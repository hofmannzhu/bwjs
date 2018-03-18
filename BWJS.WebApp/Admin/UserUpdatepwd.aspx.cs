using BWJS.BLL;
using BWJS.BLL.CookieMag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.Admin
{
    public partial class UserUpdatepwd : System.Web.UI.Page
    { 
        public int UserId= MerchantMagCookieBLL.GetMerchantMagUserId();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        } 
    }
}