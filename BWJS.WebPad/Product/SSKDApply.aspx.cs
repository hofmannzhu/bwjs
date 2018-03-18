using BWJS.BLL;
using BWJS.Model;
using BWJS.AppCode;
using BWJSLog.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebPad.Product
{
    public partial class SSKDApply : PadPage
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

        CompanyBLL opCompanyBLL = new CompanyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Company model = opCompanyBLL.GetModel(companyId);
                    if (model != null)
                    {
                        if (model.IsRelyOnPrimaryKey != 1)
                        {
                            if (!string.IsNullOrEmpty(model.RecommendationCode))
                            {
                                recommendationCode = model.RecommendationCode;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogBLL.WriteExceptionLogToDB(Title + "，" + ex.ToString());
                }
            }
        }
    }
}