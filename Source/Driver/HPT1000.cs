﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Chamber;
using HPT1000.Source.Program;

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
            private Program.Program program         = new Program.Program();

            private Types.StatusDevice    statusDevice  = Types.StatusDevice.Fail;
     
        #endregion

        #region Method
        public HPT1000()
        {
            chamber.SetPtrPLC(plc);
            program.SetPtrPLC(plc);
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
        
            chamber.UpdateData(aData); //aktualizuju dane komponentow komory
            program.UpdateData(aData);//aktualizuj dane na temat progrmu
        }

        public Valve GetValve()
        {
            return (Valve)chamber.GetObject(Types.TypeObject.VL);
        }
        public PowerSupplay GetPowerSupply()
        {
            return (PowerSupplay)chamber.GetObject(Types.TypeObject.HV);
        }
        public FlowMeter GetFlowMeter()
        {
            return (FlowMeter)chamber.GetObject(Types.TypeObject.FM);
        }
        public ForePump GetForePump()
        {
            return (ForePump)chamber.GetObject(Types.TypeObject.FP);
        }






        #endregion

    }
}
