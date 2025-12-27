using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_21
{
    public class Ellipse : Shape
    {   
        public Ellipse(double l, double s) 
        { 
            LongAxis = l;
            ShortAxis = s;
        }


        public override string ShapeName { get { return "椭圆"; } }

        public double LongAxis { get; set; }
        public double ShortAxis { get; set; }

        public override double GetArea()
        {
            return Math.PI * ShortAxis * LongAxis;
        }

        public override double GetPerimeter()
        {
            return (2 * Math.PI * ShortAxis + 4 * (LongAxis - ShortAxis));
        }

    }
}
