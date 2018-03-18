using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Mofang.Model
{
	/// <summary>
	/// 交易表
    /// </summary>	
    [Serializable]
	public partial class Transactions
	{
   		     
      	/// <summary>
		/// 交易流水号，每次请求不能相同
        /// </summary>	
        public string TransNo { get; set;}
        
		/// <summary>
		/// 自增编号
        /// </summary>	
        public int TransactionID { get; set;}
        
		/// <summary>
		/// 渠道商身份标识，由魔方指定
        /// </summary>	
        public string Customkey { get; set;}
        
		/// <summary>
		/// 承保天数(与起保时间终保时间差一致)
        /// </summary>	
        public string InsurantDateLimit { get; set;}
        
		/// <summary>
		/// 方案代码
        /// </summary>	
        public string CaseCode { get; set;}
        
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
        
		   
	}
}

