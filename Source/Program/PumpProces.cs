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
        private int     maxTimeWaitOnSetpoint   = 1800; //[s]
        private double  setpointPressure        = 0.5; //[mBar]
        
        override public void PrepareDataPLC(int[] aData)
        {
            if (active)
            {
                aData[Types.OFFSET_SEQ_CMD]            |= (int)System.Math.Pow(2, Types.BIT_CMD_PUMP);
                aData[Types.OFFSET_SEQ_PUMP_MAX_TIME]   = maxTimeWaitOnSetpoint;
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

        public void SetTimeMax(int aTime)
        {
            maxTimeWaitOnSetpoint = aTime;
        }
        public int GetTimeMax()
        {
            return maxTimeWaitOnSetpoint;
        }
    }
}
