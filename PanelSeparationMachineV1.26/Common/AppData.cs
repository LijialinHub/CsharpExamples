using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanelSeparationMachineV1._26
{

    /// <summary>
    /// 应用程序数据类
    /// </summary>
    public class AppData
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

    }
}
