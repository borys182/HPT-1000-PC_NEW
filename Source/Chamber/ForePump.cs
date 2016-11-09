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
            base.UpdateData(aData);
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
        public ItemLogger ControlPump(Types.StateFP state)
        {
            ItemLogger aErr = new ItemLogger();

            int[] aData = { (int)state };

            if (state == Types.StateFP.ON || state == Types.StateFP.OFF)
            {
                if (plc != null)
                {
                    if (controlMode == Types.ControlMode.Manual)
                    {
                        int aCode = plc.WriteWords(Types.ADDR_FP_CTRL, 1, aData);
                        aErr.SetErrorMXComponents(Types.EventType.CONTROL_PUMP, aCode);
                    }
                    else
                        aErr.SetErrorApp(Types.EventType.CONTROL_PUMP);
                }
                else
                    aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);
            }
            else
                aErr.SetErrorApp(Types.EventType.CALL_INCORRECT_OPERATION);

            return aErr;
        }
        //-----------------------------------------------------------------------------------------
        public ItemLogger SetTimeWaitPF(int aValue)
        {
            ItemLogger aErr = new ItemLogger();
            int[] aData = new int[1];

            aData[0] = aValue;
            if (plc != null)
            {
                int aCode = plc.WriteWords(Types.GetAddress(Types.AddressSpace.Settings, Types.OFFSET_TIME_WAIT_PF), 1, aData);
                aErr.SetErrorMXComponents(Types.EventType.SET_WIAT_TIME_PF, aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            if (!aErr.IsError())
                timeWaitPF = aValue;

            return aErr;
        }
        //-----------------------------------------------------------------------------------------
        public ItemLogger SetTimePumpToSV(int aValue)
        {
            ItemLogger aErr = new ItemLogger();
            int[] aData = new int[1];

            aData[0] = aValue;
            if (plc != null)
            {
                int aCode = plc.WriteWords(Types.GetAddress(Types.AddressSpace.Settings, Types.OFFSET_TIME_PUMP_TO_SV), 1, aData);
                aErr.SetErrorMXComponents(Types.EventType.SET_TIME_PUMP_TO_SV, aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            if (!aErr.IsError())
                timePumpToSV = aValue;

            return aErr;
        }
        //-----------------------------------------------------------------------------------------
    }
}
