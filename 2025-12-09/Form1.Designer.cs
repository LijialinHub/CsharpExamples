namespace _2025_12_09
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
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.btnDrawLine = new System.Windows.Forms.Button();
            this.btnDrawRectangle = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnDrawTriangle = new System.Windows.Forms.Button();
            this.btnDrawString = new System.Windows.Forms.Button();
            this.btnFillEllipse = new System.Windows.Forms.Button();
            this.btnFillPolygon = new System.Windows.Forms.Button();
            this.btnFillRectangle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.BackColor = System.Drawing.SystemColors.Desktop;
            this.picDisplay.Dock = System.Windows.Forms.DockStyle.Left;
            this.picDisplay.Location = new System.Drawing.Point(0, 0);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(708, 692);
            this.picDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            // 
            // btnDrawLine
            // 
            this.btnDrawLine.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDrawLine.Location = new System.Drawing.Point(742, 27);
            this.btnDrawLine.Name = "btnDrawLine";
            this.btnDrawLine.Size = new System.Drawing.Size(149, 54);
            this.btnDrawLine.TabIndex = 1;
            this.btnDrawLine.Text = "绘制直线";
            this.btnDrawLine.UseVisualStyleBackColor = true;
            this.btnDrawLine.Click += new System.EventHandler(this.btnDrawLine_Click);
            // 
            // btnDrawRectangle
            // 
            this.btnDrawRectangle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDrawRectangle.Location = new System.Drawing.Point(742, 110);
            this.btnDrawRectangle.Name = "btnDrawRectangle";
            this.btnDrawRectangle.Size = new System.Drawing.Size(149, 54);
            this.btnDrawRectangle.TabIndex = 1;
            this.btnDrawRectangle.Text = "绘制矩形";
            this.btnDrawRectangle.UseVisualStyleBackColor = true;
            this.btnDrawRectangle.Click += new System.EventHandler(this.btnDrawRectangle_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCircle.Location = new System.Drawing.Point(742, 193);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(149, 54);
            this.btnCircle.TabIndex = 1;
            this.btnCircle.Text = "绘制圆";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnDrawTriangle
            // 
            this.btnDrawTriangle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDrawTriangle.Location = new System.Drawing.Point(742, 276);
            this.btnDrawTriangle.Name = "btnDrawTriangle";
            this.btnDrawTriangle.Size = new System.Drawing.Size(149, 54);
            this.btnDrawTriangle.TabIndex = 1;
            this.btnDrawTriangle.Text = "绘制三角形";
            this.btnDrawTriangle.UseVisualStyleBackColor = true;
            this.btnDrawTriangle.Click += new System.EventHandler(this.btnDrawTriangle_Click);
            // 
            // btnDrawString
            // 
            this.btnDrawString.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDrawString.Location = new System.Drawing.Point(742, 359);
            this.btnDrawString.Name = "btnDrawString";
            this.btnDrawString.Size = new System.Drawing.Size(149, 54);
            this.btnDrawString.TabIndex = 1;
            this.btnDrawString.Text = "绘制字符串";
            this.btnDrawString.UseVisualStyleBackColor = true;
            this.btnDrawString.Click += new System.EventHandler(this.btnDrawString_Click);
            // 
            // btnFillEllipse
            // 
            this.btnFillEllipse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFillEllipse.Location = new System.Drawing.Point(742, 442);
            this.btnFillEllipse.Name = "btnFillEllipse";
            this.btnFillEllipse.Size = new System.Drawing.Size(149, 54);
            this.btnFillEllipse.TabIndex = 2;
            this.btnFillEllipse.Text = "填充椭圆";
            this.btnFillEllipse.UseVisualStyleBackColor = true;
            this.btnFillEllipse.Click += new System.EventHandler(this.btnFillEllipse_Click);
            // 
            // btnFillPolygon
            // 
            this.btnFillPolygon.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFillPolygon.Location = new System.Drawing.Point(742, 525);
            this.btnFillPolygon.Name = "btnFillPolygon";
            this.btnFillPolygon.Size = new System.Drawing.Size(149, 54);
            this.btnFillPolygon.TabIndex = 2;
            this.btnFillPolygon.Text = "填充多边形";
            this.btnFillPolygon.UseVisualStyleBackColor = true;
            this.btnFillPolygon.Click += new System.EventHandler(this.btnFillPolygon_Click);
            // 
            // btnFillRectangle
            // 
            this.btnFillRectangle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFillRectangle.Location = new System.Drawing.Point(742, 608);
            this.btnFillRectangle.Name = "btnFillRectangle";
            this.btnFillRectangle.Size = new System.Drawing.Size(149, 54);
            this.btnFillRectangle.TabIndex = 2;
            this.btnFillRectangle.Text = "填充矩形";
            this.btnFillRectangle.UseVisualStyleBackColor = true;
            this.btnFillRectangle.Click += new System.EventHandler(this.btnFillRectangle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 692);
            this.Controls.Add(this.btnFillRectangle);
            this.Controls.Add(this.btnFillPolygon);
            this.Controls.Add(this.btnFillEllipse);
            this.Controls.Add(this.btnDrawString);
            this.Controls.Add(this.btnDrawTriangle);
            this.Controls.Add(this.btnCircle);
            this.Controls.Add(this.btnDrawRectangle);
            this.Controls.Add(this.btnDrawLine);
            this.Controls.Add(this.picDisplay);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Button btnDrawLine;
        private System.Windows.Forms.Button btnDrawRectangle;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnDrawTriangle;
        private System.Windows.Forms.Button btnDrawString;
        private System.Windows.Forms.Button btnFillEllipse;
        private System.Windows.Forms.Button btnFillPolygon;
        private System.Windows.Forms.Button btnFillRectangle;
    }
}

