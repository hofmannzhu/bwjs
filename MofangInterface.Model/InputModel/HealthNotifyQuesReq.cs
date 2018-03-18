using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.InputModel
{
    /// <summary>
    /// 获取健康告知题目请求
    /// </summary>
    public class HealthNotifyQuesReq
    {
        /// <summary>
        /// 交易流水号，每次请求不能相同
        /// </summary>
        public string transNo { get; set; }

        /// <summary>
        /// 渠道商身份标识
        /// </summary>
        public string customkey { get; set; }

        /// <summary>
        /// 产品方案代码
        /// </summary>
        public string caseCode { get; set; }

        public string priceArgsId { get; set; }
    }
}
