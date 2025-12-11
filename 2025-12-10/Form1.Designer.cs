namespace _2025_12_10
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDrawRectangle = new System.Windows.Forms.Button();
            this.btnTranslation = new System.Windows.Forms.Button();
            this.btnRotation = new System.Windows.Forms.Button();
            this.btnZooming = new System.Windows.Forms.Button();
            this.btnCoordReset = new System.Windows.Forms.Button();
            this.btnXAxisMirror = new System.Windows.Forms.Button();
            this.btnYAxisMirror = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(646, 658);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnDrawRectangle
            // 
            this.btnDrawRectangle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDrawRectangle.Location = new System.Drawing.Point(668, 12);
            this.btnDrawRectangle.Name = "btnDrawRectangle";
            this.btnDrawRectangle.Size = new System.Drawing.Size(151, 47);
            this.btnDrawRectangle.TabIndex = 1;
            this.btnDrawRectangle.Text = "绘制矩形";
            this.btnDrawRectangle.UseVisualStyleBackColor = true;
            this.btnDrawRectangle.Click += new System.EventHandler(this.btnDrawRectangle_Click);
            // 
            // btnTranslation
            // 
            this.btnTranslation.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTranslation.Location = new System.Drawing.Point(668, 267);
            this.btnTranslation.Name = "btnTranslation";
            this.btnTranslation.Size = new System.Drawing.Size(151, 58);
            this.btnTranslation.TabIndex = 1;
            this.btnTranslation.Text = "平移变化\r\n(x轴平移20，y轴平移40)\r\n";
            this.btnTranslation.UseVisualStyleBackColor = true;
            this.btnTranslation.Click += new System.EventHandler(this.btnTranslation_Click);
            // 
            // btnRotation
            // 
            this.btnRotation.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRotation.Location = new System.Drawing.Point(668, 363);
            this.btnRotation.Name = "btnRotation";
            this.btnRotation.Size = new System.Drawing.Size(151, 58);
            this.btnRotation.TabIndex = 1;
            this.btnRotation.Text = "旋转变换\r\n(旋转30度)\r\n";
            this.btnRotation.UseVisualStyleBackColor = true;
            this.btnRotation.Click += new System.EventHandler(this.btnRotation_Click);
            // 
            // btnZooming
            // 
            this.btnZooming.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnZooming.Location = new System.Drawing.Point(668, 459);
            this.btnZooming.Name = "btnZooming";
            this.btnZooming.Size = new System.Drawing.Size(151, 58);
            this.btnZooming.TabIndex = 1;
            this.btnZooming.Text = "缩放变换\r\n(缩放0.5x)\r\n";
            this.btnZooming.UseVisualStyleBackColor = true;
            this.btnZooming.Click += new System.EventHandler(this.btnZooming_Click);
            // 
            // btnCoordReset
            // 
            this.btnCoordReset.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCoordReset.Location = new System.Drawing.Point(668, 555);
            this.btnCoordReset.Name = "btnCoordReset";
            this.btnCoordReset.Size = new System.Drawing.Size(151, 58);
            this.btnCoordReset.TabIndex = 1;
            this.btnCoordReset.Text = "坐标复位\r\n";
            this.btnCoordReset.UseVisualStyleBackColor = true;
            this.btnCoordReset.Click += new System.EventHandler(this.btnCoordReset_Click);
            // 
            // btnXAxisMirror
            // 
            this.btnXAxisMirror.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnXAxisMirror.Location = new System.Drawing.Point(668, 97);
            this.btnXAxisMirror.Name = "btnXAxisMirror";
            this.btnXAxisMirror.Size = new System.Drawing.Size(151, 47);
            this.btnXAxisMirror.TabIndex = 1;
            this.btnXAxisMirror.Text = "X轴镜像";
            this.btnXAxisMirror.UseVisualStyleBackColor = true;
            this.btnXAxisMirror.Click += new System.EventHandler(this.btnXAxisMirror_Click);
            // 
            // btnYAxisMirror
            // 
            this.btnYAxisMirror.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYAxisMirror.Location = new System.Drawing.Point(668, 182);
            this.btnYAxisMirror.Name = "btnYAxisMirror";
            this.btnYAxisMirror.Size = new System.Drawing.Size(151, 47);
            this.btnYAxisMirror.TabIndex = 1;
            this.btnYAxisMirror.Text = "Y轴镜像";
            this.btnYAxisMirror.UseVisualStyleBackColor = true;
            this.btnYAxisMirror.Click += new System.EventHandler(this.btnYAxisMirror_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 658);
            this.Controls.Add(this.btnCoordReset);
            this.Controls.Add(this.btnZooming);
            this.Controls.Add(this.btnRotation);
            this.Controls.Add(this.btnTranslation);
            this.Controls.Add(this.btnYAxisMirror);
            this.Controls.Add(this.btnXAxisMirror);
            this.Controls.Add(this.btnDrawRectangle);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDrawRectangle;
        private System.Windows.Forms.Button btnTranslation;
        private System.Windows.Forms.Button btnRotation;
        private System.Windows.Forms.Button btnZooming;
        private System.Windows.Forms.Button btnCoordReset;
        private System.Windows.Forms.Button btnXAxisMirror;
        private System.Windows.Forms.Button btnYAxisMirror;
    }
}

