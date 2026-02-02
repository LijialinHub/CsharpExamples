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
    /// 设备信息实体
    /// </summary>
    public class DeviceInfoEntity : INotifyPropertyChanged
    {

        /// <summary>
        /// 接口ID(设备ID)
        /// </summary>
        public string InterfaceID { get; set; } = "S220050916";
        
        
        /// <summary>
        /// 已运行时间
        /// </summary>
        public CustomTime RunningTime  { get; set; } = new CustomTime();


        private int _ProductNum;
        /// <summary>
        /// 产品总数
        /// </summary>
        public int ProductNum
        {
            get { return _ProductNum; }
            set
            {   
                if (_ProductNum == value) { return; }
                _ProductNum = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// 自定义时间
    /// </summary>
    [Serializable]
    public class CustomTime
    {
        public int Seconds { get; set; }

        public int Minutes { get; set; }

        public int Hours { get; set; }

        public int Days { get; set; }

    }

}
