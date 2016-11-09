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
            if(itemLog.IsError() && !IsContains(itemLog))
                logList.Add(itemLog);
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AddError(Exception ex)
        {
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
        public static ItemLogger GetLastAction()
        {
            ItemLogger itemLog = null;

            if (logList.Count > 0)
                itemLog = logList[logList.Count - 1];

            return itemLog;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
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
