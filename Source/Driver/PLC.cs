using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPT1000.Source.Driver
{
     /**
     * Klasa bazowa dla konkretnych typow PLC. Wymusza na nich implementacje funkcji do komunikacji oraz czytania/zapisywania danych
    */
    public abstract class PLC
    {
        protected Types.TypePLC   typePLC   = Types.TypePLC.L;           ///<Zmienna okrela typ sterownika PLC 
        protected Types.TypeComm  typeComm  = Types.TypeComm.USB;        ///<Zmienna okresla typ komunikacji sie ze sterownikiem PLC
        protected string    addressIP       = "127.0.0.1";

        //----------------------------------------------------------------------------------------
        abstract public int Connect();                          ///<Funkcja ma za zadanie opierajac sie na parmaetrach komunikacyjnych polaczenie sie z PLC. Aktualne polaczenie zostaje przerwane
        //----------------------------------------------------------------------------------------
        abstract public int SetDevice(string aAddr, int aState);                ///<Funkcja ustawia przestrzn dyskrtna w PLC na podana wartosc
        //----------------------------------------------------------------------------------------
        abstract public int GetDevice(string aAddr, out int aState);            ///<Funkcja zwraca stan flagi spod danego adresu w przestrzeni PLC
        //----------------------------------------------------------------------------------------
         abstract public int WriteWords(string aAddr, int aSize, int[] aData);   ///<Zapisz w przestrzeni PLC dana liczbe rejestrow wartosciami 16 bitowymi
        //----------------------------------------------------------------------------------------
        abstract public int ReadWords(string aAddr, int aSize, int[] aData);    ///<Odczytaj z przestrzeni PLC dana liczbe rejestrow 16 bitowych
        //----------------------------------------------------------------------------------------
        abstract public int WriteRealData(string aAddr, float aValue);          ///<Zapisz w przestrzeni PLC liczbe zmienno przecinkowa (dwa rejestry 16 bitiwe)
        //----------------------------------------------------------------------------------------
        abstract public int ReadRealData(string aAddr , out float aValue);      ///<Odczytaj z przestrzeni PLC liczbe zmienno przecinkowa (dwa rejestry 16 bitiwe)
        //----------------------------------------------------------------------------------------
        public void SetAddrIP(string aAddrIP)
        {
            addressIP = aAddrIP;
        }
        //----------------------------------------------------------------------------------------
        public void SetTypePLC(Types.TypePLC aType)
        {
            typePLC = aType;
        }
        //----------------------------------------------------------------------------------------
        public Types.TypePLC GetTypePLC()
        {
            return typePLC;
        }
        //----------------------------------------------------------------------------------------
        public void SetTypeComm(Types.TypeComm aType)
        {
            typeComm = aType;
        }
        //----------------------------------------------------------------------------------------
        public Types.TypeComm GetTypeComm()
        {
            return typeComm;
        }
        //----------------------------------------------------------------------------------------

    }
}
