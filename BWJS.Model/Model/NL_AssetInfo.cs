using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model{
	    /// <summary>
    /// 资产信息
    /// </summary>
	    [Serializable]
	public partial class NL_AssetInfo
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
        /// 名下是否有车
        /// </summary>
        [DataMember]
        public int? Cars
        {
            set;
            get;
        }
        /// <summary>
        /// 名下是否有房
        /// </summary>
        [DataMember]
        public int? Houses
        {
            set;
            get;
        }
        /// <summary>
        /// 是否做过其它贷款
        /// </summary>
        [DataMember]
        public int? OtherLoans
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
        /// 是否有淘宝帐号
        /// </summary>
        [DataMember]
        public int? TaobaoAccount
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
        /// 是否有信用卡
        /// </summary>
        [DataMember]
        public int? CreditCard
        {
            set;
            get;
        }
        /// <summary>
        /// 您的信用情况
        /// </summary>
        [DataMember]
        public int? CreditSituation
        {
            set;
            get;
        }
        /// <summary>
        /// 信用卡使用年限
        /// </summary>
        [DataMember]
        public int? CreditCardServiceLife
        {
            set;
            get;
        }
        #endregion BasicModel

        #region ExtensionModel

        #endregion
    }
}