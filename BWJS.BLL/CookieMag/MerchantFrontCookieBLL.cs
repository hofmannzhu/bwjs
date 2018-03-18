using BWJS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UtilityHelper;

namespace BWJS.BLL.CookieMag
{
    /// <summary>
    /// 商家用户登录Cookie
    /// </summary>
    public class MerchantFrontCookieBLL
    {


        /// <summary>
        /// 获取商家用户Cookie
        /// </summary>
        /// <returns></returns>
        public static int GetMerchantFrontUserId()
        {
            HttpCookie userInfoCookie = System.Web.HttpContext.Current.Request.Cookies["MerchantFrontUserCookie"];
            if (userInfoCookie != null)
            {
                string strUserInfo = HttpUtility.UrlDecode(userInfoCookie.Value, Encoding.GetEncoding("UTF-8"));
                LoginUserCookie userInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginUserCookie>(strUserInfo) as LoginUserCookie;
                return userInfo.LoginUserID;
            }
            else
            {
                return 0;
            }
        }
        public static void SetMerchantFrontCookie(int UserID, string LoginName)
        {
            LoginUserCookie loginuserCookie = new LoginUserCookie()
            {
                LoginUserID = UserID,
                LoginName = LoginName,

            };
            HttpCookie userInfo = new HttpCookie("MerchantFrontUserCookie");
            //将序列化之后的Json串以UTF-8编码，再存入Cookie
            userInfo.Value = HttpUtility.UrlEncode(ObjectToJson(loginuserCookie), Encoding.GetEncoding("UTF-8"));
            userInfo.Expires = DateTime.Now.AddHours(8);//8小时过期 

            HttpContext.Current.Response.Cookies.Add(userInfo);
        }

        public static LoginUserCookie GetMerchantFrontUserCookie()
        {

            HttpCookie userInfoCookie = HttpContext.Current.Request.Cookies.Get("MerchantFrontUserCookie");
            string strUserInfo = HttpUtility.UrlDecode(userInfoCookie.Value, Encoding.GetEncoding("UTF-8"));
            LoginUserCookie userInfo = JsonToObject(strUserInfo) as LoginUserCookie;
            return userInfo;

        }

        /// <summary>
        /// 将对象序列化成Json
        /// </summary>
        /// <param name="obj">需要序列化的对象</param>
        /// <returns>序列化后的字符串</returns>
        public static string ObjectToJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 从Json字符串反序列化为对象
        /// </summary>
        /// <param name="jsonString">Json字符串</param>
        /// <param name="obj">要生成的对象类型</param>
        /// <returns>反序列化后的对象</returns>
        public static object JsonToObject(string jsonString)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<LoginUserCookie>(jsonString);
        }
    }
}
