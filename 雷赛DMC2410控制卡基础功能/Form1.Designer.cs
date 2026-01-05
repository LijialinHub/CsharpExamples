namespace 雷赛DMC2410控制卡基础功能
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRunAbsolute = new System.Windows.Forms.Button();
            this.btnRunRelatively = new System.Windows.Forms.Button();
            this.txtRelativePosition = new System.Windows.Forms.TextBox();
            this.txtAbsolutePosition = new System.Windows.Forms.TextBox();
            this.nudRunSpeed = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radZAxis = new System.Windows.Forms.RadioButton();
            this.radYAxis = new System.Windows.Forms.RadioButton();
            this.radXAxis = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslXAxis = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslYAxis = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslZAxis = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkIsMicro = new System.Windows.Forms.CheckBox();
            this.btnYAxisForward = new System.Windows.Forms.Button();
            this.btnXAxisRightMove = new System.Windows.Forms.Button();
            this.btnXAxisLeftMove = new System.Windows.Forms.Button();
            this.btnZAxisDown = new System.Windows.Forms.Button();
            this.btnZAxisUp = new System.Windows.Forms.Button();
            this.btnYAxisRetreat = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.nudJogSpeed = new System.Windows.Forms.NumericUpDown();
            this.cmbMicroDistance = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkZAxis = new System.Windows.Forms.CheckBox();
            this.chkYAxis = new System.Windows.Forms.CheckBox();
            this.chkXAxis = new System.Windows.Forms.CheckBox();
            this.btnGoHome = new System.Windows.Forms.Button();
            this.radGoHomeMode3 = new System.Windows.Forms.RadioButton();
            this.radGoHomeMode2 = new System.Windows.Forms.RadioButton();
            this.radGoHomeMode0 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.panelDisplayAxisStatus = new System.Windows.Forms.Panel();
            this.lblAlrm2 = new System.Windows.Forms.Label();
            this.lblAlrm1 = new System.Windows.Forms.Label();
            this.lblAlrm0 = new System.Windows.Forms.Label();
            this.lblNL2 = new System.Windows.Forms.Label();
            this.lblNL1 = new System.Windows.Forms.Label();
            this.lblNL0 = new System.Windows.Forms.Label();
            this.lblPL2 = new System.Windows.Forms.Label();
            this.lblORG2 = new System.Windows.Forms.Label();
            this.lblPL1 = new System.Windows.Forms.Label();
            this.lblORG1 = new System.Windows.Forms.Label();
            this.lblRun2 = new System.Windows.Forms.Label();
            this.lblPL0 = new System.Windows.Forms.Label();
            this.lblRun1 = new System.Windows.Forms.Label();
            this.lblORG0 = new System.Windows.Forms.Label();
            this.lblRun0 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRunSpeed)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudJogSpeed)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panelDisplayAxisStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.btnRunAbsolute);
            this.groupBox1.Controls.Add(this.btnRunRelatively);
            this.groupBox1.Controls.Add(this.txtRelativePosition);
            this.groupBox1.Controls.Add(this.txtAbsolutePosition);
            this.groupBox1.Controls.Add(this.nudRunSpeed);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radZAxis);
            this.groupBox1.Controls.Add(this.radYAxis);
            this.groupBox1.Controls.Add(this.radXAxis);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单轴位置控制";
            // 
            // btnRunAbsolute
            // 
            this.btnRunAbsolute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRunAbsolute.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRunAbsolute.Location = new System.Drawing.Point(292, 185);
            this.btnRunAbsolute.Name = "btnRunAbsolute";
            this.btnRunAbsolute.Size = new System.Drawing.Size(101, 45);
            this.btnRunAbsolute.TabIndex = 5;
            this.btnRunAbsolute.Text = "运行";
            this.btnRunAbsolute.UseVisualStyleBackColor = false;
            this.btnRunAbsolute.Click += new System.EventHandler(this.btnRunAbsolute_Click);
            // 
            // btnRunRelatively
            // 
            this.btnRunRelatively.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRunRelatively.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRunRelatively.Location = new System.Drawing.Point(292, 133);
            this.btnRunRelatively.Name = "btnRunRelatively";
            this.btnRunRelatively.Size = new System.Drawing.Size(101, 45);
            this.btnRunRelatively.TabIndex = 5;
            this.btnRunRelatively.Text = "运行";
            this.btnRunRelatively.UseVisualStyleBackColor = false;
            this.btnRunRelatively.Click += new System.EventHandler(this.btnRunRelatively_Click);
            // 
            // txtRelativePosition
            // 
            this.txtRelativePosition.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRelativePosition.Location = new System.Drawing.Point(115, 181);
            this.txtRelativePosition.Name = "txtRelativePosition";
            this.txtRelativePosition.Size = new System.Drawing.Size(82, 31);
            this.txtRelativePosition.TabIndex = 4;
            // 
            // txtAbsolutePosition
            // 
            this.txtAbsolutePosition.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAbsolutePosition.Location = new System.Drawing.Point(115, 147);
            this.txtAbsolutePosition.Name = "txtAbsolutePosition";
            this.txtAbsolutePosition.Size = new System.Drawing.Size(82, 31);
            this.txtAbsolutePosition.TabIndex = 4;
            // 
            // nudRunSpeed
            // 
            this.nudRunSpeed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudRunSpeed.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRunSpeed.Location = new System.Drawing.Point(115, 105);
            this.nudRunSpeed.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudRunSpeed.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRunSpeed.Name = "nudRunSpeed";
            this.nudRunSpeed.Size = new System.Drawing.Size(82, 31);
            this.nudRunSpeed.TabIndex = 3;
            this.nudRunSpeed.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(204, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "pulse";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(204, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "pulse";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(9, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "相对位置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(9, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "绝对位置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(204, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "pulse/s";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "运行速度";
            // 
            // radZAxis
            // 
            this.radZAxis.AutoSize = true;
            this.radZAxis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radZAxis.Location = new System.Drawing.Point(251, 44);
            this.radZAxis.Name = "radZAxis";
            this.radZAxis.Size = new System.Drawing.Size(69, 25);
            this.radZAxis.TabIndex = 0;
            this.radZAxis.Text = "Z轴";
            this.radZAxis.UseVisualStyleBackColor = true;
            // 
            // radYAxis
            // 
            this.radYAxis.AutoSize = true;
            this.radYAxis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radYAxis.Location = new System.Drawing.Point(150, 44);
            this.radYAxis.Name = "radYAxis";
            this.radYAxis.Size = new System.Drawing.Size(69, 25);
            this.radYAxis.TabIndex = 0;
            this.radYAxis.Text = "Y轴";
            this.radYAxis.UseVisualStyleBackColor = true;
            // 
            // radXAxis
            // 
            this.radXAxis.AutoSize = true;
            this.radXAxis.Checked = true;
            this.radXAxis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radXAxis.Location = new System.Drawing.Point(49, 44);
            this.radXAxis.Name = "radXAxis";
            this.radXAxis.Size = new System.Drawing.Size(69, 25);
            this.radXAxis.TabIndex = 0;
            this.radXAxis.TabStop = true;
            this.radXAxis.Text = "X轴";
            this.radXAxis.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslXAxis,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.tsslYAxis,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7,
            this.tsslZAxis});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1501, 35);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 28);
            this.toolStripStatusLabel1.Text = "X轴:";
            // 
            // tsslXAxis
            // 
            this.tsslXAxis.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsslXAxis.ForeColor = System.Drawing.Color.Red;
            this.tsslXAxis.Name = "tsslXAxis";
            this.tsslXAxis.Size = new System.Drawing.Size(52, 28);
            this.tsslXAxis.Text = "****";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(170, 28);
            this.toolStripStatusLabel3.Text = "                                ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(43, 28);
            this.toolStripStatusLabel4.Text = "Y轴:";
            // 
            // tsslYAxis
            // 
            this.tsslYAxis.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.tsslYAxis.ForeColor = System.Drawing.Color.Red;
            this.tsslYAxis.Name = "tsslYAxis";
            this.tsslYAxis.Size = new System.Drawing.Size(52, 28);
            this.tsslYAxis.Text = "****";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(170, 28);
            this.toolStripStatusLabel6.Text = "                                ";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(43, 28);
            this.toolStripStatusLabel7.Text = "Z轴:";
            // 
            // tsslZAxis
            // 
            this.tsslZAxis.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.tsslZAxis.ForeColor = System.Drawing.Color.Red;
            this.tsslZAxis.Name = "tsslZAxis";
            this.tsslZAxis.Size = new System.Drawing.Size(52, 28);
            this.tsslZAxis.Text = "****";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.chkIsMicro);
            this.groupBox2.Controls.Add(this.btnYAxisForward);
            this.groupBox2.Controls.Add(this.btnXAxisRightMove);
            this.groupBox2.Controls.Add(this.btnXAxisLeftMove);
            this.groupBox2.Controls.Add(this.btnZAxisDown);
            this.groupBox2.Controls.Add(this.btnZAxisUp);
            this.groupBox2.Controls.Add(this.btnYAxisRetreat);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.nudJogSpeed);
            this.groupBox2.Controls.Add(this.cmbMicroDistance);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(3, 254);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 336);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "jog运动";
            // 
            // chkIsMicro
            // 
            this.chkIsMicro.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIsMicro.BackColor = System.Drawing.Color.White;
            this.chkIsMicro.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chkIsMicro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsMicro.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkIsMicro.Location = new System.Drawing.Point(110, 181);
            this.chkIsMicro.Name = "chkIsMicro";
            this.chkIsMicro.Size = new System.Drawing.Size(104, 54);
            this.chkIsMicro.TabIndex = 7;
            this.chkIsMicro.Text = "Jog";
            this.chkIsMicro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIsMicro.UseVisualStyleBackColor = false;
            this.chkIsMicro.CheckedChanged += new System.EventHandler(this.chkIsMicro_CheckedChanged);
            // 
            // btnYAxisForward
            // 
            this.btnYAxisForward.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYAxisForward.Location = new System.Drawing.Point(115, 254);
            this.btnYAxisForward.Name = "btnYAxisForward";
            this.btnYAxisForward.Size = new System.Drawing.Size(92, 46);
            this.btnYAxisForward.TabIndex = 6;
            this.btnYAxisForward.Text = "Y轴前进";
            this.btnYAxisForward.UseVisualStyleBackColor = true;
            this.btnYAxisForward.Click += new System.EventHandler(this.btnMicroMove_Click);
            this.btnYAxisForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJog_MouseDown_Click);
            this.btnYAxisForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJog_MouseUp_Click);
            // 
            // btnXAxisRightMove
            // 
            this.btnXAxisRightMove.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnXAxisRightMove.Location = new System.Drawing.Point(219, 185);
            this.btnXAxisRightMove.Name = "btnXAxisRightMove";
            this.btnXAxisRightMove.Size = new System.Drawing.Size(92, 46);
            this.btnXAxisRightMove.TabIndex = 6;
            this.btnXAxisRightMove.Text = "X轴右移";
            this.btnXAxisRightMove.UseVisualStyleBackColor = true;
            this.btnXAxisRightMove.Click += new System.EventHandler(this.btnMicroMove_Click);
            this.btnXAxisRightMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJog_MouseDown_Click);
            this.btnXAxisRightMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJog_MouseUp_Click);
            // 
            // btnXAxisLeftMove
            // 
            this.btnXAxisLeftMove.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnXAxisLeftMove.Location = new System.Drawing.Point(12, 185);
            this.btnXAxisLeftMove.Name = "btnXAxisLeftMove";
            this.btnXAxisLeftMove.Size = new System.Drawing.Size(92, 46);
            this.btnXAxisLeftMove.TabIndex = 6;
            this.btnXAxisLeftMove.Text = "X轴左移";
            this.btnXAxisLeftMove.UseVisualStyleBackColor = true;
            this.btnXAxisLeftMove.Click += new System.EventHandler(this.btnMicroMove_Click);
            this.btnXAxisLeftMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJog_MouseDown_Click);
            this.btnXAxisLeftMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJog_MouseUp_Click);
            // 
            // btnZAxisDown
            // 
            this.btnZAxisDown.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnZAxisDown.Location = new System.Drawing.Point(320, 254);
            this.btnZAxisDown.Name = "btnZAxisDown";
            this.btnZAxisDown.Size = new System.Drawing.Size(92, 46);
            this.btnZAxisDown.TabIndex = 6;
            this.btnZAxisDown.Text = "Z轴下降";
            this.btnZAxisDown.UseVisualStyleBackColor = true;
            this.btnZAxisDown.Click += new System.EventHandler(this.btnMicroMove_Click);
            this.btnZAxisDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJog_MouseDown_Click);
            this.btnZAxisDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJog_MouseUp_Click);
            // 
            // btnZAxisUp
            // 
            this.btnZAxisUp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnZAxisUp.Location = new System.Drawing.Point(320, 117);
            this.btnZAxisUp.Name = "btnZAxisUp";
            this.btnZAxisUp.Size = new System.Drawing.Size(92, 46);
            this.btnZAxisUp.TabIndex = 6;
            this.btnZAxisUp.Text = "Z轴上升";
            this.btnZAxisUp.UseVisualStyleBackColor = true;
            this.btnZAxisUp.Click += new System.EventHandler(this.btnMicroMove_Click);
            this.btnZAxisUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJog_MouseDown_Click);
            this.btnZAxisUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJog_MouseUp_Click);
            // 
            // btnYAxisRetreat
            // 
            this.btnYAxisRetreat.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYAxisRetreat.Location = new System.Drawing.Point(118, 117);
            this.btnYAxisRetreat.Name = "btnYAxisRetreat";
            this.btnYAxisRetreat.Size = new System.Drawing.Size(92, 46);
            this.btnYAxisRetreat.TabIndex = 6;
            this.btnYAxisRetreat.Text = "Y轴后退";
            this.btnYAxisRetreat.UseVisualStyleBackColor = true;
            this.btnYAxisRetreat.Click += new System.EventHandler(this.btnMicroMove_Click);
            this.btnYAxisRetreat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJog_MouseDown_Click);
            this.btnYAxisRetreat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJog_MouseUp_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(353, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 18);
            this.label10.TabIndex = 5;
            this.label10.Text = "pulse/s";
            // 
            // nudJogSpeed
            // 
            this.nudJogSpeed.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudJogSpeed.Location = new System.Drawing.Point(267, 54);
            this.nudJogSpeed.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudJogSpeed.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudJogSpeed.Name = "nudJogSpeed";
            this.nudJogSpeed.Size = new System.Drawing.Size(82, 28);
            this.nudJogSpeed.TabIndex = 4;
            this.nudJogSpeed.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // cmbMicroDistance
            // 
            this.cmbMicroDistance.FormattingEnabled = true;
            this.cmbMicroDistance.Items.AddRange(new object[] {
            "10",
            "50",
            "200"});
            this.cmbMicroDistance.Location = new System.Drawing.Point(96, 53);
            this.cmbMicroDistance.Name = "cmbMicroDistance";
            this.cmbMicroDistance.Size = new System.Drawing.Size(90, 26);
            this.cmbMicroDistance.TabIndex = 3;
            this.cmbMicroDistance.Text = "200";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(289, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "运行速度";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(192, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "pulse";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(9, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "微动距离";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox3.Controls.Add(this.chkZAxis);
            this.groupBox3.Controls.Add(this.chkYAxis);
            this.groupBox3.Controls.Add(this.chkXAxis);
            this.groupBox3.Controls.Add(this.btnGoHome);
            this.groupBox3.Controls.Add(this.radGoHomeMode3);
            this.groupBox3.Controls.Add(this.radGoHomeMode2);
            this.groupBox3.Controls.Add(this.radGoHomeMode0);
            this.groupBox3.Location = new System.Drawing.Point(440, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(431, 246);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "回原点控制";
            // 
            // chkZAxis
            // 
            this.chkZAxis.AutoSize = true;
            this.chkZAxis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkZAxis.Location = new System.Drawing.Point(250, 43);
            this.chkZAxis.Name = "chkZAxis";
            this.chkZAxis.Size = new System.Drawing.Size(70, 25);
            this.chkZAxis.TabIndex = 6;
            this.chkZAxis.Text = "Z轴";
            this.chkZAxis.UseVisualStyleBackColor = true;
            // 
            // chkYAxis
            // 
            this.chkYAxis.AutoSize = true;
            this.chkYAxis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkYAxis.Location = new System.Drawing.Point(161, 43);
            this.chkYAxis.Name = "chkYAxis";
            this.chkYAxis.Size = new System.Drawing.Size(70, 25);
            this.chkYAxis.TabIndex = 6;
            this.chkYAxis.Text = "Y轴";
            this.chkYAxis.UseVisualStyleBackColor = true;
            // 
            // chkXAxis
            // 
            this.chkXAxis.AutoSize = true;
            this.chkXAxis.Checked = true;
            this.chkXAxis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXAxis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkXAxis.Location = new System.Drawing.Point(54, 43);
            this.chkXAxis.Name = "chkXAxis";
            this.chkXAxis.Size = new System.Drawing.Size(70, 25);
            this.chkXAxis.TabIndex = 6;
            this.chkXAxis.Text = "X轴";
            this.chkXAxis.UseVisualStyleBackColor = true;
            // 
            // btnGoHome
            // 
            this.btnGoHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGoHome.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGoHome.Location = new System.Drawing.Point(269, 111);
            this.btnGoHome.Name = "btnGoHome";
            this.btnGoHome.Size = new System.Drawing.Size(101, 116);
            this.btnGoHome.TabIndex = 5;
            this.btnGoHome.Text = "执行原点回归";
            this.btnGoHome.UseVisualStyleBackColor = false;
            // 
            // radGoHomeMode3
            // 
            this.radGoHomeMode3.AutoSize = true;
            this.radGoHomeMode3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radGoHomeMode3.Location = new System.Drawing.Point(54, 193);
            this.radGoHomeMode3.Name = "radGoHomeMode3";
            this.radGoHomeMode3.Size = new System.Drawing.Size(178, 40);
            this.radGoHomeMode3.TabIndex = 0;
            this.radGoHomeMode3.Text = "3：二次回零\r\n   (有搜索功能)";
            this.radGoHomeMode3.UseVisualStyleBackColor = true;
            // 
            // radGoHomeMode2
            // 
            this.radGoHomeMode2.AutoSize = true;
            this.radGoHomeMode2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radGoHomeMode2.Location = new System.Drawing.Point(54, 141);
            this.radGoHomeMode2.Name = "radGoHomeMode2";
            this.radGoHomeMode2.Size = new System.Drawing.Size(196, 40);
            this.radGoHomeMode2.TabIndex = 0;
            this.radGoHomeMode2.Text = "2: 一次回零加回找\r\n  (有搜索功能)";
            this.radGoHomeMode2.UseVisualStyleBackColor = true;
            // 
            // radGoHomeMode0
            // 
            this.radGoHomeMode0.AutoSize = true;
            this.radGoHomeMode0.Checked = true;
            this.radGoHomeMode0.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radGoHomeMode0.Location = new System.Drawing.Point(54, 91);
            this.radGoHomeMode0.Name = "radGoHomeMode0";
            this.radGoHomeMode0.Size = new System.Drawing.Size(141, 22);
            this.radGoHomeMode0.TabIndex = 0;
            this.radGoHomeMode0.TabStop = true;
            this.radGoHomeMode0.Text = "0: 只计home";
            this.radGoHomeMode0.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.panelDisplayAxisStatus);
            this.groupBox4.Location = new System.Drawing.Point(877, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(623, 246);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "回原点控制";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(6, 200);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(44, 21);
            this.label33.TabIndex = 3;
            this.label33.Text = "Z轴";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(6, 141);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(44, 21);
            this.label32.TabIndex = 3;
            this.label32.Text = "Y轴";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(6, 91);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(44, 21);
            this.label31.TabIndex = 3;
            this.label31.Text = "X轴";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(520, 24);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(54, 21);
            this.label30.TabIndex = 3;
            this.label30.Text = "报警";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(413, 24);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(54, 21);
            this.label29.TabIndex = 3;
            this.label29.Text = "负限";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(304, 24);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(54, 21);
            this.label28.TabIndex = 3;
            this.label28.Text = "正限";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(209, 24);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 21);
            this.label27.TabIndex = 3;
            this.label27.Text = "原点";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(75, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(98, 21);
            this.label26.TabIndex = 3;
            this.label26.Text = "运行状态";
            // 
            // panelDisplayAxisStatus
            // 
            this.panelDisplayAxisStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.panelDisplayAxisStatus.Controls.Add(this.lblAlrm2);
            this.panelDisplayAxisStatus.Controls.Add(this.lblAlrm1);
            this.panelDisplayAxisStatus.Controls.Add(this.lblAlrm0);
            this.panelDisplayAxisStatus.Controls.Add(this.lblNL2);
            this.panelDisplayAxisStatus.Controls.Add(this.lblNL1);
            this.panelDisplayAxisStatus.Controls.Add(this.lblNL0);
            this.panelDisplayAxisStatus.Controls.Add(this.lblPL2);
            this.panelDisplayAxisStatus.Controls.Add(this.lblORG2);
            this.panelDisplayAxisStatus.Controls.Add(this.lblPL1);
            this.panelDisplayAxisStatus.Controls.Add(this.lblORG1);
            this.panelDisplayAxisStatus.Controls.Add(this.lblRun2);
            this.panelDisplayAxisStatus.Controls.Add(this.lblPL0);
            this.panelDisplayAxisStatus.Controls.Add(this.lblRun1);
            this.panelDisplayAxisStatus.Controls.Add(this.lblORG0);
            this.panelDisplayAxisStatus.Controls.Add(this.lblRun0);
            this.panelDisplayAxisStatus.Location = new System.Drawing.Point(61, 55);
            this.panelDisplayAxisStatus.Name = "panelDisplayAxisStatus";
            this.panelDisplayAxisStatus.Size = new System.Drawing.Size(548, 185);
            this.panelDisplayAxisStatus.TabIndex = 0;
            // 
            // lblAlrm2
            // 
            this.lblAlrm2.BackColor = System.Drawing.Color.White;
            this.lblAlrm2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAlrm2.Location = new System.Drawing.Point(434, 132);
            this.lblAlrm2.Name = "lblAlrm2";
            this.lblAlrm2.Size = new System.Drawing.Size(94, 36);
            this.lblAlrm2.TabIndex = 0;
            // 
            // lblAlrm1
            // 
            this.lblAlrm1.BackColor = System.Drawing.Color.White;
            this.lblAlrm1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAlrm1.Location = new System.Drawing.Point(434, 78);
            this.lblAlrm1.Name = "lblAlrm1";
            this.lblAlrm1.Size = new System.Drawing.Size(94, 36);
            this.lblAlrm1.TabIndex = 0;
            // 
            // lblAlrm0
            // 
            this.lblAlrm0.BackColor = System.Drawing.Color.White;
            this.lblAlrm0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAlrm0.Location = new System.Drawing.Point(434, 22);
            this.lblAlrm0.Name = "lblAlrm0";
            this.lblAlrm0.Size = new System.Drawing.Size(94, 36);
            this.lblAlrm0.TabIndex = 0;
            // 
            // lblNL2
            // 
            this.lblNL2.BackColor = System.Drawing.Color.White;
            this.lblNL2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNL2.Location = new System.Drawing.Point(329, 132);
            this.lblNL2.Name = "lblNL2";
            this.lblNL2.Size = new System.Drawing.Size(94, 36);
            this.lblNL2.TabIndex = 0;
            // 
            // lblNL1
            // 
            this.lblNL1.BackColor = System.Drawing.Color.White;
            this.lblNL1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNL1.Location = new System.Drawing.Point(329, 78);
            this.lblNL1.Name = "lblNL1";
            this.lblNL1.Size = new System.Drawing.Size(94, 36);
            this.lblNL1.TabIndex = 0;
            // 
            // lblNL0
            // 
            this.lblNL0.BackColor = System.Drawing.Color.White;
            this.lblNL0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNL0.Location = new System.Drawing.Point(329, 22);
            this.lblNL0.Name = "lblNL0";
            this.lblNL0.Size = new System.Drawing.Size(94, 36);
            this.lblNL0.TabIndex = 0;
            // 
            // lblPL2
            // 
            this.lblPL2.BackColor = System.Drawing.Color.White;
            this.lblPL2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPL2.Location = new System.Drawing.Point(224, 132);
            this.lblPL2.Name = "lblPL2";
            this.lblPL2.Size = new System.Drawing.Size(94, 36);
            this.lblPL2.TabIndex = 0;
            // 
            // lblORG2
            // 
            this.lblORG2.BackColor = System.Drawing.Color.White;
            this.lblORG2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblORG2.Location = new System.Drawing.Point(119, 132);
            this.lblORG2.Name = "lblORG2";
            this.lblORG2.Size = new System.Drawing.Size(94, 36);
            this.lblORG2.TabIndex = 0;
            // 
            // lblPL1
            // 
            this.lblPL1.BackColor = System.Drawing.Color.White;
            this.lblPL1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPL1.Location = new System.Drawing.Point(224, 78);
            this.lblPL1.Name = "lblPL1";
            this.lblPL1.Size = new System.Drawing.Size(94, 36);
            this.lblPL1.TabIndex = 0;
            // 
            // lblORG1
            // 
            this.lblORG1.BackColor = System.Drawing.Color.White;
            this.lblORG1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblORG1.Location = new System.Drawing.Point(119, 78);
            this.lblORG1.Name = "lblORG1";
            this.lblORG1.Size = new System.Drawing.Size(94, 36);
            this.lblORG1.TabIndex = 0;
            // 
            // lblRun2
            // 
            this.lblRun2.BackColor = System.Drawing.Color.White;
            this.lblRun2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRun2.Location = new System.Drawing.Point(14, 132);
            this.lblRun2.Name = "lblRun2";
            this.lblRun2.Size = new System.Drawing.Size(94, 36);
            this.lblRun2.TabIndex = 0;
            // 
            // lblPL0
            // 
            this.lblPL0.BackColor = System.Drawing.Color.White;
            this.lblPL0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPL0.Location = new System.Drawing.Point(224, 22);
            this.lblPL0.Name = "lblPL0";
            this.lblPL0.Size = new System.Drawing.Size(94, 36);
            this.lblPL0.TabIndex = 0;
            // 
            // lblRun1
            // 
            this.lblRun1.BackColor = System.Drawing.Color.White;
            this.lblRun1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRun1.Location = new System.Drawing.Point(14, 78);
            this.lblRun1.Name = "lblRun1";
            this.lblRun1.Size = new System.Drawing.Size(94, 36);
            this.lblRun1.TabIndex = 0;
            // 
            // lblORG0
            // 
            this.lblORG0.BackColor = System.Drawing.Color.White;
            this.lblORG0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblORG0.Location = new System.Drawing.Point(119, 22);
            this.lblORG0.Name = "lblORG0";
            this.lblORG0.Size = new System.Drawing.Size(94, 36);
            this.lblORG0.TabIndex = 0;
            // 
            // lblRun0
            // 
            this.lblRun0.BackColor = System.Drawing.Color.White;
            this.lblRun0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRun0.Location = new System.Drawing.Point(14, 22);
            this.lblRun0.Name = "lblRun0";
            this.lblRun0.Size = new System.Drawing.Size(94, 36);
            this.lblRun0.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1501, 625);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.btnMicroMove_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRunSpeed)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudJogSpeed)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panelDisplayAxisStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radZAxis;
        private System.Windows.Forms.RadioButton radYAxis;
        private System.Windows.Forms.RadioButton radXAxis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRelativePosition;
        private System.Windows.Forms.TextBox txtAbsolutePosition;
        private System.Windows.Forms.NumericUpDown nudRunSpeed;
        private System.Windows.Forms.Button btnRunAbsolute;
        private System.Windows.Forms.Button btnRunRelatively;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslXAxis;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tsslYAxis;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel tsslZAxis;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbMicroDistance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudJogSpeed;
        private System.Windows.Forms.Button btnYAxisForward;
        private System.Windows.Forms.Button btnXAxisRightMove;
        private System.Windows.Forms.Button btnXAxisLeftMove;
        private System.Windows.Forms.Button btnYAxisRetreat;
        private System.Windows.Forms.CheckBox chkIsMicro;
        private System.Windows.Forms.Button btnZAxisDown;
        private System.Windows.Forms.Button btnZAxisUp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGoHome;
        private System.Windows.Forms.RadioButton radGoHomeMode3;
        private System.Windows.Forms.RadioButton radGoHomeMode2;
        private System.Windows.Forms.RadioButton radGoHomeMode0;
        private System.Windows.Forms.CheckBox chkZAxis;
        private System.Windows.Forms.CheckBox chkYAxis;
        private System.Windows.Forms.CheckBox chkXAxis;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panelDisplayAxisStatus;
        private System.Windows.Forms.Label lblRun0;
        private System.Windows.Forms.Label lblAlrm2;
        private System.Windows.Forms.Label lblAlrm1;
        private System.Windows.Forms.Label lblAlrm0;
        private System.Windows.Forms.Label lblNL2;
        private System.Windows.Forms.Label lblNL1;
        private System.Windows.Forms.Label lblNL0;
        private System.Windows.Forms.Label lblPL2;
        private System.Windows.Forms.Label lblORG2;
        private System.Windows.Forms.Label lblPL1;
        private System.Windows.Forms.Label lblORG1;
        private System.Windows.Forms.Label lblRun2;
        private System.Windows.Forms.Label lblPL0;
        private System.Windows.Forms.Label lblRun1;
        private System.Windows.Forms.Label lblORG0;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Timer timer1;
    }
}

