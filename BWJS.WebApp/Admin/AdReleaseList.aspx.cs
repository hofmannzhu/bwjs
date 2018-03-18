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
    public partial class AdReleaseList : AdminPage
    {


        public string basePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //var basePath = CommonHelper.GetConfigValue("ResourceBasePath");
            Literal litNavString = this.Master.FindControl("litNavString") as Literal;
            if (litNavString != null)
            {
               
                litNavString.Text = "广告管理";
            }
        }
    }
}