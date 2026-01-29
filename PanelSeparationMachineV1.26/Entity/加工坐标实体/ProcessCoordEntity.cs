using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{   
    /// <summary>
    /// 加工坐标实体类
    /// </summary>
    public class ProcessCoordEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 数据库主键ID（唯一码）
        /// </summary>
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
                if (value == _Num) { return; }
                _Num = value;
                OnPropertyChanged();
            }
        }

        private double _XPosition;
        /// <summary>
        /// X坐标
        /// </summary>
        public double XPosition
        {
            get { return _XPosition; }
            set
            {
                if (value == _XPosition) { return;}
                _XPosition = value;
                OnPropertyChanged();
            }
        }

        private double _YPosition;
        /// <summary>
        /// Y坐标
        /// </summary>
        public double YPosition
        {
            get { return _YPosition; }
            set
            {
                if (value == _YPosition) { return; }
                _YPosition = value;
                OnPropertyChanged();
            }
        }

        private double _ZPosition;
        /// <summary>
        /// Z坐标
        /// </summary>
        public double ZPosition
        {
            get { return _ZPosition; }
            set
            {
                if (value == _ZPosition) { return; }
                _ZPosition = value;
                OnPropertyChanged();
            }
        }

    }
}
