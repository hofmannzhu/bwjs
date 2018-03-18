using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.OutputModel
{
    /// <summary>
    /// 退保响应
    /// </summary>
    public class OrderCancleOutputModel
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
        /// 退保信息码 0000 代表退保申请已提交（一般代表退保成功）
        /// </summary>
        public string respCode { get; set; } 
        /// <summary>
        /// 投保单号
        /// </summary>
        public string insureNum { get; set; }
    }
}
