using BWJS.AppCode;
using BWJS.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.Admin
{
    public partial class AdReleaseAdd : AdminPage
    {
        public int AdReleaseID = 0;

        public int LoginUserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUserID = currentAdmin.UserID;
            if (Request.QueryString["AdReleaseID"] != null)
            {
                AdReleaseID = Convert.ToInt32(Request.QueryString["AdReleaseID"].ToString());
            }
        }
    }
}