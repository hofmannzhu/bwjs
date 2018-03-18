using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 网贷申请
    /// </summary>
    [Serializable]
    public partial class NetLoanApply
    {
        #region BasicModel

        /// <summary>
        /// 网贷申请编号
        /// </summary>		
        [DataMember]
        public int NetLoanApplyId
        {
            get;
            set;
        }
        /// <summary>
        /// 渠道编号
        /// </summary>		
        [DataMember]
        public int? CompanyId
        {
            get;
            set;
        }
        /// <summary>
        /// 商家编号
        /// </summary>		
        [DataMember]
        public int? UserId
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
        /// 设备编号
        /// </summary>		
        [DataMember]
        public string SN
        {
            get;
            set;
        }
        /// <summary>
        /// 证件号码库编号
        /// </summary>		
        [DataMember]
        public int? IdCardLibraryId
        {
            get;
            set;
        }
        /// <summary>
        /// 姓名
        /// </summary>		
        [DataMember]
        public string FullName
        {
            get;
            set;
        }
        /// <summary>
        /// 证件类型
        /// </summary>		
        [DataMember]
        public int? IdCardType
        {
            get;
            set;
        }
        /// <summary>
        /// 证件号码
        /// </summary>		
        [DataMember]
        public string IdCard
        {
            get;
            set;
        }
        /// <summary>
        /// 性别
        /// </summary>		
        [DataMember]
        public int? Sex
        {
            get;
            set;
        }
        /// <summary>
        /// 手机号码
        /// </summary>		
        [DataMember]
        public string Mobile
        {
            get;
            set;
        }
        /// <summary>
        /// 推荐码
        /// </summary>		
        [DataMember]
        public string RecommendationCode
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
        /// 状态0未成功1成功
        /// </summary>		
        [DataMember]
        public int? Status
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
        /// <summary>
        /// 申请金额
        /// </summary>		
        [DataMember]
        public decimal ApplicationAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 放款金额
        /// </summary>		
        [DataMember]
        public decimal LoanAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 合同金额
        /// </summary>		
        [DataMember]
        public decimal ContractAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 申请期限
        /// </summary>		
        [DataMember]
        public int? LoanTerm
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
        /// 放款日期
        /// </summary>		
        [DataMember]
        public DateTime? LoanDate
        {
            get;
            set;
        }
        /// <summary>
        /// 申请产品编号
        /// </summary>		
        [DataMember]
        public int? ProductId
        {
            get;
            set;
        }
        /// <summary>
        /// 申请产品名
        /// </summary>		
        [DataMember]
        public string ProductName
        {
            get;
            set;
        }
        /// <summary>
        /// 结算状态0未结算1已结算
        /// </summary>		
        [DataMember]
        public int IsSettled
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
        /// 代理商返利百分比
        /// </summary>		
        [DataMember]
        public decimal AgentRebate
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
        /// 结算日期
        /// </summary>		
        [DataMember]
        public DateTime? SettlementDate
        {
            get;
            set;
        }
        #endregion
        /// <summary>
        /// 申请产品名
        /// </summary>		
        [DataMember]
        public string SourceCompany
        {
            get;
            set;
        }
    }
}
