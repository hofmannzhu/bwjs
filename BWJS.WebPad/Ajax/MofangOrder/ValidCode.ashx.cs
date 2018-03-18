using BWJS.SMS;
using BWJSLog.BLL;
using BWJSLog.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BWJS.WebPad.Ajax.MofangOrder
{
    /// <summary>
    /// ValidCode 的摘要说明
    /// </summary>
    public class ValidCode : IHttpHandler, IRequiresSessionState
    { 
        public void ProcessRequest(HttpContext context)
        { 
            string action = context.Request.Form["Action"];
            context.Response.ContentType = "text/plain";
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            try
            {
                switch (action)
                {
                    case "ValidCodeAction":
                        GetValidCode(Request, Response,context);
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
       public void GetValidCode(HttpRequest Request, HttpResponse Response,HttpContext context)
        {
            string moblie = UtilityHelper.BWJSCommonHelper.SafeString(Request["moblie"], "");

            //1.随即生成4位数字(及1000到9999之间的数字)  
            Random rdm = new Random();
            int number = rdm.Next(1000, 10000);
            context.Session["ValidCode"] = number.ToString();  
            SmsHelper.DoSend(moblie, null, "您的验证码：" + number.ToString()+ "  如非本人操作，请勿将验证码告诉他人。 【牛牛通宝】 ", null, string.Empty);
            context.Response.Write("{\"isSend\":\"ok\",\"number\":" + number + ",\"moblie\":" + moblie + "}");
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