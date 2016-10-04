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

        private PLC                     plc                 = new PLC_Mitsubishi();
        private Chamber.Chamber         chamber             = new Chamber.Chamber();
        private List<Program.Program>   programs            = new List<Program.Program>(); //Lista wszystkich programow zapisanych w aplikacji

        private Types.DriverStatus      status              = Types.DriverStatus.Unknown;

        private ThreadStart             funThr;
        private Thread                  threadReadData;

        private bool                    flagUpdateSettings  = false;
        private int[]                   dataSettingsPLC     = new int[Types.LENGHT_SETTINGS_DATA];

        bool                            connectionPLC       = false;

        private static RefreshProgram   refreshProgram      = null;

        //-----------------------------------------------------------------------------------------
        public HPT1000()
        {
            chamber.SetPtrPLC(plc);
            foreach (Program.Program pr in programs)
                pr.SetPtrPLC(plc);

            funThr = new ThreadStart(Run);
            threadReadData = new Thread(funThr);

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

                //aktualizuju dane komponentow komory
                chamber.UpdateData(aData);

                //aktualizuj dane na temat aktualnie wykonywanego subprogramu. Poniewaz dane programow sa odczytywane razem z danymi komponenotw musze je przesunac o dany offset
                int[] aDataProgram = new int[Types.SIZE_PRG_DATA];
                CopyData(aData, aDataProgram);
                foreach (Program.Program pr in programs)
                    pr.UpdateActualSubprogramData(aDataProgram);
           
                //Wykonaj operacje po nawiazaniu polaczenia z PLC
                if (!connectionPLC && aRes == 0)
                    FirstRun();

                //Sprawdz czy jest komunikacja
                CheckConnection(aRes);

                //Tymczasowe odczytywabie setingsow w watku synchronicznie
                if (flagUpdateSettings)
                {
                    plc.ReadWords(Types.ADDR_START_SETTINGS, Types.LENGHT_SETTINGS_DATA, dataSettingsPLC);
                    flagUpdateSettings = false;
                }
                //Odczytuj dane co 0.5 s
                Thread.Sleep(500);
            }
        }
        //-----------------------------------------------------------------------------------------
        private void FirstRun()
        {
            //Odczytaj z automatu settingsy z PLC po nawiazaniu polaczenia
            plc.ReadWords(Types.ADDR_START_SETTINGS, Types.LENGHT_SETTINGS_DATA, dataSettingsPLC);
            UpdateSettings();
            //Odczytaj z PLC parametry programu aktualnie wgranego
            ReadProgramFromPLC();
        }
        //-----------------------------------------------------------------------------------------
        // Wyodrebnij z bufora danych dane programu
        void CopyData(int[] aData,int[] aDataProgram)
        {
            for (int i = 0; i < aDataProgram.Length; i++)
            {
                if (aData.Length > i)
                    aDataProgram[i] = aData[i + Types.OFFSET_PRG_DATA];
            }
        }
        //-----------------------------------------------------------------------------------------
        void CheckConnection(int aRes)
        {
            if (aRes == 0)
            {
                connectionPLC = true;
                status = Types.DriverStatus.OK;
            }
            else
            {
                connectionPLC = false;
                status = Types.DriverStatus.NoComm;
            }
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja ma za zadanie pobranie parametrow programu z PLC i utworzonie/aktualizacja paramtrow instancji po stronie PC
        public void ReadProgramFromPLC()
        {
            Program.Program programPLC = null;
            //Sprawdz czy w PLC istnieje jakis program oraz czy ma jakies subprogramy
            int[] aData = new int[1];
            int aProgramIdInPLC       = 0;
            int aCountSubprogramInPLC = 0;

            if (plc != null)
                plc.ReadWords(Types.ADDR_PRG_ID, 2, aData);
            aProgramIdInPLC = aData[0];

            if (plc != null)
                plc.ReadWords(Types.ADDR_PRG_SEQ_COUNTS, 1, aData);
            aCountSubprogramInPLC = aData[0];

            //Sprawdz czy istnieje juz instanacja programu z parametrami z PLC
            if (aProgramIdInPLC > 0 && aCountSubprogramInPLC > 0)
            {
                foreach (Program.Program program in programs)
                {
                    //Status jest inny niz Niezaladowany do PLC to znaczy ze juz zostal zaladowany
                    if (program.GetID() == aProgramIdInPLC)
                        programPLC = program;
                }
                if (programPLC == null)
                {
                    programPLC = new Program.Program();
                    programPLC.SetPtrPLC(plc);
                    AddProgram(programPLC);
                }
                programPLC.SetName("Program in PLC");
                programPLC.ReadProgramsData();
            }
            else
            {
                ERROR aErr = new ERROR(Types.ERROR_CODE.NO_PRG_IN_PLC,0);
                Logger.AddError(aErr);
            }
        }
        //-----------------------------------------------------------------------------------------
        public void UpdateSettings()
        {
            ERROR aErr = new ERROR(0,0);
            int[] aData = new int[Types.LENGHT_SETTINGS_DATA];
            flagUpdateSettings = true;
            //   aErr.ErrorCodePLC = plc.ReadWords(Types.ADDR_START_SETTINGS, Types.LENGHT_SETTINGS_DATA, aData);
       
            //aktualizuj dane na temat settingsow
            if (aErr.ErrorCodePLC == 0)
                chamber.UpdateSettings(dataSettingsPLC);

            Logger.AddError(aErr);
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public static void AddToRefreshList(RefreshProgram aRefresh)
        {
            refreshProgram += aRefresh;
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
        public void NewProgram()
        {
            Program.Program program = new Program.Program();
            program.SetPtrPLC(plc);
            AddProgram(program);
        }
        //-----------------------------------------------------------------------------------------
        private void AddProgram(Program.Program program)
        {
            programs.Add(program);
            //Poinformuj moich obserwatorow aby odswiezyly sobie informacje na temat programow
            if (refreshProgram != null)
                refreshProgram();
        }
        //-----------------------------------------------------------------------------------------
        public bool RemoveProgram(Program.Program program)
        {
            bool aRes = false;

            aRes = programs.Remove(program);

            //Poinformuj moich obserwatorow aby odswiezyly sobie informacje na temat programow
            if (refreshProgram != null)
                refreshProgram();

            return aRes;
        }
        //-----------------------------------------------------------------------------------------
        private uint GetUniqueProgramID()
        {
            uint aId = 0;
            bool aExist = true;

            while (aExist)
            {
                aId++;
                aExist = false;
                foreach (Program.Program program in programs)
                {
                    if (program.GetID() == aId)
                        aExist = true;
                }
            }
            return aId;
        }
        //-------------------------------------------------------------------------------------------------------------------------


    }
}
