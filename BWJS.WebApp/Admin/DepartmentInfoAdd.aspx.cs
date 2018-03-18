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
    public partial class DepartmentInfoAdd : AdminPage
    {
        public int DepartmentID = 0;
        public int LoginUserID = 0;
        public string DepartmentInfoNameChild = "";
        public string DepartmentInfoName = "";
        public int DepartmentInfoType = 0;
        public int ParentID = 0;
        DepartmentInfoBLL DepartmentInfobll = new DepartmentInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUserID = currentAdmin.UserID;
            if (Request.QueryString["DepartmentID"] != null && Request.QueryString["DepartmentID"] != "undefined")
            {
                DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"].ToString());
            }
            if (!IsPostBack)
            {
                this.btnSave.Text = "添加部门";
                if (DepartmentID > 0)
                {
                    DataSet ds = new DataSet();
                    ds = DepartmentInfobll.GetParentNameList(" r.DepartmentID= " + DepartmentID + " AND r.RecordIsDelete=0 ");
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            this.txtDepartmentName.Value = ds.Tables[0].Rows[0]["ParentDepartmentInfoName"].ToString();
                            this.txtDepartmentNameChild.Value = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                            this.txtDepartmentID.Value = ds.Tables[0].Rows[0]["ParentId"].ToString();
                            this.txtDepartmentCode.Value = ds.Tables[0].Rows[0]["DepartmentCode"].ToString();
                            this.txtRemark.Value = ds.Tables[0].Rows[0]["Remark"].ToString();
                            if (ds.Tables[0].Rows[0]["IsReceiveBusiness"].ToString() == "True" || ds.Tables[0].Rows[0]["IsReceiveBusiness"].ToString() == "1")
                            {
                                this.RadioYes.Checked = true;
                                this.RadioNo.Checked = false;
                            }
                            else {
                                this.RadioYes.Checked = false;
                                this.RadioNo.Checked = true;
                            }
                          
                            this.btnSave.Text = "修改部门";
                        }
                    }
                }

            }



        }


        protected void btnRoot_Click(object sender, EventArgs e)
        {
            this.txtDepartmentName.Value = "添加根节点";
            this.txtDepartmentID.Value = "0";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DepartmentInfoInfoSave();
        }

        protected void DepartmentInfoInfoSave()
        {
            DepartmentInfoBLL DepartmentInfoBLL = new DepartmentInfoBLL();
            DepartmentInfoNameChild = this.txtDepartmentNameChild.Value.Trim();
            DepartmentInfoName = this.txtDepartmentName.Value.ToString();
            string Remark = "";
            Remark = this.txtRemark.Value.ToString();
            try
            {
                ParentID = int.Parse(this.txtDepartmentID.Value);
            }
            catch
            { }
            if (DepartmentInfoNameChild.Length > 50)
            {
                Response.Write(IFrameLayerClosetwo("部门名称输入过长,请重新输入！"));
                Response.End();
            }
            if (this.txtDepartmentNameChild.Value.ToString() == "")
            {
                Response.Write(IFrameLayerClosetwo("请填写部门名称！"));
                Response.End();
            }
            if (this.txtDepartmentCode.Value.ToString() == "")
            {
                Response.Write(IFrameLayerClosetwo("请填写部门编码名称！"));
                Response.End();
            }
            if ((ParentID == DepartmentID) && ParentID != 0 && DepartmentID != 0)
            {
                Response.Write(IFrameLayerClosetwo("父级选择错误，请重新选择！"));
                Response.End();
            }

            DataSet ds2 = new DataSet();
            ds2 = DepartmentInfobll.GetParentNameList("r.DepartmentID=" + ParentID + "  and r.RecordIsDelete=0 ");
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (DepartmentID!=0)
                {
                    if (ds2.Tables[0].Rows[0]["ParentID"].ToInt() == DepartmentID)
                    {
                        Response.Write(IFrameLayerClosetwo("父级选择错误，请重新选择！"));
                        Response.End();
                    }
                }
            }

            DataSet ds = new DataSet();
            ds = DepartmentInfobll.GetParentNameList("r.DepartmentID<>" + DepartmentID + " and r.DepartmentName='" + DepartmentInfoNameChild + "'  and r.RecordIsDelete=0 ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Write(IFrameLayerClosetwo("部门名称重复,重新填写！"));
                Response.End();
            }
            ds = DepartmentInfobll.GetParentNameList("  r.DepartmentID<>" + DepartmentID + " and  r.DepartmentCode='" + this.txtDepartmentCode.Value.ToString() + "'  and r.RecordIsDelete=0 ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Write(IFrameLayerClosetwo("部门编码重复,重新填写！"));
                Response.End();
            }


            bool bFlag = false;
            if (this.btnSave.Text == "修改部门")
            {
                DepartmentInfo model = new DepartmentInfo();
                model.DepartmentID = Request.QueryString["DepartmentID"].ToString().ToInt();
                model.Remark = Remark;
                model.DepartmentName = DepartmentInfoNameChild;
                model.ParentID = ParentID;
                model.DepartmentCode = this.txtDepartmentCode.Value.ToString();
                model.RecordIsDelete = false;
                model.UpdateUser = LoginUserID;
                model.RecordUpdateTime = DateTime.Now;
                if (this.RadioYes.Checked == true)
                {
                    model.IsReceiveBusiness = true;
                }
                else {
                    model.IsReceiveBusiness = false;
                }
               
                bFlag = DepartmentInfoBLL.Update(model);
                DepartmentUserLogBLL.WriteDepartmentUserLogToDB(DepartmentID, "修改部门", 1, 0, LoginUserID);
                if (bFlag)
                {
                    Response.Write(IFrameLayerClosetwo("修改部门成功！"));
                    Response.End();
                }
                else
                {
                    Response.Write(IFrameLayerClosetwo("修改部门失败"));
                    Response.End();
                }
            }
            else
            {
                DepartmentInfo model = new DepartmentInfo();
                model.DepartmentID = DepartmentID;
                model.DepartmentName = DepartmentInfoNameChild;
                model.ParentID = ParentID;
                model.Remark = Remark;
                model.DepartmentCode = this.txtDepartmentCode.Value.ToString();
                model.RecordIsDelete = false;
                model.RecordUpdateTime = DateTime.Now;
                model.CreatedUser = LoginUserID;
                model.RecordCreateTime = DateTime.Now;
                if (this.RadioYes.Checked == true)
                {
                    model.IsReceiveBusiness = true;
                }
                else {
                    model.IsReceiveBusiness = false;
                }
                int DepartmentInfoIdNew = 0;
                DepartmentInfoIdNew = DepartmentInfoBLL.Add(model);
                DepartmentUserLogBLL.WriteDepartmentUserLogToDB(DepartmentInfoIdNew, "添加部门", 0, 0, LoginUserID);
                if (DepartmentInfoIdNew > 0)
                {
                    Response.Write(IFrameLayerClosetwo("添加部门成功！"));
                    Response.End();
                }
                else
                {
                    Response.Write(IFrameLayerClosetwo("添加部门失败，继续添加！"));
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
                      window.parent.GetDepartmentList();
                }, 1000 );";

            s += "</script>";
            return s;
        }
    }
}