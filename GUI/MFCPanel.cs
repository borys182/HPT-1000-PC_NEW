using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPT1000.Source;
using HPT1000.Source.Driver;
using HPT1000.Source.Chamber;


namespace HPT1000.GUI
{
    public partial class MFCPanel : UserControl
    {
        MFC      mfc        = null;
        GasTypes gasTypes   = null;
        int      channelId  = 0;

        int timerRefresh        = 0;
        int timeWaitOnRefresh   = 30;//3[s]
        
        //-----------------------------------------------------------------------------------------
        public MFCPanel()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------------------
        public void RefreshData()
        {
            if (mfc != null)
            {
                dEditActualFlow_percent.Value   = mfc.GetActualFlow(channelId,Types.UnitFlow.percent);
                dEditActualFlow_sccm.Value      = mfc.GetActualFlow(channelId,Types.UnitFlow.sccm);

                if(timerRefresh > timeWaitOnRefresh)
                {
                    dEditFlow_sccm.Value    = mfc.GetSetpoint(channelId, Types.UnitFlow.sccm);
                    dEditFlow_percent.Value = mfc.GetSetpoint(channelId, Types.UnitFlow.percent);
                }

                if (timerRefresh <= timeWaitOnRefresh)
                    timerRefresh++;

                ShowGasType();
            }
            SetLimit();
        }
        //-----------------------------------------------------------------------------------------
        public void RefreshGasType()
        {
            if (gasTypes != null && !cBoxGasType.Focused)
            {
                cBoxGasType.Items.Clear();
                foreach (GasType gasType in gasTypes.Items)
                {
                    cBoxGasType.Items.Add(gasType);
                }
                ShowGasType();
            }
        }
        //-----------------------------------------------------------------------------------------
        private void ShowGasType()
        {
            //Nie odsiwezaj gdy kist jest rozwinieta. Robie to sprawdzajac czy focusa nie posiadaja dzieci zas gdy focus jest na Parencie to mozna odswiezac
            if(mfc != null && (!cBoxGasType.ContainsFocus))
            {
                for (int i = 0; i < cBoxGasType.Items.Count; i++)
                {
                    GasType gasType = (GasType)cBoxGasType.Items[i];
                    if (gasType != null && gasType.Equals(mfc.GetGasType(channelId)))
                        cBoxGasType.SelectedIndex = i;
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public void SetMFC(MFC aMFCPtr, GasTypes aGasTypes ,int aChannelID)
        {
            mfc         = aMFCPtr;
            gasTypes    = aGasTypes;

            channelId   = aChannelID;
            labNameMFC.Text = "MFC " + aChannelID.ToString();          
        }
        //-----------------------------------------------------------------------------------------
        private void SetLimit()
        {
            if (mfc != null)
            {
                scrollFlow.Maximum          = (int)mfc.GetMaxFlow(channelId);
                dEditFlow_sccm.MaximumValue = (int)mfc.GetMaxFlow(channelId);
            }
        }
        //-----------------------------------------------------------------------------------------
        private void SetScrollValue(int aValue)
        {
            if (aValue <= scrollFlow.Maximum && aValue >= scrollFlow.Minimum)
                scrollFlow.Value = aValue;
        }
        //-----------------------------------------------------------------------------------------
        private void scrollFlow_ValueChanged(object sender, EventArgs e)
        {
            dEditFlow_sccm.Value = scrollFlow.Value;

            dEditFlow_sccm.tBox_KeyUp(sender, new KeyEventArgs(Keys.Enter));
        }
        //-----------------------------------------------------------------------------------------
        private bool dEditFlow_sccm_EnterOn()
        {
            bool aRes = false;
            ERROR aErr = new ERROR();

            if (mfc != null)
                aErr = mfc.SetFlow(channelId, (int)dEditFlow_sccm.Value, Types.UnitFlow.sccm);

            if (!aErr.IsError())
            {
                aRes = true;
                timerRefresh = 0;
            }
            SetScrollValue((int)dEditFlow_sccm.Value);

            Logger.AddError(aErr);

            return aRes;
        }
        //-----------------------------------------------------------------------------------------
        private bool dEditFlow_percent_EnterOn()
        {
            bool aRes = false;
            ERROR aErr = new ERROR();

            if (mfc != null)
                aErr = mfc.SetFlow(channelId, (int)dEditFlow_percent.Value, Types.UnitFlow.percent);

            if (!aErr.IsError())
            {
                aRes = true;
                timerRefresh = 0;
            }
           Logger.AddError(aErr);

            return aRes;
        }
        //-----------------------------------------------------------------------------------------
        private void cBoxGasType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mfc != null)
            {
                GasType gasType = (GasType)cBoxGasType.SelectedItem;
                mfc.SetGasType(channelId, gasType);
            }
        }
        //-----------------------------------------------------------------------------------------

    }
}
