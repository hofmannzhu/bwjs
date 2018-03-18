using MofangInterface.BLL;
using MofangInterface.Model;
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
    /// RestrictGenes 的摘要说明
    /// </summary>
    public class RestrictGenesHandler : IHttpHandler
    {
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
                        GetRestrictGenes(Request, Response);
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public void GetRestrictGenes(HttpRequest Request, HttpResponse Response)
        {
            TrialReq trialReq = new TrialReq();
            string JsonTrialReq = Request.Form["JsonTrialReq"];
            if (string.IsNullOrEmpty(JsonTrialReq))
            {
                Response.Write("strTrialReq不能为空");
            }
            trialReq = SerializerHelper.DeserializeObject<TrialReq>(JsonTrialReq);
            TrialResp trialResp = new TrialResp();
            trialResp = baoxianBLL.GetOrderTrial(trialReq);
            //string strEncode = Utils.base64Encode(SerializerHelper.ToJson(trialResp.priceArgs.genes));
            //string strRusult = "{\"respstat\":\"" + trialResp.respstat + "\", \"priceArgsId\":\"" + trialResp.priceArgsId + "\",\"strEncode\":\"" + strEncode + "\"}";
            Response.Write(SerializerHelper.ToJson(trialResp));
        }
    }
}