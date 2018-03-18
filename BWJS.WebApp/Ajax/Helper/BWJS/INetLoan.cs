using Mofang.Model;
using Mofang.BLL;
using Newtonsoft.Json;
using BWJS.AppCode;
using BWJSLog.BLL;
using BWJS.Model;
using BWJS.BLL;
using UtilityHelper;
using MofangInterface.BLL;
using MofangInterface.Model.InputModel;
using MofangInterface.Model.OutputModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;
using XBWN.Model;
using XBWN.BLL;
using Newtonsoft.Json.Linq;

namespace BWJS.WebApp.Ajax.Helper.BWJS
{
    /// <summary>
    /// 网贷
    /// </summary>
    public class INetLoan
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
        static string loanApi = CommonHelper.GetAppSettingsValue("loanApi", "http://192.168.1.8:84");
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
                    case "getidcardmodel":
                        HttpContext.Current.Response.Write(GetIdCardModel());
                        break;
                    case "getnetloan":
                        HttpContext.Current.Response.Write(GetNetLoanApplyList());
                        break;
                    case "getnetloanmodel":
                        HttpContext.Current.Response.Write(GetNetLoanApplyModel());
                        break;
                    case "getidcardtype":
                        HttpContext.Current.Response.Write(GetIdCardTypeList());
                        break;
                    case "idcardlibraryadd":
                        HttpContext.Current.Response.Write(IdCardLibraryIdAdd());
                        break;
                    case "companylist":
                        HttpContext.Current.Response.Write(GetCompanyList());
                        break;
                    case "checkmonbileisregister":
                        HttpContext.Current.Response.Write(CheckMonbileIsRegister());
                        break;
                    case "getmonbilesmscode":
                        HttpContext.Current.Response.Write(GetMonbileSmsCode());
                        break;
                    case "memerregister":
                        HttpContext.Current.Response.Write(MemerRegister());
                        break;
                    case "memersignin":
                        HttpContext.Current.Response.Write(MemerSignIn());
                        break;
                    case "bankcardlist":
                        HttpContext.Current.Response.Write(GetBankCardList());
                        break;
                    case "bankcardlistby":
                        HttpContext.Current.Response.Write(GetBankCardListBy());
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
                    case "imagesupload":
                        HttpContext.Current.Response.Write(ImagesUpload());
                        break;
                    case "submitidinformation":
                        HttpContext.Current.Response.Write(SubmitIDInformation());
                        break;
                    case "checkuserisauthentication":
                        HttpContext.Current.Response.Write(CheckUserIsAuthentication());
                        break;
                    case "taskcreate":
                        HttpContext.Current.Response.Write(TaskCreate());
                        break;
                    case "sendoperatorsmscode":
                        HttpContext.Current.Response.Write(SendOperatorSmsCode());
                        break;
                    case "sendoperatorimgcode":
                        HttpContext.Current.Response.Write(SendOperatorImgCode());
                        break;
                    case "getloanparas":
                        HttpContext.Current.Response.Write(GetLoanParas());
                        break;
                    case "submitloanapply":
                        HttpContext.Current.Response.Write(SubmitLoanApply());
                        break;
                    case "confirmationloanapply":
                        HttpContext.Current.Response.Write(ConfirmationLoanApply());
                        break;
                    case "comprehensivequery":
                        HttpContext.Current.Response.Write(ComprehensiveQuery());
                        break;
                    case "borrowingstatequery":
                        HttpContext.Current.Response.Write(BorrowingStateQuery());
                        break;
                    case "fetchrong360":
                        HttpContext.Current.Response.Write(FetchRong360());
                        break;
                    case "confirmationofauthorization":
                        HttpContext.Current.Response.Write(ConfirmationOfAuthorization());
                        break;
               
                        
                }

                #endregion
            }
        }

        #region 获取证件号码库管理

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
                result = DNTRequest.GetResultJson(false, "获取证件号码信息失败", ex.Message);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 获取证件号码库详情
        /// <summary>
        /// 获取证件号码库详情
        /// </summary>
        static public Object GetIdCardModel()
        {
            string result = string.Empty;
            try
            {
                int identityCardLibraryId = DNTRequest.GetInt("identityCardLibraryId", 0);
                if (identityCardLibraryId == 0)
                {
                    result = DNTRequest.GetResultJson(false, "获取获取证件号码信息失败,请稍后再试", null);
                }
                IdCardLibraryBLL op = new IdCardLibraryBLL();
                IdentityCardLibrary model = new IdentityCardLibrary();
                if (identityCardLibraryId != 0)
                {
                    model = op.GetModel(identityCardLibraryId);
                }
                result = DNTRequest.GetResultJson(true, "success", model);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取获取证件号码信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 证件号码库新增记录
        /// <summary>
        /// 证件号码库新增记录
        /// </summary>
        /// <returns></returns>

        static public Object IdCardLibraryIdAdd()
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
                    result = DNTRequest.GetResultJson(true, "身份认证成功", netLoanApplyId);
                }
                else
                {
                    result = DNTRequest.GetResultJson(false, "身份认证失败，请稍后再试", null);
                }
                #endregion

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "身份认证异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #endregion

        #region 获取网贷申请管理

        #region 获取网贷申请列表

        /// <summary>
        /// 获取网贷申请列表
        /// </summary>
        static public Object GetNetLoanApplyList()
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

                #region 条件搜索
                StringBuilder where = new StringBuilder();
                where.Append("a.IsDeleted=0 ");

                #region 权限
                DepartmentInfo df = new DepartmentInfo();
                DepartmentInfoBLL bll = new DepartmentInfoBLL();
                df = bll.GetModel(ComPage.CurrentAdmin.DepartmentID);
                if (ComPage.CurrentAdmin.UserType != 1)
                {
                    if ((df == null) || (df != null && df.IsReceiveBusiness != false))
                    {
                        where.Append(" AND  a.UserId IN(select ID from [dbo].[GetDepartmentChildren](" + ComPage.CurrentAdmin.UserID + "))");
                    }
                }
                #endregion

                #region 渠道类别
                string companyCategory = DNTRequest.GetString("companyCategory");
                if (string.IsNullOrEmpty(companyCategory))
                {
                    companyCategory = JsonRequest.GetJsonKeyVal(jsonText, "companyCategory");
                }
                if (!string.IsNullOrEmpty(companyCategory))
                {
                    where.AppendFormat(" AND d.[CompanyCategoryId]={0} ", companyCategory);
                }
                #endregion

                #region 申请状态
                string status = DNTRequest.GetString("status");
                if (string.IsNullOrEmpty(status))
                {
                    status = JsonRequest.GetJsonKeyVal(jsonText, "status");
                }
                if (!string.IsNullOrEmpty(status))
                {
                    where.AppendFormat(" AND a.[Status]={0} ", status);
                }
                #endregion

                #region 结算状态
                string isSettled = DNTRequest.GetString("isSettled");
                if (string.IsNullOrEmpty(isSettled))
                {
                    isSettled = JsonRequest.GetJsonKeyVal(jsonText, "isSettled");
                }
                if (!string.IsNullOrEmpty(isSettled))
                {
                    where.AppendFormat(" AND a.[isSettled]={0} ", isSettled);
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
                    where.AppendFormat(" AND a.[FullName] like '%{0}%'", fullName);
                }
                #endregion

                #region 证件号码
                string idCard = DNTRequest.GetString("idCard");
                if (string.IsNullOrEmpty(idCard))
                {
                    idCard = JsonRequest.GetJsonKeyVal(jsonText, "idCard");
                    idCard = System.Web.HttpContext.Current.Server.UrlDecode(idCard);
                }
                if (!string.IsNullOrEmpty(idCard))
                {
                    where.AppendFormat(" AND a.[IdCard] like '%{0}%'", idCard);
                }
                #endregion

                #region 手机号码
                string mobile = DNTRequest.GetString("mobile");
                if (string.IsNullOrEmpty(mobile))
                {
                    mobile = JsonRequest.GetJsonKeyVal(jsonText, "mobile");
                    mobile = System.Web.HttpContext.Current.Server.UrlDecode(mobile);
                }
                if (!string.IsNullOrEmpty(mobile))
                {
                    where.AppendFormat(" AND a.[Mobile] like '%{0}%'", mobile);
                }
                #endregion

                #region 推荐码
                string recommendationCode = DNTRequest.GetString("recommendationCode");
                if (string.IsNullOrEmpty(recommendationCode))
                {
                    recommendationCode = JsonRequest.GetJsonKeyVal(jsonText, "recommendationCode");
                    recommendationCode = System.Web.HttpContext.Current.Server.UrlDecode(recommendationCode);
                }
                if (!string.IsNullOrEmpty(recommendationCode))
                {
                    where.AppendFormat(" AND a.[RecommendationCode] like '%{0}%'", recommendationCode);
                }
                #endregion

                #region 申请金额
                string applicationAmount = DNTRequest.GetString("applicationAmount");
                if (string.IsNullOrEmpty(applicationAmount))
                {
                    applicationAmount = JsonRequest.GetJsonKeyVal(jsonText, "applicationAmount");
                    applicationAmount = System.Web.HttpContext.Current.Server.UrlDecode(applicationAmount);
                }
                if (!string.IsNullOrEmpty(applicationAmount))
                {
                    where.AppendFormat(" AND a.[ApplicationAmount] = {0}", applicationAmount);
                }
                #endregion

                #region 放款金额
                string loanAmount = DNTRequest.GetString("loanAmount");
                if (string.IsNullOrEmpty(loanAmount))
                {
                    loanAmount = JsonRequest.GetJsonKeyVal(jsonText, "loanAmount");
                    loanAmount = System.Web.HttpContext.Current.Server.UrlDecode(loanAmount);
                }
                if (!string.IsNullOrEmpty(loanAmount))
                {
                    where.AppendFormat(" AND a.[LoanAmount] = {0}", loanAmount);
                }
                #endregion

                #region 申请期限
                string loanTerm = DNTRequest.GetString("loanTerm");
                if (string.IsNullOrEmpty(loanTerm))
                {
                    loanTerm = JsonRequest.GetJsonKeyVal(jsonText, "loanTerm");
                    loanTerm = System.Web.HttpContext.Current.Server.UrlDecode(loanTerm);
                }
                if (!string.IsNullOrEmpty(loanTerm))
                {
                    where.AppendFormat(" AND a.[loanTerm] = {0}", loanTerm);
                }
                #endregion

                #region 申请产品名
                string productName = DNTRequest.GetString("productName");
                if (string.IsNullOrEmpty(productName))
                {
                    productName = JsonRequest.GetJsonKeyVal(jsonText, "productName");
                    productName = System.Web.HttpContext.Current.Server.UrlDecode(productName);
                }
                if (!string.IsNullOrEmpty(productName))
                {
                    where.AppendFormat(" AND a.[ProductName] like '%{0}%'", productName);
                }
                #endregion

                #region 所属商家
                string merchantName = DNTRequest.GetString("merchantName");
                if (string.IsNullOrEmpty(merchantName))
                {
                    merchantName = JsonRequest.GetJsonKeyVal(jsonText, "merchantName");
                    merchantName = System.Web.HttpContext.Current.Server.UrlDecode(merchantName);
                }
                if (!string.IsNullOrEmpty(merchantName))
                {
                    where.AppendFormat(" AND b.[UserName] like '%{0}%'", merchantName);
                }
                #endregion

                #region 渠道
                string companyName = DNTRequest.GetString("companyName");
                if (string.IsNullOrEmpty(companyName))
                {
                    companyName = JsonRequest.GetJsonKeyVal(jsonText, "companyName");
                    companyName = System.Web.HttpContext.Current.Server.UrlDecode(companyName);
                }
                if (!string.IsNullOrEmpty(companyName))
                {
                    where.AppendFormat(" AND d.[CompanyName] like '%{0}%'", companyName);
                }
                #endregion

                #region 产品
                string mainBusiness = DNTRequest.GetString("mainBusiness");
                if (string.IsNullOrEmpty(mainBusiness))
                {
                    mainBusiness = JsonRequest.GetJsonKeyVal(jsonText, "mainBusiness");
                    mainBusiness = System.Web.HttpContext.Current.Server.UrlDecode(mainBusiness);
                }
                if (!string.IsNullOrEmpty(mainBusiness))
                {
                    where.AppendFormat(" AND d.[MainBusiness] like '%{0}%'", mainBusiness);
                }
                #endregion

                #region 排序
                string iSortCol_0 = JsonRequest.GetJsonKeyVal(jsonText, "iSortCol_0");
                string sSortDir_0 = JsonRequest.GetJsonKeyVal(jsonText, "sSortDir_0");
                int iSortingCols = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iSortingCols"));
                string orderBy = string.Empty;
                if (!string.IsNullOrEmpty(iSortCol_0))
                {
                    string orderField = JsonRequest.GetJsonKeyVal(jsonText, string.Format("mDataProp_{0}", iSortCol_0));
                    orderBy = string.Format(" {0} {1}", orderField, sSortDir_0);
                }
                #endregion

                #region 执行sql
                string sql = "";
                int zys = 0;
                int sumcount = 0;
                NetLoanApplyBLL opNetLoanApplyBLL = new NetLoanApplyBLL();
                DataTable dt = opNetLoanApplyBLL.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
                #endregion

                #region 结果组装
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
                #endregion

                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取网贷申请信息失败", ex.Message);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 获取网贷申请详情
        /// <summary>
        /// 获取网贷申请详情
        /// </summary>
        static public Object GetNetLoanApplyModel()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", 0);
                if (netLoanApplyId == 0)
                {
                    result = DNTRequest.GetResultJson(false, "获取获取网贷申请信息失败,请稍后再试", null);
                }
                NetLoanApplyBLL op = new NetLoanApplyBLL();
                NetLoanApply model = new NetLoanApply();
                if (netLoanApplyId != 0)
                {
                    model = op.GetModel(netLoanApplyId);
                }
                result = DNTRequest.GetResultJson(true, "success", model);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取获取网贷申请信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #endregion

        #region 获取证件类型列表

        /// <summary>
        /// 获取证件类型列表
        /// </summary>
        static public Object GetIdCardTypeList()
        {
            string result = string.Empty;
            try
            {
                CardTypeBLL op = new CardTypeBLL();
                List<CardType> list = op.GetModelList(string.Empty);
                result = DNTRequest.GetResultJson(true, "success", list);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取证件类型异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 获取渠道列表
        /// <summary>
        /// 获取渠道列表
        /// </summary>
        static public Object GetCompanyList()
        {
            string result = string.Empty;
            try
            {
                int companyCategoryId = DNTRequest.GetInt("companyCategoryId", -1);
                int pageIndex = DNTRequest.GetInt("pageIndex", 1);
                int pageSize = DNTRequest.GetInt("pageSize", 10);
                string functionName = DNTRequest.GetString("functionName");
                string list = string.Empty;
                string tablesql = string.Format("select * from dbo.[Company]");
                string where = "IsDeleted=0";
                if (companyCategoryId != -1)
                {
                    where += string.Format(" and CompanyCategoryId={0}", companyCategoryId);
                }
                int zys = 0;
                int sumcount = 0;
                string sql = string.Empty;
                string orderby = "OrderId asc";
                CompanyBLL op = new CompanyBLL();
                DataTable dt = op.GetList(tablesql, where, pageIndex, pageSize, orderby, ref sql, ref zys, ref sumcount);
                string pageHtml = ComPage.SetPageHtml(zys, sumcount, pageIndex, functionName);
                var obj = new
                {
                    list = ((dt == null) ? (new DataTable()) : (dt)),
                    pageHtml = pageHtml,
                    pageIndex = pageIndex
                };
                result = DNTRequest.GetResultJson(true, "success", obj);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取渠道列表异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        
        #region 闪速快贷

        #region 验证手机是否注册
        /// <summary>
        /// 验证手机是否注册
        /// </summary>
        /// <returns></returns>
        static public Object CheckMonbileIsRegister()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string telNo = DNTRequest.GetString("telNo");
                string apiUrl = loanApi + "/xbwnapi/Loan/CheckMonbileIsRegister";
                string postParamters = string.Format("netLoanApplyId={0}&telNo={1}", netLoanApplyId, telNo);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);

                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "验证手机是否注册异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 发送手机验证码
        /// <summary>
        /// 发送手机验证码
        /// </summary>
        /// <returns></returns>
        static public Object GetMonbileSmsCode()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string telNo = DNTRequest.GetString("telNo");
                string apiUrl = loanApi + "/xbwnapi/Loan/GetMonbileSmsCode";
                string postParamters = string.Format("netLoanApplyId={0}&telNo={1}", netLoanApplyId, telNo);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "发送手机验证码异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 会员注册
        /// <summary>
        /// 会员注册
        /// </summary>
        /// <returns></returns>
        static public Object MemerRegister()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string telNo = DNTRequest.GetString("telNo");
                string password = DNTRequest.GetString("password");
                string inviteCode = DNTRequest.GetString("inviteCode");
                string smsCode = DNTRequest.GetString("smsCode");
                string apiUrl = loanApi + "/xbwnapi/Loan/MemerRegister";
                string postParamters = string.Format("netLoanApplyId={0}&telNo={1}&password={2}&inviteCode={3}&smsCode={4}", netLoanApplyId, telNo, password, inviteCode, smsCode);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "会员注册异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 会员登录
        /// <summary>
        /// 会员登录
        /// </summary>
        /// <returns></returns>
        static public Object MemerSignIn()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string telNo = DNTRequest.GetString("telNo");
                string password = DNTRequest.GetString("password");
                string smsCode = DNTRequest.GetString("smsCode");
                string apiUrl = loanApi + "/xbwnapi/Loan/MemerSignIn";
                string postParamters = string.Format("netLoanApplyId={0}&telNo={1}&password={2}&smsCode={3}", netLoanApplyId, telNo, password, smsCode);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "会员登录异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 获取银行卡列表

        #region 获取银行卡列表从数据库

        /// <summary>
        /// 获取银行卡列表从数据库
        /// </summary>
        static public Object GetBankCardListBy()
        {
            string result = string.Empty;
            try
            {
                string realName = DNTRequest.GetString("realName");
                string idNo = DNTRequest.GetString("idNo");
                string telNo = DNTRequest.GetString("telNo");
                int flag = DNTRequest.GetInt("flag", 0);
                xbwn_UserBankBLL op = new xbwn_UserBankBLL();
                xbwn_UserBank model = op.GetModel(realName, idNo, telNo, flag);
                if (model != null)
                {
                    result = DNTRequest.GetResultJson(true, "success", model);
                }
                else
                {
                    result = DNTRequest.GetResultJson(false, "未找到提现卡信息", null);
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取银行卡列表异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        /// <summary>
        /// 获取银行卡列表
        /// </summary>
        /// <returns></returns>
        static public Object GetBankCardList()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string token = DNTRequest.GetString("token");
                string apiUrl = loanApi + "/xbwnapi/Loan/GetBankCardList";
                string postParamters = string.Format("netLoanApplyId={0}&token={1}", netLoanApplyId, token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取银行卡列表异常，请稍后再试", null);
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
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string realName = DNTRequest.GetString("realName");
                string idNo = DNTRequest.GetString("idNo");
                string bankCardNo = DNTRequest.GetString("bankCardNo");
                string telNo = DNTRequest.GetString("telNo");
                int cash = DNTRequest.GetInt("cash", 0);
                string token = DNTRequest.GetString("token");
                string apiUrl = loanApi + "/xbwnapi/Loan/BankCardAdd";
                string postParamters = string.Format("netLoanApplyId={0}&realName={1}&idNo={2}&bankCardNo={3}&telNo={4}&cash={5}&token={6}"
                    , netLoanApplyId, realName, idNo, bankCardNo, telNo, cash, token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "添加银行异常，请稍后再试", null);
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
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string no = DNTRequest.GetString("no");
                string token = DNTRequest.GetString("token");

                string apiUrl = loanApi + "/xbwnapi/Loan/BankCardSmsCode";
                string postParamters = string.Format("netLoanApplyId={0}&no={1}&token={2}"
                    , netLoanApplyId, no, token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "发送银行手机验证码异常，请稍后再试", null);
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
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string no = DNTRequest.GetString("no");
                string code = DNTRequest.GetString("code");
                string token = DNTRequest.GetString("token");

                string apiUrl = loanApi + "/xbwnapi/Loan/BankCardSmsCodeCheck";
                string postParamters = string.Format("netLoanApplyId={0}&no={1}&code={2}&token={3}"
                    , netLoanApplyId, no, code, token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "验证银行手机短信异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
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
                string token = DNTRequest.GetString("token");

                byte[] photoData = new byte[0];
                //HttpContext.Current.Response.ContentType = "application/octet-stream";
                //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                //photoData = HttpContext.Current.Request.BinaryRead(HttpContext.Current.Request.TotalBytes);

                //System.Text.Encoding.UTF8.GetBytes(base64Code);

                photoData = Convert.FromBase64String(base64Code);


                string apiUrl = loanApi + "/xbwnapi/Loan/ImagesUpload";
                string postParamters = string.Format("netLoanApplyId={0}&base64Code={1}&token={2}&photoData={3}"
                    , netLoanApplyId, base64Code, token, photoData);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "图片上传异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 身份证信息提交

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

                string apiUrl = loanApi + "/xbwnapi/Loan/CheckUserIsAuthentication";
                string postParamters = string.Format("netLoanApplyId={0}&memberId={1}&customerId={2}", netLoanApplyId, memberId, customerId);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "身份证信息提交异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        /// <summary>
        /// 身份证信息提交
        /// </summary>
        /// <returns></returns>
        static public Object SubmitIDInformation()
        {
            string result = string.Empty;
            try
            {
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

                string apiUrl = loanApi + "/xbwnapi/Loan/SubmitIDInformation";
                string postParamters = string.Format("netLoanApplyId={0}&fontId={1}&bankId={2}&realName={3}&idNo={4}&birth={5}&national={6}&address={7}&authority={8}&validperiod={9}&faceNo={10}&token={11}"
                    , netLoanApplyId, fontId, bankId, realName, idNo, birth, national, address, authority, validperiod, faceNo, token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "身份证信息提交异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 创建手机运营商爬取任务
        /// <summary>
        /// 创建手机运营商爬取任务
        /// </summary>
        /// <returns></returns>
        static public Object TaskCreate()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string telNo = DNTRequest.GetString("telNo");
                string servicePwd = DNTRequest.GetString("servicePwd");
                string token = DNTRequest.GetString("token");
                string apiUrl = loanApi + "/xbwnapi/Loan/TaskCreate";
                string postParamters = string.Format("netLoanApplyId={0}&telNo={1}&servicePwd={2}&token={3}"
                    , netLoanApplyId, telNo, servicePwd, token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "创建手机运营商爬取任务异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 更新手机运营商爬取任务
        /// <summary>
        /// 更新手机运营商爬取任务
        /// </summary>
        /// <returns></returns>
        static public Object TaskUpdate()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string smsCode = DNTRequest.GetString("smsCode");
                int taskId = DNTRequest.GetInt("taskId", -1);
                string servicePwd = DNTRequest.GetString("servicePwd");
                string imgCode = DNTRequest.GetString("imgCode");
                string realName = DNTRequest.GetString("realName");
                string idNo = DNTRequest.GetString("idNo");
                string token = DNTRequest.GetString("token");
                string apiUrl = loanApi + "/xbwnapi/Loan/TaskQuery";
                string postParamters = string.Format("netLoanApplyId={0}&smsCode={1}&taskId={2}&servicePwd={3}&imgCode={4}&realName={5}&idNo={6}&token={7}"
                    , netLoanApplyId, smsCode, taskId, servicePwd, imgCode, realName, idNo, token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "更新手机运营商爬取任务异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 查询手机运营商爬取任务
        /// <summary>
        /// 查询手机运营商爬取任务
        /// </summary>
        /// <returns></returns>
        static public Object TaskQuery()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                int taskId = DNTRequest.GetInt("taskId", -1);
                string token = DNTRequest.GetString("token");

                string apiUrl = loanApi + "/xbwnapi/Loan/TaskQuery";
                string postParamters = string.Format("netLoanApplyId={0}&taskId={1}token={2}"
                    , netLoanApplyId, taskId, token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "查询手机运营商爬取任务异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 发送运营商短信
        /// <summary>
        /// 发送运营商短信
        /// </summary>
        /// <returns></returns>
        static public Object SendOperatorSmsCode()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string taskId = DNTRequest.GetString("taskId");
                string telNo = DNTRequest.GetString("telNo");
                string smsCode = DNTRequest.GetString("smsCode");
                string token = DNTRequest.GetString("token");

                string apiUrl = loanApi + "/xbwnapi/Loan/SendOperatorSmsCode";
                string postParamters = string.Format("netLoanApplyId={0}&taskId={1}&telNo={2}&smsCode={3}&token={4}"
                    , netLoanApplyId, taskId, telNo, smsCode);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "发送运营商短信异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 发送运营商图片验证码
        /// <summary>
        /// 发送运营商图片验证码
        /// </summary>
        /// <returns></returns>
        static public Object SendOperatorImgCode()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string taskId = DNTRequest.GetString("taskId");
                string telNo = DNTRequest.GetString("telNo");
                string imgCode = DNTRequest.GetString("imgCode");
                string token = DNTRequest.GetString("token");

                string apiUrl = loanApi + "/xbwnapi/Loan/SendOperatorImgCode";
                string postParamters = string.Format("netLoanApplyId={0}&taskId={1}&telNo={2}&imgCode={3}&token={4}"
                    , netLoanApplyId, taskId, telNo, imgCode, token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "发送运营商图片验证码异常，请稍后再试", null);
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
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string imei = DNTRequest.GetString("imei");
                string uuid = DNTRequest.GetString("uuid");
                string token = DNTRequest.GetString("token");

                string apiUrl = loanApi + "/xbwnapi/Loan/GetLoanParas";
                string postParamters = string.Format("netLoanApplyId={0}&imei={1}&uuid={2}&token={3}"
                    , netLoanApplyId, imei, uuid, token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取借款参数异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 提交借款
        /// <summary>
        /// 提交借款
        /// </summary>
        /// <returns></returns>
        static public Object SubmitLoanApply()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string loanAmount = DNTRequest.GetString("loanAmount");
                string bankId = DNTRequest.GetString("bankId");
                string token = DNTRequest.GetString("token");

                string apiUrl = loanApi + "/xbwnapi/Loan/SubmitLoanApply";
                string postParamters = string.Format("netLoanApplyId={0}&loanAmount={1}&bankId={2}&token={3}"
                    , netLoanApplyId, loanAmount, HttpUtility.UrlEncode(bankId), token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "提交借款异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 确认借款
        /// <summary>
        /// 确认借款
        /// </summary>
        /// <returns></returns>
        static public Object ConfirmationLoanApply()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string borrowNo = DNTRequest.GetString("borrowNo");
                string tradePassword = DNTRequest.GetString("tradePassword");
                string tradePasswordSecond = DNTRequest.GetString("tradePasswordSecond");
                string token = DNTRequest.GetString("token");

                string apiUrl = loanApi + "/xbwnapi/Loan/ConfirmationLoanApply";
                string postParamters = string.Format("netLoanApplyId={0}&borrowNo={1}&tradePassword={2}&tradePasswordSecond={3}&token={4}"
                    , netLoanApplyId, borrowNo, tradePassword, tradePasswordSecond, token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);

                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "确认借款异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 首页综合信息查询
        /// <summary>
        /// 首页综合信息查询
        /// </summary>
        static public Object ComprehensiveQuery()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string imei = DNTRequest.GetString("imei");
                string uuid = DNTRequest.GetString("uuid");
                string token = DNTRequest.GetString("token");

                string apiUrl = loanApi + "/xbwnapi/Loan/ComprehensiveQuery";
                string postParamters = string.Format("netLoanApplyId={0}&imei={1}&uuid={2}&token={3}"
                    , netLoanApplyId, imei, uuid, token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "首页综合信息查询异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 借款状态审核查询
        /// <summary>
        /// 借款状态审核查询
        /// </summary>
        static public Object BorrowingStateQuery()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string borrowNo = DNTRequest.GetString("borrowNo");
                string token = DNTRequest.GetString("token");

                string apiUrl = loanApi + "/xbwnapi/Loan/BorrowingStateQuery";
                string postParamters = string.Format("netLoanApplyId={0}&borrowNo={1}&token={2}", netLoanApplyId, borrowNo, token);
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "借款状态审核查询异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 确认授权 
        /// <summary>
        /// 确认授权提交
        /// </summary>
        static public Object ConfirmationOfAuthorization()
        {
            string result = string.Empty;
            try
            {
                int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
                string identityCardNumber = DNTRequest.GetString("identityCardNumber");
                string accountExec = DNTRequest.GetString("accountExec");
                string authorizedPassword = DNTRequest.GetString("authorizedPassword");
                string borrowNo = DNTRequest.GetString("borrowNo");
                string operatorName = DNTRequest.GetString("operatorName");
                string operatorId = DNTRequest.GetString("operatorId");
                string token = DNTRequest.GetString("token");

                if (string.IsNullOrEmpty(accountExec))
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("success", false);
                    ht.Add("message", "请输入授权账号");
                    ht.Add("data", null);
                    return Newtonsoft.Json.JsonConvert.SerializeObject(ht);
                }
                if (string.IsNullOrEmpty(authorizedPassword))
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("success", false);
                    ht.Add("message", "请输入授权密码");
                    ht.Add("data", null);
                    return Newtonsoft.Json.JsonConvert.SerializeObject(ht);
                }
                if (string.IsNullOrEmpty(identityCardNumber))
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("success", false);
                    ht.Add("message", "请输入授权身份证号");
                    ht.Add("data", null);
                    return Newtonsoft.Json.JsonConvert.SerializeObject(ht);
                }

                #region 商户信息验证
                if (!string.IsNullOrEmpty(accountExec) && !string.IsNullOrEmpty(authorizedPassword) && !string.IsNullOrEmpty(identityCardNumber))
                {
                    UsersBLL bll = new UsersBLL();
                    Users model = new Users();
                    string PwdKey = BLL.LinkFun.getPwdKey();
                    authorizedPassword = DESEncrypt.Encrypt(PwdKey, authorizedPassword);
                    Model.ReturnModel returnModel = bll.VerificationPassword(accountExec, authorizedPassword, identityCardNumber);
                    if (returnModel.IsSuccess)
                    {
                        model = bll.GetModel(ComPage.SafeToInt(returnModel.Data));
                        if (model != null) {
                            operatorName = string.Format("{0}${1}${2}",model.UserName,model.CardID, model.Phone);
                        }
                        string apiUrl = loanApi + "/xbwnapi/Loan/ConfirmationOfAuthorization";
                        string postParamters = string.Format("netLoanApplyId={0}&identityCardNumber={1}&accountExec={2}&authorizedPassword={3}&token={4}&operatorName={5}&operatorId={6}&borrowNo={7}"
                            , netLoanApplyId, identityCardNumber, accountExec, authorizedPassword, token, operatorName, operatorId, borrowNo);
                        string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);

                        result = outputJson;
                    }
                    else
                {
                        Hashtable ht = new Hashtable();
                        ht.Add("success", false);
                        ht.Add("message", returnModel.ErrMessage);
                        ht.Add("data", null);
                        return Newtonsoft.Json.JsonConvert.SerializeObject(ht);
                        //{"data":{"boolean":true},"success":true,"code":null,"message":null,"mark":true,"timestamp":0}
                    }
                }

                #endregion 商户信息验证

            }
            catch (Exception ex)
            {
                Hashtable ht = new Hashtable();
                ht.Add("success", false);
                ht.Add("message", "确认授权异常，请稍后再试");
                ht.Add("data", null);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(ht);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #endregion

        #region 抓取容360html页面
        /// <summary>
        /// 抓取容360html页面
        /// </summary>
        /// <returns></returns>
        static public Object FetchRong360()
        {
            string result = string.Empty;
            try
            {
                string url = DNTRequest.GetString("url");
                string telNo = DNTRequest.GetString("tradePassword");
                string servicePwd = DNTRequest.GetString("servicePwd");
                string token = DNTRequest.GetString("token");

                string outputJson = UtilityHelper.HttpService.Get(url, false);

                object obj = new
                {
                    result = true,
                    msg = "",
                    html = HttpContext.Current.Server.HtmlEncode(outputJson)
                };
                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "抓取容360html页面异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

     
    }
}