using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{

    /// <summary>
    /// 绘图处理业务逻辑
    /// </summary>
    public class DrawHandleBLL
    {
        /// <summary>
        /// 画布
        /// </summary>
        private Bitmap bmp;
        
        /// <summary>
        /// 绘图工具
        /// </summary>
        private Graphics g;

        /// <summary>
        /// 画框
        /// </summary>
        private PictureBox pictureBox;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DrawHandleBLL(PictureBox pictureBox)
        {   
            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
            g = Graphics.FromImage(bmp);
            this.pictureBox = pictureBox;
        }


        /// <summary>
        /// 坐标复原方法
        /// </summary>
        public void CoordinatesReset()
        {

            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
            g = Graphics.FromImage(bmp);

            //画十字架 &&箭头 && 文字描述
            int w = pictureBox.ClientSize.Width;
            int h = pictureBox.ClientSize.Height;
            int wHalf = w / 2;
            int hHalf = h / 2;
            //线
            g.DrawLine(new Pen(Color.Green, 3f), 0, hHalf, w, hHalf);
            g.DrawLine(new Pen(Color.Green, 3f), wHalf, 0, wHalf, h);
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
            g.DrawString("X轴", new Font("宋体", 12), Brushes.Red, new PointF(w - 30, hHalf + 20));

            g.DrawString("Y轴", new Font("宋体", 12), Brushes.Red, new PointF(wHalf + 10, 10));


            //将坐标系由左上角改为图像中心
            g.Transform = new System.Drawing.Drawing2D.Matrix(1, 0, 0, -1, 0, 0);
            g.TranslateTransform(wHalf, -hHalf);

            pictureBox.Image = bmp;
        }


        public async Task DisplayDataPointsAsync(Brush brush, 
                                        BindingList<ProcessCoordEntity> processCoordEntities,
                                        DrawParamsEntity drawParamsEntity)
        {


            await Task.Run(() =>
            {
                for (int i = 0; i < processCoordEntities.Count; i++)
                {
                    float pixX = (float)(processCoordEntities[i].XPosition * drawParamsEntity.XDrawScale + drawParamsEntity.XDrawOffset);
                    float pixY = (float)(processCoordEntities[i].YPosition * drawParamsEntity.YDrawScale + drawParamsEntity.YDrawOffset);

                    RectangleF rectangleF = new RectangleF(pixX - 5, pixY - 5, 10, 10);
                    g.FillEllipse(brush, rectangleF);

                }
                pictureBox.Invoke(new Action(() =>
                {
                    pictureBox.Image = bmp;
                }));
            });


        }


        /// <summary>
        /// 绘制轨迹方法
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="processCoordEntities"></param>
        /// <param name="drawParamsEntity"></param>
        /// <returns></returns>
        public async Task DrawTrackAsync(Pen pen,
                                        BindingList<ProcessCoordEntity> processCoordEntities,
                                        DrawParamsEntity drawParamsEntity ) 
        {

            if (processCoordEntities.Count == 0)
            {
                return;
            }

            float pixX = (float)(processCoordEntities[0].XPosition * drawParamsEntity.XDrawScale + drawParamsEntity.XDrawOffset);
            float pixY = (float)(processCoordEntities[0].YPosition * drawParamsEntity.YDrawScale + drawParamsEntity.YDrawOffset);

            await Task.Run(() =>
            {
                for (int i = 1; i < processCoordEntities.Count; i++)
                {
                    Thread.Sleep(1000);
                    float pixX2 = (float)(processCoordEntities[i].XPosition * drawParamsEntity.XDrawScale + drawParamsEntity.XDrawOffset);
                    float pixY2 = (float)(processCoordEntities[i].YPosition * drawParamsEntity.YDrawScale + drawParamsEntity.YDrawOffset);

                    g.DrawLine(pen, pixX, pixY, pixX2, pixY2);

                    pictureBox.Invoke(new Action(() =>
                    {
                        pictureBox.Image = bmp;
                    }));

                    pixX = pixX2;
                    pixY = pixY2;
                }
                

                
            });


        }

    }
}
