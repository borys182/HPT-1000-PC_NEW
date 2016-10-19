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
    public partial class ValvePanel : UserControl
    {
        Types.TypeValve   typeValve    = Types.TypeValve.None;
        Valve                           valve        = null;

        //-----------------------------------------------------------------------------------------
        public ValvePanel()
        {
            InitializeComponent();
            if (imageList_Valve.Images.Count > 0)
                picture.Image = imageList_Valve.Images[0];
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        //-----------------------------------------------------------------------------------------
        public void SetValvePtr(Valve aValve, Source.Driver.Types.TypeValve aTypeValve)
        {
            valve       = aValve;
            typeValve   = aTypeValve;
        }
        //-----------------------------------------------------------------------------------------
        public void RefreshData()
        {
            if (valve != null)
            {
                switch (valve.GetState(typeValve))
                {
                    case Source.Driver.Types.StateValve.Close:
                        if (imageList_Valve.Images.Count > 0)
                            picture.Image = imageList_Valve.Images[0];
                        break;
                    case Source.Driver.Types.StateValve.Open:
                        if (imageList_Valve.Images.Count > 1)
                            picture.Image = imageList_Valve.Images[1];
                        break;
                    case Source.Driver.Types.StateValve.Error:
                        if (imageList_Valve.Images.Count > 2)
                            picture.Image = imageList_Valve.Images[2];
                        break;
                }
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                LoadBitmap();
            }
        }
        //-----------------------------------------------------------------------------------------
        private void LoadBitmap()
        {
            Bitmap valvePicture = new Bitmap("d:\\Projekty\\HPT-1000\\HPT-1000_PC\\Images\\ValveError.png");

            if ( valve.GetState(typeValve) == Types.StateValve.Close)
                valvePicture = new Bitmap("d:\\Projekty\\HPT-1000\\HPT-1000_PC\\Images\\ValveClose.png");

            if (valve.GetState(typeValve) == Types.StateValve.Open)
                valvePicture = new Bitmap("d:\\Projekty\\HPT-1000\\HPT-1000_PC\\Images\\ValveOpen.png");

            valvePicture.MakeTransparent(Color.White);
            picture.Image = valvePicture;
        }
        //-----------------------------------------------------------------------------------------
        private void picture_Click(object sender, EventArgs e)
        {
            ERROR aErr = new ERROR();

            if (valve != null)
            {
                if(valve.GetState(typeValve) == Types.StateValve.Close)
                    aErr = valve.SetState(Source.Driver.Types.StateValve.Open, typeValve);

                if (valve.GetState(typeValve) == Types.StateValve.Open)
                    aErr = valve.SetState(Source.Driver.Types.StateValve.Close, typeValve);
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
