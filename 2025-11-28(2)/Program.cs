using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace _2025_11_28_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region File类
            ////FIle类的常用方法
            ////AppendAllText 复制 Copy 创建Create 删除Delete 
            ////Exists 判断文件是否存在  移动/剪切Move
            ////读取文件内容：ReadAllText 写入文件内容WriteAllText

            //string path = Environment.CurrentDirectory + "\\测试文件.txt";
            //if (!File.Exists(path))
            //{   
            //    //File.Create方法是以文件流形式创建文件的，文件流无法自动释放
            //    //所以会一直占用资源，直到应用程序退出
            //    //一般继承了IDisposable接口的，可能人为手动释放
            //    FileStream fs = File.Create(path);
            //    fs.Dispose(); //释放由System.IO.Stream使用的所有资源
            //    fs.Close();  //关闭当前流并释放之前关联的所有资源 如套接字和文件句柄
            //                 //不直接调用此方法 而应确保流正确释放   

            //}
            //else
            //{
            //    string contend = "//FIle类的常用方法\r\n//AppendAllText 复制 Copy 创建Create 删除Delete \r\n//Exists 判断文件是否存在  移动/剪切Move\r\n//读取文件内容：ReadAllText 写入文件内容WriteAllText";
            //    File.WriteAllText(path, contend);
            //    File.AppendAllText(path, contend);

            //    //File.Copy(path, "C:\\Users\\Lijialin\\Desktop\\txtCp.txt",true);

            //    File.Move(path, "C:\\Users\\Lijialin\\Desktop\\txtCp.txt");

            //    File.Delete("C:\\Users\\Lijialin\\Desktop\\txtCp.txt");

            //}
            #endregion


            #region FileStream类
            ////FileStream:文件流类
            ////可以处理任何格式的文件的读写(以字节形式)
            ////是以 流 的形式处理，适用于大容量文件
            ////一个类如果集成类IDisposable接口
            ////一般不会通过GC自动回收释放资源，这时有两种解决方案
            ////1.手动释放资源（调用Dispose或者Close方法）
            ////2.使用using(){} 结构


            ////使用FileStream进行读取
            //string path = @"C:\Users\Lijialin\Desktop\sql.txt";
            //using (FileStream fs = new FileStream(path, FileMode.Open,FileAccess.Read))
            //{
            //    //1KB=1024B 1MB=1024KB 1GB=1024MB
            //    List<byte> strList = new List<byte>();
            //    byte[] buffer = new byte[10];
            //    int byteRead = 0;


            //    while( (byteRead = fs.Read(buffer, 0, 10)) > 0)
            //    {
            //        //int num = fs.Read(bt, 0, 1000); //num是实际读到字节数，如果是0 则读完了

            //        //Console.Write(Encoding.UTF8.GetString(buffer, 0, byteRead)) ;
            //        //Console.Write(Encoding.Default.GetString(buffer, 0, byteRead)) ;
            //        for (int i = 0; i < byteRead; i++)
            //        {
            //            strList.Add(buffer[i]);
            //        }

            //    }
            //    string allContend = Encoding.UTF8.GetString(strList.ToArray());
            //    Console.WriteLine(allContend);
            //}



            #endregion


            #region 使用FileStream 写入

            //string path = "./写入.txt";
            //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            //{
            //    string str = " //FileStream:文件流类\r\n " +
            //        "可以处理任何格式的文件的读写(以字节形式)\r\n" +
            //        "是以 流 的形式处理，适用于大容量文件\r\n" +
            //        "一个类如果集成类IDisposable接口\r\n" +
            //        "一般不会通过GC自动回收释放资源，这时有两种解决方案\r\n" +
            //        "1.手动释放资源（调用Dispose或者Close方法）\r\n" +
            //        "2.使用using(){} 结构\r\n";


            //    byte[] buffers = Encoding.UTF8.GetBytes(str);

            //    fs.Write(buffers, 0, buffers.Length);




            #endregion


            #region 使用FileStream复制文件(边读边写)

            //string p1 = "D:\\1.mp4";
            //string p2 = "D:\\2.mp4";

            //using (FileStream fs = new FileStream(p1, FileMode.Open, FileAccess.Read)) 
            //{
            //    using (FileStream fsw = new FileStream(p2, FileMode.Create, FileAccess.Write)) 
            //    {
            //        byte[] buffer = new byte[1024*1024]; //每次处理1m
            //        while (true) { 
            //            int num = fs.Read(buffer, 0, buffer.Length);
            //            if (num == 0) { break; }
            //            fsw.Write(buffer, 0, num);
            //        }
            //    }
            //}


            #endregion


            #region 序列化和反序列化
            //序列化是将对象的状态转化为可存储(相当于小型数据库)或可传输数据格式，相当于压缩
            //反序列化:把收到的字节流或者文本格式数据，还原成内存中的对象，想三姑解压缩
            //常用序列化和反序列化
            //1.二进制格式序列化和反序列化(.Net Framework中的类 BinaryFormatter)
            //2.XML格式序列化和反序列化(.Net Framework中的类XmlSerializer)
            //3.Json格式序列化和反序列化(使用第三方类库Nuget找)

            #region 二进制序列化和反序列化
            //二进制格式序列化和反序列化(二进制格式有一个加密性，各种数据类型都可以处理)
            //List<Student> stuList = new List<Student>() 
            //{ 
            //    new Student(){Name = "张三",Age = 25, Sex = Sex.Man, Avatar = Image.FromFile(@"D:\\安装包\\i6tse-3rp8m-001.ico")},

            //    new Student(){Name = "李四",Age = 18, Sex = Sex.Woman, Avatar = Image.FromFile(@"D:\\安装包\\文件.png")},
            //};

            //BinaryFormatter binaryFormatter = new BinaryFormatter();

            //FileStream fs = new FileStream("x.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //binaryFormatter.Serialize(fs, stuList);
            //fs.Close();

            
            //string path = "./x.txt";

            //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            //BinaryFormatter binaryFormatter = new BinaryFormatter();
            //Object ob = binaryFormatter.Deserialize(fs);

            //List<Student> students = ob as List<Student>;

            //fs.Close();

            //foreach (var item in students)
            //{
            //    item.ShowInfo();
            //}


            #endregion

            #region XML序列化和反序列化

            //List<Student> stulist = new List<Student>()
            //{
            //    new Student(){Name = "张三",Age = 25, Sex = Sex.Man},
            //    new Student(){Name = "李四",Age = 18, Sex = Sex.Woman},
            //};
            //string path = "xmlSerializer.xml";
            //using (FileStream fs = new FileStream(path,FileMode.Create, FileAccess.Write))
            //{
            //    XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            //    serializer.Serialize(fs, (Object)stulist);
            //}

            ////反序列化
            //using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            //{
            //    XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            //    List<Student> students = serializer.Deserialize(fs) as List<Student>;

            //    foreach (var item in students)
            //    {
            //        item.ShowInfo();
            //    }
            //}


            #endregion

            #region Json格式序列化和反序列化
            //List<Student> stulist = new List<Student>()
            //{
            //    new Student(){Name = "张三",Age = 25, Sex = Sex.Man},
            //    new Student(){Name = "李四",Age = 18, Sex = Sex.Woman},
            //};

            //string strJson = JsonConvert.SerializeObject(stulist);
            //File.WriteAllText("jsTest.json", strJson);

            ////反序列化
            //string localStr = File.ReadAllText("jsTest.json");
            //List<Student> stulist2 = JsonConvert.DeserializeObject<List<Student>>(localStr);


            #endregion


            #endregion

        }

    }

    /// <summary>
    /// 学生类
    /// </summary>

    //[Serializable] //Serializable：可序列化特性
    //要进行二进制序列化必须加上Serializable特性
    //特性是一个类，作用类似一个标签

   
    public class Student       //要进行xml格式序列化和反序列化，
                               //这个类必须要有无参构造函数 ，否则报错
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [XmlAttribute("姓名")]
        //[XmlIgnore] 忽略本属性 不保存
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [XmlAttribute("年龄")]
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [XmlAttribute("性别")]
        public Sex Sex { get; set; }

        /// <summary>
        /// 头像图像数据
        /// </summary>
        public Image Avatar { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"我叫{Name} 今年 {Age}岁，性别 {Sex}");
        }

    }

    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum Sex
    {
        Man,
        Woman
    }

}


