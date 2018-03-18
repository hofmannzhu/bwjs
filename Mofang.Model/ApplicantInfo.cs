using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Mofang.Model
{
	/// <summary>
	/// 投保人信息
    /// </summary>	
    [Serializable]
	public partial class ApplicantInfo
	{
   		     
      	/// <summary>
		/// 自动编号
        /// </summary>	
        public int ApplicantInfoID { get; set;}
        
		/// <summary>
		/// 承保编号
        /// </summary>	
        public int OrderApplyID { get; set;}
        
		/// <summary>
		/// 投保人姓名
        /// </summary>	
        public string CName { get; set;}
        
		/// <summary>
		/// 投保人姓名拼音，境外旅游险必填
        /// </summary>	
        public string EName { get; set;}
        
		/// <summary>
		/// 投保人证件类型
        /// </summary>	
        public int CardType { get; set;}
        
		/// <summary>
		/// 投保人证件号
        /// </summary>	
        public string CardCode { get; set;}
        
		/// <summary>
		/// 投保人性别 1男0女
        /// </summary>	
        public int Sex { get; set;}
        
		/// <summary>
		/// 投保人出生日期 格式:yyyy-mm-dd
        /// </summary>	
        public string BirthDay { get; set;}
        
		/// <summary>
		/// 投保人移动电话
        /// </summary>	
        public string Mobile { get; set;}
        
		/// <summary>
		/// 投保人邮箱
        /// </summary>	
        public string Email { get; set;}
        
		/// <summary>
		/// CardPeriod
        /// </summary>	
        public string CardPeriod { get; set;}
        
		/// <summary>
		/// CreatUserID
        /// </summary>	
        public int CreatUserID { get; set;}
        
		/// <summary>
		/// RecordUpdateUserID
        /// </summary>	
        public int RecordUpdateUserID { get; set;}
        
		/// <summary>
		/// RecordUpdateTime
        /// </summary>	
        public DateTime RecordUpdateTime { get; set;}
        
		/// <summary>
		/// RecordIsDelete
        /// </summary>	
        public bool RecordIsDelete { get; set;}
        
		/// <summary>
		/// RecordCreateTime
        /// </summary>	
        public DateTime RecordCreateTime { get; set;}
        /// <summary>
        /// 职业信息，职业id使用“-”拼接如：101414-101415-101416
        /// </summary>
        public string Job { get; set; }

    }
}

