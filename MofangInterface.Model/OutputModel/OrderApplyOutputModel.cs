using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.OutputModel
{
    /// <summary>
    /// 承保响应
    /// </summary>
    public class OrderApplyOutputModel
    {
        /// <summary>
        /// 返回信息
        /// </summary>
        public string respmsg { get; set; }

        /// <summary>
        /// 返回码
        /// </summary>
        public string respstat { get; set; }

        /// <summary>
        /// 交易流水号，与请求报文的流水号一致
        /// </summary>
        public string transNo { get; set; }

        /// <summary>
        /// 投保单号(只会为一个投保单号)
        /// </summary>
        public string insureNum { get; set; }

        /// <summary>
        /// 投保价格
        /// </summary>
        public string price { get; set; }
 
    }
}
