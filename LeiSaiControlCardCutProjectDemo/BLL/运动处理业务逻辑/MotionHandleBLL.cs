using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 运动控制业务逻辑类
    /// </summary>
    public class MotionHandleBLL
    {
        /// <summary>
        /// 控制卡对象
        /// </summary>
        private MotionCard motion = new LeiSaiCard();  //选择的是雷赛DMC2410

        /// <summary>
        /// 线程取消信号
        /// </summary>
        private CancellationTokenSource cts;

        /// <summary>
        /// 实时读取轴数据的任务
        /// </summary>
        private Task realTimeReadTask;


        /// <summary>
        /// 打开控制卡
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool OpenCard(out string res)
        {
            try
            {
                motion.OpenCard();
                res = "打开控制卡成功!";
                return true;
            }
            catch (Exception ex)
            {

                res = "打开控制卡失败！ "+ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 关闭控制卡
        /// </summary>
        public void CloseCard()
        {
            try
            {
                motion.CloseCard();
                
            }
            catch (Exception )
            {
            }
        }


        /// <summary>
        /// X轴向左移动
        /// </summary>
        /// <param name="axis">X轴实体对象</param>
        /// <param name="highorlow">True:高速 False:低速</param>
        /// <param name="res">执行结果信息</param>
        /// <returns>True:执行正常 False:执行异常</returns>
        public bool JogLeftMove(Axis axis, bool highorlow, out string res)
        { 
            try
            { 
                motion.AxisPositiveDirMove(axis, highorlow);
                res = "正在执行Jog左移!";
                return true;
            }
            catch (Exception ex)
            {
                res =ex.Message;
                return false;
            }
        }


        /// <summary>
        /// X轴向右移动
        /// </summary>
        public bool JogRightMove(Axis axis, bool highorlow, out string res)
        {
            try
            {
                motion.AxisNegativeDirMove(axis, highorlow);
                res = "正在执行Jog右移!";
                return true;
            }
            catch (Exception ex)
            {
                res = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// Y轴后退
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="highorlow"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool JogBackAwayMove(Axis axis, bool highorlow, out string res)
        {
            try
            {
                motion.AxisNegativeDirMove(axis, highorlow);
                res = "正在执行Jog后退!";
                return true;
            }
            catch (Exception ex)
            {
                res = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// Y轴前进
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="highorlow"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool JogForwardMove(Axis axis, bool highorlow, out string res)
        {
            try
            {
                motion.AxisPositiveDirMove(axis, highorlow);
                res = "正在执行Jog前进!";
                return true;
            }
            catch (Exception ex)
            {
                res = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// Z轴上升
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="highorlow"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool JogUpMove(Axis axis, bool highorlow, out string res)
        {
            try
            {
                motion.AxisNegativeDirMove(axis, highorlow);
                res = "正在执行Jog上移!";
                return true;
            }
            catch (Exception ex)
            {
                res = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Z轴下降
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="highorlow"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool JogDownMove(Axis axis, bool highorlow, out string res)
        {
            try
            {
                motion.AxisPositiveDirMove(axis, highorlow);
                res = "正在执行Jog下移!";
                return true;
            }
            catch (Exception ex)
            {
                res = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 轴停止
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool AxisStop(Axis axis, out string res)
        {
            try
            {
                motion.AxisStop(axis);
                res = $"{axis.Axis_Name} Jog停止";
                return true;
            }
            catch (Exception ex)
            {
                res = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 微动
        /// </summary>
        /// <param name="axis">要微动的轴对象</param>
        /// <param name="dist">微动距离(单位:mm)</param>
        /// <param name="speed">微动速度</param>
        /// <returns>True:执行正常 False:执行异常</returns>
        public bool MicroMove(Axis axis, double dist, double speed)
        {
            try
            {
                motion.MicroMove(axis, speed, dist);
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        /// <summary>
        /// 实时工艺IO数据
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="iOEntity"></param>
        private void  ReadIO(IOCraftEntity iOEntity)
        { 
            Axis axis = new Axis();
            axis.Axis_CardNo = iOEntity.MaterialSignals.CardNo;
            iOEntity.MaterialSignals.StatusValue = motion.ReadInBit(axis, iOEntity.MaterialSignals.BitNo);

            axis.Axis_CardNo = iOEntity.Cutter.CardNo;
            iOEntity.Cutter.StatusValue = motion.ReadInBit(axis, iOEntity.Cutter.BitNo);
            
        }

        /// <summary>
        /// 实时读取轴数据
        /// </summary>
        /// <param name="iOEntity">IO工艺对象</param>
        /// <param name="axises">轴对象集合</param>
        /// <returns></returns>
        public void RealTimeReadAxisData(IOCraftEntity iOEntity,
                                                    params Axis[] axises)
        { 

            cts = new CancellationTokenSource();

            realTimeReadTask = Task.Run(() =>
            { 
                while (!cts.IsCancellationRequested)
                {

                    foreach (var item in axises)
                    {
                        motion.AxisPosGet(item);
                        motion.ReadRunningSpeed(item);
                        motion.ReadPositiveLimit(item);
                        motion.ReadNegativeLimit(item);
                        motion.ReadOrg(item);
                        motion.RunningStatus(item);
                        motion.ReadAlarm(item);
                    }

                    ReadIO(iOEntity);
                    Thread.Sleep(5);
                }
            }, cts.Token);

        }

        /// <summary>
        /// 停止实时读取
        /// </summary>
        /// <returns></returns>
        public async Task StopRealTimeRead()
        {
            cts?.Cancel();
            await realTimeReadTask;
            cts?.Dispose();
        }

        /// <summary>
        /// 选中轴进行回原点
        /// </summary>
        /// <param name="axis">轴对象</param>
        /// <param name="mode">回原模式</param>
        /// <param name="dir">回原方向</param>
        /// <param name="speedSel">回原速度选择</param>
        public void SelectAxisGoHome(Axis axis, ushort mode, ushort dir, ushort speedSel)
        {
            try
            {
                Task.Run(() =>
                {
                    axis.Home_Mode = mode;
                    axis.Home_dir = dir;
                    axis.Home_speedSel = speedSel;
                    motion.GoHome(axis);
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 一键回原点
        /// </summary>
        /// <param name="axes">一次是XYZ轴对象</param>
        /// <param name="mode">回原模式 0：只计home 2：回零加回找</param>
        /// <param name="dir">回原方向 1：正方向回原 2：负方向回原</param>
        /// <param name="speedSel">0：低速回原 1：高速回原</param>
        public void AllGoHome(Axis[] axes, ushort mode, ushort dir, ushort speedSel)
        {

            //1.Z轴先回原点
            Task tz = Task.Run(() =>
            {
                axes[2].Home_Mode = mode;
                axes[2].Home_dir = dir;
                axes[2].Home_speedSel = speedSel;
                motion.GoHome(axes[2]);

            });


            //2.X轴回原点
            Task.Run(() =>
            {
                tz.Wait(); //阻塞
                if (!axes[2].OverGoHomeMark) { return; }
                axes[0].Home_Mode = mode;
                axes[0].Home_dir = dir;
                axes[0].Home_speedSel = speedSel;
                motion.GoHome(axes[0]);
            });

            //3.Y轴回原点
            Task.Run(() =>
            {
                tz.Wait(); //阻塞
                if (!axes[2].OverGoHomeMark) { return; }
                axes[1].Home_Mode = mode;
                axes[1].Home_dir = dir;
                axes[1].Home_speedSel = speedSel;
                motion.GoHome(axes[1]);
            });


        }

        /// <summary>
        /// 去指定点
        /// </summary>
        /// <param name="axes">依次是XYZ轴实体对象</param>
        /// <param name="dists">依次是XYZ轴绝对距离</param>
        public void GoSpecifyPoint(Axis[] axes, double[] dists)
        {
            Task.Run(() =>
            {
                //1.Z轴先到安全高度
                motion.PtPAbsoluteMove(axes[2], axes[2].SafePosition);

                //2.XY轴一起移动
                motion.Line2AbsoluteMove(axes[0], dists[0], axes[1], dists[1]);

                //3.Z轴移动
                motion.PtPAbsoluteMove(axes[2], dists[2]);
            });
        }

    }
}
