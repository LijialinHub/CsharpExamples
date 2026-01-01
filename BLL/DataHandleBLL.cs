using DAL;
using Entity;
using IniHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{   

    /// <summary>
    /// 数据处理业务逻辑
    /// </summary>
    public class DataHandleBLL
    {

        /// <summary>
        /// 加工坐标数据访问工具对象
        /// </summary>
        private ProcessCoordDAL ProcessCoordDAL = new ProcessCoordDAL() 
        { 
            DataBaseServer = new AccessDBHelper() 
        }; //默认使用Access数据库

        /// <summary>
        /// 保存绘图参数到Ini文件
        /// </summary>
        /// <param name="drawParams">绘图参数实体</param>
        public void SaveDrawParamToIni(DrawParamsEntity drawParams)
        {
            IniFiles iniFiles = new IniFiles(Environment.CurrentDirectory + @"\参数.ini");
            iniFiles.WriteString("绘图参数", "X轴缩放比例", drawParams.XDrawScale.ToString());
            iniFiles.WriteString("绘图参数", "Y轴缩放比例", drawParams.YDrawScale.ToString());
            iniFiles.WriteString("绘图参数", "X轴偏移", drawParams.XDrawOffset.ToString());
            iniFiles.WriteString("绘图参数", "Y轴偏移", drawParams.YDrawOffset.ToString());
        }


        /// <summary>
        /// 从Ini文件读取绘图参数
        /// </summary>
        /// <param name="drawParams">绘图参数实体</param>
        public void ReadDrawParamFromIni(DrawParamsEntity drawParams)
        {
            IniFiles iniFiles = new IniFiles(Environment.CurrentDirectory + @"\参数.ini");
            drawParams.XDrawScale = double.Parse(iniFiles.ReadString("绘图参数", "X轴缩放比例", "1"));
            drawParams.YDrawScale = double.Parse(iniFiles.ReadString("绘图参数", "Y轴缩放比例", "1"));
            drawParams.XDrawOffset = double.Parse(iniFiles.ReadString("绘图参数", "X轴偏移", "0"));
            drawParams.YDrawOffset = double.Parse(iniFiles.ReadString("绘图参数", "Y轴偏移", "0"));
        }

        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns>True：打开成功 False：打开失败</returns>
        public bool OpenDataBase(string dbName)
        {
            if(ProcessCoordDAL.DataBaseServer.IsDataBaseExist(dbName))
            {
                ProcessCoordDAL.DbName = dbName;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="res">执行结果</param>
        /// <returns>True：创建成功 False：创建失败</returns>
        public bool CreateDataBase(string dbName, out string res)
        {
            try
            {
                ProcessCoordDAL.DbName = dbName;
                ProcessCoordDAL.CreateDataBase();
                res = "创建数据库成功！";
                return true;
            }
            catch (Exception ex)
            {
                res = "数据库创建失败！ " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 获取表名
        /// </summary>
        /// <returns></returns>
        public bool GetTableNames(BindingList<string> tableNames, out string res)
        {
            try
            {
                //BindingList是专门用于绑定的集合，
                //使用普通的List绑定，当List集合元素发生增加或者移除，绑定到的空间对象不会有变化
                //使用BindingList去绑定，当BindingList集合元素发生增加或者移除，绑定到的控件对象就会同样更新

                List<string> list = ProcessCoordDAL.GetTableName();
                tableNames.Clear();

                for (int i = 0; i < list.Count; i++)
                {
                    tableNames.Add(list[i]);
                }

                res = "获取表名成功！";
                return true;
            }
            catch (Exception ex)
            {
                res = "获取表名失败！ " + ex.Message;
                tableNames.Clear();
                return false;
            }
        }

        /// <summary>
        /// 创建表格
        /// </summary>
        /// <param name="tableName">表格名</param>
        /// <param name="res">执行结果</param>
        /// <returns>True：创建成功 False：创建失败</returns>
        public bool CreateTable(string tableName, 
                                BindingList<string> tableNames, 
                                out string res)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(tableName))
                {
                    throw new Exception("表格名称不能为空！");
                }
                if(tableNames.Contains(tableName))
                {
                    throw new Exception("表格已经存在！");
                }

                ProcessCoordDAL.CreateTable(tableName);
                GetTableNames(tableNames, out res);
                res = "创建表格成功！";
                
                return true;
            }
            catch (Exception ex)
            {

                res = "创建表格失败！ " + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 删除表格
        /// </summary>
        /// <param name="tableName">表格名</param>
        /// <param name="res">执行结果</param>
        /// <returns>True：删除成功 False：删除失败</returns>
        public bool DeleteTable(string tableName, 
                                BindingList<string> tableNames, 
                                out string res)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tableName))
                {
                    throw new Exception("表格名称不能为空！");
                }
                if (!tableNames.Contains(tableName))
                {
                    throw new Exception("表格不存在！");
                }

                ProcessCoordDAL.DeleteTable(tableName);
                GetTableNames(tableNames, out res);
                res = "删除表格成功！";
                return true;
            }
            catch (Exception ex)
            {

                res = "删除表格失败！ " + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 获取表格数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="processCoordEntities">坐标对象绑定集合</param>
        /// <param name="res">执行结果</param>
        /// <returns>True:执行成功 False:执行失败</returns>
        public bool GetTableData(string tableName, 
                                    BindingList<ProcessCoordEntity> processCoordEntities, 
                                    out string res)
        {
            try
            {
                List<ProcessCoordEntity> coordEntities = ProcessCoordDAL.GetCoordList(tableName);
                processCoordEntities.Clear();
                
                for (global::System.Int32 i = 0; i < coordEntities.Count; i++)
                {
                    processCoordEntities.Add(coordEntities[i]);
                }

                res = "读取表格数据成功！";
                return true;

            }
            catch (Exception ex)
            {
                res = "读取表格数据失败！" + ex.Message;
                processCoordEntities.Clear();
                return false;
            }
        }


        /// <summary>
        /// 添加坐标记录
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="tableNames">表名集合</param>
        /// <param name="processCoordEntity">实体对象</param>
        /// <param name="res">执行结果</param>
        /// <returns>True:执行成功 False:执行失败</returns>
        public bool AddRecord(string tableName,
                                BindingList<string> tableNames,
                                ProcessCoordEntity processCoordEntity, out string res)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(tableName))
                {
                    throw new Exception("未指定表名！");
                }
                if (!tableNames.Contains(tableName))
                {
                    throw new Exception("数据库中不存在该表格！");
                }
                int num = ProcessCoordDAL.GetMaxNum(tableName);
                processCoordEntity.Num = num + 1;

                int count = ProcessCoordDAL.AddRecord(tableName, processCoordEntity);
                res = $"成功添加 {count} 行记录";
                return true;
            }
            catch (Exception ex)
            {
                res = $"添加记录失败！ " + ex.Message;
                return false;
            }
        }

        
        /// <summary>
        /// 修改坐标记录
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="tableNames">表名集合</param>
        /// <param name="processCoordEntity">实体对象</param>
        /// <param name="res">执行结果</param>
        /// <returns>True:执行成功 False:执行失败</returns>
        public bool ModifyRecord(string tableName, 
                                    BindingList<string> tableNames, int id,
                                    ProcessCoordEntity processCoordEntity,
                                    out string res)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tableName))
                {
                    throw new Exception("未指定表名！");
                }
                if (!tableNames.Contains(tableName))
                {
                    throw new Exception("数据库中不存在该表格！");
                }
                
                int count = ProcessCoordDAL.ModifyRecord(tableName, id, processCoordEntity);
                res = $"成功修改 {count} 行记录";
                return true;
            }
            catch (Exception ex)
            {
                res = $"修改记录失败！ " + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 删除坐标记录
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="tableNames">表名集合</param>
        /// <param name="processCoordEntity">实体对象</param>
        /// <param name="res">执行结果</param>
        /// <returns>True:执行成功 False:执行失败</returns>
        public bool DeleteRecord(string tableName,
                                    BindingList<string> tableNames, int num,
                                    out string res)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tableName))
                {
                    throw new Exception("未指定表名！");
                }
                if (!tableNames.Contains(tableName))
                {
                    throw new Exception("数据库中不存在该表格！");
                }

                int count = ProcessCoordDAL.DeleteRecord(tableName, num);
                res = $"成功删除 {count} 行记录";
                return true;
            }
            catch (Exception ex)
            {
                res = $"删除记录失败！ " + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 删除所有坐标记录
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="tableNames">表名集合</param>
        /// <param name="res">执行结果</param>
        /// <returns>True:执行成功 False:执行失败</returns>
        public bool DeleteAllRecord(string tableName,
                                    BindingList<string> tableNames,
                                    out string res)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tableName))
                {
                    throw new Exception("未指定表名！");
                }
                if (!tableNames.Contains(tableName))
                {
                    throw new Exception("数据库中不存在该表格！");
                }

                int count = ProcessCoordDAL.DeleteAllRecord(tableName);
                res = $"成功删除 {count} 行记录";
                return true;
            }
            catch (Exception ex)
            {
                res = $"删除记录失败！ " + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 插入坐标记录
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="tableNames"></param>
        /// <param name="processCoordEntity"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool InsertRecord(string tableName,
                                    BindingList<string> tableNames,
                                    ProcessCoordEntity processCoordEntity,
                                    out string res)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tableName))
                {
                    throw new Exception("未指定表名！");
                }
                if (!tableNames.Contains(tableName))
                {
                    throw new Exception("数据库中不存在该表格！");
                }

                int count = ProcessCoordDAL.InsertRecord(tableName, processCoordEntity.Num, processCoordEntity);
                res = $"成功插入 {count} 条记录！";
                return true;
            }
            catch (Exception ex)
            {
                res = "插入记录失败！ "  + ex.Message ;
                return false;
            }
        }



    }

}
