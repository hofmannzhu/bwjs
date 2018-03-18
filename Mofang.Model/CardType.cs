using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Mofang.Model
{
	/// <summary>
	/// 退保表单
    /// </summary>	
    [Serializable]
	public partial class CardType
	{
   		     
      	/// <summary>
		/// 自增编号
        /// </summary>	
        public int CDID { get; set;}
        
		/// <summary>
		/// 证件类型值
        /// </summary>	
        public int Value { get; set;}
        
		/// <summary>
		/// 证件类型说明
        /// </summary>	
        public string Name { get; set;}
        
		/// <summary>
		/// 排序
        /// </summary>	
        public int Sort { get; set;}
        
		   
	}
}

