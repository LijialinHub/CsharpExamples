using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _2025_11_21.ShapeFactory;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace _2025_11_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 抽象工厂模式

            //string[] shapeNames = Enum.GetNames(typeof(ShapeType));

            //string selectShape = "";

            //for (int i = 0; i < shapeNames.Length; i++) {

            //    selectShape += $" {i}.{shapeNames[i]} ";

            //}

            //Console.WriteLine($"提供形状有 {selectShape}");
            //Console.Write($"请选择要制造的形状的编号 ");
            //int num = int.Parse( Console.ReadLine() );

            //Shape shape = ShapeFactory.GetShape((ShapeType)num);

            ////获取实体后要执行的动作
            //shape.ShowInfo();
            //Console.WriteLine(shape.GetArea());
            //Console.WriteLine(shape.GetPerimeter());


            #endregion


            #region 正则表达式

            //正则表达式: 为了从字符中找出我们需要的字符串数据，字符串提供的方法又不够用
            //正则表达式元字符
            //常用元字符
            /*
              1.匹配除换行符（\n \r）之外的任何单个字符。
                \. 匹配普通的.
              2. []意义
                1. [0-9] 表示匹配0-9之间(包括)任意单个字符
                2. [a-z] 表示匹配任意单个小写英文字母a-z
                3. [xyz123] 表示匹配x或y或z或1或2或3
                4. [a-z0-9A-Z] 表示匹配a-z或0-9或A-Z任何单个字符
                5. [^0-9] 表示匹配除了0-9之外的任意单个字符
                6. [^XYZ] 表示匹配除了XYZ之外的任意单个字符
             
               3. {}的意义
                
                1. ab{3} 匹配 abbb
                2. ab{3,5} 匹配 abbb abbbb abbbbb
                3. ab{3,} 匹配 abbb abbbb ....b至少3个(包括3个)以上

               4. ()的意义 当成一个整体
                1. (ab){3} 匹配ababab
               
               5. |的意义 或是或者，优先级最低
                1. z|food 匹配z或者food
                2. (z|f)ood 匹配zood或者food
               
               6. ^ab 匹配字符串以a开头的ab
               7. ab$ 匹配字符串ab 并且以b结尾的字符串
                
               8. 限定匹配个数
                ? 0个或者1个 中指贪婪模式
                + 1个或1个以上
                * 0个或多个
               9. \d(digital) 匹配单个数字字符 相当于[0-9]
                  \D 匹配非数字单个字符
               
                  \w(word) 匹配数字、字母、下划线_ （汉字），可以组成单词字符
                  \W       匹配非数字、字母、下划线_ 单个字符

                  \s(space) 匹配不可见单个字符 (换行、回车、空格)
                  \S        匹配可见单个字符
                  
                  \b (board) 匹配单词边界
                  \B        匹配非单词边界

                Regex类 (Regular Expression)
                  1. Regex.IsMatch(): 判断是否匹配，返回True false
                  2. Regex.Match() : 返回首个匹配结果
                  3. Regex.Matchs() : 返回所有(多个)匹配结果
                  4. Regex.Replace() : 替换匹配结果
             
             */

            //测试正则表达式元字符
            //while (true) {

            //    Console.WriteLine("输入要匹配的字符串:");
            //    string input = Console.ReadLine();
            //    bool isOk = Regex.IsMatch(input, "\\w+");
            //    if (!isOk) { break; }

            //    //Match match = Regex.Match(input, ""); //找单个
            //    MatchCollection matchCollection = Regex.Matches(input, "\\w+");

            //    Console.WriteLine("匹配的结果:");

            //    foreach (Match match in matchCollection) {

            //        Console.WriteLine(match.Value);
            //    }       

            //    Console.WriteLine("***************************");

            //}

            //Console.WriteLine("测试结束............................");


            //1.匹配以S开头的单词
            string str1 = "A ThouSand Space S 18 李四 Splendid";
            MatchCollection matchCollection = Regex.Matches(str1, @"\bS\w*\b");

            //foreach (var item in matchCollection)
            //{
            //    Console.WriteLine(item);
            //}

            //2.匹配以m开头以e结尾的单词
            string str2 = "make maze  and manage to m123e me measure mawenm it";
            MatchCollection matchCollection2 = Regex.Matches(str2, @"\bm[A-Za-z]*e\b");

            foreach (var item in matchCollection2)
            {
                Console.WriteLine(item);
            }

            //3.替换掉多余的空格
            string str3 = "Hello Word, My name        is    Leo";

            Console.WriteLine(Regex.Replace(str3, @"\s+", " "));

            //4. 判断一个字符串是不是身份证号码
            //长度为15位或18位的字符串 ，首位不能是0
            //如果是15位 则全是数字
            //如果是18位 则17位是数字 末尾可能是数字也可能是X

            //while (true)
            //{

            //    Console.Write("请输入身份证号码");
            //    string id = Console.ReadLine().Trim();
            //    bool isOk = Regex.IsMatch(id, @"^[1-9]\d{14}$|^[1-9]\d{16}(\d|X)$");
            //    if (isOk) { Console.WriteLine("身份证号码 合法"); }
            //    else { Console.WriteLine("身份证号码不合法"); }

            //}

            


            #endregion



        }
    }



    /// <summary>
    /// 形状类
    /// </summary>
    public abstract class Shape  //如果一个类中有抽象成员(方法、属性、字段) 
                                 //那么这个类必须定义成抽象类，加关键字abstract
                                 //抽象成员可以不实现，由继承它的非抽象类必须实现
                                 //抽象类可以继承抽象类，抽象方法可以不实现
                                 //抽象类就是用来做父类的 相当于制定一套标准
                                 
    {   
        /// <summary>
        /// 形状名称
        /// </summary>
        public abstract string ShapeName { get; }


        /// <summary>
        /// 获取面积方法
        /// </summary>
        /// <returns>面积值</returns>
        public abstract double GetArea();

        /// <summary>
        /// 获取周长方法
        /// </summary>
        /// <returns></returns>
        public abstract double GetPerimeter();

        /// <summary>
        /// 信息显示
        /// </summary>
        public virtual void ShowInfo()
        {
            Console.WriteLine($"这是一个 {ShapeName} 形状，面积是 {GetArea()} 周长是 {GetPerimeter()}");
        }

    }



}
