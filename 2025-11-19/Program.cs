using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2025_11_19_dll_;
namespace _2025_11_19
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region try catch语句

            //try //程序在运行时会捕获 try作用域中的异常代码，一旦发生异常会立即进入catch语句中处理 产生的异常对象就是exception类的实例会赋给ex
            //{
            //    Console.Write("输入第一个数:");
            //    double a = double.Parse(Console.ReadLine());

            //    Console.Write("输入第二个数:");

            //    double b = double.Parse(Console.ReadLine());

            //    if(b == 0) { throw new Exception("除数不能为0"); } //会立即进入catch语句中 将异常对象赋值给ex

            //    double res = a / b;
            //    Console.WriteLine($"两个数相除的结果是 {res} ");

            //    Console.ReadLine();
            //}
            //catch (Exception ex) //catch作用域中编写异常处理的代码
            //{
            //    //Console.WriteLine(ex.Message);
            //    throw ex;
            //}
            #endregion


            #region dll的创建和引用

            //Console.WriteLine(Calcu.Add<bool>(true,false));

            ////不是所有的dll都可以添加引用 必须是.net语言编写的

            #endregion


            //类的三大特性 封装、继承、多态
            #region 类的继承
            //继承允许我们根据一个类来定义另一个类
            //这使得创建和维护应用程序变得更加容易 同时也有利于重用代码和节省开发时间
            //当创建一个类时。程序员不需要完整重新编写新的数据成员（字段属性）和成员函数(方法)
            //只需要设计一个新的类，继承已有的类的成员即可
            //这个已有的类被称为基类(父类)，而新创建的类被称为派生类(子类)

            Biology biology = new Biology();
            biology.TypeName = "黄种人";
            biology.Breath();

            Person person = new Person();
            person.Name = "张三";
            person.Age = 18;
            person.Running();
            person.TypeName = "白种人";
            person.Breath();


            #endregion

        }
    }






}
