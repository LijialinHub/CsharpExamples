namespace _2025_12_08_2_
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lalState = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSecond = new System.Windows.Forms.NumericUpDown();
            this.nudMinute = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMinute = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(50, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(228, 61);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Location = new System.Drawing.Point(50, 184);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(228, 61);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lalState
            // 
            this.lalState.BackColor = System.Drawing.Color.Red;
            this.lalState.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.lalState.Location = new System.Drawing.Point(37, 71);
            this.lalState.Name = "lalState";
            this.lalState.Size = new System.Drawing.Size(197, 141);
            this.lalState.TabIndex = 1;
            this.lalState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lalState);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(368, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 259);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "电机状态";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nudSecond);
            this.groupBox2.Controls.Add(this.nudMinute);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(33, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 293);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置运行时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "秒";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "分";
            // 
            // nudSecond
            // 
            this.nudSecond.Location = new System.Drawing.Point(26, 180);
            this.nudSecond.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudSecond.Name = "nudSecond";
            this.nudSecond.Size = new System.Drawing.Size(120, 35);
            this.nudSecond.TabIndex = 1;
            this.nudSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudMinute
            // 
            this.nudMinute.Location = new System.Drawing.Point(26, 90);
            this.nudMinute.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMinute.Name = "nudMinute";
            this.nudMinute.Size = new System.Drawing.Size(120, 35);
            this.nudMinute.TabIndex = 0;
            this.nudMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblSecond);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblMinute);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblHours);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(368, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 293);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "已运行时间";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(147, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 48);
            this.label9.TabIndex = 0;
            this.label9.Text = "秒";
            // 
            // lblSecond
            // 
            this.lblSecond.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSecond.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblSecond.Location = new System.Drawing.Point(67, 180);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(60, 48);
            this.lblSecond.TabIndex = 0;
            this.lblSecond.Text = "0";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(147, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 48);
            this.label7.TabIndex = 0;
            this.label7.Text = "分钟";
            // 
            // lblMinute
            // 
            this.lblMinute.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMinute.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblMinute.Location = new System.Drawing.Point(67, 132);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(60, 48);
            this.lblMinute.TabIndex = 0;
            this.lblMinute.Text = "0";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(147, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 48);
            this.label5.TabIndex = 0;
            this.label5.Text = "小时";
            // 
            // lblHours
            // 
            this.lblHours.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHours.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblHours.Location = new System.Drawing.Point(67, 84);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(60, 48);
            this.lblHours.TabIndex = 0;
            this.lblHours.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(698, 618);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "练习";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lalState;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudSecond;
        private System.Windows.Forms.NumericUpDown nudMinute;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
    }
}

