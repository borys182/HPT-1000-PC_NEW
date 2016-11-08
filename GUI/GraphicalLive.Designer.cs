namespace HPT1000.GUI
{
    partial class GraphicalLive
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicalLive));
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grBoxSeries = new System.Windows.Forms.GroupBox();
            this.cBoxVoltage = new System.Windows.Forms.CheckBox();
            this.cBoxCurent = new System.Windows.Forms.CheckBox();
            this.cBoxFlow1 = new System.Windows.Forms.CheckBox();
            this.cBoxFlow3 = new System.Windows.Forms.CheckBox();
            this.cBoxFlow2 = new System.Windows.Forms.CheckBox();
            this.cBoxPressure = new System.Windows.Forms.CheckBox();
            this.cBoxPower = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxChart = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnZoomReset = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.grBoxSeries.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.LightGray;
            this.chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            this.chart.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            chartArea4.AxisX.Crossing = -1.7976931348623157E+308D;
            chartArea4.AxisX.IsMarginVisible = false;
            chartArea4.AxisX.IsStartedFromZero = false;
            chartArea4.AxisX.MajorGrid.Interval = 0D;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea4.AxisX.MinorGrid.Enabled = true;
            chartArea4.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea4.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea4.AxisY.MinorGrid.Enabled = true;
            chartArea4.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea4.AxisY.Title = "pressure [mBar]";
            chartArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea4.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            chartArea4.CursorX.IsUserSelectionEnabled = true;
            chartArea4.CursorY.IsUserSelectionEnabled = true;
            chartArea4.Name = "ChartAreaPressure";
            chartArea5.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea5.AxisX.MinorGrid.Enabled = true;
            chartArea5.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea5.AxisY.MinorGrid.Enabled = true;
            chartArea5.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea5.AxisY.Title = "value";
            chartArea5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea5.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            chartArea5.CursorX.IsUserSelectionEnabled = true;
            chartArea5.CursorY.IsUserSelectionEnabled = true;
            chartArea5.Name = "ChartAreaPower";
            chartArea6.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea6.AxisX.MinorGrid.Enabled = true;
            chartArea6.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea6.AxisX.Title = "time [s]";
            chartArea6.AxisY.MinorGrid.Enabled = true;
            chartArea6.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea6.AxisY.Title = "flow [sccm]";
            chartArea6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea6.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            chartArea6.CursorX.IsUserSelectionEnabled = true;
            chartArea6.CursorY.IsUserSelectionEnabled = true;
            chartArea6.Name = "ChartAreaMFC";
            this.chart.ChartAreas.Add(chartArea4);
            this.chart.ChartAreas.Add(chartArea5);
            this.chart.ChartAreas.Add(chartArea6);
            this.chart.Location = new System.Drawing.Point(-3, 30);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series4.ChartArea = "ChartAreaPressure";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Series1";
            series5.ChartArea = "ChartAreaPower";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "Series2";
            series6.ChartArea = "ChartAreaMFC";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Name = "Series3";
            this.chart.Series.Add(series4);
            this.chart.Series.Add(series5);
            this.chart.Series.Add(series6);
            this.chart.Size = new System.Drawing.Size(1124, 672);
            this.chart.TabIndex = 0;
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
            this.grBoxSeries.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grBoxSeries.Location = new System.Drawing.Point(0, 685);
            this.grBoxSeries.Name = "grBoxSeries";
            this.grBoxSeries.Size = new System.Drawing.Size(1124, 63);
            this.grBoxSeries.TabIndex = 11;
            this.grBoxSeries.TabStop = false;
            this.grBoxSeries.Text = "Series";
            // 
            // cBoxVoltage
            // 
            this.cBoxVoltage.AutoSize = true;
            this.cBoxVoltage.Checked = true;
            this.cBoxVoltage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxVoltage.Location = new System.Drawing.Point(352, 26);
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
            this.cBoxCurent.Location = new System.Drawing.Point(493, 26);
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
            this.cBoxFlow1.Location = new System.Drawing.Point(618, 26);
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
            this.cBoxFlow3.Location = new System.Drawing.Point(946, 26);
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
            this.cBoxFlow2.Location = new System.Drawing.Point(782, 26);
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
            this.cBoxPressure.Location = new System.Drawing.Point(32, 26);
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
            this.cBoxPower.Location = new System.Drawing.Point(215, 26);
            this.cBoxPower.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cBoxPower.Name = "cBoxPower";
            this.cBoxPower.Size = new System.Drawing.Size(114, 24);
            this.cBoxPower.TabIndex = 11;
            this.cBoxPower.Text = "Power: [W]";
            this.cBoxPower.UseVisualStyleBackColor = true;
            this.cBoxPower.CheckedChanged += new System.EventHandler(this.cBox_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.toolStripBtnClear,
            this.toolStripSeparator3,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripComboBoxChart,
            this.toolStripSeparator2,
            this.toolStripSeparator4,
            this.toolStripBtnZoomReset});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1124, 28);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripBtnClear
            // 
            this.toolStripBtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnClear.Image = global::HPT1000.Properties.Resources.Clear;
            this.toolStripBtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnClear.Name = "toolStripBtnClear";
            this.toolStripBtnClear.Size = new System.Drawing.Size(24, 25);
            this.toolStripBtnClear.Text = "toolStripButton1";
            this.toolStripBtnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            // GraphicalLive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grBoxSeries);
            this.Controls.Add(this.chart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "GraphicalLive";
            this.Size = new System.Drawing.Size(1124, 748);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.grBoxSeries.ResumeLayout(false);
            this.grBoxSeries.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.GroupBox grBoxSeries;
        private System.Windows.Forms.CheckBox cBoxVoltage;
        private System.Windows.Forms.CheckBox cBoxCurent;
        private System.Windows.Forms.CheckBox cBoxFlow1;
        private System.Windows.Forms.CheckBox cBoxFlow3;
        private System.Windows.Forms.CheckBox cBoxFlow2;
        private System.Windows.Forms.CheckBox cBoxPressure;
        private System.Windows.Forms.CheckBox cBoxPower;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnClear;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxChart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripBtnZoomReset;
    }
}
