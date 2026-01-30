using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
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
        /// 视觉修正后的机械矩阵关系
        /// </summary>
        private HTuple visionCorrectMachineMatrix;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hWindowControl"></param>
        public CemeraVisionHandleBLL(HWindowControl hWindowControl)
        {
            imageProcessing = new ImageProcessing(hWindowControl);
        }


        #region 相机部分



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

        #endregion


        #region 视觉部分

        /// <summary>
        /// 绘制ROI
        /// </summary>
        /// <param name="roiSelect"></param>
        /// <param name="roiName"></param>
        public bool DrawROI(RoiSelect roiSelect, string roiName, out string res)
        {
            try
            {
                imageProcessing.MakeROI(roiSelect, roiName);
                res = "绘制ROI成功!";
                return true;
            }
            catch (Exception ex)
            {
                res = "绘制ROI失败！ "+ ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 创建模板
        /// </summary>
        /// <param name="modelName"></param>
        public bool CreateModel(string modelName, out string res)
        {
            try
            {
                imageProcessing.CreateShapeModel(modelName);
                res = "创建模板成功！";
                return true;
            }
            catch (Exception ex)
            {
                res = "创建模板失败！" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 执行匹配
        /// </summary>
        /// <param name="shapeModeName"></param>
        /// <param name="minScores"></param>
        /// <param name="maxOverlap"></param>
        /// <param name="greediness"></param>
        /// <returns></returns>
        public PixelPos ExcuteMatch(string shapeModeName, double minScores, double maxOverlap,
                                    double greediness )
        {
            
            List<PixelPos> matches = imageProcessing.FindShapeModel(shapeModeName, minScores, 1, maxOverlap,
                                                                         greediness, "red", 2, "green", "yellow", 15);
            imageProcessing.DisplayNGOrOK(matches);
            if (matches.Count == 0) { return null; }
            return matches[0];

        }

        /// <summary>
        /// 图像高度
        /// </summary>
        public double ImageHeight
        {
            get
            {
                return imageProcessing.hv_Height;
            }
        }

        /// <summary>
        /// 图像宽度
        /// </summary>
        public double ImageWidth
        {
            get
            {
                return imageProcessing.hv_Width;
            }
        }


        /// <summary>
        /// 获取视觉修正后的机械矩阵
        /// </summary>
        /// <param name="cameraVisionEntity">相机视觉参数实体</param>
        /// <param name="newMarkPos">相机修正后坐标</param>
        public void GetVisionCorrectMachineMatrix(CameraVisionEntity cameraVisionEntity,
                                                MachineCoordEntity[] newMarkPos)
        {
            MachineCoordEntity[] oldPos = new MachineCoordEntity[2]
            {
                cameraVisionEntity.TBMachineMark1,
                cameraVisionEntity.TBMachineMark2
            };

            imageProcessing.GetCorrectMatrix(oldPos, newMarkPos, out HTuple matrix);
            visionCorrectMachineMatrix = matrix;
        }


        /// <summary>
        /// 修改点坐标
        /// </summary>
        /// <param name="old">以前的点坐标</param>
        /// <param name="newPos">新的点坐标</param>
        public void CorrectPoint(MachineCoordEntity old,
                                out MachineCoordEntity newPos)
        {
            MachineCoordEntity machine = new MachineCoordEntity();
            imageProcessing.GetAffineTransPoint(visionCorrectMachineMatrix, 
                                                old, machine);
            newPos = machine;
            
        }



        #endregion


    }
}
