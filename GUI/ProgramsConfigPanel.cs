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
using HPT1000.Source.Chamber;
using HPT1000.Source.Program;
using HPT1000.Source;

namespace HPT1000.GUI
{
  

    public partial class ProgramsConfigPanel : UserControl
    {
        private HPT1000.Source.Driver.HPT1000 hpt1000 = null;

        private static Color backGradientStartColor = Color.FromArgb(50, 130, 50);
        private static Color backGradientEndColor = Color.FromArgb(150, 255, 100);

        private const double pressureResolution = 1000;    //zmienna okresla ile miejsc po przecinku mozna wprowadzac do zmiennych presure

        private bool        flagRefreshProgram = false;

        //--------------------------------------------------------------------------------------------------------------------------------------
        public ProgramsConfigPanel()
        {
            InitializeComponent();

            HideButton();
            HideProgramComponent();
            ClearProgramInfo();
            treeViewProgram.Nodes.Clear();
            RefreshTreeViewPrograms();

            scrollPumpSetpoint.Maximum = (int)pressureResolution * 1100;
            scrollPumpSetpoint.Minimum = 1;

            scrollGasPressure.Maximum = (int)pressureResolution * 1100;
            scrollGasPressure.Minimum = 1;

            scrollGasPressureDevaDown.Maximum   = (int)pressureResolution * 1100;
            scrollGasPressureDevaUp.Minimum     = 1;

            scrollGasPressureDevaUp.Maximum     = (int)pressureResolution * 1100;
            scrollGasPressureDevaUp.Minimum     = 1;

        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        public HPT1000.Source.Driver.HPT1000 HPT1000
        {
            set { hpt1000 = value; }
            get { return hpt1000; }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            /*       if (Width <= 0 || Height <= 0)
                       return;
                   Graphics g = e.Graphics;
                   Brush backBr = new System.Drawing.Drawing2D.LinearGradientBrush(new RectangleF(0, 0, Width, Height),
                       backGradientStartColor, backGradientEndColor,
                       System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                   g.FillRectangle(backBr, 0, 0, Width, Height);
                   backBr.Dispose();
             */
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        //Odświez dane w drzewie na temat aktuanych programow i subprogramow. Jezeli czegos brakuje to dodaj i zaktualizuj nazwe
        public void RefreshTreeViewPrograms()
        {
            TreeNode nodePrograms = null;
            bool aExistProgram = false;
            bool aExistSubprogram = false;
            //Jezeli nie istnieje zaden wezel to dodaj pierwszy
            if (treeViewProgram.Nodes.Count == 0)
                treeViewProgram.Nodes.Add("Programs list", "Programs list", 0, 0);
            if (treeViewProgram.Nodes.Count > 0)
                nodePrograms = treeViewProgram.Nodes[0];

            if (hpt1000 != null && nodePrograms != null)
            {
                foreach (Program pr in hpt1000.GetPrograms())
                {
                    aExistProgram = false;
                    TreeNode nodeProgram = null;
                    if (IsTreeViewContainsObject(pr))
                    {
                        nodeProgram = GetNodeContainsObject(pr);
                        if (nodeProgram != null)
                            nodeProgram.Text = pr.GetName();
                        aExistProgram = true;
                    }
                    else
                    {
                        nodeProgram = new TreeNode(pr.GetName(), 1, 1);
                        nodeProgram.Tag = pr;
                    }
                    foreach (Subprogram sub_pr in pr.GetSubprograms())
                    {
                        TreeNode nodeSubprogram = null;
                        aExistSubprogram = false;
                        if (IsTreeViewContainsObject(sub_pr))
                        {
                            nodeSubprogram = GetNodeContainsObject(sub_pr);
                            if (nodeSubprogram != null)
                                nodeSubprogram.Text = sub_pr.GetName();
                            aExistSubprogram = true;
                        }
                        else
                        {
                            nodeSubprogram = new TreeNode(sub_pr.GetName(), 2, 2);
                            nodeSubprogram.Tag = sub_pr;
                        }
                        if (nodeProgram != null && !aExistSubprogram)
                            nodeProgram.Nodes.Add(nodeSubprogram);
                    }
                    if (nodePrograms != null && !aExistProgram)
                        nodePrograms.Nodes.Add(nodeProgram);
                }
            }
            RemoveEmptyNode();//usn wezly nie powiazane juz z zadnym obiektem
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void RemoveEmptyNode()
        {
            if (hpt1000 != null && treeViewProgram.Nodes.Count > 0)
            {
                //Usun wezel programu jezeli program juz nie istnieje
                for (int i = 0; i < treeViewProgram.Nodes[0].Nodes.Count; i++)
                {
                    TreeNode node = treeViewProgram.Nodes[0].Nodes[i];
                    if (!IsObjectExist(node.Tag))
                    {
                        treeViewProgram.Nodes[0].Nodes.Remove(node);
                        i = -1;
                    }
                }
                //Usun wezel sub-programu jezeli subprogram juz nie istnieje
                for (int i = 0; i < treeViewProgram.Nodes[0].Nodes.Count; i++)
                {
                    TreeNode node = treeViewProgram.Nodes[0].Nodes[i];
                    for (int j = 0; j < node.Nodes.Count; j++)
                    {
                        TreeNode subNode = node.Nodes[j];
                        if (!IsObjectExist(subNode.Tag))
                        {
                            node.Nodes.Remove(subNode);
                            j = -1;
                        }
                        //treeViewProgram.Nodes[0].Nodes.Remove(subNode);
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void AddNewProgram()
        {
            if (hpt1000 != null)
                hpt1000.NewProgram();
            RefreshTreeViewPrograms();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void AddNewSubProgram()
        {
            Program program = null;
            TreeNode node = treeViewProgram.SelectedNode;

            program = GetProgram();

            if (program != null)
                program.NewSubprogram();
            else
                MessageBox.Show(Translate.GetText("Nie wybrano wezla programu"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            RefreshTreeViewPrograms();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        bool IsObjectExist(object aObj)
        {
            bool aRes = false;
            if (hpt1000 != null && aObj != null)
            {
                foreach (Program program in hpt1000.GetPrograms())
                {
                    if (aObj.Equals(program))
                        aRes = true;
                    foreach (Subprogram subProgram in program.GetSubprograms())
                        if (subProgram.Equals(aObj))
                            aRes = true;
                }
            }
            return aRes;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        private bool IsTreeViewContainsObject(object aObj)
        {
            bool aRes = false;
            if (treeViewProgram.Nodes.Count > 0)
            {
                TreeNode node = GetNode(treeViewProgram.Nodes[0], aObj);
                if (node != null)
                    aRes = true;
            }
            return aRes;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        private TreeNode GetNodeContainsObject(object aObj)
        {
            TreeNode node = null;

            if (treeViewProgram.Nodes.Count > 0)
                node = GetNode(treeViewProgram.Nodes[0], aObj);

            return node;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        TreeNode GetNode(TreeNode nodeIn, object aObj)
        {
            TreeNode nodeRes = null;
            //sprawdz czy sam go nie mam
            if (nodeIn.Tag != null && nodeIn.Tag.Equals(aObj))
                nodeRes = nodeIn;
            //Ja nie mam tego obiektu u siebie wiec sprawdz czy nie maja go moje wezly
            else
            {
                foreach (TreeNode node in nodeIn.Nodes)
                {
                    if (node.Tag != null && node.Tag.Equals(aObj))
                    {
                        nodeRes = node;
                        break;
                    }
                    else
                        if (nodeRes == null)//jezeli jeszcze nie znalazlem to szukaj dalej
                            nodeRes = GetNode(node, aObj);
                }
            }
            return nodeRes;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        private void treeViewProgram_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeViewProgram.SelectedNode;
            Program program = null;
            Subprogram subProgram = null;

            ClearProgramInfo();
            HideButton();
            //zaznaczono program
            if (node.Parent != null && node.Parent.Parent == null)
            {
                program = (Program)node.Tag;
                btnRemoveProgram.Enabled = true;
            }
            //zaznaczono subprogram
            if (node.Parent != null && node.Parent.Parent != null && node.Parent.Parent.Parent == null)
            {
                program = (Program)node.Parent.Tag;
                subProgram = (Subprogram)node.Tag;
                btnRemoveSubprogram.Enabled = true;
            }
            //Wyswietl info na temat programu
            if (program != null)
            {
                tBoxNameProgram.Text = program.GetName();
                tBoxDescProgram.Text = program.GetDescription();

                foreach (Control ctr in grBoxProgram.Controls)
                    ctr.Enabled = true;

                btnAddNewSubprogram.Enabled = true;
            }
            //Wyswietl info na temat subprogramu
            if (subProgram != null)
            {
                tBoxNameSubprogram.Text = subProgram.GetName();
                tBoxDescSubprgoram.Text = subProgram.GetDescription();

                ShowInfoStageProcess(subProgram);

                foreach (Control ctr in grBoxSubprogram.Controls)
                    ctr.Enabled = true;

                tabControlProcess.Enabled = true;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void ShowInfoStageProcess(Subprogram subProgram)
        {
            ShowInfoPumpStage(subProgram.GetPumpProces());
            ShowInfoGasStage(subProgram.GetGasProces());
            ShowInfoPlasmaStage(subProgram.GetPlasmaProces());
            ShowInfoPurgeStage(subProgram.GetPurgeProces());
            ShowInfoVentStage(subProgram.GetVentProces());
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void ShowInfoPumpStage(PumpProces pumpStage)
        {
            if (pumpStage != null)
            {
                cBoxPump.Checked                = pumpStage.Active;
                timePump.Value                  = pumpStage.GetTimeWaitForPumpDown();
                tBoxPumpSetpoint.Text           = pumpStage.GetSetpoint().ToString();
                int aValue = (int)(pumpStage.GetSetpoint() * pressureResolution);

                if (scrollPumpSetpoint.Maximum > aValue && aValue > scrollPumpSetpoint.Minimum)
                    scrollPumpSetpoint.Value    = aValue;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void ShowInfoGasStage(GasProces gasStage)
        {
            if(gasStage != null)
            {
                cBoxGas.Checked = gasStage.Active;
                timeGas.Value   = gasStage.GetTimeProcesDuration();

                tBoxFlow1.Text = gasStage.GetGasFlow(Types.UnitFlow.sccm, 1).ToString();
                tBoxFlow2.Text = gasStage.GetGasFlow(Types.UnitFlow.sccm, 2).ToString();
                tBoxFlow3.Text = gasStage.GetGasFlow(Types.UnitFlow.sccm, 3).ToString();

                tBoxFlow1Min.Text = gasStage.GetMinGasFlow(1).ToString();
                tBoxFlow2Min.Text = gasStage.GetMinGasFlow(2).ToString();
                tBoxFlow3Min.Text = gasStage.GetMinGasFlow(3).ToString();

                tBoxFlow1Max.Text = gasStage.GetMaxGasFlow(1).ToString();
                tBoxFlow2Max.Text = gasStage.GetMaxGasFlow(2).ToString();
                tBoxFlow3Max.Text = gasStage.GetMaxGasFlow(3).ToString();

                tBoxGasPressure.Text            = gasStage.GetSetpointPressure().ToString();
                tBoxGasPressureDevaDown.Text    = gasStage.GetMinDeviationPresure().ToString();
                tBoxGasPressureDevaUp.Text      = gasStage.GetMaxDeviationPresure().ToString();

                tBoxGasVaporCycleTime.Text  = gasStage.GetCycleTime().ToString();
                tBoxGasVaporOnTime.Text     = gasStage.GetOnTime().ToString();

                tBoxGasDevaShareMFC1.Text = gasStage.GetShareDevaition(1).ToString();
                tBoxGasDevaShareMFC2.Text = gasStage.GetShareDevaition(2).ToString();
                tBoxGasDevaShareMFC2.Text = gasStage.GetShareDevaition(3).ToString();

                tBoxGasShareMFC1.Text = gasStage.GetShareGas(1).ToString();
                tBoxGasShareMFC2.Text = gasStage.GetShareGas(2).ToString();
                tBoxGasShareMFC3.Text = gasStage.GetShareGas(3).ToString();

                SetValueToScroll(scrollGasDevaShareMFC1, (int)gasStage.GetShareDevaition(1));
                SetValueToScroll(scrollGasDevaShareMFC2, (int)gasStage.GetShareDevaition(2));
                SetValueToScroll(scrollGasDevaShareMFC3, (int)gasStage.GetShareDevaition(3));

                SetValueToScroll(scrollGasPressure, (int)(gasStage.GetSetpointPressure() * pressureResolution));
                SetValueToScroll(scrollGasPressureDevaDown, (int)(gasStage.GetMinDeviationPresure() * pressureResolution));
                SetValueToScroll(scrollGasPressureDevaUp, (int)(gasStage.GetMaxDeviationPresure() * pressureResolution));

                SetValueToScroll(scrollGasVaporCycleTime, (int)gasStage.GetCycleTime());
                SetValueToScroll(scrollGasVaporOnTime, (int)gasStage.GetOnTime());

                SetValueToScroll(scrollFlow1, (int)gasStage.GetGasFlow(Types.UnitFlow.sccm, 1));
                SetValueToScroll(scrollFlow2, (int)gasStage.GetGasFlow(Types.UnitFlow.sccm, 2));
                SetValueToScroll(scrollFlow3, (int)gasStage.GetGasFlow(Types.UnitFlow.sccm, 3));

                SetValueToScroll(scrollFlow1Min, (int)gasStage.GetMinGasFlow(1));
                SetValueToScroll(scrollFlow2Min, (int)gasStage.GetMinGasFlow(2));
                SetValueToScroll(scrollFlow3Min, (int)gasStage.GetMinGasFlow(3));

                SetValueToScroll(scrollFlow1Max, (int)gasStage.GetMaxGasFlow(1));
                SetValueToScroll(scrollFlow2Max, (int)gasStage.GetMaxGasFlow(2));
                SetValueToScroll(scrollFlow3Max, (int)gasStage.GetMaxGasFlow(3));

                switch(gasStage.GetModeProces())
                {
                    case Types.GasProcesMode.FlowSP:
                        rBtnModeFlow.Checked        = true;
                        break;
                    case Types.GasProcesMode.Pressure_Vap:
                        rBtnModePressure.Checked    = true;
                        rBtnPressureViaVapo.Checked = true;
                        break;
                    case Types.GasProcesMode.Presure_MFC:
                        rBtnModePressure.Checked     = true;
                        rBtnPressureViaGases.Checked = true;
                        break;
                }

                cBoxMFC1.Checked = gasStage.GetActiveFlow(1);
                cBoxMFC2.Checked = gasStage.GetActiveFlow(2);
                cBoxMFC3.Checked = gasStage.GetActiveFlow(3);

                cBoxGasListMFC1.Enabled = gasStage.GetActiveFlow(1);
                cBoxGasListMFC2.Enabled = gasStage.GetActiveFlow(2);
                cBoxGasListMFC3.Enabled = gasStage.GetActiveFlow(3);

                grBoxMFC1.Enabled = cBoxMFC1.Checked;
                grBoxMFC2.Enabled = cBoxMFC2.Checked;
                grBoxMFC3.Enabled = cBoxMFC3.Checked;

                grBoxGasesMFC1.Enabled = cBoxMFC1.Checked;
                grBoxGasesMFC2.Enabled = cBoxMFC2.Checked;
                grBoxGasesMFC3.Enabled = cBoxMFC3.Checked;

                grBoxGasFlow.Enabled = rBtnModeFlow.Checked;
                grBoxGasPressure.Enabled = rBtnModePressure.Checked;

                cBoxVaporiser.Checked   = gasStage.GetVaporiserActive();
                grBoxVaporiser.Enabled  = gasStage.GetVaporiserActive();
            }
            SetLimitGasScroll(gasStage);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void ShowInfoPlasmaStage(PlasmaProces plasmaStage)
        {
            if (plasmaStage != null)
            {
                cBoxPower.Checked           = plasmaStage.Active;
                timePlasma.Value            = plasmaStage.GetTimeOperate();
                tBoxPlasmaSetpoint.Text     = plasmaStage.GetSetpointPercent().ToString(); 
                tBoxPlasmaDeviation.Text    = plasmaStage.GetDeviation().ToString();
                if(scrollPlasmaSetpoint.Maximum > plasmaStage.GetSetpointPercent()  && scrollPlasmaSetpoint.Minimum < plasmaStage.GetSetpointPercent())
                    scrollPlasmaSetpoint.Value  = plasmaStage.GetSetpointPercent();
                if (scrollPlasmaDevistion.Maximum > plasmaStage.GetDeviation() && scrollPlasmaDevistion.Minimum < plasmaStage.GetDeviation())
                    scrollPlasmaDevistion.Value = (int)plasmaStage.GetDeviation();

                switch(plasmaStage.GetWorkMode())
                {
                    case Types.WorkModeHV.Curent:
                        rBtnPlasmaModeCurent.Checked = true;
                        break;
                    case Types.WorkModeHV.Power:
                        rBtnPlasmaModePower.Checked = true;
                        break;
                    case Types.WorkModeHV.Voltage:
                        rBtnPlasmaModeVoltage.Checked = true;
                        break;
                }

            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void ShowInfoPurgeStage(FlushProces purgeStage)
        {
            cBoxPurge.Checked = purgeStage.Active;
            if(purgeStage != null)
                timePurge.Value = purgeStage.GetTimePurge();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void ShowInfoVentStage(VentProces ventStage)
        {
            cBoxVent.Checked = ventStage.Active;
            if (ventStage != null)
                timeVent.Value = ventStage.GetTimeVent();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void SetLimitGasScroll(GasProces gasStage)
        {
            if(gasStage != null)
            {
                scrollFlow1.Minimum = gasStage.GetLimitDown(1);
                scrollFlow2.Minimum = gasStage.GetLimitDown(2);
                scrollFlow3.Minimum = gasStage.GetLimitDown(3);

                scrollFlow1.Maximum = gasStage.GetLimitUp(1);
                scrollFlow2.Maximum = gasStage.GetLimitUp(2);
                scrollFlow3.Maximum = gasStage.GetLimitUp(3);

                scrollFlow1Min.Minimum = gasStage.GetLimitDown(1);
                scrollFlow2Min.Minimum = gasStage.GetLimitDown(2);
                scrollFlow3Min.Minimum = gasStage.GetLimitDown(3);

                scrollFlow1Min.Maximum = gasStage.GetLimitUp(1);
                scrollFlow2Min.Maximum = gasStage.GetLimitUp(2);
                scrollFlow3Min.Maximum = gasStage.GetLimitUp(3);


                scrollFlow1Max.Minimum = gasStage.GetLimitDown(1);
                scrollFlow2Max.Minimum = gasStage.GetLimitDown(2);
                scrollFlow3Max.Minimum = gasStage.GetLimitDown(3);

                scrollFlow1Max.Maximum = gasStage.GetLimitUp(1);
                scrollFlow2Max.Maximum = gasStage.GetLimitUp(2);
                scrollFlow3Max.Maximum = gasStage.GetLimitUp(3);
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void ClearProgramInfo()
        {
            tBoxDescProgram.Text = "";
            tBoxDescSubprgoram.Text = "";
            tBoxNameProgram.Text = "";
            tBoxNameSubprogram.Text = "";

            cBoxGas.Checked = false;
            cBoxPower.Checked = false;
            cBoxPurge.Checked = false;
            cBoxVent.Checked = false;
            cBoxPump.Checked = false;

            foreach (Control ctr in grBoxProgram.Controls)
                ctr.Enabled = false;

            foreach (Control ctr in grBoxSubprogram.Controls)
                ctr.Enabled = false;

            tabControlProcess.Enabled = false;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void HideButton()
        {
            //  btnAddNewProgram.Enabled        = false;
            btnAddNewSubprogram.Enabled = false;
            btnRemoveProgram.Enabled = false;
            btnRemoveSubprogram.Enabled = false;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void HideProgramComponent()
        {
            grBoxGas.Enabled = false;
            grBoxPlasma.Enabled = false;
            grBoxPump.Enabled = false;
            grBoxPurge.Enabled = false;
            grBoxVent.Enabled = false;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        private void btnAddNewProgram_Click(object sender, EventArgs e)
        {
            AddNewProgram();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        private void btnAddNewSubprogram_Click(object sender, EventArgs e)
        {
            AddNewSubProgram();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        //Zwroc program z aktualnie zaznaczonego wezla
        Program GetProgram()
        {
            Program program = null;
            TreeNode node = treeViewProgram.SelectedNode;

            if (node != null && node.Parent != null && node.Parent.Parent == null)
                program = (Program)node.Tag;
            if (node != null && node.Parent != null && node.Parent.Parent != null && node.Parent.Parent.Parent == null)
                program = (Program)node.Parent.Tag;

            return program;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        Subprogram GetSubprogram()
        {
            Subprogram subPrgoram = null;
            TreeNode node = treeViewProgram.SelectedNode;
            if (node != null && node.Parent != null && node.Parent.Parent != null && node.Parent.Parent.Parent == null)
            {
                subPrgoram = (Subprogram)node.Tag;
            }
            return subPrgoram;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        PumpProces GetCurrentPumpProcess()
        {
            PumpProces pumpProces = null;
            if (GetSubprogram() != null)
                pumpProces = (PumpProces)GetSubprogram().PumpProces;
            return pumpProces;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        GasProces GetCurrentGasProcess()
        {
            GasProces gasProces = null;
            if (GetSubprogram() != null)
                gasProces = (GasProces)GetSubprogram().GasProces;
            return gasProces;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        PlasmaProces GetCurrentPlasmaProcess()
        {
            PlasmaProces plasmaProces = null;
            if (GetSubprogram() != null)
                plasmaProces = (PlasmaProces)GetSubprogram().PlasmaProces;
            return plasmaProces;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        VentProces GetCurrentVentProcess()
        {
            VentProces ventProces = null;
            if (GetSubprogram() != null)
                ventProces = (VentProces)GetSubprogram().VentProces;
            return ventProces;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        FlushProces GetCurrentPurgeProcess()
        {
            FlushProces purgeProces = null;
            if (GetSubprogram() != null)
                purgeProces = (FlushProces)GetSubprogram().PurgeProces;
            return purgeProces;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        //Funkcja sporawdz czy text zawiera poprawna wartosc zmiennoprzecikowa
        private bool CheckFloatStringValue(string aTxt, out double aValue)
        {
            bool aRes = false;
            
            if (Double.TryParse(aTxt, out aValue))
                aRes = true;
            else
                aValue = -1;

            return aRes;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        //Funkcja sporawdz czy text zawiera poprawna wartosc zmiennoprzecikowa
        private bool CheckIntStringValue(string aTxt, out int aValue)
        {
            bool aRes = false;
                        
            if (Int32.TryParse(aTxt, out aValue))
                aRes = true;
            else
                aValue = -1;

            return aRes;
        }       
        //--------------------------------------------------------------------------------------------------------------------------------------
        void SetValueToScroll(HScrollBar scroll, int aValue)
        {
            if(aValue > scroll.Minimum && aValue < scroll.Maximum )
                scroll.Value = aValue;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        //Ustaw odpowiedie dostepne checkboxy oraz ustaw dane w subprogramie
        private void cBoxProcess_CheckedChanged(object sender, EventArgs e)
        {
            grBoxGas.Enabled = cBoxGas.Checked;
            grBoxPlasma.Enabled = cBoxPower.Checked;
            grBoxPump.Enabled = cBoxPump.Checked;
            grBoxPurge.Enabled = cBoxPurge.Checked;
            grBoxVent.Enabled = cBoxVent.Checked;

        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        private void tBoxNameProgram_KeyUp(object sender, KeyEventArgs e)
        {
            Program program = GetProgram();
            if (program != null)
                program.SetName(tBoxNameProgram.Text);
            RefreshTreeViewPrograms();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        private void tBoxDescProgram_KeyUp(object sender, KeyEventArgs e)
        {
            Program program = GetProgram();
            if (program != null)
                program.SetDescription(tBoxDescProgram.Text);
            RefreshTreeViewPrograms();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        private void tBoxNameSubprogram_KeyUp(object sender, KeyEventArgs e)
        {
            Subprogram Subprogram = GetSubprogram();
            if (Subprogram != null)
                Subprogram.SetName(tBoxNameSubprogram.Text);
            RefreshTreeViewPrograms();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        private void tBoxDescSubprgoram_KeyUp(object sender, KeyEventArgs e)
        {
            Subprogram Subprogram = GetSubprogram();
            if (Subprogram != null)
                Subprogram.SetDescription(tBoxDescSubprgoram.Text);
            RefreshTreeViewPrograms();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        private void btnRemoveProgram_Click(object sender, EventArgs e)
        {
            Program program = null;
            TreeNode node = treeViewProgram.SelectedNode;

            program = GetProgram();

            if (program == null)
                MessageBox.Show(Translate.GetText("Nie wybrano wezla programu"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (hpt1000.RemoveProgram(program))
                MessageBox.Show(Translate.GetText("Program zostal poprawnie usuniety"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(Translate.GetText("Nie udalo usunac sie programu"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            RefreshTreeViewPrograms();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        private void btnRemoveSubprogram_Click(object sender, EventArgs e)
        {
            Program program = null;
            Subprogram subProgram = null;
            TreeNode node = treeViewProgram.SelectedNode;

            program = GetProgram();
            subProgram = GetSubprogram();

            if (subProgram == null || program == null)
                MessageBox.Show(Translate.GetText("Nie wybrano wezla sub-programu"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (program != null && program.RemoveSubprogram(subProgram))
                MessageBox.Show(Translate.GetText("Sub-program zostal poprawnie usuniety"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(Translate.GetText("Nie udalo usunac sie sub-programu"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            RefreshTreeViewPrograms();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void cBoxProcess_Click(object sender, EventArgs e)
        {
            Subprogram subProgram = GetSubprogram();
            if (subProgram != null)
            {
                if (subProgram.PumpProces != null) subProgram.PumpProces.Active = cBoxPump.Checked;
                if (subProgram.GasProces != null) subProgram.GasProces.Active = cBoxGas.Checked;
                if (subProgram.PlasmaProces != null) subProgram.PlasmaProces.Active = cBoxPower.Checked;
                if (subProgram.PurgeProces != null) subProgram.PurgeProces.Active = cBoxPurge.Checked;
                if (subProgram.VentProces != null) subProgram.VentProces.Active = cBoxVent.Checked;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        //OPROGRAMOWANIE WPROWADZANIA WARTOSCI Z KONTROLEK UMIESZCZONYCH NA TAB PANELU DLA KONKRETNYCH PROCESOW
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void checkFloatValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            double aValue = 0;
            //Jezeli string nie zawiera liczby to nie wpisuj jej do pola 
            if (sender is TextBox && !CheckFloatStringValue(((TextBox)sender).Text + e.KeyChar, out aValue) && (int)e.KeyChar != 8)
                e.Handled = true;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void checkIntValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            int aValue = 0;
            //Jezeli string nie zawiera liczby to nie wpisuj jej do pola 
            if (sender is TextBox && !CheckIntStringValue(((TextBox)sender).Text + e.KeyChar, out aValue) && (int)e.KeyChar != 8)
                e.Handled = true;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        //PUMP PROCES
        //----------------------------------------------------------------------------------------
        private void tBoxPumpSetpoint_Validated(object sender, EventArgs e)
        {
            //Po utracie fokusa wpisz do pola aktualna wartosc
            if (GetCurrentPumpProcess() != null)
            {
                tBoxPumpSetpoint.Text = GetCurrentPumpProcess().GetSetpoint().ToString();
                if (scrollPumpSetpoint.Maximum > GetCurrentPumpProcess().GetSetpoint() * pressureResolution)
                    scrollPumpSetpoint.Value = (int)(GetCurrentPumpProcess().GetSetpoint() * pressureResolution);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void tBoxPumpSetpoint_KeyUp(object sender, KeyEventArgs e)
        {
            double aValue = 0;
            if (e.KeyCode == Keys.Enter && CheckFloatStringValue(tBoxPumpSetpoint.Text, out aValue))
            {
                if (GetCurrentPumpProcess() != null)
                    GetCurrentPumpProcess().SetSetpoint(aValue);
                grBoxPump.Focus();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void timePump_ValueChanged(object sender, EventArgs e)
        {
            if (GetCurrentPumpProcess() != null)
                GetCurrentPumpProcess().SetTimeWaitForPumpDown(timePump.Value);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollPumpSetpoint_ValueChanged(object sender, EventArgs e)
        {
            double aValue = 0;
            if(pressureResolution > 0)
                aValue = scrollPumpSetpoint.Value / pressureResolution;
            if (GetCurrentPumpProcess() != null)
            {
                GetCurrentPumpProcess().SetSetpoint(aValue);
                tBoxPumpSetpoint.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        //PLASMA
        //----------------------------------------------------------------------------------------
        private void rBtnPlasmaMode_Click(object sender, EventArgs e)
        {
            Types.WorkModeHV mode = Types.WorkModeHV.Power;

            if (rBtnPlasmaModeCurent.Checked) mode = Types.WorkModeHV.Curent;
            if (rBtnPlasmaModeVoltage.Checked) mode = Types.WorkModeHV.Voltage;
            if (rBtnPlasmaModePower.Checked) mode = Types.WorkModeHV.Power;

            if (GetCurrentPlasmaProcess() != null)
                GetCurrentPlasmaProcess().SetWorkMode(mode);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void timePlasma_ValueChanged(object sender, EventArgs e)
        {
            if (GetCurrentPlasmaProcess() != null)
                GetCurrentPlasmaProcess().SetTimeOperate(timePlasma.Value);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void tBoxPlasmaSetpoint_Validated(object sender, EventArgs e)
        {
            //Po utracie fokusa wpisz do pola aktualna wartosc
            if (GetCurrentPlasmaProcess() != null)
            {
                tBoxPlasmaSetpoint.Text = GetCurrentPlasmaProcess().GetSetpointPercent().ToString();
                if (scrollPlasmaSetpoint.Maximum > GetCurrentPlasmaProcess().GetSetpointPercent())
                    scrollPlasmaSetpoint.Value = GetCurrentPlasmaProcess().GetSetpointPercent();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void tBoxPlasmaSetpoint_KeyUp(object sender, KeyEventArgs e)
        {
            double aValue = 0;
            if (e.KeyCode == Keys.Enter && CheckFloatStringValue(tBoxPlasmaSetpoint.Text, out aValue))
            {
                if (GetCurrentPlasmaProcess() != null)
                    GetCurrentPlasmaProcess().SetSetpointPercent((int)aValue);
                grBoxPlasma.Focus();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollPlasmaSetpoint_Scroll(object sender, ScrollEventArgs e)
        {
            int aValue = scrollPlasmaSetpoint.Value;
            if (GetCurrentPlasmaProcess() != null)
            {
                GetCurrentPlasmaProcess().SetSetpointPercent(aValue);
                tBoxPlasmaSetpoint.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void tBoxPlsamsDeviation_Validated(object sender, EventArgs e)
        {
            //Po utracie fokusa wpisz do pola aktualna wartosc
            if (GetCurrentPlasmaProcess() != null)
            {
                tBoxPlasmaDeviation.Text = GetCurrentPlasmaProcess().GetDeviation().ToString();
                if (scrollPlasmaDevistion.Maximum > GetCurrentPlasmaProcess().GetDeviation())
                    scrollPlasmaDevistion.Value = (int)GetCurrentPlasmaProcess().GetDeviation();
            } 
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void tBoxPlsamsDeviation_KeyUp(object sender, KeyEventArgs e)
        {
            double aValue = 0;
            if (e.KeyCode == Keys.Enter && CheckFloatStringValue(tBoxPlasmaDeviation.Text, out aValue))
            {
                if (GetCurrentPlasmaProcess() != null)
                    GetCurrentPlasmaProcess().SetDeviation(aValue);
                grBoxPlasma.Focus();
            }
        }
        //-----------------------------------------------------------------------------------------
        private void scrollPlasmaDevistion_Scroll(object sender, ScrollEventArgs e)
        {
            int aValue = scrollPlasmaDevistion.Value;
            if (GetCurrentPlasmaProcess() != null)
            {
                GetCurrentPlasmaProcess().SetDeviation(aValue);
                tBoxPlasmaDeviation.Text = aValue.ToString();
            }
        }
        //-----------------------------------------------------------------------------------------
        //PURGE
        //----------------------------------------------------------------------------------------
        private void timePyrge_ValueChanged(object sender, EventArgs e)
        {
            if (GetCurrentPurgeProcess() != null)
                GetCurrentPurgeProcess().SetTimePurge(timePurge.Value);
        }
        //----------------------------------------------------------------------------------------
        //VENT
        //----------------------------------------------------------------------------------------
        private void timeVent_ValueChanged(object sender, EventArgs e)
        {
            if (GetCurrentVentProcess() != null)
                GetCurrentVentProcess().SetTimeVent(timeVent.Value);
        }
        //-----------------------------------------------------------------------------------------
        //------------------------------GAS------------------------------------------
        //----------------------------------------------------------------------------------------
        private void SetModeGas()
        {
            Types.GasProcesMode mode = Types.GasProcesMode.FlowSP;

           if (rBtnModeFlow.Checked)
                mode = Types.GasProcesMode.FlowSP;
            else
            {
                if (rBtnPressureViaGases.Checked)
                    mode = Types.GasProcesMode.Presure_MFC;
                else
                    mode = Types.GasProcesMode.Pressure_Vap;
            }

            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
                ((GasProces)GetSubprogram().GasProces).SetModeProces(mode);

            grBoxGasFlow.Enabled        = rBtnModeFlow.Checked;
            grBoxGasPressure.Enabled    = rBtnModePressure.Checked;
            grBoxGasesMFC1.Enabled      = cBoxMFC1.Checked && rBtnPressureViaGases.Checked;
            grBoxGasesMFC2.Enabled      = cBoxMFC2.Checked && rBtnPressureViaGases.Checked;
            grBoxGasesMFC3.Enabled      = cBoxMFC3.Checked && rBtnPressureViaGases.Checked;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void rBtnGasMode_CheckedChanged(object sender, EventArgs e)
        {
            //Ustaw domyslnie tryb flow
            if (((Control)sender).Name == "rBtnModePressure" && ((RadioButton)sender).Checked == true )
                rBtnPressureViaGases.Checked = true;

            SetModeGas();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void rBtnGasModePressure_CheckedChanged(object sender, EventArgs e)
        {
            SetModeGas();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void timeGas_ValueChanged(object sender, EventArgs e)
        {
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
                ((GasProces)GetSubprogram().GasProces).SetTimeProcesDuration(timeGas.Value);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void cBoxMFC1_Click(object sender, EventArgs e)
        {
            cBoxGasListMFC1.Enabled = cBoxMFC1.Checked;
            grBoxMFC1.Enabled       = cBoxMFC1.Checked;
            grBoxGasesMFC1.Enabled  = cBoxMFC1.Checked;

            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
                ((GasProces)GetSubprogram().GasProces).SetActiveFlow(cBoxMFC1.Checked,1);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void cBoxMFC2_Click(object sender, EventArgs e)
        {
            cBoxGasListMFC2.Enabled = cBoxMFC2.Checked;
            grBoxMFC2.Enabled       = cBoxMFC2.Checked;
            grBoxGasesMFC2.Enabled  = cBoxMFC2.Checked;

            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
                ((GasProces)GetSubprogram().GasProces).SetActiveFlow(cBoxMFC2.Checked, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void cBoxMFC3_Click(object sender, EventArgs e)
        {
            cBoxGasListMFC3.Enabled = cBoxMFC3.Checked;
            grBoxMFC3.Enabled       = cBoxMFC3.Checked;
            grBoxGasesMFC3.Enabled  = cBoxMFC3.Checked;

            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
                ((GasProces)GetSubprogram().GasProces).SetActiveFlow(cBoxMFC3.Checked, 3);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void cBoxVaporiser_Click(object sender, EventArgs e)
        {
            grBoxVaporiser.Enabled = cBoxVaporiser.Checked;

            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
                ((GasProces)GetSubprogram().GasProces).SetVaporaiserActive(cBoxVaporiser.Checked);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollFlow1_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollFlow1.Value  ;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetGasFlow(aValue,Types.UnitFlow.sccm, 1);
                tBoxFlow1.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollFlow2_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollFlow2.Value;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetGasFlow(aValue, Types.UnitFlow.sccm, 2);
                tBoxFlow2.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollFlow3_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollFlow3.Value;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetGasFlow(aValue, Types.UnitFlow.sccm, 3);
                tBoxFlow3.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollFlow1Min_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollFlow1Min.Value;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetMinGasFlow(aValue, 1);
                tBoxFlow1Min.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollFlow2Min_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollFlow2Min.Value;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetMinGasFlow(aValue, 2);
                tBoxFlow2Min.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollFlow3Min_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollFlow3Min.Value;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetMinGasFlow(aValue, 3);
                tBoxFlow3Min.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollFlow1Max_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollFlow1Max.Value;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetMaxGasFlow(aValue, 1);
                tBoxFlow1Max.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollFlow2Max_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollFlow2Max.Value;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetMaxGasFlow(aValue, 2);
                tBoxFlow2Max.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollFlow3Max_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollFlow3Max.Value;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetMaxGasFlow(aValue, 3);
                tBoxFlow3Max.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollGasVaporCycleTime_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollGasVaporCycleTime.Value;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetCycleTime(aValue);
                tBoxGasVaporCycleTime.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollGasVaporOnTime_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollGasVaporOnTime.Value;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetOnTime(aValue);
                tBoxGasVaporOnTime.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollGasDevaShareMFC1_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollGasDevaShareMFC1.Value;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetShareDevaition(aValue,1);
                tBoxGasDevaShareMFC1.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollGasDevaShareMFC2_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollGasDevaShareMFC2.Value;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetShareDevaition(aValue, 2);
                tBoxGasDevaShareMFC2.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollGasDevaShareMFC3_ValueChanged(object sender, EventArgs e)
        {
            int aValue = scrollGasDevaShareMFC3.Value;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetShareDevaition(aValue, 3);
                tBoxGasDevaShareMFC3.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollGasPressure_ValueChanged(object sender, EventArgs e)
        {
            double aValue = 0;
            if (pressureResolution > 0)
                aValue = scrollGasPressure.Value / pressureResolution;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                ((GasProces)GetSubprogram().GasProces).SetSetpointPressure(aValue);
                tBoxGasPressure.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollGasPressureDevaDown_ValueChanged(object sender, EventArgs e)
        {
            double aValue = 0;
            if (pressureResolution > 0)
                aValue = scrollGasPressureDevaDown.Value / pressureResolution;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                GetCurrentGasProcess().SetMinDeviationPresure(aValue);
                tBoxGasPressureDevaDown.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void scrollGasPressureDevaUp_ValueChanged(object sender, EventArgs e)
        {
            double aValue = 0;
            if (pressureResolution > 0)
                aValue = scrollGasPressureDevaUp.Value / pressureResolution;
            if (GetSubprogram() != null && GetSubprogram().GasProces != null)
            {
                GetCurrentGasProcess().SetMaxDeviationPresure(aValue);
                tBoxGasPressureDevaUp.Text = aValue.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        //Sprawdz czy wartosc z danego pola miesci sie w zakresie jezeli nie to zwroc wartosc ustawiona na min max. Jezeli jest ok to zwroc true
        private void SetLimitValue(object sender, double aValueIn,out double aValue)
        {
            string  aName = "";
            double  aMin = -100000000000.0;
            double  aMax =  100000000000.0;

            aValue = aValueIn;
            if (sender is TextBox)
            {
                aName = ((TextBox)sender).Name;

                if (aName == "tBoxFlow1" || aName == "tBoxFlow1Min" || aName == "tBoxFlow1Max")
                {
                    aMin = ((GasProces)GetCurrentGasProcess()).GetLimitDown(1);
                    aMax = ((GasProces)GetCurrentGasProcess()).GetLimitUp(1);
                }

                if (aName == "tBoxFlow2" || aName == "tBoxFlow2Min" || aName == "tBoxFlow2Max")
                {
                    aMin = ((GasProces)GetCurrentGasProcess()).GetLimitDown(2);
                    aMax = ((GasProces)GetCurrentGasProcess()).GetLimitUp(2);
                }

                if (aName == "tBoxFlow3" || aName == "tBoxFlow3Min" || aName == "tBoxFlow3Max")
                {
                    aMin = ((GasProces)GetCurrentGasProcess()).GetLimitDown(3);
                    aMax = ((GasProces)GetCurrentGasProcess()).GetLimitUp(3);
                }

                if (aName == "tBoxGasVaporCycleTime")
                {
                    aMin = scrollGasVaporCycleTime.Minimum;
                    aMax = scrollGasVaporCycleTime.Maximum;
                }

                if (aName == "tBoxGasVaporOnTime" || 
                    aName == "tBoxGasDevaShareMFC1" || aName == "tBoxGasDevaShareMFC2" || aName == "tBoxGasDevaShareMFC3" ||
                    aName == "tBoxGasShareMFC1"     || aName == "tBoxGasShareMFC2"     || aName == "tBoxGasShareMFC3")
                {
                    aMin = 0;
                    aMax = 100;
                }
                if (aName == "tBoxGasPressure" || aName == "tBoxGasPressureDevaUp" || aName == "tBoxGasPressureDevaDown")  
                {
                    aMin = 0.001;
                    aMax = 1100;
                }

                if (aValue < aMin)
                {
                    ((TextBox)sender).Text = aMin.ToString();
                    aValue = aMin;
                }
                if (aValue > aMax)
                {
                    ((TextBox)sender).Text = aMax.ToString();
                    aValue = aMax;
                }                                
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void tBoxGas_KeyUp(object sender, KeyEventArgs e)
        {
            double aValue       = 0;
            string aName        = "";
            GasProces gasStage  = GetCurrentGasProcess();

            if (e.KeyCode == Keys.Enter && sender is TextBox && CheckFloatStringValue(((TextBox)sender).Text, out aValue) && gasStage != null)
            {
                aName = ((TextBox)sender).Name;
                SetLimitValue(sender, aValue,out aValue);

                if (aName == "tBoxFlow1")
                    gasStage.SetGasFlow(aValue, Types.UnitFlow.sccm, 1);
                if (aName == "tBoxFlow2")
                    gasStage.SetGasFlow(aValue, Types.UnitFlow.sccm, 2);
                if (aName == "tBoxFlow3")
                    gasStage.SetGasFlow(aValue, Types.UnitFlow.sccm, 3);
                if (aName == "tBoxFlow1Min")
                    gasStage.SetMinGasFlow((int)aValue, 1);
                if (aName == "tBoxFlow2Min")
                    gasStage.SetMinGasFlow((int)aValue, 2);
                if (aName == "tBoxFlow3Min")
                    gasStage.SetMinGasFlow((int)aValue, 3);
                if (aName == "tBoxFlow1Max")
                    gasStage.SetMaxGasFlow((int)aValue, 1);
                if (aName == "tBoxFlow2Max")
                    gasStage.SetMaxGasFlow((int)aValue, 2);
                if (aName == "tBoxFlow3Max")
                    gasStage.SetMaxGasFlow((int)aValue, 3);
                if (aName == "tBoxGasVaporCycleTime")
                    gasStage.SetCycleTime(aValue);
                if (aName == "tBoxGasVaporOnTime")
                    GetCurrentGasProcess().SetOnTime((int)aValue);
                if (aName == "tBoxGasShareMFC1")
                    gasStage.SetShareGas((int)aValue, 1);
                if (aName == "tBoxGasShareMFC2")
                    gasStage.SetShareGas((int)aValue, 2);
                if (aName == "tBoxGasShareMFC3")
                    gasStage.SetShareGas((int)aValue, 3);
                if (aName == "tBoxGasDevaShareMFC1")
                    gasStage.SetShareDevaition((int)aValue, 1);
                if (aName == "tBoxGasDevaShareMFC2")
                    gasStage.SetShareDevaition((int)aValue, 2);
                if (aName == "tBoxGasDevaShareMFC3")
                    gasStage.SetShareDevaition((int)aValue, 3);
                if (aName == "tBoxGasPressure")
                    gasStage.SetSetpointPressure(aValue);
                if (aName == "tBoxGasPressureDevaDown")
                    gasStage.SetMinDeviationPresure(aValue);
                if (aName == "tBoxGasPressureDevaUp")
                    gasStage.SetMaxDeviationPresure(aValue);

                grBoxGas.Focus();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void tBoxGas_Validated(object sender, EventArgs e)
        {
            GasProces gasStage  = GetCurrentGasProcess();
            string    aName     = ((TextBox)sender).Name;
            double    aValue    = 0;
            //Po utracie fokusa wpisz do pola aktualna wartosc
            if (gasStage != null)
            {
                if (aName == "tBoxFlow1")
                {
                    tBoxFlow1.Text = gasStage.GetGasFlow(Types.UnitFlow.sccm, 1).ToString();
                    if (scrollFlow1.Maximum >= gasStage.GetGasFlow(Types.UnitFlow.sccm, 1) && scrollFlow1.Minimum <= gasStage.GetGasFlow(Types.UnitFlow.sccm, 1))
                        scrollFlow1.Value = (int)(gasStage.GetGasFlow(Types.UnitFlow.sccm, 1));
                }
                if (aName == "tBoxFlow2")
                {
                    tBoxFlow2.Text = gasStage.GetGasFlow(Types.UnitFlow.sccm, 2).ToString();
                    if (scrollFlow2.Maximum >= gasStage.GetGasFlow(Types.UnitFlow.sccm, 2) && scrollFlow2.Minimum <= gasStage.GetGasFlow(Types.UnitFlow.sccm, 2))
                        scrollFlow2.Value = (int)(gasStage.GetGasFlow(Types.UnitFlow.sccm, 2));
                }
                if (aName == "tBoxFlow3")
                {
                    tBoxFlow3.Text = gasStage.GetGasFlow(Types.UnitFlow.sccm, 3).ToString();
                    if (scrollFlow3.Maximum >= gasStage.GetGasFlow(Types.UnitFlow.sccm, 3) && scrollFlow2.Minimum <= gasStage.GetGasFlow(Types.UnitFlow.sccm, 3))
                        scrollFlow3.Value = (int)(gasStage.GetGasFlow(Types.UnitFlow.sccm, 3));
                }
                if (aName == "tBoxFlow1Min")
                {
                    tBoxFlow1Min.Text = gasStage.GetMinGasFlow(1).ToString();
                    if (scrollFlow1Min.Maximum >= gasStage.GetMinGasFlow(1) && scrollFlow1Min.Minimum <= gasStage.GetMinGasFlow(1))
                        scrollFlow1Min.Value = (int)(gasStage.GetMinGasFlow(1));
                }
                if (aName == "tBoxFlow2Min")
                {
                    tBoxFlow2Min.Text = gasStage.GetMinGasFlow(2).ToString();
                    if (scrollFlow2Min.Maximum >= gasStage.GetMinGasFlow(2) && scrollFlow2Min.Minimum <= gasStage.GetMinGasFlow(2))
                        scrollFlow2Min.Value = (int)(gasStage.GetMinGasFlow(2));
                }
                if (aName == "tBoxFlow3Min")
                {
                    tBoxFlow3Min.Text = gasStage.GetMinGasFlow(3).ToString();
                    if (scrollFlow3Min.Maximum >= gasStage.GetMinGasFlow(3) && scrollFlow3Min.Minimum <= gasStage.GetMinGasFlow(3))
                        scrollFlow3Min.Value = (int)(gasStage.GetMinGasFlow(3));
                }
                if (aName == "tBoxFlow1Max")
                {
                    tBoxFlow1Max.Text = gasStage.GetMaxGasFlow(1).ToString();
                    if (scrollFlow1Max.Maximum >= gasStage.GetMaxGasFlow(1) && scrollFlow1Max.Minimum <= gasStage.GetMaxGasFlow(1))
                        scrollFlow1Max.Value = (int)(gasStage.GetMaxGasFlow(1));
                }
                if (aName == "tBoxFlow2Max")
                {
                    tBoxFlow2Max.Text = gasStage.GetMaxGasFlow(2).ToString();
                    if (scrollFlow2Max.Maximum >= gasStage.GetMaxGasFlow(2) && scrollFlow2Max.Minimum <= gasStage.GetMaxGasFlow(2))
                        scrollFlow2Max.Value = (int)(gasStage.GetMaxGasFlow(2));
                }
                if (aName == "tBoxFlow3Max")
                {
                    tBoxFlow3Max.Text = gasStage.GetMaxGasFlow(3).ToString();
                    if (scrollFlow3Max.Maximum >= gasStage.GetMaxGasFlow(3) && scrollFlow3Max.Minimum <= gasStage.GetMaxGasFlow(3))
                        scrollFlow3Max.Value = (int)(gasStage.GetMaxGasFlow(3));
                }
                if (aName == "tBoxGasVaporCycleTime")
                {
                    tBoxGasVaporCycleTime.Text = gasStage.GetCycleTime().ToString();
                    if (scrollGasVaporCycleTime.Maximum >= gasStage.GetCycleTime() && scrollGasVaporCycleTime.Minimum <= gasStage.GetCycleTime())
                        scrollGasVaporCycleTime.Value = (int)(gasStage.GetCycleTime());
                }
                if (aName == "tBoxGasVaporOnTime")
                {
                    tBoxGasVaporOnTime.Text = gasStage.GetOnTime().ToString();
                    if (scrollGasVaporOnTime.Maximum >= gasStage.GetOnTime() && scrollGasVaporOnTime.Minimum <= gasStage.GetOnTime())
                        scrollGasVaporOnTime.Value = (int)(gasStage.GetOnTime());
                }
                if (aName == "tBoxGasShareMFC1")
                {
                    tBoxGasShareMFC1.Text = gasStage.GetShareGas(1).ToString();
                }
                if (aName == "tBoxGasShareMFC2")
                {
                    tBoxGasShareMFC2.Text = gasStage.GetShareGas(2).ToString();
                }
                if (aName == "tBoxGasShareMFC3")
                {
                    tBoxGasShareMFC3.Text = gasStage.GetShareGas(3).ToString();
                }
                if (aName == "tBoxGasDevaShareMFC1")
                {
                    tBoxGasDevaShareMFC1.Text = gasStage.GetShareDevaition(1).ToString();
                    if (scrollGasDevaShareMFC1.Maximum >= gasStage.GetShareDevaition(1) && scrollGasDevaShareMFC1.Minimum <= gasStage.GetShareDevaition(1))
                        scrollGasDevaShareMFC1.Value = (int)(gasStage.GetShareDevaition(1));
                }
                if (aName == "tBoxGasDevaShareMFC2")
                {
                    tBoxGasDevaShareMFC2.Text = gasStage.GetShareDevaition(2).ToString();
                    if (scrollGasDevaShareMFC2.Maximum >= gasStage.GetShareDevaition(2) && scrollGasDevaShareMFC2.Minimum <= gasStage.GetShareDevaition(2))
                        scrollGasDevaShareMFC2.Value = (int)(gasStage.GetShareDevaition(2));
                }
                if (aName == "tBoxGasDevaShareMFC3")
                {
                    tBoxGasDevaShareMFC3.Text = gasStage.GetShareDevaition(3).ToString();
                    if (scrollGasDevaShareMFC3.Maximum >= gasStage.GetShareDevaition(3) && scrollGasDevaShareMFC3.Minimum <= gasStage.GetShareDevaition(3))
                        scrollGasDevaShareMFC3.Value = (int)(gasStage.GetShareDevaition(3));
                }
                if (aName == "tBoxGasPressure")
                {
                    tBoxGasPressure.Text = gasStage.GetSetpointPressure().ToString();
                    aValue = gasStage.GetSetpointPressure() * pressureResolution;
                    if (scrollGasPressure.Maximum >= aValue && scrollGasPressure.Minimum <= aValue)
                        scrollGasPressure.Value = (int)aValue;
                }
                if (aName == "tBoxGasPressureDevaDown")
                {
                    tBoxGasPressureDevaDown.Text = gasStage.GetMinDeviationPresure().ToString();
                    aValue = gasStage.GetMinDeviationPresure() * pressureResolution;
                    if (scrollGasPressureDevaDown.Maximum >= aValue && scrollGasPressureDevaDown.Minimum <= aValue)
                        scrollGasPressureDevaDown.Value = (int)aValue;
                }
                if (aName == "tBoxGasPressureDevaUp")
                {
                    tBoxGasPressureDevaUp.Text = gasStage.GetMaxDeviationPresure().ToString();
                    aValue = gasStage.GetMaxDeviationPresure() * pressureResolution;
                    if (scrollGasPressureDevaUp.Maximum >= aValue && scrollGasPressureDevaUp.Minimum <= aValue)
                        scrollGasPressureDevaUp.Value = (int)aValue;
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        //Funkcja jest wywolywana jako delegat w momencie zmian dokonywanych w liscie programow/subprogramow
        public void RefreshProgram()
        {
            flagRefreshProgram = true;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            //Z uwagi na fakt ze nie mozna odswiez komponentow graficnzych z innego watku niz w ktorycm zostaly one utworzone dlatego odswiezam to przez Timer i flage
            if (flagRefreshProgram)
            {
                RefreshTreeViewPrograms();
                flagRefreshProgram = false;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void btnReadFromPLC_Click(object sender, EventArgs e)
        {
            if (hpt1000 != null)
                hpt1000.ReadProgramFromPLC();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------

    }
}
