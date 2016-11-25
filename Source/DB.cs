using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using Npgsql;

using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;
using HPT1000.Source.Chamber;

/*Lista rzeczy do zrobienia
 *  dostosowanie procedury AddUser aby podawac typ privligie a nie id
 *  serial dla tabel
 *  zwracac info czy sie udalo wykonac procedury
 */

namespace HPT1000.Source
{
    enum TypeFillParameters { NewUser = 1 , ModifyUser = 2 , RemoveUser = 3};
    struct ErrorText
    {
        public Types.EventCategory EventCategory;
        public Types.EventType     EventType;
        public int                 ErrCode;
        public string              Text;
        public Types.Language      Language;

        

        public ErrorText(int aCategory,int aType,int aErrCode,string aTxt,Types.Language aLanguage)
        {
            EventCategory = (Types.EventCategory)aCategory;
            EventType     = (Types.EventType)aType;
            ErrCode = (int)aType;// aErrCode; 
            Text          = aTxt;
            Language      = aLanguage;
        }
    }
    /*
     * Klasa jest odpowiedzilana za komunikacje z baza danych oraz udostpenianie danych z niej pobranych. W bazie danych sa przechowywane informacje na temat:
     * : translacji tekstow , użytkowników i uprawnień, pomiarów, programów 
     */
    public class DB
    {
        private static List<ErrorText> actionTextList = new List<ErrorText>();

        //korzystanie ze standardowego sterownika ODBC dostarczonego przez framwork visula
        private OdbcConnection connection = new OdbcConnection("Dsn=PostgreSQL;" + "database=HE-005;server=localhost;" + "port=5432;uid=postgres;");

