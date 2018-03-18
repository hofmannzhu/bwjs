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
    public partial class MachineSupplierAdd : AdminPage
    {
       public int MachineSupplierId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                MachineSupplierId = DNTRequest.GetInt("MachineSupplierId", 0);
            }
        }
    }
}