using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PanelSeparationMachineV1._26
{

    /// <summary>
    /// 应用程序数据类
    /// </summary>
    public class AppData : INotifyPropertyChanged
    {

        /// <summary>
        /// 绘图参数(来自Ini文件)
        /// </summary>
        public static DrawParamsEntity DrawParamsEntity = new DrawParamsEntity();

        /// <summary>
        /// 当前用户实体对象
        /// </summary>
        public static UserEntity CurrentUserEntity = new UserEntity();

        /// <summary>
        /// Roi选择
        /// </summary>
        public static RoiSelect RoiSelect;

        /// <summary>
        /// 设备信息实体
        /// </summary>
        public static DeviceInfoEntity deviceInfoEntity = new DeviceInfoEntity();



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
