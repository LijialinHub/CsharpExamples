namespace PanelSeparationMachineV1._26
{
    partial class frmDrawParams
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nudXAxisScalar = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudYAxisScalar = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudXOffset = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudYOffset = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudXAxisScalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYAxisScalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "X轴缩放比例";
            // 
            // nudXAxisScalar
            // 
            this.nudXAxisScalar.DecimalPlaces = 2;
            this.nudXAxisScalar.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.nudXAxisScalar.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudXAxisScalar.Location = new System.Drawing.Point(221, 52);
            this.nudXAxisScalar.Name = "nudXAxisScalar";
            this.nudXAxisScalar.Size = new System.Drawing.Size(120, 35);
            this.nudXAxisScalar.TabIndex = 1;
            this.nudXAxisScalar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(28, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Y轴缩放比例";
            // 
            // nudYAxisScalar
            // 
            this.nudYAxisScalar.DecimalPlaces = 2;
            this.nudYAxisScalar.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.nudYAxisScalar.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudYAxisScalar.Location = new System.Drawing.Point(221, 104);
            this.nudYAxisScalar.Name = "nudYAxisScalar";
            this.nudYAxisScalar.Size = new System.Drawing.Size(120, 35);
            this.nudYAxisScalar.TabIndex = 1;
            this.nudYAxisScalar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(28, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "X轴偏移量";
            // 
            // nudXOffset
            // 
            this.nudXOffset.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.nudXOffset.Location = new System.Drawing.Point(221, 160);
            this.nudXOffset.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudXOffset.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nudXOffset.Name = "nudXOffset";
            this.nudXOffset.Size = new System.Drawing.Size(120, 35);
            this.nudXOffset.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(28, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Y轴偏移量";
            // 
            // nudYOffset
            // 
            this.nudYOffset.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.nudYOffset.Location = new System.Drawing.Point(221, 217);
            this.nudYOffset.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudYOffset.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nudYOffset.Name = "nudYOffset";
            this.nudYOffset.Size = new System.Drawing.Size(120, 35);
            this.nudYOffset.TabIndex = 1;
            // 
            // frmDrawParams
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(373, 271);
            this.Controls.Add(this.nudYOffset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudXOffset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudYAxisScalar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudXAxisScalar);
            this.Controls.Add(this.label1);
            this.Name = "frmDrawParams";
            this.Text = "绘图参数";
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 386, 298);
            this.Load += new System.EventHandler(this.frmDrawParams_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudXAxisScalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYAxisScalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudXAxisScalar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudYAxisScalar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudXOffset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudYOffset;
    }
}