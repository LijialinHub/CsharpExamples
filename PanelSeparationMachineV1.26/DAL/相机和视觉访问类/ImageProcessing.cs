using Entity;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 图像处理类
    /// </summary>
    public class ImageProcessing
    {
        /// <summary>
        /// 图像
        /// </summary>
        public HObject ho_Image;

        /// <summary>
        /// 图像的宽(像素)
        /// </summary>
        public HTuple hv_Width;

        /// <summary>
        /// 图像的高(像素)
        /// </summary>
        public HTuple hv_Height;

        /// <summary>
        /// Halcon窗体控件
        /// </summary>
        public HWindowControl hWindowControl;

        /// <summary>
        ///  Halcon图像显示窗口的句柄
        /// </summary>
        public HTuple hv_ExpDefaultWinHandle;

        /// <summary>
        /// 取消线程信号
        /// </summary>
        private CancellationTokenSource cts;

        /// <summary>
        /// 实时采集任务
        /// </summary>
        private Task realTimeAcq;

        /// <summary>
        /// 模版图像（用于创建模版）
        /// </summary>
        private HObject modelImage;

        public ImageProcessing(HWindowControl hW)
        {
            hWindowControl = hW;
            hv_ExpDefaultWinHandle = hWindowControl.HalconWindow;

            HOperatorSet.GenEmptyObj(out ho_Image);//相当于new
        }

        /* 注意事项
       1、对于HObject类型的数据（图像,区域，轮廓），在使用前一定要执行
          GenEmptyObj方法去创建实体，不能使用普通的new创建

       2、HTuple类型的数据（整数、浮点、字符串、数组....），不需要创建实体，
          可以直接使用，不会报错
       */


        /// <summary>
        /// 重新显示图片
        /// </summary>
        public void DisplayImageAgain()
        {
            try
            {
                //获取图像的宽高
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);

                hWindowControl.ImagePart = new Rectangle(0, 0, hv_Width.I, hv_Height.I);
                //显示图像
                HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// 打开单张图片
        /// </summary>
        /// <param name="path">路径</param>
        public void ReadSingleImage(string path)
        {

            HOperatorSet.ReadImage(out ho_Image, path);

            //获取图像大小
            HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);

            //调整 Halcon图像显示窗口的显示像素
            hWindowControl.ImagePart = new Rectangle(0, 0, hv_Width.I, hv_Height.I);

            //显示图像到这个窗口
            HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
        }

        /// <summary>
        /// 读取图片文件夹
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="delaytime">延时切换 单位：ms</param>
        public async void ReadImageFloder(string path, int delaytime = 500)
        {

            HTuple hv_ImageFiles;
            HTuple hv_Index;

            //将文件夹中文件的路径 输出到变量ImageFiles
            HOperatorSet.ListFiles(path,
                (new HTuple("files")).TupleConcat("follow_links"), out hv_ImageFiles);
            //筛选出图片格式 输出给变量ImageFiles
            HOperatorSet.TupleRegexpSelect(hv_ImageFiles, (new HTuple("\\.(tif|tiff|gif|bmp|jpg|jpeg|jp2|png|pcx|pgm|ppm|pbm|xwd|ima|hobj)$")).TupleConcat(
                "ignore_case"), out hv_ImageFiles);

            await Task.Run(() =>
            {
                //|ImageFiles|：ImageFiles集合的元素个数
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_ImageFiles.TupleLength()
                    )) - 1); hv_Index = (int)hv_Index + 1)
                {
                    ho_Image.Dispose();
                    HOperatorSet.ReadImage(out ho_Image, hv_ImageFiles.TupleSelect(hv_Index));

                    //获取图像大小
                    HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);

                    //调整 Halcon图像显示窗口的显示像素
                    hWindowControl.ImagePart = new Rectangle(0, 0, hv_Width.I, hv_Height.I);

                    //显示图像到这个窗口
                    HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);

                    Thread.Sleep(delaytime);
                }
            });
        }


        public void set_display_font(HTuple hv_WindowHandle, HTuple hv_Size, HTuple hv_Font,
    HTuple hv_Bold, HTuple hv_Slant)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_OS = null, hv_BufferWindowHandle = new HTuple();
            HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Height = new HTuple();
            HTuple hv_Scale = new HTuple(), hv_Exception = new HTuple();
            HTuple hv_SubFamily = new HTuple(), hv_Fonts = new HTuple();
            HTuple hv_SystemFonts = new HTuple(), hv_Guess = new HTuple();
            HTuple hv_I = new HTuple(), hv_Index = new HTuple(), hv_AllowedFontSizes = new HTuple();
            HTuple hv_Distances = new HTuple(), hv_Indices = new HTuple();
            HTuple hv_FontSelRegexp = new HTuple(), hv_FontsCourier = new HTuple();
            HTuple hv_Bold_COPY_INP_TMP = hv_Bold.Clone();
            HTuple hv_Font_COPY_INP_TMP = hv_Font.Clone();
            HTuple hv_Size_COPY_INP_TMP = hv_Size.Clone();
            HTuple hv_Slant_COPY_INP_TMP = hv_Slant.Clone();

            // Initialize local and output iconic variables 
            //This procedure sets the text font of the current window with
            //the specified attributes.
            //It is assumed that following fonts are installed on the system:
            //Windows: Courier New, Arial Times New Roman
            //Mac OS X: CourierNewPS, Arial, TimesNewRomanPS
            //Linux: courier, helvetica, times
            //Because fonts are displayed smaller on Linux than on Windows,
            //a scaling factor of 1.25 is used the get comparable results.
            //For Linux, only a limited number of font sizes is supported,
            //to get comparable results, it is recommended to use one of the
            //following sizes: 9, 11, 14, 16, 20, 27
            //(which will be mapped internally on Linux systems to 11, 14, 17, 20, 25, 34)
            //
            //Input parameters:
            //WindowHandle: The graphics window for which the font will be set
            //Size: The font size. If Size=-1, the default of 16 is used.
            //Bold: If set to 'true', a bold font is used
            //Slant: If set to 'true', a slanted font is used
            //
            HOperatorSet.GetSystem("operating_system", out hv_OS);
            // dev_get_preferences(...); only in hdevelop
            // dev_set_preferences(...); only in hdevelop
            if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
            {
                hv_Size_COPY_INP_TMP = 16;
            }
            if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
            {
                //Set font on Windows systems
                try
                {
                    //Check, if font scaling is switched on
                    //open_window(...);
                    HOperatorSet.SetFont(hv_ExpDefaultWinHandle, "-Consolas-16-*-0-*-*-1-");
                    HOperatorSet.GetStringExtents(hv_ExpDefaultWinHandle, "test_string", out hv_Ascent,
                        out hv_Descent, out hv_Width, out hv_Height);
                    //Expected width is 110
                    hv_Scale = 110.0 / hv_Width;
                    hv_Size_COPY_INP_TMP = ((hv_Size_COPY_INP_TMP * hv_Scale)).TupleInt();
                    //close_window(...);
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    //throw (Exception)
                }
                if ((int)((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))).TupleOr(
                    new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("courier")))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Courier New";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Consolas";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Arial";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Times New Roman";
                }
                if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = 1;
                }
                else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = 0;
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_Slant_COPY_INP_TMP = 1;
                }
                else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Slant_COPY_INP_TMP = 0;
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                try
                {
                    HOperatorSet.SetFont(hv_ExpDefaultWinHandle, ((((((("-" + hv_Font_COPY_INP_TMP) + "-") + hv_Size_COPY_INP_TMP) + "-*-") + hv_Slant_COPY_INP_TMP) + "-*-*-") + hv_Bold_COPY_INP_TMP) + "-");
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    //throw (Exception)
                }
            }
            else if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Dar"))) != 0)
            {
                //Set font on Mac OS X systems. Since OS X does not have a strict naming
                //scheme for font attributes, we use tables to determine the correct font
                //name.
                hv_SubFamily = 0;
                if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_SubFamily = hv_SubFamily.TupleBor(1);
                }
                else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_SubFamily = hv_SubFamily.TupleBor(2);
                }
                else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
                {
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Menlo-Regular";
                    hv_Fonts[1] = "Menlo-Italic";
                    hv_Fonts[2] = "Menlo-Bold";
                    hv_Fonts[3] = "Menlo-BoldItalic";
                }
                else if ((int)((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))).TupleOr(
                    new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("courier")))) != 0)
                {
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "CourierNewPSMT";
                    hv_Fonts[1] = "CourierNewPS-ItalicMT";
                    hv_Fonts[2] = "CourierNewPS-BoldMT";
                    hv_Fonts[3] = "CourierNewPS-BoldItalicMT";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "ArialMT";
                    hv_Fonts[1] = "Arial-ItalicMT";
                    hv_Fonts[2] = "Arial-BoldMT";
                    hv_Fonts[3] = "Arial-BoldItalicMT";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "TimesNewRomanPSMT";
                    hv_Fonts[1] = "TimesNewRomanPS-ItalicMT";
                    hv_Fonts[2] = "TimesNewRomanPS-BoldMT";
                    hv_Fonts[3] = "TimesNewRomanPS-BoldItalicMT";
                }
                else
                {
                    //Attempt to figure out which of the fonts installed on the system
                    //the user could have meant.
                    HOperatorSet.QueryFont(hv_ExpDefaultWinHandle, out hv_SystemFonts);
                    hv_Fonts = new HTuple();
                    hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Guess = new HTuple();
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Regular");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "MT");
                    for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
                    {
                        HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
                        if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
                        {
                            if (hv_Fonts == null)
                                hv_Fonts = new HTuple();
                            hv_Fonts[0] = hv_Guess.TupleSelect(hv_I);
                            break;
                        }
                    }
                    //Guess name of slanted font
                    hv_Guess = new HTuple();
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Italic");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-ItalicMT");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Oblique");
                    for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
                    {
                        HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
                        if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
                        {
                            if (hv_Fonts == null)
                                hv_Fonts = new HTuple();
                            hv_Fonts[1] = hv_Guess.TupleSelect(hv_I);
                            break;
                        }
                    }
                    //Guess name of bold font
                    hv_Guess = new HTuple();
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Bold");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldMT");
                    for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
                    {
                        HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
                        if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
                        {
                            if (hv_Fonts == null)
                                hv_Fonts = new HTuple();
                            hv_Fonts[2] = hv_Guess.TupleSelect(hv_I);
                            break;
                        }
                    }
                    //Guess name of bold slanted font
                    hv_Guess = new HTuple();
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldItalic");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldItalicMT");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldOblique");
                    for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
                    {
                        HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
                        if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
                        {
                            if (hv_Fonts == null)
                                hv_Fonts = new HTuple();
                            hv_Fonts[3] = hv_Guess.TupleSelect(hv_I);
                            break;
                        }
                    }
                }
                hv_Font_COPY_INP_TMP = hv_Fonts.TupleSelect(hv_SubFamily);
                try
                {
                    HOperatorSet.SetFont(hv_ExpDefaultWinHandle, (hv_Font_COPY_INP_TMP + "-") + hv_Size_COPY_INP_TMP);
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    //throw (Exception)
                }
            }
            else
            {
                //Set font for UNIX systems
                hv_Size_COPY_INP_TMP = hv_Size_COPY_INP_TMP * 1.25;
                hv_AllowedFontSizes = new HTuple();
                hv_AllowedFontSizes[0] = 11;
                hv_AllowedFontSizes[1] = 14;
                hv_AllowedFontSizes[2] = 17;
                hv_AllowedFontSizes[3] = 20;
                hv_AllowedFontSizes[4] = 25;
                hv_AllowedFontSizes[5] = 34;
                if ((int)(new HTuple(((hv_AllowedFontSizes.TupleFind(hv_Size_COPY_INP_TMP))).TupleEqual(
                    -1))) != 0)
                {
                    hv_Distances = ((hv_AllowedFontSizes - hv_Size_COPY_INP_TMP)).TupleAbs();
                    HOperatorSet.TupleSortIndex(hv_Distances, out hv_Indices);
                    hv_Size_COPY_INP_TMP = hv_AllowedFontSizes.TupleSelect(hv_Indices.TupleSelect(
                        0));
                }
                if ((int)((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))).TupleOr(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(
                    "Courier")))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "courier";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "helvetica";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "times";
                }
                if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = "bold";
                }
                else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = "medium";
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("times"))) != 0)
                    {
                        hv_Slant_COPY_INP_TMP = "i";
                    }
                    else
                    {
                        hv_Slant_COPY_INP_TMP = "o";
                    }
                }
                else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Slant_COPY_INP_TMP = "r";
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                try
                {
                    HOperatorSet.SetFont(hv_ExpDefaultWinHandle, ((((((("-adobe-" + hv_Font_COPY_INP_TMP) + "-") + hv_Bold_COPY_INP_TMP) + "-") + hv_Slant_COPY_INP_TMP) + "-normal-*-") + hv_Size_COPY_INP_TMP) + "-*-*-*-*-*-*-*");
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    if ((int)((new HTuple(((hv_OS.TupleSubstr(0, 4))).TupleEqual("Linux"))).TupleAnd(
                        new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("courier")))) != 0)
                    {
                        HOperatorSet.QueryFont(hv_ExpDefaultWinHandle, out hv_Fonts);
                        hv_FontSelRegexp = (("^-[^-]*-[^-]*[Cc]ourier[^-]*-" + hv_Bold_COPY_INP_TMP) + "-") + hv_Slant_COPY_INP_TMP;
                        hv_FontsCourier = ((hv_Fonts.TupleRegexpSelect(hv_FontSelRegexp))).TupleRegexpMatch(
                            hv_FontSelRegexp);
                        if ((int)(new HTuple((new HTuple(hv_FontsCourier.TupleLength())).TupleEqual(
                            0))) != 0)
                        {
                            hv_Exception = "Wrong font name";
                            //throw (Exception)
                        }
                        else
                        {
                            try
                            {
                                HOperatorSet.SetFont(hv_ExpDefaultWinHandle, (((hv_FontsCourier.TupleSelect(
                                    0)) + "-normal-*-") + hv_Size_COPY_INP_TMP) + "-*-*-*-*-*-*-*");
                            }
                            // catch (Exception) 
                            catch (HalconException HDevExpDefaultException2)
                            {
                                HDevExpDefaultException2.ToHTuple(out hv_Exception);
                                //throw (Exception)
                            }
                        }
                    }
                    //throw (Exception)
                }
            }
            // dev_set_preferences(...); only in hdevelop

            return;
        }

        public void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
      HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_Red = null, hv_Green = null, hv_Blue = null;
            HTuple hv_Row1Part = null, hv_Column1Part = null, hv_Row2Part = null;
            HTuple hv_Column2Part = null, hv_RowWin = null, hv_ColumnWin = null;
            HTuple hv_WidthWin = new HTuple(), hv_HeightWin = null;
            HTuple hv_MaxAscent = null, hv_MaxDescent = null, hv_MaxWidth = null;
            HTuple hv_MaxHeight = null, hv_R1 = new HTuple(), hv_C1 = new HTuple();
            HTuple hv_FactorRow = new HTuple(), hv_FactorColumn = new HTuple();
            HTuple hv_UseShadow = null, hv_ShadowColor = null, hv_Exception = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Index = new HTuple();
            HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
            HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_FrameHeight = new HTuple();
            HTuple hv_FrameWidth = new HTuple(), hv_R2 = new HTuple();
            HTuple hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
            HTuple hv_CurrentColor = new HTuple();
            HTuple hv_Box_COPY_INP_TMP = hv_Box.Clone();
            HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
            HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
            HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
            HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

            // Initialize local and output iconic variables 
            //This procedure displays text in a graphics window.
            //
            //Input parameters:
            //WindowHandle: The WindowHandle of the graphics window, where
            //   the message should be displayed
            //String: A tuple of strings containing the text message to be displayed
            //CoordSystem: If set to 'window', the text position is given
            //   with respect to the window coordinate system.
            //   If set to 'image', image coordinates are used.
            //   (This may be useful in zoomed images.)
            //Row: The row coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Column: The column coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Color: defines the color of the text as string.
            //   If set to [], '' or 'auto' the currently set color is used.
            //   If a tuple of strings is passed, the colors are used cyclically
            //   for each new textline.
            //Box: If Box[0] is set to 'true', the text is written within an orange box.
            //     If set to' false', no box is displayed.
            //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
            //       the text is written in a box of that color.
            //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
            //       'true' -> display a shadow in a default color
            //       'false' -> display no shadow (same as if no second value is given)
            //       otherwise -> use given string as color string for the shadow color
            //
            //Prepare window
            HOperatorSet.GetRgb(hv_ExpDefaultWinHandle, out hv_Red, out hv_Green, out hv_Blue);
            HOperatorSet.GetPart(hv_ExpDefaultWinHandle, out hv_Row1Part, out hv_Column1Part,
                out hv_Row2Part, out hv_Column2Part);
            HOperatorSet.GetWindowExtents(hv_ExpDefaultWinHandle, out hv_RowWin, out hv_ColumnWin,
                out hv_WidthWin, out hv_HeightWin);
            HOperatorSet.SetPart(hv_ExpDefaultWinHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
            //
            //default settings
            if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Row_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Column_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
            {
                hv_Color_COPY_INP_TMP = "";
            }
            //
            hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
            //
            //Estimate extentions of text depending on font size.
            HOperatorSet.GetFontExtents(hv_ExpDefaultWinHandle, out hv_MaxAscent, out hv_MaxDescent,
                out hv_MaxWidth, out hv_MaxHeight);
            if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
            {
                hv_R1 = hv_Row_COPY_INP_TMP.Clone();
                hv_C1 = hv_Column_COPY_INP_TMP.Clone();
            }
            else
            {
                //Transform image to window coordinates
                hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
                hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
                hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
                hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
            }
            //
            //Display text box depending on text size
            hv_UseShadow = 1;
            hv_ShadowColor = "gray";
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleEqual("true"))) != 0)
            {
                if (hv_Box_COPY_INP_TMP == null)
                    hv_Box_COPY_INP_TMP = new HTuple();
                hv_Box_COPY_INP_TMP[0] = "#fce9d4";
                hv_ShadowColor = "#f28d26";
            }
            if ((int)(new HTuple((new HTuple(hv_Box_COPY_INP_TMP.TupleLength())).TupleGreater(
                1))) != 0)
            {
                if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual("true"))) != 0)
                {
                    //Use default ShadowColor set above
                }
                else if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual(
                    "false"))) != 0)
                {
                    hv_UseShadow = 0;
                }
                else
                {
                    hv_ShadowColor = hv_Box_COPY_INP_TMP[1];
                    //Valid color?
                    try
                    {
                        HOperatorSet.SetColor(hv_ExpDefaultWinHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                            1));
                    }
                    // catch (Exception) 
                    catch (HalconException HDevExpDefaultException1)
                    {
                        HDevExpDefaultException1.ToHTuple(out hv_Exception);
                        hv_Exception = "Wrong value of control parameter Box[1] (must be a 'true', 'false', or a valid color string)";
                        throw new HalconException(hv_Exception);
                    }
                }
            }
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleNotEqual("false"))) != 0)
            {
                //Valid color?
                try
                {
                    HOperatorSet.SetColor(hv_ExpDefaultWinHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                        0));
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    hv_Exception = "Wrong value of control parameter Box[0] (must be a 'true', 'false', or a valid color string)";
                    throw new HalconException(hv_Exception);
                }
                //Calculate box extents
                hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
                hv_Width = new HTuple();
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    )) - 1); hv_Index = (int)hv_Index + 1)
                {
                    HOperatorSet.GetStringExtents(hv_ExpDefaultWinHandle, hv_String_COPY_INP_TMP.TupleSelect(
                        hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
                    hv_Width = hv_Width.TupleConcat(hv_W);
                }
                hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    ));
                hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
                hv_R2 = hv_R1 + hv_FrameHeight;
                hv_C2 = hv_C1 + hv_FrameWidth;
                //Display rectangles
                HOperatorSet.GetDraw(hv_ExpDefaultWinHandle, out hv_DrawMode);
                HOperatorSet.SetDraw(hv_ExpDefaultWinHandle, "fill");
                //Set shadow color
                HOperatorSet.SetColor(hv_ExpDefaultWinHandle, hv_ShadowColor);
                if ((int)(hv_UseShadow) != 0)
                {
                    HOperatorSet.DispRectangle1(hv_ExpDefaultWinHandle, hv_R1 + 1, hv_C1 + 1, hv_R2 + 1,
                        hv_C2 + 1);
                }
                //Set box color
                HOperatorSet.SetColor(hv_ExpDefaultWinHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                    0));
                HOperatorSet.DispRectangle1(hv_ExpDefaultWinHandle, hv_R1, hv_C1, hv_R2, hv_C2);
                HOperatorSet.SetDraw(hv_ExpDefaultWinHandle, hv_DrawMode);
            }
            //Write text.
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                )) - 1); hv_Index = (int)hv_Index + 1)
            {
                hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                    )));
                if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
                    "auto")))) != 0)
                {
                    HOperatorSet.SetColor(hv_ExpDefaultWinHandle, hv_CurrentColor);
                }
                else
                {
                    HOperatorSet.SetRgb(hv_ExpDefaultWinHandle, hv_Red, hv_Green, hv_Blue);
                }
                hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
                HOperatorSet.SetTposition(hv_ExpDefaultWinHandle, hv_Row_COPY_INP_TMP, hv_C1);
                HOperatorSet.WriteString(hv_ExpDefaultWinHandle, hv_String_COPY_INP_TMP.TupleSelect(
                    hv_Index));
            }
            //Reset changed window settings
            HOperatorSet.SetRgb(hv_ExpDefaultWinHandle, hv_Red, hv_Green, hv_Blue);
            HOperatorSet.SetPart(hv_ExpDefaultWinHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
                hv_Column2Part);

            return;
        }

        /// <summary>
        /// 制作ROI
        /// </summary>
        /// <param name="roiSelect">ROI选择</param>
        /// <param name="roiName">ROI名字</param>
        /// <param name="setColor">设置颜色</param>
        /// <param name="mode">模式：fill  margin</param>
        /// <param name="lineWidth">线宽</param>
        public void MakeROI(RoiSelect roiSelect, string roiName,
                             string setColor = "red", string mode = "margin", int lineWidth = 2)
        {

            HObject ho_Circle;
            HObject ho_Rectangle, ho_Rectangle1, ho_Region, ho_ImagePart;

            HTuple hv_Row = null, hv_Column = null, hv_Radius = null;
            HTuple hv_Row1 = null, hv_Column1 = null, hv_Row2 = null;
            HTuple hv_Column2 = null, hv_Row3 = null, hv_Column3 = null;
            HTuple hv_Phi = null, hv_Length1 = null, hv_Length2 = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Circle);
            HOperatorSet.GenEmptyObj(out modelImage);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_Rectangle1);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_ImagePart);

            try
            {


                //设置颜色
                HOperatorSet.SetColor(hv_ExpDefaultWinHandle, setColor);
                //设置填充模式
                HOperatorSet.SetDraw(hv_ExpDefaultWinHandle, mode);
                //设置线宽
                HOperatorSet.SetLineWidth(hv_ExpDefaultWinHandle, lineWidth);

                if (roiSelect == RoiSelect.Circle) //绘制圆形ROI 
                {
                    HOperatorSet.DrawCircle(hv_ExpDefaultWinHandle, out hv_Row, out hv_Column,
                                            out hv_Radius);
                    //生成ROI区域
                    ho_Circle.Dispose();
                    HOperatorSet.GenCircle(out ho_Circle, hv_Row, hv_Column, hv_Radius);
                    HOperatorSet.DispObj(ho_Circle, hv_ExpDefaultWinHandle);

                    //从原图中，将选中区域裁剪出来
                    //ImageReduced就是用来创建模版的图像
                    modelImage.Dispose();
                    HOperatorSet.ReduceDomain(ho_Image, ho_Circle, out modelImage);
                }
                else if (roiSelect == RoiSelect.Rectangle1) //绘制矩形ROI
                {
                    //矩形的左上角坐标：Row1, Column1   右下角坐标：Row2, Column2
                    HOperatorSet.DrawRectangle1(hv_ExpDefaultWinHandle, out hv_Row1, out hv_Column1,
                        out hv_Row2, out hv_Column2);
                    //生成矩形区域
                    ho_Rectangle.Dispose();
                    HOperatorSet.GenRectangle1(out ho_Rectangle, hv_Row1, hv_Column1, hv_Row2, hv_Column2);

                    HOperatorSet.DispObj(ho_Rectangle, hv_ExpDefaultWinHandle);
                    //截图
                    modelImage.Dispose();
                    HOperatorSet.ReduceDomain(ho_Image, ho_Rectangle, out modelImage);
                }
                else if (roiSelect == RoiSelect.Rectangle2) //绘制旋转矩形ROI
                {
                    //中心点坐标：Row3, Column3  旋转弧度：Phi
                    //长轴的一半：Length1    短轴的一半：Length2
                    HOperatorSet.DrawRectangle2(hv_ExpDefaultWinHandle, out hv_Row3, out hv_Column3,
                    out hv_Phi, out hv_Length1, out hv_Length2);
                    //生成旋转矩形区域
                    ho_Rectangle1.Dispose();
                    HOperatorSet.GenRectangle2(out ho_Rectangle1, hv_Row3, hv_Column3, hv_Phi, hv_Length1,
                        hv_Length2);


                    HOperatorSet.DispObj(ho_Rectangle1, hv_ExpDefaultWinHandle);
                    //截图
                    modelImage.Dispose();
                    HOperatorSet.ReduceDomain(ho_Image, ho_Rectangle1, out modelImage);
                }
                else  //绘制任意区域,绘制时直接生成区域Region
                {
                    ho_Region.Dispose();
                    HOperatorSet.DrawRegion(out ho_Region, hv_ExpDefaultWinHandle);

                    HOperatorSet.DispObj(ho_Region, hv_ExpDefaultWinHandle);
                    modelImage.Dispose();
                    HOperatorSet.ReduceDomain(ho_Image, ho_Region, out modelImage);
                }

                //提取图像，生成新的图像尺寸
                ho_ImagePart.Dispose();
                HOperatorSet.CropDomain(modelImage, out ho_ImagePart);
                //将图像ImagePart储存起来,到时给C#的PictureBox控件使用
                //0~~~255:背景的灰度值   0：黑色背景    255：白色背景
                //ROI.bmp：路径（相对(和当前文件在同一个文件夹) 或者 绝对）
                HOperatorSet.WriteImage(ho_ImagePart, "bmp", 0, Environment.CurrentDirectory + $@"\{roiName}ROI.bmp");
            }
            catch (Exception ex)
            {
                ho_Circle.Dispose();
                ho_Rectangle.Dispose();
                ho_Rectangle1.Dispose();
                ho_Region.Dispose();
                ho_ImagePart.Dispose();
                throw ex;
            }
            ho_Circle.Dispose();
            ho_Rectangle.Dispose();
            ho_Rectangle1.Dispose();
            ho_Region.Dispose();
            ho_ImagePart.Dispose();
        }


        /// <summary>
        /// 创建模版
        /// </summary>
        /// <param name="shapeModeName">模版名称</param>
        /// <param name="metric">极性选择：'ignore_color_polarity', 'ignore_global_polarity', 'ignore_local_polarity', 'use_polarity'</param>
        public void CreateShapeModel(string shapeModeName, string metric = "use_polarity")
        {
            try
            {
                HTuple hv_ModelID;

                HOperatorSet.CreateShapeModel(modelImage, "auto", (new HTuple(0)).TupleRad()
          , (new HTuple(360)).TupleRad(), "auto", "auto", metric, "auto",
          "auto", out hv_ModelID);

                //保存ModelID指向的模版数据，文件的后缀名可以随便写
                HOperatorSet.WriteShapeModel(hv_ModelID, Environment.CurrentDirectory + $@"\{shapeModeName}ShapeModel.shm");
                //释放模版资源
                HOperatorSet.ClearShapeModel(hv_ModelID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查找模版
        /// </summary>
        /// <param name="shapeModeName">模版名称</param>
        /// <param name="minScore">最小分数</param>
        /// <param name="numMatches">匹配个数</param>
        /// <param name="maxOverlap">重叠度</param>
        /// <param name="greediness">贪婪度</param>
        /// <param name="markColor">标记颜色</param>
        /// <param name="lineWidth">线宽</param>
        /// <param name="contourXldColor">轮廓颜色</param>
        /// <param name="fontColor">字体颜色</param>
        /// <param name="fontSize">字体大小</param>
        /// <returns>匹配到的对象</returns>
        public List<PixelPos> FindShapeModel(string shapeModeName, double minScore, int numMatches,
                                   double maxOverlap, double greediness,
                                   string markColor, int lineWidth,
                                   string contourXldColor, string fontColor, int fontSize)
        {
            HTuple hv_ModelID;
            HTuple hv_Row1, hv_Column1, hv_Angle, hv_Score;
            HTuple hv_Num, hv_Index;
            HTuple hv_HomMat2DIdentity, hv_HomMat2DTranslate, hv_HomMat2DResult;

            HObject ho_ModelContours, ho_Cross, ho_ContoursAffinTrans;
            HOperatorSet.GenEmptyObj(out ho_ModelContours);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_ContoursAffinTrans);

            List<PixelPos> pixelPosList = new List<PixelPos>();
            try
            {
                //显示要查找的图片
                HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);

                //读取要查找的模版数据
                HOperatorSet.ReadShapeModel(Environment.CurrentDirectory + $@"\{shapeModeName}ShapeModel.shm", out hv_ModelID);
                //获取形状模版图像的轮廓，1表示1级金字塔，这轮廓所在的ROI的中心点位于0,0
                ho_ModelContours.Dispose();
                HOperatorSet.GetShapeModelContours(out ho_ModelContours, hv_ModelID, 1);

                HOperatorSet.FindShapeModel(ho_Image, hv_ModelID, (new HTuple(0)).TupleRad()
                  , (new HTuple(360)).TupleRad(), minScore, numMatches, maxOverlap, "least_squares", 0, greediness,
                   out hv_Row1, out hv_Column1, out hv_Angle, out hv_Score);

                //找到的个数
                hv_Num = new HTuple(hv_Row1.TupleLength());


                HOperatorSet.SetColor(hv_ExpDefaultWinHandle, markColor);//标记颜色
                HOperatorSet.SetLineWidth(hv_ExpDefaultWinHandle, lineWidth);//线宽
                //生成十字架,可以处理集合
                ho_Cross.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Row1, hv_Column1, 6, hv_Angle);
                HOperatorSet.DispObj(ho_Cross, hv_ExpDefaultWinHandle);


                HTuple end_val82 = hv_Num - 1;
                HTuple step_val82 = 1;
                for (hv_Index = 0; hv_Index.Continue(end_val82, step_val82); hv_Index = hv_Index.TupleAdd(step_val82))
                {
                    //生成一个原始矩阵（没有任何变换的）
                    HOperatorSet.HomMat2dIdentity(out hv_HomMat2DIdentity);

                    //方法一
                    //平移变换
                    HOperatorSet.HomMat2dTranslate(hv_HomMat2DIdentity, hv_Row1.TupleSelect(hv_Index),
                        hv_Column1.TupleSelect(hv_Index), out hv_HomMat2DTranslate);
                    //旋转变换
                    HOperatorSet.HomMat2dRotate(hv_HomMat2DTranslate, hv_Angle.TupleSelect(hv_Index),
                        hv_Row1.TupleSelect(hv_Index), hv_Column1.TupleSelect(hv_Index), out hv_HomMat2DResult);

                    //设为绿色
                    HOperatorSet.SetColor(hv_ExpDefaultWinHandle, contourXldColor);
                    //HomMat2DRotate：这个矩阵就有平移和旋转信息
                    //仿射变换
                    ho_ContoursAffinTrans.Dispose();
                    HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_ContoursAffinTrans,
                        hv_HomMat2DResult);
                    //显示仿射变换后的轮廓
                    HOperatorSet.DispObj(ho_ContoursAffinTrans, hv_ExpDefaultWinHandle);
              
                    PixelPos pixelPos = new PixelPos();
                    pixelPos.Num = hv_Index.I + 1;
                    pixelPos.Row = double.Parse(hv_Row1.TupleSelect(hv_Index).TupleString(".2f"));
                    pixelPos.Column = double.Parse(hv_Column1.TupleSelect(hv_Index).TupleString(".2f"));
                    pixelPos.Angle = Math.Round(hv_Angle.TupleSelect(hv_Index).D * 180.0 / Math.PI, 2);

                    pixelPosList.Add(pixelPos);
                }

                //释放模版资源
                HOperatorSet.ClearShapeModel(hv_ModelID);
                return pixelPosList;
            }
            catch (Exception ex)
            {
                return pixelPosList;
            }

            finally
            {
                ho_ModelContours.Dispose();
                ho_Cross.Dispose();
                ho_ContoursAffinTrans.Dispose();
            }

            
        }


        /// <summary>
        /// 显示NG或者OK
        /// </summary>
        /// <param name="matches">匹配结果</param>
        public void DisplayNGOrOK(List<PixelPos> matches)
        {
            set_display_font(hv_ExpDefaultWinHandle, 30, "宋体", "true", "false");
            if (matches.Count > 0)
            {
                //显示在右上角
                disp_message(hv_ExpDefaultWinHandle, "匹配OK",
                   "image", 50, hv_Width - 800, "green", "false");
            }
            else 
            {
                disp_message(hv_ExpDefaultWinHandle, "匹配NG",
                   "image", 50, hv_Width - 800, "red", "false");
            }
        }


        ///// <summary>
        ///// 获取相机修正矩阵(平移和旋转)
        ///// </summary>
        ///// <param name="oldPos">示教板的机械坐标</param>
        ///// <param name="newPos">加工板机械坐标</param>
        ///// <param name="hv_HomMat2D">关系矩阵</param>
        //public void GetCorrectMatrix(MachineCoordinatesEntity[] oldPos,
        //                             MachineCoordinatesEntity[] newPos,
        //                             out HTuple hv_HomMat2D)
        //{
        //    HTuple hv_oldX, hv_oldY, hv_newX, hv_newY;

        //    hv_oldX = new HTuple();
        //    hv_oldX[0] = oldPos[0].X; hv_oldX[1] = oldPos[1].X;

        //    hv_oldY = new HTuple();
        //    hv_oldY[0] = oldPos[0].Y; hv_oldY[1] = oldPos[1].Y;

        //    hv_newX = new HTuple();
        //    hv_newX[0] = newPos[0].X; hv_newX[1] = newPos[1].X;

        //    hv_newY = new HTuple();
        //    hv_newY[0] = newPos[0].Y; hv_newY[1] = newPos[1].Y;

        //    HOperatorSet.VectorToRigid(hv_oldX, hv_oldY, hv_newX, hv_newY, out hv_HomMat2D);
        //}

        ///// <summary>
        ///// 获取仿射变换后的点
        ///// </summary>
        ///// <param name="hv_HomMat2D">矩阵</param>
        ///// <param name="oldMPoint">之前的点坐标</param>
        ///// <param name="newMPoint">仿射后的点坐标</param> 
        //public void GetAffineTransPoint(HTuple hv_HomMat2D,
        //                                MachineCoordinatesEntity oldMPoint,
        //                                MachineCoordinatesEntity newMPoint)
        //{
        //    HTuple oldPointX, oldPointY, newPointX, newPointY;
        //    oldPointX = oldMPoint.X; oldPointY = oldMPoint.Y;

        //    HOperatorSet.AffineTransPoint2d(hv_HomMat2D, oldPointX, oldPointY,
        //                                    out newPointX, out newPointY);

        //    newMPoint.X = newPointX; newMPoint.Y = newPointY;

        //    HTuple hv_Sx, hv_Sy, hv_Phi, hv_Theta, hv_Tx, hv_Ty, hv_Deg1;

        //    HOperatorSet.HomMat2dToAffinePar(hv_HomMat2D, out hv_Sx, out hv_Sy, out hv_Phi,
        //    out hv_Theta, out hv_Tx, out hv_Ty);

        //    HOperatorSet.TupleDeg(hv_Phi, out hv_Deg1);

        //    newMPoint.Angle = hv_Deg1; newMPoint.Tx = hv_Tx; newMPoint.Ty = hv_Ty;
        //}

    }

}
