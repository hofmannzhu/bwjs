using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 贷款信息
    /// </summary>
    [Serializable]
    public partial class NL_Loan
    {
        #region BasicModel
        /// <summary>
        /// 贷款编号
        /// </summary>
        [DataMember]
        public int LoanId
        {
            set;
            get;
        }
        /// <summary>
        /// 网贷申请编号
        /// </summary>
        [DataMember]
        public int? ConsultId
        {
            set;
            get;
        }
        /// <summary>
        /// 借款单据号
        /// </summary>
        [DataMember]
        public string BorrowNo
        {
            set;
            get;
        }
        /// <summary>
        /// 提现卡编号
        /// </summary>
        [DataMember]
        public string BankId
        {
            set;
            get;
        }
        /// <summary>
        /// 贷款参数JSON
        /// </summary>
        [DataMember]
        public string LoanInfo
        {
            set;
            get;
        }
        /// <summary>
        /// 借款金额
        /// </summary>
        [DataMember]
        public decimal? LoanAmount
        {
            set;
            get;
        }
        /// <summary>
        /// 放款金额（到手金额）
        /// </summary>
        [DataMember]
        public decimal? AmountReceived
        {
            set;
            get;
        }
        /// <summary>
        /// 服务费
        /// </summary>
        [DataMember]
        public decimal? LoanServiceCharge
        {
            set;
            get;
        }
        /// <summary>
        /// 借款利率
        /// </summary>
        [DataMember]
        public decimal? LoanRate
        {
            set;
            get;
        }
        /// <summary>
        /// 到期应还
        /// </summary>
        [DataMember]
        public decimal? ReturnAmount
        {
            set;
            get;
        }
        /// <summary>
        /// 借款时间
        /// </summary>
        [DataMember]
        public DateTime? LoanDate
        {
            set;
            get;
        }
        /// <summary>
        /// 借款天数
        /// </summary>
        [DataMember]
        public int? LoanDays
        {
            set;
            get;
        }
        /// <summary>
        /// 到期时间
        /// </summary>
        [DataMember]
        public DateTime? DueDate
        {
            set;
            get;
        }
        /// <summary>
        /// 利息名称
        /// </summary>
        [DataMember]
        public string InterestName
        {
            set;
            get;
        }
        /// <summary>
        /// 利息值
        /// </summary>
        [DataMember]
        public string InterestValue
        {
            set;
            get;
        }
        /// <summary>
        /// 信博维诺银行卡编号
        /// </summary>
        [DataMember]
        public int? BankCardId
        {
            set;
            get;
        }
        /// <summary>
        /// 会员编号
        /// </summary>
        [DataMember]
        public int? MemberId
        {
            set;
            get;
        }
        /// <summary>
        /// 客户编号
        /// </summary>
        [DataMember]
        public int? CustomerId
        {
            set;
            get;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string RealName
        {
            set;
            get;
        }
        /// <summary>
        /// 身份证
        /// </summary>
        [DataMember]
        public string IdNo
        {
            set;
            get;
        }
        /// <summary>
        /// 银行编码
        /// </summary>
        [DataMember]
        public string BankCode
        {
            set;
            get;
        }
        /// <summary>
        /// 银行名称
        /// </summary>
        [DataMember]
        public string BankName
        {
            set;
            get;
        }
        /// <summary>
        /// 银行预留手机号
        /// </summary>
        [DataMember]
        public string TelNo
        {
            set;
            get;
        }
        /// <summary>
        /// 是否正确
        /// </summary>
        [DataMember]
        public int? IsCorrect
        {
            set;
            get;
        }
        /// <summary>
        /// 设置第一次借款标志false第一次借款
        /// </summary>
        [DataMember]
        public bool TradePasswordExist
        {
            set;
            get;
        }
        /// <summary>
        /// 交易密码
        /// </summary>
        [DataMember]
        public string TradePassword
        {
            set;
            get;
        }
        /// <summary>
        /// 交易密码
        /// </summary>
        [DataMember]
        public string TradePasswordSecond
        {
            set;
            get;
        }
        /// <summary>
        /// 是否成功借款1成功0失败
        /// </summary>
        [DataMember]
        public int? Flag
        {
            set;
            get;
        }
        /// <summary>
        /// 接入标志
        /// </summary>
        [DataMember]
        public bool Mark
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
        public int? CreateId
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
        /// 修改人编号
        /// </summary>
        [DataMember]
        public int? EditId
        {
            set;
            get;
        }
        /// <summary>
        /// 修改日期
        /// </summary>
        [DataMember]
        public DateTime? EditDate
        {
            set;
            get;
        }
        #endregion BasicModel

        #region ExtensionModel

        #endregion
    }
}