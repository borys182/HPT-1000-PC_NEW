using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Program
{
    public class Program : Object
    { 
        //Dane odczytane z PLC
        private Types.StatusSubprogram  status               = Types.StatusSubprogram.Wait;
        private int                     countSubprograms     = 0;        //liczba subprogramow z ktorych sie skalada program wczytny do PLC
        private int                     actualSubprogramNo   = 0;        //numer aktualnie wykonywanego subprogramu
        private ActualSubprogramData    actualSubprogramData = new ActualSubprogramData();

        //Dane potrzebne do konfigruacji na PC
        private PLC                 plc         = null;
        private string              name        = "No name";
        private uint                id          = 0;         //unikalny identyfikator programu po ktorym rozrozniamy programy
        private List<Subprogram>    segments    = new List<Subprogram>();
        private string              description = "";

        private List<Program> programs = new List<Program>(); //Lista wszystkich programow zapisanych w aplikacji

        public Program(string aName)
        {
            name = aName;
        }
        public Program(string aName,string aDescription)
        {
            name = aName;
            description = aDescription;
        }

        //Funkcja odczytuje dane z PLC na temat aktualnie wykonywanego programu i subprogramu
        public void UpdateData(int[] aData)
        {
            status              = (Types.StatusSubprogram)aData[Types.OFFSET_PRG_STATUS];
            countSubprograms    = aData[Types.OFFSET_PRG_SEQ_COUNTS];
            actualSubprogramNo  = aData[Types.OFFSET_PRG_ACTUAL_SEQ_NO];

            //odczytaj jak dlugo sie wykonuje aktualnie dany proces w subprogramie
            actualSubprogramData.WorkingTimeFlush   = aData[Types.OFFSET_PRG_TIME_FLUSH];
            actualSubprogramData.WorkingTimeGas     = aData[Types.OFFSET_PRG_TIME_GAS];
            actualSubprogramData.WorkingTimeHV      = aData[Types.OFFSET_PRG_TIME_HV];
            actualSubprogramData.WorkingTimePump    = aData[Types.OFFSET_PRG_TIME_PUMP];
            actualSubprogramData.WorkingTimeVent    = aData[Types.OFFSET_PRG_TIME_VENT];

            int aOffset = Types.OFFSET_PRG_SEQ_DATA; //przesuniecie danych segmentu wzgledem aktualnie odczytanej przestrzeni pamieci
            actualSubprogramData.Pump_SetpointPressure  = aData[Types.OFFSET_SEQ_PUMP_SP + aOffset];
            actualSubprogramData.Pump_TargetTime        = aData[Types.OFFSET_SEQ_PUMP_MAX_TIME + aOffset];

            actualSubprogramData.Vent_TargetTime        = aData[Types.OFFSET_SEQ_VENT_TIME + aOffset];

            actualSubprogramData.Flush_TargetTime       = aData[Types.OFFSET_SEQ_FLUSH_TIME + aOffset];

            actualSubprogramData.HV_Operate_Mode        = aData[Types.OFFSET_SEQ_HV_OPERATE + aOffset];
            actualSubprogramData.HV_Setpoint            = Types.ConvertDWORDToDouble(aData, Types.OFFSET_SEQ_HV_SETPOINT + aOffset);
            actualSubprogramData.HV_TargetTime          = aData[Types.OFFSET_SEQ_HV_TIME + aOffset];

            actualSubprogramData.Flow1_Setpoint         = aData[Types.OFFSET_SEQ_FLOW_1_FLOW + aOffset];
            actualSubprogramData.Flow1_MinFlow          = aData[Types.OFFSET_SEQ_FLOW_1_MIN_FLOW + aOffset];
            actualSubprogramData.Flow1_MaxFlow          = aData[Types.OFFSET_SEQ_FLOW_1_MAX_FLOW + aOffset];
            actualSubprogramData.Flow1_ShareGas         = aData[Types.OFFSET_SEQ_FLOW_1_SHARE + aOffset];
            actualSubprogramData.Flow1_Devaition        = aData[Types.OFFSET_SEQ_FLOW_1_DEVIATION + aOffset];

            actualSubprogramData.Flow2_Setpoint         = aData[Types.OFFSET_SEQ_FLOW_2_FLOW + aOffset];
            actualSubprogramData.Flow2_MinFlow          = aData[Types.OFFSET_SEQ_FLOW_2_MIN_FLOW + aOffset];
            actualSubprogramData.Flow2_MaxFlow          = aData[Types.OFFSET_SEQ_FLOW_2_MAX_FLOW + aOffset];
            actualSubprogramData.Flow2_ShareGas         = aData[Types.OFFSET_SEQ_FLOW_2_SHARE + aOffset];
            actualSubprogramData.Flow2_Devaition        = aData[Types.OFFSET_SEQ_FLOW_2_DEVIATION + aOffset];

            actualSubprogramData.Flow3_Setpoint         = aData[Types.OFFSET_SEQ_FLOW_3_FLOW + aOffset];
            actualSubprogramData.Flow3_MinFlow          = aData[Types.OFFSET_SEQ_FLOW_3_MIN_FLOW + aOffset];
            actualSubprogramData.Flow3_MaxFlow          = aData[Types.OFFSET_SEQ_FLOW_3_MAX_FLOW + aOffset];
            actualSubprogramData.Flow3_ShareGas         = aData[Types.OFFSET_SEQ_FLOW_3_SHARE + aOffset];
            actualSubprogramData.Flow3_Devaition        = aData[Types.OFFSET_SEQ_FLOW_3_DEVIATION + aOffset];

            actualSubprogramData.GasProces_Mode         = aData[Types.OFFSET_SEQ_GAS_MODE + aOffset];
            actualSubprogramData.GasProces_Setpoint     = Types.ConvertDWORDToDouble(aData,Types.OFFSET_SEQ_GAS_SETPOINT + aOffset);
            actualSubprogramData.GasProces_MinDiffer    = Types.ConvertDWORDToDouble(aData,Types.OFFSET_SEQ_GAS_MIN_DIFFER + aOffset);
            actualSubprogramData.GasProces_MaxDiffer    = Types.ConvertDWORDToDouble(aData,Types.OFFSET_SEQ_GAS_MAX_DIFFER + aOffset);
            actualSubprogramData.GasProces_TimeTarget   = aData[Types.OFFSET_SEQ_GAS_TIME + aOffset];

            actualSubprogramData.Vaporaitor_CycleTime   = Types.ConvertDWORDToDouble(aData, Types.OFFSET_SEQ_FLOW_4_CYCLE_TIME + aOffset);
            actualSubprogramData.Vaporaitor_Open        = aData[Types.OFFSET_SEQ_FLOW_4_ON_TIME + aOffset];

        }

        public int StartProgram(int aId)
        {
            int aResult = 0;
            Program program = null;

            //Odszukaj program ktory chce uruchomic
            foreach (Program pr in programs)
            {
                if (pr.id == aId)
                {
                    program = pr;
                    break;
                }
            }
            //jezeli program zostal odnaleziony to wykonaj go
            if (program != null)
            {
                //przygotuj dane do wgrania do PLC
                int[] aData        = new int[Types.MAX_SEGMENTS];
                int[] aDataControl = new int[1];

                int   aSizeData = 0;
                for (int i = 0; i < program.segments.Count; i++)
                {
                    for(int j = 0; j < Types.SEGMENT_SIZE; j++)
                        aData[i * Types.SEGMENT_SIZE + j] = program.segments[i].GetPLCSegmentData()[j];
                }
                aSizeData = program.segments.Count * Types.SEGMENT_SIZE;
                plc.WriteWords(Types.ADDR_START_BUFFER_PROGRAM, aSizeData,aData);   //wgraj dane programu do PLC          
                plc.WriteWords(Types.ADDR_CONTROL_PROGRAM, 1, aDataControl);        //uruchom program
            }

            return aResult;
        }
        public void AddSubprogram()
        {
            Subprogram segment = new Subprogram(GetNextSegmentStepNo());
            segments.Add(segment);
        }
        public uint AddProgram(string aName,string aDescription)
        {
            Program program = new Program(aName,aDescription);
            program.id = GetUniqueProgramID();
            programs.Add(program);
            return program.GetID();
        }

        public uint GetID()
        {
            return id;
        }

        public void SetName(string aName)
        {
            name = aName;
        }
        public string GetName()
        {
            return name;
        }

        public void SetDescription(string aDescription)
        {
            description = aDescription;
        }
        public string GetDescription()
        {
            return description;
        }
        //Funkcja zwraca unikalne ID ktore jeszcze nie jest uzywane przez zaden program
        public uint GetUniqueProgramID()
        {
            uint aUniqueID = 0;
            bool aExist = false;

            for (uint i = 1; i < 1000000; i++)
            {
                foreach (Program program in programs)
                {
                    if (program.id == i)
                        aExist = true;
                }
                if(!aExist)
                {
                    aUniqueID = i;
                    break;
                }
            }  
            return aUniqueID;
        }
        public uint GetNextSegmentStepNo()
        {
            uint aStepNo = 0;
            bool aExist = false;

            for (uint i = 1; i < 1000000; i++)
            {
                foreach (Subprogram segment in segments)
                {
                    if (segment.GetStepNo() == i)
                        aExist = true;
                }
                if (!aExist)
                {
                    aStepNo = i;
                    break;
                }
            }
            return aStepNo;
        }
        public void SetPtrPLC(PLC aPLC)
        {
            plc = aPLC;
        }

        public Program GetProgram(int aId)
        {
            Program program = null;
            //Odszukaj program 
            foreach (Program pr in programs)
            {
                if (pr.id == aId)
                {
                    program = pr;
                    break;
                }
            }
            return program;

        }

        public List<Program> GetPrograms()
        {
            return programs;
        }
        public List<Subprogram> GetSubPrograms()
        {
            return segments;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
