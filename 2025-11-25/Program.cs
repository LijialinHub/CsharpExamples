using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_11_25
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]   //sealed 密封类无法被继承
        //[CustAttribute("123")]   //特性类，必须继承系统Attribute类
                                 //特性类命名一般以Attribute结尾，使用时候可以省掉后面的
                                 //特性类可修饰类、以及类的成员[特性类]
                                 //[特性类] 是在调用构造函数的，无参构造函数可以省略，有参则必须写
                                 //特性类相当于一个标签，补充类，是为了给类和类的成员添加额外信息的
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

        }

        //[CustAttribute("123")]
        //public static string A {  get; set; }

    }


    sealed class A { } //sealed 密封类无法被继承

    class CustAttribute : Attribute  //特性类
    {
        public string N { get; set; }
        public CustAttribute(string n) { N = n; }
    }
}
