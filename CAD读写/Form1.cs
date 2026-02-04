using netDxf;
using netDxf.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAD读写
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 文档类
        /// </summary>
        private DxfDocument dxf;

        /// <summary>
        /// 直线实体集合
        /// </summary>
        private List<Line> listLines = new List<Line>();

        /// <summary>
        /// 圆弧实体集合
        /// </summary>
        private List <Arc> listArc = new List<Arc>();

        /// <summary>
        /// 圆实体集合
        /// </summary>
        private List<Circle> listCircle = new List<Circle>();

        /// <summary>
        /// CAD数据实体集合
        /// </summary>
        private List<CadData> listCadDatas = new List<CadData>();

        /// <summary>
        /// 绘图工具
        /// </summary>
        private Graphics gp;

        /// <summary>
        /// 画布 bmp格式图片
        /// </summary>
        private Bitmap bp;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
