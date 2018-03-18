using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 身份信息
    /// </summary>
    [Serializable]
    public partial class NL_IdentityInfo
    {
        #region BasicModel
        /// <summary>
        /// 网贷申请编号
        /// </summary>
        [DataMember]
        public int ConsultId
        {
            set;
            get;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string FullName
        {
            set;
            get;
        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        [DataMember]
        public string IDNo
        {
            set;
            get;
        }
        /// <summary>
        /// 月收入
        /// </summary>
        [DataMember]
        public int? MonthlyIncome
        {
            set;
            get;
        }
        /// <summary>
        /// 信用记录信用良好，少数逾期，多次逾期，无信用记录
        /// </summary>
        [DataMember]
        public int? CreditHistory
        {
            set;
            get;
        }
        /// <summary>
        /// 住房状态自有全款房，自有贷款房，租赁，其他
        /// </summary>
        [DataMember]
        public int? HousingStatus
        {
            set;
            get;
        }
        /// <summary>
        /// 驾驶证
        /// </summary>
        [DataMember]
        public string DrivingLicense
        {
            set;
            get;
        }
        /// <summary>
        /// 人脸
        /// </summary>
        [DataMember]
        public string Face
        {
            set;
            get;
        }
        /// <summary>
        /// 身份证扫描件
        /// </summary>
        [DataMember]
        public string IdentityCardScanner
        {
            set;
            get;
        }
        /// <summary>
        /// 银行卡
        /// </summary>
        [DataMember]
        public string DebitCard
        {
            set;
            get;
        }
        /// <summary>
        /// 信用卡
        /// </summary>
        [DataMember]
        public string CreditCard
        {
            set;
            get;
        }
        /// <summary>
        /// 微信钱包是否显示微粒贷
        /// </summary>
        [DataMember]
        public int? ParticleLoan
        {
            set;
            get;
        }
        /// <summary>
        /// 是否有商业保单
        /// </summary>
        [DataMember]
        public int? BusinessPolicy
        {
            set;
            get;
        }
        /// <summary>
        /// 信用卡使用年限
        /// </summary>
        [DataMember]
        public int? CreditCardAgeLimit
        {
            set;
            get;
        }
        /// <summary>
        /// 是否做过其他贷款
        /// </summary>
        [DataMember]
        public int? OtherLoan
        {
            set;
            get;
        }
        /// <summary>
        /// 是否有支付宝芝麻分
        /// </summary>
        [DataMember]
        public int? SesameSeed
        {
            set;
            get;
        }
        /// <summary>
        /// 是否有淘宝账户
        /// </summary>
        [DataMember]
        public int? TaobaoAccount
        {
            set;
            get;
        }
        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public string Company
        {
            set;
            get;
        }
        /// <summary>
        /// 单位性质
        /// </summary>
        [DataMember]
        public int? UnitNature
        {
            set;
            get;
        }
        /// <summary>
        /// 单位工作时间
        /// </summary>
        [DataMember]
        public int? WorkingHour
        {
            set;
            get;
        }
        /// <summary>
        /// 工资发放形式
        /// </summary>
        [DataMember]
        public int? Payroll
        {
            set;
            get;
        }
        /// <summary>
        /// 职业身份公务员/事业单位，上班族，企业主，个体户，自由职业者，其他
        /// </summary>
        [DataMember]
        public int? JobPosition
        {
            set;
            get;
        }
        /// <summary>
        /// 社保
        /// </summary>
        [DataMember]
        public int? SocialSecurit
        {
            set;
            get;
        }
        /// <summary>
        /// 公积金
        /// </summary>
        [DataMember]
        public int? Fund
        {
            set;
            get;
        }
        /// <summary>
        /// 学历
        /// </summary>
        [DataMember]
        public int? Degree
        {
            set;
            get;
        }
        /// <summary>
        /// 毕业年份
        /// </summary>
        [DataMember]
        public string GraduationYear
        {
            set;
            get;
        }
        #endregion BasicModel

        #region ExtensionModel

        #endregion
    }
}