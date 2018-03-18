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
using System.Transactions;

namespace BWJS.WebApp.Ajax.Helper
{
    /// <summary>
    /// 结算的调度实现
    /// </summary>
    [DataContract]
    public partial class ISettlement
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
                    case "getsettlementlist":
                        HttpContext.Current.Response.Write(GetSettlementList());
                        break;
                    case "queryOrder":
                        HttpContext.Current.Response.Write(QueryOrderList());
                        break;
                    case "applysettlement":
                        HttpContext.Current.Response.Write(ApplySettlement());
                        break;
                    case "getsettlementmodel":
                        HttpContext.Current.Response.Write(GetSettlementModel());
                        break;
                    case "confirmsettlement":
                        HttpContext.Current.Response.Write(ConfirmSettlement());
                        break;

                }

                #endregion
            }
        }


        #region 结算管理

        #region 获取结算申请列表

        /// <summary>
        /// 获取结算申请列表
        /// </summary>
        static public Object GetSettlementList()
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
                where.Append("a.IsDeleted=0 ");

                #region 权限
                if (ComPage.CurrentAdmin.UserType != 1)
                {
                    where.Append("AND  a.UserID IN (select ID from [dbo].[GetChildrenRole](" + ComPage.CurrentAdmin.UserID + "))");
                }
                #endregion

                #region 条件搜索

                #region 结算方式
                string settlementMethod = DNTRequest.GetString("settlementMethod");
                if (string.IsNullOrEmpty(settlementMethod))
                {
                    settlementMethod = JsonRequest.GetJsonKeyVal(jsonText, "settlementMethod");
                }
                if (!string.IsNullOrEmpty(settlementMethod))
                {
                    where.AppendFormat(" and a.SettlementMethod={0}", settlementMethod);
                }
                #endregion

                #region 支付方式
                string paymentMethod = DNTRequest.GetString("paymentMethod");
                if (string.IsNullOrEmpty(paymentMethod))
                {
                    paymentMethod = JsonRequest.GetJsonKeyVal(jsonText, "paymentMethod");
                }
                if (!string.IsNullOrEmpty(paymentMethod))
                {
                    where.AppendFormat(" and a.PaymentMethod={0}", paymentMethod);
                }
                #endregion

                #region 结算状态
                string status = DNTRequest.GetString("status");
                if (string.IsNullOrEmpty(status))
                {
                    status = JsonRequest.GetJsonKeyVal(jsonText, "status");
                }
                if (!string.IsNullOrEmpty(status))
                {
                    where.AppendFormat(" and a.ApplyStatus={0}", status);
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
                    where.AppendFormat(" and b.UserName like'%{0}%'", merchantName);
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
                    where.AppendFormat(" and a.OpeningBank like'%{0}%'", openingBank);
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
                    where.AppendFormat(" and a.CardHolder like'%{0}%'", cardHolder);
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

                #region 备注
                string remark = DNTRequest.GetString("remark");
                if (string.IsNullOrEmpty(remark))
                {
                    remark = JsonRequest.GetJsonKeyVal(jsonText, "remark");
                    remark = System.Web.HttpContext.Current.Server.UrlDecode(remark);
                }
                if (!string.IsNullOrEmpty(remark))
                {
                    where.AppendFormat(" and a.Remark like '%{0}%'", remark);
                }
                #endregion

                #region 结算金额
                string applyMoney = DNTRequest.GetString("applyMoney");
                if (string.IsNullOrEmpty(applyMoney))
                {
                    applyMoney = JsonRequest.GetJsonKeyVal(jsonText, "applyMoney");
                    applyMoney = System.Web.HttpContext.Current.Server.UrlDecode(applyMoney);
                }
                if (!string.IsNullOrEmpty(applyMoney))
                {
                    where.AppendFormat(" and (a.ApplyMoney={0} or a.ActualMoney={0})", applyMoney);
                }
                #endregion

                #region 结算周期
                string startDate = DNTRequest.GetString("startDate");
                if (string.IsNullOrEmpty(applyMoney))
                {
                    startDate = JsonRequest.GetJsonKeyVal(jsonText, "startDate");
                    startDate = System.Web.HttpContext.Current.Server.UrlDecode(startDate);
                }
                string endDate = DNTRequest.GetString("endDate");
                if (string.IsNullOrEmpty(endDate))
                {
                    endDate = JsonRequest.GetJsonKeyVal(jsonText, "endDate");
                    endDate = System.Web.HttpContext.Current.Server.UrlDecode(endDate);
                }

                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    where.AppendFormat(" and (a.StartDate>='{0} 00:00:00' and a.EndDate<='{1} 23:59:59')", startDate, endDate);
                }
                else if (string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    where.AppendFormat(" and (a.StartDate>='{0} 00:00:00' and a.EndDate<='{1} 23:59:59')", endDate, endDate);
                }
                else if (!string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(endDate))
                {
                    where.AppendFormat(" and (a.StartDate>='{0} 00:00:00' and a.EndDate<='{1} 23:59:59')", startDate, startDate);
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
                OrderRebateSettlementApplyBLL opOrderRebateSettlementApplyBLL = new OrderRebateSettlementApplyBLL();
                DataTable dt = opOrderRebateSettlementApplyBLL.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
                result = DNTRequest.GetResultJson(false, "获取结算申请信息异常，", ex.Message);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 查询可结算订单列表

        /// <summary>
        /// 查询可结算订单列表
        /// </summary>
        static public Object QueryOrderList()
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
                where.Append("b.ProductId=0");
                #region 查询条件

                #region 商家
                string UserId = DNTRequest.GetString("UserId");
                if (string.IsNullOrEmpty(UserId))
                {
                    UserId = JsonRequest.GetJsonKeyVal(jsonText, "UserId");
                }
                if (!string.IsNullOrEmpty(UserId))
                {
                    where.AppendFormat(" and a.UserId={0}", UserId);
                }
                #endregion

                #region 渠道
                string CompanyId = DNTRequest.GetString("CompanyId");
                if (string.IsNullOrEmpty(CompanyId))
                {
                    CompanyId = JsonRequest.GetJsonKeyVal(jsonText, "CompanyId");
                }
                if (!string.IsNullOrEmpty(CompanyId))
                {
                    where.AppendFormat(" and a.CompanyId={0}", CompanyId);
                }
                #endregion

                #region 结算周期
                string StartDate = DNTRequest.GetString("StartDate");
                if (string.IsNullOrEmpty(StartDate))
                {
                    StartDate = JsonRequest.GetJsonKeyVal(jsonText, "StartDate");
                }

                string EndDate = DNTRequest.GetString("EndDate");
                if (string.IsNullOrEmpty(EndDate))
                {
                    EndDate = JsonRequest.GetJsonKeyVal(jsonText, "EndDate");
                }

                if (!string.IsNullOrEmpty(StartDate) && !string.IsNullOrEmpty(EndDate))
                {
                    where.AppendFormat(" and a.CreateDate between '{0} 00:00:00' and '{1} 23:59:59'", StartDate, EndDate);
                }
                else if (string.IsNullOrEmpty(StartDate) && !string.IsNullOrEmpty(EndDate))
                {
                    where.AppendFormat(" and a.CreateDate<='{0} 23:59:59'", EndDate);
                }
                else if (!string.IsNullOrEmpty(StartDate) && string.IsNullOrEmpty(EndDate))
                {
                    where.AppendFormat(" and a.CreateDate>='{0} 00:00:00'", StartDate);
                }
                #endregion

                #endregion

                #region 固定的查询条件
                where.Append(" and a.IsDeleted=0 and a.PayStatus=1 and a.IsSettled=0 and a.IsCancel=0");
                #endregion

                #region 执行sql
                OrderRebateBLL op = new OrderRebateBLL();
                DataTable dt = op.QueryOrderList(where.ToString());
                #endregion

                #region 结果处理
                double sumOrderMoney = 0;
                double sumMerchantMoney = 0;
                double sumAgentMoney = 0;
                double sumHQMoney = 0;
                double sumNetProfit = 0;
                double sumApplyMoney = 0;
                int totalCount = 0;
                if (dt != null && dt.Rows.Count > 0)
                {
                    totalCount = dt.Rows.Count;
                    foreach (DataRow dr in dt.Rows)
                    {
                        sumOrderMoney += Math.Round(ComPage.SafeToDouble(dr["sumOrderMoney"]), 2, MidpointRounding.AwayFromZero);
                        sumMerchantMoney += Math.Round(ComPage.SafeToDouble(dr["sumMerchantMoney"]), 2, MidpointRounding.AwayFromZero);
                        sumAgentMoney += Math.Round(ComPage.SafeToDouble(dr["sumAgentMoney"]), 2, MidpointRounding.AwayFromZero);
                        sumHQMoney += Math.Round(ComPage.SafeToDouble(dr["sumHQMoney"]), 2, MidpointRounding.AwayFromZero);
                        sumNetProfit += Math.Round(ComPage.SafeToDouble(dr["sumNetProfit"]), 2, MidpointRounding.AwayFromZero);
                        int settlementMethod = ComPage.SafeToInt(dr["SettlementMethod"]);
                        double salesPercentage = ComPage.SafeToDouble(dr["SalesPercentage"]);
                        int userType = ComPage.SafeToInt(dr["UserType"]);
                        switch (settlementMethod)
                        {
                            case 1:
                                #region 销售额百分比分成
                                double salesPercentageMoney = (sumOrderMoney * salesPercentage) / 100;
                                sumApplyMoney += Math.Round(salesPercentageMoney, 2, MidpointRounding.AwayFromZero);
                                #endregion
                                break;
                            case 2:
                                #region 单笔结算分成
                                switch (userType)
                                {
                                    case 2://经销商
                                        sumApplyMoney += Math.Round(sumMerchantMoney, 2, MidpointRounding.AwayFromZero);
                                        break;
                                    case 3://代理商
                                        sumApplyMoney += Math.Round(sumAgentMoney, 2, MidpointRounding.AwayFromZero);
                                        break;
                                }
                                #endregion
                                break;
                        }

                    }
                }
                #endregion

                #region 拼装返回结果
                var obj = new
                {
                    result = true,
                    code = "",
                    msg = "",
                    sumOrderMoney = sumOrderMoney,
                    sumMerchantMoney = sumMerchantMoney,
                    sumAgentMoney = sumAgentMoney,
                    sumHQMoney = sumHQMoney,
                    sumNetProfit = sumNetProfit,
                    sumApplyMoney = sumApplyMoney,
                    recordsTotal = totalCount,
                    recordsFiltered = totalCount,
                    data = ((dt == null) ? (new DataTable()) : (dt)),
                    sEcho = sEcho
                };
                #endregion

                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                #endregion
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取结算申请信息异常，", ex.Message);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 申请结算提交
        /// <summary>
        /// 申请结算提交
        /// </summary>
        /// <returns></returns>
        static public Object ApplySettlement()
        {
            string result = string.Empty;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    string userIdAndDepartmentId = DNTRequest.GetString("userIdAndDepartmentId");
                    if (string.IsNullOrEmpty(userIdAndDepartmentId))
                    {
                        return DNTRequest.GetResultJson(false, "请先选择需要结算的商户", null);
                    }
                    int userId = 0;
                    int departmentId = 0;
                    if (!string.IsNullOrEmpty(userIdAndDepartmentId))
                    {
                        string[] userIdAndDepartmentIdList = userIdAndDepartmentId.Split(new char[] { ',' });
                        userId = ComPage.SafeToInt(userIdAndDepartmentIdList[0]);
                        departmentId = ComPage.SafeToInt(userIdAndDepartmentIdList[1]);
                    }
                    if (userId == 0)
                    {
                        return DNTRequest.GetResultJson(false, "请先选择需要结算的商户", null);
                    }

                    //订单返利结算申请表主键
                    int orderRebateSettlementApplyId = 0;
                    int res01 = 0;
                    int res02 = 0;

                    #region 订单返利结算申请信息入库
                    string objOrderRebateSettlementApply = DNTRequest.GetString("modelOrderRebateSettlementApply");
                    OrderRebateSettlementApply postOrderRebateSettlementApply = JsonConvert.DeserializeObject<OrderRebateSettlementApply>(objOrderRebateSettlementApply);

                    OrderRebateSettlementApplyBLL opOrderRebateSettlementApply = new OrderRebateSettlementApplyBLL();
                    OrderRebateSettlementApply modelOrderRebateSettlementApply = new OrderRebateSettlementApply();
                    modelOrderRebateSettlementApply.UserId = userId;
                    modelOrderRebateSettlementApply.DepartmentId = departmentId;
                    modelOrderRebateSettlementApply.StartDate = postOrderRebateSettlementApply.StartDate;
                    modelOrderRebateSettlementApply.EndDate = postOrderRebateSettlementApply.EndDate;
                    modelOrderRebateSettlementApply.ApplyMoney = postOrderRebateSettlementApply.ApplyMoney;
                    modelOrderRebateSettlementApply.ActualMoney = postOrderRebateSettlementApply.ActualMoney;
                    modelOrderRebateSettlementApply.ApplyStatus = 0;
                    modelOrderRebateSettlementApply.SettlementMethod = null;
                    modelOrderRebateSettlementApply.SalesPercentage = 0;
                    modelOrderRebateSettlementApply.PaymentMethod = postOrderRebateSettlementApply.PaymentMethod;
                    modelOrderRebateSettlementApply.OpeningBank = postOrderRebateSettlementApply.OpeningBank;
                    modelOrderRebateSettlementApply.CardHolder = postOrderRebateSettlementApply.CardHolder;
                    modelOrderRebateSettlementApply.CardNumber = postOrderRebateSettlementApply.CardNumber;
                    modelOrderRebateSettlementApply.Remark = postOrderRebateSettlementApply.Remark;
                    modelOrderRebateSettlementApply.CreateId = ComPage.CurrentAdmin.UserID;
                    modelOrderRebateSettlementApply.CreateDate = DateTime.Now;
                    modelOrderRebateSettlementApply.EditId = null;
                    modelOrderRebateSettlementApply.EditDate = null;
                    modelOrderRebateSettlementApply.IsDeleted = 0;

                    orderRebateSettlementApplyId = opOrderRebateSettlementApply.Add(modelOrderRebateSettlementApply);
                    #endregion

                    #region 结算申请详情信息入库和修改订单返利结算申请表的结算状态为已申请
                    if (orderRebateSettlementApplyId > 0)
                    {
                        #region 结算申请详情信息入库和修改订单返利结算申请表的结算状态为已申请

                        StringBuilder where = new StringBuilder();
                        where.Append("b.ProductId=0");
                        #region 获取结算申请列表查询条件
                        string UserId = DNTRequest.GetString("UserId");
                        if (string.IsNullOrEmpty(UserId))
                        {
                            UserId = JsonRequest.GetJsonKeyVal(jsonText, "UserId");
                        }
                        if (!string.IsNullOrEmpty(UserId))
                        {
                            where.AppendFormat(" and a.UserId={0}", UserId);
                        }

                        string CompanyId = DNTRequest.GetString("CompanyId");
                        if (string.IsNullOrEmpty(CompanyId))
                        {
                            CompanyId = JsonRequest.GetJsonKeyVal(jsonText, "CompanyId");
                        }
                        if (!string.IsNullOrEmpty(CompanyId))
                        {
                            where.AppendFormat(" and a.CompanyId={0}", CompanyId);
                        }

                        string StartDate = DNTRequest.GetString("StartDate");
                        if (string.IsNullOrEmpty(StartDate))
                        {
                            StartDate = JsonRequest.GetJsonKeyVal(jsonText, "StartDate");
                        }

                        string EndDate = DNTRequest.GetString("EndDate");
                        if (string.IsNullOrEmpty(EndDate))
                        {
                            EndDate = JsonRequest.GetJsonKeyVal(jsonText, "EndDate");
                        }

                        if (!string.IsNullOrEmpty(StartDate) && !string.IsNullOrEmpty(EndDate))
                        {
                            where.AppendFormat(" and a.CreateDate between '{0} 00:00:00' and '{1} 23:59:59'", StartDate, EndDate);
                        }
                        else if (string.IsNullOrEmpty(StartDate) && !string.IsNullOrEmpty(EndDate))
                        {
                            where.AppendFormat(" and a.CreateDate<='{0} 23:59:59'", EndDate);
                        }
                        else if (!string.IsNullOrEmpty(StartDate) && string.IsNullOrEmpty(EndDate))
                        {
                            where.AppendFormat(" and a.CreateDate >= '{0} 00:00:00'", StartDate);
                        }

                        #endregion

                        where.Append(" and a.IsDeleted=0 and a.PayStatus=1 and a.IsSettled=0 and a.IsCancel=0");
                        OrderRebateBLL op = new OrderRebateBLL();
                        op.ApplySettlement(orderRebateSettlementApplyId, ComPage.CurrentAdmin.UserID, where.ToString(), ref res01, ref res02);

                        #endregion
                    }
                    #endregion
                    if (orderRebateSettlementApplyId > 0 && res01 > 0 && res02 > 0)
                    {
                        ts.Complete();
                        result = DNTRequest.GetResultJson(true, "申请结算成功", null);
                    }
                    else
                    {
                        ts.Dispose();
                        result = DNTRequest.GetResultJson(false, "申请结算失败，请稍后再试", null);
                    }
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                    result = DNTRequest.GetResultJson(false, "申请结算异常，请稍后再试", null);
                    ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                }
            }
            return result;
        }

        #endregion

        #region 获取结算申请信息
        /// <summary>
        /// 获取结算申请信息
        /// </summary>
        static public Object GetSettlementModel()
        {
            string result = string.Empty;
            try
            {
                int orderRebateSettlementApplyId = DNTRequest.GetInt("OrderRebateSettlementApplyId", 0);
                if (orderRebateSettlementApplyId == 0)
                {
                    result = DNTRequest.GetResultJson(false, "获取结算申请信息失败,请稍后再试", null);
                }
                OrderRebateSettlementApplyBLL op = new OrderRebateSettlementApplyBLL();
                OrderRebateSettlementApply model = new OrderRebateSettlementApply();
                if (orderRebateSettlementApplyId != 0)
                {
                    model = op.GetModel(orderRebateSettlementApplyId);
                }
                result = DNTRequest.GetResultJson(true, "success", model);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取结算申请信息异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 确认结算
        /// <summary>
        /// 确认结算
        /// </summary>
        /// <returns></returns>
        static public Object ConfirmSettlement()
        {
            string result = string.Empty;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    string orderRebateSettlementApplyId = DNTRequest.GetString("OrderRebateSettlementApplyId");
                    if (string.IsNullOrEmpty(orderRebateSettlementApplyId))
                    {
                        return DNTRequest.GetResultJson(false, "请先选择确认结算的商户", null);
                    }
                    if (!string.IsNullOrEmpty(orderRebateSettlementApplyId))
                    {
                        OrderRebateSettlementApplyBLL opOrderRebateSettlementApply = new OrderRebateSettlementApplyBLL();
                        OrderRebateSettlementApply modelOrderRebateSettlementApply = new OrderRebateSettlementApply();

                        //更新结算申请表结算状态为已结算和更新订单表结算状态为已结算
                        int res01 = 0;
                        int res02 = 0;
                        opOrderRebateSettlementApply.ConfirmSettlement(orderRebateSettlementApplyId, ComPage.CurrentAdmin.UserID, ref res01, ref res02);

                        if (res01 > 0 && res02 > 0)
                        {
                            ts.Complete();
                            result = DNTRequest.GetResultJson(true, "确认结算成功", null);
                        }
                        else
                        {
                            ts.Dispose();
                            result = DNTRequest.GetResultJson(false, "确认结算失败，请稍后再试", null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                    result = DNTRequest.GetResultJson(false, "确认结算异常，请稍后再试", null);
                    ExceptionLogBLL.WriteExceptionLogToDB("确认结算异常，" + ex.ToString());
                }
            }
            return result;
        }

        #endregion

        #endregion
    }
}
