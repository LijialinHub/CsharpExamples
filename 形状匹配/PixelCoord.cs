using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace 形状匹配
{
    public class PixelCoord : INotifyPropertyChanged
    {   

        public int Id { get; set; }
        
        private int _Num;
        /// <summary>
        /// 编号
        /// </summary>
        public int Num
        {
            get { return _Num; }
            set
            {
                if(_Num == value)  return;
                _Num = value;
                OnPropertyChanged();
            }
        }


        private double _Row;
        /// <summary>
        /// 行
        /// </summary>
        public double Row
        {
            get { return _Row; }
            set
            {
                if (_Row == value) return;
                _Row = value;
                OnPropertyChanged();
            }
        }


        private double _Col;
        /// <summary>
        /// 列
        /// </summary> 
        public double Col
        {
            get { return _Col; }
            set
            {
                if (_Col == value) return;
                _Col = value;
                OnPropertyChanged();
            }
        }


        private double _Angle;
        /// <summary>
        /// 角度
        /// </summary> 
        public double Angle
        {
            get { return _Angle; }
            set
            {
                if (_Angle == value) return;
                _Angle = value;
                OnPropertyChanged();
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
