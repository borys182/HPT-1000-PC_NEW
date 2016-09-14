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
        private DateTime timeVent ;

        public VentProces()
        {
            timeVent = DateTime.Now;
            timeVent = timeVent.AddHours(-DateTime.Now.Hour);
            timeVent = timeVent.AddMinutes(-DateTime.Now.Minute);
            timeVent = timeVent.AddSeconds(-DateTime.Now.Second);
        }
        override public void PrepareDataPLC(int[] aData)
        {
            if (active)
            {
                aData[Types.BIT_CMD_VENT]           |= (int)System.Math.Pow(2, Types.BIT_CMD_VENT);
                aData[Types.OFFSET_SEQ_VENT_TIME]    = timeVent.Hour * 3600 + timeVent.Minute * 60 + timeVent.Second; 
            }
        }

        public void SetTimeVent(DateTime aTime)
        {
            timeVent = aTime;
        }
        public DateTime GetTimeVent()
        {
            return timeVent;
        }
    }
}
