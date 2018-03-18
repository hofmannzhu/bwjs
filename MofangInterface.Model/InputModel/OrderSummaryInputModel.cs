using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.InputModel
{
    /// <summary>
    /// 投保单列表请求
    /// </summary>
    public class OrderSummaryInputModel
    {
        /// <summary>
        /// 开始时间（>订单创建时间）
        /// </summary>
        public string starttime { get; set; }

        /// <summary>
        /// 结束时间（<订单创建时间）
        /// </summary>
        public string endtime { get; set; }

        /// <summary>
        /// 必填 渠道商用户唯一标示
        /// </summary>
        public string customkey { get; set; }

        /// <summary>
        /// 开始条数
        /// </summary>
        public int start { get; set; }

        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int limit { get; set; }
    }
}
