using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_08
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmRealtimeChart chart = new frmRealtimeChart();
            chart.TopLevel = false; //作为非顶级控件
            panelFormPage.Controls.Add(chart);
            chart.Dock = DockStyle.Fill;
            chart.Show();
        }



        private void btnChangePage_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            panelFormPage.Controls.Clear();
            switch(button.Text)
            {
                case "实时曲线":
                    frmRealtimeChart chart = new frmRealtimeChart();
                    chart.TopLevel = false; //作为非顶级控件
                    panelFormPage.Controls.Add(chart);
                    chart.Dock = DockStyle.Fill;
                    chart.Show();
                    break;

                case "报警画面":
                    frmAlarm frmAlarm = new frmAlarm();
                    frmAlarm.TopLevel = false;
                    panelFormPage.Controls.Add(frmAlarm); 
                    frmAlarm.Dock = DockStyle.Fill;
                    frmAlarm.Show();
                    break;

                case "配方画面":
                    frmRecipe frmRecipe = new frmRecipe();
                    frmRecipe.TopLevel = false;
                    panelFormPage.Controls.Add(frmRecipe);
                    frmRecipe.Dock = DockStyle.Fill;
                    frmRecipe.Show();
                    break;

                case "用户管理":
                    frmUser frmUser = new frmUser();
                    frmUser.TopLevel = false;
                    panelFormPage.Controls.Add(frmUser); 
                    frmUser.Dock = DockStyle.Fill;
                    frmUser.Show();
                    break;
            }


        }
    }
}
