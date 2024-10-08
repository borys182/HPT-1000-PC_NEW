﻿namespace HPT1000.GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnLogin = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnLogout = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labStatusAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.borderLab1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnConfirm = new System.Windows.Forms.ToolStripSplitButton();
            this.borderLab2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labStatusMsgAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.liveGraphicalPanel = new HPT1000.GUI.GraphicalLive();
            this.btnLiveModeData = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.interlockPanel_Vacuum = new HPT1000.GUI.InterlockPanel();
            this.interlockPanel_Emergency = new HPT1000.GUI.InterlockPanel();
            this.interlockPanel_Pressure = new HPT1000.GUI.InterlockPanel();
            this.interlockPanel_Thermal = new HPT1000.GUI.InterlockPanel();
            this.interlockPanel_Door = new HPT1000.GUI.InterlockPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grBoxSystem = new System.Windows.Forms.GroupBox();
            this.pictureCornerUp3 = new System.Windows.Forms.PictureBox();
            this.picturelineMFC = new System.Windows.Forms.PictureBox();
            this.pumpComponent = new HPT1000.GUI.PumpComponent();
            this.valve_Vent = new HPT1000.GUI.ValvePanel();
            this.valve_SV = new HPT1000.GUI.ValvePanel();
            this.valve_Gas = new HPT1000.GUI.ValvePanel();
            this.valve_Purge = new HPT1000.GUI.ValvePanel();
            this.pictureBox34 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureArrowUp1 = new System.Windows.Forms.PictureBox();
            this.pictureArrowUp2 = new System.Windows.Forms.PictureBox();
            this.pictureArrowDown = new System.Windows.Forms.PictureBox();
            this.pictureBox30 = new System.Windows.Forms.PictureBox();
            this.pictureCornerDown3 = new System.Windows.Forms.PictureBox();
            this.pictureBox25 = new System.Windows.Forms.PictureBox();
            this.pictureLineMFC3 = new System.Windows.Forms.PictureBox();
            this.pictureCornerDown2 = new System.Windows.Forms.PictureBox();
            this.vaporiserPanel = new HPT1000.GUI.VaporiserPanel();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.pictureBox28 = new System.Windows.Forms.PictureBox();
            this.pictureBox27 = new System.Windows.Forms.PictureBox();
            this.pictureBox26 = new System.Windows.Forms.PictureBox();
            this.pictureLineMFC2 = new System.Windows.Forms.PictureBox();
            this.pictureLineMFC1 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureCornerUp2 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureCornerUp1 = new System.Windows.Forms.PictureBox();
            this.pictureCornerDown1 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureChamber = new System.Windows.Forms.PictureBox();
            this.generatorPanel = new HPT1000.GUI.GeneratorPanel();
            this.pumpPanel = new HPT1000.GUI.PumpPanel();
            this.pressurePanel = new HPT1000.GUI.PressurePanel();
            this.mfcPanel3 = new HPT1000.GUI.MFCPanel();
            this.mfcPanel1 = new HPT1000.GUI.MFCPanel();
            this.mfcPanel2 = new HPT1000.GUI.MFCPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.programPanel = new HPT1000.GUI.ProgramPanel();
            this.tabPagePrograms = new System.Windows.Forms.TabPage();
            this.programsConfigPanel = new HPT1000.GUI.ProgramsConfigPanel();
            this.tabPageAlerts = new System.Windows.Forms.TabPage();
            this.alertsPanel = new HPT1000.GUI.AlertsPanel();
            this.tabPageArchive = new System.Windows.Forms.TabPage();
            this.archivePanel = new HPT1000.GUI.ArchivePanel();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.settingsPanel = new HPT1000.GUI.SettingsPanel();
            this.tabPageMaintenance = new System.Windows.Forms.TabPage();
            this.tabPageService = new System.Windows.Forms.TabPage();
            this.servicePanel = new HPT1000.GUI.ServicePanel();
            this.tabPageAdmin = new System.Windows.Forms.TabPage();
            this.userManagerPanel = new HPT1000.GUI.UserManagerPanel();
            this.adminPanel = new HPT1000.GUI.AdminPanel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grBoxSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCornerUp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturelineMFC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrowUp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrowUp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrowDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCornerDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLineMFC3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCornerDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLineMFC2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLineMFC1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCornerUp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCornerUp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCornerDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureChamber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPagePrograms.SuspendLayout();
            this.tabPageAlerts.SuspendLayout();
            this.tabPageArchive.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.tabPageService.SuspendLayout();
            this.tabPageAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(9, 6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(270, 35);
            this.btnLogin.TabIndex = 20;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Program.png");
            this.imageList1.Images.SetKeyName(1, "Subprogram.png");
            this.imageList1.Images.SetKeyName(2, "Pump.jpg");
            this.imageList1.Images.SetKeyName(3, "Gas.png");
            this.imageList1.Images.SetKeyName(4, "Plasma.jpg");
            this.imageList1.Images.SetKeyName(5, "Purge.jpg");
            this.imageList1.Images.SetKeyName(6, "Vent.png");
            this.imageList1.Images.SetKeyName(7, "Valve.png");
            this.imageList1.Images.SetKeyName(8, "test.png");
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(287, 6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(270, 35);
            this.btnLogout.TabIndex = 23;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labStatusUser,
            this.toolStripStatusLabel1,
            this.statusLabel,
            this.toolStripStatusLabel2,
            this.labStatusAction,
            this.borderLab1,
            this.btnConfirm,
            this.borderLab2,
            this.labStatusMsgAction});
            this.statusStrip1.Location = new System.Drawing.Point(0, 832);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1706, 26);
            this.statusStrip1.TabIndex = 25;
            // 
            // labStatusUser
            // 
            this.labStatusUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labStatusUser.Name = "labStatusUser";
            this.labStatusUser.Size = new System.Drawing.Size(129, 21);
            this.labStatusUser.Text = "Login user: None";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 21);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(114, 21);
            this.statusLabel.Text = "Connection fail";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 21);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // labStatusAction
            // 
            this.labStatusAction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labStatusAction.ForeColor = System.Drawing.Color.Green;
            this.labStatusAction.Name = "labStatusAction";
            this.labStatusAction.Size = new System.Drawing.Size(169, 21);
            this.labStatusAction.Text = "Correct set parameters";
            // 
            // borderLab1
            // 
            this.borderLab1.Name = "borderLab1";
            this.borderLab1.Size = new System.Drawing.Size(13, 21);
            this.borderLab1.Text = "|";
            // 
            // btnConfirm
            // 
            this.btnConfirm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(92, 24);
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // borderLab2
            // 
            this.borderLab2.Name = "borderLab2";
            this.borderLab2.Size = new System.Drawing.Size(13, 21);
            this.borderLab2.Text = "|";
            // 
            // labStatusMsgAction
            // 
            this.labStatusMsgAction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labStatusMsgAction.ForeColor = System.Drawing.Color.Green;
            this.labStatusMsgAction.Name = "labStatusMsgAction";
            this.labStatusMsgAction.Size = new System.Drawing.Size(61, 21);
            this.labStatusMsgAction.Text = "Corecct";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageMain);
            this.tabControlMain.Controls.Add(this.tabPagePrograms);
            this.tabControlMain.Controls.Add(this.tabPageAlerts);
            this.tabControlMain.Controls.Add(this.tabPageArchive);
            this.tabControlMain.Controls.Add(this.tabPageSettings);
            this.tabControlMain.Controls.Add(this.tabPageMaintenance);
            this.tabControlMain.Controls.Add(this.tabPageService);
            this.tabControlMain.Controls.Add(this.tabPageAdmin);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.ShowToolTips = true;
            this.tabControlMain.Size = new System.Drawing.Size(1706, 832);
            this.tabControlMain.TabIndex = 26;
            // 
            // tabPageMain
            // 
            this.tabPageMain.BackColor = System.Drawing.Color.Transparent;
            this.tabPageMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageMain.Controls.Add(this.liveGraphicalPanel);
            this.tabPageMain.Controls.Add(this.btnLiveModeData);
            this.tabPageMain.Controls.Add(this.groupBox2);
            this.tabPageMain.Controls.Add(this.grBoxSystem);
            this.tabPageMain.Controls.Add(this.groupBox1);
            this.tabPageMain.Controls.Add(this.btnLogout);
            this.tabPageMain.Controls.Add(this.btnLogin);
            this.tabPageMain.Location = new System.Drawing.Point(4, 29);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(1698, 799);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "     MAIN SCREAN     ";
            // 
            // liveGraphicalPanel
            // 
            this.liveGraphicalPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.liveGraphicalPanel.Location = new System.Drawing.Point(1321, 753);
            this.liveGraphicalPanel.Margin = new System.Windows.Forms.Padding(4);
            this.liveGraphicalPanel.Name = "liveGraphicalPanel";
            this.liveGraphicalPanel.Size = new System.Drawing.Size(71, 39);
            this.liveGraphicalPanel.TabIndex = 110;
            // 
            // btnLiveModeData
            // 
            this.btnLiveModeData.Location = new System.Drawing.Point(563, 751);
            this.btnLiveModeData.Name = "btnLiveModeData";
            this.btnLiveModeData.Size = new System.Drawing.Size(1122, 35);
            this.btnLiveModeData.TabIndex = 30;
            this.btnLiveModeData.Text = "SWITCH TO GRAPHICAL VIEW";
            this.btnLiveModeData.UseVisualStyleBackColor = true;
            this.btnLiveModeData.Click += new System.EventHandler(this.btnLiveModeData_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.interlockPanel_Vacuum);
            this.groupBox2.Controls.Add(this.interlockPanel_Emergency);
            this.groupBox2.Controls.Add(this.interlockPanel_Pressure);
            this.groupBox2.Controls.Add(this.interlockPanel_Thermal);
            this.groupBox2.Controls.Add(this.interlockPanel_Door);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(9, 655);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 96);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interlocks";
            // 
            // interlockPanel_Vacuum
            // 
            this.interlockPanel_Vacuum.Location = new System.Drawing.Point(137, 19);
            this.interlockPanel_Vacuum.Margin = new System.Windows.Forms.Padding(5);
            this.interlockPanel_Vacuum.Name = "interlockPanel_Vacuum";
            this.interlockPanel_Vacuum.Size = new System.Drawing.Size(30, 30);
            this.interlockPanel_Vacuum.TabIndex = 111;
            // 
            // interlockPanel_Emergency
            // 
            this.interlockPanel_Emergency.Location = new System.Drawing.Point(468, 19);
            this.interlockPanel_Emergency.Margin = new System.Windows.Forms.Padding(5);
            this.interlockPanel_Emergency.Name = "interlockPanel_Emergency";
            this.interlockPanel_Emergency.Size = new System.Drawing.Size(30, 30);
            this.interlockPanel_Emergency.TabIndex = 110;
            // 
            // interlockPanel_Pressure
            // 
            this.interlockPanel_Pressure.Location = new System.Drawing.Point(357, 19);
            this.interlockPanel_Pressure.Margin = new System.Windows.Forms.Padding(5);
            this.interlockPanel_Pressure.Name = "interlockPanel_Pressure";
            this.interlockPanel_Pressure.Size = new System.Drawing.Size(30, 30);
            this.interlockPanel_Pressure.TabIndex = 109;
            // 
            // interlockPanel_Thermal
            // 
            this.interlockPanel_Thermal.Location = new System.Drawing.Point(242, 19);
            this.interlockPanel_Thermal.Margin = new System.Windows.Forms.Padding(5);
            this.interlockPanel_Thermal.Name = "interlockPanel_Thermal";
            this.interlockPanel_Thermal.Size = new System.Drawing.Size(30, 30);
            this.interlockPanel_Thermal.TabIndex = 108;
            // 
            // interlockPanel_Door
            // 
            this.interlockPanel_Door.Location = new System.Drawing.Point(33, 19);
            this.interlockPanel_Door.Margin = new System.Windows.Forms.Padding(4);
            this.interlockPanel_Door.Name = "interlockPanel_Door";
            this.interlockPanel_Door.Size = new System.Drawing.Size(30, 30);
            this.interlockPanel_Door.TabIndex = 107;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(218, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 40);
            this.label6.TabIndex = 106;
            this.label6.Text = "Thermal\r\n swith";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(330, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 40);
            this.label5.TabIndex = 105;
            this.label5.Text = "Pressure \r\ngauge";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(432, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 40);
            this.label3.TabIndex = 104;
            this.label3.Text = "Emergency\r\n stop";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(111, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 40);
            this.label2.TabIndex = 103;
            this.label2.Text = "Vacuum\r\nswith";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(23, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 40);
            this.label1.TabIndex = 102;
            this.label1.Text = "Door \r\nswith";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grBoxSystem
            // 
            this.grBoxSystem.Controls.Add(this.pictureCornerUp3);
            this.grBoxSystem.Controls.Add(this.picturelineMFC);
            this.grBoxSystem.Controls.Add(this.pumpComponent);
            this.grBoxSystem.Controls.Add(this.valve_Vent);
            this.grBoxSystem.Controls.Add(this.valve_SV);
            this.grBoxSystem.Controls.Add(this.valve_Gas);
            this.grBoxSystem.Controls.Add(this.valve_Purge);
            this.grBoxSystem.Controls.Add(this.pictureBox34);
            this.grBoxSystem.Controls.Add(this.label4);
            this.grBoxSystem.Controls.Add(this.pictureArrowUp1);
            this.grBoxSystem.Controls.Add(this.pictureArrowUp2);
            this.grBoxSystem.Controls.Add(this.pictureArrowDown);
            this.grBoxSystem.Controls.Add(this.pictureBox30);
            this.grBoxSystem.Controls.Add(this.pictureCornerDown3);
            this.grBoxSystem.Controls.Add(this.pictureBox25);
            this.grBoxSystem.Controls.Add(this.pictureLineMFC3);
            this.grBoxSystem.Controls.Add(this.pictureCornerDown2);
            this.grBoxSystem.Controls.Add(this.vaporiserPanel);
            this.grBoxSystem.Controls.Add(this.label37);
            this.grBoxSystem.Controls.Add(this.label36);
            this.grBoxSystem.Controls.Add(this.pictureBox28);
            this.grBoxSystem.Controls.Add(this.pictureBox27);
            this.grBoxSystem.Controls.Add(this.pictureBox26);
            this.grBoxSystem.Controls.Add(this.pictureLineMFC2);
            this.grBoxSystem.Controls.Add(this.pictureLineMFC1);
            this.grBoxSystem.Controls.Add(this.pictureBox20);
            this.grBoxSystem.Controls.Add(this.pictureBox17);
            this.grBoxSystem.Controls.Add(this.pictureCornerUp2);
            this.grBoxSystem.Controls.Add(this.pictureBox16);
            this.grBoxSystem.Controls.Add(this.pictureCornerUp1);
            this.grBoxSystem.Controls.Add(this.pictureCornerDown1);
            this.grBoxSystem.Controls.Add(this.pictureBox10);
            this.grBoxSystem.Controls.Add(this.pictureBox8);
            this.grBoxSystem.Controls.Add(this.pictureChamber);
            this.grBoxSystem.Controls.Add(this.generatorPanel);
            this.grBoxSystem.Controls.Add(this.pumpPanel);
            this.grBoxSystem.Controls.Add(this.pressurePanel);
            this.grBoxSystem.Controls.Add(this.mfcPanel3);
            this.grBoxSystem.Controls.Add(this.mfcPanel1);
            this.grBoxSystem.Controls.Add(this.mfcPanel2);
            this.grBoxSystem.Location = new System.Drawing.Point(562, -2);
            this.grBoxSystem.Name = "grBoxSystem";
            this.grBoxSystem.Size = new System.Drawing.Size(1124, 748);
            this.grBoxSystem.TabIndex = 25;
            this.grBoxSystem.TabStop = false;
            this.grBoxSystem.Text = "System";
            // 
            // pictureCornerUp3
            // 
            this.pictureCornerUp3.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureCornerUp3.ErrorImage")));
            this.pictureCornerUp3.Image = ((System.Drawing.Image)(resources.GetObject("pictureCornerUp3.Image")));
            this.pictureCornerUp3.Location = new System.Drawing.Point(681, 250);
            this.pictureCornerUp3.Name = "pictureCornerUp3";
            this.pictureCornerUp3.Size = new System.Drawing.Size(31, 31);
            this.pictureCornerUp3.TabIndex = 109;
            this.pictureCornerUp3.TabStop = false;
            // 
            // picturelineMFC
            // 
            this.picturelineMFC.Image = ((System.Drawing.Image)(resources.GetObject("picturelineMFC.Image")));
            this.picturelineMFC.Location = new System.Drawing.Point(681, 273);
            this.picturelineMFC.Name = "picturelineMFC";
            this.picturelineMFC.Size = new System.Drawing.Size(4, 380);
            this.picturelineMFC.TabIndex = 108;
            this.picturelineMFC.TabStop = false;
            // 
            // pumpComponent
            // 
            this.pumpComponent.Location = new System.Drawing.Point(311, 550);
            this.pumpComponent.Margin = new System.Windows.Forms.Padding(4);
            this.pumpComponent.Name = "pumpComponent";
            this.pumpComponent.Size = new System.Drawing.Size(72, 62);
            this.pumpComponent.TabIndex = 107;
            // 
            // valve_Vent
            // 
            this.valve_Vent.Location = new System.Drawing.Point(125, 479);
            this.valve_Vent.Margin = new System.Windows.Forms.Padding(5);
            this.valve_Vent.Name = "valve_Vent";
            this.valve_Vent.Size = new System.Drawing.Size(35, 50);
            this.valve_Vent.TabIndex = 106;
            // 
            // valve_SV
            // 
            this.valve_SV.Location = new System.Drawing.Point(332, 479);
            this.valve_SV.Margin = new System.Windows.Forms.Padding(5);
            this.valve_SV.Name = "valve_SV";
            this.valve_SV.Size = new System.Drawing.Size(35, 50);
            this.valve_SV.TabIndex = 105;
            // 
            // valve_Gas
            // 
            this.valve_Gas.Location = new System.Drawing.Point(455, 479);
            this.valve_Gas.Margin = new System.Windows.Forms.Padding(5);
            this.valve_Gas.Name = "valve_Gas";
            this.valve_Gas.Size = new System.Drawing.Size(35, 50);
            this.valve_Gas.TabIndex = 104;
            // 
            // valve_Purge
            // 
            this.valve_Purge.Location = new System.Drawing.Point(35, 479);
            this.valve_Purge.Margin = new System.Windows.Forms.Padding(4);
            this.valve_Purge.Name = "valve_Purge";
            this.valve_Purge.Size = new System.Drawing.Size(35, 50);
            this.valve_Purge.TabIndex = 103;
            // 
            // pictureBox34
            // 
            this.pictureBox34.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox34.Image")));
            this.pictureBox34.Location = new System.Drawing.Point(348, 614);
            this.pictureBox34.Name = "pictureBox34";
            this.pictureBox34.Size = new System.Drawing.Size(4, 16);
            this.pictureBox34.TabIndex = 102;
            this.pictureBox34.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(300, 720);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 101;
            this.label4.Text = "Atmosphare";
            // 
            // pictureArrowUp1
            // 
            this.pictureArrowUp1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureArrowUp1.ErrorImage")));
            this.pictureArrowUp1.Image = global::HPT1000.Properties.Resources.Arrow_Up;
            this.pictureArrowUp1.Location = new System.Drawing.Point(36, 638);
            this.pictureArrowUp1.Name = "pictureArrowUp1";
            this.pictureArrowUp1.Size = new System.Drawing.Size(35, 65);
            this.pictureArrowUp1.TabIndex = 100;
            this.pictureArrowUp1.TabStop = false;
            // 
            // pictureArrowUp2
            // 
            this.pictureArrowUp2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureArrowUp2.ErrorImage")));
            this.pictureArrowUp2.Image = ((System.Drawing.Image)(resources.GetObject("pictureArrowUp2.Image")));
            this.pictureArrowUp2.Location = new System.Drawing.Point(123, 638);
            this.pictureArrowUp2.Name = "pictureArrowUp2";
            this.pictureArrowUp2.Size = new System.Drawing.Size(35, 65);
            this.pictureArrowUp2.TabIndex = 99;
            this.pictureArrowUp2.TabStop = false;
            // 
            // pictureArrowDown
            // 
            this.pictureArrowDown.ErrorImage = null;
            this.pictureArrowDown.Image = ((System.Drawing.Image)(resources.GetObject("pictureArrowDown.Image")));
            this.pictureArrowDown.Location = new System.Drawing.Point(335, 638);
            this.pictureArrowDown.Name = "pictureArrowDown";
            this.pictureArrowDown.Size = new System.Drawing.Size(33, 65);
            this.pictureArrowDown.TabIndex = 98;
            this.pictureArrowDown.TabStop = false;
            // 
            // pictureBox30
            // 
            this.pictureBox30.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox30.Image")));
            this.pictureBox30.Location = new System.Drawing.Point(710, 680);
            this.pictureBox30.Name = "pictureBox30";
            this.pictureBox30.Size = new System.Drawing.Size(15, 4);
            this.pictureBox30.TabIndex = 97;
            this.pictureBox30.TabStop = false;
            // 
            // pictureCornerDown3
            // 
            this.pictureCornerDown3.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureCornerDown3.ErrorImage")));
            this.pictureCornerDown3.Image = ((System.Drawing.Image)(resources.GetObject("pictureCornerDown3.Image")));
            this.pictureCornerDown3.Location = new System.Drawing.Point(681, 653);
            this.pictureCornerDown3.Name = "pictureCornerDown3";
            this.pictureCornerDown3.Size = new System.Drawing.Size(31, 31);
            this.pictureCornerDown3.TabIndex = 96;
            this.pictureCornerDown3.TabStop = false;
            // 
            // pictureBox25
            // 
            this.pictureBox25.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox25.Image")));
            this.pictureBox25.Location = new System.Drawing.Point(499, 581);
            this.pictureBox25.Name = "pictureBox25";
            this.pictureBox25.Size = new System.Drawing.Size(183, 4);
            this.pictureBox25.TabIndex = 95;
            this.pictureBox25.TabStop = false;
            // 
            // pictureLineMFC3
            // 
            this.pictureLineMFC3.Image = ((System.Drawing.Image)(resources.GetObject("pictureLineMFC3.Image")));
            this.pictureLineMFC3.Location = new System.Drawing.Point(684, 538);
            this.pictureLineMFC3.Name = "pictureLineMFC3";
            this.pictureLineMFC3.Size = new System.Drawing.Size(40, 4);
            this.pictureLineMFC3.TabIndex = 94;
            this.pictureLineMFC3.TabStop = false;
            // 
            // pictureCornerDown2
            // 
            this.pictureCornerDown2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureCornerDown2.ErrorImage")));
            this.pictureCornerDown2.Image = ((System.Drawing.Image)(resources.GetObject("pictureCornerDown2.Image")));
            this.pictureCornerDown2.Location = new System.Drawing.Point(469, 554);
            this.pictureCornerDown2.Name = "pictureCornerDown2";
            this.pictureCornerDown2.Size = new System.Drawing.Size(31, 31);
            this.pictureCornerDown2.TabIndex = 93;
            this.pictureCornerDown2.TabStop = false;
            // 
            // vaporiserPanel
            // 
            this.vaporiserPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.vaporiserPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vaporiserPanel.Location = new System.Drawing.Point(721, 595);
            this.vaporiserPanel.Margin = new System.Windows.Forms.Padding(4);
            this.vaporiserPanel.Name = "vaporiserPanel";
            this.vaporiserPanel.Size = new System.Drawing.Size(372, 132);
            this.vaporiserPanel.TabIndex = 92;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label37.Location = new System.Drawing.Point(93, 720);
            this.label37.Name = "label37";
            this.label37.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label37.Size = new System.Drawing.Size(109, 20);
            this.label37.TabIndex = 90;
            this.label37.Text = "Atmosphare";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label36.Location = new System.Drawing.Point(18, 719);
            this.label36.Name = "label36";
            this.label36.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label36.Size = new System.Drawing.Size(73, 20);
            this.label36.TabIndex = 89;
            this.label36.Text = "Purging";
            // 
            // pictureBox28
            // 
            this.pictureBox28.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox28.Image")));
            this.pictureBox28.Location = new System.Drawing.Point(171, 419);
            this.pictureBox28.Name = "pictureBox28";
            this.pictureBox28.Size = new System.Drawing.Size(99, 4);
            this.pictureBox28.TabIndex = 88;
            this.pictureBox28.TabStop = false;
            // 
            // pictureBox27
            // 
            this.pictureBox27.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox27.Image")));
            this.pictureBox27.Location = new System.Drawing.Point(149, 327);
            this.pictureBox27.Name = "pictureBox27";
            this.pictureBox27.Size = new System.Drawing.Size(121, 4);
            this.pictureBox27.TabIndex = 87;
            this.pictureBox27.TabStop = false;
            // 
            // pictureBox26
            // 
            this.pictureBox26.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox26.Image")));
            this.pictureBox26.Location = new System.Drawing.Point(81, 373);
            this.pictureBox26.Name = "pictureBox26";
            this.pictureBox26.Size = new System.Drawing.Size(189, 4);
            this.pictureBox26.TabIndex = 86;
            this.pictureBox26.TabStop = false;
            // 
            // pictureLineMFC2
            // 
            this.pictureLineMFC2.Image = ((System.Drawing.Image)(resources.GetObject("pictureLineMFC2.Image")));
            this.pictureLineMFC2.Location = new System.Drawing.Point(685, 385);
            this.pictureLineMFC2.Name = "pictureLineMFC2";
            this.pictureLineMFC2.Size = new System.Drawing.Size(40, 4);
            this.pictureLineMFC2.TabIndex = 84;
            this.pictureLineMFC2.TabStop = false;
            // 
            // pictureLineMFC1
            // 
            this.pictureLineMFC1.Image = ((System.Drawing.Image)(resources.GetObject("pictureLineMFC1.Image")));
            this.pictureLineMFC1.Location = new System.Drawing.Point(710, 250);
            this.pictureLineMFC1.Name = "pictureLineMFC1";
            this.pictureLineMFC1.Size = new System.Drawing.Size(14, 4);
            this.pictureLineMFC1.TabIndex = 83;
            this.pictureLineMFC1.TabStop = false;
            // 
            // pictureBox20
            // 
            this.pictureBox20.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox20.Image")));
            this.pictureBox20.Location = new System.Drawing.Point(469, 454);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(4, 102);
            this.pictureBox20.TabIndex = 82;
            this.pictureBox20.TabStop = false;
            // 
            // pictureBox17
            // 
            this.pictureBox17.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox17.Image")));
            this.pictureBox17.Location = new System.Drawing.Point(140, 443);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(4, 198);
            this.pictureBox17.TabIndex = 80;
            this.pictureBox17.TabStop = false;
            // 
            // pictureCornerUp2
            // 
            this.pictureCornerUp2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureCornerUp2.ErrorImage")));
            this.pictureCornerUp2.Image = ((System.Drawing.Image)(resources.GetObject("pictureCornerUp2.Image")));
            this.pictureCornerUp2.Location = new System.Drawing.Point(140, 419);
            this.pictureCornerUp2.Name = "pictureCornerUp2";
            this.pictureCornerUp2.Size = new System.Drawing.Size(31, 31);
            this.pictureCornerUp2.TabIndex = 79;
            this.pictureCornerUp2.TabStop = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox16.Image")));
            this.pictureBox16.Location = new System.Drawing.Point(51, 396);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(4, 245);
            this.pictureBox16.TabIndex = 78;
            this.pictureBox16.TabStop = false;
            // 
            // pictureCornerUp1
            // 
            this.pictureCornerUp1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureCornerUp1.ErrorImage")));
            this.pictureCornerUp1.Image = ((System.Drawing.Image)(resources.GetObject("pictureCornerUp1.Image")));
            this.pictureCornerUp1.Location = new System.Drawing.Point(51, 373);
            this.pictureCornerUp1.Name = "pictureCornerUp1";
            this.pictureCornerUp1.Size = new System.Drawing.Size(31, 31);
            this.pictureCornerUp1.TabIndex = 77;
            this.pictureCornerUp1.TabStop = false;
            // 
            // pictureCornerDown1
            // 
            this.pictureCornerDown1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureCornerDown1.ErrorImage")));
            this.pictureCornerDown1.Image = ((System.Drawing.Image)(resources.GetObject("pictureCornerDown1.Image")));
            this.pictureCornerDown1.Location = new System.Drawing.Point(116, 300);
            this.pictureCornerDown1.Name = "pictureCornerDown1";
            this.pictureCornerDown1.Size = new System.Drawing.Size(31, 31);
            this.pictureCornerDown1.TabIndex = 76;
            this.pictureCornerDown1.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(440, 206);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(4, 99);
            this.pictureBox10.TabIndex = 73;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(347, 454);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(4, 101);
            this.pictureBox8.TabIndex = 71;
            this.pictureBox8.TabStop = false;
            // 
            // pictureChamber
            // 
            this.pictureChamber.BackColor = System.Drawing.Color.Transparent;
            this.pictureChamber.Image = global::HPT1000.Properties.Resources.Plasma;
            this.pictureChamber.Location = new System.Drawing.Point(270, 307);
            this.pictureChamber.Name = "pictureChamber";
            this.pictureChamber.Size = new System.Drawing.Size(267, 149);
            this.pictureChamber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureChamber.TabIndex = 67;
            this.pictureChamber.TabStop = false;
            // 
            // generatorPanel
            // 
            this.generatorPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.generatorPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.generatorPanel.Location = new System.Drawing.Point(10, 20);
            this.generatorPanel.Margin = new System.Windows.Forms.Padding(4);
            this.generatorPanel.Name = "generatorPanel";
            this.generatorPanel.Size = new System.Drawing.Size(263, 276);
            this.generatorPanel.TabIndex = 50;
            // 
            // pumpPanel
            // 
            this.pumpPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pumpPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pumpPanel.Location = new System.Drawing.Point(725, 20);
            this.pumpPanel.Margin = new System.Windows.Forms.Padding(4);
            this.pumpPanel.Name = "pumpPanel";
            this.pumpPanel.Size = new System.Drawing.Size(371, 118);
            this.pumpPanel.TabIndex = 49;
            // 
            // pressurePanel
            // 
            this.pressurePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pressurePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pressurePanel.Location = new System.Drawing.Point(310, 20);
            this.pressurePanel.Margin = new System.Windows.Forms.Padding(4);
            this.pressurePanel.Name = "pressurePanel";
            this.pressurePanel.Size = new System.Drawing.Size(325, 189);
            this.pressurePanel.TabIndex = 48;
            // 
            // mfcPanel3
            // 
            this.mfcPanel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mfcPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mfcPanel3.Location = new System.Drawing.Point(725, 449);
            this.mfcPanel3.Margin = new System.Windows.Forms.Padding(5);
            this.mfcPanel3.Name = "mfcPanel3";
            this.mfcPanel3.Size = new System.Drawing.Size(378, 139);
            this.mfcPanel3.TabIndex = 47;
            // 
            // mfcPanel1
            // 
            this.mfcPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mfcPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mfcPanel1.Location = new System.Drawing.Point(725, 155);
            this.mfcPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.mfcPanel1.Name = "mfcPanel1";
            this.mfcPanel1.Size = new System.Drawing.Size(378, 140);
            this.mfcPanel1.TabIndex = 46;
            // 
            // mfcPanel2
            // 
            this.mfcPanel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mfcPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mfcPanel2.Location = new System.Drawing.Point(725, 302);
            this.mfcPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.mfcPanel2.Name = "mfcPanel2";
            this.mfcPanel2.Size = new System.Drawing.Size(378, 140);
            this.mfcPanel2.TabIndex = 45;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.programPanel);
            this.groupBox1.Location = new System.Drawing.Point(9, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 610);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Program";
            // 
            // programPanel
            // 
            this.programPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.programPanel.HPT1000 = null;
            this.programPanel.Location = new System.Drawing.Point(3, 23);
            this.programPanel.Margin = new System.Windows.Forms.Padding(4);
            this.programPanel.Name = "programPanel";
            this.programPanel.Size = new System.Drawing.Size(540, 584);
            this.programPanel.TabIndex = 0;
            // 
            // tabPagePrograms
            // 
            this.tabPagePrograms.Controls.Add(this.programsConfigPanel);
            this.tabPagePrograms.Location = new System.Drawing.Point(4, 29);
            this.tabPagePrograms.Name = "tabPagePrograms";
            this.tabPagePrograms.Size = new System.Drawing.Size(1698, 799);
            this.tabPagePrograms.TabIndex = 6;
            this.tabPagePrograms.Text = "     PROGRAMS     ";
            this.tabPagePrograms.UseVisualStyleBackColor = true;
            // 
            // programsConfigPanel
            // 
            this.programsConfigPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programsConfigPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.programsConfigPanel.HPT1000 = null;
            this.programsConfigPanel.Location = new System.Drawing.Point(0, 0);
            this.programsConfigPanel.Name = "programsConfigPanel";
            this.programsConfigPanel.Size = new System.Drawing.Size(1698, 799);
            this.programsConfigPanel.TabIndex = 1;
            // 
            // tabPageAlerts
            // 
            this.tabPageAlerts.Controls.Add(this.alertsPanel);
            this.tabPageAlerts.Location = new System.Drawing.Point(4, 29);
            this.tabPageAlerts.Name = "tabPageAlerts";
            this.tabPageAlerts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlerts.Size = new System.Drawing.Size(1698, 799);
            this.tabPageAlerts.TabIndex = 2;
            this.tabPageAlerts.Text = "     ALERTS     ";
            this.tabPageAlerts.UseVisualStyleBackColor = true;
            // 
            // alertsPanel
            // 
            this.alertsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alertsPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.alertsPanel.HPT1000 = null;
            this.alertsPanel.Location = new System.Drawing.Point(3, 3);
            this.alertsPanel.Name = "alertsPanel";
            this.alertsPanel.Size = new System.Drawing.Size(1692, 793);
            this.alertsPanel.TabIndex = 0;
            // 
            // tabPageArchive
            // 
            this.tabPageArchive.Controls.Add(this.archivePanel);
            this.tabPageArchive.Location = new System.Drawing.Point(4, 29);
            this.tabPageArchive.Name = "tabPageArchive";
            this.tabPageArchive.Size = new System.Drawing.Size(1698, 799);
            this.tabPageArchive.TabIndex = 3;
            this.tabPageArchive.Text = "     ARCHIVE     ";
            this.tabPageArchive.UseVisualStyleBackColor = true;
            // 
            // archivePanel
            // 
            this.archivePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.archivePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.archivePanel.Location = new System.Drawing.Point(0, 0);
            this.archivePanel.Margin = new System.Windows.Forms.Padding(4);
            this.archivePanel.Name = "archivePanel";
            this.archivePanel.Size = new System.Drawing.Size(1698, 799);
            this.archivePanel.TabIndex = 0;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.BackColor = System.Drawing.Color.Transparent;
            this.tabPageSettings.Controls.Add(this.settingsPanel);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 29);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(1698, 799);
            this.tabPageSettings.TabIndex = 4;
            this.tabPageSettings.Text = "     SETTINGS     ";
            // 
            // settingsPanel
            // 
            this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.settingsPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(1698, 799);
            this.settingsPanel.TabIndex = 0;
            // 
            // tabPageMaintenance
            // 
            this.tabPageMaintenance.Location = new System.Drawing.Point(4, 29);
            this.tabPageMaintenance.Name = "tabPageMaintenance";
            this.tabPageMaintenance.Size = new System.Drawing.Size(1698, 799);
            this.tabPageMaintenance.TabIndex = 5;
            this.tabPageMaintenance.Text = "     MAINTENANCE     ";
            this.tabPageMaintenance.UseVisualStyleBackColor = true;
            // 
            // tabPageService
            // 
            this.tabPageService.Controls.Add(this.servicePanel);
            this.tabPageService.Location = new System.Drawing.Point(4, 29);
            this.tabPageService.Name = "tabPageService";
            this.tabPageService.Size = new System.Drawing.Size(1698, 799);
            this.tabPageService.TabIndex = 7;
            this.tabPageService.Text = "     SERVICE     ";
            this.tabPageService.UseVisualStyleBackColor = true;
            // 
            // servicePanel
            // 
            this.servicePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servicePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.servicePanel.Location = new System.Drawing.Point(0, 0);
            this.servicePanel.Name = "servicePanel";
            this.servicePanel.Size = new System.Drawing.Size(1698, 799);
            this.servicePanel.TabIndex = 0;
            // 
            // tabPageAdmin
            // 
            this.tabPageAdmin.Controls.Add(this.userManagerPanel);
            this.tabPageAdmin.Controls.Add(this.adminPanel);
            this.tabPageAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabPageAdmin.Location = new System.Drawing.Point(4, 29);
            this.tabPageAdmin.Name = "tabPageAdmin";
            this.tabPageAdmin.Size = new System.Drawing.Size(1698, 799);
            this.tabPageAdmin.TabIndex = 8;
            this.tabPageAdmin.Text = "USER MANAGER  ";
            this.tabPageAdmin.UseVisualStyleBackColor = true;
            // 
            // userManagerPanel
            // 
            this.userManagerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userManagerPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userManagerPanel.Location = new System.Drawing.Point(0, 0);
            this.userManagerPanel.Margin = new System.Windows.Forms.Padding(4);
            this.userManagerPanel.Name = "userManagerPanel";
            this.userManagerPanel.Size = new System.Drawing.Size(1698, 799);
            this.userManagerPanel.TabIndex = 1;
            // 
            // adminPanel
            // 
            this.adminPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminPanel.Location = new System.Drawing.Point(0, 0);
            this.adminPanel.Margin = new System.Windows.Forms.Padding(4);
            this.adminPanel.Name = "adminPanel";
            this.adminPanel.Size = new System.Drawing.Size(1698, 799);
            this.adminPanel.TabIndex = 0;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1706, 858);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HPT 1000";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grBoxSystem.ResumeLayout(false);
            this.grBoxSystem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCornerUp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturelineMFC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrowUp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrowUp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrowDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCornerDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLineMFC3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCornerDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLineMFC2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLineMFC1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCornerUp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCornerUp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCornerDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureChamber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabPagePrograms.ResumeLayout(false);
            this.tabPageAlerts.ResumeLayout(false);
            this.tabPageArchive.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageService.ResumeLayout(false);
            this.tabPageAdmin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPageAlerts;
        private System.Windows.Forms.TabPage tabPageArchive;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageMaintenance;
        private System.Windows.Forms.TabPage tabPagePrograms;
        private ProgramsConfigPanel programsConfigPanel;
        private ProgramPanel programPanel;
        private System.Windows.Forms.GroupBox grBoxSystem;
        private System.Windows.Forms.PictureBox pictureBox34;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureArrowUp1;
        private System.Windows.Forms.PictureBox pictureArrowUp2;
        private System.Windows.Forms.PictureBox pictureArrowDown;
        private System.Windows.Forms.PictureBox pictureBox30;
        private System.Windows.Forms.PictureBox pictureCornerDown3;
        private System.Windows.Forms.PictureBox pictureBox25;
        private System.Windows.Forms.PictureBox pictureLineMFC3;
        private System.Windows.Forms.PictureBox pictureCornerDown2;
        private VaporiserPanel vaporiserPanel;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.PictureBox pictureBox28;
        private System.Windows.Forms.PictureBox pictureBox27;
        private System.Windows.Forms.PictureBox pictureBox26;
        private System.Windows.Forms.PictureBox pictureLineMFC2;
        private System.Windows.Forms.PictureBox pictureLineMFC1;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.PictureBox pictureBox17;
        private System.Windows.Forms.PictureBox pictureCornerUp2;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.PictureBox pictureCornerUp1;
        private System.Windows.Forms.PictureBox pictureCornerDown1;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureChamber;
        private GeneratorPanel generatorPanel;
        private PumpPanel pumpPanel;
        private PressurePanel pressurePanel;
        private MFCPanel mfcPanel3;
        private MFCPanel mfcPanel1;
        private MFCPanel mfcPanel2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel labStatusAction;
        private SettingsPanel settingsPanel;
        private AlertsPanel alertsPanel;
        private ValvePanel valve_Vent;
        private ValvePanel valve_SV;
        private ValvePanel valve_Gas;
        private ValvePanel valve_Purge;
        private PumpComponent pumpComponent;
        private System.Windows.Forms.PictureBox picturelineMFC;
        private System.Windows.Forms.PictureBox pictureCornerUp3;
        private System.Windows.Forms.ToolStripStatusLabel labStatusUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private InterlockPanel interlockPanel_Vacuum;
        private InterlockPanel interlockPanel_Emergency;
        private InterlockPanel interlockPanel_Pressure;
        private InterlockPanel interlockPanel_Thermal;
        private InterlockPanel interlockPanel_Door;
        private System.Windows.Forms.Button btnLiveModeData;
        private System.Windows.Forms.TabPage tabPageService;
        private System.Windows.Forms.TabPage tabPageAdmin;
        private ServicePanel servicePanel;
        private AdminPanel adminPanel;
        private GraphicalLive liveGraphicalPanel;
        private System.Windows.Forms.ToolStripSplitButton btnConfirm;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel borderLab1;
        private System.Windows.Forms.ToolStripStatusLabel borderLab2;
        private System.Windows.Forms.ToolStripStatusLabel labStatusMsgAction;
        private UserManagerPanel userManagerPanel;
        private ArchivePanel archivePanel;
    }
}

