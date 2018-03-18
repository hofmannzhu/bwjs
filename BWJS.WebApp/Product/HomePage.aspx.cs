using BWJS.AppCode;
using BWJS.BLL;
using BWJS.BLL.CookieMag;
using BWJS.Model;
using Mofang.BLL;
using Mofang.Model;
using Mofang.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace BWJS.WebApp.Product
{
    public partial class HomePage : System.Web.UI.Page
    {
        public string HomePageRefreshTime = "7200000";//默认2小时
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HomePageRefreshTime = LinkFun.ConfigString("HomePageRefreshTime", "7200000"); 
            }
        }
    }
}