using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Chamber;

namespace HPT1000.Source.Driver
{
    /// <summary>
    /// Klasa zawiera definicje typow oraz adresy komorek
    /// </summary>

    public struct DataBaseData
    {
        public int      ID_Para;
        public double   Value;
        public Value    ValuePtr;
        public string   Unit;
        public DateTime Date;

    };

    public struct Sesion
    {
        public int ID;
        public DateTime StartDate;
        public DateTime EndDate;
    };

    public struct DataBaseDevice
    {
        public int      DeviceID;
        public int      ParaID;
        public string   DeviceName;
        public string   ParaName;
    };

    public struct ConfigPara
    {
        public int      ID;
        public int      ParameterID;
        public double   Frequency;
        public double   Difference;
        public bool     Enabled;
        public int      Mode;
    };
    //Struktrua zawiera informacje na temat danego parametru programu przechowywanego w bazie danych
    public struct ProgramParameter
    {
        public int      ID;
        public string   Name;
        public string   Data;
    }

    public class Types
    {
        /// <summary>
        /// TYPY WYLICZENIOWE
        /// </summary>
        public enum TypeValve       { SV = 0, VV = 1, Purge = 2, Gas = 3, None }; //Kolejnosc zaworow odpowiada kolejnosci stanow zaworow przesylanych w zbiorczym DWORD z PLC
        public enum DriverStatus    { Unknown = 0, OK = 1, NoComm = 2, Error = 3, Warning = 4, DummyMode };
        public enum StateValve      { Unknown = 0, Close = 1, Open = 2, Error = 3, HalfOpen = 4 };
        public enum StateFP         { OFF   = 1, ON   = 2, Error = 3 };
        public enum StateHV         { OFF   = 1, ON   = 2, Error = 3 };
        public enum UnitFlow        { sccm, percent, ms };
        public enum ModeHV          { Power = 1 , Voltage = 2 , Curent = 3, Unknown = 4};
        public enum TypeObject      { None, VL, FP, HV, FM, VP, PC, INT }; //VL - vavle , FP - fore pump , HV - power suplay , FN - flow meter, VP - Vaporizer, PC-pressure control
        public enum ControlProgram  { Start = 1,Stop = 2,Resume = 3 };
        public enum WorkModeHV      { Power = 1, Voltage = 2, Curent = 3};
        public enum Word            { LOW , HIGH};
        public enum GasProcesMode   { Unknown = 0, FlowSP = 1, Presure_MFC = 2, Pressure_Vap = 3}; //okreslenie sposobu sterowania gazami w komorze {Presure_MFC - proznia jest utrzymywana przez PID z 3 przeplywek, Pressure_Vap proznia jest utrzymywana przez PID z vaporatora, FlowSP - sterujemy zgodnie z ustawionymi setpontami}
        public enum StatusProgram   { Unknown = 0 , Run = 1 , Stop = 2, Error = 3, Done = 4, Suspended = 5, Wait = 6 , Warning = 7 , NoLoad = 8};
        public enum ControlMode     { Automatic , Manual}
        public enum AddressSpace    { Settings, Program};
        public enum Language        { English = 1 };
        public enum Mode            { Automatic = 1, Manual = 2, None = 3 };
        public enum TypeComm        { USB = 0x0D, TCP = 0x05 };
        public enum TypePLC         { L = 0x51 };
        public enum UserPrivilige   { None = 0, Administrator = 1, Operator = 2, Service = 3, Technican = 4};
        public enum TypeInterlock   { None = 0 , Door = 1 , VacuumSwitch = 2 , ThermalSwitch = 3 , PressureGauge = 4 , EmgStop = 5  }
        public enum TypeDisableAccount  { Temporarily = 1 , Immediately = 2 , Access = 3  }
        public enum ModeAcq         { Freguency = 1 , Differance = 2 , Mixed = 3}

