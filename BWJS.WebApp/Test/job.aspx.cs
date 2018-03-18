using MofangInterface.Model.InputModel;
using MofangInterface.Model.OutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Test
{
    public partial class job : System.Web.UI.Page
    {
        public string CaseCode = string.Empty;
        public string TransNo = string.Empty;
        public string resultStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            CaseCode = "0001076209802609";
            TransNo= UtilityHelper.CommonHelper.OrderNoOne();

          
        } 
    }
}