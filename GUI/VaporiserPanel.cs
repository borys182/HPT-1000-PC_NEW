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
        Vaporizer vaporizer     = null;
        bool      aUnitPercent  = true;   //flaga okresla czy mam pokazywac jednostki w procentach czy ms

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
                dEditCycleTImne.Value  = vaporizer.GetCycleTime();

                if(aUnitPercent)
                    dEditOnTime.Value = vaporizer.GetOnTime(Types.UnitFlow.percent);
                else
                    dEditOnTime.Value = vaporizer.GetOnTime(Types.UnitFlow.ms);
            }
            RefreshUnit();
        }
        //-----------------------------------------------------------------------------------
        private void RefreshUnit()
        {
            if (aUnitPercent)
            {
                labUnit.Text = "[%]";
                dEditOnTime.Mask = "{0:F2}";
                dEditOnTime.MaximumValue = 100;
            }
            else
            {
                labUnit.Text = "[ms]";
                dEditOnTime.Mask = "{0:F3}";
                dEditOnTime.MaximumValue = 100000;
            }
        }
        //-----------------------------------------------------------------------------------
        private void labUnit_Click(object sender, EventArgs e)
        {
            aUnitPercent = !aUnitPercent;
            RefreshUnit();
        }
        //-----------------------------------------------------------------------------------
        private bool dEditOnTime_EnterOn()
        {
            bool aRes = false;
            ERROR aErr = new ERROR(0,0);
            Types.UnitFlow aUnit = Types.UnitFlow.ms;

            if (vaporizer != null)
            {
                if (aUnitPercent) aUnit = Types.UnitFlow.percent;

                aErr = vaporizer.SetOnTime((float)dEditOnTime.Value, aUnit);
            }
            Logger.AddError(aErr);

            if (aErr.ErrorCode == Types.ERROR_CODE.NONE && aErr.ErrorCodePLC == 0)
                aRes = true;

            return aRes;
        }
        //-----------------------------------------------------------------------------------
        private bool dEditCycleTImne_EnterOn()
        {
            bool aRes = false;
            ERROR aErr = new ERROR(0,0);
            if (vaporizer != null)
            {
                aErr = vaporizer.SetCycleTime((float)dEditCycleTImne.Value);
            }
            Logger.AddError(aErr);

            if (aErr.ErrorCode == Types.ERROR_CODE.NONE && aErr.ErrorCodePLC == 0)
                aRes = true;

            return aRes;
        }
        //-----------------------------------------------------------------------------------
        private void labUnit_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        //-----------------------------------------------------------------------------------
        private void labUnit_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
        //-----------------------------------------------------------------------------------
    }
}
