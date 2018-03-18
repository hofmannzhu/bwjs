using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace BWJS.Model
{
	/// <summary>
	/// 资源表
    /// </summary>	
    [Serializable]
	public partial class Resource
	{
   		     
      	/// <summary>
		/// 自增编号
        /// </summary>	
        public int ResourceID { get; set;}
        
		/// <summary>
		/// 资源名称
        /// </summary>	
        public string ResourceName { get; set;}
        
		/// <summary>
		/// 原始名称(带后缀)
        /// </summary>	
        public string FileName { get; set;}
        
		/// <summary>
		/// 虚拟路径，外网访问使用 
        /// </summary>	
        public string VirtualPath { get; set;}
        
		/// <summary>
		/// 存储路径，文件的真实路径
        /// </summary>	
        public string FilePath { get; set;}
        
		/// <summary>
		/// 文件后缀
        /// </summary>	
        public string FileSuffix { get; set;}
        
		/// <summary>
		/// MD5
        /// </summary>	
        public string MD5 { get; set;}
        
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

