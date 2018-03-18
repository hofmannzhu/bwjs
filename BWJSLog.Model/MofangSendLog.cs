using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace BWJSLog.Model
{
	/// <summary>
	/// 魔方发送日志表
    /// </summary>	
    [Serializable]
	public partial class MofangSendLog
	{
   		     
      	/// <summary>
		/// 自增编号
        /// </summary>	
        public int MofangSendLogID { get; set;}
        
		/// <summary>
		/// 方法名称
        /// </summary>	
        public string MothodName { get; set;}
        
		/// <summary>
		/// FKID
        /// </summary>	
        public int FKID { get; set;}
        
		/// <summary>
		/// 交易单号
        /// </summary>	
        public string TransNo { get; set;}
        
		/// <summary>
		/// 是否已发送
        /// </summary>	
        public bool IsSend { get; set;}
        
		/// <summary>
		/// 消息
        /// </summary>	
        public string Message { get; set;}
        
		/// <summary>
		/// 发送时间
        /// </summary>	
        public DateTime SendTime { get; set;}
        
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

