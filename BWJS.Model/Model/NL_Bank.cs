using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model{
	    /// <summary>
    /// 银行卡表
    /// </summary>
	    [Serializable]
	public partial class NL_Bank
    {
        #region BasicModel
        /// <summary>
        /// 银行卡编号
        /// </summary>
        [DataMember]
        public int BankId
        {
            set;
            get;
        }
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
        /// 信博维诺银行卡添加申请号
        /// </summary>
        [DataMember]
        public string No
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
        /// 银行卡号
        /// </summary>
        [DataMember]
        public string BankCardNo
        {
            set;
            get;
        }
        /// <summary>
        /// 手机号
        /// </summary>
        [DataMember]
        public string TelNo
        {
            set;
            get;
        }
        /// <summary>
        /// 1提现卡0非提现卡
        /// </summary>
        [DataMember]
        public int? Cash
        {
            set;
            get;
        }
        /// <summary>
        /// 银行手机验证码
        /// </summary>
        [DataMember]
        public string SmsCode
        {
            set;
            get;
        }
        /// <summary>
        /// 绑卡标志1成功0失败
        /// </summary>
        [DataMember]
        public int? Flag
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

        //public void Add(NL_Bank model)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

    }
}

