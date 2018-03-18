using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.OutputModel
{
    /// <summary>
    /// 订单试算响应
    /// </summary>
    public class TrialResp
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
        /// 交易流水号，与请求报文的流水号一致
        /// </summary>
        public string transNo { get; set; }

        /// <summary>
        /// 渠道商身份标识，由魔方指定
        /// </summary>
        public string caseCode { get; set; }

        /// <summary>
        /// 必填  支付金额（单位：元）
        /// </summary>
        public double price { get; set; }

        /// <summary>
        /// 产品试算信息Id(此对象用于承保接口的产品试算信息)
        /// </summary>
        public string priceArgsId { get; set; }
 
    }
}
