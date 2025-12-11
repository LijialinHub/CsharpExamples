namespace _2025_12_05_2_
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDisplayAll = new System.Windows.Forms.Button();
            this.btnDisplayTemperature = new System.Windows.Forms.Button();
            this.btnDisplayPressure = new System.Windows.Forms.Button();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.chartDisplay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nudAcqTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDisplay = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudSetTempUpperLimit = new System.Windows.Forms.NumericUpDown();
            this.nudSetTempLowerLimit = new System.Windows.Forms.NumericUpDown();
            this.nudSetPressureUpperLimit = new System.Windows.Forms.NumericUpDown();
            this.nudSetPressureLowerLimit = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaxTemp = new System.Windows.Forms.TextBox();
            this.txtMinTemp = new System.Windows.Forms.TextBox();
            this.txtMaxPressure = new System.Windows.Forms.TextBox();
            this.txtMinPressure = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAcqTime)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetTempUpperLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetTempLowerLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetPressureUpperLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetPressureLowerLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 700F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1828, 744);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.tableLayoutPanel2.Controls.Add(this.btnStart, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnDisplayAll, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnDisplayTemperature, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnDisplayPressure, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnScreenshot, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.chartDisplay, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.splitContainer1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(694, 738);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.btnStart.Location = new System.Drawing.Point(522, 187);
            this.btnStart.Margin = new System.Windows.Forms.Padding(20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(152, 74);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始采集";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDisplayAll
            // 
            this.btnDisplayAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisplayAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDisplayAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.btnDisplayAll.Location = new System.Drawing.Point(522, 301);
            this.btnDisplayAll.Margin = new System.Windows.Forms.Padding(20);
            this.btnDisplayAll.Name = "btnDisplayAll";
            this.btnDisplayAll.Size = new System.Drawing.Size(152, 74);
            this.btnDisplayAll.TabIndex = 1;
            this.btnDisplayAll.Text = "显示所有";
            this.btnDisplayAll.UseVisualStyleBackColor = false;
            this.btnDisplayAll.Click += new System.EventHandler(this.btnDisplayAll_Click);
            // 
            // btnDisplayTemperature
            // 
            this.btnDisplayTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisplayTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDisplayTemperature.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.btnDisplayTemperature.Location = new System.Drawing.Point(522, 415);
            this.btnDisplayTemperature.Margin = new System.Windows.Forms.Padding(20);
            this.btnDisplayTemperature.Name = "btnDisplayTemperature";
            this.btnDisplayTemperature.Size = new System.Drawing.Size(152, 74);
            this.btnDisplayTemperature.TabIndex = 1;
            this.btnDisplayTemperature.Text = "显示温度";
            this.btnDisplayTemperature.UseVisualStyleBackColor = false;
            this.btnDisplayTemperature.Click += new System.EventHandler(this.btnDisplayTemperature_Click);
            // 
            // btnDisplayPressure
            // 
            this.btnDisplayPressure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisplayPressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnDisplayPressure.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.btnDisplayPressure.Location = new System.Drawing.Point(522, 529);
            this.btnDisplayPressure.Margin = new System.Windows.Forms.Padding(20);
            this.btnDisplayPressure.Name = "btnDisplayPressure";
            this.btnDisplayPressure.Size = new System.Drawing.Size(152, 74);
            this.btnDisplayPressure.TabIndex = 1;
            this.btnDisplayPressure.Text = "显示压力";
            this.btnDisplayPressure.UseVisualStyleBackColor = false;
            this.btnDisplayPressure.Click += new System.EventHandler(this.btnDisplayPressure_Click);
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenshot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnScreenshot.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.btnScreenshot.Location = new System.Drawing.Point(522, 643);
            this.btnScreenshot.Margin = new System.Windows.Forms.Padding(20);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(152, 75);
            this.btnScreenshot.TabIndex = 1;
            this.btnScreenshot.Text = "截屏";
            this.btnScreenshot.UseVisualStyleBackColor = false;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // chartDisplay
            // 
            this.chartDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            chartArea1.Area3DStyle.Inclination = 20;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.Area3DStyle.WallWidth = 10;
            chartArea1.AxisX.ScaleView.Position = 0D;
            chartArea1.AxisX.ScaleView.Size = 5D;
            chartArea1.AxisX.ScrollBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            chartArea1.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea1.AxisX.ScrollBar.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            chartArea1.AxisX.ScrollBar.Size = 15D;
            chartArea1.AxisX.Title = "时间";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "温度(°C)";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY2.Interval = 100D;
            chartArea1.AxisY2.Maximum = 1000D;
            chartArea1.AxisY2.Minimum = 0D;
            chartArea1.AxisY2.Title = "压力值(Kpa)";
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea1";
            this.chartDisplay.ChartAreas.Add(chartArea1);
            this.chartDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            legend1.Title = "温度&压力";
            legend1.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.TitleSeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.chartDisplay.Legends.Add(legend1);
            this.chartDisplay.Location = new System.Drawing.Point(3, 3);
            this.chartDisplay.Name = "chartDisplay";
            this.tableLayoutPanel2.SetRowSpan(this.chartDisplay, 7);
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.IsValueShownAsLabel = true;
            series1.Label = "#VAL{N2}Kpa";
            series1.LabelToolTip = "#VALX";
            series1.Legend = "Legend1";
            series1.LegendText = "温度";
            series1.LegendToolTip = "最大值: #MAX{N2} °C\\n最小值: #MIN{N2} °C\\n";
            series1.MarkerColor = System.Drawing.Color.Red;
            series1.MarkerSize = 3;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "TempSeries";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.SystemColors.Highlight;
            series2.IsValueShownAsLabel = true;
            series2.Label = "#VAL{N2}Kpa";
            series2.Legend = "Legend1";
            series2.LegendText = "压力";
            series2.LegendToolTip = "最大值: #MAX{N2} Kpa\\n最小值: #MIN{N2} Kpa";
            series2.MarkerColor = System.Drawing.SystemColors.MenuHighlight;
            series2.MarkerSize = 3;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "PressureSeries";
            series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chartDisplay.Series.Add(series1);
            this.chartDisplay.Series.Add(series2);
            this.chartDisplay.Size = new System.Drawing.Size(496, 732);
            this.chartDisplay.TabIndex = 2;
            this.chartDisplay.Text = "chart1";
            title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            title1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.IsDockedInsideChartArea = false;
            title1.Name = "Title1";
            title1.Text = "温度压力实时曲线图";
            title1.ToolTip = "1号液罐实时压力曲线";
            this.chartDisplay.Titles.Add(title1);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(505, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 53);
            this.label1.TabIndex = 4;
            this.label1.Text = "采集时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(505, 56);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.nudAcqTime);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(186, 108);
            this.splitContainer1.SplitterDistance = 102;
            this.splitContainer1.TabIndex = 5;
            // 
            // nudAcqTime
            // 
            this.nudAcqTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAcqTime.Font = new System.Drawing.Font("宋体", 13F);
            this.nudAcqTime.Location = new System.Drawing.Point(5, 31);
            this.nudAcqTime.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.nudAcqTime.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudAcqTime.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudAcqTime.Name = "nudAcqTime";
            this.nudAcqTime.Size = new System.Drawing.Size(82, 37);
            this.nudAcqTime.TabIndex = 0;
            this.nudAcqTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudAcqTime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudAcqTime.ValueChanged += new System.EventHandler(this.nudAcqTime_ValueChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 13F);
            this.label2.Location = new System.Drawing.Point(-23, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 65);
            this.label2.TabIndex = 0;
            this.label2.Text = "ms";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dgvDisplay, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label6, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label7, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.nudSetTempUpperLimit, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.nudSetTempLowerLimit, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.nudSetPressureUpperLimit, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.nudSetPressureLowerLimit, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.label8, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.label9, 1, 10);
            this.tableLayoutPanel3.Controls.Add(this.label10, 1, 12);
            this.tableLayoutPanel3.Controls.Add(this.label11, 1, 14);
            this.tableLayoutPanel3.Controls.Add(this.txtMaxTemp, 1, 9);
            this.tableLayoutPanel3.Controls.Add(this.txtMinTemp, 1, 11);
            this.tableLayoutPanel3.Controls.Add(this.txtMaxPressure, 1, 13);
            this.tableLayoutPanel3.Controls.Add(this.txtMinPressure, 1, 15);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(703, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 16;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1122, 738);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(991, 46);
            this.label3.TabIndex = 0;
            this.label3.Text = "实时数据表";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDisplay
            // 
            this.dgvDisplay.AllowUserToAddRows = false;
            this.dgvDisplay.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDisplay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDisplay.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDisplay.Location = new System.Drawing.Point(3, 49);
            this.dgvDisplay.MultiSelect = false;
            this.dgvDisplay.Name = "dgvDisplay";
            this.dgvDisplay.ReadOnly = true;
            this.dgvDisplay.RowHeadersVisible = false;
            this.dgvDisplay.RowHeadersWidth = 62;
            this.tableLayoutPanel3.SetRowSpan(this.dgvDisplay, 15);
            this.dgvDisplay.RowTemplate.Height = 30;
            this.dgvDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisplay.Size = new System.Drawing.Size(991, 686);
            this.dgvDisplay.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "编号";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Width = 165;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CurrentTime";
            this.Column2.HeaderText = "当前时间";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 165;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Temperature";
            this.Column3.HeaderText = "温度值";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 165;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Pressure";
            this.Column4.HeaderText = "压力值";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 165;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TempAlarm";
            this.Column5.HeaderText = "温度报警";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 165;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "PressureAlarm";
            this.Column6.HeaderText = "压力报警";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 165;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(1000, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 46);
            this.label4.TabIndex = 2;
            this.label4.Text = "温度上限";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(1000, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 46);
            this.label5.TabIndex = 2;
            this.label5.Text = "温度下限";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(1000, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 46);
            this.label6.TabIndex = 2;
            this.label6.Text = "压力上限";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(1000, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 46);
            this.label7.TabIndex = 2;
            this.label7.Text = "压力下限";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudSetTempUpperLimit
            // 
            this.nudSetTempUpperLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSetTempUpperLimit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudSetTempUpperLimit.Location = new System.Drawing.Point(1000, 49);
            this.nudSetTempUpperLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSetTempUpperLimit.Name = "nudSetTempUpperLimit";
            this.nudSetTempUpperLimit.Size = new System.Drawing.Size(119, 31);
            this.nudSetTempUpperLimit.TabIndex = 3;
            this.nudSetTempUpperLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSetTempUpperLimit.ValueChanged += new System.EventHandler(this.nudSetTempUpperLimit_ValueChanged);
            // 
            // nudSetTempLowerLimit
            // 
            this.nudSetTempLowerLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSetTempLowerLimit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudSetTempLowerLimit.Location = new System.Drawing.Point(1000, 141);
            this.nudSetTempLowerLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSetTempLowerLimit.Name = "nudSetTempLowerLimit";
            this.nudSetTempLowerLimit.Size = new System.Drawing.Size(119, 31);
            this.nudSetTempLowerLimit.TabIndex = 3;
            this.nudSetTempLowerLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSetTempLowerLimit.ValueChanged += new System.EventHandler(this.nudSetTempLowerLimit_ValueChanged);
            // 
            // nudSetPressureUpperLimit
            // 
            this.nudSetPressureUpperLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSetPressureUpperLimit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudSetPressureUpperLimit.Location = new System.Drawing.Point(1000, 233);
            this.nudSetPressureUpperLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSetPressureUpperLimit.Name = "nudSetPressureUpperLimit";
            this.nudSetPressureUpperLimit.Size = new System.Drawing.Size(119, 31);
            this.nudSetPressureUpperLimit.TabIndex = 3;
            this.nudSetPressureUpperLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSetPressureUpperLimit.ValueChanged += new System.EventHandler(this.nudSetPressureUpperLimit_ValueChanged);
            // 
            // nudSetPressureLowerLimit
            // 
            this.nudSetPressureLowerLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSetPressureLowerLimit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudSetPressureLowerLimit.Location = new System.Drawing.Point(1000, 325);
            this.nudSetPressureLowerLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSetPressureLowerLimit.Name = "nudSetPressureLowerLimit";
            this.nudSetPressureLowerLimit.Size = new System.Drawing.Size(119, 31);
            this.nudSetPressureLowerLimit.TabIndex = 3;
            this.nudSetPressureLowerLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSetPressureLowerLimit.ValueChanged += new System.EventHandler(this.nudSetPressureLowerLimit_ValueChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(1000, 368);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 46);
            this.label8.TabIndex = 2;
            this.label8.Text = "当前最高温度";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(1000, 460);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 46);
            this.label9.TabIndex = 2;
            this.label9.Text = "当前最低温度";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(1000, 552);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 46);
            this.label10.TabIndex = 2;
            this.label10.Text = "当前最高压力";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(1000, 644);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 46);
            this.label11.TabIndex = 2;
            this.label11.Text = "当前最低压力";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaxTemp
            // 
            this.txtMaxTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxTemp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMaxTemp.Location = new System.Drawing.Point(1000, 417);
            this.txtMaxTemp.Name = "txtMaxTemp";
            this.txtMaxTemp.ReadOnly = true;
            this.txtMaxTemp.Size = new System.Drawing.Size(119, 31);
            this.txtMaxTemp.TabIndex = 4;
            this.txtMaxTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtMaxTemp, "双击跳到实时数据表的指定行");
            this.txtMaxTemp.DoubleClick += new System.EventHandler(this.txtGetMinMax_DoubleClick);
            // 
            // txtMinTemp
            // 
            this.txtMinTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinTemp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMinTemp.Location = new System.Drawing.Point(1000, 509);
            this.txtMinTemp.Name = "txtMinTemp";
            this.txtMinTemp.ReadOnly = true;
            this.txtMinTemp.Size = new System.Drawing.Size(119, 31);
            this.txtMinTemp.TabIndex = 4;
            this.txtMinTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtMinTemp, "双击跳到实时数据表的指定行");
            this.txtMinTemp.DoubleClick += new System.EventHandler(this.txtGetMinMax_DoubleClick);
            // 
            // txtMaxPressure
            // 
            this.txtMaxPressure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxPressure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMaxPressure.Location = new System.Drawing.Point(1000, 601);
            this.txtMaxPressure.Name = "txtMaxPressure";
            this.txtMaxPressure.ReadOnly = true;
            this.txtMaxPressure.Size = new System.Drawing.Size(119, 31);
            this.txtMaxPressure.TabIndex = 4;
            this.txtMaxPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtMaxPressure, "双击跳到实时数据表的指定行");
            this.txtMaxPressure.DoubleClick += new System.EventHandler(this.txtGetMinMax_DoubleClick);
            // 
            // txtMinPressure
            // 
            this.txtMinPressure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinPressure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMinPressure.Location = new System.Drawing.Point(1000, 693);
            this.txtMinPressure.Name = "txtMinPressure";
            this.txtMinPressure.ReadOnly = true;
            this.txtMinPressure.Size = new System.Drawing.Size(119, 31);
            this.txtMinPressure.TabIndex = 4;
            this.txtMinPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtMinPressure, "双击跳到实时数据表的指定行");
            this.txtMinPressure.DoubleClick += new System.EventHandler(this.txtGetMinMax_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1828, 744);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDisplay)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudAcqTime)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetTempUpperLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetTempLowerLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetPressureUpperLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetPressureLowerLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDisplayAll;
        private System.Windows.Forms.Button btnDisplayTemperature;
        private System.Windows.Forms.Button btnDisplayPressure;
        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown nudAcqTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDisplay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudSetTempUpperLimit;
        private System.Windows.Forms.NumericUpDown nudSetTempLowerLimit;
        private System.Windows.Forms.NumericUpDown nudSetPressureUpperLimit;
        private System.Windows.Forms.NumericUpDown nudSetPressureLowerLimit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMaxTemp;
        private System.Windows.Forms.TextBox txtMinTemp;
        private System.Windows.Forms.TextBox txtMaxPressure;
        private System.Windows.Forms.TextBox txtMinPressure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

