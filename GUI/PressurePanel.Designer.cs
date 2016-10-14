namespace HPT1000.GUI
{
    partial class PressurePanel
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
            this.dEditSetpoint = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditActulaPressure = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.cBoxGases = new System.Windows.Forms.CheckBox();
            this.scrollPressure = new System.Windows.Forms.HScrollBar();
            this.cBoxVaporizer = new System.Windows.Forms.CheckBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dEditSetpoint);
            this.groupBox1.Controls.Add(this.dEditActulaPressure);
            this.groupBox1.Controls.Add(this.cBoxGases);
            this.groupBox1.Controls.Add(this.scrollPressure);
            this.groupBox1.Controls.Add(this.cBoxVaporizer);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.label45);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Location = new System.Drawing.Point(1, -8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 195);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // dEditSetpoint
            // 
            this.dEditSetpoint.Location = new System.Drawing.Point(138, 128);
            this.dEditSetpoint.Margin = new System.Windows.Forms.Padding(5);
            this.dEditSetpoint.Mask = "0,000";
            this.dEditSetpoint.MaximumValue = 1000D;
            this.dEditSetpoint.MinimumValue = 0D;
            this.dEditSetpoint.Name = "dEditSetpoint";
            this.dEditSetpoint.ReadOnly = false;
            this.dEditSetpoint.Size = new System.Drawing.Size(89, 26);
            this.dEditSetpoint.TabIndex = 77;
            this.dEditSetpoint.Value = 0D;
            this.dEditSetpoint.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditSetpoint_EnterOn);
            // 
            // dEditActulaPressure
            // 
            this.dEditActulaPressure.Enabled = false;
            this.dEditActulaPressure.Location = new System.Drawing.Point(138, 160);
            this.dEditActulaPressure.Margin = new System.Windows.Forms.Padding(4);
            this.dEditActulaPressure.Mask = "0,000";
            this.dEditActulaPressure.MaximumValue = 1000D;
            this.dEditActulaPressure.MinimumValue = 0D;
            this.dEditActulaPressure.Name = "dEditActulaPressure";
            this.dEditActulaPressure.ReadOnly = false;
            this.dEditActulaPressure.Size = new System.Drawing.Size(88, 26);
            this.dEditActulaPressure.TabIndex = 76;
            this.dEditActulaPressure.Value = 0D;
            // 
            // cBoxGases
            // 
            this.cBoxGases.AutoSize = true;
            this.cBoxGases.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cBoxGases.Location = new System.Drawing.Point(33, 73);
            this.cBoxGases.Name = "cBoxGases";
            this.cBoxGases.Size = new System.Drawing.Size(80, 24);
            this.cBoxGases.TabIndex = 75;
            this.cBoxGases.Text = "Gases";
            this.cBoxGases.UseVisualStyleBackColor = true;
            this.cBoxGases.Click += new System.EventHandler(this.cBoxGases_Click);
            // 
            // scrollPressure
            // 
            this.scrollPressure.Location = new System.Drawing.Point(19, 100);
            this.scrollPressure.Name = "scrollPressure";
            this.scrollPressure.Size = new System.Drawing.Size(279, 21);
            this.scrollPressure.TabIndex = 74;
            this.scrollPressure.ValueChanged += new System.EventHandler(this.scrollPressure_ValueChanged);
            // 
            // cBoxVaporizer
            // 
            this.cBoxVaporizer.AutoSize = true;
            this.cBoxVaporizer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cBoxVaporizer.Location = new System.Drawing.Point(160, 73);
            this.cBoxVaporizer.Name = "cBoxVaporizer";
            this.cBoxVaporizer.Size = new System.Drawing.Size(103, 24);
            this.cBoxVaporizer.TabIndex = 73;
            this.cBoxVaporizer.Text = "Vaporizer";
            this.cBoxVaporizer.UseVisualStyleBackColor = true;
            this.cBoxVaporizer.Click += new System.EventHandler(this.cBoxGases_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.ForeColor = System.Drawing.Color.Green;
            this.label46.Location = new System.Drawing.Point(246, 166);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(60, 20);
            this.label46.TabIndex = 70;
            this.label46.Text = "[mBar]";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.ForeColor = System.Drawing.Color.Green;
            this.label45.Location = new System.Drawing.Point(246, 133);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(60, 20);
            this.label45.TabIndex = 69;
            this.label45.Text = "[mBar]";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label44.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label44.Location = new System.Drawing.Point(15, 166);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(105, 20);
            this.label44.TabIndex = 66;
            this.label44.Text = "Actual value:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label43.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label43.Location = new System.Drawing.Point(15, 133);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(75, 20);
            this.label43.TabIndex = 65;
            this.label43.Text = "Setpoint:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label42.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label42.Location = new System.Drawing.Point(14, 49);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(165, 20);
            this.label42.TabIndex = 64;
            this.label42.Text = "Control pressure via:";
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.Silver;
            this.label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label41.Dock = System.Windows.Forms.DockStyle.Top;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label41.Location = new System.Drawing.Point(3, 23);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(315, 25);
            this.label41.TabIndex = 63;
            this.label41.Text = "PRESSURE";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PressurePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "PressurePanel";
            this.Size = new System.Drawing.Size(325, 190);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.HScrollBar scrollPressure;
        private System.Windows.Forms.CheckBox cBoxGases;
        private System.Windows.Forms.CheckBox cBoxVaporizer;
        private Cotrols.DoubleEdit dEditActulaPressure;
        private Cotrols.DoubleEdit dEditSetpoint;
    }
}