        public enum MessageType     { Error = 1, Warrning = 2, Message = 3 };
        //Okreslenie zdrodla pochodzenia eventu ktory generuje nam wiadomosc do systemu. Jest to wymagane do szukania powiazanego z nim textu informacji - dla mxComponent generujemy dodatkowe info na temat bledu
        public enum EventCategory
        {
            APLICATION      = 0x01,
            MX_COMPONENTS   = 0x02,
            PLC             = 0x03,
            MESSAGE         = 0x04
        }
        public enum EventType
        {
            NONE                        = 0x00,
            PLC_PTR_NULL                = 0x01,         //Brak wskaznika na obiekt protokolu PLC
            CALL_INCORRECT_OPERATION    = 0x02,         //Wywolanie zabronienioej operacji na danym obiekcie
            BAD_FLOW_ID                 = 0x03,         //proba wykonia zapisu do plc info o przeplywkach o id roznym niz 0-2 (innych nie ma w plc)
            BAD_CYCLE_TIME              = 0x04,          //Podana wartosc cyklu szybkiego zaworu jest mniejsz niz czas wlaczenia
            BAD_ON_TIME                 = 0x05,          //Podana wartosc czasu wlaczenia zaworu szybkieg jest wieksza niz czas cyklu
            NO_PRG_IN_PLC               = 0x06,          //Brak programu w PLC   
            PLC_ERROR                   = 0x07,         //Sygnalizacja wystapienia bledu w programie PLC     
            SET_MAX_FLOW                = 0x08,
            SET_RANGE_VOLTAGE_MFC       = 0x09,
            SET_TIME_FLOW_STABILITY     = 0x0A,
            SET_FLOW                    = 0x0B,
            UPDATE_SETINGS              = 0x0C,
            WRITE_PROGRAM               = 0x0D,
            START_PROGRAM               = 0x0E,
            STOP_PROGRAM                = 0x0F,
            SET_PRESSURE_SETPOINT       = 0x10,
            SET_SETPOINT_HV             = 0x11,
            SET_MODE                    = 0x12,
            SET_OPERATE_HV              = 0x13,
            SET_LIMIT_POWER_HV          = 0x14,
            SET_LIMIT_CURRENT_HV        = 0x15,
            SET_LIMIT_VOLTAGE_HV        = 0x16,
            SET_MAX_VOLTAGE_HV          = 0x17,
            SET_MAX_POWER_HV            = 0x18,
            SET_MAX_CURENT_HV           = 0x19,
            SET_WAIT_TIME_OPERATE_HV    = 0x1A,
            SET_WAIT_TIME_SETPOINT_HV   = 0x1B,
            CONTROL_PUMP                = 0x1C,
            SET_WIAT_TIME_PF            = 0x1D,
            SET_TIME_PUMP_TO_SV         = 0x1E,
            SET_CYCLE_TIME              = 0x1F,
            SET_ON_TIME                 = 0x20,
            SET_STATE_VALVE             = 0x21,
            SET_MODE_PRESSURE           = 0x22,
            NO_SELECT_PROGRAM_TO_RUN    = 0x23,
            SET_MODE_CONTROL            = 0x24,
            MX_COMPONENTS_NO_INSTALL    = 0x25
        }

        /// <summary>
        /// ADRESY KOMOREK PLC
        /// </summary>
        public static string ADDR_REQ_COUNT_SEGMENT         = "M0";
        public static string ADDR_FINISH_COUNT_SEGMENT      = "M1";

        //Adresy komorek do sterowania recznego
        public static string ADDR_VALVES_CTRL               = "D200";
        public static string ADDR_FP_CTRL                   = "D202";
        public static string ADDR_CYCLE_TIME                = "D203";
        public static string ADDR_ON_TIME                   = "D205";
        public static string ADDR_FLOW_1_CTR                = "D207";
        public static string ADDR_FLOW_2_CTR                = "D209";
        public static string ADDR_FLOW_3_CTR                = "D211";
        public static string ADDR_POWER_SUPPLAY_SETPOINT    = "D213";
        public static string ADDR_POWER_SUPPLAY_MODE        = "D215";
        public static string ADDR_POWER_SUPPLAY_OPERATE     = "D216";
        public static string ADDR_PRESSURE_SETPOINT         = "D217";
        public static string ADDR_PRESSURE_MODE             = "D219";
        public static string ADDR_MODE_CONTROL              = "D220";  //Tryb sterowania komora albo manulany albo automatyczny

        public static string ADDR_START_STATUS_CHAMBER      = "D1000"; //poczatek bufora z danymi przedstawiajacymi stan systemu 
        public static string ADDR_CONTROL_PROGRAM           = "D1040";
        public static int    ADDR_START_CRT_PROGRAM         = 1050;   //Adres parametrow aktualnie wykonywanego programu i wykorzystuje go do dostrajania parametrow programu. Jest to adres poczatku buforu danych gdzie sa przechowywane parametry aktualnie wykonywanego programu
                                                                       //Pamietaj ze ten adres jest odzwierciedleniem PLC. Kolejne parametry urządzen posiadaja adresy zgodnie z ofsetem danego parametru w programie
        
        public static string ADDR_START_SETTINGS            = "D1200";
        public static string ADDR_BUFER_ERROR               = "D1230";
        public static string ADDR_PRG_ID                    = "D2000";
        public static string ADDR_PRG_SEQ_COUNTS            = "D2001";
        public static string ADDR_START_BUFFER_PROGRAM      = "D2002";

        public static string ADDR_FLAG_WAS_READ             = "M300";
        public static string ADDR_FLAGE_SERVICE_MODE        = "M301";

