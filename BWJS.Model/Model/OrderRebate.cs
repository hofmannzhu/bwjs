using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 订单返利
    /// </summary>
    [Serializable]
    public partial class OrderRebate
    {
        #region BasicModel
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
        /// 交易流水号
        /// </summary>		
        [DataMember]
        public string TransNo
        {
            get;
            set;
        }
        /// <summary>
        /// 渠道编号
        /// </summary>		
        [DataMember]
        public int CompanyId
        {
            get;
            set;
        }
        /// <summary>
        /// 用户编号
        /// </summary>		
        [DataMember]
        public int UserId
        {
            get;
            set;
        }
        /// <summary>
        /// 承保编号OrderApply外键
        /// </summary>		
        [DataMember]
        public int OrderApplyId
        {
            get;
            set;
        }
        /// <summary>
        /// 渠道返利编号CompanyRebate外键
        /// </summary>		
        [DataMember]
        public int CompanyRebateId
        {
            get;
            set;
        }
        /// <summary>
        /// 订单金额
        /// </summary>		
        [DataMember]
        public decimal OrderMoney
        {
            get;
            set;
        }
        /// <summary>
        /// 商家返利百分比
        /// </summary>		
        [DataMember]
        public decimal MerchantRebate
        {
            get;
            set;
        }
        /// <summary>
        /// 商家返利金额
        /// </summary>		
        [DataMember]
        public decimal MerchantMoney
        {
            get;
            set;
        }
        /// <summary>
        /// 代理商返利金额
        /// </summary>		
        [DataMember]
        public decimal AgentMoney
        {
            get;
            set;
        }
        /// <summary>
        /// 代理商返利百分比
        /// </summary>		
        [DataMember]
        public decimal AgentRebate
        {
            get;
            set;
        }
        /// <summary>
        /// 总部返利百分比
        /// </summary>		
        [DataMember]
        public decimal HQRebate
        {
            get;
            set;
        }
        /// <summary>
        /// 总部返利金额
        /// </summary>		
        [DataMember]
        public decimal HQMoney
        {
            get;
            set;
        }
        /// <summary>
        /// 净利润
        /// </summary>		
        [DataMember]
        public decimal NetProfit
        {
            get;
            set;
        }
        /// <summary>
        /// 支付状态0未支付1已支付2支付失败
        /// </summary>		
        [DataMember]
        public int PayStatus
        {
            get;
            set;
        }
        /// <summary>
        /// 结算状态0未结算1已申请2已结算
        /// </summary>		
        [DataMember]
        public int IsSettled
        {
            get;
            set;
        }
        /// <summary>
        /// 退保状态0未退保1已退保
        /// </summary>		
        [DataMember]
        public int IsCancel
        {
            get;
            set;
        }
        /// <summary>
        /// 结算日期
        /// </summary>		
        [DataMember]
        public DateTime? SettlementDate
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
        /// 备注
        /// </summary>		
        [DataMember]
        public string Remark
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
        #endregion Model
    }
}
