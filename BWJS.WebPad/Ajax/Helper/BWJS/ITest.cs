using UtilityHelper;
using BWJS.AppCode;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using BWJSLog.BLL;

namespace BWJS.WebPad.Ajax.Helper
{
    /// <summary>
    /// 测试的调度实现
    /// </summary>
    [DataContract]
    public partial class ITest
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
                    case "test":
                        HttpContext.Current.Response.Write(Test());
                        break;
                    case "jqgrid":
                        HttpContext.Current.Response.Write(GetJqGrid());
                        break;
                    case "writecookie":
                        HttpContext.Current.Response.Write(WriteCookie());
                        break;
                    case "getcookie":
                        HttpContext.Current.Response.Write(GetCookie());
                        break;

                }

                #endregion
            }
        }

        #region Test

        /// <summary>
        /// 检查是否已登录
        /// </summary>
        /// <returns></returns>
        static public Object Test()
        {
            string result = string.Empty;
            try
            {
                string sEcho = JsonRequest.GetJsonKeyVal(jsonText, "sEcho");
                int displayStart = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayStart"));
                int displayLength = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayLength"));

                string sSearch = JsonRequest.GetJsonKeyVal(jsonText, "sSearch");
                string iSortCol_0 = JsonRequest.GetJsonKeyVal(jsonText, "iSortCol_0");
                string sSortDir_0 = JsonRequest.GetJsonKeyVal(jsonText, "sSortDir_0");
                int iSortingCols = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iSortingCols"));

                string timeStamp = JsonRequest.GetJsonKeyVal(jsonText, "timeStamp");
                int pageIndex = (displayStart / displayLength) + 1;
                int pageSize = displayLength;
                string orderBy = string.Empty;
                if (!string.IsNullOrEmpty(iSortCol_0))
                {
                    string orderField = JsonRequest.GetJsonKeyVal(jsonText, string.Format("mDataProp_{0}", iSortCol_0));
                    orderBy = string.Format(" order by {0} {1}", orderField, sSortDir_0);
                }

                List<object> list = new List<object>();
                //list.Sort();
                int totalCount = 1000;
                for (int i = 1; i <= totalCount; i++)
                {
                    if (i > displayStart && i <= (displayStart + displayLength))
                    {
                        object data = new
                        {
                            Id = i,
                            Name = "hfm" + i.ToString().PadLeft(4, '0'),
                            Sex = new Random().Next(0, 2).ToString(),
                            CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        };
                        list.Add(data);
                    }
                }
                object obj = new
                {
                    result = true,
                    code = "",
                    msg = "",
                    recordsTotal = totalCount,
                    recordsFiltered = totalCount,
                    data = list,

                    sEcho = sEcho,

                    #region 注释
                    //iColumns = 6,
                    //sColumns = "",
                    //mDataProp_0 = "Id",
                    //sSearch_0 = "",
                    //bRegex_0 = false,
                    //bSearchable_0 = true,
                    //bSortable_0 = false,
                    //mDataProp_1 = "Id",
                    //sSearch_1 = "",
                    //bRegex_1 = false,
                    //bSearchable_1 = true,
                    //bSortable_1 = true,
                    //mDataProp_2 = "Name",
                    //sSearch_2 = "",
                    //bRegex_2 = false,
                    //bSearchable_2 = true,
                    //bSortable_2 = true,
                    //mDataProp_3 = "Sex",
                    //sSearch_3 = "",
                    //bRegex_3 = false,
                    //bSearchable_3 = true,
                    //bSortable_3 = true,
                    //mDataProp_4 = "CreateDate",
                    //sSearch_4 = "",
                    //bRegex_4 = false,
                    //bSearchable_4 = true,
                    //bSortable_4 = true,
                    //mDataProp_5 = "",
                    //sSearch_5 = "",
                    //bRegex_5 = false,
                    //bSearchable_5 = true,
                    //bSortable_5 = true, 
                    //sSearch = "",
                    //bRegex = false,
                    //iSortCol_0 = 0,
                    //sSortDir_0 = "asc",
                    //iSortingCols = 1,
                    #endregion

                };
                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                Log.WriteLog(" " + ex);
            }
            return result;
        }
        #endregion

        #region JqGrid

        /// <summary>
        /// JqGrid
        /// </summary>
        static public Object GetJqGrid()
        {
            string result = string.Empty;
            try
            {
                string msg = string.Empty;
                msg += "Form=";
                for (int i = 0; i < System.Web.HttpContext.Current.Request.Form.Count; i++)
                {
                    msg += System.Web.HttpContext.Current.Request.Form[i] + ",";
                }
                msg += "|QueryString=";
                for (int i = 0; i < System.Web.HttpContext.Current.Request.QueryString.Count; i++)
                {
                    msg += System.Web.HttpContext.Current.Request.QueryString[i] + ",";
                }
                msg += "|jsonText=";
                System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                System.Web.HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
                byte[] reqData = System.Web.HttpContext.Current.Request.BinaryRead(System.Web.HttpContext.Current.Request.TotalBytes);
                msg += Encoding.Default.GetString(reqData);

                return msg;

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                Log.WriteLog(" " + ex);
            }
            return result;
        }
        #endregion

        #region 写Cookie

        /// <summary>
        /// 写Cookie
        /// </summary>
        /// <returns></returns>
        static public Object WriteCookie()
        {
            string result = string.Empty;
            try
            {
                string token = DNTRequest.GetString("token");

                string apiUrl = loanApi + "/TestApi/WriteCookie";
                string postParamters = string.Format("");
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJson(false, "异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 读Cookie

        /// <summary>
        /// 读Cookie
        /// </summary>
        /// <returns></returns>
        static public Object GetCookie()
        {
            string result = string.Empty;
            try
            {
                string token = DNTRequest.GetString("token");

                string apiUrl = loanApi + "/TestApi/GetCookie";
                string postParamters = string.Format("");
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponse(apiUrl, postParamters, contentType, postMethod);
                result = outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJson(false, "异常，请稍后再试", null);
            }
            return result;
        }
        #endregion
    }
}
