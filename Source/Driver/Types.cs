using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPT1000.Source.Driver
{
    /// <summary>
    /// Klasa zawiera definicje typow oraz adresy komorek
    /// </summary>

    public class Types
    {
        /// <summary>
        /// TYPY WYLICZENIOWE
        /// </summary>
        public enum TypeValve       { SV = 0, VV = 1, V2 = 2, V3 = 3, V4 = 4, Flow1 = 5, Flow2 = 6, Flow3 = 7, Flow4 = 8 }; //Kolejnosc zaworow odpowiada kolejnosci stanow zaworow przesylanych w zbiorczym DWORD z PLC
        public enum StatusDevice    { Fail  = 1, OK   = 2 };
        public enum StateValve      { Close = 1, Open = 2, Error = 3, HalfOpen = 4 };
        public enum StateFP         { OFF   = 1, ON   = 2, Error = 3 };
        public enum StateHV         { OFF   = 1, ON   = 2, Error = 3 };
        public enum UnitFlow        { sccm, percent };
        public enum ModeHV          { Power , Voltage , Curent,Error};
        public enum TypeObject      { None, VL, FP,HV,FM }; //VL - vavle , FP - fore pump , HV - power suplay , FN - flow meter
        public enum DeviceStatus    { OK, NoComm, Error, Warning, Uknown };

        /// <summary>
        /// ADRESY KOMOREK PLC
        /// </summary>
        public static string ADDR_START_STATUS_CHAMBER      = "D100";
        public static string ADDR_VALVES_CTRL               = "D102";
        public static string ADDR_FP_CTRL                   = "D104";
        public static string ADDR_CYCLE_TIME                = "D106";
        public static string ADDR_ON_TIME                   = "D108";
        public static string ADDR_FLOW_1_CTR                = "D100";
        public static string ADDR_FLOW_2_CTR                = "D100";
        public static string ADDR_FLOW_3_CTR                = "D100";
        public static string ADDR_POWER                     = "D123";
        public static string ADDR_VOLTAGE                   = "D124";
        public static string ADDR_CURENT                    = "D125";


        public const int    LENGHT_STATUS_DATA              = 100;
        /// <summary>
        /// INDEX KONKRETNYCH DANYCH ODCZYTANYCH W ZBIORCZYM BUFORZE Z PLC
        /// </summary>
        
        //Dane odczytywane w watku
        public static int OFFSET_STATE_VALVES    = 1;
        public static int INDEX_STATE_FP        = 2;
        public static int INDEX_ACTUAL_FLOW_1   = 3;
        public static int INDEX_ACTUAL_FLOW_2   = 4;
        public static int INDEX_ACTUAL_FLOW_3   = 5;
        public static int INDEX_CYCLE_TIME      = 6;
        public static int INDEX_ON_TIME         = 7;
        public static int INDEX_POWER           = 8;
        public static int INDEX_VOLTAGE         = 9;
        public static int INDEX_CURENT          = 10;
        public static int INDEX_MODE_HV         = 11;
        public static int INDEX_STATUS_HV       = 12;
        //Dane odczytywane jako setings tylko na zdarzenie
        public static int INDEX_LIMIT_POWER     = 13;
        public static int INDEX_LIMIT_CURENT    = 14;
        public static int INDEX_LIMIT_VOLTAGE   = 15;

        public static int INDEX_PRESSURE = 11;
        public static int INDEX_DEVICE_STATUS = 11;
        public static int INDEX_DOOR_STATE = 11;



        /// <summary>
        /// KODY BLEDOW
        /// </summary>
        public static int ERROR_PLC_PTR_NULL                = 0x01;     //Brak wskaznika na obiekt protokolu PLC
        public static int ERROR_CALL_INCORRECT_OPERATION    = 0x02;     //Wywolanie zabronienioej operacji na danym obiekcie
        public static int ERROR_BAD_FLOW_ID                  = 0x03;     //proba wykonia zapisu do plc info o przeplywkach o id roznym niz 0-2 (innych nie ma w plc)

        /// <summary>
        /// Pomocniecze funkcje
        /// </summary>
        public static double ConvertIntToDouble(int[] aData, int aIndex)
        {
            double aValue = 0;
            byte[] aBytes = new byte[4];

            aBytes[0] = (byte)( aData[aIndex]    & 0xFF);
            aBytes[1] = (byte)((aData[aIndex]    & 0xFF00) >> 8);
            aBytes[2] = (byte)( aData[aIndex +1] & 0xFF);
            aBytes[3] = (byte)((aData[aIndex +1] & 0xFF00) >> 8);

            aValue = BitConverter.ToSingle(aBytes, 0);

            return aValue;
        }
    }
}
