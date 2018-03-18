using BWJS.Model;
using BWJS.BLL;
using UtilityHelper;
using BWJS.AppCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BWJSLog.BLL;

namespace BWJS.WebApp.Admin
{
    public partial class LoginOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArrayList list = new ArrayList();
                if (ComPage.CurrentAdmin != null)
                {
                    #region 更新登录状态

                    UsersBLL op = new UsersBLL();
                    Users member = new Users();
                    ComPage.CurrentAdmin.IsLogined = 0;
                    op.Update(ComPage.CurrentAdmin);
                    #endregion

                    list.Add(ComPage.memberModelCacheDependency + ComPage.CurrentAdmin.UserID);
                    list.Add(ComPage.memberModel + ComPage.CurrentAdmin.UserID);

                }
                ComPage.ClearBWJSCache(list);

                Session.RemoveAll();

                Utils.DelCoookie(Utils.GetAppSettingsValue("cookieName"));
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            finally
            {
                if (!string.IsNullOrEmpty(Request.QueryString["url"]))
                {
                    Response.Redirect(Request.QueryString["url"].ToString(), true);
                }
                else
                {
                    Response.Redirect("/Admin/Login.aspx", true);
                }
            }
        }
    }
}