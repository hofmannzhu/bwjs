using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace BWJSLog.Model
{
	/// <summary>
	/// 魔方接受日志
    /// </summary>	
    [Serializable]
	public partial class MofangReceivedLog
	{
   		     
      	/// <summary>
		/// 自增编号
        /// </summary>	
        public int MofangReceivedLogID { get; set;}
        
		/// <summary>
		/// 方法名称
        /// </summary>	
        public string MothodName { get; set;}
        
		/// <summary>
		/// TransNo
        /// </summary>	
        public string TransNo { get; set;}
        
		/// <summary>
		/// IsProcessed
        /// </summary>	
        public bool IsProcessed { get; set;}
        
		/// <summary>
		/// Message
        /// </summary>	
        public string Message { get; set;}
        
		/// <summary>
		/// ReceivedTime
        /// </summary>	
        public DateTime ReceivedTime { get; set;}
        
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

