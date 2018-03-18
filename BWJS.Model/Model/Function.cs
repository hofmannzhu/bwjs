using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 功能菜单
    /// </summary>
    public partial class Function
    {
        public Function() { }

        #region Model

        /// <summary>
        /// 功能编号
        /// </summary>		
        [DataMember]
        public int FunctionId
        {
            get;
            set;
        }
        /// <summary>
        /// 功能名称
        /// </summary>		
        [DataMember]
        public string FunctionName
        {
            get;
            set;
        }
        /// <summary>
        /// 功能代码
        /// </summary>		
        [DataMember]
        public string FunctionCode
        {
            get;
            set;
        }
        /// <summary>
        /// 功能图标
        /// </summary>		
        [DataMember]
        public string FunctionIcon
        {
            get;
            set;
        }
        /// <summary>
        /// 功能样式名
        /// </summary>		
        [DataMember]
        public string FunctionClass
        {
            get;
            set;
        }
        /// <summary>
        /// 功能类别
        /// </summary>		
        [DataMember]
        public int ClassId
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
        /// 外部链接地址
        /// </summary>		
        [DataMember]
        public string ExternalLinkAddress
        {
            get;
            set;
        }
        /// <summary>
        /// 功能路径/分割
        /// </summary>		
        [DataMember]
        public string FunctionDir
        {
            get;
            set;
        }
        /// <summary>
        /// 状态1有效0失效
        /// </summary>		
        [DataMember]
        public int Status
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
}
