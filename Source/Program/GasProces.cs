using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Program
{
    /*Klasa zawiera dane potrzebne do sterowania procesem gazow w komorze. Gazami mozemy sterowac na 3 sposoby
        1 - utrzymywahie zadanej prozni przez przeplywki
        2 - utrzymywanie zadanej prozni przez vaporatior
        3 - sterowanie przeplywem zgodnie z ustalonymi przeplywami
    */
    public class GasProces : ProcesObject
    {
        public struct FlowMeter
        {
            public bool     active;
            public int      gasFlow;        //wartosc w procenatch na jaka nalezy otworzyc dany zawor
            public int      minGasFLow;     //min przeplyw gazu - po jego przekroczeniu zglaszaj blad
            public int      maxGasFLow;     //max przeplyw gazu - po jego przekroczeniu zglaszaj blad
            public int      shareGas;       //zmienna okresla udzial daneg gazu w kontrli prozni podczas uzywania gazów do kontrli zadanej prozni z udzialem regulatora PID
            public int      maxDeviation;   //max odchylenie od zadanej wartosci udzialu danego gazu w procesie utrzymywania zadanej prozni w komorze
            public int      gasLimitDown;   //min przeplyw jaki moze byc uzyskany przez przeplywke
            public int      gasLimitUp;     //max przeplyw jaki moze byc uzyskany przez przeplywke

            public FlowMeter(int aDiffer)
            {
                active          = false;
                gasFlow         = 0;
                minGasFLow      = 10;
                maxGasFLow      = 300;
                shareGas        = 0;
                maxDeviation    = 0;
                gasLimitDown    = 5;
                gasLimitUp =     2000;
            }
        };

        private Types.GasProcesMode modeGasProces       = Types.GasProcesMode.FlowSP;
        private DateTime            timeDurationProces  ; //[s]
        //sterowanie przeplywakami
        private FlowMeter[]         tabFlow = new FlowMeter[3];
        //sterowanie vaporatorem
        private bool                activeVaporaitor   = false;
        private double              cycleTimeVaporaito = 0;
        private int                 onTimeVaporaitor   = 0;    //procentowe okreslenie jak dlugo ma byc otwarty zawor vaporatiora podczas cyklu
        //utrzymywanie zadanej prozni
        private double setpointPressure = 0;
        private double minDeviationSP   = 0;
        private double maxDeviationSP   = 0;

        public GasProces()
        {
            timeDurationProces = DateTime.Now;
            timeDurationProces = timeDurationProces.AddHours(-DateTime.Now.Hour);
            timeDurationProces = timeDurationProces.AddMinutes(-DateTime.Now.Minute);
            timeDurationProces = timeDurationProces.AddSeconds(-DateTime.Now.Second);

            tabFlow[0] = new FlowMeter(0);
            tabFlow[1] = new FlowMeter(0);
            tabFlow[2] = new FlowMeter(0);
        }

        override public void PrepareDataPLC(int[] aData)
        {
            if (tabFlow[0].active)
            {
                aData[Types.BIT_CMD_FLOW_1]                 |= (int)System.Math.Pow(2, Types.BIT_CMD_FLOW_1);
                aData[Types.OFFSET_SEQ_FLOW_1_FLOW]         = tabFlow[0].gasFlow;
                aData[Types.OFFSET_SEQ_FLOW_1_MIN_FLOW]     = tabFlow[0].minGasFLow;
                aData[Types.OFFSET_SEQ_FLOW_1_MAX_FLOW]     = tabFlow[0].maxGasFLow;
                aData[Types.OFFSET_SEQ_FLOW_1_SHARE]        = tabFlow[0].shareGas;
                aData[Types.OFFSET_SEQ_FLOW_1_DEVIATION]    = tabFlow[0].maxDeviation;

            }
            if (tabFlow[1].active)
            {
                aData[Types.BIT_CMD_FLOW_2]                 |= (int)System.Math.Pow(2, Types.BIT_CMD_FLOW_2);
                aData[Types.OFFSET_SEQ_FLOW_2_FLOW]         = tabFlow[1].gasFlow;
                aData[Types.OFFSET_SEQ_FLOW_2_MIN_FLOW]     = tabFlow[1].minGasFLow;
                aData[Types.OFFSET_SEQ_FLOW_2_MAX_FLOW]     = tabFlow[1].maxGasFLow;
                aData[Types.OFFSET_SEQ_FLOW_2_SHARE]        = tabFlow[1].shareGas;
                aData[Types.OFFSET_SEQ_FLOW_2_DEVIATION]    = tabFlow[1].maxDeviation;
            }
            if (tabFlow[2].active)
            {
                aData[Types.BIT_CMD_FLOW_3]                 |= (int)System.Math.Pow(2, Types.BIT_CMD_FLOW_3);
                aData[Types.OFFSET_SEQ_FLOW_3_FLOW]         = tabFlow[0].gasFlow;
                aData[Types.OFFSET_SEQ_FLOW_3_MIN_FLOW]     = tabFlow[2].minGasFLow;
                aData[Types.OFFSET_SEQ_FLOW_3_MAX_FLOW]     = tabFlow[2].maxGasFLow;
                aData[Types.OFFSET_SEQ_FLOW_3_SHARE]        = tabFlow[2].shareGas;
                aData[Types.OFFSET_SEQ_FLOW_3_DEVIATION]    = tabFlow[2].maxDeviation; ;
            }
            if (activeVaporaitor)
            {
                aData[Types.BIT_CMD_FLOW_4]                     |= (int)System.Math.Pow(2, Types.BIT_CMD_FLOW_4);
                aData[Types.OFFSET_SEQ_FLOW_4_CYCLE_TIME]       = Types.ConvertDOUBLEToInt(cycleTimeVaporaito, Types.Word.HIGH);
                aData[Types.OFFSET_SEQ_FLOW_4_CYCLE_TIME + 1]   = Types.ConvertDOUBLEToInt(cycleTimeVaporaito, Types.Word.LOW);
                aData[Types.OFFSET_SEQ_FLOW_4_ON_TIME]          = onTimeVaporaitor;
            }

            aData[Types.OFFSET_SEQ_GAS_MODE]        = (int)modeGasProces;
            aData[Types.OFFSET_SEQ_GAS_TIME]        = timeDurationProces.Hour * 3600 + timeDurationProces.Minute * 60 + timeDurationProces.Second;
            aData[Types.OFFSET_SEQ_GAS_SETPOINT]    = Types.ConvertDOUBLEToInt(setpointPressure, Types.Word.HIGH);
            aData[Types.OFFSET_SEQ_GAS_SETPOINT]    = Types.ConvertDOUBLEToInt(setpointPressure, Types.Word.LOW);

            aData[Types.OFFSET_SEQ_GAS_MIN_DIFFER]  = Types.ConvertDOUBLEToInt(minDeviationSP, Types.Word.HIGH);
            aData[Types.OFFSET_SEQ_GAS_MIN_DIFFER]  = Types.ConvertDOUBLEToInt(minDeviationSP, Types.Word.LOW);

            aData[Types.OFFSET_SEQ_GAS_MAX_DIFFER] = Types.ConvertDOUBLEToInt(maxDeviationSP, Types.Word.HIGH);
            aData[Types.OFFSET_SEQ_GAS_MAX_DIFFER] = Types.ConvertDOUBLEToInt(maxDeviationSP, Types.Word.LOW);
        }

        public void SetActiveFlow(bool aActive, int AFlowNo)
        {
            if (AFlowNo == 1) tabFlow[0].active = aActive;
            if (AFlowNo == 2) tabFlow[1].active = aActive;
            if (AFlowNo == 3) tabFlow[2].active = aActive;
            if (AFlowNo == 4) activeVaporaitor  = aActive;
        }
        public bool GetActiveFlow(int AFlowNo)
        {
            bool aActive = false;

            if (AFlowNo == 1) aActive = tabFlow[0].active;
            if (AFlowNo == 2) aActive = tabFlow[1].active;
            if (AFlowNo == 3) aActive = tabFlow[2].active;
            if (AFlowNo == 4) aActive = activeVaporaitor;

            return aActive;
        }

        public void SetGasFlow(double aFlow,Types.UnitFlow aUnit, int aFlowNo)
        {
            int aGasFlow = 0; //[sccm]

            if(aUnit == Types.UnitFlow.sccm)
                aGasFlow = (int)aFlow;

            if (aUnit == Types.UnitFlow.percent)
            {
                // TO DO - przelicz % na sccm 
            }
            if (aFlowNo == 1) tabFlow[0].gasFlow = aGasFlow;
            if (aFlowNo == 2) tabFlow[1].gasFlow = aGasFlow;
            if (aFlowNo == 3) tabFlow[2].gasFlow = aGasFlow;
        }
        public double GetGasFlow(Types.UnitFlow aUnit, int aFlowNo)
        {
            int     aFlow     = 0;
            double  aGasFlow  = 0;

            if (aFlowNo == 1) aFlow = tabFlow[0].gasFlow ;
            if (aFlowNo == 2) aFlow = tabFlow[1].gasFlow;
            if (aFlowNo == 3) aFlow = tabFlow[2].gasFlow;

            if (aUnit == Types.UnitFlow.sccm)
            {
                aGasFlow = aFlow;
            }
            if (aUnit == Types.UnitFlow.percent)
            {
                   // TO DO - przlicz % na sccm
            }        

            return aGasFlow;
        }

        public void SetTimeProcesDuration(DateTime aTimeProces)
        {
            timeDurationProces = aTimeProces;
        }
        public DateTime GetTimeProcesDuration()
        {
            return timeDurationProces;
        }

        public void SetCycleTime(double aTime)
        {
            cycleTimeVaporaito = aTime;
        }
        public double GetCycleTime()
        {
            return cycleTimeVaporaito;
        }

        public void SetOnTime(int aTime)
        {
            onTimeVaporaitor = aTime;
        }
        public int GetOnTime()
        {
            return onTimeVaporaitor;
        }

        public void SetMinGasFlow(int aMinFlow, int aFlowNo)
        {
            if (aFlowNo == 1) tabFlow[0].minGasFLow = aMinFlow;
            if (aFlowNo == 2) tabFlow[1].minGasFLow = aMinFlow;
            if (aFlowNo == 3) tabFlow[2].minGasFLow = aMinFlow;
        }
        public double GetMinGasFlow(int aFlowNo)
        {
            int aMinFlow = 0;

            if (aFlowNo == 1) aMinFlow = tabFlow[0].minGasFLow;
            if (aFlowNo == 2) aMinFlow = tabFlow[1].minGasFLow;
            if (aFlowNo == 3) aMinFlow = tabFlow[2].minGasFLow;

            return aMinFlow;
        }

        public void SetMaxGasFlow(int aMaxFlow, int aFlowNo)
        {
            if (aFlowNo == 1) tabFlow[0].maxGasFLow = aMaxFlow;
            if (aFlowNo == 2) tabFlow[1].maxGasFLow = aMaxFlow;
            if (aFlowNo == 3) tabFlow[2].maxGasFLow = aMaxFlow;
        }
        public double GetMaxGasFlow(int aFlowNo)
        {
            int aMaxFlow = 0;

            if (aFlowNo == 1) aMaxFlow = tabFlow[0].maxGasFLow;
            if (aFlowNo == 2) aMaxFlow = tabFlow[1].maxGasFLow;
            if (aFlowNo == 3) aMaxFlow = tabFlow[2].maxGasFLow;

            return aMaxFlow;
        }


        public void SetShareGas(int aShareGas, int aFlowNo)
        {
            if (aFlowNo == 1) tabFlow[0].shareGas = aShareGas;
            if (aFlowNo == 2) tabFlow[1].shareGas = aShareGas;
            if (aFlowNo == 3) tabFlow[2].shareGas = aShareGas;
        }
        public double GetShareGas(int aFlowNo)
        {
            int aShareGas = 0;

            if (aFlowNo == 1) aShareGas = tabFlow[0].shareGas;
            if (aFlowNo == 2) aShareGas = tabFlow[1].shareGas;
            if (aFlowNo == 3) aShareGas = tabFlow[2].shareGas;

            return aShareGas;
        }

        public void SetShareDevaition(int aDevaition, int aFlowNo)
        {
            if (aFlowNo == 1) tabFlow[0].maxDeviation = aDevaition;
            if (aFlowNo == 2) tabFlow[1].maxDeviation = aDevaition;
            if (aFlowNo == 3) tabFlow[2].maxDeviation = aDevaition;
        }
        public double GetShareDevaition(int aFlowNo)
        {
            int aDevaition = 0;

            if (aFlowNo == 1) aDevaition = tabFlow[0].maxDeviation;
            if (aFlowNo == 2) aDevaition = tabFlow[1].maxDeviation;
            if (aFlowNo == 3) aDevaition = tabFlow[2].maxDeviation;

            return aDevaition;
        }

        public void SetModeProces(Types.GasProcesMode aModeProces)
        {
            modeGasProces = aModeProces;
        }
        public Types.GasProcesMode GetModeProces()
        {
            return modeGasProces;
        }

        public void SetMinDeviationPresure(double aDev)
        {
            minDeviationSP = aDev;
        }
        public double GetMinDeviationPresure()
        {
            return minDeviationSP;
        }

        public void SetMaxDeviationPresure(double aDev)
        {
            maxDeviationSP = aDev;
        }
        public double GetMaxDeviationPresure()
        {
            return maxDeviationSP;
        }

        public void SetSetpointPressure(double aSetpoint)
        {
            setpointPressure = aSetpoint;
        }
        public double GetSetpointPressure()
        {
            return setpointPressure;
        }

        public void SetLimitDown(int aLimitDown, int aFlowNo)
        {
            if (aFlowNo == 1) tabFlow[0].gasLimitDown = aLimitDown;
            if (aFlowNo == 2) tabFlow[1].gasLimitDown = aLimitDown;
            if (aFlowNo == 3) tabFlow[2].gasLimitDown = aLimitDown;
        }
        public int GetLimitDown(int aFlowNo)
        {
            int aLimitDown = 0;

            if (aFlowNo == 1) aLimitDown = 10;// tabFlow[0].gasLimitDown;
            if (aFlowNo == 2) aLimitDown = 20;// tabFlow[1].gasLimitDown;
            if (aFlowNo == 3) aLimitDown = 30;// tabFlow[2].gasLimitDown;

            return aLimitDown;
        }

        public void SetLimitUp(int aLimitUp, int aFlowNo)
        {
            if (aFlowNo == 1) tabFlow[0].gasLimitUp = aLimitUp;
            if (aFlowNo == 2) tabFlow[1].gasLimitUp = aLimitUp;
            if (aFlowNo == 3) tabFlow[2].gasLimitUp = aLimitUp;
        }
        public int GetLimitUp(int aFlowNo)
        {
            int aLimitUp = 0;

            if (aFlowNo == 1) aLimitUp = 100;// tabFlow[0].gasLimitUp;
            if (aFlowNo == 2) aLimitUp = 200;// tabFlow[1].gasLimitUp;
            if (aFlowNo == 3) aLimitUp = 300;// tabFlow[2].gasLimitUp;

            return aLimitUp;
        }

        public void SetVaporaiserActive(bool aValue)
        {
            activeVaporaitor = aValue;
        }
        public bool GetVaporiserActive()
        {
            return activeVaporaitor;
        }
    }
}
