using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Program
{
    public class FlushProces : ProcesObject
    {
        private int timeFlush = 1800;   //czas przedmuchu podawany [s]

        override public void PrepareDataPLC(int[] aData)
        {
            if (active)
            {
                aData[Types.BIT_CMD_FLUSH]          |= (int)System.Math.Pow(2, Types.BIT_CMD_FLUSH);
                aData[Types.OFFSET_SEQ_FLUSH_TIME]   = timeFlush;
            }
        }

        public void SetTimeFlush(int aTime)
        {
            timeFlush = aTime;
        }
        public int GetTimeFlush()
        {
            return timeFlush;
        }
    }
}
