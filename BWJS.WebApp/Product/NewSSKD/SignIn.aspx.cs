using BWJS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.Product.NewSSKD
{
    public partial class SignIn : System.Web.UI.Page
    {
        public int BackgroundRefreshTime = int.Parse(LinkFun.ConfigString("BackgroundRefreshTime", "300000"));//背景刷新时间
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
    }
}