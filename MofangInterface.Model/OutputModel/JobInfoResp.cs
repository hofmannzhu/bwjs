using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.OutputModel
{
    public class JobInfoResp
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
        /// 健康告知ID
        /// </summary>
        public List<InsureJobVo> insureJobVos { get; set; }
    }
    public class InsureJobVo
    {
        /// <summary>
        /// 职业ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 职业代码模板Id(大部分渠道可以不用关注此字段)
        /// </summary>
        public int templateId { get; set; }
        /// <summary>
        /// 职业代码模板Id(大部分渠道可以不用关注此字段)
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 职业父级ID
        /// </summary>
        public int parentId { get; set; }
        /// <summary>
        /// Z职业危险等级
        /// </summary>
        public string level { get; set; }
        /// <summary>
        /// 职业名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 是否支持投保
        /// </summary>
        public string isInsure { get; set; }
    }
}
