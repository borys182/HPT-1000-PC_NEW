using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;
namespace HPT1000.Source.Chamber
{
    public class PowerSupplay : ChamberObject
    {
        //stan zasilacza
        private Types.StateHV   state       = Types.StateHV.Error;
        private Types.ModeHV    mode        = Types.ModeHV.Power;
        private double          power       = 0;
        private double          voltage     = 0;
        private double          curent      = 0;
        private double          setpoint    = 0;

        //Utworz wartosci ktore beda wykorzystywane do aktualizacji danych w bazie danych
        Value powerValue    = new Value();
        Value voltageValue  = new Value();
        Value curentValue   = new Value();

        //parametry zasilacza
        private double          limitVoltage        = 1000;
        private double          limitCurent         = 50;
        private double          limitPower          = 500;
        private double          maxVoltage          = 2000; //wartość max napiecia dla trybu Voltage jaką można ustawić na zasilaczu
        private double          maxCurent           = 100;  //wartość max prądu dla trybu Curent jaką można ustawić na zasilaczu
        private double          maxPower            = 1000; //wartość max mocy dla trybu Power jaką można ustawić na zasilaczu
        private int             timeWaitOnOperate   = 5;    //czas oczekiwania na potwierdzenie wlaczenia zasilacza
        private int             timeWaitOnSetpoint  = 30;   //czas oczekiwania na sptrawdzenie czy aktualny setpoint miesci sie w wyznaczonych widelkach programu

