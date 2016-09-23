namespace HPT1000.GUI
{
    partial class MFCPanel
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
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scrollFlow = new System.Windows.Forms.HScrollBar();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.labNameMFC = new System.Windows.Forms.Label();
            this.dEditFlow_sccm = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditActualFlow_percent = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditFlow_percent = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditActualFlow_sccm = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(323, 85);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(47, 28);
            this.comboBox2.TabIndex = 68;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dEditActualFlow_sccm);
            this.groupBox1.Controls.Add(this.dEditFlow_percent);
            this.groupBox1.Controls.Add(this.dEditActualFlow_percent);
            this.groupBox1.Controls.Add(this.dEditFlow_sccm);
            this.groupBox1.Controls.Add(this.scrollFlow);
            this.groupBox1.Controls.Add(this.label53);
            this.groupBox1.Controls.Add(this.label52);
            this.groupBox1.Controls.Add(this.label51);
            this.groupBox1.Controls.Add(this.label50);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.label48);
            this.groupBox1.Controls.Add(this.labNameMFC);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Location = new System.Drawing.Point(1, -15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 153);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            // 
            // scrollFlow
            // 
            this.scrollFlow.Location = new System.Drawing.Point(13, 55);
            this.scrollFlow.Name = "scrollFlow";
            this.scrollFlow.Size = new System.Drawing.Size(357, 21);
            this.scrollFlow.TabIndex = 81;
            this.scrollFlow.ValueChanged += new System.EventHandler(this.scrollFlow_ValueChanged);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.ForeColor = System.Drawing.Color.Green;
            this.label53.Location = new System.Drawing.Point(283, 123);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(34, 20);
            this.label53.TabIndex = 80;
            this.label53.Text = "[%]";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.ForeColor = System.Drawing.Color.Green;
            this.label52.Location = new System.Drawing.Point(283, 87);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(34, 20);
            this.label52.TabIndex = 78;
            this.label52.Text = "[%]";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.ForeColor = System.Drawing.Color.Green;
            this.label51.Location = new System.Drawing.Point(147, 121);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(60, 20);
            this.label51.TabIndex = 76;
            this.label51.Text = "[sccm]";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.ForeColor = System.Drawing.Color.Green;
            this.label50.Location = new System.Drawing.Point(147, 85);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(60, 20);
            this.label50.TabIndex = 75;
            this.label50.Text = "[sccm]";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label47.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label47.Location = new System.Drawing.Point(9, 123);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(61, 20);
            this.label47.TabIndex = 72;
            this.label47.Text = "Actual:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label48.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label48.Location = new System.Drawing.Point(11, 87);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(39, 20);
            this.label48.TabIndex = 71;
            this.label48.Text = "Set:";
            // 
            // labNameMFC
            // 
            this.labNameMFC.BackColor = System.Drawing.Color.Silver;
            this.labNameMFC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labNameMFC.Dock = System.Windows.Forms.DockStyle.Top;
            this.labNameMFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labNameMFC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labNameMFC.Location = new System.Drawing.Point(3, 23);
            this.labNameMFC.Name = "labNameMFC";
            this.labNameMFC.Size = new System.Drawing.Size(369, 25);
            this.labNameMFC.TabIndex = 69;
            this.labNameMFC.Text = "MFC 1";
            this.labNameMFC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dEditFlow_sccm
            // 
            this.dEditFlow_sccm.Location = new System.Drawing.Point(68, 83);
            this.dEditFlow_sccm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dEditFlow_sccm.Mask = "0";
            this.dEditFlow_sccm.MaximumValue = 1000000D;
            this.dEditFlow_sccm.MinimumValue = 0D;
            this.dEditFlow_sccm.Name = "dEditFlow_sccm";
            this.dEditFlow_sccm.ReadOnly = false;
            this.dEditFlow_sccm.Size = new System.Drawing.Size(78, 26);
            this.dEditFlow_sccm.TabIndex = 82;
            this.dEditFlow_sccm.Value = 0D;
            this.dEditFlow_sccm.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditFlow_sccm_EnterOn);
            // 
            // dEditActualFlow_percent
            // 
            this.dEditActualFlow_percent.Location = new System.Drawing.Point(204, 118);
            this.dEditActualFlow_percent.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dEditActualFlow_percent.Mask = "0.00";
            this.dEditActualFlow_percent.MaximumValue = 1000D;
            this.dEditActualFlow_percent.MinimumValue = 0D;
            this.dEditActualFlow_percent.Name = "dEditActualFlow_percent";
            this.dEditActualFlow_percent.ReadOnly = true;
            this.dEditActualFlow_percent.Size = new System.Drawing.Size(77, 26);
            this.dEditActualFlow_percent.TabIndex = 83;
            this.dEditActualFlow_percent.Value = 0D;
            // 
            // dEditFlow_percent
            // 
            this.dEditFlow_percent.Location = new System.Drawing.Point(204, 84);
            this.dEditFlow_percent.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dEditFlow_percent.Mask = "0.00";
            this.dEditFlow_percent.MaximumValue = 100D;
            this.dEditFlow_percent.MinimumValue = 0D;
            this.dEditFlow_percent.Name = "dEditFlow_percent";
            this.dEditFlow_percent.ReadOnly = false;
            this.dEditFlow_percent.Size = new System.Drawing.Size(78, 26);
            this.dEditFlow_percent.TabIndex = 84;
            this.dEditFlow_percent.Value = 0D;
            this.dEditFlow_percent.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditFlow_percent_EnterOn);
            // 
            // dEditActualFlow_sccm
            // 
            this.dEditActualFlow_sccm.Location = new System.Drawing.Point(68, 118);
            this.dEditActualFlow_sccm.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dEditActualFlow_sccm.Mask = "0";
            this.dEditActualFlow_sccm.MaximumValue = 100000000D;
            this.dEditActualFlow_sccm.MinimumValue = 0D;
            this.dEditActualFlow_sccm.Name = "dEditActualFlow_sccm";
            this.dEditActualFlow_sccm.ReadOnly = true;
            this.dEditActualFlow_sccm.Size = new System.Drawing.Size(76, 26);
            this.dEditActualFlow_sccm.TabIndex = 85;
            this.dEditActualFlow_sccm.Value = 0D;
            // 
            // MFCPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "MFCPanel";
            this.Size = new System.Drawing.Size(378, 140);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label labNameMFC;
        private System.Windows.Forms.HScrollBar scrollFlow;
        private Cotrols.DoubleEdit dEditActualFlow_sccm;
        private Cotrols.DoubleEdit dEditFlow_percent;
        private Cotrols.DoubleEdit dEditActualFlow_percent;
        private Cotrols.DoubleEdit dEditFlow_sccm;
    }
}
