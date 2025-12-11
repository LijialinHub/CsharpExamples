using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_05_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Tap> tapsList = new List<Tap>();
        /// <summary>
        /// Timer每间隔interval中设置的时间，进入执行一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //1.从设备获取数据（使用随机数类模拟）
            Random random = new Random();

            double temp = Math.Round(random.NextDouble() * 100, 2);
            double pressure = Math.Round(random.NextDouble() * 500,2);

            //2.创建tap类的实体对象
            Tap tap = new Tap()
            {   Id = tapsList.Count()-1 < 0 ? 1: tapsList[tapsList.Count-1].Id + 1,
                CurrentTime = DateTime.Now.ToString("HH::mm::ss"),
                Temperature = temp, Pressure = pressure
            };
            tapsList.Add(tap);
            if(tapsList.Count() > 100) { tapsList.RemoveAt(0); }

            chartDisplay.DataBind();   // 更新了数据源


            var tempList = tapsList.ToArray().Reverse().ToList();
            dgvDisplay.DataSource = new BindingSource(tempList, null);


            Tap maxTemp = tempList[0];
            Tap minTemp = tempList[0];
            Tap maxPressure = tempList[0];
            Tap minPressure = tempList[0];



            //设置报警单元格字体颜色
            for (int i = 0; i< tempList.Count();  i++)
            {
                dgvDisplay.Rows[i].Cells[4].Style.ForeColor = tempList[i].TempAlarm == "Normal" ?
                    Color.Green : Color.Red;


                dgvDisplay.Rows[i].Cells[5].Style.ForeColor = tempList[i].PressureAlarm == "Normal" ?
                    Color.Green : Color.Red;


                //更新最大值最小值
                
                if (tempList[i].Temperature >= maxTemp.Temperature)
                {
                    maxTemp = tempList[i];
                    txtMaxTemp.Tag = i;
                    
                }

                if (tempList[i].Temperature <= minTemp.Temperature)
                {
                    minTemp = tempList[i];
                    txtMinTemp.Tag = i;
                    
                }

                if (tempList[i].Pressure >= maxTemp.Pressure)
                {
                    maxPressure = tempList[i];
                    txtMaxPressure.Tag = i;
                    
                }

                if (tempList[i].Pressure <= maxTemp.Pressure)
                {
                    minPressure = tempList[i];
                    txtMinPressure.Tag = i;
                    
                }


                txtMaxTemp.Text = maxTemp.Temperature.ToString();
                txtMinTemp.Text = minTemp.Temperature.ToString();
                txtMaxPressure.Text = maxPressure.Pressure.ToString();
                txtMinPressure.Text = minPressure.Pressure.ToString();
            }

            //
            chartDisplay.ChartAreas[0].AxisX.ScaleView.Scroll(System.Windows.Forms.DataVisualization.Charting.ScrollType.Last);


        }

        /// <summary>
        /// 开始采集&停止采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(btnStart.Text == "开始采集")
            {   
                timer1.Start(); //相当于timer.Enable = True

                btnStart.Text = "停止采集";
                btnStart.BackColor = Color.Red;
            }
            else
            {   
                timer1.Stop();
                btnStart.Text = "开始采集";
                btnStart.BackColor = Color.FromArgb(192, 255, 192);
            }
        }


        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            chartDisplay.DataSource = tapsList; // 绑定数据源
            chartDisplay.Series[0].XValueMember = "CurrentTime";
            chartDisplay.Series[0].YValueMembers = "Temperature";

            chartDisplay.Series[1].XValueMember = "CurrentTime";
            chartDisplay.Series[1].YValueMembers = "Pressure";

            nudSetTempUpperLimit.Value = 90;
            nudSetTempLowerLimit.Value = 10;
            nudSetPressureUpperLimit.Value = 400;
            nudSetPressureLowerLimit.Value = 50;
            Tap.TPLimitValue.TempUpperLimit = (double)nudSetTempUpperLimit.Value;
            Tap.TPLimitValue.TempLowerLimit = (double)nudSetTempLowerLimit.Value;
            Tap.TPLimitValue.PressureUpperLimit = (double)nudSetPressureUpperLimit.Value;
            Tap.TPLimitValue.PressureLowerLimit = (double)nudSetPressureLowerLimit.Value;

            dgvDisplay.DataSource = new BindingSource(tapsList, null);
            

        }

        private void nudAcqTime_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)nudAcqTime.Value;
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            chartDisplay.Series["TempSeries"].Enabled = true;
            chartDisplay.Series["PressureSeries"].Enabled = true;
        }

        private void btnDisplayTemperature_Click(object sender, EventArgs e)
        {
            chartDisplay.Series["TempSeries"].Enabled = true;
            chartDisplay.Series["PressureSeries"].Enabled = false;
        }

        private void btnDisplayPressure_Click(object sender, EventArgs e)
        {
            chartDisplay.Series["TempSeries"].Enabled = false;
            chartDisplay.Series["PressureSeries"].Enabled = true;
        }

        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            using (Bitmap bmp = new Bitmap(chartDisplay.Width, chartDisplay.Height))
            {
               
                string FileName = DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + ".bmp";
               
                chartDisplay.SaveImage(FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp);
            }
        }

        private void nudSetTempUpperLimit_ValueChanged(object sender, EventArgs e)
        {
            Tap.TPLimitValue.TempUpperLimit = (double)nudSetTempUpperLimit.Value;
        }

        private void nudSetTempLowerLimit_ValueChanged(object sender, EventArgs e)
        {
            Tap.TPLimitValue.TempLowerLimit = (double)nudSetTempLowerLimit.Value;
        }

        private void nudSetPressureUpperLimit_ValueChanged(object sender, EventArgs e)
        {
            Tap.TPLimitValue.PressureUpperLimit = (double)nudSetPressureUpperLimit.Value;
        }

        private void nudSetPressureLowerLimit_ValueChanged(object sender, EventArgs e)
        {
            Tap.TPLimitValue.PressureLowerLimit = (double)nudSetPressureLowerLimit.Value;
        }


        /// <summary>
        /// txt双击事件 跳转到最大值最小值的行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGetMinMax_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                dgvDisplay.Rows[(int)textBox.Tag].Selected = true;
                //滚动条跟随
                dgvDisplay.FirstDisplayedScrollingRowIndex = (int)textBox.Tag;
                
            }
            catch (Exception)
            {

                
            }

            
        }
    }
}
