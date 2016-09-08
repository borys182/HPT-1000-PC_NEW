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

        //--------------------------------------------------------------------------------------------------------------------------------------
        public ProgramsConfigPanel()
        {
            InitializeComponent();

            HideButton();
            ClearProgramInfo();
            treeViewProgram.Nodes.Clear();
            RefreshTreeViewPrograms();
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
        private void RefreshTreeViewPrograms()
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
                    foreach (Subprogram sub_pr in pr.GetSubPrograms())
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
                        i = 0;
                    }
                }
                //Usun wezel sub-programu jezeli program juz nie istnieje
                for (int i = 0; i < treeViewProgram.Nodes[0].Nodes.Count; i++)
                {
                    TreeNode node = treeViewProgram.Nodes[0].Nodes[i];
                    for (int j = 0; j < node.Nodes.Count; j++)
                    {
                        TreeNode subNode = node.Nodes[j];
                        if (!IsObjectExist(subNode.Tag))
                        {
                            subNode.Nodes.Remove(subNode);
                            j = 0;
                        }
                        //treeViewProgram.Nodes[0].Nodes.Remove(subNode);
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        bool IsObjectExist(object aObj)
        {
            bool aRes = false;
            if (hpt1000 != null)
            {
                foreach (Program program in hpt1000.GetPrograms())
                {
                    if (aObj == program)
                        aRes = true;
                    foreach (Subprogram subProgram in program.GetSubPrograms())
                        if (subProgram == aObj)
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
            if (nodeIn.Tag == aObj)
                nodeRes = nodeIn;
            else
            {
                foreach (TreeNode node in nodeIn.Nodes)
                {
                    if (node.Tag == aObj)
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
            cBoxPump.Checked = pumpStage.Active;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void ShowInfoGasStage(GasProces gasStage)
        {
            cBoxGas.Checked = gasStage.Active;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void ShowInfoPlasmaStage(PlasmaProces plasmaStage)
        {
            cBoxPower.Checked = plasmaStage.Active;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void ShowInfoPurgeStage(FlushProces purgeStage)
        {
            cBoxPurge.Checked = purgeStage.Active;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        void ShowInfoVentStage(VentProces ventStage)
        {
            cBoxVent.Checked = ventStage.Active;
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
        private void btnAddNewProgram_Click(object sender, EventArgs e)
        {
            if (hpt1000 != null)
                hpt1000.AddProgram();
            RefreshTreeViewPrograms();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        private void btnAddNewSubprogram_Click(object sender, EventArgs e)
        {
            Program program = null;
            TreeNode node = treeViewProgram.SelectedNode;

            program = GetProgram();

            if (program != null)
                program.AddSubprogram();
            else
                MessageBox.Show(Translate.GetText("Nie wybrano wezla programu", Language.EN), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            RefreshTreeViewPrograms();
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
        //--------------------------------------------------------------------------------------------------------------------------------------
        //Ustaw odpowiedie dostepne checkboxy oraz ustaw dane w subprogramie
        private void cBoxProcess_CheckedChanged(object sender, EventArgs e)
        {

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
                MessageBox.Show(Translate.GetText("Nie wybrano wezla programu", Language.EN), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (hpt1000.RemoveProgram(program))
                MessageBox.Show(Translate.GetText("Program zostal poprawnie usuniety", Language.EN), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(Translate.GetText("Nie udalo usunac sie programu", Language.EN), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show(Translate.GetText("Nie wybrano wezla sub-programu", Language.EN), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (program != null && program.RemoveSubprogram(subProgram))
                MessageBox.Show(Translate.GetText("Sub-program zostal poprawnie usuniety", Language.EN), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(Translate.GetText("Nie udalo usunac sie sub-programu", Language.EN), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            RefreshTreeViewPrograms();
        }

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

    }
}