        //korzystanie z providera bazy Postgres dla C# (framework Npsql)
        private string pwd = "jan83lech";
        NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1 ; User ID = postgres ;" + "Password = " + "jan83lech" + "; Database=HE-005;");

        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie otwarcie polaczenia z baza danych. Jezeli sie to udalo to zwraca 0 w przeciwnym wypadku wartosc rozna od 0 
        private int Open()
        {
            int aRes = 1;
            try
            {
                conn.Open();
                //    connection.Open();
                aRes = 0;
            }
            catch (Exception ex) {
                Logger.AddException(ex);
                Logger.AddMsg("For unknown reasons database connection can't be opened", Types.MessageType.Error);
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie zamkniecia polaczenia z baza danych. Jezeli sie to udalo to zwraca 0 w przeciwnym wypadku wartosc rozna od 0 
        public int Close()
        {
            int aRes = 1;
            try
            {
                // connection.Close();
                conn.Close();
                aRes = 0;
            }
            catch (Exception ex) {
                Logger.AddException(ex);
                Logger.AddMsg("For unknown reasons database connection can't be closed.", Types.MessageType.Error);
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie podanie listy userow wpisanych do tabeli Users bazy danych
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            //Programowanie komunikcji z baza z urzyciem frameworka Npgswl sprecyzowanego na komuniakcje z baza danych srodowiska Visual

            //utworz zapytanie
            string query = " SELECT * FROM \"Users\"";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            //wykonaj zapytanie
            NpgsqlDataReader data = cmd.ExecuteReader();
            //odczytaj wszystkich userow zwroconych przez zapytanie i przypisz je do obietku User oraz do lsity users
            while (data.Read())
            {
                User user = new User();
                try
                {
                    if (!data.IsDBNull(data.GetOrdinal("id")))
                        user.ID = data.GetInt32(data.GetOrdinal("id"));

                    if (!data.IsDBNull(data.GetOrdinal("name")))
                        user.Name = data.GetString(data.GetOrdinal("name"));

                    if (!data.IsDBNull(data.GetOrdinal("surname")))
                        user.Surname = data.GetString(data.GetOrdinal("surname"));

                    if (!data.IsDBNull(data.GetOrdinal("login")))
                        user.Login = data.GetString(data.GetOrdinal("login"));

                    if (!data.IsDBNull(data.GetOrdinal("password")))
                        user.Password = data.GetString(data.GetOrdinal("password"));

                    if (!data.IsDBNull(data.GetOrdinal("allow_change_psw")))
                        user.AllowChangePsw = data.GetBoolean(data.GetOrdinal("allow_change_psw"));

                    if (!data.IsDBNull(data.GetOrdinal("type_block_account")))
                        user.DisableAccount = (Types.TypeDisableAccount)data.GetInt32(data.GetOrdinal("type_block_account"));

                    if (!data.IsDBNull(data.GetOrdinal("privilige")))
                        user.Privilige = (Types.UserPrivilige)data.GetInt32(data.GetOrdinal("privilige"));

                    if (!data.IsDBNull(data.GetOrdinal("start_date_block_account")))
                        user.DateStartDisableAccount = (DateTime)data.GetDate(data.GetOrdinal("start_date_block_account"));

                    if (!data.IsDBNull(data.GetOrdinal("end_date_block_account")))
                        user.DateEndDisableAccount = (DateTime)data.GetDate(data.GetOrdinal("end_date_block_account"));

                    users.Add(user);

                }
                catch (Exception ex) {
                    Logger.AddException(ex);
                }
            }
            data.Close();

            return users;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie podanie listy userow wpisanych do tabeli Users bazy danych
        public List<Program.Program> GetPrograms()
        {
            List<Program.Program> programs = new List<Program.Program>();

            //utworz zapytanie
            string query = " SELECT * FROM \"Programs\"";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            //wykonaj zapytanie
            NpgsqlDataReader data = cmd.ExecuteReader();
            //odczytaj wszystkich userow zwroconych przez zapytanie i przypisz je do obietku User oraz do lsity users
            int aProgramId = 0;
            while (data.Read())
            {
                Program.Program program = null;
                Program.Subprogram subprogram = null;
                try
                {
                    if (!data.IsDBNull(data.GetOrdinal("program_id")))
                        aProgramId = data.GetInt32(data.GetOrdinal("program_id"));

                    //Podaj mi wskaznik na program z danym ID ktory zostal juz wczesniej utworzony
                    program = GetProgram(programs, aProgramId);
                    if (program == null)
                    {
                        program = new Program.Program();
                        program.SetID((uint)aProgramId);
                        //      program.SetPtrPLC(); TO DO Zastanowic sien ad twrzemioenm progrmu z fabryky aby w jendym miejscu poprawnieni inijclizowac wymagane atrybuty obiektu
                        program.DataBase = this;
                        programs.Add(program);
                    }

                    if (!data.IsDBNull(data.GetOrdinal("program_name")))
                        program.SetName(data.GetString(data.GetOrdinal("program_name")));

                    if (!data.IsDBNull(data.GetOrdinal("program_description")))
                        program.SetDescription(data.GetString(data.GetOrdinal("program_description")));

                    //Jezeli program posiada jakis subprogram to zczytaj jego podstawoe info i dodaj do listy
                    if (!data.IsDBNull(data.GetOrdinal("subprogram_id")))
                    {
                        subprogram = new Program.Subprogram();
                        subprogram.ID = (uint)data.GetInt32(data.GetOrdinal("subprogram_id"));

                        if (!data.IsDBNull(data.GetOrdinal("subprogram_name")))
                            subprogram.SetName(data.GetString(data.GetOrdinal("subprogram_name")));

                        if (!data.IsDBNull(data.GetOrdinal("subprogram_description")))
                            subprogram.SetDescription(data.GetString(data.GetOrdinal("subprogram_description")));

                        program.AddSubprogram(subprogram);
                    }

                }
                catch (Exception ex)
                {
                    Logger.AddException(ex);
                }
            }
            data.Close();

            return programs;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie zwrocenie danego prgramu z lisy ale jezeli nie istnieje to go musi utworzyc
        private Program.Program GetProgram(List<Program.Program> programs, int aIdProgram)
        {
            Program.Program program = null;
            foreach (Program.Program pr in programs)
            {
                if (pr.GetID() == aIdProgram)
                    program = pr;
            }
            return program;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie podanie listy userow wpisanych do tabeli Users bazy danychwypelnienie danymi procesowymi podanengo subprogramu
        public void FillProcessParametersOfSubprograms(List<Program.Subprogram> subprograms)
        {
            //utworz zapytanie
            string query = " SELECT * FROM \"Subprograms\"";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            //wykonaj zapytanie
            NpgsqlDataReader data = cmd.ExecuteReader();
            //odczytaj wszystkich userow zwroconych przez zapytanie i przypisz je do obietku User oraz do lsity users
            int subprogramID = 0;
            while (data.Read())
            {
                try
                {
                    if (!data.IsDBNull(data.GetOrdinal("subprogram_id")))
                        subprogramID = data.GetInt32(data.GetOrdinal("subprogram_id"));

                    if (subprogramID > 0)
                    {
                        Program.Subprogram subprogram = GetSubprogram(subprograms, subprogramID);
                        if (subprogram != null)
                        {
                            FillVentProcessData(subprogram.GetVentProces(), data);
                            FillPumpProcessData(subprogram.GetPumpProces(), data);
                            FillPurgeProcessData(subprogram.GetPurgeProces(), data);
                            FillPowerProcessData(subprogram.GetPlasmaProces(), data);
                            FillGasProcessData(subprogram.GetGasProces(), data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.AddException(ex);
                }
            }
            data.Close();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie odczytanie listy sesji zapisu danych zawartych w bazie danych
        public List<Sesion> GetSesions()
        {
            List<Sesion> sesions = new List<Sesion>();

            //utworz zapytanie
            string query = " SELECT * FROM \"Sesions\"";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            //wykonaj zapytanie
            NpgsqlDataReader data = cmd.ExecuteReader();
            //odczytaj wszystkie sesje zwrocone przez zapytanie
            while (data.Read())
            {
                Sesion sesion = new Sesion();
                try
                {
                    if (!data.IsDBNull(data.GetOrdinal("id")))
                        sesion.ID = data.GetInt32(data.GetOrdinal("id"));

                    if (!data.IsDBNull(data.GetOrdinal("date_start")))
                        sesion.StartDate = data.GetDateTime(data.GetOrdinal("date_start"));

                    if (!data.IsDBNull(data.GetOrdinal("date_end")))
                        sesion.EndDate = data.GetDateTime(data.GetOrdinal("date_end"));

                    sesions.Add(sesion);
                }
                catch (Exception ex)
                {
                    Logger.AddException(ex);
                }
            }
            data.Close();

            return sesions;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private Program.Subprogram GetSubprogram(List<Program.Subprogram> subprograms, int subprogramID)
        {
            Program.Subprogram subprogram = null;
            foreach (Program.Subprogram subpr in subprograms)
            {
                if (subpr.ID == subprogramID)
                    subprogram = subpr;
            }
            return subprogram;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private void FillVentProcessData(Program.VentProces ventProcess, NpgsqlDataReader data)
        {
            if (ventProcess != null && data != null)
            {
                if (!data.IsDBNull(data.GetOrdinal("vent_time")))
                    ventProcess.SetTimeVent((DateTime)data.GetTime(data.GetOrdinal("vent_time")));
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private void FillPurgeProcessData(Program.FlushProces purgeProcess, NpgsqlDataReader data)
        {
            if (purgeProcess != null && data != null)
            {
                if (!data.IsDBNull(data.GetOrdinal("purge_time")))
                    purgeProcess.SetTimePurge((DateTime)data.GetTime(data.GetOrdinal("purge_time")));
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private void FillPumpProcessData(Program.PumpProces pumpProcess, NpgsqlDataReader data)
        {
            if (pumpProcess != null && data != null)
            {
                if (!data.IsDBNull(data.GetOrdinal("setpoint_pump_pressure")))
                    pumpProcess.SetSetpoint(data.GetFloat(data.GetOrdinal("setpoint_pump_pressure")));
                if (!data.IsDBNull(data.GetOrdinal("max_time_pump")))
                    pumpProcess.SetTimeWaitForPumpDown((DateTime)data.GetTime(data.GetOrdinal("max_time_pump")));
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private void FillPowerProcessData(Program.PlasmaProces powerProcess, NpgsqlDataReader data)
        {
            if (powerProcess != null && data != null)
            {
                if (!data.IsDBNull(data.GetOrdinal("power_supply_time_process")))
                    powerProcess.SetTimeOperate((DateTime)data.GetTime(data.GetOrdinal("power_supply_time_process")));
                if (!data.IsDBNull(data.GetOrdinal("power_supply_setpoint")))
                    powerProcess.SetSetpointValue(data.GetFloat(data.GetOrdinal("power_supply_setpoint")));
                if (!data.IsDBNull(data.GetOrdinal("power_supply_max_devation")))
                    powerProcess.SetDeviation(data.GetFloat(data.GetOrdinal("power_supply_max_devation")));
                if (!data.IsDBNull(data.GetOrdinal("power_supply_mode")))
                    powerProcess.SetWorkMode((Types.WorkModeHV)data.GetInt32(data.GetOrdinal("power_supply_mode")));
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private void FillGasProcessData(Program.GasProces gasProcess, NpgsqlDataReader data)
        {
            if (gasProcess != null && data != null)
            {
                if (!data.IsDBNull(data.GetOrdinal("gas_process_duration")))
                    gasProcess.SetTimeProcesDuration((DateTime)data.GetTime(data.GetOrdinal("gas_process_duration")));
                if (!data.IsDBNull(data.GetOrdinal("mode_gas")))
                    gasProcess.SetModeProces((Types.GasProcesMode)data.GetInt32(data.GetOrdinal("mode_gas")));
                if (!data.IsDBNull(data.GetOrdinal("gas_setpoint_pressure")))
                    gasProcess.SetSetpointPressure(data.GetFloat(data.GetOrdinal("gas_setpoint_pressure")));
                if (!data.IsDBNull(data.GetOrdinal("vaporaiser_cycle_time")))
                    gasProcess.SetCycleTime(data.GetFloat(data.GetOrdinal("vaporaiser_cycle_time")));
                if (!data.IsDBNull(data.GetOrdinal("vaporaiser_on_time")))
                    gasProcess.SetOnTime((int)data.GetFloat(data.GetOrdinal("vaporaiser_on_time")));
                if (!data.IsDBNull(data.GetOrdinal("mfc1_flow")))
                    gasProcess.SetGasFlow(data.GetFloat(data.GetOrdinal("mfc1_flow")), Types.UnitFlow.sccm, 1);
                if (!data.IsDBNull(data.GetOrdinal("mfc2_flow")))
                    gasProcess.SetGasFlow(data.GetFloat(data.GetOrdinal("mfc2_flow")), Types.UnitFlow.sccm, 2);
                if (!data.IsDBNull(data.GetOrdinal("mfc3_flow")))
                    gasProcess.SetGasFlow(data.GetFloat(data.GetOrdinal("mfc3_flow")), Types.UnitFlow.sccm, 3);
                if (!data.IsDBNull(data.GetOrdinal("mfc1_min_flow")))
                    gasProcess.SetMinGasFlow((int)data.GetFloat(data.GetOrdinal("mfc1_min_flow")), 1);
                if (!data.IsDBNull(data.GetOrdinal("mfc2_min_flow")))
                    gasProcess.SetMinGasFlow((int)data.GetFloat(data.GetOrdinal("mfc2_min_flow")), 2);
                if (!data.IsDBNull(data.GetOrdinal("mfc3_min_flow")))
                    gasProcess.SetMinGasFlow((int)data.GetFloat(data.GetOrdinal("mfc3_min_flow")), 3);
                if (!data.IsDBNull(data.GetOrdinal("mfc1_max_flow")))
                    gasProcess.SetMaxGasFlow((int)data.GetFloat(data.GetOrdinal("mfc1_max_flow")), 1);
                if (!data.IsDBNull(data.GetOrdinal("mfc2_max_flow")))
                    gasProcess.SetMaxGasFlow((int)data.GetFloat(data.GetOrdinal("mfc2_max_flow")), 2);
                if (!data.IsDBNull(data.GetOrdinal("mfc3_max_flow")))
                    gasProcess.SetMaxGasFlow((int)data.GetFloat(data.GetOrdinal("mfc3_max_flow")), 3);
                if (!data.IsDBNull(data.GetOrdinal("mfc1_gas_share")))
                    gasProcess.SetShareGas((int)data.GetFloat(data.GetOrdinal("mfc1_gas_share")), 1);
                if (!data.IsDBNull(data.GetOrdinal("mfc2_gas_share")))
                    gasProcess.SetShareGas((int)data.GetFloat(data.GetOrdinal("mfc2_gas_share")), 2);
                if (!data.IsDBNull(data.GetOrdinal("mfc3_gas_share")))
                    gasProcess.SetShareGas((int)data.GetFloat(data.GetOrdinal("mfc3_gas_share")), 3);
                if (!data.IsDBNull(data.GetOrdinal("mfc1_max_devation")))
                    gasProcess.SetShareDevaition((int)data.GetFloat(data.GetOrdinal("mfc1_max_devation")), 1);
                if (!data.IsDBNull(data.GetOrdinal("mfc2_max_devation")))
                    gasProcess.SetShareDevaition((int)data.GetFloat(data.GetOrdinal("mfc2_max_devation")), 2);
                if (!data.IsDBNull(data.GetOrdinal("mfc3_max_devation")))
                    gasProcess.SetShareDevaition((int)data.GetFloat(data.GetOrdinal("mfc3_max_devation")), 3);
                if (!data.IsDBNull(data.GetOrdinal("mfc1_active")))
                    gasProcess.SetActiveFlow(data.GetBoolean(data.GetOrdinal("mfc1_active")), 1);
                if (!data.IsDBNull(data.GetOrdinal("mfc2_active")))
                    gasProcess.SetActiveFlow(data.GetBoolean(data.GetOrdinal("mfc2_active")), 2);
                if (!data.IsDBNull(data.GetOrdinal("mfc3_active")))
                    gasProcess.SetActiveFlow(data.GetBoolean(data.GetOrdinal("mfc3_active")), 3);
                if (!data.IsDBNull(data.GetOrdinal("vaporaiser_active")))
                    gasProcess.SetVaporaiserActive(data.GetBoolean(data.GetOrdinal("vaporaiser_active")));
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja dodaje usera do bazy danych. Jezeli operacja sie powiedzia xwraca 0 w przeciwnym wypadku wartosc rozna od 0
        public int AddUser(User user)
        {
            int aRes = 0;
            List<NpgsqlParameter> parameters = GetUserParameters(user, TypeFillParameters.NewUser);
            aRes = PerformFunctionDB("\"NewUser\"", parameters);
            //Funkcja zwraca ID nowo utworzonego usera
            if (aRes > 0 && user != null)
            {
                user.ID = aRes; //wynik funkicji bazodanowej zwraca ID nowo utworzonego usera
                aRes = 0; //Ustaw reuslt jako ze obulo sie bez problemow
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja dodaje usera do bazy danych. Jezeli operacja sie powiedzia xwraca 0 w przeciwnym wypadku wartosc rozna od 0
        public int ModifyUser(User user)
        {
            int aRes = 0;
            //Przygotuj parametry dla procedury modife na bazie obiektu usera
            List<NpgsqlParameter> parameters = GetUserParameters(user, TypeFillParameters.ModifyUser);
            //Wykonaj procedure modyfikowania usera
            aRes = PerformFunctionDB("\"ModifyUser\"", parameters);
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja dodaje usera do bazy danych. Jezeli operacja sie powiedzia xwraca 0 w przeciwnym wypadku wartosc rozna od 0
        public int RemoveUser(User user)
        {
            int aRes = 0;
            //Przygotuj parametry dla procedury usuwania na bazie obiektu usera
            List<NpgsqlParameter> parameters = GetUserParameters(user, TypeFillParameters.RemoveUser);
            //Wykonaj procedure usuwania usera
            aRes = PerformFunctionDB("\"RemoveUser\"", parameters);
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funckja dodaje do bazy danych program
        public int AddProgram(Program.Program program)
        {
            int aRes = -1;
            if (program != null)
            {
                //Przygotuj parametry dla procedury dodawania programuw bazie danych
                List<NpgsqlParameter> parameters = GetProgramParameters(program, TypeFillParameters.NewUser);
                //Wykonaj procedure dodawania programu
                aRes = PerformFunctionDB("\"NewProgram\"", parameters);
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja dodaje usera do bazy danych. Jezeli operacja sie powiedzia xwraca 0 w przeciwnym wypadku wartosc rozna od 0
        public int ModifyProgram(Program.Program program)
        {
            int aRes = -1;
            if (program != null)
            {
                //Przygotuj parametry dla procedury modife na bazie obiektu usera
                List<NpgsqlParameter> parameters = GetProgramParameters(program, TypeFillParameters.ModifyUser);
                //Wykonaj procedure modyfikowania usera
                aRes = PerformFunctionDB("\"ModifyProgram\"", parameters);
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja usuwa program z bazy danych. Jezeli operacja sie powiedzia xwraca 0 w przeciwnym wypadku wartosc rozna od 0
        public int RemoveProgram(Program.Program program)
        {
            int aRes = -1;
            if (program != null)
            {
                //Przygotuj parametry dla procedury usuwania standardowo rekordu z bazy danych to naczy funkcja posiada tylko jeden parametr o nazwie ID
                List<NpgsqlParameter> parameters = GetRemoveStandardParameters((int)program.GetID());
                //Wykonaj procedure usuwania programu
                aRes = PerformFunctionDB("\"RemoveProgram\"", parameters);
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja dodaje do bazy danych subprogram. Powiazanie subprogramu z programem odbywa sie juz po stronie bazy danych w funkcji AddSubprpgram
        public int AddSubProgram(Program.Subprogram subprogram, Int32 idProgram)
        {
            int aRes = -1;
            if (subprogram != null)
            {
                //Przygotuj parametry dla procedury dodawania subprogramu powiazanego z programem
                List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

                //utworz parametr program name                    
                parameters.Add(GetParameter("id_program", DbType.Int32, idProgram));
                //utworz parametr subprogram name                    
                parameters.Add(GetParameter("name_subprogram", DbType.AnsiString, subprogram.GetName()));
                //utworz parametr description                    
                parameters.Add(GetParameter("description", DbType.AnsiString, subprogram.GetDescription()));

                //Wykonaj procedure dodawania programu
                aRes = PerformFunctionDB("\"AddSubprogram\"", parameters);
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja modyfikuje dane w bazie danych dla tabeli subprogram. 
        public int ModifySubprogram(Program.Subprogram subprogram)
        {
            int aRes = -1;
            if (subprogram != null)
            {
                //Przygotuj parametry dla procedury dodawania subprogramu powiazanego z programem
                List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

                //utworz parametr program id                    
                parameters.Add(GetParameter("id", DbType.Int32, subprogram.ID));
                //utworz parametr subprogram name                    
                parameters.Add(GetParameter("name", DbType.AnsiString, subprogram.GetName()));
                //utworz parametr description                    
                parameters.Add(GetParameter("description", DbType.AnsiString, subprogram.GetDescription()));

                //Wykonaj procedure dodawania programu
                aRes = PerformFunctionDB("\"ModifySubprogram\"", parameters);

                //Modyfikuj tabele zwiazane z prcesami
                ModifySubprogramStages_1(subprogram);
                ModifySubprogramStages_2(subprogram);
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja modyfikuje dane w bazie danych dla tabel powiazanych z danym subprogramem i przechowujacych info na temat jego parametrow odnosnie:
        //vent, purgu, pump oraz zasilacza. 
        public int ModifySubprogramStages_1(Program.Subprogram subprogram)
        {
            int aRes = -1;
            if (subprogram != null && subprogram.GetVentProces() != null && subprogram.GetPlasmaProces() != null && subprogram.GetPumpProces() != null && subprogram.GetPurgeProces() != null)
            {
                //Przygotuj parametry dla procedury dodawania subprogramu powiazanego z programem
                List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

                //utworz liste parametrow dla funkcji ModifySubprogramStages_1
                parameters.Add(GetParameter("id_subprogram", DbType.Int32, subprogram.ID));
                parameters.Add(GetParameter("time_vent", DbType.Time, subprogram.GetVentProces().GetTimeVent()));
                parameters.Add(GetParameter("time_purge", DbType.Time, subprogram.GetPurgeProces().GetTimePurge()));
                parameters.Add(GetParameter("time_pump", DbType.Time, subprogram.GetPumpProces().GetTimeWaitForPumpDown()));
                parameters.Add(GetParameter("setpoint_pressure_pump", DbType.Single, (float)subprogram.GetPumpProces().GetSetpoint()));
                parameters.Add(GetParameter("setpoint_power_supply", DbType.Single, (float)subprogram.GetPlasmaProces().GetSetpointValue()));
                parameters.Add(GetParameter("mode", DbType.Int32, (int)subprogram.GetPlasmaProces().GetWorkMode()));
                parameters.Add(GetParameter("max_devation_power_supply", DbType.Single, (float)subprogram.GetPlasmaProces().GetDeviation()));
                parameters.Add(GetParameter("time_duration_power_supply", DbType.Time, subprogram.GetPlasmaProces().GetTimeOperate()));

                //Wykonaj procedure dodawania programu
                aRes = PerformFunctionDB("\"ModifySubprogramStages_1\"", parameters);
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja modyfikuje dane w bazie danych dla tabel powiazanych z danym subprogramem i przechowujacych info na temat jego parametrow odnosnie sterowania gazami:
        public int ModifySubprogramStages_2(Program.Subprogram subprogram)
        {
            int aRes = -1;
            if (subprogram != null && subprogram.GetGasProces() != null)
            {
                Program.GasProces gas = subprogram.GetGasProces();
                //Przygotuj parametry dla procedury dodawania subprogramu powiazanego z programem
                List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

                //utworz liste parametrow dla funkcji ModifySubprogramStages_2 - edycja tabeli przechowujacej info na temat sterowania gazami
                parameters.Add(GetParameter("id_subprogram", DbType.Int32, subprogram.ID));
                parameters.Add(GetParameter("active_mfc1", DbType.Boolean, gas.GetActiveFlow(1)));
                parameters.Add(GetParameter("active_mfc2", DbType.Boolean, gas.GetActiveFlow(2)));
                parameters.Add(GetParameter("active_mfc3", DbType.Boolean, gas.GetActiveFlow(3)));
                parameters.Add(GetParameter("active_vaporaiser", DbType.Boolean, gas.GetVaporiserActive()));
                parameters.Add(GetParameter("flow_mfc1", DbType.Single, (float)gas.GetGasFlow(Types.UnitFlow.sccm, 1)));
                parameters.Add(GetParameter("flow_mfc2", DbType.Single, (float)gas.GetGasFlow(Types.UnitFlow.sccm, 2)));
                parameters.Add(GetParameter("flow_mfc3", DbType.Single, (float)gas.GetGasFlow(Types.UnitFlow.sccm, 3)));
                parameters.Add(GetParameter("min_flow_mfc1", DbType.Single, (float)gas.GetMinGasFlow(1)));
                parameters.Add(GetParameter("min_flow_mfc2", DbType.Single, (float)gas.GetMinGasFlow(2)));
                parameters.Add(GetParameter("min_flow_mfc3", DbType.Single, (float)gas.GetMinGasFlow(3)));
                parameters.Add(GetParameter("max_flow_mfc1", DbType.Single, (float)gas.GetMaxGasFlow(1)));
                parameters.Add(GetParameter("max_flow_mfc2", DbType.Single, (float)gas.GetMaxGasFlow(2)));
                parameters.Add(GetParameter("max_flow_mfc3", DbType.Single, (float)gas.GetMaxGasFlow(3)));
                parameters.Add(GetParameter("vaporaiser_cycle", DbType.Single, (float)gas.GetCycleTime()));
                parameters.Add(GetParameter("vaporaiser_time_on", DbType.Single, (float)gas.GetOnTime()));
                parameters.Add(GetParameter("setpoint_press", DbType.Single, (float)gas.GetSetpointPressure()));
                parameters.Add(GetParameter("max_dev_up", DbType.Single, (float)gas.GetMaxDeviationPresure()));
                parameters.Add(GetParameter("max_dev_down", DbType.Single, (float)gas.GetMinDeviationPresure()));
                parameters.Add(GetParameter("mfc1_max_dev", DbType.Single, (float)gas.GetShareDevaition(1)));
                parameters.Add(GetParameter("mfc2_max_dev", DbType.Single, (float)gas.GetShareDevaition(2)));
                parameters.Add(GetParameter("mfc3_max_dev", DbType.Single, (float)gas.GetShareDevaition(3)));
                parameters.Add(GetParameter("mfc1_gas_share", DbType.Single, (float)gas.GetShareGas(1)));
                parameters.Add(GetParameter("mfc2_gas_share", DbType.Single, (float)gas.GetShareGas(2)));
                parameters.Add(GetParameter("mfc3_gas_share", DbType.Single, (float)gas.GetShareGas(3)));
                parameters.Add(GetParameter("time", DbType.Time, gas.GetTimeProcesDuration()));
                parameters.Add(GetParameter("mode_process", DbType.Int32, gas.GetModeProces()));

                //Wykonaj procedure dodawania programu
                aRes = PerformFunctionDB("\"ModifySubprogramStages_2\"", parameters);
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja usuwa subprogram z bazy danych. Jezeli operacja sie powiedzia xwraca 0 w przeciwnym wypadku wartosc rozna od 0
        public int RemoveSubprogram(Program.Subprogram subprogram)
        {
            int aRes = -1;
            if (subprogram != null)
            {
                //Przygotuj parametry dla procedury usuwania standardowo rekordu z bazy danych to naczy funkcja posiada tylko jeden parametr o nazwie ID
                List<NpgsqlParameter> parameters = GetRemoveStandardParameters((int)subprogram.ID);
                //Wykonaj procedure usuwania subprogramu
                aRes = PerformFunctionDB("\"RemoveSubprogram\"", parameters);
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie zarejestrowanie urzadzenia w bazie danych
        public int RegisterDevice(Device device)
        {
            int aRes = -1;
            if (device != null)
            {
                //jezeli urzadzenie nie zostal jeszcze zarejestrowany to go zarejestruj
                if (device.ID_DB <= 0 && device.Name != null)
                {
                    //Przygotuj parametry dla procedury rejestracji urzadzenia w bazie danych
                    List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
                    parameters.Add(GetParameter("dev_name", DbType.AnsiString, device.Name));
                    //Wykonaj procedure rejestracji urzadzenia w bazie danych subprogramu
                    int id = PerformFunctionDB("\"RegisterDevice\"", parameters); //procedura zwraca id utworzonego 
                    if (id > 0)
                    {
                        device.ID_DB = id;
                        aRes = 0;
                    }
                }
                else
                    aRes = 0;
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie zarejestrowanie listy parametrow w bazie danych
        public int RegisterParameters(int idDevice, List<Parameter> parameters)
        {
            int aRes = -1;
            int aCountOK = 0; // liczba poprawnie zapisanych parametrow
            if (parameters != null)
            {
                foreach (Parameter para in parameters)
                {
                    //jezeli parametr nie zostal jeszcze zarejestrowany to go zarejestruj
                    if (para.ID <= 0)
                    {
                        //Przygotuj parametry dla procedury rejestracji urzadzenia w bazie danych
                        List<NpgsqlParameter> parametersDB = new List<NpgsqlParameter>();
                        parametersDB.Add(GetParameter("dev_id", DbType.Int32, idDevice));
                        parametersDB.Add(GetParameter("para_name", DbType.AnsiString, para.Name));
                        //Wykonaj procedure rejestracji urzadzenia w bazie danych subprogramu
                        int id = PerformFunctionDB("\"RegisterParameter\"", parametersDB); //procedura zwraca id utworzonego 
                        if (id > 0)
                        {
                            para.ID = id;
                            aCountOK++;
                        }
                    }
                    else
                        aCountOK++;
                }
                if (aCountOK == parameters.Count)
                    aRes = 0;
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie zarejestrowanie urzadzenia w bazie danych
        public int AddData(DataBaseData data)
        {
            int aRes = -1;

            if (data.ValuePtr != null)
            {
                //Przygotuj parametry dla procedury rejestracji urzadzenia w bazie danych
                List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
                parameters.Add(GetParameter("para_id", DbType.Int32, data.ID_Para));
                parameters.Add(GetParameter("value_", DbType.Single, (float)data.Value));
                parameters.Add(GetParameter("unit_", DbType.AnsiString, data.Unit));
                parameters.Add(GetParameter("date_", DbType.DateTime, data.Date));
                //Wykonaj procedure zapisu danych pomiarowytch w bazie danych jako danych historycznych
                aRes = PerformFunctionDB("\"AddData\"", parameters); //procedura zwraca id utworzonego 
                //jezeli udalo sie zapisac to ustaw wartosc jako ostania zapisna do bazy
                if (aRes > 0)
                    data.ValuePtr.LastValueDB = data.Value;
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie zapis daty poczatku sesji zapisu danych do bazy danych
        public int StartSesion()
        {
            int aRes = -1;

            //Przygotuj parametry dla procedury rejestracji urzadzenia w bazie danych
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            parameters.Add(GetParameter("start_date", DbType.DateTime, DateTime.Now));
            //Wykonaj procedurerozpoczecia sesji zapisu danych do bazy danych
            aRes = PerformFunctionDB("\"StartSesion\"", parameters); //procedura zwraca id utworzonego 

            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie pobranie danych z bazy danych z danego okresu
        public List<DataBaseData> GetHistoryData(DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            List<DataBaseData> listData = new List<DataBaseData>();

            //Przygotuj parametry dla procedury rejestracji urzadzenia w bazie danych
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            parameters.Add(GetParameter("StartDate", DbType.DateTime, dateTimeStart));
            parameters.Add(GetParameter("EndDate", DbType.DateTime, dateTimeEnd));
            //Wykonaj procedurerozpoczecia sesji zapisu danych do bazy danych
            DataSet dataSet = null;
            PerformFunctionDB("\"GetData\"", parameters, out dataSet); //procedura zwraca id utworzonego 

            if (dataSet != null)
            {
                if (dataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        //if(dataSet.Tables[0].Rows[i].ItemArray. == 5)
                        {
                            DataBaseData data = new DataBaseData();

                            data.ID_Para = (int)dataSet.Tables[0].Rows[i].ItemArray[1];
                            data.Value = (float)dataSet.Tables[0].Rows[i].ItemArray[2];
                            data.Date = (DateTime)dataSet.Tables[0].Rows[i].ItemArray[4];

                            listData.Add(data);
                        }
                    }
                }
            }
            //Wykonaj korekcje danych o zakres sesji to znaczy wprowadz wartosci pomiedzy punkty nalezace do roznych sesji aby nie rysowac miedzy nimi lini na wykresie
            CorectDataAboutSesion(listData);
            //Posortuj liste po datach rosnaco aby wykres zostal poprawnie narysowany
            SortList(listData);
            return listData;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie wstawianie pkt zero pomiedzy dwa sasiednie punkty nalezacy do roznych sesji. Ma to na celu przerywanie lini na wykresie aby nie sugerowac userowi ze dane byly odczydtywane w sytuacji gdy ich nie bylo
        private void CorectDataAboutSesion(List<DataBaseData> listData)
        {
            if(listData != null)
            {
                DataBaseData dataFirst;
                DataBaseData dataNext;
                //Posortuj liste po datach rosnaco
                SortList(listData);
                for (int i = 0; i < listData.Count - 1; i++)
                {
                    //Pobierz dwa sąsiednie punkty tego samego parametru
                    dataFirst   = listData[i];
                    dataNext    = GetNextPara(listData, dataFirst.ID_Para, i + 1);
                    //Jezeli zostal znaleziony sasiedni punkt i wartosc pierwszego jezt rozna od zera to dodaj dodatkowe punkty 0 aby nie rysowac danych na wykresie dla nieistniejacych sesji
                    if (dataFirst.ID_Para == dataNext.ID_Para && dataFirst.Value != 0)
                    {
                        //Podaj mi id sesji do ktorej nalezy dany punkt
                        int idSesionFirstPkt = GetIdSesion(dataFirst.Date);
                        int idSesionNextPkt = GetIdSesion(dataNext.Date);
                        //Sprawdzam czy oba punkty naleza do tej samej sesji jezeli nie to dla obydwu dodaje punkt 0 co spowoduje sciagniecie wykresu do wartosci 0
                        if(idSesionFirstPkt != idSesionNextPkt)
                        {
                            DataBaseData newDataFirst = new DataBaseData();
                            newDataFirst.ID_Para  = dataFirst.ID_Para;
                            newDataFirst.Unit     = dataFirst.Unit;
                            newDataFirst.Date     = dataFirst.Date.AddSeconds(1);
                            newDataFirst.ValuePtr = dataFirst.ValuePtr;
                            newDataFirst.Value    = 0;

                            DataBaseData newDataNext = new DataBaseData();
                            newDataNext.ID_Para  = dataNext.ID_Para;
                            newDataNext.Unit     = dataNext.Unit;
                            newDataNext.Date     = dataNext.Date.AddSeconds(-1);
                            newDataNext.ValuePtr = dataNext.ValuePtr;
                            newDataNext.Value    = 0;

                            listData.Add(newDataFirst);
                            listData.Add(newDataNext);
                        }
                    }
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie zwrocenie id sesji do ktroej nalezy dany punkt
        private int GetIdSesion(DateTime date)
        {
            int aId = 0;
            if (GetSesions() != null)
            {
                foreach (Sesion sesion in GetSesions())
                {
                    if (date >= sesion.StartDate && date <= sesion.EndDate)
                        aId = sesion.ID;
                }
            }         
            return aId;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcaj ma za zadanie podanie nastepnego punkty tego samego parametru z listy
        private DataBaseData GetNextPara(List<DataBaseData> listData,int idPara,int index)
        {
            DataBaseData data = new DataBaseData();
            for (int i = index; i < listData.Count ; i++)
            {
                //Pobierz pierwszy z brzegu punkt tego samego parametru ktroy zostal przekazany jako parametr
                if(listData[i].ID_Para == idPara)
                {
                    data = listData[i];
                    break;
                }
            }
            return data;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie sortowanie listy
        private void SortList(List<DataBaseData>listData)
        {
            if (listData != null)
            {
                for (int i = 0; i < listData.Count; i++)
                {
                    for (int j = 0; j < listData.Count - 1; j++)
                    {
                        if (listData[j].Date > listData[j + 1].Date)
                        {
                            DataBaseData data = listData[j];
                            listData[j] = listData[j + 1];
                            listData[j + 1] = data;
                        }
                    }
                }
            }
        } 
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie utworzenie lsity parametrow sla standardowej funkcji usuwania rekordu za bazy danych posiadajacej tylko jedne parametro nazwie ID
        private List<NpgsqlParameter> GetRemoveStandardParameters(int aId)
        {
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

           //utworz parametr id                    
            parameters.Add(GetParameter("id", DbType.Int32, aId));

            return parameters;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie utworzenie parametrow procedury Add/Modify user 
        private List<NpgsqlParameter> GetUserParameters(User user, TypeFillParameters typeFill)
        {
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
      
            //Wpraowdz parametr ID. Jest on wymagany dla procedur Remove oraz Modify
            if (typeFill == TypeFillParameters.ModifyUser || typeFill == TypeFillParameters.RemoveUser)
            {
                //utworz parametr id 
                parameters.Add(GetParameter("id", DbType.Int32, user.ID));
            }
            //WPrawdz parametry funkcji New/Modify na podstawie ustawien usera
            if (typeFill == TypeFillParameters.ModifyUser || typeFill == TypeFillParameters.NewUser)
            {
                //utworz parametr name 
                parameters.Add(GetParameter("name", DbType.AnsiString, user.Name));
                //utworz parametr surnname                    
                parameters.Add(GetParameter("surname", DbType.AnsiString, user.Surname));
                //utworz parametr login                    
                parameters.Add(GetParameter("login", DbType.AnsiString, user.Login));  
                //utworz parametr password                    
                parameters.Add(GetParameter("password", DbType.AnsiString, user.Password));  
                //utworz parametr allow_change psw                    
                parameters.Add(GetParameter("allow_change_psw", DbType.Boolean, user.AllowChangePsw));
                //utworz parametr typ blokowania usera                    
                parameters.Add(GetParameter("type_block", DbType.Int32, user.DisableAccount)); 
                //utworz parametr uprawnienia                    
                parameters.Add(GetParameter("privilige", DbType.Int32, user.Privilige));
                //utworz parametr data poczaktu ewentualnej blokady                    
                parameters.Add(GetParameter("start_date_block", DbType.Date, user.DateStartDisableAccount));
                //utworz parametr data konca ewentualnej blokady                      
                parameters.Add(GetParameter("end_date_block", DbType.Date, user.DateEndDisableAccount));
            }
            return parameters;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie utworzenie parametrow procedury Add/Modify dla programu 
        private List<NpgsqlParameter> GetProgramParameters(Program.Program program, TypeFillParameters typeFill)
        {
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlParameter para = null;
            if (program != null)
            {
                //Wpraowdz parametr ID. Jest on wymagany dla procedur Remove oraz Modify
                if (typeFill == TypeFillParameters.ModifyUser || typeFill == TypeFillParameters.RemoveUser)
                {
                    //utworz parametr id                    
                    parameters.Add(GetParameter("id", DbType.Int32, program.GetID()));
                }
                //WPrawdz parametry funkcji New/Modify na podstawie ustawien usera
                if (typeFill == TypeFillParameters.ModifyUser || typeFill == TypeFillParameters.NewUser)
                {
                    //utworz parametr name 
                    parameters.Add(GetParameter("name", DbType.AnsiString, program.GetName()));
                    //utworz parametr surnname                    
                    parameters.Add(GetParameter("description", DbType.AnsiString, program.GetDescription()));
                }
            }
            return parameters;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie utworzenie parametrow procedury Add/Modify dla subprogramu 
        private List<NpgsqlParameter> GetSubprogramParameters(Program.Subprogram subprogram, TypeFillParameters typeFill)
        {
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlParameter para = null;
            if (subprogram != null)
            {
                //Wpraowdz parametr ID. Jest on wymagany dla procedur Remove oraz Modify
                if (typeFill == TypeFillParameters.ModifyUser || typeFill == TypeFillParameters.RemoveUser)
                {
                    //utworz parametr id                    
                    parameters.Add(GetParameter("id", DbType.Int32, subprogram.ID));
                }
                //WPrawdz parametry funkcji New/Modify na podstawie ustawien usera
                if (typeFill == TypeFillParameters.ModifyUser || typeFill == TypeFillParameters.NewUser)
                {
                    //utworz parametr name 
                    parameters.Add(GetParameter("name" , DbType.AnsiString , subprogram.GetName()));

                    //utworz parametr surnname                    
                    parameters.Add(GetParameter("description", DbType.AnsiString, subprogram.GetDescription()));
                }
            }
            return parameters;
        }
        //-------------------------------------------------------------------------------------
        private NpgsqlParameter GetParameter(string name, DbType type, object value)
        {
            NpgsqlParameter para = new NpgsqlParameter();       //utworz parametr description                    

            para.ParameterName  = name;
            para.DbType         = type;
            para.Value          = value;

            return para;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie przekopiowanie parametrow z lity do parametrow komendy utworzonych na bazie obiektu komendy
        public void PrepareParameters(NpgsqlCommand cmd, List<NpgsqlParameter> parameters)
        {
            if (cmd != null && parameters != null)
            {
                NpgsqlParameter paraCMD = null;
                foreach (NpgsqlParameter para in parameters)
                {
                    paraCMD = cmd.CreateParameter();       //utworz parametr name                    
                    paraCMD.ParameterName = para.ParameterName;
                    paraCMD.DbType = para.DbType;
                    paraCMD.Value = para.NpgsqlValue;
                    cmd.Parameters.Add(paraCMD);
                }
            }
        }
        //-------------------------------------------------------------------------------------
        private int PerformFunctionDB(string functionName, List<NpgsqlParameter> parameters)
        {
            int aRes = -1;
            NpgsqlTransaction trans = null;
            try
            {
                trans = conn.BeginTransaction();   //Rozpoczecie tranzakcji
                //Powolonie pbiektu komendy i nadaniu mu komendy jako nazwy procedury ktora ma wykonac. Nazwa musi byc w cudzyslowiach bo wtedy sa rozpoznawane duze i male litery
                NpgsqlCommand cmd = new NpgsqlCommand(functionName, conn); 
                //Ustawienie komendy jako komendy dla ProceduryStorowanej
                cmd.CommandType = CommandType.StoredProcedure;              
                //Uzupelnij liste parametrow
                PrepareParameters(cmd, parameters);
                //Przygotuj obiekty wymagane do wykonania procedure
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                //wypelnij data set danymi odebrannymi z procedury
                data.Fill(ds);
                //Odbierz wynik zwracany funkcje przez bazy danych
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    aRes = (int)ds.Tables[0].Rows[0].ItemArray[0];
            }
            //Jezeli zdazyl sie jakis problem to zglos to
            catch (Exception ex)
            {
                Logger.AddException(ex);
             }
            //Zakonczenie tranzakcji
            finally
            {
                if (trans != null)
                    trans.Commit();
            }

            return aRes;
        }
        //-------------------------------------------------------------------------------------
        private int PerformFunctionDB(string functionName, List<NpgsqlParameter> parameters, out DataSet ds)
        {
            int aRes = -1;
            ds = new DataSet();
            NpgsqlTransaction trans = null;
            try
            {
                trans = conn.BeginTransaction();   //Rozpoczecie tranzakcji
                //Powolonie pbiektu komendy i nadaniu mu komendy jako nazwy procedury ktora ma wykonac. Nazwa musi byc w cudzyslowiach bo wtedy sa rozpoznawane duze i male litery
                NpgsqlCommand cmd = new NpgsqlCommand(functionName, conn);
                //Ustawienie komendy jako komendy dla ProceduryStorowanej
                cmd.CommandType = CommandType.StoredProcedure;
                //Uzupelnij liste parametrow
                PrepareParameters(cmd, parameters);
                //Przygotuj obiekty wymagane do wykonania procedure
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmd);
                //wypelnij data set danymi odebrannymi z procedury
                data.Fill(ds);
                //Odbierz wynik zwracany funkcje przez bazy danych
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    aRes = (int)ds.Tables[0].Rows[0].ItemArray[0];
            }
            //Jezeli zdazyl sie jakis problem to zglos to
            catch (Exception ex)
            {
                Logger.AddException(ex);
            }
            //Zakonczenie tranzakcji
            finally
            {
                if (trans != null)
                    trans.Commit();
            }
            return aRes;
        }
        //-------------------------------------------------------------------------------------
        public DB()
        {
            Open();

            ErrorText aErrorText;

            //Tymczasowe dodanie tekstow dla bledow aplilacko
            aErrorText = new ErrorText((int)Types.EventCategory.APLICATION, (int)Types.EventType.BAD_CYCLE_TIME, 0, "BAD_CYCLE_TIME", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.APLICATION, (int)Types.EventType.BAD_FLOW_ID, 0, "BAD_FLOW_ID", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.APLICATION, (int)Types.EventType.BAD_ON_TIME, 0, "BAD_ON_TIME", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.APLICATION, (int)Types.EventType.CALL_INCORRECT_OPERATION, 0, "CALL_INCORRECT_OPERATION", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.APLICATION, (int)Types.EventType.NO_PRG_IN_PLC, 0, "W pamieci PLC nie posiada zadnego zaladowanego procesu", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.APLICATION, (int)Types.EventType.PLC_PTR_NULL, 0, "PLC_PTR_NULL", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.APLICATION, (int)Types.EventType.MX_COMPONENTS_NO_INSTALL, 0, "MX Components not installed. Communication with PLC is impossible", Types.Language.English);
            actionTextList.Add(aErrorText);

            //Tymczasowe dodanie tekstow dla bledow MX Components
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_FLOW, 1, "Nie moge ustawic przeplywu. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MAX_FLOW, 1, "Nie moge ustawic max przeplywu. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_RANGE_VOLTAGE_MFC, 1, "Nie moge ustawic zakresu napiec dla przeplywki. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_TIME_FLOW_STABILITY, 1, "Nie moge ustawic czasu stabilizacji przeplywu przeplywki. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.START_PROGRAM, 1, "Nie mofe uruchomic programu. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.STOP_PROGRAM, 1, "Nie moge zatrzymac programu. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.UPDATE_SETINGS, 1, "Nie moge zaktualizowac ustawien urzadzen PLC. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.WRITE_PROGRAM, 1, "Nie moge zaladowac programu do PLC. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_PRESSURE_SETPOINT, 1, "Nie moge ustawic setpointa cisnienia komory. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_SETPOINT_HV, 1, "Nie moge ustawic setpointa dla zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MODE, 1, "Nie moge ustawic trybu pracy zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_OPERATE_HV, 1, "Nie moge ustawic trybu operate zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_LIMIT_CURRENT_HV, 1, "NNie moge ustawic limitu pradu zasilacza HV. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_LIMIT_POWER_HV, 1, "Nie moge ustawic limitu mocy zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_LIMIT_VOLTAGE_HV, 1, "Nie moge ustawic limitu napiecia zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MAX_CURENT_HV, 1, "Nie moge ustawic max pradu zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MAX_POWER_HV, 1, "Nie moge ustawic max mocy zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MAX_VOLTAGE_HV, 1, "Nie moge ustawic max napiecia zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_WAIT_TIME_OPERATE_HV, 1, "Nie moge ustawic czasu oczekiwania na stan operate . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_WAIT_TIME_SETPOINT_HV, 1, "Nie moge ustawic czasu oczekiwania na stavilizacje sie wartosci . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.CONTROL_PUMP, 1, "Nie moge zmienic stanu pracy pompy wstepnej . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_WIAT_TIME_PF, 1, "Nie moge ustawic czasu oczekiwania na poprawny stan pompy wstepnej . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_TIME_PUMP_TO_SV, 1, "Nie moge ustawic czasu pompowania do zaworu HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_CYCLE_TIME, 1, "Nie moge ustawic czasu cyklu pracy vaporatora . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_ON_TIME, 1, "Nie moge ustawic czasu wlaczenia vaporatora. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_STATE_VALVE, 1, "Nie moge ustawic . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MODE_PRESSURE ,1, "Nie moge ustawic trybu oracy cisnieniowego komory. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.NO_SELECT_PROGRAM_TO_RUN, 1, "Nie mozna uruchomic programu poniewaz nie wybrano zadnego do uruchomienia . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MODE_CONTROL, 1, "Nie moge ustawic trybu pracy . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);

            //Tymczasowe dodanie tekstow dla akcji usera
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_FLOW, 0, "Przeplyw zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MAX_FLOW, 0, "Max przeplyw zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_RANGE_VOLTAGE_MFC, 0, "Zakresu napiec dla przeplywki zostal ustawiony. ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_TIME_FLOW_STABILITY, 0, "Czasu stabilizacji przeplywu przeplywki zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.START_PROGRAM, 0, "Programu zostal uruchomiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.STOP_PROGRAM, 0, "Programu zostal zatrzymany.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.UPDATE_SETINGS, 0, "Ustawienia urzadzen PLC zostaly poprawnie odczytane.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.WRITE_PROGRAM, 0, "Programu do PLC zostal poprawnie zaladowany.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_PRESSURE_SETPOINT, 0, "Setpointa cisnienia komory zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_SETPOINT_HV, 0, "Setpointa dla zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MODE, 0, "Tryb pracy zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_OPERATE_HV, 0, "Tryb operate zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_LIMIT_CURRENT_HV, 0, "Limitu pradu zasilacza HV zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_LIMIT_POWER_HV, 0, "Limitu mocy zasilacza HV zostal ustawiony ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_LIMIT_VOLTAGE_HV, 0, "Limitu napiecia zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MAX_CURENT_HV, 0, "Max pradu zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MAX_POWER_HV, 0, "Max mocy zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MAX_VOLTAGE_HV, 0, "Max napiecia zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_WAIT_TIME_OPERATE_HV, 0, "Czas oczekiwania na stan operate zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_WAIT_TIME_SETPOINT_HV, 0, "Czas oczekiwania na stavilizacje sie wartosci zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.CONTROL_PUMP, 0, "Stan pracy pompy wstepnej zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_WIAT_TIME_PF,0, "Czas oczekiwania na poprawny stan pompy wstepnej  zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_TIME_PUMP_TO_SV, 0, "Czas pompowania do zaworu HV zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_CYCLE_TIME, 0, "Czas cyklu pracy vaporatora zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_ON_TIME, 0, "Czas wlaczenia vaporatora zostal ustawiony ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_STATE_VALVE, 0, "Stan zaworu zostal poprawnie zmioniony . ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MODE_PRESSURE, 0, "Trybu pracy cisnieniowego komory zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.MX_COMPONENTS, (int)Types.EventType.SET_MODE_CONTROL, 0, "Tryb pracy zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);

            //Tymczasowe dodanie tekstow dla bledow PLC
            aErrorText = new ErrorText((int)Types.EventCategory.PLC,(int)Types.EventType.PLC_ERROR, 1, "Nie moge wykonac programu poniewaz nie moge znalezc znacznika konca", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 2, "Nie moge wykonac programu poniewaz drzwi komory sa ciagle otwarte", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 3, "Nie moge wykonac programu poniewaz glowne zasilanie jst wylaczone", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 109, "Blad wykonania programu. Przekroczony zostal czas oczekiwania na odpompowanie komory", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 110, "Blad wykonania programu. Pompa wstępna zglasza problem", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 115, "Blad wykonania programu. Prcedura ventowania zostala przerwana poniewaz pompa wstepna jest wlaczona", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 116, "Blad wykonania programu. Brak potwierdzenia wlaczenia zasilacza plazmy", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 117, "Blad wykonania programu. Proba ustawienia nastawy zasilacza plazmy spoza dopuszczalnego zakresu", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 118, "Blad wykonania programu. Zasilacz plazmy zglasza problem sprzętowy", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 119, "Blad wykonania programu. Wartosc nastawy zasilacza plazmy nie moze sie ustabilizowac pomiedzy zadanymi widelkami", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 120, "Blad wykonania programu. Wybrano niepoprawny tryb pracy zasilacza plazmy", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 121, "Blad wykonania programu. Niepoprawne ustawienie limitow nastawy zasilacza plazmy. Nie moga byc 0 ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 122, "Blad wykonania programu. Wartosc nastawy przeplywu dla MFC1 jest poza zakresem pracy przeplwyki", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 123, "Blad wykonania programu. Wartosc przeplywu dla MFC1 nie potrafi się ustabilizowac pomiedzy zadanymi widelkami ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 124, "Blad wykonania programu. Wartosc nastawy przeplywu dla MFC2 jest poza zakresem pracy przeplwyki", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 125, "Blad wykonania programu. Wartosc przeplywu dla MFC2 nie potrafi się ustabilizowac pomiedzy zadanymi widelkami ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 126, "Blad wykonania programu. Wartosc nastawy przeplywu dla MFC3 jest poza zakresem pracy przeplwyki", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.EventCategory.PLC, (int)Types.EventType.PLC_ERROR, 127, "Blad wykonania programu. Wartosc przeplywu dla MFC3 nie potrafi się ustabilizowac pomiedzy zadanymi widelkami ", Types.Language.English);
            actionTextList.Add(aErrorText);

        }
        //-------------------------------------------------------------------------------------
        private void FillErrorTextList()
        {

        }
        //-------------------------------------------------------------------------------------
        //Podaj tekst dla danego bledu pobrany z bazy danych
        public static string GetErrorText(ItemLogger aError)
        {
            string aTxt = "No text in data base for action code:" + aError.GetErrorCode().ToString("X8");

            int aErrCode = aError.ErrCode;
            //MX Componts zawiera kod bledu jako Event poniewaz w polu bledu posiada blad MX Componts
            if (aError.EventCategory == Types.EventCategory.MX_COMPONENTS)
                aErrCode = (int)aError.EventType;


            foreach (ErrorText errorText in actionTextList)
            {
                if (errorText.EventType == aError.EventType && errorText.EventCategory == aError.EventCategory && errorText.Language == Driver.HPT1000.LanguageApp)
                {
                    if (aErrCode == errorText.ErrCode)
                    {
                        if (aError.ErrCode != 0)
                            aTxt = errorText.Text + aError.ErrCode.ToString("X8"); // wystapil blad                       
                        else
                            aTxt = errorText.Text; // wystapila akcja
                    }
                }
            }
            /*
            foreach (ErrorText errorText in actionTextList)
            {
                if (aError.EventCategory == Types.EventCategory.MX_COMPONENTS || aError.EventCategory == Types.EventCategory.APLICATION)
                {
                    if (errorText.Code == aError.EventType && errorText.Category == aError.EventCategory && errorText.Language == Driver.HPT1000.LanguageApp)
                    {
                        if (aError.ExtCode != 0 && errorText.ExtCode != 0) // wystapil blad
                            aTxt = errorText.Text + aError.ExtCode.ToString("X8");
                        if (aError.ExtCode == 0 && errorText.ExtCode == 0) // wystapila akcja
                            aTxt = errorText.Text;
                    }
                }
                else
                {
                    if (errorText.Code == aError.Code && errorText.ExtCode == aError.ExtCode && errorText.Category == aError.Category && errorText.Language == Driver.HPT1000.LanguageApp)
                        aTxt = errorText.Text;
                }
            }
            */
            return aTxt;
        }
    
    }
}
