using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPT1000.Source.Driver;
using HPT1000.Source.Program;

namespace HPT1000.GUI
{
    public partial class ProgramPanel : UserControl
    {
        private Source.Driver.HPT1000   hpt1000 = null;

        private bool                    flagRefreshProgram  = false;
        Program                         programActualRun    = null;

        //---------------------------------------------------------------------------------------
        public HPT1000.Source.Driver.HPT1000 HPT1000
        {
            set { hpt1000 = value; }
            get { return hpt1000; }
        }
        //---------------------------------------------------------------------------------------
        public ProgramPanel()
        {
            InitializeComponent();
            ClearPanel();
        }
        //---------------------------------------------------------------------------------------
        private void ClearPanel()
        {
            cBoxPrograms.Items.Clear();
            listViewSubprograms.Items.Clear();
            //txtBoxDesc.Text = "";

            labPumpSetpoint.Text        = "";
            labPumpTime.Text            = "--:--:--";
            labPumpTimeTarget.Text      = "--:--:--";

            labPurgeTime.Text           = "--:--:--";
            labPurgeTimeTarget.Text     = "--:--:--";

            labVentTime.Text            = "--:--:--";
            labVentTimeTarget.Text      = "--:--:--";

            labPlasmaSetpoint.Text      = "";
            labPlasmaTime.Text          = "--:--:--";
            labPlasmaTimeTarget.Text    = "--:--:--";

            labGasMFC1.Text             = "";
            labGasMFC2.Text             = "";
            labGasMFC3.Text             = "";
        //    labGasMode.Text             = "";
            labGasSetpointPressure.Text = "";
            labGasTime.Text             = "--:--:--";
            labGasTimeTarget.Text       = "--:--:--";
            labGasVaporiser.Text        = "";

            panelGas.Enabled            = false;
            panelPump.Enabled           = false;
            panelPurge.Enabled          = false;
            panelVent.Enabled           = false;
            panelPlasma.Enabled         = false;

        }
        //---------------------------------------------------------------------------------------
        //WYnus odswiezenie listy programow w controlce comboBox
        public void RefreshProgram()
        {
            flagRefreshProgram = true;
        }
        //---------------------------------------------------------------------------------------
        //Odsiwiez dane na temat programow
        private void UpdateListPrograms()
        {
            if (hpt1000 != null)
            {
                cBoxPrograms.Items.Clear();
                foreach (Program pr in hpt1000.GetPrograms())
                    cBoxPrograms.Items.Add(pr);         
            }
        }
        //---------------------------------------------------------------------------------------
        //Odsiwiez dane na temat aktualnie wykonywanego programu w PLC. Wyswietl dane takze po zakonczeniu programu
        public void RefreshPanel()
        {
            Subprogram  aActualSubprogram   = null;
            bool        aAnyProgramRun      = false;
            if (hpt1000 != null)
            {
                //Znajdz aktualnie wykonywany program
                foreach (Program program in hpt1000.GetPrograms())
                {
                    if (program.IsRun())
                    {
                        programActualRun = program;
                        aAnyProgramRun = true;
                    }
                }             
                if (programActualRun != null)
                {
                    //Znajdz aktualnie wykonywany subprogram wgrany do PLC z programu
                    aActualSubprogram = programActualRun.GetActualSubprogram();
                    //Wyswietl dane na temat programy=u i subprogrmau
                    ShowProgramConfig(programActualRun);
                    ShowSubprogramConfig(aActualSubprogram);
                    //Ustaw combobox na danym prgoramie
                    SetProgramInComboBox(programActualRun);
                    cBoxPrograms.Enabled        = false;
                    listViewSubprograms.Enabled = false;
                }
                else
                {
                    cBoxPrograms.Enabled        = true;
                    listViewSubprograms.Enabled = true;
                }
            }
            if(!aAnyProgramRun)
                programActualRun = null;
        }
        //--------------------------------------------------------------------------------------
        void SetProgramInComboBox(Program program)
        {
            for(int i = 0; i < cBoxPrograms.Items.Count; i++)
            {
                if (cBoxPrograms.Items[i] == program)
                    cBoxPrograms.SelectedIndex = i;
            }
        }
        //--------------------------------------------------------------------------------------
        //Pokaz dane programu
        void ShowProgramConfig(Program pr)
        {
            if (pr != null)
            {
                //Podaj mi dla ktorych subprogramow mam tworzyc liste. Czy user przeglada parametry czy wyswietlam dane z PLC aktulanie wykonywanego prgoramu
                List<Subprogram> aSubprograms = pr.GetSubprograms();
            /*    if (pr.IsRun())
                    aSubprograms = pr.GetSubprogramsPLC();
            */    labStatus.Text = "Progrma status: " + pr.Status.ToString();
                //uzupelnij liste sub programow. Jezeli jest mniej w listView to dodaj jezeli jest za duzo to usun
                if (aSubprograms != null)
                {
                    //ListView zawiera za malo wpisow to je utworz
                    int aCountNewItem = aSubprograms.Count - listViewSubprograms.Items.Count;
                    AddItem(aCountNewItem);
                    //ListView zawiera za duzo wpisow to je usun
                    int aCountRemoveItem = listViewSubprograms.Items.Count - aSubprograms.Count;
                    RemoveItem(aCountRemoveItem);
                    //Aktualizuj dane dla kolejnych itemow (subprogramow)
                    int i = 0;
                    foreach (Subprogram subPr in aSubprograms)
                    {
                        if (listViewSubprograms.Items.Count > i)
                        {
                            ListViewItem item = listViewSubprograms.Items[i];
                            if(item.Text != subPr.GetName())
                                item.Text   = subPr.GetName();
                            if(item.SubItems.Count > 1 && item.SubItems[1].Text != subPr.GetStatus().ToString())
                                item.SubItems[1].Text = subPr.GetStatus().ToString();
                            item.Tag    = subPr;
                            i++;
                        }
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------
        void AddItem(int aCount)
        {
            for (int i = 0; i < aCount; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "New item";
                item.SubItems.Add("New subitem");
                item.Tag = null;
                listViewSubprograms.Items.Add(item);
            }
        }
        //--------------------------------------------------------------------------------------
        void RemoveItem(int aCount)
        {
            for (int i = 0; i < aCount; i++)
            {
                if (listViewSubprograms.Items.Count > 0)
                    listViewSubprograms.Items.Remove(listViewSubprograms.Items[0]);
            }
        }
        //--------------------------------------------------------------------------------------
        //Pokaz dane subprogramu
        void ShowSubprogramConfig(Subprogram subProgram)
        {
            if (subProgram != null)
            {
                //podswietl aktualnie prezentowany sub program
                foreach(ListViewItem item in listViewSubprograms.Items)
                {
                    if (item.Tag == subProgram)
                        item.Selected = true;
                }
                ShowPumpProces(subProgram.GetPumpProces());
                ShowPlasmaProces(subProgram.GetPlasmaProces());
                ShowPurgeProces(subProgram.GetPurgeProces());
                ShowVentProces(subProgram.GetVentProces());
                ShowGasProces(subProgram.GetGasProces());
            }
        }
        //--------------------------------------------------------------------------------------
        //Odsiwez dane na temat procesu pompowania. Pamietaj aby odswiezac dane tylko wtedy gdy sie cos zmienilo
        void ShowPumpProces(PumpProces pumpProces)
        {
            if (pumpProces != null)
            {
                if (pumpProces.Active && !panelPump.Font.Bold)
                    panelPump.Font = new Font(panelPump.Font, FontStyle.Bold);
                if (!pumpProces.Active && panelPump.Font.Bold)
                    panelPump.Font = new Font(panelPump.Font, FontStyle.Regular);

                if (panelPump.Enabled != pumpProces.Active)
                    panelPump.Enabled = pumpProces.Active;

                labPumpTime.Text        = pumpProces.TimeWorking.ToLongTimeString();
                labPumpTimeTarget.Text  = pumpProces.GetTimeWaitForPumpDown().ToLongTimeString();
                labPumpSetpoint.Text    = "Setpoint - " + pumpProces.GetSetpoint().ToString() + " mBar";
            }
        }
        //--------------------------------------------------------------------------------------
        //Odsiwez dane na temat procesu purgowania. Pamietaj aby odswiezac dane tylko wtedy gdy sie cos zmienilo
        void ShowPurgeProces(FlushProces purgeProces)
        {
            if (purgeProces != null)
            {
                if (panelPurge.Enabled != purgeProces.Active)
                    panelPurge.Enabled = purgeProces.Active;

                if (purgeProces.Active && !panelPump.Font.Bold)
                    panelPurge.Font = new Font(panelPurge.Font, FontStyle.Bold);

                if (!purgeProces.Active && panelPump.Font.Bold)
                    panelPurge.Font = new Font(panelPurge.Font, FontStyle.Regular);

                labPurgeTime.Text       = purgeProces.TimeWorking.ToLongTimeString();
                labPurgeTimeTarget.Text = purgeProces.GetTimePurge().ToLongTimeString();
            }
        }
        //--------------------------------------------------------------------------------------
        //Odsiwez dane na temat procesu ventowania. Pamietaj aby odswiezac dane tylko wtedy gdy sie cos zmienilo
        void ShowVentProces(VentProces ventProces)
        {
            if (ventProces != null)
            {
                if(panelVent.Enabled != ventProces.Active)
                    panelVent.Enabled = ventProces.Active;

                if (ventProces.Active && !panelVent.Font.Bold)
                    panelVent.Font = new Font(panelVent.Font, FontStyle.Bold);

                if (!ventProces.Active && panelVent.Font.Bold)
                    panelVent.Font = new Font(panelVent.Font, FontStyle.Regular);

                labVentTime.Text        = ventProces.TimeWorking.ToLongTimeString();
                labVentTimeTarget.Text  = ventProces.GetTimeVent().ToLongTimeString();
            }
        }
        //--------------------------------------------------------------------------------------
        //Odsiwez dane na temat procesu plasmy. Pamietaj aby odswiezac dane tylko wtedy gdy sie cos zmienilo
        void ShowPlasmaProces(PlasmaProces plasmaProces)
        {
            if (plasmaProces != null)
            {
                if(panelPlasma.Enabled != plasmaProces.Active)
                    panelPlasma.Enabled = plasmaProces.Active;

                string aUnit = "";
                if (plasmaProces.GetWorkMode() == Types.WorkModeHV.Curent) aUnit    = " A";
                if (plasmaProces.GetWorkMode() == Types.WorkModeHV.Voltage) aUnit   = " V";
                if (plasmaProces.GetWorkMode() == Types.WorkModeHV.Power) aUnit     = " W";

                if (plasmaProces.Active && !panelPlasma.Font.Bold)
                    panelPlasma.Font = new Font(panelPlasma.Font, FontStyle.Bold);

                if (!plasmaProces.Active && panelPlasma.Font.Bold)
                    panelPlasma.Font = new Font(panelPlasma.Font, FontStyle.Regular);

                labPlasmaTime.Text = plasmaProces.TimeWorking.ToLongTimeString();
                labPlasmaTimeTarget.Text = plasmaProces.GetTimeOperate().ToLongTimeString();
                labPlasmaSetpoint.Text = "Setpoint - " + plasmaProces.GetSetpointValue().ToString() + aUnit;
            }
        }
        //--------------------------------------------------------------------------------------
        //Odsiwez dane na temat procesu dozowania gazu. Pamietaj aby odswiezac dane tylko wtedy gdy sie cos zmienilo
        void ShowGasProces(GasProces gasProces)
        {
            if (gasProces != null)
            {
                if(panelGas.Enabled != gasProces.Active)
                    panelGas.Enabled = gasProces.Active;

                if (gasProces.Active && !panelGas.Font.Bold)
                    panelGas.Font = new Font(panelGas.Font, FontStyle.Bold);

                if (!gasProces.Active && panelGas.Font.Bold)
                    panelGas.Font = new Font(panelGas.Font, FontStyle.Regular);

                labGasTime.Text         = gasProces.TimeWorking.ToLongTimeString();
                labGasTimeTarget.Text   = gasProces.GetTimeProcesDuration().ToLongTimeString();

                labGasSetpointPressure.Visible  = true;
                labGasVaporiser.Visible         = true;
                switch (gasProces.GetModeProces())
                {
                    case Types.GasProcesMode.FlowSP:
                        //labGasMode.Text = "";//"Mode: Dosing gases to chamber accordnig set flow";
                        labGasSetpointPressure.Visible = false;
                        labGasMFC1.Text = "MFC1 : " + gasProces.GetGasFlow(Types.UnitFlow.sccm, 1).ToString() + " sccm";
                        labGasMFC2.Text = "MFC2 : " + gasProces.GetGasFlow(Types.UnitFlow.sccm, 2).ToString() + " sccm";
                        labGasMFC3.Text = "MFC3 : " + gasProces.GetGasFlow(Types.UnitFlow.sccm, 3).ToString() + " sccm";
                        labGasVaporiser.Text = "Vaporiser: Cycle time - " + gasProces.GetCycleTime().ToString() + " ms " + " On time - " + gasProces.GetOnTime().ToString() + " %";
                        labGasVaporiser.Visible = gasProces.GetVaporiserActive();
                        break;
                    case Types.GasProcesMode.Pressure_Vap:
                      //  labGasMode.Text = "";// "Mode: Control pressure via vaporiator";
                        labGasSetpointPressure.Text = gasProces.GetSetpointPressure().ToString() + " mBar";
                        labGasMFC1.Text = "MFC1 : 0  %";
                        labGasMFC2.Text = "MFC2 : 0 %";
                        labGasMFC3.Text = "MFC3 : 0 %";
                        labGasVaporiser.Text = "Vaporiser: 100 %";
                        break;
                    case Types.GasProcesMode.Presure_MFC:
                     //   labGasMode.Text = "";// "Mode: Control pressure via mas flow control";
                        labGasSetpointPressure.Text = gasProces.GetSetpointPressure().ToString() + " mBar";
                        labGasMFC1.Text = "MFC1 : " + gasProces.GetShareGas(1).ToString() + " %";
                        labGasMFC2.Text = "MFC2 : " + gasProces.GetShareGas(2).ToString() + " %";
                        labGasMFC3.Text = "MFC3 : " + gasProces.GetShareGas(3).ToString() + " %";
                        labGasVaporiser.Text = "Vaporiser: 0 %";
                        break;
                }
                labGasMFC1.Visible = gasProces.GetActiveFlow(1);
                labGasMFC2.Visible = gasProces.GetActiveFlow(2);
                labGasMFC3.Visible = gasProces.GetActiveFlow(3);
          
            }
        }
        //--------------------------------------------------------------------------------------
        private void cBoxPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program program = (Program)cBoxPrograms.SelectedItem;
            ShowProgramConfig(program);
        }
        //--------------------------------------------------------------------------------------
        private void listViewSubprograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSubprograms.SelectedItems.Count > 0)
            {
                Subprogram subProgram = (Subprogram)listViewSubprograms.SelectedItems[0].Tag;
                ShowSubprogramConfig(subProgram);
            }
        }
        //--------------------------------------------------------------------------------------
        //Wgraj program do PLC oraz uruchom go
        private void btnStart_Click(object sender, EventArgs e)
        {
            Program program = (Program)cBoxPrograms.SelectedItem;
            if(program != null)
                program.StartProgram();
        }
        //--------------------------------------------------------------------------------------
        private void btnStop_Click(object sender, EventArgs e)
        {
            Program program = (Program)cBoxPrograms.SelectedItem;
            if (program != null)
                program.StopProgram();
        }
        //--------------------------------------------------------------------------------------
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            //Z uwagi na fakt ze nie mozna odswiez komponentow graficnzych z innego watku niz w ktorycm zostaly one utworzone dlatego odswiezam to przez Timer i flage
            if (flagRefreshProgram)
            {
                UpdateListPrograms();
                flagRefreshProgram = false;
            }
        }
        //--------------------------------------------------------------------------------------

    }
}
