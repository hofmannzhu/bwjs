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

namespace BWJS.WebApp.Product.SSKD
{
    /// <summary>
    /// 授权认证
    /// </summary>
    public partial class AuthorizationCertification : BasePage
    {
        NL_ConsultBLL cbll = new NL_ConsultBLL();
        NL_Consult c = new NL_Consult();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }
       

    }
}