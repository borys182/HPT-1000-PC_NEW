namespace HPT1000.GUI
{
    partial class SettingsPanel
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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cBoxComm = new System.Windows.Forms.ComboBox();
            this.cBoxDummyMode = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labConnectionExplain = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.cBoxLanguge = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tBoxPath = new System.Windows.Forms.TextBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.cBoxEnabledAcq = new System.Windows.Forms.CheckBox();
            this.btnSelectDir = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.treeViewDevices = new System.Windows.Forms.TreeView();
            this.label10 = new System.Windows.Forms.Label();
            this.grBoxDevice = new System.Windows.Forms.GroupBox();
            this.rBtnAcqDuringProcess = new System.Windows.Forms.RadioButton();
            this.rBtnAcqAllTime = new System.Windows.Forms.RadioButton();
            this.cBoxActivePressure = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.labUnitPressure = new System.Windows.Forms.Label();
            this.labPressure = new System.Windows.Forms.Label();
            this.grBoxParameter = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cBoxMode = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxParaActive = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labParaUnit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dEditAcqPressure = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditDifferencesValue = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditFrqAcq = new HPT1000.GUI.Cotrols.DoubleEdit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grBoxDevice.SuspendLayout();
            this.grBoxParameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1690, 790);
            this.tabControl1.TabIndex = 108;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.cBoxComm);
            this.tabPage1.Controls.Add(this.cBoxDummyMode);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.labConnectionExplain);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label45);
            this.tabPage1.Controls.Add(this.cBoxLanguge);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1682, 757);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "           Global           ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label15.Location = new System.Drawing.Point(67, 355);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(430, 21);
            this.label15.TabIndex = 116;
            this.label15.Text = "Determins is program should generete radom values";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label14.Location = new System.Drawing.Point(67, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(430, 21);
            this.label14.TabIndex = 115;
            this.label14.Text = "Select language for application";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cBoxComm
            // 
            this.cBoxComm.FormattingEnabled = true;
            this.cBoxComm.Items.AddRange(new object[] {
            "USB",
            "TCP"});
            this.cBoxComm.Location = new System.Drawing.Point(293, 261);
            this.cBoxComm.Name = "cBoxComm";
            this.cBoxComm.Size = new System.Drawing.Size(132, 28);
            this.cBoxComm.TabIndex = 113;
            this.cBoxComm.SelectedIndexChanged += new System.EventHandler(this.cBoxComm_SelectedIndexChanged);
            // 
            // cBoxDummyMode
            // 
            this.cBoxDummyMode.AutoSize = true;
            this.cBoxDummyMode.Location = new System.Drawing.Point(293, 400);
            this.cBoxDummyMode.Name = "cBoxDummyMode";
            this.cBoxDummyMode.Size = new System.Drawing.Size(135, 24);
            this.cBoxDummyMode.TabIndex = 111;
            this.cBoxDummyMode.Text = "Dummy mode";
            this.cBoxDummyMode.UseVisualStyleBackColor = true;
            this.cBoxDummyMode.CheckedChanged += new System.EventHandler(this.cBoxDummyMode_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(97, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 110;
            this.label4.Text = "Dummy mode:";
            // 
            // labConnectionExplain
            // 
            this.labConnectionExplain.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labConnectionExplain.Location = new System.Drawing.Point(67, 213);
            this.labConnectionExplain.Name = "labConnectionExplain";
            this.labConnectionExplain.Size = new System.Drawing.Size(430, 21);
            this.labConnectionExplain.TabIndex = 114;
            this.labConnectionExplain.Text = "Select kind of connection with PLC which you using";
            this.labConnectionExplain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(97, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 112;
            this.label1.Text = "Connection type:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label45.Location = new System.Drawing.Point(97, 125);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(146, 20);
            this.label45.TabIndex = 108;
            this.label45.Text = "Start-up language:";
            // 
            // cBoxLanguge
            // 
            this.cBoxLanguge.FormattingEnabled = true;
            this.cBoxLanguge.Items.AddRange(new object[] {
            "English"});
            this.cBoxLanguge.Location = new System.Drawing.Point(293, 122);
            this.cBoxLanguge.Name = "cBoxLanguge";
            this.cBoxLanguge.Size = new System.Drawing.Size(141, 28);
            this.cBoxLanguge.TabIndex = 109;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1682, 757);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "     Acquisition     ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.treeViewDevices);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.grBoxDevice);
            this.groupBox3.Controls.Add(this.grBoxParameter);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1676, 751);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Acquisition configuration";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.tBoxPath);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.cBoxEnabledAcq);
            this.groupBox2.Controls.Add(this.btnSelectDir);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label48);
            this.groupBox2.Location = new System.Drawing.Point(418, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1192, 161);
            this.groupBox2.TabIndex = 108;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enabled acquisition";
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label16.Location = new System.Drawing.Point(38, 83);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(866, 22);
            this.label16.TabIndex = 124;
            this.label16.Text = "Determine conditions for automatic data report generated";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tBoxPath
            // 
            this.tBoxPath.Location = new System.Drawing.Point(385, 117);
            this.tBoxPath.Name = "tBoxPath";
            this.tBoxPath.Size = new System.Drawing.Size(726, 27);
            this.tBoxPath.TabIndex = 122;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(88, 119);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(226, 24);
            this.checkBox4.TabIndex = 118;
            this.checkBox4.Text = "Perform at end of process";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // cBoxEnabledAcq
            // 
            this.cBoxEnabledAcq.AutoSize = true;
            this.cBoxEnabledAcq.Location = new System.Drawing.Point(88, 56);
            this.cBoxEnabledAcq.Name = "cBoxEnabledAcq";
            this.cBoxEnabledAcq.Size = new System.Drawing.Size(176, 24);
            this.cBoxEnabledAcq.TabIndex = 106;
            this.cBoxEnabledAcq.Text = "Enabled acquisition";
            this.cBoxEnabledAcq.UseVisualStyleBackColor = true;
            this.cBoxEnabledAcq.CheckedChanged += new System.EventHandler(this.cBoxEnabledAcq_CheckedChanged);
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Location = new System.Drawing.Point(1117, 115);
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.Size = new System.Drawing.Size(55, 30);
            this.btnSelectDir.TabIndex = 123;
            this.btnSelectDir.Text = "...";
            this.btnSelectDir.UseVisualStyleBackColor = true;
            this.btnSelectDir.Click += new System.EventHandler(this.btnSelectDir_Click);
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label13.Location = new System.Drawing.Point(38, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(866, 22);
            this.label13.TabIndex = 107;
            this.label13.Text = "Determine if data should be automatically saved in archive";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label48.Location = new System.Drawing.Point(325, 120);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(48, 20);
            this.label48.TabIndex = 121;
            this.label48.Text = "Path:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(31, 690);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(357, 39);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save configuration";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // treeViewDevices
            // 
            this.treeViewDevices.Location = new System.Drawing.Point(31, 68);
            this.treeViewDevices.Name = "treeViewDevices";
            this.treeViewDevices.Size = new System.Drawing.Size(357, 615);
            this.treeViewDevices.TabIndex = 9;
            this.treeViewDevices.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDevices_AfterSelect);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(296, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "List all parameters add data to archive";
            // 
            // grBoxDevice
            // 
            this.grBoxDevice.Controls.Add(this.rBtnAcqDuringProcess);
            this.grBoxDevice.Controls.Add(this.rBtnAcqAllTime);
            this.grBoxDevice.Controls.Add(this.cBoxActivePressure);
            this.grBoxDevice.Controls.Add(this.label7);
            this.grBoxDevice.Controls.Add(this.label40);
            this.grBoxDevice.Controls.Add(this.dEditAcqPressure);
            this.grBoxDevice.Controls.Add(this.labUnitPressure);
            this.grBoxDevice.Controls.Add(this.labPressure);
            this.grBoxDevice.Location = new System.Drawing.Point(418, 207);
            this.grBoxDevice.Name = "grBoxDevice";
            this.grBoxDevice.Size = new System.Drawing.Size(1193, 190);
            this.grBoxDevice.TabIndex = 7;
            this.grBoxDevice.TabStop = false;
            this.grBoxDevice.Text = "Conditions of start acquisition all data";
            // 
            // rBtnAcqDuringProcess
            // 
            this.rBtnAcqDuringProcess.AutoSize = true;
            this.rBtnAcqDuringProcess.Location = new System.Drawing.Point(88, 154);
            this.rBtnAcqDuringProcess.Name = "rBtnAcqDuringProcess";
            this.rBtnAcqDuringProcess.Size = new System.Drawing.Size(233, 24);
            this.rBtnAcqDuringProcess.TabIndex = 105;
            this.rBtnAcqDuringProcess.TabStop = true;
            this.rBtnAcqDuringProcess.Text = "Acquisioton during process";
            this.rBtnAcqDuringProcess.UseVisualStyleBackColor = true;
            this.rBtnAcqDuringProcess.CheckedChanged += new System.EventHandler(this.rBtnAcqDuringProcess_CheckedChanged);
            // 
            // rBtnAcqAllTime
            // 
            this.rBtnAcqAllTime.AutoSize = true;
            this.rBtnAcqAllTime.Location = new System.Drawing.Point(395, 154);
            this.rBtnAcqAllTime.Name = "rBtnAcqAllTime";
            this.rBtnAcqAllTime.Size = new System.Drawing.Size(171, 24);
            this.rBtnAcqAllTime.TabIndex = 104;
            this.rBtnAcqAllTime.TabStop = true;
            this.rBtnAcqAllTime.Text = "Acquisition all time";
            this.rBtnAcqAllTime.UseVisualStyleBackColor = true;
            this.rBtnAcqAllTime.CheckedChanged += new System.EventHandler(this.rBtnAcqAllTime_CheckedChanged);
            // 
            // cBoxActivePressure
            // 
            this.cBoxActivePressure.AutoSize = true;
            this.cBoxActivePressure.Location = new System.Drawing.Point(573, 85);
            this.cBoxActivePressure.Name = "cBoxActivePressure";
            this.cBoxActivePressure.Size = new System.Drawing.Size(127, 24);
            this.cBoxActivePressure.TabIndex = 103;
            this.cBoxActivePressure.Text = "Active option";
            this.cBoxActivePressure.UseVisualStyleBackColor = true;
            this.cBoxActivePressure.CheckedChanged += new System.EventHandler(this.cBoxActivePressure_CheckedChanged);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(38, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(866, 25);
            this.label7.TabIndex = 102;
            this.label7.Text = "Checkbox determines if parameters data of chamber should be saved in data archive" +
    " only during a process";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label40.Location = new System.Drawing.Point(38, 26);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(1149, 53);
            this.label40.TabIndex = 100;
            this.label40.Text = "Parameter determine level of pressure when parameter data of chamber will be save" +
    "d in data archive. Data will be saved when pressure will be less than set value";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labUnitPressure
            // 
            this.labUnitPressure.AutoSize = true;
            this.labUnitPressure.ForeColor = System.Drawing.Color.Green;
            this.labUnitPressure.Location = new System.Drawing.Point(462, 86);
            this.labUnitPressure.Name = "labUnitPressure";
            this.labUnitPressure.Size = new System.Drawing.Size(60, 20);
            this.labUnitPressure.TabIndex = 4;
            this.labUnitPressure.Text = "[mBar]";
            // 
            // labPressure
            // 
            this.labPressure.AutoSize = true;
            this.labPressure.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labPressure.Location = new System.Drawing.Point(84, 86);
            this.labPressure.Name = "labPressure";
            this.labPressure.Size = new System.Drawing.Size(153, 20);
            this.labPressure.TabIndex = 3;
            this.labPressure.Text = "Start acq pressure:";
            // 
            // grBoxParameter
            // 
            this.grBoxParameter.Controls.Add(this.label12);
            this.grBoxParameter.Controls.Add(this.cBoxMode);
            this.grBoxParameter.Controls.Add(this.label11);
            this.grBoxParameter.Controls.Add(this.label2);
            this.grBoxParameter.Controls.Add(this.cBoxParaActive);
            this.grBoxParameter.Controls.Add(this.label9);
            this.grBoxParameter.Controls.Add(this.label8);
            this.grBoxParameter.Controls.Add(this.labParaUnit);
            this.grBoxParameter.Controls.Add(this.dEditDifferencesValue);
            this.grBoxParameter.Controls.Add(this.label3);
            this.grBoxParameter.Controls.Add(this.dEditFrqAcq);
            this.grBoxParameter.Controls.Add(this.label5);
            this.grBoxParameter.Controls.Add(this.label6);
            this.grBoxParameter.Location = new System.Drawing.Point(419, 397);
            this.grBoxParameter.Name = "grBoxParameter";
            this.grBoxParameter.Size = new System.Drawing.Size(1192, 332);
            this.grBoxParameter.TabIndex = 5;
            this.grBoxParameter.TabStop = false;
            this.grBoxParameter.Text = "Parameter configuration";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(83, 283);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 20);
            this.label12.TabIndex = 109;
            this.label12.Text = "Mode:";
            // 
            // cBoxMode
            // 
            this.cBoxMode.FormattingEnabled = true;
            this.cBoxMode.Location = new System.Drawing.Point(281, 280);
            this.cBoxMode.Name = "cBoxMode";
            this.cBoxMode.Size = new System.Drawing.Size(148, 28);
            this.cBoxMode.TabIndex = 108;
            this.cBoxMode.SelectedIndexChanged += new System.EventHandler(this.cBoxMode_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(46, 240);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1003, 23);
            this.label11.TabIndex = 107;
            this.label11.Text = "Determines is value will be save on event frequency , difference value or mixed b" +
    "oth";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(37, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(866, 22);
            this.label2.TabIndex = 106;
            this.label2.Text = "Determine is value of parameter is saved in archive";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cBoxParaActive
            // 
            this.cBoxParaActive.AutoSize = true;
            this.cBoxParaActive.Location = new System.Drawing.Point(87, 59);
            this.cBoxParaActive.Name = "cBoxParaActive";
            this.cBoxParaActive.Size = new System.Drawing.Size(257, 24);
            this.cBoxParaActive.TabIndex = 105;
            this.cBoxParaActive.Text = "Enabled parameter acquisition";
            this.cBoxParaActive.UseVisualStyleBackColor = true;
            this.cBoxParaActive.CheckedChanged += new System.EventHandler(this.cBoxParaActive_CheckedChanged);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(37, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1134, 42);
            this.label9.TabIndex = 104;
            this.label9.Text = "Parameter determines level of differences between actual and last value when data" +
    " of chamber parameters should be saved in archive.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(37, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1012, 24);
            this.label8.TabIndex = 103;
            this.label8.Text = "Parameter determines how often data of chamber parameters should be saved in  arc" +
    "hive.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labParaUnit
            // 
            this.labParaUnit.AutoSize = true;
            this.labParaUnit.ForeColor = System.Drawing.Color.Green;
            this.labParaUnit.Location = new System.Drawing.Point(461, 202);
            this.labParaUnit.Name = "labParaUnit";
            this.labParaUnit.Size = new System.Drawing.Size(35, 20);
            this.labParaUnit.TabIndex = 5;
            this.labParaUnit.Text = "[W]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(83, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Difference values:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(461, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "[s]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(83, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Frequency:";
            // 
            // dEditAcqPressure
            // 
            this.dEditAcqPressure.Location = new System.Drawing.Point(282, 79);
            this.dEditAcqPressure.Margin = new System.Windows.Forms.Padding(5);
            this.dEditAcqPressure.Mask = "0.000";
            this.dEditAcqPressure.MaximumValue = 1200D;
            this.dEditAcqPressure.MinimumValue = 0D;
            this.dEditAcqPressure.Name = "dEditAcqPressure";
            this.dEditAcqPressure.ReadOnly = false;
            this.dEditAcqPressure.Size = new System.Drawing.Size(146, 22);
            this.dEditAcqPressure.TabIndex = 5;
            this.dEditAcqPressure.Value = 0D;
            this.dEditAcqPressure.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditAcqPressure_EnterOn);
            // 
            // dEditDifferencesValue
            // 
            this.dEditDifferencesValue.Location = new System.Drawing.Point(281, 202);
            this.dEditDifferencesValue.Mask = "0.000";
            this.dEditDifferencesValue.MaximumValue = 10000000D;
            this.dEditDifferencesValue.MinimumValue = 0D;
            this.dEditDifferencesValue.Name = "dEditDifferencesValue";
            this.dEditDifferencesValue.ReadOnly = false;
            this.dEditDifferencesValue.Size = new System.Drawing.Size(148, 22);
            this.dEditDifferencesValue.TabIndex = 4;
            this.dEditDifferencesValue.Value = 0D;
            this.dEditDifferencesValue.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditDifferencesValue_EnterOn);
            // 
            // dEditFrqAcq
            // 
            this.dEditFrqAcq.Location = new System.Drawing.Point(281, 124);
            this.dEditFrqAcq.Mask = "0.000";
            this.dEditFrqAcq.MaximumValue = 3600000D;
            this.dEditFrqAcq.MinimumValue = 0.5D;
            this.dEditFrqAcq.Name = "dEditFrqAcq";
            this.dEditFrqAcq.ReadOnly = false;
            this.dEditFrqAcq.Size = new System.Drawing.Size(148, 22);
            this.dEditFrqAcq.TabIndex = 2;
            this.dEditFrqAcq.Value = 0.5D;
            this.dEditFrqAcq.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditFrqAcq_EnterOn);
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(1690, 790);
            this.Load += new System.EventHandler(this.SettingsPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grBoxDevice.ResumeLayout(false);
            this.grBoxDevice.PerformLayout();
            this.grBoxParameter.ResumeLayout(false);
            this.grBoxParameter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cBoxComm;
        private System.Windows.Forms.CheckBox cBoxDummyMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labConnectionExplain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox cBoxLanguge;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cBoxEnabledAcq;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TreeView treeViewDevices;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grBoxDevice;
        private System.Windows.Forms.RadioButton rBtnAcqDuringProcess;
        private System.Windows.Forms.RadioButton rBtnAcqAllTime;
        private System.Windows.Forms.CheckBox cBoxActivePressure;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label40;
        private Cotrols.DoubleEdit dEditAcqPressure;
        private System.Windows.Forms.Label labUnitPressure;
        private System.Windows.Forms.Label labPressure;
        private System.Windows.Forms.GroupBox grBoxParameter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cBoxMode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cBoxParaActive;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labParaUnit;
        private Cotrols.DoubleEdit dEditDifferencesValue;
        private System.Windows.Forms.Label label3;
        private Cotrols.DoubleEdit dEditFrqAcq;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tBoxPath;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Button btnSelectDir;
        private System.Windows.Forms.Label label16;
    }
}
