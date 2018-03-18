using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BWJS.BLL.CookieMag;
using BWJS.BLL;
using UtilityHelper;

namespace XBWNInterface.Model
{
    #region 一级参数request
    /// <summary>
    /// 信博维诺请求类
    /// </summary>
    [Serializable]
    public partial class xbwn_Request
    {
        #region BasicModel
        /// <summary>
        /// 常规参数
        /// </summary>
        [DataMember]
        public header header { get; set; }
        /// <summary>
        /// 手机相关参数
        /// </summary>
        [DataMember]
        public device device { get; set; }
        /// <summary>
        /// 业务参数
        /// </summary>
        [DataMember]
        public Object data { get; set; }

        #endregion

        #region ExtensionModel

        #endregion
    }
    #endregion

    #region 二级参数header
    /// <summary>
    /// header
    /// </summary>
    [Serializable]
    public partial class header
    {
        #region BasicModel
        /// <summary>
        /// 移动端操作入口
        /// </summary>
        [DataMember]
        public string target
        {
            set;
            get;
        }
        /// <summary>
        /// 密钥键名
        /// </summary>
        [DataMember]
        public string key
        {
            set;
            get;
        }
        /// <summary>
        /// 版本号
        /// </summary>
        [DataMember]
        public string version
        {
            set;
            get;
        }
        /// <summary>
        /// 请求类型0移动网络1wifi
        /// </summary>
        [DataMember]
        public int? requestType
        {
            set;
            get;
        }
        /// <summary>
        /// 时间戳
        /// </summary>
        [DataMember]
        public long timestamp
        {
            set;
            get;
        }
        #endregion BasicModel
        #region BasicModel
        /// <summary>
        /// 签名MD5（商户号+设备号+身份证号+手机号+时间戳，连接符为-
        /// </summary>
        [DataMember]
        public string sign
        {
            set;
            get;
        }
        #endregion BasicModel
        #region BasicModel
        /// <summary>
        /// 订单号
        /// </summary>
        [DataMember]
        public string orderNo
        {
            set;
            get;
        }
        #endregion
        #region BasicModel
        /// <summary>
        /// 商户编号
        /// </summary>
        [DataMember]
        public string merchantsNo
        {
            set;
            get;
        }
        #endregion
        /// <summary>
        /// 设备编号
        /// </summary>
        [DataMember]
        public string equipmentNo
        {
            set;
            get;
        }
        /// <summary>
        /// 订单类型【LOAN】
        /// </summary>
        [DataMember]
        public string orderType
        {
            set;
            get;
        }
        /// <summary>
        /// 订单来源【BWPC】
        /// </summary>
        [DataMember]
        public string orderSource
        {
            set;
            get;
        } 

    }

    #endregion

    #region 二级参数device
    /// <summary>
    /// device
    /// </summary>
    [Serializable]
    public partial class device
    {
        #region BasicModel
        /// <summary>
        /// 手机串号
        /// </summary>
        [DataMember]
        public string imei
        {
            set;
            get;
        }
        /// <summary>
        /// 手机uuid
        /// </summary>
        [DataMember]
        public string uuid
        {
            set;
            get;
        }
        /// <summary>
        /// 客户端获取的ip
        /// </summary>
        [DataMember]
        public string ip
        {
            set;
            get;
        }
        /// <summary>
        /// gps地址
        /// </summary>
        [DataMember]
        public string gps
        {
            set;
            get;
        }
        /// <summary>
        /// 网络位置
        /// </summary>
        [DataMember]
        public string networkLocation
        {
            set;
            get;
        }
        /// <summary>
        /// mac地址
        /// </summary>
        [DataMember]
        public string mac
        {
            set;
            get;
        }
        /// <summary>
        /// 百荣设备指纹
        /// </summary>
        [DataMember]
        public string brGid
        {
            set;
            get;
        }
        /// <summary>
        /// 百荣设备流水号
        /// </summary>
        [DataMember]
        public string brNo
        {
            set;
            get;
        }
        /// <summary>
        /// 同盾设备指纹
        /// </summary>
        [DataMember]
        public string tdGid
        {
            set;
            get;
        }
        /// <summary>
        /// 移动端来源安卓ANDROID苹果IOS
        /// </summary>
        [DataMember]
        public string source
        {
            set;
            get;
        }
        /// <summary>
        /// 渠道来源如xx商城
        /// </summary>
        [DataMember]
        public string sourceChannel
        {
            set;
            get;
        }
        /// <summary>
        /// 设备指纹
        /// </summary>
        [DataMember]
        public f f { get; set; }

        #endregion BasicModel

    }
    #endregion

    #region 三级参数 f
    /// <summary>
    /// f
    /// </summary>
    [Serializable]
    public partial class f
    {
        #region BasicModel
        /// <summary>
        /// 设备指纹类型（即哪一方的设备指纹）
        /// </summary>
        [DataMember]
        public string t { get; set; }
        /// <summary>
        /// 设备指纹值
        /// </summary>
        [DataMember]
        public string v { get; set; }

        #endregion
    }


    #endregion

}