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
    /// HFunction 的摘要说明
    /// </summary>
    public class HFunction : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = GetParam("Action", context);
            switch (action)
            {
                case "VerificationIsFunName":
                    VerificationIsFunName(context);
                    break;
                case "GetFunctionOne":
                    GetFunctionOne(context);
                    break;
                case "FunctionAdd":
                    FunctionAdd(context);
                    break;

                case "DeleteFunction":
                    DeleteFunction(context);
                    break;
                case "GetParentID":
                    GetParentID(context);
                    break;
                case "FunctionNameRepeat":
                    FunctionNameRepeat(context);
                    break;

                case "VerifySonRole":
                    VerifySonRole(context);
                    break;
                case "VerifyRelationRole":
                    VerifyRelationRole(context);
                    break;


            }
        }
        FunctionBLL functionbll = new FunctionBLL();

        public void VerifyRelationRole(HttpContext context)
        {
            var FunctionID = context.Request.QueryString["FunctionID"];
            RoleFunctionBLL bll = new RoleFunctionBLL();
            DataSet ds = new DataSet();
            int b = 0;
            if (!string.IsNullOrEmpty(FunctionID))
            {
                ds = bll.GetList(" FunctionId= " + FunctionID + " and IsDeleted=0");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    b = ds.Tables[0].Rows[0]["FunctionId"].ToInt();
                }
            }
            context.Response.Write(b);
        }
        public void VerifySonRole(HttpContext context)
        {
            var FunctionID = context.Request.QueryString["FunctionID"];
            DataSet ds = new DataSet();
            int b = 0;
            if (!string.IsNullOrEmpty(FunctionID))
            {
                ds = functionbll.GetList(" ParentId=" + FunctionID + " and IsDeleted=0");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    b = ds.Tables[0].Rows[0]["FunctionID"].ToInt();
                }
            }
            context.Response.Write(b);
        }

        public void FunctionNameRepeat(HttpContext context)
        {
            int b = 0;
            string FunctionName = "";
            int FunctionID = 0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["FunctionName"]))
            {
                FunctionName = context.Request.QueryString["FunctionName"];
            }
            if (!string.IsNullOrEmpty(context.Request.QueryString["FunctionID"]))
            {
                FunctionID = Convert.ToInt32(context.Request.QueryString["FunctionID"]);
            }

            DataSet ds = new DataSet();
            ds = functionbll.GetList(" FunctionId<>" + FunctionID + " and  FunctionName='" + FunctionName + "'  and IsDeleted=0 ");
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
            int FunctionID = 0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["ParentID"]))
            {
                ParentID = Convert.ToInt32(context.Request.QueryString["ParentID"]);
            }
            if (!string.IsNullOrEmpty(context.Request.QueryString["FunctionID"]))
            {
                FunctionID = Convert.ToInt32(context.Request.QueryString["FunctionID"]);
            }

            DataSet ds2 = new DataSet();
            ds2 = functionbll.GetList("FunctionId=" + ParentID + "  and IsDeleted=0 ");
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (FunctionID!=0)
                {
                    if (ds2.Tables[0].Rows[0]["ParentId"].ToInt() == FunctionID)
                    {
                        b = 1;
                    }
                }
            }
            context.Response.Write(b);
        }
        public void DeleteFunction(HttpContext context)
        {
            var FunctionID = context.Request.QueryString["FunctionID"];
            FunctionBLL bll = new FunctionBLL();
            bool b = false;
            if (!string.IsNullOrEmpty(FunctionID))
            {
                b = bll.UpdateDelete(Convert.ToInt32(FunctionID));
            }
            context.Response.Write(b ? "1" : "0");

        }
        public void FunctionAdd(HttpContext context)
        {
            int FunctionId = 0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["FunctionId"].ToString()))
            {
                FunctionId = Convert.ToInt32(context.Request.QueryString["FunctionId"].ToString());
            }

            string objOrder = GetParam("FunctionModel", context);
            Function function = JsonConvert.DeserializeObject<Function>(objOrder);
            FunctionBLL functionbll = new FunctionBLL();
            int result = 0;
            //编辑
            if (FunctionId > 0)
            {
                if (function.FunctionName != "")
                {
                    result = functionbll.Update(function) ? 1 : 0;
                }
            }
            else {
                //添加
                if (function.FunctionName != "")
                {
                    result = functionbll.Add(function);
                }
            }
            context.Response.Write(result);

        }

        public void GetFunctionOne(HttpContext context)
        {
            var FunctionId = context.Request.QueryString["FunctionId"];
            FunctionBLL bll = new FunctionBLL();
            Function a = new Function();
            if (!string.IsNullOrEmpty(FunctionId))
            {
                a = bll.GetModel(Convert.ToInt32(FunctionId));
            }

            context.Response.Write(SerializerHelper.SerializeObject(a));
        }

        public void VerificationIsFunName(HttpContext context)
        {
            int FunctionId = 0;
            var FunctionName = context.Request.QueryString["FunctionName"];
            if (!string.IsNullOrEmpty(context.Request.QueryString["FunctionId"]))
            {
                FunctionId = Convert.ToInt32(context.Request.QueryString["FunctionId"]);
            }

            FunctionBLL functionbll = new FunctionBLL();
            if (!string.IsNullOrEmpty(FunctionName))
            {
                FunctionId = functionbll.VerificationIsFunName(FunctionName, FunctionId);
            }
            context.Response.Write(FunctionId);
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