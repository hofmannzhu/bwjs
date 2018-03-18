using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mofang.Model
{
    /// <summary>
    /// 其它信息表
    /// </summary>	
    [Serializable]
    public partial class OtherInfo
    {

        /// <summary>
        /// 自增列
        /// </summary>	
        public int OtherInfoID { get; set; }
        /// <summary>
        /// 承保编号
        /// </summary>	
        public int OrderApplyID { get; set; }
        /// <summary>
        /// 投保人居住省市格式：510000-511800-511821
        /// </summary>	
        public string ProvCityID { get; set; }

        /// <summary>
        /// 证件有效期，格式：yyyy-MM-dd（疾病险）
        /// </summary>	
        public DateTime CardPeriod { get; set; }

        /// <summary>
        /// 健康告知ID（疾病险）
        /// </summary>	
        public int NotifyAnswerID { get; set; }

        /// <summary>
        /// 产品试算信息ID
        /// </summary>	
        public string PriceArgsID { get; set; }

        /// <summary>
        /// CreatUserID
        /// </summary>	
        public int CreatUserID { get; set; }

        /// <summary>
        /// RecordUpdateUserID
        /// </summary>	
        public int RecordUpdateUserID { get; set; }

        /// <summary>
        /// RecordIsDelete
        /// </summary>	
        public bool RecordIsDelete { get; set; }

        /// <summary>
        /// RecordUpdateTime
        /// </summary>	
        public DateTime RecordUpdateTime { get; set; }

        /// <summary>
        /// RecordCreateTime
        /// </summary>	
        public DateTime RecordCreateTime { get; set; }
        public string VisaCity { get; set; }
        public string Destination { get; set; }
        public int TripPurposeId { get; set; }
        public string PropertyAddress { get; set; }
        public int RelatedPersonHouse { get; set; }

    }
}
