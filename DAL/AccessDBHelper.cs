using System;
using System.Collections.Generic;
using System.Configuration; //配置文件管理类
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOX;
using IniHelper;
using System.Data.OleDb;
using System.Data; //Access数据库ADO组件在这个里面

namespace DAL
{   
    /*数据库是一个服务器,pc端编写客户端程序
     * 常用的关系型数据库: Access(旧，收费，Windows系统自带)
     *                     SQL Server(微软，商业收费，C#支持性好)
     *                     MySQL(开源免费，中小型)
     *                     SQLite(开源免费，小型/轻量型)
     *                     Oracle(甲骨文 收费，大中小，功能最强)
     *关系型数据库本质是表的集合，一个数据库可以有多个表格
     */

    /*ADO.NET技术（数据库访问技术，使用SQL语句）
     * 包含的主要组件：
     * 1. Connection:连接数据库
     * 2. Command:命令(增删改)
     * 3. DataReader: 读一行记录(用于查询)
     * 4. DataAdapter: 数据适配器(用于查询),返回数据库中的表格
     * 5. DataSet: 内存数据库
     * 6. DataTable: 内存表
     */

    /*EF框架(数据库访问技术，使用Linq语句)
     */

    /*数据库服务类基本需要
     * 1.创建数据库
     * 2.删除数据库
     * 3.创建表格
     * 4.删除表格
     * 5.新增记录(一行数据)  6.删除记录  7.修改记录  8.查询记录
     */

    /// <summary>
    /// Access数据库服务类
    /// </summary>
    public class AccessDBHelper
    {
        
        //Provider=Microsoft.ACE.OLEDB.12.0;
        //Data Source = C:\Users\Lijialin\Desktop\AccessTest\Test1.accdb

        public static string connectionFixStr = ConfigurationManager.ConnectionStrings["AccessDB1"].ConnectionString;


        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="dbName"></param>
        public static void CreateDataBase(string dbName)
        {
            try
            {
                //Accesss数据库创建固定语法(需要引用Com中的ADOX)
                Catalog catalog = new Catalog();
                catalog.Create(connectionFixStr + dbName);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="dbName"></param>
        public static void DeleteDataBase(string dbName)
        {
            try
            {
                File.Delete(dbName);   //仅限于Access数据库，其他数据库要写SQL语句
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 创建表格
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="sql"></param>
        public static void CreateTable(string dbName, string sql)
        {
            //1.创建连接对象
            OleDbConnection oleDbConnection = new OleDbConnection(connectionFixStr + dbName);
            //2.创建命令对象
            OleDbCommand oleDbCommand = new OleDbCommand(sql, oleDbConnection);
            try
            {
                //3.打开数据库
                oleDbConnection.Open();
                //4.执行非查询命令
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally //无论是否抛出异常，都会执行
            {
                if(oleDbConnection.State == ConnectionState.Open)
                {
                    oleDbConnection.Close(); //关闭并释放资源
                }
            }
            
        }

        /// <summary>
        /// 删除表格
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="sql"></param>
        public static void DeleteTable(string dbName, string sql)
        {
            //1.创建连接对象
            OleDbConnection oleDbConnection = new OleDbConnection(connectionFixStr + dbName);
            //2.创建命令对象
            OleDbCommand oleDbCommand = new OleDbCommand(sql, oleDbConnection);
            try
            {
                //3.打开数据库
                oleDbConnection.Open();
                //4.执行非查询命令
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally //无论是否抛出异常，都会执行
            {
                if (oleDbConnection.State == ConnectionState.Open)
                {
                    oleDbConnection.Close(); //关闭并释放资源
                }
            }

        }

        /// <summary>
        /// 执行非查询命令
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>受影响行数</returns>
        public static int ExecuteNonQuery(string dbName, string sql, OleDbParameter[] parameters = null)
        {
            //1.创建连接对象
            OleDbConnection oleDbConnection = new OleDbConnection(connectionFixStr + dbName);
            //2.创建命令对象
            OleDbCommand oleDbCommand = new OleDbCommand(sql, oleDbConnection);
            try
            {
                //3.打开数据库
                oleDbConnection.Open();

                if (parameters != null)
                {
                    oleDbCommand.Parameters.AddRange(parameters);
                }

                //4.执行非查询命令
                return oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally //无论是否抛出异常，都会执行
            {
                if (oleDbConnection.State == ConnectionState.Open)
                {
                    oleDbConnection.Close(); //关闭并释放资源
                }
            }
        }


    }
}
