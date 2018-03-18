using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Mofang.Model
{
	/// <summary>
	/// 订单信息
    /// </summary>	
    [Serializable]
	public partial class ApplicationData
	{
   		     
      	/// <summary>
		/// 自增编号
        /// </summary>	
        public int AppDataID { get; set;}
        
		/// <summary>
		/// 承保编号
        /// </summary>	
        public int OrderApplyID { get; set;}
        
		/// <summary>
		/// 投保时间格式：yyyy-MM-dd hh:mm:ss
        /// </summary>	
        public string ApplicationDate { get; set;}
        
		/// <summary>
		/// 投保时间 格式:yyyy-MM-dd hh:mm:ss
        /// </summary>	
        public string StartDate { get; set;}
        
		/// <summary>
		/// 终保时间 格式:yyyy-MM-dd
        /// </summary>	
        public string EndDate { get; set;}
        
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
		/// RecordCreateTime
        /// </summary>	
        public DateTime RecordCreateTime { get; set;}
        
		/// <summary>
		/// RecordUpdateTime
        /// </summary>	
        public DateTime RecordUpdateTime { get; set;}
        
		   
	}
}

