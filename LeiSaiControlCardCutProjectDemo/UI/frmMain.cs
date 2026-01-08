using BLL;
using Entity;
using Sunny;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeiSaiControlCardCutProjectDemo
{
    public partial class frmMain : UIForm
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
        public Axis X_Axis = new Axis() { Axis_CardNo = 0, Axis_Num = 0, Axis_Name = "X轴"};
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
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            //从Ini文件读取绘图参数
            dataHandleBLL.ReadDrawParamFromIni(DrawParamsEntity);

            dataHandleBLL.ReadAxisDataFromIni(X_Axis);
            dataHandleBLL.ReadAxisDataFromIni(Y_Axis);
            dataHandleBLL.ReadAxisDataFromIni(Z_Axis);
            dataHandleBLL.ReadIOCraftEntityFromIni(IOCraftEntity);


            //表名集合绑定cmbProductName控件
            cmbProductNames.DataSource = tableNames;

            //加工坐标点集合绑定dgvDisplay控件
            dgvDisplay.AutoGenerateColumns = false;  //不自动创建列 按照指定的来
            dgvDisplay.DataSource = processCoordEntities;

            drawHandleBLL = new DrawHandleBLL(picDisplay);
            drawHandleBLL.CoordinatesReset();

            radGroupGoHomeMode.SelectedIndex = 1;
            radGroupGoHomeSpeedSelect.SelectedIndex = 1;
            radGroupAutoSelect.SelectedIndex = 1;

        }

        

        private void uiImageButton1_Click(object sender, EventArgs e)
        {
            btnEms.Selected = btnEms.Selected ? false : true;
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataHandleBLL.SaveDrawParamToIni(DrawParamsEntity);
            dataHandleBLL.WriteIOCraftEntityToIni(IOCraftEntity);




            Environment.Exit(0);    
        }

        private void 绘图参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrawParams frmDrawParams = new frmDrawParams();
            frmDrawParams.Show();
        }

        private void 参数窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAxisParamsSet frmAxisParamsSet = new frmAxisParamsSet(X_Axis, Y_Axis, Z_Axis);
            frmAxisParamsSet.Show();
        }

        /// <summary>
        /// 每间隔200ms更新一次UI数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

            #region 位置显示

            lblPositionX.Value = X_Axis.Position;
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

            gpbAxisStatus.Controls.Cast<Control>().Where(light => light is UILight).
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

                txtXRunSpeed.Text = X_Axis.RunningSpeed.ToString();
                txtYRunSpeed.Text = Y_Axis.RunningSpeed.ToString();
                txtZRunSpeed.Text = Z_Axis.RunningSpeed.ToString();


            });

            #endregion

            #region 自动运行状态

            uiLightCuterStatus.State = IOCraftEntity.Cutter.StatusValue ? UILightState.On : UILightState.Off;

            #endregion

        }


    }
}
