using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// SysConfig
    /// </summary>
    [Serializable]
    public partial class SysConfig
    {
        #region Model

        /// <summary>
        /// 编号
        /// </summary>		
        [DataMember]
        public int Id
        {
            get;
            set;
        }
        /// <summary>
        /// 0:系统
        /// </summary>		
        [DataMember]
        public int KeyType
        {
            get;
            set;
        }
        /// <summary>
        /// 名称
        /// </summary>		
        [DataMember]
        public string KeyName
        {
            get;
            set;
        }
        /// <summary>
        /// 值
        /// </summary>		
        [DataMember]
        public string KeyVal
        {
            get;
            set;
        }
        /// <summary>
        /// 描述
        /// </summary>		
        [DataMember]
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 创建用户编号
        /// </summary>		
        [DataMember]
        public int CreatUserID
        {
            get;
            set;
        }
        /// <summary>
        /// 记录修改用户编号
        /// </summary>		
        [DataMember]
        public int RecordUpdateUserID
        {
            get;
            set;
        }
        /// <summary>
        /// 记录是否删除
        /// </summary>		
        [DataMember]
        public bool RecordIsDelete
        {
            get;
            set;
        }
        /// <summary>
        /// 记录修改时间
        /// </summary>		
        [DataMember]
        public DateTime RecordUpdateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 记录创建时间
        /// </summary>		
        [DataMember]
        public DateTime RecordCreateTime
        {
            get;
            set;
        }
        #endregion
    }
}

