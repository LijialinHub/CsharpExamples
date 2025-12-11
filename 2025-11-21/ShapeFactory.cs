using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_21
{   

    /// <summary>
    /// 形状工厂类
    /// </summary>
    public class ShapeFactory
    {
        /// <summary>
        /// 获取形状对象
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        public static Shape GetShape(ShapeType shapeType) 
        {
            try
            {
                Shape shape = null;

                switch (shapeType)
                {
                    case ShapeType.Circle:
                        Console.WriteLine("请输入圆的半径:");
                        double r = double.Parse(Console.ReadLine());
                        shape = new Circle(r); break;

                    case ShapeType.Rect:

                        Console.WriteLine("请输入矩形宽:");
                        double w = double.Parse(Console.ReadLine());
                        Console.WriteLine("请输入矩形高:");
                        double h = double.Parse(Console.ReadLine());

                        shape = new Rect(w, h); break;

                    case ShapeType.Triangle:
                        Console.WriteLine("输入边长A的值:");
                        double a = double.Parse(Console.ReadLine());
                        Console.WriteLine("输入边长B的值:");
                        double b = double.Parse(Console.ReadLine());
                        Console.WriteLine("输入边长C的值:");
                        double c = double.Parse(Console.ReadLine());

                        shape = new Triangle(a, b, c); break;

                    case ShapeType.Ellipse:
                        Console.WriteLine("输入长轴的值:");
                        double l = double.Parse(Console.ReadLine());
                        Console.WriteLine("输入短轴的值:");
                        double s = double.Parse(Console.ReadLine());

                        shape = new Ellipse(l, s); break;
                    default:
                        throw new Exception("输入形状有误");
                        
                }

                return shape;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        /// <summary>
        /// 形状类型枚举
        /// </summary>
        public enum ShapeType
        {

            /// <summary>
            /// 圆
            /// </summary>
            Circle = 0,

            /// <summary>
            /// 三角形
            /// </summary>
            /// 
            Triangle = 1,

            /// <summary>
            /// 矩形
            /// </summary>
            Rect = 2,

            /// <summary>
            /// 椭圆
            /// </summary>
            Ellipse = 3
            
        }

    }
}
