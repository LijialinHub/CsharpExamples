using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 形状匹配;

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

        /// <summary>
        /// 绘制区域
        /// </summary>
        /// <param name="roiSelect"></param>
        /// <param name="setColor"></param>
        /// <param name="mode"></param>
        /// <param name="lineWidth"></param>
        public async void MakeRoi(RoiSelect roiSelect,
                            string setColor = "red", 
                            string mode = "margin", 
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

        /// <summary>
        /// 创建模型
        /// </summary>
        /// <param name="angleStart">开始角度</param>
        /// <param name="angleEnd">角度范围</param>
        /// <param name="metric">极性</param>
        public void CreateShapeModel(double angleStart = 0, 
                                        double angleEnd = 360, 
                                        string metric = "use_polarity")
        {
            try
            {
                HTuple hv_ModelID1;
                HOperatorSet.CreateShapeModel(modelImage, "auto", (new HTuple(angleStart)).TupleRad()
                , (new HTuple(angleEnd)).TupleRad(), "auto", "auto", metric, "auto", "auto",
                out hv_ModelID1);

                // 保存模型
                HOperatorSet.WriteShapeModel(hv_ModelID1, "shape_model.shm");

                HOperatorSet.ClearShapeModel(hv_ModelID1);
                hv_ModelID1.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<PixelCoord> FindShapeModel(double score = 0.9,
                                   int numMatches = 0,
                                   double maxOverlap = 0.5,
                                   double greediness = 0.5,
                                   string crossColor = "red",
                                   string contourColor = "green",
                                   string setDraw = "margin",
                                   int lineWidth = 2,
                                   string fontColor = "yellow",
                                   int fontSize = 12,
                                   double angleStart = 0,
                                   double angleEnd = 360
                                   )
        {
            try
            {
                //显示要查找的图片
                HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
                //读取模型
                HOperatorSet.ReadShapeModel("shape_model.shm", out HTuple hv_ModelID);

                //获取模板轮廓 1级图像金字塔
                HOperatorSet.GetShapeModelContours(out HObject ho_modelContours, hv_ModelID, 1);
                //寻找匹配
                HOperatorSet.FindShapeModel(ho_Image, hv_ModelID, (new HTuple(angleStart)).TupleRad()
                , (new HTuple(angleEnd)).TupleRad(), score, numMatches, maxOverlap, "least_squares", 0, greediness, out HTuple hv_Row,
                out HTuple hv_Column, out HTuple hv_Angle, out HTuple hv_Score);

                if(hv_Row.TupleLength() == 0) { return null;}

                //十字线
                HOperatorSet.SetColor(hv_ExpDefaultWinHandle, crossColor);
                HOperatorSet.SetDraw(hv_ExpDefaultWinHandle, setDraw);
                HOperatorSet.SetLineWidth(hv_ExpDefaultWinHandle, lineWidth);
                HOperatorSet.GenCrossContourXld(out HObject ho_CrossContour, hv_Row, hv_Column, 15, hv_Angle);
                HOperatorSet.DispObj(ho_CrossContour, hv_ExpDefaultWinHandle);

                List<PixelCoord> pixelCoords = new List<PixelCoord>();

                for (int i = 0; i < hv_Row.TupleLength(); i++)
                {
                    PixelCoord pixelCoord = new PixelCoord();
                    pixelCoord.Num = i+1;
                    pixelCoord.Row = Math.Round(hv_Row[i].D, 2);
                    pixelCoord.Col = Math.Round(hv_Column[i].D, 2);
                    pixelCoord.Angle = Math.Round(hv_Angle[i].D * (180.0 / Math.PI), 2);
                    pixelCoords.Add(pixelCoord);
                }

                return pixelCoords;

            }
            catch (HalconException hex)
            {

                return null;
            }

        }


        /// <summary>
        /// 实时采集
        /// </summary>
        public async void RealTimeAcquireFindShapeModel(double score = 0.9,
                                   int numMatches = 0,
                                   double maxOverlap = 0.5,
                                   double greediness = 0.5,
                                   string crossColor = "red",
                                   string contourColor = "green",
                                   string setDraw = "margin",
                                   int lineWidth = 2,
                                   string fontColor = "yellow",
                                   int fontSize = 12,
                                   double angleStart = 0,
                                   double angleEnd = 360)
        {
            await SingleAcquire();
            cts = new CancellationTokenSource();
            realTimeTask = Task.Run(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    ho_Image.Dispose();
                    HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);
                    //HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
                    FindShapeModel(score, numMatches, maxOverlap, greediness, crossColor, contourColor,
                        setDraw, lineWidth, fontColor, fontSize);
                    System.Threading.Thread.Sleep(10);
                }
            }, cts.Token);

        }



        /// <summary>
        /// 设置显示字体
        /// </summary>
        /// <param name="hv_WindowHandle">窗口句柄</param>
        /// <param name="hv_Size">字体大小</param>
        /// <param name="hv_Font">字体类型</param>
        /// <param name="hv_Bold"></param>
        /// <param name="hv_Slant"></param>
        public void set_display_font(HTuple hv_WindowHandle, HTuple hv_Size, HTuple hv_Font,
                HTuple hv_Bold, HTuple hv_Slant)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_OS = new HTuple(), hv_Fonts = new HTuple();
            HTuple hv_Style = new HTuple(), hv_Exception = new HTuple();
            HTuple hv_AvailableFonts = new HTuple(), hv_Fdx = new HTuple();
            HTuple hv_Indices = new HTuple();
            HTuple hv_Font_COPY_INP_TMP = new HTuple(hv_Font);
            HTuple hv_Size_COPY_INP_TMP = new HTuple(hv_Size);

            // Initialize local and output iconic variables 
            try
            {
                //This procedure sets the text font of the current window with
                //the specified attributes.
                //
                //Input parameters:
                //WindowHandle: The graphics window for which the font will be set
                //Size: The font size. If Size=-1, the default of 16 is used.
                //Bold: If set to 'true', a bold font is used
                //Slant: If set to 'true', a slanted font is used
                //
                hv_OS.Dispose();
                HOperatorSet.GetSystem("operating_system", out hv_OS);
                if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                    new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
                {
                    hv_Size_COPY_INP_TMP.Dispose();
                    hv_Size_COPY_INP_TMP = 16;
                }
                if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
                {
                    //Restore previous behaviour
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Size = ((1.13677 * hv_Size_COPY_INP_TMP)).TupleInt()
                                ;
                            hv_Size_COPY_INP_TMP.Dispose();
                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }
                else
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Size = hv_Size_COPY_INP_TMP.TupleInt()
                                ;
                            hv_Size_COPY_INP_TMP.Dispose();
                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Courier";
                    hv_Fonts[1] = "Courier 10 Pitch";
                    hv_Fonts[2] = "Courier New";
                    hv_Fonts[3] = "CourierNew";
                    hv_Fonts[4] = "Liberation Mono";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Consolas";
                    hv_Fonts[1] = "Menlo";
                    hv_Fonts[2] = "Courier";
                    hv_Fonts[3] = "Courier 10 Pitch";
                    hv_Fonts[4] = "FreeMono";
                    hv_Fonts[5] = "Liberation Mono";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Luxi Sans";
                    hv_Fonts[1] = "DejaVu Sans";
                    hv_Fonts[2] = "FreeSans";
                    hv_Fonts[3] = "Arial";
                    hv_Fonts[4] = "Liberation Sans";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Times New Roman";
                    hv_Fonts[1] = "Luxi Serif";
                    hv_Fonts[2] = "DejaVu Serif";
                    hv_Fonts[3] = "FreeSerif";
                    hv_Fonts[4] = "Utopia";
                    hv_Fonts[5] = "Liberation Serif";
                }
                else
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple(hv_Font_COPY_INP_TMP);
                }
                hv_Style.Dispose();
                hv_Style = "";
                if ((int)(new HTuple(hv_Bold.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Style = hv_Style + "Bold";
                            hv_Style.Dispose();
                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Bold.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception.Dispose();
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Style = hv_Style + "Italic";
                            hv_Style.Dispose();
                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Slant.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception.Dispose();
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Style.TupleEqual(""))) != 0)
                {
                    hv_Style.Dispose();
                    hv_Style = "Normal";
                }
                hv_AvailableFonts.Dispose();
                HOperatorSet.QueryFont(hv_ExpDefaultWinHandle, out hv_AvailableFonts);
                hv_Font_COPY_INP_TMP.Dispose();
                hv_Font_COPY_INP_TMP = "";
                for (hv_Fdx = 0; (int)hv_Fdx <= (int)((new HTuple(hv_Fonts.TupleLength())) - 1); hv_Fdx = (int)hv_Fdx + 1)
                {
                    hv_Indices.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_Indices = hv_AvailableFonts.TupleFind(
                            hv_Fonts.TupleSelect(hv_Fdx));
                    }
                    if ((int)(new HTuple((new HTuple(hv_Indices.TupleLength())).TupleGreater(
                        0))) != 0)
                    {
                        if ((int)(new HTuple(((hv_Indices.TupleSelect(0))).TupleGreaterEqual(0))) != 0)
                        {
                            hv_Font_COPY_INP_TMP.Dispose();
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                hv_Font_COPY_INP_TMP = hv_Fonts.TupleSelect(
                                    hv_Fdx);
                            }
                            break;
                        }
                    }
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(""))) != 0)
                {
                    throw new HalconException("Wrong value of control parameter Font");
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    {
                        HTuple
                          ExpTmpLocalVar_Font = (((hv_Font_COPY_INP_TMP + "-") + hv_Style) + "-") + hv_Size_COPY_INP_TMP;
                        hv_Font_COPY_INP_TMP.Dispose();
                        hv_Font_COPY_INP_TMP = ExpTmpLocalVar_Font;
                    }
                }
                HOperatorSet.SetFont(hv_ExpDefaultWinHandle, hv_Font_COPY_INP_TMP);

                hv_Font_COPY_INP_TMP.Dispose();
                hv_Size_COPY_INP_TMP.Dispose();
                hv_OS.Dispose();
                hv_Fonts.Dispose();
                hv_Style.Dispose();
                hv_Exception.Dispose();
                hv_AvailableFonts.Dispose();
                hv_Fdx.Dispose();
                hv_Indices.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {

                hv_Font_COPY_INP_TMP.Dispose();
                hv_Size_COPY_INP_TMP.Dispose();
                hv_OS.Dispose();
                hv_Fonts.Dispose();
                hv_Style.Dispose();
                hv_Exception.Dispose();
                hv_AvailableFonts.Dispose();
                hv_Fdx.Dispose();
                hv_Indices.Dispose();

                throw HDevExpDefaultException;
            }
        }

    }

    
}
