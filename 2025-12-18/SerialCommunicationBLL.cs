using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_12_18
{   
    /// <summary>
    /// 串口通讯业务逻辑类
    /// </summary>
    public class SerialCommunicationBLL
    {

        /*通讯
         *打开串口(对于网口:开始连接)
         *关闭串口(对于网口:断开连接)
         *发送
         *接收
         */

        /// <summary>
        /// 串口对象
        /// </summary>
        public SerialPort SerialPort { get; set; }

        /// <summary>
        /// 是否选择以十六进制读取
        /// </summary>
        public bool IsSelectHex { get; set; }

        /// <summary>
        /// 接收到数据UI执行的动作
        /// </summary>
        public event Action<string> ReceiveDataUIDoSomething;

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="res">执行结果</param>
        /// <returns>true 打开成功 false 打开失败</returns>
        public bool OpenSerialPort(out string res)
        {
            try
            {   
                if(!SerialPort.IsOpen)
                {
                    SerialPort.Open();
                    SerialPort.DataReceived -= SerialPort_DataReceived;
                    SerialPort.DataReceived += SerialPort_DataReceived; //一旦串口收到数据，会自动进入 SerialPort.DataReceived事件订阅的方法(事件处理器)。
                    res = "打开串口成功!";
                }
                else
                {
                    res = "串口已打开!";
                }
                return true;
            }
            catch (Exception ex)
            {
                res = $"打开串口失败，{ex.Message} !";
                return false;
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (IsSelectHex) 
            { 
                ReadHexData(out string res1); 
            }
            else
            {
                ReadStrData(out string res2);
            }
                
        }


        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool CloseSerialPort(out string res)
        {
            try
            {
                if(SerialPort.IsOpen)
                {
                    SerialPort.Close();
                    res =  "串口关闭成功！";
                }
                else
                {
                    res =  "串口已关闭！";
                }

                    return true;
            }
            catch (Exception ex)
            {
                res = "串口关闭失败！\r\n"+ex.Message;
                return false;
            }

        }

        /// <summary>
        /// 以十六进制发送数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool SendHexData(string data, out string res)
        {
            try
            {
                byte[] buffer2 = data.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(str => { return Convert.ToByte(str, 16); }).ToArray();

                SerialPort.DiscardOutBuffer(); //清空输出缓冲区
                SerialPort.Write(buffer2, 0, buffer2.Length);
                res = $"{data} 发送成功!";
                return true;
            }
            catch (Exception ex)
            {
                res = "发送失败! " + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 以字符串发送数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool SendStrData(string data, out string res)    
        {
            try
            {
                SerialPort.DiscardOutBuffer(); //清空输出缓冲区
                SerialPort.Encoding = Encoding.UTF8; //按照UTF8编码发送
                SerialPort.Write(data);
                res = $"{data} 发送成功!";
                return true;
            }
            catch (Exception ex)
            {
                res = "发送失败! " + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 以十六进制形式接收数据
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool ReadHexData(out string res)
        {
            try
            {   
                
                byte[] buffer = new byte[SerialPort.ReadBufferSize];
                int num = SerialPort.Read(buffer, 0, buffer.Length);
                SerialPort.DiscardInBuffer(); //清除输入缓存

                string[] outStr = new string[num];
                for (int i = 0; i < num; i++)
                {
                    //outStr[i] = Convert.ToString(buffer[i], 16);
                    outStr[i] = buffer[i].ToString("X2");
                }

                string outStrRes = string.Join(" ", outStr);
                ReceiveDataUIDoSomething?.Invoke(outStrRes);

                res = "接收数据成功！";
                return true;

            }
            catch (Exception ex)
            {
                res = $"接收数据失败！ {ex.Message}";
                return false;
                
            }
        }


        /// <summary>
        /// 以字符串形式接收数据
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ReadStrData(out string res)
        {
            try
            {
                byte[] buffer = new byte[SerialPort.ReadBufferSize];
                int num = SerialPort.Read(buffer, 0, buffer.Length);
                string outStrRes = Encoding.UTF8.GetString(buffer, 0, num);
                SerialPort.DiscardInBuffer(); //清除输入缓存

                ReceiveDataUIDoSomething?.Invoke(outStrRes);

                res = "接收数据成功！";
                return true;
            }
            catch (Exception ex)
            {
                res = $"接收数据失败！ {ex.Message}";
                return false;
            }
        }

    }






}
