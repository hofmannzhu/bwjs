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
    /// 授权认证
    /// </summary>
    [RoutePrefix("newxbwnapi/Authorization")]
    public class AuthorizationController : ApiController
    {
        [HttpPost]
        [Route("Index")]
        // GET: Authorization
        public HttpResponseMessage Index()
        {
            string result = string.Empty;
            HttpResponseMessage res = new HttpResponseMessage
            { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }

        /// <summary>
        /// 验证授权
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Checkmcs")]
        public HttpResponseMessage Checkmcs()
        {
            object result = string.Empty;
            string sign = DNTRequest.GetString("sign");
            string realName = DNTRequest.GetString("realName");
            string idNo = DNTRequest.GetString("idNo");
            string returnUrl = DNTRequest.GetString("returnUrl");
            string consultId = DNTRequest.GetString("consultId");
            string orderNo = DNTRequest.GetString("orderNo");
            string telNo = DNTRequest.GetString("telNo");
            string typeId = DNTRequest.GetString("typeId");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string token = DNTRequest.GetString("token");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            string orderSource = DNTRequest.GetString("orderSource");

            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.Checkmcs(consultId, sign, realName, idNo, returnUrl, orderNo, telNo, typeId, equipmentNo, merchantsNo, sskdRequestParas, orderSource);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }

        /// <summary>
        /// 确认授权
        /// </summary>
        [HttpPost]
        [Route("ConfirmationOfAuthorization")]
        public HttpResponseMessage ConfirmationOfAuthorization()
        {
            object result = string.Empty;
            string sign = DNTRequest.GetString("sign");
            string orderNo = DNTRequest.GetString("orderNo");
            string timeUnix = DNTRequest.GetString("timeUnix");
            int ConsultId = DNTRequest.GetInt("ConsultId", -1);
            string merchantsAcount = DNTRequest.GetString("merchantsAcount");
            string merchantsName = DNTRequest.GetString("merchantsName");
            string merchantsMobile = DNTRequest.GetString("merchantsMobile");
            string merchantsIdCardNo = DNTRequest.GetString("merchantsIdCardNo");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string token = DNTRequest.GetString("token");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            string orderSource = DNTRequest.GetString("orderSource");
            string creditLine = DNTRequest.GetString("creditLine");
            string borrowNo = DNTRequest.GetString("borrowNo");

            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.ConfirmationOfAuthorization(timeUnix, orderNo, sign, token, equipmentNo, merchantsNo, merchantsIdCardNo, merchantsAcount, merchantsMobile, merchantsName,ConsultId, sskdRequestParas, creditLine, borrowNo,orderSource);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
    }
}