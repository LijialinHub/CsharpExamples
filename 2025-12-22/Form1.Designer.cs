namespace _2025_12_22
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartListen = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtLocalIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtConnectState = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClearMsg = new System.Windows.Forms.Button();
            this.txtReceiceMsg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.cmbDstIP_Port = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSendAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnStartListen);
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.txtLocalIP);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 144);
            this.panel1.TabIndex = 0;
            // 
            // btnStartListen
            // 
            this.btnStartListen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnStartListen.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.btnStartListen.Location = new System.Drawing.Point(493, 42);
            this.btnStartListen.Name = "btnStartListen";
            this.btnStartListen.Size = new System.Drawing.Size(174, 70);
            this.btnStartListen.TabIndex = 3;
            this.btnStartListen.Text = "开始监听";
            this.btnStartListen.UseVisualStyleBackColor = false;
            this.btnStartListen.Click += new System.EventHandler(this.btnStartListen_Click);
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.txtPort.Location = new System.Drawing.Point(309, 84);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(159, 39);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "9999";
            // 
            // txtLocalIP
            // 
            this.txtLocalIP.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.txtLocalIP.Location = new System.Drawing.Point(72, 84);
            this.txtLocalIP.Name = "txtLocalIP";
            this.txtLocalIP.Size = new System.Drawing.Size(218, 39);
            this.txtLocalIP.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(325, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(117, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "本机IP";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.txtConnectState);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 144);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(818, 135);
            this.panel2.TabIndex = 1;
            // 
            // txtConnectState
            // 
            this.txtConnectState.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.txtConnectState.Location = new System.Drawing.Point(191, 6);
            this.txtConnectState.Multiline = true;
            this.txtConnectState.Name = "txtConnectState";
            this.txtConnectState.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConnectState.Size = new System.Drawing.Size(495, 107);
            this.txtConnectState.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(67, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "连接状态";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.btnClearMsg);
            this.panel3.Controls.Add(this.txtReceiceMsg);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 279);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(818, 212);
            this.panel3.TabIndex = 2;
            // 
            // btnClearMsg
            // 
            this.btnClearMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClearMsg.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.btnClearMsg.Location = new System.Drawing.Point(708, 63);
            this.btnClearMsg.Name = "btnClearMsg";
            this.btnClearMsg.Size = new System.Drawing.Size(80, 97);
            this.btnClearMsg.TabIndex = 6;
            this.btnClearMsg.Text = "清除显示";
            this.btnClearMsg.UseVisualStyleBackColor = false;
            this.btnClearMsg.Click += new System.EventHandler(this.btnClearMsg_Click);
            // 
            // txtReceiceMsg
            // 
            this.txtReceiceMsg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.txtReceiceMsg.Location = new System.Drawing.Point(191, 53);
            this.txtReceiceMsg.Multiline = true;
            this.txtReceiceMsg.Name = "txtReceiceMsg";
            this.txtReceiceMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceiceMsg.Size = new System.Drawing.Size(495, 107);
            this.txtReceiceMsg.TabIndex = 5;
            this.txtReceiceMsg.TextChanged += new System.EventHandler(this.txtReceiceMsg_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(67, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 28);
            this.label4.TabIndex = 4;
            this.label4.Text = "接收信息";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.txtSendMsg);
            this.panel4.Controls.Add(this.btnSend);
            this.panel4.Controls.Add(this.cmbDstIP_Port);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.btnSendAll);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 491);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(818, 205);
            this.panel4.TabIndex = 3;
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.txtSendMsg.Location = new System.Drawing.Point(150, 96);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendMsg.Size = new System.Drawing.Size(495, 107);
            this.txtSendMsg.TabIndex = 11;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSend.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.btnSend.Location = new System.Drawing.Point(506, 13);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(96, 77);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cmbDstIP_Port
            // 
            this.cmbDstIP_Port.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDstIP_Port.FormattingEnabled = true;
            this.cmbDstIP_Port.Location = new System.Drawing.Point(323, 58);
            this.cmbDstIP_Port.Name = "cmbDstIP_Port";
            this.cmbDstIP_Port.Size = new System.Drawing.Size(154, 32);
            this.cmbDstIP_Port.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(145, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "目标IP和端口号";
            // 
            // btnSendAll
            // 
            this.btnSendAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSendAll.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.btnSendAll.Location = new System.Drawing.Point(297, 7);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(80, 40);
            this.btnSendAll.TabIndex = 7;
            this.btnSendAll.Text = "群发";
            this.btnSendAll.UseVisualStyleBackColor = false;
            this.btnSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(145, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 28);
            this.label5.TabIndex = 5;
            this.label5.Text = "发送信息";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 700);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtLocalIP;
        private System.Windows.Forms.Button btnStartListen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConnectState;
        private System.Windows.Forms.Button btnClearMsg;
        private System.Windows.Forms.TextBox txtReceiceMsg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSendAll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDstIP_Port;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSendMsg;
    }
}

