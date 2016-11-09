using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPT1000.Source.Driver
{

    /// <summary>
    /// Klasa rzeczywistego urzadzenia PLC firmy Mitsubushhi. Jest ona odpowiedzialna za wymianę danych z PLC
    /// </summary>
    class PLC_Mitsubishi : PLC
    {
        //obiekt umozliwiajacy komunikacje z PLC bez uzycia narzedzia SetupUtility
        private ActProgTypeLib.ActProgTypeClass plc = null;

        private static object sync_Object = new object();

        private Random random = new Random();

        //-----------------------------------------------------------------------------------------
        public PLC_Mitsubishi()
        {
            typePLC = Types.TypePLC.L;
            InitialDummyModeData();

            try
            {
                plc = new ActProgTypeLib.ActProgTypeClass();
            }
            catch(Exception e)
            {
                ERROR aErr = new ERROR();
                aErr.SetErrorApp(Types.EventType.MX_COMPONENTS_NO_INSTALL);
                Logger.AddError(aErr);
            }
        }
        //-----------------------------------------------------------------------------------------
        private void InitialDummyModeData()
        {
            dummyModeStatusChamberData[0] = 1;
            dummyModeStatusChamberData[1] = 0;     //pressure
            dummyModeStatusChamberData[2] = 1;
            dummyModeStatusChamberData[4] = (int)Types.StateFP.ON;
            dummyModeStatusChamberData[5] = (int)Types.StateHV.ON;
            dummyModeStatusChamberData[6] = (int)Types.ModeHV.Power;
            dummyModeStatusChamberData[7] = 0;     //actula HV value
            dummyModeStatusChamberData[8] = 1;
            dummyModeStatusChamberData[9] = 0;
            dummyModeStatusChamberData[10] = 1;
            dummyModeStatusChamberData[11] = 0;
            dummyModeStatusChamberData[12] = 1;
            dummyModeStatusChamberData[13] = 0xAAAA; // state valves
            dummyModeStatusChamberData[14] = 0;
            dummyModeStatusChamberData[15] = 345;  //actual flow
            dummyModeStatusChamberData[17] = 157;
            dummyModeStatusChamberData[19] = 289;
            dummyModeStatusChamberData[27] = (int)Types.Mode.Automatic;
            dummyModeStatusChamberData[35] = 0xD6A; //InterlockState {}
        }
        //-----------------------------------------------------------------------------------------
        private void GenerateRandomValueForDummyMode()
        {
            double pressure = random.Next(0, 1000);
            double power    = random.Next(0, 500);
            double voltage  = random.Next(0, 1000);
            double curent   = random.Next(0, 100);
            int flow1       = random.Next(0, 500);
            int flow2       = random.Next(0, 500);
            int flow3       = random.Next(0, 500);

            dummyModeStatusChamberData[1] = Types.ConvertDOUBLEToWORD(pressure, Types.Word.LOW);      //pressure
            dummyModeStatusChamberData[2] = Types.ConvertDOUBLEToWORD(pressure, Types.Word.HIGH);     //pressure

            dummyModeStatusChamberData[7] = Types.ConvertDOUBLEToWORD(voltage, Types.Word.LOW);      //voltage
            dummyModeStatusChamberData[8] = Types.ConvertDOUBLEToWORD(voltage, Types.Word.HIGH);     //voltage

            dummyModeStatusChamberData[9] = Types.ConvertDOUBLEToWORD(curent, Types.Word.LOW);      //curent
            dummyModeStatusChamberData[10] = Types.ConvertDOUBLEToWORD(curent, Types.Word.HIGH);     //curent

            dummyModeStatusChamberData[11] = Types.ConvertDOUBLEToWORD(power, Types.Word.LOW);      //power
            dummyModeStatusChamberData[12] = Types.ConvertDOUBLEToWORD(power, Types.Word.HIGH);     //power


            dummyModeStatusChamberData[15] = flow1;   //actual flow 1
            dummyModeStatusChamberData[17] = flow2;   //actual flow 2
            dummyModeStatusChamberData[19] = flow3;   //actual flow 3

        }
        //-----------------------------------------------------------------------------------------
        //Metoda ma za zadanie otwarcie połączenia z PLC
        override public int Connect()
        {
            int aResult = -1;                //Return code
            lock (this)
            {
                try
                {
                    plc.Disconnect();

                    plc.ActUnitType     = (int)typePLC;     //Set the value of 'UnitType' to the property(UNIT_QNUSB).
                    plc.ActProtocolType = (int)typeComm;    //Set the value of 'ProtocolType' to the property(PROTOCOL_USB).                     
                    plc.ActHostAddress  = addressIP;
                    plc.ActPassword     = "txt_Password.Text";//Set the value of 'Password'.

                    aResult             = plc.Open();       //The Open method is executed.
                }
                catch (Exception exception)
                {
                    string aMessage = exception.Message;
                }
            }
            return aResult;
        }
        //-----------------------------------------------------------------------------------------
        override public int SetDevice(string aAddr, int aState)
        {
            int aResult = -1;
            lock (this)//sync_Object)
            {
                try
                {
                    aResult = plc.SetDevice(aAddr, aState);
                }
                catch (Exception exception)
                {
                    string aMsg = exception.Message;
                }
            }
            return aResult;
        }
        //-----------------------------------------------------------------------------------------
        override public int GetDevice(string aAddr, out int aState)
        {
            int aResult = -1;
            lock (this)
            {

                aState = 0;
                try
                {
                    aResult = plc.GetDevice(aAddr, out aState);
                }
                catch (Exception exception)
                {
                    string aMsg = exception.Message;
                }
            }
            return aResult;
        }
        //-----------------------------------------------------------------------------------------
        override public int WriteWords(string aAddr, int aSize, int[] aData)
        {
            int aResult = -1;
            lock (this)
            {

                try
                {
                    aResult = plc.WriteDeviceBlock(aAddr, aSize, ref aData[0]);
                }
                catch (Exception exception)
                {
                    string aMsg = exception.Message;
                }
                //przypisz wartosc do tablicy
                if (dummyMode && aAddr == Types.ADDR_MODE_CONTROL)
                {
                    dummyModeStatusChamberData[27] = aData[0];
                    aResult = 0;
                }
            }
            return aResult;
        }
        //-----------------------------------------------------------------------------------------
        override public int ReadWords(string aAddr, int aSize, int[] aData)
        {
            int aResult = -1;
            int aStartAddr = 1000;

            Int32.TryParse(aAddr.Remove(0, 1), out aStartAddr);

            lock (this)
            {
                if (dummyMode && aAddr == Types.ADDR_START_STATUS_CHAMBER)
                {
                    GenerateRandomValueForDummyMode();
                    for (int i = 0; i < aData.Length;i++)
                        if(i < dummyModeStatusChamberData.Length)
                            aData[i] = dummyModeStatusChamberData[i];
                }
                else
                {
                    try
                    {
                        for (int i = 0; i < aSize; i++)
                        {
                            aAddr = "D" + (aStartAddr + i).ToString();
                            aResult = plc.ReadDeviceBlock(aAddr, 1/*aSize*/, out aData[i]);
                        }
                    }
                    catch (Exception exception)
                    {
                        string aMsg = exception.Message;
                    }
                }       
            }
            return aResult;
        }
        //-----------------------------------------------------------------------------------------
        override public int WriteRealData(string aAddr, float aValue)
        {
            int aResult    = 0;
            int []aData    = new int[2];
            byte[]aBytes   = new byte[4];

            lock (this)
            {

                aBytes = BitConverter.GetBytes(aValue);         // przkonwertuj float na tablice bajtow

                aData[0] = (int)(aBytes[1] << 8 | aBytes[0]);   //zluz bajty w odpowiednie slowa
                aData[1] = (int)(aBytes[3] << 8 | aBytes[2]);

                aResult = WriteWords(aAddr, 2, aData);          //wgraj do PLC
            }
            return aResult;
        }
        //-----------------------------------------------------------------------------------------
        override public int ReadRealData(string aAddr, out float aValue)
        {
            int aResult = 0;

            int[] aData = new int[2];
            byte[] aBytes = new byte[4];

            lock (this)
            {

                aResult = ReadWords(aAddr, 2, aData);

                if (aResult == 0)
                {
                    aBytes[0] = (byte)(aData[0]  & 0xFF);
                    aBytes[1] = (byte)((aData[0] & 0xFF00) >> 8);
                    aBytes[2] = (byte)(aData[1]  & 0xFF);
                    aBytes[3] = (byte)((aData[1] & 0xFF00) >> 8);
                }
                aValue = BitConverter.ToSingle(aBytes, 0);
            }
            return aResult;
        }
        //-----------------------------------------------------------------------------------------
    }
}
