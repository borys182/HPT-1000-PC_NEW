namespace HPT1000.GUI
{
    partial class ArchivePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchivePanel));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.timeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.timeStart = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxChart = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnZoomReset = new System.Windows.Forms.ToolStripButton();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grBoxSeries = new System.Windows.Forms.GroupBox();
            this.cBoxVoltage = new System.Windows.Forms.CheckBox();
            this.cBoxCurent = new System.Windows.Forms.CheckBox();
            this.cBoxFlow1 = new System.Windows.Forms.CheckBox();
            this.cBoxFlow3 = new System.Windows.Forms.CheckBox();
            this.cBoxFlow2 = new System.Windows.Forms.CheckBox();
            this.cBoxPressure = new System.Windows.Forms.CheckBox();
            this.cBoxPower = new System.Windows.Forms.CheckBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.grBoxSeries.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnGetData);
            this.groupBox1.Controls.Add(this.timeEnd);
            this.groupBox1.Controls.Add(this.dateStart);
            this.groupBox1.Controls.Add(this.timeStart);
            this.groupBox1.Controls.Add(this.dateEnd);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(1462, 473);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 312);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Range time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(24, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Date start:";
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(4, 252);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(213, 40);
            this.btnGetData.TabIndex = 19;
            this.btnGetData.Text = "Load Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // timeEnd
            // 
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeEnd.Location = new System.Drawing.Point(124, 177);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.ShowUpDown = true;
            this.timeEnd.Size = new System.Drawing.Size(96, 27);
            this.timeEnd.TabIndex = 21;
            // 
            // dateStart
            // 
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStart.Location = new System.Drawing.Point(5, 87);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(117, 27);
            this.dateStart.TabIndex = 15;
            // 
            // timeStart
            // 
            this.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeStart.Location = new System.Drawing.Point(124, 87);
            this.timeStart.Name = "timeStart";
            this.timeStart.ShowUpDown = true;
            this.timeStart.Size = new System.Drawing.Size(96, 27);
            this.timeStart.TabIndex = 20;
            // 
            // dateEnd
            // 
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd.Location = new System.Drawing.Point(5, 177);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(117, 27);
            this.dateEnd.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(24, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Date End:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.toolStripSeparator3,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripComboBoxChart,
            this.toolStripSeparator2,
            this.toolStripSeparator4,
            this.toolStripBtnZoomReset});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1690, 28);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(100, 25);
            this.toolStripLabel1.Text = "Show data as:";
            // 
            // toolStripComboBoxChart
            // 
            this.toolStripComboBoxChart.Name = "toolStripComboBoxChart";
            this.toolStripComboBoxChart.Size = new System.Drawing.Size(151, 28);
            this.toolStripComboBoxChart.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxChart_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripBtnZoomReset
            // 
            this.toolStripBtnZoomReset.AutoSize = false;
            this.toolStripBtnZoomReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnZoomReset.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnZoomReset.Image")));
            this.toolStripBtnZoomReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnZoomReset.Name = "toolStripBtnZoomReset";
            this.toolStripBtnZoomReset.Size = new System.Drawing.Size(100, 25);
            this.toolStripBtnZoomReset.Text = "Zoom Reset";
            this.toolStripBtnZoomReset.Click += new System.EventHandler(this.toolStripBtnZoomReset_Click);
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.LightGray;
            this.chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            this.chart.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            chartArea1.AxisX.Crossing = -1.7976931348623157E+308D;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.MajorGrid.Interval = 0D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.Title = "pressure [mBar]";
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartAreaPressure";
            chartArea2.AxisX.Crossing = -1.7976931348623157E+308D;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.AxisX.MinorGrid.Enabled = true;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.MinorGrid.Enabled = true;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.Title = "value";
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartAreaPower";
            chartArea3.AxisX.Crossing = -1.7976931348623157E+308D;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisX.MinorGrid.Enabled = true;
            chartArea3.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea3.AxisX.Title = "time [s]";
            chartArea3.AxisY.MinorGrid.Enabled = true;
            chartArea3.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea3.AxisY.Title = "flow [sccm]";
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            chartArea3.CursorX.IsUserSelectionEnabled = true;
            chartArea3.CursorY.IsUserSelectionEnabled = true;
            chartArea3.Name = "ChartAreaMFC";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.ChartAreas.Add(chartArea3);
            this.chart.Location = new System.Drawing.Point(1, 27);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartAreaPressure";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            series2.ChartArea = "ChartAreaPower";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series2";
            series3.ChartArea = "ChartAreaMFC";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Series3";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(1452, 757);
            this.chart.TabIndex = 12;
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            this.chart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart_MouseUp);
            // 
            // grBoxSeries
            // 
            this.grBoxSeries.Controls.Add(this.cBoxVoltage);
            this.grBoxSeries.Controls.Add(this.cBoxCurent);
            this.grBoxSeries.Controls.Add(this.cBoxFlow1);
            this.grBoxSeries.Controls.Add(this.cBoxFlow3);
            this.grBoxSeries.Controls.Add(this.cBoxFlow2);
            this.grBoxSeries.Controls.Add(this.cBoxPressure);
            this.grBoxSeries.Controls.Add(this.cBoxPower);
            this.grBoxSeries.Location = new System.Drawing.Point(1462, 30);
            this.grBoxSeries.Name = "grBoxSeries";
            this.grBoxSeries.Size = new System.Drawing.Size(221, 420);
            this.grBoxSeries.TabIndex = 14;
            this.grBoxSeries.TabStop = false;
            this.grBoxSeries.Text = "Series";
            // 
            // cBoxVoltage
            // 
            this.cBoxVoltage.AutoSize = true;
            this.cBoxVoltage.Checked = true;
            this.cBoxVoltage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxVoltage.Location = new System.Drawing.Point(28, 135);
            this.cBoxVoltage.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cBoxVoltage.Name = "cBoxVoltage";
            this.cBoxVoltage.Size = new System.Drawing.Size(118, 24);
            this.cBoxVoltage.TabIndex = 17;
            this.cBoxVoltage.Text = "Voltage: [V]";
            this.cBoxVoltage.UseVisualStyleBackColor = true;
            this.cBoxVoltage.CheckedChanged += new System.EventHandler(this.cBox_CheckedChanged);
            // 
            // cBoxCurent
            // 
            this.cBoxCurent.AutoSize = true;
            this.cBoxCurent.Checked = true;
            this.cBoxCurent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxCurent.Location = new System.Drawing.Point(28, 78);
            this.cBoxCurent.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cBoxCurent.Name = "cBoxCurent";
            this.cBoxCurent.Size = new System.Drawing.Size(102, 24);
            this.cBoxCurent.TabIndex = 16;
            this.cBoxCurent.Text = "Curent[A]";
            this.cBoxCurent.UseVisualStyleBackColor = true;
            this.cBoxCurent.CheckedChanged += new System.EventHandler(this.cBox_CheckedChanged);
            // 
            // cBoxFlow1
            // 
            this.cBoxFlow1.AutoSize = true;
            this.cBoxFlow1.Checked = true;
            this.cBoxFlow1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxFlow1.Location = new System.Drawing.Point(28, 248);
            this.cBoxFlow1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cBoxFlow1.Name = "cBoxFlow1";
            this.cBoxFlow1.Size = new System.Drawing.Size(141, 24);
            this.cBoxFlow1.TabIndex = 15;
            this.cBoxFlow1.Text = "Flow 1: [sccm]";
            this.cBoxFlow1.UseVisualStyleBackColor = true;
            this.cBoxFlow1.CheckedChanged += new System.EventHandler(this.cBox_CheckedChanged);
            // 
            // cBoxFlow3
            // 
            this.cBoxFlow3.AutoSize = true;
            this.cBoxFlow3.Checked = true;
            this.cBoxFlow3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxFlow3.Location = new System.Drawing.Point(28, 359);
            this.cBoxFlow3.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cBoxFlow3.Name = "cBoxFlow3";
            this.cBoxFlow3.Size = new System.Drawing.Size(141, 24);
            this.cBoxFlow3.TabIndex = 14;
            this.cBoxFlow3.Text = "Flow 3: [sccm]";
            this.cBoxFlow3.UseVisualStyleBackColor = true;
            this.cBoxFlow3.CheckedChanged += new System.EventHandler(this.cBox_CheckedChanged);
            // 
            // cBoxFlow2
            // 
            this.cBoxFlow2.AutoSize = true;
            this.cBoxFlow2.Checked = true;
            this.cBoxFlow2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxFlow2.Location = new System.Drawing.Point(28, 305);
            this.cBoxFlow2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cBoxFlow2.Name = "cBoxFlow2";
            this.cBoxFlow2.Size = new System.Drawing.Size(141, 24);
            this.cBoxFlow2.TabIndex = 13;
            this.cBoxFlow2.Text = "Flow 2: [sccm]";
            this.cBoxFlow2.UseVisualStyleBackColor = true;
            this.cBoxFlow2.CheckedChanged += new System.EventHandler(this.cBox_CheckedChanged);
            // 
            // cBoxPressure
            // 
            this.cBoxPressure.AutoSize = true;
            this.cBoxPressure.Checked = true;
            this.cBoxPressure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxPressure.Location = new System.Drawing.Point(28, 26);
            this.cBoxPressure.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cBoxPressure.Name = "cBoxPressure";
            this.cBoxPressure.Size = new System.Drawing.Size(160, 24);
            this.cBoxPressure.TabIndex = 12;
            this.cBoxPressure.Text = "Pressure: [mBar]";
            this.cBoxPressure.UseVisualStyleBackColor = true;
            this.cBoxPressure.CheckedChanged += new System.EventHandler(this.cBox_CheckedChanged);
            // 
            // cBoxPower
            // 
            this.cBoxPower.AutoSize = true;
            this.cBoxPower.Checked = true;
            this.cBoxPower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxPower.Location = new System.Drawing.Point(28, 193);
            this.cBoxPower.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cBoxPower.Name = "cBoxPower";
            this.cBoxPower.Size = new System.Drawing.Size(114, 24);
            this.cBoxPower.TabIndex = 11;
            this.cBoxPower.Text = "Power: [W]";
            this.cBoxPower.UseVisualStyleBackColor = true;
            this.cBoxPower.CheckedChanged += new System.EventHandler(this.cBox_CheckedChanged);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // ArchivePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grBoxSeries);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "ArchivePanel";
            this.Size = new System.Drawing.Size(1690, 790);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.grBoxSeries.ResumeLayout(false);
            this.grBoxSeries.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxChart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripBtnZoomReset;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.GroupBox grBoxSeries;
        private System.Windows.Forms.CheckBox cBoxVoltage;
        private System.Windows.Forms.CheckBox cBoxCurent;
        private System.Windows.Forms.CheckBox cBoxFlow1;
        private System.Windows.Forms.CheckBox cBoxFlow3;
        private System.Windows.Forms.CheckBox cBoxFlow2;
        private System.Windows.Forms.CheckBox cBoxPressure;
        private System.Windows.Forms.CheckBox cBoxPower;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker timeEnd;
        private System.Windows.Forms.DateTimePicker timeStart;
    }
}
