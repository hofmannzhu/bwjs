using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UtilityHelper;
using XBWNInterface.BLL;

namespace XBWN.LoanApi.Controllers
{
    [RoutePrefix("TestApi")]
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        #region 写Cookie
        /// <summary>
        /// 写Cookie
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("WriteCookie")]
        public HttpResponseMessage WriteCookie()
        {
            object result = string.Empty;
            string token = DNTRequest.GetString("token");

            result = TestCookie.WriteCookie();
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion

        #region 读Cookie
        /// <summary>
        /// 读Cookie
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetCookie")]
        public HttpResponseMessage GetCookie()
        {
            object result = string.Empty;
            string token = DNTRequest.GetString("token");

            result = TestCookie.GetCookie();
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        } 
        #endregion
    }
}