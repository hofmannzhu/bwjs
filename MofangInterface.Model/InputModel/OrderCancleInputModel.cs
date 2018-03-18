using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.InputModel
{
    /// <summary>
    /// 退保请求
    /// </summary>
    public  class OrderCancleInputModel
    {
        /// <summary>
        /// 必填 投保订单的交易流水号
        /// </summary>
        public string transNo { get; set; }

        /// <summary>
        /// 必填 渠道商身份标识，由魔方指定
        /// </summary>
        public string customkey { get; set; }

        /// <summary>
        /// 必填  投保单号（投保成功后，魔方返回）
        /// </summary>
        public string insureNum { get; set; }
    }
}
