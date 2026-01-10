using DAL;
using Entity;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                            break;
                        case AutoProcessStep.DetectMaterialSignal:
                            // 检测物料到位信号
                            ExecuteDetectMaterialSignal(iOCraftEntity);
                            autoProcessStep = AutoProcessStep.TurnOnCutter;
                            break;
                        case AutoProcessStep.TurnOnCutter:
                            // 打开切割器
                            ExecuteTurnOnCutter(iOCraftEntity);
                            autoProcessStep = AutoProcessStep.ZAxisMoveToFitstPoint;
                            break;
                        case AutoProcessStep.ZAxisMoveToFitstPoint:
                            // Z轴移动到加工的第一个点
                            ExecuteZAxisMoveToFitstPoint(processCoordEntities, AxisList[2]);
                            autoProcessStep = AutoProcessStep.ProcessFromTableData;

                            break;
                        case AutoProcessStep.ProcessFromTableData:
                            // 按表格数据进行加工
                            ExecuteProcessFromTableData(processCoordEntities, 
                                                        AxisList[0], AxisList[1], AxisList[2], 
                                                        UiDoSomething);
                            autoProcessStep = AutoProcessStep.AxisGotoSafePosition;

                            break;
                        case AutoProcessStep.AxisGotoSafePosition:
                            // Z轴移动到安全位置
                            ExecuteAxisGotoSafePosition(AxisList[2]);
                            autoProcessStep = AutoProcessStep.TurnOffCutter;

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

                            break;
                    }

                    Thread.Sleep(5);
                }
            });
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
            //1. Z轴移动到安全位置
            motion.PtPAbsoluteMove(zAxis, zAxis.SafePosition);
            //2. XY轴移动到表格第一个点上方
            double x1 = processCoordEntities[0].XPosition;
            double y1 = processCoordEntities[0].YPosition;
            UIdo?.Invoke(0);  //选中第一行
            motion.Line2AbsoluteMove(xAxis, x1, yAxis,y1);

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
                Thread.Sleep(20);
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
            motion.PtPAbsoluteMove(zAxis, zFirst);
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
                motion.Line3AbsoluteMove(xAxis, x, yAxis, y, zAxis, z);

            }
        }


        /// <summary>
        /// 执行Z轴移动到安全位置
        /// </summary>
        /// <param name="zAxis">Z轴</param>
        private void ExecuteAxisGotoSafePosition(Axis zAxis)
        {
            // 1. Z轴移动到安全位置
            motion.PtPAbsoluteMove(zAxis, zAxis.SafePosition);
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
            Task tz = Task.Run(() =>{  motion.GoHome(zAxis); });

            //2.X轴回原点
            Task tx = Task.Run(() =>
            {
                tz.Wait(); //阻塞
                if (!zAxis.OverGoHomeMark) { return; }
                motion.GoHome(xAxis);
            });

            //3.Y轴回原点
            Task ty = Task.Run(() =>
            {
                tz.Wait(); //阻塞
                if (!zAxis.OverGoHomeMark) { return; }
                motion.GoHome(yAxis);
            });

            Task.WaitAll(tx, ty); //等待所有任务完成
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
        AutomaticallyStopping,

        /// <summary>
        /// 移动到待加工位置
        /// </summary>
        MoveToProcessedPosition,

        /// <summary>
        /// 检测物料到位信号
        /// </summary>
        DetectMaterialSignal,

        /// <summary>
        /// 打开切割器
        /// </summary>
        TurnOnCutter,

        /// <summary>
        /// Z轴移动到加工的第一个点
        /// </summary>
        ZAxisMoveToFitstPoint,

        /// <summary>
        /// 按表格数据进行加工
        /// </summary>
        ProcessFromTableData,

        /// <summary>
        /// Z轴移动到安全位置
        /// </summary>
        AxisGotoSafePosition,

        // <summary>
        /// 关闭切割器
        /// </summary>
        TurnOffCutter,

        /// <summary>
        /// 消除误差
        /// </summary>
        GoHomeEliminateErrors

    }





}
