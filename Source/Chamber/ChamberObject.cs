using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Chamber
{
    public abstract class ChamberObject
    {
        protected PLC plc = null;
        protected Types.TypeObject type = Types.TypeObject.None;
         public abstract void UpdateData(int[] aData);

        public void SetPonterPLC(PLC ptrPLC)
        {
            plc = ptrPLC;
        }

    }
}
