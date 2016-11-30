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
    public class HPT1000 : IDisposable
    {
        private DB                      dataBase            = null;
        private PLC                     plc                 = new PLC_Mitsubishi();
        private Chamber.Chamber         chamber             = new Chamber.Chamber();
        private List<Program.Program>   programs            = new List<Program.Program>(); //Lista wszystkich programow zapisanych w aplikacji
        private GasTypes                gasTypes            = new GasTypes();

        private Types.DriverStatus      status              = Types.DriverStatus.Unknown;
        private bool                    flagError           = false;
        private static Types.Mode       mode                = Types.Mode.None;

        private ThreadStart             funThr;
        private Thread                  threadReadData;

        bool                            connectionPLC       = false;

        private static RefreshProgram   refreshProgram      = null;
 
        public static Types.Language    LanguageApp         = Types.Language.English; //zm globalna określająca jezyk aplikacji

        List<DataBaseData>              dataBaseData        = new List<DataBaseData>(); //Lista z wartoscami danych ktore nalezy zapisac do bazy danych

        ProgramParameter                parameterAcq        = new ProgramParameter();  //Zmienna jest wykorzystywana do przechowyania w bazie danych informacji na temat parametorw urzadzenie dotyczace archiwizacji danych

        //-----Zestaw parametrow okreslajych akwizycj danych w bazie danych
        long                            lastTimeSaveDataInDB    = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;    //Counter jest wykorzystywany do odmierzania czasu zapidu danych w bazie danych
        int                             frqSaveDataInDB         = 30;    //Czestotliwość okresla jak czesto powinismy zapisywac dane w bazie. Dane sa zbierane a nastepnie zbiorczo zapisywane [s]
        double                          pressureAcq             = 1;     //Poziom prozni ponizej ktorej dane sa zapisywane w bazie danych
        bool                            activeCheckPressureAcq  = true;  //Flaga okresla czy podczas zapisu danych w bazie danych mam sprawdzac warunek na poziom cisnienia w komorze
        bool                            acqDuringOnlyProcess    = false; //Flaga okresla czy mam zapisywac dane tylko podczas trwania prcesu 
        bool                            acqAllTime              = true;  //Flaga okresla czy mam zapisywac dane caly czas
        bool                            lastConditionsSaveData  = false; // flaga okresla czy poprzednio warunki do zapisu danych byly spelnione
        bool                            firstRunNewSesion       = false; //Flaga okresla ze wykonywana jest pierwszy przebieg petli po utworzeniu nowej sesji danych
        bool                            enabledAcq              = true; //Flaga okresla czy jesrt wlaczona akwizycja danych
        //-----------------------------------------------------------------------------------------
        public int FrequencySaveDataInDB
        {
            set { frqSaveDataInDB = value; }
            get { return frqSaveDataInDB; }
        }
        //-----------------------------------------------------------------------------------------
        public double PressureAcq
        {
            set { pressureAcq = value; }
            get { return pressureAcq; }
        }
        //-----------------------------------------------------------------------------------------
        public bool ActiveCheckPressureAcq
        {
            set { activeCheckPressureAcq = value; }
            get { return activeCheckPressureAcq; }
        }
        //-----------------------------------------------------------------------------------------
        public bool AcqDuringOnlyProcess
        {
            set { acqDuringOnlyProcess = value; }
            get { return acqDuringOnlyProcess; }
        }
        //-----------------------------------------------------------------------------------------
        public bool AcqAllTime
        {
            set { acqAllTime = value; }
            get { return acqAllTime; }
        }
        //-----------------------------------------------------------------------------------------
        public bool CoonectionPLC
        {
            get { return connectionPLC; }
        }
        //-----------------------------------------------------------------------------------------
        public bool EnabledAcq
        {
            set { enabledAcq = value; }
            get { return enabledAcq; }
        }
        //-----------------------------------------------------------------------------------------
        public DB DataBase
        {
            set
            {
                dataBase = value;
                gasTypes.DataBase = value;
                //pobierz listę programó zapisanych w bazie danych
                if (dataBase != null)
                {
                    ReadProgramsFromDB();
                    RegisterDevice();
                    LoadData();
                    gasTypes.LoadGasType();
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public static Types.Mode Mode
        {
            get { return mode; }
        }
        //-----------------------------------------------------------------------------------------
        public Chamber.Chamber Chamber
        {
            get { return chamber; }
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

            parameterAcq.Name = "ParameterAcq";
        }
        //-----------------------------------------------------------------------------------------
        ~HPT1000()
        {
            Dispose();
        }
        //-----------------------------------------------------------------------------------------
        public void Dispose()
        {
            if(threadReadData.IsAlive)
                threadReadData.Abort();
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
       //         if(aData.Length > Types.OFFSET_DEVICE_STATUS) status      = (Types.DriverStatus)aData[Types.OFFSET_DEVICE_STATUS];
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

                //Sprawdz czy jest komunikacja. Jezeli nie ma to sprobuj nawiazac
                CheckConnection(aRes);

                //Odczytaj bledy z PLC
                if(flagError)
                    ReadErrorsFromPLC();

                //Wywolaj funkcje odpowiedzialna za wykonywanie akwizycji danych
                 MakeAcquisitionData();

                //Odczytuj dane co 0.5 s
                Thread.Sleep(500);
            }
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja organizuje zapis danych do bazy. Jej zadanie polega na sprawdzeniu warunkow zapisu, zbieraniu danych oraz zapisie danych w bazie
        private void MakeAcquisitionData()
        {
            //Sprawdz czy nie ma nowej sesji danych. Jezeli tak to wyczysc liste i ustaw w bazie danych nowa sesje
            if(ConditionsSaveData() && !lastConditionsSaveData)
            {
                //Rozpocznij nowa sesje danych poprzez wpis w bazie i kasowanie aktualnej listy parametrow
                if (dataBase != null)
                    dataBase.StartSesion();
                dataBaseData.Clear(); //wyczysc liste parametrow do zapisu w bazie
            }
            //Jezeli sa spelnione warunki do zapisu danych to zbieraj dane a w odpowiedniej chwili zgodnie z ustawionymi parametrami czestotliwisc zapisz je do bazy
            if(ConditionsSaveData())
            {
                //Zbieraj parametry ktore zostana zapisane w bazie danych w odpowiednim czasie
                ColetctDataToSaveInDB();
                //Sprawcz czy nadszedl czas na zpisa danych do bazy danych. Po rozpoczciu nowej sesji dane sa zapisywane odrazu ale tylko przez pierwsza iteracje
                if (Math.Abs(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - lastTimeSaveDataInDB) >= frqSaveDataInDB * 1000 || firstRunNewSesion)
                    SaveDataInDataBase();              
            }
            firstRunNewSesion       = false;
            lastConditionsSaveData  = ConditionsSaveData();
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja ma za zadanie sprawdzenie czy sa spelnione warunki do zapisu danych w bazie danych
        private bool ConditionsSaveData()
        {
            bool    aRes            = false;
            double  aPressure       = 0;
            bool    aProcessActive  = false;

            //Sprawdz czy nie wykonuje sie jakis program.
            foreach (Program.Program program in programs)
            {
                if (program.IsRun())
                    aProcessActive = true;
            }
            //Odczytaj wartosc aktualnej prozni
            if (chamber != null && chamber.GetObject(Types.TypeObject.PC) != null)
                aPressure = ((PressureControl)chamber.GetObject(Types.TypeObject.PC)).GetPressure();

            //Sprawdz czy sa spelnione warunki aby zapisac dane w bazie danych
            //Warunki to proznia jezeli opcja aktywna oraz wykonywany proces jezeli opcja aktywna
            if (connectionPLC && enabledAcq && (!activeCheckPressureAcq || (activeCheckPressureAcq && aPressure <= pressureAcq)) && (acqAllTime || (acqDuringOnlyProcess && aProcessActive)))
                aRes = true;
            
            return aRes;
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja ma za zadanie zapisanie danych w bazie danych 
        private void SaveDataInDataBase()
        {
            //Pobierz wyszstkie elementy do zapisu i zapisany element z listy usun
            while (dataBaseData.Count > 0)
            {
                DataBaseData data = dataBaseData[0]; //pobierz pierwszy element z listy do zapisu do bazy danych
                dataBaseData.RemoveAt(0);            //usun pobrany elemnt z listy
                if (dataBase != null)
                {
                    int aRes = dataBase.AddData(data);

                }
            }
            lastTimeSaveDataInDB = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja ma za zadanie zbieranie danych i wprowadzanie ich do listy parametrow ktore zostana zapisane w bazie. Zbieranie odbywa sie zgodnie z indywiduaknymi preferenacjami parametru
        private void ColetctDataToSaveInDB()
        {
            //Odczytaj dane ze wszystkich zarejestrowanych urzadzen i ich parametrow
            foreach (Device device in chamber.GetObjects())
            {
                if (device.ID_DB > 0)
                {
                    foreach (Parameter para in device.GetParameters())
                    {
                        if (para.ID > 0 && para.ValuePtr != null)
                        {
                            //Sprawdz czy sa spelnione warunki aby parametr dodac do listy tych kotre zostana zapisane do bazy danych. 
                            //Pod uwage biore roznice pomiedzy wartoscia aktualna a ostatnia oraz ostatni czas wprowadzenia parametru do lsity
                            if (para.IsDifferenceValue() && para.IsTimeSavePara() && para.EnabledAcq)
                            {
                                DataBaseData data = new DataBaseData();

                                data.ID_Para  = para.ID;
                                data.Value    = para.ValuePtr.Value_;
                                data.ValuePtr = para.ValuePtr;
                                data.Unit     = para.Unit;
                                data.Date     = DateTime.Now;

                                dataBaseData.Add(data);
                            }
                        }
                    }
                }
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
        //Funkcja odczytuje parametry programow zapisane w bazie danych. Do programow sa takze odczytywane parametry subprogramow
        private void ReadProgramsFromDB()
        {
            if (dataBase != null)
            {
                //Odczytaj liste programow z bazy danych
                foreach (Program.Program pr in dataBase.GetPrograms())
                {
                    //Wypelnij subprogramy parametrmi procesow
                    if(pr != null)
                        dataBase.FillProcessParametersOfSubprograms(pr.GetSubprograms());
                    programs.Add(pr);
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        //Zarejestruj urzadzenia w bazie danych powolane w komorze
        private void  RegisterDevice()
        {
            if(chamber != null && dataBase != null)
            {
                foreach (Device device in chamber.GetObjects())
                {
                    dataBase.RegisterDevice(device);
                    dataBase.RegisterParameters(device.ID_DB, device.GetParameters());
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        //W PLC bledy sa przechowywane w buforze cyklicznym, ktory posiada dwa wskazniki START i END. Bledy sa zapisywane pomiedzy tymi indeksami. Oprocz kodow bledow jest takze zapisana data wystapienia
        //Jedne blad jest przechowywany na 6 WORDACH (1 word kod bledu + 3 wordy daty + 1 word ID programu + 1 word ID subprogramu. Data jest przechowayna w kodzie BCD. 
        //Data jest przechowywan w kodzie BCD to znaczy kazdy word jet podzielony na bajty ktore przechowuja info: rok i miesiac, dzien i godzina, minuta i sekunda
        private void ReadErrorsFromPLC()
        {
            int[] aData = new int[Types.SIZE_ERROR_BUFFER_PLC];
            int[] aDataErr = new int[6];
            int   aRes  = 0;
            int   aCountOverflow = 0;
            ItemLogger aErr;

            if (plc != null)
            {
                //Odczytaj bufor bledow z PLC
                aRes = plc.ReadWords(Types.ADDR_BUFER_ERROR, Types.SIZE_ERROR_BUFFER_PLC, aData);
                //Ustaw flage ze bledy zostaly odczytane
                plc.SetDevice(Types.ADDR_FLAG_WAS_READ, 1);

                //Wyodrebnij z danych odczytanych z PLC konkrente kody bledow oraz daty ich wystapienia jak i ID programu i subprogramu

                int   aStartIndex  = aData[Types.OFFSET_ERR_START_INDEX];
                int   aCountsError = aData[Types.OFFSET_ERR_COUNTS_INDEX];
              
                //Odczytaj z PLC nowe bledy ktore sie mieszcza pomiedzy indeksem START i END
                for(int i = 0; i < Types.COUNT_ERROR_PLC;i++)
                {
                    if (aData.Length > (Types.OFFSET_ERR_BUFFER_INDEX + i * 6 + 3))
                    {
                        //Sprawdz czy bledy nie sa zapisame na poczatku bufora przed indeksen startu. Wynika z mozliwosci przekrecenia sie bufora
                        aCountOverflow = aStartIndex + aCountsError -Types.COUNT_ERROR_PLC;
                        if (aCountOverflow > 0 && aCountOverflow < i)
                        {
                            aDataErr[0] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 6];     //Index mnozemy razy 4 poniewaz jeden wpis bledu zajmuje 6 WORDY
                            aDataErr[1] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 6 + 1];
                            aDataErr[2] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 6 + 2];
                            aDataErr[3] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 6 + 3];
                            aDataErr[4] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 6 + 4];
                            aDataErr[5] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 6 + 5];

                            aErr = GetError(aDataErr);
                            Logger.AddError(aErr);
                        }
                        if (i >= aStartIndex && i < aStartIndex + aCountsError)
                        {
                            aDataErr[0] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 6];     //Index mnozemy razy 4 poniewaz jeden wpis bledu zajmuje 6 WORDY
                            aDataErr[1] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 6 + 1];
                            aDataErr[2] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 6 + 2];
                            aDataErr[3] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 6 + 3];
                            aDataErr[4] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 6 + 4];
                            aDataErr[5] = aData[Types.OFFSET_ERR_BUFFER_INDEX + i * 6 + 5];

                            aErr = GetError(aDataErr);
                            Logger.AddError(aErr);
                        }                     
                    }
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja ma za zadanie wyodrebnienie z jednego wpisu bledu ktory jest przechowywany na 4 wordach kod bledu oraz data jego wystapienia
        private ItemLogger GetError(int[] aData)
        {
            ItemLogger       aErr        = new ItemLogger();
            DateTime    dateTime    = new DateTime();
            int         aCode       = 0;

            int         aProgramID    = 0;
            int         aSubprogramID = 0;

            int aYear   = 0;
            int aMonth  = 0;
            int aDay    = 0;
            int aHour   = 0;
            int aMinute = 0;
            int aSecond = 0;
           //Wydrebnij kod bledu oraz date jego wystapienia z danych odczytanych z PLC (dostajesz jeden wpis)
            if (aData.Length > 3)
            {                
                aCode           = aData[0];
                aProgramID      = aData[4];
                aSubprogramID   = aData[5];

                aYear       = ConvertBcdToInt(((aData[1] >> 8)  & 0xFF)) + 2000;
                aMonth      = ConvertBcdToInt(  aData[1]        & 0xFF);
                aDay        = ConvertBcdToInt(( aData[2] >> 8)  & 0xFF);
                aHour       = ConvertBcdToInt(  aData[2]        & 0xFF);
                aMinute     = ConvertBcdToInt(( aData[3] >> 8)  & 0xFF);
                aSecond     = ConvertBcdToInt(  aData[3]        & 0xFF);
            }
            try
            {
                dateTime = new DateTime(aYear, aMonth, aDay, aHour, aMinute, aSecond);

                aErr.SetErrorPLC(aCode,dateTime,aProgramID,aSubprogramID);
            }
            catch (Exception ex)
            {
                Logger.AddException(ex);
            }

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
                if (plc != null && plc.Connect() == 0)
                    connectionPLC = true;
                else
                    connectionPLC = false;

                status = Types.DriverStatus.NoComm;
            }
            if (plc != null && plc.GetDummyMode())
            {
                connectionPLC = true;
                status = Types.DriverStatus.DummyMode;
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
                    programPLC.DataBase = dataBase;
                    programPLC.SetID((uint)aProgramIdInPLC);
                    programPLC.SetPtrPLC(plc);
                    AddProgram(programPLC);
                }
                programPLC.SetName("Program in PLC");
                programPLC.ReadProgramsData();
            }
            else
            {
                ItemLogger aErr = new ItemLogger();
                aErr.SetErrorApp(Types.EventType.NO_PRG_IN_PLC);
                Logger.AddError(aErr);
            }
        }
        //-----------------------------------------------------------------------------------------
        public void UpdateSettings()
        {
            ItemLogger aErr = new ItemLogger();
            int[] aData = new int[Types.LENGHT_SETTINGS_DATA];

            int aCode = plc.ReadWords(Types.ADDR_START_SETTINGS, Types.LENGHT_SETTINGS_DATA, aData);
            aErr.SetErrorMXComponents(Types.EventType.UPDATE_SETINGS, aCode);

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
        public Interlock GetInterlock()
        {
            return (Interlock)chamber.GetObject(Types.TypeObject.INT);
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
        //Funckaj ma za zadanie utworzenie nowego programu. Najpierw program jest zapisany w bazie danych. Jezeli zapis sie powisodl to jest tworzony obiekt i nadawany jest mu id rekordu bazy danych
        public void NewProgram()
        {
            if (dataBase != null)
            {
                //Utworz program aby posiadac obiekt na bazie ktorego utworzymy program w bazie danych.
                Program.Program program = new Program.Program();
                //Nadaj programowi unikalna nazwe
                program.SetName(GetUniqueProgramName());
                //Dodaj program do bazy danych
                int id = dataBase.AddProgram(program);
                //Poprawnie dodano program do bazy danych wiec dodaj program do lsity programow
                if (id > 0)
                {
                    program.SetID((uint)id);
                    program.DataBase = dataBase;
                    program.SetPtrPLC(plc);
                    AddProgram(program);
                }
            }
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
            if (dataBase != null)
            {
                //Usun program z bazy danych. Jezeli to sie uda to usun takze z lokalnej listy
                if(dataBase.RemoveProgram(program) == 0)
                    aRes = programs.Remove(program);

                //Poinformuj moich obserwatorow aby odswiezyly sobie informacje na temat programow
                if (refreshProgram != null)
                    refreshProgram();
            }
            return aRes;
        }
        //-----------------------------------------------------------------------------------------
        private string GetUniqueProgramName()
        {
            string  aName ;
            int     aNo = 1;

            aName = "Program " + aNo.ToString();
            for(int i = 0; i < programs.Count; i++)
            {
                Program.Program program = programs[i];
                if (program.GetName() == aName)
                {
                    aName = "Program " + (++aNo).ToString();
                    i = 0;
                }
            }

            return aName;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public ItemLogger SetMode(Types.Mode aMode)
        {
            ItemLogger aErr = new ItemLogger();
            int[] aData = new int[1];

            aData[0] = (int)aMode;
            if (plc != null)
            {
                int aCode = plc.WriteWords(Types.ADDR_MODE_CONTROL, 1, aData);
                aErr.SetErrorMXComponents(Types.EventType.SET_MODE_CONTROL, aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            return aErr;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public Types.Mode GetMode()
        {
            return mode;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public GasTypes GetGasTypes()
        {
            return gasTypes;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie zapisanie w jednym stringu parametrow dotyczacych akwizyji danych urzadzenia w baziee danych
        private void ParseParameterToAcqData(string data)
        {
            string [] parameters = data.Split(';');
            foreach(string para in parameters)
            {
                try
                {
                    if (para.Contains("EnabledAcq"))
                        enabledAcq = Convert.ToBoolean(para.Split('=')[1]);
                    if (para.Contains("Pressure"))
                        pressureAcq = Convert.ToDouble(para.Split('=')[1]);
                    if (para.Contains("DuringProces"))
                        acqDuringOnlyProcess = Convert.ToBoolean(para.Split('=')[1]);
                    if (para.Contains("AllTime"))
                        acqAllTime = Convert.ToBoolean(para.Split('=')[1]);
                }
                catch(Exception ex)
                {
                    Logger.AddException(ex);
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie wyodrebnienie z danych parametry zapisanych w formie zbiorczego stringa kolejnych wartosci dla parametrow akwizycji danych
        string ParseAcqDataToParameter()
        {
            string parameter;

            parameter = "EnabledAcq = " + EnabledAcq.ToString() + ";";
            parameter += "Pressure = " + pressureAcq.ToString() + ";";
            parameter += "DuringProces = " + acqDuringOnlyProcess.ToString() + ";";
            parameter += "AllTime = " + acqAllTime.ToString() + ";";

            return parameter;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Funckaj jest wykorzystywana do odczytu parametrow urzadzenia z bazie danych
        public int LoadData()
        {
            int aRes = -1;

            if (dataBase != null)
            {
                //Odczytaj z bazy danych wartosc dla tego parametru
                ProgramParameter parameter;
                if (dataBase.LoadParameter(parameterAcq.Name, out parameter) == 0)
                {
                    parameterAcq.ID = parameter.ID;
                    parameterAcq.Data = parameter.Data;
                    ParseParameterToAcqData(parameter.Data); // dane zostaly poprawnie odczytane z bazy danych to przekonwertuj je na parametry dotyczace akwizycji danych
                    aRes = 0;    
                }
            }            
            return aRes;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Funckja jest wykorzystywana do zapisu danyuch urzadzenia w bazie danych
        public int SaveData()
        {
            int aRes = -1;
            if (dataBase != null)
            {
                parameterAcq.Data = ParseAcqDataToParameter(); //Wykonaj parsowanie parametrow akwizycji danych ktroe powinny zostac zapisane w bazie danych
                                                               //W bazie danych sa przechowaywane jako jeden string rozdzielony ;
                aRes = dataBase.SaveParameter(parameterAcq);
            }
            return aRes;
        }
        //-------------------------------------------------------------------------------------------------------------------------

    }
}
