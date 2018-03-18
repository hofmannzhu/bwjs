using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.OutputModel
{
    /// <summary>
    /// 获取健康告知题目响应
    /// </summary>
    public class HealthNotifyQuesResp
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
        /// 健康告知题目html(富文本)
        /// </summary>
        public string healthNotifyHtml { get; set; }
        public priceArgs priceArgs { get; set; }
    }
    public class priceArgs
    {
        public int productId { get; set; }
        public int productPlanId { get; set; }
        public List<genes> genes { get; set; }
    }
    public class genes
    {
        public string key { get; set; }
        public string value { get; set; }
        public int sort { get; set; }
        public string protectItemId { get; set; }
    }
}
