using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_19_dll_
{   
    /// <summary>
    /// 计算类
    /// </summary>
    public class Calcu
    {
        /// <summary>
        /// 加法运算
        /// </summary>
        /// <typeparam name="T">类型占位符</typeparam>
        /// <param name="x">输入参数1</param>
        /// <param name="y">输入参数2</param>
        /// <returns>加的结果</returns>
        public static T Add<T>(T x, T y) 
        {
            try
            {
                dynamic a = x;
                dynamic b = y;
                return a + b;
            }
            catch (Exception ex)
            {

                throw ex;  //往外抛异常，交给调用方处理
            }
        }


        /// <summary>
        /// 减法运算
        /// </summary>
        /// <typeparam name="T">类型占位符</typeparam>
        /// <param name="x">输入参数1</param>
        /// <param name="y">输入参数2</param>
        /// <returns>减的结果</returns>
        public static T Sub<T>(T x, T y)
        {
            try
            {
                dynamic a = x;
                dynamic b = y;
                return a - b;
            }
            catch (Exception ex)
            {

                throw ex;  //往外抛异常，交给调用方处理
            }
        }

    }
}
