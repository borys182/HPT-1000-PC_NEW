using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Program
{
     public class Subprogram : Object
    {
        private string                  name        = "Sub-program name";
        private Types.StatusProgram     status      = Types.StatusProgram.NoLoad;
        private string                  description = "";
        private uint                    id          = 0;     

        public ProcesObject[] stepObjects = new ProcesObject[5]; //Każdy segment może się składać max z 5 procesow (tyle mamy obiektow procesow)

        public ProcesObject PumpProces      { get { return stepObjects[0]; } }
        public ProcesObject GasProces       { get { return stepObjects[1]; } }
        public ProcesObject PlasmaProces    { get { return stepObjects[2]; } }
        public ProcesObject PurgeProces     { get { return stepObjects[3]; } }
        public ProcesObject VentProces      { get { return stepObjects[4]; } }
        public uint ID { get { return id; } }

        //------------------------------------------------------------------------------------------------------------------------------------------------------
        public Subprogram(uint aId)
        {
            id = aId;
            stepObjects[0] = new PumpProces();
            stepObjects[1] = new GasProces();
            stepObjects[2] = new PlasmaProces();
            stepObjects[3] = new FlushProces();
            stepObjects[4] = new VentProces();
            name           = "Subprogram " + id.ToString();
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //Funkcja aktualizaje dane na temat subprogramu wykonywanego aktulnie w sterowniku PLC
        public void UpdateData(SubprogramData aSubprogramData)
        {
            status = (Types.StatusProgram)aSubprogramData.Status;
            stepObjects[0].UpdateData(aSubprogramData);
            stepObjects[1].UpdateData(aSubprogramData);
            stepObjects[2].UpdateData(aSubprogramData);
            stepObjects[3].UpdateData(aSubprogramData);
            stepObjects[4].UpdateData(aSubprogramData);
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Funkcja zwraca tablice danych segmentu przygotowana zgodnie z segmentem po stronie PLC
        public int[] GetPLCSegmentData()
        {
            int[] aData = new int[Types.SEGMENT_SIZE];

            for (int i = 0; i < stepObjects.Length; i++)
                stepObjects[i].PrepareDataPLC(aData);

            return aData;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public PumpProces GetPumpProces()
        {
            return (PumpProces)stepObjects[0];
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public GasProces GetGasProces()
        {
            return (GasProces)stepObjects[1];
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public PlasmaProces GetPlasmaProces()
        {
            return (PlasmaProces)stepObjects[2];
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public FlushProces GetPurgeProces()
        {
            return (FlushProces)stepObjects[3];
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public VentProces GetVentProces()
        {
            return (VentProces)stepObjects[4];
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public void SetName(string aName)
        {
            name = aName;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public string GetName()
        {
            return name;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return GetName();
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public void SetDescription(string aDesc)
        {
            description = aDesc;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public string GetDescription()
        {
            return description;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public Types.StatusProgram GetStatus()
        {
            return status;
        }
        //-------------------------------------------------------------------------------------------------------------------------
    }
}
