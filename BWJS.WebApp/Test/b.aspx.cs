using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.Test
{
    public partial class b : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string temp = "123456789";
                string temp001 = UtilityHelper.CommonHelper.MD5(temp, false) + "<br />";
                temp = "12222-12222-513722199008193055-15889910196-1515399650970";
                temp001 += UtilityHelper.CommonHelper.MD5(temp, false) + "<br />";

                litMsg.Text = temp001;
            }
        }
    }
}