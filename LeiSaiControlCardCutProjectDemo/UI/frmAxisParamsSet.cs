
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

namespace LeiSaiControlCardCutProjectDemo
{
    public partial class frmAxisParamsSet : UIForm
    {
        public frmAxisParamsSet()
        {
            InitializeComponent();
        }

        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="axes"></param>
        public frmAxisParamsSet(params Axis[] axes)
        {
            InitializeComponent();
            AxesList = axes.ToList();
        }




        /// <summary>
        /// 轴集合
        /// </summary>
        private List<Axis> AxesList;
        private void frmAxisParamsSet_Load(object sender, EventArgs e)
        {
          
            comboAxis.DisplayMember = "Axis_Name";
            comboAxis.DataSource = AxesList;
            comboAxis.SelectedIndex = 0;

        }


        /// <summary>
        /// 参数保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {   

            DataHandleBLL dataHandleBLL = new DataHandleBLL();

            for (int i = 0; i < AxesList.Count; i++)
            {
                dataHandleBLL.WriteAxisDataFromIni(AxesList[i]);
            }

            this.Close();
        }


        /// <summary>
        /// 切换显示轴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = comboAxis.SelectedIndex;
            SetTextBoxBinding(gpbJog, AxesList[num]);
            SetTextBoxBinding(gpbGoHome, AxesList[num]);
            SetTextBoxBinding(gpbAuto, AxesList[num]);
            SetTextBoxBinding(gpbSoftLimitAndPulseEquivalent, AxesList[num]);
        }

        /// <summary>
        /// 设置TextBox控件数据绑定
        /// </summary>
        /// <param name="groupBox"></param>
        private void SetTextBoxBinding(GroupBox groupBox, Axis axis)
        {
            groupBox.Controls.Cast<Control>().Where(x => x is TextBox).ToList().ForEach(x =>
            {
                x.DataBindings.Clear();
                string name = x.Name.Substring(3);
                x.DataBindings.Add("text", axis ,name, false, 
                    DataSourceUpdateMode.OnValidation);  //失去焦点时更新
            });
        }

        private void txtSpeed_JogHigh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
