using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_30
{
    public partial class frmDrawParams : Form
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
            nudXAxisScalar.DataBindings.Add("Value", frmMain.DrawParams, "XDrawScale", false, DataSourceUpdateMode.OnPropertyChanged);
            nudYAxisScalar.DataBindings.Add("Value", frmMain.DrawParams, "YDrawScale", false, DataSourceUpdateMode.OnPropertyChanged);
            nudXOffset.DataBindings.Add("value", frmMain.DrawParams, "XDrawOffset", false, DataSourceUpdateMode.OnPropertyChanged);
            nudYOffset.DataBindings.Add("value", frmMain.DrawParams, "YDrawOffset", false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
