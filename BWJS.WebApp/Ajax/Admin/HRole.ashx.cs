using BWJS.BLL;
using BWJS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UtilityHelper;

namespace BWJS.WebApp.Ajax.Admin
{
    /// <summary>
    /// HRole 的摘要说明
    /// </summary>
    public class HRole : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = GetParam("Action", context);
            switch (action)
            {
                case "RoleAddIdList":
                    RoleAddIdList(context);
                    break;

                case "GetRoleOne":
                    GetRoleOne(context);
                    break;
                case "DeleteRole":
                    DeleteRole(context);
                    break;
                case "VerifyRelationRole":
                    VerifyRelationRole(context);
                    break;

                case "VerifySonRole":
                    VerifySonRole(context);
                    break;
                case "GetParentID":
                    GetParentID(context);
                    break;
                case "RoleNameRepeat":
                    RoleNameRepeat(context);
                    break;

            }
        }


        RoleBLL rolebll = new RoleBLL();



        public void RoleNameRepeat(HttpContext context)
        {
            int b = 0;
            string RoleName = "";
            int RoleId = 0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["RoleName"]))
            {
                RoleName = context.Request.QueryString["RoleName"];
            }
            if (!string.IsNullOrEmpty(context.Request.QueryString["RoleId"]))
            {
                RoleId = Convert.ToInt32(context.Request.QueryString["RoleId"]);
            }

            DataSet ds = new DataSet();
            ds = rolebll.GetParentNameList("r.RoleId<>" + RoleId + " and r.RoleName='" + RoleName + "'  and r.IsDeleted=0 ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                b = 1;
            }
            context.Response.Write(b);
        }
        public void GetParentID(HttpContext context)
        {
            int b = 0;
            int ParentId = 0;
            int RoleId = 0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["ParentId"]))
            {
                ParentId = Convert.ToInt32(context.Request.QueryString["ParentId"]);
            }
            if (!string.IsNullOrEmpty(context.Request.QueryString["RoleId"]))
            {
                RoleId = Convert.ToInt32(context.Request.QueryString["RoleId"]);
            }

            DataSet ds2 = new DataSet();
            ds2 = rolebll.GetParentNameList("r.RoleId=" + ParentId + "  and r.IsDeleted=0 ");
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (RoleId!=0)
                {
                    if (ds2.Tables[0].Rows[0]["ParentId"].ToInt() == RoleId)
                    {
                        b = 1;
                    }
                }
              
            }
            context.Response.Write(b);
        }
        public void VerifyRelationRole(HttpContext context)
        {
            var RoleId = context.Request.QueryString["RoleId"];
            UserRoleBLL bll = new UserRoleBLL();
            DataSet ds = new DataSet();
            int b = 0;
            if (!string.IsNullOrEmpty(RoleId))
            {
                ds = bll.GetList(" RoleId=" + RoleId + " and IsDeleted=0");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    b = ds.Tables[0].Rows[0]["RoleId"].ToInt();
                }
            }
            context.Response.Write(b);
        }

        public void VerifySonRole(HttpContext context)
        {
            var RoleId = context.Request.QueryString["RoleId"];
            RoleBLL bll = new RoleBLL();
            DataSet ds = new DataSet();
            int b = 0;
            if (!string.IsNullOrEmpty(RoleId))
            {
                ds = bll.GetList(" ParentId=" + RoleId + " and IsDeleted=0");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    b = ds.Tables[0].Rows[0]["RoleId"].ToInt();
                }
            }
            context.Response.Write(b);
        }

        public void DeleteRole(HttpContext context)
        {
            var RoleId = context.Request.QueryString["RoleId"];
            RoleBLL bll = new RoleBLL();
            bool b = false;
            if (!string.IsNullOrEmpty(RoleId))
            {
                b = bll.UpdateDelete(Convert.ToInt32(RoleId));
            }
            context.Response.Write(b ? "1" : "0");
        }

        public void GetRoleOne(HttpContext context)
        {
            var RoleId = context.Request.QueryString["RoleId"];
            RoleBLL bll = new RoleBLL();
            Role a = new Role();
            if (!string.IsNullOrEmpty(RoleId))
            {
                a = bll.GetRoleOne(Convert.ToInt32(RoleId));
            }

            context.Response.Write(SerializerHelper.SerializeObject(a));

        }

        public void RoleAddIdList(HttpContext context)
        {
            int RoleId = 0;
            if (!string.IsNullOrEmpty(GetParam("RoleId	", context).ToString()))
            {
                RoleId = Convert.ToInt32(GetParam("RoleId	", context).ToString());
            }
            string objOrder = GetParam("RoleModel", context);
            Role roleobj = JsonConvert.DeserializeObject<Role>(objOrder);
            roleobj.RoleType = 1;
            roleobj.RoleStatus = 1;
            roleobj.IsDeleted = 0;
            RoleBLL rolebll = new RoleBLL();
            int result = 0;

            if (roleobj.RoleName != "")
            {
                if (roleobj.RoleId > 0)
                {
                    //编辑
                    result = rolebll.Update(roleobj) ? 1 : 0;
                }
                else {
                    result = rolebll.Add(roleobj);
                }

            }
            context.Response.Write(result);
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