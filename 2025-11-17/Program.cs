using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace System.Diagnostics;

namespace _2025_11_17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 字符串和相关操作
            ////字符串本质是字符的集合，集合的下标从0开始
            //string str1 = "华山编程 168！";//空格是不可见字符
            //Console.WriteLine(str1[2]);//编
            //Console.WriteLine(str1.Length);
            //Console.WriteLine(str1[str1.Length-1]); //!

            //for (int i = 0; i < str1.Length; i++)
            //{
            //    Console.Write(str1[i] + " ");
            //}
            //Console.WriteLine();

            //foreach (var item in str1)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();


            ////字符串和字符数组可以相互转换
            //char[]charArr1 = str1.ToCharArray();

            //char[] charArr2 = { '1', '2', '3' };
            //string str2 = new string(charArr2);

            //Array.Reverse(charArr2);
            //string str3 = new string(charArr2);
            //Console.WriteLine(str3);

            ////字符串常用方法
            ////1.字符串的截取 substring
            //string str4 = "今天是个晴天";
            //string str5 = str4.Substring(1, str4.Length - 1);
            //str5 = str4.Substring(2);
            //Console.WriteLine(str5);

            ////判断一个字符串是否包含某个字符串元素
            //Console.WriteLine(str4.Contains("天"));

            ////替换字符串某些元素 Replace
            //string str6 = "今天小明会过来参观，小红也会过来参观";
            //Console.WriteLine(str6.Replace("红","绿"));

            ////移除字符串中某个元素 Remove
            //string str7 = "小明小红今天会过来";
            //Console.WriteLine(str7.Remove(4));

            ////剔除字符串两边空格 Trim
            //string str8 = "  今天天气不错  ";
            //Console.WriteLine(str8.Length);
            //Console.WriteLine(str8.Trim().Length);

            ////查找或定位到指定元素的Index0f 如果没有返回-1
            //Console.WriteLine(str8.IndexOf("天天"));

            ////找到所有小的位置
            //string str9 = "小张说，据说小行星会撞上地球,小张说 小红也看到过这个小道消息";

            //int index = 0;
            //while (true)
            //{
            //    int res = str9.IndexOf("小", index);
            //    if(res == -1) { break; }
            //    Console.WriteLine(index);
            //    index = res + 1;
            //}

            ////判断是否以某个元素开头或者某个元素结尾
            //string str10 = "好好学习 天天向上";
            //Console.WriteLine(str10.StartsWith("好好"));
            //Console.WriteLine(str10.EndsWith("向上"));

            ////将字符串数组 以某个分隔符连接成一个字符串 Join
            //string[] strs = { "三国演义", "水浒传", "西游记" };
            ////以|将数组连接起来
            //string str11 = string.Join("|", strs);
            //Console.WriteLine(str11);

            ////字符串的分割 Split
            //string str12 = "张三|*李四 *-王五- |赵六";
            //string[] strs2 = str12.Split(new string[]{"|", "*", " ","-"},
            //                    StringSplitOptions.RemoveEmptyEntries); 
            //foreach (string str in strs2)
            //{
            //    Console.WriteLine(str);
            //}

            ////转大写 小写
            //string str13 = "abAB12";
            //Console.WriteLine(str13.ToLower());
            //Console.WriteLine(str13.ToUpper());

            ////判断字符串是否为null "" " " 三种情况
            //string str14 = null;
            //string str15 = "";
            //string str16 = " ";
            //Console.WriteLine(string.IsNullOrWhiteSpace(str14));
            //Console.WriteLine(string.IsNullOrWhiteSpace(str15));
            //Console.WriteLine(string.IsNullOrWhiteSpace(str16));
            #endregion

            #region String和stringBuilder的区别

            //string类型他的一些方法会创建新的string对象，而不会改变原有的对象
            //创建对象会占用系统内存资源，消耗时间
            //一旦创建string对象，就不能够修改
            //当需要大量的修改时，可使用stringbuilder类

            //string 是引用类型（特殊）
            //string a = "今天天气比较冷";
            //string b = "可能会下小雨";

            //a = b;
            //b = "下雨";
            //Console.WriteLine(a);
            //Console.WriteLine(b);

            ////数组也是引用类型
            //int[] input1 = { 1, 2, 3, 4, 5, 6 };
            //int[] input2 = { 11, 12, 13 };

            //input1  = input2; ;
            //input2[0] = 8888;
            //input1[2] = 9999;

            //foreach (var item in input1)
            //{
            //    Console.WriteLine(item + " ");
            //}
            //Console.WriteLine();


            ////stringBuilder是引用类型，进行大量字符串修改时 使用stringBuilder
            //StringBuilder sb = new StringBuilder("abc");
            //sb.Append("123");  //abc123
            //sb.Replace('2', ' '); // abc1 3
            //sb.Remove(0, 1); //bc1 3
            //sb.Replace("bc", "ABC");
            ////sb.Clear();
            //sb.Insert(0, "---");
            //Console.WriteLine(sb.ToString());

            ////以上stringBuilder的实例方法都是在修改sb这个对象本身，没有创建任何对象
            ////字符串很多方法都是创建了新的字符串对象
            //string ss = "abc";
            //string ss2 = ss + "1234";  //abc1234
            //string ss3 = ss2.Remove(1,2); //a1234
            //string ss4 = ss3.Replace("a", "XXX");//XXX1234
            //string ss5 = ss4.Insert(1, "abc");//XabcXX1234
            //Console.WriteLine(ss5);

            #endregion

            #region String 和 StringBuilder的耗时比较
            //string str1 = null;

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Restart();

            //for (int i = 0; i < 10000; i++)
            //{
            //    str1 += "AB";
            //}

            //stopwatch.Stop();
            ////Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString());
            //Console.WriteLine(stopwatch.ElapsedTicks.ToString());


            //StringBuilder stringBuilder = new StringBuilder();

            //stopwatch.Restart();
            //for (int i = 0; i< 10000 ; i++)
            //{
            //    stringBuilder.Append("AB");
            //}
            //stopwatch.Stop();
            //Console.WriteLine(stopwatch.ElapsedTicks.ToString());

            #endregion

            #region 方法参数传递
            //C#数据类型 1.值类型 2.引用类型
            //值类型 枚举 结构体（int bool double ...）
            //引用类型 类 数组 接口 委托
            //引用类型分为两部内存：1.内存栈存储指向内存堆的地址
            //                      2.内存堆存储实体对象

            //1.值类型参数 将实参的值 复制到了形参
            //改变形参 无法影响到实惨
            //相当于PLC的功能块的输入(In)类型

            int a = 1;
            int b = 2;
            Add(a, b);

            //2.引用类型参数 或者对值类型参数加关键字 ref(reference) 变成引用类型
            //引用类型是地址传递
            //改变形参就会影响到实参

            Add(ref a, b);
            Console.WriteLine(a);


            //参数本身就是引用类型 数组就是引用类型
            double[] doubles = { 1, 2, 3 };
            ScaleArray(doubles);
            foreach (var item in doubles)
            {
                Console.WriteLine(item + "");
            }
            Console.WriteLine();

            #endregion

            //参数数组 关键字params 用来修饰数组参数
            //参数数组 直接可以输入不定个数的类型参数，以逗号分割
            double[] douArr = { 1, 2, 3 };
            double r2 = SumArray(1,2,3,4,5,6,7);
            Console.WriteLine(r2);

            //输出类型out 需要方法返回多个结果时使用

            Calcu(1,2, out double p1, out double p2, out double p3, out double p4);
        }



        public static int Add(int a, int b)
        {
            a += 10;
            b *= 2;
            return a + b;
        }

        public static int Add(ref int a, int b)
        {
            a += 10;
            b *= 2;
            return a + b;
        }

        public static void ScaleArray(double[] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] *= 2;
            }
        }

        public static double SumArray(params double[] doubles)
        {
            double sum = 0;
            for (int i = 0; i< doubles.Length; i++)
            {
                sum += doubles[i];
            }

            return sum;
        }

        public static void Calcu(double a, double b, 
                            out double addRes, out double subRes,
                            out double mulRes, out double divRes)
        {
            addRes = a + b;
            subRes = b - a;
            mulRes = a * b;
            divRes = a / b;

        }
    }
}
