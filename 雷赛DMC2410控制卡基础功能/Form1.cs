using csDmc2410;
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

namespace 雷赛DMC2410控制卡基础功能
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            //试图加载格式不正确......  32位64位问题
            //为控制卡分配系统资源 并初始化控制卡
            ushort res = Dmc2410.d2410_board_init();
            if(res == 0)
            {
                MessageBox.Show("没有找到控制卡或者控制卡异常!","消息提示",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(res < 0)
            {
                MessageBox.Show("表述有2张或2张以上控制卡的硬件设置卡号相同；" +
                    "返回值取绝对值后减1 即为该卡号!", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else  //1~8
            {
                MessageBox.Show($"控制卡初始化成功! 控制卡有{res}张","消息提示",MessageBoxButtons.OK, MessageBoxIcon.Information);

                //刷新坐标到tssl
                RealTimeReadPositon();

                //实时刷新轴状态
                RealTimeReadAxisStatus();

            }



        }

        /// <summary>
        /// 实时刷新轴状态
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void RealTimeReadAxisStatus()
        {
            Task.Run(() =>
            { 
                while (true)
                {

                    foreach (Control item in panelDisplayAxisStatus.Controls)
                    {
                        string name = item.Name;
                        ushort axisNum = ushort.Parse(name.Substring(name.Length - 1));
                        if(name.Contains("Run"))
                        {   
                            this.Invoke(new Action(() => 
                            {
                                // 0:运行中 1:停止
                                item.BackColor = Dmc2410.d2410_check_done(axisNum) == 0 ? Color.Lime : Color.White;
                            }));
                        }

                        else if (name.Contains("ORG"))
                        {
                            ushort res = Dmc2410.d2410_axis_io_status(axisNum);
                            this.Invoke(new Action(() =>
                            {
                                item.BackColor = (res & (int)Math.Pow(2, 14)) == 0 ? Color.White : Color.Yellow;
                            }));
                        }

                        else if(name.Contains("PL"))
                        {
                            ushort res = Dmc2410.d2410_axis_io_status(axisNum);
                            this.Invoke(new Action(() =>
                            {
                                item.BackColor = (res & (int)Math.Pow(2, 12)) == 0 ? Color.White : Color.Blue;
                            }));
                        }

                        else if(name.Contains("NL"))
                        {
                            ushort res = Dmc2410.d2410_axis_io_status(axisNum);
                            this.Invoke(new Action(() =>
                            {
                                item.BackColor = (res & (int)Math.Pow(2, 13)) == 0 ? Color.White : Color.Yellow;
                            }));
                        }

                        else if(name.Contains("Alrm"))
                        {
                            ushort res = Dmc2410.d2410_axis_io_status(axisNum);
                            this.Invoke(new Action(() =>
                            {
                                item.BackColor = (res & (int)Math.Pow(2, 11 )) == 0 ? Color.White : Color.Red;
                            }));
                        }

                    }

                    Thread.Sleep(50);
                }
            });
        }

        /// <summary>
        /// 实时读取坐标
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private  void RealTimeReadPositon()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    int xPos = Dmc2410.d2410_get_position(0); //获取X轴坐标
                    int yPos = Dmc2410.d2410_get_position(1); //获取Y轴坐标
                    int zPos = Dmc2410.d2410_get_position(2); //获取Z轴坐标

                    double xSpeed = Dmc2410.d2410_read_current_speed(0); //获取X轴速度
                    double ySpeed = Dmc2410.d2410_read_current_speed(1); //获取Y轴速度
                    double zSpeed = Dmc2410.d2410_read_current_speed(2); //获取Z轴速度

                    this.Invoke(new Action(() => 
                    {
                        tsslXAxis.Text = xPos.ToString() + $"({xSpeed}p/s)";
                        tsslYAxis.Text = yPos.ToString() + $"({ySpeed}p/s)";
                        tsslZAxis.Text = zPos.ToString() + $"({zSpeed}p/s)";
                    }));
                    Thread.Sleep(100);
                }
            });
        }


        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dmc2410.d2410_board_close(); //关闭控制卡释放系统资源
            Environment.Exit(0);
        }

        /// <summary>
        /// 绝对位置运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunRelatively_Click(object sender, EventArgs e)
        {
            ushort axisNum = (ushort)(radXAxis.Checked ? 0 : (radYAxis.Checked ? 1 : 2));
            int dist = int.Parse(txtAbsolutePosition.Text);

            double speed = (double)nudRunSpeed.Value;
            Dmc2410.d2410_set_profile(axisNum, 0, speed, 0.1, .1);  //轴号 最小速度 最大速度 加速度时间 减速度时间
            Dmc2410.d2410_t_pmove(axisNum, dist, 1);   // 0:相对坐标模式 1:绝对坐标模式
        }

        /// <summary>
        /// 相对位置运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnRunAbsolute_Click(object sender, EventArgs e)
        {
            ushort axisNum = (ushort)(radXAxis.Checked ? 0 : (radYAxis.Checked ? 1 : 2));
            int dist = int.Parse(txtRelativePosition.Text);
            double speed = (double)nudRunSpeed.Value;
            
            Dmc2410.d2410_set_profile(axisNum, 0, speed, 0.1, 0.1);  //轴号 最小速度 最大速度 加速度时间 减速度时间
            Dmc2410.d2410_t_pmove(axisNum, dist, 0);   // 0:相对坐标模式 1:绝对坐标模式


        }

        /// <summary>
        /// 鼠标按下事件 点动运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJog_MouseDown_Click(object sender, MouseEventArgs e)
        {

            if (chkIsMicro.Checked) { return; }

                Button button = sender as Button;
            ushort axisNum = 0; //轴号
            ushort dir = 0; //方向
            double setSpeed = (double)nudJogSpeed.Value;
            switch(button.Text)
            {
                case "X轴左移": axisNum = 0; dir = 1; break;
                case "X轴右移": axisNum = 0; dir = 0; break;

                case "Y轴后退": axisNum = 1; dir = 0; break;
                case "Y轴前进": axisNum = 1; dir = 1; break;

                case "Z轴上升": axisNum = 2; dir = 0; break;
                case "Z轴下降": axisNum = 2; dir = 1; break;
            }

            Dmc2410.d2410_set_profile(axisNum, 0, setSpeed, 0.1, 0.1);
            Dmc2410.d2410_t_vmove(axisNum, dir); //指定运动方向 0：负向 1：正向

            
        }


        /// <summary>
        /// 鼠标抬起事件 点动停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJog_MouseUp_Click(object sender, MouseEventArgs e)
        {
            if (chkIsMicro.Checked) { return; }

            Button button = sender as Button;
            ushort axisNum = 0; //轴号

            switch (button.Text)
            {
                case "X轴左移":
                case "X轴右移": axisNum = 0;  break;

                case "Y轴后退": 
                case "Y轴前进": axisNum = 1;  break;

                case "Z轴上升": 
                case "Z轴下降": axisNum = 2;  break;
            }

            Dmc2410.d2410_imd_stop(axisNum); //使指定的轴立即停止，没有任何减速的过程
            
        }


        /// <summary>
        /// 键盘按下 点动运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {   


            double speed = (double)nudJogSpeed.Value;

            if (e.KeyCode == Keys.A)  //X 左移 正方向
            {
                Dmc2410.d2410_set_profile(0, 0, speed, 0.1, 0.1);
                Dmc2410.d2410_t_vmove(0, 1);
            }
            else if (e.KeyCode == Keys.D) //X 右移 负方向
            {
                Dmc2410.d2410_set_profile(0, 0, speed, 0.1, 0.1);
                Dmc2410.d2410_t_vmove(0, 0);
            }

            if (e.KeyCode == Keys.W)  //Y 后退 负方向
            {
                Dmc2410.d2410_set_profile(1, 0, speed, 0.1, 0.1);
                Dmc2410.d2410_t_vmove(1, 0);
            }
            else if (e.KeyCode == Keys.S)
            {
                Dmc2410.d2410_set_profile(1, 0, speed, 0.1, 0.1);
                Dmc2410.d2410_t_vmove(1, 1);
            }

            if(e.KeyCode == Keys.P)  //Z 上升 负方向
            {
                Dmc2410.d2410_set_profile(2, 0, speed, 0.1, 0.1);
                Dmc2410.d2410_t_vmove(2, 0);
            }
            else if (e.KeyCode == Keys.L) //Z 下降 正方向
            {
                Dmc2410.d2410_set_profile(2, 0, speed, 0.1, 0.1);
                Dmc2410.d2410_t_vmove(2, 1);
            }

        }

        /// <summary>
        /// 键盘抬起 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                Dmc2410.d2410_imd_stop(0); //使指定的轴立即停止，没有任何减速的过程
            }
            else if(e.KeyCode == Keys.S || e.KeyCode == Keys.W)
            {
                Dmc2410.d2410_imd_stop(1);
            }
            else if(e.KeyCode == Keys.P || e.KeyCode == Keys.L)
            {
                Dmc2410.d2410_imd_stop(2);
            }
        }


        /// <summary>
        /// 是否微动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIsMicro_CheckedChanged(object sender, EventArgs e)
        {
            if(chkIsMicro.Checked)
            {
                chkIsMicro.Text = "微动";
                chkIsMicro.BackColor = Color.FromArgb(255, 128, 0);
            }
            else
            {
                chkIsMicro.Text = "Jog";
                chkIsMicro.BackColor = Color.White;
            }
        }

        private void btnMicroMove_Click(object sender, EventArgs e)
        {
            if (!chkIsMicro.Checked) { return;}

            Button button = sender as Button;
            ushort axisNum = 0;
            int dist = int.Parse(cmbMicroDistance.Text); // 微动距离
            switch(button.Text)
            {
                case "X轴左移": axisNum = 0; dist = Math.Abs(dist); break;
                case "X轴右移": axisNum = 0; dist = -Math.Abs(dist); break;

                case "Y轴后退": axisNum = 1; dist = -Math.Abs(dist); break;
                case "Y轴前进": axisNum = 1; dist = Math.Abs(dist); break;

                case "Z轴上升": axisNum = 2; dist = -Math.Abs(dist); break;
                case "Z轴下降": axisNum = 2; dist = Math.Abs(dist); break;
            }

            Dmc2410.d2410_set_profile(axisNum, 0, 100, 0.1, 0.1);
            Dmc2410.d2410_t_pmove(axisNum, dist, 0); //指定运动方向 0：负向 1：正向

        }
    }
}
