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
    public partial class frmProductInfo : UIForm
    {   

        DataHandleBLL DataHandleBLL = new DataHandleBLL();

        /// <summary>
        /// 当前页码
        /// </summary>
        private int currentPageNum = 1;

        public frmProductInfo()
        {
            InitializeComponent();
        }

        private void frmProductInfo_Load(object sender, EventArgs e)
        {
            dgvProductInfo.AutoGenerateColumns = false;
            DataHandleBLL.QueryProviousPageProductRecord(ref currentPageNum, 
                                                    out string res, 
                                                    out List<ProductInfoEntity> products);

            dgvProductInfo.DataSource = null;
            dgvProductInfo.DataSource = products;
            lblPages.Text = currentPageNum.ToString();


        }

        


        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            DataHandleBLL.QueryProviousPageProductRecord(ref currentPageNum,
                                                   out string res,
                                                   out List<ProductInfoEntity> products);

            dgvProductInfo.DataSource = null;
            dgvProductInfo.DataSource = products;
            lblPages.Text = currentPageNum.ToString();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            DataHandleBLL.QueryNextPageProductRecord(ref currentPageNum,
                                                   out string res,
                                                   out List<ProductInfoEntity> products);

            dgvProductInfo.DataSource = null;
            dgvProductInfo.DataSource = products;
            lblPages.Text = currentPageNum.ToString();
        }
    }
}
