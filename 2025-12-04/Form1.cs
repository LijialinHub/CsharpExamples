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

namespace _2025_12_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.SelectedPath;
                GetDirectoryInfo(path);  //递归 获取一个文件夹下的所有文件信息 包括子文件夹下的文件
            }
        }


        /// <summary>
        /// 递归获取文件夹下的所有文件(包括子文件夹下的文件)
        /// </summary>
        /// <param name="path"></param>
        private void GetDirectoryInfo(string path)
        {
            string[] filePaths = Directory.GetFiles(path); //文件夹中文件路径
            string[] fileFolderPaths = Directory.GetDirectories(path);//文件夹中子文件夹路径

            foreach (var item in filePaths)
            {
                //FileInfo类和File类都是用来处理文件的
                //File类是静态类,FileInfo类是实例类
                string name = Path.GetFileName(item);   //文件名
                string filePath = Path.GetFullPath(item); //完整路径
                FileInfo fileInfo = new FileInfo(filePath);
                string fileSize = fileInfo.Length.ToString();
                string createDate = fileInfo.CreationTime.ToString();

                //Add Remove Replace Insert Clear Contains
                ListViewItem listViewItem = new ListViewItem(name);
                listViewItem.ForeColor = Color.Red;
                listViewItem.Font = new Font("宋体", 15);

                listViewItem.SubItems.Add(filePath);
                listViewItem.SubItems.Add(fileSize);
                listViewItem.SubItems.Add(createDate);

                listViewDisplay.Items.Add(listViewItem);
            }

            foreach (var item in fileFolderPaths)
            {
                GetDirectoryInfo(item);
            }

        }


        /// <summary>
        /// 递归方法获取文件夹大小
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private long GetDirectorySize(string path)
        {
            long size = 0;
            string[] filePaths = Directory.GetFiles(path); //文件夹中文件路径
            string[] fileFolderPaths = Directory.GetDirectories(path);//文件夹中子文件夹路径

            foreach (var item in filePaths)
            {
                FileInfo fileInfo = new FileInfo(item);
                size+= fileInfo.Length;
            }

            foreach (var item in fileFolderPaths)
            {
                size += GetDirectorySize(item);
            }
            return size;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
