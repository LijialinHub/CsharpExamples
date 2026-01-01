using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SQLServerDBHelper : IDataBaseServer
    {
        public string ConnectionFixStr
        {

            get
            {
                return "";
            }
        }

        /// <summary>
        /// 判断数据库是否存在
        /// </summary>
        /// <param name="dbName">数据库名或者路径</param>
        /// <returns>True:存在 False:不存在</returns>
        public bool IsDataBaseExist(string dbName)
        {
            return true;
        }

        /// <summary>
        /// 创建数据库参数对象
        /// </summary>
        /// <param name="parameterName">变量名</param>
        /// <param name="value">实参值</param>
        /// <returns></returns>
        public DbParameter CreateParameter(string parameterName, object value)
        {
            return new SqlParameter(parameterName, value);
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="dbName"></param>
        public void CreateDataBase(string dbName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建表格
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="sql"></param>
        public void CreateTable(string dbName, string sql)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="dbName"></param>
        public void DeleteDataBase(string dbName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除表格
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="sql"></param>
        public void DeleteTable(string dbName, string sql)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 逐行查询
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="sql">sql语句</param>
        /// <param name="oleDbParameters">sql语句参数</param>
        /// <returns>OledbDataReader逐行读取对象</returns>
        public DbDataReader ExecuteDataReader(string dbName, string sql, DbParameter[] dbParameters = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行非查询命令
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>受影响行数</returns>
        public int ExecuteNonQuery(string dbName, string sql, DbParameter[] dbParameters = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 标量查询(最大值 最小值 平均值...)
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="sql"></param>
        /// <param name="oleDbParameters"></param>
        /// <returns>第一行的第一列结果</returns>
        public object ExecuteScalar(string dbName, string sql, DbParameter[] dbParameters = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取数据库数据到内存
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string dbName, string sql, DbParameter[] dbParameters = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 读取数据库中的表格名
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public List<string> GetTableNames(string dbName)
        {
            throw new NotImplementedException();
        }

       
    }

}
