using System;
using System.Collections.Generic;
using GxIAPINET;
using HalconDotNet;

namespace DAL
{
    /// <summary>
    /// 做一个抽象类，
    /// 把图像采集所需要的方法都抽象出来，以从便程序能适用于各种相机
    /// </summary>
    public abstract class CameraClass
    {
        /// <summary>
        /// 打开相机
        /// </summary>
        /// <param name="strSN">ID号</param>
        public abstract void OpenCamera(string strSN);
        /// <summary>
        /// 关闭相机
        /// </summary>
        public abstract void CloseCamera();
        /// <summary>
        /// 单张采集
        /// </summary>
        /// <param name="m_Iamge">采集输出的图像</param>
        public abstract void AcquireSingleImage(out HObject m_Iamge);
        /// <summary>
        /// 连续采集
        /// </summary>
        /// <param name="hwindow">Halcon显示窗体</param>
        public abstract void ContinueGrab(HWindow hwindow);
        /// <summary>
        /// 停止采集
        /// </summary>
        public abstract void StopGrab();
        /// <summary>
        /// 设置曝光
        /// </summary>
        /// <param name="ExposureRaw">曝光值</param>
        public abstract void SetExposureRaw(double ExposureRaw);

        /// <summary>
        /// 设置增益
        /// </summary>
        /// <param name="GainRaw">增益值</param>
        public abstract void SetGainRaw(double GainRaw);
    }

}
