using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_01
{
    public partial class frmAdd : Form
    {
        public frmAdd()
        {
            InitializeComponent();
        }

        private frmMain frmMain;
        public frmAdd(frmMain frmMain)
        {
            this.frmMain = frmMain;
            InitializeComponent();
        }



        private void frmM_Load(object sender, EventArgs e)
        {
            //string[] positions = Enum.GetNames(typeof(Position));
            //cmbPosition.Items.AddRange(positions);
            //cmbPosition.SelectedIndex = 0;

            cmbPosition.DataSource = Enum.GetNames(typeof(Position));
            cmbPosition.SelectedIndex = 0;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {   
            //1. 检测
            if(CheckIsEmpty()) { return; }

            //2. 整理数据
            string id = txtId.Text.Trim();
            string name = txtName.Text.Trim();
            Sex sex = radMan.Checked ? Sex.Man : Sex.Woman;
            string dateOfJoining = dtpDate.Text;
            Position position = (Position)Enum.Parse(typeof(Position), cmbPosition.Text );
            int age = (int)nudAge.Value ;
            double salary = (double)nudSalary.Value ;

            //3. 创建实例对象
            Employee employee = new Employee()
            {
                Id = id, Name = name,
                Sex = sex, DateOfJoining = dateOfJoining,
                Position = position,  Age = age,
                Salary = salary
            };

            //4. 向集合添加对象
            AppData.EmployeesList.Add(employee);  
            //5. 写入到xml文件
            XmlFileAccess xmlFileAccess = new XmlFileAccess();
            if(xmlFileAccess.SaveToXml(AppData.EmployeesList, out string res))
            {

                ResetDisplay();
                //UpDataListBoxDisplay();
                frmMain.UpDataListBoxDisplay();

                MessageBox.Show(res, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        /// <summary>
        /// 复位显示控件
        /// </summary>
        private void ResetDisplay()
        {
            txtId.Clear();
            txtName.Clear();
            radMan.Checked = true;
            nudAge.Value = nudAge.Minimum;
            nudSalary.Value = nudSalary.Minimum;
            dtpDate.Value = DateTime.Now;
            cmbPosition.SelectedIndex = 0;
        }

        /// <summary>
        /// 非空检测 
        /// </summary>
        /// <returns>true:空 false:非空</returns>
        private bool CheckIsEmpty()
        {
            
            if(String.IsNullOrWhiteSpace(txtId.Text)) 
            {
                errorProvider1.SetError(txtId, "工号不能为空！");
                txtId.Focus();
                return true;
            }
            
            if (String.IsNullOrWhiteSpace(txtName.Text)) 
            { 
                errorProvider1.SetError(txtName, "姓名不能为空!");
                txtId.Focus();
                return true;
            }

            if(Regex.IsMatch(txtName.Text, @"[\d\s]"))
            {
                errorProvider1.SetError(txtName, "姓名不能有数字或空格!");
                txtId.Focus();
                return true;
            }

            return false;
        }



        private void txt_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(textBox, null); //取消异常提示
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); //关闭窗体
        }
    }
}
