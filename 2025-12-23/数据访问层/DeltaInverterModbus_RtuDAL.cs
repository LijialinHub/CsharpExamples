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
    /// 台达变频器ModbusRTU数据访问类
    /// </summary>
    public class DeltaInverterModbus_RtuDAL : InverterCommunicationControl
    {

        /// <summary>
        /// 串口对象
        /// </summary>
        private SerialPort serialPort = new SerialPort();

        /// <summary>
        /// ModbusRTU主站
        /// </summary>
        private IModbusMaster ModbusMaster;


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
            FrequencyCommand = 0x2001,

            /// <summary>
            /// 运行状态
            /// </summary>
            RunningStatus = 0x2101,

            /// <summary>
            /// 运行频率
            /// </summary>
            RunningFrequency = 0x2103,

            /// <summary>
            /// 输出电流
            /// </summary>
            OutCurrent = 0x2104,

            /// <summary>
            /// 输出电压
            /// </summary>
            OutVoltage = 0x2106,
        }


        /// <summary>
        /// 控制动作枚举
        /// </summary>
        public enum ControlAction
        {
            /// <summary>
            /// 正转
            /// </summary>
            Forward = 18,
            /// <summary>
            /// 反转
            /// </summary>
            Reverse = 34,
            /// <summary>
            /// 停止
            /// </summary>
            Stop = 1
        }


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
                ushort value = (ushort)(FrequencyValue * 100);
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
                //inverterEntity.IsRunning = (res[0]&0b11) == 0;

                int r1 = res[0] & 0b0000000000000011; //取0号1号位元 0b11
                int r2 = res[0] & 0b0000000000011000; //取3号4号位元 0b11000

                inverterEntity.IsStop = (res[0] & r1) != 0;
                inverterEntity.IsForward = (r1 == 0b11 && r2 == 0b00);
                inverterEntity.IsReverse = (r1 == 0b11 && r2 == 0b11000);

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
                if(serialPort.IsOpen)
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
