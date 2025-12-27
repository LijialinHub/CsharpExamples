using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static _2025_12_11.Program;

namespace _2025_12_11
{
    internal class Program
    {
        /// <summary>
        /// 定义了一个无返回值 无参数输入的委托类型MyDele
        /// </summary>
        public delegate void MyDele();
        
        /// <summary>
        /// 定义了一个返回值为double类型，有两个double类型输入的委托类型DeleCalcu
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public delegate double DeleCalcu(double a, double b);

        /// <summary>
        /// 定义了一个返回值为T(类型占位符，具体什么类型使用时候必须确定)
        /// 输入为P(类型占位符，具体什么类型使用时候必须确定)的数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="P"></typeparam>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public delegate T DeleCalcuGeneric<T, P>(params P[] inputs);

        static void Main(string[] args)
        {

            #region 委托的基本概念
            ////委托是一种数据类型，引用类型，特殊类(class)
            ////委托类型的变量 指向一个或多个方法
            //Program p1 = new Program();
            ////MyDele m1 = new MyDele(p1.Method);
            ////MyDele m2 = new MyDele(Program.StaMethod);

            //MyDele m1 = p1.Method;
            //MyDele m2 = StaMethod;  //new可省略

            //Test test = new Test();
            //DeleCalcu d1 = test.Add;
            //DeleCalcu d2 = Test.Sub;

            ////委托的调用 实际上指的是调用委托所指向的方法
            //m1.Invoke(); //相当于执行p1.Method
            //m1();  //m1.Invoke();的简写方式
            //m2();

            //Console.WriteLine(d1(1, 2));
            ////d1.Invoke(1,2);

            ////?的作用是为空不执行 不为空执行 为空也不报错只是不执行
            ////MyDele m3 = null;
            ////m3?.Invoke();

            //// ??作用： 如果d3.？Invoke(1,2)为null
            ////          则返回？？右边的默认值
            //DeleCalcu d3 = null;
            //double r3 = d3?.Invoke(1,2) ?? 0;
            //Console.WriteLine(r3);

            ////值类型？ 可控类型 ，可以被赋值为null
            bool? b1 = null;
            bool? b2 = true;

            #endregion

            #region 委托的多播功能 += 添加方法(Add) -=移除方法(Remove)

            DeleCalcu d1 = Test.Mul;
            d1 += Test.Div;
            d1 += Test.Sub;

            //Console.WriteLine(d1?.Invoke(1,2));//返回的是最后一个订阅的结果 但是所有订阅都执行了


            d1 -= Test.Sub;
            d1 -= Test.Sub;
            d1 -= Test.Sub; //取消订阅次数大于订阅次数 不会报错
            //相同方法 订阅几次 就需要取消几次

            //一次获取委托指向的每个方法的返回值
            foreach (var d in d1.GetInvocationList())
            {
                Object obj = d.DynamicInvoke(1,2);
                Console.WriteLine(obj);
            }

            #endregion

            #region 泛型委托

            DeleCalcuGeneric<double, double> deleCalcuGeneric = GetSum;
            Console.WriteLine(deleCalcuGeneric.Invoke(1, 2, 3));  //params关键字效果
            Console.WriteLine(deleCalcuGeneric.Invoke(new double[] {1,2,3,4,5}));


            DeleCalcuGeneric<int, int> deleCalcuGeneric2 = GetLength;
            Console.WriteLine(deleCalcuGeneric2.Invoke(0,0,0,0,0));

            #endregion

            #region 匿名方法和lambda 表达式
            DeleCalcu calcu1 = delegate (double a, double b)
            {
                return a + b;
            };

            Console.WriteLine(calcu1?.Invoke(10, 20));

            //lambda λ方法的极简形式
            DeleCalcu calcu2 = (a, b) => { return a + b; };
            calcu2 = (a, b) => a + b;

            MyDele m3 = () => { Console.WriteLine("6666"); };
            m3 += ()=> { Console.WriteLine("8888"); };
            m3.Invoke();

            DeleCalcuGeneric<double,double> d2 = (input) => {  return input.Max(); };
            DeleCalcuGeneric<double, double> d3 = input => input.Max();

            
            #endregion

            #region 系统提供的Action和Func委托
            //Action委托: 1.无参数输入,无返回值
            //            2.有一个或多个输入,无返回值的泛型委托

            Action ac1 = () => { Console.WriteLine("无参无参的委托Action"); };
            ac1.Invoke();

            Action<bool, string, double[]> ac2 = (a, b, c) =>
            {
                Console.WriteLine(!a);
                Console.WriteLine(b.Length);
                Console.WriteLine(c.Max());
            };

            ac2?.Invoke(true, "123", new double[] { 1, 2, 3, 999 });

            //Func委托:有0个或者多个参数输入,有返回值的泛型委托
            Func<int> fc1 = () => {  return 1; };
            Console.WriteLine(fc1?.Invoke());

            //最后一个是返回值类型
            Func<double[], int[], bool> fc2 = (a,b) =>
            {
                return a.Sum() > b.Sum() ? true : false;
            };

            Console.WriteLine(fc2?.Invoke(new double[]{ 0,0,0}, new int[] {1,2,3}));

            #endregion


            #region 应用举例

            double[] doubleArr = new double[] {50,15,-20,-10,55,60, 25 };
            //double r1 = GetSum(doubleArr, x => { return x > 0; });
            //规则求和 Func委托+lambda表达式
            double r1 = GetSum(doubleArr, x => x > 0);  //205
            double r2 = GetSum(doubleArr, x => x%2 == 0); // 80
            double r3 = GetSum(doubleArr, x => x%2 != 0); //95


            #endregion


        }

        public static double GetSum(double[] inputs, Func<double, bool> fc)
        {
            double sum = 0;
            foreach (var input in inputs) 
            {   
                if(fc(input))
                {
                    sum += input;
                }
            }
            return sum;
        }


        public static double GetSum(double[] inputs)
        {
            return inputs.Sum();
        }

        public static int GetLength(int[] inputs)
        {
            return inputs.Length;
        }


        public void Method() {
            Console.WriteLine("这是一个无参无返的实例方法");
        }

        public static void StaMethod() {
            Console.WriteLine("这是一个无参无返的静态方法");
        }

    }


    public class Test
    {   
        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Sub(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// 乘法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Mul(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// 除法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Div(double a, double b)
        {
            return a / b;
        }
    }

}
