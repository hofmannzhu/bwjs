using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model.Model
{
    /// <summary>
    /// 网贷申请扩展类
    /// </summary>
    [Serializable]
    public partial class NL_ConsultExT : NL_Consult
    {
        #region ExtensionModel

        /// <summary>
        /// 性别
        /// </summary>		
        [DataMember]
        public string sex
        {
            get;
            set;
        }
        /// <summary>
        /// 出生年月
        /// </summary>		 
        [DataMember]
        public string birth
        {
            get;
            set;
        }
        /// <summary>
        /// 民族
        /// </summary>		 
        [DataMember]
        public string national
        {
            get;
            set;
        }
        /// <summary>
        /// 住址
        /// </summary>		 
        [DataMember]
        public string address
        {
            get;
            set;
        }
        /// <summary>
        /// 签发机关
        /// </summary>		 
        [DataMember]
        public string authority
        {
            get;
            set;
        }
        /// <summary>
        /// 有效期
        /// </summary>		 
        [DataMember]
        public string validperiod
        {
            get;
            set;
        }
        /// <summary>
        /// 人像图片ID
        /// </summary>		 
        [DataMember]
        public string faceId
        {
            get;
            set;
        }
        /// <summary>
        /// 登录商家Id
        /// </summary>		 
        [DataMember]
        public string magId
        {
            get;
            set;
        }
        #endregion
    }
}
