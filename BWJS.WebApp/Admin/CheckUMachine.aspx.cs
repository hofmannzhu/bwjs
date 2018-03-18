using BWJS.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.Admin
{
    public partial class CheckUMachine : AdminPage
    {
        public int UserId = 0;
        public int RoleId = 0;
        public int LoginUserID = 0; 
        protected void Page_Load(object sender, EventArgs e)
        {

            LoginUserID = currentAdmin.UserID;
            if (Request.QueryString["UserId"] != null)
            {
                UserId = Convert.ToInt32(Request.QueryString["UserId"].ToString());
            }
            if (!IsPostBack)
            { 
            }

        }     
    }
}