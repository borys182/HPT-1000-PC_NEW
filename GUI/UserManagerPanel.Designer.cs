﻿namespace HPT1000.GUI
{
    partial class UserManagerPanel
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
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewUsers
            // 
            this.listViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.ColumnHeader3,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listViewUsers.ContextMenuStrip = this.contextMenuStrip;
            this.listViewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.GridLines = true;
            this.listViewUsers.Location = new System.Drawing.Point(3, 23);
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.OwnerDraw = true;
            this.listViewUsers.Size = new System.Drawing.Size(1692, 773);
            this.listViewUsers.TabIndex = 4;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.View = System.Windows.Forms.View.Details;
            this.listViewUsers.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewUsers_DrawColumnHeader);
            this.listViewUsers.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewUsers_DrawItem);
            this.listViewUsers.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listViewUsers_DrawSubItem);
            this.listViewUsers.DoubleClick += new System.EventHandler(this.listViewUsers_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 195;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Surname";
            this.columnHeader2.Width = 195;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Login";
            this.ColumnHeader3.Width = 195;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Privilige";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Allow to change";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Block account";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Block start date";
            this.columnHeader8.Width = 155;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Block end date";
            this.columnHeader9.Width = 155;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newUserToolStripMenuItem,
            this.removeUserToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(170, 56);
            // 
            // newUserToolStripMenuItem
            // 
            this.newUserToolStripMenuItem.Name = "newUserToolStripMenuItem";
            this.newUserToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.newUserToolStripMenuItem.Text = "New user";
            this.newUserToolStripMenuItem.Click += new System.EventHandler(this.newUserToolStripMenuItem_Click);
            // 
            // removeUserToolStripMenuItem
            // 
            this.removeUserToolStripMenuItem.Name = "removeUserToolStripMenuItem";
            this.removeUserToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.removeUserToolStripMenuItem.Text = "Remove user";
            this.removeUserToolStripMenuItem.Click += new System.EventHandler(this.removeUserToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewUsers);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1698, 799);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List users";
            // 
            // UserManagerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "UserManagerPanel";
            this.Size = new System.Drawing.Size(1698, 799);
            this.VisibleChanged += new System.EventHandler(this.UserManagerPanel_VisibleChanged);
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeUserToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
