using MofangInterface.BLL;
using MofangInterface.Model.InputModel;
using MofangInterface.Model.OutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilityHelper;

namespace BWJS.WebPad.Ajax.MofangOrder
{
    /// <summary>
    /// HealthHandler 的摘要说明
    /// </summary>
    public class HealthHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        BaoxianDataBLL baoxianBLL = new BaoxianDataBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Form["Action"];
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            try
            {
                switch (action)
                {
                    case "001":
                        GetHealth(Request, Response);
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
        public void GetHealth(HttpRequest Request, HttpResponse Response)
        {
            string TransNo = UtilityHelper.BWJSCommonHelper.SafeString(Request["transNo"], ""); 
            string Answer = UtilityHelper.BWJSCommonHelper.SafeString(Request["answer"], "");
            HealthNotifyReq trialReq = new HealthNotifyReq();
            trialReq.transNo = TransNo;
            string s = UtilityHelper.Utils.MD5(SerializerHelper.SerializeObject(Answer));
            trialReq.answer = s; 
            HealthNotifyResp resp = new HealthNotifyResp();
            resp = baoxianBLL.HealthAnswerSubmit(trialReq);
            string strJson = SerializerHelper.SerializeObject(resp);
            Response.Write(strJson);
        }
    } 
}