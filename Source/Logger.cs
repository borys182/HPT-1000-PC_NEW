using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPT1000.Source.Driver;
namespace HPT1000.Source
{
    //Klasa służy do logowania wszystkich bledow wystepjacych w programie i zbierania ich w jednym miejscu
    class Logger
    {
        private static List<ERROR> errorList = new List<ERROR>();

        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AddError(ERROR aErr)
        {
            if(aErr.ErrorCode != 0 || aErr.ErrorCodePLC != 0)
                errorList.Add(aErr);
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
    }
}
