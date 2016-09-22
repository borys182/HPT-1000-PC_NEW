namespace HPT1000.GUI
{
    partial class VaporiserPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.labUnit = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.dEditOnTime = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditCycleTImne = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dEditOnTime);
            this.groupBox1.Controls.Add(this.dEditCycleTImne);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labUnit);
            this.groupBox1.Controls.Add(this.label71);
            this.groupBox1.Controls.Add(this.label72);
            this.groupBox1.Controls.Add(this.label74);
            this.groupBox1.Location = new System.Drawing.Point(3, -13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 142);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(8, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 70;
            this.label1.Text = "Cycle time:";
            // 
            // labUnit
            // 
            this.labUnit.AutoSize = true;
            this.labUnit.ForeColor = System.Drawing.Color.Green;
            this.labUnit.Location = new System.Drawing.Point(272, 106);
            this.labUnit.Name = "labUnit";
            this.labUnit.Size = new System.Drawing.Size(34, 20);
            this.labUnit.TabIndex = 67;
            this.labUnit.Text = "[%]";
            this.labUnit.Click += new System.EventHandler(this.labUnit_Click);
            this.labUnit.MouseLeave += new System.EventHandler(this.labUnit_MouseLeave);
            this.labUnit.MouseHover += new System.EventHandler(this.labUnit_MouseHover);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.ForeColor = System.Drawing.Color.Green;
            this.label71.Location = new System.Drawing.Point(272, 69);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(46, 20);
            this.label71.TabIndex = 66;
            this.label71.Text = "[sec]";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label72.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label72.Location = new System.Drawing.Point(8, 106);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(76, 20);
            this.label72.TabIndex = 63;
            this.label72.Text = "ON time:";
            // 
            // label74
            // 
            this.label74.BackColor = System.Drawing.Color.Silver;
            this.label74.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label74.Dock = System.Windows.Forms.DockStyle.Top;
            this.label74.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label74.Location = new System.Drawing.Point(3, 23);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(359, 25);
            this.label74.TabIndex = 60;
            this.label74.Text = "VAPORISER";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dEditOnTime
            // 
            this.dEditOnTime.Location = new System.Drawing.Point(125, 104);
            this.dEditOnTime.Margin = new System.Windows.Forms.Padding(5);
            this.dEditOnTime.Mask = "{0:F3}";
            this.dEditOnTime.MaximumValue = 100000D;
            this.dEditOnTime.MinimumValue = 0D;
            this.dEditOnTime.Name = "dEditOnTime";
            this.dEditOnTime.Size = new System.Drawing.Size(100, 28);
            this.dEditOnTime.TabIndex = 74;
            this.dEditOnTime.Value = 100000D;
            this.dEditOnTime.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditOnTime_EnterOn);
            // 
            // dEditCycleTImne
            // 
            this.dEditCycleTImne.Location = new System.Drawing.Point(125, 65);
            this.dEditCycleTImne.Margin = new System.Windows.Forms.Padding(4);
            this.dEditCycleTImne.Mask = "{0:F3}";
            this.dEditCycleTImne.MaximumValue = 100000D;
            this.dEditCycleTImne.MinimumValue = 0D;
            this.dEditCycleTImne.Name = "dEditCycleTImne";
            this.dEditCycleTImne.Size = new System.Drawing.Size(102, 27);
            this.dEditCycleTImne.TabIndex = 73;
            this.dEditCycleTImne.Value = 100000D;
            this.dEditCycleTImne.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditCycleTImne_EnterOn);
            // 
            // VaporiserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "VaporiserPanel";
            this.Size = new System.Drawing.Size(370, 133);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labUnit;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label1;
        private Cotrols.DoubleEdit dEditCycleTImne;
        private Cotrols.DoubleEdit dEditOnTime;
    }
}
