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
        private Source.Driver.HPT1000   hpt1000   = new HPT1000.Source.Driver.HPT1000();
        private Source.DB               dataBase  = new DB();

        private Login                   loginForm = null;

        private bool                    liveModeData_Graphical = false;

        ERROR lastError = new ERROR();

        int timerLastErrorShow = 0;

        Point pointCornerMFC1   = new Point(545, 200);
        Point pointCornerMFC2   = new Point(545, 308);
        Point pointCornerMFC3   = new Point(545, 430);
        Point pointLineMFC1     = new Point(545, 218);
        Point pointLineMFC2     = new Point(545, 315);
        Point pointLineMFC3     = new Point(545, 440);
        Point pointLineVaporator = new Point(545, 465);
        Size sizeLineMFC_1      = new Size(3, 304);
        Size sizeLineMFC_2      = new Size(3, 215);
        Size sizeLineMFC_3      = new Size(3, 82);
        Size sizeLineVaporator  = new Size(3, 62);

        //------------------------------------------------------------------------------------------
        public MainForm()
        {
            InitializeComponent();

            programsConfigPanel.HPT1000 = hpt1000;
            programPanel.HPT1000        = hpt1000;
            alertsPanel.HPT1000         = hpt1000;
            settingsPanel.SetPtrHPT(hpt1000);
            servicePanel.SetPtrHPT(hpt1000);

            generatorPanel.SetGeneratorPtr(hpt1000.GetPowerSupply());
            pressurePanel.SetPresureControlPtr(hpt1000.GetPressureControl());
            pumpPanel.SetPumpPtr(hpt1000.GetForePump());
            vaporiserPanel.SetVaporizerPtr(hpt1000.GetVaporizer());
            mfcPanel1.SetMFC(hpt1000.GetMFC(),hpt1000.GetGasTypes(),1);
            mfcPanel2.SetMFC(hpt1000.GetMFC(),hpt1000.GetGasTypes(),2);
            mfcPanel3.SetMFC(hpt1000.GetMFC(),hpt1000.GetGasTypes(),3);


            valve_Gas.SetValvePtr(hpt1000.GetValve(), Types.TypeValve.Gas);
            valve_Purge.SetValvePtr(hpt1000.GetValve(), Types.TypeValve.Purge);
            valve_SV.SetValvePtr(hpt1000.GetValve(), Types.TypeValve.SV);
            valve_Vent.SetValvePtr(hpt1000.GetValve(), Types.TypeValve.VV);

            interlockPanel_Door.SetInterlockPtr(hpt1000.GetInterlock(), Types.TypeInterlock.Door);
            interlockPanel_Emergency.SetInterlockPtr(hpt1000.GetInterlock(), Types.TypeInterlock.EmgStop);
            interlockPanel_Pressure.SetInterlockPtr(hpt1000.GetInterlock(), Types.TypeInterlock.PressureGauge);
            interlockPanel_Thermal.SetInterlockPtr(hpt1000.GetInterlock(), Types.TypeInterlock.ThermalSwitch);
            interlockPanel_Vacuum.SetInterlockPtr(hpt1000.GetInterlock(), Types.TypeInterlock.VacuumSwitch);

            pumpComponent.SetPumpPtr(hpt1000.GetForePump());

            //Dodaj obserwatorow

            //Odswiezaj nazwy programow/subprogramow w glownym oknie aplikacji gdy zostanie zmieniona one zmoienone w oknie ConfigsProgram
            Program.AddToRefreshList(new RefreshProgram(programPanel.RefreshProgram));
            Program.AddToRefreshList(new RefreshProgram(programsConfigPanel.RefreshProgram));
            Source.Driver.HPT1000.AddToRefreshList(new RefreshProgram(programPanel.RefreshProgram));
            Source.Driver.HPT1000.AddToRefreshList(new RefreshProgram(programsConfigPanel.RefreshProgram));
            //Odswiezaj nazwy gazow na panelu przeplywki gdy zostana one zmienione w oknie Settings
            GasTypes.AddToRefreshList(new RefreshGasType(mfcPanel1.RefreshGasType));
            GasTypes.AddToRefreshList(new RefreshGasType(mfcPanel2.RefreshGasType));
            GasTypes.AddToRefreshList(new RefreshGasType(mfcPanel3.RefreshGasType));

            //Ustaw odpowidnie obrazki dla SystemWindow
            LoadBitmap();
        }
        //------------------------------------------------------------------------------------------
        private void LoadBitmap()
        {
            Bitmap chamber      = new Bitmap(Properties.Resources.Plasma);
            Bitmap arrowUp      = new Bitmap(Properties.Resources.Arrow_Up);
            Bitmap arrowDown    = new Bitmap(Properties.Resources.Arrow_Down);
            Bitmap cornerUp     = new Bitmap(Properties.Resources.Corner_Right_Top);
            Bitmap cornerDown   = new Bitmap(Properties.Resources.Corner_Right_Bottom);

            chamber.MakeTransparent(Color.White);
            arrowUp.MakeTransparent(Color.White);
            arrowDown.MakeTransparent(Color.White);
            cornerUp.MakeTransparent(Color.White);
            cornerDown.MakeTransparent(Color.White);

            pictureChamber.SizeMode     = PictureBoxSizeMode.StretchImage;
            pictureArrowUp1.SizeMode    = PictureBoxSizeMode.StretchImage;
            pictureArrowUp2.SizeMode    = PictureBoxSizeMode.StretchImage;
            pictureCornerUp3.SizeMode   = PictureBoxSizeMode.StretchImage;
            pictureArrowDown.SizeMode   = PictureBoxSizeMode.StretchImage;
            pictureCornerUp1.SizeMode   = PictureBoxSizeMode.StretchImage;
            pictureCornerUp2.SizeMode   = PictureBoxSizeMode.StretchImage;
            pictureCornerUp3.SizeMode   = PictureBoxSizeMode.StretchImage;
            pictureCornerDown1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureCornerDown2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureCornerDown3.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureChamber.Image    = chamber;
         
            pictureArrowUp1.Image   = arrowUp;
            pictureArrowUp2.Image   = arrowUp;

            pictureArrowDown.Image  = arrowDown;

            pictureCornerUp1.Image  = cornerUp;
            pictureCornerUp2.Image  = cornerUp;
            pictureCornerUp3.Image  = cornerUp;

            pictureCornerDown1.Image = cornerDown;
            pictureCornerDown2.Image = cornerDown;
            pictureCornerDown3.Image = cornerDown;
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
            interlockPanel_Door.RefreshPanel();
            interlockPanel_Emergency.RefreshPanel();
            interlockPanel_Pressure.RefreshPanel();
            interlockPanel_Thermal.RefreshPanel();
            interlockPanel_Vacuum.RefreshPanel();

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
            //pokaz ustawienia dla aktywnych MFC
            ShowOnlyEnableMFC();
            //pokaz usera oraz poustawiaj uprawnienia do aplikacji
            ShowUser();
        }
        //----------------------------------------------------------------------------------
        public void ShowUser()
        {
            bool userLoged = true;
            if(dataBase != null)
            {
                labStatusUser.Text = "USER:  " + dataBase.UserApp.ToString() + "    ";
                switch(dataBase.UserApp.Privilige)
                {
                    case Types.UserPrivilige.Administrator:
                        SetUserPriviligeToAppAsAdmin();
                        break;
                    case Types.UserPrivilige.Operator:
                        SetUserPriviligeToAppAsOperator();
                        break;
                    case Types.UserPrivilige.Service:
                        SetUserPriviligeToAppAsService();
                        break;
                    case Types.UserPrivilige.None:
                        SetUserPriviligeToAppAsNone();
                        userLoged = false;
                        break;
                }
            }
            else
            {
                userLoged = false;
            }

            btnLogin.Enabled    = !userLoged;
            btnLogout.Enabled   = userLoged;
        }
        //----------------------------------------------------------------------------------
        public void SetUserPriviligeToAppAsAdmin()
        {
            programPanel.Visible        = true;
            programPanel.Enabled        = true;
            grBoxSystem.Enabled         = true;
            programsConfigPanel.Enabled = true;
            alertsPanel.Enabled         = true;
            settingsPanel.Enabled       = true;
            if(!tabControlMain.TabPages.Contains(tabPageService))
                tabControlMain.TabPages.Insert(tabControlMain.TabPages.Count, tabPageService);
            if (!tabControlMain.TabPages.Contains(tabPageAdmin))
                tabControlMain.TabPages.Insert(tabControlMain.TabPages.Count, tabPageAdmin);
        }
        //----------------------------------------------------------------------------------
        public void SetUserPriviligeToAppAsOperator()
        {
            tabControlMain.Visible      = true;
            programPanel.Enabled        = true;
            grBoxSystem.Enabled         = true;
            programsConfigPanel.Enabled = false;
            alertsPanel.Enabled         = true;
            settingsPanel.Enabled       = false;
            tabControlMain.TabPages.Remove(tabPageService);
            tabControlMain.TabPages.Remove(tabPageAdmin);

        }
        //----------------------------------------------------------------------------------
        public void SetUserPriviligeToAppAsService()
        {
            tabControlMain.Visible      = true;
            programPanel.Enabled        = true;
            grBoxSystem.Enabled         = true;
            programsConfigPanel.Enabled = true;
            alertsPanel.Enabled         = true;
            settingsPanel.Enabled       = true;
            if (!tabControlMain.TabPages.Contains(tabPageService))
                tabControlMain.TabPages.Insert(tabControlMain.TabPages.Count, tabPageService);
            if (!tabControlMain.TabPages.Contains(tabPageAdmin))
                tabControlMain.TabPages.Insert(tabControlMain.TabPages.Count, tabPageAdmin);
        }
        //----------------------------------------------------------------------------------
        public void SetUserPriviligeToAppAsNone()
        {
            programPanel.Enabled        = false;
            grBoxSystem.Enabled         = false;
            programsConfigPanel.Enabled = false;
            alertsPanel.Enabled         = false;
            settingsPanel.Enabled       = false;
            tabControlMain.TabPages.Remove(tabPageService);
            tabControlMain.TabPages.Remove(tabPageAdmin);


            ShowLoginForm();
        }
        //----------------------------------------------------------------------------------
        private void ShowLoginForm()
        {
            if (loginForm == null || loginForm.IsDisposed)
            {
                loginForm = new Login();
                loginForm.FormClosed += new FormClosedEventHandler(loginForm_closed);
                loginForm.SetDB(dataBase);
            }
            loginForm.Show();
        }
        //----------------------------------------------------------------------------------
        private void loginForm_closed(object sender, FormClosedEventArgs e)
        {
            loginForm.Dispose();
            loginForm = null;
        }
        //----------------------------------------------------------------------------------
        public void ShowOnlyEnableMFC()
        {
            if (hpt1000 != null)
            {
                bool mfc1Enable = hpt1000.GetMFC().GetActive(1);
                bool mfc2Enable = hpt1000.GetMFC().GetActive(2);
                bool mfc3Enable = hpt1000.GetMFC().GetActive(3);

                bool  aVisibleCorner = false;
                Point pointCorner    = pictureCornerUp3.Location;
                Point pointLine      = pointLineVaporator;
                Size sizeLineMFC     = sizeLineVaporator;

                mfcPanel1.Visible       = mfc1Enable;
                pictureLineMFC1.Visible = mfc1Enable;

                mfcPanel2.Visible       = mfc2Enable;
                pictureLineMFC2.Visible = mfc2Enable;

                mfcPanel3.Visible       = mfc3Enable;
                pictureLineMFC3.Visible = mfc3Enable;

                if (mfc3Enable)
                {
                    aVisibleCorner = true;
                    pointCorner = pointCornerMFC3;
                    sizeLineMFC = sizeLineMFC_3;
                    pointLine = pointLineMFC3;

                }

                if (mfc2Enable)
                {
                    aVisibleCorner = true;
                    pointCorner = pointCornerMFC2;
                    sizeLineMFC = sizeLineMFC_2;
                    pointLine = pointLineMFC2;
                }

                if (mfc1Enable)
                {
                    aVisibleCorner = true;
                    pointCorner = pointCornerMFC1;
                    sizeLineMFC = sizeLineMFC_1;
                    pointLine = pointLineMFC1;
                }

                pictureCornerUp3.Visible    = aVisibleCorner;
                pictureCornerUp3.Location   = pointCorner;
                picturelineMFC.Size         = sizeLineMFC;
                picturelineMFC.Location     = pointLine;
            }
        }
        //----------------------------------------------------------------------------------
        private void ShowLastActionStatus()
        {
            ERROR aErr = Logger.GetLastAction();

            if (aErr != null && !aErr.Equals(lastError) && ( aErr.IsError() || aErr.IsAction()))
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }
        //----------------------------------------------------------------------------------
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (dataBase != null)
                dataBase.LogoutUser();
        }
        //----------------------------------------------------------------------------------
        private void btnLiveModeData_Click(object sender, EventArgs e)
        {
         //   liveModeData_Graphical != liveModeData_Graphical;
        }
        //----------------------------------------------------------------------------------
    }
}
