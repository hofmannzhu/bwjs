using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.InputModel
{
    /// <summary>
    /// 获取支付链接请求
    /// </summary>
    public class GetPayUrlReq
    {
        /// <summary>
        /// 必填 交易流水号，每次请求不能相同
        /// </summary>
        public string transNo { get; set; }

        /// <summary>
        /// 必填  方案代码
        /// </summary>
        public string caseCode { get; set; }

        /// <summary>
        /// 必填  渠道商身份标识
        /// </summary>
        public string customkey { get; set; }

        /// <summary>
        ///  必填  投保单号
        /// </summary>
        public string insureNum { get; set; }

        /// <summary>
        /// 必填  支付金额（单位：元）
        /// </summary>
        public double price { get; set; }

        /// <summary>
        /// 必填  页面通知地址 
        /// 回跳地址
        /// </summary>
        public string pageNoticeUrl { get; set; }

     
    }
}
