using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using HalconDotNet;

namespace BLL
{   
    /// <summary>
    /// 相机视觉处理业务逻辑
    /// </summary>
    public class CemeraVisionHandleBLL
    {   
        /// <summary>
        /// 相机对象
        /// </summary>
        private CameraClass camera = new MERCameraClass(0); //大恒相机

        /// <summary>
        /// 图像处理
        /// </summary>
        private ImageProcessing imageProcessing;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hWindowControl"></param>
        public CemeraVisionHandleBLL(HWindowControl hWindowControl)
        {
            imageProcessing = new ImageProcessing(hWindowControl);
        }

        /// <summary>
        /// 打开相机
        /// </summary>
        /// <param name="strSn">相机序列号</param>
        public void OpenCamera(string strSn)
        {
            camera.OpenCamera(strSn);
        }

        /// <summary>
        /// 关闭相机
        /// </summary>
        public void CloseCamera() 
        {
            camera.CloseCamera();
        }

        /// <summary>
        /// 单次采集
        /// </summary>
        public void SingleAcq()
        {
            camera.AcquireSingleImage(out imageProcessing.ho_Image);
            imageProcessing.DisplayImageAgain();
        }

        /// <summary>
        /// 连续采集
        /// </summary>
        public void ContinueAcq()
        {
            camera.ContinueGrab(imageProcessing.hWindowControl.HalconWindow);
        }

        /// <summary>
        /// 停止连续采集
        /// </summary>
        public void StopContinueAcq()
        {
            camera.StopGrab();
        }

        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="exposureTime"></param>
        public void SetExposure(double exposureTime)
        {
            camera.SetExposureRaw(exposureTime);
        }

        /// <summary>
        /// 设置增益
        public void SetGain(double gain)
        {
            camera.SetGainRaw(gain);
        }
    }
}
