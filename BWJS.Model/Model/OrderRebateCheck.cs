using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model
{
    /// <summary>
    /// 订单返利
    /// </summary>
    [Serializable]
    public partial class OrderRebateCheck
    {
        #region BasicModel
        /// <summary>
        /// 订单返利编号
        /// </summary>
        [DataMember]
        public int OrderRebateId
        {
            set;
            get;
        }
        /// <summary>
        /// 交易流水号
        /// </summary>
        [DataMember]
        public string TransNo
        {
            set;
            get;
        }
        /// <summary>
        /// 渠道编号
        /// </summary>
        [DataMember]
        public int? CompanyId
        {
            set;
            get;
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember]
        public int? UserId
        {
            set;
            get;
        }
        /// <summary>
        /// 承保编号OrderApply外键
        /// </summary>
        [DataMember]
        public int? OrderApplyId
        {
            set;
            get;
        }
        /// <summary>
        /// 渠道返利编号CompanyRebate外键
        /// </summary>
        [DataMember]
        public int? CompanyRebateId
        {
            set;
            get;
        }
        /// <summary>
        /// 订单金额
        /// </summary>
        [DataMember]
        public decimal? OrderMoney
        {
            set;
            get;
        }
        /// <summary>
        /// 商家返利百分比
        /// </summary>
        [DataMember]
        public decimal? MerchantRebate
        {
            set;
            get;
        }
        /// <summary>
        /// 商家返利金额
        /// </summary>
        [DataMember]
        public decimal? MerchantMoney
        {
            set;
            get;
        }
        /// <summary>
        /// 代理商返利金额
        /// </summary>
        [DataMember]
        public decimal? AgentMoney
        {
            set;
            get;
        }
        /// <summary>
        /// 代理商返利百分比
        /// </summary>
        [DataMember]
        public decimal? AgentRebate
        {
            set;
            get;
        }
        /// <summary>
        /// 总部返利百分比
        /// </summary>
        [DataMember]
        public decimal? HQRebate
        {
            set;
            get;
        }
        /// <summary>
        /// 总部返利金额
        /// </summary>
        [DataMember]
        public decimal? HQMoney
        {
            set;
            get;
        }
        /// <summary>
        /// 净利润
        /// </summary>
        [DataMember]
        public decimal? NetProfit
        {
            set;
            get;
        }
        /// <summary>
        /// 支付状态0未支付1已支付2支付失败
        /// </summary>
        [DataMember]
        public int? PayStatus
        {
            set;
            get;
        }
        /// <summary>
        /// 结算状态0未结算1已申请2已结算
        /// </summary>
        [DataMember]
        public int? IsSettled
        {
            set;
            get;
        }
        /// <summary>
        /// 退保状态0未退保1已退保
        /// </summary>
        [DataMember]
        public int? IsCancel
        {
            set;
            get;
        }
        /// <summary>
        /// 结算日期
        /// </summary>
        [DataMember]
        public DateTime? SettlementDate
        {
            set;
            get;
        }
        /// <summary>
        /// 建档日期
        /// </summary>
        [DataMember]
        public DateTime? CreateDate
        {
            set;
            get;
        }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark
        {
            set;
            get;
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        [DataMember]
        public int? IsDeleted
        {
            set;
            get;
        }
        /// <summary>
        /// 建档人编号
        /// </summary>
        [DataMember]
        public int? Exp_CreateId
        {
            set;
            get;
        }
        /// <summary>
        /// 建档日期
        /// </summary>
        [DataMember]
        public DateTime? Exp_CreateDate
        {
            set;
            get;
        }
        /// <summary>
        /// 修改人编号
        /// </summary>
        [DataMember]
        public int? Exp_EditId
        {
            set;
            get;
        }
        /// <summary>
        /// 修改日期
        /// </summary>
        [DataMember]
        public DateTime? Exp_EditDate
        {
            set;
            get;
        }
        /// <summary>
        /// 批次号
        /// </summary>
        [DataMember]
        public string Exp_BatchNo
        {
            set;
            get;
        }
        /// <summary>
        /// 新生成的订单返利编号
        /// </summary>
        [DataMember]
        public int? Exp_NewId
        {
            set;
            get;
        }
        /// <summary>
        /// 类别
        /// </summary>
        [DataMember]
        public int? Exp_CompanyCategoryId
        {
            set;
            get;
        }
        /// <summary>
        /// 渠道
        /// </summary>
        [DataMember]
        public int? Exp_CompanyId
        {
            set;
            get;
        }
        /// <summary>
        /// 结算方式1销售额百分比2单笔结算
        /// </summary>
        [DataMember]
        public int? Exp_SettlementMethod
        {
            set;
            get;
        }
        /// <summary>
        /// 销售额百分比
        /// </summary>
        [DataMember]
        public decimal? Exp_SalesPercentage
        {
            set;
            get;
        }
        /// <summary>
        /// 商家
        /// </summary>
        [DataMember]
        public int? Exp_UserId
        {
            set;
            get;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string Exp_FullName
        {
            set;
            get;
        }
        /// <summary>
        /// 证件类型
        /// </summary>
        [DataMember]
        public int? Exp_IdCardType
        {
            set;
            get;
        }
        /// <summary>
        /// 证件号码
        /// </summary>
        [DataMember]
        public string Exp_IdCard
        {
            set;
            get;
        }
        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public int? Exp_Sex
        {
            set;
            get;
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        [DataMember]
        public string Exp_Mobile
        {
            set;
            get;
        }
        /// <summary>
        /// 推荐码
        /// </summary>
        [DataMember]
        public string Exp_RecommendationCode
        {
            set;
            get;
        }
        /// <summary>
        /// 申请金额
        /// </summary>
        [DataMember]
        public decimal? Exp_ApplicationAmount
        {
            set;
            get;
        }
        /// <summary>
        /// 放款金额
        /// </summary>
        [DataMember]
        public decimal? Exp_LoanAmount
        {
            set;
            get;
        }
        /// <summary>
        /// 合同金额
        /// </summary>
        [DataMember]
        public decimal? Exp_ContractAmount
        {
            set;
            get;
        }
        /// <summary>
        /// 申请期限
        /// </summary>
        [DataMember]
        public int? Exp_LoanTerm
        {
            set;
            get;
        }
        /// <summary>
        /// 放款日期
        /// </summary>
        [DataMember]
        public DateTime? Exp_LoanDate
        {
            set;
            get;
        }
        /// <summary>
        /// 申请产品编号
        /// </summary>
        [DataMember]
        public int? Exp_ProductId
        {
            set;
            get;
        }
        /// <summary>
        /// 申请产品
        /// </summary>
        [DataMember]
        public string Exp_ProductName
        {
            set;
            get;
        }
        /// <summary>
        /// 商家返利百分比
        /// </summary>
        [DataMember]
        public decimal? Exp_MerchantRebate
        {
            set;
            get;
        }
        /// <summary>
        /// 商家返利金额
        /// </summary>
        [DataMember]
        public decimal? Exp_MerchantMoney
        {
            set;
            get;
        }
        /// <summary>
        /// 代理商返利百分比
        /// </summary>
        [DataMember]
        public decimal? Exp_AgentRebate
        {
            set;
            get;
        }
        /// <summary>
        /// 代理商返利金额
        /// </summary>
        [DataMember]
        public decimal? Exp_AgentMoney
        {
            set;
            get;
        }
        /// <summary>
        /// 总部返利百分比
        /// </summary>
        [DataMember]
        public decimal? Exp_HQRebate
        {
            set;
            get;
        }
        /// <summary>
        /// 总部返利金额
        /// </summary>
        [DataMember]
        public decimal? Exp_HQMoney
        {
            set;
            get;
        }
        /// <summary>
        /// 净利润
        /// </summary>
        [DataMember]
        public decimal? Exp_NetProfit
        {
            set;
            get;
        }
        #endregion BasicModel

        #region ExtensionModel 
        #endregion
    }
}
