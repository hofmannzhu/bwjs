using BWJS.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.Product.NewSSKD
{
    public partial class housingLoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ComPage.CurrentUser.UserID <= 0)
            {
                Response.Redirect("/Product/NewSSKD/SignIn.aspx");
            }
        }
    }
}