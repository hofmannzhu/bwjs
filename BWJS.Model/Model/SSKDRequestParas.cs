using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model
{
    /// <summary>
    /// 闪速快贷请求参数类
    /// </summary>
    [Serializable]
    public class SSKDRequestParas
    {
        #region 公用参数
        /// <summary>
        /// 申请借款主键
        /// </summary>
        [DataMember]
        public int ConsultId { get; set; }

        /// <summary>
        /// 签名MD5（商户号+设备号+身份证号+手机号+时间戳，连接符为-）
        /// </summary>
        [DataMember]
        public string Sign { get; set; }

        /// <summary>
        /// 申请借款主键
        /// </summary>
        [DataMember]
        public string OrderNo { get; set; }

        /// <summary>
        /// 申请借款主键
        /// </summary>
        [DataMember]
        public string Token { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        [DataMember]
        public string EquipmentNo { get; set; }

        /// <summary>
        /// 商户编号
        /// </summary>
        [DataMember]
        public string MerchantsNo { get; set; }
        #endregion

        #region 页面初始化时间
        DateTime? pageLoadDateTime = null;
        /// <summary>
        /// 页面初始化时间
        /// </summary>
        [DataMember]
        public DateTime PageLoadDateTime
        {
            get { return pageLoadDateTime.HasValue ? pageLoadDateTime.Value : DateTime.Now; }
            set { pageLoadDateTime = value; }
        }

        #endregion

        #region 填写信息参数

        /// <summary>
        /// 省
        /// </summary>
        [DataMember]
        [DefaultValue(-1)]
        public int ProvinceId { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [DataMember]
        [DefaultValue(-1)]
        public int CityId { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        [DataMember]
        [DefaultValue(-1)]
        public int DistrictId { get; set; }

        /// <summary>
        /// 现居住地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// 常用邮箱
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [DataMember]
        public string CompanyName { get; set; }
        #endregion

        #region header
        /// <summary>
        /// pc端操作入口
        /// </summary>
        [DataMember]
        [DefaultValue("pcrk")]
        public string Target { get; set; }
        /// <summary>
        /// 秘钥键名
        /// </summary>
        [DataMember]
        [DefaultValue("myjm")]
        public string Key { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        [DataMember]
        [DefaultValue("V1")]
        public string Version { get; set; }
        /// <summary>
        /// 浏览器类型 1-IE  0-其它
        /// </summary>
        [DataMember]
        [DefaultValue(1)]
        public int RequestType { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        [DataMember]
        [DefaultValue(0)]
        public long Timestamp { get; set; }
        /// <summary>
        /// 订单类型【LOAN】
        /// </summary>
        [DataMember]
        [DefaultValue("LOAN")]
        public string OrderType { get; set; }
        /// <summary>
        /// 订单来源【BWPC/BWPAD】
        /// </summary>
        [DataMember]
        [DefaultValue("BWPC")]
        public string OrderSource { get; set; }
        #endregion


        #region data
        /// <summary>
        ///商户账号
        /// </summary>
        [DataMember]
        public string merchantsAcount { get; set; }


        /// <summary>
        ///商户姓名
        /// </summary>
        [DataMember]
        public string merchantsName { get; set; }

        /// <summary>
        ///商户手机号
        /// </summary>
        [DataMember]
        public string merchantsMobile { get; set; }

        /// <summary>
        ///商户身份证号
        /// </summary>
        [DataMember]
        public string merchantsIdCardNo { get; set; }


        /// <summary>
        /// 授权类型(开户create 授额quota 提额improve)
        /// </summary>
        [DataMember]
        public string authorizedType { get; set; }


        /// <summary>
        /// 授权额度
        /// </summary>
        [DataMember]
        public string amount { get; set; }
        #endregion

        /// <summary>
        /// 商户信息
        /// </summary>
        [DataMember]
        public MerchantInfo MerchantInfo { get; set; }

        /// <summary>
        /// 设备信息
        /// </summary>
        [DataMember]
        public MachineInfo MachineInfo { get; set; }
    }

    /// <summary>
    /// 商户信息
    /// </summary>
    [Serializable]
    public class MerchantInfo
    {
        /// <summary>
        /// 商户编号
        /// </summary>
        [DataMember]
        public string MerchantNo { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string LoginName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string RealName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public string Sex { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [DataMember]
        public string QQ { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        [DataMember]
        public string WeChat { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// 头像ID
        /// </summary>
        [DataMember]
        public long HeadId { get; set; }

        /// <summary>
        /// 商户名称
        /// </summary>
        [DataMember]
        public string CompanyName { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [DataMember]
        public string IdCardNo { get; set; }

        /// <summary>
        /// 锁定状态 0-正常；1-锁定
        /// </summary>
        [DataMember]
        public string IsLocked { get; set; }

        /// <summary>
        /// 登录状态 0-未登录；1-已登录
        /// </summary>
        [DataMember]
        public string IsLogined { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        [DataMember]
        public int LoginTimes { get; set; }

        /// <summary>
        /// 所在省
        /// </summary>
        [DataMember]
        public string Province { get; set; }

        /// <summary>
        /// 所在市
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// 所在区县
        /// </summary>
        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// 上级商户编号
        /// </summary>
        [DataMember]
        public string SuperMerchantNo { get; set; }

    }

    /// <summary>
    /// 设备信息
    /// </summary>
    [Serializable]
    public class MachineInfo
    {
        /// <summary>
        /// IMEI编号
        /// </summary>
        [DataMember]
        public string ImeiNo { get; set; }

        /// <summary>
        /// 设备类型(PC、PAD)
        /// </summary>
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        [DataMember]
        public string MachineNo { get; set; }

        /// <summary>
        /// mac地址
        /// </summary>
        [DataMember]
        public string Mac { get; set; }

        /// <summary>
        /// 设备所在地
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// 状态 1-正常；0-冻结
        /// </summary>
        [DataMember]
        public string Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [DataMember]
        public string Longitude { get; set; }

        /// <summary>
        /// 维度
        /// </summary>
        [DataMember]
        public string Latitude { get; set; }

    }
}
