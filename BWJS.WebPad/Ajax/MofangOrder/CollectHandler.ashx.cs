using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilityHelper;

namespace BWJS.WebPad.Ajax.MofangOrder
{
    /// <summary>
    /// CollectHandler 的摘要说明
    /// </summary>
    public class CollectHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Form["Action"];
            string beginDate = ""; string dataValue = ""; string dataUnit = "";
            beginDate = context.Request.Form["beginDate"];
            dataValue = context.Request.Form["dataValue"];
            dataUnit = context.Request.Form["dataUnit"];
            string words = context.Request.Form["words"];
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            try
            {
                switch (action)
                {
                    case "001":
                        GetEndDate(beginDate, dataValue, dataUnit, Request, Response);
                        break; 
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                //错误日志
            }
        } 
        public void GetEndDate(string beginDate, string dataValue, string dataUnit, HttpRequest Request, HttpResponse Response)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(beginDate))
            {
                DateTime dt = Convert.ToDateTime(beginDate);
                int dataNum = CommonHelper.GetNumFromStr(dataValue).ToInt();
                switch (dataUnit)
                {
                    case "年":
                        result = dt.AddYears(dataNum).ToString("yyyy-MM-dd");
                        break;
                    case "月":
                        result = dt.AddMonths(dataNum).ToString("yyyy-MM-dd");
                        break;
                    default:
                        result = dt.AddDays(dataNum).ToString("yyyy-MM-dd");
                        break;
                }
            }
            Response.Write(result);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}