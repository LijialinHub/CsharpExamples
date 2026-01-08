using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL  
{
    /// <summary>
    /// 运动控制卡（抽象类）
    /// </summary>
    public abstract class MotionCard     
    {
        /// <summary>
        /// 初始化运动控制卡
        /// </summary>
        public abstract void OpenCard();

        /// <summary>
        /// 关闭运动控制卡
        /// </summary>
        public abstract void CloseCard();

        /// <summary>
        /// Jog正方向运动
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="highorlow">高速或低速</param>
        public abstract void AxisPositiveDirMove(Axis ax, bool highorlow);

        /// <summary>
        /// Jog负方向运动
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="highorlow">高速或低速</param>
        public abstract void AxisNegativeDirMove(Axis ax, bool highorlow);

        /// <summary>
        /// 轴停止
        /// </summary>
        /// <param name="ax">轴</param>
        public abstract void AxisStop(Axis ax);

        /// <summary>
        /// 获取轴位置
        /// </summary>
        /// <param name="ax">轴</param>
        /// <returns></returns>
        public abstract double AxisPosGet(Axis ax);

        /// <summary>
        /// 回原点
        /// </summary>
        /// <param name="ax">轴</param>
        public abstract void GoHome(Axis ax);

        /// <summary>
        /// 绝对运动
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="dist">绝对距离</param>
        public abstract void PtPAbsoluteMove(Axis ax, double dist);

        /// <summary>
        /// 微动
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="speed">速度</param>
        /// <param name="dist">微动距离</param>
        public abstract void MicroMove(Axis ax, double speed, double dist);

        /// <summary>
        /// 两轴直线插补绝对运动
        /// </summary>
        /// <param name="Ax1">轴1</param>
        /// <param name="dst1">轴1位置</param>
        /// <param name="Ax2">轴2</param>
        /// <param name="dst2">轴2位置</param>
        public abstract void Line2AbsoluteMove(Axis Ax1, double dst1, Axis Ax2, double dst2);

        /// <summary>
        /// 三轴直线插补绝对运动
        /// </summary>
        /// <param name="Ax1">第一个轴</param>
        /// <param name="dst1">第一个轴绝对位置</param>
        /// <param name="Ax2">第二个轴</param>
        /// <param name="dst2">第二个轴绝对位置</param>
        /// <param name="Ax3">第三个轴</param>
        /// <param name="dst3">第三个轴绝对位置</param>
        public abstract void Line3AbsoluteMove(Axis Ax1, double dst1, Axis Ax2, double dst2, Axis Ax3, double dst3);


        /// <summary>
        /// 两轴直线插补相对运动
        /// </summary>
        /// <param name="Ax1">轴1</param>
        /// <param name="dst1">轴1位置</param>
        /// <param name="Ax2">轴2</param>
        /// <param name="dst2">轴2位置</param>
        public abstract void Line2RelativelyMove(Axis Ax1, double dst1, Axis Ax2, double dst2);


        /// <summary>
        /// 轴运行状态检测
        /// </summary>
        /// <param name="axNum">轴号</param>
        /// <returns>轴状态 true：运行  false：停止</returns>
        public abstract bool RunningStatus(Axis ax);


        /// <summary>
        /// 读取输入位状态
        /// </summary>
        /// <param name="bitNo">输入位号</param>
        /// <returns>状态 true：通  false：断</returns>
        public abstract bool ReadInBit(Axis ax, ushort bitNo);


        /// <summary>
        /// 控制位输出信号
        /// </summary>
        /// <param name="bitNo">输出位号</param>
        /// <param name="val">通(true)_断(false)</param>
        public abstract void WriteOutBit(Axis ax, ushort bitNo, bool val);


        /// <summary>
        /// 读取轴报警
        /// </summary>
        /// <param name="ax">轴</param>
        /// <returns>状态 true：报警  false：无报警</returns>
        public abstract bool ReadAlarm(Axis ax);

        /// <summary>
        /// 读取轴原点信号
        /// </summary>
        /// <param name="ax">轴</param>
        /// <returns>状态 true：碰到原点   false：没有碰到</returns>
        public abstract bool ReadOrg(Axis ax);

        /// <summary>
        /// 读取正限位信号
        /// </summary>
        /// <param name="ax">轴</param>
        /// <returns>状态 true：碰到正限位   false：没有碰到</returns>
        public abstract bool ReadPositiveLimit(Axis ax);

        /// <summary>
        /// 读取负限位信号
        /// </summary>
        /// <param name="ax">轴</param>
        /// <returns>状态 true：碰到负限位   false：没有碰到</returns>
        public abstract bool ReadNegativeLimit(Axis ax);

        /// <summary>
        /// 按下急停
        /// </summary>
        public abstract void PressEstop();

        /// <summary>
        /// 松开急停
        /// </summary>
        public abstract void LoosenEstop();

        /// <summary>
        /// 按下暂停
        /// </summary>
        public abstract void PressPause();

        /// <summary>
        /// 松开暂停
        /// </summary>
        public abstract void LoosenPause();


        /// <summary>
        /// 脉冲输出模式设置
        /// </summary>
        /// <param name="ax">脉冲轴</param>
        public abstract void PulseModeSet(Axis axs);


        /// <summary>
        /// 读取输出位状态
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="bitNo">位号</param>
        /// <returns>状态  True：通，false：断</returns>
        public abstract bool ReadOutBit(Axis ax, ushort bitNo);

        /// <summary>
        /// 设置软限位
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="enanle">True：软限位有效  false：无效</param>
        public abstract void SoftLimitSet(Axis ax, bool enanle);

        /// <summary>
        /// 读取运行速度
        /// </summary>
        /// <param name="ax">轴对象</param>
        /// <returns>速度值（单位：mm/s 或 °/s）</returns>
        public abstract double ReadRunningSpeed(Axis ax);
    }
}
