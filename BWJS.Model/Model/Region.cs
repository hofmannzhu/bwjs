using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{

    /// <summary>
    /// 区域
    /// </summary>
    [Serializable]
    public partial class Region
    {
        public Region() { }

        #region Model

        /// <summary>
        /// 区域编号
        /// </summary>		
        [DataMember]
        public int RegionId
        {
            get;
            set;
        }
        /// <summary>
        /// 区域名称
        /// </summary>		
        [DataMember]
        public string ReginName
        {
            get;
            set;
        }
        /// <summary>
        /// 区域代码
        /// </summary>		
        [DataMember]
        public string ReginCode
        {
            get;
            set;
        }
        /// <summary>
        /// 父编号
        /// </summary>		
        [DataMember]
        public int ParentId
        {
            get;
            set;
        }
        /// <summary>
        /// 区域路径/分割
        /// </summary>		
        [DataMember]
        public string RegionDir
        {
            get;
            set;
        }
        /// <summary>
        /// 状态0无效1有效
        /// </summary>		
        [DataMember]
        public int RegionStatus
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
        public int EditId
        {
            get;
            set;
        }
        /// <summary>
        /// 修改日期
        /// </summary>		
        [DataMember]
        public DateTime EditDate
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
        /// 备注
        /// </summary>		
        [DataMember]
        public string Remark
        {
            get;
            set;
        }
        #endregion Model
    }
}
