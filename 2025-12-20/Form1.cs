using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TcpClient tcpClient;


        /// <summary>
        /// 连接&&断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (btnConnection.Text == "连接")
            {   
                tcpClient = new TcpClient();
                
                if(tcpClient.StartConnect(txtServerIP.Text.Trim(), Convert.ToInt32(mtxtServerPort.Text), out string res))
                {
                    this.Text = $"TCP客户端[{tcpClient.GetLocalIPAndPort()}]";
                    tcpClient.RealTimeReceive(
                        receiveData=> 
                    {
                        string receiveInfo = $"{DateTime.Now.ToString("HH:mm:ss")} : {receiveData}\r\n";
                        this.Invoke(new Action(() => 
                        {
                            txtReceiveMsg.AppendText(receiveInfo);   
                        }));
                    }, exceptionData => 
                    {
                        string exceptionInfo = $"{DateTime.Now.ToString("HH:mm:ss")} : {exceptionData}\r\n";
                        this.Invoke(new Action(() =>  //异常消息
                        {
                            txtConnectionMsg.Text = exceptionInfo;

                            if (tcpClient.CloseConnect(out string res2))  //异常直接断开
                            {
                                btnConnection.Text = "连接";
                                btnConnection.BackColor = Color.FromArgb(128, 255, 128);
                            }
                            
                        }));
                    });

                    btnConnection.Text = "断开";
                    btnConnection.BackColor = Color.Red;
                }
                string conInfo = $"{DateTime.Now.ToString("HH:mm:ss")} : {res}\r\n";

                txtConnectionMsg.AppendText(conInfo);
            }
            else //断开
            {

                if(tcpClient.CloseConnect(out string res))
                {
                    btnConnection.Text = "连接";
                    btnConnection.BackColor = Color.FromArgb(128, 255, 128);
                }
                string conInfo = $"{DateTime.Now.ToString("HH:mm:ss")} : {res}\r\n";
                txtConnectionMsg.AppendText(conInfo);
            }
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (tcpClient != null) 
            {
                if(!tcpClient.SendData(txtSendMsg.Text, out string res))
                {
                    string conInfo = $"{DateTime.Now.ToString("HH:mm:ss")} : {res}\r\n";
                    txtConnectionMsg.AppendText(conInfo);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 清除连接信息显示框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearConnectionMsg_Click(object sender, EventArgs e)
        {
            txtConnectionMsg.Clear();
        }

        private void btnClearSendMsg_Click(object sender, EventArgs e)
        {
            txtSendMsg.Clear();
        }

        private void btnClearReceiveMsg_Click(object sender, EventArgs e)
        {
            txtReceiveMsg.Clear();
        }
    }
}
