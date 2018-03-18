using BWJS.AppCode;
using MofangInterface.BLL;
using MofangInterface.Model.InputModel;
using MofangInterface.Model.OutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Mofang
{
    public partial class NoticeInsurance : BasePage
    {
        public HealthNotifyQuesResp resp = null;
        public string priceArgsId = string.Empty;
        public string price = string.Empty;
        public string buyCount = string.Empty;
        public string strPriceArgs = string.Empty; 
        public string TransNo = string.Empty;
        public string CaseCode = string.Empty;
        public string protectitemid = string.Empty;
        public string SinglePrice = string.Empty;
        public string insurantDateLimitVal = string.Empty;
        public string insurantDateLimitUnit = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            BaoxianDataBLL bll = new BaoxianDataBLL();
            HealthNotifyQuesReq req = new HealthNotifyQuesReq();
            TransNo = UtilityHelper.BWJSCommonHelper.SafeString(Request["transNo"], "");
            CaseCode = UtilityHelper.BWJSCommonHelper.SafeString(Request["CaseCode"], "");

            priceArgsId = UtilityHelper.BWJSCommonHelper.SafeString(Request["priceArgsId"], "");
            price = UtilityHelper.BWJSCommonHelper.SafeString(Request["price"], "");
            SinglePrice = UtilityHelper.BWJSCommonHelper.SafeString(Request["SinglePrice"], "");
            buyCount = UtilityHelper.BWJSCommonHelper.SafeString(Request["buyCount"], "");
            //strPriceArgs = UtilityHelper.BWJSCommonHelper.SafeString(Request["priceArgs"], "");
            protectitemid = UtilityHelper.BWJSCommonHelper.SafeString(Request["protectitemid"], "");
            insurantDateLimitVal = BWJSCommonHelper.SafeString(Request["hdinsurantDateLimitVal"], ""); //承保值                
            insurantDateLimitUnit = BWJSCommonHelper.SafeString(Request["hdinsurantDateLimitUnit"], ""); //承保单位
            req.priceArgsId = priceArgsId;
            req.transNo = TransNo;
            req.caseCode = CaseCode;
            resp = bll.GetHealthNotifyQues(req);
            strPriceArgs = SerializerHelper.ToJson(resp.priceArgs);
        } 
    }
}