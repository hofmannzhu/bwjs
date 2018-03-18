using BWJS.AppCode;
using BWJS.BLL;
using BWJSLog.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UtilityHelper;

namespace BWJS.WebApp.Ajax.Admin
{
    /// <summary>
    /// HDepartment 的摘要说明
    /// </summary>
    public class HDepartment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = GetParam("Action", context);
            switch (action)
            {
                case "DeleteDepartment":
                    DeleteDepartment(context);
                    break;
                case "VerifySonDepartment":
                    VerifySonDepartment(context);
                    break;
                case "VerifyRelationDepartment":
                    VerifyRelationDepartment(context);
                    break;

            }
        }

        public void VerifyRelationDepartment(HttpContext context)
        {
            var DepartmentID = context.Request.QueryString["DepartmentID"];
            UsersBLL bll = new UsersBLL();
            DataSet ds = new DataSet();
            int b = 0;
            if (!string.IsNullOrEmpty(DepartmentID))
            {
                ds = bll.GetList(" DepartmentID=" + DepartmentID + " and RecordIsDelete=0");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    b = ds.Tables[0].Rows[0]["DepartmentID"].ToInt();
                }
            }
            context.Response.Write(b);
        }


        public void VerifySonDepartment(HttpContext context)
        {
            var DepartmentID = context.Request.QueryString["DepartmentID"];
            DepartmentInfoBLL bll = new DepartmentInfoBLL();
            DataSet ds = new DataSet();
            int b = 0;
            if (!string.IsNullOrEmpty(DepartmentID))
            {
                ds = bll.GetList(" ParentId=" + DepartmentID + " and RecordIsDelete=0");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    b = ds.Tables[0].Rows[0]["DepartmentID"].ToInt();
                }
            }
            context.Response.Write(b);
        }

        public void DeleteDepartment(HttpContext context)
        {
            var DepartmentID = context.Request.QueryString["DepartmentID"];
            DepartmentInfoBLL bll = new DepartmentInfoBLL();
            bool b = false;
            if (!string.IsNullOrEmpty(DepartmentID))
            {
                b = bll.UpdateDelete(Convert.ToInt32(DepartmentID),ComPage.CurrentUser.UserID);
                DepartmentUserLogBLL.WriteDepartmentUserLogToDB(DepartmentID.ToInt(), "删除部门", 2, 0, ComPage.CurrentAdmin.UserID);
            }
            context.Response.Write(b ? "1" : "0");
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