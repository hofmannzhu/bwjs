using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model
{
    /// <summary>
    /// 用户基本信息表
    /// </summary>
    [Serializable]
    public partial class SupplierInfo
    {

        /// <summary>
        /// 主键编号
        /// </summary>		
        [DataMember]
        public int SId
        {
            get;
            set;
        }
        /// <summary>
        /// 标记名称
        /// </summary>		
        [DataMember]
        public string SignName
        {
            get;
            set;
        }
        /// <summary>
        /// 用户名称
        /// </summary>		
        [DataMember]
        public string UserName
        {
            get;
            set;
        }
        /// <summary>
        /// 用户手机号
        /// </summary>		
        [DataMember]
        public string UserMobile
        {
            get;
            set;
        }
        /// <summary>
        /// 用户邮箱
        /// </summary>		
        [DataMember]
        public string UserEmail
        {
            get;
            set;
        }
        /// <summary>
        /// 用户详细地址
        /// </summary>		
        [DataMember]
        public string UserAdress
        {
            get;
            set;
        }
        /// <summary>
        /// 用户QQ
        /// </summary>		
        [DataMember]
        public string UserQQ
        {
            get;
            set;
        }
        /// <summary>
        /// 用户微信
        /// </summary>		
        [DataMember]
        public string UserWechat
        {
            get;
            set;
        }
        /// <summary>
        /// 公司名称
        /// </summary>		
        [DataMember]
        public string CorporateName
        {
            get;
            set;
        }
        /// <summary>
        /// 公司官网地址
        /// </summary>		
        [DataMember]
        public string CompanyWebsite
        {
            get;
            set;
        }
        /// <summary>
        /// 公司电话
        /// </summary>		
        [DataMember]
        public string CompanyPhone
        {
            get;
            set;
        }
        /// <summary>
        /// 保证金
        /// </summary>		
        [DataMember]
        public string CautionMoney
        {
            get;
            set;
        }
        /// <summary>
        /// 担保人
        /// </summary>		
        [DataMember]
        public string Guarantee
        {
            get;
            set;
        }
        /// <summary>
        /// 担保人手机号
        /// </summary>		
        [DataMember]
        public string GuaranteeMobile
        {
            get;
            set;
        }
        /// <summary>
        /// 可提现金额
        /// </summary>		
        [DataMember]
        public string Balance
        {
            get;
            set;
        }
        /// <summary>
        /// 锁定总余额
        /// </summary>		
        [DataMember]
        public string LockBalance
        {
            get;
            set;
        }
        /// <summary>
        /// 总返利金额
        /// </summary>		
        [DataMember]
        public string TotalBalance
        {
            get;
            set;
        }
        /// <summary>
        /// 类型 暂时未定
        /// </summary>		
        [DataMember]
        public int Type
        {
            get;
            set;
        }
        /// <summary>
        /// 状态 0表示正常
        /// </summary>		
        [DataMember]
        public int State
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        [DataMember]
        public DateTime CreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 最后更新时间
        /// </summary>		
        [DataMember]
        public DateTime UpdateTime
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
        /// 扩展字段1
        /// </summary>		
        [DataMember]
        public string extend1
        {
            get;
            set;
        }
        /// <summary>
        /// 扩展字段2
        /// </summary>		
        [DataMember]
        public string extend2
        {
            get;
            set;
        }
        /// <summary>
        /// 扩展字段3
        /// </summary>		
        [DataMember]
        public string extend3
        {
            get;
            set;
        }
        /// <summary>
        /// 扩展字段4
        /// </summary>		
        [DataMember]
        public string extend4
        {
            get;
            set;
        }
        /// <summary>
        /// 扩展字段5
        /// </summary>		
        [DataMember]
        public string extend5
        {
            get;
            set;
        }

    }
}
