using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_21
{
    /// <summary>
    /// 三角形类
    /// </summary>
    public class Triangle : Shape
    {
        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        /// <summary>
        /// A边长
        /// </summary>
        public double SideA { get; set; }

        /// <summary>
        /// B边长
        /// </summary>
        public double SideB { get; set; }

        /// <summary>
        /// C边长
        /// </summary>
        public double SideC { get; set; }


        public override string ShapeName { get { return "三角形"; } }


        public override double GetArea()
        {
            double p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public override double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }

        public override void ShowInfo()  //重写了父类中的虚方法
        {
            Console.WriteLine($"这是一个{ShapeName} 三条边是{SideA} {SideB} {SideC} 面积是 {GetArea()} 周长是 {GetPerimeter()} ");
        }
    }
}
