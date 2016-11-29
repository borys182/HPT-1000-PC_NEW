using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source
{
    //Klasa jest odpowiedzialna za reprezentowania wiadomosci bledu powiazanej z danym kodem bledu oraz jezykiem 
    public struct MessageError
    {
        public int                  ID ;
        public Types.EventCategory  EventCategory;  //Kategoria zdarzenia
        public Types.EventType      EventType;      //Typ zdarzenia
        public int                  ErrCode;        //Kod bledu
        public string               Text;           //Wiadomosc bledu
        public Types.Language       Language;       //Okreslenie jezyka

        //------------------------------------------------------------------------------------------------------
        //Konstruktor sparametryzowany pozwalajacy odrazu utworzyc dany obiekt wiadomosci bledu
        public MessageError(int aCategory, int aType, int aErrCode, string aTxt, Types.Language aLanguage)
        {
            EventCategory   = (Types.EventCategory)aCategory;
            EventType       = (Types.EventType)aType;
            ErrCode         = (int)aType;// aErrCode; 
            Text            = aTxt;
            Language        = aLanguage;
            ID              = 0;
        }
        //------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------
    public struct MessageEvent
    {
        public int              ID;
        public int              Code;       //Kategoria zdarzenia
        public string           Text;       //Typ zdarzenia
        public Types.Language   Language;   //Okreslenie jezyka
    }
    //------------------------------------------------------------------------------------------------------
    /*Klasa jest reprezentatnem wiadomosci wystepujaacyh w aplikacji. Jest odpowiedzialna za odczyt wiadomosci z pliku oraz podawanie danej wiadomosci do akcji aplikacji. 
     */
    public class Message
    {
        private static List<MessageError> messageErrors = new List<MessageError>();
        private static List<MessageEvent> messageEvents = new List<MessageEvent>();

        private DB dataBase = null;

        //------------------------------------------------------------------------------------------------------
        public DB DataBase
        {
            set { dataBase = value; }
        }
        //------------------------------------------------------------------------------------------------------
        public void LoadErrorMessages()
        {
            if(dataBase != null)
            {
                messageErrors = dataBase.GetMessageErrors();
                messageEvents = dataBase.GetMessageEvents();
            }
        }
        //-------------------------------------------------------------------------------------
        //Funkcja zwraca tekst dla danego bledu. Teksty sa przechowywane w danym pliku odpowiednim dla jezyka
        public static string GetText(ItemLogger aLog)
        {
            string aTxt = "No text in data base for error: Event type: " + aLog.EventType + " Event category: " + aLog.EventCategory + " Error code: " + aLog.GetErrorCode().ToString("X8");

            int aErrCode = aLog.ErrCode;
            string aExtText = ""; //Dodatkowe info na temat bledu. Jest tutaj zawarty kod bledu MX Components
            //MX Componts zawiera kod bledu jako Event poniewaz w polu bledu posiada blad MX Componts
            if (aLog.EventCategory == Types.EventCategory.MX_COMPONENTS)
            {
                aErrCode = (int)aLog.EventType;
                aExtText = " MX Componets reports error: " + aLog.ErrCode.ToString("X8");
            }

            foreach (MessageError error in messageErrors)
            {
                if (error.EventType == aLog.EventType && error.EventCategory == aLog.EventCategory && error.Language == Driver.HPT1000.LanguageApp)
                {
                    if (aErrCode == error.ErrCode)
                    {
                        if (aLog.ErrCode != 0)
                            aTxt = error.Text + aExtText; // wystapil blad                       
                        else
                            aTxt = GetMessageEvent((int)aLog.EventType); // wystapila akcja poszukaj text dla niej
                    }
                }
            }
            return aTxt;
        }
        //-------------------------------------------------------------------------------------
        private static string GetMessageEvent(int aCode)
        {
            string aTxt = "";
            foreach(MessageEvent msgEvent in messageEvents)
            {
                if (msgEvent.Code == aCode)
                    aTxt = msgEvent.Text;
            }
            return aTxt;
        }
        //-------------------------------------------------------------------------------------

    }
}
