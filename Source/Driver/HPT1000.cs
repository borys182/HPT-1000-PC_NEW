using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Chamber;

namespace HPT1000.Source.Driver
{
    /// <summary>
    /// Klasa driver opisujaca zachowanie sie komory oraz mozliwe funkcje przez nia wykonywane
    /// </summary>
    class HPT1000
    {

        #region Private
            private PLC             plc             = new PLC_Mitsubishi();
            private Chamber.Chamber chamber         = new Chamber.Chamber();

            private Types.StatusDevice    statusDevice  = Types.StatusDevice.Fail;
            private int                   stateValves   = 0x7;
            private Types.StateFP         stateFP       = Types.StateFP.Error;
            private Types.StateHV         stateHV       = Types.StateHV.Error; 
        #endregion

        #region Method
        public HPT1000()
        {
            chamber.SetPtrPLC(plc);
        }
        public void SetIPAddres(string aIPAddress)
        {
            plc.SetAddrIP(aIPAddress);
        }
        public int Connect()
        {
            int aRes = -1;
            aRes = plc.Connect();
            return aRes;
        }

        //Funkcaj watku drivera
        public void Run()
        {
            int[] aData = new int[Types.LENGHT_STATUS_DATA];

            plc.ReadWords(Types.ADDR_START_STATUS_CHAMBER, Types.LENGHT_STATUS_DATA, aData);
            aData[Types.INDEX_STATE_VALVES] = 0x9999;
            chamber.UpdateData(aData);
        }

        public int SetStateValve(Types.StateValve state, Types.TypeValve kindValve)
        {
            int iRes = 0;
            iRes = chamber.SetValveState(state,kindValve);
            return iRes;
        }

        public Types.StateValve GetStateValve(Types.TypeValve kindValve)
        {
            Types.StateValve state = 0;
            state = chamber.GetValveState(kindValve);
            return state;
        }

        public Types.StatusDevice GetStatusDevice()
        {
            return statusDevice;
        }

        //public StateFP

        public int WriteWords(string aAddr, int aSize, int[] aData)
        {
            int aRes = -1;
            aRes = plc.WriteWords( aAddr,  aSize,  aData);
            return aRes;
        }




        public int ReadWords(string aAddr, int aSize, int[] aData)
        {
            int aRes = -1;
            aRes = plc.ReadWords( aAddr,  aSize, aData);
            return aRes;
        }
        #endregion

    }
}
