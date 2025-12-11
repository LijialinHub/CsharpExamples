using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_10_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            // 先重置坐标系
            CoordinatesReset();
            
            // 设置正弦波参数
            int scale = 30; // 1:30比例
            double amplitude = 1.0; // 振幅
            double frequency = 1.0; // 频率
            
            // 创建正弦波画笔
            Pen sinePen = new Pen(Color.Blue, 2f);
            
            // 计算正弦波点
            List<PointF> points = new List<PointF>();
            
            // 从-2π到2π，步长为0.1
            for (double x = -2 * Math.PI; x <= 2 * Math.PI; x += 0.01)
            {
                double y = amplitude * Math.Sin(frequency * x);
                
                // 将数学坐标转换为屏幕坐标（1:30比例）
                float screenX = (float)(x * scale);
                float screenY = (float)(y * scale);
                
                points.Add(new PointF(screenX, screenY));
            }
            
            // 绘制正弦波曲线
            if (points.Count > 1)
            {
                g.DrawCurve(sinePen, points.ToArray());
                
            }
            
            // 刷新显示
            picDisplay.Image = bmp;
        }

        /// <summary>
        /// 坐标复原方法
        /// </summary>
        /// 
        Graphics g;
        Bitmap bmp;
        private void CoordinatesReset()
        {
            bmp = new Bitmap(picDisplay.ClientSize.Width, picDisplay.ClientSize.Height);
            g = Graphics.FromImage(bmp);

            // 画十字架 && 箭头 && 文字描述
            int w = picDisplay.ClientSize.Width;
            int h = picDisplay.ClientSize.Height;
            int wHalf = w / 2;
            int hHalf = h / 2;
            
            // 线
            g.DrawLine(new Pen(Color.Green, 3f), 0, hHalf, w, hHalf);
            g.DrawLine(new Pen(Color.Green, 3f), wHalf, 0, wHalf, h);
            
            // 箭头
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

            // 文字描述
            g.DrawString("X轴", new Font("宋体", 12), Brushes.Red, new PointF(w - 30, hHalf + 20));
            g.DrawString("Y轴", new Font("宋体", 12), Brushes.Red, new PointF(wHalf + 10, 10));
            
            // 添加刻度
            Font scaleFont = new Font("Arial", 10);
            Brush scaleBrush = Brushes.Black;
            
            // X轴刻度 (π、2π、-π、-2π)
            // 使用1:50比例，即1单位=50像素
            int scale = 30;
            
            // 2π ≈ 6.28, π ≈ 3.14
            int twoPiPixel = (int)(2 * Math.PI * scale);
            int piPixel = (int)(Math.PI * scale);
            
            // 刻度线
            // π
            g.DrawLine(new Pen(Color.Black, 1), wHalf + piPixel, hHalf - 5, wHalf + piPixel, hHalf + 5);
            // 2π
            g.DrawLine(new Pen(Color.Black, 1), wHalf + twoPiPixel, hHalf - 5, wHalf + twoPiPixel, hHalf + 5);
            // -π
            g.DrawLine(new Pen(Color.Black, 1), wHalf - piPixel, hHalf - 5, wHalf - piPixel, hHalf + 5);
            // -2π
            g.DrawLine(new Pen(Color.Black, 1), wHalf - twoPiPixel, hHalf - 5, wHalf - twoPiPixel, hHalf + 5);
            
            // X轴刻度文字（在屏幕坐标系下绘制，Y坐标需要调整）
            g.DrawString("π", scaleFont, scaleBrush, new PointF(wHalf + piPixel - 5, hHalf + 15));
            g.DrawString("2π", scaleFont, scaleBrush, new PointF(wHalf + twoPiPixel - 10, hHalf + 15));
            g.DrawString("-π", scaleFont, scaleBrush, new PointF(wHalf - piPixel - 10, hHalf + 15));
            g.DrawString("-2π", scaleFont, scaleBrush, new PointF(wHalf - twoPiPixel - 15, hHalf + 15));
            
            // Y轴刻度文字（在屏幕坐标系下绘制）
            g.DrawString("1", scaleFont, scaleBrush, new PointF(wHalf + 10, hHalf - scale - 5));
            g.DrawString("0", scaleFont, scaleBrush, new PointF(wHalf + 10, hHalf + 5));
            g.DrawString("-1", scaleFont, scaleBrush, new PointF(wHalf + 10, hHalf + scale - 5));
            
            // 将坐标系由左上角改为图像中心
            g.Transform = new System.Drawing.Drawing2D.Matrix(1, 0, 0, -1, 0, 0);
            g.TranslateTransform(wHalf, -hHalf);

            picDisplay.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CoordinatesReset();
            //绘图呈现质量
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CoordinatesReset();
        }
    }
}
