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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchivePanel));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grBoxParameter = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cBoxParaActive = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labParaUnit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnGetData = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeViewDevices = new System.Windows.Forms.TreeView();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rBtnAcqDuringProcess = new System.Windows.Forms.RadioButton();
            this.rBtnAcqAllTime = new System.Windows.Forms.RadioButton();
            this.cBoxActivePressure = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.labUnitPressure = new System.Windows.Forms.Label();
            this.labPressure = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timeStart = new System.Windows.Forms.DateTimePicker();
            this.timeEnd = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dEditAcqPressure = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditDifferencesValue = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.dEditFrqAcq = new HPT1000.GUI.Cotrols.DoubleEdit();
            this.grBoxParameter.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.grBoxSeries.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grBoxParameter
            // 
            this.grBoxParameter.Controls.Add(this.label4);
            this.grBoxParameter.Controls.Add(this.cBoxParaActive);
            this.grBoxParameter.Controls.Add(this.label9);
            this.grBoxParameter.Controls.Add(this.label8);
            this.grBoxParameter.Controls.Add(this.labParaUnit);
            this.grBoxParameter.Controls.Add(this.dEditDifferencesValue);
            this.grBoxParameter.Controls.Add(this.label3);
            this.grBoxParameter.Controls.Add(this.dEditFrqAcq);
            this.grBoxParameter.Controls.Add(this.label2);
            this.grBoxParameter.Controls.Add(this.label1);
            this.grBoxParameter.Location = new System.Drawing.Point(419, 338);
            this.grBoxParameter.Name = "grBoxParameter";
            this.grBoxParameter.Size = new System.Drawing.Size(1192, 379);
            this.grBoxParameter.TabIndex = 5;
            this.grBoxParameter.TabStop = false;
            this.grBoxParameter.Text = "Parameter configuration";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(37, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(866, 42);
            this.label4.TabIndex = 106;
            this.label4.Text = "Determine is value of parameter is saved in archive";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cBoxParaActive
            // 
            this.cBoxParaActive.AutoSize = true;
            this.cBoxParaActive.Location = new System.Drawing.Point(87, 97);
            this.cBoxParaActive.Name = "cBoxParaActive";
            this.cBoxParaActive.Size = new System.Drawing.Size(257, 24);
            this.cBoxParaActive.TabIndex = 105;
            this.cBoxParaActive.Text = "Enabled parameter acquisition";
            this.cBoxParaActive.UseVisualStyleBackColor = true;
            this.cBoxParaActive.CheckedChanged += new System.EventHandler(this.cBoxParaActive_CheckedChanged);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(37, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(866, 42);
            this.label9.TabIndex = 104;
            this.label9.Text = "Parameter determines level of differences between actual and last value when data" +
    " of chamber parameters should be saved in archive.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(37, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(866, 42);
            this.label8.TabIndex = 103;
            this.label8.Text = "Parameter determines how often data of chamber parameters should be saved in  arc" +
    "hive.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labParaUnit
            // 
            this.labParaUnit.AutoSize = true;
            this.labParaUnit.ForeColor = System.Drawing.Color.Green;
            this.labParaUnit.Location = new System.Drawing.Point(461, 319);
            this.labParaUnit.Name = "labParaUnit";
            this.labParaUnit.Size = new System.Drawing.Size(35, 20);
            this.labParaUnit.TabIndex = 5;
            this.labParaUnit.Text = "[W]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(83, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Difference values:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(461, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "[s]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(83, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Frequency:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1690, 790);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.chart);
            this.tabPage1.Controls.Add(this.grBoxSeries);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1682, 757);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "History data";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // dateEnd
            // 
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd.Location = new System.Drawing.Point(5, 177);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(117, 27);
            this.dateEnd.TabIndex = 16;
            // 
            // dateStart
            // 
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStart.Location = new System.Drawing.Point(5, 87);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(117, 27);
            this.dateStart.TabIndex = 15;
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
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1676, 28);
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
            this.chart.Location = new System.Drawing.Point(0, 30);
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
            this.chart.Size = new System.Drawing.Size(1450, 721);
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
            this.grBoxSeries.Location = new System.Drawing.Point(1456, 34);
            this.grBoxSeries.Name = "grBoxSeries";
            this.grBoxSeries.Size = new System.Drawing.Size(221, 409);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1682, 757);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuration data acquisition";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeViewDevices);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.grBoxParameter);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1676, 755);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Acquisition configuration";
            // 
            // treeViewDevices
            // 
            this.treeViewDevices.Location = new System.Drawing.Point(31, 77);
            this.treeViewDevices.Name = "treeViewDevices";
            this.treeViewDevices.Size = new System.Drawing.Size(357, 640);
            this.treeViewDevices.TabIndex = 9;
            this.treeViewDevices.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDevices_AfterSelect);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(279, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "List all parameters saving in archive";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rBtnAcqDuringProcess);
            this.groupBox4.Controls.Add(this.rBtnAcqAllTime);
            this.groupBox4.Controls.Add(this.cBoxActivePressure);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label40);
            this.groupBox4.Controls.Add(this.dEditAcqPressure);
            this.groupBox4.Controls.Add(this.labUnitPressure);
            this.groupBox4.Controls.Add(this.labPressure);
            this.groupBox4.Location = new System.Drawing.Point(418, 67);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1193, 262);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Conditions of start acquisition all data";
            // 
            // rBtnAcqDuringProcess
            // 
            this.rBtnAcqDuringProcess.AutoSize = true;
            this.rBtnAcqDuringProcess.Location = new System.Drawing.Point(88, 213);
            this.rBtnAcqDuringProcess.Name = "rBtnAcqDuringProcess";
            this.rBtnAcqDuringProcess.Size = new System.Drawing.Size(233, 24);
            this.rBtnAcqDuringProcess.TabIndex = 105;
            this.rBtnAcqDuringProcess.TabStop = true;
            this.rBtnAcqDuringProcess.Text = "Acquisioton during process";
            this.rBtnAcqDuringProcess.UseVisualStyleBackColor = true;
            this.rBtnAcqDuringProcess.Click += new System.EventHandler(this.rBtnAcqDuringProcess_Click);
            // 
            // rBtnAcqAllTime
            // 
            this.rBtnAcqAllTime.AutoSize = true;
            this.rBtnAcqAllTime.Location = new System.Drawing.Point(440, 213);
            this.rBtnAcqAllTime.Name = "rBtnAcqAllTime";
            this.rBtnAcqAllTime.Size = new System.Drawing.Size(171, 24);
            this.rBtnAcqAllTime.TabIndex = 104;
            this.rBtnAcqAllTime.TabStop = true;
            this.rBtnAcqAllTime.Text = "Acquisition all time";
            this.rBtnAcqAllTime.UseVisualStyleBackColor = true;
            this.rBtnAcqAllTime.Click += new System.EventHandler(this.rBtnAcqAllTime_Click);
            // 
            // cBoxActivePressure
            // 
            this.cBoxActivePressure.AutoSize = true;
            this.cBoxActivePressure.Location = new System.Drawing.Point(587, 107);
            this.cBoxActivePressure.Name = "cBoxActivePressure";
            this.cBoxActivePressure.Size = new System.Drawing.Size(127, 24);
            this.cBoxActivePressure.TabIndex = 103;
            this.cBoxActivePressure.Text = "Active option";
            this.cBoxActivePressure.UseVisualStyleBackColor = true;
            this.cBoxActivePressure.CheckedChanged += new System.EventHandler(this.cBoxActivePressure_CheckedChanged);
            this.cBoxActivePressure.Click += new System.EventHandler(this.cBoxActivePressure_Click);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(38, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(866, 42);
            this.label7.TabIndex = 102;
            this.label7.Text = "Checkbox determines if parameters data of chamber should be saved in data archive" +
    " only during a process";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label40.Location = new System.Drawing.Point(38, 37);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(866, 42);
            this.label40.TabIndex = 100;
            this.label40.Text = "Parameter determines level of pressure when parameter data of chamber will be sav" +
    "ed in data archive. Data will be saved when pressure will be less than set value" +
    "";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labUnitPressure
            // 
            this.labUnitPressure.AutoSize = true;
            this.labUnitPressure.ForeColor = System.Drawing.Color.Green;
            this.labUnitPressure.Location = new System.Drawing.Point(462, 108);
            this.labUnitPressure.Name = "labUnitPressure";
            this.labUnitPressure.Size = new System.Drawing.Size(60, 20);
            this.labUnitPressure.TabIndex = 4;
            this.labUnitPressure.Text = "[mBar]";
            // 
            // labPressure
            // 
            this.labPressure.AutoSize = true;
            this.labPressure.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labPressure.Location = new System.Drawing.Point(84, 108);
            this.labPressure.Name = "labPressure";
            this.labPressure.Size = new System.Drawing.Size(153, 20);
            this.labPressure.TabIndex = 3;
            this.labPressure.Text = "Start acq pressure:";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
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
            // timeEnd
            // 
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeEnd.Location = new System.Drawing.Point(124, 177);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.ShowUpDown = true;
            this.timeEnd.Size = new System.Drawing.Size(96, 27);
            this.timeEnd.TabIndex = 21;
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
            this.groupBox1.Location = new System.Drawing.Point(1456, 449);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 302);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Range time";
            // 
            // dEditAcqPressure
            // 
            this.dEditAcqPressure.Location = new System.Drawing.Point(282, 104);
            this.dEditAcqPressure.Margin = new System.Windows.Forms.Padding(4);
            this.dEditAcqPressure.Mask = "0.000";
            this.dEditAcqPressure.MaximumValue = 1200D;
            this.dEditAcqPressure.MinimumValue = 0D;
            this.dEditAcqPressure.Name = "dEditAcqPressure";
            this.dEditAcqPressure.ReadOnly = false;
            this.dEditAcqPressure.Size = new System.Drawing.Size(155, 28);
            this.dEditAcqPressure.TabIndex = 5;
            this.dEditAcqPressure.Value = 0D;
            this.dEditAcqPressure.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditAcqPressure_EnterOn);
            // 
            // dEditDifferencesValue
            // 
            this.dEditDifferencesValue.Location = new System.Drawing.Point(281, 319);
            this.dEditDifferencesValue.Mask = "0.000";
            this.dEditDifferencesValue.MaximumValue = 10000000D;
            this.dEditDifferencesValue.MinimumValue = 0D;
            this.dEditDifferencesValue.Name = "dEditDifferencesValue";
            this.dEditDifferencesValue.ReadOnly = false;
            this.dEditDifferencesValue.Size = new System.Drawing.Size(148, 22);
            this.dEditDifferencesValue.TabIndex = 4;
            this.dEditDifferencesValue.Value = 0D;
            this.dEditDifferencesValue.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditDifferencesValue_EnterOn);
            // 
            // dEditFrqAcq
            // 
            this.dEditFrqAcq.Location = new System.Drawing.Point(281, 195);
            this.dEditFrqAcq.Mask = "0.000";
            this.dEditFrqAcq.MaximumValue = 3600000D;
            this.dEditFrqAcq.MinimumValue = 0.5D;
            this.dEditFrqAcq.Name = "dEditFrqAcq";
            this.dEditFrqAcq.ReadOnly = false;
            this.dEditFrqAcq.Size = new System.Drawing.Size(148, 22);
            this.dEditFrqAcq.TabIndex = 2;
            this.dEditFrqAcq.Value = 0.5D;
            this.dEditFrqAcq.EnterOn += new HPT1000.GUI.Cotrols.DoubleEdit.MakeOperation(this.dEditFrqAcq_EnterOn);
            // 
            // ArchivePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "ArchivePanel";
            this.Size = new System.Drawing.Size(1690, 790);
            this.Load += new System.EventHandler(this.ArchivePanel_Load);
            this.grBoxParameter.ResumeLayout(false);
            this.grBoxParameter.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.grBoxSeries.ResumeLayout(false);
            this.grBoxSeries.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grBoxParameter;
        private Cotrols.DoubleEdit dEditFrqAcq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labParaUnit;
        private Cotrols.DoubleEdit dEditDifferencesValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private Cotrols.DoubleEdit dEditAcqPressure;
        private System.Windows.Forms.Label labUnitPressure;
        private System.Windows.Forms.Label labPressure;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rBtnAcqDuringProcess;
        private System.Windows.Forms.RadioButton rBtnAcqAllTime;
        private System.Windows.Forms.CheckBox cBoxActivePressure;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TreeView treeViewDevices;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox cBoxParaActive;
        private System.Windows.Forms.Label label4;
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
