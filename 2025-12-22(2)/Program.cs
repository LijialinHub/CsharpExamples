using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_12_22_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //键值对集合
            Dictionary<string, double> dc = new Dictionary<string, double>()
            {
                {"温度1#",98.23 },
                { "温度2#",100},
                { "温度3#",99}
            };

            dc.Add("温度4#", 99); //添加
            dc.Remove("温度4#"); //移除
            Console.WriteLine(dc.Count());

            dc["温度3#"] = 999;

            foreach (var item in dc)
            {
                Console.WriteLine($"{item.Key} :{item.Value}");
            }

            foreach (var item in dc.Keys)
            {
                Console.WriteLine(item);
            }

            foreach (var item in dc.Values)
            {
                Console.WriteLine(item);
            }

        }
    }
}
