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

namespace _2025_12_15_3_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取消令牌信号
        /// </summary>
        private CancellationTokenSource cts = new CancellationTokenSource();

        /// <summary>
        /// 人工复位事件
        /// </summary>
        private ManualResetEvent mre = new ManualResetEvent(true);  //false 初始状态设为终止
                                                                //true 非终止
        

        /// <summary>
        /// 开始执行(20s后自动停止)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            // 如果已有任务在运行，先取消它
            //if (cts != null && !cts.IsCancellationRequested)
            //{
            //    //cts.Cancel();
            //    return;
            //}

            cts = new CancellationTokenSource(new TimeSpan(0, 0, 20)); //五秒后取消

            int num = 0;
            var tk1 = Task.Run(() =>
            {
                while (!cts.IsCancellationRequested) 
                {
                    num++;
                    this.Invoke(new Action(() => 
                    { 
                        label1.Text = num.ToString();
                    }));

                    Thread.Sleep(200);
                }
            });

            cts.Token.Register(() =>
            {
                MessageBox.Show("20s 任务已取消");
            });

        }

        /// <summary>
        /// 手动取消执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Task.Run(() => 
            {
                cts?.Cancel();
            });
        }

        /// <summary>
        /// 手动取消任务(3s后)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if(cts != null && !cts.IsCancellationRequested)
            {
                cts?.CancelAfter(3000); //3s后取消
            }
        }

        /// <summary>
        /// 取消信号重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
        }


        /// <summary>
        /// 暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            mre.Reset();  //阻止线程继续执行
        }

        /// <summary>
        /// 继续
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            mre.Set();  //允许线程继续执行
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// 开始执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {

            int num = 0;
            var tk1 = Task.Run(() =>
            {

                MessageBox.Show($"当前Task.Run的线程Id是: {Thread.CurrentThread.ManagedThreadId}");
                while (!cts.IsCancellationRequested)
                {
                    num++;
                    this.Invoke(new Action(() =>
                    {
                        label1.Text = num.ToString();
                    }));
                    Thread.Sleep(200);

                    mre.WaitOne();      //阻止当前线程，直到当前System.Threading.WaitHandle收到信号为止。
                    //收到信号: 执行 mre.set() 线程可以往下执行
                    //执行了mre.Reset() 线程阻塞在这里

                }
            }, cts.Token);


            //一旦收到取消信号就触发下面的操作(无论是手动的Cancel方法还是时间到了自动发送取消)
            //就会调用Regiser方法中的委托
            cts.Token.Register (() =>
            {
                this.BackColor = Color.Red;

                MessageBox.Show($"任务已取消  当前Token.Register的线程Id是: {Thread.CurrentThread.ManagedThreadId}");
                

                int m = 0;
                for (int i = 0; i < 10; i++)
                {
                    m++;
                    this.Invoke(new Action(() => { this.Text = m.ToString(); }));
                    Thread.Sleep(1000);
                }
            },false);  //True: Ui线程执行Token.Register里面的委托
                       //False: 延续Cancel那个线程去执行Token.Register里面的委托
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
