namespace _2025_12_17_4_
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
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSync = new System.Windows.Forms.Button();
            this.buttonASync = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChangeColor = new System.Windows.Forms.Button();
            this.txt1t100 = new System.Windows.Forms.TextBox();
            this.txt100t1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(99, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "打印1到100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(558, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "打印1到100";
            // 
            // buttonSync
            // 
            this.buttonSync.Location = new System.Drawing.Point(137, 381);
            this.buttonSync.Name = "buttonSync";
            this.buttonSync.Size = new System.Drawing.Size(169, 84);
            this.buttonSync.TabIndex = 2;
            this.buttonSync.Text = "同步方法(先1t100 再100t1)";
            this.buttonSync.UseVisualStyleBackColor = true;
            this.buttonSync.Click += new System.EventHandler(this.buttonSync_Click);
            // 
            // buttonASync
            // 
            this.buttonASync.Location = new System.Drawing.Point(628, 381);
            this.buttonASync.Name = "buttonASync";
            this.buttonASync.Size = new System.Drawing.Size(169, 84);
            this.buttonASync.TabIndex = 2;
            this.buttonASync.Text = "异步方法(先1t100 再100t1)";
            this.buttonASync.UseVisualStyleBackColor = true;
            this.buttonASync.Click += new System.EventHandler(this.buttonASync_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(117, 477);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 65);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Location = new System.Drawing.Point(529, 477);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(171, 71);
            this.btnChangeColor.TabIndex = 4;
            this.btnChangeColor.Text = "点击变色";
            this.btnChangeColor.UseVisualStyleBackColor = true;
            this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // txt1t100
            // 
            this.txt1t100.Location = new System.Drawing.Point(104, 68);
            this.txt1t100.Multiline = true;
            this.txt1t100.Name = "txt1t100";
            this.txt1t100.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt1t100.Size = new System.Drawing.Size(281, 275);
            this.txt1t100.TabIndex = 5;
            // 
            // txt100t1
            // 
            this.txt100t1.Location = new System.Drawing.Point(563, 68);
            this.txt100t1.Multiline = true;
            this.txt100t1.Name = "txt100t1";
            this.txt100t1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt100t1.Size = new System.Drawing.Size(281, 275);
            this.txt100t1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 560);
            this.Controls.Add(this.txt100t1);
            this.Controls.Add(this.txt1t100);
            this.Controls.Add(this.btnChangeColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonASync);
            this.Controls.Add(this.buttonSync);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSync;
        private System.Windows.Forms.Button buttonASync;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChangeColor;
        private System.Windows.Forms.TextBox txt1t100;
        private System.Windows.Forms.TextBox txt100t1;
    }
}

