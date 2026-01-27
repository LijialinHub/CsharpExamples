using PanelSeparationMachineV1._26;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanelSeparationMachineV1._26
{
    public partial class frmDrawParams : UIForm
    {
        public frmDrawParams()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDrawParams_Load(object sender, EventArgs e)
        {
            nudXAxisScalar.DataBindings.Add("Value", frmMain.DrawParamsEntity, "XDrawScale", false, DataSourceUpdateMode.OnPropertyChanged);
            nudYAxisScalar.DataBindings.Add("Value", frmMain.DrawParamsEntity, "YDrawScale", false, DataSourceUpdateMode.OnPropertyChanged);
            nudXOffset.DataBindings.Add("value", frmMain.DrawParamsEntity, "XDrawOffset", false, DataSourceUpdateMode.OnPropertyChanged);
            nudYOffset.DataBindings.Add("value", frmMain.DrawParamsEntity, "YDrawOffset", false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
