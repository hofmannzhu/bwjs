using BWJS.BLL;
using BWJS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using UtilityHelper;

namespace BWJS.WebPad.Ajax.Admin
{
    /// <summary>
    /// HOrderRebate 的摘要说明
    /// </summary>
    public class HOrderRebate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["Action"];
            if (action == "" || action == null)
            {
                action = context.Request.Form["Action"];
            }
            switch (action)
            {
                case "GetOrderRebateList":
                    GetOrderRebateList(context);
                    break;
                case "GetOrderRebatetabs":
                    GetOrderRebatetabs(context);
                    break;

            }
        }


        public void GetOrderRebatetabs(HttpContext context)
        {
            int OrderRebateId = 0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["OrderRebateId"]))
            {
                OrderRebateId = Convert.ToInt32(context.Request.QueryString["OrderRebateId"]);
            }
            OrderRebate ort = new OrderRebate();
            OrderRebateBLL orderrebatebll = new OrderRebateBLL();
            ort = orderrebatebll.GetModel(OrderRebateId);

            var b = SerializerHelper.SerializeObject(new { data = ort });
            context.Response.Write(b);


        }

        public void GetOrderRebateList(HttpContext context)
        {
            string SearchData = "";
            if (!string.IsNullOrEmpty(context.Request.QueryString["SearchData"]))
            {
                SearchData = context.Request.QueryString["SearchData"];
            }

            DataSet ds = new DataSet();
            OrderRebateBLL orderrebatebll = new OrderRebateBLL();
            if (SearchData != "")
            {
                SearchData = "  (moa.InsureNum like'" + SearchData + "%'  or ort.TransNo  like'" + SearchData + "%')  AND ort.IsDeleted=0 ";
            }
            ds = orderrebatebll.GetOrderList(SearchData);
            var b = SerializerHelper.SerializeObject(new { data = ds.Tables[0] });
            context.Response.Write(b);
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