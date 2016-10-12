using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source
{
    /*
     * Klasa jest odpowiedzialna za dostarczanie tekstu w danym jezyku. Podajemy tekst w jezyky polski zas tekst jezt zwracany w jezyky zadanym.
     * Tlumaczony tekst jest pobierany z bazy danych. Jezeli nie ma jakiegos tekstu przetlumaczonego to dodaje go do listy tekstow nie przetlumacoznych ktora z czasem jest zapisywany w tabeli bazy danych 
     */ 
    public class Translate
    {
        private static Dictionary<string, string> dictionary_PL_EN = new Dictionary<string, string>();

        //-----------------------------------------------------------------------
        private void LoadTextFromDB()
        {

        }
        //-----------------------------------------------------------------------
        public static string GetText(string aTxt , Types.Language aLanguage)
        {
            string aMsg = "";

            bool aRes = dictionary_PL_EN.TryGetValue(aTxt, out aMsg);

            if (aRes == false)
            {
                AddTextToTranslate(aTxt,aLanguage);
                aMsg = aTxt;    
            }    
            return aMsg;
        }
        //-----------------------------------------------------------------------
        private static void AddTextToTranslate(string txt, Types.Language targetLanguage)
        {

        }
        //-----------------------------------------------------------------------
    }
}
