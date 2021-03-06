﻿using BWJS.AppCode;
using BWJS.BLL;
using BWJS.Model;
using BWJSLog.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using UtilityHelper;
using System.Collections;
using BWJS.Model.Model;

namespace BWJS.WebApp.Ajax.Helper.BWJS
{
    public class INewNetLoan
    {
        static string postMethod = "POST";
        /// <summary>
        /// 指定响应的 HTTP内容类型。如果未指定默认为application/x-www-form-urlencoded;charset=utf-8
        /// text/plain;charset=utf-8
        /// </summary>
        static string contentType = "application/x-www-form-urlencoded;charset=utf-8";
        /// <summary>
        /// 贷款Api地址
        /// </summary>
        static string loanApi = CommonHelper.GetAppSettingsValue("loanApi", "http://localhost:7173");
        static string webappurl = CommonHelper.GetAppSettingsValue("webappurl", "http://localhost:7173");

        static string jsonText = string.Empty;

        static public void Implementation(string postJsonText)
        {
            jsonText = postJsonText;
            string action = DNTRequest.GetString("action");
            if (string.IsNullOrEmpty(action))
            {
                action = JsonRequest.GetJsonKeyVal(jsonText, "action");
            }
            if (!string.IsNullOrEmpty(action))
            {
                #region 实现

                switch (action)
                {
                    case "getidcard":
                        HttpContext.Current.Response.Write(GetIdCardLibraryList());
                        break;
                    case "getbankcardlistbyfourelements":
                        HttpContext.Current.Response.Write(GetBankCardListByFourElements());
                        break;
                    case "getbankcardlistbytwoelements":
                        HttpContext.Current.Response.Write(GetBankCardListByTwoElements());
                        break;
                    case "bankcardlist":
                        HttpContext.Current.Response.Write(BankCardList());
                        break;
                    case "bankcardadd":
                        HttpContext.Current.Response.Write(BankCardAdd());
                        break;
                    case "bankcardsmscode":
                        HttpContext.Current.Response.Write(BankCardSmsCode());
                        break;
                    case "bankcardsmscodecheck":
                        HttpContext.Current.Response.Write(BankCardSmsCodeCheck());
                        break;
                    case "GetOrderInformation":
                        HttpContext.Current.Response.Write(GetOrderInformation());
                        break;
                    case "imagesupload":
                        HttpContext.Current.Response.Write(ImagesUpload());
                        break;
                    case "submitidinformation":
                        HttpContext.Current.Response.Write(SubmitIDInformation());
                        break;
                    case "checkuserisauthentication":
                        HttpContext.Current.Response.Write(CheckUserIsAuthentication());
                        break;
                    case "InsertConsult":
                        HttpContext.Current.Response.Write(InsertConsult());
                        break;
                    case "UpdataConsult":
                        HttpContext.Current.Response.Write(UpdataConsult());
                        break;
                    case "fillintheinformation":
                        HttpContext.Current.Response.Write(FillInTheInformation());
                        break;
                    case "getloanparas":
                        HttpContext.Current.Response.Write(GetLoanParas());
                        break;
                    case "StagingCalculation":
                        HttpContext.Current.Response.Write(StagingCalculation());
                        break;
                    case "LoanApplication":
                        HttpContext.Current.Response.Write(LoanApplication());
                        break;
                    case "Checkmcs":
                        HttpContext.Current.Response.Write(Checkmcs());
                        break;
                    case "confirmationofauthorization":
                        HttpContext.Current.Response.Write(ConfirmationOfAuthorization());
                        break;
                    case "AppraisalReport":
                        HttpContext.Current.Response.Write(AppraisalReport());
                        break;
                    case "GetaInformation":
                        HttpContext.Current.Response.Write(GetaInformation());
                        break;
                    case "SetEquipmentCapture":
                        HttpContext.Current.Response.Write(SetEquipmentCapture());
                        break;
                    case "SetMerchantCapture":
                        HttpContext.Current.Response.Write(SetMerchantCapture());
                        break;
                    case "GetRzjd":
                        HttpContext.Current.Response.Write(GetRzjd());
                        break;
                    case "base64decode":
                        HttpContext.Current.Response.Write(Base64Decode());
                        break;
                    case "applystatuschange":
                        HttpContext.Current.Response.Write(ApplyStatusChange());
                        break;
                    case "getlocationjson":
                        HttpContext.Current.Response.Write(GetLocationJson());
                        break;
                    case "getaddressbylocation":
                        HttpContext.Current.Response.Write(GetAddressByLocation());
                        break;
                    case "getR":
                        HttpContext.Current.Response.Write(GetRegion());
                        break;
                    case "getconfiglist":
                        HttpContext.Current.Response.Write(GetConfigList());
                        break;
                    case "housingloanapply":
                        HttpContext.Current.Response.Write(HousingLoanApply());
                        break;
                    case "orderauthenticationprogressquery":
                        HttpContext.Current.Response.Write(OrderAuthenticationProgressQuery());
                        break;
                }
                #endregion
            }
        }

