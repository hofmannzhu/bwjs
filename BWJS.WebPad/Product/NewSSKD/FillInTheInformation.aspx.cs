using BWJS.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BWJS.BLL;
using BWJS.Model;
using BWJS.Model.Model;
using System.Text;
using UtilityHelper;

namespace BWJS.WebPad.Product.SSKD
{
    /// <summary>
    /// 填写信息
    /// </summary>
    public partial class FillInTheInformation : PadPage
    {
        NLLoanConfigBLL LoanConfigbll = new NLLoanConfigBLL();

        public StringBuilder strCityAreaTree = new StringBuilder();
        CityAreaBLL CityAreabll = new CityAreaBLL();
        /// <summary>
        /// 贷款申请主键
        /// </summary>
        // public int ConsultId = DNTRequest.GetInt("ConsultId", 0);

        public string consultid = string.Empty;
        public string IDNo = string.Empty;
        public string mobile = string.Empty;
        public string orderNo = string.Empty;
        public string fullName = string.Empty;
        public string postToken = string.Empty;
        public string postTimeStamp = string.Empty;

        public string sex = string.Empty;
        public string birth = string.Empty;
        public string national = string.Empty;
        public string address = string.Empty;
        public string authority = string.Empty;
        public string validperiod = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!Page.IsPostBack)
                {
                    postTimeStamp = DNTRequest.GetFormString("hiddTimeStamp");
                    postToken = DNTRequest.GetFormString("hiddToken");
                    consultid = DNTRequest.GetFormString("hidConsultId");
                    IDNo = DNTRequest.GetFormString("hidIDNo");
                    mobile = DNTRequest.GetFormString("hidMobile");
                    orderNo = DNTRequest.GetFormString("hidOrderNo");

                    fullName = DNTRequest.GetFormString("hiddFullName");
                    sex = DNTRequest.GetFormString("hiddSex");
                    birth = DNTRequest.GetFormString("hiddBirth");
                    national = DNTRequest.GetFormString("hiddNational");
                    address = DNTRequest.GetFormString("hiddAddress");
                    authority = DNTRequest.GetFormString("hiddAuthority");
                    validperiod = DNTRequest.GetFormString("hiddValidperiod");

                    NewSSKDCookie postModel = new NewSSKDCookie();
                    postModel.IDCardNo = IDNo;
                    postModel.Mobile = mobile;
                    postModel.OrderNo = orderNo;
                    postModel.ConsultId = consultid;
                    postModel.Token = postToken;
                    postModel.FullName = fullName;
                    postModel.Sex = sex;
                    postModel.Birth = birth;
                    postModel.National = national;
                    postModel.Address = address;
                    postModel.Authority = authority;
                    postModel.Validperiod = validperiod;
                    postModel.TimeStamp = postTimeStamp;
                    base.SSKDHelperPage_Load(postModel);
                }
            }
        }
    }
}