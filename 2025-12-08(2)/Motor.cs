using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _2025_12_08_2_
{   
    /// <summary>
    /// 电机类
    /// </summary>
    public  class Motor : INotifyPropertyChanged  //目的:数据绑定
    {
        /// <summary>
        /// 分钟
        /// </summary>
        public int nudMinute { get; set; } 

        /// <summary>
        /// 秒
        /// </summary>
        public int nudSecond { get; set; }

        /// <summary>
        /// 电机状态
        /// </summary>
        private bool _motorstate;
        public bool motorSstate
        {

            get { return _motorstate; }
            set
            {
                if (_motorstate == value) { return; }
                _motorstate = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// 已运行秒数
        /// </summary>
        public int runSeconds { get; set; }= 0;

        /// <summary>
        /// 属性改变事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 属性发生改变执行的方法
        /// </summary>
        /// <param name="propertyName">属性名 CallerMemberName特性可以自动获取属性名</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
