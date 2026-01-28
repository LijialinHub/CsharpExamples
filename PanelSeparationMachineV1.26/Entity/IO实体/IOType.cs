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
    /// IO信息类
    /// </summary>
    public class IOType : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private string _name;
        /// <summary>
        /// IO名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {   
                if (_name == value) { return;} 
                _name = value;
                OnPropertyChanged();
            }
        }


        private ushort _cardNo;
        /// <summary>
        /// 控制卡号
        /// </summary>
        public ushort CardNo
        {
            get { return _cardNo; }
            set
            {
                if (_cardNo == value) { return; }
                _cardNo = value;
                OnPropertyChanged();
            }
        }


        private ushort _bitNo;
        /// <summary>
        /// 位号
        /// </summary>
        public ushort BitNo
        {
            get { return _bitNo; }
            set
            {
                if (_bitNo == value) { return; }
                _bitNo = value;
                OnPropertyChanged();
            }
        }


        private bool _StatusValue;
        /// <summary>
        /// 状态值
        /// </summary>
        public bool StatusValue
        {
            get { return _StatusValue; }
            set
            {
                if (_StatusValue == value) { return; }
                _StatusValue = value;
                OnPropertyChanged();
            }
        }
    }
}
