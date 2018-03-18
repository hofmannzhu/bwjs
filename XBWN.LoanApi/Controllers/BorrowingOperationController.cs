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
    ///借款操作
    /// </summary>
    [RoutePrefix("newxbwnapi/BorrowingOperation")]
    public class BorrowingOperationController : ApiController
    {
        [HttpPost]
        [Route("Index")]
        public HttpResponseMessage Index()
        {
            string result = string.Empty;
            HttpResponseMessage res = new HttpResponseMessage
            { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }

        /// <summary>
        /// 获取借款参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetLoanParas")]
        public HttpResponseMessage GetLoanParas()
        {
            object result = string.Empty;
            int ConsultId = DNTRequest.GetInt("ConsultId", -1);
            string orderNo = DNTRequest.GetString("orderNo");
            string sign = DNTRequest.GetString("sign");
            string timeUnix = DNTRequest.GetString("timeUnix");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string token = DNTRequest.GetString("token");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            string orderSource = DNTRequest.GetString("orderSource");

            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.GetLoanParas(orderNo, sign, ConsultId, timeUnix, token, equipmentNo, merchantsNo, sskdRequestParas, orderSource);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 借款分期计算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("StagingCalculation")]
        public HttpResponseMessage StagingCalculation()
        {
            object result = string.Empty;
            int ConsultId = DNTRequest.GetInt("ConsultId", -1);
            string orderNo = DNTRequest.GetString("orderNo");
            string sign = DNTRequest.GetString("sign");
            string timeUnix = DNTRequest.GetString("timeUnix");
            string productId = DNTRequest.GetString("productId");
            string loanAmount = DNTRequest.GetString("loanAmount");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string token = DNTRequest.GetString("token");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            string orderSource = DNTRequest.GetString("orderSource");


            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.StagingCalculation(orderNo, sign, ConsultId, timeUnix, productId, loanAmount, token, equipmentNo, merchantsNo, sskdRequestParas, orderSource);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 借款申请
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("LoanApplication")]
        public HttpResponseMessage LoanApplication()
        {
            object result = string.Empty;
            int ConsultId = DNTRequest.GetInt("ConsultId", -1);
            string orderNo = DNTRequest.GetString("orderNo");
            string sign = DNTRequest.GetString("sign");
            string timeUnix = DNTRequest.GetString("timeUnix");
            string bankCardNo = DNTRequest.GetString("bankCardNo");
            string productId = DNTRequest.GetString("productId");
            string loanAmount = DNTRequest.GetString("loanAmount");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string token = DNTRequest.GetString("token");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            string orderSource = DNTRequest.GetString("orderSource");

            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.LoanApplication(orderNo, sign, ConsultId, bankCardNo, productId, loanAmount, timeUnix, token, equipmentNo, merchantsNo, sskdRequestParas, orderSource);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
    }
}
