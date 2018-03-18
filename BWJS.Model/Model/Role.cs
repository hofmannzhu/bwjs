using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{

    /// <summary>
    /// 角色
    /// </summary>
    [Serializable]
    public partial class Role
    {
        public Role() { }

        #region Model

        /// <summary>
        /// 角色编号
        /// </summary>		
        [DataMember]
        public int RoleId
        {
            get;
            set;
        }
        /// <summary>
        /// 角色名称
        /// </summary>		
        [DataMember]
        public string RoleName
        {
            get;
            set;
        }
        /// <summary>
        /// 角色类型
        /// </summary>		
        [DataMember]
        public int RoleType
        {
            get;
            set;
        }
        /// <summary>
        /// 状态0无效1有效
        /// </summary>		
        [DataMember]
        public int RoleStatus
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
        /// 是否管理岗位
        /// </summary>		
        [DataMember]
        public bool IsManager
        {
            get;
            set;
        }
        /// <summary>
        /// 父ID
        /// </summary>		
        [DataMember]
        public int ParentId
        {
            get;
            set;
        }

        
        #endregion
    }
}
