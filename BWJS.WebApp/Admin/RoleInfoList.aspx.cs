using BWJS.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.Admin
{
    public partial class RoleInfoList : AdminPage
    {
        public int LoginUserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoginUserID = currentAdmin.UserID;
            Literal litNavString = this.Master.FindControl("litNavString") as Literal;
            if (litNavString != null)
            {
                litNavString.Text = "角色管理";
            }
        }
    }
}