using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Halcon_1
{
    public class HalconVision
    {
        /// <summary>
        /// 采集句柄
        /// </summary>
        private HTuple hv_AcqHandle;

        /// <summary>
        /// 要处理的图像
        /// </summary>
        public HObject ho_Image;

        /// <summary>
        /// 显示窗体句柄
        /// </summary>
        public HTuple hv_ExpDefaultWinHandle;

        private HWindowControl hWindowControl;


        public HTuple hv_width, hv_height;

        /// <summary>
        /// 取消信号
        /// </summary>
        private CancellationTokenSource cts;

        private Task realTimeTask;

        /// <summary>
        /// 模板图像
        /// </summary>
        private HObject modelImage;


        public enum RoiSelect
        {
            Circle,
            Rectangle,
            Rectangle2,
            Region
        }


        public HalconVision(HWindowControl hWindowControl)
        {   
            //ctor 快捷键 创建构造函数
            //对于htuple类型，可以不用创建实例
            //对于HObject类型，使用时要HOperatorSet.GenEmptyObj 制造实例 （否则报错 未将对象引用到实例）
            //实例化ho_Image对象(不通过new)
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out modelImage);

            this.hv_ExpDefaultWinHandle = hWindowControl.HalconWindow;
            this.hWindowControl = hWindowControl;

            this.hWindowControl.SizeChanged += HWindowControl1_SizeChanged;

        }


        /// <summary>
        /// 打开相机
        /// </summary>
        public void openCamera()
        {
            try
            {
                HOperatorSet.OpenFramegrabber("DirectShow", 1, 1, 0, 0, 0, 0, "default", 8, "rgb",
                    -1, "false", "default", "[0] USB2.0 HD UVC WebCam", 0, -1, out hv_AcqHandle);

                //启动抓图
                HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        /// <summary>
        /// 关闭相机
        /// </summary>
        public async Task closeCamera()
        {
            try
            {
                await SingleAcquire();
                //关闭采集卡
                HOperatorSet.CloseFramegrabber(hv_AcqHandle);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="exposureTime"></param>
        public void SetExposureTiem(double exposureTime)
        {
            HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "ExposureTime", exposureTime);
        }

        /// <summary>
        /// 设置增益
        /// </summary>
        /// <param name="gain"></param>
        public  void SetGain(double gain = 0.0)
        {
            //HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "Gain", gain);
            HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "brightness", (int)gain);
        }


        /// <summary>
        /// 单次采集
        /// </summary>
        public async Task SingleAcquire()
        {
            await StopRealTimeAcquire();

            //从采集卡同步获取图像
            ho_Image.Dispose();
            HOperatorSet.GrabImage(out ho_Image, hv_AcqHandle);
            HOperatorSet.GetImageSize(ho_Image, out  hv_width, out  hv_height);
            hWindowControl.ImagePart = new System.Drawing.Rectangle(0, 0, (int)hv_width, (int)hv_height);
            HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);

        }


        /// <summary>
        /// 实时采集
        /// </summary>
        public async void RealTimeAcquire()
        {   
            await SingleAcquire();
            cts = new CancellationTokenSource();
            realTimeTask = Task.Run(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    ho_Image.Dispose();
                    HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);
                    HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
                    System.Threading.Thread.Sleep(10);
                }
            }, cts.Token);
            
        }

        /// <summary>
        /// 停止实时采集
        /// </summary>
        public async Task StopRealTimeAcquire()
        {
            cts?.Cancel();
            await(realTimeTask != null ? realTimeTask : Task.Delay(0));
        }


        /// <summary>
        /// 读取图片
        /// </summary>
        /// <param name="path">路径</param>
        public async void ReadImageFile(string path)
        {
            await StopRealTimeAcquire();
            ho_Image.Dispose();
            HOperatorSet.ReadImage(out ho_Image, path);
            HOperatorSet.GetImageSize(ho_Image, out hv_width, out hv_height);
            hWindowControl.ImagePart = new System.Drawing.Rectangle(0, 0, (int)hv_width, (int)hv_height);
            HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);


        }


        /// <summary>
        /// 读取图像文件夹
        /// </summary>
        /// <param name="path">路径</param>
        public async Task ReadImageFolder(string path)
        {
            try
            {
                await StopRealTimeAcquire();

                HOperatorSet.ListFiles(path, (new HTuple("files")).TupleConcat("follow_links"),
                out HTuple hv_ImageFiles);

                HOperatorSet.TupleRegexpSelect(hv_ImageFiles, (new HTuple("\\.(tif|tiff|gif|bmp|jpg|jpeg|jp2|png|pcx|pgm|ppm|pbm|xwd|ima|hobj)$")).TupleConcat(
                    "ignore_case"), out HTuple ExpTmpOutVar_0);
                hv_ImageFiles.Dispose();
                hv_ImageFiles = ExpTmpOutVar_0;

                await Task.Run(() =>
                {
                    for (HTuple hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_ImageFiles.TupleLength()
                        )) -1); hv_Index = (int)hv_Index + 1)
                    {
                        ho_Image.Dispose();
                        HOperatorSet.ReadImage(out ho_Image, hv_ImageFiles.TupleSelect(hv_Index));
                        HOperatorSet.GetImageSize(ho_Image, out hv_width, out hv_height);
                        hWindowControl.ImagePart = new System.Drawing.Rectangle(0, 0, (int)hv_width, (int)hv_height);
                        HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
                        //Image Acquisition 01: Do something
                        HOperatorSet.WaitSeconds(1);
                    }
                });
            }
            catch (Exception)
            {

                
            }

        }


        public async void MakeRoi(RoiSelect roiSelect,
                            string setColor, 
                            string mode, 
                            int lineWidth = 2)
        {

            await StopRealTimeAcquire();

            HOperatorSet.SetColor(hv_ExpDefaultWinHandle, setColor);
            HOperatorSet.SetDraw(hv_ExpDefaultWinHandle, mode);
            HOperatorSet.SetLineWidth(hv_ExpDefaultWinHandle, lineWidth);

            HTuple hv_Row, hv_Column, hv_Radius, phi;
            HTuple hv_Row2, hv_Column2;
            HTuple hv_Length1, hv_Length2;
            HObject ho_Circle, ho_Rectangle, ho_Region;

            HOperatorSet.GenEmptyObj(out ho_Circle);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_Region);

            modelImage.Dispose();


            try
            {
                
                if (roiSelect == RoiSelect.Circle)
                {
                    ho_Circle.Dispose();
                    HOperatorSet.DrawCircle(hv_ExpDefaultWinHandle, out hv_Row, out hv_Column, out hv_Radius);
                    HOperatorSet.GenCircle(out ho_Circle, hv_Row, hv_Column, hv_Radius);
                    // 清窗 → 显示原图 → 叠加新 ROI
                    HOperatorSet.ClearWindow(hv_ExpDefaultWinHandle);
                    HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
                    HOperatorSet.DispObj(ho_Circle, hv_ExpDefaultWinHandle);
                    HOperatorSet.ReduceDomain(ho_Image, ho_Circle, out modelImage);
                }
                else if (roiSelect == RoiSelect.Rectangle)
                {
                    ho_Rectangle.Dispose();
                    HOperatorSet.DrawRectangle1(hv_ExpDefaultWinHandle, out hv_Row, out hv_Column, out hv_Row2, out hv_Column2);
                    HOperatorSet.GenRectangle1(out ho_Rectangle, hv_Row, hv_Column, hv_Row2, hv_Column2);
                    // 清窗 → 显示原图 → 叠加新 ROI
                    HOperatorSet.ClearWindow(hv_ExpDefaultWinHandle);
                    HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
                    HOperatorSet.DispObj(ho_Rectangle, hv_ExpDefaultWinHandle);
                    HOperatorSet.ReduceDomain(ho_Image, ho_Rectangle, out modelImage);
                }
                else if (roiSelect == RoiSelect.Rectangle2)
                {
                    ho_Rectangle.Dispose();
                    HOperatorSet.DrawRectangle2(hv_ExpDefaultWinHandle, out hv_Row, out hv_Column, out phi, out hv_Length1, out hv_Length2);
                    HOperatorSet.GenRectangle2(out ho_Rectangle, hv_Row, hv_Column, phi, hv_Length1, hv_Length2);
                    // 清窗 → 显示原图 → 叠加新 ROI
                    HOperatorSet.ClearWindow(hv_ExpDefaultWinHandle);
                    HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
                    HOperatorSet.DispObj(ho_Rectangle, hv_ExpDefaultWinHandle);
                    HOperatorSet.ReduceDomain(ho_Image, ho_Rectangle, out modelImage);
                }
                else
                {
                    ho_Region.Dispose();
                    HOperatorSet.DrawRegion(out ho_Region, hv_ExpDefaultWinHandle);
                    // 清窗 → 显示原图 → 叠加新 ROI
                    HOperatorSet.ClearWindow(hv_ExpDefaultWinHandle);
                    HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
                    HOperatorSet.DispObj(ho_Region, hv_ExpDefaultWinHandle);
                    HOperatorSet.ReduceDomain(ho_Image, ho_Region, out modelImage);
                }


                HOperatorSet.CropDomain(modelImage, out HObject ImagePart);
                HOperatorSet.WriteImage(ImagePart, "bmp", 255, "region.bmp");
                ImagePart.Dispose();
            }
            catch (Exception)
            {
                ho_Circle.Dispose();
                ho_Rectangle.Dispose();
                ho_Region.Dispose();

            }

        }


        // 2. 加上这个事件处理函数
        private void HWindowControl1_SizeChanged(object sender, EventArgs e)
        {
            if (ho_Image == null || !ho_Image.IsInitialized()) return;
            HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
        }

    }

    
}
