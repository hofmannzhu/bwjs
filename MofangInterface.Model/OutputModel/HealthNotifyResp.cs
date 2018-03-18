using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.OutputModel
{
    /// <summary>
    /// 健康告知提交响应
    /// </summary>
    public class HealthNotifyResp
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
        /// 渠道商身份标识
        /// </summary>
        public string customkey { get; set; }

        /// <summary>
        /// 健康告知ID
        /// </summary>
        public int healthId { get; set; } 
    } 
}
