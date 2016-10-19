using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source
{
    struct ErrorText
    {
        public Types.ERROR_CATEGORY Category;
        public Types.ERROR_CODE     Code;
        public int                  ExtCode;
        public string               Text;
        public Types.Language       Language;

        public ErrorText(int aCategory,int aCode,int aExtCode,string aTxt,Types.Language aLanguage)
        {
            Category = (Types.ERROR_CATEGORY)aCategory;
            Code     = (Types.ERROR_CODE)aCode;
            ExtCode  = aExtCode; 
            Text     = aTxt;
            Language = aLanguage;
        }
    }
    /*
     * Klasa jest odpowiedzilana za komunikacje z baza danych oraz udostpenianie danych z niej pobranych. W bazie danych sa przechowywane informacje na temat:
     * : translacji tekstow , użytkowników i uprawnień, pomiarów, programów 
     */ 
    class DB
    {
        List<ErrorText> actionTextList = new List<ErrorText>();
      
        //-------------------------------------------------------------------------------------
        public DB()
        {
            ErrorText aErrorText;

            //Tymczasowe dodanie tekstow dla bledow aplilacko
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.APLICATION, (int)Types.ERROR_CODE.BAD_CYCLE_TIME, 0, "BAD_CYCLE_TIME", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.APLICATION, (int)Types.ERROR_CODE.BAD_FLOW_ID, 0, "BAD_FLOW_ID", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.APLICATION, (int)Types.ERROR_CODE.BAD_ON_TIME, 0, "BAD_ON_TIME", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.APLICATION, (int)Types.ERROR_CODE.CALL_INCORRECT_OPERATION, 0, "CALL_INCORRECT_OPERATION", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.APLICATION, (int)Types.ERROR_CODE.NO_PRG_IN_PLC, 0, "W pamieci PLC nie posiada zadnego zaladowanego procesu", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.APLICATION, (int)Types.ERROR_CODE.PLC_PTR_NULL, 0, "PLC_PTR_NULL", Types.Language.English);
            actionTextList.Add(aErrorText);

            //Tymczasowe dodanie tekstow dla bledow MX Components
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_FLOW, 1, "Nie moge ustawic przeplywu. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MAX_FLOW, 1, "Nie moge ustawic max przeplywu. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_RANGE_VOLTAGE_MFC, 1, "Nie moge ustawic zakresu napiec dla przeplywki. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_TIME_FLOW_STABILITY, 1, "Nie moge ustawic czasu stabilizacji przeplywu przeplywki. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.START_PROGRAM, 1, "Nie mofe uruchomic programu. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.STOP_PROGRAM, 1, "Nie moge zatrzymac programu. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.UPDATE_SETINGS, 1, "Nie moge zaktualizowac ustawien urzadzen PLC. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.WRITE_PROGRAM, 1, "Nie moge zaladowac programu do PLC. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_PRESSURE_SETPOINT, 1, "Nie moge ustawic setpointa cisnienia komory. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_SETPOINT_HV, 1, "Nie moge ustawic setpointa dla zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MODE, 1, "Nie moge ustawic trybu pracy zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_OPERATE_HV, 1, "Nie moge ustawic trybu operate zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_LIMIT_CURRENT_HV, 1, "NNie moge ustawic limitu pradu zasilacza HV. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_LIMIT_POWER_HV, 1, "Nie moge ustawic limitu mocy zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_LIMIT_VOLTAGE_HV, 1, "Nie moge ustawic limitu napiecia zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MAX_CURENT_HV, 1, "Nie moge ustawic max pradu zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MAX_POWER_HV, 1, "Nie moge ustawic max mocy zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MAX_VOLTAGE_HV, 1, "Nie moge ustawic max napiecia zasilacza HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_WAIT_TIME_OPERATE_HV, 1, "Nie moge ustawic czasu oczekiwania na stan operate . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_WAIT_TIME_SETPOINT_HV, 1, "Nie moge ustawic czasu oczekiwania na stavilizacje sie wartosci . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.CONTROL_PUMP, 1, "Nie moge zmienic stanu pracy pompy wstepnej . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_WIAT_TIME_PF, 1, "Nie moge ustawic czasu oczekiwania na poprawny stan pompy wstepnej . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_TIME_PUMP_TO_SV, 1, "Nie moge ustawic czasu pompowania do zaworu HV . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_CYCLE_TIME, 1, "Nie moge ustawic czasu cyklu pracy vaporatora . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_ON_TIME, 1, "Nie moge ustawic czasu wlaczenia vaporatora. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_STATE_VALVE, 1, "Nie moge ustawic . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MODE_PRESSURE ,1, "Nie moge ustawic trybu oracy cisnieniowego komory. MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.NO_SELECT_PROGRAM_TO_RUN, 1, "Nie mozna uruchomic programu poniewaz nie wybrano zadnego do uruchomienia . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MODE_CONTROL, 1, "Nie moge ustawic trybu pracy . MX Components zglasza blad: ", Types.Language.English);
            actionTextList.Add(aErrorText);

            //Tymczasowe dodanie tekstow dla akcji usera
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_FLOW, 0, "Przeplyw zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MAX_FLOW, 0, "Max przeplyw zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_RANGE_VOLTAGE_MFC, 0, "Zakresu napiec dla przeplywki zostal ustawiony. ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_TIME_FLOW_STABILITY, 0, "Czasu stabilizacji przeplywu przeplywki zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.START_PROGRAM, 0, "Programu zostal uruchomiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.STOP_PROGRAM, 0, "Programu zostal zatrzymany.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.UPDATE_SETINGS, 0, "Ustawienia urzadzen PLC zostaly poprawnie odczytane.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.WRITE_PROGRAM, 0, "Programu do PLC zostal poprawnie zaladowany.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_PRESSURE_SETPOINT, 0, "Setpointa cisnienia komory zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_SETPOINT_HV, 0, "Setpointa dla zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MODE, 0, "Tryb pracy zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_OPERATE_HV, 0, "Tryb operate zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_LIMIT_CURRENT_HV, 0, "Limitu pradu zasilacza HV zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_LIMIT_POWER_HV, 0, "Limitu mocy zasilacza HV zostal ustawiony ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_LIMIT_VOLTAGE_HV, 0, "Limitu napiecia zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MAX_CURENT_HV, 0, "Max pradu zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MAX_POWER_HV, 0, "Max mocy zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MAX_VOLTAGE_HV, 0, "Max napiecia zasilacza HV zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_WAIT_TIME_OPERATE_HV, 0, "Czas oczekiwania na stan operate zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_WAIT_TIME_SETPOINT_HV, 0, "Czas oczekiwania na stavilizacje sie wartosci zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.CONTROL_PUMP, 0, "Stan pracy pompy wstepnej zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_WIAT_TIME_PF,0, "Czas oczekiwania na poprawny stan pompy wstepnej  zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_TIME_PUMP_TO_SV, 0, "Czas pompowania do zaworu HV zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_CYCLE_TIME, 0, "Czas cyklu pracy vaporatora zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_ON_TIME, 0, "Czas wlaczenia vaporatora zostal ustawiony ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_STATE_VALVE, 0, "Stan zaworu zostal poprawnie zmioniony . ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MODE_PRESSURE, 0, "Trybu pracy cisnieniowego komory zostal ustawiony.", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MODE_CONTROL, 0, "Tryb pracy zostal ustawiony .", Types.Language.English);
            actionTextList.Add(aErrorText);

            //Tymczasowe dodanie tekstow dla bledow PLC
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC,(int)Types.ERROR_CODE.PLC_ERROR, 1, "Nie moge wykonac programu poniewaz nie moge znalezc znacznika konca", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 2, "Nie moge wykonac programu poniewaz drzwi komory sa ciagle otwarte", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 3, "Nie moge wykonac programu poniewaz glowne zasilanie jst wylaczone", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 109, "Blad wykonania programu. Przekroczony zostal czas oczekiwania na odpompowanie komory", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 110, "Blad wykonania programu. Pompa wstępna zglasza problem", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 115, "Blad wykonania programu. Prcedura ventowania zostala przerwana poniewaz pompa wstepna jest wlaczona", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 116, "Blad wykonania programu. Brak potwierdzenia wlaczenia zasilacza plazmy", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 117, "Blad wykonania programu. Proba ustawienia nastawy zasilacza plazmy spoza dopuszczalnego zakresu", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 118, "Blad wykonania programu. Zasilacz plazmy zglasza problem sprzętowy", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 119, "Blad wykonania programu. Wartosc nastawy zasilacza plazmy nie moze sie ustabilizowac pomiedzy zadanymi widelkami", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 120, "Blad wykonania programu. Wybrano niepoprawny tryb pracy zasilacza plazmy", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 121, "Blad wykonania programu. Niepoprawne ustawienie limitow nastawy zasilacza plazmy. Nie moga byc 0 ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 122, "Blad wykonania programu. Wartosc nastawy przeplywu dla MFC1 jest poza zakresem pracy przeplwyki", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 123, "Blad wykonania programu. Wartosc przeplywu dla MFC1 nie potrafi się ustabilizowac pomiedzy zadanymi widelkami ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 124, "Blad wykonania programu. Wartosc nastawy przeplywu dla MFC2 jest poza zakresem pracy przeplwyki", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 125, "Blad wykonania programu. Wartosc przeplywu dla MFC2 nie potrafi się ustabilizowac pomiedzy zadanymi widelkami ", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 126, "Blad wykonania programu. Wartosc nastawy przeplywu dla MFC3 jest poza zakresem pracy przeplwyki", Types.Language.English);
            actionTextList.Add(aErrorText);
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 127, "Blad wykonania programu. Wartosc przeplywu dla MFC3 nie potrafi się ustabilizowac pomiedzy zadanymi widelkami ", Types.Language.English);
            actionTextList.Add(aErrorText);

        }
        //-------------------------------------------------------------------------------------
        private void FillErrorTextList()
        {

        }
        //-------------------------------------------------------------------------------------
        public string GetErrorText(ERROR aError)
        {
            string aTxt = "No text in data base for action code:" + aError.GetErrorCode().ToString("X8");

            foreach (ErrorText errorText in actionTextList)
            {
                if (aError.Category == Types.ERROR_CATEGORY.MX_COMPONENTS || aError.Category == Types.ERROR_CATEGORY.APLICATION)
                {
                    if (errorText.Code == aError.Code && errorText.Category == aError.Category && errorText.Language == Driver.HPT1000.LanguageApp)
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
            return aTxt;
        }
        //-------------------------------------------------------------------------------------
    }
}
