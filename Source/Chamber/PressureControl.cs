﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Chamber
{
    public class PressureControl : ChamberObject
    {
        double actualPressure = 0;
        Value  pressureValue = new Value();

        Types.GasProcesMode mode = Types.GasProcesMode.FlowSP;

        private double setpoint = 0;

        //-----------------------------------------------------------------------------------------
        public PressureControl()
        {
            //Uzupelnij liste parametrow ktore powinny byc zapisywane w bazi danych
            AddParameter("Pressure", pressureValue,"mBar");
     
            //Ustaw nazwe urzadzenia - pamietaj ze musi ona byc unikalna dla calego systemu
            name = "PressureControl";

            acqData = true; //Ustawiam flage ze urzadzenie jest przenzaczone do arachiwzowania danych w nbazie danych
        }
        //-----------------------------------------------------------------------------------------
        //Ustwa aktualny przeplyw dla wszystkich przeplywek
        override public void UpdateData(int[] aData)
        {
            if (aData.Length > Types.OFFSET_PRESSURE && aData.Length > Types.OFFSET_MODE_PRESSURE)
            {
                //z PLC dostaje DWORD ktorego nalezy przekonwertowac na double
                actualPressure = Types.ConvertDWORDToDouble(aData, Types.OFFSET_PRESSURE);
                setpoint       = Types.ConvertDWORDToDouble(aData, Types.OFFSET_SETPOINT_GAS);

                if (Enum.IsDefined(typeof(Types.GasProcesMode), aData[Types.OFFSET_MODE_PRESSURE]))
                    mode = (Types.GasProcesMode)Enum.Parse(typeof(Types.GasProcesMode), (aData[Types.OFFSET_MODE_PRESSURE]).ToString()); // konwertuj int na Enum
                else
                    mode = Types.GasProcesMode.Unknown;
                //Aktualizuj dane zapisywane do bazy danych
                pressureValue.Value_ = actualPressure;
            }
            base.UpdateData(aData);
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja umozliwia ustawianie setpointa prozni dla regulatora PID
        public ItemLogger SetSetpoint(double aSetpoint)
        {
            ItemLogger aErr = new ItemLogger();

            if (plc != null)
            {
                int aCode = 0;
                if (controlMode == Types.ControlMode.Manual)
                    aCode = plc.WriteRealData(Types.ADDR_PRESSURE_SETPOINT, (float)aSetpoint);
                if (controlMode == Types.ControlMode.Automatic)
                    aCode = plc.WriteRealData("D" + (Types.OFFSET_SEQ_GAS_SETPOINT + Types.ADDR_START_CRT_PROGRAM).ToString(), (float)aSetpoint);
                aErr.SetErrorMXComponents(Types.EventType.SET_PRESSURE_SETPOINT, aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.PLC_PTR_NULL);

            return aErr;
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja umozliwia ustawianie setpointa prozni dla regulatora PID
        public ItemLogger SetMode(Types.GasProcesMode aMode)
        {
            ItemLogger aErr  = new ItemLogger();
            int[] aData = new int[1];

            aData[0] = (int)aMode;
            if (plc != null)
            {
                int aCode = 0;
                if (controlMode == Types.ControlMode.Manual)
                    aCode = plc.WriteWords(Types.ADDR_PRESSURE_MODE,1,aData);
                if (controlMode == Types.ControlMode.Automatic)
                    aCode = plc.WriteWords("D" + (Types.OFFSET_SEQ_GAS_MODE + Types.ADDR_START_CRT_PROGRAM).ToString(), 1,aData);
                aErr.SetErrorMXComponents(Types.EventType.SET_MODE_PRESSURE, aCode);
            }
            else
                aErr.SetErrorApp(Types.EventType.BAD_FLOW_ID);

            return aErr;
        }
        //----------------------------------------------------------------------------------------
        public double GetPressure()
        {
            return actualPressure;
        }
        //----------------------------------------------------------------------------------------
        public Types.GasProcesMode GetMode()
        {
            return mode;
        }
        //----------------------------------------------------------------------------------------
        public double GetSetpoint()
        {
            return setpoint;
        }
        //----------------------------------------------------------------------------------------
    }
}
