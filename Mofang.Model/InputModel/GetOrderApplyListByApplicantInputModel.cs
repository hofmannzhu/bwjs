using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mofang.Model.InputModel
{
    public class GetOrderApplyListByApplicantInputModel :InputModelBase
    {
        /// <summary>
        /// 投保人身份证号
        /// </summary>
        public string ApplicantInfoCardCode { get; set; }
    }
}
