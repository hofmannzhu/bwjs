using UtilityHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BWJSLog.BLL;

namespace XBWNInterface.BLL
{
    /// <summary>
    /// 测试类
    /// </summary>
    public class TestCookie
    {
        #region 写Cookie
        /// <summary>
        /// 写Cookie
        /// </summary>
        static public Object WriteCookie()
        {
            string result = string.Empty;
            try
            {
                string consultId = new Random().Next(10000, 90000).ToString();
                string token = DateTime.Now.ToString("yyyyMMddHHmmssffff");

                Utils.DelCoookie("bwjsCookie20180107");
                Utils.WriteCookie("bwjsCookie20180107", "token", consultId, 2);
                Utils.WriteCookie("bwjsCookie20180107", "consultId", token, 2);

                //if (HttpContext.Current.Request.Cookies["bwjsCookie20180107"] != null)
                //{
                //}
                //else
                //{

                //    HttpCookie cookie = new HttpCookie("bwjsCookie20180107");
                //    cookie.Values.Add("consultId", HttpContext.Current.Server.UrlEncode(consultId.ToString()));
                //    cookie.Values.Add("token", HttpContext.Current.Server.UrlEncode(token));
                //    cookie.Expires = DateTime.Now.AddMinutes(120);
                //    HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
                //    //HttpContext.Current.Response.AppendCookie(cookie);
                //    HttpContext.Current.Response.Cookies.Add(cookie);
                //}
                HttpCookie consultIdCookie = new HttpCookie("consultId");
                consultIdCookie.Value = HttpUtility.UrlEncode(consultId.ToString(), Encoding.GetEncoding("UTF-8"));
                consultIdCookie.Expires = DateTime.Now.AddHours(2);
                HttpContext.Current.Response.Cookies.Add(consultIdCookie);

                HttpCookie tokenCookie = new HttpCookie("token");
                tokenCookie.Value = HttpUtility.UrlEncode(token, Encoding.GetEncoding("UTF-8"));
                tokenCookie.Expires = DateTime.Now.AddHours(2);
                HttpContext.Current.Response.Cookies.Add(tokenCookie);
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "异常，请稍后再试", null);
            }
            return result;
        }
        #endregion
        
        #region 读Cookie
        /// <summary>
        /// 读Cookie
        /// </summary>
        static public Object GetCookie()
        {
            string result = string.Empty;
            try
            {

                string token = Utils.GetCookie("bwjsCookie20180107", "token");
                string consultId = Utils.GetCookie("bwjsCookie20180107", "consultId");
                result = string.Format("{0}-{1}");
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "异常，请稍后再试", null);
            }
            return result;
        } 
        #endregion

    }
}
