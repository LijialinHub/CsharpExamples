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



        private double _Greedness;
        /// <summary>
        /// 贪婪度
        /// </summary>
        public double Greedness
        {
            get { return _Greedness; }
            set
            {
                if (_Greedness == value) { return; }
                _Greedness = value;
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





    }
}
