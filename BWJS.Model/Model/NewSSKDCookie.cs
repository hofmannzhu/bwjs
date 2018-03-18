using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model.Model
{
    /// <summary>
    /// 闪速快贷实体类
    /// </summary>
    public class NewSSKDCookie
    {
        /// <summary>
        /// 证件号码
        /// </summary>
        public string IDCardNo { set; get; }

        /// <summary>
        /// 申请人手机号码
        /// </summary>
        public string Mobile { set; get; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { set; get; }

        /// <summary>
        /// 申请编号
        /// </summary>
        public string ConsultId { set; get; }

        /// <summary>
        /// 商户编号
        /// </summary>
        public string MerchantId { set; get; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string MachineId { set; get; }

        /// <summary>
        /// token值
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 身份证姓名
        /// </summary>
        public string FullName { set; get; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { set; get; }
        /// <summary>
        /// 出生年月
        /// </summary>
        public string Birth { set; get; }
        /// <summary>
        /// 民族
        /// </summary>
        public string National { set; get; }
        /// <summary>
        /// 住址
        /// </summary>
        public string Address { set; get; }
        /// <summary>
        /// 签发机关
        /// </summary>
        public string Authority { set; get; }
        /// <summary>
        /// 有效期
        /// </summary>
        public string Validperiod { set; get; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp { set; get; }
    }
}
