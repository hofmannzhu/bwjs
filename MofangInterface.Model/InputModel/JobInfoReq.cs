using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.InputModel
{
    public class JobInfoReq
    {
        /// <summary>
        /// 交易流水号，与请求报文的流水号一致
        /// </summary>
        public string transNo { get; set; }

        /// <summary>
        /// 方案代码
        /// </summary>
        public string caseCode { get; set; }

        /// <summary>
        /// 渠道商身份标识，由魔方指定
        /// </summary>
        public string customkey { get; set; }
    }
}
