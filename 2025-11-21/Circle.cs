using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_21
{
    public class Circle : Shape
    {   
        public Circle(double r) { Radius = r; }

        public double Radius { get; set; }

        public override string ShapeName { get { return "圆"; }  }

        public override double GetArea()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }


        public override void ShowInfo()
        {
            base.ShowInfo();
        }



    }
}
