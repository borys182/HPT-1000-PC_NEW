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
        private Types.WorkModeHV workMode       = Types.WorkModeHV.Power;
        private double           setpoint       = 0;    //Ustaw wartosc ktora jest moca/pradem/napieciem w zaleznosci od wybranego trybu pracy
        private DateTime         timeOperate;           //Czas wlaczenia zasilacza. Ustawienie czasu 0 wlacza zasilacz na czas nieokrelsony i jego wylaczenie nastepuje w momencie wyslania komendy OFF
        private double           deviationSP    = 0;    //procentowe okreslenie max odchylki

        private double maxPower     = 10;
        private double maxVoltage   = 10;
        private double maxCurrent   = 10;
        
        //-----------------------------------------------------------------------------------------------------------
        public PlasmaProces()
        {
            //zeruja godziny/minuty/sekundy
            timeOperate = DateTime.Now;
            timeOperate = timeOperate.AddHours(-DateTime.Now.Hour);
            timeOperate = timeOperate.AddMinutes(-DateTime.Now.Minute);
            timeOperate = timeOperate.AddSeconds(-DateTime.Now.Second);
        }
        //-----------------------------------------------------------------------------------------------------------
        public override void UpdateData(SubprogramData aSubprogramData)
        {
            workMode    = (Types.WorkModeHV)aSubprogramData.HV_Operate_Mode;
            setpoint    = aSubprogramData.HV_Setpoint;
            deviationSP = aSubprogramData.HV_Deviation;
            timeOperate = ConvertDate(aSubprogramData.HV_TargetTime);
            timeWorking = ConvertDate(aSubprogramData.WorkingTimeHV);

            ReadActiveWithCMD(aSubprogramData.Command, Types.BIT_CMD_HV);
            //       deviationSP = aSubprogramData.
        }
        //-----------------------------------------------------------------------------------------------------------
        override public void PrepareDataPLC(int[] aData)
        {
            if (active)
            {
                aData[Types.OFFSET_SEQ_CMD] |= (int)System.Math.Pow(2, Types.BIT_CMD_HV);
                aData[Types.OFFSET_SEQ_HV_OPERATE] = (int)workMode;
                aData[Types.OFFSET_SEQ_HV_TIME] = timeOperate.Hour * 3600 + timeOperate.Minute * 60 + timeOperate.Second;
                aData[Types.OFFSET_SEQ_HV_SETPOINT] = Types.ConvertDOUBLEToWORD(setpoint, Types.Word.LOW);
                aData[Types.OFFSET_SEQ_HV_SETPOINT + 1] = Types.ConvertDOUBLEToWORD(setpoint, Types.Word.HIGH);
                aData[Types.OFFSET_SEQ_HV_DRIFT_SETPOINT] = Types.ConvertDOUBLEToWORD(deviationSP, Types.Word.LOW);
                aData[Types.OFFSET_SEQ_HV_DRIFT_SETPOINT + 1] = Types.ConvertDOUBLEToWORD(deviationSP, Types.Word.HIGH);
            }
        }
        //-----------------------------------------------------------------------------------------------------------
        public void SetTimeOperate(DateTime aTime)
        {
            timeOperate = aTime;
        }
        //-----------------------------------------------------------------------------------------------------------
        public DateTime GetTimeOperate()
        {
            return timeOperate;
        }
        //-----------------------------------------------------------------------------------------------------------
        public void SetWorkMode(Types.WorkModeHV aWorkMode)
        {
            workMode = aWorkMode;
        }
        //-----------------------------------------------------------------------------------------------------------
        public Types.WorkModeHV GetWorkMode()
        {
            return workMode;
        }
        //-----------------------------------------------------------------------------------------------------------
        public void SetSetpointValue(double aValueSP)
        {
            setpoint = aValueSP;
        }
        //-----------------------------------------------------------------------------------------------------------
        public double GetSetpointValue()
        {
            return setpoint;
        }
        //-----------------------------------------------------------------------------------------------------------
        public void SetSetpointPercent(int aValue)
        {
            switch (workMode)
            {
                case Types.WorkModeHV.Power:
                        setpoint = maxPower * aValue / 100;
                    break;
                case Types.WorkModeHV.Voltage:
                        setpoint = maxVoltage * aValue / 100;

                    break;
                case Types.WorkModeHV.Curent:
                        setpoint = maxCurrent * aValue / 100;

                    break;
            }
        }
        //-----------------------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------------------
        public void SetDeviation(double aValue)
        {
            deviationSP = aValue;
        }
        //-----------------------------------------------------------------------------------------------------------
        public double GetDeviation()
        {
            return deviationSP;
        }
        //-----------------------------------------------------------------------------------------------------------
        //TO DO - okreslenie wartosci maxPower/Curent/Voltage
    }
}
