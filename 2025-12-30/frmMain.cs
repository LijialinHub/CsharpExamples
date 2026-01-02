using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;
using Microsoft.VisualBasic;

namespace _2025_12_30
{
    public partial class frmMain : Form
    {   
        /// <summary>
        /// 数据处理业务逻辑对象
        /// </summary>
        private DataHandleBLL dataHandleBLL = new DataHandleBLL();

        /// <summary>
        /// 绘图业务逻辑对象
        /// </summary>
        private DrawHandleBLL drawHandleBLL;

        /// <summary>
        /// 加工坐标点集合(来自数据库)
        /// </summary>
        private BindingList<ProcessCoordEntity> processCoordEntities = new BindingList<ProcessCoordEntity>();

        /// <summary>
        /// 表名集合
        /// </summary>
        private BindingList<string> tableNames = new BindingList<string>();

        /// <summary>
        /// 绘图参数(来自Ini文件)
        /// </summary>
        public static DrawParamsEntity DrawParams = new DrawParamsEntity();

        public frmMain()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            //从Ini文件读取绘图参数
            dataHandleBLL.ReadDrawParamFromIni(DrawParams);

            //表名集合绑定cmbProductName控件
            cmbProductName.DataSource = tableNames;

            //加工坐标点集合绑定dgvDisplay控件
            dgvDisplay.AutoGenerateColumns = false;  //不自动创建列 按照指定的来
            dgvDisplay.DataSource = processCoordEntities;

