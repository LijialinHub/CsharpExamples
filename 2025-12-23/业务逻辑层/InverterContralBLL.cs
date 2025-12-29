using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Modbus.Device;   //NModbus4类库中的

namespace _2025_12_23
{   
    /// <summary>
    /// 变频器控制业务逻辑类
    /// </summary>
    public class InverterContralBLL
    {   
        /// <summary>
        /// 变频器控制数据访问对象
        /// </summary>
        private InverterModbusDAL inverterModbusDAL = new InverterModbusDAL();

        /// <summary>
        /// 变频器通讯控制
        /// </summary>
        //public InverterCommunicationControl inverterCommunicationControl = new DeltaInverterModbus_RtuDAL();

        public InverterCommunicationControl inverterCommunicationControl = new HuiChuanInverterModbus_RtuDAL();
        /// <summary>
        /// 取消信号
        /// </summary>
        private CancellationTokenSource cts;

        /// <summary>
        /// 实时采集退出标志
        /// </summary>
        private bool isRealTimeExitsMark = true;

        private Task taskTimeExits;

        /// <summary>
        /// 保存变频器数据到ini文件
        /// </summary>
        public bool SaveInverterDataToIni(InverterEntity inverterEntity, 
                                            SerialParamatersEntity serialParamatersEntity,
                                            out string res)
        {
            try
            {
                inverterModbusDAL.SaveInverterDataToIni(inverterEntity, serialParamatersEntity);
                res = "保存变频器数据成功！";
                return true;
            }
            catch (Exception ex)
            {
                res = "保存变频器数据失败！" + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 从ini文件中读取变频器数据
        /// </summary>
        public bool ReadInverterDataFromIni(InverterEntity inverterEntity, 
                                    SerialParamatersEntity serialParamatersEntity, 
                                    out string res)
        {
            try
            {
                inverterModbusDAL.ReadInverterDataFromIni(inverterEntity, serialParamatersEntity);
                res = "读取变频器数据成功！";
                return true;
            }
            catch (Exception ex)
            {   
                res = "读取变频器数据失败！" + ex.Message;
                return false;
            }
        }


        //串口打开_关闭
        //发送正转、反转、停止命令  设置频率 ==》 写入
        //读取频率 输出电流 输出电压 运行状态 ==》 读取（实时 1.开线程 2.使用定时器Timer）


        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="res"></param>
        /// <param name="serialParamatersEntity">串口参数对象</param>
        /// <returns></returns>
        public bool OpenSerialPort(SerialParamatersEntity serialParamatersEntity, out string res)
        {
            try
            {   
                inverterCommunicationControl.OpenSerialPort(serialParamatersEntity);

                res = "打开串口成功!";
                return true;
            }
            catch (Exception ex)
            {
                res = $"打开串口失败 \r\n，{ex.Message} !";
                return false;
            }
        }


        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <param name="res">执行结果</param>
        /// <returns></returns>
        public async Task<bool> CloseSerialPortAsync( )
        {
            try
            {
                await Task.Run(() => 
                { 
                    while (true)
                    {
                        if(isRealTimeExitsMark) { break; }
                        Thread.Sleep(5);
                    }
                });
                
                cts?.Cancel();

                inverterCommunicationControl.CloseSerialPort();
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> CloseSerialPortAsync2()
        {
            try
            {
                await taskTimeExits;
                cts?.Cancel();

                inverterCommunicationControl.CloseSerialPort();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }






        /// <summary>
        /// 执行正转
        /// </summary>
        /// <param name="inverterEntity"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool ExcuteForward(InverterEntity inverterEntity, out string res)
        {
            try
            {
                inverterCommunicationControl.ExecuteForward(inverterEntity);
                res = "执行成功";
                return true;
            }
            catch (Exception ex)
            {
                res = $"执行失败 \r\n，{ex.Message} !";
                return false;
            }
        }


        /// <summary>
        /// 执行反转
        /// </summary>
        /// <param name="inverterEntity"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool ExcuteReverse(InverterEntity inverterEntity, out string res)
        {
            try
            {
                inverterCommunicationControl.ExecuteReverse(inverterEntity);
                res = "执行成功";
                return true;
            }
            catch (Exception ex)
            {
                res = $"执行失败 \r\n，{ex.Message} !";
                return false;
            }
        }


        /// <summary>
        /// 执行停止
        /// </summary>
        /// <param name="inverterEntity"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool ExcuteStop(InverterEntity inverterEntity, out string res)
        {
            try
            {
                inverterCommunicationControl.ExecuteStop(inverterEntity);
                res = "执行成功";
                return true;
            }
            catch (Exception ex)
            {
                res = $"执行失败 \r\n，{ex.Message} !";
                return false;
            }
        }


        /// <summary>
        /// 执行设置频率
        /// </summary>
        /// <param name="inverterEntity"></param>
        /// <param name="frequencyValue"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool ExeSetFrequency(InverterEntity inverterEntity,double frequencyValue, out string res)
        {
            try
            {
                inverterCommunicationControl.ExecuteSetFrequency(inverterEntity,frequencyValue);
                res = "执行成功";
                return true;
            }
            catch (Exception ex)
            {
                res = $"执行失败 \r\n，{ex.Message} !";
                return false;
            }
        }


        public void RealTimeReadInverterData(InverterEntity inverterEntity)
        {   
            cts = new CancellationTokenSource();
            isRealTimeExitsMark = false;
            Task.Run(() => 
            {
                try
                {
                    while (!cts.IsCancellationRequested)
                    {
                        inverterCommunicationControl.GetRunningStatus(inverterEntity);
                        inverterCommunicationControl.GetRunningFrequency(inverterEntity);
                        inverterCommunicationControl.GetOutCurrent(inverterEntity);
                        inverterCommunicationControl.GetOutVoltage(inverterEntity);
                        Thread.Sleep(10);
                    }
                    isRealTimeExitsMark = true;
                }
                catch (Exception ex)
                {
                    isRealTimeExitsMark = true;
                }
            }, cts.Token);
        }


        public void RealTimeReadInverterData2(InverterEntity inverterEntity)
        {
            cts = new CancellationTokenSource();

            taskTimeExits = Task.Run(() =>
            {
                try
                {
                    while (!cts.IsCancellationRequested)
                    {
                        inverterCommunicationControl.GetRunningStatus(inverterEntity);
                        inverterCommunicationControl.GetRunningFrequency(inverterEntity);
                        inverterCommunicationControl.GetOutCurrent(inverterEntity);
                        inverterCommunicationControl.GetOutVoltage(inverterEntity);
                        Thread.Sleep(10);
                    }
                    
                }
                catch (Exception ex)
                {
                    
                }
            }, cts.Token);
        }

    }
}
