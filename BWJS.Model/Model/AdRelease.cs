using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 广告发布表
    /// </summary>
    [Serializable]
    public partial class AdRelease
    {
        #region Model

        /// <summary>
        /// 自增编号
        /// </summary>		
        [DataMember]
        public int AdReleaseID
        {
            get;
            set;
        }
        /// <summary>
        /// 广告名称
        /// </summary>
        public string AdReleaseName
        {
            get;
            set;
        }
        /// <summary>
        /// 广告开始时间
        /// </summary>		
        [DataMember]
        public DateTime BeginTime
        {
            get;
            set;
        }
        /// <summary>
        /// 广告结束时间
        /// </summary>		
        [DataMember]
        public DateTime EndTime
        {
            get;
            set;
        }
        /// <summary>
        /// 资源编号
        /// </summary>		
        [DataMember]
        public int ResourceID
        {
            get;
            set;
        }
        /// <summary>
        /// CreatUserID
        /// </summary>		
        [DataMember]
        public int CreatUserID
        {
            get;
            set;
        }
        /// <summary>
        /// RecordUpdateUserID
        /// </summary>		
        [DataMember]
        public int RecordUpdateUserID
        {
            get;
            set;
        }
        /// <summary>
        /// RecordIsDelete
        /// </summary>		
        [DataMember]
        public bool RecordIsDelete
        {
            get;
            set;
        }
        /// <summary>
        /// RecordUpdateTime
        /// </summary>		
        [DataMember]
        public DateTime RecordUpdateTime
        {
            get;
            set;
        }
        /// <summary>
        /// RecordCreateTime
        /// </summary>		
        [DataMember]
        public DateTime RecordCreateTime
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
        #endregion

    }

    /// <summary>
    /// 广告发布表
    /// </summary>
    public partial class AdReleaseExpand : AdRelease
    {
        #region Model
        /// <summary>
        /// 广告位编号
        /// </summary>		
        [DataMember]
        public int PositionId
        {
            get;
            set;
        }

        /// <summary>
        ///  广告位名称
        /// </summary>		
        [DataMember]
        public string PositionName
        {
            get;
            set;
        }
        #endregion
    }

}

