using BWJS.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebPad.Product.NewSSKD
{
    /// <summary>
    /// 评估报告-提取额度
    /// </summary>
    public partial class ExtractTheAmount : PadPage
    {
        public string authorizedType = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            authorizedType= DNTRequest.GetFormString("authorizedType");
        }
    }
}