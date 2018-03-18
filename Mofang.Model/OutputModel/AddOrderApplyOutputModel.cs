using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mofang.Model.OutputModel
{
    public class AddOrderApplyOutputModel 
    {
        /// <summary>
        /// 保单号
        /// </summary>
        public string InsureNum { get; set; }

        /// <summary>
        /// 投保价格
        /// </summary>
        public string Price { get; set; }
    }
}
