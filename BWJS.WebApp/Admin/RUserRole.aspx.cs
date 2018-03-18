using BWJS.AppCode;
using BWJS.BLL;
using BWJS.Model;
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
    public partial class RUserRole : AdminPage
    {
        public int UserId = 0;
        public int RoleId = 0;
        public int LoginUserID = 0;
        UserRoleBLL userrolebll = new UserRoleBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            LoginUserID = currentAdmin.UserID;
            if (Request.QueryString["UserId"] != null)
            {
                UserId = Convert.ToInt32(Request.QueryString["UserId"].ToString());
            }
            if (!IsPostBack)
            {
                this.btnSave.Text = "添加角色";
                if (UserId > 0)
                {
                    DataSet ds = new DataSet();
                    ds = userrolebll.GetUserRoleName(" ur.UserId=" + UserId + " AND ur.IsDeleted=0 ");
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            this.txtRoleName.Value = ds.Tables[0].Rows[0]["RoleName"].ToString();
                            this.txtRoleId.Value = ds.Tables[0].Rows[0]["RoleId"].ToString();
                            this.btnSave.Text = "修改角色";
                        }
                    }
                }

            }

        }
        protected void btnRoot_Click(object sender, EventArgs e)
        {
            this.txtRoleName.Value = "清空此角色";
            this.txtRoleId.Value = "0";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
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
        protected void Save()
        {

            try
            {
                RoleId = int.Parse(this.txtRoleId.Value);
            }
            catch
            { }
            //if (this.txtRoleName.Value.ToString() == "清空此角色")
            //{
            //    Response.Write(CommonHelper.JumpBack("请选择角色！"));
            //    Response.End();
            //}

            int bFlag = 0;
            if (this.btnSave.Text == "修改角色")
            {
                UserRole model = new UserRole();
                if (this.txtRoleName.Value.ToString() == "清空此角色")
                {
                    model.IsDeleted = 1;
                }
                else {
                    model.IsDeleted = 0;
                }
                model.UserId = UserId;
                model.RoleId = RoleId;
                model.EditId = LoginUserID;
                model.EditDate = DateTime.Now;
                bFlag = userrolebll.UpdateRole(model);
                if (bFlag > 0)
                {
                    Response.Write(IFrameLayerClosetwo("修改角色成功！"));
                    Response.End();
                }
                else
                {
                    Response.Write(IFrameLayerClosetwo("修改角色失败"));
                    Response.End();
                }
            }
            else
            {
                UserRole model = new UserRole();
                model.UserId = UserId;
                model.RoleId = RoleId;
                model.CreateId = LoginUserID;
                model.EditId = LoginUserID;
                model.IsDeleted = 0;
                model.CreateDate = DateTime.Now;
                model.EditDate = DateTime.Now;
                int UserRoleIdNew = 0;
                UserRoleIdNew = userrolebll.Add(model);
                if (UserRoleIdNew > 0)
                {
                    Response.Write(IFrameLayerClosetwo("添加角色成功！"));
                    Response.End();
                }
                else
                {
                    Response.Write(IFrameLayerClosetwo("添加角色失败，继续添加！"));
                    Response.End();
                }
            }
        }
    }
}