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
    /// IO实体类(按钮 传感器 等 阀)
    /// </summary>
    public class IOCraftEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public IOCraftEntity()
        {
            MaterialSignals = new IOType();
            Cutter = new IOType();
        }



        private IOType _MaterialSignals;

        /// <summary>
        /// 物料到位信号(True :物料到位)
        /// </summary>
        public IOType MaterialSignals  //输入信号
        {
            get { return _MaterialSignals; }
            set
            {   
                if (_MaterialSignals == value) { return;}
                _MaterialSignals = value;
                OnPropertyChanged();
            }
        }


        private IOType _Cutter;

        /// <summary>
        /// 切割器 
        /// </summary>
        public IOType Cutter  //输出信号
        {
            get { return _Cutter; }
            set
            {
                if (_Cutter == value) { return; }
                _Cutter = value;
                OnPropertyChanged();
            }
        }
    }
}
