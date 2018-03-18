using BWJS.AppCode;
using BWJS.BLL;
using BWJS.Model;
using BWJSLog.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Admin
{
    public partial class RUserDepartment : AdminPage
    {
        public int UserID = 0;
        public int LoginUserID = 0;
        public int DepartmentInfoType = 0;
        public int ParentID = 0;
        UsersBLL usersbll = new UsersBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUserID = currentAdmin.UserID;
            if (Request.QueryString["UserID"] != null && Request.QueryString["UserID"] != "undefined")
            {
                UserID = Request.QueryString["UserID"].ToInt();
            }
            if (!IsPostBack)
            {
                if (UserID > 0)
                {
                    DataSet ds = new DataSet();
                    ds = usersbll.GetNameList(" u.RecordIsDelete=0  and u.UserID=" + UserID + " and u.DepartmentID<>0  and u.DepartmentID is not null");
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            this.txtDepartmentName.Value = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                            this.txtDepartmentID.Value = ds.Tables[0].Rows[0]["DepartmentID"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnRoot_Click(object sender, EventArgs e)
        {
            this.txtDepartmentName.Value = "清空此部门";
            this.txtDepartmentID.Value = "0";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DepartmentInfoInfoSave();
        }


        public static string IFrameLayerClosetwo(string msg)
        {
            string s;
            s = "<script language=\"javascript\">\r\n";
            s += "parent.layer.msg('" + msg + "', 1, 1);\r\n";
            s += @"  setTimeout(function(){
                        parent.layer.close(parent.layer.getFrameIndex(window.name));
                      window.parent.GetUsersList();
                }, 1000 );";

            s += "</script>";
            return s;
        }
        protected void DepartmentInfoInfoSave()
        {
            if (UserID > 0)
            {
                UsersBLL usersbll = new UsersBLL();
                int DepartmentID = 0;
                try
                {
                    DepartmentID = int.Parse(this.txtDepartmentID.Value);
                }
                catch
                { }
                bool bFlag = false;
                Users model = new Users();
                model.DepartmentID = DepartmentID;
                model.UserID = UserID;
                model.RecordIsDelete = false;
                model.RecordUpdateUserID = LoginUserID;
                model.RecordUpdateTime = DateTime.Now;
                bFlag = usersbll.UpdateDepartmentID(model);
                //日志添加
                DepartmentUserLogBLL.WriteDepartmentUserLogToDB(DepartmentID, "用户关联部门", 3, UserID, LoginUserID);
                if (bFlag)
                {
                    Response.Write(IFrameLayerClosetwo("关联部门成功！"));
                    Response.End();
                }
                else
                {
                    Response.Write(IFrameLayerClosetwo("关联部门失败！"));
                    Response.End();
                }
            }
            else {
                Response.Write(IFrameLayerClosetwo("未获取到用户！"));
                Response.End();
            }
        }
    }
}