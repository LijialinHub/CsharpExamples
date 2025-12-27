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

namespace _2025_12_17_4_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 同步方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSync_Click(object sender, EventArgs e)
        {
            SyncExecuteTest();
        }


        /// <summary>
        /// 异步方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonASync_Click(object sender, EventArgs e)
        {
            //await ASyncExecuteTest().ConfigureAwait(false);
            await ASyncExecuteTest();
            //Thread.Sleep(3000);
            label3.Text = "到了btn2方法中";
        }

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);

            this.BackColor = Color.FromArgb(r, g, b);

        }



        private void SyncExecuteTest()
        {
            txt100t1.Clear();
            txt1t100.Clear();
            for (int i = 1; i <= 100; i++)
            {
                txt1t100.AppendText(i + "\r\n");
                Thread.Sleep(50);
            }

            for (int i = 100; i >= 1; i--)
            {
                txt100t1.AppendText(i + "\r\n");
                Thread.Sleep(50);
            }

            label3.Text = "已完成";
        }


        private async Task ASyncExecuteTest()
        {
            txt100t1.Clear();
            txt1t100.Clear();

            await Task.Run(() => 
            {
                for (int i = 1; i <= 100; i++)
                {
                    this.Invoke(new Action(() => 
                    { 
                        txt1t100.AppendText(i + "\r\n"); 
                    }));
                    
                    Thread.Sleep(50);
                }
            }).ConfigureAwait(false); //设为true(默认就是true)
                                      //,那么这个1 到100执行完了 延续UI线程执行后边的代码
                                      //设为false，那么从线程池中取一个线程执行后面代码


            this.Invoke(new Action(() =>
            {
                label3.Text = $"1到100已完成";
            }));

            MessageBox.Show($"{Thread.CurrentThread.ManagedThreadId}");

            await Task.Run(() =>
            {
                for (int i = 1; i <= 100; i++)
                {

                    this.Invoke(new Action(() =>
                    {
                        txt100t1.AppendText(i + "\r\n");
                    }));
                    Thread.Sleep(50);
                }
            });

            MessageBox.Show($"{Thread.CurrentThread.ManagedThreadId}");
            this.Invoke(new Action(() =>
            {
                label3.Text = $"100到1已完成";
            }));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
