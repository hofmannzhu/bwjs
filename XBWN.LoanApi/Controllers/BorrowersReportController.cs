using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Text;
using UtilityHelper;
using XBWNInterface.BLL;

namespace XBWN.LoanApi.Controllers
{
    /// <summary>
    /// 借款人报告
    /// </summary>
    [RoutePrefix("newxbwnapi/BorrowersReport")]
    public class BorrowersReportController : ApiController
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
        [HttpPost]
        [Route("AppraisalReport")]
        // GET: UserReport  用户报告
        public HttpResponseMessage AppraisalReport()
        {
            object result = string.Empty; 
            string ConsultId = DNTRequest.GetString("ConsultId");
            string sign = DNTRequest.GetString("sign");
            string orderNo = DNTRequest.GetString("orderNo");
            string timeUnix = DNTRequest.GetString("timeUnix");
            string reportType = DNTRequest.GetString("reportType");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string token = DNTRequest.GetString("token");
            string bwjsApi = DNTRequest.GetString("bwjsApi");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            string orderSource = DNTRequest.GetString("orderSource");
            

            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.AppraisalReport(ConsultId, sign, orderNo, timeUnix, reportType, token, merchantsNo, equipmentNo, bwjsApi, sskdRequestParas,orderSource);
            HttpResponseMessage res = new HttpResponseMessage
            { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
       
    }
}