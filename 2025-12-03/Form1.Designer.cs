namespace _2025_12_03
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
            this.btnWriteFile = new System.Windows.Forms.Button();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.btnDelFile = new System.Windows.Forms.Button();
            this.btnMoveFile = new System.Windows.Forms.Button();
            this.btnCopyFile = new System.Windows.Forms.Button();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.txtFileDisplay = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnDelFolder = new System.Windows.Forms.Button();
            this.btnMoveFolder = new System.Windows.Forms.Button();
            this.btnCreateFolder = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.btnWriteFile);
            this.panel1.Controls.Add(this.btnReadFile);
            this.panel1.Controls.Add(this.btnDelFile);
            this.panel1.Controls.Add(this.btnMoveFile);
            this.panel1.Controls.Add(this.btnCopyFile);
            this.panel1.Controls.Add(this.btnCreateFile);
            this.panel1.Controls.Add(this.txtFileDisplay);
            this.panel1.Controls.Add(this.txtFileName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1255, 345);
            this.panel1.TabIndex = 0;
            // 
            // btnWriteFile
            // 
            this.btnWriteFile.Location = new System.Drawing.Point(1028, 217);
            this.btnWriteFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWriteFile.Name = "btnWriteFile";
            this.btnWriteFile.Size = new System.Drawing.Size(191, 76);
            this.btnWriteFile.TabIndex = 2;
            this.btnWriteFile.Text = "写入";
            this.btnWriteFile.UseVisualStyleBackColor = true;
            this.btnWriteFile.Click += new System.EventHandler(this.btnWriteFile_Click);
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(1028, 33);
            this.btnReadFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(191, 76);
            this.btnReadFile.TabIndex = 2;
            this.btnReadFile.Text = "读取";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // btnDelFile
            // 
            this.btnDelFile.Location = new System.Drawing.Point(285, 237);
            this.btnDelFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelFile.Name = "btnDelFile";
            this.btnDelFile.Size = new System.Drawing.Size(191, 76);
            this.btnDelFile.TabIndex = 2;
            this.btnDelFile.Text = "删除";
            this.btnDelFile.UseVisualStyleBackColor = true;
            this.btnDelFile.Click += new System.EventHandler(this.btnDelFile_Click);
            // 
            // btnMoveFile
            // 
            this.btnMoveFile.Location = new System.Drawing.Point(52, 237);
            this.btnMoveFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMoveFile.Name = "btnMoveFile";
            this.btnMoveFile.Size = new System.Drawing.Size(191, 76);
            this.btnMoveFile.TabIndex = 2;
            this.btnMoveFile.Text = "移动";
            this.btnMoveFile.UseVisualStyleBackColor = true;
            this.btnMoveFile.Click += new System.EventHandler(this.btnMoveFile_Click);
            // 
            // btnCopyFile
            // 
            this.btnCopyFile.Location = new System.Drawing.Point(285, 120);
            this.btnCopyFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCopyFile.Name = "btnCopyFile";
            this.btnCopyFile.Size = new System.Drawing.Size(191, 76);
            this.btnCopyFile.TabIndex = 2;
            this.btnCopyFile.Text = "复制";
            this.btnCopyFile.UseVisualStyleBackColor = true;
            this.btnCopyFile.Click += new System.EventHandler(this.btnCopyFile_Click);
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Location = new System.Drawing.Point(52, 120);
            this.btnCreateFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(191, 76);
            this.btnCreateFile.TabIndex = 2;
            this.btnCreateFile.Text = "创建";
            this.btnCreateFile.UseVisualStyleBackColor = true;
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // txtFileDisplay
            // 
            this.txtFileDisplay.Location = new System.Drawing.Point(537, 33);
            this.txtFileDisplay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFileDisplay.Multiline = true;
            this.txtFileDisplay.Name = "txtFileDisplay";
            this.txtFileDisplay.Size = new System.Drawing.Size(458, 279);
            this.txtFileDisplay.TabIndex = 1;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(251, 29);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(216, 35);
            this.txtFileName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(81, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件名:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.txtFolderPath);
            this.panel2.Controls.Add(this.txtFolderName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnOpenFolder);
            this.panel2.Controls.Add(this.btnDelFolder);
            this.panel2.Controls.Add(this.btnMoveFolder);
            this.panel2.Controls.Add(this.btnCreateFolder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.panel2.Location = new System.Drawing.Point(0, 345);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1255, 271);
            this.panel2.TabIndex = 1;
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(251, 105);
            this.txtFolderPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(593, 35);
            this.txtFolderPath.TabIndex = 3;
            // 
            // txtFolderName
            // 
            this.txtFolderName.Location = new System.Drawing.Point(251, 24);
            this.txtFolderName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(313, 35);
            this.txtFolderName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(46, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 47);
            this.label3.TabIndex = 2;
            this.label3.Text = "路径:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(52, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 47);
            this.label2.TabIndex = 2;
            this.label2.Text = "文件夹名:";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(1028, 49);
            this.btnOpenFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(191, 91);
            this.btnOpenFolder.TabIndex = 2;
            this.btnOpenFolder.Text = "打开文件夹";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnDelFolder
            // 
            this.btnDelFolder.Location = new System.Drawing.Point(472, 172);
            this.btnDelFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelFolder.Name = "btnDelFolder";
            this.btnDelFolder.Size = new System.Drawing.Size(191, 63);
            this.btnDelFolder.TabIndex = 2;
            this.btnDelFolder.Text = "删除";
            this.btnDelFolder.UseVisualStyleBackColor = true;
            this.btnDelFolder.Click += new System.EventHandler(this.btnDelFolder_Click);
            // 
            // btnMoveFolder
            // 
            this.btnMoveFolder.Location = new System.Drawing.Point(251, 172);
            this.btnMoveFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMoveFolder.Name = "btnMoveFolder";
            this.btnMoveFolder.Size = new System.Drawing.Size(191, 63);
            this.btnMoveFolder.TabIndex = 2;
            this.btnMoveFolder.Text = "移动";
            this.btnMoveFolder.UseVisualStyleBackColor = true;
            this.btnMoveFolder.Click += new System.EventHandler(this.btnMoveFolder_Click);
            // 
            // btnCreateFolder
            // 
            this.btnCreateFolder.Location = new System.Drawing.Point(33, 172);
            this.btnCreateFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateFolder.Name = "btnCreateFolder";
            this.btnCreateFolder.Size = new System.Drawing.Size(191, 63);
            this.btnCreateFolder.TabIndex = 2;
            this.btnCreateFolder.Text = "创建";
            this.btnCreateFolder.UseVisualStyleBackColor = true;
            this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 1038);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWriteFile;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.Button btnDelFile;
        private System.Windows.Forms.Button btnMoveFile;
        private System.Windows.Forms.Button btnCopyFile;
        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.TextBox txtFileDisplay;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelFolder;
        private System.Windows.Forms.Button btnMoveFolder;
        private System.Windows.Forms.Button btnCreateFolder;
        private System.Windows.Forms.Button btnOpenFolder;
    }
}

