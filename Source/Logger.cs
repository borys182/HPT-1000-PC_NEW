﻿using System;
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
            if(aErr.IsError())
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
        public static ERROR GetLastError()
        {
            ERROR aErr = new ERROR();

            if (errorList.Count > 0)
                aErr = errorList[errorList.Count - 1];

            return aErr;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
