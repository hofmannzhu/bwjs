using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BWJSLog.Model
{
    /// <summary>
    /// 短信发送日志
    /// </summary>
    [Serializable]
    public partial class SmsSendLog
    {
        #region Model

        /// <summary>
        /// 短信日志编号
        /// </summary>		
        [DataMember]
        public int SmsLogId
        {
            get;
            set;
        }
        /// <summary>
        /// 短信模板编号
        /// </summary>		
        [DataMember]
        public int? SmsTemplateId
        {
            get;
            set;
        }
        /// <summary>
        /// 发送类型1实时发送2延迟发送
        /// </summary>		
        [DataMember]
        public int SendType
        {
            get;
            set;
        }
        /// <summary>
        /// 短信内容
        /// </summary>		
        [DataMember]
        public string SmsContent
        {
            get;
            set;
        }
        /// <summary>
        /// 接收手机号码
        /// </summary>		
        [DataMember]
        public string Mobile
        {
            get;
            set;
        }
        /// <summary>
        /// 状态0未发送1已发送
        /// </summary>		
        [DataMember]
        public int Status
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
        /// 建档日期
        /// </summary>		
        [DataMember]
        public DateTime CreateDate
        {
            get;
            set;
        }
        /// <summary>
        /// 发送日期
        /// </summary>		
        [DataMember]
        public DateTime SendDate
        {
            get;
            set;
        }
        /// <summary>
        /// 发送结果
        /// </summary>		
        [DataMember]
        public string SendResult
        {
            get;
            set;
        }
        #endregion
    }
}
