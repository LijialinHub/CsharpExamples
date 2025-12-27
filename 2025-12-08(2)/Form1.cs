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

namespace _2025_12_08_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Motor motor;
        private void btnStart_Click(object sender, EventArgs e)
        {
            

            if(nudMinute.Value !=0  || nudSecond.Value != 0)
            {
                motor = new Motor();
                motor.nudMinute = (int)nudMinute.Value;
                motor.nudSecond = (int)nudSecond.Value;
                motor.motorSstate = true;

                motor.motorSstate = true;
                timer1.Enabled = true;
                timer1.Interval = 1000;
                timer1.Start();

                lalState.BackColor = motor.motorSstate == true ? Color.Green : Color.Red;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(motor.motorSstate == true)
            {
                motor.runSeconds++;
                lblSecond.Text = motor.runSeconds.ToString();

                //motor.runSeconds转为时分秒进行显示
                int h = motor.runSeconds / 60 / 60;
                int m = motor.runSeconds %3600 /60;
                int s = motor.runSeconds % 60;

                lblHours.Text = h.ToString();
                lblMinute.Text = m.ToString();
                lblSecond.Text = s.ToString();

                
            }
            if (motor.runSeconds >= motor.nudMinute * 60 + motor.nudSecond)
            {   

                timer1.Stop();
                motor.motorSstate = false;
                lalState.BackColor = motor.motorSstate == true ? Color.Green : Color.Red;
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            motor.motorSstate = false;
            timer1.Stop();
            lalState.BackColor = motor.motorSstate == true ? Color.Green : Color.Red;
        }

    }
}
