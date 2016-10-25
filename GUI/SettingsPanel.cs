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

namespace HPT1000.GUI
{
    public partial class SettingsPanel : UserControl
    {
        private Source.Driver.HPT1000   hpt1000  = null;

        //----------------------------------------------------------------------------------------------------------------------------
        public SettingsPanel()
        {
            InitializeComponent();

            FillComboBoxLanguge();
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private void FillComboBoxLanguge()
        {
            cBoxLanguge.Items.Clear();
            foreach (string aName in Enum.GetNames(typeof(Types.Language)))
            {
                cBoxLanguge.Items.Add(aName);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public void SetPtrHPT(Source.Driver.HPT1000 hptPtr)
        {
            hpt1000 = hptPtr;
        }
        //------------------------------------------------------------------------------------------
        public void RefreshSettingsPanel()
        {
            if (hpt1000 != null)
            {
                for (int i = 0; i < cBoxLanguge.Items.Count; i++)
                {
                    if (cBoxLanguge.Items[i].ToString() == Source.Driver.HPT1000.LanguageApp.ToString())
                        cBoxLanguge.SelectedIndex = i;
                }

            }
        }
        //------------------------------------------------------------------------------------------
        private void cBoxDummyMode_CheckedChanged(object sender, EventArgs e)
        {
            if (hpt1000 != null && hpt1000.GetPLC() != null)
                hpt1000.GetPLC().SetDummyMode(cBoxDummyMode.Checked);

        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void btnSelectDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                tBoxPath.Text = fbd.SelectedPath;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void SettingsPanel_VisibleChanged(object sender, EventArgs e)
        {
            RefreshSettingsPanel();
        }
        //---------------------------------------------------------------------------------------------------------------------------

    }

}