        //-------------------------------------------------------------------------------------------
        //Ustaw w konstruktorze liste parametrow ktore powinny byc zapisywane w bazie danyc
        public PowerSupplay()
        {
            // TO DO NA CZAS TESTOW USTAWIAM NA SZTYWNO ID TRZEBA TO ZAPISAC/ODCZYTAC Z PLIKU
            //Uzupelnij liste parametrow ktore powinny byc zapisywane w bazi danych
            AddParameter("Power", powerValue,"W").ID = 5;
            AddParameter("Voltage", voltageValue,"V").ID = 6;
            AddParameter("Curent", curentValue,"A").ID = 7;
            //Ustaw nazwe urzadzenia - pamietaj ze musi ona byc unikalna dla calego systemu
            name = "PowerSupply";

            acqData = true; //Ustawiam flage ze urzadzenie jest przenzaczone do arachiwzowania danych w nbazie danych
        }
        //-------------------------------------------------------------------------------------------
        public double LimitVoltage
        {
            get { return limitVoltage; }
        }
        //-------------------------------------------------------------------------------------------
        public double LimitCurent
        {
            get { return limitCurent; }
        }
        //-------------------------------------------------------------------------------------------
        public double LimitPower
        {
            get { return limitPower; }
        }
        //-------------------------------------------------------------------------------------------
        public double Power
        {
            get { return power; }
        }
        //-------------------------------------------------------------------------------------------
        public double Voltage
        {
            get { return voltage; }
        }
        //-------------------------------------------------------------------------------------------
        public double Curent
        {
            get { return curent; }
        }
        //-------------------------------------------------------------------------------------------
        public double Setpoint
        {
            get { return setpoint; }
        }
        //-------------------------------------------------------------------------------------------
        public Types.StateHV State
        {
            get { return state; }
        }
        //-------------------------------------------------------------------------------------------
        public Types.ModeHV Mode
        {
            get { return mode; }
        }
        //-------------------------------------------------------------------------------------------
        public double MaxPower
        {
            get { return maxPower; }
        }
        //-------------------------------------------------------------------------------------------
        public double MaxVoltage
        {
            get { return maxVoltage; }
        }
        //-------------------------------------------------------------------------------------------
        public double MaxCurent
        {
            get { return maxCurent; }
        }
        //-------------------------------------------------------------------------------------------
        public double TimeWaitSetpoint
        {
            get { return timeWaitOnSetpoint; }
        }
        //-------------------------------------------------------------------------------------------
        public double TimeWaitOperate
        {
            get { return timeWaitOnOperate; }
        }
        //-------------------------------------------------------------------------------------------
        override public void UpdateData(int []aData)
        {
            if (aData.Length > Types.OFFSET_POWER && aData.Length > Types.OFFSET_VOLTAGE && aData.Length > Types.OFFSET_CURENT && aData.Length > Types.OFFSET_MODE_HV && aData.Length > Types.OFFSET_STATUS_HV)
            {
                power       = Types.ConvertDWORDToDouble(aData, Types.OFFSET_POWER);
                voltage     = Types.ConvertDWORDToDouble(aData, Types.OFFSET_VOLTAGE);
                curent      = Types.ConvertDWORDToDouble(aData, Types.OFFSET_CURENT);
                setpoint    = Types.ConvertDWORDToDouble(aData, Types.OFFSET_SETPOINT_HV);

                if (Enum.IsDefined(typeof(Types.ModeHV), aData[Types.OFFSET_MODE_HV]))
                    mode = (Types.ModeHV)Enum.Parse(typeof(Types.ModeHV), (aData[Types.OFFSET_MODE_HV]).ToString()); // konwertuj int na Enum
                else
                    mode = Types.ModeHV.Unknown;

                if (Enum.IsDefined(typeof(Types.StateHV), aData[Types.OFFSET_STATUS_HV]))
                    state = (Types.StateHV)Enum.Parse(typeof(Types.StateHV), (aData[Types.OFFSET_STATUS_HV]).ToString()); // konwertuj int na Enum
                else
                    state = Types.StateHV.Error;

                //aktualizuj wartosci w obiektach parametrow ktore sa wykorzystywane do zapisu danych w bazie danych
                powerValue.Value_   = power;
                voltageValue.Value_ = voltage;
                curentValue.Value_  = curent;

            }
            base.UpdateData(aData);
        }
        //-------------------------------------------------------------------------------------------
        override public void UpdateSettingsData(int[] aData)
        {
            if (aData.Length > Types.OFFSET_HV_LIMIT_POWER  && aData.Length > Types.OFFSET_HV_LIMIT_VOLTAGE && aData.Length > Types.OFFSET_HV_LIMIT_CURENT &&
                aData.Length > Types.OFFSET_HV_MAX_POWER    && aData.Length > Types.OFFSET_HV_MAX_VOLTAGE   && aData.Length > Types.OFFSET_HV_MAX_CURENT &&
                aData.Length > Types.OFFSET_HV_WAIT_OPERATE && aData.Length > Types.OFFSET_HV_WAIT_SETPOINT)
            {
                limitPower          = Types.ConvertDWORDToDouble(aData, Types.OFFSET_HV_LIMIT_POWER);
                limitVoltage        = Types.ConvertDWORDToDouble(aData, Types.OFFSET_HV_LIMIT_VOLTAGE);
                limitCurent         = Types.ConvertDWORDToDouble(aData, Types.OFFSET_HV_LIMIT_CURENT);
                maxPower            = Types.ConvertDWORDToDouble(aData, Types.OFFSET_HV_MAX_POWER);
                maxVoltage          = Types.ConvertDWORDToDouble(aData, Types.OFFSET_HV_MAX_VOLTAGE);
                maxCurent           = Types.ConvertDWORDToDouble(aData, Types.OFFSET_HV_MAX_CURENT);
                timeWaitOnOperate   = aData[Types.OFFSET_HV_WAIT_OPERATE];
                timeWaitOnSetpoint  = aData[Types.OFFSET_HV_WAIT_SETPOINT];
            }
        }
        //-----------------------------------------------------------------------------------------
        public ItemLogger SetSetpoint(double aSetpoint)
        {
            ItemLogger aErr  = new ItemLogger();
            int   aCode = 0;

            if (plc != null)
            {
                if(controlMode == Types.ControlMode.Automatic)
                    aCode = plc.WriteRealData("D" + (Types.ADDR_START_CRT_PROGRAM + Types.OFFSET_SEQ_HV_SETPOINT).ToString(), (float)aSetpoint);

                if(controlMode == Types.ControlMode.Manual)
                    aCode = plc.WriteRealData(Types.ADDR_POWER_SUPPLAY_SETPOINT, (float)aSetpoint);

                aErr.SetErrorMXComponents(Types.EventType.SET_SETPOINT_HV ,aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            return aErr;
        }       
        //-----------------------------------------------------------------------------------------
        //Mozliwosc ustawienia tylko w trybie recznym
        public ItemLogger SetMode(Types.ModeHV aMode)
        {
            ItemLogger aErr = new ItemLogger();
            int []aData = new int[1] ;

            aData[0] =  (int)aMode;

            if (plc != null)
            {
                int aCode = 0;

                if (controlMode == Types.ControlMode.Automatic)
                    aCode = plc.WriteWords("D" + (Types.ADDR_START_CRT_PROGRAM + Types.OFFSET_SEQ_HV_OPERATE).ToString(), 1, aData);

                if (controlMode == Types.ControlMode.Manual)
                    aCode = plc.WriteWords(Types.ADDR_POWER_SUPPLAY_MODE, 1, aData);

                aErr.SetErrorMXComponents(Types.EventType.SET_MODE, aCode);                
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            return aErr;
        }
        //-----------------------------------------------------------------------------------------
        //Mozliwosc ustawienia tylko w trybie recznym
        public ItemLogger SetOperate(bool aOperate)
        {
            ItemLogger aErr = new ItemLogger();

            int[] aData = new int[1];

            aData[0] = Convert.ToInt32(aOperate);
            if (plc != null)
            {
                int aCode = 0;
                if (controlMode == Types.ControlMode.Manual)
                {
                    aCode = plc.WriteWords(Types.ADDR_POWER_SUPPLAY_OPERATE, 1, aData);
                    aErr.SetErrorMXComponents(Types.EventType.SET_OPERATE_HV, aCode);
                }
                else
                    aErr.SetErrorApp(Types.EventType.SET_OPERATE_HV);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            return aErr;
        }
        //-------------------------------------------------------------------------------------------  
        public ItemLogger SetLimitPower(double aValue)
        {
            ItemLogger aErr = new ItemLogger();

            if (plc != null)
            {
                int aCode = plc.WriteRealData(Types.GetAddress(Types.AddressSpace.Settings, Types.OFFSET_HV_LIMIT_POWER), (float)aValue);
                aErr.SetErrorMXComponents(Types.EventType.SET_LIMIT_POWER_HV,aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            if (!aErr.IsError())
                limitPower = aValue;

            return aErr;
        }
        //-------------------------------------------------------------------------------------------  
        public ItemLogger SetLimitCurent(double aValue)
        {
            ItemLogger aErr = new ItemLogger();

            if (plc != null)
            {
                int aCode = plc.WriteRealData(Types.GetAddress(Types.AddressSpace.Settings, Types.OFFSET_HV_LIMIT_CURENT), (float)aValue);
                aErr.SetErrorMXComponents(Types.EventType.SET_LIMIT_CURRENT_HV, aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            if (!aErr.IsError())
                limitCurent = aValue;

            return aErr;
        }
        //-------------------------------------------------------------------------------------------  
        public ItemLogger SetLimitVoltage(double aValue)
        {
            ItemLogger aErr = new ItemLogger();

            if (plc != null)
            {
                int aCode = plc.WriteRealData(Types.GetAddress(Types.AddressSpace.Settings, Types.OFFSET_HV_LIMIT_VOLTAGE), (float)aValue);
                aErr.SetErrorMXComponents(Types.EventType.SET_LIMIT_VOLTAGE_HV, aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            if (!aErr.IsError())
                limitVoltage = aValue;

            return aErr;
        }
        //-------------------------------------------------------------------------------------------  
        //Ustaw max wartosc napiecia jaka jest jest mozliwa do ustawiania z zasilacza
        public ItemLogger SetMaxVoltage(double aValue)
        {
            ItemLogger aErr = new ItemLogger();

            if (plc != null)
            {
                int aCode = plc.WriteRealData(Types.GetAddress(Types.AddressSpace.Settings, Types.OFFSET_HV_MAX_VOLTAGE), (float)aValue);
                aErr.SetErrorMXComponents(Types.EventType.SET_MAX_VOLTAGE_HV, aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            if (!aErr.IsError())
                maxVoltage = aValue;

            return aErr;
        }
        //-------------------------------------------------------------------------------------------  
        //Ustaw max wartosc mocy jaka jest jest mozliwa do ustawiania z zasilacza
        public ItemLogger SetMaxPower(double aValue)
        {
            ItemLogger aErr = new ItemLogger();

            if (plc != null)
            {
                int aCode = plc.WriteRealData(Types.GetAddress(Types.AddressSpace.Settings, Types.OFFSET_HV_MAX_POWER), (float)aValue);
                aErr.SetErrorMXComponents(Types.EventType.SET_MAX_POWER_HV, aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            if (!aErr.IsError())
                maxPower = aValue;

            return aErr;
        }
        //-------------------------------------------------------------------------------------------  
        //Ustaw max wartosc pradu jaka jest jest mozliwa do ustawiania z zasilacza
        public ItemLogger SetMaxCurent(double aValue)
        {
            ItemLogger aErr = new ItemLogger();

            if (plc != null)
            {
                int aCode = plc.WriteRealData(Types.GetAddress(Types.AddressSpace.Settings, Types.OFFSET_HV_MAX_CURENT), (float)aValue);
                aErr.SetErrorMXComponents(Types.EventType.SET_MAX_CURENT_HV, aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            if (!aErr.IsError())
                maxCurent = aValue;

            return aErr;
        }
        //------------------------------------------------------------------------------------------- 
        //Ustaw czas oczekiwania na sprawdzenie poprawnisci wlaczenia zasilacza
        public ItemLogger SetWaitTimeOperate(int aValue)
        {
            ItemLogger aErr = new ItemLogger();
            int[] aData = new int[1];

            aData[0] = aValue;
            if (plc != null)
            {
                int aCode = plc.WriteWords(Types.GetAddress(Types.AddressSpace.Settings, Types.OFFSET_HV_WAIT_OPERATE), 1, aData);
                aErr.SetErrorMXComponents(Types.EventType.SET_WAIT_TIME_OPERATE_HV, aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            if (!aErr.IsError())
                timeWaitOnOperate = aValue;

            return aErr;
        }
        //------------------------------------------------------------------------------------------- 
        //Ustaw czas oczekiwania na stabilizacje sie wartosc setpoint poiedzy zadanymi widelkami programu
        public ItemLogger SetWaitTimeSetpoint(int aValue)
        {
            ItemLogger aErr = new ItemLogger();
            int[] aData = new int[1];

            aData[0] = aValue;
            if (plc != null)
            {
                int aCode = plc.WriteWords(Types.GetAddress(Types.AddressSpace.Settings, Types.OFFSET_HV_WAIT_SETPOINT), 1, aData);
                aErr.SetErrorMXComponents(Types.EventType.SET_WAIT_TIME_SETPOINT_HV,aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            if (!aErr.IsError())
                timeWaitOnSetpoint = aValue;

            return aErr;
        }
        //------------------------------------------------------------------------------------------- 


    }
}
