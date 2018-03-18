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
    /// 贷款申请
    /// </summary>
    [RoutePrefix("newxbwnapi/LoanApplication")]
    public class LoanApplicationController : ApiController
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
        /// 立即申请
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertPadConsult")]
        public HttpResponseMessage InsertPadConsult()
        {
            object result = string.Empty;
            string Consult = DNTRequest.GetString("Consult");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            result = NewLoanInterface.InsertPadConsult(Consult, equipmentNo, merchantsNo);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }



        #region InsertConsult
        /// <summary>
        /// 立即申请
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertConsult")]
        public HttpResponseMessage InsertConsult()
        {
            object result = string.Empty;
            string Consult = DNTRequest.GetString("Consult");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string base64Code = DNTRequest.GetString("base64Code");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            if (!string.IsNullOrEmpty(base64Code))
            {
                base64Code = base64Code.Replace(" ", "+");
            }

            result = NewLoanInterface.InsertConsult(Consult, equipmentNo, merchantsNo, base64Code, sskdRequestParas);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion

        #region 填写信息
        /// <summary>
        /// 填写信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("FillInTheInformation")]
        public HttpResponseMessage FillInTheInformation()
        {
            object result = string.Empty;
            string sskdRequestParasJson = DNTRequest.GetString("sskdRequestParas");
            string array = DNTRequest.GetString("array");
            string orderSource = DNTRequest.GetString("orderSource");

            result = NewLoanInterface.FillInTheInformation(sskdRequestParasJson, array, orderSource);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };//
            return res;
        }
        #endregion

        #region 根据四要素得到绑定卡
        /// <summary>
        /// 根据四要素得到绑定卡
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetBankCardListByFourElements")]
        public HttpResponseMessage GetBankCardListByFourElements()
        {
            object result = string.Empty;
            string consultId = DNTRequest.GetString("consultId");
            string token = DNTRequest.GetString("token");
            string realName = DNTRequest.GetString("realName");
            string telNo = DNTRequest.GetString("telNo");
            string idCardNo = DNTRequest.GetString("idCardNo");
            string bankCardNo = DNTRequest.GetString("bankCardNo");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.GetBankCardListByFourElements(consultId, token, realName, telNo, idCardNo, bankCardNo, sskdRequestParas);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion

        #region 根据根据姓名证件号码得到绑定卡
        /// <summary>
        /// 根据根据姓名证件号码得到绑定卡
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetBankCardListByTwoElements")]
        public HttpResponseMessage GetBankCardListByTwoElements()
        {
            object result = string.Empty;
            string consultId = DNTRequest.GetString("consultId");
            string token = DNTRequest.GetString("token");
            string realName = DNTRequest.GetString("realName");
            string idCardNo = DNTRequest.GetString("idCardNo");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            string orderSource = DNTRequest.GetString("orderSource");

            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.GetBankCardListByTwoElements(consultId, token, realName, idCardNo, sskdRequestParas, orderSource);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion

        #region 银行卡列表
        /// <summary>
        /// 银行卡列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("BankCardList")]
        public HttpResponseMessage BankCardList()
        {
            object result = string.Empty;
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            result = NewLoanInterface.BankCardList(sskdRequestParas);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion

        #region 添加银行
        /// <summary>
        /// 添加银行
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("BankCardAdd")]
        public HttpResponseMessage BankCardAdd()
        {
            object result = string.Empty;
            int consultId = DNTRequest.GetInt("consultId", -1);
            string realName = DNTRequest.GetString("realName");
            string token = DNTRequest.GetString("token");
            string idCardNo = DNTRequest.GetString("idCardNo");
            string bankCardNo = DNTRequest.GetString("bankCardNo");
            string telNo = DNTRequest.GetString("telNo");
            string sign = DNTRequest.GetString("sign");
            string orderNo = DNTRequest.GetString("orderNo");
            string timeUnix = DNTRequest.GetString("timeUnix");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            string orderSource = DNTRequest.GetString("orderSource");
            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.BankCardAdd(realName, idCardNo, bankCardNo, telNo, sign, orderNo, timeUnix, merchantsNo, equipmentNo, consultId, sskdRequestParas, orderSource);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion

        #region 发送银行手机验证码
        /// <summary>
        /// 发送银行手机验证码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("BankCardSmsCode")]
        public HttpResponseMessage BankCardSmsCode()
        {
            object result = string.Empty;
            int consultId = DNTRequest.GetInt("consultId", -1);
            string realName = DNTRequest.GetString("realName");
            string token = DNTRequest.GetString("token");
            string idCardNo = DNTRequest.GetString("idCardNo");
            string bankCardNo = DNTRequest.GetString("bankCardNo");
            string telNo = DNTRequest.GetString("telNo");
            string sign = DNTRequest.GetString("sign");
            string orderNo = DNTRequest.GetString("orderNo");
            string timeUnix = DNTRequest.GetString("timeUnix");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            string orderSource = DNTRequest.GetString("orderSource");

            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.BankCardSmsCode(realName, idCardNo, bankCardNo, telNo, sign, orderNo, timeUnix, merchantsNo, equipmentNo, consultId, sskdRequestParas, orderSource);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion

        #region 验证银行手机短信
        /// <summary>
        /// 验证银行手机短信
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("BankCardSmsCodeCheck")]
        public HttpResponseMessage BankCardSmsCodeCheck()
        {
            object result = string.Empty;
            int consultId = DNTRequest.GetInt("consultId", -1);
            string code = DNTRequest.GetString("code");
            string token = DNTRequest.GetString("token");
            string bankCardId = DNTRequest.GetString("bankCardId");
            string sign = DNTRequest.GetString("sign");
            string orderNo = DNTRequest.GetString("orderNo");
            string timeUnix = DNTRequest.GetString("timeUnix");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            string orderSource = DNTRequest.GetString("orderSource");
            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.BankCardSmsCodeCheck(code, bankCardId, sign, orderNo, timeUnix, merchantsNo, equipmentNo, consultId, sskdRequestParas, orderSource);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion

        #region 图片上传
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ImagesUpload")]
        public HttpResponseMessage ImagesUpload()
        {
            object result = string.Empty;
            string base64Code = DNTRequest.GetString("base64Code");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            if (!string.IsNullOrEmpty(base64Code))
            {
                base64Code = base64Code.Replace(" ", "+");
                base64Code = base64Code.Replace(" ", "");
                base64Code = base64Code.Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");
                if (base64Code.Length % 4 > 0)
                {
                    base64Code = base64Code.PadRight(base64Code.Length + 4 - base64Code.Length % 4, '=');
                }
            }

            byte[] photoData = new byte[0];
            string msg = string.Empty;
            string fileName = string.Empty;
            string _contentType = "application/x-jpg";
            photoData = DNTRequest.Base64StringToByte(base64Code, ref msg, ref fileName);
            if (!string.IsNullOrEmpty(msg))
            {
                HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(msg, Encoding.GetEncoding("UTF-8"), "text/plain") };
                return res;
            }
            else
            {
                result = NewLoanInterface.ImagesUpload(base64Code, photoData, fileName, _contentType, sskdRequestParas);

                HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
                return res;
            }
        }
        #endregion

        #region 检查身份认证是否成功
        /// <summary>
        /// 检查身份认证是否成功
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("CheckUserIsAuthentication")]
        public HttpResponseMessage CheckUserIsAuthentication()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string memberId = DNTRequest.GetString("memberId");
            string customerId = DNTRequest.GetString("customerId");
            string token = DNTRequest.GetString("token");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.CheckUserIsAuthentication(memberId, customerId, netLoanApplyId, sskdRequestParas);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion

        #region 身份证信息提交
        /// <summary>
        /// 身份证信息提交
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("SubmitIDInformation")]
        public HttpResponseMessage SubmitIDInformation()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string sign = DNTRequest.GetString("sign");
            string faceIds = DNTRequest.GetString("faceIds");
            string idCardIds = DNTRequest.GetString("idCardIds");
            string realName = DNTRequest.GetString("realName");
            string idCardNo = DNTRequest.GetString("idCardNo");
            string sex = DNTRequest.GetString("sex");
            string birth = DNTRequest.GetString("birth");
            string national = DNTRequest.GetString("national");
            string address = DNTRequest.GetString("address");
            string authority = DNTRequest.GetString("authority");
            string validperiod = DNTRequest.GetString("validperiod");
            string orderNo = DNTRequest.GetString("orderNo");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string token = DNTRequest.GetString("token");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            string orderSource = DNTRequest.GetString("orderSource");
            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.SubmitIDInformation(sign, orderNo, equipmentNo, merchantsNo, faceIds, idCardIds, realName, idCardNo, sex, birth, national, address, authority, validperiod, netLoanApplyId, sskdRequestParas, orderSource);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion

        #region 立即申请后填写信息
        /// <summary>
        /// 立即申请后填写信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdataConsult")]
        public HttpResponseMessage UpdataConsult()
        {
            object result = string.Empty;
            string ConsultId = DNTRequest.GetString("ConsultId");
            string ProvinceId = DNTRequest.GetString("ProvinceId");
            string CityId = DNTRequest.GetString("CityId");
            string DistrictId = DNTRequest.GetString("DistrictId");
            string Area = DNTRequest.GetString("Area");
            string Address = DNTRequest.GetString("Address");
            string ProfessionInfo = DNTRequest.GetString("professionInfo");
            string IdentityInfo = DNTRequest.GetString("identityInfo");
            string AssetInfo = DNTRequest.GetString("assetInfo");
            string sign = DNTRequest.GetString("sign");
            string orderNo = DNTRequest.GetString("orderNo");
            string array = DNTRequest.GetString("array");
            string token = DNTRequest.GetString("token");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string orderSource = DNTRequest.GetString("orderSource");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.UpdataConsult(ConsultId, ProvinceId, CityId, DistrictId, Area, Address, ProfessionInfo, IdentityInfo, AssetInfo, sign, orderNo, array, equipmentNo, merchantsNo, orderSource, sskdRequestParas);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };//
            return res;
        }
        #endregion

        #region 自描述信息入库
        /// <summary>
        /// 自描述信息入库
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetaInformation")]
        public HttpResponseMessage GetaInformation()
        {
            object result = string.Empty;
            string idNo = DNTRequest.GetString("idNo");
            string Mobile = DNTRequest.GetString("Mobile");
            string FullName = DNTRequest.GetString("FullName");
            string token = DNTRequest.GetString("token");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.GetaInformation(idNo, Mobile, FullName, sskdRequestParas);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };//
            return res;
        }
        #endregion

        #region 认证进度查询
        /// <summary>
        /// 认证进度查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRzjd")]
        public HttpResponseMessage GetRzjd()
        {
            object result = string.Empty;

            string consultId = DNTRequest.GetString("consultId");
            string orderNo = DNTRequest.GetString("orderNo");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string sign = DNTRequest.GetString("sign");
            string token = DNTRequest.GetString("token");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            string orderSource = DNTRequest.GetString("orderSource");

            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.GetRzjd(consultId, orderNo, merchantsNo, equipmentNo, sign, sskdRequestParas, orderSource);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };//
            return res;
        }
        #endregion

        #region 贷款状态变更
        /// <summary>
        /// 贷款状态变更
        /// </summary>
        [HttpPost]
        [Route("ApplyStatusChange")]
        public HttpResponseMessage ApplyStatusChange()
        {
            object result = string.Empty;
            int consultId = DNTRequest.GetInt("consultId", -1);
            int status = DNTRequest.GetInt("status", -1);
            int prevStatus = DNTRequest.GetInt("prevStatus", -1);
            string sskdModel = DNTRequest.GetString("sskdModel");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            result = NewLoanInterface.ApplyStatusChange(consultId, status, prevStatus, sskdRequestParas);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };//
            return res;
        }
        #endregion

        #region 百度IP定位当前位置信息
        /// <summary>
        /// 百度IP定位当前位置信息
        /// </summary>
        [HttpPost]
        [Route("GetLocationJson")]
        public HttpResponseMessage GetLocationJson()
        {
            object result = string.Empty;
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };//
            return res;
        }
        #endregion


        #region 前台ajax（log记录）
        /// <summary>
        /// 前台ajax（log记录）
        /// </summary>
        [HttpPost]
        [Route("AjaxApiLog")]
        public HttpResponseMessage AjaxApiLog()
        {
            object result = string.Empty;
            string url = DNTRequest.GetString("url");
            string paramStr = DNTRequest.GetString("paramStr");
            result = NewLoanInterface.AjaxApiLog(url, paramStr);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };//
            return res;
        }
        #endregion

        #region 订单认证进度
        /// <summary>
        /// 订单认证进度
        /// </summary>
        [HttpPost]
        [Route("OrderAuthenticationProgressQuery")]
        public HttpResponseMessage OrderAuthenticationProgressQuery()
        {
            object result = string.Empty;
            string telNo = DNTRequest.GetString("telNo");
            string idCardNo = DNTRequest.GetString("idCardNo");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            result = NewLoanInterface.OrderAuthenticationProgressQuery(sskdRequestParas, telNo, idCardNo);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion

        
        #region 商户受额
        /// <summary>
        /// 商户受额
        /// </summary>
        [HttpPost]
        [Route("MerchantAcceptance")]
        public HttpResponseMessage MerchantAcceptance()
        {
            object result = string.Empty;
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            string merchantsAcount = DNTRequest.GetString("merchantsAcount");
            string merchantsMobile = DNTRequest.GetString("merchantsMobile");
            string merchantsName = DNTRequest.GetString("merchantsName");
            string merchantsIdCardNo = DNTRequest.GetString("merchantsIdCardNo");
            string amount = DNTRequest.GetString("amount");
            result = NewLoanInterface.MerchantAcceptance(sskdRequestParas, merchantsAcount, merchantsMobile, merchantsName, merchantsIdCardNo, amount);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion


        #region 查询商户权限
        /// <summary>
        /// 查询商户权限
        /// </summary>
        [HttpPost]
        [Route("QueryBusinessPermissions")]
        public HttpResponseMessage QueryBusinessPermissions()
        {
            object result = string.Empty;
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
            result = NewLoanInterface.QueryBusinessPermissions(sskdRequestParas);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion
    }
}