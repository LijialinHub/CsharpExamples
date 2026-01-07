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
            if (res == 0)
            {
                MessageBox.Show("没有找到控制卡或者控制卡异常!", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (res < 0)
            {
                MessageBox.Show("表述有2张或2张以上控制卡的硬件设置卡号相同；" +
                    "返回值取绝对值后减1 即为该卡号!", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else  //1~8
            {
                MessageBox.Show($"控制卡初始化成功! 控制卡有{res}张", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //刷新坐标到tssl
                RealTimeReadPositon();

                //实时刷新轴状态
                RealTimeReadAxisStatus();

                //读取IO状态
                RealTimeReadAxisIOStatus();

            }



        }

        /// <summary>
        /// 实时读取轴IO状态
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void RealTimeReadAxisIOStatus()
        {
            Task.Run(() => 
            {
                while (true)
                {
                    //cardno 轴编号 bitno 位号
                    int in1 = Dmc2410.d2410_read_inbit(0, 1);
                    int in2 = Dmc2410.d2410_read_inbit(0, 2);
                    int in3 = Dmc2410.d2410_read_inbit(0, 3);

                    int out1 = Dmc2410.d2410_read_outbit(0, 1);
                    int out2 = Dmc2410.d2410_read_outbit(0, 2);
                    int out3 = Dmc2410.d2410_read_outbit(0, 3);
                    int out4 = Dmc2410.d2410_read_outbit(0, 4);
                    int out5 = Dmc2410.d2410_read_outbit(0, 5);

                    //On Off输出电平 0：低电平 1：高电平
                    this.Invoke(new Action(() =>
                    {
                        lblIn1.BackColor = in1 == 0 ? Color.Red : Color.White;
                        lblIn2.BackColor = in2 == 0 ? Color.Red : Color.White;
                        lblIn3.BackColor = in3 == 0 ? Color.Red : Color.White;

                        lblOUT1.BackColor = out1 == 0 ? Color.Red : Color.White;
                        lblOUT2.BackColor = out2 == 0 ? Color.Red : Color.White;
                        lblOUT3.BackColor = out3 == 0 ? Color.Red : Color.White;
                        lblOUT4.BackColor = out4 == 0 ? Color.Red : Color.White;
                        lblOUT5.BackColor = out5 == 0 ? Color.Red : Color.White;
                    }));
                    Thread.Sleep(100);
                }

            });
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
                        if (name.Contains("Run"))
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

                        else if (name.Contains("PL"))
                        {
                            ushort res = Dmc2410.d2410_axis_io_status(axisNum);
                            this.Invoke(new Action(() =>
                            {
                                item.BackColor = (res & (int)Math.Pow(2, 12)) == 0 ? Color.White : Color.Blue;
                            }));
                        }

                        else if (name.Contains("NL"))
                        {
                            ushort res = Dmc2410.d2410_axis_io_status(axisNum);
                            this.Invoke(new Action(() =>
                            {
                                item.BackColor = (res & (int)Math.Pow(2, 13)) == 0 ? Color.White : Color.Yellow;
                            }));
                        }

                        else if (name.Contains("Alrm"))
                        {
                            ushort res = Dmc2410.d2410_axis_io_status(axisNum);
                            this.Invoke(new Action(() =>
                            {
                                item.BackColor = (res & (int)Math.Pow(2, 11)) == 0 ? Color.White : Color.Red;
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
        private void RealTimeReadPositon()
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
            switch (button.Text)
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
                case "X轴右移": axisNum = 0; break;

                case "Y轴后退":
                case "Y轴前进": axisNum = 1; break;

                case "Z轴上升":
                case "Z轴下降": axisNum = 2; break;
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

            if (e.KeyCode == Keys.P)  //Z 上升 负方向
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
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                Dmc2410.d2410_imd_stop(0); //使指定的轴立即停止，没有任何减速的过程
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.W)
            {
                Dmc2410.d2410_imd_stop(1);
            }
            else if (e.KeyCode == Keys.P || e.KeyCode == Keys.L)
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
            if (chkIsMicro.Checked)
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
            if (!chkIsMicro.Checked) { return; }

            Button button = sender as Button;
            ushort axisNum = 0;
            int dist = int.Parse(cmbMicroDistance.Text); // 微动距离
            switch (button.Text)
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

        /// <summary>
        /// 输出点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblSetOut_click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            //截取空间名的最后一位
            ushort bitNo = ushort.Parse(label.Name.Substring(label.Name.Length - 1));

            //读取状态
            int readOutRes = Dmc2410.d2410_read_outbit(0, bitNo);

            //输出电平 0：低电平 1：高电平
            Dmc2410.d2410_write_outbit(0, bitNo, (ushort)(readOutRes == 0 ? 1 : 0));
        }

        /// <summary>
        /// 急停信号
        /// volatile的主要作用是防止编译器对变量的访问进行优化
        /// 确保变量的值始终都是最新的，字段可能由同时执行的多个线程修改
        /// </summary>
        private volatile bool isEmgSignal = false;
        private void btnEmergencyStop_Click(object sender, EventArgs e)
        {
            if (btnEmergencyStop.Text == "急停")
            {
                Dmc2410.d2410_emg_stop();
                isEmgSignal = true;
                CheckEmgSignal();
                btnEmergencyStop.Text = "急停复位";
                btnEmergencyStop.BackColor = Color.Yellow;
            }
            else
            {
                isEmgSignal = false;
                btnEmergencyStop.Text = "急停";
                btnEmergencyStop.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// 检测急停信号
        /// </summary>
        private void CheckEmgSignal()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (!isEmgSignal) { break; }
                    Dmc2410.d2410_emg_stop();
                    Thread.Sleep(5);
                }
            });
        }

        private void btnGoHome_Click(object sender, EventArgs e)
        {
            ushort mode = (ushort)(radGoHomeMode0.Checked ? 0 : (radGoHomeMode2.Checked ? 2 : 3));
            if (chkXAxis.Checked)
            {
                Task.Run(() =>
                {
                    GoHome(0, mode, 1000);
                });
            }

            if (chkYAxis.Checked)
            {
                Task.Run(() =>
                {
                    GoHome(1, mode, 1000);
                });
            }

            if (chkZAxis.Checked)
            {
                Task.Run(() =>
                {
                    GoHome(2, mode, 1000);
                });
            }

        }


        /// <summary>
        /// 回原点
        /// </summary>
        /// <param name="axisNum"></param>
        /// <param name="mode"></param>
        /// <param name="speed"></param>

        private bool AxisExceptionStop { get; set; }  //轴异常停止
        private void GoHome(ushort axisNum, ushort mode, double speed = 2000)
        {
            //axisNum: 轴编号
            //org_logic org信号的有效点平 0：低电平有效(外接常闭) 1：高电平有效
            //filter 允许/禁止滤波功能 0：禁止 1：允许
            Dmc2410.d2410_set_HOME_pin_logic(axisNum, 0, 1);

            //axisNum: 轴编号
            //mode: 轴回原点模式 0：只计home 2：一次回零加回找 3：两次回零
            Dmc2410.d2410_config_home_mode(axisNum, mode, 1);

            //设置速度曲线
            Dmc2410.d2410_set_profile(axisNum, 100, speed, 0.1, 0.1);

            //axisNum: 轴编号
            //home_mode: 轴回原点模式 1:正方向回原点 2:负方向回原点
            //vel_mode: 速度模式 0:低速 1：高速
            Dmc2410.d2410_home_move(axisNum, 2, 1);

            while (true)  //阻塞 等待脉冲停止(认为回原点完成了)
            {
                if (Dmc2410.d2410_check_done(axisNum) == 1) { break; }
                Thread.Sleep(200);
            }

            if (AxisExceptionStop) { return; }  //轴异常停止,就不往轴位置写0了
            Dmc2410.d2410_set_position(axisNum, 0); //设置轴位置为0
        }

        /// <summary>
        /// 两轴直线插补
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLine2_Click(object sender, EventArgs e)
        {
            //设置插补运动速度曲线
            Dmc2410.d2410_set_vector_profile(0, 1000, 0.1, 0.1);

            int xDist = int.Parse(txtLine2X.Text);
            int yDist = int.Parse(txtLine2Y.Text);
            ushort posi_mode = (ushort)(radRelativelySel.Checked ? 0 : 1);

            /*
             * axis1 指定两轴插补的第一轴
             * axis2 轴插补的第二轴
             * Dist1 第一轴插补的距离 单位 pulse
             * Dist2 第二轴插补的距离 单位 pulse
             * posi_mode 轴插补模式(运动模式) 0:相对坐标模式 1:绝对坐标模式
             */
            Dmc2410.d2410_t_line2(0, xDist, 1, yDist, posi_mode);
        }


        /// <summary>
        /// 三轴直线插补
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLine3_Click(object sender, EventArgs e)
        {
            
            
            
            //设置插补运动速度曲线
            Dmc2410.d2410_set_vector_profile(0, 2000, 0.1, 0.1);

            int xDist = int.Parse(txtLine3X.Text);
            int yDist = int.Parse(txtLine3Y.Text);
            int zDist = int.Parse(txtLine3Z.Text);
            ushort posi_mode = (ushort)(radRelativelySel.Checked ? 0 : 1);

            /*
             * axis1 指定两轴插补的第一轴
             * axis2 轴插补的第二轴
             * Dist1 第一轴插补的距离 单位 pulse
             * Dist2 第二轴插补的距离 单位 pulse
             * posi_mode 轴插补模式(运动模式) 0:相对坐标模式 1:绝对坐标模式
             */
            Dmc2410.d2410_t_line3(new ushort[] { 0, 1, 2 }, xDist, yDist, zDist, posi_mode);
        }


        /// <summary>
        /// 圆弧插补
        /// //是否是个半圆和两个轴的脉冲当量有关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArcMove_Click(object sender, EventArgs e)
        {
            //设置插补运动速度曲线
            Dmc2410.d2410_set_vector_profile(0, 2000, 0.1, 0.1);

            int xDist = int.Parse(txtArcMoveX.Text);
            int yDist = int.Parse(txtArcMoveY.Text);
            ushort dir = (ushort)cmbArcDir.SelectedIndex;

            if (radRelativelySel.Checked)   //相对坐标模式
            {
                //绘制半圆
                Dmc2410.d2410_rel_arc_move(new ushort[] { 0, 1 },     //轴号列表
                                            new int[] { xDist, yDist }, //目标相对位置
                                            new int[] { xDist / 2, yDist / 2 },  //圆心相对位置
                                            dir);      //圆弧方向 0:顺时针 1:逆时针
            }
            else   //绝对坐标模式
            {
                int xpos = Dmc2410.d2410_get_position(0);
                int ypos = Dmc2410.d2410_get_position(1);

                //绘制半圆
                Dmc2410.d2410_arc_move(new ushort[] { 0, 1 },  //轴号列表
                                        new int[] { xpos, ypos }, //目标绝对位置
                                        new int[] { (xpos + xDist) / 2, (ypos + yDist) / 2 },  //圆心绝对位置
                                        dir);   //圆弧方向 0:顺时针 1:逆时针
            } 

        }


        /// <summary>
        /// 设置比较器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComporeConfig_Click(object sender, EventArgs e)
        {
            /*执行位置比较时
             *每个比较点的触发
             */
            
            
            
            //参数： card 卡号
            //queue 比较队列号，取值范围0~1
            //enable 比较功能状态， 0：禁止比较功能 1：使能比较功能
            //axis 指定轴号，取值范围0~3
            //cmp_source 比较源 0：比较指令位置 1：比较编码器位置
            Dmc2410.d2410_compare_config_Extern(0, 0, 1, 0, 0);
        }

        private void btnComporeClear_Click(object sender, EventArgs e)
        {

            //功能 清除所有比较点
            //参数 card 卡号 queue 比较队列号 取值范围0~1
            Dmc2410.d2410_compare_clear_points_Extern(0, 0);
        }

        /// <summary>
        /// 获取当前比较点位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCurrentComparePoint_Click(object sender, EventArgs e)
        {
            //功能 获取当前比较点位置
            //参数 card 卡号 queue 队列号 取值范围0~1
            //返回值 当前比较点位置值
            int res = Dmc2410.d2410_compare_get_current_point_Extern(0, 0);
            txtCompareGetCurrent.Text = res.ToString();
        }


        /// <summary>
        /// 已比较点数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComporePointsCount_Click(object sender, EventArgs e)
        {   
            //功能 查询已经比较过得点个数
            //参数 card 卡号 queue 比较队列号 取值范围0~1
            //返回值 已经比较过的点个数
            var res = Dmc2410.d2410_compare_get_points_runned_Extern(0, 0);
            txtComporePointsCount.Text = res.ToString();
        }

        /// <summary>
        /// 可加入点数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemainingPoints_Click(object sender, EventArgs e)
        {   
            //功能 查询可加入比较点数量
            //参数 card 卡号 queue 队列号 取值范围0~1
            //返回值 剩余可用的比较点数量
            int res = Dmc2410.d2410_compare_get_points_remained_Extern(0, 0);
            txtRemainingPoints.Text = res.ToString();
        }

        /// <summary>
        /// <summary>
        /// 添加比较点
        /// </summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompareAdd_Click(object sender, EventArgs e)
        {
            //每组最多添加8个比较点
            for (int i = 0; i < dgvDisplay.Rows.Count - 1; i++)
            {
                //位置坐标
                uint pos = uint.Parse(dgvDisplay.Rows[i].Cells[0].Value.ToString());

                //dir 比较方向 0：小于等于 1：大于等于
                //action 比较点触发功能 3==》取反IO 此时，对应的动作参数actpara就是输出的位号
                uint actparea = uint.Parse(dgvDisplay.Rows[i].Cells[1].Value.ToString());
                Dmc2410.d2410_compare_add_point_Extern(0, 0, pos, 1, 3, actparea);
            }
        }

        /// <summary>
        /// 清除表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
