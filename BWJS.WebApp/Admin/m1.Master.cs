using BWJS.AppCode;
using BWJS.BLL;
using BWJS.Model;
using BWJSLog.BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Admin
{
    public partial class m1 : System.Web.UI.MasterPage
    {
        /// <summary>
        /// 用户权限
        /// </summary>
        ArrayList userFunction = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                userFunction = GetUserFunction;

                GetLeftMenu();
                if (ComPage.CurrentAdmin != null)
                {
                    string userType = string.Empty;
                    switch (ComPage.CurrentAdmin.UserType)
                    {
                        case 1:
                            userType = "员工";
                            break;
                        case 2:
                            userType = "商家";
                            break;
                        case 3:
                            userType = "代理商";
                            break;
                    }
                    //litUserType.Text = userType;
                    litCurrentUserInfo.Text = (string.IsNullOrEmpty(ComPage.CurrentAdmin.UserName) ? (ComPage.CurrentAdmin.LoginName) : (ComPage.CurrentAdmin.UserName));
                }
            }
        }

        public bool CheckedAuthorize(string functionCode)
        {
            List<Function> list = new List<Function>();
            FunctionBLL bll = new FunctionBLL();

            list = bll.GetFuctionDepartmentExtentList2(" f.IsDeleted=0  AND  ur.UserId=" + ComPage.CurrentAdmin.UserID + "");
            if (ComPage.CurrentAdmin.UserType == 1)
            {
                return true;
            }
            else {
                return list.Exists(t => t.FunctionCode == functionCode);
            }
        }

        #region 获取左侧导航菜单
        /// <summary>
        /// 获取左侧导航菜单
        /// </summary>
        protected void GetLeftMenu()
        {
            try
            {
                int parentId = DNTRequest.GetInt("parentId", 0);
                FunctionBLL opFunctionBLL = new FunctionBLL();
                Function modelFunction = new Function();
                DataSet ds = opFunctionBLL.GetList("IsDeleted=0");
                DataTable dt = null;
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                StringBuilder html = new StringBuilder();
                List<Hashtable> list = new List<Hashtable>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow[] allList = dt.Select(string.Format("ClassId=0 and ParentId={0}", parentId), "OrderId ASC");
                    if (allList.Length > 0)
                    {
                        foreach (DataRow dr in allList)
                        {
                            bool isParent = false;
                            DataRow[] allChild = dt.Select(string.Format("ClassId=0 and ParentId={0}", dr["FunctionId"]), "OrderId ASC");
                            if (allChild != null && allChild.Length > 0)
                            {
                                isParent = true;
                            }
                            if (ComPage.CurrentAdmin.UserType == 1)
                            {
                                html.AppendFormat("<li class=\"par\">{0}</li>", dr["FunctionName"]);
                            }
                            else {
                                if (userFunction.Contains(dr["FunctionId"]))
                                {
                                    html.AppendFormat("<li class=\"par\">{0}</li>", dr["FunctionName"]);
                                }
                            }
                            if (isParent)
                            {
                                GetLeftMenuChild(html, allChild, dt);
                            }
                        }
                    }
                }
                if (string.IsNullOrEmpty(html.ToString()))
                {
                    html.Append("<li>暂无权限</li>");
                }
                litLeftMenu.Text = html.ToString();
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
        }

        /// <summary>
        /// 获取左侧导航子菜单
        /// </summary>
        protected void GetLeftMenuChild(StringBuilder html, DataRow[] allList, DataTable dt)
        {
            try
            {
                if (allList.Length > 0)
                {
                    html.AppendFormat("<div class=\"child\">");
                    html.AppendFormat("<ul>");
                    foreach (DataRow dr in allList)
                    {
                        if (ComPage.CurrentAdmin.UserType == 1)
                        {
                            html.AppendFormat("<li class=\"ch\"><a href =\"{0}\">{1}</a></li>", dr["ExternalLinkAddress"], dr["FunctionName"]);
                        }
                        else {
                            if (userFunction.Contains(dr["FunctionId"]))
                            {
                                html.AppendFormat("<li class=\"ch\"><a href =\"{0}\">{1}</a></li>", dr["ExternalLinkAddress"], dr["FunctionName"]);
                            }
                        }
                    }
                    html.AppendFormat("</ul>");
                    html.AppendFormat("</div>");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
        }

        public ArrayList GetUserFunction
        {
            get
            {
                ArrayList arr = new ArrayList();
                UserRoleBLL op = new UserRoleBLL();
                DataTable dt = op.GetUserFunction(ComPage.CurrentAdmin.UserID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        arr.Add(dr["FunctionId"]);
                    }
                }
                return arr;
            }
        }

        #endregion
    }
}