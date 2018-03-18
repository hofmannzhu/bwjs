using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{

    /// <summary>
    /// 角色权限
    /// </summary>
    [Serializable]
    public partial class RoleFunction
    {
        public RoleFunction() { }

        #region Model

        /// <summary>
        /// 角色权限编号
        /// </summary>		
        [DataMember]
        public int RoleFunctionId
        {
            get;
            set;
        }
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
        /// 功能编号
        /// </summary>		
        [DataMember]
        public int FunctionId
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
        #endregion

    }
}
