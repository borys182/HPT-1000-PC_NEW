using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HPT1000.Source.Chamber;
using HPT1000.Source.Program;

namespace HPT1000.Source.Driver
{
    /// <summary>
    /// Klasa driver opisujaca zachowanie sie komory oraz mozliwe funkcje przez nia wykonywane
    /// </summary>
    public class HPT1000
    {

        #region Private
            private PLC             plc             = new PLC_Mitsubishi();
            private Chamber.Chamber chamber         = new Chamber.Chamber();
            private List<Program.Program> programs  = new List<Program.Program>(); //Lista wszystkich programow zapisanych w aplikacji
                
        private Types.DriverStatus    status        = Types.DriverStatus.Unknown;

        private ThreadStart    funThr;
        private Thread         threadReadData;

        #endregion

        #region Method
        //-----------------------------------------------------------------------------------------
        public HPT1000()
        {
            chamber.SetPtrPLC(plc);
            foreach(Program.Program pr in programs)
                pr.SetPtrPLC(plc);

            funThr          = new ThreadStart(Run);
            threadReadData  = new Thread(funThr);

            threadReadData.Start();
        }
        //-----------------------------------------------------------------------------------------
        //Funkcaj watku drivera
        private void Run()
        {
            int aRes = 0;
            int[] aData = new int[Types.LENGHT_STATUS_DATA];

            while (true)
            {         
                aRes = plc.ReadWords(Types.ADDR_START_STATUS_CHAMBER, Types.LENGHT_STATUS_DATA, aData);

/*                if (Enum.IsDefined(typeof(Types.DriverStatus), aData[Types.OFFSET_DEVICE_STATUS]))
                    status = (Types.DriverStatus)Enum.Parse(typeof(Types.DriverStatus), (aData[Types.OFFSET_DEVICE_STATUS]).ToString()); // konwertuj int na Enum
                else
                    status = Types.DriverStatus.Unknown;
 */               
                //aktualizuju dane komponentow komory
                chamber.UpdateData(aData);
                //aktualizuj dane na temat progrmu
                foreach (Program.Program pr in programs)
                    pr.UpdateData(aData);
                //Sprawdz czy jest komunikacja
                if (aRes == 0)  status = Types.DriverStatus.OK;
                else            status = Types.DriverStatus.NoComm;

                //Odczytuj dane co 0.5 s
                Thread.Sleep(500);
            }
        }
        //-----------------------------------------------------------------------------------------
        public Valve GetValve()
        {
            return (Valve)chamber.GetObject(Types.TypeObject.VL);
        }
        //-----------------------------------------------------------------------------------------
        public PowerSupplay GetPowerSupply()
        {
            return (PowerSupplay)chamber.GetObject(Types.TypeObject.HV);
        }
        //-----------------------------------------------------------------------------------------
        public MFC GetMFC()
        {
            return (MFC)chamber.GetObject(Types.TypeObject.FM);
        }
        //-----------------------------------------------------------------------------------------
        public ForePump GetForePump()
        {
            return (ForePump)chamber.GetObject(Types.TypeObject.FP);
        }
        //-----------------------------------------------------------------------------------------
        public Vaporizer GetVaporizer()
        {
            return (Vaporizer)chamber.GetObject(Types.TypeObject.VP);
        }
        //-----------------------------------------------------------------------------------------
        public PressureControl GetPressureControl()
        {
            return (PressureControl)chamber.GetObject(Types.TypeObject.PC);
        }
        //-----------------------------------------------------------------------------------------
        public PLC GetPLC()
        {
            return plc;
        }
        //-----------------------------------------------------------------------------------------
        public Types.DriverStatus GetStatus()
        {
            return status;
        }
        //-----------------------------------------------------------------------------------------
        public List<Program.Program> GetPrograms()
        {
            return programs;
        }
        //-----------------------------------------------------------------------------------------
        public void AddProgram()
        {
            Program.Program program = new Program.Program();
            //  program.id = GetUniqueProgramID();
            program.SetPtrPLC(plc);
            programs.Add(program);  
        }
        //-----------------------------------------------------------------------------------------
        public bool RemoveProgram(Program.Program program)
        {
            bool aRes = false;

            aRes = programs.Remove(program);

            return aRes;
        }
        //-----------------------------------------------------------------------------------------


        #endregion

    }
}
