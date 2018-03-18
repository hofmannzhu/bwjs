using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XBWNInterface.Model
{
    #region 一级参数Response
    /// <summary>
    /// 信博维诺响应类
    /// </summary>
    [Serializable]
    public partial class xbwn_Response
    {
        #region BasicModel
        /// <summary>
        /// 返回数据
        /// </summary>
        [DataMember]
        public Object data
        {
            set;
            get;
        }
        /// <summary>
        /// 执行是否成功
        /// </summary>
        [DataMember]
        public bool success
        {
            set;
            get;
        }
        /// <summary>
        /// 返回的错误编码
        /// </summary>
        [DataMember]
        public string code
        {
            set;
            get;
        }
        /// <summary>
        /// 返回的错误信息
        /// </summary>
        [DataMember]
        public string message
        {
            set;
            get;
        }
        /// <summary>
        /// 接入标志成功true失败false
        /// </summary>
        [DataMember]
        public bool mark
        {
            set;
            get;
        }
        /// <summary>
        /// 返回的时间戳
        /// </summary>
        [DataMember]
        public long timestamp
        {
            set;
            get;
        }
        #endregion BasicModel
    } 
    #endregion
}
