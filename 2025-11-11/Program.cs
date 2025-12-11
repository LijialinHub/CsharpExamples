using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region C#中的简单数据类型

            //int型数据可以参与按位与& 按位或| 按位取反运算
            int h1 = 1234;      //   0b 0100 1101 0010
            int h2 = 0xABCD;    // 1010 1011 1100 1101

            //按位与& 1和1相与，结果为1； 0和0，0和1相与，结果就是0， 遇0为0全1为1；
            int r1 = h1 & h2;  // 0000 0000 1100 0000
            Console.WriteLine(r1);

            //按位或 | 只要有一个是1 结果就是1 都为0 结果才是0
            int r2 = h1 & h2;  //1010 1111 1101 1111 = 45023

            //按位取反~ 0变1 1变0
            //int是32位有符号的整数，最高位为符号位，为0表示正整数，为1表示负整数
            int r3 = ~h1;   // 0b 1011 0010 1101


            //十进制转 二进制十六进制显示 
            //方法1
            string str = Convert.ToString(r3, 2); //2为目标进制

            int h3 = 18;
            string r4 = Convert.ToString(h3, 2);  //0b10010
            string r5 = Convert.ToString(h3, 16); //0x12

            //方法2 tostring方法 只适用于转16进制
            int h4 = 6666; //0x1A0A
            string r6 = h4.ToString("X");//0x1A0A
            string r7 = h4.ToString("x");//0x1a0a
            Console.WriteLine(r7);
            string r8 = h4.ToString("X8"); // 0x00001A0A

            //byte型 无符号字节(1个字节8个位，表示都是正整数) 0~255
            byte r = 255;
            //sbyte型 有符号字节 1个字节8个位 -128~127
            sbyte w = -128;

            //short型 16位有符号整数 -32768~32767  
            //long型，长整形，64位有符号整数
            short x = 32767;
            long y = 10000000000;

            //float型 double型 decimal型 一般用来表示浮点数
            //按照精度：decimal（128位） 》 double双精度，输入的小数默认为double（64位） 》 float （32位）单精度
            //float型：精确到六位（多的四舍五入），小数后边必须加后缀f；
            //double型：精确到14位 多的四舍五入 小数后边可以加d 也不可以不加
            //decimal型：精度最高。小数后边必须加后缀m

            float m1 = 3.1415926f;
            double m2 = 3.1415926;
            decimal m3 = 3.13213123123123123m;

            #endregion


            #region 隐式转换和显式转换

            //c#是强类型语言，不同类型不能随便转换
            short a = 32767;
            int b = a;   //小转大可以自动转 叫做隐式转换

            int c = 1000000;
            short d = (short)c; //大转小可能不安全 需要显式转换(强转)


            #endregion


            #region 数据转换方法（主要是针对字符串 转变int byte double。。。）

            string str1 = "123";
            string str2 = "23.56";
            string str3 = "15abc";

            //字符串转数值必须使用方法，不能隐式转换和强制转换

            //1.类型名.Parse()
            r1 = int.Parse(str1);
            Console.WriteLine(str1 + 55); //字符串的 + 表示连接 12355
            Console.WriteLine(r1 + 55);  // 值相加 123+55 = 178
            Console.WriteLine(r1 > 99); //true

            double q2 = double.Parse(str2);
            Console.WriteLine(q2 + 10); //33.56

            //2. 使用Convert类的方法
            int q3 = Convert.ToInt32(str1);
            double q4 = Convert.ToDouble(str2);
            float q5 = Convert.ToSingle(str2);

            //3. 类型名.TryParse() 方法 更加安全
            int q6;
            bool isOk = int.TryParse(str3, out q6);
            if (isOk)
            {
                //转换成功后的值赋值给变量q6 False不能转的话 r8还是之前的值
                Console.WriteLine("可以转");
            }
            else
            {
                Console.WriteLine("不能转");
            }


            #endregion


            #region 枚举

            //枚举是一种数据类型 特殊类
            //作用：固定参数，以防止乱写
            Student zs = new Student("张三", 18, Sex.Man);
            zs.ShowInfo();

            //枚举和字符串相互转换

            //enum -> string
            Sex sex = Sex.Woman;
            string sexStr = sex.ToString();
            Console.WriteLine(sexStr);

            //string -> enum
            Sex sex1 = (Sex)Enum.Parse(typeof(Sex), "Woman");
            Console.WriteLine(sex1);

            str3 = "TuesDay";
            Week week = (Week)Enum.Parse(typeof(Week), str3);
            Console.WriteLine(week);

            //enum -> int
            Week week1 = Week.WednesDay;
            Console.WriteLine((int)(week1));

            //int -> enum
            int s = 19;
            Week week2 = (Week)s;
            Console.WriteLine(week2);


            #endregion




        }
    }



    class Student
    {
        public Student(string name, int age, Sex sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// 自我介绍
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine($"我叫{Name}，今年 {Age}岁，性别是 {Sex} ");

        }
    }


    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum Sex
    {
        /// <summary>
        /// 男
        /// </summary>
        Man,
        /// <summary>
        /// 女
        /// </summary>
        Woman
    }


    public enum Week
    {
        /*
         *枚举中的每一个项和一个int值等效
         *默认枚举中的第一项是0，
         *后边的项是前一项加1
         *也可以为人为指定值
         */


        SunDay, //0
        MonDay, //1
        TuesDay = 100,
        WednesDay, //101
        ThursDay = 0x12, //18
        FriDay,  //19
        SaturDay //20
    }



}





