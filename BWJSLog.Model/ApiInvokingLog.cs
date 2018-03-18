using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BWJSLog.Model
{
    /// <summary>
    /// 接口调用日志
    /// </summary>
    [Serializable]
    public partial class ApiInvokingLog
    {
        #region BasicModel
        /// <summary>
        /// 接口调用日志编号
        /// </summary>
        [DataMember]
        public int ApiInvokingLogId
        {
            set;
            get;
        }
        /// <summary>
        /// 渠道编号
        /// </summary>
        [DataMember]
        public int CompanyId
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
        /// 类名
        /// </summary>
        [DataMember]
        public string ClassName
        {
            set;
            get;
        }
        /// <summary>
        /// 方法名
        /// </summary>
        [DataMember]
        public string MethodName
        {
            set;
            get;
        }
        /// <summary>
        /// 请求地址
        /// </summary>
        [DataMember]
        public string ApiUrl
        {
            set;
            get;
        }
        /// <summary>
        /// 请求时间
        /// </summary>
        [DataMember]
        public DateTime? RequestDate
        {
            set;
            get;
        }
        /// <summary>
        /// 请求数据
        /// </summary>
        [DataMember]
        public string RequestData
        {
            set;
            get;
        }
        /// <summary>
        /// 响应时间
        /// </summary>
        [DataMember]
        public DateTime? ResponseDate
        {
            set;
            get;
        }
        /// <summary>
        /// 相应数据
        /// </summary>
        [DataMember]
        public string ResponseData
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
        #endregion BasicModel

        #region ExtensionModel

        #endregion
    }
}
