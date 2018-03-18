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
    /// 联系人管理
    /// </summary>
    [RoutePrefix("newxbwnapi/ContactManager")]
    public class ContactManagerController : ApiController
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

        /// <summary>
        /// 设备信息
        /// </summary>
        [HttpPost]
        [Route("EquipmentCapture")]
        public HttpResponseMessage EquipmentCapture()
        {
            object result = string.Empty;
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            result = NewLoanInterface.EquipmentCapture(sskdRequestParas);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }

        /// <summary>
        /// 商户信息
        /// </summary>
        [HttpPost]
        [Route("MerchantCapture")]
        public HttpResponseMessage MerchantCapture()
        {
            object result = string.Empty;
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            result = NewLoanInterface.MerchantCapture(sskdRequestParas);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }

        /// <summary>
        /// 设备商户关联信息
        /// </summary>
        [HttpPost]
        [Route("EquipmentMerchantRelation")]
        public HttpResponseMessage EquipmentMerchantRelation()
        {
            object result = string.Empty;
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            result = NewLoanInterface.MerchantCapture(sskdRequestParas);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
    }
}