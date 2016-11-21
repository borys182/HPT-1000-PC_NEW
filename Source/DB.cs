using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using Npgsql;

using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

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
        private static List<ErrorText>  actionTextList  = new List<ErrorText>();

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
            catch (Exception ex){
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
            catch(Exception ex){
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
            NpgsqlCommand cmd = new NpgsqlCommand(query,conn);
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
                catch (Exception ex){
                    Logger.AddException(ex);
                }
            }
            data.Close();
        
            return users;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja dodaje usera do bazy danych. Jezeli operacja sie powiedzia xwraca 0 w przeciwnym wypadku wartosc rozna od 0
        public int AddUser(User user)
        {
            int aRes = 0;
            List<NpgsqlParameter>parameters = GetUserParameters(user, TypeFillParameters.NewUser);
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
                List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
                NpgsqlParameter para = null;

                para = new NpgsqlParameter();       //utworz parametr name                    
                para.ParameterName = "name";
                para.DbType = DbType.AnsiString;
                para.Value = program.GetName();
                parameters.Add(para);

                para = new NpgsqlParameter();       //utworz parametr description                    
                para.ParameterName = "description";
                para.DbType = DbType.AnsiString;
                para.Value = program.GetDescription();
                parameters.Add(para);

                //Wykonaj procedure dodawania programu
                aRes = PerformFunctionDB("\"NewProgram\"", parameters);
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja dodaje do bazy danych subprogram. Powiazanie subprogramu z programem odbywa sie juz po stronie bazy danych w funkcji AddSubprpgram
        public int AddSubProgram(Program.Subprogram subprogram,string programName)
        {
            int aRes = -1;
            if (subprogram != null)
            {
                //Przygotuj parametry dla procedury dodawania subprogramu powiazanego z programem
                List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
                NpgsqlParameter para = null;

                para = new NpgsqlParameter();       //utworz parametr program name                    
                para.ParameterName = "name_program";
                para.DbType = DbType.AnsiString;
                para.Value = programName;
                parameters.Add(para);

                para = new NpgsqlParameter();       //utworz parametr subprogram name                    
                para.ParameterName = "name_subprogram";
                para.DbType = DbType.AnsiString;
                para.Value = subprogram.GetName();
                parameters.Add(para);

                para = new NpgsqlParameter();       //utworz parametr description                    
                para.ParameterName = "description";
                para.DbType = DbType.AnsiString;
                para.Value = subprogram.GetDescription();
                parameters.Add(para);

                //Wykonaj procedure dodawania programu
                aRes = PerformFunctionDB("\"NewProgram\"", parameters);
            }
            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie utworzenie parametrow procedury Add/Modify user 
        private List<NpgsqlParameter> GetUserParameters(User user, TypeFillParameters typeFill)
        {
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlParameter para = null;
            //Wpraowdz parametr ID. Jest on wymagany dla procedur Remove oraz Modify
            if (typeFill == TypeFillParameters.ModifyUser || typeFill == TypeFillParameters.RemoveUser)
            {
                para = new NpgsqlParameter();       //utworz parametr name                    
                para.ParameterName = "id";
                para.DbType = DbType.Int32;
                para.Value = user.ID;
                parameters.Add(para);
            }
            //WPrawdz parametry funkcji New/Modify na podstawie ustawien usera
            if (typeFill == TypeFillParameters.ModifyUser || typeFill == TypeFillParameters.NewUser)
            {
                para = new NpgsqlParameter();       //utworz parametr name                    
                para.ParameterName = "name";
                para.DbType = DbType.AnsiString;
                para.Value = user.Name;
                parameters.Add(para);

                para = new NpgsqlParameter();       //utworz parametr surnname                    
                para.ParameterName = "surname";
                para.DbType = DbType.AnsiString;
                para.Value = user.Surname;
                parameters.Add(para);

                para = new NpgsqlParameter();       //utworz parametr login                    
                para.ParameterName = "login";
                para.DbType = DbType.AnsiString;
                para.Value = user.Login;
                parameters.Add(para);

                para = new NpgsqlParameter();       //utworz parametr password                    
                para.ParameterName = "password";
                para.DbType = DbType.AnsiString;
                para.Value = user.Password;
                parameters.Add(para);

                para = new NpgsqlParameter();       //utworz parametr allow_change psw                    
                para.ParameterName = "allow_change_psw";
                para.DbType = DbType.Boolean;
                para.Value = user.AllowChangePsw;
                parameters.Add(para);

                para = new NpgsqlParameter();       //utworz parametr typ blokowania usera                    
                para.ParameterName = "type_block";
                para.DbType = DbType.Int32;
                para.Value = user.DisableAccount;
                parameters.Add(para);

                para = new NpgsqlParameter();       //utworz parametr uprawnienia                    
                para.ParameterName = "privilige";
                para.DbType = DbType.Int32;
                para.Value = user.Privilige;
                parameters.Add(para);

                para = new NpgsqlParameter();       //utworz parametr data poczaktu ewentualnej blokady                    
                para.ParameterName = "start_date_block";
                para.DbType = DbType.Date;
                para.Value = user.DateStartDisableAccount;
                parameters.Add(para);

                para = new NpgsqlParameter();       //utworz parametr data konca ewentualnej blokady                      
                para.ParameterName = "end_date_block";
                para.DbType = DbType.Date;
                para.Value = user.DateEndDisableAccount;
                parameters.Add(para);
            }
            return parameters;
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
