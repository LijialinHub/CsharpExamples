using _2025_12_18;
using HslCommunication;
using HslCommunication.Profinet.Melsec;
using IniHelper;
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

namespace _2025_12_27
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 串口参数数据
        /// </summary>
        private SerialParamatersEntity serialParamatersEntity = new SerialParamatersEntity();

        /// <summary>
        /// Ini文件读取
        /// </summary>
        private IniFiles iniFiles = new IniFiles(Environment.CurrentDirectory + @"\参数.ini");

        /// <summary>
        /// 创建FxSerial编程口协议通讯对象
        /// </summary>
        private MelsecFxSerial melsecFxSerial = new MelsecFxSerial();

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
            serialParamatersEntity.DataBits = int.Parse(iniFiles.ReadString("通讯参数", "数据位", "7"));
            serialParamatersEntity.ParityBits = (Parity)Enum.Parse(typeof(Parity), iniFiles.ReadString("通讯参数", "校验位", "Even"));
            serialParamatersEntity.StopBits = (StopBits)Enum.Parse(typeof(StopBits), iniFiles.ReadString("通讯参数", "停止位", "One"));

            #endregion

            #region 数据绑定

            cmbBaudRate.DataBindings.Add("SelectedItem", serialParamatersEntity, "BaudRate");

            cmbDataBit.DataBindings.Add("SelectedItem", serialParamatersEntity, "DataBits");

            cmbParityBit.DataBindings.Add("SelectedItem", serialParamatersEntity, "ParityBits");

            cmbStopBit.DataBindings.Add("SelectedItem", serialParamatersEntity, "StopBits");

            #endregion


            //控件使能
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;


        }


        /// <summary>
        /// 窗体关闭时保存参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //保存到Ini文件
            iniFiles.WriteString("通讯参数", "波特率", serialParamatersEntity.BaudRate.ToString());
            iniFiles.WriteString("通讯参数", "数据位", serialParamatersEntity.DataBits.ToString());
            iniFiles.WriteString("通讯参数", "校验位", serialParamatersEntity.ParityBits.ToString());
            iniFiles.WriteString("通讯参数", "停止位", serialParamatersEntity.StopBits.ToString());
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(btnOpen.Text == "打开")
            {
                melsecFxSerial.SerialPortInni(serialParamatersEntity.PortName, serialParamatersEntity.BaudRate, serialParamatersEntity.DataBits, serialParamatersEntity.StopBits, serialParamatersEntity.ParityBits);

                if(! melsecFxSerial.IsOpen())
                {

                    melsecFxSerial.Open();  //打开串口
                }

                btnOpen.Text = "关闭";
                btnOpen.BackColor = Color.Red;

            }
            else//关闭
            {
                melsecFxSerial?.Close();
                btnOpen.Text = "打开";
                btnOpen.BackColor = Color.FromArgb(128, 255, 128);
            }

        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            //保存到Ini文件
            iniFiles.WriteString("通讯参数", "波特率", serialParamatersEntity.BaudRate.ToString());
            iniFiles.WriteString("通讯参数", "数据位", serialParamatersEntity.DataBits.ToString());
            iniFiles.WriteString("通讯参数", "校验位", serialParamatersEntity.ParityBits.ToString());
            iniFiles.WriteString("通讯参数", "停止位", serialParamatersEntity.StopBits.ToString());
        }

        private void cmbPortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialParamatersEntity.PortName = cmbPortName.Text;
        }

        private void btnReadD16_Click(object sender, EventArgs e)
        {
            string address = "D" + nudWriteD16Address.Value.ToString();
            OperateResult operateResult = melsecFxSerial.Write(address, (short)nudWriteD16Value.Value);

            if(!operateResult.IsSuccess)
            {
                errorProvider1.SetError(nudWriteD16Address, operateResult.Message);
            }
            else
            {
                errorProvider1.SetError(nudWriteD16Address, null);
            }
        }

        private void btnReadD32_Click(object sender, EventArgs e)
        {

        }

        private void btnReadDFloat_Click(object sender, EventArgs e)
        {

        }

        

        
    }
}
