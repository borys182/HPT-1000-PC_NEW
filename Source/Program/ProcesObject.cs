using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Program
{
    abstract public class ProcesObject
    {
        protected bool      active = true; //flaga okresla czy w danym segmenie dany obiekt procesu bierze udzial. Domyslnie ustawiam na true
        protected DateTime  timeWorking;

        //-------------------------------------------------------------------------------------
        protected DateTime ConvertDate(int aSeconds)
        {
            DateTime aDateTime = DateTime.Now;

            aDateTime = aDateTime.AddHours(-DateTime.Now.Hour);
            aDateTime = aDateTime.AddMinutes(-DateTime.Now.Minute);
            aDateTime = aDateTime.AddSeconds(-DateTime.Now.Second);

            int aHour   =  aSeconds / (3600);
            int aMinute = (aSeconds - aHour * 3600) / 60;
            int aSecond =  aSeconds - aHour * 3600 - aMinute * 60;

            aDateTime = aDateTime.AddHours(aHour);
            aDateTime = aDateTime.AddMinutes(aMinute);
            aDateTime = aDateTime.AddSeconds(aSecond);

            return aDateTime;
        }
        //-------------------------------------------------------------------------------------
        public bool Active
        {
            set { active = value; }
            get { return active; }
        }
        //------------------------------------------------------------------------------------
        public DateTime TimeWorking
        {
            get { return timeWorking; }
        }
        //------------------------------------------------------------------------------------
        //Funkcja ma za zadanie przygotowanie danych  dla PLC zgodnie z przygotowana rozpiska pamieci
        abstract public void PrepareDataPLC(int[] aData);
        //------------------------------------------------------------------------------------
        abstract public void UpdateData(SubprogramData aSubprogramData);
        //------------------------------------------------------------------------------------
        //Funkcja ma za zadanie sprawdzenie czy w slowie komand jest ustawiony bit danego procesu. Jezeli tak to aktuwuj proces
        protected void ReadActiveWithCMD(int aCMD, int aBitNr)
        {
            if ((aCMD & (int)System.Math.Pow(2, aBitNr)) != 0)
                active = true;
            else
                active = false;
        }
        //------------------------------------------------------------------------------------
        protected bool IsBitActive(int aCMD, int aBitNr)
        {
            bool aRes = false;

            if ((aCMD & (int)System.Math.Pow(2, aBitNr)) != 0)
                aRes = true;

            return aRes;
        }
        //------------------------------------------------------------------------------------
    }
}