using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;
using Sunny.UI;


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
        private DataHandleBLL DataHandleBLL = new DataHandleBLL();

        #endregion

        #region 实体

        /// <summary>
        /// 相机视觉参数实体对象
        /// </summary>
        private CameraVisionEntity CameraVisionEntity = new CameraVisionEntity();

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
            #region 相机和图像

            DataHandleBLL.ReadCameraVisionFromIni(CameraVisionEntity);

            cemeraVisionHandleBLL = new CemeraVisionHandleBLL(hWindowControl1);
            cemeraVisionHandleBLL.OpenCamera(CameraVisionEntity.StrSN);
            cemeraVisionHandleBLL.SingleAcq();

            #endregion
        }


        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            #region 相机和图像

            DataHandleBLL.WriteCameraVisionToIni(CameraVisionEntity);
            cemeraVisionHandleBLL.CloseCamera(); //关闭相机

            #endregion

            Environment.Exit(0); //退出程序
        }
    }
}
