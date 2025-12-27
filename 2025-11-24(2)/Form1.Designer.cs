namespace _2025_11_24_2_
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
            this.btnReadSource = new System.Windows.Forms.Button();
            this.txtDisplayRource = new System.Windows.Forms.TextBox();
            this.btnDisplayCoord = new System.Windows.Forms.Button();
            this.txtDisplayXY = new System.Windows.Forms.TextBox();
            this.btnDisplayX = new System.Windows.Forms.Button();
            this.txtDisplayX_Y = new System.Windows.Forms.TextBox();
            this.btnDisplayY = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReadSource
            // 
            this.btnReadSource.Font = new System.Drawing.Font("宋体", 13F);
            this.btnReadSource.Location = new System.Drawing.Point(40, 38);
            this.btnReadSource.Name = "btnReadSource";
            this.btnReadSource.Size = new System.Drawing.Size(276, 62);
            this.btnReadSource.TabIndex = 0;
            this.btnReadSource.Text = "加载G代码";
            this.btnReadSource.UseVisualStyleBackColor = true;
            this.btnReadSource.Click += new System.EventHandler(this.btnReadSource_Click);
            // 
            // txtDisplayRource
            // 
            this.txtDisplayRource.Location = new System.Drawing.Point(40, 106);
            this.txtDisplayRource.Multiline = true;
            this.txtDisplayRource.Name = "txtDisplayRource";
            this.txtDisplayRource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDisplayRource.Size = new System.Drawing.Size(276, 509);
            this.txtDisplayRource.TabIndex = 1;
            this.txtDisplayRource.TextChanged += new System.EventHandler(this.txtDisplayRource_TextChanged);
            // 
            // btnDisplayCoord
            // 
            this.btnDisplayCoord.Font = new System.Drawing.Font("宋体", 13F);
            this.btnDisplayCoord.Location = new System.Drawing.Point(335, 38);
            this.btnDisplayCoord.Name = "btnDisplayCoord";
            this.btnDisplayCoord.Size = new System.Drawing.Size(276, 62);
            this.btnDisplayCoord.TabIndex = 0;
            this.btnDisplayCoord.Text = "显示XY的加工坐标";
            this.btnDisplayCoord.UseVisualStyleBackColor = true;
            this.btnDisplayCoord.Click += new System.EventHandler(this.btnDisplayCoord_Click);
            // 
            // txtDisplayXY
            // 
            this.txtDisplayXY.Font = new System.Drawing.Font("宋体", 13F);
            this.txtDisplayXY.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDisplayXY.Location = new System.Drawing.Point(335, 106);
            this.txtDisplayXY.Multiline = true;
            this.txtDisplayXY.Name = "txtDisplayXY";
            this.txtDisplayXY.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDisplayXY.Size = new System.Drawing.Size(276, 509);
            this.txtDisplayXY.TabIndex = 1;
            // 
            // btnDisplayX
            // 
            this.btnDisplayX.Font = new System.Drawing.Font("宋体", 13F);
            this.btnDisplayX.Location = new System.Drawing.Point(646, 38);
            this.btnDisplayX.Name = "btnDisplayX";
            this.btnDisplayX.Size = new System.Drawing.Size(135, 62);
            this.btnDisplayX.TabIndex = 0;
            this.btnDisplayX.Text = "X轴坐标";
            this.btnDisplayX.UseVisualStyleBackColor = true;
            this.btnDisplayX.Click += new System.EventHandler(this.btnDisplayX_Click);
            // 
            // txtDisplayX_Y
            // 
            this.txtDisplayX_Y.Font = new System.Drawing.Font("宋体", 13F);
            this.txtDisplayX_Y.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDisplayX_Y.Location = new System.Drawing.Point(646, 106);
            this.txtDisplayX_Y.Multiline = true;
            this.txtDisplayX_Y.Name = "txtDisplayX_Y";
            this.txtDisplayX_Y.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDisplayX_Y.Size = new System.Drawing.Size(276, 509);
            this.txtDisplayX_Y.TabIndex = 1;
            // 
            // btnDisplayY
            // 
            this.btnDisplayY.Font = new System.Drawing.Font("宋体", 13F);
            this.btnDisplayY.Location = new System.Drawing.Point(787, 38);
            this.btnDisplayY.Name = "btnDisplayY";
            this.btnDisplayY.Size = new System.Drawing.Size(135, 62);
            this.btnDisplayY.TabIndex = 0;
            this.btnDisplayY.Text = "Y轴坐标";
            this.btnDisplayY.UseVisualStyleBackColor = true;
            this.btnDisplayY.Click += new System.EventHandler(this.btnDisplayY_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1026, 643);
            this.Controls.Add(this.txtDisplayX_Y);
            this.Controls.Add(this.btnDisplayY);
            this.Controls.Add(this.btnDisplayX);
            this.Controls.Add(this.btnDisplayCoord);
            this.Controls.Add(this.txtDisplayRource);
            this.Controls.Add(this.btnReadSource);
            this.Controls.Add(this.txtDisplayXY);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadSource;
        private System.Windows.Forms.TextBox txtDisplayRource;
        private System.Windows.Forms.Button btnDisplayCoord;
        private System.Windows.Forms.TextBox txtDisplayXY;
        private System.Windows.Forms.Button btnDisplayX;
        private System.Windows.Forms.TextBox txtDisplayX_Y;
        private System.Windows.Forms.Button btnDisplayY;
    }
}

