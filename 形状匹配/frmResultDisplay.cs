using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 形状匹配
{
    public partial class frmResultDisplay : Form
    {
        public frmResultDisplay(List<PixelCoord> pixelCoords)
        {
            InitializeComponent();
            //不自动生成列
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = pixelCoords;
        }

        private void frmResultDisplay_Load(object sender, EventArgs e)
        {

        }
    }
}
