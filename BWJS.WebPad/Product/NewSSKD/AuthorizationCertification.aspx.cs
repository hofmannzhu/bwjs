using BWJS.BLL;
using BWJS.Model;
using BWJS.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebPad.Product.SSKD
{
    /// <summary>
    /// 授权认证
    /// </summary>
    public partial class AuthorizationCertification : PadPage
    {
        NL_ConsultBLL cbll = new NL_ConsultBLL();
        NL_Consult c = new NL_Consult();
        public string state = "a";
        public string typename = "a";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DNTRequest.GetString("state")))
            {
                state = DNTRequest.GetString("state");
            }
            if (string.IsNullOrEmpty(DNTRequest.GetString("typename")))
            {
                typename = DNTRequest.GetString("typename");
            }
       
            if (!Page.IsPostBack)
            {
            }
        }


    }
}