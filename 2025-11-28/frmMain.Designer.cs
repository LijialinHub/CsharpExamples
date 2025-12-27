namespace _2025_11_28
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.btnOpenImg = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSaveImg = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.18644F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.81356F));
            this.tableLayoutPanel1.Controls.Add(this.picDisplay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOpenImg, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrevious, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnNext, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveImg, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(952, 598);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // picDisplay
            // 
            this.picDisplay.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.picDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDisplay.Location = new System.Drawing.Point(3, 3);
            this.picDisplay.Name = "picDisplay";
            this.tableLayoutPanel1.SetRowSpan(this.picDisplay, 4);
            this.picDisplay.Size = new System.Drawing.Size(671, 592);
            this.picDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            // 
            // btnOpenImg
            // 
            this.btnOpenImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnOpenImg.FlatAppearance.BorderSize = 3;
            this.btnOpenImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenImg.Font = new System.Drawing.Font("幼圆", 13F, System.Drawing.FontStyle.Bold);
            this.btnOpenImg.Location = new System.Drawing.Point(735, 37);
            this.btnOpenImg.Margin = new System.Windows.Forms.Padding(3, 3, 70, 40);
            this.btnOpenImg.Name = "btnOpenImg";
            this.btnOpenImg.Size = new System.Drawing.Size(147, 72);
            this.btnOpenImg.TabIndex = 1;
            this.btnOpenImg.Text = "打开图像";
            this.btnOpenImg.UseVisualStyleBackColor = false;
            this.btnOpenImg.Click += new System.EventHandler(this.btnOpenImg_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnPrevious.FlatAppearance.BorderSize = 3;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("幼圆", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.Location = new System.Drawing.Point(735, 186);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(3, 3, 70, 40);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(147, 72);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "上一张";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnNext.FlatAppearance.BorderSize = 3;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("幼圆", 13F, System.Drawing.FontStyle.Bold);
            this.btnNext.Location = new System.Drawing.Point(735, 335);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 3, 70, 40);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(147, 72);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "下一张";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSaveImg
            // 
            this.btnSaveImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveImg.BackColor = System.Drawing.Color.Crimson;
            this.btnSaveImg.FlatAppearance.BorderSize = 3;
            this.btnSaveImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveImg.Font = new System.Drawing.Font("幼圆", 13F, System.Drawing.FontStyle.Bold);
            this.btnSaveImg.Location = new System.Drawing.Point(735, 486);
            this.btnSaveImg.Margin = new System.Windows.Forms.Padding(3, 3, 70, 40);
            this.btnSaveImg.Name = "btnSaveImg";
            this.btnSaveImg.Size = new System.Drawing.Size(147, 72);
            this.btnSaveImg.TabIndex = 1;
            this.btnSaveImg.Text = "保存";
            this.btnSaveImg.UseVisualStyleBackColor = false;
            this.btnSaveImg.Click += new System.EventHandler(this.btnSaveImg_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 598);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "frmMain";
            this.Text = "图像浏览应用程序";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Button btnOpenImg;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSaveImg;
    }
}

