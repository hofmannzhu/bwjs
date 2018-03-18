using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{

    /// <summary>
    /// 渠道返利
    /// </summary>
    [Serializable]
    public partial class CompanyRebate
    {
        #region BasicModel

        /// <summary>
        /// 渠道返利编号
        /// </summary>		
        [DataMember]
        public int CompanyRebateId
        {
            get;
            set;
        }
        /// <summary>
        /// 渠道编号
        /// </summary>		
        [DataMember]
        public int? CompanyId
        {
            get;
            set;
        }
        /// <summary>
        /// 产品编号Mofang.Products表外键ProductId=0则指渠道本身
        /// </summary>		
        [DataMember]
        public int? ProductId
        {
            get;
            set;
        }
        /// <summary>
        /// 返利代码对应Products表方案代码
        /// </summary>		
        [DataMember]
        public string CaseCode
        {
            get;
            set;
        }
        /// <summary>
        /// 返利名称对应Products表产品名称
        /// </summary>		
        [DataMember]
        public string RebateName
        {
            get;
            set;
        }
        /// <summary>
        /// 渠道返利百分比
        /// </summary>		
        [DataMember]
        public decimal CompanyRebatePer
        {
            get;
            set;
        }
        /// <summary>
        /// 商家返利百分比
        /// </summary>		
        [DataMember]
        public decimal MerchantRebate
        {
            get;
            set;
        }
        /// <summary>
        /// 代理商返利百分比
        /// </summary>		
        [DataMember]
        public decimal AgentRebate
        {
            get;
            set;
        }
        /// <summary>
        /// 总部返利百分比
        /// </summary>		
        [DataMember]
        public decimal HQRebate
        {
            get;
            set;
        }
        /// <summary>
        /// 结算方式1销售额百分比2单笔结算
        /// </summary>		
        [DataMember]
        public int SettlementMethod
        {
            get;
            set;
        }
        /// <summary>
        /// 销售额百分比
        /// </summary>		
        [DataMember]
        public decimal SalesPercentage
        {
            get;
            set;
        }
        /// <summary>
        /// 分润描述
        /// </summary>		
        [DataMember]
        public string ProfitDescription
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
    }
}
