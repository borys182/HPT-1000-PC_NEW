using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPT1000.Source.Driver;
using HPT1000.Source.Chamber;
using HPT1000.Source.Program;
using HPT1000.Source;

namespace HPT1000.GUI
{
    ///<summary>
    ///Klasa jest odpowiedzialna za reprezentowanie glownego okna programu
    ///</summary>
    public partial class MainForm : Form
    {
        private Source.Driver.HPT1000 hpt1000 = new HPT1000.Source.Driver.HPT1000();

        ERROR lastError = new ERROR();

        int timerLastErrorShow = 0;

        //------------------------------------------------------------------------------------------
        public MainForm()
        {
            InitializeComponent();

            programsConfigPanel.HPT1000 = hpt1000;
            programPanel.HPT1000        = hpt1000;
            alertsPanel.HPT1000         = hpt1000;
            settingsPanel.SetPtrHPT(hpt1000);
            
            generatorPanel.SetGeneratorPtr(hpt1000.GetPowerSupply());
            pressurePanel.SetPresureControlPtr(hpt1000.GetPressureControl());
            pumpPanel.SetPumpPtr(hpt1000.GetForePump());
            vaporiserPanel.SetVaporizerPtr(hpt1000.GetVaporizer());
            mfcPanel1.SetMFC(hpt1000.GetMFC(),1);
            mfcPanel2.SetMFC(hpt1000.GetMFC(),2);
            mfcPanel3.SetMFC(hpt1000.GetMFC(),3);

            valve_Gas.SetValvePtr(hpt1000.GetValve(), Types.TypeValve.Gas);
            valve_Purge.SetValvePtr(hpt1000.GetValve(), Types.TypeValve.Purge);
            valve_SV.SetValvePtr(hpt1000.GetValve(), Types.TypeValve.SV);
            valve_Vent.SetValvePtr(hpt1000.GetValve(), Types.TypeValve.VV);

            pumpComponent.SetPumpPtr(hpt1000.GetForePump());

            //Dodaj obserwatorow
            Program.AddToRefreshList(new RefreshProgram(programPanel.RefreshProgram));
            Program.AddToRefreshList(new RefreshProgram(programsConfigPanel.RefreshProgram));
            Source.Driver.HPT1000.AddToRefreshList(new RefreshProgram(programPanel.RefreshProgram));
            Source.Driver.HPT1000.AddToRefreshList(new RefreshProgram(programsConfigPanel.RefreshProgram));

            //Ustaw odpowidnie obrazki dla SystemWindow
            LoadBitmap();

        }
        //------------------------------------------------------------------------------------------
        private void LoadBitmap()
        {
            Bitmap chamber      = new Bitmap("d:\\Projekty\\HPT-1000\\HPT-1000_PC\\Images\\Plasma.jpg");
            Bitmap arrowUp      = new Bitmap("d:\\Projekty\\HPT-1000\\HPT-1000_PC\\Images\\Arrow_Up.png");
            Bitmap arrowDown    = new Bitmap("d:\\Projekty\\HPT-1000\\HPT-1000_PC\\Images\\Arrow_Down.png");
            Bitmap cornerUp     = new Bitmap("d:\\Projekty\\HPT-1000\\HPT-1000_PC\\Images\\Corner_Right_Top.png");
            Bitmap cornerDown   = new Bitmap("d:\\Projekty\\HPT-1000\\HPT-1000_PC\\Images\\Corner_Right_Bottom.png");

            chamber.MakeTransparent(Color.White);
            arrowUp.MakeTransparent(Color.White);
            arrowDown.MakeTransparent(Color.White);
            cornerUp.MakeTransparent(Color.White);
            cornerDown.MakeTransparent(Color.White);

            pictureChamber.Image = chamber;
            pictureChamber.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureArrowUp1.Image = arrowUp;
            pictureArrowUp2.Image = arrowUp;

            pictureArrowDown.Image = arrowDown;

            pictureCornerUp1.Image = cornerUp;
            pictureCornerUp2.Image = cornerUp;
            pictureCornerUp3.Image = cornerUp;

            pictureCornerDown1.Image = cornerDown;
            pictureCornerDown2.Image = cornerDown;
            pictureCornerDown3.Image = cornerDown;
        }
        //------------------------------------------------------------------------------------------
        private void btnGetState_Click(object sender, EventArgs e)
        {

            Types.StateValve state = hpt1000.GetValve().GetState(Types.TypeValve.SV);
        }
        //----------------------------------------------------------------------------------
        private void timer_Tick(object sender, EventArgs e)
        {
            //Odswiez panel programu
            programPanel.RefreshPanel();
            //Odswiezaj dane elementow komory na panelach systemu
            generatorPanel.RefreshData();
            pumpPanel.RefreshData();
            vaporiserPanel.RefreshData();
            pressurePanel.RefreshData();
            mfcPanel1.RefreshData();
            mfcPanel2.RefreshData();
            mfcPanel3.RefreshData();
            valve_Gas.RefreshData();
            valve_Purge.RefreshData();
            valve_SV.RefreshData();
            valve_Vent.RefreshData();
            pumpComponent.RefreshData();
            alertsPanel.RefreshPanel();

            switch (hpt1000.GetStatus())
            {
                case Types.DriverStatus.OK:
                    statusLabel.Text = "Communication OK";
                    statusLabel.ForeColor = Color.Blue;
                    break;
                case Types.DriverStatus.NoComm:
                    statusLabel.Text        = "No communication";
                    statusLabel.ForeColor   = Color.Red;
                    break;
                case Types.DriverStatus.DummyMode:
                    statusLabel.Text = "Dummy mode";
                    statusLabel.ForeColor = Color.Blue;
                    break;
            }
            //pokaz wynik ostatniej akcji jaka wystapila w systemie na dolnym pasku statusu
            ShowLastActionStatus();
        }
        //----------------------------------------------------------------------------------
        private void ShowLastActionStatus()
        {
            ERROR aErr = Logger.GetLastAction();

            if (!aErr.Equals(lastError) && ( aErr.IsError() || aErr.IsAction()))
            {
                if (aErr.IsError())
                {
                    labStatusAction.Text = "Error : " + aErr.GetText();
                    labStatusAction.ForeColor = Color.Red;
                }
                if (aErr.IsAction())
                {
                    labStatusAction.Text = aErr.GetText();
                    labStatusAction.ForeColor = Color.Green;
                }
                lastError = aErr;
                timerLastErrorShow = 0;
            }

            if (timerLastErrorShow > 50)
                labStatusAction.Text = "";

            if (timerLastErrorShow <= 50)
                timerLastErrorShow++;
        }
        //----------------------------------------------------------------------------------
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hpt1000.Dispose();
        }
        //----------------------------------------------------------------------------------
    }
}
