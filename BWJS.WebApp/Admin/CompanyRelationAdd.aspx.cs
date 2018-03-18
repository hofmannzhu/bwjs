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
	public partial class CompanyRelationAdd : AdminPage
    {
        public int companyRelationId = 0;
        public int machineId = 0;
        public int dbUserId = 0;
        public int LoginUserID = 0;
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!Page.IsPostBack)
            {
                companyRelationId = DNTRequest.GetInt("CompanyRelationId", 0);
                dbUserId = DNTRequest.GetInt("dbUserId", 0);
                machineId = DNTRequest.GetInt("MachineID", 0);
                LoginUserID = currentAdmin.UserID;
            }
        }
	}
}