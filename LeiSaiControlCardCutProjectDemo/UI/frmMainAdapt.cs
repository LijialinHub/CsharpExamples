using BLL;
using Entity;
using Microsoft.VisualBasic;
using Sunny.UI;
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

namespace LeiSaiControlCardCutProjectDemo
{
    public partial class frmMainAdapt : UIForm
    {

        #region 字段和属性

        #region  业务逻辑

        /// <summary>
        /// 数据处理业务逻辑对象
        /// </summary>
        private DataHandleBLL dataHandleBLL = new DataHandleBLL();

        /// <summary>
        /// 绘图业务逻辑对象
        /// </summary>
        private DrawHandleBLL drawHandleBLL;

        /// <summary>
        /// 运动处理业务逻辑对象
        /// </summary>
        private MotionHandleBLL motionHandleBLL = new MotionHandleBLL();

        /// <summary>
        /// 工艺流程业务逻辑对象
        /// </summary>
        private ProcessFlowBLL processFlowBLL = new ProcessFlowBLL();



        #endregion

        #region 实体

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
        public static DrawParamsEntity DrawParamsEntity = new DrawParamsEntity();


        //轴实体
        public Axis X_Axis = new Axis() { Axis_CardNo = 0, Axis_Num = 0, Axis_Name = "X轴" };
        public Axis Y_Axis = new Axis() { Axis_CardNo = 0, Axis_Num = 3, Axis_Name = "Y轴" };
        public Axis Z_Axis = new Axis() { Axis_CardNo = 0, Axis_Num = 2, Axis_Name = "Z轴" };

        /// <summary>
        /// IO工艺实体
        /// </summary>
        public IOCraftEntity IOCraftEntity = new IOCraftEntity();

        #endregion

        #endregion



        public frmMainAdapt()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMainAdapt_Load(object sender, EventArgs e)
        {
            if (motionHandleBLL.OpenCard(out string res))
            {
                MessageBox.Show(res, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //从Ini文件读取绘图参数
                dataHandleBLL.ReadDrawParamFromIni(DrawParamsEntity);

                dataHandleBLL.ReadAxisDataFromIni(X_Axis);
                dataHandleBLL.ReadAxisDataFromIni(Y_Axis);
                dataHandleBLL.ReadAxisDataFromIni(Z_Axis);
                dataHandleBLL.ReadIOCraftEntityFromIni(IOCraftEntity);


                //表名集合绑定cmbProductName控件
                cmbProductName.DataSource = tableNames;

                //加工坐标点集合绑定dgvDisplay控件
                dgvDisplay.AutoGenerateColumns = false;  //不自动创建列 按照指定的来
                dgvDisplay.DataSource = processCoordEntities;

                drawHandleBLL = new DrawHandleBLL(picDisplay);
                drawHandleBLL.CoordinatesReset();

                radGroupGoHomeMode.SelectedIndex = 1;
                radGroupGoHomeSpeedSelect.SelectedIndex = 1;
                radGroupAutoSelect.SelectedIndex = 1;

                cmbSelectPos.DisplayMember = "Num";
                cmbSelectPos.DataSource = processCoordEntities;

                //控制卡信号
                motionHandleBLL.RealTimeReadAxisData(IOCraftEntity, X_Axis, Y_Axis, Z_Axis);

                //自动工艺流程相关数据
                processFlowBLL.processCoordEntities = processCoordEntities;
                processFlowBLL.AxisList = new List<Axis>() { X_Axis, Y_Axis, Z_Axis };
                processFlowBLL.iOCraftEntity = IOCraftEntity;

                processFlowBLL.drawHandleBLL = drawHandleBLL;
                processFlowBLL.drawParamsEntity = DrawParamsEntity;

                processFlowBLL.UiDoSomething -= processFlowBLL_UiDoSomething;
                processFlowBLL.UiDoSomething += processFlowBLL_UiDoSomething;

            }
            else
            {
                MessageBox.Show(res, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //Environment.Exit(0);
            }

        }

        private void processFlowBLL_UiDoSomething(int num)
        {

            this.Invoke(new Action(() =>
            {
                dgvDisplay.Rows[num].Selected = true;
            }));
        }

        /// <summary>
        /// 急停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEms_Click(object sender, EventArgs e)
        {
            if (!btnEms.Selected)
            {
                processFlowBLL.PressEmg();
                btnEms.Selected = true;
            }
            else
            {
                processFlowBLL.LoosenEmg();
                btnEms.Selected = false;
            }
        }


        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void frmMainAdapt_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataHandleBLL.SaveDrawParamToIni(DrawParamsEntity);
            dataHandleBLL.WriteIOCraftEntityToIni(IOCraftEntity);

            await motionHandleBLL.StopRealTimeRead();  //停止实时读取
            motionHandleBLL.CloseCard();  //关闭控制卡

            Environment.Exit(0);
        }

        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 打开数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAxisParamsSet frmAxisParamsSet = new frmAxisParamsSet(X_Axis, Y_Axis, Z_Axis);
            frmAxisParamsSet.Show();
        }

        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 创建数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择一个数据库";
            ofd.Filter = "数据库|*.mdb|数据库|*.accdb";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tlpDatabaseOP.Enabled = true;
                string path = ofd.FileName;
                dataHandleBLL.OpenDataBase(path);
                tsslDataBaseName.Text = Path.GetFileName(path);

