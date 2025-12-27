using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 随机变色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRandColor_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            var r = random.Next(0, 256);
            var g = random.Next(0, 256);
            var b = random.Next(0, 256);
            this.BackColor = Color.FromArgb(r, g, b);
        }

        private void btnNotThread_Click(object sender, EventArgs e)
        {
            txtDisplay1t100.Clear();
            for (int i = 1; i < 101; i++)
            {
                txtDisplay1t100.AppendText(i + "\r\n");
                Thread.Sleep(100);
            }
        }


        private void btnOpenThread_Click(object sender, EventArgs e)
        {
            txtDisplay1t100.Clear();
            Thread thread = new Thread(() =>
            {
                //对UI控件的写入操作，必须使用UI线程(主线程)来完成
                for (int i = 1; i < 101; i++)
                {
                    this.Invoke(new Action(() =>   //不是一定要用this 只要是UI控件对象都可以调出Invoke方法  
                    {   
                        //在这里的代码就是UI线程完成的
                        txtDisplay1t100.AppendText(i + "\r\n");
                    }));
                    
                    Thread.Sleep(100);  //执行流线程休眠100ms
                }
            });
            //获取或设置一个值，该值指示某个线程是否为后台线程
            //false:前台线程  true:后台线程(所有的前台线程结束后，后台线程会自动终止退出，应用程序结束)
            //主线程就是前台线程
            thread.IsBackground = true;
           
            thread.Start();// 开始执行
            
        }

        
        private void btnAllExecute_Click(object sender, EventArgs e)
        {

            //编程： 同步执行（顺序执行） 异步执行(并发执行,一般要开线程)

            txtDisplay1t100.Clear();
            txtDisplay100t1.Clear();

            Thread thread = new Thread(() =>
            {
            for (int i = 1; i < 101; i++)
            {
                    this.Invoke(new Action(() => { txtDisplay1t100.AppendText(i + "\r\n"); }));
                    Thread.Sleep(100);  //执行流线程休眠100ms
                }
            });

            Thread thread2 = new Thread(() =>
            {
                for (int i = 100; i >= 1; i--)
                {
                    this.Invoke(new Action(() => { txtDisplay100t1.AppendText(i + "\r\n"); }));
                    Thread.Sleep(100);  //执行流线程休眠100ms
                }
            });

            thread.IsBackground = true;
            thread2.IsBackground = true;

            thread.Start();
            thread2.Start();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0); //结束程序
        }

        private void btnHasArgs_Click(object sender, EventArgs e)
        {

            Thread thread = new Thread(obj => 
            {
                int num = int.Parse((string)obj);
                int sum = 0;
                for (int i = 0; i < num; i++)
                {
                    sum += i;
                    this.Invoke(new Action(() =>
                    {
                        txtDisplayRes.Text = sum.ToString();
                    }));

                    Thread.Sleep(100);
                }

                
            });

            thread.IsBackground = true;
            thread.Start(txtArgs.Text);

            
        }
    }
}
