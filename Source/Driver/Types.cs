﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPT1000.Source.Driver
{
    public struct ERROR
    {
        private Types.ERROR_CODE     errorCode    { set; get; }
        private int                  errorCodePLC { set; get; }

        public int ErrorCodePLC
        {
            set
            {
                errorCodePLC = value;
                if (value == 0) errorCode = Types.ERROR_CODE.NONE;
                else            errorCode = Types.ERROR_CODE.PLC_WRITE;
            }
            get { return errorCodePLC; }
        }

        public Types.ERROR_CODE ErrorCode
        {
            set { errorCode = value; }
            get { return errorCode; }
        }

        public ERROR(int aDifer)
        {
            errorCode       = Types.ERROR_CODE.NONE;
            errorCodePLC    = 0;
        }
    }

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
        public enum ModeHV          { Power = 1 , Voltage = 2 , Curent = 3, Unknown = 4};
        public enum TypeObject      { None, VL, FP,HV,FM }; //VL - vavle , FP - fore pump , HV - power suplay , FN - flow meter
        public enum DeviceStatus    { OK, NoComm, Error, Warning, Unknown };
        public enum ControlProgram  { Start,Stop,Resume };
        public enum WorkModeHV      { Power = 1, Voltage = 2, Curent = 3};
        public enum Word            { LOW , HIGH};
        public enum GasProcesMode   { Unknown = 0, Presure_MFC = 1, Pressure_Vap = 2, FlowSP = 3}; //okreslenie sposobu sterowania gazami w komorze {Presure_MFC - proznia jest utrzymywana przez PID z 3 przeplywek, Pressure_Vap proznia jest utrzymywana przez PID z vaporatora, FlowSP - sterujemy zgodnie z ustawionymi setpontami}
        public enum StatusSubprogram { Wait , Working , Suspended , Done , Warning , Error  };
        public enum ControlMode     { Automatic , Manual}

        public enum ERROR_CODE
        {
            NONE                        = 0x00,
            PLC_PTR_NULL                = 0x01,         //Brak wskaznika na obiekt protokolu PLC
            CALL_INCORRECT_OPERATION    = 0x02,         //Wywolanie zabronienioej operacji na danym obiekcie
            BAD_FLOW_ID                 = 0x03,         //proba wykonia zapisu do plc info o przeplywkach o id roznym niz 0-2 (innych nie ma w plc)
            PLC_WRITE                   = 0x04          //Nie powiodl sie zapis do sterownika PLC. Dodatkowe informacje sa zwrocone w kodzie bezposrednio ze sterownika PLC (MX Components)
        }
        
        /// <summary>
        /// ADRESY KOMOREK PLC
        /// </summary>
        public static string ADDR_START_STATUS_CHAMBER      = "D1000"; //poczatek bufora z danymi przedstawiajacymi stan systemu 
        public static string ADDR_START_BUFFER_PROGRAM      = "D2000";

     
        //Adresy komorek do sterowania recznego
        public static string ADDR_VALVES_CTRL               = "D102";
        public static string ADDR_FP_CTRL                   = "D104";
        public static string ADDR_CYCLE_TIME                = "D106";
        public static string ADDR_ON_TIME                   = "D108";
        public static string ADDR_FLOW_1_CTR                = "D100";
        public static string ADDR_FLOW_2_CTR                = "D100";
        public static string ADDR_FLOW_3_CTR                = "D100";
        public static string ADDR_POWER_SUPPLAY_SETPOINT    = "D123";
        public static string ADDR_POWER_SUPPLAY_MODE        = "D124";
        public static string ADDR_POWER_SUPPLAY_OPERATE     = "D125";
        public static string ADDR_PRESSURE_SETPOINT         = "D125";
        public static string ADDR_PRESSURE_MODE             = "D125";


        //Adresy komorek do dostrajania parametrow programu. Jest to adres poczatku buforu danych gdzie sa przechowywane parametry aktualnie wykonywanego programu
        //Pamietaj zmienijac adres tej przestrzeniu tutaj tez musisz zmienic adres
        //Kolejne parametry urządzen posiadaja adresy zgodnie z ofsetem danego parametru w programie
        public static string ADDR_CONTROL_PROGRAM           = "D1050";

        public const int    LENGHT_STATUS_DATA              = 100;
        public const int    SEGMENT_SIZE                    = 30;
        public const int    MAX_SEGMENTS                    = 100;//Max liczba segmentow z ktorych moze sie skladac program po stronie PLC
        /// <summary>
        /// OFFSET KONKRETNYCH DANYCH ODCZYTANYCH W ZBIORCZYM BUFORZE Z PLC
        /// </summary>

        //Dane odczytywane ciagle w watku
        public static int OFFSET_DEVICE_STATUS  = 0;
        public static int OFFSET_PRESSURE       = 1;
        public static int OFFSET_DOOR_STATE     = 3;
        public static int OFFSET_STATE_FP       = 4;
        public static int OFFSET_STATUS_HV      = 5;
        public static int OFFSET_MODE_HV        = 6;
        public static int OFFSET_VOLTAGE        = 7;
        public static int OFFSET_CURENT         = 9;
        public static int OFFSET_POWER          = 11;
        public static int OFFSET_STATE_VALVES   = 13;
        public static int OFFSET_ACTUAL_FLOW_1  = 14;
        public static int OFFSET_ACTUAL_FLOW_2  = 16;
        public static int OFFSET_ACTUAL_FLOW_3  = 18;
        public static int OFFSET_CYCLE_TIME     = 20;
        public static int OFFSET_ON_TIME        = 22;
        public static int OFFSET_MODE_PRESSURE  = 24;


        //Dane aktualnie wykonywanego programu i subprogramu odczytywane ciagle
        public static int OFFSET_PRG_CONTROL        = 0;
        public static int OFFSET_PRG_STATUS         = 1;
        public static int OFFSET_PRG_SEQ_COUNTS     = 2;
        public static int OFFSET_PRG_ACTUAL_SEQ_NO  = 3;
        public static int OFFSET_PRG_TIME_PUMP      = 5;
        public static int OFFSET_PRG_TIME_GAS       = 6;
        public static int OFFSET_PRG_TIME_HV        = 7;
        public static int OFFSET_PRG_TIME_VENT      = 8;
        public static int OFFSET_PRG_TIME_FLUSH     = 9;
        public static int OFFSET_PRG_SEQ_DATA       = 10;





        //Dane odczytywane jako setings tylko na zdarzenie
        public static int OFFSET_LIMIT_POWER    = 13;
        public static int OFFSET_LIMIT_CURENT   = 14;
        public static int OFFSET_LIMIT_VOLTAGE  = 15;


        //Offset od bazowego adresu dla kolejnych parametrow subprogramu
        public static int OFFSET_SEQ_CMD                = 0;
        public static int OFFSET_SEQ_STATUS             = 2;
        public static int OFFSET_SEQ_PUMP_MAX_TIME      = 3;
        public static int OFFSET_SEQ_PUMP_SP            = 4;
        public static int OFFSET_SEQ_VENT_TIME          = 7;
        public static int OFFSET_SEQ_FLUSH_TIME         = 8;
        public static int OFFSET_SEQ_FLOW_1_FLOW        = 9;
        public static int OFFSET_SEQ_FLOW_1_MIN_FLOW    = 11;
        public static int OFFSET_SEQ_FLOW_1_MAX_FLOW    = 11;
        public static int OFFSET_SEQ_FLOW_1_SHARE       = 11;
        public static int OFFSET_SEQ_FLOW_1_DEVIATION   = 11;
        public static int OFFSET_SEQ_FLOW_2_FLOW        = 9;
        public static int OFFSET_SEQ_FLOW_2_MIN_FLOW    = 11;
        public static int OFFSET_SEQ_FLOW_2_MAX_FLOW    = 11;
        public static int OFFSET_SEQ_FLOW_2_SHARE       = 11;
        public static int OFFSET_SEQ_FLOW_2_DEVIATION   = 11;
        public static int OFFSET_SEQ_FLOW_3_FLOW        = 9;
        public static int OFFSET_SEQ_FLOW_3_MIN_FLOW    = 11;
        public static int OFFSET_SEQ_FLOW_3_MAX_FLOW    = 11;
        public static int OFFSET_SEQ_FLOW_3_SHARE       = 11;
        public static int OFFSET_SEQ_FLOW_3_DEVIATION   = 11;
        public static int OFFSET_SEQ_FLOW_4_ON_TIME     = 18;
        public static int OFFSET_SEQ_FLOW_4_CYCLE_TIME  = 20;
        public static int OFFSET_SEQ_MOTOR_1_CMD        = 22;
        public static int OFFSET_SEQ_MOTOR_1_SPEED      = 23;
        public static int OFFSET_SEQ_MOTOR_2_CMD        = 25;
        public static int OFFSET_SEQ_MOTOR_2_SPEED      = 26;
        public static int OFFSET_SEQ_DELAY_TIME         = 28;
        public static int OFFSET_SEQ_CHECK_VACUUM_SP    = 29;
        public static int OFFSET_SEQ_HV_OPERATE         = 31;
        public static int OFFSET_SEQ_HV_SETPOINT        = 32;
        public static int OFFSET_SEQ_HV_TIME            = 34;
        public static int OFFSET_SEQ_GAS_MODE           = 34;
        public static int OFFSET_SEQ_GAS_TIME           = 34;
        public static int OFFSET_SEQ_GAS_SETPOINT       = 34;
        public static int OFFSET_SEQ_GAS_MIN_DIFFER     = 34;
        public static int OFFSET_SEQ_GAS_MAX_DIFFER     = 34;


        //Bity w slowie komendy programu dla kolejnych funkcji
        public static int BIT_CMD_PUMP              = 0;
        public static int BIT_CMD_PUMP_BUTTERFLY    = 1;
        public static int BIT_CMD_STOP              = 2;
        public static int BIT_CMD_VENT              = 3;
        public static int BIT_CMD_FLUSH             = 4;
        public static int BIT_CMD_HV                = 5;
        public static int BIT_CMD_FLOW_1            = 6;
        public static int BIT_CMD_FLOW_2            = 7;
        public static int BIT_CMD_FLOW_3            = 8;
        public static int BIT_CMD_FLOW_4            = 9;
        public static int BIT_CMD_MOTOR_1           = 10;
        public static int BIT_CMD_MOTOR_2           = 11;
        public static int BIT_CMD_DELAY             = 12;
        public static int BIT_CMD_CHECK_VACUM       = 13;
        public static int BIT_CMD_END               = 14;
    
        /// <summary>
        /// Pomocniecze funkcje
        /// </summary>
        public static double ConvertDWORDToDouble(int[] aData, int aIndex)
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

        //Funkcaj ma za zadanie przekonwertowanie float na dwa wordy i zwrocenie mlodszego badz starszego
        public static int ConvertDOUBLEToInt(double aValue,Word whichWord )
        {
            int aWord = 0;
            byte[] aBytes = new byte[4];

            aBytes = BitConverter.GetBytes(aValue);         // przkonwertuj float na tablice bajtow

            if(whichWord == Word.HIGH)
                aWord = (int)(aBytes[1] << 8 | aBytes[0]);
            else
                aWord = (int)(aBytes[3] << 8 | aBytes[2]);

            return aWord;
        }
    }
}
