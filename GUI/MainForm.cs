using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPT1000.Source.Driver;
using HPT1000.Source.Chamber;
using HPT1000.Source.Program;

namespace HPT1000.GUI
{
    ///<summary>
    ///Klasa jest odpowiedzialna za reprezentowanie glownego okna programu
    ///</summary>
    public partial class MainForm : Form
    {
        #region Private

        private HPT1000.Source.Driver.HPT1000 hpt1000 = new HPT1000.Source.Driver.HPT1000();

        #endregion

        public MainForm()
        {
            InitializeComponent();

            RefreshTreeViewPrograms();

        //    listView1.Items.S Add()
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBoxMsg.Text = "Connecting ...";
            
            int aRes = hpt1000.Connect();

            if (aRes == 0)
                txtBoxMsg.Text = "Connection OK";
            else
                txtBoxMsg.Text = "Connection faild " + String.Format("0x{0:x8}", aRes);
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
           
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            /*
            int iRes = 0;
            if (rBtnOpen.Checked)
                iRes = hpt.SetStateValve(Types.StateValve.Open, Types.TypeValve.VV);
            else
                iRes = hpt.SetStateValve(Types.StateValve.Close, Types.TypeValve.VV);

            if (iRes == 0)
                txtBoxMsg.Text = "Set OK";
            else
                txtBoxMsg.Text = "Set faild " + String.Format("0x{0:x8}", iRes);
             */
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            hpt1000.Run();
        }

        private void btnGetState_Click(object sender, EventArgs e)
        {

            Types.StateValve state = hpt1000.GetValve().GetState(Types.TypeValve.SV);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox23.Text = (hScrollBar1.Value * 0.01).ToString();
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddNewProgram_Click(object sender, EventArgs e)
        {
            if (txtBoxNameProgram.Text.Length > 0)
            {
                hpt1000.GetProgram().AddProgram(txtBoxNameProgram.Text, txtBoxProgramDescription.Text);
                RefreshTreeViewPrograms();
            }
            else
                MessageBox.Show("File Name is empty. I can't add new program");
        }

        private void RefreshTreeViewPrograms()
        {
            treeViewPr.Nodes.Clear();
            TreeNode nodePrograms = new TreeNode("Programs", 1, 1);
            foreach (Program pr in hpt1000.GetProgram().GetPrograms())
            {
                TreeNode nodeProgram    = new TreeNode(pr.GetName(),1,1);
                TreeNode nodeSubprograms = new TreeNode("Subprograms", 2, 2);

                foreach (Subprogram sub_pr in pr.GetSubPrograms())
                {
                    TreeNode nodeSubprogram = new TreeNode(sub_pr.GetName(), 3, 4);
                    nodeSubprograms.Nodes.Add(nodeSubprogram);
                }
                nodeProgram.Nodes.Add(nodeSubprograms);
                nodePrograms.Nodes.Add(nodeProgram);
            }
            treeViewPr.Nodes.Add(nodePrograms);
        }

        private void listBoxPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
