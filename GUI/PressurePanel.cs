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
    public partial class PressurePanel : UserControl
    {
        PressureControl presureControl = null;

        //-----------------------------------------------------------------------------------------
        public PressurePanel()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------------------
        public void RefreshData()
        {
            if(presureControl != null)
            {
                tBoxActulaPressure.Text = presureControl.GetPressure().ToString();

                if (presureControl.GetMode() == Types.GasProcesMode.Pressure_Vap)
                {
                    cBoxVaporizer.Checked   = true;
                    cBoxGases.Checked       = false;
                }
                if (presureControl.GetMode() == Types.GasProcesMode.Presure_MFC)
                {
                    cBoxVaporizer.Checked   = false;
                    cBoxGases.Checked       = true;
                }
                if (presureControl.GetMode() == Types.GasProcesMode.Unknown && presureControl.GetMode() == Types.GasProcesMode.FlowSP)
                {
                    cBoxVaporizer.Checked   = false;
                    cBoxGases.Checked       = false;
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public void SetPresureControlPtr(PressureControl presurePtr)
        {
            presureControl = presurePtr;
        }
        //-----------------------------------------------------------------------------------------
        private void cBoxGases_Click(object sender, EventArgs e)
        {
            ERROR aErr = new ERROR(0);
            if(presureControl != null)
            {
                if (cBoxGases.Checked)
                    presureControl.SetMode(Types.GasProcesMode.Presure_MFC);
                if (cBoxVaporizer.Checked)
                    presureControl.SetMode(Types.GasProcesMode.Pressure_Vap);
            }
            Logger.AddError(aErr);
        }
        //-----------------------------------------------------------------------------------------
        private void tBoxSetpoint_Validated(object sender, EventArgs e)
        {
            ERROR aErr = new ERROR(0);
            double aSetpoint = Double.Parse(tBoxSetpoint.Text);

            if (presureControl != null)
                presureControl.SetSetpoint(aSetpoint);

           Logger.AddError(aErr);
        }
        //-----------------------------------------------------------------------------------------

    }
}
