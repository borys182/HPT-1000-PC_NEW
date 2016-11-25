using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Chamber
{
    public abstract class ChamberObject:  Device
    {
        protected PLC               plc         = null;
        protected Types.ControlMode controlMode = Types.ControlMode.Manual;

        //---------------------------------------------------------------------------------------
        public virtual void UpdateData(int[] aData)
        {
            if (Driver.HPT1000.Mode == Types.Mode.Automatic)
                controlMode = Types.ControlMode.Automatic;
            else
                controlMode = Types.ControlMode.Manual;
        }
        //---------------------------------------------------------------------------------------
        public virtual void UpdateSettingsData(int[] aData)
        {}
        //---------------------------------------------------------------------------------------
        public virtual void SetPonterPLC(PLC ptrPLC)
        {
            plc = ptrPLC;
        }
       //---------------------------------------------------------------------------------------
        public Types.ControlMode GetControlMode()
        {
            return controlMode;
        }
        //---------------------------------------------------------------------------------------
    }
}
