using UtilityHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.Admin
{
    public partial class OrderRebateInfo : System.Web.UI.Page
    {
        public int OrderRebateId = 0;
        public int OrderApplyId = 0;
        public string InsureNum = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderRebateId = DNTRequest.GetInt("OrderRebateId", 0);
            OrderApplyId = DNTRequest.GetInt("OrderApplyId", 0);
            InsureNum = DNTRequest.GetString("InsureNum");
        }
    }
}