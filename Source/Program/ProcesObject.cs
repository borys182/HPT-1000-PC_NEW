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
        protected bool active                   { set; get; } //flaga okresla czy w danym segmenie dany obiekt procesu bierze udzial
        protected DateTime timeWorking          { get;}

        //-------------------------------------------------------------------------------------
        public bool Active
        {
            set { active = value; }
            get { return active;  }        
        }
        //------------------------------------------------------------------------------------
        public DateTime TimeWorking
        {
            get { return timeWorking; }
        }
        //------------------------------------------------------------------------------------
        //Funkcja ma za zadanie przygotowanie danych  dla PLC zgodnie z przygotowana rozpiska pamieci
        abstract public void PrepareDataPLC(int[] aData);
    }
}
