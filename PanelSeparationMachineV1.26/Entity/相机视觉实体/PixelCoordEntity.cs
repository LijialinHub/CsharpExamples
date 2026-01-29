using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{   
    /// <summary>
    /// 像素坐标实体
    /// </summary>
    public class PixelCoordEntity
    {   
        /// <summary>
        /// 坐标行
        /// </summary>
        public double Row { get; set; }

        /// <summary>
        /// 坐标列
        /// </summary>
        public double Column { get; set; }

        /// <summary>
        /// 旋转角度
        /// </summary>
        public double Angle { get; set; }
    }
}
