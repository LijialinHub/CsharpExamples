namespace _2025_12_20
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
            this.mtxtServerPort = new System.Windows.Forms.MaskedTextBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtConnectionMsg = new System.Windows.Forms.TextBox();
            this.btnClearConnectionMsg = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtReceiveMsg = new System.Windows.Forms.TextBox();
            this.btnClearReceiveMsg = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.btnClearSendMsg = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.mtxtServerPort);
            this.panel1.Controls.Add(this.btnConnection);
            this.panel1.Controls.Add(this.txtServerIP);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 160);
            this.panel1.TabIndex = 0;
            // 
            // mtxtServerPort
            // 
            this.mtxtServerPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.mtxtServerPort.Location = new System.Drawing.Point(304, 88);
            this.mtxtServerPort.Mask = "00009";
            this.mtxtServerPort.Name = "mtxtServerPort";
            this.mtxtServerPort.PromptChar = ' ';
            this.mtxtServerPort.Size = new System.Drawing.Size(152, 35);
            this.mtxtServerPort.TabIndex = 3;
            // 
            // btnConnection
            // 
            this.btnConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnConnection.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnection.Location = new System.Drawing.Point(475, 64);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(118, 59);
            this.btnConnection.TabIndex = 2;
            this.btnConnection.Text = "连接";
            this.btnConnection.UseVisualStyleBackColor = false;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // txtServerIP
            // 
            this.txtServerIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtServerIP.Location = new System.Drawing.Point(88, 88);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(160, 35);
            this.txtServerIP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(284, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "服务器端口号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(146, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.txtConnectionMsg);
            this.panel2.Controls.Add(this.btnClearConnectionMsg);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(674, 211);
            this.panel2.TabIndex = 1;
            // 
            // txtConnectionMsg
            // 
            this.txtConnectionMsg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.txtConnectionMsg.Location = new System.Drawing.Point(88, 91);
            this.txtConnectionMsg.Multiline = true;
            this.txtConnectionMsg.Name = "txtConnectionMsg";
            this.txtConnectionMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConnectionMsg.Size = new System.Drawing.Size(506, 102);
            this.txtConnectionMsg.TabIndex = 3;
            // 
            // btnClearConnectionMsg
            // 
            this.btnClearConnectionMsg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearConnectionMsg.Location = new System.Drawing.Point(476, 21);
            this.btnClearConnectionMsg.Name = "btnClearConnectionMsg";
            this.btnClearConnectionMsg.Size = new System.Drawing.Size(118, 48);
            this.btnClearConnectionMsg.TabIndex = 2;
            this.btnClearConnectionMsg.Text = "清楚显示";
            this.btnClearConnectionMsg.UseVisualStyleBackColor = true;
            this.btnClearConnectionMsg.Click += new System.EventHandler(this.btnClearConnectionMsg_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(94, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "连接信息";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.txtReceiveMsg);
            this.panel3.Controls.Add(this.btnClearReceiveMsg);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 371);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(674, 202);
            this.panel3.TabIndex = 2;
            // 
            // txtReceiveMsg
            // 
            this.txtReceiveMsg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.txtReceiveMsg.Location = new System.Drawing.Point(80, 81);
            this.txtReceiveMsg.Multiline = true;
            this.txtReceiveMsg.Name = "txtReceiveMsg";
            this.txtReceiveMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceiveMsg.Size = new System.Drawing.Size(514, 102);
            this.txtReceiveMsg.TabIndex = 6;
            // 
            // btnClearReceiveMsg
            // 
            this.btnClearReceiveMsg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearReceiveMsg.Location = new System.Drawing.Point(476, 20);
            this.btnClearReceiveMsg.Name = "btnClearReceiveMsg";
            this.btnClearReceiveMsg.Size = new System.Drawing.Size(118, 48);
            this.btnClearReceiveMsg.TabIndex = 5;
            this.btnClearReceiveMsg.Text = "清楚显示";
            this.btnClearReceiveMsg.UseVisualStyleBackColor = true;
            this.btnClearReceiveMsg.Click += new System.EventHandler(this.btnClearReceiveMsg_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(86, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "接收信息";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.txtSendMsg);
            this.panel4.Controls.Add(this.btnSendMsg);
            this.panel4.Controls.Add(this.btnClearSendMsg);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 573);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(674, 191);
            this.panel4.TabIndex = 3;
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.txtSendMsg.Location = new System.Drawing.Point(79, 72);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendMsg.Size = new System.Drawing.Size(514, 102);
            this.txtSendMsg.TabIndex = 9;
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSendMsg.Location = new System.Drawing.Point(338, 11);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(118, 48);
            this.btnSendMsg.TabIndex = 8;
            this.btnSendMsg.Text = "发送信息";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // btnClearSendMsg
            // 
            this.btnClearSendMsg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearSendMsg.Location = new System.Drawing.Point(475, 11);
            this.btnClearSendMsg.Name = "btnClearSendMsg";
            this.btnClearSendMsg.Size = new System.Drawing.Size(118, 48);
            this.btnClearSendMsg.TabIndex = 8;
            this.btnClearSendMsg.Text = "清楚显示";
            this.btnClearSendMsg.UseVisualStyleBackColor = true;
            this.btnClearSendMsg.Click += new System.EventHandler(this.btnClearSendMsg_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(85, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "发送信息";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 762);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClearConnectionMsg;
        private System.Windows.Forms.TextBox txtConnectionMsg;
        private System.Windows.Forms.TextBox txtReceiveMsg;
        private System.Windows.Forms.Button btnClearReceiveMsg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.Button btnClearSendMsg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mtxtServerPort;
    }
}

