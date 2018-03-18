using Mofang.BLL;
using Mofang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilityHelper;

namespace BWJS.WebPad.Ajax.MofangOrder
{
    /// <summary>
    /// HApplicantInfo 的摘要说明
    /// </summary>
    public class HApplicantInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string action = GetParam("Action", context);
            switch (action)
            {
                case "GetApplicantInfotabs":
                    GetApplicantInfotabs(context);
                    break;
            }
        }

        public void GetApplicantInfotabs(HttpContext context)
        {
            int ApplicantInfoID = 0;
            int OrderApplyID = 0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["ApplicantInfoID"]))
            {
                ApplicantInfoID = Convert.ToInt32(context.Request.QueryString["ApplicantInfoID"]);
            }
            if (!string.IsNullOrEmpty(context.Request.QueryString["OrderApplyID"]))
            {
                OrderApplyID = Convert.ToInt32(context.Request.QueryString["OrderApplyID"]);
            }
            ApplicantInfoBackups ort = new ApplicantInfoBackups();
            ApplicantInfoBLL applicantInfobll = new ApplicantInfoBLL();
            ort = applicantInfobll.GetOrderModel(OrderApplyID);

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