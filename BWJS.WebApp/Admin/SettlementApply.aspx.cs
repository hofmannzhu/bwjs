using UtilityHelper;
using BWJS.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.Admin
{
    public partial class SettlementApply : AdminPage
    {
        public int OrderRebateSettlementApplyId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OrderRebateSettlementApplyId = DNTRequest.GetInt("OrderRebateSettlementApplyId", 0);
            }
        }
    }
}