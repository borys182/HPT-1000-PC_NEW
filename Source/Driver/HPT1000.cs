using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HPT1000.Source.Chamber;
using HPT1000.Source.Program;

namespace HPT1000.Source.Driver
{
    /// <summary>
    /// Klasa driver opisujaca zachowanie sie komory oraz mozliwe funkcje przez nia wykonywane
    /// </summary>
    public class HPT1000
    {

        private PLC                     plc                 = new PLC_Mitsubishi();
        private Chamber.Chamber         chamber             = new Chamber.Chamber();
        private List<Program.Program>   programs            = new List<Program.Program>(); //Lista wszystkich programow zapisanych w aplikacji

        private Types.DriverStatus      status              = Types.DriverStatus.Unknown;
        private bool                    flagError           = false;
        private static Types.Mode       mode                = Types.Mode.None;

        private ThreadStart             funThr;
        private Thread                  threadReadData;

        bool                            connectionPLC       = false;

        private static RefreshProgram   refreshProgram      = null;

        
        public static Types.Language    LanguageApp         = Types.Language.PL; //zm globalna określająca jezyk aplikacji

        //-----------------------------------------------------------------------------------------
        public static Types.Mode Mode
        {
            get { return mode; }
        }
        //-----------------------------------------------------------------------------------------
        public HPT1000()
        {
            chamber.SetPtrPLC(plc);
            foreach (Program.Program pr in programs)
                pr.SetPtrPLC(plc);

            funThr = new ThreadStart(Run);
            threadReadData = new Thread(funThr);

            threadReadData.Start();
        }
        //-----------------------------------------------------------------------------------------
        //Funkcaj watku drivera
        private void Run()
        {
            int aRes = 0;
            int[] aData = new int[Types.LENGHT_STATUS_DATA];
            
            while (true)
            {
                aRes = plc.ReadWords(Types.ADDR_START_STATUS_CHAMBER, Types.LENGHT_STATUS_DATA, aData);
                //aktualizuj dane urzadzenia HPT1000
                if(aData.Length > Types.OFFSET_DEVICE_STATUS) status      = (Types.DriverStatus)aData[Types.OFFSET_DEVICE_STATUS];
                if(aData.Length > Types.OFFSET_OCCURED_ERROR) flagError   = Convert.ToBoolean(aData[Types.OFFSET_OCCURED_ERROR]);
                if(aData.Length > Types.OFFSET_MODE)          mode        = (Types.Mode)aData[Types.OFFSET_MODE];

                //aktualizuju dane komponentow komory
                chamber.UpdateData(aData);

                //aktualizuj dane na temat aktualnie wykonywanego subprogramu. Poniewaz dane programow sa odczytywane razem z danymi komponenotw musze je przesunac o dany offset
                int[] aDataProgram = new int[Types.SIZE_PRG_DATA];
                CopyData(aData, aDataProgram);
                foreach (Program.Program pr in programs)
                    pr.UpdateActualSubprogramData(aDataProgram);
           
                //Wykonaj operacje po nawiazaniu polaczenia z PLC
                if (!connectionPLC && aRes == 0)
                    FirstRun();

                //Sprawdz czy jest komunikacja
                CheckConnection(aRes);

                //Odczytaj bledy z PLC
                if(flagError)
                    ReadErrorsFromPLC();
                //Odczytuj dane co 0.5 s
                Thread.Sleep(500);
            }
        }
        //-----------------------------------------------------------------------------------------
        private void FirstRun()
        {
            //Odczytaj z automatu settingsy z PLC po nawiazaniu polaczenia
            UpdateSettings();
            //Odczytaj z PLC parametry programu aktualnie wgranego
            ReadProgramFromPLC();
        }
        //-----------------------------------------------------------------------------------------
        //W PLC bledy sa przechowywane w buforze cyklicznym, ktory posiada dwa wskazniki START i END. Bledy sa zapisywane pomiedzy tymi indeksami. Oprocz kodow bledow jest takze zapisana data wystapienia
        //Jedne blad jest przechowywany na 4 WORDACH (1 word kod bledu + 3 wordy daty. Data jest przechowayna w kodzie BCD. 
        //Data jest przechowywan w kodzie BCD to znaczy kazdy word jet podzielony na bajty ktore przechowuja info: rok i miesiac, dzien i godzina, minuta i sekunda
        private void ReadErrorsFromPLC()
        {
            int[] aData = new int[Types.SIZE_ERROR_BUFFER_PLC];
            int[] aDataErr = new int[4];
            int   aRes  = 0;
            int   aCountOverflow = 0;
            ERROR aErr;

            if (plc != null)
            {
                //Odczytaj bufor bledow z PLC
                aRes = plc.ReadWords(Types.ADDR_BUFER_ERROR, Types.SIZE_ERROR_BUFFER_PLC, aData);
                //Ustaw flage ze bledy zostaly odczytane
                plc.SetDevice(Types.ADDR_FLAG_WAS_READ, 1);

                //Wyodrebnij z danych odczytanych z PLC konkrente kody bledow oraz daty ich wystapienia

                int   aStartIndex  = aData[Types.OFFSET_ERR_START_INDEX];
                int   aCountsError = aData[Types.OFFSET_ERR_COUNTS_INDEX];
              
                //Odczytaj z PLC nowe bledy ktore sie mieszcza pomiedzy indeksem START i END
                for(int i = 0; i < Types.COUNT_ERROR_PLC;i++)
                {
                    if (aData.Length > (Types.OFFSET_ERR_BUFFER_INDEX + i * 4 + 3))
                    {
                        //Sprawdz czy bledy nie sa zapisame na poczatku bufora przed indeksen startu. Wynika z mozliwosci przekrecenia sie bufora
                        aCountOverflow = aStartIndex + aCountsError -Types.COUNT_ERROR_PLC;
                        if (aCountOverflow > 0 && aCountOverflow < i)
                        {
                            aDataErr[0] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 4];     //Index mnozemy razy 4 poniewaz jeden wpis bledu zajmuje 4 WORDY
                            aDataErr[1] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 4 + 1];
                            aDataErr[2] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 4 + 2];
                            aDataErr[3] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 4 + 3];

                            aErr = GetError(aDataErr);
                            Logger.AddError(aErr);
                        }
                        if (i >= aStartIndex && i < aStartIndex + aCountsError)
                        {
                            aDataErr[0] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 4];     //Index mnozemy razy 4 poniewaz jeden wpis bledu zajmuje 4 WORDY
                            aDataErr[1] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 4 + 1];
                            aDataErr[2] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 4 + 2];
                            aDataErr[3] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 4 + 3];

                            aErr = GetError(aDataErr);
                            Logger.AddError(aErr);
                        }                     
                    }
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja ma za zadanie wyodrebnienie z jednego wpisu bledu ktory jest przechowywany na 4 wordach kod bledu oraz data jego wystapienia
        private ERROR GetError(int[] aData)
        {
            ERROR       aErr        = new ERROR();
            DateTime    dateTime    = new DateTime();
            int         aCode       = 0;
            
            int aYear   = 0;
            int aMonth  = 0;
            int aDay    = 0;
            int aHour   = 0;
            int aMinute = 0;
            int aSecond = 0;
           //Wydrebnij kod bledu oraz date jego wystapienia z danych odczytanych z PLC (dostajesz jeden wpis)
            if (aData.Length > 3)
            {                
                aCode   = aData[0];
                aYear   = ConvertBcdToInt(((aData[1] >> 8)  & 0xFF)) + 2000;
                aMonth  = ConvertBcdToInt(  aData[1]        & 0xFF);
                aDay    = ConvertBcdToInt(( aData[2] >> 8)  & 0xFF);
                aHour   = ConvertBcdToInt(  aData[2]        & 0xFF);
                aMinute = ConvertBcdToInt(( aData[3] >> 8)  & 0xFF);
                aSecond = ConvertBcdToInt(  aData[3]        & 0xFF);
            }
            try
            {
                dateTime = new DateTime(aYear, aMonth, aDay, aHour, aMinute, aSecond);

                aErr.SetErrorPLC(aCode,dateTime);
            }
            catch (Exception e) { }

            return aErr;
        }
        //-----------------------------------------------------------------------------------------
        private int ConvertBcdToInt(int aBcdValue)
        {
            int aRes = 0;

            aRes = ((aBcdValue >> 4) & 0xF) * 10 + (aBcdValue & 0xF);

            return aRes;
        }
        //-----------------------------------------------------------------------------------------
        // Wyodrebnij z bufora danych dane programu
        void CopyData(int[] aData,int[] aDataProgram)
        {
            for (int i = 0; i < aDataProgram.Length; i++)
            {
                if (aData.Length > i)
                    aDataProgram[i] = aData[i + Types.OFFSET_PRG_DATA];
            }
        }
        //-----------------------------------------------------------------------------------------
        void CheckConnection(int aRes)
        {
            if (aRes == 0)
            {
                connectionPLC = true;
                status = Types.DriverStatus.OK;
            }
            else
            {
                connectionPLC = false;
                status = Types.DriverStatus.NoComm;
            }
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja ma za zadanie pobranie parametrow programu z PLC i utworzonie/aktualizacja paramtrow instancji po stronie PC
        public void ReadProgramFromPLC()
        {
            Program.Program programPLC = null;
            //Sprawdz czy w PLC istnieje jakis program oraz czy ma jakies subprogramy
            int[] aData = new int[1];
            int aProgramIdInPLC       = 0;
            int aCountSubprogramInPLC = 0;

            if (plc != null)
                plc.ReadWords(Types.ADDR_PRG_ID, 2, aData);
            aProgramIdInPLC = aData[0];

            if (plc != null)
                plc.ReadWords(Types.ADDR_PRG_SEQ_COUNTS, 1, aData);
            aCountSubprogramInPLC = aData[0];

            //Sprawdz czy istnieje juz instanacja programu z parametrami z PLC
            if (aProgramIdInPLC > 0 && aCountSubprogramInPLC > 0)
            {
                foreach (Program.Program program in programs)
                {
                    //Status jest inny niz Niezaladowany do PLC to znaczy ze juz zostal zaladowany
                    if (program.GetID() == aProgramIdInPLC)
                        programPLC = program;
                }
                if (programPLC == null)
                {
                    programPLC = new Program.Program();
                    programPLC.SetPtrPLC(plc);
                    AddProgram(programPLC);
                }
                programPLC.SetName("Program in PLC");
                programPLC.ReadProgramsData();
            }
            else
            {
                ERROR aErr = new ERROR();
                aErr.SetErrorApp(Types.ERROR_CODE.NO_PRG_IN_PLC);
                Logger.AddError(aErr);
            }
        }
        //-----------------------------------------------------------------------------------------
        public void UpdateSettings()
        {
            ERROR aErr = new ERROR();
            int[] aData = new int[Types.LENGHT_SETTINGS_DATA];

            int aCode = plc.ReadWords(Types.ADDR_START_SETTINGS, Types.LENGHT_SETTINGS_DATA, aData);
            aErr.SetErrorMXComponents(Types.ERROR_CODE.UPDATE_SETINGS, aCode);

            //aktualizuj dane na temat settingsow
            if (aCode == 0)
                chamber.UpdateSettings(aData);

            Logger.AddError(aErr);
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public static void AddToRefreshList(RefreshProgram aRefresh)
        {
            refreshProgram += aRefresh;
        }
        //-----------------------------------------------------------------------------------------
        public Valve GetValve()
        {
            return (Valve)chamber.GetObject(Types.TypeObject.VL);
        }
        //-----------------------------------------------------------------------------------------
        public PowerSupplay GetPowerSupply()
        {
            return (PowerSupplay)chamber.GetObject(Types.TypeObject.HV);
        }
        //-----------------------------------------------------------------------------------------
        public MFC GetMFC()
        {
            return (MFC)chamber.GetObject(Types.TypeObject.FM);
        }
        //-----------------------------------------------------------------------------------------
        public ForePump GetForePump()
        {
            return (ForePump)chamber.GetObject(Types.TypeObject.FP);
        }
        //-----------------------------------------------------------------------------------------
        public Vaporizer GetVaporizer()
        {
            return (Vaporizer)chamber.GetObject(Types.TypeObject.VP);
        }
        //-----------------------------------------------------------------------------------------
        public PressureControl GetPressureControl()
        {
            return (PressureControl)chamber.GetObject(Types.TypeObject.PC);
        }
        //-----------------------------------------------------------------------------------------
        public PLC GetPLC()
        {
            return plc;
        }
        //-----------------------------------------------------------------------------------------
        public Types.DriverStatus GetStatus()
        {
            return status;
        }
        //-----------------------------------------------------------------------------------------
        public List<Program.Program> GetPrograms()
        {
            return programs;
        }
        //-----------------------------------------------------------------------------------------
        public void NewProgram()
        {
            Program.Program program = new Program.Program();
            program.SetPtrPLC(plc);
            AddProgram(program);
        }
        //-----------------------------------------------------------------------------------------
        private void AddProgram(Program.Program program)
        {
            programs.Add(program);
            //Poinformuj moich obserwatorow aby odswiezyly sobie informacje na temat programow
            if (refreshProgram != null)
                refreshProgram();
        }
        //-----------------------------------------------------------------------------------------
        public bool RemoveProgram(Program.Program program)
        {
            bool aRes = false;

            aRes = programs.Remove(program);

            //Poinformuj moich obserwatorow aby odswiezyly sobie informacje na temat programow
            if (refreshProgram != null)
                refreshProgram();

            return aRes;
        }
        //-----------------------------------------------------------------------------------------
        private uint GetUniqueProgramID()
        {
            uint aId = 0;
            bool aExist = true;

            while (aExist)
            {
                aId++;
                aExist = false;
                foreach (Program.Program program in programs)
                {
                    if (program.GetID() == aId)
                        aExist = true;
                }
            }
            return aId;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public ERROR SetMode(Types.Mode aMode)
        {
            ERROR aErr = new ERROR();
            int[] aData = new int[1];

            aData[0] = (int)aMode;
            if (plc != null)
            {
                int aCode = plc.WriteWords(Types.ADDR_MODE_CONTROL, 1, aData);
                aErr.SetErrorMXComponents(Types.ERROR_CODE.SET_MODE_CONTROL, aCode);
            }
            else
                aErr.SetErrorApp(Types.ERROR_CODE.PLC_PTR_NULL);

            return aErr;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public Types.Mode GetMode()
        {
            return mode;
        }
        //-------------------------------------------------------------------------------------------------------------------------
    }
}
