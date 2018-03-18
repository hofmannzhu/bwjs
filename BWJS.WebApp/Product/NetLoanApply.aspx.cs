using UtilityHelper;
using BWJS.AppCode;
using BWJS.BLL;
using BWJS.Model;
using Mofang.BLL;
using Mofang.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BWJSLog.BLL;

namespace BWJS.WebApp.Product
{
    public partial class NetLoanApply : BasePage
    {
        
        public string loginUserName = string.Empty;
        /// <summary>
        /// 推荐码
        /// </summary>
        public string recommendationCode = string.Empty;
        /// <summary>
        /// 渠道编号
        /// </summary>
        public int companyId = DNTRequest.GetInt("hiddCompanyId", 0);
        /// <summary>
        /// 渠道网贷产品分类编号
        /// </summary>
        public int netPayCategoryId = DNTRequest.GetInt("hiddNetPayCategoryId", 2);
        /// <summary>
        /// 渠道网贷产品页索引
        /// </summary>
        public int netPayPageIndex = DNTRequest.GetInt("hiddNetPayPageIndex", 1);
        //
        public string apiUrl = string.Empty;
        public int IsOpenPage = 0;//是否打开网页形式
        CompanyBLL opCompanyBLL = new CompanyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("/Product/NewSSKD/Index.aspx");
            if (!IsPostBack)
            {
                try
                {
                    loginUserName = ComPage.CurrentUser.LoginName;
                    #region 获取渠道API
                    Company model = opCompanyBLL.GetModel(companyId);
                    if (model != null)
                    {
                        IsOpenPage = model.DockingMode;
                        apiUrl = model.API;
                    }
                    #endregion
                    #region 获取渠道推荐码
                    //recommendationCode = Server.UrlEncode(CommonHelper.GetAppSettingsValue("RecommendationCode80", "08001"));
                    if (model.IsRelyOnPrimaryKey != 1)
                    {
                        if (!string.IsNullOrEmpty(model.RecommendationCode))
                        {
                            rc.Value = model.RecommendationCode;
                            litRecommendationCode.Text = string.Format("专属推荐码({0})", model.RecommendationCode);
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    ExceptionLogBLL.WriteExceptionLogToDB("渠道认证异常，" + ex.ToString());
                }
            }
        }
    }
}