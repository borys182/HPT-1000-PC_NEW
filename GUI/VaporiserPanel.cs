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
        bool      unitPercent  = true;   //flaga okresla czy mam pokazywac jednostki w procentach czy ms

        int       timeWaitOnRefresh = 30; //3 s
        int       timerRefresh      = 0;
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
            if (vaporizer != null && timerRefresh > timeWaitOnRefresh)
            {
                dEditCycleTImne.Value  = (double)vaporizer.GetCycleTime() / 1000.0;

                if(unitPercent)
                    dEditOnTime.Value = vaporizer.GetOnTime(Types.UnitFlow.percent);
                else
                    dEditOnTime.Value = (double)vaporizer.GetOnTime(Types.UnitFlow.ms) / 1000.0;
            }

            if (timerRefresh <= timeWaitOnRefresh)
                timerRefresh++;

            RefreshUnit();
        }
        //-----------------------------------------------------------------------------------
        private void RefreshUnit()
        {
            if (unitPercent)
            {
                labUnit.Text = "[%]";
      //          dEditOnTime.Mask = "{0:F2}";
                dEditOnTime.MaximumValue = 100;
            }
            else
            {
                labUnit.Text = "[sec]";
        //        dEditOnTime.Mask = "{0:F3}";
                dEditOnTime.MaximumValue = 100000;
            }
        }
        //-----------------------------------------------------------------------------------
        private void labUnit_Click(object sender, EventArgs e)
        {
            unitPercent = !unitPercent;
            RefreshUnit();
        }
        //-----------------------------------------------------------------------------------
        private bool dEditOnTime_EnterOn()
        {
            bool aRes = false;
            ItemLogger aErr = new ItemLogger();

            if (vaporizer != null)
            {
                float           aValue = (float)dEditOnTime.Value;
                Types.UnitFlow  aUnit  = Types.UnitFlow.ms;

                if (unitPercent) aUnit = Types.UnitFlow.percent;
                else aValue *= 1000; //przlicz s na ms

                aErr = vaporizer.SetOnTime(aValue , aUnit);
            }
            Logger.AddError(aErr);

            if (!aErr.IsError())
            {
                aRes = true;
                timerRefresh = 0;
            }
            return aRes;
        }
        //-----------------------------------------------------------------------------------
        private bool dEditCycleTImne_EnterOn()
        {
            bool aRes = false;
            ItemLogger aErr = new ItemLogger();
            if (vaporizer != null)
            {
                aErr = vaporizer.SetCycleTime((float)dEditCycleTImne.Value * 1000); // poniewa z formatki dane wprowadzam w sec musze je przeliczyc na ms
            }
            Logger.AddError(aErr);

            if (!aErr.IsError())
            {
                aRes = true;
                timerRefresh = 0;
            }
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
