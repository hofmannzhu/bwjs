using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Mofang.Model
{
	/// <summary>
	/// 被投保人信息表
    /// </summary>	
    [Serializable]
	public partial class InsurantInfo
	{
   		     
      	/// <summary>
		/// 自动编号
        /// </summary>	
        public int InsurantInfoID { get; set;}
        
		/// <summary>
		/// OrderApplyID
        /// </summary>	
        public int OrderApplyID { get; set;}
        
		/// <summary>
		/// 被投保人姓名
        /// </summary>	
        public string CName { get; set;}
        
		/// <summary>
		/// 被投保人姓名拼音，境外旅游险必填
        /// </summary>	
        public string EName { get; set;}
        
		/// <summary>
		/// 1男 0女
        /// </summary>	
        public int Sex { get; set;}
        
		/// <summary>
		/// 被保险人证件类型
        /// </summary>	
        public int CardType { get; set;}
        
		/// <summary>
		/// 被保险人证件号
        /// </summary>	
        public string CardCode { get; set;}
        
		/// <summary>
		/// 被保险人出生日期 格式：yyyy-mm-dd
        /// </summary>	
        public string Birthday { get; set;}
        
		/// <summary>
		/// 与投保人关系
        /// </summary>	
        public int RelationID { get; set;}
        
		/// <summary>
		/// 被保险人购买份数(不能超过最高购买份数)
        /// </summary>	
        public int Count { get; set;}
        
		/// <summary>
		/// 产品结算价(单位:元)
        /// </summary>	
        public decimal SinglePrice { get; set;}
        
		/// <summary>
		/// 证件有效期
        /// </summary>	
        public string CardPeriod { get; set;}
        
		/// <summary>
		/// 手机号
        /// </summary>	
        public string Mobile { get; set;}
        
		/// <summary>
		/// CreatUserID
        /// </summary>	
        public int CreatUserID { get; set;}
        
		/// <summary>
		/// RecordUpdateUserID
        /// </summary>	
        public int RecordUpdateUserID { get; set;}
        
		/// <summary>
		/// RecordIsDelete
        /// </summary>	
        public bool RecordIsDelete { get; set;}
        
		/// <summary>
		/// RecordUpdateTime
        /// </summary>	
        public DateTime RecordUpdateTime { get; set;}
        
		/// <summary>
		/// RecordCreateTime
        /// </summary>	
        public DateTime RecordCreateTime { get; set;}
        
	    public string Email { get; set; }
        /// <summary>
        /// 职业信息，职业id使用“-”拼接如：101414-101415-101416
        /// </summary>
        public string Job { get; set; }
    }
}

