using XBWNInterface.BLL;
using UtilityHelper;
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
    /// 贷款控制器
    /// </summary>
    [RoutePrefix("xbwnapi/Loan")]
    public class LoanController : ApiController
    {
        /// <summary>
        /// 验证手机是否注册
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("CheckMonbileIsRegister")]
        public HttpResponseMessage CheckMonbileIsRegister()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string telNo = DNTRequest.GetString("telNo");
            result = LoanInterface.CheckMonbileIsRegister(telNo, netLoanApplyId);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 发送手机验证码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetMonbileSmsCode")]
        public HttpResponseMessage GetMonbileSmsCode()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string telNo = DNTRequest.GetString("telNo");
            result = LoanInterface.GetMonbileSmsCode(telNo, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 会员注册
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("MemerRegister")]
        public HttpResponseMessage MemerRegister()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string telNo = DNTRequest.GetString("telNo");
            string password = DNTRequest.GetString("password");
            string inviteCode = DNTRequest.GetString("inviteCode");
            string smsCode = DNTRequest.GetString("smsCode");
            result = LoanInterface.MemerRegister(telNo, password, inviteCode, smsCode, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 会员登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("MemerSignIn")]
        public HttpResponseMessage MemerSignIn()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string telNo = DNTRequest.GetString("telNo");
            string password = DNTRequest.GetString("password");
            string smsCode = DNTRequest.GetString("smsCode");
            result = LoanInterface.MemerSignIn(telNo, password, smsCode, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 获取银行卡列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetBankCardList")]
        public HttpResponseMessage GetBankCardList()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.GetBankCardList(netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 添加银行
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("BankCardAdd")]
        public HttpResponseMessage BankCardAdd()
        {
            object result = string.Empty;
            string realName = DNTRequest.GetString("realName");
            string idNo = DNTRequest.GetString("idNo");
            string bankCardNo = DNTRequest.GetString("bankCardNo");
            string telNo = DNTRequest.GetString("telNo");
            int cash = DNTRequest.GetInt("cash", -1);
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.BankCardAdd(realName, idNo, bankCardNo, telNo, cash, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 发送银行手机验证码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("BankCardSmsCode")]
        public HttpResponseMessage BankCardSmsCode()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string no = DNTRequest.GetString("no");
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.BankCardSmsCode(no, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 验证银行手机短信
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("BankCardSmsCodeCheck")]
        public HttpResponseMessage BankCardSmsCodeCheck()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string no = DNTRequest.GetString("no");
            string code = DNTRequest.GetString("code");
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.BankCardSmsCodeCheck(no, code, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ImagesUpload")]
        public HttpResponseMessage ImagesUpload()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string base64Code = DNTRequest.GetString("base64Code");
            string token = DNTRequest.GetString("token");

            byte[] photoData = new byte[0];

            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            photoData = HttpContext.Current.Request.BinaryRead(HttpContext.Current.Request.TotalBytes);

            //photoData = Convert.FromBase64String(base64Code);

            LoanInterface.cookieValue = token;
            result = LoanInterface.ImagesUpload(base64Code, photoData, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
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

            result = LoanInterface.CheckUserIsAuthentication(memberId, customerId, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
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
            string fontId = DNTRequest.GetString("fontId");
            string bankId = DNTRequest.GetString("bankId");
            string realName = DNTRequest.GetString("realName");
            string idNo = DNTRequest.GetString("idNo");
            string birth = DNTRequest.GetString("birth");
            string national = DNTRequest.GetString("national");
            string address = DNTRequest.GetString("address");
            string authority = DNTRequest.GetString("authority");
            string validperiod = DNTRequest.GetString("validperiod");
            string faceNo = DNTRequest.GetString("faceNo");
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.SubmitIDInformation(fontId, bankId, realName, idNo, birth, national, address, authority, validperiod, faceNo, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 创建手机运营商爬取任务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("TaskCreate")]
        public HttpResponseMessage TaskCreate()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string telNo = DNTRequest.GetString("telNo");
            string servicePwd = DNTRequest.GetString("servicePwd");
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.TaskCreate(telNo, servicePwd, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 更新手机运营商爬取任务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("TaskUpdate")]
        public HttpResponseMessage TaskUpdate()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string smsCode = DNTRequest.GetString("smsCode");
            string taskId = DNTRequest.GetString("taskId");
            string servicePwd = DNTRequest.GetString("servicePwd");
            string imgCode = DNTRequest.GetString("imgCode");
            string realName = DNTRequest.GetString("realName");
            string idNo = DNTRequest.GetString("idNo");
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.TaskUpdate(smsCode, taskId, servicePwd, imgCode, realName, idNo, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 查询手机运营商爬取任务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("TaskQuery")]
        public HttpResponseMessage TaskQuery()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string taskId = DNTRequest.GetString("taskId");
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.TaskQuery(taskId, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 发送运营商短信
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("SendOperatorSmsCode")]
        public HttpResponseMessage SendOperatorSmsCode()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string taskId = DNTRequest.GetString("taskId");
            string telNo = DNTRequest.GetString("telNo");
            string smsCode = DNTRequest.GetString("smsCode");
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.SendOperatorSmsCode(taskId, telNo, smsCode, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 发送运营商图片验证码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("SendOperatorImgCode")]
        public HttpResponseMessage SendOperatorImgCode()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string taskId = DNTRequest.GetString("taskId");
            string telNo = DNTRequest.GetString("telNo");
            string imgCode = DNTRequest.GetString("imgCode");
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.SendOperatorImgCode(taskId, telNo, imgCode, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
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
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string token = DNTRequest.GetString("token");
            LoanInterface.cookieValue = token;
            result = LoanInterface.GetLoanParas(netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 提交借款
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("SubmitLoanApply")]
        public HttpResponseMessage SubmitLoanApply()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string loanAmount = DNTRequest.GetString("loanAmount");
            string bankId = DNTRequest.GetString("bankId");
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.SubmitLoanApply(loanAmount, bankId, netLoanApplyId);
            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 确认借款
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ConfirmationLoanApply")]
        public HttpResponseMessage ConfirmationLoanApply()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string borrowNo = DNTRequest.GetString("borrowNo");
            string tradePassword = DNTRequest.GetString("tradePassword");
            string tradePasswordSecond = DNTRequest.GetString("tradePasswordSecond");
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.ConfirmationLoanApply(borrowNo, tradePassword, tradePasswordSecond, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }

        /// <summary>
        /// 首页综合信息查询
        /// </summary>
        [HttpPost]
        [Route("ComprehensiveQuery")]
        public HttpResponseMessage ComprehensiveQuery()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.ComprehensiveQuery(netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }

        /// <summary>
        /// 借款状态审核查询
        /// </summary>
        [HttpPost]
        [Route("BorrowingStateQuery")]
        public Object BorrowingStateQuery()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string borrowNo = DNTRequest.GetString("borrowNo");
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.BorrowingStateQuery(borrowNo, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        /// <summary>
        /// 确认授权
        /// </summary>
        [HttpPost]
        [Route("ConfirmationOfAuthorization")]
        public Object ConfirmationOfAuthorization()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string identityCardNumber = DNTRequest.GetString("identityCardNumber");
            string accountExec = DNTRequest.GetString("accountExec");
            string authorizedPassword = DNTRequest.GetString("authorizedPassword");
            string borrowNo = DNTRequest.GetString("borrowNo");
            string operatorName = DNTRequest.GetString("operatorName");
            string operatorId = DNTRequest.GetString("operatorId");
            string token = DNTRequest.GetString("token");

            LoanInterface.cookieValue = token;
            result = LoanInterface.ConfirmationOfAuthorization(identityCardNumber, accountExec, authorizedPassword, operatorName, operatorId, borrowNo, netLoanApplyId);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
    }
}