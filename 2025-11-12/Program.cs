using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _2025_11_12
{
    internal class Program
    {
        public double P1 = 3.14;
        public static double P2 = 3.14;
        public const double P3 = 3.14; //常量在定义时必须赋初始值
                                       //常量就是静态的，不需要加static 使用类名调用
        static void Main(string[] args)
        {
            

            #region 常量关键字Const，将某个变量固定下来。防止后续修改

            int a = 66;
            a = 99;
            int b;//定义可以不用赋值
            b = 111;
            const int c = 44; //常量在定义时必须赋初始值
                              //c = 55; 常量一旦被赋值 后续不允许被修改

            //作用域 {}
            {
                int d = 66; //离开花括号就失效了
            }



            #endregion

            #region 装箱与拆箱操作

            //装箱：将值类型转化为引用类型
            //拆箱：将引用类型转化为值类型 他们之间要有继承关系
            //object类型：是所有类的父类，万类之源，object是引用类型
            //装箱拆箱会浪费系统资源，应该尽量避免
            //C# 数据类型分两种：
            //1.值类型：枚举，结构体，（bool int long short byte double float decimal char...）
            //值类型数据存在栈中

            //2.引用类型：类类型 委托 接口 数组
            //引用类型分两部分存储：
            //栈中存的是指向堆的地址，堆中存实体对象

            a = 33;

            Program p = new Program();

            object ob1 = a; //装箱操作
            a = (int)ob1;   //拆箱操作


            #endregion

            #region 字符类型 char

            //字符串类型 char 使用单引号‘’ 里面必须是单个字符
            //字符串是由多个字符char组成的

            //char ch1 = 'a';
            //char ch2 = ' ';//可以是空格 空格是不可见字符 但是不能为空
            //char ch3 = '4';
            //char ch4 = '!';

            ////字符的常用方法
            ////1.判断是否是数字
            //bool a1 = char.IsDigit(ch3);
            //Console.WriteLine(a1);

            ////判断是否是字母
            //bool a2 = char.IsLetter(ch1);

            ////是否是小写字母
            //bool a3 = char.IsLower(ch1);
            ////判断是否是大写字母
            //bool a4 = char.IsUpper(ch1);

            ////是否是标点符号
            //bool a5 = char.IsPunctuation(ch4);
            ////转大小写
            //char c1 = char.ToUpper(ch1);
            //char c2 = char.ToLower(ch1);

            ////字符和int可以互相转换
            //char b1 = 'a';
            //int r1 = b1;
            //Console.WriteLine(r1) ;
            //Console.WriteLine(r1.ToString("X"));//转16进制

            ////字符对应一个ascii码值 Unicode包括Ascii码
            ////A~Z 0x41 ....
            ////0~9 0x30 ....0x39

            //char b2 = '编';
            //Console.WriteLine((int)b2);
            //Console.WriteLine(((int)b2).ToString("X"));




            #endregion

            #region 控制台的输入
            //Console.WriteLine("请输入一个字符:");
            //string str = Console.ReadLine(); // 控制台接收用户输入 并换行


            #endregion

            #region 输入一个整数 判断是整数? 负数？0 ？
            //Console.WriteLine("请输入一个整数：");
            //string rr = Console.ReadLine();
            //int interA = Convert.ToInt32(rr);
            //Console.WriteLine(interA);
            //if (interA == 0) Console.WriteLine("等于0");
            //if (interA > 0) Console.WriteLine("大于0");
            //if (interA < 0) Console.WriteLine("小于0");

            #endregion

            #region 在控制台输入两个浮点数，分别求出他们的加结果 减结果 乘除结果打印出来

            //Console.WriteLine("请输入第一个数字:");
            //string str1 = Console.ReadLine();
            //Console.WriteLine("请输入第二个数字:");
            //string str2 = Console.ReadLine();

            //Console.WriteLine($"相加结果是{Convert.ToInt32(str1) + Convert.ToInt32(str2)}");
            //Console.WriteLine($"相减结果是{Convert.ToInt32(str1) - Convert.ToInt32(str2)  }"  );
            //Console.WriteLine($"相乘结果是{Convert.ToInt32(str1) * Convert.ToInt32(str2)  }"  );
            //Console.WriteLine($"相除结果是{Convert.ToDouble(str1) / Convert.ToDouble(str2)}"  );


            #endregion

            #region 在控制台输入两个整数，比较他们的大小，输出大的那个值 打印出来

            //Console.WriteLine("输入第一个数:");
            //int interA = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("输入第二个数:");
            //int interB = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(interA > interB ? interA:interB);
            #endregion

            #region args 传递消息

            //Console.WriteLine(args[0]);
            //Console.WriteLine(args[1]);

            #endregion


            #region C#的运算符 + - * / % ++ -- += *= -= /= %= & && | || ~ ^

            //++自加1 --自减1 ++ --有前置和后置之分
            int cc = 5;
            cc++;
            Console.WriteLine(cc);
            ++cc;
            Console.WriteLine(cc);
            cc--;
            Console.WriteLine(cc);
            --cc;
            Console.WriteLine(cc);

            int c1 = 10;
            int c2 = 10;
            int r1 = ++c1;  //11
            int r2 = c2++;  //10

            int c3 = 20;
            int r3 = 100;
            r3 += c3; //相当于r3 = r3 + c3 +-*/%同理




            #endregion




        }


        public void M_1()
        {
            int a = 66; //局部变量 作用域不超过{}
            Console.WriteLine(a);
        }

        public void M_2()
        {
            int a = 99; //局部变量 作用域不超过{}
            Console.WriteLine(a);
            
            
        }

        public static void M_3()
        {
            Program program = new Program();
            program.M_2();   //m_3是静态方法，调用时没有对象传进来，m2是实例方法 必须使用对象调用
            
        }


    }
}
