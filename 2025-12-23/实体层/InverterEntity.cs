using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _2025_12_23
{
    /// <summary>
    /// 变频器实体对象
    /// </summary>
    public class InverterEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 属性改变触发的方法
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private string _Description;
        /// <summary>
        /// 变频器描述信息
        /// </summary>
        public string Description 
        {
            get 
            {
                return _Description;
            }
            set
            {
                if(value == _Description) { return; }
                _Description = value;
                OnPropertyChanged();
            }
        }


        private byte _StationNumber;
        /// <summary>
        /// 站号
        /// </summary>
        public byte StationNumber
        {
            get
            {
                return _StationNumber;
            }
            set
            {
                if (_StationNumber == value) { return; }
                _StationNumber = value;
                OnPropertyChanged();
            }
        }

        
        private bool _isStop;
        /// <summary>
        /// 运行标志
        /// </summary>
        public bool IsStop
        {
            get
            {
                return _isStop;
            }
            set
            {
                if(_isStop == value) { return; }
                _isStop = value;
                OnPropertyChanged();
            }
        }


        private bool _IsForward;
        /// <summary>
        /// 正转标志
        /// </summary>
        public bool IsForward 
        { 
            get 
            { 
                return _IsForward; 
            }
            set
            {
                if (_IsForward == value) { return; }
                _IsForward = value;
                OnPropertyChanged();
            }
        }


        private bool _IsReverse;
        /// <summary>
        /// 反转标志
        /// </summary>
        public bool IsReverse
        {
            get
            {
                return _IsReverse;
            }
            set
            {
                if (_IsReverse == value) { return; }
                _IsReverse = value;
                OnPropertyChanged();
            }
        }


        private double _RunningFrequency;   
        /// <summary>
        /// 运行频率
        /// </summary>
        public double RunningFrequency
        {
            get
            {
                return _RunningFrequency;
            }
            set
            {
                if (_RunningFrequency == value) { return; }
                _RunningFrequency = value;
                OnPropertyChanged();
            }
        }


        private double _OutputCurrent;
        /// <summary>
        /// 输出电流
        /// </summary>
        public double OutputCurrent
        {
            get
            {
                return _OutputCurrent;
            }
            set
            {
                if (_OutputCurrent == value) { return; }
                _OutputCurrent = value;
                OnPropertyChanged();
            }
        }


        private double _OutputVoltage;
        /// <summary>
        /// 输出电压
        /// </summary>
        public double OutputVoltage
        {
            get
            {
                return _OutputVoltage;
            }
            set
            {
                if (_OutputVoltage == value) { return; }
                _OutputVoltage = value;
                OnPropertyChanged();
            }
        }


    }
}
