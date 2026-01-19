using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace Halcon_1
{
    public partial class Form1 : Form
    {   
        /// <summary>
        /// 图像处理类
        /// </summary>
        private HalconVision hv;
        
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            hv = new HalconVision(hWindowControl1);
            try
            {
                hv.openCamera();
                MessageBox.Show("打开相机成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            
        }

        private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            await hv.closeCamera();
            Environment.Exit(0);
        }

        /// <summary>
        /// 单次采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            await hv.SingleAcquire();
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = sender as TrackBar;
            hv.SetGain(trackBar.Value);
        }

        /// <summary>
        /// 连续采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            hv.RealTimeAcquire();
        }

        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            hv.SetExposureTiem(Convert.ToDouble(numericUpDown1.Value));
        }


        private void 打开单张图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //设置文件类型 png bmp jpg gif jepg
            openFileDialog.Filter = "Image File(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            openFileDialog.Title = "请选择图片";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                hv.ReadImageFile(openFileDialog.FileName);
            }
        }

        private async  void 打开图片文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //选择文件夹
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择文件夹";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                await hv.ReadImageFolder(folderBrowserDialog.SelectedPath);
            }
        }

    }
}