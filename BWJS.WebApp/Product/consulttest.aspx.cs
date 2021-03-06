﻿using BWJS.AppCode;
using BWJS.BLL;
using BWJS.Model;
using BWJSLog.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Product
{
    public partial class consulttest : BasePage
    {

        NLLoanConfigBLL LoanConfigbll = new NLLoanConfigBLL();
        /// <summary>
        /// 用途
        /// </summary>
        public StringBuilder strLoanUse = new StringBuilder();
        /// <summary>
        /// 期限
        /// </summary>
        public StringBuilder strLoanTerm = new StringBuilder();
     
        /// <summary>
        /// 渠道编号
        /// </summary>
        public int companyId = DNTRequest.GetInt("hiddCompanyId", 0);

        /// <summary>
        /// 推荐码
        /// </summary>
        public string recommendationCode = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoanTermStringBuilder();
            strLoanUseStringBuilder();
            if (!IsPostBack)
            {
                try
                {
                    CompanyBLL opCompanyBLL = new CompanyBLL();
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

        public void LoanTermStringBuilder(){
            strLoanTerm.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> NLLoanConfig = new List<NLLoanConfig>();

            NLLoanConfig = LoanConfigbll.GetConfigList("term");
            var list = NLLoanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strLoanTerm.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }

        public void strLoanUseStringBuilder()
        {
            strLoanUse.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> NLLoanConfig = new List<NLLoanConfig>();

            NLLoanConfig = LoanConfigbll.GetConfigList("use");
            var list = NLLoanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strLoanUse.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }
        

    }
}