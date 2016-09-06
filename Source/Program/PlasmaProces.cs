using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Program
{
    public class PlasmaProces : ProcesObject
    {
        private Types.WorkModeHV workMode   = Types.WorkModeHV.Power;
        private double setpoint             = 0;    //Ustaw wartosc ktora jest moca/pradem/napieciem w zaleznosci od wybranego trybu pracy
        private int timeOperate             = 0;    //Czas wlaczenia zasilacza. Ustawienie czasu 0 wlacza zasilacz na czas nieokrelsony i jego wylaczenie nastepuje w momencie wyslania komendy OFF

        private double maxPower     = 10;
        private double maxVoltage   = 10;
        private double maxCurrent   = 10;

        override public void PrepareDataPLC(int[] aData)
        {
            aData[Types.BIT_CMD_HV] |= (int)System.Math.Pow(2, Types.BIT_CMD_HV);
            aData[Types.OFFSET_SEQ_HV_OPERATE]      = (int)workMode;
            aData[Types.OFFSET_SEQ_HV_TIME]         = timeOperate;
            aData[Types.OFFSET_SEQ_HV_SETPOINT]     = Types.ConvertDOUBLEToInt(setpoint,Types.Word.HIGH);
            aData[Types.OFFSET_SEQ_HV_SETPOINT + 1] = Types.ConvertDOUBLEToInt(setpoint, Types.Word.LOW);
        }

        public void SetTimeOperate(int aTime)
        {
            timeOperate = aTime;
        }
        public int GetTimeOperate()
        {
            return timeOperate;
        }

        public void SetWorkMode(Types.WorkModeHV aWorkMode)
        {
            workMode = aWorkMode;
        }
        public Types.WorkModeHV GetWorkMode()
        {
            return workMode;
        }

        public void SetSetpointValue(double aValueSP)
        {
            setpoint = aValueSP;
        }
        public double GetSetpointValue()
        {
            return setpoint;
        }
        public int GetSetpointPercent()
        {
            int aPercentValue = 0;
            switch(workMode)
            {
                case Types.WorkModeHV.Power:
                    if (maxPower > 0)
                        aPercentValue = (int)(setpoint / maxPower * 100);
                    break;
                case Types.WorkModeHV.Voltage:
                    if (maxVoltage > 0)
                        aPercentValue = (int)(setpoint / maxVoltage * 100);
                    break;
                case Types.WorkModeHV.Curent:
                    if (maxCurrent > 0)
                        aPercentValue = (int)(setpoint / maxCurrent * 100);
                    break;
            }
            return aPercentValue;
        }
        //TO DO - okreslenie wartosci maxPower/Curent/Voltage
    }
}
