using BWJS.AppCode;
using BWJS.BLL;
using BWJS.BLL.CookieMag;
using BWJS.Model;
using Mofang.BLL;
using Mofang.Model;
using Mofang.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BWJS.AppCode;

namespace BWJS.WebApp.Product
{
    public partial class Index : BasePage
    {
        public List<ProductCategory> oCategoryList = null;
        public string magName = string.Empty;
        public string ProductIndexRefreshTime = "7200000";//默认2小时
        public List<Company> litCompanyNetLoan = null;
        public List<Company> litCompanyBank = null;
        public List<Company> litCompanyOther = null;
        public int ImageNum = int.Parse(LinkFun.ConfigString("ImageNum", "1"));//背景刷新时间
        public int BackgroundRefreshTime = int.Parse(LinkFun.ConfigString("BackgroundRefreshTime", "7200000"));//背景刷新时间
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductIndexRefreshTime = LinkFun.ConfigString("ProductIndexRefreshTime", "7200000"); //LinkFun.getProductIndexRefreshTime();
                ProductsBLL adHelper = new ProductsBLL();
                ProductCategoryBLL oProductCategoryBLL = new ProductCategoryBLL();
                oCategoryList = oProductCategoryBLL.GetCardTypeList();
                LoginUserCookie cookie = MerchantFrontCookieBLL.GetMerchantFrontUserCookie();
                magName = cookie.LoginName;
                CompanyBLL opCompanyBLL = new CompanyBLL();

                StringBuilder where = new StringBuilder();
                //where.AppendFormat("IsDeleted=0 and CompanyCategoryId=2 order by OrderId asc");
                //litCompanyNetLoan = opCompanyBLL.GetModelList(where.ToString());

                where = new StringBuilder();
                where.AppendFormat("IsDeleted=0 and CompanyCategoryId=4 order by OrderId asc");
                litCompanyBank = opCompanyBLL.GetModelList(where.ToString());

                where = new StringBuilder();
                where.AppendFormat("IsDeleted=0 and CompanyCategoryId=5 order by OrderId asc");
                litCompanyOther = opCompanyBLL.GetModelList(where.ToString());

            }
        }
    }
}