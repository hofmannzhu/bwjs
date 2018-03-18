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
    public partial class NL_Consult
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
        /// 渠道编号
        /// </summary>
        [DataMember]
        public int? CompanyId
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
        /// 手机号
        /// </summary>
        [DataMember]
        public string Mobile
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
        /// 贷款金额
        /// </summary>
        [DataMember]
        public decimal? LoanAmount
        {
            set;
            get;
        }
        /// <summary>
        /// 贷款期限
        /// </summary>
        [DataMember]
        public int? LoanTerm
        {
            set;
            get;
        }
        /// <summary>
        /// 贷款用途
        /// </summary>
        [DataMember]
        public string LoanUse
        {
            set;
            get;
        }
        /// <summary>
        /// 利息
        /// </summary>
        [DataMember]
        public decimal? LoanRate
        {
            set;
            get;
        }
        /// <summary>
        /// 贷款状态
        /// </summary>
        [DataMember]
        public int? Status
        {
            set;
            get;
        }
        /// <summary>
        /// 贷款状态说明
        /// </summary>
        [DataMember]
        public string StatusRemark
        {
            set;
            get;
        }
        /// <summary>
        /// 省份编号
        /// </summary>
        [DataMember]
        public int? ProvinceId
        {
            set;
            get;
        }
        /// <summary>
        /// 城市编号
        /// </summary>
        [DataMember]
        public int? CityId
        {
            set;
            get;
        }
        /// <summary>
        /// 地区编号
        /// </summary>
        [DataMember]
        public int? DistrictId
        {
            set;
            get;
        }
        /// <summary>
        /// 地区
        /// </summary>
        [DataMember]
        public string Area
        {
            set;
            get;
        }
        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        public string Address
        {
            set;
            get;
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember]
        public string Email
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
        /// 签名
        /// </summary>
        [DataMember]
        public string Sign
        {
            set;
            get;
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        [DataMember]
        public string OrderNo
        {
            set;
            get;
        }
        /// <summary>
        /// 查询码
        /// </summary>
        [DataMember]
        public string QueryCode
        {
            set;
            get;
        }
        /// <summary>
        /// 身份认证是否成功
        /// </summary>
        [DataMember]
        public bool IdentitySuccess
        {
            set;
            get;
        }
        /// <summary>
        /// 手机运营商授权是否成功
        /// </summary>
        [DataMember]
        public bool MobileOperatorSuccess
        {
            set;
            get;
        }
        /// <summary>
        /// 支付宝授权是否成功
        /// </summary>
        [DataMember]
        public bool AlipaySuccess
        {
            set;
            get;
        }
        /// <summary>
        /// 淘宝授权是否成功
        /// </summary>
        [DataMember]
        public bool TaobaoSuccess
        {
            set;
            get;
        }
        /// <summary>
        /// 京东授权是否成功
        /// </summary>
        [DataMember]
        public bool JdSuccess
        {
            set;
            get;
        }
        /// <summary>
        /// 人行征信授权是否成功
        /// </summary>
        [DataMember]
        public bool PbocSuccess
        {
            set;
            get;
        }
        /// <summary>
        /// 社保授权是否成功
        /// </summary>
        [DataMember]
        public bool RbjSuccess
        {
            set;
            get;
        }
        /// <summary>
        /// 公积金授权是否成功
        /// </summary>
        [DataMember]
        public bool GjjSuccess
        {
            set;
            get;
        }
        /// <summary>
        /// 学信网授权是否成功
        /// </summary>
        [DataMember]
        public bool ChsiSuccess
        {
            set;
            get;
        }
        /// <summary>
        /// 邮箱授权是否成功
        /// </summary>
        [DataMember]
        public bool EmailSuccess
        {
            set;
            get;
        }
        /// <summary>
        /// 其他授权是否成功
        /// </summary>
        [DataMember]
        public bool OtherSuccess
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
        /// 接入标志
        /// </summary>
        [DataMember]
        public bool Mark
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
        #endregion BasicModel

        #region ExtensionModel

        #endregion
    }
}