        public const int    LENGHT_STATUS_DATA              = 110;//50;
        public const int    LENGHT_SETTINGS_DATA            = 40;
        public const int    SEGMENT_SIZE                    = 50;   //Rozmiar parametrow subprogramu
        public const int    MAX_SEGMENTS                    = 100;  //Max liczba segmentow z ktorych moze sie skladac program po stronie PLC
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
        public static int OFFSET_ACTUAL_FLOW_1  = 15;
        public static int OFFSET_ACTUAL_FLOW_2  = 17;
        public static int OFFSET_ACTUAL_FLOW_3  = 19;
        public static int OFFSET_CYCLE_TIME     = 21;
        public static int OFFSET_ON_TIME        = 23;
        public static int OFFSET_MODE_PRESSURE  = 25;
        public static int OFFSET_OCCURED_ERROR  = 26;
        public static int OFFSET_MODE           = 27;
        public static int OFFSET_SETPOINT_HV    = 28;
        public static int OFFSET_SETPOINT_GAS   = 30;
        public static int OFFSET_SETPOINT_MFC1  = 32;
        public static int OFFSET_SETPOINT_MFC2  = 33;
        public static int OFFSET_SETPOINT_MFC3  = 34;
        public static int OFFSET_INTERLOCKS     = 35;



        //Dane odczytywane na zdarzenie
        public static int OFFSET_HV_LIMIT_POWER     = 0;
        public static int OFFSET_HV_LIMIT_CURENT    = 2;
        public static int OFFSET_HV_LIMIT_VOLTAGE   = 4;
        public static int OFFSET_HV_MAX_POWER       = 6;
        public static int OFFSET_HV_MAX_CURENT      = 8;
        public static int OFFSET_HV_MAX_VOLTAGE     = 10;
        public static int OFFSET_HV_WAIT_OPERATE    = 12;
        public static int OFFSET_HV_WAIT_SETPOINT   = 13;
        public static int OFFSET_RANGE_FLOW_MFC1    = 14;
        public static int OFFSET_RANGE_FLOW_MFC2    = 15;
        public static int OFFSET_RANGE_FLOW_MFC3    = 16;
        public static int OFFSET_RANGE_VOLTAGE_MFC1 = 17;
        public static int OFFSET_RANGE_VOLTAGE_MFC2 = 18;
        public static int OFFSET_RANGE_VOLTAGE_MFC3 = 19;
        public static int OFFSET_TIME_FLOW_STABILITY = 20;
        public static int OFFSET_TIME_PUMP_TO_SV    = 21;
        public static int OFFSET_TIME_WAIT_PF       = 22;

        //Dane aktualnie wykonywanego programu i subprogramu odczytywane ciagle
        public static int SIZE_PRG_DATA             = 70;//110;
        public static int OFFSET_PRG_DATA           = 40;   //Okreslenie poczatku gdzie sie znajduje dane na temat aktualnie wykonywanego progrmau w odczytanym buforze
        public static int OFFSET_STATUS_DATA        = 60;

        public const int  COUNT_ERROR_PLC           = 25;
        public const  int SIZE_ERROR_BUFFER_PLC     = COUNT_ERROR_PLC * 6 + 2;  //Rozmiar bufora jest mnozony razy 6 poniewaz jeden wpis bledu zajmuje 4 WORDY a 2 wziela sie z odczytu za jednym razem info p StartIndex i CountError

        public static int OFFSET_PRG_CONTROL        = 0;
        public static int OFFSET_PRG_STATUS         = 1;
       
        public static int OFFSET_PRG_ACTUAL_PRG_ID  = 3;
        public static int OFFSET_PRG_ACTUAL_SEQ_ID  = 4;
        public static int OFFSET_PRG_TIME_PUMP      = 5;
        public static int OFFSET_PRG_TIME_GAS       = 6;
        public static int OFFSET_PRG_TIME_HV        = 7;
        public static int OFFSET_PRG_TIME_VENT      = 8;
        public static int OFFSET_PRG_TIME_FLUSH     = 9;
        public static int OFFSET_PRG_SEQ_DATA       = 10;

        public static int OFFSET_ERR_START_INDEX    = 0;
        public static int OFFSET_ERR_COUNTS_INDEX   = 1;
        public static int OFFSET_ERR_BUFFER_INDEX   = 2;

