using Halcon_1;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 形状匹配
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 图像处理类
        /// </summary>
        private HalconVision hv;

        private List<PixelCoord> pixelCoords;


        private void Form1_Load(object sender, EventArgs e)
        {
            hv = new HalconVision(hWindowControl1);
            try
            {
                hv.openCamera();
                //MessageBox.Show("打开相机成功！");

                if (File.Exists("region.bmp"))
                {
                    pictureBox1.Image = Image.FromFile("region.bmp");
                }
                comboBox1.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox4.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void hWindowControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(hWindowControl1, e.X, e.Y);
            }
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
                        hv.MakeRoi(HalconVision.RoiSelect.Circle);
                        break;
                    case "平行矩形":
                        hv.MakeRoi(HalconVision.RoiSelect.Rectangle);
                        break;
                    case "旋转矩形":
                        hv.MakeRoi(HalconVision.RoiSelect.Rectangle2);
                        break;
                    case "任意区域":
                        hv.MakeRoi(HalconVision.RoiSelect.Region);
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

        private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            await hv.closeCamera();
            Environment.Exit(0);
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

        /// <summary>
        /// 单张采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button5_Click(object sender, EventArgs e)
        {
            await hv.SingleAcquire();
        }

        /// <summary>
        /// 实时采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            hv.RealTimeAcquire();
        }

        /// <summary>
        /// 创建模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {   
                pictureBox1.Image.Dispose();
                hv.CreateShapeModel();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 设置亮度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            System.Windows.Forms.TrackBar trackBar = sender as System.Windows.Forms.TrackBar;
            hv.SetGain(trackBar.Value);
        }

        

        /// <summary>
        /// 执行匹配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {   
            double score = Convert.ToDouble(numericUpDown3.Value);
            int numMatches = Convert.ToInt32(numericUpDown5.Value);
            double maxOverlap = Convert.ToDouble(numericUpDown7.Value);
            double greediness = Convert.ToDouble(numericUpDown9.Value);

            string crossColor = comboBox1.SelectedItem.ToString();
            string contourColor = comboBox3.SelectedItem.ToString();
            string setDraw = comboBox4.SelectedItem.ToString();
            int lineWidth = Convert.ToInt32(numericUpDown1.Value);
            string fontColor = comboBox2.SelectedItem.ToString();
            int fontSize = Convert.ToInt32(numericUpDown2.Value);


            pixelCoords = hv.FindShapeModel(score, numMatches, maxOverlap, greediness, crossColor, contourColor, setDraw, lineWidth, fontColor, fontSize);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmResultDisplay frmResultDisplay = new frmResultDisplay(pixelCoords);
            frmResultDisplay.ShowDialog();

        }

        /// <summary>
        /// 实时匹配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            double score = Convert.ToDouble(numericUpDown3.Value);
            int numMatches = Convert.ToInt32(numericUpDown5.Value);
            double maxOverlap = Convert.ToDouble(numericUpDown7.Value);
            double greediness = Convert.ToDouble(numericUpDown9.Value);

            string crossColor = comboBox1.SelectedItem.ToString();
            string contourColor = comboBox3.SelectedItem.ToString();
            string setDraw = comboBox4.SelectedItem.ToString();
            int lineWidth = Convert.ToInt32(numericUpDown1.Value);
            string fontColor = comboBox2.SelectedItem.ToString();
            int fontSize = Convert.ToInt32(numericUpDown2.Value);


            hv.RealTimeAcquireFindShapeModel(score, numMatches, maxOverlap, greediness, crossColor, contourColor, setDraw, lineWidth, fontColor, fontSize);
        }
    }
}
