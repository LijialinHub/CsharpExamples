using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2025_11_19;

namespace _2025_11_20
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region 类的多态
            ////核心定理==里氏转换：子类的对象(子类的子类)可以赋给父类(父类的父类)的引用

            //Biology biology = new Biology() { TypeName = "动物" };

            //Biology biology1 = new Person();

            //Person p1 = (Person)biology1;  //父类接收子类实例时候 想用子类方法 需要强转
            ////p1.Breath();


            //List<Biology> biologies = new List<Biology>()
            //{   
            //    new Person(){TypeName = "黑"},
            //    new Student(){TypeName = "黄"},
            //    new Driver(){ TypeName = "白"}
            //};

            //foreach (var item in biologies)
            //{
            //    //if(item is Student st)  //特殊写法 判断完做了个类型转换 赋值给了st
            //    // {
            //    //     //st.Study();

            //    // }
            //    (item as Student)?.Study();  //同上等效
            //}


            ////is 关键字 和 as 关键字 以及？
            ////is: 当前变量的引用名是否指向某个类的对象 返回true或者false
            //bool isok1 = biologies[0] is Biology;
            //bool isok2 = biologies[0] is Person;
            //bool isok3 = biologies[2] is Student;


            ////as关键字，用于转换，能转则转，不能转赋null值
            ////?: 非空检测 ，如果前边为空，则不执行后边的方法 ，避免报错
            //Biology biology2 = biologies[0] as Biology;
            //Student student2 = biologies[2] as Student; //为null 

            //student2?.Study();   //不报错 为null就不执行.后边的方法


            #endregion

            #region 虚方法和重新方法

            //A a1 = new A();
            //A a2 = new B();
            //A a3 = new C();
            //A a4 = new D();

            //a1.Method_A2();
            //a2.Method_A2();

            //a1.Method_A1();
            //a2.Method_A1();  //a2指向的实体是new B（）
            //                 //虚方法是动态调用。如果子类重写了，则调用子类中重写的方法Method_A1
            //                 //没有则还是调用父类中的Method_A1


            //a3.Method_A1();
            //a4.Method_A1(); //

            //B b1 = new D();
            //b1.Method_A1();
            //b1.Method_A2();



            #endregion


            #region 结构体
            //结构体是值类型，可以认为是更加简单的类
            //结构体一般存储一些公开的字段就行了 包含属性的话 需要new实例化使用
            //结构体一般不需要实例化(包含属性的话需要)

            Inverter inverter;

            inverter.Current = 0;
            inverter.Voltage = 1;


            #endregion



        }
    }


    struct Inverter
    {
        /// <summary>
        /// 电压
        /// </summary>
        public double Voltage;
        /// <summary>
        /// 电流
        /// </summary>
        public double Current;
    }


    class A
    {
        public virtual void Method_A1()   //用virtual修饰 虚方法
        {
            Console.WriteLine("这是A类中的虚方法Method_A1");
        }

        public void Method_A2()
        {
            Console.WriteLine("这是A类中的正常方法Method_A2");
        }

    }

    class B : A
    {   
        //虚方法是可以被子类重写的，也可以不重写
        public override void Method_A1()  //override:重写、覆盖
        {
            //base.Method_A(); //执行父类的Method_A1
            Console.WriteLine("这是B中重写父类A的虚方法Method_A1");
        }
    }

    class C : B 
    {

    }

    class D : B
    {
        public override void Method_A1()
        {
            Console.WriteLine("这是D中重写了父类的父类虚方法Method_A1");
        }
    }



}
