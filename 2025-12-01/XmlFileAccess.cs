using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _2025_12_01
{   
    /// <summary>
    /// xml文件访问类
    /// </summary>
    public class XmlFileAccess
    {
        /// <summary>
        /// xml文件路径
        /// </summary>
        public static string path = Environment.CurrentDirectory + @"\成员信息.xml";

        /// <summary>
        /// 保存到xml文件
        /// </summary>
        /// <param name="employees">员工集合</param>
        /// <param name="res">执行结果</param>
        /// <returns>true:执行成功 false:执行失败</returns>
        public bool SaveToXml(List<Employee> employees, out string res)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
                    xmlSerializer.Serialize(fs, (Object)employees);
                }
                res = "保存到XML文件成功\r\n";
                return true;
            }
            catch (Exception ex)
            {
                res = "保存到XML文件失败\r\n" + ex.Message;
                return false;
            }
            
        }

        /// <summary>
        /// 读取xml文件
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="res">执行结果</param>
        /// <returns></returns>
        public bool ReadXmlFile(out List<Employee> employees, out string res)
        {

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
                    employees = (List<Employee>)xmlSerializer.Deserialize(fs);
                }
                if (employees == null) { throw new Exception("文件内容异常\r\n"); }
                res = "读取XML文件成功\r\n";
                return true;
            }
            catch (Exception ex)
            {
                employees = new List<Employee>();
                res = "读取XML文件失败\r\n" + ex.Message;
                return false;
            }


        }

    }
}
