using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csLTDMC;
using System.Threading;

namespace DAL
{
   public class LeiSaiCard5410 : MotionCard
    {
        /// <summary>
        /// Jog负向移动
        /// </summary>
        /// <param name="ax"></param>
        /// <param name="highorlow"></param>
        public override void AxisNegativeDirMove(Axis ax, bool highorlow)
        {
            try
            {
                double runSpeed = highorlow ? ax.Speed_JogHigh * ax.PulseEquivalent : ax.Speed_JogLow * ax.PulseEquivalent;
                short error1 = LTDMC.dmc_set_profile_unit(ax.Axis_CardNo, ax.Axis_Num, ax.Speed_JogStart * ax.PulseEquivalent, runSpeed,
                                                  ax.Speed_JogAccTime,ax.Speed_JogDecTime,2);
                if(error1!=0)
                { throw new Exception($"{ax.Axis_Name}Jog负方向运动设置运动曲线发生异常：错误代码" + error1); }
                short error2 = LTDMC.dmc_set_s_profile(ax.Axis_CardNo, ax.Axis_Num, 0, 0.01);
                if (error2 != 0)
                { throw new Exception($"{ax.Axis_Name}Jog负方向运动设置运动曲线发生异常：错误代码" + error2); }
                short error3 = LTDMC.dmc_vmove(ax.Axis_CardNo, ax.Axis_Num, 0);
                if (error3 != 0)
                { throw new Exception($"{ax.Axis_Name}Jog负方向运动设置运动曲线发生异常：错误代码" + error3); }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 读取实时位置
        /// </summary>
        /// <param name="ax"></param>
        /// <returns></returns>
        public override double AxisPosGet(Axis ax)
        {
            try
            {
                ax.Position = LTDMC.dmc_get_position(ax.Axis_CardNo,ax.Axis_Num)/ax.PulseEquivalent;
                return ax.Position;
            }
            catch (AccessViolationException)
            {
                return 0;
            }
        }
        /// <summary>
        /// Jog正向移动
        /// </summary>
        /// <param name="ax"></param>
        /// <param name="highorlow"></param>
        public override void AxisPositiveDirMove(Axis ax, bool highorlow)
        {
            try
            {
                double runSpeed = highorlow ? ax.Speed_JogHigh * ax.PulseEquivalent : ax.Speed_JogLow * ax.PulseEquivalent;
                short error1 = LTDMC.dmc_set_profile_unit(ax.Axis_CardNo, ax.Axis_Num, ax.Speed_JogStart * ax.PulseEquivalent, runSpeed,
                                                  ax.Speed_JogAccTime, ax.Speed_JogDecTime, 2);
                if (error1 != 0)
                { throw new Exception($"{ax.Axis_Name}Jog负方向运动设置运动曲线发生异常：错误代码" + error1); }
                short error2 = LTDMC.dmc_set_s_profile(ax.Axis_CardNo, ax.Axis_Num, 0, 0.01);
                if (error2 != 0)
                { throw new Exception($"{ax.Axis_Name}Jog负方向运动设置运动曲线发生异常：错误代码" + error2); }
                short error3 = LTDMC.dmc_vmove(ax.Axis_CardNo, ax.Axis_Num, 1);
                if (error3 != 0)
                { throw new Exception($"{ax.Axis_Name}Jog负方向运动设置运动曲线发生异常：错误代码" + error3); }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 轴停止
        /// </summary>
        /// <param name="ax"></param>
        public override void AxisStop(Axis ax)
        {
            try
            {
                short error1 = LTDMC.dmc_stop(ax.Axis_CardNo, ax.Axis_Num, 0);
                if (error1 != 0)
                { throw new Exception($"{ax.Axis_Name}Jog负方向运动设置运动曲线发生异常：错误代码" + error1); }
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        /// <summary>
        /// 关闭卡
        /// </summary>
        public override void CloseCard()
        {
            try
            {
                short error1 = LTDMC.dmc_board_close();
                if (error1 != 0)
                { throw new Exception($"关闭运动卡发生异常：错误代码" + error1); }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        /// <summary>
        /// 回原点
        /// </summary>
        /// <param name="ax"></param>
        public override void GoHome(Axis ax)
        {
            try
            {
                short error1 = LTDMC.dmc_set_profile(ax.Axis_CardNo, ax.Axis_Num, ax.Speed_homeStart * ax.PulseEquivalent, ax.Speed_homeMax * ax.PulseEquivalent,
                                               ax.Speed_homeAccTime, ax.Speed_homeDecTime, 2);
                if (error1 != 0)
                { throw new Exception($"回原点设置曲线发生异常：错误代码" + error1); }
                short error2 = LTDMC.dmc_set_home_pin_logic(ax.Axis_CardNo, ax.Axis_Num, 0, 0);
                    if (error2 != 0)
                { throw new Exception($"回原点设置ORG信号的有效电平，以及允许/禁止滤波功能发生异常：错误代码" + error2); }
                short error3 = LTDMC.dmc_set_homemode(ax.Axis_CardNo, ax.Axis_Num, ax.Home_dir, ax.Home_speedSel, ax.Home_Mode, 0);//设置回零模式
                if (error3 != 0)
                { throw new Exception($"回原点设定指定轴的回原点模式发生异常：错误代码" + error3); }
                short error4 = LTDMC.dmc_home_move(ax.Axis_CardNo,ax.Axis_Num);//启动回零
                if (error4 != 0)
                { throw new Exception($"单轴回原点运动发生异常：错误代码" + error4); }
                ax.OverGoHomeMark = false;
                while (true) //阻塞
                {
                    if (LTDMC.dmc_check_done(ax.Axis_CardNo,ax.Axis_Num) == 1) { break; }
                    Thread.Sleep(2);
                }

                //非正常停止
                if (ax.ExceptionStop) { return; }
                if (Axis.EmgMark) { return; }
               
                LTDMC.dmc_set_position(ax.Axis_CardNo,ax.Axis_Num, 0);
                ax.OverGoHomeMark = true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 两轴直线插补绝对
        /// </summary>
        /// <param name="Ax1"></param>
        /// <param name="dst1"></param>
        /// <param name="Ax2"></param>
        /// <param name="dst2"></param>
        public override void Line2AbsoluteMove(Axis Ax1, double dst1, Axis Ax2, double dst2)
        {
            try
            {
                ushort[] ax = new ushort[] { (ushort)Ax1.Axis_Num, (ushort)Ax2.Axis_Num };
                double[] dst = new double[] { dst1 * Ax1.PulseEquivalent, dst2 * Ax2.PulseEquivalent };
                short error1 = LTDMC.dmc_set_vector_profile_unit(Ax1.Axis_CardNo, 0, Ax1.Speed_autoStart * Ax1.PulseEquivalent,
                                            Ax1.Speed_autoMax * Ax1.PulseEquivalent, Ax1.Speed_autoAccTime, Ax1.Speed_autoDecTime, 2);
                if (error1 != 0)
                { throw new Exception($"设定插补运动速度曲线发生异常：错误代码" + error1); }
                short error2 = LTDMC.dmc_line_unit(Ax1.Axis_CardNo, 0, 2, ax, dst, 1);
                if (error2 != 0)
                { throw new Exception($"两轴插补运动发生异常：错误代码" + error2); }
                while (true) //阻塞
                {
                    if (LTDMC.dmc_check_done_multicoor(Ax1.Axis_CardNo, 0) == 1) { break; }
                    Thread.Sleep(2);
                }

            }
            catch (Exception)
            {

                throw;
            }
           
        }
        /// <summary>
        /// 两轴直线插补相对运动
        /// </summary>
        /// <param name="Ax1"></param>
        /// <param name="dst1"></param>
        /// <param name="Ax2"></param>
        /// <param name="dst2"></param>
        public override void Line2RelativelyMove(Axis Ax1, double dst1, Axis Ax2, double dst2)
        {
            throw new NotImplementedException();

        }
        /// <summary>
        /// 三轴直线插补
        /// </summary>
        /// <param name="Ax1"></param>
        /// <param name="dst1"></param>
        /// <param name="Ax2"></param>
        /// <param name="dst2"></param>
        /// <param name="Ax3"></param>
        /// <param name="dst3"></param>
        public override void Line3AbsoluteMove(Axis Ax1, double dst1, Axis Ax2, double dst2, Axis Ax3, double dst3)
        {
            try
            {
                ushort[] ax = new ushort[] { (ushort)Ax1.Axis_Num, (ushort)Ax2.Axis_Num, (ushort)Ax3.Axis_Num };
                double[] dst = new double[] { dst1 * Ax1.PulseEquivalent, dst2 * Ax2.PulseEquivalent, dst3 * Ax3.PulseEquivalent };
                short error1 = LTDMC.dmc_set_vector_profile_unit(Ax1.Axis_CardNo, 0, Ax1.Speed_autoStart * Ax1.PulseEquivalent,
                                            Ax1.Speed_autoMax * Ax1.PulseEquivalent, Ax1.Speed_autoAccTime, Ax1.Speed_autoDecTime, 2);
                if (error1 != 0)
                { throw new Exception($"设定插补运动速度曲线发生异常：错误代码" + error1); }
                short error2 = LTDMC.dmc_line_unit(Ax1.Axis_CardNo, 0, 3, ax, dst, 1);
                if (error2 != 0)
                { throw new Exception($"两轴插补运动发生异常：错误代码" + error2); }
                while (true) //阻塞
                {
                    if (LTDMC.dmc_check_done_multicoor(Ax1.Axis_CardNo, 0) == 1) { break; }
                    Thread.Sleep(2);
                }

            }
            catch (Exception)
            {

                throw;
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
        /// 松开暂停
        /// </summary>
        public override void LoosenPause()
        {
            Axis.PauseMark = false;
        }
        /// <summary>
        /// 微动
        /// </summary>
        /// <param name="ax"></param>
        /// <param name="speed"></param>
        /// <param name="dist"></param>
        public override void MicroMove(Axis ax, double speed, double dist)
        {
            try
            {
                short error1 = LTDMC.dmc_set_profile_unit(ax.Axis_CardNo,ax.Axis_Num,ax.Speed_JogLow*ax.PulseEquivalent,
                                                                           speed * ax.PulseEquivalent, 0.1,0.1,0);
                if (error1 != 0)
                { throw new Exception($"{ax.Axis_Name}微动运动设置曲线发生异常：" + error1); }

                short error2 = LTDMC.dmc_pmove_unit(ax.Axis_CardNo, ax.Axis_Num,
                                                   (int)(dist * ax.PulseEquivalent), 0);
                if (error2 != 0)
                { throw new Exception($"{ax.Axis_Name}微动运动发生异常：" + error2); }

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 初始化运动卡
        /// </summary>
        public override void OpenCard()
        {
            try
            {
                short error1= LTDMC.dmc_board_init();//获取卡数量
                if (error1 == 0)
                {
                    throw new Exception("没有找到控制卡，或者控制卡异常!");
                }
                else if (error1 < 0)
                {
                    throw new Exception("有 2 张或 2 张以上控制卡的硬件设置卡号相同!");
                }
            }
            catch (Exception)
            {

                throw;
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
                short error1 = LTDMC.dmc_emg_stop(0);
                if (error1 != 0)
                { throw new Exception($"急停发生异常：错误代码" + error1); }

                Task.Run(() =>
                {
                    while (Axis.EmgMark)
                    {
                        LTDMC.dmc_emg_stop(0);
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
        /// 暂停
        /// </summary>
        public override void PressPause()
        {
            try
            {
                Axis.PauseMark = true;//暂停标志接通                
                short error1 = LTDMC.dmc_emg_stop(0);
                if (error1 != 0)
                { throw new Exception($"按下暂停发生异常：错误代码" + error1); }

                Task.Run(() =>
                {
                    while (Axis.PauseMark)
                    {
                        LTDMC.dmc_emg_stop(0);
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
        /// 绝对运动
        /// </summary>
        /// <param name="ax"></param>
        /// <param name="dist"></param>
        public override void PtPAbsoluteMove(Axis ax, double dist)
        {
            try
            {
                short error1 = LTDMC.dmc_set_profile_unit(ax.Axis_CardNo, ax.Axis_Num,
                                         ax.Speed_autoStart * ax.PulseEquivalent,
                                         ax.Speed_autoMax * ax.PulseEquivalent,
                                         ax.Speed_autoAccTime,
                                         ax.Speed_autoDecTime, 1);
                if (error1 != 0)
                { throw new Exception($"{ax.Axis_Name}绝对运动设置曲线发生异常：" + error1); }
                short error2 = LTDMC.dmc_set_s_profile(ax.Axis_CardNo, ax.Axis_Num, 0, 0.01);
                if (error2 != 0)
                { throw new Exception($"{ax.Axis_Name}绝对运动设置曲线发生异常：" + error2); }
                short error3 = LTDMC.dmc_pmove_unit(ax.Axis_CardNo, ax.Axis_Num, (int)dist, 1);
                if (error3 != 0)
                { throw new Exception($"{ax.Axis_Name}绝对点位运动发生异常：" + error3); }
                while (true) //阻塞
                {
                    if (LTDMC.dmc_check_done(ax.Axis_CardNo, ax.Axis_Num) == 1) { break; }
                    Thread.Sleep(2);
                }
            }
            catch (Exception)
            {

                throw;
            }
          


        }
        /// <summary>
        /// 脉冲输出模式
        /// </summary>
        /// <param name="axs"></param>
        public override void PulseModeSet(Axis ax)
        {
            LTDMC.dmc_set_pulse_outmode(ax.Axis_CardNo, ax.Axis_Num, ax.PulseOutMode);
        }
        /// <summary>
        /// 读取轴报警
        /// </summary>
        /// <param name="ax"></param>
        /// <returns></returns>
        public override bool ReadAlarm(Axis ax)
        {
            try
            {
                ushort res = (ushort)(LTDMC.dmc_axis_io_status(ax.Axis_CardNo, ax.Axis_Num));
                ax.PositiveLimit = (res & (int)Math.Pow(2, 0)) != 0;
                return ax.PositiveLimit;
            }
            catch (AccessViolationException)
            {
                return false;
            }
        }
        /// <summary>
        /// 读取输入位状态
        /// </summary>
        /// <param name="ax"></param>
        /// <param name="bitNo"></param>
        /// <returns></returns>
        public override bool ReadInBit(Axis ax, ushort bitNo)
        {
            try
            {
                int res = LTDMC.dmc_read_inbit(ax.Axis_CardNo, bitNo);

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
        /// <param name="ax"></param>
        /// <returns></returns>
        public override bool ReadNegativeLimit(Axis ax)
        {
            try
            {
                ushort res = (ushort)(LTDMC.dmc_axis_io_status(ax.Axis_CardNo, ax.Axis_Num));
                ax.PositiveLimit = (res & (int)Math.Pow(2, 2)) != 0;
                return ax.PositiveLimit;
            }
            catch (AccessViolationException)
            {
                return false;
            }
        }
        /// <summary>
        /// 读取轴原点信号
        /// </summary>
        /// <param name="ax"></param>
        /// <returns></returns>
        public override bool ReadOrg(Axis ax)
        {
            try
            {
                uint res = LTDMC.dmc_axis_io_status(ax.Axis_CardNo, ax.Axis_Num);
                ax.Org = (res & (int)Math.Pow(2, 4)) != 0;
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
        /// <param name="ax"></param>
        /// <param name="bitNo"></param>
        /// <returns></returns>
        public override bool ReadOutBit(Axis ax, ushort bitNo)
        {
            try
            {
                int res = LTDMC.dmc_read_outbit(ax.Axis_CardNo, bitNo);

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
        /// <param name="ax"></param>
        /// <returns></returns>
        public override bool ReadPositiveLimit(Axis ax)
        {
            try
            {
                ushort res = (ushort)(LTDMC.dmc_axis_io_status(ax.Axis_CardNo,ax.Axis_Num));
                ax.PositiveLimit = (res & (int)Math.Pow(2, 1)) != 0;
                return ax.PositiveLimit;
            }
            catch (AccessViolationException)
            {
                return false;
            }
        }
        /// <summary>
        /// 读取运行速度
        /// </summary>
        /// <param name="ax"></param>
        /// <returns></returns>
        public override double ReadRunningSpeed(Axis ax)
        {
            ax.RunningSpeed = LTDMC.dmc_read_current_speed(ax.Axis_CardNo, ax.Axis_Num);
            return ax.RunningSpeed;
        }
        /// <summary>
        /// 轴运行状态
        /// </summary>
        /// <param name="ax"></param>
        /// <returns></returns>
        public override bool RunningStatus(Axis ax)
        {
            try
            {
                ax.IsRunning = LTDMC.dmc_check_done(ax.Axis_CardNo, ax.Axis_Num) == 0;
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
        /// <param name="ax"></param>
        /// <param name="enanle"></param>
        public override void SoftLimitSet(Axis ax, bool enanle)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 控制位输出状态
        /// </summary>
        /// <param name="ax"></param>
        /// <param name="bitNo"></param>
        /// <param name="val"></param>
        public override void WriteOutBit(Axis ax, ushort bitNo, bool val)
        {
            try
            {
                short error1 = LTDMC.dmc_write_outbit(ax.Axis_CardNo, bitNo, (ushort)(val ? 0 : 1));
                if (error1 != 0)
                { throw new Exception($"{ax.Axis_Name} 控制输出信号发生异常：" + error1); }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
