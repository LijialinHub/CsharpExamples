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
    /// 轴类
    /// </summary>
    public class Axis : INotifyPropertyChanged
    {
        #region  轴信息
        private ushort _Axis_CardNo;

        /// <summary>
        /// 控制卡卡号
        /// </summary>
        public ushort Axis_CardNo
        {
            get { return _Axis_CardNo; }
            set
            {
                if (_Axis_CardNo == value) { return; }
                _Axis_CardNo = value;
                OnPropertyChanged();
            }
        }

        private ushort _Axis_Num;

        /// <summary>
        /// 轴号
        /// </summary>
        public ushort Axis_Num
        {
            get { return _Axis_Num; }
            set
            {
                if (_Axis_Num == value) { return; }
                _Axis_Num = value;
                OnPropertyChanged();
            }
        }

        private string _Axis_Name;

        /// <summary>
        /// 轴名
        /// </summary>
        public string Axis_Name
        {
            get { return _Axis_Name; }
            set
            {
                if (_Axis_Name == value) { return; }
                _Axis_Name = value;
                OnPropertyChanged();
            }
        }

        private double _Position;

        /// <summary>
        /// 轴位置(单位：mm 或 °)
        /// </summary>
        public double Position
        {
            get { return _Position; }
            set
            {
                if (_Position == value) { return; }
                _Position = value;
                OnPropertyChanged();
            }
        }

        private double _RunningSpeed;

        /// <summary>
        /// 轴运行速度(单位：mm/s 或 °/s)
        /// </summary>
        public double RunningSpeed
        {
            get { return _RunningSpeed; }
            set
            {
                if (_RunningSpeed == value) { return; }
                _RunningSpeed = value;

                OnPropertyChanged();
            }
        }
        #endregion

        #region 轴的Jog参数（点动/手动）
        private double _Speed_JogStart;

        /// <summary>
        /// 初始速度(单位：mm/s   或者 °/s)
        /// </summary>
        public double Speed_JogStart
        {
            get { return _Speed_JogStart; }
            set
            {
                if (_Speed_JogStart == value) { return; }
                _Speed_JogStart = value;
                OnPropertyChanged();
            }
        }

        private double _Speed_JogHigh;

        /// <summary>
        /// 点动高速(运行速度:mm/s  或者 °/s)
        /// </summary>
        public double Speed_JogHigh
        {
            get { return _Speed_JogHigh; }
            set
            {
                if (_Speed_JogHigh == value) { return; }
                _Speed_JogHigh = value;
                OnPropertyChanged();
            }
        }

        private double _Speed_JogLow;

        /// <summary>
        /// 点动低速(单位：mm/s 或者 °/s)
        /// </summary>
        public double Speed_JogLow
        {
            get { return _Speed_JogLow; }
            set
            {
                if (_Speed_JogLow == value) { return; }
                _Speed_JogLow = value;
                OnPropertyChanged();
            }
        }

        private double _Speed_JogAccTime;

        /// <summary>
        /// 点动加速时间(单位：秒)
        /// </summary>
        public double Speed_JogAccTime
        {
            get { return _Speed_JogAccTime; }
            set
            {
                if (_Speed_JogAccTime == value) { return; }
                _Speed_JogAccTime = value;
                OnPropertyChanged();
            }
        }

        private double _Speed_JogDecTime;

        /// <summary>
        /// 点动减速时间(单位：秒)
        /// </summary>
        public double Speed_JogDecTime
        {
            get { return _Speed_JogDecTime; }
            set
            {
                if (_Speed_JogDecTime == value) { return; }
                _Speed_JogDecTime = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region 轴的自动参数
        private double _Speed_autoStart;

        /// <summary>
        /// 自动起始速度(单位：mm/s   或者 °/s)
        /// </summary>
        public double Speed_autoStart
        {
            get { return _Speed_autoStart; }
            set
            {
                if (_Speed_autoStart == value) { return; }
                _Speed_autoStart = value;
                OnPropertyChanged();
            }
        }

        private double _Speed_autoMax;

        /// <summary>
        /// 自动最大速度(单位：mm/s)
        /// </summary>
        public double Speed_autoMax
        {
            get { return _Speed_autoMax; }
            set
            {
                if (_Speed_autoMax == value) { return; }
                _Speed_autoMax = value;
                OnPropertyChanged();
            }
        }


        private double _Speed_autoAccTime;

        /// <summary>
        /// 自动加速时间(单位：秒)
        /// </summary>
        public double Speed_autoAccTime
        {
            get { return _Speed_autoAccTime; }
            set
            {
                if (_Speed_autoAccTime == value) { return; }
                _Speed_autoAccTime = value;
                OnPropertyChanged();
            }
        }


        private double _Speed_autoDecTime;

        /// <summary>
        /// 自动减速时间(单位：秒)
        /// </summary>
        public double Speed_autoDecTime
        {
            get { return _Speed_autoDecTime; }
            set
            {
                if (_Speed_autoDecTime == value) { return; }
                _Speed_autoDecTime = value;
                OnPropertyChanged();
            }
        }
        #endregion


        #region 轴回原点参数
        private double _Speed_homeStart;

        /// <summary>
        /// 回原点起始速度(单位：mm/s 或者 °/s)
        /// </summary>
        public double Speed_homeStart
        {
            get { return _Speed_homeStart; }
            set
            {
                if (_Speed_homeStart == value) { return; }
                _Speed_homeStart = value;
                OnPropertyChanged();
            }
        }

        private double _Speed_homeMax;

        /// <summary>
        /// 回原点最大速度(单位：mm/s)
        /// </summary>
        public double Speed_homeMax
        {
            get { return _Speed_homeMax; }
            set
            {
                if (_Speed_homeMax == value) { return; }
                _Speed_homeMax = value;
                OnPropertyChanged();
            }
        }

        private double _Speed_homeAccTime;

        /// <summary>
        /// 回原点加速时间(单位：秒 )
        /// </summary>
        public double Speed_homeAccTime
        {
            get { return _Speed_homeAccTime; }
            set
            {
                if (_Speed_homeAccTime == value) { return; }
                _Speed_homeAccTime = value;
                OnPropertyChanged();
            }
        }

        private double _Speed_homeDecTime;

        /// <summary>
        /// 回原点减速时间(单位：秒  或者 °/s)
        /// </summary>
        public double Speed_homeDecTime
        {
            get { return _Speed_homeDecTime; }
            set
            {
                if (_Speed_homeDecTime == value) { return; }
                _Speed_homeDecTime = value;
                OnPropertyChanged();
            }
        }

        private ushort _Home_dir;

        /// <summary>
        /// 回原点方向
        /// </summary>
        public ushort Home_dir
        {
            get { return _Home_dir; }
            set
            {
                if (_Home_dir == value) { return; }
                _Home_dir = value;
                OnPropertyChanged();
            }
        }


        private ushort _Home_speedSel;

        /// <summary>
        /// 回原点速度选择
        /// </summary>
        public ushort Home_speedSel
        {
            get { return _Home_speedSel; }
            set
            {
                if (_Home_speedSel == value) { return; }
                _Home_speedSel = value;
                OnPropertyChanged();
            }
        }

        private ushort _Home_Mode;

        /// <summary>
        /// 回原点模式
        /// </summary>
        public ushort Home_Mode
        {
            get { return _Home_Mode; }
            set
            {
                if (_Home_Mode == value) { return; }
                _Home_Mode = value;
                OnPropertyChanged();
            }
        }

        private bool _OverGoHomeMark;

        /// <summary>
        /// 回原点完成标志(True：已经回到原点；False：未回到原点)
        /// </summary>
        public bool OverGoHomeMark
        {
            get { return _OverGoHomeMark; }
            set
            {
                if (_OverGoHomeMark == value) { return; }
                _OverGoHomeMark = value;
                OnPropertyChanged();
            }
        }
        #endregion


        #region 轴其它参数

        private double _PulseEquivalent;

        /// <summary>
        /// 轴的脉冲当量(pluse/mm  或者  pluse/°)
        /// </summary>
        public double PulseEquivalent
        {
            get { return _PulseEquivalent; }
            set
            {
                if (_PulseEquivalent == value) { return; }
                _PulseEquivalent = value;
                OnPropertyChanged();
            }
        } //根据实际计算

        private double _SoftLimit_P;

        /// <summary>
        /// 正向软限位(单位：mm)
        /// </summary>
        public double SoftLimit_P
        {
            get { return _SoftLimit_P; }
            set
            {
                if (_SoftLimit_P == value) { return; }
                _SoftLimit_P = value;
                OnPropertyChanged();
            }
        }


        private double _SoftLimit_N;

        /// <summary>
        /// 负向软限位(单位：mm)
        /// </summary>
        public double SoftLimit_N
        {
            get { return _SoftLimit_N; }
            set
            {
                if (_SoftLimit_N == value) { return; }
                _SoftLimit_N = value;
                OnPropertyChanged();
            }
        }


        private double _SafePosition;

        /// <summary>
        /// 轴安全位置
        /// </summary>
        public double SafePosition
        {
            get { return _SafePosition; }
            set
            {
                if (_SafePosition == value) { return; }
                _SafePosition = value;
                OnPropertyChanged();
            }
        }

        private double _WorkSpeed;

        /// <summary>
        /// 轴工作速度(单位：mm/s)
        /// </summary>
        public double WorkSpeed
        {
            get { return _WorkSpeed; }
            set
            {
                if (_WorkSpeed == value) { return; }
                _WorkSpeed = value;
                OnPropertyChanged();
            }
        }

        private double _WaitingPosition;

        /// <summary>
        /// 加工等待位(单位：mm 或者  °/pluse)
        /// </summary>
        public double WaitingPosition
        {
            get { return _WaitingPosition; }
            set
            {
                if (_WaitingPosition == value) { return; }
                _WaitingPosition = value;
                OnPropertyChanged();
            }
        }

        private bool _ExceptionStop;

        /// <summary>
        /// 轴异常停止
        /// </summary>
        public bool ExceptionStop
        {
            get { return _ExceptionStop; }
            set
            {
                if (_ExceptionStop == value) { return; }
                _ExceptionStop = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// 急停标志
        /// </summary>
        public volatile static bool EmgMark;


        /// <summary>
        /// 暂停标志
        /// </summary>
        public volatile static bool PauseMark;


        /// <summary>
        /// 脉冲输出模式
        /// </summary>
        public ushort PulseOutMode { get; set; } = 0;
        #endregion


        #region 轴信号

        private bool _IsRunning;
        /// <summary>
        /// 运行信号(True：正在运行 False：停止中)
        /// </summary>
        public bool IsRunning
        {
            get { return _IsRunning; }
            set
            {
                if (_IsRunning == value) { return; }
                _IsRunning = value;
                OnPropertyChanged();
            }
        }

        public bool _Org;
        /// <summary>
        /// 原点信号
        /// </summary>
        public bool Org
        {
            get { return _Org; }
            set
            {
                if (_Org == value) { return; }
                _Org = value;
                OnPropertyChanged();
            }
        }


        public bool _PositiveLimit;
        /// <summary>
        /// 正限位
        /// </summary>
        public bool PositiveLimit
        {
            get { return _PositiveLimit; }
            set
            {
                if (_PositiveLimit == value) { return; }
                _PositiveLimit = value;
                OnPropertyChanged();
            }
        }

        public bool _NegativeLimit;

        /// <summary>
        /// 负限位
        /// </summary>
        public bool NegativeLimit
        {
            get { return _NegativeLimit; }
            set
            {
                if (_NegativeLimit == value) { return; }
                _NegativeLimit = value;
                OnPropertyChanged();
            }
        }

        public bool _FaultAlrm;

        /// <summary>
        /// 故障报警信号
        /// </summary>
        public bool FaultAlrm
        {
            get { return _FaultAlrm; }
            set
            {
                if (_FaultAlrm == value) { return; }
                _FaultAlrm = value;
                OnPropertyChanged();
            }
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 属性改变
        /// </summary>
        /// <param name="propertyName">属性名</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
