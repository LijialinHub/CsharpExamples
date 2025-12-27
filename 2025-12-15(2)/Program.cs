using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_12_15_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 开启Task任务的三种方法
            ////Task都是后台线程，Task从线程池中取的
            ////异步多线程 同步单线程

            //Task tk1 = new Task(()=>
            //{
            //    Console.WriteLine($"当前子线程ID：{Thread.CurrentThread.ManagedThreadId}");

            //    for (int i = 1; i <= 10; i++)
            //    {
            //        Console.WriteLine($"当前i = {i}");
            //        Thread.Sleep(200);
            //    }
            //});

            ////tk1.Start(); //启动任务


            ////Console.WriteLine($"当前主线程ID：{Thread.CurrentThread.ManagedThreadId}");
            ////Console.ReadLine();  //

            ////定义并马上开始执行任务
            //Task tk2 = Task.Factory.StartNew(()=>
            //{
            //    Console.WriteLine($"当前子线程ID：{Thread.CurrentThread.ManagedThreadId}");

            //    for (int i = 1; i <= 10; i++)
            //    {
            //        Console.WriteLine($"当前i = {i}");
            //        Thread.Sleep(200);
            //    }
            //});
            //Console.WriteLine($"当前主线程ID：{Thread.CurrentThread.ManagedThreadId}");
            //Thread.Sleep(3000);
            //Console.WriteLine("********************************************");
            //Console.ReadLine();  //


            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine($"当前i = {i}");
            //        Thread.Sleep(200);
            //    }
            //    Console.WriteLine($"当前子线程: {Thread.CurrentThread.ManagedThreadId}");
            //}
            //);

            //for (int i = 10; i>=1; i--)
            //{
            //    Console.WriteLine($"当前num = {i}");
            //    Thread.Sleep(200);
            //}

            //Console.WriteLine($"当前主线程ID {Thread.CurrentThread.ManagedThreadId}");
            //Thread.Sleep(1000);
            //Console.WriteLine("*************************************");
            //Console.ReadLine();  


            #endregion

            #region Task的返回值

            //Task<int> tk1 = new Task<int>(() =>
            //{
            //    int sum = 0;
            //    for (int i = 0; i < 10; i++)
            //    {
            //        sum += i;
            //        Console.WriteLine($"i的值为: {i}");
            //    }
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"当前子线程id: {Thread.CurrentThread.ManagedThreadId}");
            //    return sum;
            //});

            //tk1.Start();
            //Console.WriteLine($"当前主线程id: {Thread.CurrentThread.ManagedThreadId}");
            //Console.WriteLine(tk1.Result); //阻塞了当前线程(主线程)
            //Console.WriteLine("************************************************");
            //Console.ReadLine();


            //Task<int> tk2 = Task.Run<int>(() => 
            //{
            //    int sum = 0;
            //    for (int i = 0; i < 10; i++)
            //    {
            //        sum += i;
            //        Console.WriteLine($"i的值为: {i}");
            //    }
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"当前子线程id: {Thread.CurrentThread.ManagedThreadId}");
            //    return sum;
            //});

            //Console.WriteLine($"当前主线程id: {Thread.CurrentThread.ManagedThreadId}");

            //Task tk3 = Task.Run(() => 
            //{
            //    Console.WriteLine($"当前tk3子线程id: {Thread.CurrentThread.ManagedThreadId}");
            //    Console.WriteLine($"tk2的结果是: {tk2.Result}"); //阻塞了当前线程(主线程)
            //});


            #endregion

            #region Task参数输入和返回

            //Task<int> tk4 = new Task<int>(obj =>
            //{
            //    Student stu = obj as Student;
            //    if (stu == null)
            //    {
            //        return 0;
            //    }
            //    int sum = stu.ChineseScore + stu.EnglishScore + stu.MathScore;
            //    Console.WriteLine("----------------------");
            //    Thread.Sleep(2000);
            //    return sum;

            //}, new Student() { Name = "张三", ChineseScore = 1, EnglishScore = 2, MathScore = 3 });

            //tk4.Start();
            //Console.WriteLine("*************************");
            //Console.WriteLine(tk4.Result);
            //Console.WriteLine("*************************");
            //Console.ReadLine();


            Task<Student> tkStu2 = Task.Run<Student>((() =>
            {
                Student stu = new Student()
                {
                    Name = "李四",
                    ChineseScore = 90,
                    MathScore = 95,
                    EnglishScore = 85
                };
                Thread.Sleep(2000);
                return stu;
            }));

            Console.WriteLine("*************************");
            tkStu2.Result.ShowInfo();
            Console.WriteLine("*************************");
            Console.ReadLine();


            #endregion

            #region 多个线程长时间运行，要使用Thread.Sleep的方法

            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(5);
                }
            });

            #endregion

        }
    }


    public class Student
    {
        public string Name { get; set; }

        public int ChineseScore { get; set; }

        public int MathScore { get; set; }

        public int EnglishScore { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"姓名: {Name}, 语文成绩: {ChineseScore}, 数学成绩: {MathScore}, 英语成绩: {EnglishScore}");
        }
    }


}
