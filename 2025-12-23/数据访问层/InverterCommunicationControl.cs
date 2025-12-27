using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_12_23
{   
    /// <summary>
    /// 变频器通讯控制类
    /// </summary>
    public abstract class InverterCommunicationControl
    {   
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="serialParamatersEntity">串口对象</param>
        public abstract void OpenSerialPort(SerialParamatersEntity serialParamatersEntity);

        /// <summary>
        /// 关闭串口
        /// </summary>
        public abstract void CloseSerialPort();

        /// <summary>
        /// 执行正转命令
        /// </summary>
        /// <param name="inverterEntity">变频器对象</param>
        /// <returns>True：正常 False：执行异常</returns>
        public abstract void ExecuteForward(InverterEntity inverterEntity);

        /// <summary>
        /// 执行反转命令
        /// </summary>
        /// <param name="inverterEntity">变频器对象</param>
        /// <returns>True：正常 False：执行异常</returns>
        public abstract void ExecuteReverse(InverterEntity inverterEntity);

        /// <summary>
        /// 执行停止命令
        /// </summary>
        /// <param name="inverterEntity">变频器对象</param>
        /// <returns>True：正常 False：执行异常</returns>
        public abstract void ExecuteStop(InverterEntity inverterEntity);

        /// <summary>
        /// 执行设置变频器频率命令
        /// </summary>
        /// <param name="inverterEntity"></param>
        /// <param name="FrequencyValue">频率值</param>
        /// <returns></returns>
        public abstract void ExecuteSetFrequency(InverterEntity inverterEntity,double FrequencyValue);

        /// <summary>
        /// 读取运行频率
        /// </summary>
        /// <param name="inverterEntity">变频器对象</param>
        /// <returns>True：正常 False：执行异常</returns>
        public abstract void GetRunningFrequency(InverterEntity inverterEntity);

        /// <summary>
        /// 读取输出电流
        /// </summary>
        /// <param name="inverterEntity"></param>
        /// <returns></returns>
        public abstract void GetOutCurrent(InverterEntity inverterEntity);

        /// <summary>
        /// 读取输出电压
        /// </summary>
        /// <param name="inverterEntity"></param>
        /// <returns></returns>
        public abstract void GetOutVoltage(InverterEntity inverterEntity);

        /// <summary>
        /// 读取运行状态
        /// </summary>
        /// <param name="inverterEntity"></param>
        /// <returns></returns>
        public abstract void GetRunningStatus(InverterEntity inverterEntity);

    }

}
