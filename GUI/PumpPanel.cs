using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPT1000.Source.Chamber;
using HPT1000.Source.Driver;
using HPT1000.Source;


namespace HPT1000.GUI
{
    public partial class PumpPanel : UserControl
    {
        private ForePump pump = null;

        //-----------------------------------------------------------------------------------------
        public PumpPanel()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------------------
        public void SetPumpPtr(ForePump pumpPtr)
        {
            pump = pumpPtr;
        }
        //-----------------------------------------------------------------------------------------
        public void RefreshData()
        {
            /*
            if (pump != null)
            {
                if (pump.GetState() == Types.StateFP.ON)
                {
                    labState.Text = "Fore pump state: Runnig";
                    labState.ForeColor = System.Drawing.Color.Green;
                }
                if (pump.GetState() == Types.StateFP.OFF)
                {
                    labState.Text = "Fore pump state: Stopped";
                    labState.ForeColor = System.Drawing.Color.Black;
                }
                if (pump.GetState() == Types.StateFP.Error)
                {
                    labState.Text = "Fore pump state: Error";
                    labState.ForeColor = System.Drawing.Color.Red;
                }
            }
            */
        }
        //-----------------------------------------------------------------------------------------
        private void btnStart_Click(object sender, EventArgs e)
        {
            ERROR aErr = new ERROR(0,0);
            if (pump != null)
            {
                aErr = pump.ControlPump(Types.StateFP.ON);
            }
            Logger.AddError(aErr);
        }
        //-----------------------------------------------------------------------------------------
        private void btnStop_Click(object sender, EventArgs e)
        {
            ERROR aErr = new ERROR(0,0);
            if (pump != null)
            {
                aErr = pump.ControlPump(Types.StateFP.OFF);
            }
            Logger.AddError(aErr);
        }
        //-----------------------------------------------------------------------------------------

    }
}
