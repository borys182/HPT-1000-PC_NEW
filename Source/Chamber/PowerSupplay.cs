﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;
namespace HPT1000.Source.Chamber
{
    public class PowerSupplay : ChamberObject
    {
        private Types.StateHV   state = Types.StateHV.Error;
        private Types.ModeHV    mode = Types.ModeHV.Power;

        private double          power    = 0;
        private double          voltage  = 0;
        private double          curent   = 0;
        
        private double          limitVoltage = 0;
        private double          limitCurent  = 0;
        private double          limitPower   = 0;

       //-------------------------------------------------------------------------------------------
        override public void UpdateData(int []aData)
        {
            power           = Types.ConvertDWORDToDouble(aData, Types.OFFSET_POWER);
            voltage         = Types.ConvertDWORDToDouble(aData, Types.OFFSET_VOLTAGE);
            curent          = Types.ConvertDWORDToDouble(aData, Types.OFFSET_CURENT);

            if (Enum.IsDefined(typeof(Types.ModeHV), aData[Types.OFFSET_MODE_HV]))
                mode = (Types.ModeHV)Enum.Parse(typeof(Types.ModeHV), (aData[Types.OFFSET_MODE_HV]).ToString()); // konwertuj int na Enum
            else
                mode = Types.ModeHV.Unknown;

            if (Enum.IsDefined(typeof(Types.StateHV), aData[Types.OFFSET_STATUS_HV]))
                state = (Types.StateHV)Enum.Parse(typeof(Types.StateHV), (aData[Types.OFFSET_STATUS_HV]).ToString()); // konwertuj int na Enum
            else
                state = Types.StateHV.Error;
        }
        //-------------------------------------------------------------------------------------------
        override public void UpdateSettings(int[] aData)
        {
            limitPower      = Types.ConvertDWORDToDouble(aData, Types.OFFSET_POWER);
            limitVoltage    = Types.ConvertDWORDToDouble(aData, Types.OFFSET_VOLTAGE);
            limitCurent     = Types.ConvertDWORDToDouble(aData, Types.OFFSET_CURENT);
        }
        //-------------------------------------------------------------------------------------------
        public double GetPower()
        {
            return power;
        }
        //------------------------------------------------------------------------------------------
        public double GetVoltage()
        {
            return voltage;
        }
        //------------------------------------------------------------------------------------------
        public double GetCurent()
        {
            return curent;
        }
        //-----------------------------------------------------------------------------------------
        public Types.ModeHV GetMode()
        {
            return mode;
        }
        //-----------------------------------------------------------------------------------------
        public Types.StateHV GetState()
        {
            return state;
        }
        //-----------------------------------------------------------------------------------------

        public ERROR SetSetpoint(double aSetpoint)
        {
            ERROR aErr = new ERROR(0);

            if (plc != null)
            {
                if(controlMode == Types.ControlMode.Automatic)
                    aErr.ErrorCodePLC = plc.WriteRealData(Types.ADDR_CONTROL_PROGRAM + Types.OFFSET_SEQ_HV_SETPOINT, (float)aSetpoint);
                if(controlMode == Types.ControlMode.Manual)
                    aErr.ErrorCodePLC = plc.WriteRealData(Types.ADDR_POWER_SUPPLAY_SETPOINT, (float)aSetpoint);
            }
            else
                aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;

            return aErr;
        }       
        //-----------------------------------------------------------------------------------------
        //Mozliwosc ustawienia tylko w trybie recznym
        public ERROR SetMode(Types.ModeHV aMode)
        {
            ERROR aErr = new ERROR(0);
            int []aData = new int[1] ;

            aData[0] =  (int)aMode;

            if (plc != null)
            {
                if (controlMode == Types.ControlMode.Manual)
                    aErr.ErrorCodePLC = plc.WriteWords(Types.ADDR_POWER_SUPPLAY_MODE, 1,aData);
            }
            else
                aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;

            return aErr;
        }
        //-----------------------------------------------------------------------------------------
        //Mozliwosc ustawienia tylko w trybie recznym
        public ERROR SetOperate(bool aOperate)
        {
            ERROR aErr = new ERROR(0);

            int[] aData = new int[1];

            aData[0] = Convert.ToInt32(aOperate);
            if (plc != null)
            {
                if (controlMode == Types.ControlMode.Manual)
                    aErr.ErrorCodePLC = plc.WriteWords(Types.ADDR_POWER_SUPPLAY_OPERATE,1, aData);
            }
            else
                aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;

            return aErr;
        }
        //-------------------------------------------------------------------------------------------
    
    }
}
