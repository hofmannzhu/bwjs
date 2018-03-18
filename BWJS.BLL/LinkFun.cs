using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.BLL
{
    public class LinkFun
    { 
        /// <summary>
        /// 订单支付成功后通知页面
        /// </summary>
        /// <returns></returns>
        //public static string getAdRefreshTime()
        //{
        //    return System.Configuration.ConfigurationManager.AppSettings["AdRefreshTime"];
        //}
        //public static string getProductIndexRefreshTime()
        //{
        //    return System.Configuration.ConfigurationManager.AppSettings["ProductIndexRefreshTime"];
        //}
        public static string getBWJSDomain()
        {
            return System.Configuration.ConfigurationManager.AppSettings["BWJSDomain"];
        }
        //public static string getBackgroundRefreshTime()
        //{
        //    return System.Configuration.ConfigurationManager.AppSettings["BackgroundRefreshTime"];
        //}
        public static string getPwdKey()
        {
            return System.Configuration.ConfigurationManager.AppSettings["PwdKey"];
        }
        public static string ConfigString(string keyName, string defaultVal)
        {
            try
            {
                return SysConfigBLL.GetValue(keyName);//改成了不用缓存
            }
            catch
            {
                return defaultVal;
            }
        }

    }
}
