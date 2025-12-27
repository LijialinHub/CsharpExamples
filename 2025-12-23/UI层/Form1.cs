using IniHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_23
{
    public partial class Form1 : Form
    {   
        /// <summary>
        /// 串口参数数据实体对象
        /// </summary>
        private SerialParamatersEntity serialParamatersEntity = new SerialParamatersEntity();

        /// <summary>
        /// 变频器数据实体对象
        /// </summary>
        private InverterEntity inverterEntity = new InverterEntity();   

        /// <summary>
        /// 变频器控制逻辑处理对象
        /// </summary>
        private InverterContralBLL inverterContralBLL = new InverterContralBLL();


        public Form1()
        {
            InitializeComponent();
        }

        private void cmbBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //从INI文件中读取变频器数据
            bool isOk = inverterContralBLL.ReadInverterDataFromIni(inverterEntity, serialParamatersEntity, out string res);

            MessageBox.Show(res, 
                            isOk? "消息提示" : "错误提示❌", MessageBoxButtons.OK, 
                            isOk? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            

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

            mtxtStationNumber.DataBindings.Add("Text", inverterEntity, "StationNumber");

            #endregion

            //控件的使能
            tableLayoutPanel4.Enabled = false;


        }

        /// <summary>
        /// 打开_关闭串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnOpen_Close_Click(object sender, EventArgs e)
        {
            if(btnOpen_Close.Text == "打开")
            {
                if(inverterContralBLL.OpenSerialPort(serialParamatersEntity, out string res))
                {   
                    MessageBox.Show(res, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    inverterContralBLL.RealTimeReadInverterData2(inverterEntity);

                    inverterContralBLL.ExeSetFrequency(inverterEntity, (double)nudSetFre.Value, out res);


                    timerUpdataUIDisplayData.Start();

                    btnOpen_Close.Text = "关闭";
                    btnOpen_Close.BackColor = Color.Red;
                    tableLayoutPanel4.Enabled = true;
                }

               
            }
            else
            {   
                if(await inverterContralBLL.CloseSerialPortAsync2())
                {   
                    timerUpdataUIDisplayData.Stop();
                    btnOpen_Close.Text = "打开";
                    btnOpen_Close.BackColor = Color.FromArgb(128, 255, 128);
                    tableLayoutPanel4.Enabled = false;
                }
                
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            inverterContralBLL.SaveInverterDataToIni(inverterEntity, serialParamatersEntity, out string res);
        }

        /// <summary>
        /// 更新UI显示数据
        /// </summary>
        private void timerUpdataUIDisplayData_Tick(object sender, EventArgs e)
        {
            lblStop.BackColor = inverterEntity.IsStop ? Color.DimGray : Color.Red;
            lblForward.BackColor = inverterEntity.IsForward ? Color.Green : Color.DimGray;
            lblBack.BackColor = inverterEntity.IsReverse ? Color.Yellow : Color.DimGray;

            txtVoltage.Text = inverterEntity.OutputVoltage.ToString();
            txtCurrent.Text = inverterEntity.OutputCurrent.ToString();
            txtRunFre.Text = inverterEntity.RunningFrequency.ToString();
        }

        /// <summary>
        /// 窗体关闭
        /// </summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// 串口名称改变
        /// </summary>
        private void cmbPortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialParamatersEntity.PortName = cmbPortName.Text;
        }

        /// <summary>
        /// 正转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForward_Click(object sender, EventArgs e)
        {
            inverterContralBLL.ExcuteForward(inverterEntity, out string res);
            OperationRecords("按下了正转按钮!", res, Color.Blue);
        }

        /// <summary>
        /// 操作记录
        /// </summary>
        /// <param name="v"></param>
        /// <param name="res"></param>
        /// <param name="blue"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OperationRecords(string act, string res, Color color)
        {   
            string currentTime = DateTime.Now.ToString("HH:mm::ss");
            ListViewItem listViewItem = new ListViewItem(currentTime);
            listViewItem.ForeColor = color;
            listViewItem.SubItems.Add(act);
            listViewItem.SubItems.Add(res);
            listViewDisplay.Items.Insert(0, listViewItem);

            string path = Environment.CurrentDirectory + $@"\操作记录\{DateTime.Now.ToString("yyyy年MM月dd日")}";
            string content = currentTime + ": " + act + " " + res + "\r\n\r\n";
            File.AppendAllText(path, content);
        }

        /// <summary>
        /// 反转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            inverterContralBLL.ExcuteReverse(inverterEntity, out string res);
            OperationRecords("按下了反转按钮!", res, Color.Yellow);

        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            inverterContralBLL.ExcuteStop(inverterEntity, out string res);
            OperationRecords("按下了停止按钮!",res, Color.Red);
        }

        /// <summary>
        /// 设置频率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudSetFre_ValueChanged(object sender, EventArgs e)
        {
            inverterContralBLL.ExeSetFrequency(inverterEntity, (double)nudSetFre.Value, out string res);
            OperationRecords($"设置频率为{nudSetFre.Value}Hz", res, Color.Black);
        }

        /// <summary>
        /// 清空记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearRecord_Click(object sender, EventArgs e)
        {
            listViewDisplay.Items.Clear();
        }
    }
}
