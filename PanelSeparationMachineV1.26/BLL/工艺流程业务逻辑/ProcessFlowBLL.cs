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
        /// UI停止实时采集并更新图像
        /// </summary>
        public event Action UIGrapAndUpdate;

        /// <summary>
        /// 继续实时采集
        /// </summary>
        public event Action UIRealTimeAcq;

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
                MachineCoordEntity[] markMachinePos = new MachineCoordEntity[2];

                while (true)
                {
                    switch (autoProcessStep)
                    {
                        case AutoProcessStep.MoveToProcessedPosition:
                            // 移动到待加工位置
                            CuttingWorkStationOperation.ExecuteMoveToProcessedPosition(motion,
                                                 AxisList[0], AxisList[1], AxisList[2], 
                                                 mr, processPauseMark);
                            autoProcessStep = AutoProcessStep.DetectMaterialSignal;

                            if(Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            break;

                        case AutoProcessStep.DetectMaterialSignal:
                            // 检测物料到位信号
                            CuttingWorkStationOperation.ExecuteDetectMaterialSignal(iOCraftEntity);
                            autoProcessStep = AutoProcessStep.MoveToMark2;

                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }
                            drawHandleBLL.CoordinatesReset(); 
                            break;


                        case AutoProcessStep.MoveToMark2:
                            // 移动到Mark2
                            CuttingWorkStationOperation.ExcecuteMoveToMark2(motion,
                                                AxisList[0], AxisList[1], AxisList[2],
                                                cameraVisionEntity,
                                                mr, processPauseMark
                                                );

                            autoProcessStep = AutoProcessStep.Mark2PositionPhotograph;

                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            break;


                        case AutoProcessStep.Mark2PositionPhotograph:
                            // Mark2位置拍照
                            bool isMark2Find = CuttingWorkStationOperation.ExecuteMark2PositionPhotograph(UIGrapAndUpdate,
                                                                                    CemeraVisionHandleBLL,
                                                                                    cameraVisionEntity,
                                                                                    out MachineCoordEntity mark2MachinePos,
                                                                                    out string res
                                                                                     );
                            // 如果未找到Mark2 匹配失败 或 按下急停
                            if (!isMark2Find || Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            UIRealTimeAcq?.Invoke(); //继续实时采集
                            markMachinePos[1] = mark2MachinePos;
                            autoProcessStep = AutoProcessStep.MoveToMark1;



                            break;


                        case AutoProcessStep.MoveToMark1:
                            // 移动到Mark1
                            CuttingWorkStationOperation.ExcecuteMoveToMark1(motion,
                                                AxisList[0], AxisList[1], AxisList[2],
                                                cameraVisionEntity,
                                                mr, processPauseMark
                                                );

                            autoProcessStep = AutoProcessStep.Mark1PositionPhotograph;

                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            break;

                        case AutoProcessStep.Mark1PositionPhotograph:
                            // Mark1位置拍照
                            bool isMark1Find = CuttingWorkStationOperation.ExecuteMark1PositionPhotograph(UIGrapAndUpdate,
                                                                                    CemeraVisionHandleBLL,
                                                                                    cameraVisionEntity,
                                                                                    out MachineCoordEntity mark1MachinePos,
                                                                                    out string res1
                                                                                     );
                            // 如果未找到Mark1 匹配失败 或 按下急停
                            if (!isMark1Find || Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            
                            markMachinePos[0] = mark1MachinePos;
                            autoProcessStep = AutoProcessStep.CalculateCorrectionMatrix;
                            UIRealTimeAcq?.Invoke(); //继续实时采集
                            break;


                        case AutoProcessStep.CalculateCorrectionMatrix:
                            // 计算修正坐标矩阵
                            CuttingWorkStationOperation.ExecuteCalculateCorrectionMatrix(CemeraVisionHandleBLL,
                                                                                        markMachinePos,
                                                                                        cameraVisionEntity
                                                                                        );

                            autoProcessStep = AutoProcessStep.GoToCorrectionFirstPoint;
                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            break;


                        case AutoProcessStep.GoToCorrectionFirstPoint:

                            // 移动到修正后的第一个点
                            CuttingWorkStationOperation.ExecuteGoToCorrectionFirstPoint(motion,
                                                AxisList[0], AxisList[1], AxisList[2],
                                                processCoordEntities,
                                                CemeraVisionHandleBLL,
                                                mr, processPauseMark,
                                                UiDoSomething
                                                );

                            autoProcessStep = AutoProcessStep.TurnOnCutter;
                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            break;



                        case AutoProcessStep.TurnOnCutter:
                            // 打开切割器
                            CuttingWorkStationOperation.ExecuteTurnOnCutter(motion, iOCraftEntity);
                            autoProcessStep = AutoProcessStep.ZAxisMoveToFitstPoint;

                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }
                            break;


                        case AutoProcessStep.ZAxisMoveToFitstPoint:
                            // Z轴移动到加工的第一个点
                            CuttingWorkStationOperation.ExecuteZAxisMoveToFitstPoint(motion,processCoordEntities, AxisList[2],
                                mr,
                                processPauseMark);
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


                            CuttingWorkStationOperation.ExecuteProcessFromTableData(motion,
                                                                    processCoordEntities, 
                                                                    AxisList[0], AxisList[1], AxisList[2], 
                                                                    CemeraVisionHandleBLL,
                                                                    mr, processPauseMark,
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
                            CuttingWorkStationOperation.ExecuteAxisGotoSafePosition(motion, 
                                                                                    AxisList[2],
                                                                                    mr, processPauseMark);
                            autoProcessStep = AutoProcessStep.TurnOffCutter;

                            if (Axis.EmgMark)
                            {
                                autoProcessStep = AutoProcessStep.AutomaticallyStopping;
                                return;
                            }

                            break;
                        case AutoProcessStep.TurnOffCutter:
                            // 关闭切割器
                            CuttingWorkStationOperation.ExecuteTurnOffCutter(motion, 
                                                                            iOCraftEntity);
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
                            CuttingWorkStationOperation.ExecuteGoHomeEliminateErrors(motion,
                                                                                    AxisList[0], AxisList[1], AxisList[2],
                                                                                    mr, processPauseMark);
                           
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
