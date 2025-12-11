/*
 * 用户： INI配置文件操作类
 * 日期: 2015/1/10
 * 时间: 13:55
 */

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Specialized;

namespace IniHelper
{
	/// <summary>
	/// IniFiles的类
	/// </summary>
	public class IniFiles
	{
		public string FileName; //INI文件名
		
		//声明读写INI文件的API函数
		[DllImport("kernel32")] //特性 里面添加路径:1.相对路径(项目exe所在的文件夹中)
								//					2.绝对路径
								//					3.环境变量路径
		//extern：外部的，关键字 修饰一个方法，外部方法
		private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);
		
		//类的构造函数，传递INI文件名
		public IniFiles(string AFileName)
		{
			// 判断文件是否存在
			var fileInfo = new FileInfo(AFileName);
			//Todo:搞清枚举的用法
			
			if ((!fileInfo.Exists))
			{
				//|| (FileAttributes.Directory in fileInfo.Attributes))
				//文件不存在，建立文件
				//var sw = new StreamWriter(AFileName, false, Encoding.Default);
				try
				{
					//sw.Write("#表格配置档案");
					//sw.Close();
				}

				catch
				{
					throw (new ApplicationException("Ini文件不存在"));
				}
			}
			//必须是完全路径，不能是相对路径
			FileName = fileInfo.FullName;
		}

        /// <summary>
        /// 以字符串形式写入ini
        /// </summary>
        /// <param name="Section">节点</param>
        /// <param name="Key">关键字</param>
        /// <param name="Value">值</param>
        public void WriteString(string Section, string Key, string Value)
		{
			if (!WritePrivateProfileString(Section, Key, Value, FileName))
			{
				
				throw (new ApplicationException("写Ini文件出错"));
			}
		}

        /// <summary>
        /// 以字符串形式从ini中读取
        /// </summary>
        /// <param name="Section">节点</param>
        /// <param name="Key">关键字</param>
        /// <param name="Default">默认值</param>
        /// <param name="return">未找到(Section下的关键字，则返回默认值）</return>


        public string ReadString(string Section, string Key, string Default)
		{
			var Buffer = new Byte[65535];
			int bufLen = GetPrivateProfileString(Section, Key, Default, Buffer, Buffer.GetUpperBound(0), FileName);
			//必须设定0（系统默认的代码页）的编码方式，否则无法支持中文
			string s = Encoding.GetEncoding(0).GetString(Buffer);
			s = s.Substring(0, bufLen);
			return s.Trim();
		}

		//读整数
		public int ReadInteger(string Section, string Key, int Default)
		{
			string intStr = ReadString(Section, Key, Convert.ToString(Default));
			try
			{
				return Convert.ToInt32(intStr);

			}
			catch (Exception ex)
			{
				Console.WriteLine("39. " + ex.Message);
				return Default;
			}
		}

		//写整数
		public void WriteInteger(string Section, string Key, int Value)
		{
			WriteString(Section, Key, Value.ToString());
		}

		//读布尔
		public bool ReadBool(string Section, string Key, bool Default)
		{
			try
			{
				return Convert.ToBoolean(ReadString(Section, Key, Convert.ToString(Default)));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return Default;
			}
		}

		//写Bool
		public void WriteBool(string Section, string Key, bool Value)
		{
			WriteString(Section, Key, Convert.ToString(Value));
		}

		private void GetStringsFromBuffer(Byte[] Buffer, int bufLen, StringCollection Strings)
		{
			Strings.Clear();
			if (bufLen != 0)
			{
				int start = 0;
				for (int i = 0; i < bufLen; i++)
				{
					if ((Buffer[i] == 0) && ((i - start) > 0))
					{
						String s = Encoding.GetEncoding(0).GetString(Buffer, start, i - start);
						Strings.Add(s);
						start = i + 1;
					}
				}
			}
		}
		
		
		//从Ini文件中，将指定的Section名称中的所有Key添加到列表中
		public void ReadSection(string Section, StringCollection Keys)
		{
			var Buffer = new Byte[16384];
			//Keys.Clear();

			int bufLen = GetPrivateProfileString(Section, null, null, Buffer, Buffer.GetUpperBound(0),
			                                     FileName);
			//对Section进行解析
			GetStringsFromBuffer(Buffer, bufLen, Keys);
		}
				
		//从Ini文件中，读取所有的Sections的名称
		public void ReadSections(StringCollection SectionList)
		{
			//Note:必须得用Bytes来实现，StringBuilder只能取到第一个Section
			var Buffer = new byte[65535];
			int bufLen = 0;
			bufLen = GetPrivateProfileString(null, null, null, Buffer,
			                                 Buffer.GetUpperBound(0), FileName);
			GetStringsFromBuffer(Buffer, bufLen, SectionList);
		}
		
		//读取指定的Section的所有Value到列表中
		public void ReadSectionValues(string Section, NameValueCollection Values)
		{
			var KeyList = new StringCollection();
			ReadSection(Section, KeyList);
			Values.Clear();
			foreach (string key in KeyList)
			{
				Values.Add(key, ReadString(Section, key, ""));
				
			}
		}
		
		/**/////读取指定的Section的所有Value到列表中，
		//public void ReadSectionValues(string Section, NameValueCollection Values,char splitString)
		//{　 string sectionValue;
		//　　string[] sectionValueSplit;
		//　　StringCollection KeyList = new StringCollection();
		//　　ReadSection(Section, KeyList);
		//　　Values.Clear();
		//　　foreach (string key in KeyList)
		//　　{
		//　　　　sectionValue=ReadString(Section, key, "");
		//　　　　sectionValueSplit=sectionValue.Split(splitString);
		//　　　　Values.Add(key, sectionValueSplit[0].ToString(),sectionValueSplit[1].ToString());
		
		//　　}
		//}
		//清除某个Section
		
		public void EraseSection(string Section)
		{
			if (!WritePrivateProfileString(Section, null, null, FileName))
			{

				throw (new ApplicationException("无法清除Ini文件中的Section"));
			}
		}
		
		//删除某个Section下的键
		public void DeleteKey(string Section, string Key)
		{
			WritePrivateProfileString(Section, Key, null, FileName);
		}
		
		//Note:对于Win9X，来说需要实现UpdateFile方法将缓冲中的数据写入文件
		//在Win NT, 2000和XP上，都是直接写文件，没有缓冲，所以，无须实现UpdateFile
		//执行完对Ini文件的修改之后，应该调用本方法更新缓冲区。
		public void UpdateFile()
		{
			WritePrivateProfileString(null, null, null, FileName);
		}

		//检查某个Section下的某个键值是否存在
		public bool ValueExists(string Section, string Key)
		{
			var Keys = new StringCollection();
			ReadSection(Section, Keys);
			return Keys.IndexOf(Key) > -1;
		}

		//确保资源的释放,析构函数
		~IniFiles()
		{
			UpdateFile();
		}
	}
}
