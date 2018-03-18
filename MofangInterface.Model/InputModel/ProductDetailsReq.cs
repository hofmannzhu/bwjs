using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.InputModel
{
    /// <summary>
    /// 产品详情信息请求
    /// </summary>
    public class ProductDetailsReq
    {
        /// <summary>
        /// 必填 交易流水号，每次请求不能相同
        /// </summary>
        public string transNo { get; set; }

        /// <summary>
        /// 必填  渠道商身份标识
        /// </summary>
        public string customkey { get; set; }

        /// <summary>
        /// 必填  方案代码，每一款保险公司产品的方案代码都不相同
        /// </summary>
        public string caseCode { get; set; }
    }
}
