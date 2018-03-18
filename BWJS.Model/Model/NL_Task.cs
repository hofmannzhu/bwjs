using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model{
	    /// <summary>
    /// 运营商爬取任务
    /// </summary>
	    [Serializable]
	public partial class NL_Task
    {
        #region BasicModel
        /// <summary>
        /// 手机运营商爬取任务编号
        /// </summary>
        [DataMember]
        public int AutoId
        {
            set;
            get;
        }
        /// <summary>
        /// 网贷申请编号
        /// </summary>
        [DataMember]
        public int? ConsultId
        {
            set;
            get;
        }
        /// <summary>
        /// 手机号
        /// </summary>
        [DataMember]
        public string TelNo
        {
            set;
            get;
        }
        /// <summary>
        /// 服务密码
        /// </summary>
        [DataMember]
        public string ServicePwd
        {
            set;
            get;
        }
        /// <summary>
        /// 信博维诺任务编号
        /// </summary>
        [DataMember]
        public string TaskId
        {
            set;
            get;
        }
        /// <summary>
        /// 爬取状态
        /// </summary>
        [DataMember]
        public string State
        {
            set;
            get;
        }
        /// <summary>
        /// 任务状态
        /// </summary>
        [DataMember]
        public string TaskStatus
        {
            set;
            get;
        }
        /// <summary>
        /// 图片验证码
        /// </summary>
        [DataMember]
        public string ImgStr
        {
            set;
            get;
        }
        /// <summary>
        /// 接入标志
        /// </summary>
        [DataMember]
        public bool Mark
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

