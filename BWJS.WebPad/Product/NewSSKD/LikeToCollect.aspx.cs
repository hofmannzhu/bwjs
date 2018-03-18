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
    /// 人像采集
    /// </summary>
    public partial class LikeToCollect : PadPage
    {

        public string xinboweinuoApi = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            xinboweinuoApi = CommonHelper.GetAppSettingsValue("xinboweinuoApi", "http://202.85.222.36:8100");
            if (!Page.IsPostBack)
            {
            }
        }
    }
}