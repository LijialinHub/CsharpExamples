using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace _2025_11_24_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载G代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadSource_Click(object sender, EventArgs e)
        {   

            string filePath = "D:\\华山资料\\给网课学员类库及资料作业\\G代码.NC";
            //File类：文件的相关操作(创建、删除、移动....),读写小容量的txt文件
            txtDisplayRource.Text = File.ReadAllText(filePath);
            
        }

        private void btnDisplayCoord_Click(object sender, EventArgs e)
        {
            txtDisplayXY.Clear();

            MatchCollection matchCollection = Regex.Matches(txtDisplayRource.Text,
                @"[XY]-?\d+\.\d+");
            foreach (Match match in matchCollection) 
            {
                txtDisplayXY.AppendText(match.Value.ToString() + "\r\n");
            }

        }

        private void btnDisplayX_Click(object sender, EventArgs e)
        {
            txtDisplayX_Y.Clear();

            MatchCollection matchCollection = Regex.Matches(txtDisplayRource.Text,
                @"X-?\d+\.\d+");
            foreach (Match match in matchCollection)
            {
                txtDisplayX_Y.AppendText(match.Value.ToString() + "\r\n");
            }
        }

        private void btnDisplayY_Click(object sender, EventArgs e)
        {
            txtDisplayX_Y.Clear();

            MatchCollection matchCollection = Regex.Matches(txtDisplayRource.Text,
                @"Y-?\d+\.\d+");
            foreach (Match match in matchCollection)
            {
                txtDisplayX_Y.AppendText(match.Value.ToString() + "\r\n");
            }
        }

        private void txtDisplayRource_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
