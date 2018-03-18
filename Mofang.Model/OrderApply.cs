using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace Mofang.Model
{
	/// <summary>
	/// 承包申请表
    /// </summary>	
    [Serializable]
	public partial class OrderApply
	{
        #region BasicModel

        /// <summary>
        /// 承包自增编号
        /// </summary>		
        [DataMember]
        public int OrderApplyID
        {
            get;
            set;
        }
        /// <summary>
        /// 设备编号
        /// </summary>		
        [DataMember]
        public int MachineID
        {
            get;
            set;
        }
        /// <summary>
        /// 用户编号
        /// </summary>		
        [DataMember]
        public int UserID
        {
            get;
            set;
        }
        /// <summary>
        /// 部门编号
        /// </summary>		
        [DataMember]
        public int? DepartmentId
        {
            get;
            set;
        }
        /// <summary>
        /// 投保单号(只会为一个投保单号)
        /// </summary>		
        [DataMember]
        public string InsureNum
        {
            get;
            set;
        }
        /// <summary>
        /// 投保价格
        /// </summary>		
        [DataMember]
        public string Price
        {
            get;
            set;
        }
        /// <summary>
        /// 返回信息Success为成功,其它为错误信息
        /// </summary>		
        [DataMember]
        public string Respmsg
        {
            get;
            set;
        }
        /// <summary>
        /// 0000代表Success I0001自定义错误
        /// </summary>		
        [DataMember]
        public string Respstat
        {
            get;
            set;
        }
        /// <summary>
        /// Status
        /// </summary>		
        [DataMember]
        public int Status
        {
            get;
            set;
        }
        /// <summary>
        /// 创建人编号
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
        /// 0正常 1删除
        /// </summary>		
        [DataMember]
        public bool RecordIsDelete
        {
            get;
            set;
        }
        /// <summary>
        /// 最后更新时间
        /// </summary>		
        [DataMember]
        public DateTime RecordUpdateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
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

