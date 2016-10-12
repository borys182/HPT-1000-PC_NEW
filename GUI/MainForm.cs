﻿using System;
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
using HPT1000.Source;

namespace HPT1000.GUI
{
    ///<summary>
    ///Klasa jest odpowiedzialna za reprezentowanie glownego okna programu
    ///</summary>
    public partial class MainForm : Form
    {
        private Source.Driver.HPT1000 hpt1000 = new HPT1000.Source.Driver.HPT1000();

        ERROR lastError = new ERROR();

        int timerLastErrorShow = 0;

        //------------------------------------------------------------------------------------------
        public MainForm()
        {
            InitializeComponent();

            programsConfigPanel.HPT1000 = hpt1000;
            programPanel.HPT1000        = hpt1000;

            generatorPanel.SetGeneratorPtr(hpt1000.GetPowerSupply());
            pressurePanel.SetPresureControlPtr(hpt1000.GetPressureControl());
            pumpPanel.SetPumpPtr(hpt1000.GetForePump());
            vaporiserPanel.SetVaporizerPtr(hpt1000.GetVaporizer());
            mfcPanel1.SetMFC(hpt1000.GetMFC(),1);
            mfcPanel2.SetMFC(hpt1000.GetMFC(),2);
            mfcPanel3.SetMFC(hpt1000.GetMFC(),3);

            valve_Gas.SetValvePtr(hpt1000.GetValve(), Types.TypeValve.Gas);
            valve_Purge.SetValvePtr(hpt1000.GetValve(), Types.TypeValve.Purge);
            valve_SV.SetValvePtr(hpt1000.GetValve(), Types.TypeValve.SV);
            valve_Vent.SetValvePtr(hpt1000.GetValve(), Types.TypeValve.VV);

            pumpComponent.SetPumpPtr(hpt1000.GetForePump());

            //Dodaj obserwatorow
            Program.AddToRefreshList(new RefreshProgram(programPanel.RefreshProgram));
            Program.AddToRefreshList(new RefreshProgram(programsConfigPanel.RefreshProgram));
            Source.Driver.HPT1000.AddToRefreshList(new RefreshProgram(programPanel.RefreshProgram));
            Source.Driver.HPT1000.AddToRefreshList(new RefreshProgram(programsConfigPanel.RefreshProgram));

         }
        //------------------------------------------------------------------------------------------
        public void RefreshSettingsPanel()
        {
            if(hpt1000.GetPowerSupply() != null)
            {
                dEditCurentLimit.Value      = hpt1000.GetPowerSupply().LimitCurent;
                dEditPowerLimit.Value       = hpt1000.GetPowerSupply().LimitPower;
                dEditVoltageLimit.Value     = hpt1000.GetPowerSupply().LimitVoltage;
                dEditMaxPower.Value         = hpt1000.GetPowerSupply().MaxPower;
                dEditMaxCurent.Value        = hpt1000.GetPowerSupply().MaxCurent;
                dEditMaxVoltage.Value       = hpt1000.GetPowerSupply().MaxVoltage;
                dEditTimeWaitSetpoint.Value = hpt1000.GetPowerSupply().TimeWaitSetpoint;
                dEditTimeOperate.Value      = hpt1000.GetPowerSupply().TimeWaitOperate;
            }
            if (hpt1000.GetMFC() != null)
            {
                dEditMaxFlow_MFC1.Value     = hpt1000.GetMFC().GetMaxFlow(1);
                dEditMaxFlow_MFC2.Value     = hpt1000.GetMFC().GetMaxFlow(2);
                dEditMaxFlow_MFC3.Value     = hpt1000.GetMFC().GetMaxFlow(3);
                dEditRangeVoltageMFC1.Value = hpt1000.GetMFC().GetRangeVoltage(1);
                dEditRangeVoltageMFC2.Value = hpt1000.GetMFC().GetRangeVoltage(2);
                dEditRangeVoltageMFC3.Value = hpt1000.GetMFC().GetRangeVoltage(3);
                dEditFlowStability.Value    = hpt1000.GetMFC().TimeFlowStability;
            }
            if (hpt1000.GetForePump() != null)
            {
                dEditTimePumpToSV.Value     = hpt1000.GetForePump().TimePumpToSV;
                dEditTimeWaitPF.Value       = hpt1000.GetForePump().TimeWaitPF;
            }
        }
        //------------------------------------------------------------------------------------------
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
        private void btnGetState_Click(object sender, EventArgs e)
        {

            Types.StateValve state = hpt1000.GetValve().GetState(Types.TypeValve.SV);
        }
        //----------------------------------------------------------------------------------
        private void timer_Tick(object sender, EventArgs e)
        {
            //Odswiez panel programu
            programPanel.RefreshPanel();
            //Odswiezaj dane elementow komory na panelach systemu
            generatorPanel.RefreshData();
            pumpPanel.RefreshData();
            vaporiserPanel.RefreshData();
            pressurePanel.RefreshData();
            mfcPanel1.RefreshData();
            mfcPanel2.RefreshData();
            mfcPanel3.RefreshData();
            valve_Gas.RefreshData();
            valve_Purge.RefreshData();
            valve_SV.RefreshData();
            valve_Vent.RefreshData();
            pumpComponent.RefreshData();

            //Odswiez liste bledow
            ShowErrorList();

            switch (hpt1000.GetStatus())
            {
                case Types.DriverStatus.OK:
                    statusLabel.Text = "Communication OK";
                    statusLabel.ForeColor = Color.Blue;
                    break;
                case Types.DriverStatus.NoComm:
                    statusLabel.Text        = "No communication";
                    statusLabel.ForeColor   = Color.Red;
                    break;
            }
            //pokaz ostani blad jaki wystapil na dolnym pasku statusu
            ERROR aErr = Logger.GetLastError();
            if (aErr.IsError() && !aErr.Equals(lastError))
            {
                labLastError.Text  = "Error : " + aErr.GetErrorCode().ToString("X8") + " " + aErr.GetText();
                lastError = aErr;
                timerLastErrorShow = 0;
            }
            if (timerLastErrorShow > 50)
                labLastError.Text = "";
            timerLastErrorShow++;
    //        if(timerLastErrorShow > int.MaxI)
        }
        //----------------------------------------------------------------------------------
        private void ShowErrorList()
        {
            for (int i = 0; i < Logger.GetErrorList().Count; i++)
            {
                ERROR aErr = Logger.GetErrorList()[i];

                if (!IsErrorExist(aErr))
                {
                    ListViewItem aItem = new ListViewItem();
                    aItem.Text = "0x" + aErr.GetErrorCode().ToString("X8");
                    aItem.SubItems.Add(aErr.GetText());
                    aItem.SubItems.Add(aErr.Time.ToString());
                    aItem.Tag = aErr;

                    listViewErrors.Items.Add(aItem);
                }
            }
        }
        //----------------------------------------------------------------------------------
        private bool IsErrorExist(ERROR aErr)
        {
            bool aRes = false;

            foreach (ListViewItem aItem in listViewErrors.Items)
            {
                if (aErr.Equals(aItem.Tag))
                    aRes = true;
            }
            return aRes;
        }
        //----------------------------------------------------------------------------------
        private void cBoxComm_SelectedValueChanged(object sender, EventArgs e)
        {
            lock (cBoxComm)
            {
                if (hpt1000.GetPLC() != null)
                {
                    if (cBoxComm.SelectedItem.ToString() == "USB")
                        hpt1000.GetPLC().SetTypeComm(TypeComm.USB);
                    if (cBoxComm.SelectedItem.ToString() == "TCP")
                        hpt1000.GetPLC().SetTypeComm(TypeComm.TCP);
                }
            }
        }
        //----------------------------------------------------------------------------------
        private void btnReadSettings_Click(object sender, EventArgs e)
        {
            if (hpt1000 != null)
                hpt1000.UpdateSettings();

            RefreshSettingsPanel();
        }
        //----------------------------------------------------------------------------------
        private bool dEditPowerLimit_EnterOn()
        {
            bool aRes = false;
            ERROR aErr = new ERROR();

            if (hpt1000.GetPowerSupply() != null)
                aErr = hpt1000.GetPowerSupply().SetLimitPower(dEditPowerLimit.Value);

            Logger.AddError(aErr);

            if (!aErr.IsError())
                aRes = true;

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditVoltageLimit_EnterOn()
        {
            bool aRes = false;
            ERROR aErr = new ERROR();

            if (hpt1000.GetPowerSupply() != null)
                aErr = hpt1000.GetPowerSupply().SetLimitVoltage(dEditVoltageLimit.Value);

            Logger.AddError(aErr);

            if (!aErr.IsError())
                aRes = true;

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditCurentLimit_EnterOn()
        {
            bool aRes = false;
            ERROR aErr = new ERROR();

            if (hpt1000.GetPowerSupply() != null)
                aErr = hpt1000.GetPowerSupply().SetLimitCurent(dEditCurentLimit.Value);

            Logger.AddError(aErr);

            if (!aErr.IsError())
                aRes = true;

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditMaxFlow_MFC1_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetMFC() != null)
            {
                hpt1000.GetMFC().SetMaxFlow(1, (int)dEditMaxFlow_MFC1.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditMaxFlow_MFC2_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetMFC() != null)
            {
                hpt1000.GetMFC().SetMaxFlow(2, (int)dEditMaxFlow_MFC2.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditMaxFlow_MFC3_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetMFC() != null)
            {
                hpt1000.GetMFC().SetMaxFlow(3, (int)dEditMaxFlow_MFC3.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditMaxPower_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetPowerSupply() != null)
            {
                hpt1000.GetPowerSupply().SetMaxPower(dEditMaxPower.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditMaxVoltage_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetPowerSupply() != null)
            {
                hpt1000.GetPowerSupply().SetMaxVoltage(dEditMaxVoltage.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditMaxCurent_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetPowerSupply() != null)
            {
                hpt1000.GetPowerSupply().SetMaxCurent(dEditMaxCurent.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditTimeOperate_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetPowerSupply() != null)
            {
                hpt1000.GetPowerSupply().SetWaitTimeOperate((int)dEditTimeOperate.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditTimeWaitSetpoint_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetPowerSupply() != null)
            {
                hpt1000.GetPowerSupply().SetWaitTimeSetpoint((int)dEditTimeWaitSetpoint.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditRangeVoltageMFC1_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetMFC() != null)
            {
                hpt1000.GetMFC().SetRangeVoltage(1,(int)dEditRangeVoltageMFC1.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditRangeVoltageMFC2_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetMFC() != null)
            {
                hpt1000.GetMFC().SetRangeVoltage(2, (int)dEditRangeVoltageMFC2.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditRangeVoltageMFC3_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetMFC() != null)
            {
                hpt1000.GetMFC().SetRangeVoltage(3, (int)dEditRangeVoltageMFC3.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditFlowStability_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetMFC() != null)
            {
                hpt1000.GetMFC().SetTimeFlowStability((int)dEditFlowStability.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditTimeWaitPF_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetForePump() != null)
            {
                hpt1000.GetForePump().SetTimeWaitPF((int)dEditTimeWaitPF.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private bool dEditTimePumpToSV_EnterOn()
        {
            bool aRes = true;

            if (hpt1000.GetForePump() != null)
            {
                hpt1000.GetForePump().SetTimePumpToSV((int)dEditTimePumpToSV.Value);
                aRes = true;
            }

            return aRes;
        }
        //----------------------------------------------------------------------------------
        private void btnConnect_Click(object sender, EventArgs e)
        {
            int aRes = 0;

            if (hpt1000.GetPLC() != null)
                aRes = hpt1000.GetPLC().Connect();
        }
        //----------------------------------------------------------------------------------
    }
}
