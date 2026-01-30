using Common;
using DAL;
using Entity;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{   


    /// <summary>
    /// 工艺流程业务逻辑类
    /// </summary>
    public class ProcessFlowBLL
    {   
        /// <summary>
        /// 自动工艺流程
        /// </summary>
        public AutoProcessStep autoProcessStep { get; set;}

        /// <summary>
        /// 要加工的数据集合
        /// </summary>
        public BindingList<ProcessCoordEntity> processCoordEntities { get; set;}


        /// <summary>
        /// 轴对象集合
        /// </summary>
        public List<Axis> AxisList { get; set; }

        /// <summary>
        /// IO工艺
        /// </summary>
        public IOCraftEntity iOCraftEntity { get; set; }
        
        /// <summary>
        /// 绘图工具
        /// </summary>
        public DrawHandleBLL drawHandleBLL { get; set; }

        /// <summary>
        /// 绘图参数实体
        /// </summary>
        public DrawParamsEntity drawParamsEntity { get; set; }


        /// <summary>
        /// 相机视觉业务逻辑对象
        /// </summary>
        public CemeraVisionHandleBLL CemeraVisionHandleBLL { get; set; }

        /// <summary>
        /// 相机视觉实体参数
        /// </summary>
        public CameraVisionEntity cameraVisionEntity { get; set; }

        

        /// <summary>
        /// 全自动标志(True:全自动 False:半自动)
        /// </summary>
        public bool FullyAutomaticMark { get; set; } = true;

        /// <summary>
        /// 消除误差前的加工执行次数
        /// </summary>
        public int EliminateErrorsCount { get; set; }

        /// <summary>
        /// 运动控制卡对象
        /// </summary>
        private MotionCard motion = new LeiSaiCard();

        /// <summary>
        /// UI执行的动作（选中dgv的行）
        /// </summary>
        public event Action<int> UiDoSomething;

        /// <summary>
        /// 人为阻塞信号对象
        /// </summary>
        private volatile ManualResetEvent mr = new ManualResetEvent(true);

        /// <summary>
        /// 暂停标志
        /// </summary>
        public volatile bool processPauseMark = false;

        /// <summary>
        /// 暂停前切割器状态
        /// </summary>
        public volatile bool brforePauseCutterStatus;


        /// <summary>
        /// 自动运行
        /// </summary>
        public async Task AutoRunAsync()
        {
            await Task.Run(() =>
            {
                autoProcessStep = AutoProcessStep.MoveToProcessedPosition;
                while (true)
                {
                    switch (autoProcessStep)
                    {
                        case AutoProcessStep.MoveToProcessedPosition:
                            // 移动到待加工位置
                            ExecuteMoveToProcessedPosition(processCoordEntities,
                                                AxisList[0], AxisList[1], AxisList[2], 
                                                UiDoSomething);
                            autoProcessStep = AutoProcessStep.DetectMaterialSignal;

                            if(Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            break;
                        case AutoProcessStep.DetectMaterialSignal:
                            // 检测物料到位信号
                            ExecuteDetectMaterialSignal(iOCraftEntity);
                            autoProcessStep = AutoProcessStep.TurnOnCutter;

                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }
                            drawHandleBLL.CoordinatesReset(); 
                            break;
                        case AutoProcessStep.TurnOnCutter:
                            // 打开切割器
                            ExecuteTurnOnCutter(iOCraftEntity);
                            autoProcessStep = AutoProcessStep.ZAxisMoveToFitstPoint;

                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }
                            break;
                        case AutoProcessStep.ZAxisMoveToFitstPoint:
                            // Z轴移动到加工的第一个点
                            ExecuteZAxisMoveToFitstPoint(processCoordEntities, AxisList[2]);
                            autoProcessStep = AutoProcessStep.ProcessFromTableData;

                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            break;
                        case AutoProcessStep.ProcessFromTableData:
                            // 按表格数据进行加工

                            drawHandleBLL.DrawTrack(new Pen(Color.Red,2f), AxisList[0], AxisList[1], drawParamsEntity); //绘制


                            ExecuteProcessFromTableData(processCoordEntities, 
                                                        AxisList[0], AxisList[1], AxisList[2], 
                                                        UiDoSomething);
                            drawHandleBLL.StopDraw(); //停止绘制
                            autoProcessStep = AutoProcessStep.AxisGotoSafePosition;

                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            break;
                        case AutoProcessStep.AxisGotoSafePosition:
                            // Z轴移动到安全位置
                            ExecuteAxisGotoSafePosition(AxisList[2]);
                            autoProcessStep = AutoProcessStep.TurnOffCutter;

                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            break;
                        case AutoProcessStep.TurnOffCutter:
                            // 关闭切割器
                            ExecuteTurnOffCutter(iOCraftEntity);
                            EliminateErrorsCount++;
                            if (EliminateErrorsCount == 10)  // 10次回原点
                            {
                                EliminateErrorsCount = 0;
                                autoProcessStep = AutoProcessStep.GoHomeEliminateErrors;
                                break;
                            }
                            if (FullyAutomaticMark)
                            {
                                autoProcessStep = AutoProcessStep.MoveToProcessedPosition;
                            }
                            else
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return; // 跳出自动运行方法
                            }

                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            break;
                        case AutoProcessStep.GoHomeEliminateErrors:
                            // 移动到原点消除错误
                            ExecuteGoHomeEliminateErrors(AxisList[0], AxisList[1], AxisList[2]);
                           
                            if (FullyAutomaticMark)
                            {
                                autoProcessStep = AutoProcessStep.MoveToProcessedPosition;
                            }
                            else
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return; // 跳出自动运行方法
                            }

                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            break;
                    }

                    Thread.Sleep(5);
                }
            });
        }


        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause()
        { 
            mr.Reset(); //阻塞自动的执行流
            motion.PressPause(); //所有轴停止
            processPauseMark = true;
            Axis axis = new Axis() { Axis_CardNo = iOCraftEntity.Cutter.CardNo };
            brforePauseCutterStatus = motion.ReadOutBit(axis, iOCraftEntity.Cutter.BitNo);
            motion.WriteOutBit(axis, iOCraftEntity.Cutter.BitNo, false); //切割器关闭
        }


        /// <summary>
        /// 再启动
        /// </summary>
        public void StartAgain()
        {
            motion.LoosenPause();
            
            Axis axis = new Axis() { Axis_CardNo = iOCraftEntity.Cutter.CardNo };
            motion.WriteOutBit(axis, iOCraftEntity.Cutter.BitNo, brforePauseCutterStatus);
            Thread.Sleep(200);
            mr.Set(); //取消阻塞
        }

        /// <summary>
        /// 按下急停
        /// </summary>
        public void PressEmg()
        {
            try
            {
                motion.PressEstop(); //停止所有轴
                Axis axis = new Axis() { Axis_CardNo = iOCraftEntity.Cutter.CardNo };
                motion.WriteOutBit(axis, iOCraftEntity.Cutter.BitNo, false);
                Thread.Sleep(200);
                foreach (var item in AxisList)
                {
                    item.OverGoHomeMark = false;
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 松开急停
        /// </summary>
        public void LoosenEmg()
        {
            try
            {
                motion.LoosenEstop();
            }
            catch (Exception)
            {  
            }
        }




        /*************************************************工位相关动作***********************************************
         */


        /// <summary>
        /// 执行移动到待加工位置
        /// </summary>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        /// <param name="zAxis"></param>
        private void ExecuteMoveToProcessedPosition(BindingList<ProcessCoordEntity> processCoordEntities
                                                    ,Axis xAxis, Axis yAxis, Axis zAxis, 
                                                    Action<int> UIdo = null)
        {
        Pos1:
            //1. Z轴移动到安全位置
            motion.PtPAbsoluteMove(zAxis, zAxis.SafePosition);
            mr.WaitOne();
            if(processPauseMark) 
            {
                processPauseMark = false;
                goto Pos1;
            }
            if (Axis.EmgMark) { return; } //按下急停 跳出方法

            //2. XY轴移动到表格第一个点上方
            double x1 = processCoordEntities[0].XPosition;
            double y1 = processCoordEntities[0].YPosition;
            UIdo?.Invoke(0);  //选中第一行

        Pos2:
            motion.Line2AbsoluteMove(xAxis, x1, yAxis, y1);
            mr.WaitOne();
            if (processPauseMark)
            {
                processPauseMark = false;
                goto Pos2;
            }
            if (Axis.EmgMark) { return; } //按下急停 跳出方法

        }


        /// <summary>
        /// 执行检测物料到位信号
        /// </summary>
        /// <param name="iOCraftEntity"></param>
        private void ExecuteDetectMaterialSignal(IOCraftEntity iOCraftEntity)
        {
            while (true)
            {
                if(iOCraftEntity.MaterialSignals.StatusValue) { break;}
                if (Axis.EmgMark){  return; }
                Thread.Sleep(5);
            }
        }

       /// <summary>
       /// 执行打开切割器
       /// </summary>
       /// <param name="iOCraftEntity">IO实体</param>
       /// <param name="delayTime"></param>
        private void ExecuteTurnOnCutter(IOCraftEntity iOCraftEntity,
                                            int delayTime = 1000)
        {
            Axis axis = new Axis() { Axis_CardNo = iOCraftEntity.Cutter.CardNo};
            motion.WriteOutBit(axis, iOCraftEntity.Cutter.BitNo, true);
            Thread.Sleep(delayTime);
            
        }


        /// <summary>
        /// 执行Z轴移动到第一个点
        /// </summary>
        /// <param name="processCoordEntities">表对象集合</param>
        /// <param name="zAxis">Z轴</param>
        private void ExecuteZAxisMoveToFitstPoint(BindingList<ProcessCoordEntity> processCoordEntities,
                                                    Axis zAxis)
        {
            double zFirst = processCoordEntities[0].ZPosition;
        Pos1:
            motion.PtPAbsoluteMove(zAxis, zFirst);
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
        private void ExecuteProcessFromTableData(BindingList<ProcessCoordEntity> processCoordEntities,
                                            Axis xAxis, Axis yAxis, Axis zAxis,
                                            Action<int> UIdo  = null)
        {
            for (int i = 1; i < processCoordEntities.Count; i++)
            {
                double x = processCoordEntities[i].XPosition;
                double y = processCoordEntities[i].YPosition;
                double z = processCoordEntities[i].ZPosition;
                UIdo?.Invoke(i);
            Pos1:
                motion.Line3AbsoluteMove(xAxis, x, yAxis, y, zAxis, z);
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
        private void ExecuteAxisGotoSafePosition(Axis zAxis)
        {
        // 1. Z轴移动到安全位置
        Pos1:
            motion.PtPAbsoluteMove(zAxis, zAxis.SafePosition);
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
        private void ExecuteTurnOffCutter(IOCraftEntity iOCraftEntity,
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
        private void ExecuteGoHomeEliminateErrors(Axis xAxis, Axis yAxis, Axis zAxis)
        {
            //1.Z轴先回原点
            Task tz = Task.Run(() =>
            {
            Pos1:
                motion.GoHome(zAxis);
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
                if (processPauseMark)
                {
                    processPauseMark = false;
                    goto Pos3;
                }
                if (Axis.EmgMark) { return; } //按下急停 跳出方法
            });

            Task.WaitAll(tx, ty); //等待所有任务完成
        }


        /// <summary>
        /// 执行去Mark2位置
        /// </summary>
        /// <param name="xAxis">X轴</param>
        /// <param name="yAxis">Y轴</param>
        /// <param name="zAxis">Z轴</param>
        /// <param name="cameraVisionEntity"></param>
        private async void ExcecuteMoveToMark2(Axis xAxis, Axis yAxis, Axis zAxis,
                                        CameraVisionEntity cameraVisionEntity)
        {
            //1.Z轴先到安全高度
            motion.PtPAbsoluteMove(zAxis, zAxis.SafePosition);

            //2.XY轴一起移动
            motion.Line2AbsoluteMove(xAxis, cameraVisionEntity.TBMachineMark2.X,
                                    yAxis, cameraVisionEntity.TBMachineMark2.Y);

            //3.Z轴移动
            motion.PtPAbsoluteMove(zAxis, cameraVisionEntity.BDHeight);
        }


        /// <summary>
        /// 执行去Mark2位置拍照
        /// </summary>
        /// <param name="uiIGrapAndUpdate">UI停止实时采集并更新图像</param>
        /// <param name="cemeraVisionHandleBLL">相机视觉处理业务逻辑</param>
        /// <param name="cameraVisionEntity">相机视觉实体</param>
        /// <param name="mark2MachinePos">加工板Mark2位置坐标</param>
        private bool ExecuteMark2PositionPhotograph(Action uiIGrapAndUpdate,
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
        private async void ExcecuteMoveToMark1(Axis xAxis, Axis yAxis, Axis zAxis,
                                        CameraVisionEntity cameraVisionEntity)
        {
            //1.Z轴先到安全高度
            motion.PtPAbsoluteMove(zAxis, zAxis.SafePosition);

            //2.XY轴一起移动
            motion.Line2AbsoluteMove(xAxis, cameraVisionEntity.TBMachineMark1.X,
                                    yAxis, cameraVisionEntity.TBMachineMark1.Y);

            //3.Z轴移动
            motion.PtPAbsoluteMove(zAxis, cameraVisionEntity.BDHeight);
        }


        /// <summary>
        /// 执行去Mark1位置拍照
        /// </summary>
        /// <param name="uiIGrapAndUpdate">UI停止实时采集并更新图像</param>
        /// <param name="cemeraVisionHandleBLL">相机视觉处理业务逻辑</param>
        /// <param name="cameraVisionEntity">相机视觉实体</param>
        /// <param name="mark1MachinePos">加工板Mark1位置坐标</param>
        private bool ExecuteMark1PositionPhotograph(Action uiIGrapAndUpdate,
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
        private void ExecuteCalculateCorrectionMatrix(CemeraVisionHandleBLL cemeraVisionHandleBLL,
                                                        MachineCoordEntity[] markMachinePos,
                                                        CameraVisionEntity cameraVisionEntity
                                                        )
        {

            cemeraVisionHandleBLL.GetVisionCorrectMachineMatrix(cameraVisionEntity, markMachinePos);

        }


    }


    /// <summary>
    /// 自动加工步骤
    /// </summary>
    public enum AutoProcessStep
    {
        /// <summary>
        /// 自动停止中
        /// </summary>
        [DescriptionCustomAttribute("自动停止中")]
        AutomaticallyStopping,

        /// <summary>
        /// 移动到待加工位置
        /// </summary>
        [DescriptionCustomAttribute("移动到待加工位置")]
        MoveToProcessedPosition,

        /// <summary>
        /// 检测物料到位信号
        /// </summary>
        [DescriptionCustomAttribute("检测物料到位信号")]
        DetectMaterialSignal,

        /// <summary>
        /// 移动到Mark2
        /// </summary>
        [DescriptionCustomAttribute("移动到Mark2")]
        MoveToMark2,

        /// <summary>
        /// Mark2位置拍照
        /// </summary>
        [DescriptionCustomAttribute("Mark2位置拍照")]
        Mark2PositionPhotograph,


        /// <summary>
        /// 移动到Mark1
        /// </summary>
        [DescriptionCustomAttribute("移动到Mark1")]
        MoveToMark1,

        /// <summary>
        /// Mark1位置拍照
        /// </summary>
        [DescriptionCustomAttribute("Mark1位置拍照")]
        Mark1PositionPhotograph,

        /// <summary>
        /// 计算修正坐标矩阵
        /// </summary>
        [DescriptionCustomAttribute("计算修正坐标矩阵")]
        CalculateCorrectionMatrix,


        /// <summary>
        /// 打开切割器
        /// </summary>
        [DescriptionCustomAttribute("打开切割器")]
        TurnOnCutter,

        /// <summary>
        /// 移动到修正后的第一个点
        /// </summary>
        [DescriptionCustomAttribute("移动到修正后的第一个点")]
        GoToCorrectionFirstPoint,

        /// <summary>
        /// Z轴移动到加工的第一个点
        /// </summary>
        [DescriptionCustomAttribute("Z轴移动到加工的第一个点")]
        ZAxisMoveToFitstPoint,

        /// <summary>
        /// 按表格数据进行加工
        /// </summary>
        [DescriptionCustomAttribute("按表格数据进行加工")]
        ProcessFromTableData,

        /// <summary>
        /// Z轴上升到安全位置
        /// </summary>
        [DescriptionCustomAttribute("Z轴上升到安全位置")]
        AxisGotoSafePosition,

        /// <summary>
        /// 关闭切割器
        /// </summary>
        [DescriptionCustomAttribute("关闭切割器")]
        TurnOffCutter,

        /// <summary>
        /// 回原点消除误差
        /// </summary>
        [DescriptionCustomAttribute("回原点消除误差")]
        GoHomeEliminateErrors

    }





}
