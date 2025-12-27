using HslCommunication;
using HslCommunication.Profinet.Melsec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 与FX5U系列PLC的MC通讯
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MC连接对象
        /// </summary>
        private MelsecMcNet mcNet;

        /// <summary>
        /// 打开_关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_DisConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect_DisConnect.Text == "连接")
            {
                string plcIpAddress = txtIP.Text;//PLC的IP地址
                int plcPort=int.Parse(txtPort.Text);//端口号
                mcNet=new MelsecMcNet(plcIpAddress, plcPort);
                OperateResult result= mcNet.ConnectServer();//连接服务器(PLC)
                if (!result.IsSuccess)
                { 
                    MessageBox.Show("连接失败!" + result.Message, "消息提示",
                                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                }
                else//成功
                {
                    MessageBox.Show("连接成功!" + result.Message, "消息提示",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnConnect_DisConnect.Text = "断开";
                    btnConnect_DisConnect.BackColor = Color.Red;

                }

            }
            else
            {
                mcNet.ConnectClose();
                btnConnect_DisConnect.Text = "连接";
                btnConnect_DisConnect.BackColor = Color.Linen;

            }
        }

        /// <summary>
        /// 写入16位整数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteD16_Click(object sender, EventArgs e)
        {
            string address = "D" + nudWriteD16Adderss.Value.ToString();
            OperateResult operate = mcNet.Write(address, (short)nudWriteD16Value.Value);

            if (!operate.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudWriteD16Adderss, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudWriteD16Adderss, null);
            }

        }

        /// <summary>
        /// 写入32位整数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteD32_Click(object sender, EventArgs e)
        {
            string address = "D" + nudWriteD32Adderss.Value.ToString();
            OperateResult operate = mcNet.Write(address, (int)nudWriteD32Value.Value);

            if (!operate.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudWriteD32Adderss, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudWriteD32Adderss, null);
            }
        }
        /// <summary>
        /// 写入32位浮点数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteDFloat_Click(object sender, EventArgs e)
        {
            string address = "D" + numWriteDFloatAdderss.Value.ToString();
            OperateResult operate = mcNet.Write(address, (float)numWriteDFloatValue.Value);

            if (!operate.IsSuccess)//不成功
            {
                //Message: 异常信息
                errorProvider1.SetError(numWriteDFloatAdderss, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(numWriteDFloatAdderss, null);
            }
        }
        /// <summary>
        /// 读取16位整数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadD16_Click(object sender, EventArgs e)
        {
            string address = "D" + nudReadD16Adderss.Value.ToString();
            OperateResult<short> result = mcNet.ReadInt16(address);

            if (!result.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudReadD16Adderss, result.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudReadD16Adderss, null);
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
            string address = "D" + nudReadD32Adderss.Value.ToString();
            OperateResult<int> result = mcNet.ReadInt32(address);

            if (!result.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudReadD32Adderss, result.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudReadD32Adderss, null);
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
            string address = "D" + numReadDFloatAdderss.Value.ToString();
            OperateResult<float> result = mcNet.ReadFloat(address);

            if (!result.IsSuccess)//不成功
            {
                errorProvider1.SetError(numReadDFloatAdderss, result.Message);
            }
            else//成功
            {
                errorProvider1.SetError(numReadDFloatAdderss, null);
                numReadDFloatValue.Value = (decimal)result.Content;

            }
        }

        /// <summary>
        /// 读取M点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadM_Click(object sender, EventArgs e)
        {
            string address = "M" + nudMAdderss.Value.ToString();
            OperateResult<bool> result = mcNet.ReadBool(address);

            if (!result.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudMAdderss, result.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudMAdderss, null);
                userLantern_M.LanternBackground = result.Content ? Color.Red : Color.Gray;
            }
        }

        /// <summary>
        /// 连接M点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnM_On_Click(object sender, EventArgs e)
        {
            string address = "M" + nudMAdderss.Value.ToString();
            OperateResult operate = mcNet.Write(address, true);

            if (!operate.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudMAdderss, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudMAdderss, null);
            }
        }
        /// <summary>
        /// 断开M点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnM_off_Click(object sender, EventArgs e)
        {
            string address = "M" + nudMAdderss.Value.ToString();
            OperateResult operate = mcNet.Write(address, false);

            if (!operate.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudMAdderss, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudMAdderss, null);
            }
        }

        /// <summary>
        /// 读取Y点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadY_Click(object sender, EventArgs e)
        {
            string address = "Y" + nudYAdderss.Value.ToString();
            OperateResult<bool> result = mcNet.ReadBool(address);

            if (!result.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudYAdderss, result.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudYAdderss, null);
                userLantern_Y.LanternBackground = result.Content ? Color.Red : Color.Gray;
            }
        }

        /// <summary>
        /// 连接Y点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnY_On_Click(object sender, EventArgs e)
        {
            string address = "Y" + nudYAdderss.Value.ToString();
            OperateResult operate = mcNet.Write(address, true);

            if (!operate.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudYAdderss, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudYAdderss, null);
            }
        }

        /// <summary>
        /// 断开Y点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnY_off_Click(object sender, EventArgs e)
        {
            string address = "Y" + nudYAdderss.Value.ToString();
            OperateResult operate = mcNet.Write(address, false);

            if (!operate.IsSuccess)//不成功
            {
                errorProvider1.SetError(nudYAdderss, operate.Message);
            }
            else//成功
            {
                errorProvider1.SetError(nudYAdderss, null);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
