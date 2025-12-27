using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_12_05_2_
{
    /// <summary>
    /// 温度压力类
    /// </summary>
    public class Tap
    {

        /// <summary>
        /// 温度压力上下限
        /// </summary>
        public static TPLimitValue TPLimitValue;


        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 当前时间
        /// </summary>
        public string CurrentTime {  get; set; } //对接X轴

        /// <summary>
        /// 温度
        /// </summary>
        public double Temperature { get; set; } //对接左主Y轴

        /// <summary>
        /// 压力
        /// </summary>
        public double Pressure { get; set; } //对接右副Y轴


        /// <summary>
        /// 温度报警
        /// </summary>
        public string TempAlarm
        {
            get
            {   //normal lower high
                return Temperature >= TPLimitValue.TempUpperLimit ? "High" :
                    (Temperature <= TPLimitValue.TempLowerLimit ? "Lower" : "Normal");
            }
        }


        /// <summary>
        /// 压力报警
        /// </summary>
        public  string PressureAlarm
        {
            get
            {
                return Pressure >= TPLimitValue.PressureUpperLimit ? "High" :
                    (Pressure <= TPLimitValue.PressureLowerLimit ? "Lower" :
                    "Normal");
            }
        }




    }


    public struct TPLimitValue
    {
        /// <summary>
        /// 温度上限
        /// </summary>
        public double TempUpperLimit;

        /// <summary>
        /// 温度下限
        /// </summary>
        public double TempLowerLimit;

        /// <summary>
        /// 压力上限
        /// </summary>
        public double PressureUpperLimit;


        /// <summary>
        /// 压力下限
        /// </summary>
        public double PressureLowerLimit;


        

    }


}
