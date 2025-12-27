using _2025_12_18;
using HslCommunication;
using HslCommunication.Controls;
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

                //控件使能
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
                groupBox5.Enabled = true;


            }
            else//关闭
            {
                melsecFxSerial?.Close();
                btnOpen.Text = "打开";
                btnOpen.BackColor = Color.FromArgb(128, 255, 128);

                //控件使能
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
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


        /// <summary>
        /// 写入16位整数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteD16_Click(object sender, EventArgs e)
        {
            string address = "D" + nudWriteD16Address.Value.ToString();
            OperateResult operate = melsecFxSerial.Write(address, (short)nudWriteD16Value.Value);

            if (!operate.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudWriteD16Address, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudWriteD16Address, null);
            }

        }

        /// <summary>
        /// 写入32位整数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteD32_Click(object sender, EventArgs e)
        {
            string address = "D" + nudWriteD32Address.Value.ToString();
            OperateResult operate = melsecFxSerial.Write(address, (int)nudWriteD32Value.Value);

            if (!operate.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudWriteD32Address, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudWriteD32Address, null);
            }
        }
        /// <summary>
        /// 写入32位浮点数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteDFloat_Click(object sender, EventArgs e)
        {
            string address = "D" + nudWriteFloatAddress.Value.ToString();
            OperateResult operate = melsecFxSerial.Write(address, (float)nudWriteFloatValue.Value);

            if (!operate.IsSuccess)//不成功
            {
                //Message: 异常信息
                errorProvider1.SetError(nudWriteFloatAddress, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudWriteFloatAddress, null);
            }
        }
        /// <summary>
        /// 读取16位整数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadD16_Click(object sender, EventArgs e)
        {
            string address = "D" + nudReadD16Address.Value.ToString();
            OperateResult<short> result = melsecFxSerial.ReadInt16(address);

            if (!result.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudReadD16Address, result.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudReadD16Address, null);
                nudReadD16Value.Value = result.Content;
            }
        }
        /// <summary>
        /// 读取32位整数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadD32_Click(object sender, EventArgs e)
        {
            string address = "D" + nudReadD32Address.Value.ToString();
            OperateResult<int> result = melsecFxSerial.ReadInt32(address);

            if (!result.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudReadD32Address, result.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudReadD32Address, null);
                nudReadD32Value.Value = result.Content;
            }
        }
        /// <summary>
        /// 读取32位浮点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadDFloat_Click(object sender, EventArgs e)
        {
            string address = "D" + nudReadDFloatAddress.Value.ToString();
            OperateResult<float> result = melsecFxSerial.ReadFloat(address);

            if (!result.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudReadDFloatAddress, result.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudReadDFloatAddress, null);
                nudReadDFloatValue.Value = (decimal)result.Content;

            }
        }

        /// <summary>
        /// 读取M点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadM_Click(object sender, EventArgs e)
        {
            string address = "M" + nudMAddress.Value.ToString();
            OperateResult<bool> result = melsecFxSerial.ReadBool(address);

            if (!result.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudMAddress, result.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudMAddress, null);
                lblMStatus.LanternBackground = result.Content ? Color.Red : Color.Gray;
            }
        }

        /// <summary>
        /// 连接M点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnM_On_Click(object sender, EventArgs e)
        {
            string address = "M" + nudMAddress.Value.ToString();
            OperateResult operate = melsecFxSerial.Write(address, true);

            if (!operate.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudMAddress, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudMAddress, null);
            }
        }
        /// <summary>
        /// 断开M点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnM_off_Click(object sender, EventArgs e)
        {
            string address = "M" + nudMAddress.Value.ToString();
            OperateResult operate = melsecFxSerial.Write(address, false);

            if (!operate.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudMAddress, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudMAddress, null);
            }
        }

        /// <summary>
        /// 读取Y点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadY_Click(object sender, EventArgs e)
        {
            string address = "Y" + nudYAddress.Value.ToString();
            OperateResult<bool> result = melsecFxSerial.ReadBool(address);

            if (!result.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudYAddress, result.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudYAddress, null);
                lblYStatus.LanternBackground = result.Content ? Color.Red : Color.Gray;
            }
        }

        /// <summary>
        /// 连接Y点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnY_On_Click(object sender, EventArgs e)
        {
            string address = "Y" + nudYAddress.Value.ToString();
            OperateResult operate = melsecFxSerial.Write(address, true);

            if (!operate.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudYAddress, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudYAddress, null);
            }
        }

        /// <summary>
        /// 断开Y点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnY_off_Click(object sender, EventArgs e)
        {
            string address = "Y" + nudYAddress.Value.ToString();
            OperateResult operate = melsecFxSerial.Write(address, false);

            if (!operate.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudYAddress, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudYAddress, null);
            }
        }



    }
}
