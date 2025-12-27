using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _2025_12_22
{   
    /// <summary>
    /// TCP服务器类
    /// </summary>
    public class TcpServer
    {
        /// <summary>
        /// 服务器套接字对象
        /// </summary>
        private Socket ServerSocket;

        /// <summary>
        /// 词典集合
        /// </summary>
        private Dictionary<string, Socket> dc = new Dictionary<string, Socket>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public TcpServer()
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }


        /// <summary>
        /// 开始监听
        /// </summary>
        /// <param name="iPAddress"></param>
        /// <param name="localPort"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool StartListen(IPAddress iPAddress, int localPort, out string res)
        {
            try
            {
                EndPoint endPoint = new IPEndPoint(iPAddress, localPort);

                ServerSocket.Bind(endPoint);
                //挂起的连接队列的最大长度
                ServerSocket.Listen(10);
                res = "监听成功";
                return true;

            }
            catch (Exception ex)
            {

                res = $"监听失败 " + ex.Message;
                return false;
            }

        }


        /// <summary>
        /// 断开监听
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool CloseListen(out string res)
        {
            try
            {
                //ServerSocket?.Shutdown(SocketShutdown.Both);
                ServerSocket?.Close();  
                ServerSocket = null;
                res = "断开监听成功";
                return true;
            }
            catch (Exception ex)
            {

                res = "断开监听失败" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 实时等待任意客户端连接
        /// </summary>
        /// <param name="updataClientInfo">更新客户端信息消息执行的委托</param>
        /// <param name="exceptionAcceptDoSomething">异常客户端连接执行的委托</param>
        /// <param name="normalReceiveDoSomething">正常接收执行的委托</param>
        /// <param name="exceptionReceiveDoSomething">异常接收执行的委托</param>
        public void WaitAnyClientConnect(Action<string> updataClientInfo,
                                        Action<string> exceptionAcceptDoSomething,
                                        Action<string, string> normalReceiveDoSomething,
                                        Action<string, string> exceptionReceiveDoSomething)
        {
            Task.Run(() => 
            {
                try
                {
                    while (true)
                    {
                        //一旦有客户端主动连接过来，就会创建一个此客户端和本服务器的专属套接字
                        //这个套接字就可以用来为本地服务器和这个客户端的读写通讯
                        //如果没有客户端跟本地服务连接，阻塞在这个位置
                        Socket socket = ServerSocket.Accept();
                        //socket.RemoteEndPoint.ToString()表示客户端IP地址和端口号
                        dc.Add(socket.RemoteEndPoint.ToString(), socket);

                        updataClientInfo?.Invoke(socket.RemoteEndPoint.ToString()); //更新客户端消息要执行的动作
                        RealTimeReceive(socket, normalReceiveDoSomething, exceptionReceiveDoSomething);
                    }
                }
                catch (Exception ex)
                {
                    exceptionAcceptDoSomething?.Invoke(ex.Message); //异常连接要执行的动作
                    dc.Clear();
                    ServerSocket?.Close();
                    ServerSocket = null;
                }
            });

        }

        
        /// <summary>
        /// 实时接收数据
        /// </summary>
        /// <param name="socket">套接字</param>
        /// <param name=""></param>
        /// <param name="normalReceiveDoSomething">正常接收执行的委托</param>
        /// <param name="exceptionReceiveDoSomething">异常接收执行的委托</param>
        private void RealTimeReceive(Socket socket,
                                    Action<string,string> normalReceiveDoSomething,
                                    Action<string, string> exceptionReceiveDoSomething)
        {
            byte[] buffers = new byte[socket.ReceiveBufferSize];

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

                        int num = socket.Receive(buffers);
                        if (num == 0)
                        {
                            throw new Exception($"【{socket.RemoteEndPoint}】客户端断开！");
                        }
                        if(ServerSocket == null)
                        {
                            throw new Exception($"服务器断开！");
                        }
                        string str = Encoding.UTF8.GetString(buffers, 0, num);
                        normalReceiveDoSomething?.Invoke(socket.RemoteEndPoint.ToString(),str);
                    }
                }
                catch (Exception ex)
                {
                    exceptionReceiveDoSomething?.Invoke(socket.RemoteEndPoint.ToString(),$"与【{socket.RemoteEndPoint}】发生异常，"+ex.Message);
                    dc.Remove(socket.RemoteEndPoint.ToString()); //从词典移除这个客户端IP和端口号
                    socket?.Close();
                    socket = null;
                }
            });

        }


        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="strData"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool SendData(string clientIpPort,string strData, out string res)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(strData);
                dc[clientIpPort].Send(buffer);
                res = $"【{clientIpPort}】 {strData}";
                return true;
            }
            catch (Exception ex)
            {
                res = "发送数据失败 " + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 群发
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isContinues">一旦某个客户端发生异常是否继续</param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool MassSending(string data, out string res, bool isContinues = true)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);   
                foreach (var item in dc.Keys)
                {
                    if(!SendData(item, data, out string res1))
                    {
                        if (isContinues)
                        {
                            continue;
                        }
                        else 
                        {
                            throw new Exception("群发过程有客户端发生异常，终止发送"+ res1);
                        }
                    }
                }

                res = "群发成功！";
                return true;
            }
            catch (Exception ex)
            {

                res = "群发失败" + ex.Message;
                return false;
            }
        }

    }

}
