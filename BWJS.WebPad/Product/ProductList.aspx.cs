using BWJS.BLL;
using BWJS.AppCode;
using Mofang.BLL;
using Mofang.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebPad.Product
{
    public partial class ProductList : PadPage
    {
        public List<ProductsViewModel> listMofang = new List<ProductsViewModel>();

        public string UserName = "";
        public int UserID = 0;
        public int BackgroundRefreshTime = int.Parse(LinkFun.ConfigString("BackgroundRefreshTime", "300000"));//背景刷新时间
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int CategoryId = UtilityHelper.BWJSCommonHelper.SafeInt(Request["CategoryId"], 0);

                ProductsBLL adHelper = new ProductsBLL();
                listMofang = adHelper.GetProducts(CategoryId);
                UserName = ComPage.CurrentUser.LoginName;
                UserID = ComPage.CurrentUser.UserID;
            }
        }
    }
}