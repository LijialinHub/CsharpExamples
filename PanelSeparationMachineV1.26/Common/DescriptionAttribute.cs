using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 自定义描述特性类
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    public class DescriptionCustomAttribute : Attribute
    {   
        public DescriptionCustomAttribute(string description)
        {
            Description = description;
        }
        
        
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

    }

}
