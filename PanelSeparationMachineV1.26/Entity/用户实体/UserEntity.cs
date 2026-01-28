using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class UserEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        /// <summary>
        /// 职级
        /// </summary>
        public enum Level   //特性的获取要通过反射技术
        {
            [DescriptionCustom("操作员")]
            Operator = 0,
            [DescriptionCustom("技术员")]
            Technician = 1,
            [DescriptionCustom("工程师")]
            Engineer = 2,
            [DescriptionCustom("高级工程师")]
            SeniorEngineer = 3,
            [DescriptionCustom("经理")]
            Manager = 4,
            [DescriptionCustom("管理员")]
            Administrator = 100
        }

        /// <summary>
        /// 性别
        /// </summary>
        public enum Sex
        {   
            [DescriptionCustom("男")]
            Man,
            [DescriptionCustom("女")]
            Woman
        }




        public int Id { get; set; }

        private string _EmployeeID;
        /// <summary>
        /// 工号
        /// </summary>
        public string EmployeeID
        {
            get { return _EmployeeID; }
            set
            {   
                if (_EmployeeID == value) { return;}
                _EmployeeID = value;
                OnPropertyChanged();
            }
        }
        

        private string _Name;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name == value) { return; }
                _Name = value;
                OnPropertyChanged();
            }
        }


        private int _Age;
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age
        {
            get { return _Age; }
            set
            {
                if (_Age == value) { return; }
                _Age = value;
                OnPropertyChanged();
            }
        }



        private string _Password;
        /// <summary>
        /// 密码
        /// </summary>

        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password == value) { return; }
                _Password = value;
                OnPropertyChanged();
            }
        }


        private Level _JobLevel;

        /// <summary>
        /// 职级
        /// </summary>
        public Level JobLevel
        {
            get { return _JobLevel; }
            set
            {
                if (_JobLevel == value) { return; }
                _JobLevel = value;
                OnPropertyChanged();
            }
        }

        private Sex _Gender;
        /// <summary>
        /// 性别
        /// </summary>
        public Sex Gender
        {
            get { return _Gender; }
            set
            {
                if (_Gender == value) { return; }
                _Gender = value;
                OnPropertyChanged();
            }
        }


        private string _AvatarFileName;
        /// <summary>
        /// 头像文件名
        /// </summary>
        public string AvatarFileName
        {
            get { return _AvatarFileName; }
            set
            {
                if (_AvatarFileName == value) { return; }
                _AvatarFileName = value;
                OnPropertyChanged();
            }
        }

    }


    


}
