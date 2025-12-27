using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_04_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            OperationRecords("按下了 正转运行按钮", Color.FromArgb(255, 224, 192));
        }


        private void btnReverse_Click(object sender, EventArgs e)
        {
            OperationRecords("按下了 反转运行按钮", Color.FromArgb(0, 224, 192));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            OperationRecords("按下了 停止按钮", Color.FromArgb(99, 224, 192));
        }

        private void btnFault_Click(object sender, EventArgs e)
        {
            OperationRecords("发生 故障信号", Color.FromArgb(10, 44, 192));
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            OperationRecords("按下了 故障复位 按钮", Color.FromArgb(30, 224, 44));
        }


        /// <summary>
        /// 操作记录
        /// </summary>
        /// <param name="info"></param>
        /// <param name="color"></param>
        private void OperationRecords(string info, Color color)
        {
            string currentTime = DateTime.Now.ToString("HH:mm::ss");
            string content = info;

            ListViewItem listViewItem = new ListViewItem(currentTime);
            listViewItem.SubItems.Add(content);
            listView1.Items.Insert(0, listViewItem);

            SaveToLog(info);
        }

        /// <summary>
        /// 保存到日志
        /// </summary>
        /// <param name="info"></param>
        private void SaveToLog(string info)
        {
            string path = Environment.CurrentDirectory + $@"\操作记录\{DateTime.Now.ToString("MM dd")}.txt";

            string content = DateTime.Now.ToString("HH:mm::ss") + ": " + info;

            File.AppendAllText(path, content+"\r\n");
            

        }

        private void 清除所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
