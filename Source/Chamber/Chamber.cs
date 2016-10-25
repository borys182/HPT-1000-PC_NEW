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

        private bool                door;
        //------------------------------------------------------------------------------------------------
        public Chamber()
        {
            objects.Add(new Valve());
            objects.Add(new ForePump());
            objects.Add(new MFC());
            objects.Add(new PowerSupplay());
            objects.Add(new Vaporizer());
            objects.Add(new PressureControl());
            objects.Add(new Interlock());
        }
        //------------------------------------------------------------------------------------------------
        public void UpdateData(int []aData)
        {
            door        = Convert.ToBoolean(aData[Types.OFFSET_DOOR_STATE]);
            //aktualizuj dane obiektow
            foreach (ChamberObject aObject in objects)
                aObject.UpdateData(aData);
            
        }
        //------------------------------------------------------------------------------------------------
        public void UpdateSettings(int[] aData)
        {
            //aktualizuj dane obiektow
            foreach (ChamberObject aObject in objects)
                aObject.UpdateSettingsData(aData);
        }
        //------------------------------------------------------------------------------------------------
        public void SetPtrPLC(PLC plc)
        {
            foreach (ChamberObject aObject in objects)
                aObject.SetPonterPLC(plc);
        }
        //------------------------------------------------------------------------------------------------
        public ChamberObject GetObject(Types.TypeObject typeObj)
        {
            ChamberObject aObject = null;
            foreach (ChamberObject obj in objects)
            {
                if (typeObj == Types.TypeObject.FM && obj is MFC)
                    aObject = obj;
                if (typeObj == Types.TypeObject.FP && obj is ForePump)
                    aObject = obj;
                if (typeObj == Types.TypeObject.HV && obj is PowerSupplay)
                    aObject = obj;
                if (typeObj == Types.TypeObject.VL && obj is Valve)
                    aObject = obj;
                if (typeObj == Types.TypeObject.VP && obj is Vaporizer)
                    aObject = obj;
                if (typeObj == Types.TypeObject.PC && obj is PressureControl)
                    aObject = obj;
                if (typeObj == Types.TypeObject.INT && obj is Interlock)
                    aObject = obj;
            }
            return aObject;
        }
        //------------------------------------------------------------------------------------------------
    }
}
