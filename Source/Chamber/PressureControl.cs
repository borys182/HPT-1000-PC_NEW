using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Chamber
{
    public class PressureControl : ChamberObject
    {
        double              actualPressure      = 0;
        Types.GasProcesMode mode                = Types.GasProcesMode.FlowSP;
        
        //-----------------------------------------------------------------------------------------
        //Ustwa aktualny przeplyw dla wszystkich przeplywek
        override public void UpdateData(int[] aData)
        {
            if (aData.Length > Types.OFFSET_PRESSURE && aData.Length > Types.OFFSET_MODE_PRESSURE)
            {
                //z PLC dostaje DWORD ktorego nalezy przekonwertowac na double
                actualPressure = Types.ConvertDWORDToDouble(aData, Types.OFFSET_PRESSURE);

                if (Enum.IsDefined(typeof(Types.GasProcesMode), aData[Types.OFFSET_MODE_PRESSURE]))
                    mode = (Types.GasProcesMode)Enum.Parse(typeof(Types.GasProcesMode), (aData[Types.OFFSET_MODE_PRESSURE]).ToString()); // konwertuj int na Enum
                else
                    mode = Types.GasProcesMode.Unknown;
            }
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja umozliwia ustawianie setpointa prozni dla regulatora PID
        public ERROR SetSetpoint(double aSetpoint)
        {
            ERROR aErr = new ERROR(0,0);
            if (plc != null)
            {
                if (controlMode == Types.ControlMode.Manual)
                    aErr.ErrorCodePLC = plc.WriteRealData(Types.ADDR_PRESSURE_SETPOINT, (float)aSetpoint);
                if (controlMode == Types.ControlMode.Automatic)
                    aErr.ErrorCodePLC = plc.WriteRealData(Types.OFFSET_SEQ_GAS_SETPOINT + Types.ADDR_CONTROL_PROGRAM, (float)aSetpoint);
            }
            else
                aErr.ErrorCode = Types.ERROR_CODE.BAD_FLOW_ID;

            return aErr;
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja umozliwia ustawianie setpointa prozni dla regulatora PID
        public ERROR SetMode(Types.GasProcesMode aMode)
        {
            ERROR aErr  = new ERROR(0,0);
            int[] aData = new int[1];

            aData[0] = (int)aMode;
            if (plc != null)
            {
                if (controlMode == Types.ControlMode.Manual)
                    aErr.ErrorCodePLC = plc.WriteWords(Types.ADDR_PRESSURE_MODE,1,aData);
                if (controlMode == Types.ControlMode.Automatic)
                    aErr.ErrorCodePLC = plc.WriteWords(Types.OFFSET_SEQ_GAS_MODE + Types.ADDR_CONTROL_PROGRAM,1,aData);
            }
            else
                aErr.ErrorCode = Types.ERROR_CODE.BAD_FLOW_ID;

            return aErr;
        }
        //----------------------------------------------------------------------------------------
        public double GetPressure()
        {
            return actualPressure;
        }
        //----------------------------------------------------------------------------------------
        public Types.GasProcesMode GetMode()
        {
            return mode;
        }
        //----------------------------------------------------------------------------------------

    }
}
