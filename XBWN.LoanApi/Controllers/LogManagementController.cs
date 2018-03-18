using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Text;

namespace XBWN.LoanApi.Controllers
{
    /// <summary>
    /// 日志管理
    /// </summary>
    [RoutePrefix("newxbwnapi/LogManagement")]
    public class LogManagementController : ApiController
    {
        [HttpPost]
        [Route("Index")]
        // GET: BankCardManagement
        public HttpResponseMessage Index()
        {
            string result = string.Empty;
            HttpResponseMessage res = new HttpResponseMessage
            { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
    }
}