using BWJS.Model;
using BWJS.BLL;
using UtilityHelper;
using BWJS.AppCode;
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
using BWJSLog.BLL;
using Mofang.Model;
using Mofang.BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BWJS.Model.Model;
using BWJSLog.Model;
using BWJS.BLL.CookieMag;

namespace BWJS.WebApp.Ajax.Helper
{
    /// <summary>
    /// 后台管理的调度实现
    /// </summary>
    [DataContract]
    public partial class IGL
    {
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
                    case "signin":
                        HttpContext.Current.Response.Write(UserSignIn());
                        break;
                    case "orderPayApplyL":
                        HttpContext.Current.Response.Write(GetOrderPayApplyList());
                        break;
                    case "orderCancle":
                        HttpContext.Current.Response.Write(OrderCancle());
                        break;
                    case "AddMachine":
                        HttpContext.Current.Response.Write(AddMachine());
                        break;
                    case "GetMachineList":
                        HttpContext.Current.Response.Write(GetMachineList());
                        break;
                    case "DeleteMachine":
                        HttpContext.Current.Response.Write(DeleteMachine());
                        break;
                    case "GetMachineOne":
                        HttpContext.Current.Response.Write(GetMachineOne());
                        break;
                    case "GetMachineOne2":
                        HttpContext.Current.Response.Write(GetMachineOne2());
                        break;
                    case "merchantList":
                        HttpContext.Current.Response.Write(GetMerchantList());
                        break;
                    case "merchantListForSelect":
                        HttpContext.Current.Response.Write(GetMerchantListForSelect());
                        break;
                    case "companyCategoryListForSelect":
                        HttpContext.Current.Response.Write(GetCompanyCategoryListForSelect());
                        break;
                    case "companyListForSelect":
                        HttpContext.Current.Response.Write(GetCompanyListForSelect());
                        break;
                    case "bankforselect":
                        HttpContext.Current.Response.Write(GetBankListForSelect());
                        break;
                    case "orderCancleList":
                        HttpContext.Current.Response.Write(GetOrderCancleList());
                        break;
                    case "getsmssendlist":
                        HttpContext.Current.Response.Write(GetSmsSendLogList());
                        break;
                    case "getsmssendmodel":
                        HttpContext.Current.Response.Write(GetSmsSendModelJson());
                        break;

                    case "SupplierInfo":
                        HttpContext.Current.Response.Write(SupplierInfo());
                        break;
                    case "supplierL":
                        HttpContext.Current.Response.Write(SupplierList());
                        break;
                    case "supplierList":
                        HttpContext.Current.Response.Write(GetSupplierList());
                        break;
                    case "DeleteMachineSupplier":
                        HttpContext.Current.Response.Write(DeleteMachineSupplier());
                        break;
                    case "GetMachineSupplier":
                        HttpContext.Current.Response.Write(GetMachineSupplierModel());
                        break;
                    case "AddMachineSupplier":
                        HttpContext.Current.Response.Write(AddMachineSupplier());
                        break;
                    case "UserUpdatePwd":
                        HttpContext.Current.Response.Write(UserUpdatePwd());
                        break;
                    case "userbankl":
                        HttpContext.Current.Response.Write(GetUserBankList());
                        break;
                    case "userbankmodel":
                        HttpContext.Current.Response.Write(GetUserBankModel());
                        break;
                    case "userbankadd":
                        HttpContext.Current.Response.Write(AddUserBank());
                        break;
                    case "userbankdel":
                        HttpContext.Current.Response.Write(DeleteUserBank());
                        break;
                    case "setdefault":
                        HttpContext.Current.Response.Write(SetIsDefault());
                        break;
                    case "companyRelationList":
                        HttpContext.Current.Response.Write(GetCompanyRelationList());
                        break;
                    case "GetCompanyRelation":
                        HttpContext.Current.Response.Write(GetCompanyRelationModel());
                        break;
                    case "AddCompanyRelation":
                        HttpContext.Current.Response.Write(AddCompanyRelation());
                        break;
                    case "DeleteCompanyRelation":
                        HttpContext.Current.Response.Write(DeleteCompanyRelation());
                        break;
                    case "GetCompanyRelationOne":
                        HttpContext.Current.Response.Write(GetCompanyRelationOne());
                        break;
                    case "GetSysConfigList":
                        HttpContext.Current.Response.Write(GetSysConfigList());
                        break;
                    case "BinDingUsersMachine":
                        HttpContext.Current.Response.Write(BinDingUsersMachine());
                        break;
                    case "GetBinDingUsers":
                        HttpContext.Current.Response.Write(GetBinDingUsers());
                        break;
                }

