using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PixelPos
    {   
        
        public int Id { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 行坐标
        /// </summary>
        public double Row { get; set; }

        /// <summary>
        /// 列坐标
        /// </summary>
        public double Column { get; set; }

        /// <summary>
        /// <summary>
        /// 偏移角度(相对于模板图像ROI的)
        /// </summary>
        public double Angle { get; set; }

        /// <summary>
        /// 行坐标缩放比例
        /// </summary>
        public double ScaleRow { get; set; }

        /// <summary>
        /// 列坐标缩放比例
        /// </summary> 
        public double ScaleColumn { get; set; }
    }
}
