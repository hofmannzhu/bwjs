using BWJS.BLL;
using BWJS.Model;
using BWJS.Model.Model;
using BWJS.AppCode;
using BWJSLog.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using UtilityHelper;
using BWJS.AppCode;

namespace BWJS.WebPad.Ajax.Admin
{
    /// <summary>
    /// UserManager 的摘要说明
    /// </summary>
    public class UserManager : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["Action"];
            switch (action)
            {
                case "AddUser":
                    AddUser(context);
                    break;
                case "GetUsersList":
                    GetUsersList(context);
                    break;
                case "DeleteUser":
                    DeleteUser(context);
                    break;
                case "GetUsersOne":
                    GetUsersOne(context);
                    break;
                case "VerificationIsUserName":
                    VerificationIsUserName(context);
                    break;

            }
        }
        public void AddUser(HttpContext context)
        {
            string PwdKey = LinkFun.getPwdKey();
            int UserID = 0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["UserID"].ToString()))
            {
                UserID = Convert.ToInt32(context.Request.QueryString["UserID"].ToString());
            }


            string objOrder = GetParam("UsersModel", context);
            Users users = JsonConvert.DeserializeObject<Users>(objOrder);
            UsersBLL usersbll = new UsersBLL();


            int result = 0;
            //编辑
            if (UserID > 0)
            {
                if (users.LoginName != "" && users.Password != "")
                {
                    result = usersbll.Update(users) ? 1 : 0;
                }
            }
            else {
                string pwd = DESEncrypt.Encrypt(PwdKey, users.Password);//加密密码
                users.Password = pwd;
                //添加
                if (users.LoginName != "" && users.Password != "")
                {
                    result = usersbll.Add(users);
                }
            }
            context.Response.Write(result);
        }

        public void GetUsersList(HttpContext context)
        {
            UsersBLL usersbll = new UsersBLL();
            List<UsersBackups> list = new List<UsersBackups>();
            string LoginName = context.Request.QueryString["LoginName"];
            string UsersName = context.Request.QueryString["UsersName"];
            string Mobiles = context.Request.QueryString["Mobiles"];

            string Where = " u.RecordIsDelete=0 ";
            DepartmentInfo df = new DepartmentInfo();
            DepartmentInfoBLL bll = new DepartmentInfoBLL();
            df = bll.GetModel(ComPage.CurrentAdmin.DepartmentID);
            if (ComPage.CurrentAdmin.UserType != 1)
            {
                if ((df == null) || (df != null && df.IsReceiveBusiness != false))
                {
                    Where += " AND  u.UserID IN(select ID from [dbo].[GetDepartmentChildren](" + ComPage.CurrentAdmin.UserID + "))";
                }
            }
            if (!string.IsNullOrEmpty(LoginName))
            {
                Where += " AND LoginName like'%" + LoginName + "%' ";
            }
            if (!string.IsNullOrEmpty(Mobiles))
            {
                Where += " AND phone like'%" + Mobiles + "%' ";
            }
            if (!string.IsNullOrEmpty(UsersName))
            {
                Where += " AND UserName like'%" + UsersName + "%' ";
            }
            //if (!string.IsNullOrEmpty(UsersData) && UsersData != "")
            //{
            //    Where += " AND (LoginName like'" + UsersData + "%' or phone like'" + UsersData + "%' or UserName like '" + UsersData + "%') ";
            //}
            list = usersbll.GetModelListName(Where);
            var b = SerializerHelper.SerializeObject(new { data = list });
            context.Response.Write(b);
        }

        public string GetUsersListData(string Where)
        {
            StringBuilder sb = new StringBuilder("");
            try
            {
                UsersBLL usersbll = new UsersBLL();
                DataSet ds = new DataSet();
                ds = usersbll.GetList(Where);
                if (ds != null && ds.Tables.Count > 0)
                {
                    for (int q = 0; q < ds.Tables[0].Rows.Count; q++)
                    {
                        string styleclass = "";
                        if ((q + 1) % 2 == 0)
                        {
                            styleclass = "even";
                        }
                        else
                        {
                            styleclass = "odd";
                        }

                        sb.Append("<tr role=\"row\" class=\"" + styleclass + "\">");
                        sb.Append("<td>" + Convert.ToInt32(ds.Tables[0].Rows[q]["UserID"]) + "</td>");
                        sb.Append("<td>" + ds.Tables[0].Rows[q]["LoginName"].ToString() + "</td>");
                        sb.Append("<td>" + ds.Tables[0].Rows[q]["UserName"].ToString() + "</td>");
                        sb.Append("<td>" + ds.Tables[0].Rows[q]["CardID"].ToString() + "</td>");
                        string SexData = "";
                        if (ds.Tables[0].Rows[q]["Sex"] != null && ds.Tables[0].Rows[q]["Sex"].ToString() != "")
                        {
                            SexData = Convert.ToInt32(ds.Tables[0].Rows[q]["Sex"]) == 1 ? "男" : "女";
                        }
                        else {
                            SexData = "男";
                        }
                        sb.Append("<td>" + SexData + "</td>");
                        sb.Append("<td>" + ds.Tables[0].Rows[q]["Phone"].ToString() + "</td>");
                        sb.Append("<td>" + ds.Tables[0].Rows[q]["QQ"].ToString() + "</td>");
                        sb.Append("<td>" + ds.Tables[0].Rows[q]["Wechat"].ToString() + "</td>");
                        sb.Append("<td>" + ds.Tables[0].Rows[q]["Email"].ToString() + "</td>");
                        sb.Append("<td>" + (Convert.ToInt32(ds.Tables[0].Rows[q]["UserType"]) == 1 ? "管理员" : "客户") + "</td>");
                        sb.Append("<td>" + ds.Tables[0].Rows[q]["CityID"].ToString() + "</td>");
                        sb.Append("<td>" + ds.Tables[0].Rows[q]["CompanyName"].ToString() + "</td>");
                        sb.Append("<td>" + ds.Tables[0].Rows[q]["RecordUpdateTime"].ToString() + "</td>");
                        sb.Append("<td>");
                        sb.Append("<a   href=\"javascript:UpdateUsers(" + Convert.ToInt32(ds.Tables[0].Rows[q]["UserID"]) + ")\">修改</a>&nbsp;&nbsp;");
                        sb.Append("<a   href=\"javascript:DeleteUsers(" + Convert.ToInt32(ds.Tables[0].Rows[q]["UserID"]) + ")\">删除</a>&nbsp;&nbsp;");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                    }
                }
            }
            catch
            {

            }
            return sb.ToString();
        }

        public void DeleteUser(HttpContext context)
        {
            string result = string.Empty;
            try
            {
                var usersIds = DNTRequest.GetString("UsersID");
                if (string.IsNullOrEmpty(usersIds))
                {
                    result = DNTRequest.GetResultJson(false, "请先选择一条数据", null);
                    return;
                }
                else
                {
                    MachineBLL opMachineBLL = new MachineBLL();
                    Machine modelMachine = new Machine();
                    modelMachine = opMachineBLL.GetModelByUserId(Convert.ToInt32(usersIds));
                    if (modelMachine != null)
                    {
                        result = DNTRequest.GetResultJson(false, "用户已绑定设备，不允许删除", null);
                    }
                    else
                    {
                        UsersBLL bll = new UsersBLL();
                        bool res = bll.Delete(Convert.ToInt32(usersIds));
                        if (res)
                        {
                            result = DNTRequest.GetResultJson(true, "删除用户成功", null);
                        }
                        else
                        {
                            result = DNTRequest.GetResultJson(false, "删除用户失败，请稍后再试", null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "删除用户异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            context.Response.Write(result);
        }


        public void GetUsersOne(HttpContext context)
        {
            var UsersID = context.Request.QueryString["UsersID"];
            UsersBLL bll = new UsersBLL();
            Users u = new Users();
            if (!string.IsNullOrEmpty(UsersID))
            {
                u = bll.GetModel(Convert.ToInt32(UsersID));
            }

            context.Response.Write(SerializerHelper.SerializeObject(u));
        }

        public void VerificationIsUserName(HttpContext context)
        {
            var LoginName = context.Request.QueryString["LoginName"];
            UsersBLL bll = new UsersBLL();
            int UserID = 0;
            if (!string.IsNullOrEmpty(LoginName))
            {
                UserID = bll.VerificationIsUserName(LoginName);
            }
            context.Response.Write(UserID);
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