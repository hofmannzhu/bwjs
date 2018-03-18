using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.InputModel
{
    /// <summary>
    /// 健康告知提交请求
    /// </summary>
    public class HealthNotifyReq
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
        /// 上述页面的duck.getHealthOld()值
        /// </summary>
        public string answer { get; set; }
    }
}
