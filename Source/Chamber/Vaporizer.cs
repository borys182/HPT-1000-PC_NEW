using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;
using HPT1000.Source;

namespace HPT1000.Source.Chamber
{
    /**
     *  Klasa reprezentuje zawor vaporatora ktorgo zadaniem jest szybkie wstrzykiwanie gazu do komory
     */ 
    public class Vaporizer : ChamberObject
    {
        ///Parametry vaporaitora
        private double cycleTime        = 0;                    ///<Okrelsenie dlugosc trwania cyklu "PWM" [ms]
        private double onTime           = 0;                    ///<Czas wlaczenia przeplywki w danym cyklu (czas nie moze byc wiekszy niz czas cyklu) [ms]

        bool           enabled          = false;                ///<Flaga okresla czy w danej konfiguracji sprzetowej dostepny jest vaporizer
      
        //-------------------------------------------------------------------------------------
        /**
         * Funkcja ma za zadanie aktualizowanie parametró vaporatora odczytane ze sterownika PLC
         */ 
        override public void UpdateData(int[] aData)
        {
            if (aData.Length > Types.OFFSET_CYCLE_TIME && aData.Length > Types.OFFSET_ON_TIME)
            {
                cycleTime   = Types.ConvertDWORDToDouble(aData, Types.OFFSET_CYCLE_TIME);
                onTime      = Types.ConvertDWORDToDouble(aData, Types.OFFSET_ON_TIME);
            }
        }
        //-------------------------------------------------------------------------------------
        /**
         * Funkcja umozliwia ustawienie w przestrzeni PLC czasu cyklu dla sterowania zaworem szybkim w przestrzeni sterownika PLC
         * @param CycleTime - czas cyklu pracy zaworu podawany w ms
        */
        public ERROR SetCycleTime(float aCycleTime)
        {
            ERROR aErr = new ERROR(0,0);

            if (aCycleTime < onTime)    aErr.ErrorCode = Types.ERROR_CODE.BAD_CYCLE_TIME;
            if (plc == null)            aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;

            if (aErr.ErrorCode == Types.ERROR_CODE.NONE)
            {
                if(controlMode == Types.ControlMode.Manual)
                    aErr.ErrorCodePLC = plc.WriteRealData(Types.ADDR_CYCLE_TIME, aCycleTime);
                if (controlMode == Types.ControlMode.Automatic)
                    aErr.ErrorCodePLC = plc.WriteRealData(Types.OFFSET_SEQ_FLOW_4_CYCLE_TIME + Types.ADDR_CONTROL_PROGRAM, aCycleTime);
            }
                        
            //Aktualizuj czas cyklu pracy. W watku moze byc za wolno dla szybkiego ustawienia czasu wlaczenia zaworu 
            if (aErr.ErrorCode == 0 && aErr.ErrorCodePLC == 0)
                cycleTime = aCycleTime;

            Logger.AddError(aErr);
            return aErr;
        }
        //-------------------------------------------------------------------------------------
        /**
         * Funkcja umozliwia ustawienie w przestrzeni PLC czasu jak dlugo ma byc wlaczany zawor szybki w danym cyklu
         * @param OnTime - procentowe okreslenie czasu wlaczenia zawotu w danym cyklu
        */
        public ERROR SetOnTime(float aOnTimeValue, Types.UnitFlow aUnit)
        {
            ERROR aErr = new ERROR(0,0);
            double aOnTime = 0;

            if (aUnit == Types.UnitFlow.percent)
            {
                if (aOnTimeValue < 0)                           aOnTime = 0;
                if (aOnTimeValue > 100)                         aOnTime = cycleTime;
                if (aOnTimeValue >= 0 && aOnTimeValue <= 100)   aOnTime = cycleTime * aOnTimeValue / 100;
            }
            else
                aOnTime = aOnTimeValue;

            if (aOnTime > cycleTime)    aErr.ErrorCode = Types.ERROR_CODE.BAD_ON_TIME;
            if (plc == null)            aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;

            if (aErr.ErrorCode == Types.ERROR_CODE.NONE)
            {
                if (controlMode == Types.ControlMode.Manual)
                    aErr.ErrorCodePLC = plc.WriteRealData(Types.ADDR_ON_TIME, (float)aOnTime);
                if (controlMode == Types.ControlMode.Automatic)
                    aErr.ErrorCodePLC = plc.WriteRealData(Types.OFFSET_SEQ_FLOW_4_ON_TIME + Types.ADDR_CONTROL_PROGRAM, (float)aOnTime);
            }
            Logger.AddError(aErr);
            return aErr;
        }
        //-------------------------------------------------------------------------------------
        /**
         * Funkcja zwraca w ms czas cyklu pracy zaworu
         * @return Czas cyklu pracy zaworu wyrazony w ms 
         */ 
        public double GetCycleTime()
        {
            return cycleTime;
        }
        //-------------------------------------------------------------------------------------
        /**
         * Funkcja zwraca w % czas wlaczenia zaworu szybkiego w danym cyklu pracy
         * @return Czas wlaczenia zaworu szybkiego w danym cyklu pracy wyrazony w % odnosnie do czasu cyklu pracy zaworu
         */
        public double GetOnTime(Types.UnitFlow aUnit)
        {
            double aValue = 0;

            switch (aUnit)
            {
                case Types.UnitFlow.ms:
                    aValue = onTime;
                    break;
                case Types.UnitFlow.percent:
                    if (cycleTime != 0)
                        aValue = onTime / cycleTime * 100;
                    break;
            }
            return aValue;
        }
        //-------------------------------------------------------------------------------------
        /**
         * Funkcja ustawia falge okreslajac czy w danej konfiguracji jest dostepny zawor szybki
         */ 
        public void SetActive(bool aState)
        {
            enabled = aState;
        }
        //-------------------------------------------------------------------------------------
        /**
        * Funkcja zwraca falge okreslajac czy w danej konfiguracji jest dostepny zawor szybki
        */
        public bool GetActive()
        {
            return enabled;
        }
        //-------------------------------------------------------------------------------------
    }
}

