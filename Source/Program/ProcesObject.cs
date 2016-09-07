using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPT1000.Source.Program
{
    abstract public class ProcesObject
    {
        protected bool active { set; get; } //flaga okresla czy w danym segmenie dany obiekt procesu bierze udzial
        
        public bool Active
        {
            set { active = value; }
            get { return active;  }        
        }
        //Funkcja ma za zadanie przygotowanie danych  dla PLC zgodnie z przygotowana rozpiska pamieci
        abstract public void PrepareDataPLC(int[] aData);
    }
}
