﻿using System;
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
        private static List<ItemLogger> logList = new List<ItemLogger>();

        //------------------------------------------------------------------------------------------------------------------------------------------------
        private static bool IsContains(ItemLogger aItemLog)
        {
            bool aRes = false;

            foreach (ItemLogger itemLog in logList)
            {
                if (itemLog.Equals(aItemLog))
                {
                    aRes = true;
                    break;
                }
            }

            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AddError(ItemLogger itemLog)
        {
            if(!IsContains(itemLog))
                logList.Add(itemLog);
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AddException(Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static List<ItemLogger> GetLogList()
        {
            return logList;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ClearLogger()
        {
            logList.Clear();      
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie podanie ostatniej akcji zakonczonej bledem. Kolejne bledy nie beda prezentowane dopuki aktulny nie zostanie potwierdzony
        public static ItemLogger GetLastError()
        {
            ItemLogger itemLogRes = null;

            foreach (ItemLogger itemLog in logList)
            {
                //znalazlem wpis z niepotwierdzonym bledem. Ustawiam go jako rezulta funkcji
                if (itemLog.IsError() && !itemLog.ConfirmError)
                {
                    itemLogRes = itemLog;
                    break;
                }
            }

            return itemLogRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie podanie ostatniej akcji bedacej informacja
        public static ItemLogger GetLastInformation()
        {
            ItemLogger itemLogRes = null;

            foreach (ItemLogger itemLog in logList)
            {
                //znalazlem wpis z niepotwierdzonym bledem. Ustawiam go jako rezulta funkcji
                if (itemLog.IsInformation())
                    itemLogRes = itemLog;
            }
            return itemLogRes;
        }//------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AddMsg(string aText,Types.MessageType aTypeMsg)
        {
            ItemLogger itemLog = new ItemLogger();

            itemLog.SetMessage(aText, aTypeMsg);

            if (!IsContains(itemLog))
                logList.Add(itemLog);
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
