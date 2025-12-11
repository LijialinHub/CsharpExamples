using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_15
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region 在控制台输出一个九九乘法表

            //for (int i = 1; i <= 9; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write($"{j}*{i}={i * j} ");
            //    }
            //    Console.WriteLine();
            //}

            #endregion

            #region 三维数组(非重点)

            //int[,,] arr1 = new int[2, 2, 3];
            //int[,,] arr2 = new int[2, 2, 3]
            //{
            //    {{ 1,2,3},{4,5,6 } },
            //    { { 7,8,9},{10,11,12 } }
            //};


            #endregion

            #region 转义字符 在字符串中 \是对后边字符的转义 并不是所有字符都能转义
            //常用的转义字符 1.\n换行
            //               2.\t tab键 相当于六个空格
            //               3.\r 回车键 enter键
            //               4.\b 退格键 BackSapce键
            //               5.\" 引号

            char chr = '\n';
            string str1 = "小\b明说：\"今晚回家吃饭\"\n小张说:\"我也是\"";
            Console.WriteLine(str1);

            //1. 如果需要原样输出转义字符 1.字符串前边加@ 取消字符串中所有\的转义作用
            //2. 转义字符前再加一个\ 双斜杠\\
            string str2 = @"C:\Users\Lijialin\Pictures\Camera Roll\WIN_20251112_08_59_46_Pro.jpg";


            #endregion

        }
    }
}
