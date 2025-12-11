using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_10
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        Graphics g;
        Bitmap bmp;
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void test_Load(object sender, EventArgs e) => CoordinatesReset();

        /// <summary>
        /// 坐标复原方法
        /// </summary>
        private void CoordinatesReset()
        {
            bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            g = Graphics.FromImage(bmp);

            //画十字架 &&箭头 && 文字描述
            int w = pictureBox1.ClientSize.Width;
            int h = pictureBox1.ClientSize.Height;
            int wHalf = w / 2;
            int hHalf = h / 2;
            //线
            g.DrawLine(new Pen(Color.Green,3f), 0, hHalf, w, hHalf);
            g.DrawLine(new Pen(Color.Green,3f), wHalf, 0,wHalf,h);
            //箭头
            g.DrawLines(new Pen(Color.Green, 3f), new Point[]
                {
                    new Point(w-10, hHalf-10),
                    new Point(w, hHalf),
                    new Point(w-10, hHalf+10)
                });

            g.DrawLines(new Pen(Color.Green, 3f), new Point[]
                {
                    new Point(wHalf-10, 10),
                    new Point(wHalf, 0),
                    new Point(wHalf+10, 10)
                });

            //文字描述
            g.DrawString("X轴", new Font("宋体",12), Brushes.Red, new PointF(w-30, hHalf+20));

            g.DrawString("Y轴", new Font("宋体", 12), Brushes.Red, new PointF(wHalf+10, 10));


            //将坐标系由左上角改为图像中心
            g.Transform = new System.Drawing.Drawing2D.Matrix(1,0,0,-1,0,0);
            g.TranslateTransform(wHalf, -hHalf);

            pictureBox1.Image = bmp;
        }

        /// <summary>
        /// 平移 X轴平移20
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTranslation_Click(object sender, EventArgs e)
        {
            g.TranslateTransform(20, 0);
        }

        /// <summary>
        /// X轴镜像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXAxisMirror_Click(object sender, EventArgs e)
        {
            float dx = g.Transform.OffsetX;
            float dy = g.Transform.OffsetY;

            g.Transform = new System.Drawing.Drawing2D.Matrix(-1,0,0,-1,dx,dy);
        }

        /// <summary>
        /// Y轴镜像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYAxisMirror_Click(object sender, EventArgs e)
        {
            float dx = g.Transform.OffsetX;
            float dy = g.Transform.OffsetY;
            g.Transform = new System.Drawing.Drawing2D.Matrix(1, 0, 0, 1,dx,dy);
        }

        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawRectangle_Click(object sender, EventArgs e)
        {
            g.DrawRectangle(new Pen(Color.Red), new Rectangle(10, 10, 100, 50));
            pictureBox1.Image = bmp;
        }

        /// <summary>
        /// 旋转30度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotation_Click(object sender, EventArgs e)
        {
            g.RotateTransform(30);
        }

        /// <summary>
        /// 缩放0.5x
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZooming_Click(object sender, EventArgs e)
        {
            g.ScaleTransform(0.5f, 0.5f);
        }

        /// <summary>
        /// 坐标复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCoordReset_Click(object sender, EventArgs e)=>CoordinatesReset();

    }
}
