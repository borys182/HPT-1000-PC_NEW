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
    public partial class GeneratorPanel : UserControl
    {
        private PowerSupplay generator          = null;
        private const int    setpointResolution = 1000;    //zmienna okresla z jaka dokladnosci mozna podawac setopinta

        //------------------------------------------------------------------------------------------
        public GeneratorPanel()
        {
            InitializeComponent();
            scrollSetpoint.Minimum = 1;
        }
        //------------------------------------------------------------------------------------------
        public void SetGeneratorPtr(PowerSupplay aGeneraotrPtr)
        {
            generator = aGeneraotrPtr;
        }
        //------------------------------------------------------------------------------------------
        public void RefreshData()
        {
            SetLimit();
            if(generator != null)
            {                    
                dEditActualPower.Value      = generator.Power;
                dEditActualVoltage.Value    = generator.Voltage;
                dEditActualCurent.Value     = generator.Curent;

                switch (generator.Mode)
                {
                    case Types.ModeHV.Power:
                        rBtnModePower.Checked = true;
                        labUnitSP.Text = "[W]";
                        break;
                    case Types.ModeHV.Curent:
                        rBtnModeCurent.Checked = true;
                        labUnitSP.Text = "[A]";
                        break;
                    case Types.ModeHV.Voltage:
                        rBtnModeVoltage.Checked = true;
                        labUnitSP.Text = "[V]";
                        break;
                }
                if (generator.State == Types.StateHV.ON)
                {
                    cBoxOperate.Checked   = true;
                    cBoxOperate.BackColor = Color.Green;
                    cBoxOperate.Text      = "Operate On";
                }
                if (generator.State == Types.StateHV.OFF)
                {
                    cBoxOperate.Checked   = false;
                    cBoxOperate.BackColor = Color.Silver;
                    cBoxOperate.Text      = "Operate Off";
                }
                if (generator.State == Types.StateHV.Error)
                {
                    cBoxOperate.Checked = false;
                    cBoxOperate.BackColor = Color.Red;
                    cBoxOperate.Text      = "Operate Off";
                }
            }
        }
        //------------------------------------------------------------------------------------------
        private void SetLimit()
        {
            double aLimitValue = 0;

            if(generator != null)
            {
                switch (generator.Mode)
                {
                    case Types.ModeHV.Power:
                        aLimitValue = generator.LimitPower;
                        break;
                    case Types.ModeHV.Curent:
                        aLimitValue = generator.LimitCurent;
                        break;
                    case Types.ModeHV.Voltage:
                        aLimitValue = generator.LimitVoltage;
                        break;
                }
            }
            dEditSetpoint.MaximumValue  = aLimitValue;
            scrollSetpoint.Maximum      = (int)(aLimitValue * setpointResolution);
        }
        //------------------------------------------------------------------------------------------
        private void radioButtonMode_Click(object sender, EventArgs e)
        {
            Types.ModeHV mode = Types.ModeHV.Unknown;
            ERROR aErr = new ERROR(0,0);

            if (rBtnModeCurent.Checked)  mode = Types.ModeHV.Curent;
            if (rBtnModeVoltage.Checked) mode = Types.ModeHV.Voltage;
            if (rBtnModePower.Checked)   mode = Types.ModeHV.Power;

            if (generator != null)
                aErr = generator.SetMode(mode);
            
            Logger.AddError(aErr);
        }
        //------------------------------------------------------------------------------------------
        private void cBoxOperate_Click(object sender, EventArgs e)
        {
            ERROR aErr = new ERROR(0,0);

            if (generator != null)
                aErr = generator.SetOperate(cBoxOperate.Checked);

            Logger.AddError(aErr);
        }
        //------------------------------------------------------------------------------------------
        private void SetScrollValue(double aValue)
        {
            int aValueScroll = (int)(aValue * setpointResolution);

            if (scrollSetpoint.Maximum >= aValueScroll && scrollSetpoint.Minimum <= aValueScroll)
                scrollSetpoint.Value = aValueScroll;
        }
        //------------------------------------------------------------------------------------------
        private bool dEditSetpoint_EnterOn()
        {
            bool aRes = false;
            ERROR aErr = new ERROR(0,0);

            if (generator != null)
                aErr = generator.SetSetpoint(dEditSetpoint.Value);

            SetScrollValue(dEditSetpoint.Value);

            Logger.AddError(aErr);

            if (aErr.ErrorCode == Types.ERROR_CODE.NONE && aErr.ErrorCodePLC == 0)
                aRes = true;

            return aRes;
        }
        //------------------------------------------------------------------------------------------
        private void scrollSetpoint_ValueChanged(object sender, EventArgs e)
        {
            double aValue = 0;

            if (setpointResolution > 0)
                aValue = (double)(scrollSetpoint.Value) / (double)(setpointResolution);

            dEditSetpoint.Value = aValue;

            dEditSetpoint.tBox_KeyUp(sender, new KeyEventArgs(Keys.Enter));
        }
        //------------------------------------------------------------------------------------------

    }
}
