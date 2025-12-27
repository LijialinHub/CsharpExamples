using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_12_16
{
    internal class Program
    {
        /// <summary>
        /// 两种方法实现线程间的顺序执行
        /// </summary>
        private static AutoResetEvent are1 = new AutoResetEvent(true); 
        private static AutoResetEvent are2 = new AutoResetEvent(true); 
        private static AutoResetEvent are3 = new AutoResetEvent(true); 

        private static ManualResetEvent mre1 = new ManualResetEvent(false);
        private static ManualResetEvent mre2 = new ManualResetEvent(false);
        private static ManualResetEvent mre3 = new ManualResetEvent(false);


        static void Main(string[] args)
        {

            #region 阻塞点自动复位 AutoResetEvent

            //Task tk1 = new Task(() =>
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        are1.WaitOne();
            //        Console.WriteLine("AAA");  // 执行了are1.set(),就不阻塞了，线程往下走
            //                                   //然后are1.WaitOne() 会自动复位，又阻塞了
            //        are2.Set();

            //        //mre1.WaitOne();
            //        //Console.WriteLine("AAA");
            //        //mre1.Reset();
            //        //mre2.Set();

            //    }
            //});


            //Task tk2 = new Task(() =>
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        are2.WaitOne();
            //        Console.WriteLine("BBB");
            //        are3.Set();

            //        //mre2.WaitOne();
            //        //Console.WriteLine("BBB");
            //        //mre2.Reset();
            //        //mre3.Set();


            //    }
            //});

            //Task tk3 = new Task(() =>
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        are3.WaitOne();
            //        Console.WriteLine("CCC");
            //        are1.Set();

            //        //mre3.WaitOne();
            //        //Console.WriteLine("CCC");
            //        //mre3.Reset();
            //        //mre1.Set();
            //    }
            //});

            //tk1.Start();
            //tk2.Start();
            //tk3.Start();
            ////are1.Set();
            ////mre1.Set();
            //Console.ReadLine();

            #endregion


            #region Task的阻塞控制

            #region Wait方法， Wait就是用来阻塞线程的。阻塞其所在位置的线程
            ////x.Wait(); 放在哪里 就阻塞哪里 要等x执行完
            //Task tk3 = new Task(() => 
            //{
            //    Console.WriteLine($"当前线程tk3的线程ID是: {Thread.CurrentThread.ManagedThreadId}");
            //    Thread.Sleep(2000);// 模拟一个耗时执行动作
            //    Console.WriteLine("线程tk3的线程动作执行完了");
            //});

            //Task tk4 = new Task(() =>
            //{
            //    Console.WriteLine($"当前线程tk4的线程ID是: {Thread.CurrentThread.ManagedThreadId}");
            //    tk3.Wait();
            //    Thread.Sleep(1000);// 模拟一个耗时执行动作
            //    Console.WriteLine("线程tk4的线程动作执行完了");
            //});

            //tk3.Start();
            //tk4.Start();
            //tk3.Wait();//阻塞主线程，直到tk3任务执行完毕，主线程才往下走
            //Console.WriteLine($"当前主线程线程ID是: {Thread.CurrentThread.ManagedThreadId}");
            //Console.ReadLine();


            #endregion


            #region WaitAll WaitAny (WhenAll WhenAny, ContinueWith)方法

            Task<string> tk3 = new Task<string>(() =>
            {
                Console.WriteLine($"当前线程tk1的线程ID是: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);// 模拟一个耗时执行动作
                Console.WriteLine("线程tk1的线程动作执行完了");
                return "线程tk1执行完了";
            });

            Task<string> tk4 = new Task<string>(() =>
            {
                Console.WriteLine($"当前线程tk2的线程ID是: {Thread.CurrentThread.ManagedThreadId}");

                Thread.Sleep(3000);// 模拟一个耗时执行动作
                Console.WriteLine("线程tk2的线程动作执行完了");
                return "线程tk2执行完了";
            });

            tk3.Start();
            tk4.Start();
            Console.WriteLine("******************************************************");
            //Task.WaitAll(tk3, tk4);  //tk3 tk4都必须执行完，执行流才往下走
            //int res = Task.WaitAny(tk3, tk4);  //tk3 tk4只要有一个执行完，执行流就往下走
            //返回值是先执行完的任务的索引 0表示tk3 1表示tk4

            //WhenAll 线程带返回值的情况  tk3 tk4都必须执行完，执行流才往下走
            //Task<string[]> taskArr = Task.WhenAll(tk3, tk4);
            //string[] strArr = taskArr.Result;
            //Console.WriteLine(strArr[0]);
            //Console.WriteLine(strArr[1]);

            //WhenAny 线程带返回值的情况  tk3 tk4只要有一个执行完，执行流就往下走
            //Task<Task<string>> taskAny = Task.WhenAny(tk3, tk4);
            //string taskAnyStr = taskAny.Result.Result;
            //Console.WriteLine(taskAnyStr);   //先执行完的任务的返回值


            //ContinueWith  当tk4执行完后，继续执行后续的任务 
            //tk4.ContinueWith((t) =>
            //{
            //    Console.WriteLine("继续执行tk4的后续任务");
            //    Console.WriteLine($"tk4的返回值是: {t.Result}");
            //});


            Console.WriteLine($"当前主线程线程ID是: {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadLine();


            #endregion


            #endregion

        }
    }
}
