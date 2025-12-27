using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace _2025_12_18
{

    /// <summary>
    /// 串口参数实体类
    /// </summary>
    public class SerialParamatersEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 属性改变触发的方法
        /// </summary>
        /// <param name="propertyName"></param>
        //CallerMemberName 属性会自动获取调用该方法的属性名称
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _PortName;
        /// <summary>
        /// 端口号
        /// </summary>
        public string PortName
        {
            get { return _PortName; }
            set
            {
                if (_PortName == value) { return; }
                _PortName = value;
                OnPropertyChanged();
            }
        }

        private int _BaudRate;
        /// <summary>
        /// 波特率 (2400,4800, 9600,19200,28400,57600,115200等标准波特率 单位bps)
        /// </summary>
        public int BaudRate
        {
            get { return _BaudRate; }
            set 
            { 
                if(_BaudRate == value) { return; }
                _BaudRate = value;
                OnPropertyChanged();
            }
        }

        private int _DataBits;
        /// <summary>
        /// 数据位 7或8位
        /// </summary>
        public int DataBits
        {
            get { return _DataBits; }
            set 
            {   
                if(_DataBits == value) { return; }
                _DataBits = value; 
                OnPropertyChanged();
            }
        }

        private Parity _ParityBits;
        /// <summary>
        /// 校验位
        /// </summary>
        public Parity ParityBits
        {
            get { return _ParityBits; }
            set 
            {   
                if(_ParityBits == value) { return; }
                _ParityBits = value;
                OnPropertyChanged();
            }
        }

        private StopBits _StopBits;
        /// <summary>
        /// 停止位
        /// </summary>
        public StopBits StopBits
        {
            get { return _StopBits; }
            set 
            {   
                if(_StopBits == value) { return; }
                _StopBits = value; 
                OnPropertyChanged();
            }
        }

    }
}
