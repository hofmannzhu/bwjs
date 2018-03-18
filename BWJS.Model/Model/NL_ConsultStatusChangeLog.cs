using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 网贷申请状态变更日志
    /// </summary>
    [Serializable]
    public partial class NL_ConsultStatusChangeLog
    {
        #region BasicModel
        /// <summary>
        /// 网贷申请状态变更日志编号
        /// </summary>
        [DataMember]
        public int Id
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
        /// 业务类型1网贷2保险3信用卡
        /// </summary>
        [DataMember]
        public int BusinessType
        {
            set;
            get;
        }
        /// <summary>
        /// 当前状态
        /// </summary>
        [DataMember]
        public int Status
        {
            set;
            get;
        }
        /// <summary>
        /// 上一步状态
        /// </summary>
        [DataMember]
        public int? PrevStatus
        {
            set;
            get;
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        [DataMember]
        public DateTime CreateDate
        {
            set;
            get;
        }
        #endregion BasicModel

        #region ExtensionModel

        #endregion
    }
}