                if (dataHandleBLL.GetTableNames(tableNames, out string res))
                {
                    tsslDataBaseName.Text = Path.GetFileName(path);
                    tsslExecuteInfo.Text = res;

                    if (tableNames.Count > 0)
                    {
                        cmbProductName.SelectedIndex = 0;
                        dataHandleBLL.GetTableData(cmbProductName.Text, processCoordEntities, out res);
                    }

                }
            }
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 创建数据库ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string dbName = Interaction.InputBox("输入Access数据库的名字", "输入框",
                                                $"加工轨迹_{DateAndTime.Now.ToString("MM月dd日")}.mdb", 100, 100);

            if (string.IsNullOrWhiteSpace(dbName)) { return; }

            string path = Environment.CurrentDirectory + $@"\{dbName}";

            bool isOk = dataHandleBLL.CreateDataBase(path, out string res);

            tsslExecuteInfo.ForeColor = isOk ? Color.Green : Color.Red;
            tsslExecuteInfo.Text = res;

            tsslDataBaseName.Text = dbName;
        }

        /// <summary>
        /// 绘图参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDrawParams frmDrawParams = new frmDrawParams();
            frmDrawParams.Show();
        }

        /// <summary>
        /// 切换表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataHandleBLL.GetTableData(cmbProductName.Text, processCoordEntities, out string res);
        }

        /// <summary>
        /// 删除表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelProduct_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否删除表格?", "消息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool isOk = dataHandleBLL.DeleteTable(cmbProductName.Text, tableNames, out string res);

                tsslExecuteInfo.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteInfo.Text = res;

                if (isOk)
                {
                    if (tableNames.Count > 0)
                    {
                        cmbProductName.SelectedIndex = 0;
                    }
                    else//没有表
                    {
                        cmbProductName.Text = "";
                    }
                }

            }
        }

        /// <summary>
        /// 微动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMicroMove_Click(object sender, EventArgs e)
        {
            if (!chkMicroMove.Checked) { return; }  //微动模式
            UIButton button = sender as UIButton;
            double dist = double.Parse(cmbMicroDist.Text);

            switch (button.Text)
            {
                case "向左": motionHandleBLL.MicroMove(X_Axis, Math.Abs(dist), 0.5); break;
                case "向右": motionHandleBLL.MicroMove(X_Axis, -Math.Abs(dist), 0.5); break;

                case "后退": motionHandleBLL.MicroMove(Y_Axis, -Math.Abs(dist), 0.5); break;
                case "前进": motionHandleBLL.MicroMove(Y_Axis, Math.Abs(dist), 0.5); break;

                case "上升": motionHandleBLL.MicroMove(Z_Axis, -Math.Abs(dist), 0.5); break;
                case "下降": motionHandleBLL.MicroMove(Z_Axis, Math.Abs(dist), 0.5); break;
            }
        }

        /// <summary>
        /// 点动运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJogRun_MouseDown(object sender, MouseEventArgs e)
        {
            if (chkMicroMove.Checked) { return; }  //微动互锁
            UIButton button = sender as UIButton;
            bool highorlow = radHighSpeed.Checked;
            string res = "";
            switch (button.Text)
            {
                case "向左": motionHandleBLL.JogLeftMove(X_Axis, highorlow, out res); break;
                case "向右": motionHandleBLL.JogRightMove(X_Axis, highorlow, out res); break;

                case "后退": motionHandleBLL.JogBackAwayMove(Y_Axis, highorlow, out res); break;
                case "前进": motionHandleBLL.JogForwardMove(Y_Axis, highorlow, out res); break;

                case "上升": motionHandleBLL.JogUpMove(Z_Axis, highorlow, out res); break;
                case "下降": motionHandleBLL.JogDownMove(Z_Axis, highorlow, out res); break;
            }
            tsslExecuteInfo.Text = res;
        }

        /// <summary>
        /// 点动停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJogRun_MouseUp(object sender, MouseEventArgs e)
        {
            if (chkMicroMove.Checked) { return; }  //微动互锁
            UIButton button = sender as UIButton;
            string res = "";
            switch (button.Text)
            {
                case "向左":
                case "向右": motionHandleBLL.AxisStop(X_Axis, out res); break;

                case "后退":
                case "前进": motionHandleBLL.AxisStop(Y_Axis, out res); break;

                case "上升":
                case "下降": motionHandleBLL.AxisStop(Z_Axis, out res); break;
            }
            tsslExecuteInfo.Text = res;
        }

        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRecord_Click(object sender, EventArgs e)

        {
            try
            {

                if (!X_Axis.OverGoHomeMark || !Y_Axis.OverGoHomeMark || !Z_Axis.OverGoHomeMark)
                {
                    MessageBox.Show("回原点未完成！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                ProcessCoordEntity processCoordEntity = new ProcessCoordEntity()
                {
                    XPosition = lblPositionX.Value,
                    YPosition = lblPositionY.Value,
                    ZPosition = lblPositionZ.Value,
                };

                bool isOk = dataHandleBLL.AddRecord(cmbProductName.Text, tableNames, processCoordEntity, out string res);

                dataHandleBLL.GetTableData(cmbProductName.Text, processCoordEntities, out string res2);
                tsslExecuteInfo.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteInfo.Text = res;

                if (isOk)
                {
                    //选中最后一行
                    dgvDisplay.Rows[dgvDisplay.Rows.Count - 1].Selected = true;
                }

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

                if (!X_Axis.OverGoHomeMark || !Y_Axis.OverGoHomeMark || !Z_Axis.OverGoHomeMark)
                {
                    MessageBox.Show("回原点未完成！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int num = int.Parse(dgvDisplay.SelectedRows[0].Cells[0].Value.ToString());
                ProcessCoordEntity processCoordEntity = new ProcessCoordEntity()
                {
                    Num = num,
                    XPosition = lblPositionX.Value,
                    YPosition = lblPositionY.Value,
                    ZPosition = lblPositionZ.Value
                };


                bool isOk = dataHandleBLL.InsertRecord(cmbProductName.Text, tableNames, processCoordEntity, out string res);

                dataHandleBLL.GetTableData(cmbProductName.Text, processCoordEntities, out string res2);

                tsslExecuteInfo.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteInfo.Text = res;

                if (isOk)
                {
                    int index = 0;
                    index = dgvDisplay.Rows.Cast<DataGridViewRow>(). //Ienumerable<DataGridViewRow>
                            Where(dR => dR.Cells[0].Value.ToString() == processCoordEntity.Num.ToString()).
                            FirstOrDefault()?.Index ?? 0;  //集合中的第一个或者默认值null

                    dgvDisplay.Rows[index].Selected = true;
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
        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {

                int num = int.Parse(dgvDisplay.SelectedRows[0].Cells[0].Value.ToString());

                bool isOk = dataHandleBLL.DeleteRecord(cmbProductName.Text, tableNames, num, out string res);

                dataHandleBLL.GetTableData(cmbProductName.Text, processCoordEntities, out string res1);

                tsslExecuteInfo.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteInfo.Text = res;
                if (isOk)
                {
                    if (dgvDisplay.Rows.Count > 0)
                    {
                        dgvDisplay.Rows[0].Selected = true;

                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbSelectPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDisplay.Rows[cmbSelectPos.SelectedIndex].Selected = true;

            }
            catch (Exception)
            {


            }
        }

        /// <summary>
        /// 去指定点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoToDesPoint_Click(object sender, EventArgs e)
        {
            if (!X_Axis.OverGoHomeMark || !Y_Axis.OverGoHomeMark || !Z_Axis.OverGoHomeMark)
            {
                MessageBox.Show("回原点未完成！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSelectPos.Items.Count <= 0) { return; }


            int num = cmbSelectPos.SelectedIndex;
            double x = double.Parse(dgvDisplay.Rows[num].Cells[1].Value.ToString());
            double y = double.Parse(dgvDisplay.Rows[num].Cells[2].Value.ToString());
            double z = double.Parse(dgvDisplay.Rows[num].Cells[3].Value.ToString());

            motionHandleBLL.GoSpecifyPoint(new Axis[] { X_Axis, Y_Axis, Z_Axis },
                            new double[] { x, y, z });
        }

        /// <summary>
        /// 修改点坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyPosition_Click(object sender, EventArgs e)
        {
            if (!X_Axis.OverGoHomeMark || !Y_Axis.OverGoHomeMark || !Z_Axis.OverGoHomeMark)
            {
                MessageBox.Show("回原点未完成！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int rowIndex = dgvDisplay.SelectedRows[0].Index;  //获取行索引
                int num = int.Parse(dgvDisplay.SelectedRows[0].Cells[0].Value.ToString()); //获取编号

                ProcessCoordEntity processCoordEntity = new ProcessCoordEntity()
                {
                    XPosition = lblPositionX.Value,
                    YPosition = lblPositionY.Value,
                    ZPosition = lblPositionZ.Value,
                };

                bool isOk = dataHandleBLL.ModifyRecord(cmbProductName.Text, tableNames, num, processCoordEntity, out string res);

                dataHandleBLL.GetTableData(cmbProductName.Text, processCoordEntities, out string res1);

                tsslExecuteInfo.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteInfo.Text = res;

                if (isOk)
                {
                    dgvDisplay.Rows[num - 1].Selected = true;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 回原点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoHome_Click(object sender, EventArgs e)
        {
            if (chkXAxis.Checked)
            {
                motionHandleBLL.SelectAxisGoHome(X_Axis, (ushort)(radGroupGoHomeMode.SelectedIndex == 0 ? 0 : 2), 2, (ushort)(radGroupGoHomeSpeedSelect.SelectedIndex == 0 ? 0 : 1));
            }

            if (chkYAxis.Checked)
            {
                motionHandleBLL.SelectAxisGoHome(Y_Axis, (ushort)(radGroupGoHomeMode.SelectedIndex == 0 ? 0 : 2), 2, (ushort)(radGroupGoHomeSpeedSelect.SelectedIndex == 0 ? 0 : 1));
            }

            if (chkZAxis.Checked)
            {
                motionHandleBLL.SelectAxisGoHome(Z_Axis, (ushort)(radGroupGoHomeMode.SelectedIndex == 0 ? 0 : 2), 2, (ushort)(radGroupGoHomeSpeedSelect.SelectedIndex == 0 ? 0 : 1));
            }
        }

        /// <summary>
        /// 一键回原点
        /// </summary>
        private void btnOneKeyHome_Click(object sender, EventArgs e)
        {
            motionHandleBLL.AllGoHome(new Axis[] { X_Axis, Y_Axis, Z_Axis },
                                       (ushort)(radGroupGoHomeMode.SelectedIndex == 0 ? 0 : 2),
                                       2,
                                       (ushort)(radGroupGoHomeSpeedSelect.SelectedIndex == 0 ? 0 : 1)
                                       );
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            #region 位置显示

            lblPositionX.Value = X_Axis.Position;  // 保留4位小数显示
            lblPositionY.Value = Y_Axis.Position;
            lblPositionZ.Value = Z_Axis.Position;


            lblDisplayXOverGoHomeMark.Text = X_Axis.OverGoHomeMark ? "X轴回原点完成" : "X轴未回原点";
            lblDisplayYOverGoHomeMark.Text = Y_Axis.OverGoHomeMark ? "Y轴回原点完成" : "Y轴未回原点";
            lblDisplayZOverGoHomeMark.Text = Z_Axis.OverGoHomeMark ? "Z轴回原点完成" : "Z轴未回原点";

            lblDisplayXOverGoHomeMark.ForeColor = X_Axis.OverGoHomeMark ? Color.Green : Color.Red;
            lblDisplayYOverGoHomeMark.ForeColor = Y_Axis.OverGoHomeMark ? Color.Green : Color.Red;
            lblDisplayZOverGoHomeMark.ForeColor = Z_Axis.OverGoHomeMark ? Color.Green : Color.Red;

            #endregion

            #region 轴状态

            tableLayoutPanel8.Controls.Cast<Control>().Where(light => light is UILight).
            Cast<UILight>().
            ForEach(light =>
            {
                Axis axis = light.Name.Substring(light.Name.Length - 1) == "X" ? X_Axis :
                    light.Name.Substring(light.Name.Length - 1) == "Y" ? Y_Axis : Z_Axis;

                if (light.Name.Contains("Run"))
                {
                    light.State = axis.IsRunning ? UILightState.Blink : UILightState.Off;
                }

                else if (light.Name.Contains("ORG"))
                {
                    light.State = axis.Org ? UILightState.On : UILightState.Off;
                }
                else if (light.Name.Contains("PEL"))
                {
                    light.State = axis.PositiveLimit ? UILightState.On : UILightState.Off;
                }
                else if (light.Name.Contains("NEL"))
                {
                    light.State = axis.NegativeLimit ? UILightState.On : UILightState.Off;
                }
                else
                {
                    light.State = axis.FaultAlrm ? UILightState.On : UILightState.Off;
                }

                txtXRunSpeed.Text = X_Axis.RunningSpeed.ToString("F2");
                txtYRunSpeed.Text = Y_Axis.RunningSpeed.ToString("F2");
                txtZRunSpeed.Text = Z_Axis.RunningSpeed.ToString("F2");


            });

            #endregion

            #region 自动运行状态

            uiLightCuterStatus.State = IOCraftEntity.Cutter.StatusValue ? UILightState.On : UILightState.Off;


            switch (processFlowBLL.autoProcessStep)
            {
                case AutoProcessStep.AutomaticallyStopping:
                    lblStatus.Text = "自动停止中...";
                    break;
                case AutoProcessStep.MoveToProcessedPosition:
                    lblStatus.Text = "移动到待加工位置" + (Axis.PauseMark ? "_暂停中" : "");
                    break;

                case AutoProcessStep.DetectMaterialSignal:
                    lblStatus.Text = "检测物料到位信号" + (Axis.PauseMark ? "_暂停中" : "");
                    break;

                case AutoProcessStep.TurnOnCutter:
                    lblStatus.Text = "打开切割器" + (Axis.PauseMark ? "_暂停中" : "");
                    break;

                case AutoProcessStep.ZAxisMoveToFitstPoint:
                    lblStatus.Text = "Z轴移动到加工的第一个点" + (Axis.PauseMark ? "_暂停中" : "");
                    break;

                case AutoProcessStep.ProcessFromTableData:
                    lblStatus.Text = "从表格数据中获取加工数据" + (Axis.PauseMark ? "_暂停中" : "");
                    break;

                case AutoProcessStep.AxisGotoSafePosition:
                    lblStatus.Text = "Z轴移动到安全位置" + (Axis.PauseMark ? "_暂停中" : "");
                    break;

                case AutoProcessStep.TurnOffCutter:
                    lblStatus.Text = "关闭切割器" + (Axis.PauseMark ? "_暂停中" : "");
                    break;

                case AutoProcessStep.GoHomeEliminateErrors:
                    lblStatus.Text = "消除误差" + (Axis.PauseMark ? "_暂停中" : "");
                    break;
            }


            //lblStatus.Text = processFlowBLL.autoProcessStep.ToString();




            #endregion

        }

        /// <summary>
        /// 自动运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnStart_Click(object sender, EventArgs e)

        {
            if (!X_Axis.OverGoHomeMark || !Y_Axis.OverGoHomeMark || !Z_Axis.OverGoHomeMark)
            {
                MessageBox.Show("回原点未完成！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvDisplay.Rows.Count == 0)
            {
                MessageBox.Show("表格中没有任何数据！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (processFlowBLL.autoProcessStep != AutoProcessStep.AutomaticallyStopping)
            {
                MessageBox.Show("自动进行中！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            cmbProductName.Enabled = false;
            btnDelProduct.Enabled = false;

            await processFlowBLL.AutoRunAsync();

            cmbProductName.Enabled = true;
            btnDelProduct.Enabled = true;

        }

        /// <summary>
        /// 暂停_再启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, EventArgs e)
        {
            //如果不是自动运行中，则无法执行暂停
            if (processFlowBLL.autoProcessStep == AutoProcessStep.AutomaticallyStopping) { return; }

            if (btnPause.Text == "暂停")
            {
                processFlowBLL.Pause();
                btnPause.Text = "再启动";
                btnPause.FillColor = Color.Red;
            }
            else
            {
                processFlowBLL.StartAgain();
                btnPause.Text = "暂停";
                btnPause.FillColor = Color.FromArgb(255, 128, 0);
            }
        }

        /// <summary>
        /// 全自动半自动切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="index"></param>
        /// <param name="text"></param>
        private void radGroupAutoSelect_ValueChanged(object sender, int index, string text)
        {
            if (text == "半自动")
            {
                processFlowBLL.FullyAutomaticMark = false;
            }
            else
            {
                processFlowBLL.FullyAutomaticMark = true;
            }
        }

        /// <summary>
        /// 按下回车创建表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult dialogResult = MessageBox.Show("是否创建表格?", "消息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    bool isOk = dataHandleBLL.CreateTable(cmbProductName.Text, tableNames, out string res);

                    tsslExecuteInfo.ForeColor = isOk ? Color.Green : Color.Red;
                    tsslExecuteInfo.Text = res;

                    if (isOk)
                    {
                        cmbProductName.SelectedItem = cmbProductName.Text;  //选中创建的表格

                    }

                }
            }
        }

        /// <summary>
        /// 切换 点动_微动切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkMicroMove_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMicroMove.Text == "点动")
            {
                chkMicroMove.Text = "微动";
                chkMicroMove.BackColor = Color.FromArgb(255, 128, 0);
            }
            else
            {
                chkMicroMove.Text = "点动";
                chkMicroMove.BackColor = Color.FromArgb(0, 128, 255);
            }
        }

        private void dgvDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int num = dgvDisplay.SelectedIndex;
                cmbSelectPos.SelectedIndex = num;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
