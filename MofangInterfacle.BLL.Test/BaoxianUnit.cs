using MofangInterface.BLL;
using MofangInterface.Model;
using MofangInterface.Model.InputModel;
using UtilityHelper;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mofang.BLL;
using BWJS.BLL;
using BWJS.Model;
using BWJS.SMS;
using BWJSLog.BLL;

namespace MofangInterfacle.BLL.Test
{
    [TestClass]
    public class BaoxianUnit
    {
        const string pageNoticeUrl = "";

        #region 获取本机信息
        [TestMethod]
        public void IpHelperTest()
        {
            IpHelper.Test();

        }

        #endregion

        #region 获取位置信息
        [TestMethod]
        public void GetocationLInfo()
        {
            var res = MachineLocationLogBLL.GetLocationInfo();

        }
        #endregion

        #region 地址解析
        [TestMethod]
        public void GetLocationByAddress()
        {
            string address = "";
            var res = MachineLocationLogBLL.GetLocationByAddress(address);
        }
        #endregion

        #region 逆地址解析
        [TestMethod]
        public void GetAddressByLocation()
        {
            string longitude = string.Empty;
            string latitude = string.Empty;
            string output = string.Empty;
            int pois = 0;
            var res = MachineLocationLogBLL.GetAddressByLocation(longitude, latitude, output, pois);
        }
        #endregion

        #region orderApply承保测试
        [TestMethod]
        public void OrderApply()
        {
            OrderApplyInputModel model = new OrderApplyInputModel();
            model.transNo = UtilityHelper.CommonHelper.OrderNoOne();
            //model.customkey = "bowangjishi";
            model.caseCode = "0000052178002133";
            model.insurantDateLimit = "365";

            ApplicationData _applicationData = new ApplicationData();
            _applicationData.applicationDate = "2017-09-07 13:00:00";
            _applicationData.startDate = "2017-09-08";
            _applicationData.endDate = "2018-09-08";

            ApplicantInfo _applicantInfo = new ApplicantInfo();
            _applicantInfo.cName = "倪成智";
            _applicantInfo.eName = "nichengzhi";
            _applicantInfo.cardType = 1;
            _applicantInfo.cardCode = "210623199008092631";
            _applicantInfo.sex = 1;
            _applicantInfo.birthday = "1990-08-09";
            _applicantInfo.mobile = "15841505041";
            _applicantInfo.email = "1446821306@qq.com";
            _applicantInfo.cardPeriod = "2020-10-01";

            InsurantInfo _insurantInfo = new InsurantInfo();
            _insurantInfo.cName = "倪成智";
            _insurantInfo.eName = "nichengzhi";
            _insurantInfo.cardType = 1;
            _insurantInfo.cardCode = "210623199008092631";
            _insurantInfo.sex = 1;
            _insurantInfo.birthday = "1990-08-09";
            _insurantInfo.mobile = "15841505041";
            _insurantInfo.relationId = 1;
            _insurantInfo.count = 1;
            _insurantInfo.singlePrice = 12;
            _insurantInfo.cardPeriod = "2020-10-01";

            OtherInfo _otherInfo = new OtherInfo();
            _otherInfo.provCityId = "510000-511800-511821";
            _otherInfo.cardPeriod = "2020-10-01";
            _otherInfo.notifyAnswerId = "";
            _otherInfo.priceArgsId = "";

            model.applicationdata = _applicationData;
            model.applicantinfo = _applicantInfo;
            model.insurantInfo = _insurantInfo;
            model.otherInfo = _otherInfo;

            BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
            var res = baoxianDataBLL.OrderApply(model);

        }
        #endregion

        #region orderCancle退保测试
        [TestMethod]
        public void OrderCancle()
        {
            BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
            OrderCancleInputModel model = new OrderCancleInputModel();
            model.transNo = UtilityHelper.CommonHelper.OrderNoOne();
            //model.customkey = "bowangjishi";
            model.insureNum = "20170927001111";
            var res = baoxianDataBLL.OrderCancle(model);
        }

        #endregion

        #region orderSummary投保单列表测试
        [TestMethod]
        public void OrderSummary()
        {
            BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
            OrderSummaryInputModel model = new OrderSummaryInputModel();
            model.starttime = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
            model.endtime = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd");
            //model.starttime = "2016-11-25 16:25:20";
            //model.endtime = "2018-12-03 16:25:20";
            //model.customkey = "bowangjishi";
            model.start = 1;
            model.limit = 50;
            var res = baoxianDataBLL.OrderSummary(model);
        }

