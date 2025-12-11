using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniHelper;

namespace _2025_12_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private IniFiles iniFiles = new IniFiles(Environment.CurrentDirectory+@"\参数.Ini");

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //读取Ini参数
            nudXJogSpeed.Value = decimal.Parse(iniFiles.ReadString("轴参数", "X轴电动速度", "0"));
            nudYJogSpeed.Value = decimal.Parse(iniFiles.ReadString("轴参数", "Y轴电动速度", "0"));
            nudZJogSpeed.Value = decimal.Parse(iniFiles.ReadString("轴参数", "Z轴电动速度", "0"));
            nudZWorkHeight.Value = decimal.Parse(iniFiles.ReadString("轴参数", "Z轴工作高度", "0"));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //写入Ini参数
            iniFiles.WriteString("轴参数", "X轴电动速度", nudXJogSpeed.Value.ToString());
            iniFiles.WriteString("轴参数", "Y轴电动速度", nudYJogSpeed.Value.ToString());
            iniFiles.WriteString("轴参数", "Z轴电动速度", nudZJogSpeed.Value.ToString());
            iniFiles.WriteString("轴参数", "Z轴工作高度", nudZWorkHeight.Value.ToString());
        }
    }
}
