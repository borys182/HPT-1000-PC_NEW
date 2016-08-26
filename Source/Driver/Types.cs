using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPT1000.Source.Driver
{
    /// <summary>
    /// Klasa zawiera definicje typow oraz adresy komorek
    /// </summary>
    public class Types
    {
        public enum TypeValve { SV, VV, V2, V3, V4, Flow1, Flow2, Flow3, Flow4 }; //Kolejnosc zaworow odpowiada kolejnosci stanow zaworow przesylanych w zbiorczym DWORD z PLC
        public enum StateValve { Close = 0, Open = 1, Error = 3 };
        public enum Operation { ON, OFF };
    }
}
