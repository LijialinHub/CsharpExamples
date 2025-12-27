namespace _2025_12_13
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDisplay1t100 = new System.Windows.Forms.TextBox();
            this.txtDisplay100t1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNotThread = new System.Windows.Forms.Button();
            this.btnOpenThread = new System.Windows.Forms.Button();
            this.btnAllExecute = new System.Windows.Forms.Button();
            this.btnRandColor = new System.Windows.Forms.Button();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.btnHasArgs = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDisplayRes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(75, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "从1到100";
            // 
            // txtDisplay1t100
            // 
            this.txtDisplay1t100.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtDisplay1t100.Location = new System.Drawing.Point(78, 93);
            this.txtDisplay1t100.Multiline = true;
            this.txtDisplay1t100.Name = "txtDisplay1t100";
            this.txtDisplay1t100.ReadOnly = true;
            this.txtDisplay1t100.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDisplay1t100.Size = new System.Drawing.Size(358, 265);
            this.txtDisplay1t100.TabIndex = 1;
            // 
            // txtDisplay100t1
            // 
            this.txtDisplay100t1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtDisplay100t1.Location = new System.Drawing.Point(501, 93);
            this.txtDisplay100t1.Multiline = true;
            this.txtDisplay100t1.Name = "txtDisplay100t1";
            this.txtDisplay100t1.ReadOnly = true;
            this.txtDisplay100t1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDisplay100t1.Size = new System.Drawing.Size(358, 265);
            this.txtDisplay100t1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(506, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "从100到1";
            // 
            // btnNotThread
            // 
            this.btnNotThread.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNotThread.Location = new System.Drawing.Point(79, 386);
            this.btnNotThread.Name = "btnNotThread";
            this.btnNotThread.Size = new System.Drawing.Size(160, 71);
            this.btnNotThread.TabIndex = 3;
            this.btnNotThread.Text = "不开线程执行从1到100";
            this.btnNotThread.UseVisualStyleBackColor = true;
            this.btnNotThread.Click += new System.EventHandler(this.btnNotThread_Click);
            // 
            // btnOpenThread
            // 
            this.btnOpenThread.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenThread.Location = new System.Drawing.Point(282, 386);
            this.btnOpenThread.Name = "btnOpenThread";
            this.btnOpenThread.Size = new System.Drawing.Size(160, 71);
            this.btnOpenThread.TabIndex = 3;
            this.btnOpenThread.Text = "开线程执行从1到100";
            this.btnOpenThread.UseVisualStyleBackColor = true;
            this.btnOpenThread.Click += new System.EventHandler(this.btnOpenThread_Click);
            // 
            // btnAllExecute
            // 
            this.btnAllExecute.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllExecute.Location = new System.Drawing.Point(485, 386);
            this.btnAllExecute.Name = "btnAllExecute";
            this.btnAllExecute.Size = new System.Drawing.Size(160, 71);
            this.btnAllExecute.TabIndex = 3;
            this.btnAllExecute.Text = "同时执行两个任务";
            this.btnAllExecute.UseVisualStyleBackColor = true;
            this.btnAllExecute.Click += new System.EventHandler(this.btnAllExecute_Click);
            // 
            // btnRandColor
            // 
            this.btnRandColor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRandColor.Location = new System.Drawing.Point(688, 386);
            this.btnRandColor.Name = "btnRandColor";
            this.btnRandColor.Size = new System.Drawing.Size(160, 71);
            this.btnRandColor.TabIndex = 3;
            this.btnRandColor.Text = "随机变色";
            this.btnRandColor.UseVisualStyleBackColor = true;
            this.btnRandColor.Click += new System.EventHandler(this.btnRandColor_Click);
            // 
            // txtArgs
            // 
            this.txtArgs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtArgs.Location = new System.Drawing.Point(282, 498);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.Size = new System.Drawing.Size(160, 31);
            this.txtArgs.TabIndex = 4;
            this.txtArgs.Text = "100";
            // 
            // btnHasArgs
            // 
            this.btnHasArgs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnHasArgs.Location = new System.Drawing.Point(282, 535);
            this.btnHasArgs.Name = "btnHasArgs";
            this.btnHasArgs.Size = new System.Drawing.Size(160, 57);
            this.btnHasArgs.TabIndex = 5;
            this.btnHasArgs.Text = "带参执行线程";
            this.btnHasArgs.UseVisualStyleBackColor = true;
            this.btnHasArgs.Click += new System.EventHandler(this.btnHasArgs_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 479);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "结果";
            // 
            // txtDisplayRes
            // 
            this.txtDisplayRes.Location = new System.Drawing.Point(94, 500);
            this.txtDisplayRes.Multiline = true;
            this.txtDisplayRes.Name = "txtDisplayRes";
            this.txtDisplayRes.Size = new System.Drawing.Size(163, 92);
            this.txtDisplayRes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 477);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "参数";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 604);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDisplayRes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHasArgs);
            this.Controls.Add(this.txtArgs);
            this.Controls.Add(this.btnOpenThread);
            this.Controls.Add(this.btnRandColor);
            this.Controls.Add(this.btnAllExecute);
            this.Controls.Add(this.btnNotThread);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDisplay100t1);
            this.Controls.Add(this.txtDisplay1t100);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDisplay1t100;
        private System.Windows.Forms.TextBox txtDisplay100t1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNotThread;
        private System.Windows.Forms.Button btnOpenThread;
        private System.Windows.Forms.Button btnAllExecute;
        private System.Windows.Forms.Button btnRandColor;
        private System.Windows.Forms.TextBox txtArgs;
        private System.Windows.Forms.Button btnHasArgs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDisplayRes;
        private System.Windows.Forms.Label label4;
    }
}

