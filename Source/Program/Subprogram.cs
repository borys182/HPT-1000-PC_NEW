using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Program
{
    //Struktrua zwiera dane aktualnie wykonywanego subprogramu
    public struct ActualSubprogramData
    {
        public int     WorkingTimePump;
        public int     WorkingTimeGas;
        public int     WorkingTimeHV;
        public int     WorkingTimeFlush;
        public int     WorkingTimeVent;

        public int      Pump_TargetTime;
        public double   Pump_SetpointPressure;
        public int      Vent_TargetTime;
        public int      Flush_TargetTime;
        public int      HV_Operate_Mode;
        public double   HV_Setpoint;
        public int      HV_TargetTime;
        public int      Flow1_Setpoint;
        public int      Flow1_MinFlow;
        public int      Flow1_MaxFlow;
        public int      Flow1_ShareGas;
        public int      Flow1_Devaition;
        public int      Flow2_Setpoint;
        public int      Flow2_MinFlow;
        public int      Flow2_MaxFlow;
        public int      Flow2_ShareGas;
        public int      Flow2_Devaition;
        public int      Flow3_Setpoint;
        public int      Flow3_MinFlow;
        public int      Flow3_MaxFlow;
        public int      Flow3_ShareGas;
        public int      Flow3_Devaition;
        public double   Vaporaitor_CycleTime;
        public int      Vaporaitor_Open;
        public int      GasProces_Mode;
        public int      GasProces_TimeTarget;
        public double   GasProces_Setpoint;
        public double   GasProces_MaxDiffer;
        public double   GasProces_MinDiffer;
        
        public ActualSubprogramData(int A)
        {
            WorkingTimePump     = 0;
            WorkingTimeGas      = 0;
            WorkingTimeHV       = 0;
            WorkingTimeFlush    = 0;
            WorkingTimeVent     = 0;

            Pump_TargetTime     = 0;
            Pump_SetpointPressure = 0;
            Vent_TargetTime     = 0;
            Flush_TargetTime    = 0;
            HV_Operate_Mode     = 0;
            HV_Setpoint         = 0;
            HV_TargetTime       = 0;
            Flow1_Setpoint      = 0;
            Flow1_MinFlow       = 0;
            Flow1_MaxFlow       = 0;
            Flow1_ShareGas      = 0;
            Flow1_Devaition     = 0;
            Flow2_Setpoint      = 0;
            Flow2_MinFlow       = 0;
            Flow2_MaxFlow       = 0;
            Flow2_ShareGas      = 0;
            Flow2_Devaition     = 0;
            Flow3_Setpoint      = 0;
            Flow3_MinFlow       =  0;
            Flow3_MaxFlow       = 0;
            Flow3_ShareGas      = 0;
            Flow3_Devaition     = 0;
            Vaporaitor_CycleTime = 0;
            Vaporaitor_Open     = 0;
            GasProces_Mode      = 0;
            GasProces_TimeTarget = 0;
            GasProces_Setpoint  = 0;
            GasProces_MaxDiffer = 0;
            GasProces_MinDiffer = 0;
        }
    };

    public class Subprogram : Object
    {
        private uint                    stepNo  = 0;
        private string                  name    = "No name";
        private Types.StatusSubprogram  status  = Types.StatusSubprogram.Wait;

        private int actualSubprogram; //Dane aktualnie wykonywanego programu

        private ProcesObject[] stepObjects = new ProcesObject[5]; //Każdy segment może się składać max z 5 procesow (tyle mamy obiektow procesow)

        public Subprogram(uint aId)
        {
            stepObjects[0] = new PumpProces();
            stepObjects[1] = new GasProces();
            stepObjects[2] = new PlasmaProces();
            stepObjects[3] = new FlushProces();
            stepObjects[4] = new VentProces();
           
            stepNo = aId;

        }

        //Funkcja zwraca tablice danych segmentu przygotowana zgodnie z segmentem po stronie PLC
        public int[] GetPLCSegmentData()
        {
            int[] aData = new int[Types.SEGMENT_SIZE];

            for (int i = 0; i < stepObjects.Length; i++)
                stepObjects[i].PrepareDataPLC(aData);


            return aData;
        } 

        public PumpProces GetPumpProces()
        {
            return (PumpProces)stepObjects[0];
        }
        public GasProces GetGasProces()
        {
            return (GasProces)stepObjects[1];
        }
        public PlasmaProces GetPlasmaProces()
        {
            return (PlasmaProces)stepObjects[2];
        }
        public FlushProces GetPurgeProces()
        {
            return (FlushProces)stepObjects[3];
        }
        public VentProces GetVentProces()
        {
            return (VentProces)stepObjects[4];
        }

        public uint GetStepNo()
        {
            return stepNo;
        }
        public void SetName(string aName)
        {
            name = aName;
        }
        public string GetName()
        {
            return name;
        }

        public override string ToString()
        {
            return GetName();
        }
    }
}
