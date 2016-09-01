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
            pressure    = Types.ConvertDWORDToDouble(aData, Types.OFFSET_PRESSURE);
            door        = Convert.ToBoolean(aData[Types.OFFSET_DOOR_STATE]);

            if (Enum.IsDefined(typeof(Types.DeviceStatus), aData[Types.OFFSET_DEVICE_STATUS]))
                status = (Types.DeviceStatus)Enum.Parse(typeof(Types.DeviceStatus), (aData[Types.OFFSET_DEVICE_STATUS]).ToString()); // konwertuj int na Enum
            else
                status = Types.DeviceStatus.Unknown;

            //aktualizuj dane obiektow
            foreach (ChamberObject aObject in objects)
                aObject.UpdateData(aData);
            
        }
        public void SetPtrPLC(PLC plc)
        {
            foreach (ChamberObject aObject in objects)
                aObject.SetPonterPLC(plc);
        }
        public ChamberObject GetObject(Types.TypeObject typeObj)
        {
            ChamberObject aObject = null;

            foreach(ChamberObject obj in objects)
            {
                if (obj.GetTypeObject() == typeObj)
                    aObject = obj;
            }
            return aObject;
        }
    }
}
