using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 渠道关系
    /// </summary>
    [Serializable]
    public partial class CompanyRelation
    {
        #region BasicModel
        /// <summary>
        /// 渠道关系编号
        /// </summary>		
        [DataMember]
        public int CompanyRelationId
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
        /// 商家编号
        /// </summary>		
        [DataMember]
        public int? UserId
        {
            get;
            set;
        }
        /// <summary>
        /// 商家部门编号
        /// </summary>		
        [DataMember]
        public int? DepartmentId
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
        /// 二维码地址
        /// </summary>		
        [DataMember]
        public string QRCode
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
        /// <summary>
        /// 业务对接地址
        /// </summary>		
        [DataMember]
        public string API
        {
            get;
            set;
        }
        
        #endregion
    }
}
