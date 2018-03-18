using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace MofangInterface.BLL
{
    public class LinkFun
    {
        /// <summary>
        /// 订单支付成功后通知页面
        /// </summary>
        /// <returns></returns>
        public static string getPageNoticeUrl()
        {
            return System.Configuration.ConfigurationManager.AppSettings["pageNoticeUrl"];
        }
        /// <summary>
        /// 渠道密钥
        /// </summary>
        public static string getVI()
        {
            return System.Configuration.ConfigurationManager.AppSettings["VI"];
        }
        /// <summary>
        /// 接口地址
        /// </summary>
        public static string getURLBaseMoFang()
        {
            return System.Configuration.ConfigurationManager.AppSettings["URLBaseMoFang"];
        }
        /// <summary>
        /// 渠道商身份标识
        /// </summary>
        public static string getCustomkey()
        {
            return System.Configuration.ConfigurationManager.AppSettings["Customkey"];
        }
    }
}
