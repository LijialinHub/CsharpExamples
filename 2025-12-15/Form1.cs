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

namespace _2025_12_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread thread;
        /// <summary>
        /// 继续
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                thread?.Resume();  //继续挂起的线程
            }
            catch (Exception)
            {

                
            }
        }
        /// <summary>
        /// 线程暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                thread?.Suspend();  //挂起线程
            }
            catch (Exception)
            {

                
            }
        }
        /// <summary>
        /// 线程开始事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            int num = 0;
            thread = new Thread(()=>
            {
                while (true) 
                {
                    num++;
                    this.Invoke(new Action(() => { label1.Text = num.ToString(); }));
                }
            });

            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 中止事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuspension_Click(object sender, EventArgs e)
        {
            try
            {
                thread.Abort();
            }
            catch (Exception)
            {

                
            }
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
