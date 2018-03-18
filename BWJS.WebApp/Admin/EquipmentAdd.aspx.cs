using BWJS.AppCode;
using UtilityHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using MofangInterface.BLL;
using BWJSLog.BLL;

namespace BWJS.WebApp.Admin
{
    public partial class EquipmentAdd : AdminPage
    {
        public int machineId = 0;
        public int dbUserId  = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                dbUserId = DNTRequest.GetInt("dbUserId", 0);
                machineId = DNTRequest.GetInt("MachineID", 0);
            }
        }
    }
}