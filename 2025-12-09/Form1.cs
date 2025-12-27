using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_09
{
    public partial class Form1 : Form   //Graphics Device Interface 一种绘图技术
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绘图工具
        /// </summary>
        private Graphics g;
        /// <summary>
        /// 画布
        /// </summary>
        Bitmap Bitmap;
        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap = new Bitmap(picDisplay.ClientSize.Width, picDisplay.ClientSize.Height);
            g = Graphics.FromImage(Bitmap);
        }

        
        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            g.Clear(picDisplay.BackColor);
            g.DrawLine(new Pen(Color.Red, 3f), 0, 0, 100, 100);
            picDisplay.Image = Bitmap;
        }

        private void btnDrawRectangle_Click(object sender, EventArgs e)
        {
            g.Clear(picDisplay.BackColor);
            g.DrawRectangle(new Pen(Color.Green, 3f), new Rectangle(200, 200, 100, 150));
            picDisplay.Image = Bitmap;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            g.Clear(picDisplay.BackColor);
            g.DrawArc(new Pen(Color.Blue, 10f), new Rectangle(350, 350, 200, 200), 0, 360);
            picDisplay.Image = Bitmap;
        }

        private void btnDrawTriangle_Click(object sender, EventArgs e)
        {
            g.Clear(picDisplay.BackColor);
            PointF[] pts = new PointF[3] {
                new PointF(100,100), new PointF(0,300), new PointF(200,300)
            };

            g.DrawPolygon(new Pen(Color.Pink), pts);
            picDisplay.Image = Bitmap;
        }

        private void btnDrawString_Click(object sender, EventArgs e)
        {
            g.Clear(picDisplay.BackColor);
            Brush brush = new SolidBrush(Color.White);
            g.DrawString("Hello Word", new Font("微软雅黑",14), brush, 300, 300);
            picDisplay.Image = Bitmap;
        }

        private void btnFillEllipse_Click(object sender, EventArgs e)
        {                      
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(350, 350, 200, 200));
            picDisplay.Image = Bitmap;
        }

        private void btnFillPolygon_Click(object sender, EventArgs e)
        {
            PointF[] pts = new PointF[3] {
                new PointF(100,100), new PointF(0,300), new PointF(200,300)
            };
            Brush brush = new SolidBrush(Color.Red);
            g.FillPolygon(brush, pts);
            picDisplay.Image = Bitmap;
        }

        private void btnFillRectangle_Click(object sender, EventArgs e)
        {
            Brush brush = new SolidBrush(Color.Green);
            g.FillRectangle(brush, new Rectangle(200, 200, 100, 150));
            picDisplay.Image = Bitmap;
        }
    }
}
