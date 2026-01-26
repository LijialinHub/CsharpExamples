using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Security.Permissions;
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

        public IDataBaseServer DataBaseServer { get; set; }


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
                string sql = $"create table " +   //primary key主键，不能重复，数据库中会自动添加
                            $"{tableName} " +
                            $"(Id autoincrement primary key, " +
                            $"Num int," +
                            $" XPosition decimal(10,4), " +
                            $"YPosition decimal(10,4), " +
                            $"ZPosition decimal(10,4) )";

                DataBaseServer.CreateTable(DbName, sql);
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
                DataBaseServer.DeleteTable(DbName, sql);
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
                string sql = $"insert into {tableName} " +
                    $"(Num,XPosition,YPosition,ZPosition) " +
                    $"values(@Num,@XPosition,@YPosition,@ZPosition)";
                DbParameter[] parameters = new DbParameter[] 
                {
                    DataBaseServer.CreateParameter("@Num", processCoordEntity.Num),
                    DataBaseServer.CreateParameter("@XPosition", processCoordEntity.XPosition),
                    DataBaseServer.CreateParameter("@YPosition", processCoordEntity.YPosition),
                    DataBaseServer.CreateParameter("@ZPosition", processCoordEntity.ZPosition)
                };
               
                return DataBaseServer.ExecuteNonQuery(DbName, sql, parameters);
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
        public int DeleteAllRecord(string tableName)
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
                //string sql = $"update {tableName} " +
                //    $"set XPosition=@XPosition, YPosition=@YPosition, ZPosition=@ZPosition " +
                //    $"where Num=@Num";


                string sql = $"update {tableName} " +
                             $"set XPosition = @XPosition, YPosition = @YPosition, ZPosition = @ZPosition " +
                             $"where Num = @Num";


                DbParameter[] dbParameters = new DbParameter[]
                {
                    DataBaseServer.CreateParameter("@XPosition", processCoordEntity.XPosition),
                    DataBaseServer.CreateParameter("@YPosition", processCoordEntity.YPosition),
                    DataBaseServer.CreateParameter("@ZPosition", processCoordEntity.ZPosition),
                    DataBaseServer.CreateParameter("@Num", modifyNum)
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

        /// <summary>
        /// 获取坐标点集合
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>坐标点集合对象</returns>
        public List<ProcessCoordEntity> GetCoordList(string tableName) 
        {
            try
            {
                List<ProcessCoordEntity> list = new List<ProcessCoordEntity>();
                string sql = $"select * from {tableName} order by Num asc"; //asc:升序 des:降序
                DbDataReader dbDataReader = DataBaseServer.ExecuteDataReader(DbName, sql);

                while (true)
                {
                    bool hasRow = dbDataReader.Read();
                    if (!hasRow) { break; }
                    ProcessCoordEntity coord = new ProcessCoordEntity()
                    {
                        Num = int.Parse(dbDataReader["Num"].ToString()),
                        XPosition = double.Parse(dbDataReader["XPosition"].ToString()),
                        YPosition = double.Parse(dbDataReader["YPosition"].ToString()),
                        ZPosition = double.Parse(dbDataReader["ZPosition"].ToString())
                    };
                    list.Add(coord);
                }
                dbDataReader.Close();
                return list;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
        /// <summary>
        /// 获取最大编号值
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>最大编号值</returns>
        public int GetMaxNum(string tableName)
        {
            try
            {
                string sql = $"select Max(Num) from {tableName}";
                object obj = DataBaseServer.ExecuteScalar(DbName,sql);
                int num = (int)obj;
                return num;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="num"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public int InsertRecord(string tableName, int num, ProcessCoordEntity coord)
        {
            try
            {
                //1.修改要插入编号以及后面记录的所有编号，加1
                string sql = $"update {tableName} set Num=Num+1 where Num>=@Num";
                OleDbParameter[] oleDbParameter = new OleDbParameter[]
                {
                    new OleDbParameter("@Num",num)
                };

                DataBaseServer.ExecuteNonQuery(DbName, sql, oleDbParameter);
                //2.添加
                coord.Num = num;
                return AddRecord(tableName, coord);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
