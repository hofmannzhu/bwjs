using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.OutputModel
{
    /// <summary>
    /// 投保单列表响应
    /// </summary>
    public class OrderSummaryOutputModel
    {
        /// <summary>
        /// 返回消息
        /// </summary>
        public string respstat { get; set; }

        /// <summary>
        /// 返回状态
        /// </summary>
        public string respmsg { get; set; }

        /// <summary>
        /// 保单信息
        /// </summary>
        public List<Order> orders { get; set; }
    }

    public class Order
    {
        /// <summary>
        /// 产品名
        /// </summary>
        public string aliasName { get; set; }

        /// <summary>
        /// 交易码
        /// </summary>
        public string transNo { get; set; }

        /// <summary>
        /// 方案代码
        /// </summary>
        public string caseCode { get; set; }

        /// <summary>
        /// 投保时间 格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string createtime { get; set; }

        /// <summary>
        /// 渠道商用户唯一标示
        /// </summary>
        public string customkey { get; set; }

        /// <summary>
        /// 起保时间 格式：yyyy-MM-dd
        /// </summary>
        public string startDate { get; set; }

        /// <summary>
        /// 终保时间  格式：yyyy-MM-dd
        /// </summary>
        public string endDate { get; set; }

        /// <summary>
        /// 保单下载地址
        /// </summary>
        public string policyUrl { get; set; }

        /// <summary>
        /// 投保单号（投保成功后，魔方返回）
        /// </summary>
        public string insureNum { get; set; }

        /// <summary>
        /// 保单状态 -1：出单失败	 1：承保失败 10：待出单 20：已出单30：已过期 40：退保中 50：已退保
        /// </summary>
        public string issueState { get; set; }

        /// <summary>
        /// 保单状态描述
        /// </summary>
        public string issueStateDesc { get; set; }

        /// <summary>
        /// 投保详细信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public double singlePrice { get; set; }

        /// <summary>
        /// 被保人姓名
        /// </summary>
        public string insurantcName { get; set; }

        /// <summary>
        /// 被保人证件类型
        /// </summary>
        public int insurantcardType { get; set; }

        /// <summary>
        /// 被保人证件码
        /// </summary>
        public string insurantcardCode { get; set; }

        /// <summary>
        /// 投保人姓名
        /// </summary>
        public string applicantcName { get; set; }

        /// <summary>
        /// 投保人证件类型
        /// </summary>
        public int applicantcardType { get; set; }

        /// <summary>
        /// 投保人证件码
        /// </summary>
        public string applicantcardCode { get; set; }

        /// <summary>
        /// 购买份数
        /// </summary>
        public int count { get; set; }
    }
}
