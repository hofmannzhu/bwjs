using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Admin
{
    public partial class BinDingUsersMachine : System.Web.UI.Page
    {
        public int machineId = 0;
        public int dbUserId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dbUserId = DNTRequest.GetInt("dbUserId", 0);
                machineId = DNTRequest.GetInt("MachineID", 0);
            }
        }
    }
}