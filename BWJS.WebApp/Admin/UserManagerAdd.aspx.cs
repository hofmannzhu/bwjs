using BWJS.AppCode;
using UtilityHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BWJS.AppCode;
using System.Text;
using BWJS.BLL;
using BWJS.Model.Model;
using System.Data;
using BWJS.Model;

namespace BWJS.WebApp.Admin
{
    public partial class UserManagerAdd : AdminPage
    {
        public int UserID = 0;
        public int LoginUserID = 0;
        public string LoginName = "";
        public int LoginUserDepartmentID = 0;
        public string UserDepartmentName = "";
        public bool IsMaster = false;
        public StringBuilder strCityAreaTree = new StringBuilder(); //
        CityAreaBLL CityAreabll = new CityAreaBLL();

        DepartmentInfoBLL deparentbll = new DepartmentInfoBLL();
        public int LoginUserRoleID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            DrpCityAreaData(1);
            UserID = DNTRequest.GetInt("UserID", 0);
            LoginUserID = currentAdmin.UserID;
            if (currentAdmin.UserType == 1)
            {
                IsMaster = true;
            }
            DepartmentInfo departmentInfo = new DepartmentInfo();
         
            LoginUserDepartmentID = currentAdmin.DepartmentID;
            //departmentInfo = deparentbll.GetDepartmentInfoOne(LoginUserDepartmentID);
            //UserDepartmentName = departmentInfo.DepartmentName.ToString();
            DataSet ds = new DataSet();
            LoginName = currentAdmin.UserName;
            if (!IsPostBack)
            {
                DrpDepartmentInfoData();
                DropDownSupplierInfoData();
                if (!IsMaster)
                {
                    drpDepartmentInfoID.SelectedValue = LoginUserDepartmentID.ToString();
                }

            }
        }


        public void DrpDepartmentInfoData()
        {
            ListItem liFist = new ListItem();
            liFist.Value = "0";
            liFist.Text = "请选择……";
            liFist.Selected = true;
            drpDepartmentInfoID.Items.Add(liFist);
            //if (IsMaster)
            //{
            DrpDeparmentData(0, -1);
            //}
            //else
            //{
            //    UsersBLL usersbll = new UsersBLL();
            //    DataTable dt = new DataTable();
            //    int RoleParentId = 0;
            //    dt = usersbll.GetUserRoleTable(" u.UserId=" + LoginUserID + " and u.RecordIsDelete=0 ");
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        RoleParentId = dt.Rows[0]["ParentId"].ToInt();
            //    }

            //    if (RoleParentId == 0)
            //    {
            //        ListItem liFist2 = new ListItem();
            //        liFist2.Value = LoginUserDepartmentID.ToString();
            //        liFist2.Text = UserDepartmentName;
            //        drpDepartmentInfoID.Items.Add(liFist2);
            //    }
            //    DrpDeparmentData(LoginUserDepartmentID, -1);
            //}
        }
        public void DropDownSupplierInfoData()
        {
            ListItem liFist = new ListItem();
            liFist.Value = "0";
            liFist.Text = "请选择……";
            liFist.Selected = true;
            DropDownSupplierInfo.Items.Add(liFist);
            SupplierInfoBLL oSupplierInfoBLL = new SupplierInfoBLL();
            string sqlWhere = " State =0";
            var list = oSupplierInfoBLL.GetModelList(sqlWhere);
            foreach (var item in list)
            {
                ListItem li = new ListItem();
                li.Value = item.SId.ToString();
                li.Text = item.UserName + " " + item.SignName;
                DropDownSupplierInfo.Items.Add(li); 
            } 
        } 
        
        /// <summary>
        /// 绑定生成一个有树结构的下拉菜单 
        /// </summary>
        /// <param name="ParentId">父ID</param>
        /// <param name="i">用来控制缩入量的值，请输入-1</param>
        public void DrpDeparmentData(int ParentId, int i)
        {
            string strPading = ""; //缩入字符 
            i++;
            for (int j = 0; j < i; j++)
            {
                strPading += "　";//如果要增加缩入的长度，改成两个全角的空格就可以了 
            }

            DepartmentInfoBLL departmentInfoBLL = new DepartmentInfoBLL();

            int RecordIsDelete = 0;

            var list = departmentInfoBLL.GetDepartmentInfolist(ParentId, RecordIsDelete);
            foreach (var item in list)
            {

                ListItem li = new ListItem();
                li.Value = item.DepartmentID.ToString();
                li.Text = strPading + " " + item.DepartmentName;
                drpDepartmentInfoID.Items.Add(li);
                DrpDeparmentData(item.DepartmentID, i);
            }
            i--;

        }


        public void DrpCityAreaData(int ParentID)
        {

            strCityAreaTree.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<CityArea> lstCityArea = new List<CityArea>();
            lstCityArea = CityAreabll.GetCityAreaAllList(ParentID);
            var list = lstCityArea.Where(d => d.ParentID == ParentID);
            foreach (var item in list)
            {
                strCityAreaTree.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.Name);
            }

        }
    }
}