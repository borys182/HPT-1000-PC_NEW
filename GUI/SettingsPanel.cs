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
        private GasTypes                gasTypes = null;
        //----------------------------------------------------------------------------------------------------------------------------
        public SettingsPanel()
        {
            InitializeComponent();

            FillComboBoxLanguge();
            FillComboBoxCommunication();
            FillComboBoxGases();
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
        private void FillComboBoxCommunication()
        {
            cBoxComm.Items.Clear();
            foreach (string aName in Enum.GetNames(typeof(Types.TypeComm)))
            {
                cBoxComm.Items.Add(aName);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private void FillComboBoxGases()
        {
            cBoxGasType.Items.Clear();

            if (gasTypes != null)
            {
                foreach (GasType gasType in gasTypes.Items )
                {
                    cBoxGasType.Items.Add(gasType);
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public void SetPtrHPT(Source.Driver.HPT1000 hptPtr)
        {
            hpt1000 = hptPtr;

            if(hpt1000 != null)
                gasTypes = hpt1000.GetGasTypes();
        }
        //------------------------------------------------------------------------------------------
        public void RefreshSettingsPanel()
        {
            if (hpt1000 != null)
            {
                PowerSupplay aPowerSupply = hpt1000.GetPowerSupply();
                MFC          aMFC         = hpt1000.GetMFC();
                ForePump     aForePump    = hpt1000.GetForePump();

                if (aPowerSupply != null)
                {
                    dEditCurentLimit.Value = aPowerSupply.LimitCurent;
                    dEditPowerLimit.Value = aPowerSupply.LimitPower;
                    dEditVoltageLimit.Value = aPowerSupply.LimitVoltage;
                    dEditRangePower.Value = aPowerSupply.MaxPower;
                    dEditRangeCurent.Value = aPowerSupply.MaxCurent;
                    dEditRangeVoltage.Value = aPowerSupply.MaxVoltage;
                    timeSetpointStabilization.Value = Types.ConvertDate((int)aPowerSupply.TimeWaitSetpoint);
                    timeWaitOnOperate.Value = Types.ConvertDate((int)aPowerSupply.TimeWaitOperate);
                }

                if (aMFC != null)
                {
                    dEditMaxFlow_MFC1.Value = aMFC.GetMaxFlow(1);
                    dEditMaxFlow_MFC2.Value = aMFC.GetMaxFlow(2);
                    dEditMaxFlow_MFC3.Value = aMFC.GetMaxFlow(3);
                    dEditRangeVoltageMFC1.Value = aMFC.GetRangeVoltage(1);
                    dEditRangeVoltageMFC2.Value = aMFC.GetRangeVoltage(2);
                    dEditRangeVoltageMFC3.Value = aMFC.GetRangeVoltage(3);
                    timeFlowStabilization.Value = Types.ConvertDate((int)aMFC.TimeFlowStability);

                    cBoxMFC1.Checked = aMFC.GetActive(1);
                    cBoxMFC2.Checked = aMFC.GetActive(2);
                    cBoxMFC3.Checked = aMFC.GetActive(3);
                }

                if (aForePump != null)
                {
                    timePumpToSV.Value = Types.ConvertDate((int)aForePump.TimePumpToSV);
                    timeWaitPF.Value = Types.ConvertDate((int)aForePump.TimeWaitPF);
                }

                for (int i = 0; i < cBoxLanguge.Items.Count; i++)
                {
                    if (cBoxLanguge.Items[i].ToString() == Source.Driver.HPT1000.LanguageApp.ToString())
                        cBoxLanguge.SelectedIndex = i;
                }

                for (int i = 0; i < cBoxComm.Items.Count; i++)
                {
                    if (hpt1000.GetPLC() != null && cBoxComm.Items[i].ToString() == hpt1000.GetPLC().GetTypeComm().ToString())
                        cBoxComm.SelectedIndex = i;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private int GetSecond(DateTime aDateTime)
        {
            int aSec = 0;

            aSec = aDateTime.Hour * 3600 + aDateTime.Minute * 60 + aDateTime.Second;

            return aSec;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private void btnConnect_Click(object sender, EventArgs e)
        {
            int aRes = 0; //TO DO;

            if (hpt1000.GetPLC() != null)
                aRes = hpt1000.GetPLC().Connect();
        }
        //------------------------------------------------------------------------------------------
        private void cBoxComm_SelectedIndexChanged(object sender, EventArgs e)
        {
            lock (cBoxComm)
            {
                if (hpt1000.GetPLC() != null)
                {
                    if (cBoxComm.SelectedItem.ToString() == "USB")
                        hpt1000.GetPLC().SetTypeComm(Types.TypeComm.USB);
                    if (cBoxComm.SelectedItem.ToString() == "TCP")
                        hpt1000.GetPLC().SetTypeComm(Types.TypeComm.TCP);
                }
            }
        }
        //------------------------------------------------------------------------------------------
        private void timePumpToSV_ValueChanged(object sender, EventArgs e)
        {
            if (hpt1000.GetForePump() != null)
                hpt1000.GetForePump().SetTimePumpToSV(GetSecond(timePumpToSV.Value));
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private void timeWaitPF_ValueChanged(object sender, EventArgs e)
        {
            if (hpt1000.GetForePump() != null)
                hpt1000.GetForePump().SetTimeWaitPF((int)GetSecond(timeWaitPF.Value));
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void timeFlowStabilization_ValueChanged(object sender, EventArgs e)
        {
            if (hpt1000.GetMFC() != null)
                hpt1000.GetMFC().SetTimeFlowStability(GetSecond(timeFlowStabilization.Value));
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private bool dEditRangeVoltageMFC1_EnterOn()
        {
            bool aRes = false;

            if (hpt1000.GetMFC() != null)
            {
                if (!hpt1000.GetMFC().SetRangeVoltage(1, (int)dEditRangeVoltageMFC1.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private bool dEditRangeVoltageMFC2_EnterOn()
        {
            bool aRes = false;

            if (hpt1000.GetMFC() != null)
            {
                if (!hpt1000.GetMFC().SetRangeVoltage(2, (int)dEditRangeVoltageMFC2.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private bool dEditRangeVoltageMFC3_EnterOn()
        {
            bool aRes = false;

            if (hpt1000.GetMFC() != null)
            {
                if (!hpt1000.GetMFC().SetRangeVoltage(3, (int)dEditRangeVoltageMFC3.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void timeSetpointStabilization_ValueChanged(object sender, EventArgs e)
        {
            if (hpt1000.GetPowerSupply() != null)
                hpt1000.GetPowerSupply().SetWaitTimeSetpoint(GetSecond(timeSetpointStabilization.Value));
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void timeWaitOnOperate_ValueChanged(object sender, EventArgs e)
        {
            if (hpt1000.GetPowerSupply() != null)
                hpt1000.GetPowerSupply().SetWaitTimeOperate(GetSecond(timeWaitOnOperate.Value));
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private bool dEditRangeCurent_EnterOn()
        {
            bool aRes = false;

            if (hpt1000.GetPowerSupply() != null)
            {
                if (!hpt1000.GetPowerSupply().SetMaxCurent(dEditRangeCurent.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private bool dEditRangeVoltage_EnterOn()
        {
            bool aRes = false;

            if (hpt1000.GetPowerSupply() != null)
            {
                if (!hpt1000.GetPowerSupply().SetMaxVoltage(dEditRangeVoltage.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private bool dEditRangePower_EnterOn()
        {
            bool aRes = false;

            if (hpt1000.GetPowerSupply() != null)
            {
                if (!hpt1000.GetPowerSupply().SetMaxPower(dEditRangePower.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private bool dEditMaxFlow_MFC1_EnterOn()
        {
            bool aRes = false;

            if (hpt1000.GetMFC() != null)
            {
                if (!hpt1000.GetMFC().SetMaxFlow(1, (int)dEditMaxFlow_MFC1.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private bool dEditMaxFlow_MFC2_EnterOn()
        {
            bool aRes = false;

            if (hpt1000.GetMFC() != null)
            {
                if (!hpt1000.GetMFC().SetMaxFlow(2, (int)dEditMaxFlow_MFC2.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private bool dEditMaxFlow_MFC3_EnterOn()
        {
            bool aRes = false;

            if (hpt1000.GetMFC() != null)
            {
                if (!hpt1000.GetMFC().SetMaxFlow(3, (int)dEditMaxFlow_MFC3.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private bool dEditCurentLimit_EnterOn()
        {
            bool aRes = false;

            if (hpt1000.GetPowerSupply() != null)
            {
                if (!hpt1000.GetPowerSupply().SetLimitCurent(dEditCurentLimit.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private bool dEditVoltageLimit_EnterOn()
        {
            bool aRes = false;

            if (hpt1000.GetPowerSupply() != null)
            {
                if (!hpt1000.GetPowerSupply().SetLimitVoltage(dEditVoltageLimit.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private bool dEditPowerLimit_EnterOn()
        {
            bool aRes = false;

            if (hpt1000.GetPowerSupply() != null)
            {
                if (!hpt1000.GetPowerSupply().SetLimitPower(dEditPowerLimit.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void btnReadSettings_Click(object sender, EventArgs e)
        {
            if (hpt1000 != null)
                hpt1000.UpdateSettings();

            RefreshSettingsPanel();
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void cBoxComm_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            lock (cBoxComm)
            {
                if (hpt1000.GetPLC() != null)
                {
                    if (cBoxComm.SelectedItem.ToString() == "USB")
                        hpt1000.GetPLC().SetTypeComm(Types.TypeComm.USB);
                    if (cBoxComm.SelectedItem.ToString() == "TCP")
                        hpt1000.GetPLC().SetTypeComm(Types.TypeComm.TCP);

                }
            }
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
        private void cBoxDummyMode_CheckedChanged(object sender, EventArgs e)
        {
            if (hpt1000 != null && hpt1000.GetPLC() != null)
                hpt1000.GetPLC().SetDummyMode(cBoxDummyMode.Checked);

        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void cBoxGasType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GasType gasType = (GasType)cBoxGasType.SelectedItem;

            if (gasType != null)
            {
                tBoxGasDescription.Text = gasType.Description;
                dEditFactorGas.Value    = gasType.Factor;
                tBoxNameGas.Text        = gasType.Name;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            bool aError = true;

            GasType gasType = (GasType)cBoxGasType.SelectedItem;

            if (gasType != null)
            {
                if (tBoxNameGas.Text != "")
                {
                    gasType.Factor      = dEditFactorGas.Value;
                    gasType.Description = tBoxGasDescription.Text;
                    gasType.Name        = tBoxNameGas.Text;

                    int aSelectedInde = cBoxGasType.SelectedIndex;
                    FillComboBoxGases();
                    if (cBoxGasType.Items.Count > aSelectedInde)
                        cBoxGasType.SelectedIndex = aSelectedInde;

                    aError = false;
                    Source.Logger.AddMsg(Source.Translate.GetText("Ustawienia dla typu gazu " + gasType.Name + " zostal poprawnie zapisane"), Types.MessageType.Information);
                }
                else
                    Source.Logger.AddMsg(Source.Translate.GetText("Nie udalo sie zapisać zmian typu gazu. Pole Nazawa nie moze byc puste"), Types.MessageType.Error);
           }
            else
                Source.Logger.AddMsg(Source.Translate.GetText("Nie udalo sie zapisać zmian typu gazu. Nie wybrano gazu do edycji"), Types.MessageType.Error);

            if(aError)
            {
                tBoxGasDescription.Text = gasType.Description;
                dEditFactorGas.Value    = gasType.Factor;
                tBoxNameGas.Text        = gasType.Name;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void btnNewGas_Click(object sender, EventArgs e)
        {
            if (gasTypes != null)
            {
                GasType gasType = new GasType();

                gasType.Factor      = 1;
                gasType.Name        = "gas " + gasTypes.Items.Count.ToString();
                gasType.Description = "description ...";

                if (!gasTypes.Contains(gasType))
                {
                    gasTypes.Add(gasType);
                    cBoxGasType.Items.Add(gasType);

                    Source.Logger.AddMsg(Source.Translate.GetText("Typ gazu " + gasType.Name + " zostal poprawnie dodany"), Types.MessageType.Information);

                    cBoxGasType.Refresh();
                    cBoxGasType.SelectedIndex = cBoxGasType.Items.Count - 1;

                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void cBoxMFC_Click(object sender, EventArgs e)
        {
            if (hpt1000 != null)
            {
                hpt1000.GetMFC().SetActive(1, cBoxMFC1.Checked);
                hpt1000.GetMFC().SetActive(2, cBoxMFC2.Checked);
                hpt1000.GetMFC().SetActive(3, cBoxMFC3.Checked);
            }

            dEditMaxFlow_MFC1.Enabled = cBoxMFC1.Checked;
            dEditRangeVoltageMFC1.Enabled = cBoxMFC1.Checked;

            dEditMaxFlow_MFC2.Enabled = cBoxMFC2.Checked;
            dEditRangeVoltageMFC2.Enabled = cBoxMFC2.Checked;

            dEditMaxFlow_MFC3.Enabled = cBoxMFC3.Checked;
            dEditRangeVoltageMFC3.Enabled = cBoxMFC3.Checked;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void btnRemoveGas_Click(object sender, EventArgs e)
        {
            GasType gasType = (GasType)cBoxGasType.SelectedItem;

            if (gasType != null && gasTypes != null)
            {
                gasTypes.Remove(gasType);

                int aSelectedIndex = cBoxGasType.SelectedIndex;
                FillComboBoxGases();

                cBoxGasType.SelectedIndex = aSelectedIndex - 1;

                if(cBoxGasType.SelectedIndex < 0)
                {
                    tBoxNameGas.Text        = "";
                    tBoxGasDescription.Text = "";
                    dEditFactorGas.Value    = 0;
                }

                Source.Logger.AddMsg(Source.Translate.GetText("Typu gazu " + gasType.Name + " zostal poprawnie usuniety"), Types.MessageType.Information);
            }
            else
                Source.Logger.AddMsg(Source.Translate.GetText("Nie udalo sie usunac typu gazu. Typ gazu nie zostal wybrany"), Types.MessageType.Error);
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void timer_Tick(object sender, EventArgs e)
        {
            if (cBoxGasType.SelectedIndex == -1)
            {
                btnSaveSettings.Enabled = false;
                btnRemoveGas.Enabled    = false;
            }
            else
            {
                btnSaveSettings.Enabled = true;
                btnRemoveGas.Enabled    = true;
            }
        }
            //---------------------------------------------------------------------------------------------------------------------------
    }

}
