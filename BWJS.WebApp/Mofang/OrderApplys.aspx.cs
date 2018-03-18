using UtilityHelper;
using Mofang.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mofang.BLL;
using Mofang.Model;
using Mofang.BLL.Helper;
using BWJS.BLL;
using BWJS.Model;
using MofangInterface.BLL;
using MofangInterface.Model.InputModel;
using MofangInterface.Model.OutputModel;
using System.Text;
using BWJS.BLL.CookieMag;
using BWJS.AppCode;

namespace BWJS.WebApp.Mofang
{
    public partial class OrderApplys : BasePage
    {
        public Products ProModel = null;
        public List<TravelDestination> oTravelDestinationList = null;
        public List<CardTypeViewModel> oCardTypeList = null;
        public List<RelationViewModel> listRelationViewMode = null;
        ProductsBLL bll = new ProductsBLL();
        TravelDestinationBLL oTravelDestinationBLL = new TravelDestinationBLL();
        public string protectitemid = string.Empty;
        public string CaseCode = string.Empty;
        public string TransNo = string.Empty;
        public string priceArgsId = string.Empty;
        public string price = string.Empty;
        public string buyCount = string.Empty;
        public bool isShowProvince = false;
        public bool isShowrelatedPersonHouse = false;
        public bool isShowcaichansuozaidi = false;
        public bool isluyouxianCXMDD = false;//旅游险 出行目的地
        public string healthId = string.Empty;
        public bool isoneSelf = false;
        public bool typeMen = false;
        public bool typeWomen = false;
        public bool isHaveJob = false;
        public bool isOnlyOthers = false;//只能为他人投保
        /// <summary>
        /// Mofang.Products表主键编号
        /// </summary>
        public int productId = 0;
        public int userId = 0;
        public int MachineID = 0;
        public string SinglePrice = string.Empty;
        public string CXMDDStr = string.Empty;
        public string insurantDateLimitVal = string.Empty;
        public string insurantDateLimitUnit = string.Empty;
        public int StartDateParame = 1;//投保日期默认为第二天开始
        BaoxianDataBLL oBaoxianDataBLL = new BaoxianDataBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                UsersBLL oUsersBLL = new UsersBLL();
                MachineBLL oMachineBLL = new MachineBLL();
                userId = MerchantFrontCookieBLL.GetMerchantFrontUserId();
                if (userId > 0)
                {
                    Machine oMachine = new Machine();
                    oMachine = oMachineBLL.GetModelByUserId(userId);
                    if (oMachine != null)
                    {
                        MachineID = oMachine.MachineID;
                    }
                }
                TransNo = BWJSCommonHelper.SafeString(Request["transNo"], "");
                TransNo = string.IsNullOrEmpty(TransNo) ? "" : TransNo.Trim();
                CaseCode = BWJSCommonHelper.SafeString(Request["CaseCode"], "");
                CaseCode = string.IsNullOrEmpty(CaseCode) ? "" : CaseCode.Trim();
                protectitemid = BWJSCommonHelper.SafeString(Request["protectitemid"], "");
                protectitemid = string.IsNullOrEmpty(protectitemid) ? "" : protectitemid.Trim();
                priceArgsId = BWJSCommonHelper.SafeString(Request["priceArgsId"], "");
                priceArgsId = string.IsNullOrEmpty(priceArgsId) ? "" : priceArgsId.Trim();
                price = BWJSCommonHelper.SafeString(Request["price"], "");
                price = string.IsNullOrEmpty(price) ? "" : price.Trim();
                SinglePrice = BWJSCommonHelper.SafeString(Request["SinglePrice"], "");
                SinglePrice = string.IsNullOrEmpty(SinglePrice) ? "" : SinglePrice.Trim();
                buyCount = BWJSCommonHelper.SafeString(Request["buyCount"], "");
                buyCount = string.IsNullOrEmpty(buyCount) ? "" : buyCount.Trim();
                healthId = BWJSCommonHelper.SafeString(Request["healthId"], "");
                healthId = string.IsNullOrEmpty(healthId) ? "" : healthId.Trim();
                productId = DNTRequest.GetInt("productId", 0);
                insurantDateLimitVal = BWJSCommonHelper.SafeString(Request["hdinsurantDateLimitVal"], ""); //承保值                
                insurantDateLimitUnit = BWJSCommonHelper.SafeString(Request["hdinsurantDateLimitUnit"], ""); //承保单位
                CardTypeBLL oCardTypeBLL = new CardTypeBLL();
                oCardTypeList = oCardTypeBLL.GetCardTypeList(CaseCode);
                RelationBLL oRelationBLL = new RelationBLL();
                listRelationViewMode = oRelationBLL.GetRelationViewModelList(CaseCode);
                switch (CaseCode)
                {
                    case "0000052178002133":
                        isShowProvince = true;
                        isoneSelf = true;//被保人必须是投保人本人
                        break;
                    case "0001075211202628":
                        isShowcaichansuozaidi = true;
                        isShowrelatedPersonHouse = true;
                        isoneSelf = true;
                        break;
                    case "0000076164701939":
                        isluyouxianCXMDD = true;
                        oTravelDestinationList = oTravelDestinationBLL.GetTravelDestinationList(CaseCode);
                        ProductDestinationReq oProductDestinationReqModel = new ProductDestinationReq();
                        oProductDestinationReqModel.caseCode = CaseCode;
                        oProductDestinationReqModel.transNo = TransNo;
                        ProductCXDestinationResp oProductCXDestinationResp = oBaoxianDataBLL.ProductDestinations(oProductDestinationReqModel);
                        CXMDDStr = GetCXMDDStr(oProductCXDestinationResp);
                        //     isShowrelatedPersonHouse = true;
                        break;
                    case "0000052067400588":
                        isShowcaichansuozaidi = true;
                        isoneSelf = true;
                        break;
                    case "0001077178502139":
                        typeMen = true;
                        break;
                    case "0001077178602140":
                        typeWomen = true;
                        break;
                    case "0001076209802609"://一起慧99-百万医疗保险 无门诊计划 
                        isHaveJob = true;
                        break;
                    case "0001076211102627"://一起慧99-百万医疗保险 有门诊计划 
                        isHaveJob = true;
                        break; 
                    case "0001075190802342"://少儿住院宝
                        isOnlyOthers = true;
                        StartDateParame = 3;// 这个产品要求（起保日期只能为投保日起第三天）
                        break;
                        
                }
                List<Products> oProductsList = bll.ProductsByCaseCode(CaseCode);
                if (oProductsList != null)
                {
                    ProModel = oProductsList.FirstOrDefault();
                }
            }


        }
        /// <summary>
        /// 获取产品出行目的地
        /// </summary>
        /// <returns></returns>
        public string GetCXMDDStr(ProductCXDestinationResp oProductCXDestinationResp)
        {
            StringBuilder builder = new StringBuilder();
            if (oProductCXDestinationResp != null)
            {
                List<ProductDestination> list = oProductCXDestinationResp.destinations.OrderBy(d => d.initial).ToList();
                int count = list.Count;
                if (oProductCXDestinationResp.chooseOne)//目的地是否只能选择一个国家true：是 false：否
                {
                    builder.AppendLine("<div id=\"ProductDestinationId\" name=\"ProductDestinationId\" typeInput='radioR'>");
                    for (int i = 0; i < count; i++)
                    {
                        builder.AppendLine("<label>");
                        builder.AppendLine(" <input name = \"ProductDestination\" type = \"radio\" value = \"" + list[i].cName + "\" />");
                        builder.AppendLine(list[i].initial + "-" + list[i].cName);
                        builder.AppendLine("</label>");
                    }
                }
                else
                {
                    builder.AppendLine("<div id=\"ProductDestinationId\" name=\"ProductDestinationId\" typeInput='radioC'>");
                    for (int i = 0; i < count; i++)
                    {
                        builder.AppendLine("<label>");
                        builder.AppendLine(" <input name = \"ProductDestination\" type = \"checkbox\" value = \"" + list[i].cName + "\" />");
                        builder.AppendLine(list[i].initial + "-" + list[i].cName);
                        builder.AppendLine("</label>");
                    }
                }
                builder.AppendLine("</div>");
                return builder.ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// 获取终保时间
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetEndDate(string beginDate, string dataValue, string dataUnit)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(beginDate))
            {
                DateTime dt = Convert.ToDateTime(beginDate);
                int dataNum = CommonHelper.GetNumFromStr(dataValue).ToInt();



                //string [] sp = type.Split('-');
                //if(sp.Count()>1)
                //{
                //    string dates = sp[1].TrimEnd('天');
                //    int d= BWJSCommonHelper.SafeInt(dates, 0);
                //    dt.AddDays(d);
                //    result= dt.ToString("yyyy-MM-dd");
                //}
                //else
                //{
                switch (dataUnit)
                {
                    case "年":
                        result = dt.AddYears(dataNum).ToString("yyyy-MM-dd");
                        break;
                    case "月":
                        result = dt.AddMonths(dataNum).ToString("yyyy-MM-dd");
                        break;
                    default:
                        result = dt.AddDays(dataNum).ToString("yyyy-MM-dd");
                        break;
                }
                //} 
            }
            return result;
        }

       
    }
}