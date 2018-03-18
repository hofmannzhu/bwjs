using UtilityHelper;
using BWJS.AppCode;
using Mofang.BLL;
using Mofang.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.Product
{
    public partial class NetLoanPlatform : BasePage
    {
        public string loginUserName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loginUserName = ComPage.CurrentUser.LoginName;
                litRecommendationCode.Text = DNTRequest.GetString("rc");
            }
        }
    }
}