namespace _2025_12_08
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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRealtimeChartPage = new System.Windows.Forms.Button();
            this.btnAlarmPage = new System.Windows.Forms.Button();
            this.btnRecipePage = new System.Windows.Forms.Button();
            this.btnUserPage = new System.Windows.Forms.Button();
            this.panelFormPage = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelFormPage, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.77778F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1178, 657);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1172, 119);
            this.label1.TabIndex = 0;
            this.label1.Text = "xx公司xx项目";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnRealtimeChartPage, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAlarmPage, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnRecipePage, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnUserPage, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 122);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(229, 532);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnRealtimeChartPage
            // 
            this.btnRealtimeChartPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRealtimeChartPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRealtimeChartPage.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRealtimeChartPage.Location = new System.Drawing.Point(30, 30);
            this.btnRealtimeChartPage.Margin = new System.Windows.Forms.Padding(30);
            this.btnRealtimeChartPage.Name = "btnRealtimeChartPage";
            this.btnRealtimeChartPage.Size = new System.Drawing.Size(169, 73);
            this.btnRealtimeChartPage.TabIndex = 0;
            this.btnRealtimeChartPage.Text = "实时曲线";
            this.btnRealtimeChartPage.UseVisualStyleBackColor = false;
            this.btnRealtimeChartPage.Click += new System.EventHandler(this.btnChangePage_Click);
            // 
            // btnAlarmPage
            // 
            this.btnAlarmPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlarmPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAlarmPage.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAlarmPage.Location = new System.Drawing.Point(30, 163);
            this.btnAlarmPage.Margin = new System.Windows.Forms.Padding(30);
            this.btnAlarmPage.Name = "btnAlarmPage";
            this.btnAlarmPage.Size = new System.Drawing.Size(169, 73);
            this.btnAlarmPage.TabIndex = 0;
            this.btnAlarmPage.Text = "报警画面";
            this.btnAlarmPage.UseVisualStyleBackColor = false;
            this.btnAlarmPage.Click += new System.EventHandler(this.btnChangePage_Click);
            // 
            // btnRecipePage
            // 
            this.btnRecipePage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecipePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRecipePage.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRecipePage.Location = new System.Drawing.Point(30, 296);
            this.btnRecipePage.Margin = new System.Windows.Forms.Padding(30);
            this.btnRecipePage.Name = "btnRecipePage";
            this.btnRecipePage.Size = new System.Drawing.Size(169, 73);
            this.btnRecipePage.TabIndex = 0;
            this.btnRecipePage.Text = "配方画面";
            this.btnRecipePage.UseVisualStyleBackColor = false;
            this.btnRecipePage.Click += new System.EventHandler(this.btnChangePage_Click);
            // 
            // btnUserPage
            // 
            this.btnUserPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnUserPage.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserPage.Location = new System.Drawing.Point(30, 429);
            this.btnUserPage.Margin = new System.Windows.Forms.Padding(30);
            this.btnUserPage.Name = "btnUserPage";
            this.btnUserPage.Size = new System.Drawing.Size(169, 73);
            this.btnUserPage.TabIndex = 0;
            this.btnUserPage.Text = "用户管理";
            this.btnUserPage.UseVisualStyleBackColor = false;
            this.btnUserPage.Click += new System.EventHandler(this.btnChangePage_Click);
            // 
            // panelFormPage
            // 
            this.panelFormPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFormPage.Location = new System.Drawing.Point(238, 122);
            this.panelFormPage.Name = "panelFormPage";
            this.panelFormPage.Size = new System.Drawing.Size(937, 532);
            this.panelFormPage.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1178, 657);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "frmMain";
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnRealtimeChartPage;
        private System.Windows.Forms.Button btnAlarmPage;
        private System.Windows.Forms.Button btnRecipePage;
        private System.Windows.Forms.Button btnUserPage;
        private System.Windows.Forms.Panel panelFormPage;
    }
}

