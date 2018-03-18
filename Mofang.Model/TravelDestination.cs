using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Mofang.Model
{
    /// <summary>
    /// 出行目的地
    /// </summary>
    [Serializable]
    public partial class TravelDestination
    {
        public TravelDestination() { }

        /// <summary>
        /// Id
        /// </summary>		
        [DataMember]
        public int Id
        {
            get;
            set;
        }
        /// <summary>
        /// 值
        /// </summary>		
        [DataMember]
        public int Value
        {
            get;
            set;
        }
        /// <summary>
        /// 关系名称
        /// </summary>		
        [DataMember]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 1:可用0:不可用
        /// </summary>		
        [DataMember]
        public int Status
        {
            get;
            set;
        }
        /// <summary>
        /// 排序
        /// </summary>		
        [DataMember]
        public int Sort
        {
            get;
            set;
        }
    }
}
