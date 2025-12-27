using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_21
{
    public class Rect : Shape
    {   
        public Rect(double w, double h)
        {
            Width = w;
            Height = h;
        }


        public override string ShapeName { get { return "矩形"; } }

        public double Width { get; set; }

        public double Height { get; set; }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override double GetPerimeter()
        {
            return (Width + Height) * 2;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"这是一个 {ShapeName} 长是{Height} 宽是{Width} 面积{GetArea()} 周长{GetPerimeter()}");
        }

    }
}
