using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
	/// <summary>
	/// 广告位表
    /// </summary>	
    [Serializable]
	public partial class AdPosition
    {
        #region BasicModel
        /// <summary>
        /// 广告位编号
        /// </summary>
        [DataMember]
        public int AdPositionID
        {
            set;
            get;
        }
        /// <summary>
        /// 广告位名称
        /// </summary>
        [DataMember]
        public string Name
        {
            set;
            get;
        }
        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public int? Sort
        {
            set;
            get;
        }
        /// <summary>
        /// 广告位图片地址
        /// </summary>
        [DataMember]
        public string DefaultPicUrl
        {
            set;
            get;
        }
        /// <summary>
        /// 广告类型1PC广告2Pad广告
        /// </summary>
        [DataMember]
        public int? TypeId
        {
            set;
            get;
        }
        /// <summary>
        /// 广告表编号
        /// </summary>
        [DataMember]
        public int? AdReleaseID
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int? CreatUserID
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int? RecordUpdateUserID
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool RecordIsDelete
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime RecordUpdateTime
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime RecordCreateTime
        {
            set;
            get;
        }
        #endregion BasicModel

        #region ExtensionModel

        #endregion
    }
}

