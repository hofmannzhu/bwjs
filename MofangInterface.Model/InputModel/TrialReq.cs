using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.InputModel
{
    /// <summary>
    /// 订单试算请求
    /// </summary>
    public class TrialReq
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

        /// <summary>
        /// 当前试算因子值(所有试算因子)
        /// </summary>
        public List<GeneParam> newRestrictGenes { get; set; }

        //被改变的试算因子被该前的值
        public GeneParam oldRestrictGene { get; set; }
    }
}