        #endregion

        #region getPayUrl获取支付链接测试
        [TestMethod]
        public void GetPayUrl()
        {
            BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
            GetPayUrlReq model = new GetPayUrlReq();
            model.transNo = UtilityHelper.CommonHelper.OrderNoOne();
            model.caseCode = "0000052178002133";
            //model.customkey = "bowangjishi";
            model.insureNum = "20170907004888";
            model.price = 50;
            model.pageNoticeUrl = pageNoticeUrl;
            var res = baoxianDataBLL.GetPayUrl(model);

        }
        #endregion 

        #region getProductPropertyArea产品财产所在地测试
        [TestMethod]
        public void ProductPropertyArea()
        {
            BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
            ProductPropertyAreaReq model = new ProductPropertyAreaReq();
            model.transNo = UtilityHelper.CommonHelper.OrderNoOne();
            //model.costomKey = "bowangjishi"; //costomKey!=Customkey ?
            model.caseCode = "0001075211202628";
            model.areaCode = "110000";
            var res = baoxianDataBLL.GetProductPropertyArea(model);
        }

        #endregion

        #region productDetails产品详细信息测试
        [TestMethod]
        public void ProductDetails()
        {
            BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
            ProductDetailsReq model = new ProductDetailsReq();
            model.transNo = UtilityHelper.CommonHelper.OrderNoOne();
            //model.customkey = "bowangjishi";
            model.caseCode = "0001077178502139";
            var res = baoxianDataBLL.GetProductDetails(model);

        }
        #endregion

        #region getOrderTrial订单试算测试
        [TestMethod]
        public void GetOrderTrial()
        {
            BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
            TrialReq model = new TrialReq();
            model.transNo = UtilityHelper.CommonHelper.OrderNoOne();
            //model.customkey = "bowangjishi";
            model.caseCode = "0000052178002133";
            model.newRestrictGenes = null;
            model.oldRestrictGene = null;
            var res = baoxianDataBLL.GetOrderTrial(model);
        }

        #endregion

        #region getHealthNotifyQues获取健康告知题目测试
        [TestMethod]
        public void GetHealthNotifyQues()
        {
            BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
            HealthNotifyQuesReq model = new HealthNotifyQuesReq();
            model.transNo = UtilityHelper.CommonHelper.OrderNoOne();
            //model.customkey = "bowangjishi";
            model.caseCode = "0000052178002133";
            var res = baoxianDataBLL.GetHealthNotifyQues(model);
        }
        #endregion

        #region healthAnswerSubmit健康告知提交测试
        [TestMethod]
        public void HealthAnswerSubmit()
        {
            BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
            HealthNotifyReq model = new HealthNotifyReq();
            model.transNo = UtilityHelper.CommonHelper.OrderNoOne();
            //model.customkey = "bowangjishi";
            model.answer = string.Empty;
            var res = baoxianDataBLL.HealthAnswerSubmit(model);
        }
        #endregion

        #region productInsuredArea产品可投保区域测试
        [TestMethod]
        public void ProductInsuredArea()
        {
            BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
            ProductInsuredAreaReq model = new ProductInsuredAreaReq();
            model.transNo = UtilityHelper.CommonHelper.OrderNoOne();
            model.caseCode = "0000052178002133";
            model.areaCode = "110000";
            var res = baoxianDataBLL.ProductInsuredArea(model);
        }

        #endregion


        #region 发送短信测试
        [TestMethod]
        public void SmsSendTest()
        {
            string msisdns = "13426086182";
            string smsContent = string.Format("尊敬的用户，您好：您的{0}交易流水号已于{1}已支付成功，投保单号为{2}，特此通知。"
                , "f088a1b28e5c4a5dabf81d4f96702b60", DateTime.Now.ToString("yy年MM月dd日HH时mm分"), "20170925002242");
            string result = SmsHelper.DoSend(msisdns, null, smsContent, null, string.Empty);
        }

        #endregion

        [TestMethod]
        public void sss()
        {
            #region 更新退保状态
            OrderRebateBLL opOrderRebateBLL = new OrderRebateBLL();
            OrderRebate modelOrderRebate = new OrderRebate();

            modelOrderRebate = opOrderRebateBLL.GetModel(1);
            if (modelOrderRebate != null)
            {
                modelOrderRebate.IsCancel = 1;
                bool res1 = opOrderRebateBLL.Update(modelOrderRebate);
            }
            #endregion
        }

    }
}
