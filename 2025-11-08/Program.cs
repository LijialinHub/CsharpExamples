using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using _2025_11_08.TT;


namespace _2025_11_08
{

    //Program是系统提供的一个类， 这个类中有Main方法
    //Main方法是程序入口 项目运行时 会自动进入Program类中的Main方法
    //从上到下 从左到右依次执行
    internal class Program  //namespace: 命名空间关键字
                            //命名空间的成员 类class 结构体struct 枚举enum
                            //接口interface 委托delegate
    {

        static void Main(string[] args)
        {
            #region using和对象的介绍

            int a = 666;
            string b = "abc";
            //new Student 做了三件事
            //在内存 堆中分配了一个空间
            //在这个空间创建了Student类的对象
            //调用了Student类无参的构造函数
            Student zs = new Student(); //实例化

            Employee employee;

            IFly fly;

            MyDele myDele;

            Teacher teacher;

            TT.Teacher teacher1 = new TT.Teacher();
            TT.TT_1.Driver driver = new TT.TT_1.Driver();

            #endregion

            //C#中的注释方法有四种：
            //1. //
            //2. /*要注释的内容*/ 块主食 
            //3. 在一个类或者类的成员上面加 “///”
            //4. #region 代码 #endregion 收纳折叠作用

            /*
             
             *这是一个块注释
             *可以进行换行
             
             */


            #region 控制台相关操作

            //1.控制台的输出功能
            //F12：查看定义
            Console.WriteLine("Hello Word!");  //在控制台打印并换行
            Console.Write("666\n");             //只打印不换行
            Console.WriteLine("Hello Word!");

            #endregion


            Student student = new Student();
            student.Name = "Test";
            Console.WriteLine(student.Name);

            //student.Age = 1;






    }
    }

    /// <summary>
    /// 学生类
    /// </summary>
    class Student     //帕斯卡命名方式 每个单词首字母大写
    {

        //类的成员 属性 字段 构造函数 方法 事件 （其他类 析构函数）


        /*
         * 字段是用来存储数据
         * 属性是字段的一个筛选器，属性有get set 方法，而字段没有
         * 属性命名一般使用帕斯卡命名方式
         * 字段一般是私有的private，属性一般是公开的public
         * 字段命名一般有两种方式 1.驼峰法（单词第一个是小写后面单词第一个字母大写）
         *                        2.每个单词首字母大写，前边加_ 例如： _Name
         * 私有的private：只能在当前类内部访问
         * 公开的public：访问不受限。当前类的内部和外部都可以访问
         */


        //private string name;

        //public string Name   //属性
        //{
        //    get { return name; }  //return 返回name的值
        //    set 
        //    {
        //        name = value; //value外部写入的值
        //    }
            
        //}


        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }  //自动属性
                                          //vs会自动生成一个私有name字段 不需要人为编写
                                          //get和set都是访问这个name字段

        private int age;

        public int Age  
        {
            get 
            { 
                return age; 
            }
            set  //对写入的数据做了过滤
            {
                if(value > 3 && value < 60)   //逻辑与：&&
                {
                    age = value;
                }
                else
                {
                    age = 0;
                    //throw 抛 后边接异常类的实体对象
                    throw new Exception("输入年龄有误，必须在3-60之间");
                }
            }
        }



        






        class TT { }
    }

    struct Employee
    {

    }

    /// <summary>
    /// 性别枚举
    /// </summary>
    enum Sex
    {
        Man,
        Woman
    }


    interface IFly  //接口一般以大写字母I开头， 用于扩展解耦
    {

    }


    delegate void MyDele(); //定义了一个无返回值 无参数输入的委托类型 MyDele


    namespace TT
    {
        public class Teacher { }

        namespace TT_1
        {
            public class Driver { }
        }
    }




}


namespace TN
{
    class People
    {

    }

    namespace TN_1
    {
        class Bird { }
    }

}


