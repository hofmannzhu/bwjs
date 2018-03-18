using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 订单返利结算申请
    /// </summary>
    [Serializable]
    public partial class OrderRebateSettlementApply
    {
        #region BasicModel
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
        /// 商家编号
        /// </summary>		
        [DataMember]
        public int UserId
        {
            get;
            set;
        }
        /// <summary>
        /// 部门编号
        /// </summary>		
        [DataMember]
        public int? DepartmentId
        {
            get;
            set;
        }
        /// <summary>
        /// 申请起始日期
        /// </summary>		
        [DataMember]
        public DateTime? StartDate
        {
            get;
            set;
        }
        /// <summary>
        /// 申请截止日期
        /// </summary>		
        [DataMember]
        public DateTime? EndDate
        {
            get;
            set;
        }
        /// <summary>
        /// 申请结算金额
        /// </summary>		
        [DataMember]
        public decimal ApplyMoney
        {
            get;
            set;
        }
        /// <summary>
        /// 实际结算金额
        /// </summary>		
        [DataMember]
        public decimal ActualMoney
        {
            get;
            set;
        }
        /// <summary>
        /// 结算申请状态0未结算1待支付2已结算
        /// </summary>		
        [DataMember]
        public int ApplyStatus
        {
            get;
            set;
        }
        /// <summary>
        /// 结算方式1销售额百分比2单笔结算
        /// </summary>		
        [DataMember]
        public int? SettlementMethod
        {
            get;
            set;
        }
        /// <summary>
        /// 销售额百分比
        /// </summary>		
        [DataMember]
        public decimal SalesPercentage
        {
            get;
            set;
        }
        /// <summary>
        /// 支付方式1线下转账2在线支付
        /// </summary>		
        [DataMember]
        public int? PaymentMethod
        {
            get;
            set;
        }
        /// <summary>
        /// 开户行
        /// </summary>		
        [DataMember]
        public string OpeningBank
        {
            get;
            set;
        }
        /// <summary>
        /// 持卡人
        /// </summary>		
        [DataMember]
        public string CardHolder
        {
            get;
            set;
        }
        /// <summary>
        /// 卡号
        /// </summary>		
        [DataMember]
        public string CardNumber
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>		
        [DataMember]
        public string Remark
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
        /// 修改人编号
        /// </summary>		
        [DataMember]
        public int? EditId
        {
            get;
            set;
        }
        /// <summary>
        /// 修改日期
        /// </summary>		
        [DataMember]
        public DateTime? EditDate
        {
            get;
            set;
        }
        /// <summary>
        /// 是否删除
        /// </summary>		
        [DataMember]
        public int IsDeleted
        {
            get;
            set;
        }

        #endregion

        #region ExtensionModel 

        #endregion
    }
}
