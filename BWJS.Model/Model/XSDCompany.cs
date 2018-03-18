using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model
{
    [Serializable]
    public class XSDCompany
    {
        #region BasicModel

        /// <summary>
        /// 渠道编号
        /// </summary>		
        [DataMember]
        public int CompanyId
        {
            get;
            set;
        } 
        /// <summary>
        /// 渠道名称
        /// </summary>		
        [DataMember]
        public string CompanyName
        {
            get;
            set;
        }  
        /// <summary>
        /// 手机
        /// </summary>		
        [DataMember]
        public string Mobile
        {
            get;
            set;
        } 
        /// <summary>
        /// Logo
        /// </summary>		
        [DataMember]
        public string Logo
        {
            get;
            set;
        } 
        /// <summary>
        /// 主营业务
        /// </summary>		
        [DataMember]
        public string MainBusiness
        {
            get;
            set;
        } 
        /// <summary>
        /// 推荐码
        /// </summary>		
        [DataMember]
        public string RecommendationCode
        {
            get;
            set;
        }  
        /// <summary>
        /// 排序编号
        /// </summary>		
        [DataMember]
        public int? OrderId
        {
            get;
            set;
        } 
        /// <summary>
        /// 描述Html
        /// </summary>		
        [DataMember]
        public string DescriptionHtml
        {
            get;
            set;
        } 
        #endregion
    }
}
