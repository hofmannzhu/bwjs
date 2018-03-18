using BWJS.AppCode;
using BWJS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.Admin
{
    public partial class UserManagerInfoList : AdminPage
    {
        public int LoginUserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUserID = currentAdmin.UserID;
            Literal litNavString = this.Master.FindControl("litNavString") as Literal;
            if (litNavString != null)
            {
                litNavString.Text = "用户管理";
            }
            if (!IsPostBack)
            {
                DrpDepartmentInfoData();
            }
        }  
        public void DrpDepartmentInfoData()
        {
            ListItem liFist = new ListItem();
            liFist.Value = "0";
            liFist.Text = "请选择……";
            liFist.Selected = true;
            drpDepartmentInfoID.Items.Add(liFist);
            DrpDeparmentData(0, -1); 
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
    }
}