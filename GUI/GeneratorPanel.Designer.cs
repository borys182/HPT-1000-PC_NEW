namespace HPT1000.GUI
{
    partial class GeneratorPanel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBntNone = new System.Windows.Forms.RadioButton();
            this.dEditSetpoint = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditActualVoltage = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditActualCurent = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditActualPower = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxOperate = new System.Windows.Forms.CheckBox();
            this.scrollSetpoint = new System.Windows.Forms.HScrollBar();
            this.labUnitActualSP = new System.Windows.Forms.Label();
            this.labUnitSP = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.rBtnModeCurent = new System.Windows.Forms.RadioButton();
            this.rBtnModeVoltage = new System.Windows.Forms.RadioButton();
            this.rBtnModePower = new System.Windows.Forms.RadioButton();
            this.label38 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBntNone);
            this.groupBox1.Controls.Add(this.dEditSetpoint);
            this.groupBox1.Controls.Add(this.dEditActualVoltage);
            this.groupBox1.Controls.Add(this.dEditActualCurent);
            this.groupBox1.Controls.Add(this.dEditActualPower);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cBoxOperate);
            this.groupBox1.Controls.Add(this.scrollSetpoint);
            this.groupBox1.Controls.Add(this.labUnitActualSP);
            this.groupBox1.Controls.Add(this.labUnitSP);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.rBtnModeCurent);
            this.groupBox1.Controls.Add(this.rBtnModeVoltage);
            this.groupBox1.Controls.Add(this.rBtnModePower);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(3, -5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 277);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            // 
            // rBntNone
            // 
            this.rBntNone.AutoSize = true;
            this.rBntNone.Location = new System.Drawing.Point(82, 78);
            this.rBntNone.Name = "rBntNone";
            this.rBntNone.Size = new System.Drawing.Size(69, 24);
            this.rBntNone.TabIndex = 77;
            this.rBntNone.TabStop = true;
            this.rBntNone.Text = "None";
            this.rBntNone.UseVisualStyleBackColor = true;
            this.rBntNone.Visible = false;
            // 
            // dEditSetpoint
            // 
            this.dEditSetpoint.Location = new System.Drawing.Point(128, 107);
            this.dEditSetpoint.Margin = new System.Windows.Forms.Padding(5);
            this.dEditSetpoint.Mask = "0.000";
            this.dEditSetpoint.MaximumValue = 0D;
            this.dEditSetpoint.MinimumValue = 0D;
            this.dEditSetpoint.Name = "dEditSetpoint";
            this.dEditSetpoint.ReadOnly = false;
            this.dEditSetpoint.Size = new System.Drawing.Size(87, 26);
            this.dEditSetpoint.TabIndex = 76;
            this.dEditSetpoint.Value = 0D;
            this.dEditSetpoint.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditSetpoint_EnterOn);
            // 
            // dEditActualVoltage
            // 
            this.dEditActualVoltage.Enabled = false;
            this.dEditActualVoltage.Location = new System.Drawing.Point(128, 177);
            this.dEditActualVoltage.Margin = new System.Windows.Forms.Padding(5);
            this.dEditActualVoltage.Mask = "0.000";
            this.dEditActualVoltage.MaximumValue = 10000D;
            this.dEditActualVoltage.MinimumValue = 0D;
            this.dEditActualVoltage.Name = "dEditActualVoltage";
            this.dEditActualVoltage.ReadOnly = false;
            this.dEditActualVoltage.Size = new System.Drawing.Size(85, 26);
            this.dEditActualVoltage.TabIndex = 75;
            this.dEditActualVoltage.Value = 0D;
            // 
            // dEditActualCurent
            // 
            this.dEditActualCurent.Enabled = false;
            this.dEditActualCurent.Location = new System.Drawing.Point(128, 210);
            this.dEditActualCurent.Margin = new System.Windows.Forms.Padding(5);
            this.dEditActualCurent.Mask = "0.000";
            this.dEditActualCurent.MaximumValue = 10000D;
            this.dEditActualCurent.MinimumValue = 0D;
            this.dEditActualCurent.Name = "dEditActualCurent";
            this.dEditActualCurent.ReadOnly = false;
            this.dEditActualCurent.Size = new System.Drawing.Size(85, 26);
            this.dEditActualCurent.TabIndex = 74;
            this.dEditActualCurent.Value = 0D;
            // 
            // dEditActualPower
            // 
            this.dEditActualPower.Enabled = false;
            this.dEditActualPower.Location = new System.Drawing.Point(128, 145);
            this.dEditActualPower.Margin = new System.Windows.Forms.Padding(4);
            this.dEditActualPower.Mask = "0.000";
            this.dEditActualPower.MaximumValue = 10000D;
            this.dEditActualPower.MinimumValue = 0D;
            this.dEditActualPower.Name = "dEditActualPower";
            this.dEditActualPower.ReadOnly = false;
            this.dEditActualPower.Size = new System.Drawing.Size(86, 27);
            this.dEditActualPower.TabIndex = 73;
            this.dEditActualPower.Value = 0D;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(224, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 72;
            this.label3.Text = "[A]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(11, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 70;
            this.label4.Text = "Actual curent:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(224, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 69;
            this.label1.Text = "[V]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(9, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 67;
            this.label2.Text = "Actual voltage:";
            // 
            // cBoxOperate
            // 
            this.cBoxOperate.Appearance = System.Windows.Forms.Appearance.Button;
            this.cBoxOperate.BackColor = System.Drawing.Color.Silver;
            this.cBoxOperate.Location = new System.Drawing.Point(13, 241);
            this.cBoxOperate.Name = "cBoxOperate";
            this.cBoxOperate.Size = new System.Drawing.Size(239, 31);
            this.cBoxOperate.TabIndex = 65;
            this.cBoxOperate.Text = "Enable";
            this.cBoxOperate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cBoxOperate.UseVisualStyleBackColor = false;
            this.cBoxOperate.Click += new System.EventHandler(this.cBoxOperate_Click);
            // 
            // scrollSetpoint
            // 
            this.scrollSetpoint.Location = new System.Drawing.Point(13, 78);
            this.scrollSetpoint.Name = "scrollSetpoint";
            this.scrollSetpoint.Size = new System.Drawing.Size(240, 21);
            this.scrollSetpoint.TabIndex = 64;
            this.scrollSetpoint.ValueChanged += new System.EventHandler(this.scrollSetpoint_ValueChanged);
            // 
            // labUnitActualSP
            // 
            this.labUnitActualSP.AutoSize = true;
            this.labUnitActualSP.ForeColor = System.Drawing.Color.Green;
            this.labUnitActualSP.Location = new System.Drawing.Point(224, 148);
            this.labUnitActualSP.Name = "labUnitActualSP";
            this.labUnitActualSP.Size = new System.Drawing.Size(35, 20);
            this.labUnitActualSP.TabIndex = 63;
            this.labUnitActualSP.Text = "[W]";
            // 
            // labUnitSP
            // 
            this.labUnitSP.AutoSize = true;
            this.labUnitSP.ForeColor = System.Drawing.Color.Green;
            this.labUnitSP.Location = new System.Drawing.Point(224, 112);
            this.labUnitSP.Name = "labUnitSP";
            this.labUnitSP.Size = new System.Drawing.Size(35, 20);
            this.labUnitSP.TabIndex = 62;
            this.labUnitSP.Text = "[W]";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label40.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label40.Location = new System.Drawing.Point(9, 148);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(111, 20);
            this.label40.TabIndex = 59;
            this.label40.Text = "Actual power:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label39.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label39.Location = new System.Drawing.Point(9, 112);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(75, 20);
            this.label39.TabIndex = 58;
            this.label39.Text = "Setpoint:";
            // 
            // rBtnModeCurent
            // 
            this.rBtnModeCurent.AutoSize = true;
            this.rBtnModeCurent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rBtnModeCurent.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.rBtnModeCurent.Location = new System.Drawing.Point(170, 53);
            this.rBtnModeCurent.Name = "rBtnModeCurent";
            this.rBtnModeCurent.Size = new System.Drawing.Size(80, 24);
            this.rBtnModeCurent.TabIndex = 57;
            this.rBtnModeCurent.TabStop = true;
            this.rBtnModeCurent.Text = "Curent";
            this.rBtnModeCurent.UseVisualStyleBackColor = true;
            this.rBtnModeCurent.Click += new System.EventHandler(this.radioButtonMode_Click);
            // 
            // rBtnModeVoltage
            // 
            this.rBtnModeVoltage.AutoSize = true;
            this.rBtnModeVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rBtnModeVoltage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.rBtnModeVoltage.Location = new System.Drawing.Point(82, 52);
            this.rBtnModeVoltage.Name = "rBtnModeVoltage";
            this.rBtnModeVoltage.Size = new System.Drawing.Size(86, 24);
            this.rBtnModeVoltage.TabIndex = 56;
            this.rBtnModeVoltage.TabStop = true;
            this.rBtnModeVoltage.Text = "Voltage";
            this.rBtnModeVoltage.UseVisualStyleBackColor = true;
            this.rBtnModeVoltage.Click += new System.EventHandler(this.radioButtonMode_Click);
            // 
            // rBtnModePower
            // 
            this.rBtnModePower.AutoSize = true;
            this.rBtnModePower.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rBtnModePower.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.rBtnModePower.Location = new System.Drawing.Point(4, 52);
            this.rBtnModePower.Name = "rBtnModePower";
            this.rBtnModePower.Size = new System.Drawing.Size(77, 24);
            this.rBtnModePower.TabIndex = 54;
            this.rBtnModePower.TabStop = true;
            this.rBtnModePower.Text = "Power";
            this.rBtnModePower.UseVisualStyleBackColor = true;
            this.rBtnModePower.Click += new System.EventHandler(this.radioButtonMode_Click);
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.Silver;
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label38.Dock = System.Windows.Forms.DockStyle.Top;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label38.Location = new System.Drawing.Point(3, 23);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(273, 25);
            this.label38.TabIndex = 53;
            this.label38.Text = "GENERATOR";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GeneratorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "GeneratorPanel";
            this.Size = new System.Drawing.Size(263, 275);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.RadioButton rBtnModeCurent;
        private System.Windows.Forms.RadioButton rBtnModeVoltage;
        private System.Windows.Forms.RadioButton rBtnModePower;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label labUnitActualSP;
        private System.Windows.Forms.Label labUnitSP;
        private System.Windows.Forms.HScrollBar scrollSetpoint;
        private System.Windows.Forms.CheckBox cBoxOperate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Cotrols.DoubleEdit dEditSetpoint;
        private Cotrols.DoubleEdit dEditActualVoltage;
        private Cotrols.DoubleEdit dEditActualCurent;
        private Cotrols.DoubleEdit dEditActualPower;
        private System.Windows.Forms.RadioButton rBntNone;
    }
}
