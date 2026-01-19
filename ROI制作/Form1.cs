using Halcon_1;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROI制作
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

        private async void 打开图片文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //选择文件夹
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择文件夹";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                await hv.ReadImageFolder(folderBrowserDialog.SelectedPath);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hv = new HalconVision(hWindowControl1);
            try
            {
                hv.openCamera();
                MessageBox.Show("打开相机成功！");

                if(File.Exists("region.bmp"))
                {
                    pictureBox1.Image = Image.FromFile("region.bmp");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            await hv.closeCamera();
            Environment.Exit(0);
        }

        /// <summary>
        /// 单张采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            await hv.SingleAcquire();
        }

        /// <summary>
        /// 实时采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            hv.RealTimeAcquire();
        }

        /// <summary>
        /// 设置亮度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = sender as TrackBar;
            hv.SetGain(trackBar.Value);
        }

        

        private void ROISelect(object sender, EventArgs e)
        {

            try
            {
                this.hWindowControl1.MouseDown -= hWindowControl1_MouseDown;
                this.圆形ToolStripMenuItem.Click -= ROISelect;
                this.平行矩形ToolStripMenuItem.Click -= ROISelect;
                this.旋转矩形ToolStripMenuItem.Click -= ROISelect;
                this.任意区域ToolStripMenuItem.Click -= ROISelect;




                if (pictureBox1.Image != null) { pictureBox1.Image.Dispose(); }

                ToolStripMenuItem item = sender as ToolStripMenuItem;

                switch (item.Text)
                {
                    case "圆形":
                        hv.MakeRoi(HalconVision.RoiSelect.Circle, comboBox1.Text, comboBox2.Text, (int)numericUpDown1.Value);
                        break;
                    case "平行矩形":
                        hv.MakeRoi(HalconVision.RoiSelect.Rectangle, comboBox1.Text, comboBox2.Text, (int)numericUpDown1.Value);
                        break;
                    case "旋转矩形":
                        hv.MakeRoi(HalconVision.RoiSelect.Rectangle2, comboBox1.Text, comboBox2.Text, (int)numericUpDown1.Value);
                        break;
                    case "任意区域":
                        hv.MakeRoi(HalconVision.RoiSelect.Region, comboBox1.Text, comboBox2.Text, (int)numericUpDown1.Value);
                        break;
                }
                pictureBox1.Image = Image.FromFile("region.bmp");
                
            }
            catch (Exception)
            {
            }
            finally 
            {   
                this.圆形ToolStripMenuItem.Click += ROISelect;
                this.平行矩形ToolStripMenuItem.Click += ROISelect;
                this.旋转矩形ToolStripMenuItem.Click += ROISelect;
                this.任意区域ToolStripMenuItem.Click += ROISelect;
                this.hWindowControl1.MouseDown += hWindowControl1_MouseDown;
            }
            
        }


        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void hWindowControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(hWindowControl1, e.X, e.Y);
            }
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile("region.bmp");
            }
            catch (Exception)
            {
            }
        }
    }
}
