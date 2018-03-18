using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace Mofang.Model
{
	/// <summary>
	/// 终端产品展示表
    /// </summary>	
    [Serializable]
	public partial class Products
	{

        /// <summary>
        /// 产品自增列
        /// </summary>		
        [DataMember]
        public int ProductsID
        {
            get;
            set;
        }
        /// <summary>
        /// 渠道编号BWJS.Sys_Company表外键
        /// </summary>		
        [DataMember]
        public int CompanyId
        {
            get;
            set;
        }
        /// <summary>
        /// 保险公司
        /// </summary>		
        [DataMember]
        public string CompanyName
        {
            get;
            set;
        }
        /// <summary>
        /// 产品类型编号
        /// </summary>		
        [DataMember]
        public int ProductTypeId
        {
            get;
            set;
        }
        /// <summary>
        /// 产品类型名称
        /// </summary>		
        [DataMember]
        public string ProductTypeName
        {
            get;
            set;
        }
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
        /// 产品名称
        /// </summary>		
        [DataMember]
        public string ProductName
        {
            get;
            set;
        }
        /// <summary>
        /// 产品计划
        /// </summary>		
        [DataMember]
        public string ProductPlan
        {
            get;
            set;
        }
        /// <summary>
        /// 方案代码
        /// </summary>		
        [DataMember]
        public string CaseCode
        {
            get;
            set;
        }
        /// <summary>
        /// 承保期限
        /// </summary>		
        [DataMember]
        public string PeriodDate
        {
            get;
            set;
        }
        /// <summary>
        /// 承保年龄
        /// </summary>		
        [DataMember]
        public string PeriodAge
        {
            get;
            set;
        }
        /// <summary>
        /// 投保日期
        /// </summary>		
        [DataMember]
        public string InsuranceDate
        {
            get;
            set;
        }
        /// <summary>
        /// 是否退保 0可以退保 1不可以退保
        /// </summary>		
        [DataMember]
        public string IsQuitInsure
        {
            get;
            set;
        }
        /// <summary>
        /// 证件类型 以逗号隔开
        /// </summary>		
        [DataMember]
        public string CardTypeIDs
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
        /// <summary>
        /// Remark
        /// </summary>		
        [DataMember]
        public string Remark
        {
            get;
            set;
        }

        public string ProducDescribe
        {
            get;
            set;
        }

        
    }
}

