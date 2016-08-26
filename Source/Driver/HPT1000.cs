using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Chamber;

namespace HPT1000.Source.Driver
{
    enum StatusDevice   { Fail = 1,OK = 2 };
    enum StateFP        { OFF = 1 , ON = 2 , Error = 3};
    enum StateHV        { OFF = 1 , ON = 2 , Error = 3};

    /// <summary>
    /// Klasa driver opisujaca zachowanie sie komory oraz mozliwe funkcje przez nia wykonywane
    /// </summary>
    class HPT1000
    {

        #region Private
            private PLC             plc             = new PLC_Mitsubishi();
            private Chamber.Chamber chamber         = new Chamber.Chamber();

            private StatusDevice    statusDevice    = StatusDevice.Fail;
            private int             stateValves     = 0x7;
            private StateFP         stateFP         = StateFP.Error;
            private StateHV         stateHV         = StateHV.Error; 
        #endregion

        #region Method
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

        }

        public StatusDevice GetStatusDevice()
        {
            return statusDevice;
        }

        //Funkcja ma za zadanie podanie stanu danego zaworu
    /*    public Types.StateValve GetStateValves(Types.TypeValve kindValve )
        {
          
        }
    */
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
