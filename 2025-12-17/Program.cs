using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_12_17
{
    internal class Program
    {   
        //锁 一般是静态只读，目的是具有唯一性
        public static readonly object lockObj = new object();  //线程锁

        static void Main(string[] args)
        {

            Task tk1 = new Task(()=>ShowDateTimeNow("tk1"));
            Task tk2 = new Task(() => ShowDateTimeNow("tk2"));
            Task tk3 = new Task(() => ShowDateTimeNow("tk3"));

            tk1.Start();
            tk2.Start();
            tk3.Start();
            Console.ReadLine();

        }

        public static void ShowDateTimeNow(string taskName)
        {
            #region 方法一

            //lock (lockObj)  //只要有一个线程进入，其他线程就不能进入，除非这个线程执行完，然后才能进入  在锁外排队，等待这个执行完，才能进入一个线程
            //{
            //    Console.WriteLine(taskName + "---" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //    Thread.Sleep(1000);
            //}

            #endregion


            #region 方法二

            Monitor.Enter(lockObj); //加锁

            try
            {
                Console.WriteLine(taskName + "---" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            finally 
            { 
                Monitor.Exit(lockObj); //释放指定对象上的排它锁
            }
            #endregion


        }

    }



}
