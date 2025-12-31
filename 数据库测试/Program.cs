using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace 数据库测试
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dbName = Environment.CurrentDirectory + @"\Test.accdb";
            AccessDBHelper accessDBHelper = new AccessDBHelper();
            accessDBHelper.CreateDataBase(dbName);

            //创建表格 (表名 学生表 字段 编号整数 姓名文本 性别文本 成绩小数)
            string sqlCreateTable = "create table 学生表(编号 int, 姓名 nvarchar(4), 性别 nvarchar(1), 成绩 decimal(5,2))";
            
            accessDBHelper.CreateTable(dbName, sqlCreateTable);

            //删除表格
            string sqlDeleteTable = "drop table 学生表";
            //AccessDBHelper.DeleteTable(dbName, sqlDeleteTable);

            //新增记录
            string sqlInsert = "insert into 学生表(编号, 姓名, 性别, 成绩)"+
                                         "values(1, '李佳霖','男',100.0)";
            //在sql语句中，前边加@ 表示变量
            string sqlInsert2 = "insert into 学生表(编号, 姓名, 性别, 成绩)"+
                                "values(@Id, @Name,@Sex,@Score)";

            //不可以乱序添加
            OleDbParameter[] parameters = new OleDbParameter[]
            {
                new OleDbParameter("@Id", 1),
                new OleDbParameter("@Name", "李佳霖"),
                new OleDbParameter("@Sex", "男"),
                new OleDbParameter("@Score", 100.0),

            };

            //AccessDBHelper.ExecuteNonQuery(dbName, sqlInsert2, parameters);

            //删除记录
            string sqlDelete = "delete from 学生表 where 性别='男'";
            string sqlDelete2 = "delete from 学生表 where 成绩 < 60";
            //AccessDBHelper.ExecuteNonQuery(dbName, sqlDelete2);

            //修改记录
            string sqlModify = "update 学生表 set 成绩=成绩+5 where 成绩<=90";
            //AccessDBHelper.ExecuteNonQuery(dbName, sqlModify);


            

            //查询
            string sqlSelect1 = "select * from 学生表";
            DataSet dataSet1 = accessDBHelper.GetDataSet(dbName, sqlSelect1);
            DataTable dataTable1 = dataSet1.Tables[0];

            //聚合函数 + 标量查询 
            string sqlQuery2 = "select count(*) from 学生表";
            object res1 = accessDBHelper.ExecuteScalar(dbName, sqlQuery2);

            //string sqlQuery3 = "select avg(成绩) from 学生表";
            //object res2 = AccessDBHelper.ExecuteScalar(dbName, sqlQuery3);

            string sqlQuery4 = "select min(成绩) from 学生表";
            object res3 = accessDBHelper.ExecuteScalar(dbName, sqlQuery4);

            string sqlQuery5 = "select max(成绩) from 学生表";
            object res4 = accessDBHelper.ExecuteScalar(dbName, sqlQuery5);

            string sqlQuery6 = "select sum(成绩) from 学生表";
            object res5 = accessDBHelper.ExecuteScalar(dbName, sqlQuery6);

            //逐行查询
            DbDataReader oleDbDataReader = accessDBHelper.ExecuteDataReader(dbName, sqlSelect1);
            while (oleDbDataReader.Read())
            {
                Console.WriteLine($"{oleDbDataReader["编号"]} {oleDbDataReader["姓名"]} {oleDbDataReader["性别"]} {oleDbDataReader["成绩"]} ");
            }
            oleDbDataReader.Close();

            //获取所有表名
            List<string> tablesName = accessDBHelper.GetTableNames(dbName);
        }
    }
}
