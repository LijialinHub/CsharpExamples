using GxIAPINET;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    /// <summary>
    /// 大恒水星系列相机
    /// </summary>
    public class MERCameraClass : CameraClass
    {
        //输出参数
        public double[] difToCenterX = new double[2];
        public double[] difToCenterY = new double[2];

        /// <summary>
        /// 采集图像
        /// </summary>
        public HObject Himg = null;

        bool m_bIsOpen = false;              //<设备打开状态
        bool m_bSingle = false;              //<设备打开状态
        bool m_bSingle2 = false;
        IGXFactory m_objIGXFactory = null;   //Factory对像

        /// <summary>
        /// 设备信息列表
        /// </summary>
        List<IGXDeviceInfo> m_listIGXDeviceInfo = new List<IGXDeviceInfo>();

        /// <summary>
        /// 相机参数状态列表
        /// </summary>
        List<DAL.CCamerInfo> m_listCCamerInfo = new List<CCamerInfo>();

        /// <summary>
        /// 初始化相机数目
        /// </summary>
        int m_nCamNum = 0;

        /// <summary>
        /// 相机的打开ID
        /// </summary>
        int m_nOperateID = -1;//操作相机编号打开相机时根据此ID来操作打开哪个相机

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="CameraId">相机ID</param>
        public MERCameraClass(int CameraId)
        {
            try
            {
                m_objIGXFactory = IGXFactory.GetInstance(); //返回IGXFactory对象实例
                m_objIGXFactory.Init(); //使用其他接口之前，必须执行初始化

                __EnumDevice();

                m_nOperateID = CameraId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("30. " + ex.Message);
            }

        }

        /// <summary>
        /// 打开并初始化相机
        /// </summary>
        /// <param name="strSN">设备用的序列号</param>
        public override void OpenCamera(string strSN)
        {
            //  strSN = ""; //打开设备用的序列号
            //*************
            try
            {
                // 判断当前连接设备个数
                if (m_listIGXDeviceInfo.Count <= 0)
                {
                    MessageBox.Show("未发现设备!");
                    return;
                }
                try
                {
                    //停止流通道、注销采集回调和关闭流
                    if (null != m_listCCamerInfo[m_nOperateID].m_objIGXStream)
                    {
                        m_listCCamerInfo[m_nOperateID].m_objIGXStream.Close();
                        m_listCCamerInfo[m_nOperateID].m_objIGXStream = null;
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show("31. " + ee.Message);
                }

                // 如果设备已经打开则关闭，保证相机在初始化出错情况下能再次打开
                if (null != m_listCCamerInfo[m_nOperateID].m_objIGXDevice)
                {
                    m_listCCamerInfo[m_nOperateID].m_objIGXDevice.Close();
                    m_listCCamerInfo[m_nOperateID].m_objIGXDevice = null;
                }

                //strSN = m_listIGXDeviceInfo[m_nOperateID].GetSN();  //获取设备序列号
                //if ((strSN == "0041002018") && m_nOperateID == 0) strSN = "0038002018";


                // IGXDevice objIGXDevice = m_objIGXFactory.OpenDeviceBySN(strSN, GX_ACCESS_MODE.GX_ACCESS_EXCLUSIVE);  //打开选中的设备
                m_listCCamerInfo[m_nOperateID].m_objIGXDevice = m_objIGXFactory.OpenDeviceBySN(strSN, GX_ACCESS_MODE.GX_ACCESS_CONTROL);  //打开选中的设备
                                                                                                                                          // m_listCCamerInfo[m_nOperateID].m_objIGXDevice = m_objIGXDevice;
                m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl = m_listCCamerInfo[m_nOperateID].m_objIGXDevice.GetRemoteFeatureControl();//获取远端设备层属性控制器，通过此控制器可以控制远端设备所有功能

                __InitParam(); //初始化相机参数，设定采集模式


                //开启采集流通道进行图像采集
                if (null != m_listCCamerInfo[m_nOperateID].m_objIGXStream)
                {
                    //RegisterCaptureCallback第一个参数属于用户自定参数(类型必须为引用
                    //类型)，若用户想用这个参数可以在委托函数中进行使用m_objIGXStream.RegisterCaptureCallback(this, __CaptureCallbackPro);

                    m_listCCamerInfo[m_nOperateID].m_objIGXStream.StartGrab();//开启流层采集，不论是回调采集还是单帧采集，之前必须先调用StartGrab接口，先启动流层采集
                }

                //发送开采命令
                if (null != m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl)
                {
                    m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetCommandFeature("AcquisitionStart").Execute();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("32. " + ex.Message);
            }
        }

        /// <summary>
        /// 枚举设备,此方法来自多相机例程
        /// </summary>
        private void __EnumDevice()
        {

            m_listIGXDeviceInfo.Clear();
            if (null != m_objIGXFactory)
            {
                //返回的设备信息列表，存入到m_listIGXDeviceInfo集合中
                m_objIGXFactory.UpdateDeviceList(200, m_listIGXDeviceInfo);

            }
            // 判断当前连接设备个数
            if (m_listIGXDeviceInfo.Count <= 0)
            {
                MessageBox.Show("未检测到设备,请确保设备正常连接然后重启程序!");
                return;
            }

            m_nCamNum = __GetMin(m_listIGXDeviceInfo.Count);
            // m_cb_EnumDevice.Items.Clear();
            for (int i = 0; i < m_nCamNum; i++)
            {
                //  m_cb_EnumDevice.Items.Add(m_listIGXDeviceInfo[i].GetDisplayName());
                CCamerInfo objCCamerInfo = new CCamerInfo();
                objCCamerInfo.m_strDisplayName = m_listIGXDeviceInfo[i].GetDisplayName();  //获取设备展示名称
                objCCamerInfo.m_strSN = m_listIGXDeviceInfo[i].GetSN();//获取设备序列号
                objCCamerInfo.m_emDeviceType = m_listIGXDeviceInfo[i].GetDeviceClass();   //获取设备类型，比如USB2.0、USB3.0、Gige

                m_listCCamerInfo.Add(objCCamerInfo);
            }


        }
        /// <summary>
        ///  初始化相机参数
        /// </summary>
        private void __InitParam()
        {
            if (null != m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl)
            {
                //打开流
                if (null != m_listCCamerInfo[m_nOperateID].m_objIGXDevice)
                {
                    m_listCCamerInfo[m_nOperateID].m_objIGXStream = m_listCCamerInfo[m_nOperateID].m_objIGXDevice.OpenStream(0);//OpenStream(0)参数都设为0，用户指定流通道序号打开某个流，获取流通道对象,此处也是注册回调函数采集
                }

                // 设备打开后更新设备打开标识
                m_bIsOpen = true;

                if (null != m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl)
                {
                    //设置采集模式连续采集
                    m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetEnumFeature("AcquisitionMode").SetValue("Continuous");

                    //设置触发模式为开
                    m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("Off");

                    //选择触发源为软触发
                    m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Software");
                }
            }
        }
        /// <summary>
        /// 当枚举的相机个数超过4个，按4个显示，小于等于4个按实际值显示
        /// 当枚举的相机个数小于0按0返回
        /// </summary>
        /// <param name="nDeviceCount">实际枚举到的个数</param>
        /// <returns>显示的最小个数</returns>
        private int __GetMin(int nDeviceCount)
        {
            if (nDeviceCount < 0)
            {
                return 0;
            }

            if (nDeviceCount > 4)
            {
                return 4;
            }

            return nDeviceCount;
        }

        /// <summary>
        /// 关闭相机
        /// </summary>
        public override void CloseCamera()
        {
            try
            {
                try
                {
                    //停止流通道、注销采集回调和关闭流
                    if (null != m_listCCamerInfo[m_nOperateID].m_objIGXStream)
                    {
                        m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetCommandFeature("AcquisitionStop").Execute();
                        m_listCCamerInfo[m_nOperateID].m_objIGXStream.StopGrab();
                        //注销采集回调函数
                        m_listCCamerInfo[m_nOperateID].m_objIGXStream.UnregisterCaptureCallback();
                        m_listCCamerInfo[m_nOperateID].m_objIGXStream.Close();
                        m_listCCamerInfo[m_nOperateID].m_objIGXStream = null;
                    }
                }
                catch (Exception)
                { }

                try
                {
                    //关闭设备
                    if (null != m_listCCamerInfo[m_nOperateID].m_objIGXDevice)
                    {
                        m_listCCamerInfo[m_nOperateID].m_objIGXDevice.Close();
                        m_listCCamerInfo[m_nOperateID].m_objIGXDevice = null;
                    }
                }
                catch (Exception)
                {

                }
                m_bIsOpen = false;
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 单帧取像
        /// </summary>
        /// <param name="m_Iamge">采集到的图像</param>
        public override void AcquireSingleImage(out HObject m_Iamge)
        {
            IntPtr arrHandler;
            byte[] m_arr = null;
            IntPtr[] m_arrHandler = null;
            IImageData objIImageData = null;

            //每次发送触发命令之前清空采集输出队列
            //防止库内部缓存帧，造成本次GXGetImage得到的图像是上次发送触发得到的图
            m_Iamge = null;
            if (m_nOperateID == 0) m_bSingle = true; else m_bSingle2 = true;
            try
            {
                //打开流
                //if (null != m_listCCamerInfo[m_nOperateID].m_objIGXStream) //
                //{
                //    m_listCCamerInfo[m_nOperateID].m_objIGXStream.FlushQueue();
                //}
                if (null != m_listCCamerInfo[m_nOperateID].m_objIGXDevice)
                {
                    if (null == m_listCCamerInfo[m_nOperateID].m_objIGXStream)
                        m_listCCamerInfo[m_nOperateID].m_objIGXStream = m_listCCamerInfo[m_nOperateID].m_objIGXDevice.OpenStream(0);//用户指定流通道序号打开某个流，获取流通道对象,此处也是注册回调函数采集
                    m_listCCamerInfo[m_nOperateID].m_objIGXStream.StartGrab();
                }
                //发送软触发命令
                if (null != m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl)
                {
                    //开始采集
                    m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetCommandFeature("AcquisitionStart").Execute();
                }

                //获取图像
                if (null != m_listCCamerInfo[m_nOperateID].m_objIGXStream)
                {
                    objIImageData = m_listCCamerInfo[m_nOperateID].m_objIGXStream.GetImage(500);//nTimeout

                }
                int m_nWidth = (int)objIImageData.GetWidth();
                int m_nHeigh = (int)objIImageData.GetHeight();

                m_arr = new byte[(m_nWidth * 3) * m_nHeigh];
                m_arrHandler = new IntPtr[(m_nWidth * 3) * m_nHeigh];

                arrHandler = objIImageData.GetBuffer();  //获取图像数据指针

                const int GX_FRAME_STATUS_SUCCESS = 0;
                if (objIImageData.GetStatus() == GX_FRAME_STATUS_SUCCESS) //采集成功正常帧 为0，不成功残帧为 - 1
                {
                    #region  改造
                    //采图成功而且是完整帧，可以进行图像处理...
                    //将相机的SDK采集的图像赋给了Halc0n的Hobect变量 m_Iamge
                    HOperatorSet.GenImage1(out m_Iamge, "byte",
                                 objIImageData.GetWidth(), objIImageData.GetHeight(), arrHandler);

                    
                    //旋转180度
                    HOperatorSet.RotateImage(m_Iamge, out m_Iamge, 180, "constant");
                    #endregion
                }
                objIImageData.Destroy();//销毁objImageData对象

                //停采
                m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetCommandFeature("AcquisitionStop").Execute();

                m_listCCamerInfo[m_nOperateID].m_objIGXStream.StopGrab();

                if (null != objIImageData)
                {
                    //用完之后释放资源
                    objIImageData.Destroy();
                }
            }
            catch (Exception ee)
            {

            }
        }

        private GX_VALID_BIT_LIST __GetBestValudBit(GX_PIXEL_FORMAT_ENTRY emPixelFormatEntry)
        {
            GX_VALID_BIT_LIST emValidBits = GX_VALID_BIT_LIST.GX_BIT_0_7;
            switch (emPixelFormatEntry)
            {
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG8:
                    {
                        emValidBits = GX_VALID_BIT_LIST.GX_BIT_0_7;
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG10:
                    {
                        emValidBits = GX_VALID_BIT_LIST.GX_BIT_2_9;
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG12:
                    {
                        emValidBits = GX_VALID_BIT_LIST.GX_BIT_4_11;
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO14:
                    {
                        //暂时没有这样的数据格式待升级
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG16:
                    {
                        //暂时没有这样的数据格式待升级
                        break;
                    }
                default:
                    break;
            }
            return emValidBits;
        }

        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="ExposureRaw">曝光值</param>
        public override void SetExposureRaw(double ExposureRaw)
        {
            double dMin = 0.0;                       //最小值
            double dMax = 0.0;                       //最大值

            try
            {
                //获取当前相机的曝光值、最小值、最大值和单位
                if (null != m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl)
                {
                    dMin = m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetFloatFeature("ExposureTime").GetMin();
                    dMax = m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetFloatFeature("ExposureTime").GetMax();
                    //判断输入值是否在曝光时间的范围内
                    //若大于最大值则将曝光值设为最大值
                    if (ExposureRaw > dMax)
                    {
                        ExposureRaw = dMax;
                    }
                    //若小于最小值将曝光值设为最小值
                    if (ExposureRaw < dMin)
                    {
                        ExposureRaw = dMin;
                    }
                    m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetFloatFeature("ExposureTime").SetValue(ExposureRaw);
                }
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 设置增益
        /// </summary>
        /// <param name="GainRaw">增益值</param>
        public override void SetGainRaw(double GainRaw)
        {
            double dMin = 0.0;           //最小值
            double dMax = 0.0;           //最大值
            try
            {
                //当前相机的增益值、最小值、最大值
                if (null != m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl)
                {
                    dMin = m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetFloatFeature("Gain").GetMin();
                    dMax = m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetFloatFeature("Gain").GetMax();

                    //判断输入值是否在增益值的范围内
                    //若输入的值大于最大值则将增益值设置成最大值
                    if (GainRaw > dMax)
                    {
                        GainRaw = dMax;
                    }

                    //若输入的值小于最小值则将增益的值设置成最小值
                    if (GainRaw < dMin)
                    {
                        GainRaw = dMin;
                    }

                    m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetFloatFeature("Gain").SetValue(GainRaw);
                }
            }
            catch (Exception ex)
            {

            }
        }

        //**************回调函数连续采集*****************
        /// <summary>
        /// 回调函数,用于获取图像信息和显示图像
        /// </summary>
        /// <param name="objUserParam">用户自定义传入参数</param>
        /// <param name="objIFrameData">图像信息对象</param>
        private void __CaptureCallbackPro(object objUserParam, IFrameData objIFrameData)
        {
            IntPtr arrHandler;
            byte[] m_arr = null;
            IntPtr[] m_arrHandler = null;
            IImageData objIImageData = null;
            difToCenterX[0] = 0;
            difToCenterY[0] = 0;

            if (m_bSingle) return;

            //每次发送触发命令之前清空采集输出队列
            //防止库内部缓存帧，造成本次GXGetImage得到的图像是上次发送触发得到的图
            if (null != m_listCCamerInfo[0].m_objIGXStream) //回调中图像自动覆盖，不用清空
            {
                m_listCCamerInfo[0].m_objIGXStream.FlushQueue();
            }
            const int GX_FRAME_STATUS_SUCCESS = 0;
            if (objIFrameData.GetStatus() == GX_FRAME_STATUS_SUCCESS) //采集成功正常帧 为0，不成功残帧为 - 1
            {
                //采图成功而且是完整帧，可以进行图像处理...
                UInt64 nWidth = objIFrameData.GetWidth();
                UInt64 nHeight = objIFrameData.GetHeight();

                GX_PIXEL_FORMAT_ENTRY emPixelFormat = objIFrameData.GetPixelFormat();
                m_arr = new byte[(nWidth * 3) * nHeight];
                m_arrHandler = new IntPtr[(nWidth * 3) * nHeight];
                arrHandler = objIFrameData.GetBuffer();

                #region  改造
                //将内存中图像取出，生成一个Hobject 的halcon图像
                HOperatorSet.GenImage1(out Himg, "byte", objIFrameData.GetWidth(), 
                                         objIFrameData.GetHeight(), arrHandler);
                HOperatorSet.RotateImage(Himg, out Himg, 180, "constant");

                //m_listCCamerInfo[0].m_objImageShowFrom：Halcon显示窗体
                HOperatorSet.DispObj(Himg, m_listCCamerInfo[0].m_objImageShowFrom);
                HOperatorSet.SetLineWidth(m_listCCamerInfo[0].m_objImageShowFrom, 2);
                HOperatorSet.SetColor(m_listCCamerInfo[0].m_objImageShowFrom, "red");
                HOperatorSet.DispLine(m_listCCamerInfo[0].m_objImageShowFrom, nHeight / 2, 0, nHeight / 2, nWidth);
                HOperatorSet.DispLine(m_listCCamerInfo[0].m_objImageShowFrom, 0, nWidth / 2, nHeight, nWidth / 2);

                //autoGetHoleCenter(Himg, m_listCCamerInfo[0].m_objImageShowFrom, out difToCenterX[0], out difToCenterY[0]);
                #endregion
            }

            if (Himg != null) Himg.Dispose();
            objIFrameData = null;


        }

        private void __CaptureCallbackPro2(object objUserParam, IFrameData objIFrameData)
        {
            IntPtr arrHandler;
            byte[] m_arr = null;
            IntPtr[] m_arrHandler = null;
            IImageData objIImageData = null;

            if (m_bSingle2) return;

            //每次发送触发命令之前清空采集输出队列
            //防止库内部缓存帧，造成本次GXGetImage得到的图像是上次发送触发得到的图
            try
            {
                //if (null != m_listCCamerInfo[1].m_objIGXStream)
                //{
                //    m_listCCamerInfo[1].m_objIGXStream.FlushQueue();
                //}
                const int GX_FRAME_STATUS_SUCCESS = 0;
                if (objIFrameData.GetStatus() == GX_FRAME_STATUS_SUCCESS) //采集成功正常帧 为0，不成功残帧为 - 1
                {
                    //采图成功而且是完整帧，可以进行图像处理...
                    UInt64 nWidth = objIFrameData.GetWidth();
                    UInt64 nHeight = objIFrameData.GetHeight();

                    GX_PIXEL_FORMAT_ENTRY emPixelFormat = objIFrameData.GetPixelFormat();
                    m_arr = new byte[(nWidth * 3) * nHeight];
                    m_arrHandler = new IntPtr[(nWidth * 3) * nHeight];
                    arrHandler = objIFrameData.GetBuffer();
                    HOperatorSet.GenImage1(out Himg, "byte", objIFrameData.GetWidth(), objIFrameData.GetHeight(), arrHandler);
                    HOperatorSet.DispObj(Himg, m_listCCamerInfo[1].m_objImageShowFrom);
                    HOperatorSet.SetLineWidth(m_listCCamerInfo[1].m_objImageShowFrom, 1);
                    HOperatorSet.SetColor(m_listCCamerInfo[1].m_objImageShowFrom, "red");
                    HOperatorSet.DispLine(m_listCCamerInfo[1].m_objImageShowFrom, nHeight / 2, 0, nHeight / 2, nWidth);
                    HOperatorSet.DispLine(m_listCCamerInfo[1].m_objImageShowFrom, 0, nWidth / 2, nHeight, nWidth / 2);

                }

                if (Himg != null) Himg.Dispose();
                objIFrameData = null;
            }
            catch
            {

            }

        }


        /// <summary>
        /// 图像的显示和存储
        /// </summary>
        /// <param name="m_Iamge">图像信息对象</param>
        void ImageShowAndSave(out HObject m_Iamge)
        {
            IntPtr arrHandler;
            byte[] m_arr = null;
            IntPtr[] m_arrHandler = null;
            IImageData objIImageData = null;

            //每次发送触发命令之前清空采集输出队列
            //防止库内部缓存帧，造成本次GXGetImage得到的图像是上次发送触发得到的图
            if (null != m_listCCamerInfo[m_nOperateID].m_objIGXStream)
            {
                m_listCCamerInfo[m_nOperateID].m_objIGXStream.FlushQueue();
            }

            //获取图像
            if (null != m_listCCamerInfo[m_nOperateID].m_objIGXStream)
            {
                objIImageData = m_listCCamerInfo[m_nOperateID].m_objIGXStream.GetImage(500);//nTimeout

            }

            int m_nWidth = (int)objIImageData.GetWidth();
            int m_nHeigh = (int)objIImageData.GetHeight();

            m_arr = new byte[(m_nWidth * 3) * m_nHeigh];
            m_arrHandler = new IntPtr[(m_nWidth * 3) * m_nHeigh];

            arrHandler = objIImageData.GetBuffer();
            HOperatorSet.GenImage1(out m_Iamge, "byte", objIImageData.GetWidth(), objIImageData.GetHeight(), arrHandler);


        }

        /// <summary>
        /// 使用回调方式来进行连续采集
        /// </summary>
        public override void ContinueGrab(HWindow hwindow)
        {
            //注意：必须先发送开采命令，相机才能输出曝光结束事件，而且发送开采命令，
            //必须严格按照：先调用IGXStream::StartGrab接口，然后再通过属性控制器获取”AcquisitionStart”命令节点，执行命令Execute。

            //注册采集回调函数，注意第一个参数是用户私有参数，用户可以传入任何object对象，也可以是null
            //用户私有参数在回调函数内部还原使用，如果不使用私有参数，可以传入null
            if (m_nOperateID == 0) m_bSingle = false; else if (m_nOperateID == 1) m_bSingle2 = false;
            try
            {

                m_listCCamerInfo[m_nOperateID].m_objIGXStream.RegisterCaptureCallback(null, __CaptureCallbackPro);

            }
            catch
            {

            }
            //开启采集流通道进行图像采集
            if (null != m_listCCamerInfo[m_nOperateID].m_objIGXStream)
            {
                //RegisterCaptureCallback第一个参数属于用户自定参数(类型必须为引用
                //类型)，若用户想用这个参数可以在委托函数中进行使用m_objIGXStream.RegisterCaptureCallback(this, __CaptureCallbackPro);
                m_listCCamerInfo[m_nOperateID].m_objIGXStream.StartGrab();//开启流层采集，不论是回调采集还是单帧采集，之前必须先调用StartGrab接口，先启动流层采集
            }
            //发送开采命令
            if (null != m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl)
            {
                m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetCommandFeature("AcquisitionStart").Execute();
            }
            m_listCCamerInfo[m_nOperateID].m_objImageShowFrom = hwindow;

        }

        /// <summary>
        /// 停止采集
        /// </summary>
        public override void StopGrab()
        {
            var camerInfo = m_listCCamerInfo[m_nOperateID];
            //停止流通道、注销采集回调和关闭流
           // if (m_listCCamerInfo[m_nOperateID].m_objIGXStream != null)
            if (camerInfo != null && camerInfo.m_objIGXStream != null)
            {
                var stream = camerInfo.m_objIGXStream;

                stream.StopGrab();
                stream.UnregisterCaptureCallback();
                stream.Close();
                camerInfo.m_objIGXStream = null;

                //m_listCCamerInfo[m_nOperateID].m_objIGXStream.StopGrab();
                //m_listCCamerInfo[m_nOperateID].m_objIGXStream.UnregisterCaptureCallback();
                //m_listCCamerInfo[m_nOperateID].m_objIGXStream.Close();
                //m_listCCamerInfo[m_nOperateID].m_objIGXStream = null;
            }


        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~MERCameraClass()
        {

            try
            {
                // 如果未停采则先停止采集

                if (null != m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl)
                {

                    //m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl.GetCommandFeature("AcquisitionStop").Execute();
                }

            }
            catch (Exception)
            {

            }

            try
            {
                //停止流通道、注销采集回调和关闭流
                if (null != m_listCCamerInfo[m_nOperateID].m_objIGXStream)
                {
                    m_listCCamerInfo[m_nOperateID].m_objIGXStream.StopGrab();
                    m_listCCamerInfo[m_nOperateID].m_objIGXStream.UnregisterCaptureCallback();
                    m_listCCamerInfo[m_nOperateID].m_objIGXStream.Close();
                    m_listCCamerInfo[m_nOperateID].m_objIGXStream = null;
                }
            }
            catch (Exception)
            {

            }
            try
            {
                ////关闭设备
                if (null != m_listCCamerInfo[m_nOperateID].m_objIGXDevice)
                {

                    m_listCCamerInfo[m_nOperateID].m_objIGXDevice.Close();
                    m_listCCamerInfo[m_nOperateID].m_objIGXDevice = null;
                }
            }
            catch (Exception)
            {

            }

            try
            {
                //反初始化
                if (null != m_objIGXFactory)
                {
                    m_objIGXFactory.Uninit();
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
