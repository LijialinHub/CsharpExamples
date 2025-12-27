using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_12_17_3_
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"主线程ID是: {Thread.CurrentThread.ManagedThreadId}");
            int sum = await Method3();
            Console.WriteLine(sum);
            Console.WriteLine($"主线程ID是: {Thread.CurrentThread.ManagedThreadId}");

            Console.ReadLine();
        }


        public static async Task Method1()     //方法里有await关键字
                                                //那么这个方法必须声明为异步方法
                                                //方法前加async关键字
        {   

            //await加在返回值为Task的类型的代码前边
            await Task.Run(() => 
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Method 1");
                }
                Console.WriteLine($"Method1 执行0~9 的线程ID是: {Thread.CurrentThread.ManagedThreadId}");
            });

            
            Console.WriteLine($"Method1 的线程ID是: {Thread.CurrentThread.ManagedThreadId}");
            
        }


        public static void Method2()
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Method 2");
                    Thread.Sleep(300);
                }
                Console.WriteLine($"Method2 执行0~9 的线程ID是: {Thread.CurrentThread.ManagedThreadId}");
            });

            Console.WriteLine($"Method2 的线程ID是: {Thread.CurrentThread.ManagedThreadId}");
        }


        public static async  Task<int> Method3()
        {
            int sum = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    sum += i;
                    Thread.Sleep(100);
                }
            });

            return sum;
        }


    }
}
