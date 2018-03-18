using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BWJSLog.Model
{
    /// <summary>
    /// 操作日志
    /// </summary>
    [Serializable]
    public partial class OperationLog
    {
        #region BasicModel
        /// <summary>
        /// 操作日志编号
        /// </summary>
        [DataMember]
        public int OperationLogId
        {
            set;
            get;
        }
        /// <summary>
        /// 业务类型1网贷2保险3信用卡
        /// </summary>
        [DataMember]
        public int BusinessType
        {
            set;
            get;
        }
        /// <summary>
        /// 关联编号
        /// </summary>
        [DataMember]
        public int? RelationId
        {
            set;
            get;
        }
        /// <summary>
        /// 日志内容
        /// </summary>
        [DataMember]
        public string LogContent
        {
            set;
            get;
        }
        /// <summary>
        /// IP地址
        /// </summary>
        [DataMember]
        public string Ip
        {
            set;
            get;
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember]
        public int UserId
        {
            set;
            get;
        }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [DataMember]
        public string RealName
        {
            set;
            get;
        }
        /// <summary>
        /// 建档时间
        /// </summary>
        [DataMember]
        public DateTime CreateDate
        {
            set;
            get;
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        [DataMember]
        public int? DepartmentId
        {
            set;
            get;
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        [DataMember]
        public string DepartmentName
        {
            set;
            get;
        }
        /// <summary>
        /// 角色编号
        /// </summary>
        [DataMember]
        public int? RoleId
        {
            set;
            get;
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        [DataMember]
        public string RoleName
        {
            set;
            get;
        }
        /// <summary>
        /// 组编号
        /// </summary>
        [DataMember]
        public int? GroupId
        {
            set;
            get;
        }
        /// <summary>
        /// 组名称
        /// </summary>
        [DataMember]
        public string GroupName
        {
            set;
            get;
        }
        #endregion BasicModel
        
        #region ExtensionModel

        #endregion
    }
}