            drawHandleBLL = new DrawHandleBLL(picTrackDisplay);
            drawHandleBLL.CoordinatesReset();
        }


        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //保存绘图参数到Ini文件
            dataHandleBLL.SaveDrawParamToIni(DrawParams);
        }


        /// <summary>
        /// 打开Access数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择一个Accesss数据库";
            openFileDialog.Filter = "Access数据库|*.mdb|Access数据库|*.accdb";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                dataHandleBLL.OpenDataBase(path);

                if(dataHandleBLL.GetTableNames(tableNames, out string res1))
                {
                    if(tableNames.Count > 0)
                    {
                        dataHandleBLL.GetTableData(cmbProductName.Text, processCoordEntities, out string res);
                        DisplayCurrentCoord();
                    }
                }

                tsslDbName.Text = Path.GetFileName(path);
                panel2.Enabled = true;
            }
        }

        /// <summary>
        /// 切换表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataHandleBLL.GetTableData(cmbProductName.Text, processCoordEntities, out string res);
            if(processCoordEntities.Count > 0)
            {
                DisplayCurrentCoord();
            }
            else
            {
                DisplayCurrentCoord(true);
            }
            
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accessToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string dbName= Interaction.InputBox("输入Access数据库的名字","输入框",
                                                $"加工轨迹_{DateAndTime.Now.ToString("MM月dd日")}.mdb",100, 100);

            if(string.IsNullOrWhiteSpace(dbName)) { return; }

            string path = Environment.CurrentDirectory + $@"\{dbName}";

            bool isOk = dataHandleBLL.CreateDataBase(path, out string res);

            tsslExecuteResult.ForeColor = isOk? Color.Green: Color.Red;
            tsslExecuteResult.Text = res;

            if (isOk) 
            {
                panel2.Enabled = true;
                tsslDbName.Text = dbName;
            }
            else
            {
                panel2.Enabled = false;
            }
        }


        /// <summary>
        /// 键盘按键按下创建表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                DialogResult dialogResult = MessageBox.Show("是否创建表格?","消息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes) 
                {
                    bool isOk = dataHandleBLL.CreateTable(cmbProductName.Text, tableNames, out string res);
                    
                    tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
                    tsslExecuteResult.Text = res;

                    if (isOk) 
                    {
                        cmbProductName.SelectedItem = cmbProductName.Text;  //选中创建的表格
                        DisplayCurrentCoord(true);
                    }
                    
                }
            }
        }


        /// <summary>
        /// 删除表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否删除表格?", "消息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool isOk = dataHandleBLL.DeleteTable(cmbProductName.Text, tableNames, out string res);

                tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteResult.Text = res;

                if (isOk)
                {
                    if(cmbProductName.Items.Count > 0)
                    {
                        cmbProductName.SelectedIndex = 0;
                    }
                    else//没有表
                    {
                        cmbProductName.Text = "";
                    }

                    if (processCoordEntities.Count > 0)
                    {
                        DisplayCurrentCoord();
                    }
                    else
                    {
                        DisplayCurrentCoord(true);
                    }
                }

            }
        }

        /// <summary>
        /// 选中单元格触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DisplayCurrentCoord();
        }

        /// <summary>
        /// 显示当前选中的坐标
        /// </summary>
        private void DisplayCurrentCoord(bool isClear = false)
        {
            try
            {
                if(isClear)
                {
                    txtId.Clear();
                    txtXAxis.Clear();
                    txtYAxis.Clear();
                    txtZAxis.Clear();
                    return;
                }

                txtId.Text = dgvDisplay.SelectedRows[0].Cells[0].Value.ToString();
                txtXAxis.Text = dgvDisplay.SelectedRows[0].Cells[1].Value.ToString();
                txtYAxis.Text = dgvDisplay.SelectedRows[0].Cells[2].Value.ToString();
                txtZAxis.Text = dgvDisplay.SelectedRows[0].Cells[3].Value.ToString();


            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessCoordEntity processCoordEntity = new ProcessCoordEntity()
                {
                    XPosition = double.Parse(txtXAxis.Text),
                    YPosition = double.Parse(txtYAxis.Text),
                    ZPosition = double.Parse(txtZAxis.Text),
                    //Num = int.Parse(txtId.Text)

                };

                bool isOk = dataHandleBLL.AddRecord(cmbProductName.Text, tableNames, processCoordEntity, out string res);

                dataHandleBLL.GetTableData(cmbProductName.Text, processCoordEntities, out string res2);

                if (isOk)
                {
                    dgvDisplay.Rows[dgvDisplay.Rows.Count - 1].Selected = true;
                    DisplayCurrentCoord();
                }

                tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteResult.Text = res;

            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertRecord_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessCoordEntity processCoordEntity = new ProcessCoordEntity()
                {
                    Num = int.Parse(txtId.Text),
                    XPosition = double.Parse(txtXAxis.Text),
                    YPosition = double.Parse(txtYAxis.Text),
                    ZPosition = double.Parse(txtZAxis.Text)
                };


                bool isOk = dataHandleBLL.InsertRecord(cmbProductName.Text, tableNames ,processCoordEntity, out string res);

                dataHandleBLL.GetTableData(cmbProductName.Text, processCoordEntities, out string res2);

                tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteResult.Text = res;

                if(isOk)
                {
                    int index = 0;
                    index = dgvDisplay.Rows.Cast<DataGridViewRow>(). //Ienumerable<DataGridViewRow>
                            Where(dR => dR.Cells[0].Value.ToString() == processCoordEntity.Num.ToString()).
                            FirstOrDefault()?.Index ?? 0;  //集合中的第一个或者默认值null

                    dgvDisplay.Rows[index].Selected = true;
                    DisplayCurrentCoord();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyRecord_Click(object sender, EventArgs e)
        {

            try
            {

                int num = int.Parse(txtId.Text);

                ProcessCoordEntity processCoordEntity = new ProcessCoordEntity()
                {
                    XPosition = double.Parse(txtXAxis.Text),
                    YPosition = double.Parse(txtYAxis.Text),
                    ZPosition = double.Parse(txtZAxis.Text),
                };

                bool isOk = dataHandleBLL.ModifyRecord(cmbProductName.Text, tableNames, num, processCoordEntity, out string res);

                dataHandleBLL.GetTableData(cmbProductName.Text, processCoordEntities, out string res1);

                tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteResult.Text = res;
                if (isOk) 
                {
                    dgvDisplay.Rows[num-1].Selected = true;
                    DisplayCurrentCoord();
                }


            }
            catch (Exception)
            {

                throw;
            }



        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveRecord_Click(object sender, EventArgs e)
        {
            try
            {

                int num = int.Parse(dgvDisplay.SelectedRows[0].Cells[0].Value.ToString());

              
                bool isOk = dataHandleBLL.DeleteRecord(cmbProductName.Text, tableNames, num, out string res);

                dataHandleBLL.GetTableData(cmbProductName.Text, processCoordEntities, out string res1);

                tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteResult.Text = res;
                if (isOk)
                {
                   if(dgvDisplay.Rows.Count > 0)
                    {
                        dgvDisplay.Rows[0].Selected = true;
                        DisplayCurrentCoord();
                    }
                    else
                    {
                        DisplayCurrentCoord(true);
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 删除所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                bool isOk = dataHandleBLL.DeleteAllRecord(cmbProductName.Text, tableNames, out string res);
                dataHandleBLL.GetTableData(cmbProductName.Text, processCoordEntities, out string res1);

                tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteResult.Text = res;

                DisplayCurrentCoord(true);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void 绘图参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrawParams frmDrawParams = new frmDrawParams();
            frmDrawParams.Show();
        }

        /// <summary>
        /// 数据点显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnShowDataPoint_Click(object sender, EventArgs e)
        {

            drawHandleBLL.CoordinatesReset();
            await drawHandleBLL.DisplayDataPointsAsync(Brushes.Red, processCoordEntities, DrawParams);

           
        }

        /// <summary>
        /// 开始加工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnStart_Click(object sender, EventArgs e)
        {
            drawHandleBLL.CoordinatesReset();
            await drawHandleBLL.DrawTrackAsync(new Pen(Color.Red, 2), processCoordEntities, DrawParams);

            MessageBox.Show("绘制结束！");
        }
    }
}
