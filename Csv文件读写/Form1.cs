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


namespace Csv文件读写
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 写入CSV文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteCsv_Click(object sender, EventArgs e)
        {
            if (dgvDisplay.Rows.Count == 0) { return; }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "请选择保存路径";
            saveFileDialog.Filter = "CSV文件|*.csv";



            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string filePath = saveFileDialog.FileName;

                    this.Text = filePath;

                    using (StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.Default))
                    {
                        string header = "";
                        for (global::System.Int32 i = 0; i < dgvDisplay.Columns.Count; i++)
                        {
                            header += dgvDisplay.Columns[i].HeaderText + ",";
                        }

                        header.Substring(0, header.Length - 1);
                        streamWriter.WriteLine(header);   //写入了列标题

                        //写入每行数据 Linq
                        for (global::System.Int32 i = 0; i < dgvDisplay.Rows.Count-1; i++)
                        {

                            string rowData = "";

                            for (global::System.Int32 j = 0; j < dgvDisplay.Rows[i].Cells.Count; j++)
                            {
                                rowData += dgvDisplay.Rows[i].Cells[j].Value.ToString() + ",";
                            }
                            rowData.Substring(0, rowData.Length - 1);
                            streamWriter.WriteLine(rowData);

                        }


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }



        }

        /// <summary>
        /// 读取CSV文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadCsv_Click(object sender, EventArgs e)
        {
            

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "请选择CSV文件";
            openFileDialog.Filter = "CSV文件|*.csv";
            openFileDialog.Multiselect = false; // 只能选择一个文件

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            { 
                string filePath = openFileDialog.FileName;

                this.Text = filePath;

                dgvDisplay.Columns.Clear();
                using (StreamReader streamReader = new StreamReader(filePath, Encoding.Default))
                {   
                    //读取第一行
                    string line = streamReader.ReadLine();
                    //添加到表格中
                    //dgvDisplay.Columns.AddRange(line.Split(',').Select(columnName => new DataGridViewTextBoxColumn { HeaderText = columnName }).ToArray());

                    var colHeads = line.Split(',');
                    colHeads.All(str => dgvDisplay.Columns.Add($"N_{str}", str) >= 0);
                    
                    //读取行数据
                    while(true)
                    {
                        string rowData = streamReader.ReadLine();
                        if (rowData == null)
                        {
                            break;
                        }

                        //var rowDatas = line.Split(',');
                        dgvDisplay.Rows.Add(rowData.Split(','));
                    }

                    
                }
               
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
