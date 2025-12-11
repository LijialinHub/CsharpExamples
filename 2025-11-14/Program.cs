using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_14
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region 程序控制关键字 break continue return goto
            //break:1.switch语句中 跳出条件语句
            //2.用于 while和for foreach循环语句中，跳出当前循环

            //Console.WriteLine("输入星期:");
            //string strInput = Console.ReadLine();

            //switch(strInput)
            //{
            //    case "星期一":
            //    case "星期二":
            //    case "星期三":
            //        Console.WriteLine($"{strInput}, 工作日：9：00 ~ 18:00"); break;

            //    case "星期四":
            //        Console.WriteLine($"{strInput}, 工作日：8：30 ~ 17:30"); break;

            //    case "星期五":
            //        Console.WriteLine($"{strInput}, 工作日：8：00 ~ 17:00"); break;

            //    case "星期六":
            //    case "星期日":
            //        Console.WriteLine($"{strInput}, 休息日。。。。"); break;

            //    default:
            //        Console.WriteLine("输入错误"); break;

            //}

            //Console.WriteLine("跳出switch语句");


            //for(int i = 0; i < 10; i++)
            //{
            //    while(true)
            //    {
            //        Console.WriteLine("请输入数字:");
            //        double m = double.Parse(Console.ReadLine());
            //        if(m <=0) { break; }
            //    }
            //    Console.WriteLine($"当前for语句执行第{i+1}次*******************");
            //}
            //Console.WriteLine("退出成功");
            //Console.WriteLine("******************************************");


            //int[] vs = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //foreach (var item in vs)
            //{   
            //    Console.WriteLine(item + "  ");
            //    if (item > 6) break;
            //}
            //Console.WriteLine();
            //Console.WriteLine("****************");

            ////continue:结束当次循环 继续下一场循环
            //Console.WriteLine("1到10的奇数是: ");
            //for (int i=0; i<=10; i++)
            //{
            //    if(i % 2 == 0) { continue; }
            //    Console.WriteLine(i);
            //}



            //    //goto: 跳转到指定标签位置
            //    int num = 0;
            //pos1:
            //    num++;
            //    Console.WriteLine($"while循环前边 这是第{num} 句话 ！");
            //    num++;
            //    Console.WriteLine($"while循环前边 这是第{num} 句话 ！");

            //    while (true)
            //    {
            //        num++;
            //        Console.WriteLine($"while循环中 这是第{num}句话");
            //        if (num == 5) { goto pos1; }
            //        if (num == 8) { goto pos2; }
            //    }

            //    num++;
            //    Console.WriteLine($"**********while循环后边 这是第{num} 句话 ！ **********");

            //pos2:
            //    num++;
            //    Console.WriteLine($"while循环后边 这是第{num} 句话 ！");


            #endregion

            #region Math类 静态类 存放的是一些数学运算方法

            //int r1 = Math.Abs(-6);
            //double r2 = Math.Abs(-6.38);
            //int r3 = Math.Abs(10);

            ////返回大于或等于指定的双精度浮点数的最小整数值 上限
            //double r4 = Math.Ceiling(3.45); //4

            ////返回小于或等于指定小数的最大整数
            //double r6 = Math.Floor(3.45); //3

            ////任何数的任何次方
            //double r7 = Math.Pow(2, 3); // 8

            ////求某个数据的指定位元是1还是0 就是看二进制某一位是0还是1 倒着看
            //int data = 0b101001010; //左右边是最低位 0号位元
            ////例如要读取data的第三号位元是1还是0
            //int r9 = data & (int)Math.Pow(2, 3);
            //if(r9 == 0) { Console.WriteLine("第三号位元是0"); }
            //else { Console.WriteLine("第三号位元是1"); }

            ////将小数值按指定的小数位四舍五入
            //double r10 = Math.Round(3.567, 2);

            ////三角函数
            //double a = Math.PI / 6; // PI=180°/ 6 =  30°
            //double b = Math.PI / 3; // PI=180°/ 3 =  60°
            //double c = Math.PI / 4; // PI=180°/ 4 =  45°

            //Math.Sin(a); //0.5   
            //Math.Cos(b); //0.5
            //Math.Tan(c); //1

            //Math.Sqrt(2); //1.414 求平方根
            //Math.Truncate(a); //返回一个浮点数的整数部分 直接拿 不四舍五入



            #endregion

            #region 二维数组
            //int[,] intArr = new int[2, 3]; //创建了两行三列的二维数组
            //                               //共六个元素

            //Console.WriteLine(intArr.Length);

            ////数组的索引下标固定从0开始
            //intArr[0, 0] = 10;
            //intArr[0, 1] = 20;
            //intArr[0, 2] = 30;
            //intArr[1, 0] = 40;
            //intArr[1, 1] = 50;
            //intArr[1, 2] = 60;

            //double[,] intArr2 = new double[,]
            //{
            //    {10,20,30 },
            //    {40,50,60 }
            //};

            ////省略new关键字
            //double[,] intArr3 = { {10,20,30 },
            //                      {40,50,60 }};


            //int rows = intArr3.GetLength(0); //行数
            //int cols = intArr3.GetLength(1); //列数


            ////使用for语句去遍历
            //for (int i = 0; i < rows; i++)
            //{ 
            //    for (int j = 0; j < cols; j++)
            //    {
            //        Console.Write($"{intArr3[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}

            ////使用foreach遍历
            //foreach (int i in intArr2)
            //{
            //    Console.WriteLine(i + "  ");
            //}
            


            #endregion




        }
    }
}
