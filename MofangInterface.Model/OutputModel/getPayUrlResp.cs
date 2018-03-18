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
    public class GetPayUrlResp
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
        /// 投保单号
        /// </summary>
        public string insureNum { get; set; }

        /// <summary>
        /// 渠道ID
        /// </summary>
        public string customkey { get; set; }

        /// <summary>
        /// 支付参数对象，用于跳转到支付页面
        /// </summary>
        public string payUrl { get; set; } 
    }
}
