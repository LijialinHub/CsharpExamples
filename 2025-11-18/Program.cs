using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _2025_11_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 三元运算符 相当于(if else语句的简化版)

            //double a = 20, b = 30, c = 49, d = 80;
            //double max = a >= b ? a : b;

            //max = a > b ? (a >= c ? a : c) : (b >= c ? b : c);

            //double min = a < b ? (a < c ? a : b) : (b < c ? b : c);

            //max = a >= b ? (a >= c ? (a >= d ? a : d) : (c >= d ? c : d)) :
            //               (b >= c ? (b >= d ? b : d) : (c >= d ? c : d));

            //min = a < b ? (a < c ? (a < d ? a : d) : (c < d ? c : d)) :
            //              (b < c ? (b < d ? b : d) : (c < d ? c : d));

            #endregion

            #region List集合
            ////数组是元素数量固定的集合。一旦数组被创建，它的元素个数必须固定大小
            ////数组不能增加或者删除元素，所以在某些情况下不是很方便
            ////List集合 是泛型集合，他的元素个数可以随时添加或者删除add move
            ////泛型有一个<> , <>写入类型名，泛型在创建时确定类型
            ////List中的<>写入是List集合中的元素类型
            ////集合的索引下标都是固定从0开始的

            //List<int> intList = new List<int>() { 10,20};//创建了一个List集合对象
            //                                             //这个集合中的每个元素都是int类型

            ////Add:添加元素
            //intList.Add(10);
            //intList.Add(20);

            ////IEnumerable: 可枚举的接口
            ////一般集合都会集成这个接口，只要继承这个接口 就可以使用foreach遍历
            //int[] ints = { 1234 };
            //intList.AddRange(ints);
            //intList.AddRange(new int[] {123,456});

            //int count = intList.Count; //count属性 元素个数

            ////移除元素:Remove
            //intList.Remove(1234);
            //intList.RemoveAt(0); // 通过索引移除
            //intList.RemoveRange(0, 2); //通过索引移除N个 
            //intList.Clear(); //清空集合

            ////插入： insert
            //intList.Insert(2, 666);

            ////List集合和数组可以相互转换
            //List<bool> bools = new List<bool>() { true, false};
            //bool[] boArr = bools.ToArray(); //list2arr

            //List<bool> bools2 = bools.ToList();




            #endregion

            #region 泛型
            ////泛型（Generic）允许延迟编写类或方法中的编程元素的数据类型的规范
            ////使用的时候必须确定泛型中的具体类型
            ////换句话说，泛型允许编写一个可以与任何数据类型一起工作的类或方法

            //GenericCls<int[], bool, string, char> genericCls = new GenericCls<int[], bool, string, char>();

            //genericCls.A = new int[] { 1, 2, 3 };
            //genericCls.B = true;
            //genericCls.C = "123";

            //GenericCls<int[], bool, string, char>.D = '1';

            //Add<int>(1, 2);

            // Console.WriteLine(getSum<int>(new int[] { 1,2,3}));//泛型方法



            #endregion

            #region 随机数Random类

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(random.Next(1, 100));
            }


            #endregion

        }

        public static T Add<T> (T a, T b)
        {
            dynamic aa = a; //dynamic 动态的 ，在运行分析具体类型
                            //编写过程中不会报错
            dynamic bb = b;
            return aa+bb;
        }


        public static T getSum<T>(T[] xArr) where T : struct //泛型约束 必须是struct类型数据
        {
            //dynamic sum = default(T);
            T sum = default(T);

            for (int i = 0; i < xArr.Length; i++)
            {   
                dynamic dynamic = xArr[i];
                sum += dynamic;
            }
            return sum;
        }



    }

    //<>中的T 表示类型占位符，可以是其他任何单词 
    class GenericCls<T,P,W,M>
    {
        public T A { get; set; }

        public P B { get; set; }

        public W C { get; set; }

        public static M D { get; set; }

         

    }



}
