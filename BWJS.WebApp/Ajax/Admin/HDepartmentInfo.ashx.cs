using BWJS.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UtilityHelper;

namespace BWJS.WebApp.Ajax.Admin
{
    /// <summary>
    /// HDepartmentInfo 的摘要说明
    /// </summary>
    public class HDepartmentInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = GetParam("Action", context);
            switch (action)
            {
                case "GetParentID":
                    GetParentID(context);
                    break;
                case "DepartmentNameRepeat":
                    DepartmentNameRepeat(context);
                    break;
                case "DepartmentCodeRepeat":
                    DepartmentCodeRepeat(context);
                    break;
            }
        }

        DepartmentInfoBLL DepartmentInfobll = new DepartmentInfoBLL();

        public void DepartmentCodeRepeat(HttpContext context)
        {
            int b = 0;
            string DepartmentCode = "";
            int DepartmentID = 0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["DepartmentCode"]))
            {
                DepartmentCode = context.Request.QueryString["DepartmentCode"];
            }
            if (!string.IsNullOrEmpty(context.Request.QueryString["DepartmentID"]))
            {
                DepartmentID = Convert.ToInt32(context.Request.QueryString["DepartmentID"]);
            }

            DataSet ds = new DataSet();
            ds = DepartmentInfobll.GetParentNameList("  r.DepartmentID<>" + DepartmentID + " and  r.DepartmentCode='" + DepartmentCode + "'  and r.RecordIsDelete=0 ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                b = 1;
            }
            context.Response.Write(b);

        }

        public void DepartmentNameRepeat(HttpContext context)
        {
            int b = 0;
            string DepartmentName = "";
            int DepartmentID = 0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["DepartmentName"]))
            {
                DepartmentName = context.Request.QueryString["DepartmentName"];
            }
            if (!string.IsNullOrEmpty(context.Request.QueryString["DepartmentID"]))
            {
                DepartmentID = Convert.ToInt32(context.Request.QueryString["DepartmentID"]);
            }

            DataSet ds = new DataSet();
            ds = DepartmentInfobll.GetParentNameList("r.DepartmentID<>" + DepartmentID + " and r.DepartmentName='" + DepartmentName + "'  and r.RecordIsDelete=0 ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                b = 1;
            }
            context.Response.Write(b);
        }
        public void GetParentID(HttpContext context)
        {
            int b = 0;
            int ParentID = 0;
            int DepartmentID = 0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["ParentID"]))
            {
                ParentID = Convert.ToInt32(context.Request.QueryString["ParentID"]);
            }
            if (!string.IsNullOrEmpty(context.Request.QueryString["DepartmentID"]))
            {
                DepartmentID = Convert.ToInt32(context.Request.QueryString["DepartmentID"]);
            }

            DataSet ds2 = new DataSet();
            ds2 = DepartmentInfobll.GetParentNameList("r.DepartmentID=" + ParentID + "  and r.RecordIsDelete=0 ");
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (DepartmentID!=0)
                {
                    if (ds2.Tables[0].Rows[0]["ParentID"].ToInt() == DepartmentID)
                    {
                        b = 1;
                    }
                }
               
            }
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