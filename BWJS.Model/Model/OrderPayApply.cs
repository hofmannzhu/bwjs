using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{

    /// <summary>
    /// 订单支付
    /// </summary>
    [Serializable]
    public partial class OrderPayApply
    {
        public OrderPayApply() { }

        #region Model

        /// <summary>
        /// 支付申请编号
        /// </summary>		
        [DataMember]
        public int OrderPayApplyId
        {
            get;
            set;
        }
        /// <summary>
        /// 订单返利编号OrderRebate外键
        /// </summary>		
        [DataMember]
        public int OrderRebateId
        {
            get;
            set;
        }
        /// <summary>
        /// 订单金额
        /// </summary>		
        [DataMember]
        public decimal OrderMoney
        {
            get;
            set;
        }
        /// <summary>
        /// 支付单号码（支付系统唯一标识)
        /// </summary>		
        [DataMember]
        public string PayOrderNumber
        {
            get;
            set;
        }
        /// <summary>
        /// 支付状态0未支付1已支付2支付失败
        /// </summary>		
        [DataMember]
        public int PayStatus
        {
            get;
            set;
        }
        /// <summary>
        /// 支付平台
        /// </summary>		
        [DataMember]
        public int PayPlatform
        {
            get;
            set;
        }
        /// <summary>
        /// 支付方式
        /// </summary>		
        [DataMember]
        public int PayMethod
        {
            get;
            set;
        }
        /// <summary>
        /// 支付返回码
        /// </summary>		
        [DataMember]
        public string PayCode
        {
            get;
            set;
        }
        /// <summary>
        /// 支付返回描述
        /// </summary>		
        [DataMember]
        public string PayText
        {
            get;
            set;
        }
        /// <summary>
        /// 支付返回JSON
        /// </summary>		
        [DataMember]
        public string PayJson
        {
            get;
            set;
        }
        /// <summary>
        /// 建档日期
        /// </summary>		
        [DataMember]
        public DateTime CreateDate
        {
            get;
            set;
        }
        /// <summary>
        /// 支付成功日期
        /// </summary>		
        [DataMember]
        public DateTime? PayDate
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>		
        [DataMember]
        public string Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 是否删除
        /// </summary>		
        [DataMember]
        public int IsDeleted
        {
            get;
            set;
        }
        #endregion Model
    }
}
