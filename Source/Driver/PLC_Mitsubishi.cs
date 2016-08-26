using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HPT1000.Source.Driver
{
    /// <summary>
    /// Klasa rzeczywistego urzadzenia PLC firmy Mitsubushhi. Jest ona odpowiedzialna za wymianę danych z PLC
    /// </summary>
    class PLC_Mitsubishi : PLC
    {
        #region Private
            //obiekt umozliwiajacy komunikacje z PLC bez uzycia narzedzia SetupUtility
            private ActProgTypeLib.ActProgTypeClass plc = new ActProgTypeLib.ActProgTypeClass();
            //parametry komunikacyjne okreslajcae typ PLC seri L
            private int typePLC         = 0x51 ; //typ PLC seri L
            private int typeProtocol    = 0x05 ; //ustawienie komunikacji jako TCP
        #endregion

        #region Public
            public string addressIP = "127.0.0.1";
        #endregion

        #region Method

        override public void SetAddrIP(string aAddrIP)
        {
            addressIP = aAddrIP;
        }

        //Metoda ma za zadanie otwarcie połączenia z PLC
        override public int Connect()
        {
            int aResult = -1;                //Return code
            try
            {
                plc.ActUnitType     = typePLC;  //Set the value of 'UnitType' to the property(UNIT_QNUSB).
                plc.ActProtocolType = 0x0D;     //Set the value of 'ProtocolType' to the property(PROTOCOL_USB).                     
                plc.ActHostAddress  = addressIP;
                plc.ActPassword     = "txt_Password.Text";//Set the value of 'Password'.
                
                aResult = plc.Open();       //The Open method is executed.
            }
            catch (Exception exception)
            {
                string aMessage = exception.Message;
            }
             return aResult;
        }

        override public int SetDevice(string aAddr, int aState)
        {
            int aResult = -1;
            try
            {
                aResult = plc.SetDevice(aAddr, aState);
            }
            catch(Exception exception)
            {
                string aMsg = exception.Message;
            }
            return aResult;
        }

        override public int GetDevice(string aAddr, out int aState)
        {
            int aResult = -1;
            aState = 0;
            try
            {
                aResult = plc.GetDevice(aAddr, out aState);
            }
            catch (Exception exception)
            {
                string aMsg = exception.Message;
            }
            return aResult;
        }

        override public int WriteWords(string aAddr, int aSize, int []aData)
        {
            int aResult = -1;
            try
            {
                aResult = plc.WriteDeviceBlock(aAddr, aSize, ref aData[0]);
            }
            catch (Exception exception)
            {
                string aMsg = exception.Message;
            }
            return aResult;
        }

        override public int ReadWords(string aAddr, int aSize, int[] aData)
        {
            int aResult = -1;
            try
            {
                aResult = plc.ReadDeviceBlock(aAddr, aSize, out aData[0]);
            }
            catch (Exception exception)
            {
                string aMsg = exception.Message;
            }
            return aResult;
        }
        #endregion
    }

}
