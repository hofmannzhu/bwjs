using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace Mofang.Model
{
    /// <summary>
    /// 产品分类表
    /// </summary>	
    [Serializable]
    public partial class ProductCategory
    {
        /// <summary>
        /// 分类编号
        /// </summary>		
        [DataMember]
        public int ProductCategoryId
        {
            get;
            set;
        }
        /// <summary>
        /// 分类名称
        /// </summary>		
        [DataMember]
        public string CategoryName
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
        /// 父编号
        /// </summary>		
        [DataMember]
        public int ParentId
        {
            get;
            set;
        }

        public string ProductCaPictureUrl
        {
            get;
            set;
        }
        public bool RecordIsDelete
        {
            get;
            set;
        }
        
    }
}

