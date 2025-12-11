using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_19
{
    /// <summary>
    /// 生物类
    /// </summary>
    public class Biology
    {
        /// <summary>
        /// 品种
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 呼吸方法
        /// </summary>
        public void Breath()
        {
            Console.WriteLine("正在呼吸中");
        }

        //私有字段 只能在本类中访问
        private int A { get; set; }

        //受保护的，只能在当前类和它的派生类中访问
        //权限等级：private < protected < public
        protected int B { get; set; }

        /// <summary>
        /// 无论子类还是其他类都可以访问 访问和修改的都是同一个值 共享的
        /// 静态的成员虽然被子类继承了，但是所有的子类共享同一个静态成员
        /// </summary>
        public static int C { get; set; } //公共的 静态的


    }

    /// <summary>
    /// 人类
    /// </summary>
    public class Person : Biology  //Person类继承了Biology类
                                   //Biology是Person的父类 or 基类
                                   //Person是Biology的子类 or 派生类
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 奔跑方法
        /// </summary>
        public void Running()
        {
            Console.WriteLine("正在跑步中");
        }

    }

    /// <summary>
    /// 学生类
    /// </summary>
    public class Student : Person, ISwimming  //一个类只能继承一个类
                                              //但是可以继承多个接口
                                              //集成的类必须在接口前面
    {
        /// <summary>
        /// 分数
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// 学习方法
        /// </summary>
        public void Study()
        {
            Console.WriteLine("正在学习中");
        }

    }

    /// <summary>
    /// 司机类
    /// </summary>
    public class Driver : Person
    {
        /// <summary>
        /// 驾驶年限
        /// </summary>
        public int DriveYears { get; set; }

        /// <summary>
        /// 驾驶方法
        /// </summary>
        public void Driving()
        {
            Console.WriteLine("正在驾驶中");
        }
    }


    interface ISwimming
    {

    }




}
