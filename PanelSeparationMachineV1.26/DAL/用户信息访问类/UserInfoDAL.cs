using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //[Serializable]
    public class UserInfoDAL
    {   
        /// <summary>
        /// 保存用户数据
        /// </summary>
        /// <param name="userEntities">用户实体集合</param>
        public void SaveUserData(List<UserEntity> userEntities)
        {
            try
            {
                string path = Environment.CurrentDirectory + @"\用户信息.txt";
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fs, userEntities);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 读取用户数据
        /// </summary>
        /// <returns></returns>
        public List<UserEntity> ReadUserData()
        { 
            try
            {
                List<UserEntity> userEntities;
                string path = Environment.CurrentDirectory + @"\用户信息.txt";
                if(! File.Exists(path))
                {
                    throw new Exception("文件不存在！");
                }
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    userEntities =  binaryFormatter.Deserialize(fs) as List<UserEntity>;
                }
                return userEntities;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
