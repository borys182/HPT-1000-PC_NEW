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
            this.btnSetOnTime = new System.Windows.Forms.Button();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.btnSetCycleTime = new System.Windows.Forms.Button();
            this.tBoxOnTime = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.tBoxCycleTime = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSetOnTime);
            this.groupBox1.Controls.Add(this.label70);
            this.groupBox1.Controls.Add(this.label71);
            this.groupBox1.Controls.Add(this.btnSetCycleTime);
            this.groupBox1.Controls.Add(this.tBoxOnTime);
            this.groupBox1.Controls.Add(this.label72);
            this.groupBox1.Controls.Add(this.label73);
            this.groupBox1.Controls.Add(this.tBoxCycleTime);
            this.groupBox1.Controls.Add(this.label74);
            this.groupBox1.Location = new System.Drawing.Point(3, -11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 138);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            // 
            // btnSetOnTime
            // 
            this.btnSetOnTime.Location = new System.Drawing.Point(264, 99);
            this.btnSetOnTime.Name = "btnSetOnTime";
            this.btnSetOnTime.Size = new System.Drawing.Size(65, 29);
            this.btnSetOnTime.TabIndex = 68;
            this.btnSetOnTime.Text = "Set";
            this.btnSetOnTime.UseVisualStyleBackColor = true;
            this.btnSetOnTime.Click += new System.EventHandler(this.btnSetOnTime_Click);
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.ForeColor = System.Drawing.Color.Green;
            this.label70.Location = new System.Drawing.Point(219, 102);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(34, 20);
            this.label70.TabIndex = 67;
            this.label70.Text = "[%]";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.ForeColor = System.Drawing.Color.Green;
            this.label71.Location = new System.Drawing.Point(213, 65);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(46, 20);
            this.label71.TabIndex = 66;
            this.label71.Text = "[sec]";
            // 
            // btnSetCycleTime
            // 
            this.btnSetCycleTime.Location = new System.Drawing.Point(264, 59);
            this.btnSetCycleTime.Name = "btnSetCycleTime";
            this.btnSetCycleTime.Size = new System.Drawing.Size(65, 29);
            this.btnSetCycleTime.TabIndex = 65;
            this.btnSetCycleTime.Text = "Set";
            this.btnSetCycleTime.UseVisualStyleBackColor = true;
            this.btnSetCycleTime.Click += new System.EventHandler(this.btnSetCycleTime_Click);
            // 
            // tBoxOnTime
            // 
            this.tBoxOnTime.Location = new System.Drawing.Point(109, 100);
            this.tBoxOnTime.Name = "tBoxOnTime";
            this.tBoxOnTime.Size = new System.Drawing.Size(100, 27);
            this.tBoxOnTime.TabIndex = 64;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label72.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label72.Location = new System.Drawing.Point(8, 105);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(76, 20);
            this.label72.TabIndex = 63;
            this.label72.Text = "ON time:";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label73.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label73.Location = new System.Drawing.Point(6, 67);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(93, 20);
            this.label73.TabIndex = 62;
            this.label73.Text = "Cycle time:";
            // 
            // tBoxCycleTime
            // 
            this.tBoxCycleTime.Location = new System.Drawing.Point(109, 62);
            this.tBoxCycleTime.Name = "tBoxCycleTime";
            this.tBoxCycleTime.Size = new System.Drawing.Size(100, 27);
            this.tBoxCycleTime.TabIndex = 61;
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
            // VaporiserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "VaporiserPanel";
            this.Size = new System.Drawing.Size(370, 128);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSetOnTime;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Button btnSetCycleTime;
        private System.Windows.Forms.TextBox tBoxOnTime;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox tBoxCycleTime;
        private System.Windows.Forms.Label label74;
    }
}
