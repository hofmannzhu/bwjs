using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XBWNInterface.Model
{
   public class newxbwn_Request
    {
        #region BasicModel
        /// <summary>
        /// 常规参数
        /// </summary>
        [DataMember]
        public header header { get; set; } 
        /// <summary>
        /// 业务参数
        /// </summary>
        [DataMember]
        public Object data { get; set; }

        /// <summary>
        /// 业务参数
        /// </summary>
        [DataMember]
        public Object device { get; set; }

        #endregion
    }
}
