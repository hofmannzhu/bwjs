using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{

    /// <summary>
    /// 渠道
    /// </summary>
    [Serializable]
    public partial class Company
    {
        #region BasicModel

        /// <summary>
        /// 渠道编号
        /// </summary>		
        [DataMember]
        public int CompanyId
        {
            get;
            set;
        }
        /// <summary>
        /// 渠道分类编号
        /// </summary>		
        [DataMember]
        public int? CompanyCategoryId
        {
            get;
            set;
        }
        /// <summary>
        /// 渠道名称
        /// </summary>		
        [DataMember]
        public string CompanyName
        {
            get;
            set;
        }
        /// <summary>
        /// 负责人
        /// </summary>		
        [DataMember]
        public string CompanyManager
        {
            get;
            set;
        }
        /// <summary>
        /// 电话
        /// </summary>		
        [DataMember]
        public string Phone
        {
            get;
            set;
        }
        /// <summary>
        /// 手机
        /// </summary>		
        [DataMember]
        public string Mobile
        {
            get;
            set;
        }
        /// <summary>
        /// 地址
        /// </summary>		
        [DataMember]
        public string Address
        {
            get;
            set;
        }
        /// <summary>
        /// QQ
        /// </summary>		
        [DataMember]
        public string QQ
        {
            get;
            set;
        }
        /// <summary>
        /// 主页
        /// </summary>		
        [DataMember]
        public string SiteUrl
        {
            get;
            set;
        }
        /// <summary>
        /// Logo
        /// </summary>		
        [DataMember]
        public string Logo
        {
            get;
            set;
        }
        /// <summary>
        /// 业务对接地址
        /// </summary>		
        [DataMember]
        public string API
        {
            get;
            set;
        }
        /// <summary>
        /// 二维码地址
        /// </summary>		
        [DataMember]
        public string QRCode
        {
            get;
            set;
        }
        /// <summary>
        /// 主要品牌
        /// </summary>		
        [DataMember]
        public string MainBrand
        {
            get;
            set;
        }
        /// <summary>
        /// 主营业务
        /// </summary>		
        [DataMember]
        public string MainBusiness
        {
            get;
            set;
        }
        /// <summary>
        /// 是否显示推荐码
        /// </summary>		
        [DataMember]
        public int IsDisplay
        {
            get;
            set;
        }
        /// <summary>
        /// 是否依赖主键
        /// </summary>		
        [DataMember]
        public int IsRelyOnPrimaryKey
        {
            get;
            set;
        }
        /// <summary>
        /// 推荐码前缀
        /// </summary>		
        [DataMember]
        public string RecommendationPrefix
        {
            get;
            set;
        }
        /// <summary>
        /// 推荐码长度几位数
        /// </summary>		
        [DataMember]
        public int RecommendationLength
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
        /// 微信号
        /// </summary>		
        [DataMember]
        public string Wechat
        {
            get;
            set;
        }
        /// <summary>
        /// 公众号
        /// </summary>		
        [DataMember]
        public string PublicWechat
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
        /// 状态0正常1锁定
        /// </summary>		
        [DataMember]
        public int Status
        {
            get;
            set;
        }
        /// <summary>
        /// 排序编号
        /// </summary>		
        [DataMember]
        public int? OrderId
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
        /// 建档人编号
        /// </summary>		
        [DataMember]
        public int CreateId
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
        /// 修改人编号
        /// </summary>		
        [DataMember]
        public int? EditId
        {
            get;
            set;
        }
        /// <summary>
        /// 修改日期
        /// </summary>		
        [DataMember]
        public DateTime? EditDate
        {
            get;
            set;
        }
        /// <summary>
        /// 是否是apk形式
        /// </summary>		
        [DataMember]
        public bool IsAPK
        {
            get;
            set;
        }
        /// <summary>
        /// 安卓app路径
        /// </summary>		
        [DataMember]
        public string AndroidURL
        {
            get;
            set;
        }
        /// <summary>
        /// 苹果app路径
        /// </summary>		
        [DataMember]
        public string IosURL
        {
            get;
            set;
        }
        /// <summary>
        /// 对接方式0手持设备1pc
        /// </summary>		
        [DataMember]
        public int DockingMode
        {
            get;
            set;
        }
        /// <summary>
        /// 描述Html
        /// </summary>		
        [DataMember]
        public string DescriptionHtml
        {
            get;
            set;
        } 
        /// <summary>
        /// 审核条件
        /// </summary>
        [DataMember]
        public string AuditConditions
        {
            get;
            set;
        } 
        #endregion


        #region ExtensionModel 
        #endregion
    }
}
