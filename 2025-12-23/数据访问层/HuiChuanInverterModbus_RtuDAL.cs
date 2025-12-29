using Modbus.Device;
using System;
using System.Collections.Generic;
using System.IO.Ports;
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
            Stop = 5
        }


        /// <summary>
        /// 串口对象
        /// </summary>
        private SerialPort serialPort = new SerialPort();

        /// <summary>
        /// ModbusRTU主站
        /// </summary>
        private IModbusMaster ModbusMaster;

        /// <summary>
        /// 执行正转命令
        /// </summary>
        /// <param name="inverterEntity">变频器对象</param>
        /// <returns>True：正常 False：执行异常</returns>
        public override void ExecuteForward(InverterEntity inverterEntity)
        {
            try
            {
                ModbusMaster.WriteSingleRegisterAsync(inverterEntity.StationNumber, (ushort)RegisterAddress.ControlCommand,
                                                    (ushort)ControlAction.Forward);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 执行反转命令
        /// </summary>
        /// <param name="inverterEntity">变频器对象</param>
        /// <returns>True：正常 False：执行异常</returns>
        public override void ExecuteReverse(InverterEntity inverterEntity)
        {
            try
            {
                ModbusMaster.WriteSingleRegisterAsync(inverterEntity.StationNumber, (ushort)RegisterAddress.ControlCommand,
                                                    (ushort)ControlAction.Reverse);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 执行停止命令
        /// </summary>
        /// <param name="inverterEntity">变频器对象</param>
        /// <returns>True：正常 False：执行异常</returns>
        public override void ExecuteStop(InverterEntity inverterEntity)
        {
            try
            {
                ModbusMaster.WriteSingleRegisterAsync(inverterEntity.StationNumber, (ushort)RegisterAddress.ControlCommand,
                                                    (ushort)ControlAction.Stop);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 执行设置变频器频率命令
        /// </summary>
        /// <param name="inverterEntity"></param>
        /// <param name="FrequencyValue">频率值</param>
        /// <returns></returns>
        public override void ExecuteSetFrequency(InverterEntity inverterEntity, double FrequencyValue)
        {
            try
            {
                ushort value = (ushort)(FrequencyValue * 200);
                ModbusMaster.WriteSingleRegisterAsync(inverterEntity.StationNumber, (ushort)RegisterAddress.FrequencyCommand, value);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 读取运行频率
        /// </summary>
        /// <param name="inverterEntity">变频器对象</param>
        /// <returns>True：正常 False：执行异常</returns>
        public override void GetRunningFrequency(InverterEntity inverterEntity)
        {
            try
            {
                ushort[] res = ModbusMaster.ReadHoldingRegisters(inverterEntity.StationNumber,
                                                 (ushort)RegisterAddress.RunningFrequency,
                                                 1);
                inverterEntity.RunningFrequency = res[0] / 100.0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 读取输出电流
        /// </summary>
        /// <param name="inverterEntity"></param>
        /// <returns></returns>
        public override void GetOutCurrent(InverterEntity inverterEntity)
        {
            try
            {
                ushort[] res = ModbusMaster.ReadHoldingRegisters(inverterEntity.StationNumber,
                                                 (ushort)RegisterAddress.OutCurrent,
                                                 1);
                inverterEntity.OutputCurrent = res[0] / 100.0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 读取输出电压
        /// </summary>
        /// <param name="inverterEntity"></param>
        /// <returns></returns>
        public override void GetOutVoltage(InverterEntity inverterEntity)
        {
            try
            {
                ushort[] res = ModbusMaster.ReadHoldingRegisters(inverterEntity.StationNumber,
                                                 (ushort)RegisterAddress.OutVoltage,
                                                 1);
                inverterEntity.OutputVoltage = res[0] / 10.0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 读取运行状态
        /// </summary>
        /// <param name="inverterEntity"></param>
        /// <returns></returns>
        public override void GetRunningStatus(InverterEntity inverterEntity)
        {
            try
            {
                ushort[] res = ModbusMaster.ReadHoldingRegisters(inverterEntity.StationNumber,
                                                (ushort)RegisterAddress.RunningStatus,
                                                1);
                
                inverterEntity.IsStop = res[0] != 3;
                inverterEntity.IsForward = res[0] == 1;
                inverterEntity.IsReverse = res[0] == 2;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="serialParamatersEntity"></param>
        public override void OpenSerialPort(SerialParamatersEntity serialParamatersEntity)
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.PortName = serialParamatersEntity.PortName;
                    serialPort.BaudRate = serialParamatersEntity.BaudRate;
                    serialPort.DataBits = serialParamatersEntity.DataBits;
                    serialPort.Parity = serialParamatersEntity.ParityBits;
                    serialPort.StopBits = serialParamatersEntity.StopBits;
                    ModbusMaster = ModbusSerialMaster.CreateRtu(serialPort); //创建ModbusRTU主站
                    serialPort.Open();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void CloseSerialPort()
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    ModbusMaster.Dispose();  //释放ModbusMaster主站资源
                    serialPort.Close();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
