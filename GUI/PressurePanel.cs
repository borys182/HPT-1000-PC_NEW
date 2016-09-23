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
        PressureControl      presureControl     = null;
        private const double pressureResolution = 1000;    //zmienna okresla ile miejsc po przecinku mozna wprowadzac do zmiennych presure
        private const double maxPressure        = 1000;     //max wartosc mozliwa do wpisania
        //-----------------------------------------------------------------------------------------
        public PressurePanel()
        {
            InitializeComponent();

            scrollPressure.Minimum = 1;
            scrollPressure.Maximum = (int)(maxPressure * pressureResolution);

            dEditSetpoint.MinimumValue = 1 / pressureResolution;
            dEditSetpoint.MaximumValue = maxPressure;
        }
        //-----------------------------------------------------------------------------------------
        public void RefreshData()
        {
            if(presureControl != null)
            {
                dEditActulaPressure.Value = presureControl.GetPressure();

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
                if (presureControl.GetMode() == Types.GasProcesMode.Unknown || presureControl.GetMode() == Types.GasProcesMode.FlowSP)
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
        private void SetScrollValue(double aValue)
        {
            int aValueScroll = (int)(aValue * pressureResolution);

            if (scrollPressure.Maximum >= aValueScroll && scrollPressure.Minimum <= aValueScroll)
                scrollPressure.Value = aValueScroll;
        }
        //-----------------------------------------------------------------------------------------
        private void scrollPressure_ValueChanged(object sender, EventArgs e)
        {
            double aValue = 0;

            if (pressureResolution > 0)
                aValue = scrollPressure.Value / pressureResolution;

            dEditSetpoint.Value = aValue;
            
            dEditSetpoint.tBox_KeyUp(sender, new KeyEventArgs(Keys.Enter));
        }
        //-----------------------------------------------------------------------------------------
        private bool dEditSetpoint_EnterOn()
        {
            bool  aRes = false;
            ERROR aErr = new ERROR(0);

            if (presureControl != null)
                aErr = presureControl.SetSetpoint(dEditSetpoint.Value);

            if (aErr.ErrorCode == Types.ERROR_CODE.NONE && aErr.ErrorCodePLC == 0)
                aRes = true;
            
            SetScrollValue(dEditSetpoint.Value);

            Logger.AddError(aErr);

            return aRes;
        }
        //-----------------------------------------------------------------------------------------
        private void cBoxGases_Click(object sender, EventArgs e)
        {
            ERROR aErr = new ERROR(0);
            if (presureControl != null)
            {
                if (cBoxGases.Checked)
                    aErr = presureControl.SetMode(Types.GasProcesMode.Presure_MFC);

                if (cBoxVaporizer.Checked)
                    aErr = presureControl.SetMode(Types.GasProcesMode.Pressure_Vap);

                if (!cBoxVaporizer.Checked && !cBoxGases.Checked)
                    aErr = presureControl.SetMode(Types.GasProcesMode.FlowSP);
            }
            Logger.AddError(aErr);
        }
        //-----------------------------------------------------------------------------------------

    }
}
