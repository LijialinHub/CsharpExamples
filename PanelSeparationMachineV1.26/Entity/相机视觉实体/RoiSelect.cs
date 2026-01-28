using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{   
    /// <summary>
    /// ROI选择枚举
    /// </summary>
    public enum RoiSelect
    {   
        /// <summary>
        /// 圆形
        /// </summary>
        Circle,
        /// <summary>
        /// 平行矩形
        /// </summary>
        Rectangle1,
        /// <summary>
        /// 旋转矩形
        /// </summary>
        Rectangle2,
        /// <summary>
        /// 任意区域
        /// </summary>
        Region
    }
}
