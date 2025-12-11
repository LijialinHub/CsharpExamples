using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_01
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd frmAdd = new frmAdd(this);
            frmAdd.ShowDialog();
            

        }

        /// <summary>
        /// 修改选中成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifySelect_Click(object sender, EventArgs e)
        {
            if(listBoxDisplay.SelectedIndex == -1) { return; } //未选中
            frmModify frmModify = new frmModify(listBoxDisplay.SelectedIndex, this);
            frmModify.ShowDialog();

        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {

            XmlFileAccess xmlFileAccess = new XmlFileAccess();
            bool isOk  = xmlFileAccess.ReadXmlFile(out AppData.EmployeesList, out string res);
            if (!isOk) { MessageBox.Show(res, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            ////如果控件有DataSource属性，那么控件会自动绑定数据源
            ////例如List、Bind、DataTable....
            listBoxDisplay.DisplayMember = "UiDisplayData";
            listBoxDisplay.DataSource = AppData.EmployeesList;

        }



        /// <summary>
        /// 更新listBox控件的显示
        /// </summary>
        public void UpDataListBoxDisplay()
        {
            ////如果控件有DataSource属性，那么控件会自动绑定数据源
            ////例如List、Bind、DataTable....
            //listBoxDisplay.DataSource = null; //先断开再重新绑定
            //listBoxDisplay.DisplayMember = "UiDisplayData";
            //listBoxDisplay.DataSource = AppData.EmployeesList;

            listBoxDisplay.DisplayMember = "UiDisplayData";
            listBoxDisplay.DataSource = new BindingSource(AppData.EmployeesList, null);
           
        }


        /// <summary>
        /// 显示选中成员的详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxDisplay_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //获取选中项 未选中时返回-1
                int selectedIndex = listBoxDisplay.SelectedIndex;
                string str = $"工号:{AppData.EmployeesList[selectedIndex].Id}\r\n" +
                                    $"姓名:{AppData.EmployeesList[selectedIndex].Name}\r\n" +
                                    $"性别:{AppData.EmployeesList[selectedIndex].Sex}\r\n" +
                                    $"年龄:{AppData.EmployeesList[selectedIndex].Age}\r\n" +
                                    $"工资:{AppData.EmployeesList[selectedIndex].Salary}\r\n" +
                                    $"入职日期:{AppData.EmployeesList[selectedIndex].DateOfJoining}\r\n" +
                                    $"职位:{AppData.EmployeesList[selectedIndex].Position}\r\n";

                MessageBox.Show(str, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                
            }

        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {

            try
            {
                int selectIndex = listBoxDisplay.SelectedIndex;
                //if(selectIndex <= 0) { return; }

                //先插入再删除
                AppData.EmployeesList.Insert(selectIndex - 1, AppData.EmployeesList[selectIndex]);
                AppData.EmployeesList.RemoveAt(selectIndex + 1);
                UpDataListBoxDisplay();
                listBoxDisplay.SelectedIndex = selectIndex - 1;
            }
            catch (Exception)
            {
            }

        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {

            try
            {
                int selectIndex = listBoxDisplay.SelectedIndex;
                //if (selectIndex == AppData.EmployeesList.Count()-1 || selectIndex < 0) { return; }
                //先插入再删除
                AppData.EmployeesList.Insert(selectIndex + 2, AppData.EmployeesList[selectIndex]);
                AppData.EmployeesList.RemoveAt(selectIndex);
                UpDataListBoxDisplay();
                listBoxDisplay.SelectedIndex = selectIndex + 1;
            }
            catch (Exception)
            {
               
            }
        }

        private void btnDelSelect_Click(object sender, EventArgs e)
        {
            try
            {
                //删除选中成员
                AppData.EmployeesList.RemoveAt(listBoxDisplay.SelectedIndex);
                UpDataListBoxDisplay();
                //序列化
                XmlFileAccess xmlFileAccess = new XmlFileAccess();
                bool isOk = xmlFileAccess.SaveToXml(AppData.EmployeesList, out string res);
            }
            catch (Exception)
            {
            }
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            try
            {
                AppData.EmployeesList.Clear();
                UpDataListBoxDisplay();
                //序列化
                XmlFileAccess xmlFileAccess = new XmlFileAccess();
                bool isOk = xmlFileAccess.SaveToXml(AppData.EmployeesList, out string res);
            }
            catch (Exception)
            {
            }
        }
    }
}
