namespace _2025_12_04
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
            this.listViewDisplay = new System.Windows.Forms.ListView();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewDisplay
            // 
            this.listViewDisplay.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewDisplay.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.listViewDisplay.GridLines = true;
            this.listViewDisplay.HideSelection = false;
            this.listViewDisplay.HoverSelection = true;
            this.listViewDisplay.Location = new System.Drawing.Point(27, 104);
            this.listViewDisplay.Name = "listViewDisplay";
            this.listViewDisplay.Size = new System.Drawing.Size(1230, 357);
            this.listViewDisplay.TabIndex = 11;
            this.listViewDisplay.UseCompatibleStateImageBehavior = false;
            this.listViewDisplay.View = System.Windows.Forms.View.Details;
            this.listViewDisplay.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(535, 13);
            this.btnOpenFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(137, 65);
            this.btnOpenFolder.TabIndex = 10;
            this.btnOpenFolder.Text = "打开文件夹";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // txtFolderName
            // 
            this.txtFolderName.Font = new System.Drawing.Font("宋体", 12F);
            this.txtFolderName.Location = new System.Drawing.Point(171, 33);
            this.txtFolderName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(313, 35);
            this.txtFolderName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(23, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 47);
            this.label4.TabIndex = 8;
            this.label4.Text = "文件夹名:";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 112;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "路径";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 336;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "文件大小(字节)";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 153;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "创建日期";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 217;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 544);
            this.Controls.Add(this.listViewDisplay);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.txtFolderName);
            this.Controls.Add(this.label4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewDisplay;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}

