using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_12_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 扩展方法

            double[] doubleArr = new double[] { 50, 15, -20, -10, 55, 60, 25 };
            Console.WriteLine(CustomEx.GetSum(doubleArr, x=>x>0));
            //扩展用法
            Console.WriteLine(doubleArr.GetSum(x=>x>0));

            //为某个类拓展一个方法
            Calcu calcu = new Calcu();
            calcu.Sub(1, 2);

            //泛型扩展方法
            int[] intArr = new int[] { 1, 2, 3 };
            Console.WriteLine(intArr.GetSum<int>(x=>x%2!=0)); //int可省略 会自动推导
            Console.WriteLine(intArr.GetSum(x=>x%2!=0));

            List<decimal> decimalArr = new List<decimal>() { 1, 2, 3, 4, 5 };
            Console.WriteLine(decimalArr.GetSumEx<decimal>(x => { return x > 3; }));

            //系统提供的一些扩展方法
            List<double> doubleList = new List<double> { 1, 2, 3, 4, 5, 6 };

            doubleList.Sum(x => { return x * 2; }); //每个元素乘以2的和




            #endregion


            #region LINQ(Language Integrated Query 语言集成查询) 
            //一种查询技术
            //linq to objects：对象集合的查询
            //linq to xml： xml的查询
            //linq to ADO.NET：主要负责数据库的查询
            //查询表达式 查询扩展方法

            #region where（过滤集合中的元素）
            int[] intArr1 = new int[] {1,2,3,4,5,5,6,7,8,9,10};
            //查询表达式
            var r1 = from num in intArr1   //查询intArr1中大于3的偶数元素
                     where num > 3 
                     where num % 2 == 0  //也可以 where num > 3 && num % 2 == 0 
                     select num;         //最后必须以select或者group by结尾

            Console.WriteLine("=================LINQ===================");
            //foreach (var item in r1)
            //{
            //    Console.Write(item + "  ");
            //}
            Console.WriteLine();
            //查询扩展方法
            var r2  = intArr1.Where<int>(x => { return x % 2 == 0 && x > 3; });

            //foreach (var item in r2)
            //{
            //    Console.Write(item + "  ");
            //}


            List<Student> stuList = new List<Student>()
            {
                new Student(){ClassId = 1, Name = "张三" ,ChineseScore = 10, EnglishScore = 20, MathScore = 30},

                new Student(){ClassId = 2, Name = "李四" ,ChineseScore = 30, EnglishScore = 50, MathScore = 80},

                new Student(){ClassId = 3, Name = "王五" ,ChineseScore = 88, EnglishScore = 66, MathScore = 95},

                new Student(){ClassId = 3, Name = "赵六" ,ChineseScore = 0, EnglishScore = 33, MathScore = 42},

                new Student(){ClassId = 2, Name = "孙七" ,ChineseScore = 40, EnglishScore = 73, MathScore = 90},

                new Student(){ClassId = 1, Name = "周八" ,ChineseScore = 67, EnglishScore = 86, MathScore = 38},

                new Student(){ClassId = 2, Name = "吴九" ,ChineseScore = 55, EnglishScore = 66, MathScore = 98},

                new Student(){ClassId = 2, Name = "郑十" ,ChineseScore = 45, EnglishScore = 89, MathScore = 99}
            };

            //let子句用于在查询中添加一个新的局部变量使其在后面的查询中可见
            //匿名类
            double Pressure = 888.65;
            var a = new { Id = 33, TempValue = 66.23, Pressure };
            
            //SQL写法
            var r3 = from student in stuList
                     let sum = student.ChineseScore + student.MathScore + student.EnglishScore
                     where sum > 200
                     select new { Name = student.Name, Sum = sum};   //此处写法为匿名类

            //foreach (var item in r3)
            //{
            //    Console.WriteLine($"姓名: {item.Name} 总分: {item.Sum}");
            //}

            //链式写法
            var r4 = stuList.Where(student =>
            { 
                return student.ChineseScore + student.MathScore + student.EnglishScore > 200; 
            }).
            Select(student => 
            { 
                return new 
                {
                    Name = student.Name,
                    Sum = student.ChineseScore + student.MathScore + student.EnglishScore 
                 }; 
            });

            //foreach (var item in r4)
            //{
            //    Console.WriteLine($"姓名: {item.Name} 总分: {item.Sum}");
            //}

            #endregion


            #region OrderBy和OrderByDescending: 按升序或者降序排序

            var r5 = from stu in stuList
                     let sum = stu.MathScore + stu.ChineseScore + stu.EnglishScore
                     orderby sum ascending  //升序
                     orderby sum descending //降序
                     orderby sum descending, stu.EnglishScore descending  //先根据sum进行降序排序 如果sum一样 按照EnglishScore降序排序
                     select new { ClassId = stu.ClassId, Name = stu.Name, Sum = sum };


            var r6 = stuList.OrderByDescending(stu => (stu.MathScore + stu.ChineseScore + stu.EnglishScore)).
                ThenByDescending(stu => stu.EnglishScore).
                Select(stu => 
                { 
                    return new
                    { 
                        ClassId = stu.ClassId,
                        Name = stu.Name, 
                        Sum = stu.MathScore + stu.ChineseScore + stu.EnglishScore 
                    }; 
                });


            #endregion


            #region GroupBy：根据键值对元素进行分组

            var r7 = from stu in stuList
                     group stu by stu.ClassId;

            foreach (IGrouping<int, Student> bjGroup in r7)
            {
                Console.WriteLine($"班级号: {bjGroup.Key}");
                foreach (var item in bjGroup)
                {
                    Console.WriteLine(item.Name);
                }
            }

            Console.WriteLine("=================");
            var r8 = stuList.GroupBy(stu => stu.ClassId);

            foreach (IGrouping<int, Student> bjGroup in r8)
            {
                Console.WriteLine($"班级号: {bjGroup.Key}");
                foreach (var item in bjGroup)
                {
                    Console.WriteLine(item.Name);
                }
            }


            #endregion


            #region Any 和 All: 检查集合是否满足某些条件
            //Count: 个数 Take: 取 Skip: 跳过

            List<int> intList1 = new List<int>() { 20, 30,30, -50, -50, 60, 70, 80 };

            //集合只要有一个满足 就返回True
            bool res1 = intList1.Any(input => { return input > 70; });
            //集合中所有元素满足条件 才返回True
            bool res2 = intList1.All(input => { return input > 70; });
            //集合中满足条件的元素的个数
            int num2 = intList1.Count(input => { return input > 50; });
            //去重
            var res3 = intList1.Distinct();
            //跳过集合中前三个元素 ,取后边所有
            var res4 = intList1.Skip(3);
            //取指定元素个数
            var res5 = intList1.Take(3);

            #endregion


            #endregion


        }



    }


    /// <summary>
    /// 学生类
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 班级编号
        /// </summary>
        public int ClassId { get; set; }


        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 语文成绩
        /// </summary>
        public double ChineseScore { get; set; }

        /// <summary>
        /// 数学成绩
        /// </summary>
        public double MathScore { get; set; }

        /// <summary>
        /// 英语成绩
        /// </summary>
        public double EnglishScore { get; set; }

    }



    public class Calcu
    {
        public double Add(double a, double b)
        { return a + b; }
    }


    public static class CustomEx   //扩展方法必须定义在静态类中
                                   //扩展方法的第一个参，以this开头
                                   //以this开头，声明的就是对这个类的对象的一个扩展(为某个类增加一个方法)
    {   
        /// <summary>
        /// 只支持数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doubles"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T GetSum<T>(this T[] doubles, Func<T, bool> func)
        {
            dynamic sum = default(T);
            foreach (var item in doubles)
            {
                if (func(item))
                {
                    sum += item;
                }
            }
            return sum;
        }

        /// <summary>
        /// 支持所有集合(可以foreach的集合)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputs"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T GetSumEx<T>(this IEnumerable<T> inputs, Func<T,bool> func)
        {
            dynamic sum = default(T);
            foreach (var item in inputs)
            {
                if (func(item))
                {
                    sum += item;
                }
            }
            return sum;
        }



        /// <summary>
        /// 为Calcu类拓展一个方法
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Sub(this Calcu obj, double a, double b) 
        { 
            return a - b; 
        }

    }

}
