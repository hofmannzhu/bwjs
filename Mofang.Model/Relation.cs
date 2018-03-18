using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Mofang.Model
{
	/// <summary>
	/// 投保人与被投保人关系表
    /// </summary>	
    [Serializable]
	public partial class Relation
	{
   		     
      	/// <summary>
		/// 自增编号
        /// </summary>	
        public int ID { get; set;}
        
		/// <summary>
		/// 值
        /// </summary>	
        public int Value { get; set;}
        
		/// <summary>
		/// 关系名称
        /// </summary>	
        public string Name { get; set;}
        
		/// <summary>
		/// 1:可用0:不可用
        /// </summary>	
        public int Status { get; set;}
        
		/// <summary>
		/// 排序
        /// </summary>	
        public int Sort { get; set;}
        
		   
	}
}

