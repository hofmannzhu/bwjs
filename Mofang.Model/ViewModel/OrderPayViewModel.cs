using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mofang.Model.ViewModel
{
   public class OrderPayViewModel
    { 

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
        public string caseCode { get; set; }
        public string customkey { get; set; }
    }
}
