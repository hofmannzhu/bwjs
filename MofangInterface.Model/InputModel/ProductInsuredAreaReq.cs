using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.InputModel
{
    /// <summary>
    /// 产品可投保区域请求
    /// </summary>
    public class ProductInsuredAreaReq
    {
        public string customkey { get; set; }
        /// <summary>
        /// 必填 交易流水号，每次请求不能相同
        /// </summary>
        public string transNo { get; set; }

        /// <summary>
        /// 必填  方案代码，每一款保险公司产品的方案代码都不相同，由慧择分配
        /// </summary>
        public string caseCode { get; set; }

        /// <summary>
        /// 地区编码，为空时查询省份列表
        /// </summary>
        public string areaCode { get; set; }

    }
}
