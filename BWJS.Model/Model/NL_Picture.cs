using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model{
	    /// <summary>
    /// 图片表
    /// </summary>
	    [Serializable]
	public partial class NL_Picture
	{
        #region BasicModel
        /// <summary>
        /// 图片编号
        /// </summary>
        [DataMember]
        public int PictiureId
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
        /// Base64编码
        /// </summary>
        [DataMember]
        public string Base64Code
        {
            set;
            get;
        }
        /// <summary>
        /// 信博维诺图片编号
        /// </summary>
        [DataMember]
        public string ImgId
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