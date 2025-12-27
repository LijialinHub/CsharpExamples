using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace _2025_11_27
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            //日期事件类:DateTime
            int year = DateTime.Now.Year;
            cmbYear.Items.Add("");
            for (int i = year ; i >= year - 60; i--)
            {
                cmbYear.Items.Add(i+ "年");
            }

            cmbMonth.Items.Add("");
            for (int i = 1; i<=12;i++)
            {
                cmbMonth.Items.Add(i + "月");
            }

            cmbDay.Items.Add("");
            for (int i = 1;i<=31;i++)
            {
                cmbDay.Items.Add(i + "日");
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //1.非空检测
            if(IsCheckEmpty()) return;

            //2.整理数据
            string name = txtName.Text.Trim();
            string birthYear = cmbYear.Text;
            string birthMonth = cmbMonth.Text;
            string birthDay = cmbDay.Text;
            string score = txtScore.Text.Trim();
            string sex  = rabMan.Checked ? "男" : "女";
            string hobby = "";

            foreach (Control item in tlpHobbies.Controls)
            {
                if(item is CheckBox chk)
                {
                    hobby += chk.Checked? chk.Text + ",": "";
                }
            }

            hobby = hobby.Length!=0? hobby.Substring(0,hobby.Length-1): "无";

            //登记
            string path = Environment.CurrentDirectory + @"\学员信息.txt";
            string contend = $"姓名：{name} \r\n出生日期: {birthYear}{birthMonth}{birthDay} \r\n性别：{sex} \r\n兴趣爱好: {hobby}\r\n";
                           
            //打开一个文件 然后像其中追加指定字符串，然后关闭文件
            //如图文件不存在。此方法将创建一个文件，将指定的字符串写入文件中，然后关闭文件

            File.AppendAllText(path, contend);

            MessageBox.Show("登记成功","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearInputControl();


        }

        /// <summary>
        /// 清空空间
        /// </summary>
        private void ClearInputControl()
        {
            foreach (Control item in tlpBaseInfo.Controls)
            {
                (item as TextBox)?.Clear();
                if(item is ComboBox cmb)
                {
                    cmb.SelectedIndex = 0;
                }
            }


            foreach (var item in tlpHobbies.Controls)
            {
                if(item is CheckBox chk)
                {
                    chk.Checked = false;
                }    
            }

        }






        /// <summary>
        /// 非空检测
        /// </summary>
        /// <returns>true：检测为空</returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool IsCheckEmpty()
        {
            foreach (Control item in tlpBaseInfo.Controls)
            {
                if(string.IsNullOrWhiteSpace(item.Text))
                {
                    MessageBox.Show($"{item.Tag}未输入", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    item.Focus(); //为控件设置输入焦点
                    
                    return true;
                    
                }
            }
            return false;
        }

        /// <summary>
        /// 文本改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtScore_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double score = double.Parse(txtScore.Text);
                if (score >= 0 && score <= 100)
                {
                    errorProvider1.SetError(txtScore, null);
                }
                else
                {
                    throw new Exception("请输入0-100的数字");
                }

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txtScore, ex.Message);
            }

        }




    }
}
