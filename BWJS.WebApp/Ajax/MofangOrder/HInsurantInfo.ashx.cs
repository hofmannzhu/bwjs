using Mofang.BLL;
using Mofang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilityHelper;

namespace BWJS.WebApp.Ajax.MofangOrder
{
    /// <summary>
    /// HInsurantInfo 的摘要说明
    /// </summary>
    public class HInsurantInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string action = GetParam("Action", context);
            switch (action)
            {
                case "GetInsurantInfotabs":
                    GetInsurantInfotabs(context);
                    break;
            }
        }


        public void GetInsurantInfotabs(HttpContext context)
        {
            int OrderApplyID = 0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["OrderApplyID"]))
            {
                OrderApplyID = Convert.ToInt32(context.Request.QueryString["OrderApplyID"]);
            }
            InsurantInfo ort = new InsurantInfo();
            InsurantInfoBLL insurantInfobll = new InsurantInfoBLL();
            ort = insurantInfobll.GetOrdertModel(OrderApplyID);

            var b = SerializerHelper.SerializeObject(new { data = ort });
            context.Response.Write(b);
        }
        private string GetParam(string name, HttpContext context)
        {

            string value = context.Request.QueryString[name] ?? context.Request.Form[name];
            return string.IsNullOrEmpty(value) ? "" : value.Trim();
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