                #endregion
            }
        }

        #region 用户登录

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        static public Object UserSignIn()
        {
            string result = string.Empty;
            try
            {
                #region 登录判断

                string uid = DNTRequest.GetString("inpUid").Trim();
                string pwd = DNTRequest.GetString("inpPwd").Trim();
                if (string.IsNullOrEmpty(uid))
                {
                    return DNTRequest.GetResultJson(false, "请输入登录名", null);
                }
                if (string.IsNullOrEmpty(pwd))
                {
                    return DNTRequest.GetResultJson(false, "请输入密码", null);
                }
                if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(pwd))
                {
                    UsersBLL op = new UsersBLL();
                    Users employee = op.AdminLogin(uid);
                    if (employee != null)
                    {
                        //pwd = Utils.MD5(pwd);
                        string PwdKey = BLL.LinkFun.getPwdKey();
                        pwd = DESEncrypt.Encrypt(PwdKey, pwd);//旧密码加密 
                        if (pwd == employee.Password)
                        {
                            if (employee.IsLocked == 0)
                            {
                                employee.LastAccessIP = HttpContext.Current.Request.UserHostAddress;
                                int loginTimes = ComPage.SafeToInt(employee.LoginTimes);
                                employee.LoginTimes = ((loginTimes == -1) ? (1) : (loginTimes + 1));
                                employee.RecordUpdateTime = DateTime.Now;
                                employee.IsLogined = 1;
                                bool res = op.Update(employee);

                                string url = "/Admin/default.aspx";

                                switch (employee.UserType)
                                {
                                    case 1:
                                        //AdminCookieExpires
                                        //AdminCookieName
                                        break;
                                    case 2:
                                        //MerchantCookieExpires
                                        //MerchantCookieName
                                        break;
                                    case 3:
                                        //AgentCookieExpires
                                        //AgentCookieName
                                        break;
                                }

                                string key = ComPage.employeeModelCacheDependency + employee.UserID;
                                ComPage.SetBWJSCache(key, Guid.NewGuid(), null, DateTime.Now.AddMinutes(ComPage.SafeToDouble(BLL.LinkFun.ConfigString("cookieExpires", "120"))), TimeSpan.Zero);//Utils.GetAppSettingsValue("cookieExpires")

                                MerchantMagCookieBLL.SetMerchantMagCookie(employee.UserID, employee.LoginName);

                                //
                                HttpCookie cookie = new HttpCookie(Utils.GetAppSettingsValue("cookieName"));
                                cookie.Expires = DateTime.Now.AddMinutes(ComPage.SafeToDouble(BLL.LinkFun.ConfigString("cookieExpires", "120")));//Utils.GetAppSettingsValue("cookieExpires")
                                cookie.Values.Add("Id", HttpContext.Current.Server.UrlEncode(employee.UserID.ToString()));

                                System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                                System.Web.HttpContext.Current.Response.AppendCookie(cookie);
                                //
                                //HttpContext.Current.Response.Redirect("/Admin/default.aspx");

                                //SetMerchantFrontCookie

                                object obj = new
                                {
                                    result = true,
                                    msg = "登录成功",
                                    url = url,
                                };
                                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                                //result = DNTRequest.GetResultJson(true, "登录成功", null);
                            }
                            else
                            {
                                result = DNTRequest.GetResultJson(false, "用户已锁定", null);
                            }
                        }
                        else
                        {
                            result = DNTRequest.GetResultJson(false, "密码错误", null);
                        }
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(false, "登录名不存在", null);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 获取订单支付列表

        /// <summary>
        /// 获取订单支付列表
        /// </summary>
        static public Object GetOrderPayApplyList()
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
                where.AppendFormat("1=1");

                #region 权限
                DepartmentInfo df = new DepartmentInfo();
                DepartmentInfoBLL bll = new DepartmentInfoBLL();
                df = bll.GetModel(ComPage.CurrentAdmin.DepartmentID);

                if (ComPage.CurrentAdmin.UserType != 1)
                {
                    if ((df == null) || (df != null && df.IsReceiveBusiness != false))
                    {

                        where.Append(" AND a.IsDeleted=0 AND c.UserID IN(SELECT ID from[BWJSDB].dbo.[GetDepartmentChildren](" + ComPage.CurrentAdmin.UserID + "))");
                    }
                }
                #endregion


                #region 条件搜索

                #region 支付状态
                string payStatus = DNTRequest.GetString("payStatus");
                if (string.IsNullOrEmpty(payStatus))
                {
                    payStatus = JsonRequest.GetJsonKeyVal(jsonText, "payStatus");
                }
                if (!string.IsNullOrEmpty(payStatus))
                {
                    where.AppendFormat(" and a.PayStatus={0}", payStatus);
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
                    where.AppendFormat(" and b.IsSettled={0}", isSettled);
                }
                #endregion

                #region 退保状态
                string isCancel = DNTRequest.GetString("isCancel");
                if (string.IsNullOrEmpty(isCancel))
                {
                    isCancel = JsonRequest.GetJsonKeyVal(jsonText, "isCancel");
                }
                if (!string.IsNullOrEmpty(isCancel))
                {
                    where.AppendFormat(" and b.IsCancel={0}", isCancel);
                }
                #endregion

                #region 订单流水号
                string transNo = DNTRequest.GetString("transNo");
                if (string.IsNullOrEmpty(transNo))
                {
                    transNo = JsonRequest.GetJsonKeyVal(jsonText, "transNo");
                    transNo = System.Web.HttpContext.Current.Server.UrlDecode(transNo);
                }
                if (!string.IsNullOrEmpty(transNo))
                {
                    where.AppendFormat(" and b.TransNo like  '%{0}%'", transNo);
                }
                #endregion

                #region 保单号
                string insureNum = DNTRequest.GetString("insureNum");
                if (string.IsNullOrEmpty(insureNum))
                {
                    insureNum = JsonRequest.GetJsonKeyVal(jsonText, "insureNum");
                    insureNum = System.Web.HttpContext.Current.Server.UrlDecode(insureNum);
                }
                if (!string.IsNullOrEmpty(insureNum))
                {
                    where.AppendFormat(" and c.InsureNum like  '%{0}%'", insureNum);
                }
                #endregion

                #region 投保人
                string tBName = DNTRequest.GetString("tBName");
                if (string.IsNullOrEmpty(tBName))
                {
                    tBName = JsonRequest.GetJsonKeyVal(jsonText, "tBName");
                    tBName = System.Web.HttpContext.Current.Server.UrlDecode(tBName);
                }
                if (!string.IsNullOrEmpty(tBName))
                {
                    where.AppendFormat(" and d.CName like  '%{0}%'", tBName);
                }
                #endregion

                #region 被保人
                string bBName = DNTRequest.GetString("bBName");
                if (string.IsNullOrEmpty(bBName))
                {
                    bBName = JsonRequest.GetJsonKeyVal(jsonText, "bBName");
                    bBName = System.Web.HttpContext.Current.Server.UrlDecode(bBName);
                }
                if (!string.IsNullOrEmpty(bBName))
                {
                    where.AppendFormat(" and e.CName like  '%{0}%'", bBName);
                }
                #endregion

                #region 商家
                string merchantName = DNTRequest.GetString("merchantName");
                if (string.IsNullOrEmpty(merchantName))
                {
                    merchantName = JsonRequest.GetJsonKeyVal(jsonText, "merchantName");
                    merchantName = System.Web.HttpContext.Current.Server.UrlDecode(merchantName);
                }
                if (!string.IsNullOrEmpty(merchantName))
                {
                    where.AppendFormat(" and u.UserName like  '%{0}%'", merchantName);
                }
                #endregion

                #region 购买产品
                string remark = DNTRequest.GetString("remark");
                if (string.IsNullOrEmpty(remark))
                {
                    remark = JsonRequest.GetJsonKeyVal(jsonText, "remark");
                    remark = System.Web.HttpContext.Current.Server.UrlDecode(remark);
                }
                if (!string.IsNullOrEmpty(remark))
                {
                    where.AppendFormat(" and a.Remark like  '%{0}%'", remark);
                }
                #endregion

                #region 下单日期
                string createDateStart = DNTRequest.GetString("createDateStart");
                if (string.IsNullOrEmpty(createDateStart))
                {
                    createDateStart = JsonRequest.GetJsonKeyVal(jsonText, "createDateStart");
                    createDateStart = System.Web.HttpContext.Current.Server.UrlDecode(createDateStart);
                }
                string createDateEnd = DNTRequest.GetString("createDateEnd");
                if (string.IsNullOrEmpty(createDateEnd))
                {
                    createDateEnd = JsonRequest.GetJsonKeyVal(jsonText, "createDateEnd");
                    createDateEnd = System.Web.HttpContext.Current.Server.UrlDecode(createDateEnd);
                }

                if (!string.IsNullOrEmpty(createDateStart) && !string.IsNullOrEmpty(createDateEnd))
                {
                    where.AppendFormat(" and (a.CreateDate>='{0} 00:00:00' and a.CreateDate<='{1} 23:59:59')", createDateStart, createDateEnd);
                }
                else if (string.IsNullOrEmpty(createDateStart) && !string.IsNullOrEmpty(createDateEnd))
                {
                    where.AppendFormat(" and a.CreateDate<='{0} 23:59:59'", createDateEnd);
                }
                else if (!string.IsNullOrEmpty(createDateStart) && string.IsNullOrEmpty(createDateEnd))
                {
                    where.AppendFormat(" and a.CreateDate>='{0} 00:00:00'", createDateStart);
                }
                #endregion

                #endregion

                #region 排序字段
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

                #region 分页查询
                string sql = "";
                int zys = 0;
                int sumcount = 0;
                OrderPayApplyBLL opOrderPayApplyBLL = new OrderPayApplyBLL();
                DataTable dt = opOrderPayApplyBLL.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
                #endregion

                #region 查询结果
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

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 退保
        /// <summary>
        /// 退保
        /// </summary>
        static public Object OrderCancle()
        {
            OrderCancleBLL ordercancelBll = new OrderCancleBLL();
            string result = string.Empty;
            try
            {
                string dataParam = DNTRequest.GetString("dataParam").Trim();
                if (string.IsNullOrEmpty(dataParam))
                {
                    return DNTRequest.GetResultJson(false, "退保失败，未获取到投保单号", null);
                }
                if (!string.IsNullOrEmpty(dataParam))
                {
                    string[] dataParamList = dataParam.Split(new char[] { ',' });

                    int orderRebateId = ComPage.SafeToInt(dataParamList[0]);
                    string insureNum = ComPage.SafeToString(dataParamList[1]);

                    OrderCancle modelOrderCancle = new OrderCancle();
                    modelOrderCancle.InsureNum = ComPage.SafeToString(dataParamList[1]);
                    modelOrderCancle.OrderApplyID = ComPage.SafeToInt(dataParamList[2]);
                    modelOrderCancle.OrderRebateId = ComPage.SafeToInt(dataParamList[0]);
                    modelOrderCancle.RecordCreateTime = DateTime.Now;
                    modelOrderCancle.RecordUpdateTime = DateTime.Now;
                    modelOrderCancle.CreatUserID = ComPage.SafeToInt(dataParamList[3]);
                    int OrderCancleId = ordercancelBll.Add(modelOrderCancle);
                    if (OrderCancleId > 0)
                    {
                        OrderCancle oOrderCancle = ordercancelBll.GetModel(OrderCancleId);

                        BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
                        OrderCancleInputModel model = new OrderCancleInputModel();


                        model.transNo = ComPage.SafeToString(dataParamList[4]);// UtilityHelper.CommonHelper.OrderNoOne();
                        model.insureNum = modelOrderCancle.InsureNum;

                        OrderCancleOutputModel res = baoxianDataBLL.OrderCancle(model);
                        if (res != null)
                        {
                            oOrderCancle.RespCode = res.respCode;
                            oOrderCancle.RespMsg = res.respmsg;
                            oOrderCancle.TransNo = model.transNo;
                            oOrderCancle.OrderCancleID = OrderCancleId;
                            oOrderCancle.InsureNum = model.insureNum;
                            ordercancelBll.Update(oOrderCancle);//更新状态
                            if (res.respstat == "0000")
                            {
                                #region 更新退保状态
                                OrderRebateBLL opOrderRebateBLL = new OrderRebateBLL();
                                OrderRebate modelOrderRebate = new OrderRebate();

                                modelOrderRebate = opOrderRebateBLL.GetModel(modelOrderCancle.OrderRebateId);
                                if (modelOrderRebate != null)
                                {
                                    modelOrderRebate.IsCancel = 1;
                                    bool res1 = opOrderRebateBLL.Update(modelOrderRebate);
                                }
                                #endregion

                                result = DNTRequest.GetResultJson(true, "退保成功", null);
                            }
                            else
                            {
                                result = DNTRequest.GetResultJson(false, res.respmsg, null);
                            }
                            //ordercancelBll.


                        }
                        else
                        {
                            result = DNTRequest.GetResultJson(false, "退保失败，远程接口无响应", null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 设备管理

        /// <summary>
        /// 添加修改设备
        /// </summary>
        static public Object AddMachine()
        {
            string result = string.Empty;
            try
            {
                int machineId = DNTRequest.GetInt("MachineID", 0);
                string objOrder = DNTRequest.GetString("MachineModel");

                MachineBLL op = new MachineBLL();
                Machine model = JsonConvert.DeserializeObject<Machine>(objOrder);
                #region 获取当前位置信息
                string longitude = string.Empty;
                string latitude = string.Empty;
                string jsonText = MachineLocationLogBLL.GetLocationInfo();
                if (!string.IsNullOrEmpty(jsonText))
                {
                    JObject o = JObject.Parse(jsonText);
                    longitude = o["content"]["point"]["x"].ToString();
                    latitude = o["content"]["point"]["y"].ToString();
                }
                model.Latitude = latitude;
                model.Longitude = longitude;
                #endregion
                if (machineId > 0)
                {
                    #region 修改
                    bool snExist = op.Exists(machineId, model.SN);
                    if (!snExist)
                    {
                        Machine modelDB = op.GetModel(machineId);
                        modelDB.SId = model.SId;
                        modelDB.MachineSupplierId = model.MachineSupplierId;
                        modelDB.SN = model.SN;
                        modelDB.MAC = IpHelper.GetClientMacAddress();
                        modelDB.Address = model.Address;
                        modelDB.Status = model.Status;
                        modelDB.TeamViewerNumber = model.TeamViewerNumber;
                        modelDB.TeamViewerPwd = model.TeamViewerPwd;
                        modelDB.Remark = model.Remark;
                        modelDB.RecordUpdateUserID = ComPage.CurrentAdmin.UserID;
                        modelDB.RecordUpdateTime = DateTime.Now;
                        modelDB.Platform = model.Platform;
                        modelDB.FlatDeviceNumber = model.FlatDeviceNumber;
                        bool res1 = op.Update(modelDB);
                        if (res1)
                        {
                            result = DNTRequest.GetResultJson(true, "修改成功", null);

                            #region 通知风控系统

                            #endregion
                        }
                        else
                        {
                            result = DNTRequest.GetResultJson(false, "修改失败，请稍候再试", null);
                        }
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(false, "修改失败，设备号已存在", null);
                    }
                    #endregion
                }
                else
                {
                    #region 添加
                    //判断pad是否超过指定数量，超过不能添加
                    string platform = model.Platform;
                    if (string.IsNullOrEmpty(platform) && platform == "平板")
                    {
                        int countMachine = op.TotalUserIdPlatform(model.UserID, model.Platform);
                        int countSys = 0;
                        try
                        {
                            countSys = int.Parse(BLL.LinkFun.ConfigString("padMaxNum", "2"));
                        }
                        catch { }
                        if (countMachine > countSys)
                        {
                            result = DNTRequest.GetResultJson(false, "添加失败，授权设备过多!", null);
                        }
                        return result;
                    }
                    bool snExist = op.ExistsBySN(model.SN);
                    if (!snExist)
                    {
                        model.MAC = IpHelper.GetClientMacAddress();
                        model.Status = 1;
                        model.CreatUserID = ComPage.CurrentAdmin.UserID;
                        model.RecordIsDelete = false;
                        model.RecordUpdateTime = DateTime.Now;
                        model.RecordCreateTime = DateTime.Now;
                        int res1 = op.Add(model);
                        if (res1 > 0)
                        {
                            result = DNTRequest.GetResultJson(true, "添加成功", null);

                            #region 通知风控系统

                            #endregion
                        }
                        else
                        {
                            result = DNTRequest.GetResultJson(false, "添加失败，请稍候再试", null);
                        }
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(false, "添加失败，设备号已存在", null);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "添加设备异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        /// <summary>
        /// 获取设备列表
        /// </summary>
        static public Object GetMachineList()
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
                where.Append(" a.RecordIsDelete=0 ");
                DepartmentInfo df = new DepartmentInfo();
                DepartmentInfoBLL bll = new DepartmentInfoBLL();
                df = bll.GetModel(ComPage.CurrentAdmin.DepartmentID);
                if (ComPage.CurrentAdmin.UserType != 1)
                {
                    if ((df == null) || (df != null && df.IsReceiveBusiness != false))
                    {
                        where.Append(" AND  a.UserID IN (select ID from [BWJSDB].dbo.[GetDepartmentChildren](" + ComPage.CurrentAdmin.UserID + "))");
                    }
                }

                #region 条件搜索
                string status = DNTRequest.GetString("status");
                if (string.IsNullOrEmpty(status))
                {
                    status = JsonRequest.GetJsonKeyVal(jsonText, "status");
                }
                if (!string.IsNullOrEmpty(status))
                {
                    where.AppendFormat(" AND a.[Status]={0} ", status);
                }

                string key = DNTRequest.GetString("searchKey");
                if (string.IsNullOrEmpty(key))
                {
                    key = JsonRequest.GetJsonKeyVal(jsonText, "searchKey");
                }

                string val = DNTRequest.GetString("searchValue");
                if (string.IsNullOrEmpty(val))
                {
                    val = JsonRequest.GetJsonKeyVal(jsonText, "searchValue");
                    val = System.Web.HttpContext.Current.Server.UrlDecode(val);
                }

                if (string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(val))
                {
                    where.AppendFormat(" AND (a.SN like'%{0}%' or a.MAC like'%{0}%' or a.Address like '%{0}%') ", val);
                }
                else if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(val))
                {
                    switch (key)
                    {
                        case "1":
                            where.AppendFormat(" and a.SN like'%{0}%'", val);
                            break;
                        case "2":
                            where.AppendFormat(" and a.MAC like'%{0}%'", val);
                            break;
                        case "3":
                            where.AppendFormat(" and a.Address like '%{0}%'", val);
                            break;
                        case "4":
                            where.AppendFormat(" and (a.Longitude like '%{0}%' or a.Latitude like '%{0}%')", val);
                            break;
                        case "5":
                            where.AppendFormat(" and a.TeamViewerNumber like '%{0}%'", val);
                            break;
                        case "6":
                            where.AppendFormat(" and a.Remark like '%{0}%'", val);
                            break;
                    }
                }
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
                MachineBLL opMachineBLL = new MachineBLL();
                DataTable dt = opMachineBLL.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
                result = DNTRequest.GetResultJson(false, "获取设备列表信息失败", ex.Message);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        /// <summary>
        /// 删除设备
        /// </summary>
        /// <returns></returns>
        static public Object DeleteMachine()
        {
            string result = string.Empty;
            try
            {
                string machineIds = DNTRequest.GetString("MachineID");
                if (string.IsNullOrEmpty(machineIds))
                {
                    return DNTRequest.GetResultJson(false, "请先选择一条数据", null);
                }
                else
                {
                    MachineBLL op = new MachineBLL();
                    bool res = op.DeleteList(machineIds, ComPage.CurrentAdmin.UserID);
                    if (res)
                    {
                        result = DNTRequest.GetResultJson(true, "删除设备成功", null);

                        #region 通知风控系统

                        #endregion
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(false, "删除设备失败，请稍后再试", null);
                    }
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "删除设备异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        /// <summary>
        /// 获取设备详情
        /// </summary>
        static public Object GetMachineOne()
        {
            string result = string.Empty;
            try
            {
                int machineId = DNTRequest.GetInt("MachineID", 0);
                if (machineId == 0)
                {
                    result = DNTRequest.GetResultJson(false, "获取设备信息失败,请稍后再试", null);
                }
                MachineBLL op = new MachineBLL();
                Machine model = new Machine();
                if (machineId != 0)
                {
                    model = op.GetModel(machineId);
                }
                result = DNTRequest.GetResultJson(true, "success", model);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取设备信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        /// <summary>
        /// 获取设备详情
        /// </summary>
        static public Object GetMachineOne2()
        {
            string result = string.Empty;
            try
            {
                int machineId = DNTRequest.GetInt("MachineID", 0);
                if (machineId == 0)
                {
                    result = DNTRequest.GetResultJson(false, "获取设备信息失败,请稍后再试", null);
                }
                MachineBLL op = new MachineBLL();
                MachineBackups model = new MachineBackups();
                if (machineId != 0)
                {
                    model = op.GetModelListName2(" MachineID =" + machineId + " ");
                }
                result = DNTRequest.GetResultJson(true, "success", model);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取设备信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 获取商家列表

        /// <summary>
        /// 获取商家列表
        /// </summary>
        static public Object GetMerchantList()
        {
            string result = string.Empty;
            try
            {

                int dbUserId = DNTRequest.GetInt("dbUserId", 0);
                int machineId = DNTRequest.GetInt("machineId", 0);
                UsersBLL op = new UsersBLL();
                List<Users> list = new List<Users>();
                StringBuilder where = new StringBuilder();
                where.AppendFormat("UserType<>1  AND  RecordIsDelete=0");
                //if (dbUserId == 0)
                //{
                //    where.AppendFormat(" and userid not in(select distinct userid from BWJSDB.[dbo].[Machine] WHERE RecordIsDelete=0) ");
                //}
                //else
                //{
                //    where.AppendFormat(" and (userid not in(select distinct userid from BWJSDB.[dbo].[Machine] WHERE RecordIsDelete=0) or UserId={0})", dbUserId);
                //}
                list = op.GetModelList(where.ToString());
                result = DNTRequest.GetResultJson(true, "success", list);

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取商家异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        /// <summary>
        /// 获取商家列表
        /// </summary>
        static public Object GetMerchantListForSelect()
        {
            string result = string.Empty;
            try
            {
                UsersBLL op = new UsersBLL();
                List<Users> list = new List<Users>();
                StringBuilder where = new StringBuilder();
                where.AppendFormat("UserType<>1  AND  RecordIsDelete=0");
                list = op.GetModelList(where.ToString());
                result = DNTRequest.GetResultJson(true, "success", list);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取商家异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        /// 获取所以商户列表
        /// </summary>
        static public Object SupplierInfo()
        {
            string result = string.Empty;
            try
            {
                StringBuilder where = new StringBuilder();
                where.Append("State=0");
                SupplierInfoBLL op = new SupplierInfoBLL();
                List<SupplierInfo> list = op.GetModelList(where.ToString());
                result = DNTRequest.GetResultJson(true, "success", list);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #region 获取用户银行列表
        /// <summary>
        /// 获取用户银行列表
        /// </summary>
        static public Object GetBankListForSelect()
        {
            string result = string.Empty;
            try
            {
                int merchantId = DNTRequest.GetInt("merchantId", -1);
                if (merchantId == -1)
                {
                    return DNTRequest.GetResultJson(false, "获取用户银行失败，缺少商家编号", null);
                }
                UserBankBLL op = new UserBankBLL();
                List<UserBank> list = new List<UserBank>();
                StringBuilder where = new StringBuilder();
                where.AppendFormat("IsDeleted=0");
                if (merchantId != -1)
                {
                    where.AppendFormat(" and UserId={0}", merchantId);
                }
                list = op.GetModelList(where.ToString());
                result = DNTRequest.GetResultJson(true, "success", list);

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取用户银行异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 获取渠道类别列表
        /// <summary>
        /// 获取渠道类别列表
        /// </summary>
        static public Object GetCompanyCategoryListForSelect()
        {
            string result = string.Empty;
            try
            {
                CompanyCategoryBLL op = new CompanyCategoryBLL();
                List<CompanyCategory> list = new List<CompanyCategory>();
                StringBuilder where = new StringBuilder();
                where.AppendFormat("IsDeleted=0");
                list = op.GetModelList(where.ToString());
                result = DNTRequest.GetResultJson(true, "success", list);

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取渠道类别异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 获取渠道列表

        /// <summary>
        /// 获取渠道列表
        /// </summary>
        static public Object GetCompanyListForSelect()
        {
            string result = string.Empty;
            try
            {
                CompanyBLL op = new CompanyBLL();
                List<Company> list = new List<Company>();
                StringBuilder where = new StringBuilder();
                where.AppendFormat("CompanyCategoryId<>1 and IsDeleted=0");
                list = op.GetModelList(where.ToString());
                result = DNTRequest.GetResultJson(true, "success", list);

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取渠道异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 获取渠道关系列表

        #region 获取渠道关系
        /// <summary>
        /// 获取渠道关系
        /// </summary>
        static public Object GetCompanyRelationListForSelect()
        {
            string result = string.Empty;
            try
            {
                CompanyRelationBLL op = new CompanyRelationBLL();
                List<CompanyRelation> list = new List<CompanyRelation>();
                StringBuilder where = new StringBuilder();
                where.AppendFormat("IsDeleted=0");
                list = op.GetModelList(where.ToString());
                result = DNTRequest.GetResultJson(true, "success", list);

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取渠道异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 获取渠道关系列表
        /// <summary>
        /// 获取渠道关系列表
        /// </summary>
        static public Object GetCompanyRelationList()
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
                where.Append(" a.IsDeleted=0 ");
                DepartmentInfo df = new DepartmentInfo();
                DepartmentInfoBLL bll = new DepartmentInfoBLL();
                df = bll.GetModel(ComPage.CurrentAdmin.DepartmentID);
                if (ComPage.CurrentAdmin.UserType != 1)
                {
                    if ((df == null) || (df != null && df.IsReceiveBusiness != false))
                    {
                        where.Append(" AND  a.UserID IN (select ID from [BWJSDB].dbo.[GetDepartmentChildren](" + ComPage.CurrentAdmin.UserID + "))");
                    }
                }

                #region 条件搜索

                string key = DNTRequest.GetString("searchKey");
                if (string.IsNullOrEmpty(key))
                {
                    key = JsonRequest.GetJsonKeyVal(jsonText, "searchKey");
                }

                string val = DNTRequest.GetString("searchValue");
                if (string.IsNullOrEmpty(val))
                {
                    val = JsonRequest.GetJsonKeyVal(jsonText, "searchValue");
                    val = System.Web.HttpContext.Current.Server.UrlDecode(val);
                }

                if (string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(val))
                {
                    where.AppendFormat(" AND (a2.CompanyName like '%{0}%' or a3.UserName like '%{0}%' or a4.DepartmentName like '%{0}%' or a2.MainBusiness like '%{0}%') ", val);
                }
                else if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(val))
                {
                    switch (key)
                    {
                        case "1":
                            where.AppendFormat(" and a2.CompanyName like '%{0}%'", val);
                            break;
                        case "2":
                            where.AppendFormat(" and a3.UserName like '%{0}%'", val);
                            break;
                        case "3":
                            where.AppendFormat(" and a4.DepartmentName like '%{0}%'", val);
                            break;
                        case "4":
                            where.AppendFormat(" and a2.MainBusiness like '%{0}%'", val);
                            break;
                    }
                }
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
                CompanyRelationBLL opCompanyRelationBLL = new CompanyRelationBLL();
                DataTable dt = opCompanyRelationBLL.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
                result = DNTRequest.GetResultJson(false, "获取设备列表信息失败", ex.Message);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 获取详细渠道关系
        /// <summary>
        /// 获取详细渠道关系
        /// </summary>
        /// <returns></returns>
        static public Object GetCompanyRelationModel()
        {
            string result = string.Empty;
            try
            {
                int companyRelationId = DNTRequest.GetInt("CompanyRelationId", 0);
                if (companyRelationId == 0)
                {
                    result = DNTRequest.GetResultJson(false, "获取渠道关系信息失败,请稍后再试", null);
                }
                CompanyRelationBLL op = new CompanyRelationBLL();
                CompanyRelation model = new CompanyRelation();
                if (companyRelationId != 0)
                {
                    model = op.GetModel(companyRelationId);
                }
                result = DNTRequest.GetResultJson(true, "success", model);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取渠道关系信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 获取渠道关系详情

        /// <summary>
        /// 获取渠道关系详情
        /// </summary>
        static public Object GetCompanyRelationOne()
        {
            string result = string.Empty;
            try
            {
                int companyRelationId = DNTRequest.GetInt("CompanyRelationId", 0);
                if (companyRelationId == 0)
                {
                    result = DNTRequest.GetResultJson(false, "获取渠道关系详情信息失败,请稍后再试", null);
                }
                CompanyRelationBLL op = new CompanyRelationBLL();
                CompanyRelation model = new CompanyRelation();
                if (companyRelationId != 0)
                {
                    model = op.GetCompanyRelationName(" CompanyRelationId =" + companyRelationId + " ");
                }
                result = DNTRequest.GetResultJson(true, "success", model);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取渠道关系详情信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 添加渠道关系
        /// <summary>
        /// 添加渠道关系
        /// </summary>
        /// <returns></returns>
        static public Object AddCompanyRelation()
        {
            string result = string.Empty;
            try
            {
                int CompanyRelationId = DNTRequest.GetInt("CompanyRelationId", 0);
                string objOrder = DNTRequest.GetString("CompanyRelationModel");
                CompanyRelationBLL op = new CompanyRelationBLL();
                CompanyRelation model = JsonConvert.DeserializeObject<CompanyRelation>(objOrder);
                if (CompanyRelationId > 0)
                {
                    #region 修改
                    CompanyRelation modelDB = op.GetModel(CompanyRelationId);
                    modelDB.CompanyRelationId = model.CompanyRelationId;
                    modelDB.CompanyId = model.CompanyId;
                    modelDB.UserId = model.UserId;
                    modelDB.DepartmentId = model.DepartmentId;
                    modelDB.RecommendationCode = model.RecommendationCode;
                    modelDB.QRCode = model.QRCode;
                    modelDB.Remark = model.Remark;
                    modelDB.IsDeleted = model.IsDeleted;
                    modelDB.API = model.API;
                    modelDB.CreateId = model.CreateId;
                    modelDB.CreateDate = model.CreateDate;
                    modelDB.EditId = ComPage.CurrentAdmin.UserID;
                    modelDB.EditDate = DateTime.Now;

                    bool res1 = op.Update(modelDB);
                    if (res1)
                    {
                        result = DNTRequest.GetResultJson(true, "修改成功", null);
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(false, "修改失败，请稍候再试", null);
                    }
                    #endregion
                }
                else
                {
                    model.CreateId = ComPage.CurrentAdmin.UserID;
                    model.CreateDate = DateTime.Now;
                    op.Add(model);
                    result = DNTRequest.GetResultJson(true, "添加成功", null);
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "添加渠道关系信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 删除渠道关系
        /// <summary>
        /// 删除渠道关系
        /// </summary>
        /// <returns></returns>
        static public Object DeleteCompanyRelation()
        {
            string result = string.Empty;
            try
            {
                string companyRelationIds = DNTRequest.GetString("CompanyRelationId");
                if (string.IsNullOrEmpty(companyRelationIds))
                {
                    return DNTRequest.GetResultJson(false, "请先选择一条数据", null);
                }
                else
                {
                    CompanyRelationBLL op = new CompanyRelationBLL();
                    bool res = op.DeleteList(companyRelationIds, ComPage.CurrentAdmin.UserID);
                    if (res)
                    {
                        result = DNTRequest.GetResultJson(true, "删除渠道关系成功", null);
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(false, "删除渠道关系失败，请稍后再试", null);
                    }
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "删除渠道关系异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #endregion

        #region 获取退单管理列表

        /// <summary>
        /// 获取退单管理列表
        /// </summary>
        static public Object GetOrderCancleList()
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
                where.Append("a.RecordIsDelete=0");
                DepartmentInfo df = new DepartmentInfo();
                DepartmentInfoBLL bll = new DepartmentInfoBLL();
                df = bll.GetModel(ComPage.CurrentAdmin.DepartmentID);
                if (ComPage.CurrentAdmin.UserType != 1)
                {
                    if ((df == null) || (df != null && df.IsReceiveBusiness != false))
                    {
                        //where.AppendFormat(@" AND  ((b.DepartmentId in(SELECT DepartmentID from [BWJSDB].dbo.[GetDepartmentChildrenList]({0})))
                        //OR(b.UserID IN(SELECT ID from[BWJSDB].dbo.[GetDepartmentChildren]({0})) AND b.DepartmentId IS null))", ComPage.CurrentAdmin.UserID);

                        where.Append(" AND b.UserID IN(SELECT ID from[BWJSDB].dbo.[GetDepartmentChildren](" + ComPage.CurrentAdmin.UserID + "))");
                    }
                }

                #region 条件搜索

                string key = DNTRequest.GetString("searchKey");
                if (string.IsNullOrEmpty(key))
                {
                    key = JsonRequest.GetJsonKeyVal(jsonText, "searchKey");
                }

                string val = DNTRequest.GetString("searchValue");
                if (string.IsNullOrEmpty(val))
                {
                    val = JsonRequest.GetJsonKeyVal(jsonText, "searchValue");
                    val = System.Web.HttpContext.Current.Server.UrlDecode(val);
                }

                if (!string.IsNullOrEmpty(val))
                {
                    where.AppendFormat(" AND a.InsureNum like '%{0}%' ", val);
                }
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
                OrderCancleBLL opOrderCancleBLL = new OrderCancleBLL();
                DataTable dt = opOrderCancleBLL.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
                result = DNTRequest.GetResultJson(false, "获取获取退单管理列表", ex.Message);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 短信日志管理

        #region 获取短信发送日志列表

        /// <summary>
        /// 获取短信发送日志列表
        /// </summary>
        static public Object GetSmsSendLogList()
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
                where.Append("a.IsDeleted=0");
                //DepartmentInfo df = new DepartmentInfo();
                //DepartmentInfoBLL bll = new DepartmentInfoBLL();
                //df = bll.GetModel(ComPage.CurrentAdmin.DepartmentID);
                //     if (ComPage.CurrentAdmin.UserType != 1 && (df != null && df.IsReceiveBusiness != false))
                //{
                //    where.AppendFormat(" and b.UserID in(select ID from [BWJSDB].dbo.[GetDepartmentChildren]({0}))", ComPage.CurrentAdmin.UserID);
                //}

                #region 条件搜索
                string status = DNTRequest.GetString("status");
                if (string.IsNullOrEmpty(status))
                {
                    status = JsonRequest.GetJsonKeyVal(jsonText, "status");
                }
                if (!string.IsNullOrEmpty(status))
                {
                    where.AppendFormat(" AND a.[Status] ={0} ", status);
                }

                string sendType = DNTRequest.GetString("sendType");
                if (string.IsNullOrEmpty(sendType))
                {
                    sendType = JsonRequest.GetJsonKeyVal(jsonText, "sendType");
                }
                if (!string.IsNullOrEmpty(sendType))
                {
                    where.AppendFormat(" AND a.[SendType] ={0} ", sendType);
                }


                string key = DNTRequest.GetString("searchKey");
                if (string.IsNullOrEmpty(key))
                {
                    key = JsonRequest.GetJsonKeyVal(jsonText, "searchKey");
                }

                string val = DNTRequest.GetString("searchValue");
                if (string.IsNullOrEmpty(val))
                {
                    val = JsonRequest.GetJsonKeyVal(jsonText, "searchValue");
                    val = System.Web.HttpContext.Current.Server.UrlDecode(val);
                }

                if (string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(val))
                {
                    where.AppendFormat(" and (a.Mobile like'%{0}%' or a.SmsContent like'%{0}%' or convert(varchar,a.CreateDate,120) like '%{0}%' or convert(varchar,a.SendDate,120) like '%{0}%') or a.SendResult like '%{0}%'", val);
                }
                else if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(val))
                {
                    switch (key)
                    {
                        case "1":
                            where.AppendFormat(" and a.Mobile like'%{0}%'", val);
                            break;
                        case "2":
                            where.AppendFormat(" and a.SmsContent like'%{0}%'", val);
                            break;
                        case "3":
                            where.AppendFormat(" and convert(varchar,a.CreateDate,120) like '%{0}%'", val);
                            break;
                        case "4":
                            where.AppendFormat(" and convert(varchar,a.SendDate,120) like '%{0}%'", val);
                            break;
                        case "5":
                            where.AppendFormat(" and a.SendResult like '%{0}%'", val);
                            break;
                    }
                }
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
                SmsSendLogBLL opSmsSendLogBLL = new SmsSendLogBLL();
                DataTable dt = opSmsSendLogBLL.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
                result = DNTRequest.GetResultJson(false, "获取短信发送列表异常，", ex.Message);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 获取短信发送日志详情
        /// <summary>
        /// 获取短信发送日志详情
        /// </summary>
        static public Object GetSmsSendModelJson()
        {
            string result = string.Empty;
            try
            {
                int smsLogId = DNTRequest.GetInt("smsLogId", 0);
                if (smsLogId == 0)
                {
                    result = DNTRequest.GetResultJson(false, "获取短信发送日志失败,请稍后再试", null);
                }
                SmsSendLogBLL op = new SmsSendLogBLL();
                SmsSendLog model = new SmsSendLog();
                if (smsLogId != 0)
                {
                    model = op.GetModel(smsLogId);
                }
                result = DNTRequest.GetResultJson(true, "success", model);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取短信发送日志异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }


        #endregion

        #endregion

        #region 设备管理

        #region 获取设备生产厂家信息
        /// <summary>
        /// 获取设备生产厂家信息
        /// </summary>
        static public Object SupplierList()
        {
            string result = string.Empty;
            try
            {
                StringBuilder where = new StringBuilder();
                where.Append("IsDeleted=0");
                MachineSupplierBLL op = new MachineSupplierBLL();
                List<MachineSupplier> list = op.GetModelList(where.ToString());
                result = DNTRequest.GetResultJson(true, "success", list);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 获取设备生产厂家信息
        /// <summary>
        /// 获取设备生产厂家信息
        /// </summary>
        static public Object GetSupplierList()
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
                where.Append("a.IsDeleted=0");
                DepartmentInfo df = new DepartmentInfo();
                DepartmentInfoBLL bll = new DepartmentInfoBLL();
                df = bll.GetModel(ComPage.CurrentAdmin.DepartmentID);

                if (ComPage.CurrentAdmin.UserType != 1)
                {
                    if ((df == null) || (df != null && df.IsReceiveBusiness != false))
                    {
                        where.AppendFormat(" and a.CreateId in(select ID from [BWJSDB].dbo.[GetDepartmentChildren]({0}))", ComPage.CurrentAdmin.UserID);
                    }
                }


                #region 条件搜索
                string status = DNTRequest.GetString("status");
                if (string.IsNullOrEmpty(status))
                {
                    status = JsonRequest.GetJsonKeyVal(jsonText, "status");
                }
                if (!string.IsNullOrEmpty(status))
                {
                    where.AppendFormat(" and a.[Status]={0}", status);
                }

                string key = DNTRequest.GetString("searchKey");
                if (string.IsNullOrEmpty(key))
                {
                    key = JsonRequest.GetJsonKeyVal(jsonText, "searchKey");
                }

                string val = DNTRequest.GetString("searchValue");
                if (string.IsNullOrEmpty(val))
                {
                    val = JsonRequest.GetJsonKeyVal(jsonText, "searchValue");
                    val = System.Web.HttpContext.Current.Server.UrlDecode(val);
                }

                if (string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(val))
                {
                    where.AppendFormat(" and (a.SupplierName like'%{0}%' or a.Manager like'%{0}%' or a.Mobile like '%{0}%' or a.Address like '%{0}%') ", val);
                }
                else if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(val))
                {
                    switch (key)
                    {
                        case "1":
                            where.AppendFormat(" and a.SupplierName like'%{0}%'", val);
                            break;
                        case "2":
                            where.AppendFormat(" and a.Manager like'%{0}%'", val);
                            break;
                        case "3":
                            where.AppendFormat(" and a.Mobile like '%{0}%'", val);
                            break;
                        case "4":
                            where.AppendFormat(" and a.Address like '%{0}%'", val);
                            break;
                    }
                }
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
                MachineSupplierBLL opMachineSupplierBLL = new MachineSupplierBLL();
                DataTable dt = opMachineSupplierBLL.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #region 删除设备供应商
        /// <summary>
        /// 删除设备供应商
        /// </summary>
        /// <returns></returns>
        static public Object DeleteMachineSupplier()
        {
            string result = string.Empty;
            try
            {
                string machineSupplierIds = DNTRequest.GetString("MachineSupplierId");
                if (string.IsNullOrEmpty(machineSupplierIds))
                {
                    return DNTRequest.GetResultJson(false, "请先选择一条数据", null);
                }
                else
                {
                    MachineSupplierBLL op = new MachineSupplierBLL();
                    bool res = op.DeleteList(machineSupplierIds, ComPage.CurrentAdmin.UserID);
                    if (res)
                    {
                        result = DNTRequest.GetResultJson(true, "删除设备供应商成功", null);
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(false, "删除设备供应商失败，请稍后再试", null);
                    }
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "删除设备供应商异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 获取设备供应商详情
        /// <summary>
        /// 获取设备供应商详情
        /// </summary>
        static public Object GetMachineSupplierModel()
        {
            string result = string.Empty;
            try
            {
                int MachineSupplierId = DNTRequest.GetInt("MachineSupplierId", 0);
                if (MachineSupplierId == 0)
                {
                    result = DNTRequest.GetResultJson(false, "获取设备供应商信息失败,请稍后再试", null);
                }
                MachineSupplierBLL op = new MachineSupplierBLL();
                MachineSupplier model = new MachineSupplier();
                if (MachineSupplierId != 0)
                {
                    model = op.GetModel(MachineSupplierId);
                }
                result = DNTRequest.GetResultJson(true, "success", model);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取设备供应商信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 添加设备供应商
        /// <summary>
        /// 添加设备供应商
        /// </summary>
        /// <returns></returns>
        static public Object AddMachineSupplier()
        {
            string result = string.Empty;
            try
            {
                int MachineSupplierId = DNTRequest.GetInt("MachineSupplierId", 0);
                string objOrder = DNTRequest.GetString("MachineSupplierModel");
                MachineSupplierBLL op = new MachineSupplierBLL();
                MachineSupplier model = JsonConvert.DeserializeObject<MachineSupplier>(objOrder);
                if (MachineSupplierId > 0)
                {
                    #region 修改
                    MachineSupplier modelDB = op.GetModel(MachineSupplierId);
                    modelDB.MachineSupplierId = model.MachineSupplierId;
                    modelDB.SupplierName = model.SupplierName;
                    modelDB.Manager = model.Manager;
                    modelDB.Phone = model.Phone;
                    modelDB.Mobile = model.Mobile;
                    modelDB.Address = model.Address;
                    modelDB.QQ = model.QQ;
                    modelDB.SiteUrl = model.SiteUrl;
                    modelDB.Logo = model.Logo;
                    modelDB.API = model.API;
                    modelDB.QRCode = model.QRCode;
                    modelDB.MainBrand = model.MainBrand;
                    modelDB.MainBusiness = model.MainBusiness;
                    modelDB.Wechat = model.Wechat;
                    modelDB.PublicWechat = model.PublicWechat;
                    modelDB.Remark = model.Remark;
                    modelDB.Status = model.Status;
                    modelDB.EditId = ComPage.CurrentAdmin.UserID;
                    modelDB.EditDate = DateTime.Now;

                    bool res1 = op.Update(modelDB);
                    if (res1)
                    {
                        result = DNTRequest.GetResultJson(true, "修改成功", null);
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(false, "修改失败，请稍候再试", null);
                    }
                    #endregion
                }
                else
                {
                    model.CreateId = ComPage.CurrentAdmin.UserID;
                    model.CreateDate = DateTime.Now;
                    op.Add(model);
                    result = DNTRequest.GetResultJson(true, "添加成功", null);
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "添加设备供应商异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        #endregion

        #region 用户银行卡管理

        #region 获取用户银行卡列表

        /// <summary>
        /// 获取用户银行卡列表
        /// </summary>
        static public Object GetUserBankList()
        {
            string result = string.Empty;
            try
            {
                string sEcho = JsonRequest.GetJsonKeyVal(jsonText, "sEcho");
                int displayStart = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayStart"));
                int displayLength = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayLength"));
                int pageIndex = (displayStart / displayLength) + 1;
                int pageSize = displayLength;

                StringBuilder where = new StringBuilder();
                where.AppendFormat("a.IsDeleted=0");

                int userId = DNTRequest.GetInt("userId", -1);
                if (userId == -1)
                {
                    string tempUserId = JsonRequest.GetJsonKeyVal(jsonText, "userId");
                    if (!string.IsNullOrEmpty(tempUserId))
                    {
                        userId = ComPage.SafeToInt(tempUserId);
                    }
                }
                if (userId != -1)
                {
                    where.AppendFormat(" and a.UserId={0}", userId);
                }
                else
                {
                    where.AppendFormat(" and a.UserId={0}", ComPage.CurrentAdmin.UserID);
                }

                #region 条件搜索

                #region 银行代码
                string bankCode = DNTRequest.GetString("bankCode");
                if (string.IsNullOrEmpty(bankCode))
                {
                    bankCode = JsonRequest.GetJsonKeyVal(jsonText, "bankCode");
                    bankCode = System.Web.HttpContext.Current.Server.UrlDecode(bankCode);
                }
                if (!string.IsNullOrEmpty(bankCode))
                {
                    where.AppendFormat(" and a.BankCode like '%{0}%'", bankCode);
                }
                #endregion

                #region 开户行
                string openingBank = DNTRequest.GetString("openingBank");
                if (string.IsNullOrEmpty(openingBank))
                {
                    openingBank = JsonRequest.GetJsonKeyVal(jsonText, "openingBank");
                    openingBank = System.Web.HttpContext.Current.Server.UrlDecode(openingBank);
                }
                if (!string.IsNullOrEmpty(openingBank))
                {
                    where.AppendFormat(" and a.OpeningBank like '%{0}%'", openingBank);
                }
                #endregion

                #region 持卡人
                string cardHolder = DNTRequest.GetString("cardHolder");
                if (string.IsNullOrEmpty(cardHolder))
                {
                    cardHolder = JsonRequest.GetJsonKeyVal(jsonText, "cardHolder");
                    cardHolder = System.Web.HttpContext.Current.Server.UrlDecode(cardHolder);
                }
                if (!string.IsNullOrEmpty(cardHolder))
                {
                    where.AppendFormat(" and a.CardHolder like '%{0}%'", cardHolder);
                }
                #endregion

                #region 卡号
                string cardNumber = DNTRequest.GetString("cardNumber");
                if (string.IsNullOrEmpty(cardNumber))
                {
                    cardNumber = JsonRequest.GetJsonKeyVal(jsonText, "cardNumber");
                    cardNumber = System.Web.HttpContext.Current.Server.UrlDecode(cardNumber);
                }
                if (!string.IsNullOrEmpty(cardNumber))
                {
                    where.AppendFormat(" and a.CardNumber like '%{0}%'", cardNumber);
                }
                #endregion

                #region 银行地址
                string bankAddress = DNTRequest.GetString("bankAddress");
                if (string.IsNullOrEmpty(bankAddress))
                {
                    bankAddress = JsonRequest.GetJsonKeyVal(jsonText, "bankAddress");
                    bankAddress = System.Web.HttpContext.Current.Server.UrlDecode(bankAddress);
                }
                if (!string.IsNullOrEmpty(bankAddress))
                {
                    where.AppendFormat(" and a.BankAddress like '%{0}%'", bankAddress);
                }
                #endregion

                #endregion

                #region 排序字段
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

                #region 分页查询
                string sql = "";
                int zys = 0;
                int sumcount = 0;
                UserBankBLL opUserBank = new UserBankBLL();
                DataTable dt = opUserBank.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
                #endregion

                #region 查询结果
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
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取用户银行卡信息异常，", ex.Message);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 获取用户银行卡详情
        /// <summary>
        /// 获取用户银行卡详情
        /// </summary>
        static public Object GetUserBankModel()
        {
            string result = string.Empty;
            try
            {
                int userBankId = DNTRequest.GetInt("userBankId", 0);
                if (userBankId == 0)
                {
                    result = DNTRequest.GetResultJson(false, "获取用户银行卡信息失败,请稍后再试", null);
                }
                UserBankBLL op = new UserBankBLL();
                UserBank model = new UserBank();
                if (userBankId != 0)
                {
                    model = op.GetModel(userBankId);
                }
                result = DNTRequest.GetResultJson(true, "success", model);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取用户银行卡信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 添加/修改用户银行卡
        /// <summary>
        /// 添加/修改用户银行卡
        /// </summary>
        /// <returns></returns>
        static public Object AddUserBank()
        {
            string result = string.Empty;
            try
            {
                int userBankId = DNTRequest.GetInt("userBankId", -1);
                string objOrder = DNTRequest.GetString("modelUserBank");
                int userId = DNTRequest.GetInt("userId", -1);

                UserBankBLL op = new UserBankBLL();
                UserBank model = JsonConvert.DeserializeObject<UserBank>(objOrder);
                if (userId != -1)
                {
                    model.UserId = userId;
                }
                else
                {
                    model.UserId = ComPage.CurrentAdmin.UserID;
                }
                if (userBankId > 0)
                {
                    #region 修改
                    bool snExist = op.Exists(ComPage.SafeToInt(model.UserId), userBankId, model.CardNumber);
                    if (!snExist)
                    {
                        UserBank modelDB = op.GetModel(userBankId);
                        modelDB.BankCode = model.BankCode;
                        modelDB.OpeningBank = model.OpeningBank;
                        modelDB.CardHolder = model.CardHolder;
                        modelDB.CardNumber = model.CardNumber;
                        modelDB.BankAddress = model.BankAddress;
                        modelDB.EditId = ComPage.CurrentAdmin.UserID;
                        modelDB.EditDate = DateTime.Now;
                        bool res1 = op.Update(modelDB);
                        if (res1)
                        {
                            result = DNTRequest.GetResultJson(true, "修改成功", null);
                        }
                        else
                        {
                            result = DNTRequest.GetResultJson(false, "修改失败，请稍候再试", null);
                        }
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(false, "修改失败，银行卡号已存在", null);
                    }
                    #endregion
                }
                else
                {
                    #region 添加
                    bool snExist = op.ExistsByCardNumber(ComPage.SafeToInt(model.UserId), model.CardNumber);
                    if (!snExist)
                    {
                        model.IsDefault = false;
                        model.IsDeleted = 0;
                        model.CreateId = ComPage.CurrentAdmin.UserID;
                        model.CreateDate = DateTime.Now;
                        int res1 = op.Add(model);
                        if (res1 > 0)
                        {
                            result = DNTRequest.GetResultJson(true, "添加成功", null);
                        }
                        else
                        {
                            result = DNTRequest.GetResultJson(false, "添加失败，请稍候再试", null);
                        }
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(false, "添加失败，银行卡号已存在", null);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "添加银行卡异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 删除用户银行卡

        /// <summary>
        /// 删除用户银行卡
        /// </summary>
        /// <returns></returns>
        static public Object DeleteUserBank()
        {
            string result = string.Empty;
            try
            {
                string userBankId = DNTRequest.GetString("userBankId");
                if (string.IsNullOrEmpty(userBankId))
                {
                    return DNTRequest.GetResultJson(false, "请先选择一条数据", null);
                }
                else
                {
                    UserBankBLL op = new UserBankBLL();
                    bool res = op.DeleteList(userBankId, ComPage.CurrentAdmin.UserID);
                    if (res)
                    {
                        result = DNTRequest.GetResultJson(true, "删除银行卡成功", null);
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(false, "删除银行卡失败，请稍后再试", null);
                    }
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "删除银行卡异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 修改默认银行卡

        /// <summary>
        /// 修改默认银行卡
        /// </summary>
        /// <returns></returns>
        static public Object SetIsDefault()
        {
            string result = string.Empty;
            try
            {
                int userBankId = DNTRequest.GetInt("userBankId", -1);
                int userId = DNTRequest.GetInt("userId", -1);
                if (userId == -1)
                {
                    userId = ComPage.CurrentAdmin.UserID;
                }
                if (userBankId == -1)
                {
                    return DNTRequest.GetResultJson(false, "请先选择一条数据", null);
                }
                else
                {
                    UserBankBLL op = new UserBankBLL();
                    bool res = op.SetDefault(userBankId, userId, ComPage.CurrentAdmin.UserID);
                    if (res)
                    {
                        result = DNTRequest.GetResultJson(true, "设置默认银行卡成功", null);
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(false, "设置默认银行卡失败，请稍后再试", null);
                    }
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "删除银行卡异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #endregion

        #region 修改密码

        public static string UserUpdatePwd()
        {
            string result = string.Empty;
            string msg = string.Empty;
            try
            {
                int userId = DNTRequest.GetInt("userId", 0);
                if (userId <= 0)
                {
                    result = DNTRequest.GetResultJson(false, "获取用户信息失败,请稍后再试", null);
                }
                string oldPwd = DNTRequest.GetString("oldPwd");
                string newPwd = DNTRequest.GetString("newPwd");
                UsersBLL op = new UsersBLL();
                if (userId != 0)
                {
                    bool b = op.UserUpdatePwd(newPwd, oldPwd, userId, out msg);
                    if (!b)
                    {
                        result = DNTRequest.GetResultJson(false, msg, null);
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(true, "success", null);
                    }
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "修改用户信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion
        /// <summary>
        /// 获取设备列表
        /// </summary>
        static public Object GetSysConfigList()
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
                where.Append(" a.RecordIsDelete=0 ");
                DepartmentInfo df = new DepartmentInfo();
                DepartmentInfoBLL bll = new DepartmentInfoBLL();
                df = bll.GetModel(ComPage.CurrentAdmin.DepartmentID);
                if (ComPage.CurrentAdmin.UserType != 1)
                {
                    if ((df == null) || (df != null && df.IsReceiveBusiness != false))
                    {
                        where.Append(" AND  a.UserID IN (select ID from [BWJSDB].dbo.[GetDepartmentChildren](" + ComPage.CurrentAdmin.UserID + "))");
                    }
                }

                #region 条件搜索
                string status = DNTRequest.GetString("status");
                if (string.IsNullOrEmpty(status))
                {
                    status = JsonRequest.GetJsonKeyVal(jsonText, "status");
                }
                if (!string.IsNullOrEmpty(status))
                {
                    where.AppendFormat(" AND a.[Status]={0} ", status);
                }

                string key = DNTRequest.GetString("searchKey");
                if (string.IsNullOrEmpty(key))
                {
                    key = JsonRequest.GetJsonKeyVal(jsonText, "searchKey");
                }

                string val = DNTRequest.GetString("searchValue");
                if (string.IsNullOrEmpty(val))
                {
                    val = JsonRequest.GetJsonKeyVal(jsonText, "searchValue");
                    val = System.Web.HttpContext.Current.Server.UrlDecode(val);
                }

                if (string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(val))
                {
                    where.AppendFormat(" AND (a.SN like'%{0}%' or a.MAC like'%{0}%' or a.Address like '%{0}%') ", val);
                }
                else if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(val))
                {
                    switch (key)
                    {
                        case "1":
                            where.AppendFormat(" and a.SN like'%{0}%'", val);
                            break;
                        case "2":
                            where.AppendFormat(" and a.MAC like'%{0}%'", val);
                            break;
                        case "3":
                            where.AppendFormat(" and a.Address like '%{0}%'", val);
                            break;
                        case "4":
                            where.AppendFormat(" and (a.Longitude like '%{0}%' or a.Latitude like '%{0}%')", val);
                            break;
                        case "5":
                            where.AppendFormat(" and a.TeamViewerNumber like '%{0}%'", val);
                            break;
                        case "6":
                            where.AppendFormat(" and a.Remark like '%{0}%'", val);
                            break;
                    }
                }
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
                SysConfigBLL oSysConfig = new SysConfigBLL();

                DataTable dt = oSysConfig.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
                result = DNTRequest.GetResultJson(false, "获取设备列表信息失败", ex.Message);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        static public Object BinDingUsersMachine()
        {
            string result = string.Empty;
            try
            {
                int MachineID = DNTRequest.GetInt("MachineID", 0);
                string usersId = DNTRequest.GetString("usersId");
                R_UsersMachineBLL op = new R_UsersMachineBLL();
                op.DeleteListByMachineID(MachineID);//删除所有设备相关的
                if (!string.IsNullOrEmpty(usersId))
                { 
                    string[] arrayId = usersId.TrimEnd(',').Split(',');
                    int[] IUserId = Array.ConvertAll<string, int>(arrayId, s => int.Parse(s));
                    for (int i = 0; i < IUserId.Length; i++)
                    {
                        R_UsersMachine model = new R_UsersMachine();
                        model.RecordCreateTime = DateTime.Now;
                        model.RecordIsDelete = false;
                        model.RecordUpdateTime = DateTime.Now;
                        model.MachineID = MachineID;
                        model.UserID = IUserId[i];
                        op.Add(model);
                    }
                }  
                result = DNTRequest.GetResultJson(true, "绑定成功", null);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "绑定用户信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        static public Object GetBinDingUsers()
        {
            string result = string.Empty;
            try
            { 
                int machineId = DNTRequest.GetInt("machineId", 0);
                R_UsersMachineBLL op = new R_UsersMachineBLL();
                UsersBLL oUsers = new UsersBLL();
                List<Users> list = new List<Users>();
                StringBuilder where = new StringBuilder();
                where.AppendFormat("MachineID=" + machineId + "  AND  RecordIsDelete=0");
                List<R_UsersMachine> olistUserMachine = op.GetModelList(where.ToString());

                string userIds = string.Empty;
                foreach (var oUM in olistUserMachine)
                {
                    userIds = userIds + "," + oUM.UserID;
                }
                userIds = userIds.TrimStart(',').TrimEnd(',');
                string sqlStr = "UserID in (" + userIds + ")";
                list = oUsers.GetModelList(sqlStr);
                result = DNTRequest.GetResultJson(true, "success", list); 
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取商家异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
    }
}
