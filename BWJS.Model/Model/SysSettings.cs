using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 系统设置
    /// </summary>
    [Serializable]
    public partial class SysSettings
    {
        #region BasicModel
        /// <summary>
        /// 系统设置编号
        /// </summary>		
        [DataMember]
        public int SysSettingsId
        {
            get;
            set;
        }
        /// <summary>
        /// 公司名称
        /// </summary>		
        [DataMember]
        public string CompnayName
        {
            get;
            set;
        }
        /// <summary>
        /// 服务器IP
        /// </summary>		
        [DataMember]
        public string IP
        {
            get;
            set;
        }
        /// <summary>
        /// 公司域名
        /// </summary>		
        [DataMember]
        public string DomainName
        {
            get;
            set;
        }
        /// <summary>
        /// 公司Logo
        /// </summary>		
        [DataMember]
        public string Logo
        {
            get;
            set;
        }
        /// <summary>
        /// 公司Icon
        /// </summary>		
        [DataMember]
        public string Icon
        {
            get;
            set;
        }
        /// <summary>
        /// 备案号
        /// </summary>		
        [DataMember]
        public string RecordNumber
        {
            get;
            set;
        }
        /// <summary>
        /// 定时器小时数
        /// </summary>		
        [DataMember]
        public int TimerHours
        {
            get;
            set;
        }
        /// <summary>
        /// 定时器分钟数
        /// </summary>		
        [DataMember]
        public int TimerMinutes
        {
            get;
            set;
        }
        /// <summary>
        /// 定时器秒数
        /// </summary>		
        [DataMember]
        public int TimerSeconds
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
        /// 状态0正常1锁定
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

        #endregion

        #region ExtensionModel

        #endregion
    }
}
