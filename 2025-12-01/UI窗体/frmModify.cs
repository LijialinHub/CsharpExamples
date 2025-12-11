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
    public partial class frmModify : Form
    {
        

        public frmModify()
        {
            InitializeComponent();
        }




        private int selectedIndex;
        private frmMain frmMain;
        public frmModify(int selectedIndex, frmMain frmMain)
        {
            this.frmMain = frmMain;
            this.selectedIndex = selectedIndex;
            InitializeComponent();
        }


        private void frmModify_Load(object sender, EventArgs e)
        {
            //cmbPosition.Items.AddRange(Enum.GetNames(typeof(Position)));
            cmbPosition.DataSource = Enum.GetNames(typeof(Position));
            cmbPosition.SelectedIndex = 0;

            //
            txtId.Text = AppData.EmployeesList[selectedIndex].Id;
            txtName.Text = AppData.EmployeesList[selectedIndex].Name;
            radMan.Checked = AppData.EmployeesList[selectedIndex].Sex == Sex.Man;
            radWoMan.Checked = AppData.EmployeesList[selectedIndex].Sex == Sex.Woman;
            nudAge.Value = AppData.EmployeesList[selectedIndex].Age;
            nudSalary.Value = (decimal)AppData.EmployeesList[selectedIndex].Salary;
            dtpDate.Text = AppData.EmployeesList[selectedIndex].DateOfJoining;
            cmbPosition.Text = AppData.EmployeesList[selectedIndex].Position.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {   
            //1. 非空检测
            if (CheckIsEmpty()) {  return; }

            //2. 将修改后的结果写入到集合的选中对象
            AppData.EmployeesList[selectedIndex].Sex = radMan.Checked? Sex.Man: Sex.Woman;
            AppData.EmployeesList[selectedIndex].Age = (int)nudAge.Value;
            AppData.EmployeesList[selectedIndex].DateOfJoining = dtpDate.Text;
            AppData.EmployeesList[selectedIndex].Position = (Position)Enum.Parse(typeof(Position), cmbPosition.Text);
            AppData.EmployeesList[selectedIndex].Salary = (double)nudSalary.Value;

            //3. 序列化
            XmlFileAccess xmlFileAccess = new XmlFileAccess();
            if (xmlFileAccess.SaveToXml(AppData.EmployeesList, out string res))
            {

                frmMain.UpDataListBoxDisplay();

                MessageBox.Show(res, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }


        /// <summary>
        /// 非空检测 
        /// </summary>
        /// <returns>true:空 false:非空</returns>
        private bool CheckIsEmpty()
        {

            if (String.IsNullOrWhiteSpace(txtId.Text))
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

            if (Regex.IsMatch(txtName.Text, @"[\d\s]"))
            {
                errorProvider1.SetError(txtName, "姓名不能有数字或空格!");
                txtId.Focus();
                return true;
            }

            return false;
        }




    }
}
