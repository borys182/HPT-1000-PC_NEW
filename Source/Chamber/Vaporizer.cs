using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;
using HPT1000.Source;

namespace HPT1000.Source.Chamber
{
    public class Vaporizer : ChamberObject
    {
        //parametry vaporaitora
        private double  cycleTime   = 0;                    //dla przpleywki typu vaporatior jest to okrelsenie dlugosc trwania cyklu "PWM"
        private double  onTime      = 0;                    //czas wlaczenia przeplywki w danym cyklu (czas nie moze byc wiekszy niz czas cyklu)
        bool            enabled     = false;                //flaga okresla czy w danej konfiguracji sprzetowej dostepny jest vaporizer
      
        //-------------------------------------------------------------------------------------
        //Ustwa aktualne dane z vaporizera
        override public void UpdateData(int[] aData)
        {
            cycleTime   = Types.ConvertDWORDToDouble(aData, Types.OFFSET_CYCLE_TIME);
            onTime      = Types.ConvertDWORDToDouble(aData, Types.OFFSET_ON_TIME);
        }
        //-------------------------------------------------------------------------------------
        //Funkcja umozliwia ustawienie czasu cyklu dla sterowania zaworem szybkim
        public ERROR SetCycleTime(float aCycleTime)
        {
            ERROR aErr = new ERROR(0);

            if (plc != null)
            {
                if(controlMode == Types.ControlMode.Manual)
                    aErr.ErrorCodePLC = plc.WriteRealData(Types.ADDR_CYCLE_TIME, aCycleTime);
                if (controlMode == Types.ControlMode.Automatic)
                    aErr.ErrorCodePLC = plc.WriteRealData(Types.OFFSET_SEQ_FLOW_4_CYCLE_TIME + Types.ADDR_CONTROL_PROGRAM, aCycleTime);
            }
            else
                aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;

            Logger.AddError(aErr);
            return aErr;
        }
        //-------------------------------------------------------------------------------------
        //Funkcja umozliwia ustawienie czasu jak dlugo ma byc wlaczany zawor szybki
        public ERROR SetOnTime(float aOnTime)
        {
            ERROR aErr = new ERROR(0);

            if (plc != null)
            {
                if (controlMode == Types.ControlMode.Manual)
                    aErr.ErrorCodePLC = plc.WriteRealData(Types.ADDR_ON_TIME, aOnTime);
                if (controlMode == Types.ControlMode.Automatic)
                    aErr.ErrorCodePLC = plc.WriteRealData(Types.OFFSET_SEQ_FLOW_4_ON_TIME + Types.ADDR_CONTROL_PROGRAM, aOnTime);
            }
            else
                aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;

            Logger.AddError(aErr);
            return aErr;
        }
        //-------------------------------------------------------------------------------------
        public double GetCycleTime()
        {
            return cycleTime;
        }
        //-------------------------------------------------------------------------------------
        public double GetOnTime()
        {
            return onTime;
        }
        //-------------------------------------------------------------------------------------
        public void SetActive(bool aState)
        {
            enabled = aState;
        }
        //-------------------------------------------------------------------------------------
        public bool GetActive()
        {
            return enabled;
        }
        //-------------------------------------------------------------------------------------
    }
}

