using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus;
using Modbus.Device;
using Modbus.Extensions.Enron;

namespace _2025_12_26
{
    public partial class Form1 : Form
    {   
        /// <summary>
        /// Modbus_TCP 主站
        /// </summary>
        ModbusIpMaster ModbusIpMaster;

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// 连接_断开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if(btnConnect.Text == "连接")
                {
                    TcpClient tcpClient = new TcpClient(); //创建一个tcpclient对象
                    tcpClient.Connect(IPAddress.Parse(txtIP.Text), int.Parse(txtPort.Text));

                    ModbusIpMaster = ModbusIpMaster.CreateIp(tcpClient); //创建ModbusTcp主站/客户端
                    btnConnect.Text = "断开";
                    btnConnect.BackColor = Color.Red;
                }
                else //断开
                {
                    btnConnect.Text = "连接";
                    btnConnect.BackColor = Color.Lime;
                    ModbusIpMaster.Dispose(); //释放资源
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 16位整数写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteD16_Click(object sender, EventArgs e)
        {
            //PLC的保持寄存器就是D区的点位
            //D点： D0-D20479 地址范围是0-20479
            ushort address = (ushort)nudWriteD16Address.Value;
            ushort value = (ushort)nudWriteD16Value.Value;
            ModbusIpMaster.WriteSingleRegisterAsync(1, address, value);
        }

        /// <summary>
        /// 32位双整数写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteD32_Click(object sender, EventArgs e)
        {

            ushort address = (ushort)nudWriteD32Address.Value;
            uint value = (uint)nudWriteD32Value.Value;
            ModbusIpMaster.WriteSingleRegister32(1, address, value);

        }

        /// <summary>
        /// 32位浮点写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteDFloat_Click(object sender, EventArgs e)
        {
            ushort address = (ushort)nudWriteFloatAddress.Value;
            float value = (float)nudWriteFloatValue.Value;

            byte[] bytes = BitConverter.GetBytes(value);
            uint res = BitConverter.ToUInt32(bytes, 0);

            ModbusIpMaster.WriteSingleRegister32(1, address, res);
        }

        /// <summary>
        /// 16位整数读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadD16_Click(object sender, EventArgs e)
        {
            ushort address = (ushort)nudReadD16Address.Value;
            ushort[] res = ModbusIpMaster.ReadHoldingRegisters(1, address, 1);
            nudReadD16Value.Value = res[0];
        }

        /// <summary>
        /// 32位双整数读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadD32_Click(object sender, EventArgs e)
        {
            ushort address = (ushort)nudReadD32Address.Value;
            uint[] res = ModbusIpMaster.ReadHoldingRegisters32(1, address, 1);
            nudReadD32Value.Value = res[0];
        }

        /// <summary>
        /// 32位浮点读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadDFloat_Click(object sender, EventArgs e)
        {
            ushort address = (ushort)nudReadDFloatAddress.Value;
            uint[] res = ModbusIpMaster.ReadHoldingRegisters32(1, address, 1);
            byte[] bytes = BitConverter.GetBytes(res[0]);
            float r = BitConverter.ToSingle(bytes, 0);
            nudReadDFloatValue.Value = (decimal)r;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnReadM_Click(object sender, EventArgs e)
        {
            ushort address = (ushort)nudMAddress.Value;
            bool[] res = ModbusIpMaster.ReadCoils(1, address, 1);
            lblMStatus.BackColor = res[0] ? Color.Red : Color.Gray;
        }

        private void btnM_On_Click(object sender, EventArgs e)
        {
            ushort address = (ushort)nudMAddress.Value;
            ModbusIpMaster.WriteSingleCoil(1, address, true);
        }

        private void btnM_Off_Click(object sender, EventArgs e)
        {
            ushort address = (ushort)nudMAddress.Value;
            ModbusIpMaster.WriteSingleCoil(1, address, false);
        }

        private void btnReadY_Click(object sender, EventArgs e)
        {
            ushort address = (ushort)(Convert.ToUInt16(nudYAddress.Value.ToString(),8) + 24576);
            bool[] res = ModbusIpMaster.ReadCoils(1, address, 1);
            lblYStatus.BackColor = res[0] ? Color.Red : Color.Gray;
        }

        private void btnY_On_Click(object sender, EventArgs e)
        {
            ushort address = (ushort)(Convert.ToUInt16(nudYAddress.Value.ToString(), 8) + 24576);
            ModbusIpMaster.WriteSingleCoil(1, address, true);
        }

        private void btnY_Off_Click(object sender, EventArgs e)
        {
            ushort address = (ushort)(Convert.ToUInt16(nudYAddress.Value.ToString(), 8) + 24576);
            ModbusIpMaster.WriteSingleCoil(1, address, false);
        }
    }
}
