using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 会员表
    /// </summary>	
    [Serializable]
    public partial class DepartmentInfo
    {
        #region Model

        /// <summary>
        /// 客户ID
        /// </summary>		
        [DataMember]
        public int DepartmentID { get; set; }
        /// <summary>
        /// 客户名
        /// </summary>		
        [DataMember]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 是否业务部
        /// </summary>		
        [DataMember]
        public bool IsReceiveBusiness { get; set; }
        /// <summary>
        /// 父级
        /// </summary>		
        [DataMember]
        public int ParentID { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>		
        [DataMember]
        public string DepartmentCode { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        [DataMember]
        public string Remark { get; set; }
     
        /// <summary>
        /// CreatUserID
        /// </summary>		
        [DataMember]
        public int CreatedUser
        {
            get;
            set;
        }

        /// <summary>
        /// CreatUserID
        /// </summary>		
        [DataMember]
        public int UpdateUser
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
        /// RecordCreateTime
        /// </summary>		
        [Column(TypeName = "datetime2")]
        public DateTime RecordCreateTime { get; set; }
        /// <summary>
        /// RecordUpdateTime
        /// </summary>		
        [DataMember]
        public DateTime RecordUpdateTime
        {
            get;
            set;
        }
      
      
        #endregion
    }
}

