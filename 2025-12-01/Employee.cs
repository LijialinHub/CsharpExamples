using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _2025_12_01
{   
    /// <summary>
    /// 职员类
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// 工号
        /// </summary>
        [XmlAttribute("工号")]
        public string Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [XmlAttribute("姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [XmlAttribute("性别")]
        public Sex Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [XmlAttribute("年龄")]
        public int Age { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        [XmlAttribute("入职日期")]
        public string DateOfJoining { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [XmlAttribute("职位")]
        public Position Position { get; set; }

        /// <summary>
        /// 月薪
        /// </summary>
        [XmlAttribute("月薪")]
        public double Salary { get; set; }

        /// <summary>
        /// UI要显示的数据
        /// </summary>
        public string UiDisplayData { get { return Id + ": " + Name; }  }

    }

    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum Sex
    {
        Man,
        Woman
    }

    /// <summary>
    /// 职位枚举
    /// </summary>
    public enum Position
    {   
        /// <summary>
        /// 销售助理
        /// </summary>
        SalesAssistant,
        /// <summary>
        /// 销售专员
        /// </summary>
        SalesSpecialist,
        /// <summary>
        /// 经理
        /// </summary>
        Manager,
        /// <summary>
        /// 高级经理
        /// </summary>
        SeniorManager
    }

}
