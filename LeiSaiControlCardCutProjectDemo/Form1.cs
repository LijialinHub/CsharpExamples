using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny;
using Sunny.UI;

namespace LeiSaiControlCardCutProjectDemo
{
    public partial class Form1 : UIForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void uiNavMenu1_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {

        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiGroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void uiCheckBoxGroup1_ValueChanged(object sender, CheckBoxGroupEventArgs e)
        {

        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {
            imgBtnEmergencyStop.Selected = imgBtnEmergencyStop.Selected ? false : true;
        }
    }
}
