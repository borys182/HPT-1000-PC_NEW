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
        private PowerSupplay generator = null;

        //------------------------------------------------------------------------------------------
        public GeneratorPanel()
        {
            InitializeComponent();
        }
        //------------------------------------------------------------------------------------------
        public void SetGeneratorPtr(PowerSupplay aGeneraotrPtr)
        {
            generator = aGeneraotrPtr;
        }
        //------------------------------------------------------------------------------------------
        public void RefreshData()
        {
            if(generator != null)
            {                    
                tBoxActualPower.Text    = generator.GetPower().ToString();
                tBoxActualVoltage.Text  = generator.GetVoltage().ToString();
                tBoxActualCurent.Text   = generator.GetCurent().ToString();

                switch (generator.GetMode())
                {
                    case Types.ModeHV.Power:
                        rBtnModePower.Checked = true;
                        labUnitSP.Text = "W";
                        break;
                    case Types.ModeHV.Curent:
                        rBtnModePower.Checked = true;
                        labUnitSP.Text = "A";
                        break;
                    case Types.ModeHV.Voltage:
                        rBtnModePower.Checked = true;
                        labUnitSP.Text = "V";
                        break;
                }
                if (generator.GetState() == Types.StateHV.ON)
                {
                    cBoxOperate.Checked = true;
                    cBoxOperate.BackColor = System.Drawing.Color.Green;
                }
                if (generator.GetState() == Types.StateHV.OFF)
                {
                    cBoxOperate.Checked = false;
                    cBoxOperate.BackColor = System.Drawing.Color.Moccasin;
                }
                if (generator.GetState() == Types.StateHV.Error)
                {
                    cBoxOperate.Checked = false;
                    cBoxOperate.BackColor = System.Drawing.Color.Red;
                }
            }
        }
        //------------------------------------------------------------------------------------------
        //---------------------Obsluga zdarzen-------------------------
        private void radioButtonMode_Click(object sender, EventArgs e)
        {
            Types.ModeHV mode = Types.ModeHV.Unknown;
            ERROR aErr = new ERROR(0);

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
            ERROR aErr = new ERROR(0);

            if (generator != null)
                aErr = generator.SetOperate(cBoxOperate.Checked);

            Logger.AddError(aErr);
        }
        //------------------------------------------------------------------------------------------
        private void btnSetSetpoint_Click(object sender, EventArgs e)
        {
            ERROR aErr = new ERROR(0);

            if (generator != null)
                aErr = generator.SetOperate(cBoxOperate.Checked);

            Logger.AddError(aErr);
        }
        //------------------------------------------------------------------------------------------

    }
}
