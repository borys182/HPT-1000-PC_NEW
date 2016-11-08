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
            enum Index { CMD = 0, FLOW = 1, MIN_FLOW = 2, MAX_FLOW = 3, SHARE = 4, DEVIATION = 5};

            private int     id;
            public bool     Active;
            public int      GasFlow;        //wartosc w procenatch na jaka nalezy otworzyc dany zawor
            public int      MinGasFlow;     //min przeplyw gazu - po jego przekroczeniu zglaszaj blad
            public int      MaxGasFlow;     //max przeplyw gazu - po jego przekroczeniu zglaszaj blad
            public int      ShareGas;       //zmienna okresla udzial daneg gazu w kontrli prozni podczas uzywania gazów do kontrli zadanej prozni z udzialem regulatora PID
            public int      MaxDeviation;   //max odchylenie od zadanej wartosci udzialu danego gazu w procesie utrzymywania zadanej prozni w komorze
            public int      GasLimitDown;   //min przeplyw jaki moze byc uzyskany przez przeplywke
            public int      GasLimitUp;     //max przeplyw jaki moze byc uzyskany przez przeplywke
            public Types.GasProcesMode Mode;
            private int[,] addresses;  

            //---------------------------------------------------------------------------------------------------------------
            public FlowMeter(int aId)
            {
                id              = aId;
                Active          = false;
                GasFlow         = 0;
                MinGasFlow      = 10;
                MaxGasFlow      = 300;
                ShareGas        = 0;
                MaxDeviation    = 0;
                GasLimitDown    = 5;
                GasLimitUp      = 2000;
                Mode            = Types.GasProcesMode.Unknown;

                addresses       = new int[3,6];
                InitAddresses(); 
            }
            //---------------------------------------------------------------------------------------------------------------
            public void UpdateData(SubprogramData aSubprogramData)
            {
                if (aSubprogramData.tabMFC.Length > id)
                {
                    Active       = aSubprogramData.tabMFC[id].Active;
                    GasFlow      = aSubprogramData.tabMFC[id].Flow;
                    MinGasFlow   = aSubprogramData.tabMFC[id].MinFlow;
                    MaxGasFlow   = aSubprogramData.tabMFC[id].MaxFlow;
                    ShareGas     = aSubprogramData.tabMFC[id].ShareGas;
                    MaxDeviation = aSubprogramData.tabMFC[id].Devaition;
                }
            }
            //---------------------------------------------------------------------------------------------------------------
            public void PrepareData(int[] aData)
            {
                int aPow = 0;
                if (id == 0) aPow = Types.BIT_CMD_FLOW_1;
                if (id == 1) aPow = Types.BIT_CMD_FLOW_2;
                if (id == 2) aPow = Types.BIT_CMD_FLOW_3;

                if (id < (addresses.Length / 6) && Active)
                {
                    if (Mode == Types.GasProcesMode.FlowSP)
                    {
                        aData[addresses[id, (int)Index.CMD]]     |= (int)System.Math.Pow(2, aPow);
                        aData[addresses[id, (int)Index.FLOW]]     = GasFlow;
                        aData[addresses[id, (int)Index.MIN_FLOW]] = MinGasFlow;
                        aData[addresses[id, (int)Index.MAX_FLOW]] = MaxGasFlow;
                    }
                    else
                    {
                        aData[addresses[id, (int)Index.SHARE]] = ShareGas;
                        aData[addresses[id, (int)Index.DEVIATION]] = MaxDeviation;
                    }
                }
            }
            //---------------------------------------------------------------------------------------------------------------
            private void InitAddresses()
            {
                addresses[0,(int)Index.CMD]        = Types.OFFSET_SEQ_CMD;
                addresses[0,(int)Index.FLOW]       = Types.OFFSET_SEQ_FLOW_1_FLOW;
                addresses[0,(int)Index.MIN_FLOW]   = Types.OFFSET_SEQ_FLOW_1_MIN_FLOW;
                addresses[0,(int)Index.MAX_FLOW]   = Types.OFFSET_SEQ_FLOW_1_MAX_FLOW;
                addresses[0,(int)Index.SHARE]      = Types.OFFSET_SEQ_FLOW_1_SHARE;
                addresses[0,(int)Index.DEVIATION]  = Types.OFFSET_SEQ_FLOW_1_DEVIATION;

                addresses[1,(int)Index.CMD]        = Types.OFFSET_SEQ_CMD;
                addresses[1,(int)Index.FLOW]       = Types.OFFSET_SEQ_FLOW_2_FLOW;
                addresses[1,(int)Index.MIN_FLOW]   = Types.OFFSET_SEQ_FLOW_2_MIN_FLOW;
                addresses[1,(int)Index.MAX_FLOW]   = Types.OFFSET_SEQ_FLOW_2_MAX_FLOW;
                addresses[1,(int)Index.SHARE]      = Types.OFFSET_SEQ_FLOW_2_SHARE;
                addresses[1,(int)Index.DEVIATION]  = Types.OFFSET_SEQ_FLOW_2_DEVIATION;

                addresses[2,(int)Index.CMD]        = Types.OFFSET_SEQ_CMD;
                addresses[2,(int)Index.FLOW]       = Types.OFFSET_SEQ_FLOW_3_FLOW;
                addresses[2,(int)Index.MIN_FLOW]   = Types.OFFSET_SEQ_FLOW_3_MIN_FLOW;
                addresses[2,(int)Index.MAX_FLOW]   = Types.OFFSET_SEQ_FLOW_3_MAX_FLOW;
                addresses[2,(int)Index.SHARE]      = Types.OFFSET_SEQ_FLOW_3_SHARE;
                addresses[2,(int)Index.DEVIATION]  = Types.OFFSET_SEQ_FLOW_3_DEVIATION;

            }
            //---------------------------------------------------------------------------------------------------------------
        };

        private Types.GasProcesMode modeGasProces       = Types.GasProcesMode.FlowSP;
        private DateTime            timeDurationProces  ; //[s]
        //sterowanie przeplywakami
        private FlowMeter[]         tabFlow             = new FlowMeter[3];
        //sterowanie vaporatorem
        private bool                activeVaporaitor    = false;
        private double              cycleTimeVaporaito  = 0;
        private int                 onTimeVaporaitor    = 0;    //procentowe okreslenie jak dlugo ma byc otwarty zawor vaporatiora podczas cyklu
        //utrzymywanie zadanej prozni
        private double setpointPressure = 0;
        private double minDeviationSP   = 0;
        private double maxDeviationSP   = 0;

        int[]           tabOrderEditGasShareChannel    = new int[3];
        int             curentIndex = 0;   //indeks aktulnie wykonywanej akcji edycji ShareGas (indeks tablicy)
        //---------------------------------------------------------------------------------------------------------------
        public GasProces()
        {
            timeDurationProces = DateTime.Now;
            timeDurationProces = timeDurationProces.AddHours(-DateTime.Now.Hour);
            timeDurationProces = timeDurationProces.AddMinutes(-DateTime.Now.Minute);
            timeDurationProces = timeDurationProces.AddSeconds(-DateTime.Now.Second);

            tabFlow[0] = new FlowMeter(0);
            tabFlow[1] = new FlowMeter(1);
            tabFlow[2] = new FlowMeter(2);

            tabOrderEditGasShareChannel[0] = -1;
            tabOrderEditGasShareChannel[1] = -1;
            tabOrderEditGasShareChannel[2] = -1;
        }
        //---------------------------------------------------------------------------------------------------------------
        public override void UpdateData(SubprogramData aSubprogramData)
        {
            timeWorking         = ConvertDate(aSubprogramData.WorkingTimeGas);
            timeDurationProces  = ConvertDate(aSubprogramData.GasProces_TimeTarget);

            modeGasProces = (Types.GasProcesMode)aSubprogramData.GasProces_Mode;

            cycleTimeVaporaito = aSubprogramData.Vaporaitor_CycleTime;
            onTimeVaporaitor   = aSubprogramData.Vaporaitor_Open;
            setpointPressure   = aSubprogramData.GasProces_Setpoint;
            minDeviationSP     = aSubprogramData.GasProces_MinDiffer;
            maxDeviationSP     = aSubprogramData.GasProces_MaxDiffer;

            activeVaporaitor   = IsBitActive(aSubprogramData.Command, Types.BIT_CMD_FLOW_4);
            
            for (int i = 0; i < tabFlow.Length; i++)
                tabFlow[i].UpdateData(aSubprogramData);

            if (tabFlow[0].Active || tabFlow[1].Active || tabFlow[2].Active || activeVaporaitor)
                active = true;
            else
                active = false;
        }
        //---------------------------------------------------------------------------------------------------------------
        override public void PrepareDataPLC(int[] aData)
        {

            aData[Types.OFFSET_SEQ_GAS_MODE] = (int)modeGasProces;
            aData[Types.OFFSET_SEQ_GAS_TIME] = timeDurationProces.Hour * 3600 + timeDurationProces.Minute * 60 + timeDurationProces.Second;

            for (int i = 0; i < tabFlow.Length; i++)
                tabFlow[i].PrepareData(aData);

            if (activeVaporaitor)
            {
                aData[Types.OFFSET_SEQ_CMD]                    |= (int)System.Math.Pow(2, Types.BIT_CMD_FLOW_4);
                aData[Types.OFFSET_SEQ_FLOW_4_CYCLE_TIME]       = Types.ConvertDOUBLEToWORD(cycleTimeVaporaito, Types.Word.LOW);
                aData[Types.OFFSET_SEQ_FLOW_4_CYCLE_TIME + 1]   = Types.ConvertDOUBLEToWORD(cycleTimeVaporaito, Types.Word.HIGH);
                aData[Types.OFFSET_SEQ_FLOW_4_ON_TIME]          = Types.ConvertDOUBLEToWORD(onTimeVaporaitor, Types.Word.LOW);
                aData[Types.OFFSET_SEQ_FLOW_4_ON_TIME + 1]      = Types.ConvertDOUBLEToWORD(onTimeVaporaitor, Types.Word.HIGH); 
            }

            if (modeGasProces == Types.GasProcesMode.Pressure_Vap || modeGasProces == Types.GasProcesMode.Presure_MFC)
            {
                aData[Types.OFFSET_SEQ_GAS_SETPOINT]        = Types.ConvertDOUBLEToWORD(setpointPressure, Types.Word.LOW);
                aData[Types.OFFSET_SEQ_GAS_SETPOINT + 1]    = Types.ConvertDOUBLEToWORD(setpointPressure, Types.Word.HIGH);

                aData[Types.OFFSET_SEQ_GAS_DOWN_DIFFER]     = Types.ConvertDOUBLEToWORD(minDeviationSP, Types.Word.LOW);
                aData[Types.OFFSET_SEQ_GAS_DOWN_DIFFER + 1] = Types.ConvertDOUBLEToWORD(minDeviationSP, Types.Word.HIGH);

                aData[Types.OFFSET_SEQ_GAS_UP_DIFFER]       = Types.ConvertDOUBLEToWORD(maxDeviationSP, Types.Word.LOW);
                aData[Types.OFFSET_SEQ_GAS_UP_DIFFER + 1]   = Types.ConvertDOUBLEToWORD(maxDeviationSP, Types.Word.HIGH);
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetActiveFlow(bool aActive, int AFlowNo)
        {
            if (AFlowNo == 1) tabFlow[0].Active = aActive;
            if (AFlowNo == 2) tabFlow[1].Active = aActive;
            if (AFlowNo == 3) tabFlow[2].Active = aActive;
            if (AFlowNo == 4) activeVaporaitor  = aActive;

            //ustaw z automatu SahreGas dla danej liczby aktywnych kanalow. Jezeli jest 1 to 100 jezeli sa dwa to suma daje 100
            int aCountActiveFlow = 0;
            for(int i = 0; i < tabFlow.Length; i++)
            {
                if (tabFlow[i].Active)
                    aCountActiveFlow++;
            }
            //Ustaw ShareGas aby suma aktywnych kanalow byla 100
            int aValue = 0;
            if (aCountActiveFlow > 0)
                aValue = 100 / aCountActiveFlow;

            for (int i = 0; i < tabFlow.Length; i++)
            {
                if (tabFlow[i].Active)
                    tabFlow[i].ShareGas = aValue;
                else
                    tabFlow[i].ShareGas = 0;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        public bool GetActiveFlow(int AFlowNo)
        {
            bool aActive = false;

            if (AFlowNo == 1) aActive = tabFlow[0].Active;
            if (AFlowNo == 2) aActive = tabFlow[1].Active;
            if (AFlowNo == 3) aActive = tabFlow[2].Active;
            if (AFlowNo == 4) aActive = activeVaporaitor;

            return aActive;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetGasFlow(double aFlow,Types.UnitFlow aUnit, int aFlowNo)
        {
            int aGasFlow = 0; //[sccm]

            if(aUnit == Types.UnitFlow.sccm)
                aGasFlow = (int)aFlow;

            if (aUnit == Types.UnitFlow.percent)
            {
                // TO DO - przelicz % na sccm 
            }
            if (aFlowNo == 1) tabFlow[0].GasFlow = aGasFlow;
            if (aFlowNo == 2) tabFlow[1].GasFlow = aGasFlow;
            if (aFlowNo == 3) tabFlow[2].GasFlow = aGasFlow;
        }
        //---------------------------------------------------------------------------------------------------------------
        public double GetGasFlow(Types.UnitFlow aUnit, int aFlowNo)
        {
            int     aFlow     = 0;
            double  aGasFlow  = 0;

            if (aFlowNo == 1) aFlow = tabFlow[0].GasFlow;
            if (aFlowNo == 2) aFlow = tabFlow[1].GasFlow;
            if (aFlowNo == 3) aFlow = tabFlow[2].GasFlow;

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
        //---------------------------------------------------------------------------------------------------------------
        public void SetTimeProcesDuration(DateTime aTimeProces)
        {
            timeDurationProces = aTimeProces;
        }
        //---------------------------------------------------------------------------------------------------------------
        public DateTime GetTimeProcesDuration()
        {
            return timeDurationProces;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetCycleTime(double aTime)
        {
            cycleTimeVaporaito = aTime;
        }
        //---------------------------------------------------------------------------------------------------------------
        public double GetCycleTime()
        {
            return cycleTimeVaporaito;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetOnTime(int aTime)
        {
            onTimeVaporaitor = aTime;
        }
        //---------------------------------------------------------------------------------------------------------------
        public int GetOnTime()
        {
            return onTimeVaporaitor;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetMinGasFlow(int aMinFlow, int aFlowNo)
        {
            if (aFlowNo == 1) tabFlow[0].MinGasFlow = aMinFlow;
            if (aFlowNo == 2) tabFlow[1].MinGasFlow = aMinFlow;
            if (aFlowNo == 3) tabFlow[2].MinGasFlow = aMinFlow;
        }
        //---------------------------------------------------------------------------------------------------------------
        public double GetMinGasFlow(int aFlowNo)
        {
            int aMinFlow = 0;

            if (aFlowNo == 1) aMinFlow = tabFlow[0].MinGasFlow;
            if (aFlowNo == 2) aMinFlow = tabFlow[1].MinGasFlow;
            if (aFlowNo == 3) aMinFlow = tabFlow[2].MinGasFlow;

            return aMinFlow;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetMaxGasFlow(int aMaxFlow, int aFlowNo)
        {
            if (aFlowNo == 1) tabFlow[0].MaxGasFlow = aMaxFlow;
            if (aFlowNo == 2) tabFlow[1].MaxGasFlow = aMaxFlow;
            if (aFlowNo == 3) tabFlow[2].MaxGasFlow = aMaxFlow;
        }
        //---------------------------------------------------------------------------------------------------------------
        public double GetMaxGasFlow(int aFlowNo)
        {
            int aMaxFlow = 0;

            if (aFlowNo == 1) aMaxFlow = tabFlow[0].MaxGasFlow;
            if (aFlowNo == 2) aMaxFlow = tabFlow[1].MaxGasFlow;
            if (aFlowNo == 3) aMaxFlow = tabFlow[2].MaxGasFlow;

            return aMaxFlow;
        }
        //---------------------------------------------------------------------------------------------------------------
        //Ustaw dzielenie gazow ale pameitaj ze suma aktywnych kanalow mus byc 100 dlatego z autoamtu uzupelniam pozostale aktywne kanly.
        public void SetShareGas(int aShareGas, int aFlowNo)
        {
            //Ustaw/nadpisz wartosc wynikajacam ze suma aktywnych kanalow musi byc 100
            //Oblicz ile jest aktynych kanalow
            int aCountActiveChannels = 0;
            for (int i = 0; i < tabFlow.Length; i++)
            {
                if (tabFlow[i].Active)
                    aCountActiveChannels++;
            }
            //aktywny tylko jeden kanal to ustaw z automatu 100
            if (aCountActiveChannels == 1)
                aShareGas = 100;

            //aktywne sa dwa kanaly to dostosuj ten drugi do aktulnej wartosci aby suma byla 100
            if (aCountActiveChannels == 2)
            {
                for (int i = 0; i < tabFlow.Length; i++)
                {
                    if (tabFlow[i].Active && i != aFlowNo - 1)
                        tabFlow[i].ShareGas = 100 - aShareGas;
                }
            }
            
            //Ustaw wartosc wynikajacam z funkcji - musi to byc za 1 i 2 a przed 3
            if (aFlowNo == 1) tabFlow[0].ShareGas = aShareGas;
            if (aFlowNo == 2) tabFlow[1].ShareGas = aShareGas;
            if (aFlowNo == 3) tabFlow[2].ShareGas = aShareGas;

            aFlowNo--;//dostosowabie zmiennej do indeksu tablicy

            //
            
            //aktywne sa trzy kanaly to dopelnij do 100 przedostatnio edytowany kanal biorac pod uwage sume dwoch wczesniej edytowanych kanalow
            int aTmp = 0;
            int aLastShareGasEditChannel = GetLastEditGasShareChannel();
            if (aCountActiveChannels == 3)
            {
                for (int i = 0; i < tabFlow.Length; i++)
                {
                    if ( i != aLastShareGasEditChannel)
                        aTmp += tabFlow[i].ShareGas;
                }
                if (aLastShareGasEditChannel >= 0 && aLastShareGasEditChannel < tabFlow.Length)
                {
                    int aValue = 100 - aTmp;
                    if (aValue >= 0)
                        tabFlow[aLastShareGasEditChannel].ShareGas = aValue;
                    else
                    {
                        //Suma kanalow jest wieksza od 100 dlatego jednemu ustawiam na 0 a drugi dopelniam do 100
                        for (int i = 0; i < tabFlow.Length; i++)
                            if (i != aFlowNo && i != aLastShareGasEditChannel)
                                tabFlow[i].ShareGas += aValue; //defacto odejmuje poniewaz wartosc aValue jest ujemna
                        tabFlow[aLastShareGasEditChannel].ShareGas = 0;
                    }
                }
            }
            //Zapamietaj kolwjnosc edycji ktora byla wykonana aby pozniej wiedziec dla ktorego kanalu mam manewrowac wartoscia dopelninia do 100 - ostatni ktroy byl edytowany
            if (curentIndex >= 0 && curentIndex < tabOrderEditGasShareChannel.Length)
            {
                if (IfNewAction(aFlowNo))
                {
                    tabOrderEditGasShareChannel[curentIndex] = aFlowNo;
                    curentIndex++;
                }
            }
            //Przekrecenie sie licznka ustaw od 0
            if (curentIndex >= tabOrderEditGasShareChannel.Length)
                curentIndex = 0;
        }
        //---------------------------------------------------------------------------------------------------------------
        private bool IfNewAction(int aFlowNo)
        {
            bool aRes = false;
            int aIndex = curentIndex - 1;

            if (aIndex < 0)
                aIndex = tabOrderEditGasShareChannel.Length - 1;

            if (aIndex >= 0 && aIndex < tabOrderEditGasShareChannel.Length && tabOrderEditGasShareChannel[aIndex] != aFlowNo)
                aRes = true;

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------
        private int GetLastEditGasShareChannel()
        {
            int aLastChannel = 0;

            if (curentIndex == 0) aLastChannel = tabOrderEditGasShareChannel[1];
            if (curentIndex == 1) aLastChannel = tabOrderEditGasShareChannel[2];
            if (curentIndex == 2) aLastChannel = tabOrderEditGasShareChannel[0];

            if (aLastChannel == -1)
            {
                aLastChannel = curentIndex + 1;
                if (aLastChannel >= tabOrderEditGasShareChannel.Length)
                    aLastChannel = 0;
            }

            return aLastChannel;
        }
        //---------------------------------------------------------------------------------------------------------------
        public double GetShareGas(int aFlowNo)
        {
            int aShareGas = 0;

            if (aFlowNo == 1) aShareGas = tabFlow[0].ShareGas;
            if (aFlowNo == 2) aShareGas = tabFlow[1].ShareGas;
            if (aFlowNo == 3) aShareGas = tabFlow[2].ShareGas;

            return aShareGas;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetShareDevaition(int aDevaition, int aFlowNo)
        {
            if (aFlowNo == 1) tabFlow[0].MaxDeviation = aDevaition;
            if (aFlowNo == 2) tabFlow[1].MaxDeviation = aDevaition;
            if (aFlowNo == 3) tabFlow[2].MaxDeviation = aDevaition;
        }
        //---------------------------------------------------------------------------------------------------------------
        public double GetShareDevaition(int aFlowNo)
        {
            int aDevaition = 0;

            if (aFlowNo == 1) aDevaition = tabFlow[0].MaxDeviation;
            if (aFlowNo == 2) aDevaition = tabFlow[1].MaxDeviation;
            if (aFlowNo == 3) aDevaition = tabFlow[2].MaxDeviation;

            return aDevaition;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetModeProces(Types.GasProcesMode aModeProces)
        {
            modeGasProces = aModeProces;
            for (int i = 0; i < tabFlow.Length; i++)
                tabFlow[i].Mode = aModeProces;
        }
        //---------------------------------------------------------------------------------------------------------------
        public Types.GasProcesMode GetModeProces()
        {
            return modeGasProces;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetMinDeviationPresure(double aDev)
        {
            minDeviationSP = aDev;
        }
        //---------------------------------------------------------------------------------------------------------------
        public double GetMinDeviationPresure()
        {
            return minDeviationSP;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetMaxDeviationPresure(double aDev)
        {
            maxDeviationSP = aDev;
        }
        //---------------------------------------------------------------------------------------------------------------
        public double GetMaxDeviationPresure()
        {
            return maxDeviationSP;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetSetpointPressure(double aSetpoint)
        {
            setpointPressure = aSetpoint;
        }
        //---------------------------------------------------------------------------------------------------------------
        public double GetSetpointPressure()
        {
            return setpointPressure;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetLimitDown(int aLimitDown, int aFlowNo)
        {
            if (aFlowNo == 1) tabFlow[0].GasLimitDown = aLimitDown;
            if (aFlowNo == 2) tabFlow[1].GasLimitDown = aLimitDown;
            if (aFlowNo == 3) tabFlow[2].GasLimitDown = aLimitDown;
        }
        //---------------------------------------------------------------------------------------------------------------
        public int GetLimitDown(int aFlowNo)
        {
            int aLimitDown = 0;

            if (aFlowNo == 1) aLimitDown = tabFlow[0].GasLimitDown;
            if (aFlowNo == 2) aLimitDown = tabFlow[1].GasLimitDown;
            if (aFlowNo == 3) aLimitDown = tabFlow[2].GasLimitDown;

            return aLimitDown;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetLimitUp(int aLimitUp, int aFlowNo)
        {
            if (aFlowNo == 1) tabFlow[0].GasLimitUp = aLimitUp;
            if (aFlowNo == 2) tabFlow[1].GasLimitUp = aLimitUp;
            if (aFlowNo == 3) tabFlow[2].GasLimitUp = aLimitUp;
        }
        //---------------------------------------------------------------------------------------------------------------
        public int GetLimitUp(int aFlowNo)
        {
            int aLimitUp = 0;

            if (aFlowNo == 1) aLimitUp = tabFlow[0].GasLimitUp;
            if (aFlowNo == 2) aLimitUp = tabFlow[1].GasLimitUp;
            if (aFlowNo == 3) aLimitUp = tabFlow[2].GasLimitUp;

            return aLimitUp;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetVaporaiserActive(bool aValue)
        {
            activeVaporaitor = aValue;
        }
        //---------------------------------------------------------------------------------------------------------------
        public bool GetVaporiserActive()
        {
            return activeVaporaitor;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
