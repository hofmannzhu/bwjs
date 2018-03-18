using BWJS.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Admin
{ 
    public partial class SupplierInfoAdd : AdminPage
    {
        public int SId = 0;
        public int LoginUserID = 0;  
        protected void Page_Load(object sender, EventArgs e)
        {
            SId = DNTRequest.GetInt("SId", 0);
            LoginUserID = currentAdmin.UserID;
           
        }
    }
}