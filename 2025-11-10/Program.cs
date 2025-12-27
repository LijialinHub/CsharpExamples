using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_10
{   

    /* 构造函数
     *1. 无参构造函数 2. 有参构造函数
     *特点 一般是public公开的 构造函数名字和类名必须一样 中间不加任何修饰词 
     *有参构造函数一般用于创建对象时给对象的属性或者字段赋初始值
     *如果没有人为编写任何构造函数，系统会默认分配一个无参构造函数
     *如果有人为编写的构造函数，系统就不会分配构造函数
     *创建对象时必须调用人为编写的构造函数
     */


    class Student
    {
        public Student()
        {
            Console.WriteLine("这是一个无参的构造函数。");
        }  //无参构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="age">年龄</param>
        public Student(string name, int age)
        {
            this.Name = name;
            this.age = age;
        }

        public Student(
            double chineseScores,
            double mathScores,
            double englishScores,
            string name,
            int age) : this(name, age) 
        {
            ChineseScores = chineseScores;
            MathScores = mathScores;
            EnglishScores = englishScores;
            
        }

        /*方法
         * 1. 无返回值 2.有返回值
         * 无返回值的方法必须使用void修饰
         * 有返回值的必须声明返回值类型, 方法内部要写return 后跟返回值
         * 方法有() 和作用域{}
         * ()里面可以设置这个方法的参数,也可以不设置
         
         */

        /*关键字static
        *关键字static是用来修饰类的成员的(属性\字段\构造函数\事件)
        *
        *一个类的成员被static那么这个成员是静态的(共享的),是属于类的
        *使用类名调用
        *一个类的成员没有被static修饰,那么这个成员是实例成员,属于对象的,
        *使用对象去调用
        *
         */

        public void Study()
        {
            Console.WriteLine("正在学习中.....");
        }

        /// <summary>
        /// 加法运算
        /// </summary>
        /// <param name="a">数值1</param>
        /// <param name="b">数值2</param>
        /// <returns>加法运算的结果</returns>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// 减法运算
        /// </summary>
        /// <param name="a">数值1</param>
        /// <param name="b">数值2</param>
        /// <returns>减法运算的结果</returns>
        public static double Sub(double a, double b)
        {
            return a - b;
        }



        public static int A { get; set; }

        public int B { get; set; }


        /// <summary>
        /// 语文成绩
        /// </summary>
        public double ChineseScores { get; set; }
        /// <summary>
        /// 数学成绩
        /// </summary>
        public double MathScores { get; set; }
        /// <summary>
        /// 英语成绩
        /// </summary>
        public double EnglishScores { get; set; }
        /// <summary>
        /// 总分
        /// </summary>
        public double SumScores
        { 
            get 
            { 
                return ChineseScores + MathScores + EnglishScores;
            } 
        }



        public string Name { get; set; }

        private int age;

        public int Age
        {
            get { return age; }
            set { 
                if(value > 3 && value < 60)
                {  age = value; }
                else
                {
                    throw new Exception("输入有误");
                }
            }
        }




    }


    static class TestStationClass
    {

        //static修饰一个类 这个类就是个静态类
        //静态类中的所有成员都是静态的


        //public int A { get; set; }

        public static string B { get; set; }

        //public void M(){ }

    }




    internal class Program
    {   

        

        static void Main(string[] args)
        {
            #region 构造函数、方法、关键字static

            //Student student = new Student();
            //student.Name = "张三";
            //student.Age = 30;

            //student = new Student("李四", 28);
            //Console.WriteLine(student.Name);
            //Console.WriteLine(student.Age);  //CTRL + J 智能提示

            //double res = Student.Sub(2, 1);
            //Console.WriteLine(res);

            #endregion


            #region 关于控制台

            //static修饰一个类 这个类就是个静态类
            //静态类中的所有成员都是静态的 静态类是没办法实例化的

            //Console.WindowWidth = 160;
            //Console.WindowHeight = 46;
            //Console.WriteLine(Console.WindowWidth);
            //Console.WriteLine(Console.WindowHeight);

            //Console.BackgroundColor = ConsoleColor.Red;



            #endregion


            #region C#中的简单数据类型
            //常用的简单数据类型 int bool double float decimal byte Long short string char

            //bool型数据 只能赋True 或者 False  ======相当于 
            bool a = true;
            bool b = false;
            bool A = false; //C#区分大小写 A和a不是一个变量

            //bool型数据可以参入逻辑运算 &&（逻辑与）、 ||（逻辑或）、！（逻辑非）
            //逻辑与：&& 必须都为True 结果才是True；只要有一个为False 结果就是False
            bool r1 = a && b; //False
            bool r2 = b && !A && 5!=6 && (7+8)>10; 
            Console.WriteLine(r1);
            Console.WriteLine(r2);

            //逻辑或：|| 只有有一个是True 结果就是True
            bool r3 = a || b; //True
            Console.WriteLine(r3);


            //逻辑非：！ 取反 true变false false变true
            Console.WriteLine(!b);

            //int型数据 默认是32位有符号整数 范围为 -2,147,483,648 到 2,147,483,647
            //在C#中可以输入16进制数，前面加上0x 16进制数：0~9 A~F
            //也可以输入二进制数，前面加上0b 二进制数：0 1
            //1个16进制数可以转4位二进制数，反之亦可
            //8421码

            int f = 0x12AB; // 0x12AB = 1*16^3 + 2*16^2 + 10*16 +11
            int h = 0b10100011; // 1*2^7 + 1*2^5 + 1*2^1 + 1*2^0 = 128+32+2+1 = 163



            #endregion


        }
    }
}
