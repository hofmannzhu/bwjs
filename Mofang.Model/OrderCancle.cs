using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace Mofang.Model
{
	/// <summary>
	/// 退保表
    /// </summary>	
    [Serializable]
	public partial class OrderCancle
	{

        /// <summary>
        /// 自增编号
        /// </summary>		
        [DataMember]
        public int OrderCancleID
        {
            get;
            set;
        }
        /// <summary>
        /// InsureNum
        /// </summary>		
        [DataMember]
        public string InsureNum
        {
            get;
            set;
        }
        /// <summary>
        /// 退保信息码0000 代表退保申请已提交(一般代表退保成功)
        /// </summary>		
        [DataMember]
        public string RespCode
        {
            get;
            set;
        }
        /// <summary>
        /// TransNo
        /// </summary>		
        [DataMember]
        public string TransNo
        {
            get;
            set;
        }
        /// <summary>
        /// 退保详细信息
        /// </summary>		
        [DataMember]
        public string RespMsg
        {
            get;
            set;
        }
        /// <summary>
        /// 承保申请编号
        /// </summary>		
        [DataMember]
        public int OrderApplyID
        {
            get;
            set;
        }
        /// <summary>
        /// OrderRebateId
        /// </summary>		
        [DataMember]
        public int OrderRebateId
        {
            get;
            set;
        }
        /// <summary>
        /// CreatUserID
        /// </summary>		
        [DataMember]
        public int CreatUserID
        {
            get;
            set;
        }
        /// <summary>
        /// RecordUpdateUserID
        /// </summary>		
        [DataMember]
        public int RecordUpdateUserID
        {
            get;
            set;
        }
        /// <summary>
        /// RecordIsDelete
        /// </summary>		
        [DataMember]
        public bool RecordIsDelete
        {
            get;
            set;
        }
        /// <summary>
        /// RecordUpdateTime
        /// </summary>		
        [DataMember]
        public DateTime RecordUpdateTime
        {
            get;
            set;
        }
        /// <summary>
        /// RecordCreateTime
        /// </summary>		
        [DataMember]
        public DateTime RecordCreateTime
        {
            get;
            set;
        }



    }
}

