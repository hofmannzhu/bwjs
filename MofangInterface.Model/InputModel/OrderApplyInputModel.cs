using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.InputModel
{
    /// <summary>
    /// 承保请求
    /// </summary>
    public class OrderApplyInputModel
    { 
        /// <summary>
        /// 必填 交易流水号，每次请求不能相同
        /// </summary>
        public string transNo { get; set; }
        /// <summary>
        /// 渠道商身份标识
        /// </summary>
        public string customkey { get; set; }
        /// <summary>
        /// 必填  承保天数(与起保时间终保时间差一致)
        /// </summary>
        public string insurantDateLimit { get; set; }

        /// <summary>
        /// 必填 方案代码
        /// </summary>
        public string caseCode { get; set; }

        /// <summary>
        /// 必填 订单信息
        /// </summary>
        public ApplicationData applicationdata { get; set; }

        /// <summary>
        /// 必填 投保人信息
        /// </summary>
        public ApplicantInfo applicantinfo { get; set; }

        /// <summary>
        ///  必填 被保人信息
        /// </summary>
        public InsurantInfo insurantInfo { get; set; }

        
        /// <summary>
        /// 其他信息
        /// </summary>
        public OtherInfo otherInfo { get; set; } 

    }

    /// <summary>
    /// 被保人信息
    /// </summary>
    public class InsurantInfo
    {
        /// <summary>
        /// 必填 被保险人姓名
        /// </summary>
        public string cName { get; set; }

        /// <summary>
        ///  被保险人姓名拼音，境外旅游险必填
        /// </summary>
        public string eName { get; set; }

        /// <summary>
        /// 必填  被保险人性别 0：女 1：男
        /// </summary>
        public int sex { get; set; }

        /// <summary>
        /// 必填  被保险人证件类型（取值参考附录1）
        /// </summary>
        public int cardType { get; set; }

        /// <summary>
        /// 必填 被保险人证件号
        /// </summary>
        public string cardCode { get; set; }

        /// <summary>
        /// 必填 被保险人出生日期 格式：yyyy-MM-dd
        /// </summary>
        public string birthday { get; set; }

        /// <summary>
        /// 必填  与投保人关系（取值参考附录2） 
        /// </summary>
        public int relationId { get; set; }

        /// <summary>
        /// 必填  被保险人购买份数(不能超过最高购买份数)
        /// </summary>
        public int count { get; set; }


        /// <summary>
        /// 必填  产品结算价（单位：元）
        /// </summary>
        public decimal singlePrice { get; set; }

        /// <summary>
        /// 证件有效期
        /// </summary>
        public string cardPeriod { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile { get; set; }
        public string email { get; set; }
        /// <summary>
        /// 职业信息，职业id使用“-”拼接如：101414-101415-101416
        /// </summary>
        public string job { get; set; }
    }

    /// <summary>
    /// 投保人信息
    /// </summary>
    public class ApplicantInfo
    {
        /// <summary>
        /// 必填 投保人姓名
        /// </summary>
        public string cName { get; set; }

        /// <summary>
        /// 投保人姓名拼音，境外旅游险必填
        /// </summary>
        public string eName { get; set; }

        /// <summary>
        /// 必填  投保人证件类型（取值参考附录1）
        /// </summary>
        public int cardType { get; set; }

        /// <summary>
        /// 必填 投保人证件号
        /// </summary>
        public string cardCode { get; set; }

        /// <summary>
        /// 必填  投保人性别 0：女 1：男
        /// </summary>
        public int sex { get; set; }

        /// <summary>
        /// 必填  投保人出生日期
        /// 格式：yyyy-MM-dd
        /// </summary>
        public string birthday { get; set; }

        /// <summary>
        /// 必填  投保人移动电话
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        ///  必填  投保人邮箱
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 证件有效期
        /// </summary>
        public string cardPeriod { get; set; }
        /// <summary>
        /// 职业信息，职业id使用“-”拼接如：101414-101415-101416
        /// </summary>
        public string job { get; set; }
    }
    /// <summary>
    /// 订单信息
    /// </summary>
    public class ApplicationData
    {
        /// <summary>
        /// 投保时间
        /// 格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string applicationDate { get; set; }

        /// <summary>
        /// 必填  起保时间 格式：yyyy-MM-dd
        /// </summary>
        public string startDate { get; set; }

        /// <summary>
        /// 终保时间  格式：yyyy-MM-dd
        /// </summary>
        public string endDate { get; set; }
    }
    public class OtherInfo
    {
        public string provCityId { get; set; }
        public string cardPeriod { get; set; }
        public string notifyAnswerId { get; set; }
        public string priceArgsId { get; set; }
        public int relatedPersonHouse { get; set; }
        public string propertyAddress { get; set; }
        public int tripPurposeId { get; set; }
        public string destination { get; set; }
        public string visaCity { get; set; }
    }
}
