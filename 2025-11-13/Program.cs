using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 按位异或 
            ////按位异或 ^  相同为0 不同为1 参与运算的是int型数据

            //int d1 = 0x1234;     //0b 0001 0010 0011 0100
            //int d2 = 0xABCD;     //0b 1010 1011 1100 1101
            //int res1 = d1 ^ d2;  //0b 1011 1001 1111 1001
            //string str1 = Convert.ToString(res1,2);
            //Console.WriteLine(str1);

            ////举例
            //Console.WriteLine("请输入要加密的数据:");
            //int data = int.Parse(Console.ReadLine());

            ////密钥
            //int key = 123456;
            ////进行加密
            //int dataCode = data^key;
            //Console.WriteLine($"加密后的数据是{dataCode}");

            ////解密数据
            //int decryptData = dataCode ^key;
            //Console.WriteLine($"解密后的数据是{decryptData}");

            #endregion

            #region switch case语句 选择分支语句
            /*
             *输入学员成绩(整数)
             *范围：90~100 优秀：80~90 良好 70~80 中 60~70 及格 60以下 差
             */

            //Console.WriteLine("请输入学员成绩：");
            //int score = Convert.ToInt32(Console.ReadLine());

            //if(score>= 90 &&  score<= 100)
            //{
            //    Console.WriteLine("优秀");
            //}
            //else if(score>=80 &&  score<=90)
            //{
            //    Console.WriteLine("良好");
            //}
            //else if (score >= 70 && score <= 80)
            //{
            //    Console.WriteLine("中");
            //}
            //else if (score >= 60 && score <= 70)
            //{
            //    Console.WriteLine("及格");
            //}
            //else if (score < 60)
            //{
            //    Console.WriteLine("差");
            //}

            //int res = score / 10;

            //switch(res)
            //{
            //    case 10:    
            //    case 9:
            //        Console.WriteLine("优秀"); break;
            //    case 8:
            //        Console.WriteLine("良好"); break ;
            //    case 7:
            //        Console.WriteLine("中"); break;
            //    case 6:
            //        Console.WriteLine("及格"); break;
            //    default:
            //        Console.WriteLine("差"); break;
            //}




            #endregion

            #region 循环语句while --当条件满足时循环while{}的内容
            //int num = 0;

            //while (num < 100)
            //{
            //    Console.WriteLine($"欢迎来到华山培训学习 {num + 1}");
            //    num++;
            //}

            #endregion

            #region do while 语句用法
            //do while会至少执行一次
            //int num = 1;

            //do {
            //    Console.WriteLine($"欢迎来到华山培训学习 {num }");
            //    num++; 
            //    } 
            //while (num <100);

            #endregion


            #region 使用while 求1+2+。。。100的值的和

            //int index = 1;
            //int countA = 0;
            //while (index <= 100) 
            //{
            //    countA += index;
            //    index++;

            //}
            //Console.WriteLine($"1 to 100的和是: {countA}");

            #endregion

            #region 1到100之间的整数相机 得到累计值大于20的当前数

            //int index = 1;
            //int countA = 0;
            //while (index <= 100)
            //{
            //    countA += index;

            //    if (countA > 20) { Console.WriteLine(countA); }


            //    index++;

            //}


            #endregion

            #region 在while中用break实现要求用户一直输入用户名和密码
            //只要不是admin 88888就一直要求用户重新输入如果正确则提示登录成功


            //Console.WriteLine("请输入用户名：");

            //while (true)
            //{
            //    string userName = Console.ReadLine();
            //    if (userName == "admin") { break; }
            //    else
            //    {
            //        Console.WriteLine("请重新输入用户名：");
            //    }
            //}

            //Console.WriteLine("请输入用户密码：");

            //while (true)
            //{
            //    string passWord = Console.ReadLine();
            //    if (passWord == "88888") { break; }
            //    else
            //    {
            //        Console.WriteLine("请重新输入用户密码：");
            //    }
            //}

            //Console.WriteLine("登录成功！");


            #endregion

            #region 不断要求用户输入一个数字，当用户输入end时，显示刚才输入的最大值

            //List<int> list = new List<int>();
            //while (true) 
            //{ 
            //    Console.WriteLine("请输入一个数：");
            //    string str = Console.ReadLine();
            //    if(str == "end" && list.Count != 0)
            //    {   
            //        Console.WriteLine(list.Max());
            //        break;
            //    }
            //    else
            //    {
            //        list.Add(int.Parse(str));
            //    }

            //}

            #endregion

            #region 一维数组
            //数组是一种固定数量的元素的集合 数组是一种类型
            //数组一旦创建 后边不能添加或者移除元素
            //数组是引用类型
            //声明数组有三种方法
            int[] intArr1 = new int[5]; //创建了一个int类型的数组 这个数组固定5个元素

            intArr1[0] = 10; //数组的索引从0开始，0号是数组的第一个元素
            intArr1[1] = 20;
            intArr1[2] = 30;
            intArr1[3] = 40;
            intArr1[4] = 50;
            //intArr1[5] = 50; 报错 索引超出数组界限

            int count = intArr1.Length; //Length属性：数组中的元素个数
            Console.WriteLine(count);

            double[] doubleArr = new double[] { 1, 2, 3, 4, 5 };
            doubleArr[0] = 0.5;
            Console.WriteLine(doubleArr[2]); //3z
            Console.WriteLine(doubleArr.Length);

            string[] strArr = { "张三", "李四", "王五" }; //简化了 省略了new

            //集合的遍历 1.for语句 2.foreach语句
            for (int i = 0; i < strArr.Length; i++)
            {
                Console.WriteLine(strArr[i]);
            }

            //foreach + tab
            //var 是迭代变量 只能读取不能写入
            foreach (var item in intArr1)
            {
                Console.WriteLine(item);
            }

            //var：隐式类型/推断类型/万能类型 vs会自行推断
            var a = 33;
            var b = 3.56;
            var c = true;
            var d = new Program();



            //
            Student[] students = new Student[]
            {
                new Student("1", 11, Sex.Man),
                new Student("1", 11, Sex.Man),
                new Student("1", 11, Sex.Man),
            };

            foreach (var student in students) 
            {
                student.ShowInfo();
            }
            



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


}
