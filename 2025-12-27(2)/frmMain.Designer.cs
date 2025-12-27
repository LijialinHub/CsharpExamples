namespace 与FX5U系列PLC的MC通讯
{
    partial class frmMain
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect_DisConnect = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.btnReadDFloat = new System.Windows.Forms.Button();
            this.numReadDFloatValue = new System.Windows.Forms.NumericUpDown();
            this.numReadDFloatAdderss = new System.Windows.Forms.NumericUpDown();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btnReadD32 = new System.Windows.Forms.Button();
            this.nudReadD32Value = new System.Windows.Forms.NumericUpDown();
            this.nudReadD32Adderss = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.btnReadD16 = new System.Windows.Forms.Button();
            this.nudReadD16Value = new System.Windows.Forms.NumericUpDown();
            this.nudReadD16Adderss = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnWriteDFloat = new System.Windows.Forms.Button();
            this.numWriteDFloatValue = new System.Windows.Forms.NumericUpDown();
            this.numWriteDFloatAdderss = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnWriteD32 = new System.Windows.Forms.Button();
            this.nudWriteD32Value = new System.Windows.Forms.NumericUpDown();
            this.nudWriteD32Adderss = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnWriteD16 = new System.Windows.Forms.Button();
            this.nudWriteD16Value = new System.Windows.Forms.NumericUpDown();
            this.nudWriteD16Adderss = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.userLantern_Y = new HslCommunication.Controls.UserLantern();
            this.btnY_off = new System.Windows.Forms.Button();
            this.btnY_On = new System.Windows.Forms.Button();
            this.btnReadY = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.nudYAdderss = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.userLantern_M = new HslCommunication.Controls.UserLantern();
            this.btnM_off = new System.Windows.Forms.Button();
            this.btnM_On = new System.Windows.Forms.Button();
            this.btnReadM = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.nudMAdderss = new System.Windows.Forms.NumericUpDown();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReadDFloatValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReadDFloatAdderss)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReadD32Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReadD32Adderss)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReadD16Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReadD16Adderss)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWriteDFloatValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWriteDFloatAdderss)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWriteD32Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWriteD32Adderss)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWriteD16Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWriteD16Adderss)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYAdderss)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMAdderss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1116, 834);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect_DisConnect);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(552, 826);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网络设置";
            // 
            // btnConnect_DisConnect
            // 
            this.btnConnect_DisConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnConnect_DisConnect.Location = new System.Drawing.Point(27, 500);
            this.btnConnect_DisConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConnect_DisConnect.Name = "btnConnect_DisConnect";
            this.btnConnect_DisConnect.Size = new System.Drawing.Size(360, 71);
            this.btnConnect_DisConnect.TabIndex = 4;
            this.btnConnect_DisConnect.Text = "连接";
            this.btnConnect_DisConnect.UseVisualStyleBackColor = false;
            this.btnConnect_DisConnect.Click += new System.EventHandler(this.btnConnect_DisConnect_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(165, 58);
            this.txtIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(221, 39);
            this.txtIP.TabIndex = 3;
            this.txtIP.Text = "192.168.0.11";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(165, 134);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(221, 39);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "6000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "端口号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP地址";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(546, 786);
            this.label1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(561, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(552, 826);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox3.Controls.Add(this.panel6);
            this.groupBox3.Controls.Add(this.panel5);
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(3, 279);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(546, 267);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "读取D区";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.btnReadDFloat);
            this.panel6.Controls.Add(this.numReadDFloatValue);
            this.panel6.Controls.Add(this.numReadDFloatAdderss);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(332, 36);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(211, 227);
            this.panel6.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(9, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "D";
            // 
            // btnReadDFloat
            // 
            this.btnReadDFloat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReadDFloat.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadDFloat.Location = new System.Drawing.Point(104, 6);
            this.btnReadDFloat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReadDFloat.Name = "btnReadDFloat";
            this.btnReadDFloat.Size = new System.Drawing.Size(35, 119);
            this.btnReadDFloat.TabIndex = 21;
            this.btnReadDFloat.Text = "32位浮点数读取";
            this.btnReadDFloat.UseVisualStyleBackColor = false;
            this.btnReadDFloat.Click += new System.EventHandler(this.btnReadDFloat_Click);
            // 
            // numReadDFloatValue
            // 
            this.numReadDFloatValue.DecimalPlaces = 1;
            this.numReadDFloatValue.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numReadDFloatValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numReadDFloatValue.Location = new System.Drawing.Point(6, 82);
            this.numReadDFloatValue.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.numReadDFloatValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numReadDFloatValue.Name = "numReadDFloatValue";
            this.numReadDFloatValue.Size = new System.Drawing.Size(91, 25);
            this.numReadDFloatValue.TabIndex = 20;
            // 
            // numReadDFloatAdderss
            // 
            this.numReadDFloatAdderss.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numReadDFloatAdderss.Location = new System.Drawing.Point(6, 24);
            this.numReadDFloatAdderss.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.numReadDFloatAdderss.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numReadDFloatAdderss.Name = "numReadDFloatAdderss";
            this.numReadDFloatAdderss.Size = new System.Drawing.Size(91, 25);
            this.numReadDFloatAdderss.TabIndex = 19;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.btnReadD32);
            this.panel5.Controls.Add(this.nudReadD32Value);
            this.panel5.Controls.Add(this.nudReadD32Adderss);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(173, 36);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(159, 227);
            this.panel5.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(7, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "D";
            // 
            // btnReadD32
            // 
            this.btnReadD32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReadD32.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadD32.Location = new System.Drawing.Point(101, 6);
            this.btnReadD32.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReadD32.Name = "btnReadD32";
            this.btnReadD32.Size = new System.Drawing.Size(35, 119);
            this.btnReadD32.TabIndex = 21;
            this.btnReadD32.Text = "32位整数读取";
            this.btnReadD32.UseVisualStyleBackColor = false;
            this.btnReadD32.Click += new System.EventHandler(this.btnReadD32_Click);
            // 
            // nudReadD32Value
            // 
            this.nudReadD32Value.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudReadD32Value.Location = new System.Drawing.Point(3, 82);
            this.nudReadD32Value.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.nudReadD32Value.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudReadD32Value.Name = "nudReadD32Value";
            this.nudReadD32Value.Size = new System.Drawing.Size(91, 25);
            this.nudReadD32Value.TabIndex = 20;
            // 
            // nudReadD32Adderss
            // 
            this.nudReadD32Adderss.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudReadD32Adderss.Location = new System.Drawing.Point(3, 24);
            this.nudReadD32Adderss.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.nudReadD32Adderss.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudReadD32Adderss.Name = "nudReadD32Adderss";
            this.nudReadD32Adderss.Size = new System.Drawing.Size(91, 25);
            this.nudReadD32Adderss.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.btnReadD16);
            this.panel4.Controls.Add(this.nudReadD16Value);
            this.panel4.Controls.Add(this.nudReadD16Adderss);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(3, 36);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(170, 227);
            this.panel4.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(10, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 16);
            this.label12.TabIndex = 18;
            this.label12.Text = "D";
            // 
            // btnReadD16
            // 
            this.btnReadD16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReadD16.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadD16.Location = new System.Drawing.Point(105, 6);
            this.btnReadD16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReadD16.Name = "btnReadD16";
            this.btnReadD16.Size = new System.Drawing.Size(35, 119);
            this.btnReadD16.TabIndex = 17;
            this.btnReadD16.Text = "16位整数读取";
            this.btnReadD16.UseVisualStyleBackColor = false;
            this.btnReadD16.Click += new System.EventHandler(this.btnReadD16_Click);
            // 
            // nudReadD16Value
            // 
            this.nudReadD16Value.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudReadD16Value.Location = new System.Drawing.Point(7, 82);
            this.nudReadD16Value.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.nudReadD16Value.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudReadD16Value.Name = "nudReadD16Value";
            this.nudReadD16Value.Size = new System.Drawing.Size(91, 25);
            this.nudReadD16Value.TabIndex = 16;
            // 
            // nudReadD16Adderss
            // 
            this.nudReadD16Adderss.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudReadD16Adderss.Location = new System.Drawing.Point(7, 24);
            this.nudReadD16Adderss.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.nudReadD16Adderss.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudReadD16Adderss.Name = "nudReadD16Adderss";
            this.nudReadD16Adderss.Size = new System.Drawing.Size(91, 25);
            this.nudReadD16Adderss.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(3, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(546, 267);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "M";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btnWriteDFloat);
            this.panel3.Controls.Add(this.numWriteDFloatValue);
            this.panel3.Controls.Add(this.numWriteDFloatAdderss);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(332, 36);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(211, 227);
            this.panel3.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(9, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "D";
            // 
            // btnWriteDFloat
            // 
            this.btnWriteDFloat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnWriteDFloat.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWriteDFloat.Location = new System.Drawing.Point(104, 6);
            this.btnWriteDFloat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWriteDFloat.Name = "btnWriteDFloat";
            this.btnWriteDFloat.Size = new System.Drawing.Size(35, 119);
            this.btnWriteDFloat.TabIndex = 17;
            this.btnWriteDFloat.Text = "32位浮点数写入";
            this.btnWriteDFloat.UseVisualStyleBackColor = false;
            this.btnWriteDFloat.Click += new System.EventHandler(this.btnWriteDFloat_Click);
            // 
            // numWriteDFloatValue
            // 
            this.numWriteDFloatValue.DecimalPlaces = 1;
            this.numWriteDFloatValue.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numWriteDFloatValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numWriteDFloatValue.Location = new System.Drawing.Point(6, 82);
            this.numWriteDFloatValue.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.numWriteDFloatValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWriteDFloatValue.Name = "numWriteDFloatValue";
            this.numWriteDFloatValue.Size = new System.Drawing.Size(91, 25);
            this.numWriteDFloatValue.TabIndex = 16;
            // 
            // numWriteDFloatAdderss
            // 
            this.numWriteDFloatAdderss.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numWriteDFloatAdderss.Location = new System.Drawing.Point(6, 24);
            this.numWriteDFloatAdderss.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.numWriteDFloatAdderss.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numWriteDFloatAdderss.Name = "numWriteDFloatAdderss";
            this.numWriteDFloatAdderss.Size = new System.Drawing.Size(91, 25);
            this.numWriteDFloatAdderss.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnWriteD32);
            this.panel2.Controls.Add(this.nudWriteD32Value);
            this.panel2.Controls.Add(this.nudWriteD32Adderss);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(173, 36);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(159, 227);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(7, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "D";
            // 
            // btnWriteD32
            // 
            this.btnWriteD32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnWriteD32.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWriteD32.Location = new System.Drawing.Point(101, 6);
            this.btnWriteD32.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWriteD32.Name = "btnWriteD32";
            this.btnWriteD32.Size = new System.Drawing.Size(35, 119);
            this.btnWriteD32.TabIndex = 17;
            this.btnWriteD32.Text = "32位整数写入";
            this.btnWriteD32.UseVisualStyleBackColor = false;
            this.btnWriteD32.Click += new System.EventHandler(this.btnWriteD32_Click);
            // 
            // nudWriteD32Value
            // 
            this.nudWriteD32Value.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudWriteD32Value.Location = new System.Drawing.Point(3, 82);
            this.nudWriteD32Value.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.nudWriteD32Value.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWriteD32Value.Name = "nudWriteD32Value";
            this.nudWriteD32Value.Size = new System.Drawing.Size(91, 25);
            this.nudWriteD32Value.TabIndex = 16;
            // 
            // nudWriteD32Adderss
            // 
            this.nudWriteD32Adderss.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudWriteD32Adderss.Location = new System.Drawing.Point(3, 24);
            this.nudWriteD32Adderss.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.nudWriteD32Adderss.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudWriteD32Adderss.Name = "nudWriteD32Adderss";
            this.nudWriteD32Adderss.Size = new System.Drawing.Size(91, 25);
            this.nudWriteD32Adderss.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnWriteD16);
            this.panel1.Controls.Add(this.nudWriteD16Value);
            this.panel1.Controls.Add(this.nudWriteD16Adderss);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 36);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 227);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(10, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "D";
            // 
            // btnWriteD16
            // 
            this.btnWriteD16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnWriteD16.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWriteD16.Location = new System.Drawing.Point(105, 4);
            this.btnWriteD16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWriteD16.Name = "btnWriteD16";
            this.btnWriteD16.Size = new System.Drawing.Size(35, 119);
            this.btnWriteD16.TabIndex = 13;
            this.btnWriteD16.Text = "16位整数写入";
            this.btnWriteD16.UseVisualStyleBackColor = false;
            this.btnWriteD16.Click += new System.EventHandler(this.btnWriteD16_Click);
            // 
            // nudWriteD16Value
            // 
            this.nudWriteD16Value.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudWriteD16Value.Location = new System.Drawing.Point(7, 79);
            this.nudWriteD16Value.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.nudWriteD16Value.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWriteD16Value.Name = "nudWriteD16Value";
            this.nudWriteD16Value.Size = new System.Drawing.Size(91, 25);
            this.nudWriteD16Value.TabIndex = 12;
            // 
            // nudWriteD16Adderss
            // 
            this.nudWriteD16Adderss.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudWriteD16Adderss.Location = new System.Drawing.Point(7, 22);
            this.nudWriteD16Adderss.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.nudWriteD16Adderss.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudWriteD16Adderss.Name = "nudWriteD16Adderss";
            this.nudWriteD16Adderss.Size = new System.Drawing.Size(91, 25);
            this.nudWriteD16Adderss.TabIndex = 11;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 554);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(546, 268);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.userLantern_Y);
            this.groupBox5.Controls.Add(this.btnY_off);
            this.groupBox5.Controls.Add(this.btnY_On);
            this.groupBox5.Controls.Add(this.btnReadY);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.nudYAdderss);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(276, 4);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(267, 260);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "读写Y区(8进制地址0~7 10~17)";
            // 
            // userLantern_Y
            // 
            this.userLantern_Y.BackColor = System.Drawing.Color.Transparent;
            this.userLantern_Y.LanternBackground = System.Drawing.Color.Silver;
            this.userLantern_Y.Location = new System.Drawing.Point(128, 98);
            this.userLantern_Y.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userLantern_Y.Name = "userLantern_Y";
            this.userLantern_Y.Size = new System.Drawing.Size(101, 108);
            this.userLantern_Y.TabIndex = 25;
            // 
            // btnY_off
            // 
            this.btnY_off.BackColor = System.Drawing.Color.Silver;
            this.btnY_off.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnY_off.Location = new System.Drawing.Point(11, 175);
            this.btnY_off.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnY_off.Name = "btnY_off";
            this.btnY_off.Size = new System.Drawing.Size(105, 29);
            this.btnY_off.TabIndex = 24;
            this.btnY_off.Text = "断开";
            this.btnY_off.UseVisualStyleBackColor = false;
            this.btnY_off.Click += new System.EventHandler(this.btnY_off_Click);
            // 
            // btnY_On
            // 
            this.btnY_On.BackColor = System.Drawing.Color.Silver;
            this.btnY_On.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnY_On.Location = new System.Drawing.Point(11, 98);
            this.btnY_On.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnY_On.Name = "btnY_On";
            this.btnY_On.Size = new System.Drawing.Size(105, 29);
            this.btnY_On.TabIndex = 22;
            this.btnY_On.Text = "接通";
            this.btnY_On.UseVisualStyleBackColor = false;
            this.btnY_On.Click += new System.EventHandler(this.btnY_On_Click);
            // 
            // btnReadY
            // 
            this.btnReadY.BackColor = System.Drawing.Color.Silver;
            this.btnReadY.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadY.Location = new System.Drawing.Point(128, 40);
            this.btnReadY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReadY.Name = "btnReadY";
            this.btnReadY.Size = new System.Drawing.Size(105, 29);
            this.btnReadY.TabIndex = 23;
            this.btnReadY.Text = "读取";
            this.btnReadY.UseVisualStyleBackColor = false;
            this.btnReadY.Click += new System.EventHandler(this.btnReadY_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(15, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 16);
            this.label14.TabIndex = 21;
            this.label14.Text = "Y";
            // 
            // nudYAdderss
            // 
            this.nudYAdderss.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudYAdderss.Location = new System.Drawing.Point(11, 40);
            this.nudYAdderss.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.nudYAdderss.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudYAdderss.Name = "nudYAdderss";
            this.nudYAdderss.Size = new System.Drawing.Size(105, 25);
            this.nudYAdderss.TabIndex = 20;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.userLantern_M);
            this.groupBox4.Controls.Add(this.btnM_off);
            this.groupBox4.Controls.Add(this.btnM_On);
            this.groupBox4.Controls.Add(this.btnReadM);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.nudMAdderss);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(3, 4);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(267, 260);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "读写M区(10进制地址)";
            // 
            // userLantern_M
            // 
            this.userLantern_M.BackColor = System.Drawing.Color.Transparent;
            this.userLantern_M.LanternBackground = System.Drawing.Color.Silver;
            this.userLantern_M.Location = new System.Drawing.Point(129, 98);
            this.userLantern_M.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userLantern_M.Name = "userLantern_M";
            this.userLantern_M.Size = new System.Drawing.Size(101, 108);
            this.userLantern_M.TabIndex = 20;
            // 
            // btnM_off
            // 
            this.btnM_off.BackColor = System.Drawing.Color.Silver;
            this.btnM_off.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnM_off.Location = new System.Drawing.Point(7, 175);
            this.btnM_off.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnM_off.Name = "btnM_off";
            this.btnM_off.Size = new System.Drawing.Size(106, 29);
            this.btnM_off.TabIndex = 18;
            this.btnM_off.Text = "断开";
            this.btnM_off.UseVisualStyleBackColor = false;
            this.btnM_off.Click += new System.EventHandler(this.btnM_off_Click);
            // 
            // btnM_On
            // 
            this.btnM_On.BackColor = System.Drawing.Color.Silver;
            this.btnM_On.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnM_On.Location = new System.Drawing.Point(7, 98);
            this.btnM_On.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnM_On.Name = "btnM_On";
            this.btnM_On.Size = new System.Drawing.Size(106, 29);
            this.btnM_On.TabIndex = 17;
            this.btnM_On.Text = "接通";
            this.btnM_On.UseVisualStyleBackColor = false;
            this.btnM_On.Click += new System.EventHandler(this.btnM_On_Click);
            // 
            // btnReadM
            // 
            this.btnReadM.BackColor = System.Drawing.Color.Silver;
            this.btnReadM.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadM.Location = new System.Drawing.Point(130, 40);
            this.btnReadM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReadM.Name = "btnReadM";
            this.btnReadM.Size = new System.Drawing.Size(106, 29);
            this.btnReadM.TabIndex = 17;
            this.btnReadM.Text = "读取";
            this.btnReadM.UseVisualStyleBackColor = false;
            this.btnReadM.Click += new System.EventHandler(this.btnReadM_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(10, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "M";
            // 
            // nudMAdderss
            // 
            this.nudMAdderss.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudMAdderss.Location = new System.Drawing.Point(7, 40);
            this.nudMAdderss.Margin = new System.Windows.Forms.Padding(11, 36, 11, 12);
            this.nudMAdderss.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMAdderss.Name = "nudMAdderss";
            this.nudMAdderss.Size = new System.Drawing.Size(106, 25);
            this.nudMAdderss.TabIndex = 15;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 834);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "与FX5U系列PLC的MC通讯";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReadDFloatValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReadDFloatAdderss)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReadD32Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReadD32Adderss)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReadD16Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReadD16Adderss)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWriteDFloatValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWriteDFloatAdderss)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWriteD32Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWriteD32Adderss)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWriteD16Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWriteD16Adderss)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYAdderss)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMAdderss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnect_DisConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnWriteDFloat;
        private System.Windows.Forms.NumericUpDown numWriteDFloatValue;
        private System.Windows.Forms.NumericUpDown numWriteDFloatAdderss;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnWriteD32;
        private System.Windows.Forms.NumericUpDown nudWriteD32Value;
        private System.Windows.Forms.NumericUpDown nudWriteD32Adderss;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnWriteD16;
        private System.Windows.Forms.NumericUpDown nudWriteD16Value;
        private System.Windows.Forms.NumericUpDown nudWriteD16Adderss;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnReadDFloat;
        private System.Windows.Forms.NumericUpDown numReadDFloatValue;
        private System.Windows.Forms.NumericUpDown numReadDFloatAdderss;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnReadD32;
        private System.Windows.Forms.NumericUpDown nudReadD32Value;
        private System.Windows.Forms.NumericUpDown nudReadD32Adderss;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnReadD16;
        private System.Windows.Forms.NumericUpDown nudReadD16Value;
        private System.Windows.Forms.NumericUpDown nudReadD16Adderss;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnM_off;
        private System.Windows.Forms.Button btnM_On;
        private System.Windows.Forms.Button btnReadM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudMAdderss;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnY_off;
        private System.Windows.Forms.Button btnY_On;
        private System.Windows.Forms.Button btnReadY;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudYAdderss;
        private HslCommunication.Controls.UserLantern userLantern_M;
        private HslCommunication.Controls.UserLantern userLantern_Y;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

