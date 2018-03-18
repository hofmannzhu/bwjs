using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model
{
    #region 百度位置信息
    /*
{
"address": "CN|北京|北京|None|UNICOM|0|0",
"content": {
    "address": "北京市",
    "address_detail": {
        "city": "北京市",
        "city_code": 131,
        "district": "",
        "province": "北京市",
        "street": "",
        "street_number": ""
    },
    "point": {
        "x": "116.40387397",
        "y": "39.91488908"
    }
},
"status": 0
}

        {  
    address: "CN|北京|北京|None|CHINANET|1|None",    #地址  
    content:    #详细内容  
    {  
        address: "北京市",    #简要地址  
        address_detail:    #详细地址信息  
        {  
            city: "北京市",    #城市  
            city_code: 131,    #百度城市代码  
            district: "",    #区县  
            province: "北京市",    #省份  
            street: "",    #街道  
            street_number: ""    #门址  
        },  
        point:    #当前城市中心点，注意当前坐标返回类型
        {  
            x: "116.39564504",  
            y: "39.92998578"  
        }  
    },  
    status: 0    #返回状态码  
}
    */

    /// <summary>
    /// 百度位置信息响应
    /// </summary>
    public class BaiDuLocation
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 详细内容
        /// </summary>
        public BaiDuContent Content { get; set; }

        /// <summary>
        /// 返回状态码
        /// </summary>
        public int Status { get; set; }
    }

    /// <summary>
    /// 详细内容
    /// </summary>
    public class BaiDuContent
    {
        /// <summary>
        /// 简要地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 详细地址信息
        /// </summary>
        public BaiDuAdressDetail AddressDetail { get; set; }

        /// <summary>
        /// 当前城市中心点，注意当前坐标返回类型
        /// </summary>
        public BaiDuPoint Point { get; set; }
    }

    /// <summary>
    /// 详细地址信息
    /// </summary>
    public class BaiDuAdressDetail
    {
        /// <summary>
        /// 百度城市代码
        /// </summary>
        public int CityCode { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// 门址
        /// </summary>
        public string StreetNumber { get; set; }
    }

    /// <summary>
    /// 当前城市中心点，注意当前坐标返回类型
    /// </summary>
    public class BaiDuPoint
    {
        /// <summary>
        /// 简要地址
        /// </summary>
        public string X { get; set; }

        /// <summary>
        /// 详细地址信息
        /// </summary>
        public string Y { get; set; }
    }

    #endregion

    /// <summary>
    /// 订单试算里的试算因子
    /// </summary>
    public class GeneParam
    {
        /// <summary>
        /// 试算因子对应属性
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// 试算因子对应保障项目Id
        /// </summary>
        public string protectItemId { get; set; }

        /// <summary>
        /// 序列号、顺序值
        /// </summary>
        public int sort { get; set; }

        /// <summary>
        /// 试算因子值
        /// </summary>
        public string value { get; set; }

    }

    /// <summary>
    /// 产品详情里的试算因子
    /// </summary>
    public class RestrictGene
    {
        /// <summary>
        /// 试算因子对应保障项目id(当不为保障项目试算因子时此属性为空)
        /// </summary>
        public int? protectItemId { get; set; }

        /// <summary>
        /// 试算因子对应属性(当为保障项目试算因子时此属性为空)
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// 试算因子名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 试算因子默认值
        /// </summary>
        public string defaultValue { get; set; }

        /// <summary>
        /// 序列号、顺序值(升序排序)
        /// </summary>
        public int sort { get; set; }

        /// <summary>
        /// 试算因子选项
        /// </summary>
        public List<RestrictDictionary> values { get; set; }
    }

    /// <summary>
    /// 试算因子选项
    /// </summary>
    public class RestrictDictionary
    {
        /// <summary>
        /// 取值
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 类型(1为普通选项，2为从最小值到最大值根据步长生产的一系列选项)
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 最大值(只有type为2时才有用)
        /// </summary>
        public int max { get; set; }

        /// <summary>
        /// 最小值(只有type为2时才有用)
        /// </summary>
        public int min { get; set; }

        /// <summary>
        /// 步长(只有type为2时才有用)
        /// </summary>
        public int step { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string unit { get; set; }
    }

    /// <summary>
    /// 支付结果 用户支付完成，会根据对接系统提供的pageNoticeUrl发送结果给对接系统
    /// </summary>
    public class PayResult
    {
        /// <summary>
        /// 业务系统流水号
        /// </summary>
        public string BSId { get; set; }

        /// <summary>
        /// 支付的金额
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// 支付单号码（支付系统唯一标识)
        /// </summary>
        public string PayOrderNumber { get; set; }

        /// <summary>
        /// 在线支付标识
        /// </summary>
        public string OnlinePaymnetId { get; set; }

        /// <summary>
        /// 支付系统流水号
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// 成功则为：Success,失败不会通知
        /// </summary>
        public string Success { get; set; }

    }

    /// <summary>
    /// 地区信息
    /// </summary>
    public class AreaTree
    {
        /// <summary>
        /// 地区名称
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 地区编码，查询下一级时使用此编码
        /// </summary>
        public string code { get; set; }
    }
}
