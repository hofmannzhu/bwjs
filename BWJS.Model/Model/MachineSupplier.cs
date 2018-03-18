using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 设备供应商
    /// </summary>
    public class MachineSupplier
    {
        #region BasicModel

        /// <summary>
        /// 设备供应商编号
        /// </summary>		
        [DataMember]
        public int MachineSupplierId
        {
            get;
            set;
        }
        /// <summary>
        /// 供应商名称
        /// </summary>		
        [DataMember]
        public string SupplierName
        {
            get;
            set;
        }
        /// <summary>
        /// 负责人
        /// </summary>		
        [DataMember]
        public string Manager
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
        #endregion

        #region ExtensionModel

        #endregion

    }

    /// <summary>
    /// 设备供应商扩展
    /// </summary>
    public class MachineSupplierExt: MachineSupplier
    {
        public string UserName { get; set; }
    }
}
