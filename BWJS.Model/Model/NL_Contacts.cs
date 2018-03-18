using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model{
	    /// <summary>
    /// 联系人信息
    /// </summary>
	    [Serializable]
	public partial class NL_Contacts
    {
        #region BasicModel
        /// <summary>
        /// 联系人编号
        /// </summary>
        [DataMember]
        public int ContactId
        {
            set;
            get;
        }
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
        /// 关系编号
        /// </summary>
        [DataMember]
        public int? RelationId
        {
            set;
            get;
        }
        /// <summary>
        /// 深度1第一联系人2第二联系人
        /// </summary>
        [DataMember]
        public int? Depth
        {
            set;
            get;
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        [DataMember]
        public int? IsDeleted
        {
            set;
            get;
        }
        /// <summary>
        /// 建档人编号
        /// </summary>
        [DataMember]
        public int? CreateId
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
        /// 修改人编号
        /// </summary>
        [DataMember]
        public int? EditId
        {
            set;
            get;
        }
        /// <summary>
        /// 修改日期
        /// </summary>
        [DataMember]
        public DateTime? EditDate
        {
            set;
            get;
        }
        #endregion BasicModel

        #region ExtensionModel

        #endregion
    }
}

