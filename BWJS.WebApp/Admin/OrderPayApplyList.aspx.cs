using BWJS.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.Admin
{
    public partial class OrderPayApplyList : AdminPage
    {
        public int LoginUserId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoginUserId = currentAdmin.UserID;
                Literal litNavString = this.Master.FindControl("litNavString") as Literal;
                if (litNavString != null)
                {
                    litNavString.Text = "订单支付管理";
                }
            }
        }
    }
}