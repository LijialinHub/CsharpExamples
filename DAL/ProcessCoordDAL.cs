using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    /// <summary>
    /// 加工坐标数据访问类
    /// </summary>
    public class ProcessCoordDAL
    {

        IDataBaseServer DataBaseServer { get; set; } = new AccessDBHelper();


        /// <summary>
        /// 数据库名字
        /// </summary>
        public string DbName { get; set; }

        /// <summary>
        /// 创建数据库
        /// </summary>
        public void CreateDataBase()
        {
            try
            {
                DataBaseServer.CreateDataBase(DbName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        public void DeleteDataBase() 
        {
            try
            {
                DataBaseServer.DeleteDataBase(DbName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 创建表格
        /// </summary>
        /// <param name="tableName"></param>
        public void CreateTable(string tableName)
        {
            try
            {
                string sql = $"create table" +   //primary key主键，不能重复，数据库中会自动添加
                            $"{tableName}" +
                            $"(Id int primary key, " +
                            $"Num int," +
                            $" XPosition decimal(6,2), " +
                            $"YPosition decimal(6,2), " +
                            $"ZPosition decimal(6,2) )";

                DataBaseServer.CreateTable(tableName, sql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 删除表格
        /// </summary>
        /// <param name="tableName"></param>
        public void DeleteTable(string tableName)
        {
            try
            {
                string sql = $"drop table {tableName}";
                DataBaseServer.DeleteTable(tableName, sql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="processCoordEntity"></param>
        /// <returns></returns>
        public int AddRecord(string tableName, ProcessCoordEntity processCoordEntity)
        {
            try
            {
                string sql = $"insert into {tableName}" +
                    $"(Num,XPosition,YPosition,ZPosition) " +
                    $"value(@Num,@XPosition,@YPosition,@ZPosition)";
                DbParameter[] parameters = new DbParameter[] 
                {
                    DataBaseServer.CreateParameter("@Num", processCoordEntity.Num),
                    DataBaseServer.CreateParameter("@XPosition", processCoordEntity.XPosition),
                    DataBaseServer.CreateParameter("@YPosition", processCoordEntity.YPosition),
                    DataBaseServer.CreateParameter("@ZPosition", processCoordEntity.ZPosition)
                };
               
                return DataBaseServer.ExecuteNonQuery(DbName, sql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 删除指定编号记录
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="num">要删除的编号</param>
        /// <returns>受影响行数</returns>
        public int DeleteRecord(string tableName, int num) 
        {
            try
            {
                string sql = $"delete from {tableName} where Num=@Num";
                DbParameter[] oleDbParameters = new OleDbParameter[]
                {
                    new OleDbParameter("@Num", num)
                };
                return DataBaseServer.ExecuteNonQuery(DbName, sql, oleDbParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }

        /// <summary>
        /// 删除所有记录
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="num">要删除的编号</param>
        /// <returns>受影响行数</returns>
        public int DeleteAllRecord(string tableName, int num)
        {
            try
            {
                string sql = $"delete from {tableName}";
                return DataBaseServer.ExecuteNonQuery(DbName, sql);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="modifyNum"></param>
        /// <param name="processCoordEntity"></param>
        /// <returns></returns>
        public int ModifyRecord(string tableName,int modifyNum, ProcessCoordEntity processCoordEntity)
        {
            try
            {
                string sql = $"update {tableName} " +
                    $"set XPosition=@XPosition, YPosition=@YPosition, ZPosition=@ZPosition" +
                    $"where Num=@Num";

                DbParameter[] dbParameters = new DbParameter[]
                {
                    DataBaseServer.CreateParameter("@XPosition", processCoordEntity.XPosition),
                    DataBaseServer.CreateParameter("@YPosition", processCoordEntity.YPosition),
                    DataBaseServer.CreateParameter("@ZPosition", processCoordEntity.ZPosition),
                    DataBaseServer.CreateParameter("@Num", processCoordEntity.Num)
                };

                return DataBaseServer.ExecuteNonQuery(DbName, sql, dbParameters);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取表名
        /// </summary>
        /// <returns></returns>
        public List<string> GetTableName()
        {
            try
            {
                return DataBaseServer.GetTableNames(DbName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
