using BWJS.AppCode;
using BWJS.BLL;
using BWJS.Model;
using BWJS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Test.SSKDtest.LYtest
{
    public partial class AssetInfo : BasePage
    {
        NLLoanConfigBLL LoanConfigbll = new NLLoanConfigBLL();

        public StringBuilder strCityAreaTree = new StringBuilder(); //
        CityAreaBLL CityAreabll = new CityAreaBLL();
        /// <summary>
        /// 贷款申请主键
        /// </summary>
        public int ConsultId = DNTRequest.GetInt("ConsultId", 0);
        /// <summary>
        /// 用途
        /// </summary>
        public StringBuilder strLoanUse = new StringBuilder();
        /// <summary>
        /// 月收入
        /// </summary>
        public StringBuilder strMonthlyIncome = new StringBuilder();
        /// <summary>
        /// 职业身份
        /// </summary>
        public StringBuilder strJobPosition = new StringBuilder();
        /// <summary>
        /// 当前单位工作时间
        /// </summary>
        public StringBuilder strWorkingHour = new StringBuilder();
        /// <summary>
        /// 工资发放形式
        /// </summary>
        public StringBuilder strPayroll = new StringBuilder();

        /// <summary>
        /// 本地公积金
        /// </summary>
        public StringBuilder strFund = new StringBuilder();

        /// <summary>
        /// 学历
        /// </summary>
        public StringBuilder strDegree = new StringBuilder();
        /// <summary>
        ///名下车
        /// </summary>
        public StringBuilder strCars = new StringBuilder();
        /// <summary>
        ///名下房
        /// </summary>
        public StringBuilder strHouses = new StringBuilder();
        /// <summary>
        ///是否做过其他网贷
        /// </summary>
        public StringBuilder strOtherLoans = new StringBuilder();

        /// <summary>
        ///支付宝芝麻分
        /// </summary>
        public StringBuilder strSesameSeed = new StringBuilder();

        /// <summary>
        ///淘宝账号
        /// </summary>
        public StringBuilder strTaobaoAccount = new StringBuilder();

        /// <summary>
        ///商业保单
        /// </summary>
        public StringBuilder strBusinessPolicy = new StringBuilder();

        /// <summary>
        ///信用情况
        /// </summary>
        public StringBuilder strCreditSituation = new StringBuilder();

        /// <summary>
        ///是否有信用卡
        /// </summary>
        public StringBuilder strCreditCard = new StringBuilder();
        
        /// <summary>
        ///信用卡使用年限
        /// </summary>
        public StringBuilder strCreditCardServiceLifen = new StringBuilder();


        protected void Page_Load(object sender, EventArgs e)
        {
            DrpCityAreaData(1);
            strLoanUseStringBuilder();
            strMonthlyIncomeStringBuilder();
            strJobPositionStringBuilder();
            strWorkingHourStringBuilder();
            strDegreeStringBuilder();
            strPayrollStringBuilder();
            strFundStringBuilder();
            strCarsStringBuilder();
            strHousesStringBuilder();
            strOtherLoansStringBuilder();
            strSesameSeedStringBuilder();
            strTaobaoAccountStringBuilder();
            strBusinessPolicyStringBuilder();
            strCreditSituationStringBuilder();
            strCreditCardStringBuilder();
            strCreditCardServiceLifenStringBuilder();
        }


        public void strLoanUseStringBuilder()
        {
            strLoanUse.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("use");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strLoanUse.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }
        public void strMonthlyIncomeStringBuilder()
        {
            strMonthlyIncome.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("MonthIncome");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strMonthlyIncome.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }
        public void strJobPositionStringBuilder()
        {
            strJobPosition.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("ProfessionalIdentity"); 
             var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strJobPosition.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }

        public void strWorkingHourStringBuilder()
        {
            strWorkingHour.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("UnitWorkingTime");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strWorkingHour.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }
        public void strDegreeStringBuilder()
        {
            strDegree.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("Education");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strDegree.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }


        public void strPayrollStringBuilder()
        {
            strPayroll.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("FormOfPayroll");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strPayroll.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }


        public void strCarsStringBuilder()
        {
            strCars.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("IsHaveCar");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strCars.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }
        public void strOtherLoansStringBuilder()
        {
            strOtherLoans.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("HaveOtherLoans");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strOtherLoans.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }
        public void strSesameSeedStringBuilder()
        {
            strSesameSeed.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("AlipaySesameBranch");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strSesameSeed.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }
        public void strTaobaoAccountStringBuilder()
        {
            strTaobaoAccount.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");
            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();
            nlloanConfig = LoanConfigbll.GetConfigList("IsTaobaoAccount");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strTaobaoAccount.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }
        public void strBusinessPolicyStringBuilder()
        {
            strBusinessPolicy.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");
            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();
            nlloanConfig = LoanConfigbll.GetConfigList("BusinessPolicy");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strBusinessPolicy.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }

        public void strFundStringBuilder()
        {
            strFund.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("AccumulationFund");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strFund.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }

        public void strHousesStringBuilder()
        {
            strHouses.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("IsHaveHouse");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strHouses.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }
        public void strCreditSituationStringBuilder()
        {
            strCreditSituation.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("CreditSituation");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strCreditSituation.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }
        public void strCreditCardServiceLifenStringBuilder()
        {
            strCreditCardServiceLifen.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("ServiceLife");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strCreditCardServiceLifen.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }
        public void strCreditCardStringBuilder()
        {
            strCreditCard.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<NLLoanConfig> nlloanConfig = new List<NLLoanConfig>();

            nlloanConfig = LoanConfigbll.GetConfigList("IsCreditCard");
            var list = nlloanConfig.Where(d => d.IsDeleted == 0);
            foreach (var item in list)
            {
                strCreditCard.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.KeyName);
            }

        }

        

        public void DrpCityAreaData(int ParentID)
        {

            strCityAreaTree.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<CityArea> lstCityArea = new List<CityArea>();
            lstCityArea = CityAreabll.GetCityAreaAllList(ParentID);
            var list = lstCityArea.Where(d => d.ParentID == ParentID);
            foreach (var item in list)
            {
                strCityAreaTree.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.Name);
            }

        }
    }
}