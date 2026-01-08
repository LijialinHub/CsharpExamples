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
    /// 绘制参数实体
    /// </summary>
    public class DrawParamsEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private double _XDrawOffset;
        /// <summary>
        /// 绘制坐标位置X轴偏移量
        /// </summary>
        public double XDrawOffset
        {
            get { return _XDrawOffset; }
            set
            {
               if(value == _XDrawOffset) { return;}
                _XDrawOffset = value;
                OnPropertyChanged();
            }
        }

        private double _YDrawOffset;
        /// <summary>
        /// 绘制坐标位置Y轴偏移量
        /// </summary>
        public double YDrawOffset
        {
            get { return _YDrawOffset; }
            set
            {
                if (value == _YDrawOffset) { return; }
                _YDrawOffset = value;
                OnPropertyChanged();
            }
        }

        private double _XDrawScale;
        /// <summary>
        /// 绘制坐标位置X轴缩放比例
        /// </summary>
        public double XDrawScale
        {
            get { return _XDrawScale; }
            set
            {
                if (value == _XDrawScale) { return; }
                _XDrawScale = value;
                OnPropertyChanged();
            }
        }


        private double _YDrawScale;
        /// <summary>
        /// 绘制坐标位置Y轴缩放比例
        /// </summary>
        public double YDrawScale
        {
            get { return _YDrawScale; }
            set
            {
                if (value == _YDrawScale) { return; }
                _YDrawScale = value;
                OnPropertyChanged();
            }
        }

    }
}
