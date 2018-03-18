using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{

    /// <summary>
    /// 分类表
    /// </summary>
    [Serializable]
    public partial class GlobalClass
    {
        public GlobalClass() { }

        #region Model

        /// <summary>
        /// 分类编号
        /// </summary>		
        [DataMember]
        public int ClassId
        {
            get;
            set;
        }
        /// <summary>
        /// 频道编号
        /// </summary>		
        [DataMember]
        public int ChannelId
        {
            get;
            set;
        }
        /// <summary>
        /// 分类名称
        /// </summary>		
        [DataMember]
        public string ClassName
        {
            get;
            set;
        }
        /// <summary>
        /// 分类代码
        /// </summary>		
        [DataMember]
        public string ClassCode
        {
            get;
            set;
        }
        /// <summary>
        /// 分类图标
        /// </summary>		
        [DataMember]
        public string ClassIcon
        {
            get;
            set;
        }
        /// <summary>
        /// 父编号
        /// </summary>		
        [DataMember]
        public int ParentId
        {
            get;
            set;
        }
        /// <summary>
        /// 打开方式
        /// </summary>		
        [DataMember]
        public string OpenType
        {
            get;
            set;
        }
        /// <summary>
        /// 排序编号
        /// </summary>		
        [DataMember]
        public int OrderId
        {
            get;
            set;
        }
        /// <summary>
        /// 分类路径/分割
        /// </summary>		
        [DataMember]
        public string ClassPath
        {
            get;
            set;
        }
        /// <summary>
        /// 状态0无效1有效
        /// </summary>		
        [DataMember]
        public int Status
        {
            get;
            set;
        }
        /// <summary>
        /// 外部链接地址
        /// </summary>		
        [DataMember]
        public string ExternalLinkAddress
        {
            get;
            set;
        }
        /// <summary>
        /// 分类说明
        /// </summary>		
        [DataMember]
        public string Remark
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
    }
}
