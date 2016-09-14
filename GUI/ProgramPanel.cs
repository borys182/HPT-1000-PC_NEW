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
        private Source.Driver.HPT1000 hpt1000 = null;

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
        void ClearPanel()
        {
            cBoxPrograms.Items.Clear();
            listViewSubprograms.Items.Clear();
            txtBoxDesc.Text = "";

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
            labGasMode.Text             = "";
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
        //Odsiwiez dane na temat programow
        public void RefreshPanel()
        {
            if (hpt1000 != null)
            {
                cBoxPrograms.Items.Clear();
                foreach (Program pr in hpt1000.GetPrograms())
                    cBoxPrograms.Items.Add(pr);         
            }
        }
        //--------------------------------------------------------------------------------------
        //Pokaz dane programu-
        void ShowProgramConfig(Program pr)
        {
            if (pr != null)
            {
                txtBoxDesc.Text = pr.GetDescription();
                //uzupe;nij liste sub programow
                listViewSubprograms.Items.Clear();
                foreach (Subprogram subPr in pr.GetSubPrograms())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = subPr.GetName();
                    item.SubItems.Add(subPr.GetStatus().ToString());
                    item.Tag = subPr;
                    listViewSubprograms.Items.Add(item);
                }
            }
        }
        //--------------------------------------------------------------------------------------
        void ShowSubprogramConfig(Subprogram subProgram)
        {
            if (subProgram != null)
            {
                ShowPumpProces(subProgram.GetPumpProces());
                ShowPlasmaProces(subProgram.GetPlasmaProces());
                ShowPurgeProces(subProgram.GetPurgeProces());
                ShowVentProces(subProgram.GetVentProces());
                ShowGasProces(subProgram.GetGasProces());
            }
        }
        //--------------------------------------------------------------------------------------
        void ShowPumpProces(PumpProces pumpProces)
        {
            if (pumpProces != null)
            {
                panelPump.Enabled = true;
                panelPump.Enabled = pumpProces.Active;
                if (pumpProces.Active)
                    panelPump.Font = new Font(panelPump.Font, FontStyle.Bold);
                else
                    panelPump.Font = new Font(panelPump.Font, FontStyle.Regular);

                labPumpTime.Text = pumpProces.TimeWorking.ToLongTimeString();
                labPumpTimeTarget.Text  = pumpProces.GetTimeWaitForPumpDown().ToLongTimeString();
                labPumpSetpoint.Text    = "Setpoint - " + pumpProces.GetSetpoint().ToString();
            }
        }
        //--------------------------------------------------------------------------------------
        void ShowPurgeProces(FlushProces purgeProces)
        {
            if (purgeProces != null)
            {
                panelPurge.Enabled = true;
                panelPurge.Enabled = purgeProces.Active;
                if (purgeProces.Active)
                    panelPurge.Font = new Font(panelPurge.Font, FontStyle.Bold);
                else
                    panelPurge.Font = new Font(panelPurge.Font, FontStyle.Regular);

                labPurgeTime.Text       = purgeProces.TimeWorking.ToLongTimeString();
                labPurgeTimeTarget.Text = purgeProces.GetTimePurge().ToLongTimeString();
            }
        }
        //--------------------------------------------------------------------------------------
        void ShowVentProces(VentProces ventProces)
        {
            if (ventProces != null)
            {
                panelVent.Enabled = true;
                panelVent.Enabled = ventProces.Active;
                if (ventProces.Active)
                    panelVent.Font = new Font(panelVent.Font, FontStyle.Bold);
                else
                    panelVent.Font = new Font(panelVent.Font, FontStyle.Regular);

                labVentTime.Text        = ventProces.TimeWorking.ToLongTimeString();
                labVentTimeTarget.Text  = ventProces.GetTimeVent().ToLongTimeString();
            }
        }
        //--------------------------------------------------------------------------------------
        void ShowPlasmaProces(PlasmaProces plasmaProces)
        {
            if (plasmaProces != null)
            {
                panelPlasma.Enabled = true;
                panelPlasma.Enabled = plasmaProces.Active;

                string aUnit = "";
                if (plasmaProces.GetWorkMode() == Types.WorkModeHV.Curent) aUnit = "[A]";
                if (plasmaProces.GetWorkMode() == Types.WorkModeHV.Voltage) aUnit = "[V]";
                if (plasmaProces.GetWorkMode() == Types.WorkModeHV.Power) aUnit = "[W]";

                if (plasmaProces.Active)
                    panelPlasma.Font = new Font(panelPlasma.Font, FontStyle.Bold);
                else
                    panelPlasma.Font = new Font(panelPlasma.Font, FontStyle.Regular);

                labPlasmaTime.Text = plasmaProces.TimeWorking.ToLongTimeString();
                labPlasmaTimeTarget.Text = plasmaProces.GetTimeOperate().ToLongTimeString();
                labPlasmaSetpoint.Text = "Setpoint - " + plasmaProces.GetSetpointValue().ToString() + aUnit;
            }
        }
        //--------------------------------------------------------------------------------------
        void ShowGasProces(GasProces gasProces)
        {
            if (gasProces != null)
            {
                panelGas.Enabled = true;
                panelGas.Enabled = gasProces.Active;
                if (gasProces.Active)
                    panelGas.Font = new Font(panelGas.Font, FontStyle.Bold);
                else
                    panelGas.Font = new Font(panelGas.Font, FontStyle.Regular);

                labGasTime.Text = gasProces.TimeWorking.ToLongTimeString();
                labGasTime.Text = gasProces.GetTimeProcesDuration().ToLongTimeString();

                labGasSetpointPressure.Visible  = true;
                labGasMFC1.Visible              = true;
                labGasMFC2.Visible              = true;
                labGasMFC3.Visible              = true;
                labGasVaporiser.Visible         = true;
                switch (gasProces.GetModeProces())
                {
                    case Types.GasProcesMode.FlowSP:
                        labGasMode.Text = "Mode: Dosing gases to chamber accordnig set flow";
                        labGasSetpointPressure.Visible = false;
                        labGasMFC1.Text = gasProces.GetGasFlow(Types.UnitFlow.sccm, 1).ToString();
                        labGasMFC2.Text = gasProces.GetGasFlow(Types.UnitFlow.sccm, 2).ToString();
                        labGasMFC3.Text = gasProces.GetGasFlow(Types.UnitFlow.sccm, 3).ToString();
                        labGasVaporiser.Text = "Vaporiser: Cycle - " + gasProces.GetCycleTime().ToString() + " [ms] " + "  " + gasProces.GetOnTime().ToString() + " [%]";
                        break;
                    case Types.GasProcesMode.Pressure_Vap:
                        labGasMode.Text = "Mode: Control pressure via vaporiator";
                        labGasSetpointPressure.Text = gasProces.GetSetpointPressure().ToString();
                        labGasMFC1.Visible      = false;
                        labGasMFC2.Visible      = false;
                        labGasMFC3.Visible      = false;
                        labGasVaporiser.Visible = false;
                        break;
                    case Types.GasProcesMode.Presure_MFC:
                        labGasMode.Text = "Mode: Control pressure via mas flow control";
                        labGasSetpointPressure.Text = gasProces.GetSetpointPressure().ToString();
                        labGasMFC1.Text = gasProces.GetShareGas(1).ToString();
                        labGasMFC2.Text = gasProces.GetShareGas(2).ToString();
                        labGasMFC3.Text = gasProces.GetShareGas(3).ToString();
                        labGasVaporiser.Visible = false;
                        break;
                }         
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

    }
}
