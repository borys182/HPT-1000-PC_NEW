using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPT1000.Source
{
    public enum Language { EN };

    public class Translate
    {
        static Dictionary<string, string> dictionary_PL_EN = new Dictionary<string, string>();

        static List<string> aLackTranslate = new List<string>();

        public static string GetText(string aTxt , Language aLanguage)
        {
            string aMsg = "";

            bool aRes = dictionary_PL_EN.TryGetValue(aTxt, out aMsg);

            if (aRes == false)
            {
                aLackTranslate.Add(aTxt);
                aMsg = aTxt;    
            }    
            return aMsg;
        }
    }
}
