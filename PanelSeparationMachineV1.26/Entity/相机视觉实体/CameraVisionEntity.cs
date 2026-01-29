using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CameraVisionEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _StrSN;
        /// <summary>
        /// 相机序列号
        /// </summary>
        public string StrSN
        {
            get { return _StrSN; }
            set
            {
                if (_StrSN == value) { return; }
                _StrSN = value;
                OnPropertyChanged();
            }
        }


        private double _ExposeTime;
        /// <summary>
        /// 曝光时间
        /// </summary>
        public double ExposeTime
        {
            get { return _ExposeTime; }
            set
            {   
                if (_ExposeTime == value) { return; }
                _ExposeTime = value;
                OnPropertyChanged();
            }
        }

        private double _Gain;
        /// <summary>
        /// 增益
        /// </summary>
        public double Gain
        {
            get { return _Gain; }
            set
            {
                if (_Gain == value) { return; }
                _Gain = value;
                OnPropertyChanged();
            }
        }


        private double _MaxOverlap;
        /// <summary>
        /// 最大重叠度
        /// </summary>
        public double MaxOverlap
        {
            get { return _MaxOverlap; }
            set
            {
                if (_MaxOverlap == value) { return; }
                _MaxOverlap = value;
                OnPropertyChanged();
            }
        }



        private double _Greediness;
        /// <summary>
        /// 贪婪度
        /// </summary>
        public double Greediness
        {
            get { return _Greediness; }
            set
            {
                if (_Greediness == value) { return; }
                _Greediness = value;
                OnPropertyChanged();
            }
        }


        private double _MatchScores;
        /// <summary>
        /// 匹配分数
        /// </summary>
        public double MatchScores
        {
            get { return _MatchScores; }
            set
            {
                if (_MatchScores == value) { return; }
                _MatchScores = value;
                OnPropertyChanged();
            }
        }


        #region 相机标定用到的数据

        private double _BDHeight;
        /// <summary>
        /// 标定拍照高度
        /// </summary>
        public double BDHeight
        {
            get { return _BDHeight; }
            set
            {
                if (_BDHeight == value) { return; }
                _BDHeight = value;
                OnPropertyChanged();
            }
        }


        private double _XDirPixToMachine;
        /// <summary>
        /// X轴像素和机械比值
        /// </summary>

        public double XDirPixToMachine
        {
            get { return _XDirPixToMachine; }
            set
            {
                if (_XDirPixToMachine == value) { return; }
                _XDirPixToMachine = value;
                OnPropertyChanged();
            }
        }

        private double _YDirPixToMachine;
        /// <summary>
        /// Y轴像素和机械比值
        /// </summary>

        public double YDirPixToMachine
        {
            get { return _YDirPixToMachine; }
            set
            {
                if (_YDirPixToMachine == value) { return; }
                _YDirPixToMachine = value;
                OnPropertyChanged();
            }
        }


        #endregion


    }
}
