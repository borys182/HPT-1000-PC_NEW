using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Program
{
    public delegate void RefreshProgram();
    //Struktura zawiera dane regultaroa przeplywu. Poniewaz jest ich kilka to lepiej to zgromadzic w tablicy tych samych struktur
    public struct MFCData
    {
        public bool Active;
        public int  Flow;
        public int  MinFlow;
        public int  MaxFlow;
        public int  ShareGas;
        public int  Devaition;

        public MFCData(int aDiffer)
        {
            Active    = false;
            Flow      = 0;
            MinFlow   = 0;
            MaxFlow   = 0;
            ShareGas  = 0;
            Devaition = 0;
        }
    };
    //Struktrua zwiera dane aktualnie wykonywanego subprogramu
    public struct SubprogramData
    {
        public int      WorkingTimePump;
        public int      WorkingTimeGas;
        public int      WorkingTimeHV;
        public int      WorkingTimeFlush;
        public int      WorkingTimeVent;

        public int      Command;
        public int      Status;
        public int      Pump_TargetTime;
        public double   Pump_SetpointPressure;
        public int      Vent_TargetTime;
        public int      Flush_TargetTime;
        public int      HV_Operate_Mode;
        public double   HV_Setpoint;
        public double   HV_Deviation;
        public int      HV_TargetTime;
        public double   Vaporaitor_CycleTime;
        public int      Vaporaitor_Open;
        public int      GasProces_Mode;
        public int      GasProces_TimeTarget;
        public double   GasProces_Setpoint;
        public double   GasProces_MaxDiffer;
        public double   GasProces_MinDiffer;

        public MFCData[] tabMFC;

        public SubprogramData(int A)
        {
            WorkingTimePump     = 0;
            WorkingTimeGas      = 0;
            WorkingTimeHV       = 0;
            WorkingTimeFlush    = 0;
            WorkingTimeVent     = 0;

            Command             = 0;
            Status              = 0;
            Pump_TargetTime     = 0;
            Pump_SetpointPressure = 0;
            Vent_TargetTime     = 0;
            Flush_TargetTime    = 0;
            HV_Operate_Mode     = 0;
            HV_Setpoint         = 0;
            HV_TargetTime       = 0;
            HV_Deviation        = 0;
            Vaporaitor_CycleTime = 0;
            Vaporaitor_Open     = 0;
            GasProces_Mode      = 0;
            GasProces_TimeTarget = 0;
            GasProces_Setpoint  = 0;
            GasProces_MaxDiffer = 0;
            GasProces_MinDiffer = 0;

            tabMFC = new MFCData[3];
            for (int i = 0; i < tabMFC.Length; i++)
            {
                tabMFC[i].Flow      = 0;
                tabMFC[i].MinFlow   = 0;
                tabMFC[i].MaxFlow   = 0;
                tabMFC[i].ShareGas  = 0;
                tabMFC[i].Devaition = 0;
            }
        }
    };

    public class Program : Object
    { 
        //Dane odczytane z PLC
        private Types.StatusProgram     status              = Types.StatusProgram.NoLoad;
        private int                     countSubprogramsPLC = 0;        //liczba subprogramow z ktorych sie skalada program wczytny do PLC
        private int                     actualSubprogramId  = 0;        //numer aktualnie wykonywanego subprogramu
   
        //Dane potrzebne do konfigruacji na PC
        private PLC                     plc                 = null;
        private string                  name                = "Program name";
        private uint                    id                  = 0;         //unikalny identyfikator programu po ktorym rozrozniamy programy
        private string                  description         = "";
        private List<Subprogram>        subPrograms         = new List<Subprogram>();
       // private List<Subprogram>        subProgramsActual   = new List<Subprogram>(); //Lista subprogramow ktora sluzy do akutalizacji parametrow uruchomionego procesu. 
                                                                                      //Aby nie nadpisywac parametrow zapisanych w programie tworze alternatywna liste

        private static uint             UniqueID            = 1;

        private static object           Sync                = new object();

        private static RefreshProgram   refreshProgram      = null;

        //-------------------------------------------------------------------------------------------------------------------------
        public Types.StatusProgram Status
        {
            get { return status; }
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public int CountSubprograms
        {
            get { return countSubprogramsPLC; }
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public int ActualSubprogramId
        {
            get { return actualSubprogramId; }
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public Program()
        {
            lock (Sync)
            {
                id = UniqueID;
                UniqueID++;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public override bool Equals(object other)
        {
            bool aRes = false;
            //Porownuje tylko po referencji bo w kilku miejscach sie odnosze do tej samej referencji i cos zmieniam.
            if (ReferenceEquals(this, other))// || (this.GetType() == other.GetType() && ((Program)this).id == ((Program)other).GetID()))
                aRes = true;

            return aRes;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Funkcja odczytuje dane z PLC na temat aktualnie wykonywanego subprogramu
        public void UpdateActualSubprogramData(int[] aData)
        {
            //Odczytaj dane z PLC ale tylko do programu ktroego ID pokrywa sie z tym wgranym do PLC
            int aProgramId = aData[Types.OFFSET_PRG_ACTUAL_PRG_ID];
            if (aProgramId == id)
            {
                status              = (Types.StatusProgram)aData[Types.OFFSET_PRG_STATUS];
                actualSubprogramId  = aData[Types.OFFSET_PRG_ACTUAL_SEQ_ID];
                //Poniewaz funkcja GetSegmentData pracuje na ofsetach pamieci Segmentu dlatego dane segmentu powinny sie zaczynac od krotki 0 co sie wiaze z koniecznoscia przekopiowania danych do nowej tablicy
                int[] aDataSeq = new int[Types.SEGMENT_SIZE];
                for (int i = 0; i < aData.Length; i++)
                    if (aData.Length > (i + Types.OFFSET_PRG_SEQ_DATA) && aDataSeq.Length > i)
                        aDataSeq[i] = aData[i + Types.OFFSET_PRG_SEQ_DATA];

                SubprogramData aSubprogramData      = GetSegmentData(aDataSeq, 0);

                aSubprogramData.Status              = aData[Types.OFFSET_PRG_SUBPR_STATUS];
                aSubprogramData.WorkingTimeFlush    = aData[Types.OFFSET_PRG_TIME_FLUSH];
                aSubprogramData.WorkingTimeGas      = aData[Types.OFFSET_PRG_TIME_GAS];
                aSubprogramData.WorkingTimeHV       = aData[Types.OFFSET_PRG_TIME_HV];
                aSubprogramData.WorkingTimePump     = aData[Types.OFFSET_PRG_TIME_PUMP];
                aSubprogramData.WorkingTimeVent     = aData[Types.OFFSET_PRG_TIME_VENT];

                //aktualizuj status subprogramu oraz dane w aktualnie wykonywanym subprogramie pod warunkiem ze program jest wykonywny 
                foreach (Subprogram subProgram in subPrograms )//subProgramsActual)
                {
                    //sprawdz ID subprogramu oraz status Programu
                    if (subProgram.ID == actualSubprogramId && IsRun())
                        subProgram.UpdateData(aSubprogramData);
                    subProgram.UpdateStatus(aData);
                }
            }
            else
            {
                //Ustawiam statu ze program nie jest zaladowany do PLC.
                status = Types.StatusProgram.NoLoad;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Odczytaj z tablicy danych dane subprogramu
        private SubprogramData GetSegmentData(int[] aData, uint aSubprogramNo)
        {
            SubprogramData aSubprogramData = new SubprogramData(0);
            uint aOffset = aSubprogramNo * Types.SEGMENT_SIZE; //przesuniecie danych segmentu wzgledem aktualnie odczytanej przestrzeni pamieci

            if (CheckCorectTabSize((int)(aData.Length - aOffset)))
            {        
                aSubprogramData.Command                 = aData[Types.OFFSET_SEQ_CMD              + aOffset];
                aSubprogramData.Status                  = aData[Types.OFFSET_SEQ_STATUS           + aOffset];

                aSubprogramData.Pump_SetpointPressure   = Types.ConvertDWORDToDouble(aData, (int)(Types.OFFSET_SEQ_PUMP_SP + aOffset));
                aSubprogramData.Pump_TargetTime         = aData[Types.OFFSET_SEQ_PUMP_MAX_TIME    + aOffset];

                aSubprogramData.Vent_TargetTime         = aData[Types.OFFSET_SEQ_VENT_TIME        + aOffset];

                aSubprogramData.Flush_TargetTime        = aData[Types.OFFSET_SEQ_FLUSH_TIME       + aOffset];

                aSubprogramData.HV_Operate_Mode         = aData[Types.OFFSET_SEQ_HV_OPERATE       + aOffset];
                aSubprogramData.HV_Setpoint             = Types.ConvertDWORDToDouble(aData, (int)(Types.OFFSET_SEQ_HV_SETPOINT       + aOffset));
                aSubprogramData.HV_Deviation            = Types.ConvertDWORDToDouble(aData, (int)(Types.OFFSET_SEQ_HV_DRIFT_SETPOINT + aOffset));
                aSubprogramData.HV_TargetTime           = aData[Types.OFFSET_SEQ_HV_TIME          + aOffset];

                aSubprogramData.tabMFC[0].Active        = IsBitActive(aData[Types.OFFSET_SEQ_CMD],Types.BIT_CMD_FLOW_1);
                aSubprogramData.tabMFC[0].Flow          = aData[Types.OFFSET_SEQ_FLOW_1_FLOW      + aOffset];
                aSubprogramData.tabMFC[0].MinFlow       = aData[Types.OFFSET_SEQ_FLOW_1_MIN_FLOW  + aOffset];
                aSubprogramData.tabMFC[0].MaxFlow       = aData[Types.OFFSET_SEQ_FLOW_1_MAX_FLOW  + aOffset];
                aSubprogramData.tabMFC[0].ShareGas      = aData[Types.OFFSET_SEQ_FLOW_1_SHARE     + aOffset];
                aSubprogramData.tabMFC[0].Devaition     = aData[Types.OFFSET_SEQ_FLOW_1_DEVIATION + aOffset];

                aSubprogramData.tabMFC[1].Active        = IsBitActive(aData[Types.OFFSET_SEQ_CMD], Types.BIT_CMD_FLOW_2);
                aSubprogramData.tabMFC[1].Flow          = aData[Types.OFFSET_SEQ_FLOW_2_FLOW + aOffset];
                aSubprogramData.tabMFC[1].MinFlow       = aData[Types.OFFSET_SEQ_FLOW_2_MIN_FLOW + aOffset];
                aSubprogramData.tabMFC[1].MaxFlow       = aData[Types.OFFSET_SEQ_FLOW_2_MAX_FLOW + aOffset];
                aSubprogramData.tabMFC[1].ShareGas      = aData[Types.OFFSET_SEQ_FLOW_2_SHARE + aOffset];
                aSubprogramData.tabMFC[1].Devaition     = aData[Types.OFFSET_SEQ_FLOW_2_DEVIATION + aOffset];

                aSubprogramData.tabMFC[2].Active        = IsBitActive(aData[Types.OFFSET_SEQ_CMD], Types.BIT_CMD_FLOW_3);
                aSubprogramData.tabMFC[2].Flow          = aData[Types.OFFSET_SEQ_FLOW_3_FLOW + aOffset];
                aSubprogramData.tabMFC[2].MinFlow       = aData[Types.OFFSET_SEQ_FLOW_3_MIN_FLOW + aOffset];
                aSubprogramData.tabMFC[2].MaxFlow       = aData[Types.OFFSET_SEQ_FLOW_3_MAX_FLOW + aOffset];
                aSubprogramData.tabMFC[2].ShareGas      = aData[Types.OFFSET_SEQ_FLOW_3_SHARE + aOffset];
                aSubprogramData.tabMFC[2].Devaition     = aData[Types.OFFSET_SEQ_FLOW_3_DEVIATION + aOffset];

                aSubprogramData.GasProces_Mode          = aData[Types.OFFSET_SEQ_GAS_MODE         + aOffset];
                aSubprogramData.GasProces_Setpoint      = Types.ConvertDWORDToDouble(aData, (int)(Types.OFFSET_SEQ_GAS_SETPOINT      + aOffset));
                aSubprogramData.GasProces_MinDiffer     = Types.ConvertDWORDToDouble(aData, (int)(Types.OFFSET_SEQ_GAS_DOWN_DIFFER   + aOffset));
                aSubprogramData.GasProces_MaxDiffer     = Types.ConvertDWORDToDouble(aData, (int)(Types.OFFSET_SEQ_GAS_UP_DIFFER     + aOffset));
                aSubprogramData.GasProces_TimeTarget    = aData[Types.OFFSET_SEQ_GAS_TIME         + aOffset];

                aSubprogramData.Vaporaitor_CycleTime    = Types.ConvertDWORDToDouble(aData, (int)(Types.OFFSET_SEQ_FLOW_4_CYCLE_TIME + aOffset));
                aSubprogramData.Vaporaitor_Open         = (int)Types.ConvertDWORDToDouble(aData, (int)(Types.OFFSET_SEQ_FLOW_4_ON_TIME + aOffset));
            }
            return aSubprogramData;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        private bool CheckCorectTabSize(int aDataLen)
        {
            bool aRes = false;
            if (aDataLen > Types.OFFSET_SEQ_PUMP_SP &&          aDataLen > Types.OFFSET_SEQ_PUMP_MAX_TIME &&    aDataLen > Types.OFFSET_SEQ_VENT_TIME &&        aDataLen > Types.OFFSET_SEQ_FLUSH_TIME &&
                aDataLen > Types.OFFSET_SEQ_HV_OPERATE &&       aDataLen > Types.OFFSET_SEQ_HV_SETPOINT &&      aDataLen > Types.OFFSET_SEQ_HV_TIME &&          aDataLen > Types.OFFSET_SEQ_FLOW_1_FLOW &&
                aDataLen > Types.OFFSET_SEQ_FLOW_1_MIN_FLOW &&  aDataLen > Types.OFFSET_SEQ_FLOW_1_MAX_FLOW &&  aDataLen > Types.OFFSET_SEQ_FLOW_1_SHARE &&     aDataLen > Types.OFFSET_SEQ_FLOW_1_DEVIATION &&
                aDataLen > Types.OFFSET_SEQ_FLOW_2_FLOW &&      aDataLen > Types.OFFSET_SEQ_FLOW_2_MIN_FLOW &&  aDataLen > Types.OFFSET_SEQ_FLOW_2_SHARE &&     aDataLen > Types.OFFSET_SEQ_FLOW_2_DEVIATION &&
                aDataLen > Types.OFFSET_SEQ_FLOW_2_MAX_FLOW &&  aDataLen > Types.OFFSET_SEQ_FLOW_3_FLOW &&      aDataLen > Types.OFFSET_SEQ_FLOW_3_MIN_FLOW &&  aDataLen > Types.OFFSET_SEQ_FLOW_3_MAX_FLOW &&
                aDataLen > Types.OFFSET_SEQ_FLOW_3_SHARE &&     aDataLen > Types.OFFSET_SEQ_FLOW_3_DEVIATION && aDataLen > Types.OFFSET_SEQ_FLOW_3_MIN_FLOW &&  aDataLen > Types.OFFSET_SEQ_FLOW_3_MAX_FLOW &&
                aDataLen > Types.OFFSET_SEQ_FLOW_3_SHARE &&     aDataLen > Types.OFFSET_SEQ_FLOW_3_DEVIATION && aDataLen > Types.OFFSET_SEQ_GAS_MODE &&         aDataLen > Types.OFFSET_SEQ_GAS_SETPOINT &&
                aDataLen > Types.OFFSET_SEQ_GAS_DOWN_DIFFER &&  aDataLen > Types.OFFSET_SEQ_GAS_UP_DIFFER &&    aDataLen > Types.OFFSET_SEQ_GAS_TIME &&         aDataLen > Types.OFFSET_SEQ_FLOW_4_CYCLE_TIME &&
                aDataLen > Types.OFFSET_SEQ_FLOW_4_ON_TIME)
                aRes = true;

            return aRes;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public ERROR StartProgram()
        {
            ERROR aErr = new ERROR();
            //przygotuj dane do wgrania do PLC
            int[] aDataControl  = new int[1];
         
            if (plc != null)
            {
                //Wgraj parametry segmentow do PLC   
                 aErr = WriteProgramToPLC();
                //Utworz struktury danych do przechowyania aktualnych parametrow programu wczytanychy do PLC
                //CreateActualSubprogram();
                //uruchom program
                aDataControl[0] = (int)Types.ControlProgram.Start;
                int aCode = 0;
                if(!aErr.IsError())
                    aCode = plc.WriteWords(Types.ADDR_CONTROL_PROGRAM, 1, aDataControl);

                if (aCode != 0)
                    aErr.SetErrorMXComponents(Types.ERROR_CODE.START_PROGRAM, aCode);
            }
            return aErr;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public ERROR StopProgram()
        {
            ERROR aErr = new ERROR();

            //przygotuj dane do wgrania do PLC
            int[] aDataControl = new int[1];

            if (plc != null)
            {
                aDataControl[0] = (int)Types.ControlProgram.Stop;
                int aCode = plc.WriteWords(Types.ADDR_CONTROL_PROGRAM, 1, aDataControl);
                aErr.SetErrorMXComponents(Types.ERROR_CODE.STOP_PROGRAM, aCode);
            }

            return aErr;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        private ERROR WriteProgramToPLC()
        {
            ERROR aErr = new ERROR();

            int[] aDataID = new int[1];
            int[] aData = new int[Types.MAX_SEGMENTS * Types.SEGMENT_SIZE];
            int aSizeData = 0;
            
            aDataID[0] = (int)id;
            //Pobierz z kolejnych subprogramow parametry procesow
            int[] aSeqData = new int[Types.SEGMENT_SIZE];
            for (int i = 0; i < subPrograms.Count; i++)
            {
                aSeqData = subPrograms[i].GetPLCSegmentData();
                for (int j = 0; j < Types.SEGMENT_SIZE; j++)
                {
                    if (aData.Length > i * Types.SEGMENT_SIZE + j)
                        aData[i * Types.SEGMENT_SIZE + j] = aSeqData[j];
                }
                int aStatusIndex = i * Types.SEGMENT_SIZE + Types.OFFSET_SEQ_STATUS;
                if (aData.Length > aStatusIndex)
                    aData[aStatusIndex] = (int)Types.StatusProgram.Stop;
            }
            //uzupelnij subprogramy o ostatni segment END ktory dawany jest z automatu
            if (aData.Length > (subPrograms.Count * Types.SEGMENT_SIZE + Types.OFFSET_SEQ_CMD))
                aData[subPrograms.Count * Types.SEGMENT_SIZE + Types.OFFSET_SEQ_CMD] = 0x4000; //ustaw komende END

            //wgraj dane programu do PLC 
            aSizeData = subPrograms.Count * Types.SEGMENT_SIZE + Types.OFFSET_SEQ_CMD + 1;
            int aCode = plc.WriteWords(Types.ADDR_PRG_ID, 1, aDataID);
            if(aCode == 0)
                aCode = plc.WriteWords(Types.ADDR_START_BUFFER_PROGRAM, aSizeData, aData);

            aErr.SetErrorMXComponents(Types.ERROR_CODE.WRITE_PROGRAM, aCode);

            return aErr;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Odczytaj z plc dane na temat wszystkich subprogramow, utworz ich struktrure oraz zaktualizuj dane
        public void ReadProgramsData()
        {
            int aFinishCount = 0;
            int aLoop = 0;

            if (plc != null)
            {
                int[] aData = new int[1];
                //Wymus na PLC przeliczenie na nowo liczby segmentow i czekaj az to zrobi. Robie tak aby miec pewnosc ze dane w PLC zostaly poprawnie zaktualizowane na na podstawie przed chwila wgranego programu   
                plc.SetDevice(Types.ADDR_REQ_COUNT_SEGMENT, 1);
                plc.SetDevice(Types.ADDR_FINISH_COUNT_SEGMENT, 0);

                while (aFinishCount == 0)
                {
                    plc.GetDevice(Types.ADDR_FINISH_COUNT_SEGMENT, out aFinishCount);
                    //czekaj max 1 + czas odczytu danych z plc dla jednej wartosci * 10
                    if (aLoop > 10)
                        break;
                    System.Threading.Thread.Sleep(100);
                    aLoop++;
                }
                //Odczytaj liczbe segmentow z ktorych sklada sie program wgrany do PLC ale najpierw wymus na PLC przeliczenie na nowow liczby segmentow i czekaj az to zrobi
                plc.ReadWords(Types.ADDR_PRG_SEQ_COUNTS, 1, aData);
                countSubprogramsPLC = aData[0];
                //Odczytaj parametry subprogramow
                int[] aDataSeq = new int[countSubprogramsPLC * Types.SEGMENT_SIZE];
                plc.ReadWords(Types.ADDR_START_BUFFER_PROGRAM, aDataSeq.Length, aDataSeq);

                subPrograms.Clear();
                SubprogramData subProgramData;
                for (uint i = 0; i < countSubprogramsPLC; i++)
                {
                    Subprogram subProgram = new Subprogram(i + 1);
                    subProgramData = GetSegmentData(aDataSeq, i);
                    subProgram.UpdateData(subProgramData);
                    AddSubprogram(subProgram);
                }
                //CreateActualSubprogram();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Funkcja tworzy kliste akutalnych subprogramowa na bazie tych co zostalyu wgrane do PLC aby umozliwic prezentacje danych odczytanych z PLC. W innym przypadku parametry subprogramow moglyby zostac nadpisane
     /*   public void CreateActualSubprogram()
        {
            lock (subProgramsActual)
            {
                subProgramsActual.Clear();
                foreach (Subprogram subProgram in subPrograms)
                {
                    Subprogram aSubProgram = new Subprogram(subProgram.ID);//(subProgram);
                    subProgramsActual.Add(aSubProgram);
                }
            }
        }
        */
        //-------------------------------------------------------------------------------------------------------------------------
        public bool IsRun()
        {
            bool aProgramRun = false;

            if (status == Types.StatusProgram.Suspended || status == Types.StatusProgram.Run)
                aProgramRun = true;

            return aProgramRun;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Funkcja zwraca aktualnie wykonywany subprogram
        public Subprogram GetActualSubprogram()
        {
            Subprogram aActualSubprogram = null;

            foreach (Subprogram aSubprogram in subPrograms)
            {
                if (aSubprogram.ID == actualSubprogramId)
                    aActualSubprogram = aSubprogram;
            }
            return aActualSubprogram;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public void NewSubprogram()
        {
            Subprogram aSubprogram = new Subprogram(GetUnigueSubprogramID());
            AddSubprogram(aSubprogram);
        }
        //-------------------------------------------------------------------------------------------------------------------------
        private void AddSubprogram(Subprogram aSubprogram)
        {
            subPrograms.Add(aSubprogram);

            //Poinformuj moich obserwatorow aby odswiezyly sobie informacje na temat programow
            if (refreshProgram != null)
                refreshProgram();
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public bool RemoveSubprogram(Subprogram aSubprogram)
        {
            bool aRes = false;

            aRes = subPrograms.Remove(aSubprogram);

            //Poinformuj moich obserwatorow aby odswiezyly sobie informacje na temat programow
            if (refreshProgram != null)
                refreshProgram();

            return aRes;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        private uint GetUnigueSubprogramID()
        {
            uint aId = 0;
            bool aExist = true;

            while (aExist)
            {
                aId++;
                aExist = false;
                foreach (Subprogram subProgram in subPrograms)
                {
                    if (subProgram.ID == aId)
                        aExist = true;
                }
            }
            return aId;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        private bool IsBitActive(int aData, int aBitNo)
        {
            bool aRes = false;

            if ((aData & (int)Math.Pow(2, aBitNo)) != 0)
                aRes = true;

            return aRes;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Zwroc subprogramy konfigurowane przez uzytkownika
        public List<Subprogram> GetSubprograms()
        {
            return subPrograms;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Zwroc subprogramy ktrorych parametry zostaly odczytane na podstawie pamieci PLC
       /* public List<Subprogram> GetSubprogramsPLC()
        {
            return subProgramsActual;
        }
        */
        //-------------------------------------------------------------------------------------------------------------------------
        public uint GetID()
        {
            return id;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public void SetName(string aName)
        {
            name = aName;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public string GetName()
        {
            return name;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public void SetDescription(string aDescription)
        {
            description = aDescription;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public string GetDescription()
        {
            return description;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public void SetPtrPLC(PLC aPLC)
        {
            plc = aPLC;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return name;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public static void AddToRefreshList(RefreshProgram aRefresh)
        {
            refreshProgram += aRefresh;
        }
        //-------------------------------------------------------------------------------------------------------------------------
    }
}
