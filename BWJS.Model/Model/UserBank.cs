using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{

    /// <summary>
    /// 用户银行卡
    /// </summary>
    [Serializable]
    public partial class UserBank
    {
        #region BasicModel
        /// <summary>
        /// 用户银行编号
        /// </summary>
        [DataMember]
        public int UserBankId
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
        /// 银行代码
        /// </summary>
        [DataMember]
        public string BankCode
        {
            set;
            get;
        }
        /// <summary>
        /// 开户行
        /// </summary>
        [DataMember]
        public string OpeningBank
        {
            set;
            get;
        }
        /// <summary>
        /// 持卡人
        /// </summary>
        [DataMember]
        public string CardHolder
        {
            set;
            get;
        }
        /// <summary>
        /// 卡号
        /// </summary>
        [DataMember]
        public string CardNumber
        {
            set;
            get;
        }
        /// <summary>
        /// 银行地址
        /// </summary>
        [DataMember]
        public string BankAddress
        {
            set;
            get;
        }
        /// <summary>
        /// 支付宝账户
        /// </summary>
        [DataMember]
        public string AlipayAccount
        {
            set;
            get;
        }
        /// <summary>
        /// 是否默认银行卡
        /// </summary>
        [DataMember]
        public bool IsDefault
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
        /// <summary>
        /// 是否删除
        /// </summary>
        [DataMember]
        public int? IsDeleted
        {
            set;
            get;
        }
        #endregion BasicModel

        #region ExtensionModel

        #endregion
    }
}
