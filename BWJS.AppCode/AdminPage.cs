using UtilityHelper;
using BWJS.Model;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using BWJS.BLL;

namespace BWJS.AppCode
{
    /// <summary>
    /// 后端页面继承类
    /// </summary>
    public class AdminPage : System.Web.UI.Page
    {
        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        public Users currentAdmin = null;

        public bool IsMaster { get; set; }

        /// <summary>
        /// 用户权限配置
        /// </summary>
        public List<Function> Authorize { get; set; }

        #region 重载

        //protected override void OnInit(EventArgs e)
        //{
        //    //event
        //    this.Load += new EventHandler(PageBase_Load);
        //    //this.Error += new EventHandler(PageBase_Error);
        //    //this.PreRender += new EventHandler(PageBase_PreRender);

        //    base.OnInit(e);
        //}
        //private void PageBase_Load(object sender, EventArgs e)
        //{
        //    bool istest = false;
        //    if (!istest)
        //    {
        //        currentAdmin = ComPage.CurrentAdmin;
        //        if (currentAdmin != null)
        //        {
        //            string lastloginip = currentAdmin.LastAccessIP;
        //            string currentloginip = HttpContext.Current.Request.UserHostAddress;
        //            if (lastloginip != currentloginip)//currentAdmin.IsLogined == 1 &&
        //            {
        //                //SendMessage.Alert(this, "退出登录，用户在其他机器登录", "/guanli/signout.aspx");
        //                SendMessage.JsExe(Page, "signout", "alert('退出登录，用户在其他设备登录');window.top.location.href='/Admin/Login.aspx'");
        //            }
        //        }
        //        else
        //        {
        //            SendMessage.JsExe(Page, "signout", "alert('登录超时已退出，请重新登录');window.top.location.href='/Admin/Login.aspx'");
        //            //HttpContext.Current.Response.Redirect("/Admin/Login.aspx");
        //        }
        //    }

        //}
        ////private void PageBase_Error(object sender, EventArgs e)
        ////{
        ////}

        ////private void PageBase_PreRender(object sender, EventArgs e)
        ////{
        ////} 
        #endregion

        #region 构造方法
        public AdminPage()
        {
            bool istest = false;
            if (!istest)
            {
                currentAdmin = ComPage.CurrentAdmin;
                if (currentAdmin != null)
                {
                    string lastloginip = currentAdmin.LastAccessIP;
                    string currentloginip = HttpContext.Current.Request.UserHostAddress;
                    if (lastloginip != currentloginip)//currentAdmin.IsLogined == 1 &&
                    {
                        //SendMessage.Alert(this, "退出登录，用户在其他机器登录", "/guanli/signout.aspx");
                        //SendMessage.JsExe(this.Page, "logout", "alert('退出登录，用户在其他设备登录');window.top.location.href='/Admin/Login.aspx'");
                        // HttpContext.Current.Response.Redirect("/Admin/LoginOut.aspx");
                    }
                }
                else
                {
                    //SendMessage.JsExe(this.Page, "logout", "alert('登录超时已退出，请重新登录');window.top.location.href='/Admin/Login.aspx'");
                    HttpContext.Current.Response.Redirect("/Admin/LoginOut.aspx");
                }
            }
        }
        #endregion

        #region DropDownList绑定
        /// <summary>
        /// 初始化绑定DropDownList
        /// </summary>
        public void InitDDL(DataTable dt, DropDownList ddl, object defaultText, object defaultValue, object bindText, object bindValue)
        {
            ddl.Items.Clear();
            if (defaultText != null && defaultValue != null)
            {
                ddl.Items.Add(new ListItem(defaultText.ToString(), defaultValue.ToString()));
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ddl.Items.Add(new ListItem(ComPage.SafeToString(dr[bindText.ToString()]), ComPage.SafeToString(dr[bindValue.ToString()])));
                }
            }
        }
        #endregion


        #region 获取当前页面URL
        /// <summary>
        /// 获取当前页
        /// </summary>
        public string ThisPageUrl
        {
            get { return VirtualPathUtility.ToAppRelative(Request.Url.AbsolutePath); }
        }
        /// <summary>
        /// 获得页面地址
        /// </summary>
        public string GetPageUrl
        {
            get
            {
                string strTemp = "";
                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTPS"] == "off")
                {
                    strTemp = "http://";
                }
                else
                {
                    strTemp = "https://";
                }
                if (strTemp == "https://")
                {
                    strTemp = "http://";
                }
                strTemp = strTemp + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"];

                if (System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"] != "80")
                {
                    strTemp = strTemp + ":" + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                }

                strTemp = strTemp + System.Web.HttpContext.Current.Request.ServerVariables["URL"];

                if (System.Web.HttpContext.Current.Request.QueryString.AllKeys.Length > 0)
                {
                    strTemp = strTemp + "?" + System.Web.HttpContext.Current.Request.QueryString;
                }

                return strTemp;
            }
        }
        #endregion


        /// <summary>
        /// 检查用户权限
        /// </summary>
        /// <param name="functionCode">功能代码</param>
        /// <returns>True:具有权限，False：不具有权限</returns>
        /// <returns></returns>
        public bool CheckedAuthorize(string functionCode)
        {
            // 如果是管理员的，默认具有所有权限
            if (this.IsMaster)
                return true;

            //if (Authorize == null || Authorize.Count == 0)
            //    return false;

            FunctionBLL bll = new FunctionBLL();

            Authorize = bll.GetFuctionDepartmentExtentList2(" f.IsDeleted=0  AND  ur.UserId=" + currentAdmin.UserID + "");
            if (currentAdmin.UserType == 1)
            {
                return true;
            }
            else {
                return Authorize.Exists(t => t.FunctionCode == functionCode);
            }
          
        }

    }
}