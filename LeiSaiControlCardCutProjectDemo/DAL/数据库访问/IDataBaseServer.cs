using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{   
    /// <summary>
    /// 数据库服务接口
    /// </summary>
    public interface IDataBaseServer  //接口默认就是public
                               //接口所有成员都是未实现的(相当于抽象)，只能正常子类实现
                               //一个类可以继承多个接口，只能继承一个类
    {

        string ConnectionFixStr { get; }

        /// <summary>
        /// 判断数据库是否存在
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        bool IsDataBaseExist(string dbName);

        /// <summary>
        /// 创建数据库参数对象
        /// </summary>
        /// <param name="parameterName">变量名</param>
        /// <param name="value">实参值</param>
        /// <returns></returns>
        DbParameter CreateParameter(string parameterName, object value);

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="dbName"></param>
        void CreateDataBase(string dbName);

        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="dbName"></param>
        void DeleteDataBase(string dbName);

        /// <summary>
        /// 创建表格
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="sql"></param>
        void CreateTable(string dbName, string sql);

        /// <summary>
        /// 删除表格
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="sql"></param>
        void DeleteTable(string dbName, string sql);

        /// <summary>
        /// 执行非查询命令
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>受影响行数</returns>
        int ExecuteNonQuery(string dbName, string sql, DbParameter[] dbParameters = null);

        /// <summary>
        /// 获取数据库数据到内存
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        DataSet GetDataSet(string dbName, string sql, DbParameter[] dbParameters = null);

        /// <summary>
        /// 标量查询(最大值 最小值 平均值...)
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="sql"></param>
        /// <param name="oleDbParameters"></param>
        /// <returns>第一行的第一列结果</returns>
        object ExecuteScalar(string dbName, string sql, DbParameter[] dbParameters = null);

        /// <summary>
        /// 逐行查询
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="sql">sql语句</param>
        /// <param name="oleDbParameters">sql语句参数</param>
        /// <returns>OledbDataReader逐行读取对象</returns>
        DbDataReader ExecuteDataReader(string dbName, string sql, DbParameter[] dbParameters = null);

        /// <summary>
        /// 读取数据库中的表格名
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        List<string> GetTableNames(string dbName);

    }
}
