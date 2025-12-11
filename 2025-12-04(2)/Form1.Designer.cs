namespace _2025_12_04_2_
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnFault = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清除所有ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.61049F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.41199F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.16479F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(795, 606);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(789, 70);
            this.label1.TabIndex = 0;
            this.label1.Text = "操作记录";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 73);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(789, 419);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnReset, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnFault, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnStop, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnReverse, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnForward, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 498);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(789, 105);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnForward
            // 
            this.btnForward.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnForward.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnForward.FlatAppearance.BorderSize = 2;
            this.btnForward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnForward.Location = new System.Drawing.Point(15, 15);
            this.btnForward.Margin = new System.Windows.Forms.Padding(15);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(127, 75);
            this.btnForward.TabIndex = 0;
            this.btnForward.Text = "正转运行";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReverse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnReverse.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReverse.FlatAppearance.BorderSize = 2;
            this.btnReverse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReverse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReverse.Location = new System.Drawing.Point(172, 15);
            this.btnReverse.Margin = new System.Windows.Forms.Padding(15);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(127, 75);
            this.btnReverse.TabIndex = 1;
            this.btnReverse.Text = "反转运行";
            this.btnReverse.UseVisualStyleBackColor = false;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.Color.IndianRed;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStop.FlatAppearance.BorderSize = 2;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Location = new System.Drawing.Point(329, 15);
            this.btnStop.Margin = new System.Windows.Forms.Padding(15);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(127, 75);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnFault
            // 
            this.btnFault.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnFault.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFault.FlatAppearance.BorderSize = 2;
            this.btnFault.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnFault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFault.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFault.Location = new System.Drawing.Point(486, 15);
            this.btnFault.Margin = new System.Windows.Forms.Padding(15);
            this.btnFault.Name = "btnFault";
            this.btnFault.Size = new System.Drawing.Size(127, 75);
            this.btnFault.TabIndex = 3;
            this.btnFault.Text = "故障信号";
            this.btnFault.UseVisualStyleBackColor = false;
            this.btnFault.Click += new System.EventHandler(this.btnFault_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReset.FlatAppearance.BorderSize = 2;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(643, 15);
            this.btnReset.Margin = new System.Windows.Forms.Padding(15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(131, 75);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "故障复位";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "发生时间";
            this.columnHeader1.Width = 196;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "事件内容";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 548;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除所有ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 34);
            // 
            // 清除所有ToolStripMenuItem
            // 
            this.清除所有ToolStripMenuItem.BackColor = System.Drawing.Color.Red;
            this.清除所有ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.清除所有ToolStripMenuItem.Name = "清除所有ToolStripMenuItem";
            this.清除所有ToolStripMenuItem.Size = new System.Drawing.Size(240, 30);
            this.清除所有ToolStripMenuItem.Text = "清除所有";
            this.清除所有ToolStripMenuItem.Click += new System.EventHandler(this.清除所有ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 606);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFault;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清除所有ToolStripMenuItem;
    }
}

