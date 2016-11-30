namespace HPT1000.GUI
{
    partial class ServicePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnReadSetingsPLC_1 = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.timeWaitOnOperate = new System.Windows.Forms.DateTimePicker();
            this.timeSetpointStabilization = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnReadSettings = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.cBoxMFC3 = new System.Windows.Forms.CheckBox();
            this.cBoxMFC2 = new System.Windows.Forms.CheckBox();
            this.cBoxMFC1 = new System.Windows.Forms.CheckBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.timeFlowStabilization = new System.Windows.Forms.DateTimePicker();
            this.label32 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnReadSettings_1 = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.timePumpToSV = new System.Windows.Forms.DateTimePicker();
            this.timeWaitPF = new System.Windows.Forms.DateTimePicker();
            this.label38 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnRemoveGas = new System.Windows.Forms.Button();
            this.tBoxNameGas = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnNewGas = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tBoxGasDescription = new System.Windows.Forms.TextBox();
            this.cBoxGasType = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dEditRangeVoltage = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditRangeCurent = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditRangePower = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditVoltageLimit = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditCurentLimit = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditPowerLimit = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditRangeVoltageMFC2 = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditRangeVoltageMFC3 = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditRangeVoltageMFC1 = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditMaxFlow_MFC2 = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditMaxFlow_MFC3 = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditMaxFlow_MFC1 = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditFactorGas = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl2.ItemSize = new System.Drawing.Size(117, 25);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1700, 795);
            this.tabControl2.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.btnReadSetingsPLC_1);
            this.tabPage3.Controls.Add(this.label40);
            this.tabPage3.Controls.Add(this.label39);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.timeWaitOnOperate);
            this.tabPage3.Controls.Add(this.timeSetpointStabilization);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.label24);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.dEditRangeVoltage);
            this.tabPage3.Controls.Add(this.dEditRangeCurent);
            this.tabPage3.Controls.Add(this.dEditRangePower);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.dEditVoltageLimit);
            this.tabPage3.Controls.Add(this.dEditCurentLimit);
            this.tabPage3.Controls.Add(this.dEditPowerLimit);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1692, 762);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "     Power supply    ";
            // 
            // btnReadSetingsPLC_1
            // 
            this.btnReadSetingsPLC_1.Location = new System.Drawing.Point(1473, 721);
            this.btnReadSetingsPLC_1.Name = "btnReadSetingsPLC_1";
            this.btnReadSetingsPLC_1.Size = new System.Drawing.Size(213, 35);
            this.btnReadSetingsPLC_1.TabIndex = 101;
            this.btnReadSetingsPLC_1.Text = "Read settings from PLC";
            this.btnReadSetingsPLC_1.UseVisualStyleBackColor = true;
            this.btnReadSetingsPLC_1.Click += new System.EventHandler(this.btnReadSettings_Click);
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label40.Location = new System.Drawing.Point(54, 467);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(959, 30);
            this.label40.TabIndex = 99;
            this.label40.Text = "Waiting time on stabilization value  to setpoint. After this time  we check to se" +
    "e if the value is within a specified range.";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label39.Location = new System.Drawing.Point(54, 591);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(696, 30);
            this.label39.TabIndex = 98;
            this.label39.Text = "Waiting time for confirmation of correct state of power supply after change state" +
    "";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label22.Location = new System.Drawing.Point(54, 247);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(1037, 32);
            this.label22.TabIndex = 96;
            this.label22.Text = "Determine maximum range of voltage, curent and power how we can set in power supp" +
    "ly";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label21.Location = new System.Drawing.Point(54, 29);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(1028, 32);
            this.label21.TabIndex = 95;
            this.label21.Text = "Determine limit of value voltage, curent and power how we can set in power supply" +
    "";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timeWaitOnOperate
            // 
            this.timeWaitOnOperate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeWaitOnOperate.Location = new System.Drawing.Point(345, 633);
            this.timeWaitOnOperate.Name = "timeWaitOnOperate";
            this.timeWaitOnOperate.ShowUpDown = true;
            this.timeWaitOnOperate.Size = new System.Drawing.Size(100, 27);
            this.timeWaitOnOperate.TabIndex = 94;
            this.timeWaitOnOperate.ValueChanged += new System.EventHandler(this.timeWaitOnOperate_ValueChanged);
            // 
            // timeSetpointStabilization
            // 
            this.timeSetpointStabilization.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeSetpointStabilization.Location = new System.Drawing.Point(345, 511);
            this.timeSetpointStabilization.Name = "timeSetpointStabilization";
            this.timeSetpointStabilization.ShowUpDown = true;
            this.timeSetpointStabilization.Size = new System.Drawing.Size(100, 27);
            this.timeSetpointStabilization.TabIndex = 93;
            this.timeSetpointStabilization.ValueChanged += new System.EventHandler(this.timeSetpointStabilization_ValueChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label23.Location = new System.Drawing.Point(103, 640);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(170, 20);
            this.label23.TabIndex = 92;
            this.label23.Text = "Time wait on operate:";
            // 
            // label24
            // 
            this.label24.AutoEllipsis = true;
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label24.Location = new System.Drawing.Point(103, 516);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(209, 20);
            this.label24.TabIndex = 91;
            this.label24.Text = "Time setpoint stabilization:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Green;
            this.label15.Location = new System.Drawing.Point(503, 345);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 20);
            this.label15.TabIndex = 90;
            this.label15.Text = "[V]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Green;
            this.label16.Location = new System.Drawing.Point(503, 393);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 20);
            this.label16.TabIndex = 89;
            this.label16.Text = "[A]";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Green;
            this.label17.Location = new System.Drawing.Point(503, 301);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 20);
            this.label17.TabIndex = 88;
            this.label17.Text = "[W]";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label18.Location = new System.Drawing.Point(103, 393);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 20);
            this.label18.TabIndex = 87;
            this.label18.Text = "Range curent:";
            // 
            // label19
            // 
            this.label19.AutoEllipsis = true;
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label19.Location = new System.Drawing.Point(103, 345);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(120, 20);
            this.label19.TabIndex = 86;
            this.label19.Text = "Range voltage:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label20.Location = new System.Drawing.Point(103, 301);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 20);
            this.label20.TabIndex = 85;
            this.label20.Text = "Range power:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(503, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 20);
            this.label8.TabIndex = 81;
            this.label8.Text = "[V]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(503, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 20);
            this.label7.TabIndex = 80;
            this.label7.Text = "[A]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(503, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 79;
            this.label6.Text = "[W]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(103, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 78;
            this.label5.Text = "Curent limit:";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(103, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 77;
            this.label3.Text = "Voltage limit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(103, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 76;
            this.label2.Text = "Power limit:";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.btnReadSettings);
            this.tabPage4.Controls.Add(this.label46);
            this.tabPage4.Controls.Add(this.cBoxMFC3);
            this.tabPage4.Controls.Add(this.cBoxMFC2);
            this.tabPage4.Controls.Add(this.cBoxMFC1);
            this.tabPage4.Controls.Add(this.label43);
            this.tabPage4.Controls.Add(this.label37);
            this.tabPage4.Controls.Add(this.label36);
            this.tabPage4.Controls.Add(this.label27);
            this.tabPage4.Controls.Add(this.label25);
            this.tabPage4.Controls.Add(this.label41);
            this.tabPage4.Controls.Add(this.label42);
            this.tabPage4.Controls.Add(this.label31);
            this.tabPage4.Controls.Add(this.timeFlowStabilization);
            this.tabPage4.Controls.Add(this.label32);
            this.tabPage4.Controls.Add(this.label29);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.dEditRangeVoltageMFC2);
            this.tabPage4.Controls.Add(this.dEditRangeVoltageMFC3);
            this.tabPage4.Controls.Add(this.dEditRangeVoltageMFC1);
            this.tabPage4.Controls.Add(this.dEditMaxFlow_MFC2);
            this.tabPage4.Controls.Add(this.dEditMaxFlow_MFC3);
            this.tabPage4.Controls.Add(this.dEditMaxFlow_MFC1);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1692, 762);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "   Mas flow controler  ";
            // 
            // btnReadSettings
            // 
            this.btnReadSettings.Location = new System.Drawing.Point(1473, 721);
            this.btnReadSettings.Name = "btnReadSettings";
            this.btnReadSettings.Size = new System.Drawing.Size(213, 35);
            this.btnReadSettings.TabIndex = 109;
            this.btnReadSettings.Text = "Read settings from PLC";
            this.btnReadSettings.UseVisualStyleBackColor = true;
            this.btnReadSettings.Click += new System.EventHandler(this.btnReadSettings_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label46.Location = new System.Drawing.Point(108, 208);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(98, 20);
            this.label46.TabIndex = 108;
            this.label46.Text = "Connection:";
            // 
            // cBoxMFC3
            // 
            this.cBoxMFC3.AutoSize = true;
            this.cBoxMFC3.Location = new System.Drawing.Point(126, 340);
            this.cBoxMFC3.Name = "cBoxMFC3";
            this.cBoxMFC3.Size = new System.Drawing.Size(45, 24);
            this.cBoxMFC3.TabIndex = 107;
            this.cBoxMFC3.Text = " 3";
            this.cBoxMFC3.UseVisualStyleBackColor = true;
            this.cBoxMFC3.Click += new System.EventHandler(this.cBoxMFC_Click);
            // 
            // cBoxMFC2
            // 
            this.cBoxMFC2.AutoSize = true;
            this.cBoxMFC2.Location = new System.Drawing.Point(126, 298);
            this.cBoxMFC2.Name = "cBoxMFC2";
            this.cBoxMFC2.Size = new System.Drawing.Size(45, 24);
            this.cBoxMFC2.TabIndex = 106;
            this.cBoxMFC2.Text = " 2";
            this.cBoxMFC2.UseVisualStyleBackColor = true;
            this.cBoxMFC2.Click += new System.EventHandler(this.cBoxMFC_Click);
            // 
            // cBoxMFC1
            // 
            this.cBoxMFC1.AutoSize = true;
            this.cBoxMFC1.Location = new System.Drawing.Point(126, 255);
            this.cBoxMFC1.Name = "cBoxMFC1";
            this.cBoxMFC1.Size = new System.Drawing.Size(45, 24);
            this.cBoxMFC1.TabIndex = 105;
            this.cBoxMFC1.Text = " 1";
            this.cBoxMFC1.UseVisualStyleBackColor = true;
            this.cBoxMFC1.Click += new System.EventHandler(this.cBoxMFC_Click);
            // 
            // label43
            // 
            this.label43.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label43.Location = new System.Drawing.Point(53, 70);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(236, 43);
            this.label43.TabIndex = 104;
            this.label43.Text = "Determine which controler are available";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label37.Location = new System.Drawing.Point(784, 199);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(70, 20);
            this.label37.TabIndex = 103;
            this.label37.Text = "Voltage:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label36.Location = new System.Drawing.Point(404, 208);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(153, 20);
            this.label36.TabIndex = 102;
            this.label36.Text = "Maximum gas flow:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Green;
            this.label27.Location = new System.Drawing.Point(925, 345);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(30, 20);
            this.label27.TabIndex = 101;
            this.label27.Text = "[V]";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.Green;
            this.label25.Location = new System.Drawing.Point(925, 293);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(30, 20);
            this.label25.TabIndex = 100;
            this.label25.Text = "[V]";
            // 
            // label41
            // 
            this.label41.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label41.Location = new System.Drawing.Point(713, 70);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(318, 41);
            this.label41.TabIndex = 99;
            this.label41.Text = "Determine range of voltage which is used to control mass flow controller";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label42.Location = new System.Drawing.Point(339, 70);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(321, 60);
            this.label42.TabIndex = 98;
            this.label42.Text = "Determine maximum flow how we can set on correspondinf controler. This value is i" +
    "dentifies by type of controller";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label31.Location = new System.Drawing.Point(53, 498);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(1232, 37);
            this.label31.TabIndex = 97;
            this.label31.Text = "Waiting time on stabilization value  to setpoint. After this time  we check to se" +
    "e if the value is within a specified range.";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timeFlowStabilization
            // 
            this.timeFlowStabilization.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeFlowStabilization.Location = new System.Drawing.Point(342, 551);
            this.timeFlowStabilization.Name = "timeFlowStabilization";
            this.timeFlowStabilization.ShowUpDown = true;
            this.timeFlowStabilization.Size = new System.Drawing.Size(100, 27);
            this.timeFlowStabilization.TabIndex = 96;
            this.timeFlowStabilization.ValueChanged += new System.EventHandler(this.timeFlowStabilization_ValueChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label32.Location = new System.Drawing.Point(102, 556);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(180, 20);
            this.label32.TabIndex = 95;
            this.label32.Text = "Time flow stabilization:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.Green;
            this.label29.Location = new System.Drawing.Point(925, 245);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(30, 20);
            this.label29.TabIndex = 90;
            this.label29.Text = "[V]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Green;
            this.label13.Location = new System.Drawing.Point(522, 299);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 20);
            this.label13.TabIndex = 87;
            this.label13.Text = "[sccm]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Green;
            this.label11.Location = new System.Drawing.Point(522, 341);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 20);
            this.label11.TabIndex = 84;
            this.label11.Text = "[sccm]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(522, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 81;
            this.label9.Text = "[sccm]";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Transparent;
            this.tabPage5.Controls.Add(this.btnReadSettings_1);
            this.tabPage5.Controls.Add(this.label35);
            this.tabPage5.Controls.Add(this.label33);
            this.tabPage5.Controls.Add(this.timePumpToSV);
            this.tabPage5.Controls.Add(this.timeWaitPF);
            this.tabPage5.Controls.Add(this.label38);
            this.tabPage5.Controls.Add(this.label34);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1692, 762);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "           Pump            ";
            // 
            // btnReadSettings_1
            // 
            this.btnReadSettings_1.Location = new System.Drawing.Point(1467, 715);
            this.btnReadSettings_1.Name = "btnReadSettings_1";
            this.btnReadSettings_1.Size = new System.Drawing.Size(213, 35);
            this.btnReadSettings_1.TabIndex = 102;
            this.btnReadSettings_1.Text = "Read settings from PLC";
            this.btnReadSettings_1.UseVisualStyleBackColor = true;
            this.btnReadSettings_1.Click += new System.EventHandler(this.btnReadSettings_Click);
            // 
            // label35
            // 
            this.label35.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label35.Location = new System.Drawing.Point(74, 256);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(590, 28);
            this.label35.TabIndex = 75;
            this.label35.Text = "Time pumping of section  chamber from fore pump to SV valve";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label33.Location = new System.Drawing.Point(74, 91);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(634, 28);
            this.label33.TabIndex = 74;
            this.label33.Text = "Waiting time for confirmation of correct state of fore pump after change state";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timePumpToSV
            // 
            this.timePumpToSV.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePumpToSV.Location = new System.Drawing.Point(311, 297);
            this.timePumpToSV.Name = "timePumpToSV";
            this.timePumpToSV.ShowUpDown = true;
            this.timePumpToSV.Size = new System.Drawing.Size(100, 27);
            this.timePumpToSV.TabIndex = 73;
            this.timePumpToSV.ValueChanged += new System.EventHandler(this.timePumpToSV_ValueChanged);
            // 
            // timeWaitPF
            // 
            this.timeWaitPF.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeWaitPF.Location = new System.Drawing.Point(311, 134);
            this.timeWaitPF.Name = "timeWaitPF";
            this.timeWaitPF.ShowUpDown = true;
            this.timeWaitPF.Size = new System.Drawing.Size(100, 27);
            this.timeWaitPF.TabIndex = 72;
            this.timeWaitPF.ValueChanged += new System.EventHandler(this.timeWaitPF_ValueChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label38.Location = new System.Drawing.Point(123, 302);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(148, 20);
            this.label38.TabIndex = 70;
            this.label38.Text = "Time pump to SV :";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label34.Location = new System.Drawing.Point(123, 139);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(135, 20);
            this.label34.TabIndex = 69;
            this.label34.Text = "Time wait on PF:";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.Transparent;
            this.tabPage6.Controls.Add(this.btnRemoveGas);
            this.tabPage6.Controls.Add(this.tBoxNameGas);
            this.tabPage6.Controls.Add(this.label14);
            this.tabPage6.Controls.Add(this.btnNewGas);
            this.tabPage6.Controls.Add(this.btnSaveSettings);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Controls.Add(this.tBoxGasDescription);
            this.tabPage6.Controls.Add(this.cBoxGasType);
            this.tabPage6.Controls.Add(this.label28);
            this.tabPage6.Controls.Add(this.label26);
            this.tabPage6.Controls.Add(this.label10);
            this.tabPage6.Controls.Add(this.dEditFactorGas);
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1692, 762);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "             Gases             ";
            // 
            // btnRemoveGas
            // 
            this.btnRemoveGas.Location = new System.Drawing.Point(295, 479);
            this.btnRemoveGas.Name = "btnRemoveGas";
            this.btnRemoveGas.Size = new System.Drawing.Size(332, 35);
            this.btnRemoveGas.TabIndex = 87;
            this.btnRemoveGas.Text = "Remove";
            this.btnRemoveGas.UseVisualStyleBackColor = true;
            this.btnRemoveGas.Click += new System.EventHandler(this.btnRemoveGas_Click);
            // 
            // tBoxNameGas
            // 
            this.tBoxNameGas.Location = new System.Drawing.Point(295, 158);
            this.tBoxNameGas.Name = "tBoxNameGas";
            this.tBoxNameGas.Size = new System.Drawing.Size(148, 27);
            this.tBoxNameGas.TabIndex = 86;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(103, 161);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 20);
            this.label14.TabIndex = 85;
            this.label14.Text = "Gas name:";
            // 
            // btnNewGas
            // 
            this.btnNewGas.Location = new System.Drawing.Point(295, 435);
            this.btnNewGas.Name = "btnNewGas";
            this.btnNewGas.Size = new System.Drawing.Size(160, 35);
            this.btnNewGas.TabIndex = 84;
            this.btnNewGas.Text = "New";
            this.btnNewGas.UseVisualStyleBackColor = true;
            this.btnNewGas.Click += new System.EventHandler(this.btnNewGas_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(467, 435);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(160, 35);
            this.btnSaveSettings.TabIndex = 81;
            this.btnSaveSettings.Text = "Modify";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(103, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 20);
            this.label12.TabIndex = 80;
            this.label12.Text = "Description:";
            // 
            // tBoxGasDescription
            // 
            this.tBoxGasDescription.Location = new System.Drawing.Point(295, 226);
            this.tBoxGasDescription.Multiline = true;
            this.tBoxGasDescription.Name = "tBoxGasDescription";
            this.tBoxGasDescription.Size = new System.Drawing.Size(332, 114);
            this.tBoxGasDescription.TabIndex = 77;
            // 
            // cBoxGasType
            // 
            this.cBoxGasType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxGasType.FormattingEnabled = true;
            this.cBoxGasType.Location = new System.Drawing.Point(295, 91);
            this.cBoxGasType.Name = "cBoxGasType";
            this.cBoxGasType.Size = new System.Drawing.Size(150, 28);
            this.cBoxGasType.TabIndex = 76;
            this.cBoxGasType.SelectedIndexChanged += new System.EventHandler(this.cBoxGasType_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label28.Location = new System.Drawing.Point(103, 381);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(140, 20);
            this.label28.TabIndex = 73;
            this.label28.Text = "Correction factor:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label26.Location = new System.Drawing.Point(103, 91);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(81, 20);
            this.label26.TabIndex = 72;
            this.label26.Text = "Gas type:";
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(54, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(758, 29);
            this.label10.TabIndex = 70;
            this.label10.Text = "Description of available gases which might be connection to device";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dEditRangeVoltage
            // 
            this.dEditRangeVoltage.Location = new System.Drawing.Point(345, 342);
            this.dEditRangeVoltage.Margin = new System.Windows.Forms.Padding(8);
            this.dEditRangeVoltage.Mask = "0.000";
            this.dEditRangeVoltage.MaximumValue = 5000D;
            this.dEditRangeVoltage.MinimumValue = 0D;
            this.dEditRangeVoltage.Name = "dEditRangeVoltage";
            this.dEditRangeVoltage.ReadOnly = false;
            this.dEditRangeVoltage.Size = new System.Drawing.Size(100, 28);
            this.dEditRangeVoltage.TabIndex = 84;
            this.dEditRangeVoltage.Value = 0D;
            this.dEditRangeVoltage.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditRangeVoltage_EnterOn);
            // 
            // dEditRangeCurent
            // 
            this.dEditRangeCurent.Location = new System.Drawing.Point(345, 389);
            this.dEditRangeCurent.Margin = new System.Windows.Forms.Padding(8);
            this.dEditRangeCurent.Mask = "0.000";
            this.dEditRangeCurent.MaximumValue = 5000D;
            this.dEditRangeCurent.MinimumValue = 0D;
            this.dEditRangeCurent.Name = "dEditRangeCurent";
            this.dEditRangeCurent.ReadOnly = false;
            this.dEditRangeCurent.Size = new System.Drawing.Size(100, 28);
            this.dEditRangeCurent.TabIndex = 83;
            this.dEditRangeCurent.Value = 0D;
            this.dEditRangeCurent.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditRangeCurent_EnterOn);
            // 
            // dEditRangePower
            // 
            this.dEditRangePower.Location = new System.Drawing.Point(345, 298);
            this.dEditRangePower.Margin = new System.Windows.Forms.Padding(6);
            this.dEditRangePower.Mask = "0.000";
            this.dEditRangePower.MaximumValue = 5000D;
            this.dEditRangePower.MinimumValue = 0D;
            this.dEditRangePower.Name = "dEditRangePower";
            this.dEditRangePower.ReadOnly = false;
            this.dEditRangePower.Size = new System.Drawing.Size(100, 28);
            this.dEditRangePower.TabIndex = 82;
            this.dEditRangePower.Value = 0D;
            this.dEditRangePower.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditRangePower_EnterOn);
            // 
            // dEditVoltageLimit
            // 
            this.dEditVoltageLimit.Location = new System.Drawing.Point(345, 129);
            this.dEditVoltageLimit.Margin = new System.Windows.Forms.Padding(6);
            this.dEditVoltageLimit.Mask = "0.000";
            this.dEditVoltageLimit.MaximumValue = 5000D;
            this.dEditVoltageLimit.MinimumValue = 0D;
            this.dEditVoltageLimit.Name = "dEditVoltageLimit";
            this.dEditVoltageLimit.ReadOnly = false;
            this.dEditVoltageLimit.Size = new System.Drawing.Size(100, 28);
            this.dEditVoltageLimit.TabIndex = 75;
            this.dEditVoltageLimit.Value = 0D;
            this.dEditVoltageLimit.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditVoltageLimit_EnterOn);
            // 
            // dEditCurentLimit
            // 
            this.dEditCurentLimit.Location = new System.Drawing.Point(345, 175);
            this.dEditCurentLimit.Margin = new System.Windows.Forms.Padding(6);
            this.dEditCurentLimit.Mask = "0.000";
            this.dEditCurentLimit.MaximumValue = 5000D;
            this.dEditCurentLimit.MinimumValue = 0D;
            this.dEditCurentLimit.Name = "dEditCurentLimit";
            this.dEditCurentLimit.ReadOnly = false;
            this.dEditCurentLimit.Size = new System.Drawing.Size(100, 28);
            this.dEditCurentLimit.TabIndex = 74;
            this.dEditCurentLimit.Value = 0D;
            this.dEditCurentLimit.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditCurentLimit_EnterOn);
            // 
            // dEditPowerLimit
            // 
            this.dEditPowerLimit.Location = new System.Drawing.Point(345, 84);
            this.dEditPowerLimit.Margin = new System.Windows.Forms.Padding(5);
            this.dEditPowerLimit.Mask = "0.000";
            this.dEditPowerLimit.MaximumValue = 5000D;
            this.dEditPowerLimit.MinimumValue = 0D;
            this.dEditPowerLimit.Name = "dEditPowerLimit";
            this.dEditPowerLimit.ReadOnly = false;
            this.dEditPowerLimit.Size = new System.Drawing.Size(100, 28);
            this.dEditPowerLimit.TabIndex = 73;
            this.dEditPowerLimit.Value = 0D;
            this.dEditPowerLimit.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditPowerLimit_EnterOn);
            // 
            // dEditRangeVoltageMFC2
            // 
            this.dEditRangeVoltageMFC2.Location = new System.Drawing.Point(754, 288);
            this.dEditRangeVoltageMFC2.Margin = new System.Windows.Forms.Padding(12);
            this.dEditRangeVoltageMFC2.Mask = "0.00";
            this.dEditRangeVoltageMFC2.MaximumValue = 10000000D;
            this.dEditRangeVoltageMFC2.MinimumValue = 0D;
            this.dEditRangeVoltageMFC2.Name = "dEditRangeVoltageMFC2";
            this.dEditRangeVoltageMFC2.ReadOnly = false;
            this.dEditRangeVoltageMFC2.Size = new System.Drawing.Size(100, 27);
            this.dEditRangeVoltageMFC2.TabIndex = 93;
            this.dEditRangeVoltageMFC2.Value = 0D;
            this.dEditRangeVoltageMFC2.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditRangeVoltageMFC2_EnterOn);
            // 
            // dEditRangeVoltageMFC3
            // 
            this.dEditRangeVoltageMFC3.Location = new System.Drawing.Point(754, 341);
            this.dEditRangeVoltageMFC3.Margin = new System.Windows.Forms.Padding(12);
            this.dEditRangeVoltageMFC3.Mask = "0.00";
            this.dEditRangeVoltageMFC3.MaximumValue = 10000000D;
            this.dEditRangeVoltageMFC3.MinimumValue = 0D;
            this.dEditRangeVoltageMFC3.Name = "dEditRangeVoltageMFC3";
            this.dEditRangeVoltageMFC3.ReadOnly = false;
            this.dEditRangeVoltageMFC3.Size = new System.Drawing.Size(100, 27);
            this.dEditRangeVoltageMFC3.TabIndex = 91;
            this.dEditRangeVoltageMFC3.Value = 0D;
            this.dEditRangeVoltageMFC3.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditRangeVoltageMFC3_EnterOn);
            // 
            // dEditRangeVoltageMFC1
            // 
            this.dEditRangeVoltageMFC1.Location = new System.Drawing.Point(754, 241);
            this.dEditRangeVoltageMFC1.Margin = new System.Windows.Forms.Padding(10);
            this.dEditRangeVoltageMFC1.Mask = "0.00";
            this.dEditRangeVoltageMFC1.MaximumValue = 10000000D;
            this.dEditRangeVoltageMFC1.MinimumValue = 0D;
            this.dEditRangeVoltageMFC1.Name = "dEditRangeVoltageMFC1";
            this.dEditRangeVoltageMFC1.ReadOnly = false;
            this.dEditRangeVoltageMFC1.Size = new System.Drawing.Size(100, 27);
            this.dEditRangeVoltageMFC1.TabIndex = 88;
            this.dEditRangeVoltageMFC1.Value = 0D;
            this.dEditRangeVoltageMFC1.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditRangeVoltageMFC1_EnterOn);
            // 
            // dEditMaxFlow_MFC2
            // 
            this.dEditMaxFlow_MFC2.Location = new System.Drawing.Point(362, 296);
            this.dEditMaxFlow_MFC2.Margin = new System.Windows.Forms.Padding(10);
            this.dEditMaxFlow_MFC2.Mask = "0.000";
            this.dEditMaxFlow_MFC2.MaximumValue = 10000000D;
            this.dEditMaxFlow_MFC2.MinimumValue = 0D;
            this.dEditMaxFlow_MFC2.Name = "dEditMaxFlow_MFC2";
            this.dEditMaxFlow_MFC2.ReadOnly = false;
            this.dEditMaxFlow_MFC2.Size = new System.Drawing.Size(100, 27);
            this.dEditMaxFlow_MFC2.TabIndex = 85;
            this.dEditMaxFlow_MFC2.Value = 0D;
            this.dEditMaxFlow_MFC2.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditMaxFlow_MFC2_EnterOn);
            // 
            // dEditMaxFlow_MFC3
            // 
            this.dEditMaxFlow_MFC3.Location = new System.Drawing.Point(362, 341);
            this.dEditMaxFlow_MFC3.Margin = new System.Windows.Forms.Padding(10);
            this.dEditMaxFlow_MFC3.Mask = "0.000";
            this.dEditMaxFlow_MFC3.MaximumValue = 10000000D;
            this.dEditMaxFlow_MFC3.MinimumValue = 0D;
            this.dEditMaxFlow_MFC3.Name = "dEditMaxFlow_MFC3";
            this.dEditMaxFlow_MFC3.ReadOnly = false;
            this.dEditMaxFlow_MFC3.Size = new System.Drawing.Size(100, 27);
            this.dEditMaxFlow_MFC3.TabIndex = 82;
            this.dEditMaxFlow_MFC3.Value = 0D;
            this.dEditMaxFlow_MFC3.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditMaxFlow_MFC3_EnterOn);
            // 
            // dEditMaxFlow_MFC1
            // 
            this.dEditMaxFlow_MFC1.Location = new System.Drawing.Point(362, 251);
            this.dEditMaxFlow_MFC1.Margin = new System.Windows.Forms.Padding(8);
            this.dEditMaxFlow_MFC1.Mask = "0.000";
            this.dEditMaxFlow_MFC1.MaximumValue = 10000000D;
            this.dEditMaxFlow_MFC1.MinimumValue = 0D;
            this.dEditMaxFlow_MFC1.Name = "dEditMaxFlow_MFC1";
            this.dEditMaxFlow_MFC1.ReadOnly = false;
            this.dEditMaxFlow_MFC1.Size = new System.Drawing.Size(100, 27);
            this.dEditMaxFlow_MFC1.TabIndex = 79;
            this.dEditMaxFlow_MFC1.Value = 0D;
            this.dEditMaxFlow_MFC1.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditMaxFlow_MFC1_EnterOn);
            // 
            // dEditFactorGas
            // 
            this.dEditFactorGas.Location = new System.Drawing.Point(295, 378);
            this.dEditFactorGas.Margin = new System.Windows.Forms.Padding(4);
            this.dEditFactorGas.Mask = "0.000";
            this.dEditFactorGas.MaximumValue = 1000D;
            this.dEditFactorGas.MinimumValue = 0D;
            this.dEditFactorGas.Name = "dEditFactorGas";
            this.dEditFactorGas.ReadOnly = false;
            this.dEditFactorGas.Size = new System.Drawing.Size(143, 29);
            this.dEditFactorGas.TabIndex = 74;
            this.dEditFactorGas.Value = 0D;
            // 
            // ServicePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "ServicePanel";
            this.Size = new System.Drawing.Size(1700, 800);
            this.Load += new System.EventHandler(this.ServicePanel_Load);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker timeWaitOnOperate;
        private System.Windows.Forms.DateTimePicker timeSetpointStabilization;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private Cotrols.DoubleEdit dEditRangeVoltage;
        private Cotrols.DoubleEdit dEditRangeCurent;
        private Cotrols.DoubleEdit dEditRangePower;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Cotrols.DoubleEdit dEditVoltageLimit;
        private Cotrols.DoubleEdit dEditCurentLimit;
        private Cotrols.DoubleEdit dEditPowerLimit;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.CheckBox cBoxMFC3;
        private System.Windows.Forms.CheckBox cBoxMFC2;
        private System.Windows.Forms.CheckBox cBoxMFC1;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.DateTimePicker timeFlowStabilization;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private Cotrols.DoubleEdit dEditRangeVoltageMFC2;
        private Cotrols.DoubleEdit dEditRangeVoltageMFC3;
        private Cotrols.DoubleEdit dEditRangeVoltageMFC1;
        private Cotrols.DoubleEdit dEditMaxFlow_MFC2;
        private Cotrols.DoubleEdit dEditMaxFlow_MFC3;
        private Cotrols.DoubleEdit dEditMaxFlow_MFC1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.DateTimePicker timePumpToSV;
        private System.Windows.Forms.DateTimePicker timeWaitPF;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnRemoveGas;
        private System.Windows.Forms.TextBox tBoxNameGas;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnNewGas;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tBoxGasDescription;
        private System.Windows.Forms.ComboBox cBoxGasType;
        private Cotrols.DoubleEdit dEditFactorGas;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnReadSetingsPLC_1;
        private System.Windows.Forms.Button btnReadSettings;
        private System.Windows.Forms.Button btnReadSettings_1;
    }
}
