using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_11_25
{
    //partial：部分的，可以把一个类分成多个部分（一般在不同页面）编写， 他们是同一个类
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //for (double i = 0.5; i <=1.0; i+=0.1)
            //{
            //    this.Opacity = i;
            //    Thread.Sleep(25);
            //}
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //sender: 产生事件的对象，在这个方法中就是btnOK这个按钮对象
            //e: 事件的相关数据

            //mb+tab
            DialogResult dialogResult = MessageBox.Show("是否进入登录界面", "消息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (DialogResult.Yes == dialogResult)
            {
                this.Hide();
                frmLogin frmLogin = new frmLogin();
                //frmLogin.Show();
                
                frmLogin.ShowDialog(); //以对话框形式显示，置顶，垄断

            }

        }

        private void btnChangeColor_Click(object sender, EventArgs e)
        {

            Random random = new Random();

            int Rchannels = random.Next(0, 256);
            int Gchannels = random.Next(0, 256);
            int Bchannels = random.Next(0, 256);

            this.BackColor = Color.FromArgb(Rchannels, Gchannels, Bchannels);
        }

        private void btnDisable_Enable_Click(object sender, EventArgs e)
        {
            if (btnDisable_Enable.Text == "失效")
            {
                btnChangeColor.Enabled = false;
                btnDisable_Enable.Text = "生效";
                btnDisable_Enable.BackColor = Color.Green;
            }
            else
            {
                btnChangeColor.Enabled = true;
                btnDisable_Enable.Text = "失效";
                btnDisable_Enable.BackColor = Color.FromArgb(255, 192, 255);
            }
        }

        /// <summary>
        /// 取消按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否确定取消", "消息提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm1 frm1 = new frm1();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void from1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2 frm2 = new frm2();
            frm2.MdiParent = this;
            frm2.Show();
        }

        private void 水平ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 垂直ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void 堆叠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }


        /// <summary>
        /// 点动运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJog_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            switch (button.Text)
            {
                case "X轴正向运行": lblDisplayX.Text = "正向运行中......"; break;
                case "Y轴正向运行": lblDisplayY.Text = "正向运行中......"; break;
                case "X轴负向运行": lblDisplayX.Text = "负向运行中......"; break;
                case "Y轴负向运行": lblDisplayY.Text = "负向运行中......"; break;
            }


        }


        /// <summary>
        /// 点动停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJog_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            switch (button.Text)
            {
                case "X轴正向运行": lblDisplayX.Text = ""; break;
                case "Y轴正向运行": lblDisplayY.Text = ""; break;
                case "X轴负向运行": lblDisplayX.Text = ""; break;
                case "Y轴负向运行": lblDisplayY.Text = ""; break;
            }

        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            //A:X轴正向运动 D:X轴负向运动  S:Y轴正向运动 W:Y轴负向运动

            if (e.KeyCode == Keys.A)
            {
                lblDisplayX.Text = "X轴正向运动";
            }
            else if (e.KeyCode == Keys.D)
            {
                lblDisplayX.Text = "X轴负向运动";
            }
            if (e.KeyCode == Keys.S)
            {
                lblDisplayY.Text = "Y轴正向运动";
            }
            else if (e.KeyCode == Keys.W)
            {
                lblDisplayY.Text = "Y轴负向运动";
            }


        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                lblDisplayX.Text = "停止中";
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.W)
            {
                lblDisplayY.Text = "停止中";
            }

        }
    }
}
