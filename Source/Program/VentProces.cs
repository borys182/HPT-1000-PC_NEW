using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Program
{
    public class VentProces : ProcesObject
    {
        private int timeVent = 1800;

        override public void PrepareDataPLC(int[] aData)
        {
            if (active)
            {
                aData[Types.BIT_CMD_VENT]           |= (int)System.Math.Pow(2, Types.BIT_CMD_VENT);
                aData[Types.OFFSET_SEQ_VENT_TIME]    = timeVent;
            }

        }

        public void SetTimeVent(int aTime)
        {
            timeVent = aTime;
        }
        public int GetTimeVent()
        {
            return timeVent;
        }
    }
}
