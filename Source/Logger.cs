using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPT1000.Source.Driver;
namespace HPT1000.Source
{
    //Klasa służy do logowania wszystkich bledow/zdarzeń występjacych w programie i zbierania ich w jednym miejscu
    class Logger
    {
        private static List<ERROR> errorList = new List<ERROR>();

        //------------------------------------------------------------------------------------------------------------------------------------------------
        private static bool IsContains(ERROR aErr)
        {
            bool aRes = false;

            foreach (ERROR err in errorList)
            {
                if (err.Equals(aErr))
                {
                    aRes = true;
                    break;
                }
            }

            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AddError(ERROR aErr)
        {
            if((aErr.IsError() || aErr.IsInformation()) && !IsContains(aErr))
                errorList.Add(aErr);
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AddError(Exception ex)
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static List<ERROR> GetErrorList()
        {
            return errorList;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ClearErrors()
        {          
            errorList.Clear();      
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static ERROR GetLastAction()
        {
            ERROR aErr = null;

            if (errorList.Count > 0)
                aErr = errorList[errorList.Count - 1];

            return aErr;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AddMsg(string aText,Types.MessageType aTypeMsg)
        {
            ERROR aErr = new ERROR();

            aErr.SetMessage(aText, aTypeMsg);

            if (!IsContains(aErr))
                errorList.Add(aErr);
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
