using System;
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


        override public void UpdateData(int []aData)
        {
            power           = Types.ConvertIntToDouble(aData, Types.INDEX_POWER);
            voltage         = Types.ConvertIntToDouble(aData, Types.INDEX_VOLTAGE);
            curent          = Types.ConvertIntToDouble(aData, Types.INDEX_CURENT);

            limitPower      = Types.ConvertIntToDouble(aData, Types.INDEX_POWER);
            limitVoltage    = Types.ConvertIntToDouble(aData, Types.INDEX_VOLTAGE);
            limitCurent     = Types.ConvertIntToDouble(aData, Types.INDEX_CURENT);

            if (Enum.IsDefined(typeof(Types.ModeHV), aData[Types.INDEX_MODE_HV]))
                mode = (Types.ModeHV)Enum.Parse(typeof(Types.ModeHV), (aData[Types.INDEX_MODE_HV]).ToString()); // konwertuj int na Enum
            else
                mode = Types.ModeHV.Error;

            if (Enum.IsDefined(typeof(Types.StateHV), aData[Types.INDEX_STATUS_HV]))
                state = (Types.StateHV)Enum.Parse(typeof(Types.StateHV), (aData[Types.INDEX_STATUS_HV]).ToString()); // konwertuj int na Enum
            else
                state = Types.StateHV.Error;
        }

        public int SetPower(double aPower)
        {
            int aResult = 0;

            if (plc != null)
                aResult = plc.WriteRealData(Types.ADDR_POWER, (float)aPower);
            else
                aResult = Types.ERROR_PLC_PTR_NULL;

            return aResult;
        }

        public int SetVoltage(double aVoltage)
        {
            int aResult = 0;

            if (plc != null)
                aResult = plc.WriteRealData(Types.ADDR_VOLTAGE, (float)aVoltage);
            else
                aResult = Types.ERROR_PLC_PTR_NULL;

            return aResult;
        }

        public int SetCurent(double aCurent)
        {
            int aResult = 0;

            if (plc != null)
                aResult = plc.WriteRealData(Types.ADDR_CURENT, (float)aCurent);
            else
                aResult = Types.ERROR_PLC_PTR_NULL;

            return aResult;
        }
    }
}
