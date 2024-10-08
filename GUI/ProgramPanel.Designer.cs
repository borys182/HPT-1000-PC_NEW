﻿namespace HPT1000.GUI
{
    partial class ProgramPanel
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Pump",
            "Working"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Gas",
            "Wait"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Plasma");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Purge");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Vent");
            this.label4 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.listViewSubprograms = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cBoxPrograms = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panelGas = new System.Windows.Forms.Panel();
            this.labGasVaporiser = new System.Windows.Forms.Label();
            this.labGasMFC3 = new System.Windows.Forms.Label();
            this.labGasMFC2 = new System.Windows.Forms.Label();
            this.labGasMFC1 = new System.Windows.Forms.Label();
            this.labGasSetpointPressure = new System.Windows.Forms.Label();
            this.labGasTimeTarget = new System.Windows.Forms.Label();
            this.labGasTime = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.panelPump = new System.Windows.Forms.Panel();
            this.labPumpTimeTarget = new System.Windows.Forms.Label();
            this.labPumpTime = new System.Windows.Forms.Label();
            this.labPumpSetpoint = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelPlasma = new System.Windows.Forms.Panel();
            this.labPlasmaSetpoint = new System.Windows.Forms.Label();
            this.labPlasmaTimeTarget = new System.Windows.Forms.Label();
            this.labPlasmaTime = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panelVent = new System.Windows.Forms.Panel();
            this.labVentTimeTarget = new System.Windows.Forms.Label();
            this.labVentTime = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panelPurge = new System.Windows.Forms.Panel();
            this.labPurgeTimeTarget = new System.Windows.Forms.Label();
            this.labPurgeTime = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labStatus = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.rBtnManual = new System.Windows.Forms.RadioButton();
            this.rBtnAutomatic = new System.Windows.Forms.RadioButton();
            this.rBtnHide = new System.Windows.Forms.RadioButton();
            this.panel8.SuspendLayout();
            this.panelGas.SuspendLayout();
            this.panelPump.SuspendLayout();
            this.panelPlasma.SuspendLayout();
            this.panelVent.SuspendLayout();
            this.panelPurge.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(538, 25);
            this.label4.TabIndex = 48;
            this.label4.Text = "OPERATING MODE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.Silver;
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label34.Location = new System.Drawing.Point(0, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(535, 25);
            this.label34.TabIndex = 55;
            this.label34.Text = "AUTOMATIC";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listViewSubprograms
            // 
            this.listViewSubprograms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewSubprograms.FullRowSelect = true;
            this.listViewSubprograms.GridLines = true;
            this.listViewSubprograms.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.listViewSubprograms.Location = new System.Drawing.Point(8, 66);
            this.listViewSubprograms.MultiSelect = false;
            this.listViewSubprograms.Name = "listViewSubprograms";
            this.listViewSubprograms.Size = new System.Drawing.Size(429, 171);
            this.listViewSubprograms.TabIndex = 54;
            this.listViewSubprograms.UseCompatibleStateImageBehavior = false;
            this.listViewSubprograms.View = System.Windows.Forms.View.Details;
            this.listViewSubprograms.SelectedIndexChanged += new System.EventHandler(this.listViewSubprograms_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sub program name";
            this.columnHeader1.Width = 251;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 156;
            // 
            // cBoxPrograms
            // 
            this.cBoxPrograms.FormattingEnabled = true;
            this.cBoxPrograms.Location = new System.Drawing.Point(124, 30);
            this.cBoxPrograms.Name = "cBoxPrograms";
            this.cBoxPrograms.Size = new System.Drawing.Size(183, 28);
            this.cBoxPrograms.TabIndex = 47;
            this.cBoxPrograms.SelectedIndexChanged += new System.EventHandler(this.cBoxPrograms_SelectedIndexChanged);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(443, 158);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(91, 76);
            this.btnStop.TabIndex = 53;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(443, 66);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 86);
            this.btnStart.TabIndex = 52;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panelGas);
            this.panel8.Controls.Add(this.panelPump);
            this.panel8.Controls.Add(this.panelPlasma);
            this.panel8.Controls.Add(this.panelVent);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.panelPurge);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.label35);
            this.panel8.Location = new System.Drawing.Point(3, 243);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(530, 290);
            this.panel8.TabIndex = 57;
            // 
            // panelGas
            // 
            this.panelGas.Controls.Add(this.labGasVaporiser);
            this.panelGas.Controls.Add(this.labGasMFC3);
            this.panelGas.Controls.Add(this.labGasMFC2);
            this.panelGas.Controls.Add(this.labGasMFC1);
            this.panelGas.Controls.Add(this.labGasSetpointPressure);
            this.panelGas.Controls.Add(this.labGasTimeTarget);
            this.panelGas.Controls.Add(this.labGasTime);
            this.panelGas.Controls.Add(this.label26);
            this.panelGas.Location = new System.Drawing.Point(3, 194);
            this.panelGas.Name = "panelGas";
            this.panelGas.Size = new System.Drawing.Size(524, 89);
            this.panelGas.TabIndex = 35;
            // 
            // labGasVaporiser
            // 
            this.labGasVaporiser.AutoSize = true;
            this.labGasVaporiser.Location = new System.Drawing.Point(28, 64);
            this.labGasVaporiser.Name = "labGasVaporiser";
            this.labGasVaporiser.Size = new System.Drawing.Size(337, 20);
            this.labGasVaporiser.TabIndex = 9;
            this.labGasVaporiser.Text = "Vaporaitor: Cycle - 1000 [ms] Open - 25 [%]";
            // 
            // labGasMFC3
            // 
            this.labGasMFC3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.labGasMFC3.AutoSize = true;
            this.labGasMFC3.Location = new System.Drawing.Point(371, 35);
            this.labGasMFC3.Name = "labGasMFC3";
            this.labGasMFC3.Size = new System.Drawing.Size(166, 20);
            this.labGasMFC3.TabIndex = 8;
            this.labGasMFC3.Text = "MFC 3 Share: 25 [%]";
            // 
            // labGasMFC2
            // 
            this.labGasMFC2.AutoSize = true;
            this.labGasMFC2.Cursor = System.Windows.Forms.Cursors.No;
            this.labGasMFC2.Location = new System.Drawing.Point(196, 35);
            this.labGasMFC2.Name = "labGasMFC2";
            this.labGasMFC2.Size = new System.Drawing.Size(166, 20);
            this.labGasMFC2.TabIndex = 7;
            this.labGasMFC2.Text = "MFC 2 Share: 25 [%]";
            // 
            // labGasMFC1
            // 
            this.labGasMFC1.AutoSize = true;
            this.labGasMFC1.Location = new System.Drawing.Point(28, 35);
            this.labGasMFC1.Name = "labGasMFC1";
            this.labGasMFC1.Size = new System.Drawing.Size(166, 20);
            this.labGasMFC1.TabIndex = 6;
            this.labGasMFC1.Text = "MFC 1 Share: 50 [%]";
            // 
            // labGasSetpointPressure
            // 
            this.labGasSetpointPressure.AutoSize = true;
            this.labGasSetpointPressure.Location = new System.Drawing.Point(349, 7);
            this.labGasSetpointPressure.Name = "labGasSetpointPressure";
            this.labGasSetpointPressure.Size = new System.Drawing.Size(167, 20);
            this.labGasSetpointPressure.TabIndex = 5;
            this.labGasSetpointPressure.Text = "Setpoint: 0.01 [mBar]";
            // 
            // labGasTimeTarget
            // 
            this.labGasTimeTarget.AutoSize = true;
            this.labGasTimeTarget.Location = new System.Drawing.Point(250, 7);
            this.labGasTimeTarget.Name = "labGasTimeTarget";
            this.labGasTimeTarget.Size = new System.Drawing.Size(73, 20);
            this.labGasTimeTarget.TabIndex = 3;
            this.labGasTimeTarget.Text = "00:30:00";
            // 
            // labGasTime
            // 
            this.labGasTime.AutoSize = true;
            this.labGasTime.Location = new System.Drawing.Point(150, 7);
            this.labGasTime.Name = "labGasTime";
            this.labGasTime.Size = new System.Drawing.Size(73, 20);
            this.labGasTime.TabIndex = 2;
            this.labGasTime.Text = "00:01:35";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label26.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label26.Location = new System.Drawing.Point(2, 7);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(119, 20);
            this.label26.TabIndex = 0;
            this.label26.Text = "Gas supplay:";
            // 
            // panelPump
            // 
            this.panelPump.Controls.Add(this.labPumpTimeTarget);
            this.panelPump.Controls.Add(this.labPumpTime);
            this.panelPump.Controls.Add(this.labPumpSetpoint);
            this.panelPump.Controls.Add(this.label6);
            this.panelPump.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panelPump.Location = new System.Drawing.Point(3, 49);
            this.panelPump.Name = "panelPump";
            this.panelPump.Size = new System.Drawing.Size(527, 35);
            this.panelPump.TabIndex = 29;
            // 
            // labPumpTimeTarget
            // 
            this.labPumpTimeTarget.AutoSize = true;
            this.labPumpTimeTarget.Location = new System.Drawing.Point(250, 9);
            this.labPumpTimeTarget.Name = "labPumpTimeTarget";
            this.labPumpTimeTarget.Size = new System.Drawing.Size(81, 20);
            this.labPumpTimeTarget.TabIndex = 3;
            this.labPumpTimeTarget.Text = "00:30:00";
            // 
            // labPumpTime
            // 
            this.labPumpTime.AutoSize = true;
            this.labPumpTime.Location = new System.Drawing.Point(150, 9);
            this.labPumpTime.Name = "labPumpTime";
            this.labPumpTime.Size = new System.Drawing.Size(81, 20);
            this.labPumpTime.TabIndex = 2;
            this.labPumpTime.Text = "00:01:35";
            // 
            // labPumpSetpoint
            // 
            this.labPumpSetpoint.AutoSize = true;
            this.labPumpSetpoint.Location = new System.Drawing.Point(350, 9);
            this.labPumpSetpoint.Name = "labPumpSetpoint";
            this.labPumpSetpoint.Size = new System.Drawing.Size(178, 20);
            this.labPumpSetpoint.TabIndex = 1;
            this.labPumpSetpoint.Text = "Setpoint: 0.5 [mBar]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(2, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pump down:";
            // 
            // panelPlasma
            // 
            this.panelPlasma.Controls.Add(this.labPlasmaSetpoint);
            this.panelPlasma.Controls.Add(this.labPlasmaTimeTarget);
            this.panelPlasma.Controls.Add(this.labPlasmaTime);
            this.panelPlasma.Controls.Add(this.label21);
            this.panelPlasma.Location = new System.Drawing.Point(3, 157);
            this.panelPlasma.Name = "panelPlasma";
            this.panelPlasma.Size = new System.Drawing.Size(527, 35);
            this.panelPlasma.TabIndex = 34;
            // 
            // labPlasmaSetpoint
            // 
            this.labPlasmaSetpoint.AutoSize = true;
            this.labPlasmaSetpoint.Location = new System.Drawing.Point(349, 9);
            this.labPlasmaSetpoint.Name = "labPlasmaSetpoint";
            this.labPlasmaSetpoint.Size = new System.Drawing.Size(128, 20);
            this.labPlasmaSetpoint.TabIndex = 4;
            this.labPlasmaSetpoint.Text = "Setpoint: 3.5 [A]";
            // 
            // labPlasmaTimeTarget
            // 
            this.labPlasmaTimeTarget.AutoSize = true;
            this.labPlasmaTimeTarget.Location = new System.Drawing.Point(250, 9);
            this.labPlasmaTimeTarget.Name = "labPlasmaTimeTarget";
            this.labPlasmaTimeTarget.Size = new System.Drawing.Size(73, 20);
            this.labPlasmaTimeTarget.TabIndex = 3;
            this.labPlasmaTimeTarget.Text = "00:30:00";
            // 
            // labPlasmaTime
            // 
            this.labPlasmaTime.AutoSize = true;
            this.labPlasmaTime.Location = new System.Drawing.Point(150, 9);
            this.labPlasmaTime.Name = "labPlasmaTime";
            this.labPlasmaTime.Size = new System.Drawing.Size(73, 20);
            this.labPlasmaTime.TabIndex = 2;
            this.labPlasmaTime.Text = "00:01:35";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label21.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label21.Location = new System.Drawing.Point(2, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(140, 20);
            this.label21.TabIndex = 0;
            this.label21.Text = "Plasma proces:";
            // 
            // panelVent
            // 
            this.panelVent.Controls.Add(this.labVentTimeTarget);
            this.panelVent.Controls.Add(this.labVentTime);
            this.panelVent.Controls.Add(this.label16);
            this.panelVent.Location = new System.Drawing.Point(3, 85);
            this.panelVent.Name = "panelVent";
            this.panelVent.Size = new System.Drawing.Size(527, 35);
            this.panelVent.TabIndex = 30;
            // 
            // labVentTimeTarget
            // 
            this.labVentTimeTarget.AutoSize = true;
            this.labVentTimeTarget.Location = new System.Drawing.Point(250, 9);
            this.labVentTimeTarget.Name = "labVentTimeTarget";
            this.labVentTimeTarget.Size = new System.Drawing.Size(73, 20);
            this.labVentTimeTarget.TabIndex = 3;
            this.labVentTimeTarget.Text = "00:30:00";
            // 
            // labVentTime
            // 
            this.labVentTime.AutoSize = true;
            this.labVentTime.Location = new System.Drawing.Point(150, 9);
            this.labVentTime.Name = "labVentTime";
            this.labVentTime.Size = new System.Drawing.Size(73, 20);
            this.labVentTime.TabIndex = 2;
            this.labVentTime.Text = "00:01:35";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(2, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "Vent:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(379, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 20);
            this.label12.TabIndex = 33;
            this.label12.Text = "Parameters";
            // 
            // panelPurge
            // 
            this.panelPurge.Controls.Add(this.labPurgeTimeTarget);
            this.panelPurge.Controls.Add(this.labPurgeTime);
            this.panelPurge.Controls.Add(this.label18);
            this.panelPurge.Location = new System.Drawing.Point(3, 121);
            this.panelPurge.Name = "panelPurge";
            this.panelPurge.Size = new System.Drawing.Size(527, 35);
            this.panelPurge.TabIndex = 31;
            // 
            // labPurgeTimeTarget
            // 
            this.labPurgeTimeTarget.AutoSize = true;
            this.labPurgeTimeTarget.Location = new System.Drawing.Point(250, 9);
            this.labPurgeTimeTarget.Name = "labPurgeTimeTarget";
            this.labPurgeTimeTarget.Size = new System.Drawing.Size(73, 20);
            this.labPurgeTimeTarget.TabIndex = 3;
            this.labPurgeTimeTarget.Text = "00:30:00";
            // 
            // labPurgeTime
            // 
            this.labPurgeTime.AutoSize = true;
            this.labPurgeTime.Location = new System.Drawing.Point(150, 9);
            this.labPurgeTime.Name = "labPurgeTime";
            this.labPurgeTime.Size = new System.Drawing.Size(73, 20);
            this.labPurgeTime.TabIndex = 2;
            this.labPurgeTime.Text = "00:01:35";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label18.Location = new System.Drawing.Point(3, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 20);
            this.label18.TabIndex = 0;
            this.label18.Text = "Purge:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(158, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 31;
            this.label9.Text = "Stage";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(253, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 20);
            this.label10.TabIndex = 32;
            this.label10.Text = "Target";
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Silver;
            this.label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label35.Location = new System.Drawing.Point(-3, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(535, 25);
            this.label35.TabIndex = 56;
            this.label35.Text = "PROCESS STAGE";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(5, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 39;
            this.label5.Text = "Program name:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.labStatus);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.label34);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.listViewSubprograms);
            this.panel6.Controls.Add(this.btnStart);
            this.panel6.Controls.Add(this.btnStop);
            this.panel6.Controls.Add(this.cBoxPrograms);
            this.panel6.Location = new System.Drawing.Point(0, 55);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(536, 532);
            this.panel6.TabIndex = 58;
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labStatus.Location = new System.Drawing.Point(310, 33);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(152, 20);
            this.labStatus.TabIndex = 58;
            this.labStatus.Text = "Program Status: ";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // rBtnManual
            // 
            this.rBtnManual.AutoSize = true;
            this.rBtnManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rBtnManual.Location = new System.Drawing.Point(300, 29);
            this.rBtnManual.Name = "rBtnManual";
            this.rBtnManual.Size = new System.Drawing.Size(106, 24);
            this.rBtnManual.TabIndex = 59;
            this.rBtnManual.TabStop = true;
            this.rBtnManual.Text = "MANUAL";
            this.rBtnManual.UseVisualStyleBackColor = true;
            this.rBtnManual.Click += new System.EventHandler(this.rBtnMode_Click);
            // 
            // rBtnAutomatic
            // 
            this.rBtnAutomatic.AutoSize = true;
            this.rBtnAutomatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rBtnAutomatic.Location = new System.Drawing.Point(49, 28);
            this.rBtnAutomatic.Name = "rBtnAutomatic";
            this.rBtnAutomatic.Size = new System.Drawing.Size(136, 24);
            this.rBtnAutomatic.TabIndex = 60;
            this.rBtnAutomatic.TabStop = true;
            this.rBtnAutomatic.Text = "AUTOMATIC";
            this.rBtnAutomatic.UseVisualStyleBackColor = true;
            this.rBtnAutomatic.Click += new System.EventHandler(this.rBtnMode_Click);
            // 
            // rBtnHide
            // 
            this.rBtnHide.AutoSize = true;
            this.rBtnHide.Location = new System.Drawing.Point(443, 28);
            this.rBtnHide.Name = "rBtnHide";
            this.rBtnHide.Size = new System.Drawing.Size(61, 24);
            this.rBtnHide.TabIndex = 61;
            this.rBtnHide.TabStop = true;
            this.rBtnHide.Text = "hide";
            this.rBtnHide.UseVisualStyleBackColor = true;
            this.rBtnHide.Visible = false;
            // 
            // ProgramPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.rBtnHide);
            this.Controls.Add(this.rBtnAutomatic);
            this.Controls.Add(this.rBtnManual);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "ProgramPanel";
            this.Size = new System.Drawing.Size(535, 582);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panelGas.ResumeLayout(false);
            this.panelGas.PerformLayout();
            this.panelPump.ResumeLayout(false);
            this.panelPump.PerformLayout();
            this.panelPlasma.ResumeLayout(false);
            this.panelPlasma.PerformLayout();
            this.panelVent.ResumeLayout(false);
            this.panelVent.PerformLayout();
            this.panelPurge.ResumeLayout(false);
            this.panelPurge.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ListView listViewSubprograms;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox cBoxPrograms;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panelGas;
        private System.Windows.Forms.Label labGasVaporiser;
        private System.Windows.Forms.Label labGasMFC3;
        private System.Windows.Forms.Label labGasMFC2;
        private System.Windows.Forms.Label labGasMFC1;
        private System.Windows.Forms.Label labGasSetpointPressure;
        private System.Windows.Forms.Label labGasTimeTarget;
        private System.Windows.Forms.Label labGasTime;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panelPump;
        private System.Windows.Forms.Label labPumpTimeTarget;
        private System.Windows.Forms.Label labPumpTime;
        private System.Windows.Forms.Label labPumpSetpoint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelPlasma;
        private System.Windows.Forms.Label labPlasmaSetpoint;
        private System.Windows.Forms.Label labPlasmaTimeTarget;
        private System.Windows.Forms.Label labPlasmaTime;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panelVent;
        private System.Windows.Forms.Label labVentTimeTarget;
        private System.Windows.Forms.Label labVentTime;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panelPurge;
        private System.Windows.Forms.Label labPurgeTimeTarget;
        private System.Windows.Forms.Label labPurgeTime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.RadioButton rBtnManual;
        private System.Windows.Forms.RadioButton rBtnAutomatic;
        private System.Windows.Forms.RadioButton rBtnHide;
    }
}
