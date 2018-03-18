using System;
using System.Web;

namespace UtilityHelper
{
    public class CookieHelper
    {
        /// <summary>  
        /// 判断是否存在Cookie表  
        /// </summary>  
        /// <param name="cookieName">Cookie名称</param>  
        /// <returns></returns>  
        public static bool HasCookie(string cookieName)
        {
            return HttpContext.Current.Request.Cookies[cookieName] != null;
        }

        /// <summary>
        /// 读取Cookie值
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        /// <returns>Cookie值</returns>
        public static string GetCookie(string cookieName)
        {
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[cookieName];
            return httpCookie != null ? httpCookie.Value : "";
        }

        public static bool SetCookie(string cookieName, string cookieValue, int days = 0)
        {
            return SetCookie(cookieName, cookieValue, "", days);
        }

        /// <summary>  
        /// 为Cookie赋值  
        /// </summary>  
        /// <param name="cookieName">Cookie名称</param>  
        /// <param name="cookieValue">Cookie值</param>  
        /// <param name="days">Cookie日期 0 为无时间限制。浏览器关闭就结束</param>  
        /// <param name="domain">Cookie站点</param>  
        /// <returns>返回布尔值</returns>  
        public static bool SetCookie(string cookieName, string cookieValue, string domain, int days = 0)
        {
            bool boolReturnValue = false;
            if (!string.IsNullOrEmpty(cookieValue) && !string.IsNullOrEmpty(cookieName)) //判断是否能建Cookie  
            {
                HttpCookie httpCookie = new HttpCookie(cookieName)
                {
                    Value = cookieValue
                };
                //设置Cookie站点  
                if (!string.IsNullOrEmpty(domain))
                {
                    httpCookie.Domain = domain;
                }
                //将值添入Cookie中   
                if (days > 0)
                {
                    //设置Cookie有效期  
                    httpCookie.Expires = DateTime.Now.AddDays(days);
                }
                //添加Cookie  
                HttpContext.Current.Response.Cookies.Add(httpCookie);
                boolReturnValue = true;
            }
            return boolReturnValue;
        }

        public static bool RemoveCookie(string cookieName)
        {
            return RemoveCookie(cookieName, "");
        }

        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        /// <param name="domain">Cookie站点</param>
        /// <returns>删除结果：true或false</returns>
        public static bool RemoveCookie(string cookieName, string domain)
        {
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[cookieName];
            //如果Cookie存在  
            if (httpCookie == null)
                return false;
            if (!string.IsNullOrEmpty(domain))
            {
                httpCookie.Domain = domain;
            }
            httpCookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(httpCookie);
            return true;
        }
    }
}
