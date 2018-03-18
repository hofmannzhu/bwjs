using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 结算申请详情
    /// </summary>
    [Serializable]
    public partial class OrderRebateSettlementDetails
    {
        #region BasicModel 
        /// <summary>
        /// 订单结算详情编号
        /// </summary>		
        [DataMember]
        public int OrderRebateSettlementDetailsId
        {
            get;
            set;
        }
        /// <summary>
        /// 订单返利结算申请编号
        /// </summary>		
        [DataMember]
        public int OrderRebateSettlementApplyId
        {
            get;
            set;
        }
        /// <summary>
        /// 订单返利编号
        /// </summary>		
        [DataMember]
        public int OrderRebateId
        {
            get;
            set;
        }
        /// <summary>
        /// 建档日期
        /// </summary>		
        [DataMember]
        public DateTime CreateDate
        {
            get;
            set;
        }
        /// <summary>
        /// 建档人编号
        /// </summary>		
        [DataMember]
        public int CreateId
        {
            get;
            set;
        }

        #endregion


        #region ExtensionModel 

        #endregion
    }
}
