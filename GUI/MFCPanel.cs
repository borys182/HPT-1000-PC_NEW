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
        MFC_Channel mfc_Channel     = null;
        
        //-----------------------------------------------------------------------------------------
        public MFCPanel()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------------------
        public void RefreshData()
        {
            if (mfc_Channel != null)
            {
                tBoxActualFlow_percent.Text = mfc_Channel.GetActualFlow(Types.UnitFlow.percent).ToString();
                tBoxActualFlow_sccm.Text    = mfc_Channel.GetActualFlow(Types.UnitFlow.sccm).ToString();
            }
        }
        //-----------------------------------------------------------------------------------------
        public void SetMFC(MFC_Channel aMFCPtr)
        {
            mfc_Channel = aMFCPtr;
        }
        //-----------------------------------------------------------------------------------------
        private void tBoxFlow_sccm_Validated(object sender, EventArgs e)
        {
            if(mfc_Channel != null)
            {
                double aFlow = Double.Parse(tBoxFlow_sccm.Text);
                mfc_Channel.SetFlow((float)aFlow, Types.UnitFlow.sccm);
            }
        }
        //-----------------------------------------------------------------------------------------
        private void tBoxFlow_percent_Validated(object sender, EventArgs e)
        {
            if (mfc_Channel != null)
            {
                double aFlow = Double.Parse(tBoxFlow_percent.Text);
                mfc_Channel.SetFlow((float)aFlow, Types.UnitFlow.percent);
            }
        }
        //-----------------------------------------------------------------------------------------

    }
}
