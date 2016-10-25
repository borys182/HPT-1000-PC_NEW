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
            this.cBoxDummyMode = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.btnSelectDir = new System.Windows.Forms.Button();
            this.tBoxPath = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label47 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label44 = new System.Windows.Forms.Label();
            this.cBoxLanguge = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
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
            this.timer.Interval = 1000;
            // 
            // cBoxDummyMode
            // 
            this.cBoxDummyMode.AutoSize = true;
            this.cBoxDummyMode.Location = new System.Drawing.Point(170, 641);
            this.cBoxDummyMode.Name = "cBoxDummyMode";
            this.cBoxDummyMode.Size = new System.Drawing.Size(135, 24);
            this.cBoxDummyMode.TabIndex = 104;
            this.cBoxDummyMode.Text = "Dummy mode";
            this.cBoxDummyMode.UseVisualStyleBackColor = true;
            this.cBoxDummyMode.CheckedChanged += new System.EventHandler(this.cBoxDummyMode_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(78, 597);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 103;
            this.label4.Text = "Dummy mode:";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(159, 468);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(343, 24);
            this.checkBox5.TabIndex = 102;
            this.checkBox5.Text = "Monthly saving in sub directory (YYY-MM)";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Location = new System.Drawing.Point(1235, 385);
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.Size = new System.Drawing.Size(55, 30);
            this.btnSelectDir.TabIndex = 101;
            this.btnSelectDir.Text = "...";
            this.btnSelectDir.UseVisualStyleBackColor = true;
            this.btnSelectDir.Click += new System.EventHandler(this.btnSelectDir_Click);
            // 
            // tBoxPath
            // 
            this.tBoxPath.Location = new System.Drawing.Point(591, 387);
            this.tBoxPath.Name = "tBoxPath";
            this.tBoxPath.Size = new System.Drawing.Size(621, 27);
            this.tBoxPath.TabIndex = 100;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label48.Location = new System.Drawing.Point(520, 390);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(48, 20);
            this.label48.TabIndex = 99;
            this.label48.Text = "Path:";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(159, 389);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(226, 24);
            this.checkBox4.TabIndex = 98;
            this.checkBox4.Text = "Perform at end of process";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label47.Location = new System.Drawing.Point(78, 319);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(177, 20);
            this.label47.TabIndex = 97;
            this.label47.Text = "Automatic data export:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(159, 234);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(226, 24);
            this.checkBox1.TabIndex = 96;
            this.checkBox1.Text = "Perform at end of process";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label44.Location = new System.Drawing.Point(78, 181);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(142, 20);
            this.label44.TabIndex = 95;
            this.label44.Text = "Automatic saving:";
            // 
            // cBoxLanguge
            // 
            this.cBoxLanguge.FormattingEnabled = true;
            this.cBoxLanguge.Items.AddRange(new object[] {
            "English"});
            this.cBoxLanguge.Location = new System.Drawing.Point(276, 74);
            this.cBoxLanguge.Name = "cBoxLanguge";
            this.cBoxLanguge.Size = new System.Drawing.Size(141, 28);
            this.cBoxLanguge.TabIndex = 94;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label45.Location = new System.Drawing.Point(78, 77);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(146, 20);
            this.label45.TabIndex = 93;
            this.label45.Text = "Start-up language:";
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.cBoxDummyMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.btnSelectDir);
            this.Controls.Add(this.tBoxPath);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.cBoxLanguge);
            this.Controls.Add(this.label45);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(1670, 745);
            this.VisibleChanged += new System.EventHandler(this.SettingsPanel_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox cBoxDummyMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Button btnSelectDir;
        private System.Windows.Forms.TextBox tBoxPath;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.ComboBox cBoxLanguge;
        private System.Windows.Forms.Label label45;
    }
}
