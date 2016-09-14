using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;
namespace HPT1000.Source.Program
{
    public class PumpProces : ProcesObject
    {
        private DateTime    timeWaitForPumpDown     = DateTime.Now; 
        private double      setpointPressure        = 0.5; //[mBar]
        
        public PumpProces()
        {
            //zeruja godziny/minuty/sekundy
            timeWaitForPumpDown = DateTime.Now;
            timeWaitForPumpDown = timeWaitForPumpDown.AddHours(-DateTime.Now.Hour);
            timeWaitForPumpDown = timeWaitForPumpDown.AddMinutes(-DateTime.Now.Minute);
            timeWaitForPumpDown = timeWaitForPumpDown.AddSeconds(-DateTime.Now.Second);
        }
        override public void PrepareDataPLC(int[] aData)
        {
            if (active)
            {
                aData[Types.OFFSET_SEQ_CMD]            |= (int)System.Math.Pow(2, Types.BIT_CMD_PUMP);
                aData[Types.OFFSET_SEQ_PUMP_MAX_TIME]   = timeWaitForPumpDown.Hour * 3600 + timeWaitForPumpDown.Minute * 60 + timeWaitForPumpDown.Second;
                aData[Types.OFFSET_SEQ_PUMP_SP]         = Types.ConvertDOUBLEToInt(setpointPressure, Types.Word.HIGH); ;
                aData[Types.OFFSET_SEQ_PUMP_SP + 1]     = Types.ConvertDOUBLEToInt(setpointPressure, Types.Word.LOW); ;
            }
        }

        public void SetSetpoint(double aPressure)
        {
            setpointPressure = aPressure;
        }
        public double GetSetpoint()
        {
            return setpointPressure;
        }

        public void SetTimeWaitForPumpDown(DateTime aTime)
        {
            timeWaitForPumpDown = aTime;
        }
        public DateTime GetTimeWaitForPumpDown()
        {
            return timeWaitForPumpDown;
        }
    }
}
