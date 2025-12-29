using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus;
using Modbus.Device;

namespace 温度计
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 串口参数实体类
        /// </summary>
        private SerialParamatersEntity serialParamatersEntity = new SerialParamatersEntity();

        /// <summary>
        /// 串口对象
        /// </summary>
        private SerialPort serialPort;
        
        /// <summary>
        /// Modbus对象
        /// </summary>
        private IModbusMaster ModbusMaster;

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

            #region 数据绑定

            cmbBaudRate.DataBindings.Add("SelectedItem", serialParamatersEntity, "BaudRate");

            cmbDataBit.DataBindings.Add("SelectedItem", serialParamatersEntity, "DataBits");

            cmbParityBit.DataBindings.Add("SelectedItem", serialParamatersEntity, "ParityBits");

            cmbStopBit.DataBindings.Add("SelectedItem", serialParamatersEntity, "StopBits");
            #endregion


        }

        /// <summary>
        /// 打开/关闭串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnOpen_Close_Click(object sender, EventArgs e)
        {
            if(btnOpen_Close.Text == "打开")
            {
                serialPort = new SerialPort();
                serialPort.PortName = serialParamatersEntity.PortName;
                serialPort.BaudRate = serialParamatersEntity.BaudRate;
                serialPort.DataBits = serialParamatersEntity.DataBits;
                serialPort.Parity = serialParamatersEntity.ParityBits;
                serialPort.StopBits = serialParamatersEntity.StopBits;
                serialPort.Open();
                ModbusMaster = ModbusSerialMaster.CreateRtu(serialPort);

                btnOpen_Close.Text = "关闭";
                btnOpen_Close.BackColor = Color.Red;

                //读取数据
                await Task.Run(() =>
                {
                   
                    while (true)
                    {
                        try
                        {
                            //读取数据
                            var result = ModbusMaster.ReadHoldingRegisters(1, (ushort)0, 2);
                            //显示数据
                            this.Invoke(new Action(() =>
                            {
                                //更新温度和湿度
                                lblTemp.Text = Convert.ToString(result[1] / 10.0);
                                lblHumidity.Text = Convert.ToString(result[0] / 10.0);
                            }));

                            Thread.Sleep(300);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                });
            }
            else
            {
                ModbusMaster.Dispose();
                serialPort.Close();
                btnOpen_Close.Text = "打开";
                btnOpen_Close.BackColor = Color.FromArgb(128, 255, 128);
            }
        }
    }
}
