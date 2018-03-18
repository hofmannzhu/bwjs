using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 渠道网贷扩展
    /// </summary>
    [Serializable]
    public partial class CompanyNetLoan
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
        /// 最高可贷
        /// </summary>		
        [DataMember]
        public decimal HighestLoan
        {
            get;
            set;
        }
        /// <summary>
        /// 有无担保0无担保1有担保
        /// </summary>		
        [DataMember]
        public int IsHaveGuarantee
        {
            get;
            set;
        }
        /// <summary>
        /// 有无抵押0无抵押1有抵押
        /// </summary>		
        [DataMember]
        public int IsMortgage
        {
            get;
            set;
        }
        /// <summary>
        /// 最高月利息
        /// </summary>		
        [DataMember]
        public decimal MaxMonthlyInterest
        {
            get;
            set;
        }
        /// <summary>
        /// 放款时效小时
        /// </summary>		
        [DataMember]
        public int LoanPrescription
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
