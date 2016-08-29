using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Chamber
{
    class Chamber
    {
        private List<ChamberObject> objects = new List<ChamberObject>();

        private double              pressure = 0;
        private bool                door;
        private Types.DeviceStatus  status = Types.DeviceStatus.NoComm;

        public Chamber()
        {
            objects.Add(new Valve());
            objects.Add(new ForePump());
            objects.Add(new FlowMeter());
            objects.Add(new PowerSupplay());
        }

        public void UpdateData(int []aData)
        {
            pressure    = Types.ConvertIntToDouble(aData, Types.INDEX_PRESSURE);
            door        = Convert.ToBoolean(aData[Types.INDEX_DOOR_STATE]);

            if (Enum.IsDefined(typeof(Types.DeviceStatus), aData[Types.INDEX_DEVICE_STATUS]))
                status = (Types.DeviceStatus)Enum.Parse(typeof(Types.DeviceStatus), (aData[Types.INDEX_DEVICE_STATUS]).ToString()); // konwertuj int na Enum
            else
                status = Types.DeviceStatus.Uknown;

            //aktualizuj dane obiektow
            foreach (ChamberObject cObject in objects)
                cObject.UpdateData(aData);
            
        }
   
         public void SetPtrPLC(PLC plc)
        {
            foreach (ChamberObject cObject in objects)
                cObject.SetPonterPLC(plc);
        }

        public int SetValveState(Types.StateValve state , Types.TypeValve kindValve)
        {
            int iResult = 0;
            //iResult = valve.SetState(state, kindValve);
            return iResult;
        }

        public Types.StateValve GetValveState(Types.TypeValve kindValve)
        {
            Types.StateValve state = 0;
          //  state = valve.GetState(kindValve);
            return state;
        }
    }
}
