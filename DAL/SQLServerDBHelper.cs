using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

        public void CreateDataBase(string dbName)
        {
            throw new NotImplementedException();
        }

        public void CreateTable(string dbName, string sql)
        {
            throw new NotImplementedException();
        }

        public void DeleteDataBase(string dbName)
        {
            throw new NotImplementedException();
        }

        public void DeleteTable(string dbName, string sql)
        {
            throw new NotImplementedException();
        }

        public DbDataReader ExecuteDataReader(string dbName, string sql, DbParameter[] dbParameters = null)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string dbName, string sql, DbParameter[] dbParameters = null)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string dbName, string sql, DbParameter[] dbParameters = null)
        {
            throw new NotImplementedException();
        }

        public DataSet GetDataSet(string dbName, string sql, DbParameter[] dbParameters = null)
        {
            throw new NotImplementedException();
        }

        public List<string> GetTableNames(string dbName)
        {
            throw new NotImplementedException();
        }
    }

}
