using csDmc2410;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 雷赛运动控制卡类
    /// </summary>
    public class LeiSaiCard : MotionCard
    {
        /// <summary>
        /// Jog负方向运动
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="highorlow">高速(true)或低速(false)</param>
        public override void AxisNegativeDirMove(Axis ax, bool highorlow)
        {
            try
            {
                double runSpeed = highorlow ? ax.Speed_JogHigh * ax.PulseEquivalent :
                                          ax.Speed_JogLow * ax.PulseEquivalent;


                uint error1 = Dmc2410.d2410_set_profile(ax.Axis_Num,
                                           ax.Speed_JogStart * ax.PulseEquivalent,
                                           runSpeed,
                                           ax.Speed_JogAccTime,
                                           ax.Speed_JogDecTime);

                if (error1 != 0 && error1 != 4) //4 ：控制卡状态忙  这里认为返回4不是错误
                { throw new Exception($"{ax.Axis_Name}Jog负方向运动设置运动曲线发生异常：错误代码" + error1); }

                uint error2 = Dmc2410.d2410_t_vmove(ax.Axis_Num, 0);

                if (error2 != 0 && error2 != 4)//0和4认为没有问题，如果不是0和4抛异常
                { throw new Exception($"{ax.Axis_Name}Jog负方向持续运行发生异常：错误代码" + error2); }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 读取实时位置
        /// </summary>
        /// <param name="ax"></param>
        /// <returns>工程量（mm 或者 °）</returns>
        public override double AxisPosGet(Axis ax)
        {
            try
            {
                ax.Position = Dmc2410.d2410_get_position(ax.Axis_Num) / ax.PulseEquivalent;
                return ax.Position;
            }
            catch (AccessViolationException)
            {
                return 0;
            }
        }

        /// <summary>
        /// Jog正方向运动
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="highorlow">高速或低速</param>
        public override void AxisPositiveDirMove(Axis ax, bool highorlow)
        {
            try
            {
                double runSpeed = highorlow ? ax.Speed_JogHigh * ax.PulseEquivalent :
                                           ax.Speed_JogLow * ax.PulseEquivalent;

                uint error1 = Dmc2410.d2410_set_profile(ax.Axis_Num,
                                         ax.Speed_JogStart * ax.PulseEquivalent,
                                         runSpeed,
                                         ax.Speed_JogAccTime,
                                         ax.Speed_JogDecTime);
                if (error1 != 0 && error1 != 4)
                { throw new Exception($"{ax.Axis_Name}jog正方向运动设置运动曲线发生异常：错误代码" + error1); }

                uint error2 = Dmc2410.d2410_t_vmove(ax.Axis_Num, 1);
                if (error2 != 0 && error2 != 4)
                { throw new Exception($"{ax.Axis_Name}Jog正方向持续运行发生异常：错误代码" + error2); }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 轴停止
        /// </summary>
        /// <param name="ax">轴</param>
        public override void AxisStop(Axis ax)
        {
            try
            {
                uint error1 = Dmc2410.d2410_imd_stop(ax.Axis_Num);
                if (error1 != 0)
                { throw new Exception($"{ax.Axis_Name}轴停止发生异常：错误代码" + error1); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 关闭卡
        /// </summary>
        public override void CloseCard()
        {
            try
            {
                uint error1 = Dmc2410.d2410_board_close();
                if (error1 != 0)
                { throw new Exception($"关闭控制卡发生异常：错误代码" + error1); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 急停
        /// </summary>
        public override void PressEstop()
        {
            try
            {
                Axis.EmgMark = true;//急停标志接通                
                uint error1 = Dmc2410.d2410_emg_stop();
                if (error1 != 0)
                { throw new Exception($"急停发生异常：错误代码" + error1); }

                Task.Run(() =>
                {
                    while (Axis.EmgMark)
                    {
                        Dmc2410.d2410_emg_stop();
                        Thread.Sleep(2);
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 松开急停
        /// </summary>
        public override void LoosenEstop()
        {
            Axis.EmgMark = false;
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public override void PressPause()
        {
            try
            {
                Axis.PauseMark = true;//暂停标志接通                
                uint error1 = Dmc2410.d2410_emg_stop();
                if (error1 != 0)
                { throw new Exception($"急停发生异常：错误代码" + error1); }

                Task.Run(() =>
                {
                    while (Axis.PauseMark)
                    {
                        Dmc2410.d2410_emg_stop();
                        Thread.Sleep(2);
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 急停复位
        /// </summary>
        public override void LoosenPause()
        {
            Axis.PauseMark = false;
        }

        /// <summary>
        /// 回原点
        /// </summary>
        /// <param name="ax">轴</param>
        public override void GoHome(Axis ax)
        {
            try
            {
                uint error1 = Dmc2410.d2410_set_profile(ax.Axis_Num,
                                           ax.Speed_homeStart * ax.PulseEquivalent,
                                           ax.Speed_homeMax * ax.PulseEquivalent,
                                           ax.Speed_homeAccTime,
                                           ax.Speed_homeDecTime);
                if (error1 != 0)
                { throw new Exception($"回原点设置曲线发生异常：错误代码" + error1); }

                //org_logic ORG 信号的有效电平，0：低电平有效，1：高电平有效
                uint error2 = Dmc2410.d2410_set_HOME_pin_logic(ax.Axis_Num, 0, 1);
                if (error2 != 0)
                { throw new Exception($"回原点设置ORG信号的有效电平，以及允许/禁止滤波功能发生异常：错误代码" + error2); }

                uint error3 = Dmc2410.d2410_config_home_mode(ax.Axis_Num, ax.Home_Mode, 1);
                if (error3 != 0)
                { throw new Exception($"回原点设定指定轴的回原点模式发生异常：错误代码" + error3); }

                //home_mode 回原点方式，1：正方向回原点，2：负方向回原点
                //vel_mode 回原点速度，0：低速回原点，1：高速回原点
                uint error4 = Dmc2410.d2410_home_move(ax.Axis_Num, ax.Home_dir, ax.Home_speedSel);

                if (error4 != 0)
                { throw new Exception($"单轴回原点运动发生异常：错误代码" + error4); }

                ax.OverGoHomeMark = false;
                while (true) //阻塞
                {
                    if (Dmc2410.d2410_check_done(ax.Axis_Num) == 1) { break; }
                    Thread.Sleep(2);
                }

                //非正常停止
                if (ax.ExceptionStop) { return; }
                if (Axis.EmgMark) { return; }

                Dmc2410.d2410_set_position(ax.Axis_Num, 0);
                ax.OverGoHomeMark = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 两轴直线插补绝对运动
        /// </summary>
        /// <param name="Ax1">轴1</param>
        /// <param name="dst1">轴1位置(工程量 mm  °)</param>
        /// <param name="Ax2">轴2</param>
        /// <param name="dst2">轴2位置(工程量 mm  °)</param>
        public override void Line2AbsoluteMove(Axis Ax1, double dst1, Axis Ax2, double dst2)
        {
            try
            {
                //两轴插补以第一个轴速度为准
                uint error1 = Dmc2410.d2410_set_vector_profile(Ax1.Speed_autoStart * Ax1.PulseEquivalent,
                                            Ax1.Speed_autoMax * Ax1.PulseEquivalent,
                                            Ax1.Speed_autoAccTime,
                                            Ax1.Speed_autoDecTime);
                if (error1 != 0)
                { throw new Exception($"设定插补运动速度曲线发生异常：错误代码" + error1); }

                uint error2 = Dmc2410.d2410_t_line2(Ax1.Axis_Num,
                                        (int)(dst1 * Ax1.PulseEquivalent),
                                         Ax2.Axis_Num,
                                         (int)(dst2 * Ax2.PulseEquivalent),
                                         1);
                

                if (error2 != 0)
                { throw new Exception($"两轴插补运动发生异常：错误代码" + error2); }

                while (true) //阻塞
                {
                    if (Dmc2410.d2410_check_done(Ax1.Axis_Num) == 1 &&
                        Dmc2410.d2410_check_done(Ax2.Axis_Num) == 1)
                    { break; }
                    Thread.Sleep(2);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        /// <summary>
        /// 三轴直线插补
        /// </summary>
        /// <param name="Ax1">第一个轴</param>
        /// <param name="dst1">第一个轴绝对位置</param>
        /// <param name="Ax2">第二个轴</param>
        /// <param name="dst2">第二个轴绝对位置</param>
        /// <param name="Ax3">第三个轴</param>
        /// <param name="dst3">第三个轴绝对位置</param>
        public override void Line3AbsoluteMove(Axis Ax1, double dst1, Axis Ax2, double dst2, Axis Ax3, double dst3)
        {
            try
            {
                //两轴插补以第一个轴速度为准
                uint error1 = Dmc2410.d2410_set_vector_profile(Ax1.Speed_autoStart * Ax1.PulseEquivalent,
                                            Ax1.Speed_autoMax * Ax1.PulseEquivalent,
                                            Ax1.Speed_autoAccTime,
                                            Ax1.Speed_autoDecTime);
                if (error1 != 0)
                { throw new Exception($"设定插补运动速度曲线发生异常：错误代码" + error1); }

                uint error2 = Dmc2410.d2410_t_line3(new ushort[] { Ax1.Axis_Num, Ax2.Axis_Num, Ax3.Axis_Num },
                                         (int)(dst1 * Ax1.PulseEquivalent),
                                         (int)(dst2 * Ax2.PulseEquivalent),
                                         (int)(dst3 * Ax3.PulseEquivalent),
                                         1);

                if (error2 != 0)
                { throw new Exception($"三轴插补运动发生异常：错误代码" + error2); }

                while (true) //阻塞
                {
                    if (Dmc2410.d2410_check_done(Ax1.Axis_Num) == 1 &&
                        Dmc2410.d2410_check_done(Ax2.Axis_Num) == 1 &&
                        Dmc2410.d2410_check_done(Ax3.Axis_Num) == 1)
                    { break; }
                    Thread.Sleep(2);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        /// <summary>
        /// 两轴直线插补相对运动
        /// </summary>
        /// <param name="Ax1">轴1</param>
        /// <param name="dst1">轴1位置</param>
        /// <param name="Ax2">轴2</param>
        /// <param name="dst2">轴2位置</param>
        public override void Line2RelativelyMove(Axis Ax1, double dst1, Axis Ax2, double dst2)
        {
            try
            {
                //两轴插补以第一个轴速度为准
                uint error1 = Dmc2410.d2410_set_vector_profile(Ax1.Speed_autoStart * Ax1.PulseEquivalent,
                                            Ax1.Speed_autoMax * Ax1.PulseEquivalent,
                                            Ax1.Speed_autoAccTime,
                                            Ax1.Speed_autoDecTime);
                if (error1 != 0)
                { throw new Exception($"设定插补运动速度曲线发生异常：错误代码" + error1); }

                uint error2 = Dmc2410.d2410_t_line2(Ax1.Axis_Num,
                                        (int)(dst1 * Ax1.PulseEquivalent),
                                         Ax2.Axis_Num,
                                         (int)(dst2 * Ax2.PulseEquivalent),
                                         0);

                if (error2 != 0)
                { throw new Exception($"两轴插补运动发生异常：错误代码" + error2); }

                while (true)
                {
                    if (Dmc2410.d2410_check_done(Ax1.Axis_Num) == 1 &&
                        Dmc2410.d2410_check_done(Ax2.Axis_Num) == 1)
                    { break; }
                    Thread.Sleep(2);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 初始化运动控制卡
        /// </summary>
        public override void OpenCard()
        {
            try
            {
                ushort error1 = Dmc2410.d2410_board_init();
                if (error1 == 0)
                {
                    throw new Exception("没有找到控制卡，或者控制卡异常!");
                }
                else if (error1 < 0)
                {
                    throw new Exception("有 2 张或 2 张以上控制卡的硬件设置卡号相同!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 绝对运动
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="dist">绝对距离</param>
        public override void PtPAbsoluteMove(Axis ax, double dist)
        {
            try
            {
                uint error1 = Dmc2410.d2410_set_profile(ax.Axis_Num,
                                           ax.Speed_autoStart * ax.PulseEquivalent,
                                           ax.Speed_autoMax * ax.PulseEquivalent,
                                           ax.Speed_autoAccTime,
                                           ax.Speed_autoDecTime);
                if (error1 != 0 && error1 != 4)
                { throw new Exception($"{ax.Axis_Name}绝对运动设置曲线发生异常：" + error1); }

                uint error2 = Dmc2410.d2410_t_pmove(ax.Axis_Num,
                                                   (int)(dist * ax.PulseEquivalent),
                                                    1);
                if (error2 != 0 && error2 != 4)
                { throw new Exception($"{ax.Axis_Name}绝对点位运动发生异常：" + error2); }

                while (true)
                {
                    if (Dmc2410.d2410_check_done(ax.Axis_Num) == 1)
                    { break; }
                    Thread.Sleep(2);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 微动
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="speed">速度</param>
        /// <param name="dist">微动距离</param>
        public override void MicroMove(Axis ax, double speed, double dist)
        {
            try
            {
                uint error1 = Dmc2410.d2410_set_profile(ax.Axis_Num,
                                           0,
                                           speed * ax.PulseEquivalent,
                                           0.1,
                                           0.1);
                if (error1 != 0)
                { throw new Exception($"{ax.Axis_Name}微动运动设置曲线发生异常：" + error1); }

                uint error2 = Dmc2410.d2410_t_pmove(ax.Axis_Num,
                                                   (int)(dist * ax.PulseEquivalent),
                                                    0);
                if (error2 != 0)
                { throw new Exception($"{ax.Axis_Name}微动运动发生异常：" + error2); }

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 脉冲输出模式设置
        /// </summary>
        /// <param name="ax">脉冲轴</param>
        public override void PulseModeSet(Axis axs)
        {
            Dmc2410.d2410_set_pulse_outmode(axs.Axis_Num, axs.PulseOutMode);
        }

        /// <summary>
        /// 读取轴报警
        /// </summary>
        /// <param name="ax">轴</param>
        /// <returns>状态 true：报警  false：无报警</returns>
        public override bool ReadAlarm(Axis ax)
        {
            try
            {
                ushort res = Dmc2410.d2410_axis_io_status(ax.Axis_Num);

                ax.FaultAlrm = (res & (int)Math.Pow(2, 11)) != 0;

                return ax.FaultAlrm;
            }
            catch (AccessViolationException)
            {
                return false;
            }

        }


        /// <summary>
        /// 读取输入位状态
        /// </summary>
        /// <param name="bitNo">输入位号</param>
        /// <returns>状态 true：通  false：断</returns>
        public override bool ReadInBit(Axis ax, ushort bitNo)
        {
            try
            {
                int res = Dmc2410.d2410_read_inbit(ax.Axis_CardNo, bitNo);

                return res == 0;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// 读取负限位信号
        /// </summary>
        /// <param name="ax">轴</param>
        /// <returns>状态 true：碰到负限位   false：没有碰到</returns>
        public override bool ReadNegativeLimit(Axis ax)
        {
            try
            {
                ushort res = Dmc2410.d2410_axis_io_status(ax.Axis_Num);
                ax.NegativeLimit = (res & (int)Math.Pow(2, 13)) != 0;
                return ax.NegativeLimit;
            }
            catch (AccessViolationException)
            {
                return false;
            }
        }

        /// <summary>
        /// 读取轴原点信号
        /// </summary>
        /// <param name="ax">轴</param>
        /// <returns>状态 true：碰到原点   false：没有碰到</returns>
        public override bool ReadOrg(Axis ax)
        {
            try
            {
                ushort res = Dmc2410.d2410_axis_io_status(ax.Axis_Num);
                ax.Org = (res & (int)Math.Pow(2, 14)) != 0;
                return ax.Org;
            }
            catch (AccessViolationException)
            {
                return false;
            }
        }

        /// <summary>
        /// 读取输出位状态
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="bitNo">位号</param>
        /// <returns>状态  True：通，false：断</returns>
        public override bool ReadOutBit(Axis ax, ushort bitNo)
        {
            try
            {
                int res = Dmc2410.d2410_read_outbit(ax.Axis_CardNo, bitNo);

                return res == 0;
            }
            catch (AccessViolationException)
            {
                return false;
            }

        }

        /// <summary>
        /// 读取正限位信号
        /// </summary>
        /// <param name="ax">轴</param>
        /// <returns>状态 true：碰到正限位   false：没有碰到</returns>
        public override bool ReadPositiveLimit(Axis ax)
        {
            try
            {
                ushort res = Dmc2410.d2410_axis_io_status(ax.Axis_Num);
                ax.PositiveLimit = (res & (int)Math.Pow(2, 12)) != 0;
                return ax.PositiveLimit;
            }
            catch (AccessViolationException)
            {
                return false;
            }
        }

        /// <summary>
        /// 轴运行状态检测
        /// </summary>
        /// <param name="axNum">轴号</param>
        /// <returns>轴状态 true：运行  false：停止</returns>
        public override bool RunningStatus(Axis ax)
        {
            try
            {
                ax.IsRunning = Dmc2410.d2410_check_done(ax.Axis_Num) == 0;
                return ax.IsRunning;
            }
            catch (AccessViolationException)
            {
                return false;
            }
        }


        /// <summary>
        /// 设置软限位
        /// </summary>
        /// <param name="ax">轴对象</param>
        /// <param name="enanle">True:设置软限位  False：禁止软限位</param>
        public override void SoftLimitSet(Axis ax, bool enanle)
        {
            //这是雷赛卡的软限位设置方法，不同卡设置不一样！！！！
            //ON_OFF 使能状态，0：禁止，1：允许
            //source_sel 保留参数，固定值为 0
            //SL_action 限位制动方式：0：立即停止，1：减速停止
            //N_limit 负限位脉冲数
            //P_limit 正限位脉冲数
            ushort numEnanle = (ushort)(enanle ? 1 : 0);
            Dmc2410.d2410_config_softlimit(ax.Axis_Num,
                                          numEnanle, 0, 1,
                                          (int)(ax.SoftLimit_N * ax.PulseEquivalent),
                                          (int)(ax.SoftLimit_P * ax.PulseEquivalent));

            //正、负限位位置可为正数也可为负数，但正限位位置应大于负限位位置
        }

        /// <summary>
        /// 控制位输出信号
        /// </summary>
        /// <param name="bitNo">输出位号</param>
        /// <param name="val">通(true)_断(false)</param>
        public override void WriteOutBit(Axis ax, ushort bitNo, bool val)
        {
            try
            {
                uint error1 = Dmc2410.d2410_write_outbit(ax.Axis_CardNo, bitNo, (ushort)(val ? 0 : 1));
                if (error1 != 0)
                { throw new Exception($"{ax.Axis_Name} 控制输出信号发生异常：" + error1); }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 读取运行速度
        /// </summary>
        /// <param name="ax">轴对象</param>
        /// <returns>速度值（单位：mm/s 或 °/s）</returns>
        public override double ReadRunningSpeed(Axis ax)
        {
            ax.RunningSpeed = Dmc2410.d2410_read_current_speed(ax.Axis_Num) / ax.PulseEquivalent;
            return ax.RunningSpeed;
        }


    }
}
