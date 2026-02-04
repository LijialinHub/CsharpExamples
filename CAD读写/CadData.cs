using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD读写
{
    public class CadData
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 线型
        /// </summary>
        public string LineType { get; set; }

        /// <summary>
        /// 起点X
        /// </summary>
        public double StartX  { get; set; }

        /// <summary>
        /// 起点Y
        /// </summary>
        public double StartY { get; set; }

        /// <summary>
        /// 圆心
        /// </summary>
        public double CenterX { get; set; }
        
        /// <summary>
        /// 终点X
        /// </summary>
        public double EndX { get; set; }

        /// <summary>
        /// 终点Y
        /// </summary>
        public double EndY { get; set; }

    }
}
