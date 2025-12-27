using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_12_20
{
    /// <summary>
    /// TCP客户端类
    /// </summary>
    public class TcpClient
    {
        /// <summary>
        /// 客户端套接字对象
        /// </summary>
        private Socket ClientSocket;

        public TcpClient()
        {   
            //IP地址是协议版本4
            //套接字类型是字节流发送和接收
            //协议类型是TCP
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// 获取本地IP和端口号
        /// </summary>
        /// <returns></returns>
        public string GetLocalIPAndPort()
        {
            return ClientSocket.LocalEndPoint.ToString();
        }

        /// <summary>
        /// 开始连接
        /// </summary>
        /// <param name="ipString">服务器IP地址</param>
        /// <param name="port">服务器端口号</param>
        /// <param name="res">执行结果</param>
        /// <returns>True:执行成功 False:执行失败</returns>
        public bool StartConnect(string ipString, int port, out string res)
        {
            try
            {
                if(!ClientSocket.Connected)
                {
                    ClientSocket.Connect(IPAddress.Parse(ipString), port);
                }

                res = $"与 {ipString} 连接成功";
                string conInfo = $"{DateTime.Now.ToString("HH:mm:ss")} : {res}\r\n"; 
                return true;
            }
            catch (Exception ex)
            {
                res = $"与 {ipString} 连接失败 " + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool CloseConnect(out string res)
        {
            try
            {
                ClientSocket.Shutdown(SocketShutdown.Both);
                ClientSocket.Close();
                res = "与服务器断开并成功";
                return true;
            }
            catch (Exception ex)
            {
                res = "断开连接失败 " + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="strData"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool SendData(string strData, out string res)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(strData);
                ClientSocket.Send(buffer);
                res = $"【{ClientSocket.RemoteEndPoint.ToString()}】 {strData}";
                return true;
            }
            catch (Exception ex)
            {
                res = "发送数据失败 " + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 实时接收数据
        /// </summary>
        public void RealTimeReceive(Action<string> normalReceiveDoSomething,
                                    Action<string> exceptionReceiveDoSomething)
        {
            byte[] buffers = new byte[ClientSocket.ReceiveBufferSize];
            
            Task.Run(() => 
            {
                try
                {
                    while (true)
                    {
                        //num 实际收到的字节数
                        //只要收到数据Receive就会往下执行
                        // 1.如果对方（服务器）未发送数据
                        //ClientSocket.Receive 会阻塞 卡在这个地方
                        //2. 如果服务器发送了数据，num是实际接收到的字节数
                        //ClientSocket.Receive会继续往下执行
                        //3.服务器断线了，ClientSocket.Receive会不断接收到0个字节 num是0 不会阻塞

                        int num = ClientSocket.Receive(buffers);
                        if (num == 0)
                        {
                            throw new Exception("服务器断开！");
                        }
                        string str = Encoding.UTF8.GetString(buffers, 0, num);
                        normalReceiveDoSomething?.Invoke(str);
                    }
                }
                catch (Exception ex)
                {
                    exceptionReceiveDoSomething?.Invoke(ex.Message);
                }
            });

        }




    }
}
