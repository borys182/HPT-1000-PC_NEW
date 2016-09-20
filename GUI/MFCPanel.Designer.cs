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
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.label53 = new System.Windows.Forms.Label();
            this.tBoxActualFlow_percent = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.tBoxFlow_percent = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.tBoxActualFlow_sccm = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.tBoxFlow_sccm = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.hScrollBar1);
            this.groupBox1.Controls.Add(this.label53);
            this.groupBox1.Controls.Add(this.tBoxActualFlow_percent);
            this.groupBox1.Controls.Add(this.label52);
            this.groupBox1.Controls.Add(this.tBoxFlow_percent);
            this.groupBox1.Controls.Add(this.label51);
            this.groupBox1.Controls.Add(this.label50);
            this.groupBox1.Controls.Add(this.tBoxActualFlow_sccm);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.label48);
            this.groupBox1.Controls.Add(this.tBoxFlow_sccm);
            this.groupBox1.Controls.Add(this.label49);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Location = new System.Drawing.Point(1, -15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 145);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(13, 53);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(354, 21);
            this.hScrollBar1.TabIndex = 81;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.ForeColor = System.Drawing.Color.Green;
            this.label53.Location = new System.Drawing.Point(283, 118);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(34, 20);
            this.label53.TabIndex = 80;
            this.label53.Text = "[%]";
            // 
            // tBoxActualFlow_percent
            // 
            this.tBoxActualFlow_percent.Location = new System.Drawing.Point(224, 113);
            this.tBoxActualFlow_percent.Name = "tBoxActualFlow_percent";
            this.tBoxActualFlow_percent.Size = new System.Drawing.Size(44, 27);
            this.tBoxActualFlow_percent.TabIndex = 79;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.ForeColor = System.Drawing.Color.Green;
            this.label52.Location = new System.Drawing.Point(283, 85);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(34, 20);
            this.label52.TabIndex = 78;
            this.label52.Text = "[%]";
            // 
            // tBoxFlow_percent
            // 
            this.tBoxFlow_percent.Location = new System.Drawing.Point(224, 80);
            this.tBoxFlow_percent.Name = "tBoxFlow_percent";
            this.tBoxFlow_percent.Size = new System.Drawing.Size(44, 27);
            this.tBoxFlow_percent.TabIndex = 77;
            this.tBoxFlow_percent.Text = "100";
            this.tBoxFlow_percent.Validated += new System.EventHandler(this.tBoxFlow_percent_Validated);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.ForeColor = System.Drawing.Color.Green;
            this.label51.Location = new System.Drawing.Point(154, 116);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(60, 20);
            this.label51.TabIndex = 76;
            this.label51.Text = "[sccm]";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.ForeColor = System.Drawing.Color.Green;
            this.label50.Location = new System.Drawing.Point(154, 83);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(60, 20);
            this.label50.TabIndex = 75;
            this.label50.Text = "[sccm]";
            // 
            // tBoxActualFlow_sccm
            // 
            this.tBoxActualFlow_sccm.Location = new System.Drawing.Point(73, 113);
            this.tBoxActualFlow_sccm.Name = "tBoxActualFlow_sccm";
            this.tBoxActualFlow_sccm.ReadOnly = true;
            this.tBoxActualFlow_sccm.Size = new System.Drawing.Size(52, 27);
            this.tBoxActualFlow_sccm.TabIndex = 73;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label47.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label47.Location = new System.Drawing.Point(9, 118);
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
            this.label48.Location = new System.Drawing.Point(11, 85);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(39, 20);
            this.label48.TabIndex = 71;
            this.label48.Text = "Set:";
            // 
            // tBoxFlow_sccm
            // 
            this.tBoxFlow_sccm.Location = new System.Drawing.Point(74, 80);
            this.tBoxFlow_sccm.Name = "tBoxFlow_sccm";
            this.tBoxFlow_sccm.Size = new System.Drawing.Size(52, 27);
            this.tBoxFlow_sccm.TabIndex = 70;
            this.tBoxFlow_sccm.Text = "1000";
            this.tBoxFlow_sccm.Validated += new System.EventHandler(this.tBoxFlow_sccm_Validated);
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.Silver;
            this.label49.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label49.Dock = System.Windows.Forms.DockStyle.Top;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label49.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label49.Location = new System.Drawing.Point(3, 23);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(369, 25);
            this.label49.TabIndex = 69;
            this.label49.Text = "MFC 1";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MFCPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "MFCPanel";
            this.Size = new System.Drawing.Size(378, 131);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox tBoxActualFlow_percent;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox tBoxFlow_percent;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox tBoxActualFlow_sccm;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox tBoxFlow_sccm;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}
