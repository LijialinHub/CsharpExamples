using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_12_23
{   
    /// <summary>
    /// 汇川变频器Modbus_Rtu数据访问类
    /// </summary>
    public class HuiChuanInverterModbus_RtuDAL : InverterCommunicationControl
    {   /*汇川变频器参数
         * F0-03 控制通道1主命令来源 2：通信
         * F0-29 主频率来源 9：通信给定
         * n2-00 Modbus波特率 5：9600
         * n2-01 Modbus数据格式 1: 偶校验（8-E-1）
         * n2-02 Modbus本机地址 1
         * 
         */

        /// <summary>
        /// 寄存器地址
        /// </summary>
        public enum RegisterAddress
        {
            /// <summary>
            /// 变频器的命令
            /// </summary>
            ControlCommand = 0x2000,

            /// <summary>
            /// 频率命令
            /// </summary>
            FrequencyCommand = 0x1000,

            /// <summary>
            /// 运行状态
            /// </summary>
            RunningStatus = 0x3000,

            /// <summary>
            /// 运行频率
            /// </summary>
            RunningFrequency = 0x1001,

            /// <summary>
            /// 输出电流
            /// </summary>
            OutCurrent = 0x1004,

            /// <summary>
            /// 输出电压
            /// </summary>
            OutVoltage = 0x1003,
        }


        /// <summary>
        /// 控制动作枚举
        /// </summary>
        public enum ControlAction
        {
            /// <summary>
            /// 正转
            /// </summary>
            Forward = 1,
            /// <summary>
            /// 反转
            /// </summary>
            Reverse = 2,
            /// <summary>
            /// 停止 5或8(紧急停机)
            /// </summary>
            Stop = 8
        }




        public override void CloseSerialPort()
        {
            throw new NotImplementedException();
        }

        public override void ExecuteForward(InverterEntity inverterEntity)
        {
            throw new NotImplementedException();
        }

        public override void ExecuteReverse(InverterEntity inverterEntity)
        {
            throw new NotImplementedException();
        }

        public override void ExecuteSetFrequency(InverterEntity inverterEntity, double FrequencyValue)
        {
            throw new NotImplementedException();
        }

        public override void ExecuteStop(InverterEntity inverterEntity)
        {
            throw new NotImplementedException();
        }

        public override void GetOutCurrent(InverterEntity inverterEntity)
        {
            throw new NotImplementedException();
        }

        public override void GetOutVoltage(InverterEntity inverterEntity)
        {
            throw new NotImplementedException();
        }

        public override void GetRunningFrequency(InverterEntity inverterEntity)
        {
            throw new NotImplementedException();
        }

        public override void GetRunningStatus(InverterEntity inverterEntity)
        {
            throw new NotImplementedException();
        }

        public override void OpenSerialPort(SerialParamatersEntity serialParamatersEntity)
        {
            throw new NotImplementedException();
        }
    }
}
