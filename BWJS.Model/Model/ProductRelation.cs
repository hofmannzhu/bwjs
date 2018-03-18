using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{

    /// <summary>
    /// 产品分类映射
    /// </summary>
    [Serializable]
    public partial class ProductRelation
    {
        /// <summary>
        /// 产品分类映射表
        /// </summary>		
        [DataMember]
        public int ProductRelationId
        {
            get;
            set;
        }
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
        /// 产品编号
        /// </summary>		
        [DataMember]
        public int ProductId
        {
            get;
            set;
        }
    }
}
