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
        private Types.StatusProgram     status      = Types.StatusProgram.Stop;
        private string                  description = "";
        private uint                    id          = 0;

        private static RefreshProgram   refreshProgram = null;

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
        //-------------------------------------------------------------------------------------------------------------------------
        public override bool Equals(object other)
        {
            bool aRes = false;

            //Porownuje tylko po referencji bo w kilku miejscach sie odnosze do tej samej referencji i cos zmieniam.
            if (ReferenceEquals(this, other))// || (this.GetType() == other.GetType() && ((Subprogram)this).id == ((Subprogram)other).ID))
                aRes = true;

            return aRes;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //Funkcja aktualizaje dane na temat subprogramu wykonywanego aktulnie w sterowniku PLC
        public void UpdateData(SubprogramData aSubprogramData)
        {
            stepObjects[0].UpdateData(aSubprogramData);
            stepObjects[1].UpdateData(aSubprogramData);
            stepObjects[2].UpdateData(aSubprogramData);
            stepObjects[3].UpdateData(aSubprogramData);
            stepObjects[4].UpdateData(aSubprogramData);
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Status jest odczytywany ze zbiorczej tablicy w celu optyamlizacji odczytu danych z PLC
        public void UpdateStatus(int[] aData)
        {
            if(aData.Length > (id -1 + Types.OFFSET_STATUS_DATA) )
                status = (Types.StatusProgram)aData[id - 1 + Types.OFFSET_STATUS_DATA];
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

            if (refreshProgram != null)
                refreshProgram();
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
        public static void AddToRefreshList(RefreshProgram aRefresh)
        {
            refreshProgram = aRefresh;
        }
        //-------------------------------------------------------------------------------------------------------------------------
    }
}
