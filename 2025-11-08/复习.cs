using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_08
{   
    //命名空间的成员： 类 委托 接口 枚举 结构体 其他命名空间

    //类的成员： 字段、属性、方案、构造函数、事件
    class Student2
    {   
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        private int age;

        public int Age
        {
            get { return age; }
            set 
            { 
                if(value > 3 &&  value < 60)
                {
                    age = value;
                }
                else
                {
                    throw new Exception("输入有误");
                }
            }
        }

        

        
    }



    internal class 复习
    {
    }
}
