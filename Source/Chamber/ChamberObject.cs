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
        protected Types.ControlMode controlMode = Types.ControlMode.Manual;

        public abstract void UpdateData(int[] aData);
        public virtual void UpdateSettings(int[] aData) { }

        public virtual void SetPonterPLC(PLC ptrPLC)
        {
            plc = ptrPLC;
        }
       

        public void SetControlMode(Types.ControlMode aControlMode)
        {
            controlMode = aControlMode;
        }
        public Types.ControlMode GetControlMode()
        {
            return controlMode;
        }

    }
}
