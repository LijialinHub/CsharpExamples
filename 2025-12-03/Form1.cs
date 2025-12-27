using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_12_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            try
            {   
                string path = Environment.CurrentDirectory + "\\" + txtFileName.Text;
                
                if(!File.Exists(path))
                {
                    using (FileStream fs = File.Create(path)) { }  
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCopyFile_Click(object sender, EventArgs e)
        {
            string SourcePath = Environment.CurrentDirectory + "\\" + txtFileName.Text;
            string DstPath = Environment.CurrentDirectory + "\\Copy" + txtFileName.Text;

            if (File.Exists(SourcePath))
            {
                File.Copy(SourcePath, DstPath);
            }

        }

        private void btnMoveFile_Click(object sender, EventArgs e)
        {
            string SourcePath = Environment.CurrentDirectory + "\\" + txtFileName.Text;
            string DstPath = "../Move" + txtFileName.Text;

            if (File.Exists(SourcePath))
            {
                File.Move(SourcePath, DstPath);
            }
        }

        private void btnDelFile_Click(object sender, EventArgs e)
        {
            try
            {
                if(File.Exists(txtFileName.Text))
                {
                    File.Delete(txtFileName.Text);
                }
            }
            catch (Exception)
            {

                
            }
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            txtFileDisplay.Clear();
            txtFileDisplay.Text = File.ReadAllText(txtFileName.Text);
        }

        private void btnWriteFile_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(txtFileName.Text, txtFileDisplay.Text);
            }
            catch (Exception)
            {

                
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择文件夹";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtFolderPath.Text = folderBrowserDialog.SelectedPath;
                //获取文件夹名称
                //int startIndex = folderBrowserDialog.SelectedPath.LastIndexOf(@"\");
                //txtFolderName.Text = folderBrowserDialog.SelectedPath.Substring(startIndex+1);

                txtFolderName.Text = Path.GetFileName(folderBrowserDialog.SelectedPath);

                //Path类用法
                //string str1 = Path.Combine("1", "2", "3"); // 1/2/3   合并路径
                //Path.GetExtension 获取后缀

            }
        }

        private void btnMoveFolder_Click(object sender, EventArgs e)
        {
            Directory.Move(txtFolderPath.Text, "D:\\Csharp\\classCodes\\2025-12-03\\bin\\123");
        }

        private void btnDelFolder_Click(object sender, EventArgs e)
        {
            //Directory类，专门处理文件夹的类
            //常用方法 ：CreateDirectory、Delete、Exists、GetCreationTime、
            //GetDiretories 获取文件夹中子文件夹路径
            //GetFiles 获取文件夹中的文件路径
            //Move

            //Directory.Delete(txtFolderPath.Text);
            Directory.Delete(txtFolderPath.Text, true);

        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(txtFolderPath.Text);

        }
    }
}
