using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _2025_12_22
{
    public partial class Form1 : Form
    {   
        /// <summary>
        /// TCP服务器
        /// </summary>
        TcpServer tcpServer;
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 开始监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartListen_Click(object sender, EventArgs e)
        {
            try
            {   if(btnStartListen.Text == "开始监听")
                {   
                    btnStartListen.Text = "断开监听";
                    btnStartListen.BackColor = Color.Red;

                    tcpServer = new TcpServer();

                    IPAddress iPAddress = IPAddress.Parse(txtLocalIP.Text);
                    int port = int.Parse(txtPort.Text);
                    if (tcpServer.StartListen(iPAddress, port, out string res))
                    {
                       

                        tcpServer.WaitAnyClientConnect(
                            str => 
                            {
                                string info = $"[{DateTime.Now.ToString("HH:mm:ss")}]: {str} 已连接本机\r\n";
                                this.Invoke(new Action(() => 
                                {
                                    txtConnectState.AppendText(info);
                                    cmbDstIP_Port.Items.Add(str);
                                    cmbDstIP_Port.SelectedIndex = cmbDstIP_Port.Items.Count - 1;
                                }));  
                            },
                            str =>
                            {
                                string info = $"[{DateTime.Now.ToString("HH:mm:ss")}]:等待客户端连接异常,{str}\r\n";
                                this.Invoke(new Action(() =>
                                {
                                    txtConnectState.AppendText(info);
                                    cmbDstIP_Port.Items.Clear();
                                }));
                            },
                            (clientIpStr, str) =>
                            {
                                string info = $"[{DateTime.Now.ToString("HH:mm:ss")}]:[{clientIpStr}] :{str}\r\n";
                                this.Invoke(new Action(() =>
                                {
                                    txtReceiceMsg.AppendText(info);
                                }));
                            },
                            (clientIpStr, str) =>
                            {
                                string info = $"[{DateTime.Now.ToString("HH:mm:ss")}]: {str}\r\n";
                                this.Invoke(new Action(() =>
                                {
                                    txtConnectState.AppendText(info);
                                    cmbDstIP_Port.Items.Remove(clientIpStr);
                                    if(cmbDstIP_Port.Items.Count > 0) 
                                    { 
                                        cmbDstIP_Port.SelectedIndex = 0; 
                                    }
                                }));
                            }
                            );
                        string info2 = $"[{DateTime.Now.ToString("HH:mm:ss")}]: {res}\r\n";
                        txtConnectState.AppendText(info2);
                    }
                }
                else   //断开监听
                {
                    if(tcpServer.CloseListen(out string res))
                    {
                        btnStartListen.Text = "开始监听";
                        btnStartListen.BackColor = Color.FromArgb(192, 255, 192);
                    }
                    string listenStr = $"[{DateTime.Now.ToString("HH:mm:ss")}]: {res}\r\n";
                    txtConnectState.AppendText (listenStr);
                }
                
            }
            catch (Exception ex)
            {

                
            }
        }


        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load_1(object sender, EventArgs e)
        {
            //获取本地IP
            //IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            //foreach (var item in ipEntry.AddressList)
            //{
            //    if(item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            //    {
            //        txtLocalIP.Text = item.ToString();
            //    }
            //}

            //多网卡情况
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.Name == "WLAN")
                {
                    IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();

                    foreach (UnicastIPAddressInformation ipAddressInfo in ipProperties.UnicastAddresses)
                    {
                        if (ipAddressInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            txtLocalIP.Text = ipAddressInfo.Address.ToString();
                        }
                    }
                }
            }

        }

       

        /// <summary>
        /// 清除接收的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearMsg_Click(object sender, EventArgs e)
        {
            txtReceiceMsg.Clear();
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if(!tcpServer.SendData(cmbDstIP_Port.Text, txtSendMsg.Text, out string res))
            {
                string listenStr = $"[{DateTime.Now.ToString("HH:mm:ss")}]: {res}\r\n";
                txtConnectState.AppendText(listenStr);
            }
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            tcpServer.MassSending(txtSendMsg.Text, out string res);
        }

        private void txtReceiceMsg_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

    


