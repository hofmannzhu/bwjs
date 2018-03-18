using BWJS.BLL;
using BWJS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilityHelper;

namespace BWJS.WebPad.Ajax.Admin
{
    /// <summary>
    /// HRoleFunction 的摘要说明
    /// </summary>
    public class HRoleFunction : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = GetParam("Action", context);
            switch (action)
            {
                case "RoleFunctionAdd":
                    RoleFunctionAdd(context);
                    break;
                case "GetAssignCheck":
                    GetAssignCheck(context);
                    break;
            }
        }


        public void GetAssignCheck(HttpContext context)
        {
            RoleFunctionBLL roleFunctionbll = new RoleFunctionBLL();
            List<RoleFunction> list = new List<RoleFunction>();
            int RoleId = 0;
            if (!string.IsNullOrEmpty(GetParam("RoleId", context).ToString()))
            {
                RoleId = Convert.ToInt32(GetParam("RoleId", context).ToString());
            }

            list = roleFunctionbll.GetModelList(" RoleId=" + RoleId + "  AND IsDeleted=0 ");
            var b = SerializerHelper.SerializeObject(new { data = list });
            context.Response.Write(b);
        }

        public void RoleFunctionAdd(HttpContext context)
        {
            int RoleId = 0;
            string FunctionArray = "";
            if (!string.IsNullOrEmpty(GetParam("RoleId", context).ToString()))
            {
                RoleId = Convert.ToInt32(GetParam("RoleId", context).ToString());
            }
            if (!string.IsNullOrEmpty(GetParam("FunctionArray", context).ToString()))
            {
                FunctionArray = GetParam("FunctionArray", context).ToString();
            }

            string objOrder = GetParam("RoleFunctionModel", context);
            RoleFunction roleFunction = JsonConvert.DeserializeObject<RoleFunction>(objOrder);
            RoleFunctionBLL roleFunctionbll = new RoleFunctionBLL();
            int result = 0;

            if (RoleId != 0)
            {
                if (RoleId > 0)
                {
                    result = roleFunctionbll.UpdateRoleFun(RoleId, FunctionArray) ? 1 : 0;
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