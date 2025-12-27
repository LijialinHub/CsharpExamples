using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniHelper;

namespace _2025_12_18
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 串口参数数据
        /// </summary>
        private SerialParamatersEntity serialParamatersEntity = new SerialParamatersEntity();

        /// <summary>
        /// Ini文件读取
        /// </summary>
        private IniFiles iniFiles = new IniFiles(Environment.CurrentDirectory + @"\参数.ini");

        /// <summary>
        /// 串口通讯业务逻辑类对象
        /// </summary>
        private SerialCommunicationBLL SerialCommunicationBLL = new SerialCommunicationBLL();

        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            #region 设置combox中的选项
            //端口号
            string[] portNames = SerialPort.GetPortNames();
            cmbPortName.DataSource = portNames;
            if (portNames.Length > 0)
            {
                serialParamatersEntity.PortName = portNames[0];
            }

            //波特率
            cmbBaudRate.DataSource = new int[] { 2400, 4800, 9600, 19200, 38400, 57600, 115200 };

            //数据位
            cmbDataBit.DataSource = new int[] { 7, 8 };

            //检验位
            cmbParityBit.DataSource = Enum.GetValues(typeof(Parity));

            //停止位
            cmbStopBit.DataSource = Enum.GetValues(typeof(StopBits));

            #endregion

            #region 从Ini文件读取实体数据
            serialParamatersEntity.BaudRate = int.Parse(iniFiles.ReadString("通讯参数", "波特率", "9600"));
            serialParamatersEntity.DataBits = int.Parse(iniFiles.ReadString("通讯参数", "数据位", "8"));
            serialParamatersEntity.ParityBits = (Parity)Enum.Parse(typeof(Parity), iniFiles.ReadString("通讯参数", "校验位", "Even"));
            serialParamatersEntity.StopBits = (StopBits)Enum.Parse(typeof(StopBits), iniFiles.ReadString("通讯参数", "停止位", "One"));

            #endregion

            #region 数据绑定

            cmbBaudRate.DataBindings.Add("SelectedItem", serialParamatersEntity, "BaudRate");

            cmbDataBit.DataBindings.Add("SelectedItem", serialParamatersEntity, "DataBits");

            cmbParityBit.DataBindings.Add("SelectedItem", serialParamatersEntity, "ParityBits");

            cmbStopBit.DataBindings.Add("SelectedItem", serialParamatersEntity, "StopBits");

            #endregion

            #region 控件的使能

            groupBox2.Enabled = false;
            groupBox3.Enabled = false;

            #endregion

            //定时器绑定nudTimeSet
            nudTimeSet.DataBindings.Add("Value", timer1, "Interval");


        }


        /// <summary>
        /// 打开_关闭串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "打开")
            {
                if (string.IsNullOrWhiteSpace(serialParamatersEntity.PortName))
                {
                    MessageBox.Show("未找到串口!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SerialCommunicationBLL.SerialPort = new SerialPort()
                {
                    PortName = serialParamatersEntity.PortName,
                    BaudRate = serialParamatersEntity.BaudRate,
                    DataBits = serialParamatersEntity.DataBits,
                    Parity = serialParamatersEntity.ParityBits,
                    StopBits = serialParamatersEntity.StopBits
                };

                SerialCommunicationBLL.IsSelectHex = radHexadecimalReception.Checked;

                if (SerialCommunicationBLL.OpenSerialPort(out string res))  //打开串口
                {
                    button1.Text = "关闭";
                    button1.BackColor = Color.Red;

                    SerialCommunicationBLL.ReceiveDataUIDoSomething += SerialCommunicationBLL_ReceiveDataUIDoSomething;

                    groupBox2.Enabled = true;
                    groupBox3.Enabled = true;

                    MessageBox.Show(res, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else    //打开失败
                {
                    MessageBox.Show(res, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            else  //关闭串口
            {
                if (SerialCommunicationBLL.CloseSerialPort(out string res))  //成功
                {
                    button1.Text = "打开";
                    button1.BackColor = Color.FromArgb(128, 255, 128);
                    SerialCommunicationBLL.ReceiveDataUIDoSomething -= SerialCommunicationBLL_ReceiveDataUIDoSomething;

                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                }
            }
        }


        /// <summary>
        /// 接收到数据UI执行的事件
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void SerialCommunicationBLL_ReceiveDataUIDoSomething(string obj)
        {
            ListViewItem listViewItem = new ListViewItem(DateTime.Now.ToString("HH:mm:ss"));

            listViewItem.SubItems.Add(obj);

            this.Invoke(new Action(() => 
            {
                listViewDisplay.Items.Insert(0, listViewItem);
            }));
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //保存到Ini文件
            iniFiles.WriteString("通讯参数", "波特率", serialParamatersEntity.BaudRate.ToString());
            iniFiles.WriteString("通讯参数", "数据位", serialParamatersEntity.DataBits.ToString());
            iniFiles.WriteString("通讯参数", "校验位", serialParamatersEntity.ParityBits.ToString());
            iniFiles.WriteString("通讯参数", "停止位", serialParamatersEntity.StopBits.ToString());
        }


        /// <summary>
        /// 清除发送的文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSendText_Click(object sender, EventArgs e)
        {
            txtSend.Clear();
        }

        /// <summary>
        /// 串口号更改事件 更改后更新到实体类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialParamatersEntity.PortName = cmbPortName.Text;
        }

        /// <summary>
        /// 选择以字符串接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radStringReception_CheckedChanged(object sender, EventArgs e)
        {
            SerialCommunicationBLL.IsSelectHex = radHexadecimalReception.Checked;
        }

        /// <summary>
        /// 清除接收的数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearReceptionText_Click(object sender, EventArgs e)
        {
            listViewDisplay.Items.Clear();
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string res;
            bool isSendOk = radHexadecimalSend.Checked ?
                            SerialCommunicationBLL.SendHexData(txtSend.Text, out res) :
                            SerialCommunicationBLL.SendStrData(txtSend.Text, out res);

            if (!isSendOk)
            {
                //MessageBox.Show(res,"错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(btnSend, isSendOk ? null : res);
            }
        }

        /// <summary>
        /// 定时发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScheduledSend_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        /// <summary>
        /// 停止发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopSend_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        /// <summary>
        /// 每隔一段时间发送一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

            // 动态获取最新的间隔值
            timer1.Interval = (int)nudTimeSet.Value;

            string res;
            bool isSendOk = radHexadecimalSend.Checked ?
                            SerialCommunicationBLL.SendHexData(txtSend.Text, out res) :
                            SerialCommunicationBLL.SendStrData(txtSend.Text, out res);
        }
    }
}
