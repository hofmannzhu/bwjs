using BWJS.AppCode;
using UtilityHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BWJS.WebPad.Product.SSKD
{
    /// <summary>
    /// 申请确认
    /// </summary>
    public partial class ApplyForConfirmation : PadPage
    {
        public string bankCardNo = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bankCardNo = DNTRequest.GetFormString("hiddBankCardNoForApply");
                bankCardNo = bankCardNo.Trim().Replace(" ", "");
            }
        }
    }
}