        //Offset od bazowego adresu dla kolejnych parametrow subprogramu
        public static int OFFSET_SEQ_CMD                = 0;
        public static int OFFSET_SEQ_STATUS             = 2;
        public static int OFFSET_SEQ_PUMP_MAX_TIME      = 3;
        public static int OFFSET_SEQ_PUMP_SP            = 4;
        public static int OFFSET_SEQ_VENT_TIME          = 6;
        public static int OFFSET_SEQ_FLUSH_TIME         = 7;
        public static int OFFSET_SEQ_DELAY_TIME         = 8;
        public static int OFFSET_SEQ_CHECK_VACUUM       = 9;
        public static int OFFSET_SEQ_MOTOR_1_CMD        = 11;
        public static int OFFSET_SEQ_MOTOR1_SPEED       = 12;
        public static int OFFSET_SEQ_MOTOR_2_CMD        = 14;
        public static int OFFSET_SEQ_MOTOR2_SPEED       = 15;
        public static int OFFSET_SEQ_HV_OPERATE         = 17;
        public static int OFFSET_SEQ_HV_SETPOINT        = 18;
        public static int OFFSET_SEQ_HV_DRIFT_SETPOINT  = 20;
        public static int OFFSET_SEQ_HV_TIME            = 22;
        public static int OFFSET_SEQ_FLOW_1_FLOW        = 23;
        public static int OFFSET_SEQ_FLOW_1_MIN_FLOW    = 24;
        public static int OFFSET_SEQ_FLOW_1_MAX_FLOW    = 25;
        public static int OFFSET_SEQ_FLOW_1_SHARE       = 26;
        public static int OFFSET_SEQ_FLOW_1_DEVIATION   = 27;
        public static int OFFSET_SEQ_FLOW_2_FLOW        = 28;
        public static int OFFSET_SEQ_FLOW_2_MIN_FLOW    = 29;
        public static int OFFSET_SEQ_FLOW_2_MAX_FLOW    = 30;
        public static int OFFSET_SEQ_FLOW_2_SHARE       = 31;
        public static int OFFSET_SEQ_FLOW_2_DEVIATION   = 32;
        public static int OFFSET_SEQ_FLOW_3_FLOW        = 33;
        public static int OFFSET_SEQ_FLOW_3_MIN_FLOW    = 34;
        public static int OFFSET_SEQ_FLOW_3_MAX_FLOW    = 35;
        public static int OFFSET_SEQ_FLOW_3_SHARE       = 36;
        public static int OFFSET_SEQ_FLOW_3_DEVIATION   = 37;
        public static int OFFSET_SEQ_FLOW_4_ON_TIME     = 38;
        public static int OFFSET_SEQ_FLOW_4_CYCLE_TIME  = 40;
        public static int OFFSET_SEQ_GAS_MODE           = 42;
        public static int OFFSET_SEQ_GAS_TIME           = 43;
        public static int OFFSET_SEQ_GAS_SETPOINT       = 44;
        public static int OFFSET_SEQ_GAS_UP_DIFFER      = 46;
        public static int OFFSET_SEQ_GAS_DOWN_DIFFER    = 48;


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
        //--------------------------------------------------------------------------------------------
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
        //--------------------------------------------------------------------------------------------
        //Funkcaj ma za zadanie przekonwertowanie float na dwa wordy i zwrocenie mlodszego badz starszego
        public static int ConvertDOUBLEToWORD(double aValue,Word whichWord )
        {
            int aWord = 0;
            byte[] aBytes = new byte[4];
            aBytes = BitConverter.GetBytes((float)aValue);         // przkonwertuj float na tablice bajtow

            if (whichWord == Word.HIGH)
                aWord = (int)(aBytes[3] << 8 | aBytes[2]);
            else
                aWord = (int)(aBytes[1] << 8 | aBytes[0]);

            return aWord;
        }
        //--------------------------------------------------------------------------------------------
        public static DateTime ConvertDate(int aSeconds)
        {
            DateTime aDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            
            int aHour   = aSeconds / (3600);
            int aMinute = (aSeconds - aHour * 3600) / 60;
            int aSecond = aSeconds - aHour * 3600 - aMinute * 60;

            try
            {
                aDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,aHour,aMinute,aSecond);
            }
            catch(Exception ex)
            {
                Logger.AddException(ex);
            }

            return aDateTime;
        }
        //--------------------------------------------------------------------------------------------
        public static string GetAddress(AddressSpace aTypeSpace , int aOffsetAddr)
        {
            string  aAddrRes = "D0";
            int     aSpaceAddr = 0;

            switch(aTypeSpace)
            {
                case AddressSpace.Settings:
                    Int32.TryParse(ADDR_START_SETTINGS.Remove(0,1),out aSpaceAddr);
                    aAddrRes = "D" + (aSpaceAddr + aOffsetAddr).ToString();
                    break;

                case AddressSpace.Program:
                    Int32.TryParse(ADDR_START_BUFFER_PROGRAM.Remove(0, 1), out aSpaceAddr);
                    aAddrRes = "D" + (aSpaceAddr + aOffsetAddr).ToString();
                    break;
            }
            return aAddrRes;
        }
        //--------------------------------------------------------------------------------------------
    }
}
