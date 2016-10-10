using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Chamber
{
    public class ForePump : ChamberObject
    {
        private Types.StateFP state = Types.StateFP.Error;

        //parametry
        private int timeWaitPF      = 5;    //czas oczekiwania na sprawdzenie poprawnosci wlaczenia pompy wstepnej
        private int timePumpToSV    = 30;   //czas pompowania do zaworu SV. Brak jest tam glowcy dlatego pompuje en odcinek na czas

        //-----------------------------------------------------------------------------------------
        public int TimeWaitPF
        {
            get { return timeWaitPF; }
        }
        //-----------------------------------------------------------------------------------------
        public int TimePumpToSV
        {
            get { return timePumpToSV; }
        }
        //-----------------------------------------------------------------------------------------
        override public void UpdateData(int[] aData)
        {
            if (aData.Length > Types.OFFSET_STATE_FP)
            {
                if (Enum.IsDefined(typeof(Types.StateFP), aData[Types.OFFSET_STATE_FP]))
                    state = (Types.StateFP)Enum.Parse(typeof(Types.StateFP), (aData[Types.OFFSET_STATE_FP]).ToString());
                else
                    state = Types.StateFP.Error;
            }
        }
        //--------------------------------------------------------------------------------------------------------
        //Akutalizuj parametry odczytane z PLC 
        public override void UpdateSettingsData(int[] aData)
        {
            if (aData.Length > Types.OFFSET_TIME_WAIT_PF && aData.Length > Types.OFFSET_TIME_PUMP_TO_SV)
            {
                timeWaitPF = aData[Types.OFFSET_TIME_WAIT_PF];
                timePumpToSV = aData[Types.OFFSET_TIME_PUMP_TO_SV];
            }
        }
        //-----------------------------------------------------------------------------------------
        public Types.StateFP GetState()
        {
            return state;
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja umozliwia alaczenie/wylaczenie pompy
        public ERROR ControlPump(Types.StateFP state)
        {
            ERROR aErr = new ERROR(0, 0);

            int[] aData = { (int)state };

            if (state == Types.StateFP.ON || state == Types.StateFP.OFF)
            {
                if (plc != null)
                    aErr.ErrorCodePLC = plc.WriteWords(Types.ADDR_FP_CTRL, 1, aData);
                else
                    aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;
            }
            else
                aErr.ErrorCode = Types.ERROR_CODE.CALL_INCORRECT_OPERATION;

            return aErr;
        }
        //-----------------------------------------------------------------------------------------
        public ERROR SetTimeWaitPF(int aValue)
        {
            ERROR aErr = new ERROR(0, 0);
            int[] aData = new int[1];

            aData[0] = aValue;
            if (plc != null)
                aErr.ErrorCodePLC = plc.WriteWords(Types.GetAddress(Types.AddressSpace.Settings, Types.OFFSET_TIME_WAIT_PF), 1, aData);
            else
                aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;

            return aErr;
        }
        //-----------------------------------------------------------------------------------------
        public ERROR SetTimePumpToSV(int aValue)
        {
            ERROR aErr = new ERROR(0, 0);
            int[] aData = new int[1];

            aData[0] = aValue;
            if (plc != null)
                aErr.ErrorCodePLC = plc.WriteWords(Types.GetAddress(Types.AddressSpace.Settings, Types.OFFSET_TIME_PUMP_TO_SV), 1, aData);
            else
                aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;

            return aErr;
        }
        //-----------------------------------------------------------------------------------------
    }
}
