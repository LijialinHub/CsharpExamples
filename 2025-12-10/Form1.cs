using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDrawRectangle_Click(object sender, EventArgs e)
        {
            graphics.DrawRectangle(new Pen(Color.Red, 5f), new Rectangle(20,20, 150,80));
            pictureBox1.Image = bmp;
        }

        /// <summary>
        /// 绘图工具
        /// </summary>
        Graphics graphics;
        /// <summary>
        /// 画布
        /// </summary>
        Bitmap bmp;
        private void Form1_Load(object sender, EventArgs e)
        {
            CoordReset();   //坐标复位
        }


        /// <summary>
        /// 坐标复位
        /// </summary>
        private void CoordReset()
        {
            bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            graphics = Graphics.FromImage(bmp);

            graphics.Clear(pictureBox1.BackColor);
            graphics.ResetTransform();  //复位 恢复为1 0 0 1 0 0
                                         //表示坐标原点在左上角
                                         //X轴正方向➡️ Y轴正方向⬆️

            
            int wHalf = (int)bmp.Width / 2;
            int hHalf = (int)bmp.Height / 2;

            //绘制X轴
            graphics.DrawLine(new Pen(Color.Green), 0, hHalf, pictureBox1.ClientSize.Width, hHalf);

            //绘制箭头
            graphics.DrawLines(new Pen(Color.Green), new Point[]
                {
                    new Point(pictureBox1.ClientSize.Width - 10, hHalf - 10),
                    new Point(pictureBox1.ClientSize.Width, hHalf),
                    new Point(pictureBox1.ClientSize.Width - 10, hHalf + 10)
                }
                );

            graphics.DrawString("X轴", new Font("宋体", 12, FontStyle.Bold), Brushes.Red, pictureBox1.ClientSize.Width - 35, hHalf + 20);


            //绘制Y轴
            graphics.DrawLine(new Pen(Color.Green), wHalf, 0, wHalf, pictureBox1.ClientSize.Height);
            //绘制箭头
            graphics.DrawLines(new Pen(Color.Green), new Point[]
               {
                    new Point(wHalf - 10, 10),
                    new Point(wHalf, 0),
                    new Point(wHalf + 10, 10)
               }
               );


            graphics.DrawString("Y轴", new Font("宋体", 12, FontStyle.Bold), Brushes.Red, wHalf + 25, 20);


            graphics.Transform = new Matrix(1,0,0,-1,0,0);
            graphics.TranslateTransform(pictureBox1.ClientSize.Width/2, -pictureBox1.ClientSize.Height/2);  //平移变换 原点移动到图像中心点



            pictureBox1.Image = bmp;
        }

        private void btnCoordReset_Click(object sender, EventArgs e)
        {
            CoordReset();
        }

        /// <summary>
        /// X轴镜像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXAxisMirror_Click(object sender, EventArgs e)
        {   
            float dx = graphics.Transform.OffsetX;
            float dy = graphics.Transform.OffsetY;

            graphics.Transform = new Matrix(-1,0,0,-1,dx, dy);
        }

        private void btnYAxisMirror_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 平移变换 x20 y40
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTranslation_Click(object sender, EventArgs e)
        {
            graphics.TranslateTransform(20, 40);
        }

        /// <summary>
        /// 旋转变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotation_Click(object sender, EventArgs e)
        {
            graphics.RotateTransform(30);
        }

        /// <summary>
        /// 缩放变换 0.5x
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZooming_Click(object sender, EventArgs e)
        {
            graphics.ScaleTransform(0.5f, 0.5f);

        }
    }
}
