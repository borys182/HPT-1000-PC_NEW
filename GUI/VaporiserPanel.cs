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
using HPT1000.Source;

namespace HPT1000.GUI
{
    public partial class VaporiserPanel : UserControl
    {
        Vaporizer vaporizer = null;

        //-----------------------------------------------------------------------------------
        public VaporiserPanel()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------------
        public void SetVaporizerPtr(Vaporizer vapPtr)
        {
            vaporizer = vapPtr;
        }
        //-----------------------------------------------------------------------------------
        public void RefreshData()
        {
            if (vaporizer != null)
            {
                tBoxCycleTime.Text  = vaporizer.GetCycleTime().ToString();
                tBoxOnTime.Text     = vaporizer.GetOnTime().ToString();
            }
        }
        //-----------------------------------------------------------------------------------
        private void btnSetCycleTime_Click(object sender, EventArgs e)
        {
            ERROR aErr = new ERROR(0);
            if(vaporizer != null)
            {
                float aCycleTiem = (float)Double.Parse(tBoxCycleTime.Text);
                aErr = vaporizer.SetCycleTime(aCycleTiem);
            }
           Logger.AddError(aErr);
        }
        //-----------------------------------------------------------------------------------
        private void btnSetOnTime_Click(object sender, EventArgs e)
        {
            ERROR aErr = new ERROR(0);
            if (vaporizer != null)
            {
                float aOnTiem = (float)Double.Parse(tBoxOnTime.Text);
                aErr = vaporizer.SetCycleTime(aOnTiem);
            }
            Logger.AddError(aErr);
        }
        //-----------------------------------------------------------------------------------
    }
}
