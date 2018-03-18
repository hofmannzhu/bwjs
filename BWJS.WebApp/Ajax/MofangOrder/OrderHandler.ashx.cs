using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mofang.BLL.Helper;
using Mofang.Model;
using Mofang.Model.ViewModel;
using Mofang.Model.OutputModel;
using UtilityHelper;
using MofangInterface.BLL;
using System.Web.SessionState;

namespace BWJS.WebApp.Ajax.Order
{
    /// <summary>
    /// OrderHandler 的摘要说明
    /// </summary>
    public class OrderHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.Form["Action"];
            context.Response.ContentType = "text/plain";
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            try
            {
                switch (action)
                {
                    case "SubmitOrderApply":
                        OrderApplyAdd(Request, Response, context);
                        break;

                    case "OrderPay":
                        OrderPay(Request, Response);

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                //错误日志
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public void OrderApplyAdd(HttpRequest Request, HttpResponse Response, HttpContext context)
        {
            string ValidCodeRequest = UtilityHelper.BWJSCommonHelper.SafeString(Request["ValidCode"], "");
            string ValidCodeSesstion = context.Session["ValidCode"].ToString();
            if (!ValidCodeRequest.Equals(ValidCodeSesstion))
            {
                Response.Write("{\"ValidCodeError\":\"Error\"}");
            }
            else
            { 
            #region 获取参数 begin 
            string TransNo = UtilityHelper.CommonHelper.OrderNoOne(); // Guid.NewGuid().ToString("N");//这里直接赋值
            string CaseCode = UtilityHelper.BWJSCommonHelper.SafeString(Request["CaseCode"], "");
            int productId = DNTRequest.GetInt("productId", 0);

            int Type = UtilityHelper.BWJSCommonHelper.SafeInt(Request["Type"], 0);//当Type为0时默认给自己投保 1为他人投保

            #region 承包申请表 OrderApply
            int userId = UtilityHelper.BWJSCommonHelper.SafeInt(Request["userId"], 0);
            int machineID = UtilityHelper.BWJSCommonHelper.SafeInt(Request["MachineID"], 0);
            #endregion

            #region 投保人信息参数 ApplicantInfo
            string cName = UtilityHelper.BWJSCommonHelper.SafeString(Request["CName"], "");
            string eName = UtilityHelper.BWJSCommonHelper.SafeString(Request["EName"], "");
            int cardType = UtilityHelper.BWJSCommonHelper.SafeInt(Request["CardType"], 0);
            string cardCode = UtilityHelper.BWJSCommonHelper.SafeString(Request["CardCode"], "");
            int sex = UtilityHelper.BWJSCommonHelper.SafeInt(Request["Sex"], 0);
            string birthDay = UtilityHelper.BWJSCommonHelper.SafeString(Request["BirthDay"], "");
            string mobile = UtilityHelper.BWJSCommonHelper.SafeString(Request["Mobile"], "");
            string email = UtilityHelper.BWJSCommonHelper.SafeString(Request["Email"], "");
            string cardPeriod = UtilityHelper.BWJSCommonHelper.SafeString(Request["CardPeriod"], "");
            string job = UtilityHelper.BWJSCommonHelper.SafeString(Request["Job"], "");
            #endregion
            #region 订单信息参数 ApplicationData
            string applicationDate = UtilityHelper.BWJSCommonHelper.SafeString(Request["ApplicationDate"], "");
            string startDate = UtilityHelper.BWJSCommonHelper.SafeString(Request["StartDate"], "");
            string endDate = UtilityHelper.BWJSCommonHelper.SafeString(Request["EndDate"], "");
            #endregion
            #region 被投保人信息参数 InsurantInfo
            string bcName = UtilityHelper.BWJSCommonHelper.SafeString(Request["BCName"], "");
            string beName = UtilityHelper.BWJSCommonHelper.SafeString(Request["BEName"], "");
            int bsex = UtilityHelper.BWJSCommonHelper.SafeInt(Request["BSex"], 0);
            int bcardType = UtilityHelper.BWJSCommonHelper.SafeInt(Request["BCardType"], 0);
            string bcardCode = UtilityHelper.BWJSCommonHelper.SafeString(Request["BCardCode"], "");
            string bbirthDay = UtilityHelper.BWJSCommonHelper.SafeString(Request["BBirthDay"], "");
            int relationID = UtilityHelper.BWJSCommonHelper.SafeInt(Request["RelationID"], 0);//购买关系必填
            int count = UtilityHelper.BWJSCommonHelper.SafeInt(Request["Count"], 0);//购买份数必填
            decimal singlePrice = UtilityHelper.BWJSCommonHelper.SafeDecimal(Request["SinglePrice"], 0m);//购买单价必填
            decimal TotalPrice = UtilityHelper.BWJSCommonHelper.SafeDecimal(Request["TotalPrice"], 0m);//购买总价
            string bcardPeriod = UtilityHelper.BWJSCommonHelper.SafeString(Request["BCardPeriod"], "");
            string bmobile = UtilityHelper.BWJSCommonHelper.SafeString(Request["BMobile"], "");
            string bemail = UtilityHelper.BWJSCommonHelper.SafeString(Request["BEmail"], "");
            string bjob = UtilityHelper.BWJSCommonHelper.SafeString(Request["BJob"], "");
            #endregion 
            #region 其它信息 OtherInfo
            string provCityId = UtilityHelper.BWJSCommonHelper.SafeString(Request["ProvCityId"], "");
            DateTime qTCardPeriod = UtilityHelper.BWJSCommonHelper.SafeDateTime(Request["QTCardPeriod"], DateTime.Parse("1900-1-1"));//其它 证件有效期，格式：yyyy-MM-dd（疾病险）
            int notifyAnswerId = UtilityHelper.BWJSCommonHelper.SafeInt(Request["NotifyAnswerId"], 0);
            string priceArgsId = UtilityHelper.BWJSCommonHelper.SafeString(Request["PriceArgsId"], "");
            int relatedPersonHouse = UtilityHelper.BWJSCommonHelper.SafeInt(Request["RelatedPersonHouse"], 0);
            string visaCity = UtilityHelper.BWJSCommonHelper.SafeString(Request["VisaCity"], "");
            string destination = UtilityHelper.BWJSCommonHelper.SafeString(Request["Destination"], "");
            int tripPurposeId = UtilityHelper.BWJSCommonHelper.SafeInt(Request["TripPurposeId"], 0);
            string propertyAddress = UtilityHelper.BWJSCommonHelper.SafeString(Request["PropertyAddress"], "");
            #endregion
            #endregion 获取参数 end

            #region OrderApplyViewModel 赋值
            OrderApplyViewModel viewModel = new OrderApplyViewModel();
            viewModel.caseCode = CaseCode;
            viewModel.transNo = TransNo;
            viewModel.productId = productId;
            viewModel.TotalPrice = TotalPrice;
            viewModel.applicantInfo = new ApplicantInfo();
            viewModel.applicantInfo.CName = cName;
            viewModel.applicantInfo.EName = eName;
            viewModel.applicantInfo.CardType = cardType;
            viewModel.applicantInfo.Sex = sex;
            viewModel.applicantInfo.BirthDay = birthDay;
            viewModel.applicantInfo.Mobile = mobile;
            viewModel.applicantInfo.Email = email;
            viewModel.applicantInfo.CardCode = cardCode;

            viewModel.applicantInfo.CardPeriod = cardPeriod;
            viewModel.applicantInfo.RecordCreateTime = DateTime.Now;
            viewModel.applicantInfo.RecordUpdateTime = DateTime.Now;
            viewModel.applicantInfo.Job = job;

            viewModel.applicationData = new ApplicationData();
            viewModel.applicationData.ApplicationDate = applicationDate;
            viewModel.applicationData.StartDate = startDate;
            viewModel.applicationData.EndDate = endDate;
            viewModel.applicationData.RecordCreateTime = DateTime.Now;
            viewModel.applicationData.RecordUpdateTime = DateTime.Now;
            viewModel.insurantInfo = new InsurantInfo();
            if (Type == 0)//给自己投保
            {
                viewModel.insurantInfo.CName = viewModel.applicantInfo.CName;
                viewModel.insurantInfo.EName = viewModel.applicantInfo.EName;
                viewModel.insurantInfo.Sex = viewModel.applicantInfo.Sex;
                viewModel.insurantInfo.CardType = viewModel.applicantInfo.CardType;
                viewModel.insurantInfo.Birthday = viewModel.applicantInfo.BirthDay;
                viewModel.insurantInfo.CardPeriod = viewModel.applicantInfo.CardPeriod;
                viewModel.insurantInfo.Mobile = viewModel.applicantInfo.Mobile;
                viewModel.insurantInfo.CardCode = viewModel.applicantInfo.CardCode;
                viewModel.insurantInfo.RelationID = 1;
                viewModel.insurantInfo.Email = viewModel.applicantInfo.Email;//新加字段
                viewModel.insurantInfo.Job = viewModel.applicantInfo.Job;//新加字段
            }
            else
            {
                viewModel.insurantInfo.Email = bemail;
                viewModel.insurantInfo.CName = bcName;
                viewModel.insurantInfo.EName = beName;
                viewModel.insurantInfo.Sex = bsex;
                viewModel.insurantInfo.CardType = bcardType;
                viewModel.insurantInfo.Birthday = bbirthDay;
                viewModel.insurantInfo.CardPeriod = bcardPeriod;
                viewModel.insurantInfo.Mobile = bmobile;
                viewModel.insurantInfo.RelationID = relationID;
                viewModel.insurantInfo.CardCode = bcardCode;
                viewModel.insurantInfo.Job = bjob;
            }
            viewModel.insurantInfo.Count = count;
            viewModel.insurantInfo.SinglePrice = singlePrice;
            viewModel.insurantInfo.RecordCreateTime = DateTime.Now;
            viewModel.insurantInfo.RecordUpdateTime = DateTime.Now; 

            viewModel.orderApply = new OrderApply();
            viewModel.orderApply.RecordCreateTime = DateTime.Now;
            viewModel.orderApply.RecordUpdateTime = DateTime.Now;
            viewModel.orderApply.UserID = userId;
            viewModel.orderApply.MachineID = machineID;
            //  viewModel.transactions = new Transactions();

            viewModel.otherInfo = new OtherInfo();
            viewModel.otherInfo.ProvCityID = provCityId;
            viewModel.otherInfo.CardPeriod = DateTime.Parse(cardPeriod);//这里传投保人 证件有效期
            viewModel.otherInfo.NotifyAnswerID = notifyAnswerId;
            viewModel.otherInfo.PriceArgsID = priceArgsId;
            viewModel.otherInfo.RecordCreateTime = DateTime.Now;
            viewModel.otherInfo.RecordUpdateTime = DateTime.Now;
            viewModel.otherInfo.VisaCity = visaCity;
            viewModel.otherInfo.Destination = destination;
            viewModel.otherInfo.TripPurposeId = tripPurposeId;
            viewModel.otherInfo.PropertyAddress = propertyAddress;
            viewModel.otherInfo.RelatedPersonHouse = relatedPersonHouse;
            #endregion

            OrderApplyHelperBLL orderApplyHelper = new OrderApplyHelperBLL();
            string msg = "";
            bool b = orderApplyHelper.OrderApplyAdd(viewModel, out msg);
            Response.Write(msg);
            }
        }
        public void OrderPay(HttpRequest Request, HttpResponse Response)
        {
            MofangInterface.Model.InputModel.GetPayUrlReq req = new MofangInterface.Model.InputModel.GetPayUrlReq();
            MofangInterface.Model.OutputModel.GetPayUrlResp resp = new MofangInterface.Model.OutputModel.GetPayUrlResp();
            req.transNo = UtilityHelper.BWJSCommonHelper.SafeString(Request["transNo"], "");
            req.caseCode = UtilityHelper.BWJSCommonHelper.SafeString(Request["caseCode"], "");
            req.insureNum = UtilityHelper.BWJSCommonHelper.SafeString(Request["insureNum"], "");
            req.price = Convert.ToDouble(Request["price"]);
            BaoxianDataBLL bll = new BaoxianDataBLL();
            resp = bll.GetPayUrl(req);
            Response.Write(SerializerHelper.ToJson(resp));
        }
    }
}