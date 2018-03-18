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
    public partial class NLLoanConfig
    {
        #region Model

        /// <summary>
        /// 编号
        /// </summary>		
        [DataMember]
        public int ID
        {
            get;
            set;
        }

    
        
        /// <summary>
        /// 0:系统
        /// </summary>		
        [DataMember]
        public string KeyValue
        {
            get;
            set;
        }
        [DataMember]
        public int OrderNum
        {
            get;
            set;
        }
        

        [DataMember]
        public string KeyDesc
        {
            get;
            set;
        }
        [DataMember]
        public string TypeName
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
        /// 创建用户编号
        /// </summary>		
        [DataMember]
        public int CreateId
        {
            get;
            set;
        }
        /// <summary>
        /// 记录修改用户编号
        /// </summary>		
        [DataMember]
        public int EditId
        {
            get;
            set;
        }
        /// <summary>
        /// 记录是否删除
        /// </summary>		
        [DataMember]
        public int IsDeleted
        {
            get;
            set;
        }
        /// <summary>
        /// 记录修改时间
        /// </summary>		
        [DataMember]
        public DateTime EditDate
        {
            get;
            set;
        }
        /// <summary>
        /// 记录创建时间
        /// </summary>		
        [DataMember]
        public DateTime CreateDate
        {
            get;
            set;
        }
        #endregion
    }
}

