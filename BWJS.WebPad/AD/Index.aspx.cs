using BWJS.BLL;
using BWJS.BLL.AdHelper;
using BWJS.Model.InputModel;
using BWJS.Model.OutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.AD
{
    public partial class Index : System.Web.UI.Page
    {
        public string adRefreshTime = "180000";//默认3分钟
        public string u = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["u"] != null)
            {
                u = Request.QueryString["u"].ToString();
            }
            adRefreshTime = LinkFun.ConfigString("AdRefreshTime", "180000");// LinkFun.getAdRefreshTime();
        }
    }
}