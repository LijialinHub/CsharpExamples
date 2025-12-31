using System;
using System.Collections.Generic;
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
            string dbName = Environment.CurrentDirectory + @"\Test12.accdb";
            AccessDBHelper.CreateDataBase(dbName);
        }
    }
}
