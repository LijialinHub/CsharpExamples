using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniHelper;

namespace _2025_12_23
{
    /// <summary>
    /// 变频器MODBUS数据访问类
    /// </summary>
    public class InverterModbusDAL
    {

        private IniFiles iniFiles = new IniFiles(Environment.CurrentDirectory + @"\设备参数.Ini");

        /// <summary>
        /// 保存到INI文件
        /// </summary>
        /// <param name="inverterEntity">变频器实体对象</param>
        /// <param name="serialParamatersEntity">串口参数实体对象</param>
        public void SaveInverterDataToIni(InverterEntity inverterEntity, SerialParamatersEntity serialParamatersEntity)
        {

            try
            {
                iniFiles.WriteString("变频器参数", "描述信息", inverterEntity.Description);
                iniFiles.WriteString("变频器参数", "站号", inverterEntity.StationNumber.ToString());
                iniFiles.WriteString("串口参数", "波特率", serialParamatersEntity.BaudRate.ToString());
                iniFiles.WriteString("串口参数", "数据位", serialParamatersEntity.DataBits.ToString());
                iniFiles.WriteString("串口参数", "校验位", serialParamatersEntity.ParityBits.ToString());
                iniFiles.WriteString("串口参数", "停止位", serialParamatersEntity.StopBits.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 从INI文件中读取数据
        /// </summary>
        /// <param name="inverterEntity">变频器实体对象</param>
        /// <param name="serialParamatersEntity">串口参数实体对象</param>
        public void ReadInverterDataFromIni(InverterEntity inverterEntity, SerialParamatersEntity serialParamatersEntity)
        {
            try
            {
                inverterEntity.Description = iniFiles.ReadString("变频器参数", "描述信息", "*************");
                inverterEntity.StationNumber = Convert.ToByte(iniFiles.ReadString("变频器参数", "站号", ""));
                serialParamatersEntity.BaudRate = Convert.ToInt32(iniFiles.ReadString("串口参数", "波特率", "9600"));
                serialParamatersEntity.DataBits = Convert.ToInt32(iniFiles.ReadString("串口参数", "数据位", "8"));
                serialParamatersEntity.ParityBits = (Parity)Enum.Parse(typeof(Parity), iniFiles.ReadString("串口参数", "校验位", "Even"));
                serialParamatersEntity.StopBits = (StopBits)Enum.Parse(typeof(StopBits), iniFiles.ReadString("串口参数", "停止位", "One"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
