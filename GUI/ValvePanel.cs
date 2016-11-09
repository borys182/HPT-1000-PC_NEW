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
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            LoadBitmap();
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
            LoadBitmap();
        }
        //-----------------------------------------------------------------------------------------
        private void LoadBitmap()
        {
            Bitmap valvePicture = new Bitmap(Properties.Resources.ValveError);

            if (valve != null)
            {
                if (valve.GetState(typeValve) == Types.StateValve.Close)
                    valvePicture = new Bitmap(Properties.Resources.ValveClose);

                if (valve.GetState(typeValve) == Types.StateValve.Open)
                    valvePicture = new Bitmap(Properties.Resources.ValveOpen);
            }
            valvePicture.MakeTransparent(Color.White);
            picture.Image = valvePicture;
        }
        //-----------------------------------------------------------------------------------------
        private void picture_Click(object sender, EventArgs e)
        {
            ItemLogger aErr = new ItemLogger();

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
