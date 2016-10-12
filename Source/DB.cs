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
        List<ErrorText> errorsTextList = new List<ErrorText>();
        
        //-------------------------------------------------------------------------------------
        public DB()
        {
            ErrorText aErrorText;

            //Tymczasowe dodanie tekstow dla bledow aplilacko
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.APLICATION, (int)Types.ERROR_CODE.BAD_CYCLE_TIME, 0, "BAD_CYCLE_TIME", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.APLICATION, (int)Types.ERROR_CODE.BAD_FLOW_ID, 0, "BAD_FLOW_ID", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.APLICATION, (int)Types.ERROR_CODE.BAD_ON_TIME, 0, "BAD_ON_TIME", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.APLICATION, (int)Types.ERROR_CODE.CALL_INCORRECT_OPERATION, 0, "CALL_INCORRECT_OPERATION", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.APLICATION, (int)Types.ERROR_CODE.NO_PRG_IN_PLC, 0, "W pamieci PLC nie posiada zadnego zaladowanego procesu", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.APLICATION, (int)Types.ERROR_CODE.PLC_PTR_NULL, 0, "PLC_PTR_NULL", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            //Tymczasowe dodanie tekstow dla bledow MX Components
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_FLOW, 0, "Nie moge ustawic przeplywu. MX Components zglasza blad: ", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_MAX_FLOW, 0, "Nie moge ustawic max przeplywu. MX Components zglasza blad: ", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_RANGE_VOLTAGE_MFC, 0, "Nie moge ustawic zakresu napiec dla przeplywki. MX Components zglasza blad: ", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.SET_TIME_FLOW_STABILITY, 0, "Nie moge ustawic czasu stabilizacji przeplywu przeplywki. MX Components zglasza blad: ", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.START_PROGRAM, 0, "Nie mofe uruchomic programu. MX Components zglasza blad: ", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.STOP_PROGRAM, 0, "Nie moge zatrzymac programu. MX Components zglasza blad: ", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.UPDATE_SETINGS, 0, "Nie moge zaktualizowac ustawien urzadzen PLC. MX Components zglasza blad: ", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.MX_COMPONENTS, (int)Types.ERROR_CODE.WRITE_PROGRAM, 0, "Nie moge zaladowac programu do PLC. MX Components zglasza blad: ", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            //Tymczasowe dodanie tekstow dla bledow PLC
            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC,(int)Types.ERROR_CODE.PLC_ERROR, 1, "Nie moge wykonac programu poniewaz nie moge znalezc znacznika konca", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 2, "Nie moge wykonac programu poniewaz drzwi komory sa ciagle otwarte", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 3, "Nie moge wykonac programu poniewaz glowne zasilanie jst wylaczone", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 109, "Blad wykonania programu. Przekroczony zostal czas oczekiwania na odpompowanie komory", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 110, "Blad wykonania programu. Pompa wstępna zglasza problem", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 115, "Blad wykonania programu. Prcedura ventowania zostala przerwana poniewaz pompa wstepna jest wlaczona", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 116, "Blad wykonania programu. Brak potwierdzenia wlaczenia zasilacza plazmy", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 117, "Blad wykonania programu. Proba ustawienia nastawy zasilacza plazmy spoza dopuszczalnego zakresu", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 118, "Blad wykonania programu. Zasilacz plazmy zglasza problem sprzętowy", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 119, "Blad wykonania programu. Wartosc nastawy zasilacza plazmy nie moze sie ustabilizowac pomiedzy zadanymi widelkami", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 120, "Blad wykonania programu. Wybrano niepoprawny tryb pracy zasilacza plazmy", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 121, "Blad wykonania programu. Niepoprawne ustawienie limitow nastawy zasilacza plazmy. Nie moga byc 0 ", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 122, "Blad wykonania programu. Wartosc nastawy przeplywu dla MFC1 jest poza zakresem pracy przeplwyki", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 123, "Blad wykonania programu. Wartosc przeplywu dla MFC1 nie potrafi się ustabilizowac pomiedzy zadanymi widelkami ", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 124, "Blad wykonania programu. Wartosc nastawy przeplywu dla MFC2 jest poza zakresem pracy przeplwyki", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 125, "Blad wykonania programu. Wartosc przeplywu dla MFC2 nie potrafi się ustabilizowac pomiedzy zadanymi widelkami ", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 126, "Blad wykonania programu. Wartosc nastawy przeplywu dla MFC3 jest poza zakresem pracy przeplwyki", Types.Language.PL);
            errorsTextList.Add(aErrorText);

            aErrorText = new ErrorText((int)Types.ERROR_CATEGORY.PLC, (int)Types.ERROR_CODE.PLC_ERROR, 127, "Blad wykonania programu. Wartosc przeplywu dla MFC3 nie potrafi się ustabilizowac pomiedzy zadanymi widelkami ", Types.Language.PL);
            errorsTextList.Add(aErrorText);

        }
        //-------------------------------------------------------------------------------------
        private void FillErrorTextList()
        {

        }
        //-------------------------------------------------------------------------------------
        public string GetErrorText(ERROR aError)
        {
            string aTxt = "No text in data base on error code:" + aError.GetErrorCode().ToString("X8");

            foreach (ErrorText errorText in errorsTextList)
            {
                if (aError.Category == Types.ERROR_CATEGORY.MX_COMPONENTS)
                {
                    if (errorText.Code == aError.Code && errorText.Category == aError.Category && errorText.Language == Driver.HPT1000.LanguageApp)
                        aTxt = errorText.Text + aError.ExtCode.ToString("X8");
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
