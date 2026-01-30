using BLL;
using Common;
using Entity;
using PanelSeparationMachineV1._26.UI;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PanelSeparationMachineV1._26
{
    public partial class frmMain : UIForm
    {

        #region 字段和属性

        #region 业务逻辑

        /// <summary>
        /// 相机视觉处理业务逻辑
        /// </summary>
        private CemeraVisionHandleBLL cemeraVisionHandleBLL;


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
        /// 相机视觉参数实体对象
        /// </summary>
        private CameraVisionEntity CameraVisionEntity = new CameraVisionEntity();

        /// <summary>
        /// 加工坐标点集合(来自数据库) 绑定示教的DataGridView控件
        /// </summary>
        private BindingList<ProcessCoordEntity> processCoordTeaching = new BindingList<ProcessCoordEntity>();

        /// <summary>
        /// 加工坐标点集合(来自数据库) 绑定自动加工的DataGridView控件
        /// </summary>
        private BindingList<ProcessCoordEntity> processCoordAuto = new BindingList<ProcessCoordEntity>();

        /// <summary>
        /// 表名集合 示教
        /// </summary>
        private BindingList<string> tableNamesTeaching = new BindingList<string>();

        /// <summary>
        /// 表名集合 自动加工
        /// </summary>
        private BindingList<string> tableNamesAuto = new BindingList<string>();

        

        /// <summary>
        /// 轴实体
        /// </summary>
        public Axis X_Axis = new Axis() { Axis_CardNo = 0, Axis_Num = 0, Axis_Name = "X轴" };
        public Axis Y_Axis = new Axis() { Axis_CardNo = 0, Axis_Num = 1, Axis_Name = "Y轴" };
        public Axis Z_Axis = new Axis() { Axis_CardNo = 0, Axis_Num = 2, Axis_Name = "Z轴" };

        /// <summary>
        /// IO工艺实体
        /// </summary>
        public IOCraftEntity IOCraftEntity = new IOCraftEntity();

        #endregion

        #endregion



        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            if (motionHandleBLL.OpenCard(out string res))
            {
                MessageBox.Show(res, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DisplayCurrentUser();

                # region 绘图相关

                dataHandleBLL.ReadDrawParamFromIni(AppData.DrawParamsEntity);
                drawHandleBLL = new DrawHandleBLL(picTrackDisplay);
                drawHandleBLL.CoordinatesReset();

                #endregion

                #region 控制卡相关

                dataHandleBLL.ReadAxisDataFromIni(X_Axis);
                dataHandleBLL.ReadAxisDataFromIni(Y_Axis);
                dataHandleBLL.ReadAxisDataFromIni(Z_Axis);
                dataHandleBLL.ReadIOCraftEntityFromIni(IOCraftEntity);
                //控制卡信号
                motionHandleBLL.RealTimeReadAxisData(IOCraftEntity, X_Axis, Y_Axis, Z_Axis);

                #endregion

                #region 相机和图像

                dataHandleBLL.ReadCameraVisionFromIni(CameraVisionEntity);

                picDisplayRoi.Image = File.Exists(Environment.CurrentDirectory + @"\Mark1ROI.bmp") ?
                    Image.FromFile(Environment.CurrentDirectory + @"\Mark1ROI.bmp") : null;

                picCalibrationDisplay.Image = File.Exists(Environment.CurrentDirectory + @"\Mark2ROI.bmp") ?
                    Image.FromFile(Environment.CurrentDirectory + @"\Mark2ROI.bmp") : null;

                cemeraVisionHandleBLL = new CemeraVisionHandleBLL(hWindowControl1);
                cemeraVisionHandleBLL.OpenCamera(CameraVisionEntity.StrSN);
                cemeraVisionHandleBLL.SingleAcq();

                #endregion

                #region 数据库

                //固定数据库名字
                string path = Environment.CurrentDirectory + @"\轨迹加工.mdb";

                if(!File.Exists(path))
                {
                    bool isOk = dataHandleBLL.CreateDataBase(path, out string res1);
                    tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
                    tsslExecuteResult.Text = res1;

                    if(isOk)
                    {

                    }
                    else
                    {
                        
                    }
                }
                else
                { 
                    dataHandleBLL.OpenDataBase(path);

                    if (dataHandleBLL.GetTableNames(tableNamesAuto, out string res1))
                    {
                        tableNamesAuto.ForEach(str => { tableNamesTeaching.Add(str); });

                        if (tableNamesAuto.Count > 0)
                        {
                            cmbProductName.Text = tableNamesAuto[0];
                            dataHandleBLL.GetTableData(cmbProductName.Text, processCoordAuto, out res1);

                            cmbProductType.Text = tableNamesTeaching[0];
                            dataHandleBLL.GetTableData(cmbProductType.Text, processCoordTeaching, out string res2);
                        }
                    }

                }


                #endregion

                #region 自动工艺流程的相关数据

                processFlowBLL.processCoordEntities = processCoordAuto;
                processFlowBLL.AxisList = new List<Axis>() { X_Axis, Y_Axis, Z_Axis };
                processFlowBLL.iOCraftEntity = IOCraftEntity;

                processFlowBLL.drawHandleBLL = drawHandleBLL;
                processFlowBLL.drawParamsEntity = AppData.DrawParamsEntity;

                processFlowBLL.CemeraVisionHandleBLL = cemeraVisionHandleBLL;
                processFlowBLL.cameraVisionEntity = CameraVisionEntity;
                
                processFlowBLL.UiDoSomething -= processFlowBLL_UiDgvSelectUpdate;
                processFlowBLL.UiDoSomething += processFlowBLL_UiDgvSelectUpdate;

                #endregion


                //控件相关
                ControlBindingEntityData();

            }
            else
            {
                MessageBox.Show(res, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }



        }

        /// <summary>
        /// 自动流程运行到哪个点位 DataGridView空间就选中哪行 
        /// </summary>
        /// <param name="num"></param>
        private void processFlowBLL_UiDgvSelectUpdate(int num)
        {
            this.Invoke(new Action(() =>
            {
                dgvAutoDisplay.Rows[num].Selected = true;
            }));
        }

        private void DisplayCurrentUser()
        {
            FieldInfo fieldInfo = typeof(UserEntity.Level).GetField(AppData.CurrentUserEntity.JobLevel.ToString());
            DescriptionCustomAttribute descriptionCustomAttribute = (DescriptionCustomAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionCustomAttribute)); ;

            string level = descriptionCustomAttribute.Description;
            this.Text = $"当前用户: {AppData.CurrentUserEntity.Name} {AppData.CurrentUserEntity.EmployeeID} {level}";
        }


        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void  frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            #region 绘图操作

            dataHandleBLL.SaveDrawParamToIni(AppData.DrawParamsEntity);

            #endregion

            #region 控制卡操作

            dataHandleBLL.WriteIOCraftEntityToIni(IOCraftEntity);
            await motionHandleBLL.StopRealTimeRead();
            motionHandleBLL.CloseCard();

            #endregion


            #region 相机和图像
            chkContinuousAcq.Checked = false;
            dataHandleBLL.WriteCameraVisionToIni(CameraVisionEntity); //保存相机视觉参数
            cemeraVisionHandleBLL.CloseCamera(); //关闭相机

            #endregion

            Environment.Exit(0); //退出程序
        }

        

        /// <summary>
        /// 设置增益
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tkbGain_ValueChanged(object sender, EventArgs e)
        {
            cemeraVisionHandleBLL.SetGain(tkbGain.Value);
        }

        /// <summary>
        /// 设置曝光
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tkbExposureTime_ValueChanged(object sender, EventArgs e)
        {
            cemeraVisionHandleBLL.SetExposure(tkbExposureTime.Value);
        }


        /// <summary>
        /// 控件绑定实体数据
        /// </summary>
        public void ControlBindingEntityData()
        {

            radGroupAutoSelect.SelectedIndex = 0;
            radGroupGoHomeMode.SelectedIndex = 1;
            radGroupGoHomeSpeedSelect.SelectedIndex = 1;
            radGroupMarkSelect.SelectedIndex = 0;
            radGroupMatchSelect.SelectedIndex = 0;



            lblExposureTime.DataBindings.Add("Text", CameraVisionEntity, "ExposeTime", false, DataSourceUpdateMode.Never);
            lblGain.DataBindings.Add("Text", CameraVisionEntity, "Gain", false, DataSourceUpdateMode.Never);

            tkbExposureTime.DataBindings.Add("Value", CameraVisionEntity, "ExposeTime", false, DataSourceUpdateMode.OnPropertyChanged);
            tkbGain.DataBindings.Add("Value", CameraVisionEntity, "Gain", false, DataSourceUpdateMode.OnPropertyChanged);

            nudExposureSet.DataBindings.Add("Text", CameraVisionEntity, "ExposeTime", false, DataSourceUpdateMode.OnPropertyChanged);

            nudGainSet.DataBindings.Add("Text", CameraVisionEntity, "Gain", false, DataSourceUpdateMode.OnPropertyChanged);

            nudMaxOverlap.DataBindings.Add("Value", CameraVisionEntity, "MaxOverlap", false, DataSourceUpdateMode.OnPropertyChanged);

            nudMaxGreed.DataBindings.Add("Value", CameraVisionEntity, "Greediness", false, DataSourceUpdateMode.OnPropertyChanged);

            nudMatchScoreSet.DataBindings.Add("Value", CameraVisionEntity, "MatchScores", false, DataSourceUpdateMode.OnPropertyChanged);


            txtPixTomm_X.DataBindings.Add("Text", CameraVisionEntity, "XDirPixToMachine", false, DataSourceUpdateMode.OnPropertyChanged);

            txtPixTomm_Y.DataBindings.Add("Text", CameraVisionEntity, "YDirPixToMachine", false, DataSourceUpdateMode.OnPropertyChanged);

            txtCalibrationHeight.DataBindings.Add("Text", CameraVisionEntity, "BDHeight", false, DataSourceUpdateMode.OnPropertyChanged);



            //表名集合绑定cmbProductName控件
            cmbProductType.DataSource = tableNamesTeaching;
            cmbProductName.DataSource = tableNamesAuto;

            //加工坐标点集合绑定dgvDisplay控件
            dgvTeachingData.AutoGenerateColumns = false;  //不自动创建列 按照指定的来
            dgvTeachingData.DataSource = processCoordTeaching;

            dgvAutoDisplay.AutoGenerateColumns = false;  //不自动创建列 按照指定的来
            dgvAutoDisplay.DataSource = processCoordAuto;

            cmbSelectPos.DisplayMember = "Num";
            cmbSelectPos.DataSource = processCoordTeaching;

        }

        /// <summary>
        /// 连续采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkContinuousAcq_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContinuousAcq.Checked)
            {
                cemeraVisionHandleBLL.ContinueAcq();
            }
            else
            {
                cemeraVisionHandleBLL.StopContinueAcq(); //停止连续采集
                cemeraVisionHandleBLL.SingleAcq();     //单次采集
            }
        }



        /// <summary>
        /// 每隔200ms更新一次UI数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region 位置显示

            lblPositionX.Value = X_Axis.Position;  // 保留4位小数显示
            lblPositionY.Value = Y_Axis.Position;
            lblPositionZ.Value = Z_Axis.Position;


            //lblDisplayXOverGoHomeMark.Text = X_Axis.OverGoHomeMark ? "X轴回原点完成" : "X轴未回原点";
            //lblDisplayYOverGoHomeMark.Text = Y_Axis.OverGoHomeMark ? "Y轴回原点完成" : "Y轴未回原点";
            //lblDisplayZOverGoHomeMark.Text = Z_Axis.OverGoHomeMark ? "Z轴回原点完成" : "Z轴未回原点";

            //lblDisplayXOverGoHomeMark.ForeColor = X_Axis.OverGoHomeMark ? Color.Green : Color.Red;
            //lblDisplayYOverGoHomeMark.ForeColor = Y_Axis.OverGoHomeMark ? Color.Green : Color.Red;
            //lblDisplayZOverGoHomeMark.ForeColor = Z_Axis.OverGoHomeMark ? Color.Green : Color.Red;

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

            Type type = typeof(AutoProcessStep);
            FieldInfo fieldInfo = type.GetField(processFlowBLL.autoProcessStep.ToString());
            if(fieldInfo.IsDefined(typeof(DescriptionCustomAttribute), false))
            {
                DescriptionCustomAttribute descriptionCustomAttribute = (DescriptionCustomAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionCustomAttribute), false);

                lblStatus.Text = descriptionCustomAttribute.Description + (Axis.PauseMark ? "_暂停中" : "");
            }

            uiLightCuterStatus.State = IOCraftEntity.Cutter.StatusValue ? UILightState.On : UILightState.Off;

            #endregion

        }

        

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否确定关闭?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
           
        }

        private void 轴参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAxisParamsSet frmAxisParamsSet = new frmAxisParamsSet(X_Axis, Y_Axis, Z_Axis);
            frmAxisParamsSet.ShowDialog();
        }

        private void 工艺参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrawParams frmDrawParams = new frmDrawParams();
            frmDrawParams.ShowDialog();
        }

        private void 退出系统ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            chkContinuousAcq.Checked = false;
            this.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataHandleBLL.GetTableData(cmbProductName.Text, processCoordTeaching, out string res);
        }

        /// <summary>
        /// 回车键创建表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProductType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult dialogResult = MessageBox.Show("是否创建表格?", "消息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string tableName = cmbProductType.Text;
                    bool isOk = dataHandleBLL.CreateTable(tableName, tableNamesTeaching, out string res);

                    tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
                    tsslExecuteResult.Text = res;

                    string tn = cmbProductName.Text;  
                    if (isOk)
                    {
                        tableNamesAuto.Clear();
                        tableNamesTeaching.ForEach(str => { tableNamesAuto.Add(str); });

                        cmbProductName.Text = tn;   //生产页面显示之前的表
                        cmbProductType.SelectedItem = tableName;  //选中创建的表格
                    }
                }
            }
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelProduct_Click(object sender, EventArgs e)
        {
           
            string currentTableNamesTeaching = cmbProductType.Text;
            string currentTableNamesTeachingAuto = cmbProductName.Text;

            bool isOk = dataHandleBLL.DeleteTable(cmbProductType.Text, tableNamesTeaching, out string res);


            tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
            tsslExecuteResult.Text = res;

            if (isOk)
            {
                tableNamesAuto.Clear();
                tableNamesTeaching.ForEach(str => { tableNamesAuto.Add(str); });

                if (tableNamesTeaching.Count > 0)
                {
                    
                    if(currentTableNamesTeaching == currentTableNamesTeachingAuto)
                    {
                        cmbProductName.Text = tableNamesAuto[0];
                    }
                    else
                    {
                        cmbProductName.Text = currentTableNamesTeachingAuto;
                    }

                        cmbProductType.Text = tableNamesTeaching[0];

                }
                else//没有表
                {
                    cmbProductType.Text = "";
                    cmbProductName.Text = "";
                }
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

                int num = int.Parse(dgvTeachingData.SelectedRows[0].Cells[0].Value.ToString());
                ProcessCoordEntity processCoordEntity = new ProcessCoordEntity()
                {
                    Num = num,
                    XPosition = lblPositionX.Value,
                    YPosition = lblPositionY.Value,
                    ZPosition = lblPositionZ.Value
                };


                bool isOk = dataHandleBLL.InsertRecord(cmbProductName.Text, tableNamesTeaching, processCoordEntity, out string res);

                dataHandleBLL.GetTableData(cmbProductName.Text, processCoordTeaching, out string res2);

                //更新生产页面表格
                if (cmbProductType.Name == cmbProductName.Text)
                {
                    dataHandleBLL.GetTableData(cmbProductName.Text, processCoordAuto, out string res3);

                }

                tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteResult.Text = res;

                if (isOk)
                {
                    int index = 0;
                    index = dgvTeachingData.Rows.Cast<DataGridViewRow>(). //Ienumerable<DataGridViewRow>
                            Where(dR => dR.Cells[0].Value.ToString() == processCoordEntity.Num.ToString()).
                            FirstOrDefault()?.Index ?? 0;  //集合中的第一个或者默认值null

                    dgvTeachingData.Rows[index].Selected = true;
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

                int num = int.Parse(dgvTeachingData.SelectedRows[0].Cells[0].Value.ToString());

                bool isOk = dataHandleBLL.DeleteRecord(cmbProductName.Text, tableNamesTeaching, num, out string res);

                dataHandleBLL.GetTableData(cmbProductName.Text, processCoordTeaching, out string res1);

                //更新生产页面表格
                if (cmbProductType.Name == cmbProductName.Text)
                {
                    dataHandleBLL.GetTableData(cmbProductName.Text, processCoordAuto, out string res3);

                }

                tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteResult.Text = res;
                if (isOk)
                {
                    if (dgvTeachingData.Rows.Count > 0)
                    {
                        dgvTeachingData.Rows[0].Selected = true;

                    }
                }


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

                bool isOk = dataHandleBLL.AddRecord(cmbProductName.Text, tableNamesTeaching, processCoordEntity, out string res);

                dataHandleBLL.GetTableData(cmbProductName.Text, processCoordTeaching, out string res2);

                //更新生产页面表格
                if(cmbProductType.Name == cmbProductName.Text)
                {
                    dataHandleBLL.GetTableData(cmbProductName.Text, processCoordAuto, out string res3);
                    
                }

                tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteResult.Text = res;

                if (isOk)
                {
                    //选中最后一行
                    dgvTeachingData.Rows[dgvTeachingData.Rows.Count - 1].Selected = true;
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
                dgvTeachingData.Rows[cmbSelectPos.SelectedIndex].Selected = true;

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
            double x = double.Parse(dgvTeachingData.Rows[num].Cells[1].Value.ToString());
            double y = double.Parse(dgvTeachingData.Rows[num].Cells[2].Value.ToString());
            double z = double.Parse(dgvTeachingData.Rows[num].Cells[3].Value.ToString());

            motionHandleBLL.GoSpecifyPoint(new Axis[] { X_Axis, Y_Axis, Z_Axis },
                            new double[] { x, y, z });
        }
        
        /// <summary>
        /// 修改该点坐标
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
                int rowIndex = dgvTeachingData.SelectedRows[0].Index;  //获取行索引
                int num = int.Parse(dgvTeachingData.SelectedRows[0].Cells[0].Value.ToString()); //获取编号

                ProcessCoordEntity processCoordEntity = new ProcessCoordEntity()
                {
                    XPosition = lblPositionX.Value,
                    YPosition = lblPositionY.Value,
                    ZPosition = lblPositionZ.Value,
                };

                bool isOk = dataHandleBLL.ModifyRecord(cmbProductName.Text, tableNamesTeaching, num, processCoordEntity, out string res);

                dataHandleBLL.GetTableData(cmbProductName.Text, processCoordTeaching, out string res1);

                //更新生产页面表格
                if (cmbProductType.Name == cmbProductName.Text)
                {
                    dataHandleBLL.GetTableData(cmbProductName.Text, processCoordAuto, out string res3);

                }

                tsslExecuteResult.ForeColor = isOk ? Color.Green : Color.Red;
                tsslExecuteResult.Text = res;

                if (isOk)
                {
                    dgvTeachingData.Rows[num - 1].Selected = true;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvTeachingData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int num = dgvTeachingData.SelectedIndex;
                cmbSelectPos.SelectedIndex = num;

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOneKeyHome_Click(object sender, EventArgs e)
        {
            motionHandleBLL.AllGoHome(new Axis[] { X_Axis, Y_Axis, Z_Axis },
                                       (ushort)(radGroupGoHomeMode.SelectedIndex == 0 ? 0 : 2),
                                       2,
                                       (ushort)(radGroupGoHomeSpeedSelect.SelectedIndex == 0 ? 0 : 1)
                                       );
        }

        private void btnJog_MouseDown(object sender, MouseEventArgs e)
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
            tsslExecuteResult.Text = res;
        }

        private void btnJog_MouseUp(object sender, MouseEventArgs e)
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
            tsslExecuteResult.Text = res;
        }

        /// <summary>
        /// 微动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJog_Click(object sender, EventArgs e)
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
        /// 点动_微动切换
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

        /// <summary>
        /// 点动_紧急按钮
        /// </summary>
        private void btnEms_Click(object sender, EventArgs e)
        {
            UIImageButton uIButton = sender as UIImageButton;

            if (!uIButton.Selected)
            {
                processFlowBLL.PressEmg();
                uIButton.Selected = true;
            }
            else
            {
                processFlowBLL.LoosenEmg();
                uIButton.Selected = false;
            }
        }

        /// <summary>
        /// 切换页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = tabControlDisplay.SelectedIndex;
            if (num == -1) { return; }

            bool isAllAxisGoHomeOver = X_Axis.OverGoHomeMark && 
                                       Y_Axis.OverGoHomeMark &&
                                       Z_Axis.OverGoHomeMark;

            if (num == 1) //选中示教页面
            {
                if (AppData.CurrentUserEntity.JobLevel < UserEntity.Level.Technician)
                {
                    tabControlDisplay.SelectedIndex = 0;
                    MessageBox.Show("您没有权限访问此页面！(技术员登记以上才能进入)", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (processFlowBLL.autoProcessStep != AutoProcessStep.AutomaticallyStopping)
                {   
                    tabControlDisplay.SelectedIndex = 0;
                    MessageBox.Show("自动进行中！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }

            else if (num == 2) //相机设置页面
            {
                if (AppData.CurrentUserEntity.JobLevel < UserEntity.Level.Engineer)
                {
                    tabControlDisplay.SelectedIndex = 0;
                    MessageBox.Show("您没有权限访问此页面！(工程师等级以上才能进入)", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (!isAllAxisGoHomeOver)
                {
                    tabControlDisplay.SelectedIndex = 0;
                    MessageBox.Show("有轴未执行回原点！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (processFlowBLL.autoProcessStep != AutoProcessStep.AutomaticallyStopping)
                {
                    tabControlDisplay.SelectedIndex = 0;
                    MessageBox.Show("自动进行中！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }



        }

        private void 重新登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            if (frmLogin.DialogResult == DialogResult.OK)
            {
                tabControlDisplay.SelectedIndex = 0; //返回第一个画面
                DisplayCurrentUser();
            }
        }

        /// <summary>
        /// 增益设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void nudGainSet_ValueChanged(object sender, double value)
        {
            cemeraVisionHandleBLL.SetGain(value);
        }

        /// <summary>
        /// 曝光时间设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void nudExposureSet_ValueChanged(object sender, double value)
        {
            cemeraVisionHandleBLL.SetExposure(value);
        }

        /// <summary>
        /// 选择ROI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectRoi_Click(object sender, EventArgs e)
        {

            //注销事件
            hWindowControl1.HMouseDown -= hWindowControl1_HMouseDown;  //取消鼠标按下去指定位置功能



            //1. 停止连续采集并抓拍一张当前图像
            GrapAndUpdate();

            string roiName = radGroupMarkSelect.SelectedIndex == 0 ? "Mark1" : "Mark2";

            //2. 确保PictureBox1对图像资源引用进行释放
            if(picDisplayRoi.Image != null)
            {
                picDisplayRoi.Image.Dispose(); //取消和图片的关联
            }

            if(picCalibrationDisplay.Image != null && roiName == "Mark2")
            {
                picCalibrationDisplay.Image.Dispose();
            }

            //3. 显示ROI选择窗口 并绘制ROI
            frmSelectRoi frmSelectRoi = new frmSelectRoi();
            frmSelectRoi.ShowDialog();

            if(cemeraVisionHandleBLL.DrawROI(AppData.RoiSelect, roiName, out string res))
            {
                //4. 显示Roi图像
                picDisplayRoi.Image = Image.FromFile(Environment.CurrentDirectory + $@"\{roiName}ROI.bmp");
                if(roiName == "Mark2")
                {
                    picCalibrationDisplay.Image = Image.FromFile(Environment.CurrentDirectory + @"\Mark2ROI.bmp");
                }
                //5. 确定拍照高度(Z轴位置)
                CameraVisionEntity.BDHeight = Z_Axis.Position;
            }
            else //绘制ROI失败
            {
                MessageBox.Show(res, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //注销事件
            hWindowControl1.HMouseDown += hWindowControl1_HMouseDown;  //恢复鼠标按下去指定位置功能

        }

        /// <summary>
        /// 停止连续采集并抓拍一张当前图像
        /// </summary>
        private void GrapAndUpdate()
        { 
            this.Invoke(new Action(() =>
            {
                chkContinuousAcq.Checked = false; //停止连续采集
                cemeraVisionHandleBLL.SingleAcq();
            }));
        }

        /// <summary>
        /// 生成模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            string str = radGroupMarkSelect.SelectedIndex == 0 ? "Mark1" : "Mark2";
            if (cemeraVisionHandleBLL.CreateModel(str, out string res))
            {
                MessageBox.Show(res, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mark1/Mark2点切换 显示不同的Mark图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="index"></param>
        /// <param name="text"></param>
        private void radGroupMarkSelect_ValueChanged(object sender, int index, string text)
        {
            if(index == 0)
            {
                picDisplayRoi.Image = File.Exists(Environment.CurrentDirectory + @"\Mark1ROI.bmp") ? 
                    Image.FromFile(Environment.CurrentDirectory + @"\Mark1ROI.bmp") : null;
            }
            else
            {
                picDisplayRoi.Image = File.Exists(Environment.CurrentDirectory + @"\Mark2ROI.bmp") ?
                    Image.FromFile(Environment.CurrentDirectory + @"\Mark2ROI.bmp") : null;
            }
        }
        
        
        /// <summary>
        /// 匹配模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMatchMpdel_Click(object sender, EventArgs e)
        {
            //1. 停止连续采集并抓拍一张当前图像
            GrapAndUpdate();

            if(radGroupMarkSelect.SelectedIndex == 0) //选择Mark1
            {
                PixelPos pixelPos = cemeraVisionHandleBLL.ExcuteMatch("Mark1", 
                                                                        CameraVisionEntity.MatchScores,
                                                                        CameraVisionEntity.MaxOverlap,
                                                                        CameraVisionEntity.Greediness);

                if(pixelPos != null)
                {
                    CameraVisionEntity.TBImageMark1.Row = pixelPos.Row;
                    CameraVisionEntity.TBImageMark1.Column = pixelPos.Column;

                    CameraVisionEntity.TBMachineMark1.X = X_Axis.Position;
                    CameraVisionEntity.TBMachineMark1.Y = Y_Axis.Position;
                }
            }
            else //选择Mark2
            { 
                PixelPos pixelPos = cemeraVisionHandleBLL.ExcuteMatch("Mark2",
                                                                        CameraVisionEntity.MatchScores,
                                                                        CameraVisionEntity.MaxOverlap,
                                                                        CameraVisionEntity.Greediness);

                if(pixelPos != null)
                {
                    CameraVisionEntity.TBImageMark2.Row = pixelPos.Row;
                    CameraVisionEntity.TBImageMark2.Column = pixelPos.Column;

                    CameraVisionEntity.TBMachineMark2.X = X_Axis.Position;
                    CameraVisionEntity.TBMachineMark2.Y = Y_Axis.Position;
                }
            }
        }

        /// <summary>
        /// 去Mark点位置拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnGoMarkPos_Click(object sender, EventArgs e)
        {
            chkContinuousAcq.Checked = true;
            if (radGroupMarkSelect.SelectedIndex == 0) //选择Mark1
            {
                await motionHandleBLL.GotoMark1(Z_Axis, X_Axis, Y_Axis, CameraVisionEntity);
            }
            else //选择Mark2
            {
                await motionHandleBLL.GotoMark2(Z_Axis, X_Axis, Y_Axis, CameraVisionEntity);
            }
        }

        // <summary>
        /// 移动到Mark2位置
        /// </summary>
        private async void btnGotoMark2_Click(object sender, EventArgs e)
        {
            if(!File.Exists(Environment.CurrentDirectory + $@"\Mark2ShapeModel.shm"))
            {
                MessageBox.Show("没有制作Mark2的模板", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(CameraVisionEntity.TBMachineMark2.X == 0 || CameraVisionEntity.TBMachineMark2.Y == 0)
            {
                MessageBox.Show("没有Mark2的拍照位置坐标，没有执行模板制作中的匹配模板! ", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            chkContinuousAcq.Checked = true;

            await motionHandleBLL.GotoMark2(Z_Axis, X_Axis, Y_Axis, CameraVisionEntity);

            btnCalibrationPhotoGraph1.Enabled = true; //标定拍照1按钮允许
            btnCalibrationPhotoGraph2.Enabled = false; //标定拍照2按钮禁止
            btnCount.Enabled = false;  //计数按钮禁止
        }

        /// <summary>
        /// 标定拍照1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalibrationPhotoGraph1_Click(object sender, EventArgs e)
        {

            GrapAndUpdate();

            //2. 匹配Mark2
            PixelPos pixelPos = cemeraVisionHandleBLL.ExcuteMatch("Mark2",
                                                                    CameraVisionEntity.MatchScores,
                                                                    CameraVisionEntity.MaxOverlap,
                                                                    CameraVisionEntity.Greediness);

            if (pixelPos != null)
            {
                CameraVisionEntity.BDPixMark2MoveBefore.Row = pixelPos.Row;
                CameraVisionEntity.BDPixMark2MoveBefore.Column = pixelPos.Column;

                CameraVisionEntity.BDMachineMark2MoveBefore.X = X_Axis.Position;
                CameraVisionEntity.BDMachineMark2MoveBefore.Y = Y_Axis.Position;
            }
            else
            {
                MessageBox.Show("匹配失败! ", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnCalibrationPhotoGraph1.Enabled = false; //标定拍照1按钮禁止
            btnCalibrationPhotoGraph2.Enabled = true; //标定拍照2按钮允许
            btnCount.Enabled = false; //计算按钮禁止

            MessageBox.Show("分别移动XY轴，然后继续进行拍照标定2! ", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            chkContinuousAcq.Checked = true;
        }


        /// <summary>
        /// 标定拍照2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCalibrationPhotoGraph2_Click(object sender, EventArgs e)
        {

            GrapAndUpdate();

            //2. 匹配Mark2
            PixelPos pixelPos = cemeraVisionHandleBLL.ExcuteMatch("Mark2",
                                                                    CameraVisionEntity.MatchScores,
                                                                    CameraVisionEntity.MaxOverlap,
                                                                    CameraVisionEntity.Greediness);

            if (pixelPos != null)
            {
                CameraVisionEntity.BDPixMark2MoveAfter.Row = pixelPos.Row;
                CameraVisionEntity.BDPixMark2MoveAfter.Column = pixelPos.Column;

                CameraVisionEntity.BDMachineMark2MoveAfter.X = X_Axis.Position;
                CameraVisionEntity.BDMachineMark2MoveAfter.Y = Y_Axis.Position;
            }
            else
            {
                MessageBox.Show("匹配失败! ", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnCalibrationPhotoGraph1.Enabled = false; //标定拍照1按钮禁止
            btnCalibrationPhotoGraph2.Enabled = false; //标定拍照2按钮允许
            btnCount.Enabled = true; //计算按钮禁止

            MessageBox.Show("点击计算按钮进行计算! ", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            chkContinuousAcq.Checked = true;


        }

        /// <summary>
        /// 计算系数(像素和机械的比值)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCount_Click(object sender, EventArgs e)
        {
            //两次拍照 X轴方向 的机械坐标差值
            double diffX = Math.Abs(CameraVisionEntity.BDMachineMark2MoveAfter.X - 
                                    CameraVisionEntity.BDMachineMark2MoveBefore.X);

            if(diffX == 0)
            {
                MessageBox.Show("未移动X轴! ", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCalibrationPhotoGraph1.Enabled = false; //标定拍照1按钮禁止
                btnCalibrationPhotoGraph2.Enabled = true; //标定拍照2按钮允许
                btnCount.Enabled = false; //计算按钮禁止
                return;
            }

            //两次拍照 列轴方向 的像素坐标差值
            double diffC = Math.Abs(CameraVisionEntity.BDPixMark2MoveAfter.Column -
                                   CameraVisionEntity.BDPixMark2MoveBefore.Column);

            CameraVisionEntity.XDirPixToMachine = diffC / diffX;

            //*************************************************************************


            //两次拍照 Y轴方向 的机械坐标差值
            double diffY = Math.Abs(CameraVisionEntity.BDMachineMark2MoveAfter.Y -
                                    CameraVisionEntity.BDMachineMark2MoveBefore.Y);

            if (diffY == 0)
            {
                MessageBox.Show("未移动X轴! ", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCalibrationPhotoGraph1.Enabled = false; //标定拍照1按钮禁止
                btnCalibrationPhotoGraph2.Enabled = true; //标定拍照2按钮允许
                btnCount.Enabled = false; //计算按钮禁止
                return;
            }

            //两次拍照 行方向 的像素坐标差值
            double diffR = Math.Abs(CameraVisionEntity.BDPixMark2MoveAfter.Row -
                                   CameraVisionEntity.BDPixMark2MoveBefore.Row);

            CameraVisionEntity.YDirPixToMachine = diffR / diffY;

            MessageBox.Show("标定成功! ", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            chkContinuousAcq.Checked = true;
            btnCalibrationPhotoGraph1.Enabled = false;
            btnCalibrationPhotoGraph2.Enabled = false;
            btnCount.Enabled = false;

        }


        /// <summary>
        /// 相机中心点去指定位置(鼠标按下事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hWindowControl1_HMouseDown(object sender, HalconDotNet.HMouseEventArgs e)
        {

            if((CameraVisionEntity.XDirPixToMachine == 0) || (CameraVisionEntity.YDirPixToMachine == 0)){ return; }
            if(CameraVisionEntity.BDHeight != Z_Axis.Position) { return; } //Z轴必须在标定高度位置 

            if(e.Button == MouseButtons.Left)
            {   
                //获取鼠标按下位置像素坐标
                double mouseDownRow = e.X;
                double mouseDownColumn = e.Y;

                //获取相机中心点像素坐标
                double centerRow = cemeraVisionHandleBLL.ImageWidth / 2;
                double centerColumn = cemeraVisionHandleBLL.ImageHeight / 2;

                //计算机械坐标差值
                double machineX = (mouseDownColumn - centerColumn) / CameraVisionEntity.XDirPixToMachine;
                double machineY = (mouseDownRow - centerRow) / CameraVisionEntity.YDirPixToMachine;

                //注意 是否加负号(根据XY轴实际机械方向确定)
                motionHandleBLL.CrossGoToMouseDownPoint(X_Axis,- machineX,
                                                          Y_Axis, -machineY);

            }


        }


        /// <summary>
        /// 生产界面切换不同表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataHandleBLL.GetTableData(cmbProductName.Text, processCoordAuto, out string res);
        }

        /// <summary>
        /// 自动启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async  void btnStart_Click(object sender, EventArgs e)
        {

            if (!X_Axis.OverGoHomeMark || !Y_Axis.OverGoHomeMark || !Z_Axis.OverGoHomeMark)
            {
                MessageBox.Show("回原点未完成！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvAutoDisplay.Rows.Count == 0)
            {
                MessageBox.Show("表格中没有任何数据！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (processFlowBLL.autoProcessStep != AutoProcessStep.AutomaticallyStopping)
            {
                MessageBox.Show("自动进行中！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            cmbProductName.Enabled = false; //运行过程中不允许切换表格
            btnAutoGoHome.Enabled = false; //运行过程中不允许回原点

            await processFlowBLL.AutoRunAsync();   //自动运行

            cmbProductName.Enabled = true; //自动运行结束后释放
            btnAutoGoHome.Enabled = true; //自动运行结束后释放


        }



        /// <summary>
        /// 回原点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoGoHome_Click(object sender, EventArgs e)
        {
            motionHandleBLL.AllGoHome(new Axis[] { X_Axis, Y_Axis, Z_Axis },
                                     (ushort)(radGroupGoHomeMode.SelectedIndex == 0 ? 0 : 2),
                                     2, (ushort)(radGroupGoHomeSpeedSelect.SelectedIndex == 0 ? 0 : 1));
        }


        /// <summary>
        /// 暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, EventArgs e)
        {

        }
    }
}
