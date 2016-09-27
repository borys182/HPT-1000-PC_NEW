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
    public partial class PumpComponent : UserControl
    {

        ForePump pump = null;
        //-----------------------------------------------------------------------------------------
        public PumpComponent()
        {
            InitializeComponent();
            if (imageListPump.Images.Count > 0)
                picture.Image = imageListPump.Images[0];
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //-----------------------------------------------------------------------------------------
        public void SetPumpPtr(ForePump pumpPtr)
        {
            pump = pumpPtr;
        }
        //-----------------------------------------------------------------------------------------
        public void RefreshData()
        {
            if (pump != null)
            {
                switch (pump.GetState())
                {
                    case Types.StateFP.OFF:
                        if (imageListPump.Images.Count > 0)
                            picture.Image = imageListPump.Images[0];
                        break;
                    case Types.StateFP.ON:
                        if (imageListPump.Images.Count > 1)
                            picture.Image = imageListPump.Images[1];
                        break;
                    case Types.StateFP.Error:
                        if (imageListPump.Images.Count > 2)
                            picture.Image = imageListPump.Images[2];
                        break;
                }
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        //-----------------------------------------------------------------------------------------
        private void picture_Click(object sender, EventArgs e)
        {
            ERROR aErr = new ERROR(0);

            if (pump != null)
            {
                if (pump.GetState() == Types.StateFP.OFF)
                    aErr = pump.ControlPump(Types.StateFP.ON);

                if (pump.GetState() == Types.StateFP.ON)
                    aErr = pump.ControlPump(Types.StateFP.OFF);
            }
            Logger.AddError(aErr);
        }
        //-----------------------------------------------------------------------------------------
        private void picture_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        //-----------------------------------------------------------------------------------------
        private void picture_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
        //-----------------------------------------------------------------------------------------
    }
}
