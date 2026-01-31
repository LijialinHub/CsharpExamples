using BLL;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{   
    /// <summary>
    /// 切割工位动作类
    /// </summary>
    public class CuttingWorkStationOperation
    {

        /// <summary>
        /// 执行移动到待加工位置
        /// </summary>
        /// <param name="motion">运动控制卡</param>
        /// <param name="xAxis">X轴</param>
        /// <param name="yAxis">Y轴</param>
        /// <param name="zAxis">Z轴</param>
        /// <param name="UIdo">UI要做的事情</param>
        /// <param name="mr">人为阻塞</param>
        /// <param name="processPauseMark">暂停标志</param>
        public static void ExecuteMoveToProcessedPosition(MotionCard motion,
                                                    Axis xAxis, Axis yAxis, Axis zAxis,   
                                                    ManualResetEvent mr, 
                                                    bool processPauseMark,
                                                    Action<int> UIdo = null)
        {
        Pos1:
            //1. Z轴移动到安全位置
            motion.PtPAbsoluteMove(zAxis, zAxis.SafePosition);
            mr.WaitOne();
            if (processPauseMark)
            {
                processPauseMark = false;
                goto Pos1;
            }
            if (Axis.EmgMark) { return; } //按下急停 跳出方法

            //2. XY轴移动到表格第一个点上方
            double x1 = xAxis.WaitingPosition;
            double y1 = yAxis.WaitingPosition;
            UIdo?.Invoke(0);  //选中第一行

        Pos2:
            motion.Line2AbsoluteMove(xAxis, x1, yAxis, y1);
            mr.WaitOne();
            if (processPauseMark)
            {
                processPauseMark = false;
                goto Pos2;
            }
            //if (Axis.EmgMark) { return; } //按下急停 跳出方法

        }


        /// <summary>
        /// 执行检测物料到位信号
        /// </summary>
        /// <param name="iOCraftEntity"></param>
        public static void ExecuteDetectMaterialSignal(IOCraftEntity iOCraftEntity)
        {
            while (true)
            {
                if (iOCraftEntity.MaterialSignals.StatusValue) { break; }
                if (Axis.EmgMark) { return; }
                Thread.Sleep(5);
            }
        }

        /// <summary>
        /// 执行去Mark2位置
        /// </summary>
        /// <param name="xAxis">X轴</param>
        /// <param name="yAxis">Y轴</param>
        /// <param name="zAxis">Z轴</param>
        /// <param name="cameraVisionEntity"></param>
        public static  async void ExcecuteMoveToMark2(MotionCard motion,
                                        Axis xAxis, Axis yAxis, Axis zAxis,
                                        CameraVisionEntity cameraVisionEntity,
                                        ManualResetEvent mr,
                                        bool processPauseMark)
        {
        Pos1:
            //1.Z轴先到安全高度
            motion.PtPAbsoluteMove(zAxis, zAxis.SafePosition);
            mr.WaitOne();
            if (processPauseMark)
            {
                processPauseMark = false;
                goto Pos1;
            }
        Pos2:
            //2.XY轴一起移动
            motion.Line2AbsoluteMove(xAxis, cameraVisionEntity.TBMachineMark2.X,
                                    yAxis, cameraVisionEntity.TBMachineMark2.Y);
            mr.WaitOne();
            if (processPauseMark)
            {
                processPauseMark = false;
                goto Pos2;
            }

        Pos3:
            //3.Z轴移动
            motion.PtPAbsoluteMove(zAxis, cameraVisionEntity.BDHeight);
            mr.WaitOne();
            if (processPauseMark)
            {
                processPauseMark = false;
                goto Pos3;
            }
        }


        /// <summary>
        /// 执行去Mark2位置拍照
        /// </summary>
        /// <param name="uiIGrapAndUpdate">UI停止实时采集并更新图像</param>
        /// <param name="cemeraVisionHandleBLL">相机视觉处理业务逻辑</param>
        /// <param name="cameraVisionEntity">相机视觉实体</param>
        /// <param name="mark2MachinePos">加工板Mark2位置坐标</param>
        public static bool ExecuteMark2PositionPhotograph(
                                                    Action uiIGrapAndUpdate,
                                                    CemeraVisionHandleBLL cemeraVisionHandleBLL,
                                                    CameraVisionEntity cameraVisionEntity,
                                                    out MachineCoordEntity mark2MachinePos,
                                                    out string res)
        {
            try
            {
                //1. UI停止实时采集并更新图像
                uiIGrapAndUpdate?.Invoke();

                //2. 匹配Mark2，得到加工板Mark2像素坐标
                PixelPos pixelPos = cemeraVisionHandleBLL.ExcuteMatch("Mark2",
                                                                    cameraVisionEntity.MatchScores,
                                                                    cameraVisionEntity.MaxOverlap,
                                                                    cameraVisionEntity.Greediness
                                                                    );
                if (pixelPos != null)  //匹配成功
                {
                    double diffRow = pixelPos.Row - cameraVisionEntity.TBImageMark2.Row;
                    double diffColumn = pixelPos.Column - cameraVisionEntity.TBImageMark2.Column;

                    double diffX = diffColumn / cameraVisionEntity.XDirPixToMachine;
                    double diffY = diffRow / cameraVisionEntity.YDirPixToMachine;

                    //根据匹配结果修正拍照位置，得到新的拍照位置(相机 还是相减 要根据机械坐标系方向来判断)
                    mark2MachinePos = new MachineCoordEntity()
                    {
                        X = cameraVisionEntity.TBMachineMark2.X - diffX,
                        Y = cameraVisionEntity.TBMachineMark2.Y - diffY,
                    };

                    res = "Mark2位置匹配成功：";
                    return true;
                }
                else  //匹配失败
                {
                    res = "Mark2位置匹配失败：";
                    mark2MachinePos = null;
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 执行去Mark1位置
        /// </summary>
        /// <param name="xAxis">X轴</param>
        /// <param name="yAxis">Y轴</param>
        /// <param name="zAxis">Z轴</param>
        /// <param name="cameraVisionEntity"></param>
        public static async void ExcecuteMoveToMark1(MotionCard motion,
                                        Axis xAxis, Axis yAxis, Axis zAxis,
                                        CameraVisionEntity cameraVisionEntity,
                                         ManualResetEvent mr,
                                                    bool processPauseMark)
        {

        Pos1:
            //1.Z轴先到安全高度
            motion.PtPAbsoluteMove(zAxis, zAxis.SafePosition);

            mr.WaitOne();
            if (processPauseMark)
            {
                processPauseMark = false;
                goto Pos1;
            }

        Pos2:
            //2.XY轴一起移动
            motion.Line2AbsoluteMove(xAxis, cameraVisionEntity.TBMachineMark1.X,
                                    yAxis, cameraVisionEntity.TBMachineMark1.Y);


            mr.WaitOne();
            if (processPauseMark)
            {
                processPauseMark = false;
                goto Pos2;
            }
        Pos3:
            //3.Z轴移动
            motion.PtPAbsoluteMove(zAxis, cameraVisionEntity.BDHeight);

            mr.WaitOne();
            if (processPauseMark)
            {
                processPauseMark = false;
                goto Pos3;
            }
        }


        /// <summary>
        /// 执行去Mark1位置拍照
        /// </summary>
        /// <param name="uiIGrapAndUpdate">UI停止实时采集并更新图像</param>
        /// <param name="cemeraVisionHandleBLL">相机视觉处理业务逻辑</param>
        /// <param name="cameraVisionEntity">相机视觉实体</param>
        /// <param name="mark1MachinePos">加工板Mark1位置坐标</param>
        public static bool ExecuteMark1PositionPhotograph(Action uiIGrapAndUpdate,
                                                    CemeraVisionHandleBLL cemeraVisionHandleBLL,
                                                    CameraVisionEntity cameraVisionEntity,
                                                    out MachineCoordEntity mark1MachinePos,
                                                    out string res)
        {
            try
            {
                //1. UI停止实时采集并更新图像
                uiIGrapAndUpdate?.Invoke();

                //2. 匹配Mark1，得到加工板Mark2像素坐标
                PixelPos pixelPos = cemeraVisionHandleBLL.ExcuteMatch("Mark1",
                                                                    cameraVisionEntity.MatchScores,
                                                                    cameraVisionEntity.MaxOverlap,
                                                                    cameraVisionEntity.Greediness
                                                                    );
                if (pixelPos != null)  //匹配成功
                {
                    double diffRow = pixelPos.Row - cameraVisionEntity.TBImageMark1.Row;
                    double diffColumn = pixelPos.Column - cameraVisionEntity.TBImageMark1.Column;

                    double diffX = diffColumn / cameraVisionEntity.XDirPixToMachine;
                    double diffY = diffRow / cameraVisionEntity.YDirPixToMachine;

                    //根据匹配结果修正拍照位置，得到新的拍照位置(相机 还是相减 要根据机械坐标系方向来判断)
                    mark1MachinePos = new MachineCoordEntity()
                    {
                        X = cameraVisionEntity.TBMachineMark1.X - diffX,
                        Y = cameraVisionEntity.TBMachineMark1.Y - diffY,
                    };

                    res = "Mark1位置匹配成功：";
                    return true;
                }
                else  //匹配失败
                {
                    res = "Mark1位置匹配失败：";
                    mark1MachinePos = null;
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        /// <summary>
        /// 执行计算修正坐标矩阵
        /// </summary>
        /// <param name="cemeraVisionHandleBLL">相机视觉处理业务逻辑</param>
        /// <param name="markMachinePos">加工板Mark1和Mark2机械位置坐标</param>
        /// <param name="cameraVisionEntity">相机视觉实体</param>
        public static void ExecuteCalculateCorrectionMatrix(CemeraVisionHandleBLL cemeraVisionHandleBLL,
                                                        MachineCoordEntity[] markMachinePos,
                                                        CameraVisionEntity cameraVisionEntity
                                                        )
        {

            cemeraVisionHandleBLL.GetVisionCorrectMachineMatrix(cameraVisionEntity, markMachinePos);

        }


        /// <summary>
        /// 移动到修正后的第一个点
        /// </summary>
        /// <param name="xAxis">X轴</param>
        /// <param name="yAxis">Y轴</param>
        /// <param name="zAxis">Z轴</param>
        /// <param name="processCoordEntities">要处理表格集合</param>
        /// <param name="cemeraVisionHandleBLL">相机视觉处理业务逻辑</param>
        /// <param name="UIDoing">UI执行的动作</param>
        public static void ExecuteGoToCorrectionFirstPoint(MotionCard motion,
                                                    Axis xAxis, Axis yAxis, Axis zAxis,
                                                    BindingList<ProcessCoordEntity> processCoordEntities,
                                                    CemeraVisionHandleBLL cemeraVisionHandleBLL,
                                                    ManualResetEvent mr,
                                                    bool processPauseMark,
                                                    Action<int> UIDoing = null)
        {
        Pos1:
            //1. Z轴移动到安全位置
            motion.PtPAbsoluteMove(zAxis, zAxis.SafePosition);
            mr.WaitOne();
            if (processPauseMark)
            {
                processPauseMark = false;
                goto Pos1;
            }
            if (Axis.EmgMark) { return; } //按下急停 跳出方法

            //2. XY轴移动到表格第一个点上方

            MachineCoordEntity old = new MachineCoordEntity()
            {
                X = processCoordEntities[0].XPosition,
                Y = processCoordEntities[0].YPosition
            };

            //修正坐标
            cemeraVisionHandleBLL.CorrectPoint(old, out MachineCoordEntity newPos);
            double x1 = newPos.X;
            double y1 = newPos.Y;
            UIDoing?.Invoke(0);  //选中第一行

        Pos2:
            motion.Line2AbsoluteMove(xAxis, x1, yAxis, y1);
            mr.WaitOne();
            if (processPauseMark)
            {
                processPauseMark = false;
                goto Pos2;
            }
            //if (Axis.EmgMark) { return; } //按下急停 跳出方法
        }


        /// <summary>
        /// 执行打开切割器
        /// </summary>
        /// <param name="motion">运动卡</param>
        /// <param name="iOCraftEntity">IO实体</param>
        /// <param name="delayTime"></param>
        public static void ExecuteTurnOnCutter(MotionCard motion,
                                                IOCraftEntity iOCraftEntity,
                                                int delayTime = 1000)
        {
            Axis axis = new Axis() { Axis_CardNo = iOCraftEntity.Cutter.CardNo };
            motion.WriteOutBit(axis, iOCraftEntity.Cutter.BitNo, true);
            Thread.Sleep(delayTime);

        }


        /// <summary>
        /// 执行Z轴移动到第一个点
        /// </summary>
        /// <param name="processCoordEntities">表对象集合</param>
        /// <param name="zAxis">Z轴</param>
        public static void ExecuteZAxisMoveToFitstPoint(MotionCard motion,
                                                BindingList<ProcessCoordEntity> processCoordEntities,
                                                    Axis zAxis,
                                                    ManualResetEvent mr,
                                                    bool processPauseMark)
        {
            double zFirst = processCoordEntities[0].ZPosition;
        Pos1:
            motion.PtPAbsoluteMove(zAxis, zFirst);
            mr.WaitOne();
            if (processPauseMark)
            {
                processPauseMark = false;
                goto Pos1;
            }
            if (Axis.EmgMark) { return; } //按下急停 跳出方法
        }


        /// <summary>
        /// 执行按表格数据进行加工
        /// </summary>
        /// <param name="xAxis">X轴</param>
        /// <param name="yAxis">Y轴</param>
        /// <param name="zAxis">Z轴</param
        /// <param name="UIdo">UI执行动作 回调</param>
        public static void ExecuteProcessFromTableData(MotionCard motion,
                                            BindingList<ProcessCoordEntity> processCoordEntities,
                                            Axis xAxis, Axis yAxis, Axis zAxis,
                                            CemeraVisionHandleBLL cemeraVisionHandleBLL,
                                            ManualResetEvent mr,
                                            bool processPauseMark,
                                            Action<int> UIdo = null)
        {
            for (int i = 1; i < processCoordEntities.Count; i++)
            {
                double x = processCoordEntities[i].XPosition;
                double y = processCoordEntities[i].YPosition;
                double z = processCoordEntities[i].ZPosition;
                UIdo?.Invoke(i);

                MachineCoordEntity old = new MachineCoordEntity()
                {
                    X = x,
                    Y = y
                };
                cemeraVisionHandleBLL.CorrectPoint(old, out MachineCoordEntity newPos);


            Pos1:
                motion.Line3AbsoluteMove(xAxis, newPos.X, yAxis, newPos.Y, zAxis, z);
                if (processPauseMark)
                {
                    processPauseMark = false;
                    goto Pos1;
                }
                if (Axis.EmgMark) { return; } //按下急停 跳出方法

            }
        }


        /// <summary>
        /// 执行Z轴移动到安全位置
        /// </summary>
        /// <param name="zAxis">Z轴</param>
        public static void ExecuteAxisGotoSafePosition(MotionCard motion,
                                                        Axis zAxis,
                                                        ManualResetEvent mr,
                                                        bool processPauseMark)
        {
        // 1. Z轴移动到安全位置
        Pos1:
            motion.PtPAbsoluteMove(zAxis, zAxis.SafePosition);
            mr.WaitOne();
            if (processPauseMark)
            {
                processPauseMark = false;
                goto Pos1;
            }
            if (Axis.EmgMark) { return; } //按下急停 跳出方法
        }

        /// <summary>
        /// 执行关闭切割器
        /// </summary>
        /// <param name="iOCraftEntity">IO实体</param>
        /// <param name="delayTime">延时时间</param>
        public static void ExecuteTurnOffCutter(MotionCard motion,
                                            IOCraftEntity iOCraftEntity,
                                            int delayTime = 1000)
        {
            Axis axis = new Axis() { Axis_CardNo = iOCraftEntity.Cutter.CardNo };
            motion.WriteOutBit(axis, iOCraftEntity.Cutter.BitNo, false);
            Thread.Sleep(delayTime);
        }

        /// <summary>
        /// 执行移动到原点消除错误
        /// </summary>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        /// <param name="zAxis"></param>
        public static void ExecuteGoHomeEliminateErrors(MotionCard motion, 
                                                        Axis xAxis, Axis yAxis, Axis zAxis,
                                                        ManualResetEvent mr,
                                                        bool processPauseMark)
        {
            //1.Z轴先回原点
            Task tz = Task.Run(() =>
            {
            Pos1:
                motion.GoHome(zAxis);
                mr.WaitOne();
                if (processPauseMark)
                {
                    processPauseMark = false;
                    goto Pos1;
                }
                if (Axis.EmgMark) { return; } //按下急停 跳出方法
            });

            //2.X轴回原点
            Task tx = Task.Run(() =>
            {
                tz.Wait(); //阻塞
                if (!zAxis.OverGoHomeMark) { return; }
            Pos2:
                motion.GoHome(xAxis);
                mr.WaitOne();
                if (processPauseMark)
                {
                    processPauseMark = false;
                    goto Pos2;
                }
                if (Axis.EmgMark) { return; } //按下急停 跳出方法
            });

            //3.Y轴回原点
            Task ty = Task.Run(() =>
            {
                tz.Wait(); //阻塞
                if (!zAxis.OverGoHomeMark) { return; }
            Pos3:
                motion.GoHome(yAxis);
                mr.WaitOne();
                if (processPauseMark)
                {
                    processPauseMark = false;
                    goto Pos3;
                }
                if (Axis.EmgMark) { return; } //按下急停 跳出方法
            });

            Task.WaitAll(tx, ty); //等待所有任务完成
        }



    }
}