        #region 根据四要素得到绑定卡
        /// <summary>
        /// 根据四要素得到绑定卡
        /// </summary>
        /// <returns></returns>
        static public Object GetBankCardListByFourElements()
        {
            string result = string.Empty;
            try
            {
                int consultId = DNTRequest.GetInt("consultId", -1);
                string token = DNTRequest.GetString("token");
                string realName = DNTRequest.GetString("realName");
                string telNo = DNTRequest.GetString("telNo");
                string idCardNo = DNTRequest.GetString("idCardNo");
                string bankCardNo = DNTRequest.GetString("bankCardNo");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/GetBankCardListByFourElements";
                string postParamters = string.Format("realName={0}&telNo={1}&idCardNo={2}&bankCardNo={3}&token={4}&consultId={5}&sskdRequestParas={6}"
                        , realName, telNo, idCardNo, bankCardNo, token, consultId, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "根据四要素得到对象异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 根据根据姓名证件号码得到绑定卡
        /// <summary>
        /// 根据根据姓名证件号码得到绑定卡
        /// </summary>
        /// <returns></returns>
        static public Object GetBankCardListByTwoElements()
        {
            string result = string.Empty;
            try
            {
                int consultId = DNTRequest.GetInt("consultId", -1);
                string token = DNTRequest.GetString("token");
                string realName = DNTRequest.GetString("realName");
                string idCardNo = DNTRequest.GetString("idCardNo");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/GetBankCardListByTwoElements";
                string postParamters = string.Format("realName={0}&idCardNo={1}&token={2}&consultId={3}&sskdRequestParas={4}"
                        , realName, idCardNo, token, consultId, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "根据二要素得到对象异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 银行卡列表
        /// <summary>
        /// 银行卡列表
        /// </summary>
        /// <returns></returns>
        static public Object BankCardList()
        {
            string result = string.Empty;
            try
            {
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");


                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/BankCardList";
                string postParamters = string.Format("sskdRequestParas={0}", sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "获取银行卡列表异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 添加银行
        /// <summary>
        /// 添加银行
        /// </summary>
        /// <returns></returns>
        static public Object BankCardAdd()
        {
            string result = string.Empty;
            try
            {
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


                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/BankCardAdd";
                string postParamters = string.Format("realName={0}&idCardNo={1}&bankCardNo={2}&telNo={3}&sign={4}&orderNo={5}&timeUnix={6}&consultId={7}&merchantsNo={8}&equipmentNo={9}&token={10}&sskdRequestParas={11}"
                        , realName, idCardNo, bankCardNo, telNo, sign, orderNo, timeUnix, consultId, merchantsNo, equipmentNo, token, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "添加银行异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 发送银行手机验证码
        /// <summary>
        /// 发送银行手机验证码
        /// </summary>
        /// <returns></returns>
        static public Object BankCardSmsCode()
        {
            string result = string.Empty;
            try
            {
                string token = DNTRequest.GetString("token");
                int consultId = DNTRequest.GetInt("consultId", -1);
                string realName = DNTRequest.GetString("realName");
                string idCardNo = DNTRequest.GetString("idCardNo");
                string bankCardNo = DNTRequest.GetString("bankCardNo");
                string telNo = DNTRequest.GetString("telNo");
                string sign = DNTRequest.GetString("sign");
                string orderNo = DNTRequest.GetString("orderNo");
                string timeUnix = DNTRequest.GetString("timeUnix");
                string merchantsNo = DNTRequest.GetString("merchantsNo");
                string equipmentNo = DNTRequest.GetString("equipmentNo");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/BankCardSmsCode";
                string postParamters = string.Format("realName={0}&idCardNo={1}&bankCardNo={2}&telNo={3}&sign={4}&orderNo={5}&timeUnix={6}&consultId={7}&merchantsNo={8}&equipmentNo={9}&token={10}&sskdRequestParas={11}"
                    , realName, idCardNo, bankCardNo, telNo, sign, orderNo, timeUnix, consultId, merchantsNo, equipmentNo, token, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "发送银行手机验证码异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 验证银行手机短信
        /// <summary>
        /// 验证银行手机短信
        /// </summary>
        /// <returns></returns>
        static public Object BankCardSmsCodeCheck()
        {
            string result = string.Empty;
            try
            {
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

                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/BankCardSmsCodeCheck";
                string postParamters = string.Format("code={0}&bankCardId={1}&sign={2}&orderNo={3}&timeUnix={4}&consultId={5}&merchantsNo={6}&equipmentNo={7}&token={8}&sskdRequestParas={9}"
                    , code, bankCardId, sign, orderNo, timeUnix, consultId, merchantsNo, equipmentNo, token, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "验证银行手机短信异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 图片上传
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns></returns>
        static public Object ImagesUpload()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string base64Code = DNTRequest.GetString("base64Code");
                string sign = DNTRequest.GetString("sign");
                string orderNo = DNTRequest.GetString("orderNo");
                string equipmentNo = DNTRequest.GetString("equipmentNo");
                string merchantsNo = DNTRequest.GetString("merchantsNo");
                string token = DNTRequest.GetString("token");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                if (!string.IsNullOrEmpty(base64Code))
                {
                    base64Code = base64Code.Replace(" ", "+");
                    base64Code = base64Code.Replace(" ", "");
                }
                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/ImagesUpload";
                string postParamters = string.Format("netLoanApplyId={0}&base64Code={1}&token={2}&sign={3}&orderNo={4}&equipmentNo={5}&merchantsNo={6}&sskdRequestParas={7}"
                    , netLoanApplyId, base64Code, token, sign, orderNo, equipmentNo, merchantsNo, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "图片上传异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 检查身份认证是否成功

        /// <summary>
        /// 检查身份认证是否成功
        /// </summary>
        /// <returns></returns>
        static public Object CheckUserIsAuthentication()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string memberId = DNTRequest.GetString("memberId");
                string customerId = DNTRequest.GetString("customerId");
                string token = DNTRequest.GetString("token");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/CheckUserIsAuthentication";
                string postParamters = string.Format("netLoanApplyId={0}&memberId={1}&customerId={2}&token={3}&sskdRequestParas={4}", netLoanApplyId, memberId, customerId, token, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "身份证信息提交异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 提交采集的人像信息
        /// <summary>
        /// 提交采集的人像信息
        /// </summary>
        /// <returns></returns>
        static public Object SubmitIDInformation()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("consultId", -1);
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

                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/SubmitIDInformation";
                string postParamters = string.Format("sign={0}&faceIds={1}&idCardIds={2}&realName={3}&idCardNo={4}&sex={5}&birth={6}&national={7}&address={8}&authority={9}&validperiod={10}&netLoanApplyId={11}&token={12}&orderNo={13}&equipmentNo={14}&merchantsNo={15}&sskdRequestParas={16}"
                   , sign, faceIds, idCardIds, realName, idCardNo, sex, birth, national, address, authority, validperiod, netLoanApplyId, token, orderNo, equipmentNo, merchantsNo, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "提交采集的人像信息异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 获取证件号码库列表

        /// <summary>
        /// 获取证件号码库列表
        /// </summary>
        static public Object GetIdCardLibraryList()
        {
            string result = string.Empty;
            try
            {
                string sEcho = JsonRequest.GetJsonKeyVal(jsonText, "sEcho");
                int displayStart = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayStart"));
                int displayLength = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayLength"));
                int pageIndex = (displayStart / displayLength) + 1;
                int pageSize = displayLength;

                #region 获取列表
                StringBuilder where = new StringBuilder();
                where.Append("a.IsDeleted=0 ");
                //if (ComPage.CurrentAdmin.UserType != 1)
                //{
                //    where.Append("AND  a.UserID IN (select ID from [dbo].[GetChildrenRole](" + ComPage.CurrentAdmin.UserID + "))");
                //}

                #region 条件搜索

                #region 证件号码
                string identityCardNumber = DNTRequest.GetString("identityCardNumber");
                if (string.IsNullOrEmpty(identityCardNumber))
                {
                    identityCardNumber = JsonRequest.GetJsonKeyVal(jsonText, "identityCardNumber");
                    identityCardNumber = System.Web.HttpContext.Current.Server.UrlDecode(identityCardNumber);
                }
                if (!string.IsNullOrEmpty(identityCardNumber))
                {
                    where.AppendFormat(" and a.IdentityCardNumber like '%{0}%'", identityCardNumber);
                }
                #endregion

                #region 姓名
                string fullName = DNTRequest.GetString("fullName");
                if (string.IsNullOrEmpty(fullName))
                {
                    fullName = JsonRequest.GetJsonKeyVal(jsonText, "fullName");
                    fullName = System.Web.HttpContext.Current.Server.UrlDecode(fullName);
                }
                if (!string.IsNullOrEmpty(fullName))
                {
                    where.AppendFormat(" and a.[FullName] like '%{0}%'", fullName);
                }
                #endregion

                #region 民族
                string nation = DNTRequest.GetString("nation");
                if (string.IsNullOrEmpty(nation))
                {
                    nation = JsonRequest.GetJsonKeyVal(jsonText, "nation");
                    nation = System.Web.HttpContext.Current.Server.UrlDecode(nation);
                }
                if (!string.IsNullOrEmpty(nation))
                {
                    where.AppendFormat(" and a.[Nation] like '%{0}%'", nation);
                }
                #endregion

                #region 有效日期
                string effectedDate = DNTRequest.GetString("effectedDate");
                if (string.IsNullOrEmpty(effectedDate))
                {
                    effectedDate = JsonRequest.GetJsonKeyVal(jsonText, "effectedDate");
                    effectedDate = System.Web.HttpContext.Current.Server.UrlDecode(effectedDate);
                }
                if (!string.IsNullOrEmpty(effectedDate))
                {
                    where.AppendFormat(" and convert(varchar(10),a.EffectedDate,120)='{0}'", effectedDate);
                }
                #endregion

                #region 地址
                string address = DNTRequest.GetString("address");
                if (string.IsNullOrEmpty(address))
                {
                    address = JsonRequest.GetJsonKeyVal(jsonText, "address");
                    address = System.Web.HttpContext.Current.Server.UrlDecode(address);
                }
                if (!string.IsNullOrEmpty(address))
                {
                    where.AppendFormat(" and a.[Address] like '%{0}%'", address);
                }
                #endregion

                #region 发证机关
                string issuedAt = DNTRequest.GetString("issuedAt");
                if (string.IsNullOrEmpty(issuedAt))
                {
                    issuedAt = JsonRequest.GetJsonKeyVal(jsonText, "issuedAt");
                    issuedAt = System.Web.HttpContext.Current.Server.UrlDecode(issuedAt);
                }
                if (!string.IsNullOrEmpty(issuedAt))
                {
                    where.AppendFormat(" and a.IssuedAt like '%{0}%'", issuedAt);
                }
                #endregion

                #region 生日
                string birthDay = DNTRequest.GetString("birthDay");
                if (string.IsNullOrEmpty(birthDay))
                {
                    birthDay = JsonRequest.GetJsonKeyVal(jsonText, "birthDay");
                    birthDay = System.Web.HttpContext.Current.Server.UrlDecode(birthDay);
                }
                if (!string.IsNullOrEmpty(birthDay))
                {
                    where.AppendFormat(" and convert(varchar(10),a.BirthDay,120)='{0}'", birthDay);
                }
                #endregion

                #region 失效日期
                string expiredDate = DNTRequest.GetString("expiredDate");
                if (string.IsNullOrEmpty(expiredDate))
                {
                    expiredDate = JsonRequest.GetJsonKeyVal(jsonText, "expiredDate");
                    expiredDate = System.Web.HttpContext.Current.Server.UrlDecode(expiredDate);
                }
                if (!string.IsNullOrEmpty(expiredDate))
                {
                    where.AppendFormat(" and convert(varchar(10),a.ExpiredDate,120)='{0}'", expiredDate);
                }
                #endregion

                #region 来源
                string companyId = DNTRequest.GetString("companyId");
                if (string.IsNullOrEmpty(companyId))
                {
                    companyId = JsonRequest.GetJsonKeyVal(jsonText, "companyId");
                }
                if (!string.IsNullOrEmpty(companyId))
                {
                    where.AppendFormat(" and a.CompanyId={0}", companyId);
                }
                #endregion

                #region 性别
                string sex = DNTRequest.GetString("sex");
                if (string.IsNullOrEmpty(sex))
                {
                    sex = JsonRequest.GetJsonKeyVal(jsonText, "sex");
                }
                if (!string.IsNullOrEmpty(sex))
                {
                    where.AppendFormat(" and a.Sex={0}", sex);
                }
                #endregion

                #endregion

                string iSortCol_0 = JsonRequest.GetJsonKeyVal(jsonText, "iSortCol_0");
                string sSortDir_0 = JsonRequest.GetJsonKeyVal(jsonText, "sSortDir_0");
                int iSortingCols = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iSortingCols"));
                string orderBy = string.Empty;
                if (!string.IsNullOrEmpty(iSortCol_0))
                {
                    string orderField = JsonRequest.GetJsonKeyVal(jsonText, string.Format("mDataProp_{0}", iSortCol_0));
                    orderBy = string.Format(" {0} {1}", orderField, sSortDir_0);
                }

                string sql = "";
                int zys = 0;
                int sumcount = 0;
                IdCardLibraryBLL opIdCardLibraryBLL = new IdCardLibraryBLL();
                DataTable dt = opIdCardLibraryBLL.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
                object obj = new
                {
                    result = true,
                    code = "",
                    msg = "",
                    recordsTotal = sumcount,
                    recordsFiltered = sumcount,
                    data = ((dt == null) ? (new DataTable()) : (dt)),
                    sEcho = sEcho,
                };
                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                #endregion
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "获取证件号码信息失败", ex.Message);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 订单信息接收接口
        /// <summary>
        /// 订单信息接收接口
        /// </summary>
        /// <returns></returns>
        static public Object GetOrderInformation()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string taskId = DNTRequest.GetString("taskId");
                string telNo = DNTRequest.GetString("telNo");
                string smsCode = DNTRequest.GetString("smsCode");
                string token = DNTRequest.GetString("token");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/rt/it/ge";
                string postParamters = string.Format("netLoanApplyId={0}&taskId={1}&telNo={2}&smsCode={3}&token={4}&sskdRequestParas={5}"
                    , netLoanApplyId, taskId, telNo, smsCode, token, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "返回的数据", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 立即申请
        /// <summary>
        /// 网贷申请入库
        /// </summary>
        /// <returns></returns>
        static public Object InsertConsult()
        {
            string result = string.Empty;
            try
            {
                string Consult = DNTRequest.GetString("Consult");
                string token = DNTRequest.GetString("token");
                string equipmentNo = DNTRequest.GetString("equipmentNo");
                string merchantsNo = DNTRequest.GetString("merchantsNo");
                string base64Code = DNTRequest.GetString("base64Code");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                if (!string.IsNullOrEmpty(base64Code))
                {
                    base64Code = base64Code.Replace(" ", "+");
                }

                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/InsertConsult";
                string postParamters = string.Format("Consult={0}&token={1}&equipmentNo={2}&merchantsNo={3}&base64Code={4}&sskdRequestParas={5}"
                    , Consult, token, equipmentNo, merchantsNo, base64Code, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "申请借款入库异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region  填写信息
        /// <summary>
        /// 填写信息
        /// </summary>
        /// <returns></returns>
        static public Object FillInTheInformation()
        {
            string result = string.Empty;
            try
            {
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
                string array = DNTRequest.GetString("array");

                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/FillInTheInformation";
                string postParamters = string.Format("sskdRequestParas={0}&array={1}", sskdRequestParas, array);

                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region  自我描述信息入库
        /// <summary>
        /// 自我描述信息入库
        /// </summary>
        /// <returns></returns>
        static public Object UpdataConsult()
        {
            string result = string.Empty;
            try
            {
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
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/UpdataConsult";
                string postParamters = string.Format("ConsultId={0}&ProvinceId={1}&CityId={2}&DistrictId={3}&Area={4}&Address={5}&professionInfo={6}&identityInfo={7}&assetInfo={8}&sign={9}&orderNo={10}&array={11}&token={12}&equipmentNo={13}&merchantsNo={14}&sskdRequestParas={15}"
                    , ConsultId, ProvinceId, CityId, DistrictId, Area, Address, ProfessionInfo, IdentityInfo, AssetInfo, sign, orderNo, array, token, equipmentNo, merchantsNo, sskdRequestParas);


                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                if (!string.IsNullOrEmpty(outputJson))
                {
                    result = outputJson;
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应", null);
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 获取借款参数
        /// <summary>
        /// 获取借款参数
        /// </summary>
        /// <returns></returns>
        static public Object GetLoanParas()
        {
            string result = string.Empty;
            try
            {
                int ConsultId = DNTRequest.GetInt("ConsultId", -1);
                string orderNo = DNTRequest.GetString("orderNo");
                string sign = DNTRequest.GetString("sign");
                string timeUnix = DNTRequest.GetString("timeUnix");
                string equipmentNo = DNTRequest.GetString("equipmentNo");
                string merchantsNo = DNTRequest.GetString("merchantsNo");
                string token = DNTRequest.GetString("token");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/newxbwnapi/BorrowingOperation/GetLoanParas";
                string postParamters = string.Format("ConsultId={0}&orderNo={1}&sign={2}&timeUnix={3}&token={4}&equipmentNo={5}&merchantsNo={6}&sskdRequestParas={7}"
                    , ConsultId, orderNo, sign, timeUnix, token, equipmentNo, merchantsNo, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "获取借款参数异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 借款分期计算
        /// <summary>
        /// 借款分期计算
        /// </summary>
        /// <returns></returns>
        static public Object StagingCalculation()
        {
            string result = string.Empty;
            try
            {
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

                string apiUrl = loanApi + "/newxbwnapi/BorrowingOperation/StagingCalculation";
                string postParamters = string.Format("ConsultId={0}&orderNo={1}&sign={2}&timeUnix={3}&productId={4}&loanAmount={5}&token={6}&equipmentNo={7}&merchantsNo={8}&sskdRequestParas={9}"
                    , ConsultId, orderNo, sign, timeUnix, productId, loanAmount, token, equipmentNo, merchantsNo, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "借款分期计算异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 借款申请
        /// <summary>
        /// 借款申请
        /// </summary>
        /// <returns></returns>
        static public Object LoanApplication()
        {
            string result = string.Empty;
            try
            {
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

                string apiUrl = loanApi + "/newxbwnapi/BorrowingOperation/LoanApplication";
                string postParamters = string.Format("ConsultId={0}&orderNo={1}&sign={2}&bankCardNo={3}&productId={4}&loanAmount={5}&timeUnix={6}&token={7}&equipmentNo={8}&merchantsNo={9}&sskdRequestParas={10}"
                    , ConsultId, orderNo, sign, bankCardNo, productId, loanAmount, timeUnix, token, equipmentNo, merchantsNo, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "获取借款参数异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 商户授权放款 
        /// <summary>
        /// 商户授权放款
        /// </summary>
        static public Object ConfirmationOfAuthorization()
        {
            string result = string.Empty;
            try
            {
                int ConsultId = DNTRequest.GetInt("ConsultId", -1);
                string sign = DNTRequest.GetString("sign");
                string orderNo = DNTRequest.GetString("orderNo");
                string timeUnix = DNTRequest.GetString("timeUnix");
                string merchantsAcount = DNTRequest.GetString("merchantsAcount");
                string merchantsName = DNTRequest.GetString("merchantsName");
                string merchantsMobile = DNTRequest.GetString("merchantsMobile");
                string merchantsIdCardNo = DNTRequest.GetString("merchantsIdCardNo");
                string authorizedPassword = DNTRequest.GetString("authorizedPassword");
                string equipmentNo = DNTRequest.GetString("equipmentNo");
                string merchantsNo = DNTRequest.GetString("merchantsNo");
                string token = DNTRequest.GetString("token");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                if (string.IsNullOrEmpty(merchantsAcount))
                {
                    return DNTRequest.GetResultJsonForApi(false, "请输入授权账号", null);
                }
                if (string.IsNullOrEmpty(authorizedPassword))
                {
                    return DNTRequest.GetResultJsonForApi(false, "请输入授权密码", null);
                }
                if (string.IsNullOrEmpty(merchantsIdCardNo))
                {
                    return DNTRequest.GetResultJsonForApi(false, "请输入授权身份证号", null);
                }

                #region 商户信息验证
                if (!string.IsNullOrEmpty(merchantsAcount) && !string.IsNullOrEmpty(authorizedPassword) && !string.IsNullOrEmpty(merchantsIdCardNo))
                {
                    UsersBLL bll = new UsersBLL();
                    Users model = new Users();
                    string PwdKey = BLL.LinkFun.getPwdKey();
                    authorizedPassword = DESEncrypt.Encrypt(PwdKey, authorizedPassword);
                    Model.ReturnModel returnModel = bll.VerificationPassword(merchantsAcount, authorizedPassword, merchantsIdCardNo);
                    if (returnModel.IsSuccess)
                    {
                        model = bll.GetModel(ComPage.SafeToInt(returnModel.Data));
                        if (model != null)
                        {
                            merchantsAcount = model.LoginName;
                            merchantsMobile = model.Phone;
                            merchantsIdCardNo = model.CardID;
                            merchantsName = model.UserName;
                        }
                        string apiUrl = loanApi + "/newxbwnapi/Authorization/ConfirmationOfAuthorization";
                        string postParamters = string.Format("merchantsIdCardNo={0}&merchantsAcount={1}&merchantsMobile={2}&merchantsName={3}&ConsultId={4}&token={5}&sign={6}&orderNo={7}&timeUnix={8}&equipmentNo={9}&merchantsNo={10}&sskdRequestParas={11}"
                            , merchantsIdCardNo, merchantsAcount, merchantsMobile, merchantsName, ConsultId, token, sign, orderNo, timeUnix, equipmentNo, merchantsNo, sskdRequestParas);
                        string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);

                        result = outputJson;
                    }
                    else
                    {
                        result = DNTRequest.GetResultJsonForApi(false, returnModel.ErrMessage, null);
                    }
                }

                #endregion 商户信息验证

            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "商户授权放款异常，请稍后再试", null);
            }
            return result;
        }

        #endregion

        #region 授权认证
        /// <summary>
        /// 授权认证
        /// </summary>
        /// <returns></returns>
        static public Object Checkmcs()
        {
            string result = string.Empty;
            try
            {
                string sign = DNTRequest.GetString("sign");
                string realName = DNTRequest.GetString("realName");
                string idNo = DNTRequest.GetString("idNo");
                string consultId = DNTRequest.GetString("ConsultId");
                string orderNo = DNTRequest.GetString("orderNo");
                string telNo = DNTRequest.GetString("telNo");
                string typeId = DNTRequest.GetString("typeId");
                string equipmentNo = DNTRequest.GetString("equipmentNo");
                string merchantsNo = DNTRequest.GetString("merchantsNo");
                string objId = DNTRequest.GetString("objId");
                string returnUrl = webappurl + "/Product/NewSSKD/AuthorizationCertification?objId=" + objId;
                string token = DNTRequest.GetString("token");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/newxbwnapi/Authorization/Checkmcs";
                string postParamters = string.Format("sign={0}&realName={1}&idNo={2}&returnUrl={3}&ConsultId={4}&orderNo={5}&telNo={6}&TypeId={7}&token={8}&equipmentNo={9}&merchantsNo={10}&sskdRequestParas={11}"
                    , sign, realName, idNo, returnUrl, consultId, orderNo, telNo, typeId, token, equipmentNo, merchantsNo, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "验证手机运营商异常，请稍后再试", null);
            }
            return result;
        }

        #endregion

        #region 用户报告
        /// <summary>
        /// 用户报告
        /// </summary>
        /// <returns></returns>
        static public Object AppraisalReport()
        {
            string result = string.Empty;
            try
            {
                string ConsultId = DNTRequest.GetString("ConsultId");
                string sign = DNTRequest.GetString("sign");
                string orderNo = DNTRequest.GetString("orderNo");
                string timeUnix = DNTRequest.GetString("timeUnix");
                string reportType = DNTRequest.GetString("reportType");
                string equipmentNo = DNTRequest.GetString("equipmentNo");
                string merchantsNo = DNTRequest.GetString("merchantsNo");
                string token = DNTRequest.GetString("token");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/newxbwnapi/BorrowersReport/AppraisalReport";
                string postParamters = string.Format("ConsultId={0}&orderNo={1}&sign={2}&timeUnix={3}&reportType={4}&token={5}&equipmentNo={6}&merchantsNo={7}&bwjsApi={8}&sskdRequestParas={9}"
                    , ConsultId, orderNo, sign, timeUnix, reportType, token, equipmentNo, merchantsNo, loanApi, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "获取用户报告异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 设备信息
        /// <summary>
        /// 设备信息
        /// </summary>
        /// <returns></returns>
        static public Object SetEquipmentCapture()
        {
            string result = string.Empty;
            try
            {
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/newxbwnapi/ContactManager/EquipmentCapture";
                string postParamters = string.Format("sskdRequestParas={0}", sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "设置设备信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 商户信息
        /// <summary>
        /// 商户信息
        /// </summary>
        /// <returns></returns>
        static public Object SetMerchantCapture()
        {
            string result = string.Empty;
            try
            {
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/newxbwnapi/ContactManager/MerchantCapture";
                string postParamters = string.Format("sskdRequestParas={0}", sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "设置商户信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 设备商户关联信息
        /// <summary>
        /// 设备商户关联信息
        /// </summary>
        /// <returns></returns>
        static public Object EquipmentMerchantRelation()
        {
            string result = string.Empty;
            try
            {
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/newxbwnapi/ContactManager/EquipmentMerchantRelation";
                string postParamters = string.Format("sskdRequestParas={0}", sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "设置设备商户关联信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        static public Object GetaInformation()
        {
            string result = string.Empty;
            try
            {
                string idNo = DNTRequest.GetString("idNo");
                string Mobile = DNTRequest.GetString("Mobile");
                string FullName = DNTRequest.GetString("FullName");
                string token = DNTRequest.GetString("token");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");


                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/GetaInformation";
                string postParamters = string.Format("idNo={0}&Mobile={1}&FullName={2}&token={3}&sskdRequestParas={4}", idNo, Mobile, FullName, token, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "获取借款参数异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;

        }

        #region 认证进度查询
        /// <summary>
        /// 认证进度查询
        /// </summary>
        static public Object GetRzjd()
        {
            string result = string.Empty;

            try
            {
                string consultId = DNTRequest.GetString("consultId");
                string orderNo = DNTRequest.GetString("orderNo");
                string equipmentNo = DNTRequest.GetString("equipmentNo");
                string merchantsNo = DNTRequest.GetString("merchantsNo");
                string sign = DNTRequest.GetString("sign");
                string token = DNTRequest.GetString("token");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/GetRzjd";
                string postParamters = string.Format("orderNo={0}&equipmentNo={1}&merchantsNo={2}&sign={3}&token={4}&consultId={5}&sskdRequestParas={6}"
                    , orderNo, equipmentNo, merchantsNo, sign, token, consultId, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "认证结果查询异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region Base64解密
        /// <summary>
        /// Base64解密
        /// </summary>
        /// <returns></returns>
        static public Object Base64Decode()
        {
            string result = string.Empty;
            try
            {
                string base64Code = DNTRequest.GetString("base64Code");
                if (!string.IsNullOrEmpty(base64Code))
                {
                    string base64DecodeString = Utils.base64Decode(base64Code);
                    result = DNTRequest.GetResultJsonForApi(true, "success，", base64DecodeString);
                }
                else
                {
                    return DNTRequest.GetResultJsonForApi(false, "Base64加密字符串不能为空", null);
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "Base64解密异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;

        }

        #endregion

        #region 贷款状态变更
        /// <summary>
        /// 贷款状态变更
        /// </summary>
        /// <returns></returns>
        static public Object ApplyStatusChange()
        {
            string result = string.Empty;
            try
            {
                string consultId = DNTRequest.GetString("consultId");
                int status = DNTRequest.GetInt("status", -1);
                int prevStatus = DNTRequest.GetInt("prevStatus", -1);
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
                if (string.IsNullOrEmpty(consultId))
                {
                    return DNTRequest.GetResultJsonForApi(false, "未获取到贷款申请编号", null);
                }

                string sskdModel = JsonConvert.SerializeObject(BasePage.sskdModel);

                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/ApplyStatusChange";
                string postParamters = string.Format("consultId={0}&status={1}&prevStatus={2}&sskdModel={3}&sskdRequestParas={4}"
                    , consultId, status, prevStatus, sskdModel, sskdRequestParas);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "贷款状态变更异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 百度IP定位当前位置信息
        /// <summary>
        /// 百度IP定位当前位置信息
        /// </summary>
        static public Object GetLocationJson()
        {
            string result = string.Empty;
            try
            {
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
                string locationJson = MachineLocationLogBLL.GetLocationInfo();
                result = locationJson;
                //string apiUrl = loanApi + "/newxbwnapi/LoanApplication/GetLocationJson";
                //string postParamters = string.Format("locationJson={0}&sskdRequestParas={1}", locationJson, sskdRequestParas);
                //string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                //result = outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "百度IP定位当前位置信息异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 逆地址解析
        /// <summary>
        /// 逆地址解析
        /// </summary>
        static public Object GetAddressByLocation()
        {
            string result = string.Empty;
            try
            {
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
                string longitude = DNTRequest.GetString("longitude");
                string latitude = DNTRequest.GetString("latitude");
                string output = DNTRequest.GetString("output");
                int pois = DNTRequest.GetInt("pois", 0);

                string locationJson = MachineLocationLogBLL.GetAddressByLocation(longitude, latitude, output, pois);
                result = locationJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "逆地址解析异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 获取省市区

        /// <summary>
        /// 获取省市区
        /// </summary>
        static public Object GetRegion()
        {
            string result = string.Empty;
            try
            {
                int parentId = DNTRequest.GetInt("parentId", -1);
                if (parentId != -1)
                {
                    CityAreaBLL bll = new CityAreaBLL();
                    List<CityArea> modelList = bll.GetCityAreaAllList(parentId);
                    if (modelList.Count > 0)
                    {
                        result = DNTRequest.GetResultJsonForApi(true, "success", modelList);
                    }
                    else
                    {
                        result = DNTRequest.GetResultJsonForApi(false, "未获取到省市区信息", null);
                    }
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "请传递父编号", null);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "获取省市区异常，请稍候再试", null);
            }
            return result;
        }
        #endregion

        #region 获取字典

        /// <summary>
        /// 获取字典
        /// </summary>
        static public Object GetConfigList()
        {
            string result = string.Empty;
            try
            {
                string typeName = DNTRequest.GetString("typeName");
                if (!string.IsNullOrEmpty(typeName))
                {
                    NLLoanConfigBLL bll = new NLLoanConfigBLL();
                    List<NLLoanConfig> modelList = bll.GetConfigList(typeName);
                    if (modelList.Count > 0)
                    {
                        result = DNTRequest.GetResultJsonForApi(true, "success", modelList);
                    }
                    else
                    {
                        result = DNTRequest.GetResultJsonForApi(false, "未获取到获取字典信息", null);
                    }
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "请传递父编号", null);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "获取字典异常，请稍候再试", null);
            }
            return result;
        }
        #endregion

        #region 房贷申请
        /// <summary>
        /// 房贷申请
        /// </summary>
        /// <returns></returns>

        static public Object HousingLoanApply()
        {
            string result = string.Empty;
            try
            {
                //身份证号码库主键
                int identityCardLibraryId = 0;

                string objNetLoanApply = DNTRequest.GetString("modelNetLoanApply");
                NetLoanApply postNetLoanApply = JsonConvert.DeserializeObject<NetLoanApply>(objNetLoanApply);

                #region 只有身份证申请才记录到身份证号码库
                if (postNetLoanApply.IdCardType == 1)
                {
                    string objIdentityCardLibrary = DNTRequest.GetString("modelIdentityCardLibrary");
                    IdentityCardLibrary postIdentityCardLibrary = JsonConvert.DeserializeObject<IdentityCardLibrary>(objIdentityCardLibrary);

                    byte[] idPhoto = new byte[0];

                    IdCardLibraryBLL opIdCardLibraryBLL = new IdCardLibraryBLL();
                    IdentityCardLibrary modelIdentityCardLibrary = new IdentityCardLibrary();
                    modelIdentityCardLibrary.CompanyId = postIdentityCardLibrary.CompanyId;
                    modelIdentityCardLibrary.IdentityCardNumber = postIdentityCardLibrary.IdentityCardNumber;
                    modelIdentityCardLibrary.FullName = postIdentityCardLibrary.FullName;
                    modelIdentityCardLibrary.Sex = postIdentityCardLibrary.Sex;
                    modelIdentityCardLibrary.Nation = postIdentityCardLibrary.Nation;
                    if (postIdentityCardLibrary.BirthDay.ToString() != "1900/1/1 0:00:00")
                    {
                        modelIdentityCardLibrary.BirthDay = postIdentityCardLibrary.BirthDay;
                    }
                    modelIdentityCardLibrary.Address = postIdentityCardLibrary.Address;
                    modelIdentityCardLibrary.IssuedAt = postIdentityCardLibrary.IssuedAt;
                    if (postIdentityCardLibrary.EffectedDate.ToString() != "1900/1/1 0:00:00")
                    {
                        modelIdentityCardLibrary.EffectedDate = postIdentityCardLibrary.EffectedDate;
                    }
                    if (postIdentityCardLibrary.ExpiredDate.ToString() != "1900/1/1 0:00:00")
                    {
                        modelIdentityCardLibrary.ExpiredDate = postIdentityCardLibrary.ExpiredDate;
                    }
                    modelIdentityCardLibrary.IdentityCardPhoto = idPhoto;
                    modelIdentityCardLibrary.IdentityCardPhotoPath = postIdentityCardLibrary.IdentityCardPhotoPath;
                    modelIdentityCardLibrary.IdentityCardPhotoData = postIdentityCardLibrary.IdentityCardPhotoData;
                    modelIdentityCardLibrary.IdentityCardData = postIdentityCardLibrary.IdentityCardData;
                    modelIdentityCardLibrary.CreateId = ComPage.CurrentUser.UserID;
                    modelIdentityCardLibrary.CreateDate = DateTime.Now;
                    modelIdentityCardLibrary.IsDeleted = 0;

                    string fullName = modelIdentityCardLibrary.FullName;
                    int sex = modelIdentityCardLibrary.Sex;
                    string identityCardNumber = modelIdentityCardLibrary.IdentityCardNumber;
                    string address = modelIdentityCardLibrary.Address;
                    string issuedAt = modelIdentityCardLibrary.IssuedAt;
                    string effectedDate = modelIdentityCardLibrary.EffectedDate.ToString();
                    string expiredDate = modelIdentityCardLibrary.ExpiredDate.ToString();

                    identityCardLibraryId = opIdCardLibraryBLL.Exists(fullName, sex, identityCardNumber, address, issuedAt, effectedDate, expiredDate);
                    if (identityCardLibraryId == 0 && !string.IsNullOrEmpty(modelIdentityCardLibrary.IdentityCardPhotoData))//有头像才入库
                    {
                        identityCardLibraryId = opIdCardLibraryBLL.Add(modelIdentityCardLibrary);
                    }
                }
                #endregion

                #region 自动获取设备信息
                MachineBLL opMachineBLL = new MachineBLL();
                Machine modelMachine = opMachineBLL.GetModelByUserId(ComPage.CurrentUser.UserID);
                #endregion

                #region 网贷申请
                NetLoanApplyBLL opNetLoanApplyBLL = new NetLoanApplyBLL();
                NetLoanApply modelNetLoanApply = new NetLoanApply();
                modelNetLoanApply.UserId = ComPage.CurrentUser.UserID;
                modelNetLoanApply.CompanyId = postNetLoanApply.CompanyId;
                modelNetLoanApply.SN = (modelMachine != null) ? (modelMachine.SN) : (string.Empty);
                modelNetLoanApply.IdCardLibraryId = identityCardLibraryId;
                modelNetLoanApply.FullName = postNetLoanApply.FullName;
                modelNetLoanApply.IdCardType = postNetLoanApply.IdCardType;
                modelNetLoanApply.IdCard = postNetLoanApply.IdCard;
                modelNetLoanApply.Sex = postNetLoanApply.Sex;
                modelNetLoanApply.Mobile = postNetLoanApply.Mobile;
                modelNetLoanApply.RecommendationCode = postNetLoanApply.RecommendationCode;
                modelNetLoanApply.Remark = string.Empty;
                modelNetLoanApply.Status = 0;
                modelNetLoanApply.IsDeleted = 0;
                modelNetLoanApply.CreateDate = DateTime.Now;
                modelNetLoanApply.IsSettled = 0;
                int netLoanApplyId = opNetLoanApplyBLL.Add(modelNetLoanApply);
                if (netLoanApplyId > 0)
                {
                    result = DNTRequest.GetResultJsonForApi(true, "房贷申请成功", netLoanApplyId);
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "房贷申请失败，请稍后再试", null);
                }
                #endregion

            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "房贷申请异常，请稍后再试", null);
            }
            return result;
        }

        #endregion

        #region 订单认证进度
        /// <summary>
        /// 订单认证进度
        /// </summary>
        static public Object OrderAuthenticationProgressQuery()
        {
            string result = string.Empty;

            try
            {
                string telNo = DNTRequest.GetString("telNo");
                string idCardNo = DNTRequest.GetString("idCardNo");
                string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

                string apiUrl = loanApi + "/newxbwnapi/LoanApplication/OrderAuthenticationProgressQuery";
                string postParamters = string.Format("sskdRequestParas={0}&telNo={1}&idCardNo={2}", sskdRequestParas, telNo, idCardNo);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "订单认证进度查询异常，请稍后再试", null);
            }
            return result;
        }
        #endregion
    }

}