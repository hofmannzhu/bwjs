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
    public partial class RoleAdd : AdminPage
    {
        public int RoleId = 0;
        public int LoginUserID = 0;
        public string RoleNameChild = "";
        public string RoleName = "";
        public int RoleType = 0;
        public int ParentID = 0;
        RoleBLL rolebll = new RoleBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUserID = currentAdmin.UserID;
            if (Request.QueryString["RoleId"] != null)
            {
                RoleId = Convert.ToInt32(Request.QueryString["RoleId"].ToString());
            }
            if (!IsPostBack)
            {
                this.btnSave.Text = "添加角色";
                if (RoleId > 0)
                {
                    DataSet ds = new DataSet();
                    ds = rolebll.GetParentNameList(" r.RoleId=" + RoleId + " AND r.IsDeleted=0 ");
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            this.txtRoleName.Value = ds.Tables[0].Rows[0]["ParentName"].ToString();
                            this.txtRoleNameChild.Value = ds.Tables[0].Rows[0]["RoleName"].ToString();
                            this.txtRoleId.Value = ds.Tables[0].Rows[0]["ParentId"].ToString();
                            this.txtRemark.Value = ds.Tables[0].Rows[0]["Remark"].ToString();
                            if (ds.Tables[0].Rows[0]["IsManager"].ToString() == "True" || ds.Tables[0].Rows[0]["IsManager"].ToString() == "1")
                            {
                                this.yes.Checked = true;
                                this.no.Checked = false;
                            }
                            else {
                                this.yes.Checked = false;
                                this.no.Checked = true;
                            }
                            this.btnSave.Text = "修改角色";
                        }
                    }
                }

            }



        }

        protected void btnRoot_Click(object sender, EventArgs e)
        {
            this.txtRoleName.Value = "添加根节点";
            this.txtRoleId.Value = "0";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            RoleInfoSave();
        }

        protected void RoleInfoSave()
        {
            RoleBLL roleBLL = new RoleBLL();
            RoleNameChild = this.txtRoleNameChild.Value.Trim();
            RoleName = this.txtRoleName.Value.ToString();
            int RoleStatus = 1;
            try
            {
                ParentID = int.Parse(this.txtRoleId.Value);
            }
            catch
            { }
            if (RoleNameChild.Length > 50)
            {
                Response.Write(CommonHelper.JumpBack("角色名称输入过长,请重新输入！"));
                Response.End();
            }
            if (this.txtRoleNameChild.Value.ToString() == "")
            {
                Response.Write(CommonHelper.JumpBack("请填写角色名称！"));
                Response.End();
            }
            if ((ParentID == RoleId) && ParentID != 0 && RoleId != 0)
            {
                Response.Write(IFrameLayerClosetwo("父级选择错误，请重新选择！"));
                Response.End();
            }
            DataSet ds = new DataSet();
            ds = roleBLL.GetParentNameList("r.RoleId<>" + RoleId + " and r.RoleName='" + RoleNameChild + "'  and r.IsDeleted=0 ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Write(IFrameLayerClosetwo("角色名称重复,重新填写！"));
                Response.End();
            }

            bool bFlag = false;
            if (this.btnSave.Text == "修改角色")
            {
                Role model = new Role();
                model.RoleId = Request.QueryString["RoleID"].ToString().ToInt();
                model.RoleStatus = RoleStatus;
                model.RoleName = RoleNameChild;
                model.ParentId = ParentID;
                model.IsDeleted = 0;
                model.Remark = this.txtRemark.Value.ToString();
                model.EditDate = DateTime.Now;
                model.EditId = LoginUserID;
                if (this.yes.Checked == true)
                {
                    model.IsManager = true;
                }
                else {
                    model.IsManager = false;
                }
                bFlag = roleBLL.Update(model);
                if (bFlag)
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
                Role model = new Role();
                model.RoleId = RoleId;
                model.RoleName = RoleNameChild;
                model.ParentId = ParentID;
                model.RoleStatus = RoleStatus;
                model.IsDeleted = 0;
                model.EditDate = DateTime.Now;
                model.CreateId = LoginUserID;
                model.EditId = LoginUserID;
                model.Remark = this.txtRemark.Value.ToString();
                model.CreateDate = DateTime.Now;
                if (this.yes.Checked == true)
                {
                    model.IsManager = true;
                }
                else {
                    model.IsManager = false;
                }
                int RoleIdNew = 0;

                RoleIdNew = roleBLL.Add(model);
                if (RoleIdNew > 0)
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

        public static string IFrameLayerClosetwo(string msg)
        {
            string s;
            s = "<script language=\"javascript\">\r\n";
            s += "parent.layer.msg('" + msg + "', 1, 1);\r\n";
            s += @"  setTimeout(function(){
                        parent.layer.close(parent.layer.getFrameIndex(window.name));
                      window.parent.GetRoleList();
                }, 2000 );";

            s += "</script>";
            return s;
        }
    }
}