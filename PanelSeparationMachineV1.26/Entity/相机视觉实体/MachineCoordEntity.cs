using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{   

    /// <summary>
    /// 机械坐标实体类
    /// </summary>
    public class MachineCoordEntity
    {
        /// <summary>
        /// 机械X位置
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// 机械Y位置
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// 机械旋转角度
        /// </summary>
        public double Angle { get; set; }

        /// <summary>
        /// X方向的平移
        /// </summary>
        public double Tx { get; set; }

        /// <summary>
        /// Y方向的平移
        /// </summary>
        public double Ty { get; set; }
    }
}
