using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2025_11_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 3.判断是否是合法日期格式 “2008-08-08” “2008\08\08” “2008年08月08日”
            ////月范围 1~12 日范围1~31
            ////并且提取年月日的值 （提示 使用正则表达式的提取组Groups）
            //while (true)
            //{
            //    Console.WriteLine("输入日期:");
            //    string input = Console.ReadLine();
            //    Match match = Regex.Match(input, @"^([1-9]\d*)[-年\\](0[1-9]|1[0-2])[-月\\](0[1-9]|[12]\d|3[01])日?$");
            //    if (match.Success) //匹配成功
            //    {
            //        //提取年月日的值 (提示：使用正则表达式的提取组)
            //        //Console.WriteLine(match.Groups[0].Value);
            //        Console.WriteLine(match.Groups[1].Value); //从1开始
            //        Console.WriteLine(match.Groups[2].Value);
            //        Console.WriteLine(match.Groups[3].Value);
            //    }
            //    else
            //    {
            //        Console.WriteLine("日期格式非法");
            //    }
            #endregion


            
        }
    }
}