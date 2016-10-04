using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Chamber
{
    public class ForePump : ChamberObject
    {
        private Types.StateFP state = Types.StateFP.Error;

        //-----------------------------------------------------------------------------------------
        override public void UpdateData(int []aData)
        {
            if (aData.Length > Types.OFFSET_STATE_FP)
            {
                if (Enum.IsDefined(typeof(Types.StateFP), aData[Types.OFFSET_STATE_FP]))
                    state = (Types.StateFP)Enum.Parse(typeof(Types.StateFP), (aData[Types.OFFSET_STATE_FP]).ToString());
                else
                    state = Types.StateFP.Error;
            }
        }
        //-----------------------------------------------------------------------------------------
        public Types.StateFP GetState()
        {
            return state;
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja umozliwia alaczenie/wylaczenie pompy
        public ERROR ControlPump(Types.StateFP state)
        {
            ERROR aErr = new ERROR(0,0);

            int[] aData = {(int)state};

            if (state == Types.StateFP.ON || state == Types.StateFP.OFF)
            {
                if (plc != null)
                    aErr.ErrorCodePLC = plc.WriteWords(Types.ADDR_FP_CTRL, 1, aData);
                else
                    aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;
            }
            else
                aErr.ErrorCode = Types.ERROR_CODE.CALL_INCORRECT_OPERATION;

            return aErr;
        }
        //-----------------------------------------------------------------------------------------
    }
}
