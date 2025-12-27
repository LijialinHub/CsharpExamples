using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_11_28
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //图像
        private List<Image> images = new List<Image>();
        private int ImageIndex = 0;

        private void btnOpenImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); //创建对话框对象
            openFileDialog.Multiselect = true;  //允许多选文件
            openFileDialog.Title = "打开图像";  //标题
            //括号里是解释 括号后是格式
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            images.Clear();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] imagePaths = openFileDialog.FileNames;
                picDisplay.Image = Image.FromFile(imagePaths[0]);

                foreach (string path in imagePaths) 
                {
                    images.Add(Image.FromFile(path));
                }
            }
           

        }

        /// <summary>
        /// 上一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {

            try
            {
                ImageIndex++;
                ImageIndex = ImageIndex > images.Count - 1 ? 0 : ImageIndex;
                picDisplay.Image = images[ImageIndex];
            }
            catch (Exception ex)
            {

                //throw ex;
            }
            
        }

        /// <summary>
        /// 下一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {

            try
            {
                ImageIndex--;
                ImageIndex = ImageIndex < 0 ? images.Count - 1 : ImageIndex;
                picDisplay.Image = images[ImageIndex];
            }
            catch (Exception ex)
            {

                //throw ex;
            }
        }

        private void btnSaveImg_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Title = "保存图像";
                saveFileDialog.Filter = "bmp|*.bmp|png|*.png|jpg|*.jpg";
                if(saveFileDialog.ShowDialog() == DialogResult.OK && picDisplay.Image!=null)
                {
                    string path = saveFileDialog.FileName;
                    picDisplay.Image.Save(path);
                    MessageBox.Show($"保存成功,位于{path}", "提示",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
            }
        }
    }
}
