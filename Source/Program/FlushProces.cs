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
        private DateTime timeFlush ;   //czas przedmuchu podawany [s]
        //----------------------------------------------------------------------------------------------------
        public FlushProces()
        {
            //zeruja godziny/minuty/sekundy
            timeFlush = DateTime.Now;
            timeFlush = timeFlush.AddHours(-DateTime.Now.Hour);
            timeFlush = timeFlush.AddMinutes(-DateTime.Now.Minute);
            timeFlush = timeFlush.AddSeconds(-DateTime.Now.Second);
        }
        //----------------------------------------------------------------------------------------------------
        public override void UpdateData(SubprogramData aSubprogramData)
        {            
            timeFlush   = ConvertDate(aSubprogramData.Flush_TargetTime);
            timeWorking = ConvertDate(aSubprogramData.WorkingTimeFlush);

            ReadActiveWithCMD(aSubprogramData.Command, Types.BIT_CMD_FLUSH);
        }
        //----------------------------------------------------------------------------------------------------
        override public void PrepareDataPLC(int[] aData)
        {
            if (active)
            {
                aData[Types.OFFSET_SEQ_CMD]          |= (int)System.Math.Pow(2, Types.BIT_CMD_FLUSH);
                aData[Types.OFFSET_SEQ_FLUSH_TIME]   = timeFlush.Hour * 3600 + timeFlush.Minute * 60 + timeFlush.Second; 
            }
        }
        //----------------------------------------------------------------------------------------------------
        public void SetTimePurge(DateTime aTime)
        {
            timeFlush = aTime;
        }
        //----------------------------------------------------------------------------------------------------
        public DateTime GetTimePurge()
        {
            return timeFlush;
        }
        //----------------------------------------------------------------------------------------------------
    }
}
