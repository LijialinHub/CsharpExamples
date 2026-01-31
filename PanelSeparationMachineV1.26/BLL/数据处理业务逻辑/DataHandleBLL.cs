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

        #region Ini设备参数数据读写

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
        /// 从Ini文件读取轴数据
        /// </summary>
        /// <param name="axis"></param>
        public void ReadAxisDataFromIni(Axis axis)
        {
            IniFiles iniFiles = new IniFiles(Environment.CurrentDirectory + @"\参数.ini");

            //脉冲当量 p/mm
            axis.PulseEquivalent = double.Parse(iniFiles.ReadString(axis.Axis_Name, "PulseEquivalent", "0"));

            //手动参数设置
            axis.Speed_JogStart = double.Parse(iniFiles.ReadString(axis.Axis_Name, "Speed_JogStart", "0"));
            axis.Speed_JogHigh = double.Parse(iniFiles.ReadString(axis.Axis_Name, "Speed_JogHigh", "0"));
            axis.Speed_JogLow = double.Parse(iniFiles.ReadString(axis.Axis_Name, "Speed_JogLow", "0"));
            axis.Speed_JogAccTime = double.Parse(iniFiles.ReadString(axis.Axis_Name, "Speed_JogAccTime", "0"));
            axis.Speed_JogDecTime = double.Parse(iniFiles.ReadString(axis.Axis_Name, "Speed_JogDecTime", "0"));

            //自动参数设置
            axis.Speed_autoStart = double.Parse(iniFiles.ReadString(axis.Axis_Name, "Speed_autoStart", "0"));
            axis.Speed_autoMax = double.Parse(iniFiles.ReadString(axis.Axis_Name, "Speed_autoMax", "0"));
            axis.Speed_autoAccTime = double.Parse(iniFiles.ReadString(axis.Axis_Name, "Speed_autoAccTime", "0"));
            axis.Speed_autoDecTime = double.Parse(iniFiles.ReadString(axis.Axis_Name, "Speed_autoDecTime", "0"));
            axis.WaitingPosition = double.Parse(iniFiles.ReadString(axis.Axis_Name, "WaitingPosition", "0"));

            //回原点参数设置
            axis.Speed_homeStart = double.Parse(iniFiles.ReadString(axis.Axis_Name, "Speed_homeStart", "0"));
            axis.Speed_homeMax = double.Parse(iniFiles.ReadString(axis.Axis_Name, "Speed_homeMax", "0"));
            axis.Speed_homeAccTime = double.Parse(iniFiles.ReadString(axis.Axis_Name, "Speed_homeAccTime", "0"));
            axis.Speed_homeDecTime = double.Parse(iniFiles.ReadString(axis.Axis_Name, "Speed_homeDecTime", "0"));

            //Z轴安全位置
            axis.SafePosition = double.Parse(iniFiles.ReadString(axis.Axis_Name, "SafePosition", "0"));
            //Z轴工作速度
            axis.WorkSpeed = double.Parse(iniFiles.ReadString(axis.Axis_Name, "WorkSpeed", "0"));
            //软限位设置
            axis.SoftLimit_P = double.Parse(iniFiles.ReadString(axis.Axis_Name, "SoftLimit_P", "0"));
            axis.SoftLimit_N = double.Parse(iniFiles.ReadString(axis.Axis_Name, "SoftLimit_N", "0"));

        }

        /// <summary>
        /// 保存轴数据到Ini文件
        /// </summary>
        /// <param name="axis"></param>
        public void WriteAxisDataFromIni(Axis axis)
        {
            IniFiles iniFiles = new IniFiles(Environment.CurrentDirectory + @"\参数.ini");

            //脉冲当量 p/mm
            iniFiles.WriteString(axis.Axis_Name, "PulseEquivalent", axis.PulseEquivalent.ToString());

            //手动参数设置
            iniFiles.WriteString(axis.Axis_Name, "Speed_JogStart", axis.Speed_JogStart.ToString());
            iniFiles.WriteString(axis.Axis_Name, "Speed_JogHigh", axis.Speed_JogHigh.ToString());
            iniFiles.WriteString(axis.Axis_Name, "Speed_JogLow", axis.Speed_JogLow.ToString());
            iniFiles.WriteString(axis.Axis_Name, "Speed_JogAccTime", axis.Speed_JogAccTime.ToString());
            iniFiles.WriteString(axis.Axis_Name, "Speed_JogDecTime", axis.Speed_JogDecTime.ToString());

            //自动参数设置
            iniFiles.WriteString(axis.Axis_Name, "Speed_autoStart", axis.Speed_autoStart.ToString());
            iniFiles.WriteString(axis.Axis_Name, "Speed_autoMax", axis.Speed_autoMax.ToString());
            iniFiles.WriteString(axis.Axis_Name, "Speed_autoAccTime", axis.Speed_autoAccTime.ToString());
            iniFiles.WriteString(axis.Axis_Name, "Speed_autoDecTime", axis.Speed_autoDecTime.ToString());
            iniFiles.WriteString(axis.Axis_Name, "WaitingPosition", axis.WaitingPosition.ToString());

            //回原点参数设置
            iniFiles.WriteString(axis.Axis_Name, "Speed_homeStart", axis.Speed_homeStart.ToString());
            iniFiles.WriteString(axis.Axis_Name, "Speed_homeMax", axis.Speed_homeMax.ToString());
            iniFiles.WriteString(axis.Axis_Name, "Speed_homeAccTime", axis.Speed_homeAccTime.ToString());
            iniFiles.WriteString(axis.Axis_Name, "Speed_homeDecTime", axis.Speed_homeDecTime.ToString());

            //Z轴安全位置
            iniFiles.WriteString(axis.Axis_Name, "SafePosition", axis.SafePosition.ToString());
            //Z轴工作速度
            iniFiles.WriteString(axis.Axis_Name, "WorkSpeed", axis.WorkSpeed.ToString());
            //软限位设置
            iniFiles.WriteString(axis.Axis_Name, "SoftLimit_P", axis.SoftLimit_P.ToString());
            iniFiles.WriteString(axis.Axis_Name, "SoftLimit_N", axis.SoftLimit_N.ToString());


        }


        /// <summary>
        /// 从Ini文件读取IO工艺实体
        /// </summary>
        public void ReadIOCraftEntityFromIni(IOCraftEntity iOCraftEntity)
        {
            IniFiles iniFiles = new IniFiles(Environment.CurrentDirectory + @"\参数.ini");

            iOCraftEntity.MaterialSignals.Name = iniFiles.ReadString("物料到位信号", "信号名", "物料到位信号");
            iOCraftEntity.MaterialSignals.CardNo = ushort.Parse(iniFiles.ReadString("物料到位信号", "卡号", "0"));
            iOCraftEntity.MaterialSignals.BitNo = ushort.Parse(iniFiles.ReadString("物料到位信号", "位号", "1"));

            iOCraftEntity.Cutter.Name = iniFiles.ReadString("切割器信号", "信号名", "切割器信号");
            iOCraftEntity.Cutter.CardNo = ushort.Parse(iniFiles.ReadString("切割器信号", "卡号", "0"));
            iOCraftEntity.Cutter.BitNo = ushort.Parse(iniFiles.ReadString("切割器信号", "位号", "2"));

        }

        /// <summary>
        /// 保存IO工艺数据到Ini文件
        /// </summary>
        /// <param name="iOCraftEntity"></param>
        public void WriteIOCraftEntityToIni(IOCraftEntity iOCraftEntity)
        {
            IniFiles iniFiles = new IniFiles(Environment.CurrentDirectory + @"\参数.ini");

            iniFiles.WriteString("物料到位信号", "信号名", iOCraftEntity.MaterialSignals.Name);
            iniFiles.WriteString("物料到位信号", "卡号", iOCraftEntity.MaterialSignals.CardNo.ToString());
            iniFiles.WriteString("物料到位信号", "位号", iOCraftEntity.MaterialSignals.BitNo.ToString());


            iniFiles.WriteString("切割器信号", "信号名", iOCraftEntity.Cutter.Name);
            iniFiles.WriteString("切割器信号", "卡号", iOCraftEntity.Cutter.CardNo.ToString());
            iniFiles.WriteString("切割器信号", "位号", iOCraftEntity.Cutter.BitNo.ToString());
        }

        /// <summary>
        /// 写入视觉参数
        /// </summary>
        /// <param name="vision">视觉实体对象</param>
        public void WriteCameraVisionToIni(CameraVisionEntity vision)
        {
            IniFiles iniFiles = new IniFiles(Environment.CurrentDirectory + @"\参数.ini");

            iniFiles.WriteString("视觉参数", "相机序列号", vision.StrSN.ToString());
            iniFiles.WriteString("视觉参数", "曝光时间", vision.ExposeTime.ToString());
            iniFiles.WriteString("视觉参数", "增益", vision.Gain.ToString());

            iniFiles.WriteString("视觉参数", "贪婪度", vision.Greediness.ToString());
            iniFiles.WriteString("视觉参数", "重叠度", vision.MaxOverlap.ToString());
            iniFiles.WriteString("视觉参数", "匹配分数", vision.MatchScores.ToString());

            iniFiles.WriteString("视觉参数", "拍照高度", vision.BDHeight.ToString());
            iniFiles.WriteString("视觉参数", "X方向像素和机械比值", vision.XDirPixToMachine.ToString());
            iniFiles.WriteString("视觉参数", "Y方向像素和机械比值", vision.YDirPixToMachine.ToString());

            iniFiles.WriteString("视觉参数", "示教板Mark1像素行坐标", vision.TBImageMark1.Row.ToString());
            iniFiles.WriteString("视觉参数", "示教板Mark1像素列坐标", vision.TBImageMark1.Column.ToString());

            iniFiles.WriteString("视觉参数", "示教板Mark2像素行坐标", vision.TBImageMark2.Row.ToString());
            iniFiles.WriteString("视觉参数", "示教板Mark2像素列坐标", vision.TBImageMark2.Column.ToString());

            iniFiles.WriteString("视觉参数", "示教板Mark1机械X坐标", vision.TBMachineMark1.X.ToString());
            iniFiles.WriteString("视觉参数", "示教板Mark1机械Y坐标", vision.TBMachineMark1.Y.ToString());

            iniFiles.WriteString("视觉参数", "示教板Mark2机械X坐标", vision.TBMachineMark2.X.ToString());
            iniFiles.WriteString("视觉参数", "示教板Mark2机械Y坐标", vision.TBMachineMark2.Y.ToString());
        }

        /// <summary>
        /// 从Ini文件读取视觉参数
        /// </summary>
        /// <param name="vision"></param>
        public void ReadCameraVisionFromIni(CameraVisionEntity vision)
        {
            IniFiles iniFiles = new IniFiles(Environment.CurrentDirectory + @"\参数.ini");

            vision.StrSN = iniFiles.ReadString("视觉参数", "相机序列号", "RG0260011022");
            vision.ExposeTime = double.Parse(iniFiles.ReadString("视觉参数", "曝光时间", "6000.0"));
            vision.Gain = double.Parse(iniFiles.ReadString("视觉参数", "增益", "0.0"));

            vision.Greediness = double.Parse(iniFiles.ReadString("视觉参数", "贪婪度", "0.0"));
            vision.MaxOverlap = double.Parse(iniFiles.ReadString("视觉参数", "重叠度", "0.0"));
            vision.MatchScores = double.Parse(iniFiles.ReadString("视觉参数", "匹配分数", "0.0"));

            vision.BDHeight = double.Parse(iniFiles.ReadString("视觉参数", "拍照高度", "0"));
            vision.XDirPixToMachine = double.Parse(iniFiles.ReadString("视觉参数", "X方向像素和机械比值", "0"));
            vision.YDirPixToMachine = double.Parse(iniFiles.ReadString("视觉参数", "Y方向像素和机械比值", "0"));

            vision.TBImageMark1.Row = double.Parse(iniFiles.ReadString("视觉参数", "示教板Mark1像素行坐标", "0"));
            vision.TBImageMark1.Column = double.Parse(iniFiles.ReadString("视觉参数", "示教板Mark1像素列坐标", "0"));

            vision.TBImageMark2.Row = double.Parse(iniFiles.ReadString("视觉参数", "示教板Mark2像素行坐标", "0"));
            vision.TBImageMark2.Column = double.Parse(iniFiles.ReadString("视觉参数", "示教板Mark2像素列坐标", "0"));

            vision.TBMachineMark1.X = double.Parse(iniFiles.ReadString("视觉参数", "示教板Mark1机械X坐标", "0"));
            vision.TBMachineMark1.Y = double.Parse(iniFiles.ReadString("视觉参数", "示教板Mark1机械Y坐标", "0"));

            vision.TBMachineMark2.X = double.Parse(iniFiles.ReadString("视觉参数", "示教板Mark2机械X坐标", "0"));
            vision.TBMachineMark2.Y = double.Parse(iniFiles.ReadString("视觉参数", "示教板Mark2机械Y坐标", "0"));

        }

        #endregion

        #region 加工坐标数据库访问
        //****************************************数据库*******************************

        /// <summary>
        /// 加工坐标数据访问工具对象
        /// </summary>
        private ProcessCoordDAL ProcessCoordDAL = new ProcessCoordDAL()
        {
            DataBaseServer = new AccessDBHelper()
        }; //默认使用Access数据库


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

        #endregion

        #region 用户数据访问

        private UserInfoDAL UserInfoDAL = new UserInfoDAL();
        
        /// <summary>
        /// 保存用户数据
        /// </summary>
        /// <param name="userEntities">用户集合</param>
        /// <param name="res">执行结果</param>
        /// <returns>True:成功 False:失败</returns>
        public bool SaveUserData(List<UserEntity> userEntities, out string res)
        {
            try
            {
                UserInfoDAL.SaveUserData(userEntities);
                res = "保存用户数据成功！";
                return true;
            }
            catch (Exception ex)
            {
                res = "保存用户数据失败！ " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 读取用户数据
        /// </summary>
        /// <param name="userEntities">用户集合</param>
        /// <param name="res">执行结果</param>
        /// <returns>True:成功 False:失败</returns>
        public bool ReadUserData(out List<UserEntity> userEntities, out string res)
        {
            try
            {
                userEntities = UserInfoDAL.ReadUserData();
                if (userEntities == null || userEntities.Count == 0)
                {
                    throw new Exception("用户数据为空！");
                }
                res = "读取用户数据成功！";
                return true;
            }
            catch (Exception ex)
            {
                res = "读取用户数据失败！ " + ex.Message;
                userEntities = null;
                return false;
            }
        }


        #endregion


    }

}
