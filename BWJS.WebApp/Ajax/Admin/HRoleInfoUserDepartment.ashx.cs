using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using UtilityHelper;

namespace BWJS.WebApp.Ajax.Admin
{
    /// <summary>
    /// HRoleInfoUserDepartment 的摘要说明
    /// </summary>
    public class HRoleInfoUserDepartment : IHttpHandler
    {
        private int DepartmentInfoID = 0;
        public void ProcessRequest(HttpContext context)
        {
            DepartmentInfoID = context.Request.QueryString["DepartmentInfoID"].ToInt();
            context.Response.ContentType = "text/plain";
            //context.Response.Write(getRoleInfo(DepartmentInfoID));
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        //public string getRoleInfo(int DepartmentInfoID)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    RRoleDepartmentBLL oRRoleDepartmentBLL = new RRoleDepartmentBLL();
        //    var lstRoleInfo = oRRoleDepartmentBLL.GetRRoleDepartmentList(DepartmentInfoID);

        //    sb.Append("{");
        //    sb.Append("\"DataList\":[");
        //    foreach (var item in lstRoleInfo)
        //    {
        //        sb.Append("{\"ID\":\"" + item.RoleID + "\",\"Name\":\"" + item.RoleName + "\"},");
        //    }
        //    if (lstRoleInfo.Count > 0)
        //    {
        //        sb.Remove(sb.Length - 1, 1);
        //    }
        //    sb.Append("]");
        //    sb.Append("}");


        //    return sb.ToString();
        //}
    }
}