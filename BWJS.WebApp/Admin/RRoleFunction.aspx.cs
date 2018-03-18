using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.Admin
{
    public partial class RRoleFunction : System.Web.UI.Page
    {
        public int RoleId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["RoleId"] != null)
            {
                RoleId = Convert.ToInt32(Request.QueryString["RoleId"].ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}