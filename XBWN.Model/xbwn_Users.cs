using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XBWN.Model
{
    /// <summary>
    /// 信博维诺用户表
    /// </summary>
    [Serializable]
    public partial class xbwn_Users
    {       
        #region BasicModel
        /// <summary>
        /// 商家编号
        /// </summary>
        [DataMember]
        public int UserId
        {
            set;
            get;
        }
        /// <summary>
        /// 网贷申请编号
        /// </summary>
        [DataMember]
        public int NetLoanApplyId
        {
            set;
            get;
        }
        /// <summary>
        /// 手机串号
        /// </summary>
        [DataMember]
        public string IMEI
        {
            set;
            get;
        }
        /// <summary>
        /// 信博维诺用户编号
        /// </summary>
        [DataMember]
        public int? MemberId
        {
            set;
            get;
        }
        /// <summary>
        /// 信博维诺客户编号
        /// </summary>
        [DataMember]
        public int? CustomerId
        {
            set;
            get;
        }
        /// <summary>
        /// 令牌信息
        /// </summary>
        [DataMember]
        public string Token
        {
            set;
            get;
        }
        /// <summary>
        /// 用户姓名
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
        /// 带有86的手机号
        /// </summary>
        [DataMember]
        public string TelNo
        {
            set;
            get;
        }
        /// <summary>
        /// 密码
        /// </summary>
        [DataMember]
        public string UserPassword
        {
            set;
            get;
        }
        /// <summary>
        /// 邀请码
        /// </summary>
        [DataMember]
        public string InviteCode
        {
            set;
            get;
        }
        /// <summary>
        /// IP
        /// </summary>
        [DataMember]
        public string RegisterIP
        {
            set;
            get;
        }
        /// <summary>
        /// 信博维诺短信验证码
        /// </summary>
        [DataMember]
        public string SmsCode
        {
            set;
            get;
        }
        /// <summary>
        /// 信博维诺身份证正面图片标识
        /// </summary>
        [DataMember]
        public string FontId
        {
            set;
            get;
        }
        /// <summary>
        /// 信博维诺身份证背面图片标识
        /// </summary>
        [DataMember]
        public string BankId
        {
            set;
            get;
        }
        /// <summary>
        /// 信博维诺人脸图片编号逗号分隔
        /// </summary>
        [DataMember]
        public string FaceNo
        {
            set;
            get;
        }
        /// <summary>
        /// 身份证信息提交是否成功
        /// </summary>
        [DataMember]
        public bool Success
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
