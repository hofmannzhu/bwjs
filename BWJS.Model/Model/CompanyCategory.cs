using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 渠道分类
    /// </summary>
    [Serializable]
    public partial class CompanyCategory
    {
        #region BasicModel

        /// <summary>
        /// 渠道分类编号
        /// </summary>		
        [DataMember]
        public int CompanyCategoryId
        {
            get;
            set;
        }
        /// <summary>
        /// 渠道分类名称
        /// </summary>		
        [DataMember]
        public string CompanyCategoryName
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
        #endregion
    }
}
