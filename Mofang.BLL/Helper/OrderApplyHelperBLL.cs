using UtilityHelper;
using MofangInterface.BLL;
using MofangInterface.Model;
using MofangInterface.Model.InputModel;
using MofangInterface.Model.OutputModel;
using BWJS.BLL;
using BWJS.Model;
using Mofang.DAL;
using Mofang.Model.ViewModel;
using BWJSLog.BLL;
using BWJSLog.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BWJS.BLL.CookieMag;

namespace Mofang.BLL.Helper
{
    public partial class OrderApplyHelperBLL
    {
        private readonly ApplicationDataDAL dalApplicationData = new ApplicationDataDAL();
        private readonly ApplicantInfoDAL dalApplicantInfo = new ApplicantInfoDAL();
        private readonly InsurantInfoDAL dalInsurantInfo = new InsurantInfoDAL();
        private readonly OrderApplyDAL dalOrderApply = new OrderApplyDAL();
        private readonly OtherInfoDAL otherInfoDAL = new OtherInfoDAL();
        int departmentId = 0;
        public bool OrderApplyAdd(OrderApplyViewModel viewModel, out string msg)
        {
            msg = "ok";
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    { 
                        int ApplyId = dalOrderApply.Add(viewModel.orderApply, trans, conn);//
                        if (ApplyId < 0)
                        { 
                            return false;
                        }
                        else
                        {
                            viewModel.insurantInfo.OrderApplyID = ApplyId;
                            viewModel.applicantInfo.OrderApplyID = ApplyId;
                            viewModel.applicationData.OrderApplyID = ApplyId;
                            viewModel.otherInfo.OrderApplyID = ApplyId;
                            #region 创建人赋值
                       
                            //LoginUserCookie cookie = MerchantFrontCookieBLL.GetMerchantFrontUserCookie();
                            int createUserId = MerchantFrontCookieBLL.GetMerchantFrontUserId();
                            //int createUserId= cookie.LoginUserID;
                            try
                            {
                                UsersBLL opUsersBLL = new UsersBLL();
                                Users modelUsers = opUsersBLL.GetModel(createUserId);
                                if (modelUsers != null) {
                                    departmentId = modelUsers.DepartmentID;
                                }
                            }
                            catch { }
                            viewModel.insurantInfo.CreatUserID = createUserId;
                            viewModel.applicantInfo.CreatUserID = createUserId;
                            viewModel.applicationData.CreatUserID = createUserId;
                            viewModel.otherInfo.CreatUserID = createUserId;
                            viewModel.orderApply.CreatUserID = createUserId;
                            viewModel.orderApply.DepartmentId = departmentId;
                            #endregion

                        }
                        int retCatId = dalApplicationData.Add(viewModel.applicationData, trans, conn);//
                        int retInfoId = dalApplicantInfo.Add(viewModel.applicantInfo, trans, conn);//
                        int retInsurantId = dalInsurantInfo.Add(viewModel.insurantInfo, trans, conn);//
                        int retotherId = otherInfoDAL.Add(viewModel.otherInfo, trans, conn); 
                        //调用Mofang业务BaoxianDataBLL

                        BaoxianDataBLL baoxianBLL = new BaoxianDataBLL();
                        OrderApplyInputModel orderModel = new OrderApplyInputModel();
                        orderModel.applicantinfo = new ApplicantInfo();
                        orderModel.applicantinfo.cName = viewModel.applicantInfo.CName;
                        orderModel.applicantinfo.eName = viewModel.applicantInfo.EName;
                        orderModel.applicantinfo.cardType = viewModel.applicantInfo.CardType;
                        orderModel.applicantinfo.cardCode = viewModel.applicantInfo.CardCode;
                        orderModel.applicantinfo.sex = viewModel.applicantInfo.Sex;
                        orderModel.applicantinfo.birthday = viewModel.applicantInfo.BirthDay;
                        orderModel.applicantinfo.mobile = viewModel.applicantInfo.Mobile;
                        orderModel.applicantinfo.email = viewModel.applicantInfo.Email;
                        orderModel.applicantinfo.cardPeriod = viewModel.applicantInfo.CardPeriod;
                        orderModel.applicantinfo.job = viewModel.applicantInfo.Job;

                        orderModel.applicationdata = new ApplicationData();
                        orderModel.applicationdata.applicationDate = viewModel.applicationData.ApplicationDate;
                        orderModel.applicationdata.startDate = viewModel.applicationData.StartDate;
                        orderModel.applicationdata.endDate = viewModel.applicationData.EndDate;

                        orderModel.insurantInfo = new InsurantInfo();
                        orderModel.insurantInfo.birthday = viewModel.insurantInfo.Birthday;
                        orderModel.insurantInfo.cardCode = viewModel.insurantInfo.CardCode;
                        orderModel.insurantInfo.cardPeriod = viewModel.insurantInfo.CardPeriod;
                        orderModel.insurantInfo.cardType = viewModel.insurantInfo.CardType;
                        orderModel.insurantInfo.cName = viewModel.insurantInfo.CName;
                        orderModel.insurantInfo.count = viewModel.insurantInfo.Count;
                        orderModel.insurantInfo.eName = viewModel.insurantInfo.EName;
                        orderModel.insurantInfo.mobile = viewModel.insurantInfo.Mobile;
                        orderModel.insurantInfo.relationId = viewModel.insurantInfo.RelationID;
                        orderModel.insurantInfo.sex = viewModel.insurantInfo.Sex;
                        orderModel.insurantInfo.singlePrice = viewModel.insurantInfo.SinglePrice;
                        orderModel.insurantInfo.email = viewModel.insurantInfo.Email;
                        orderModel.insurantInfo.job = viewModel.insurantInfo.Job;
                        orderModel.caseCode = viewModel.caseCode;
                        orderModel.transNo = viewModel.transNo;
                        int Days = 0;
                        try
                        {
                            TimeSpan ts = Convert.ToDateTime(viewModel.applicationData.EndDate) - Convert.ToDateTime(viewModel.applicationData.StartDate);
                            Days = ts.Days;
                            if (Days == 0)
                            {
                                msg = "投保时间差有误!";
                            }
                        }
                        catch(Exception ex)
                        {
                            ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                        }
                        orderModel.insurantDateLimit = Days.ToString();

                        orderModel.otherInfo = new OtherInfo();
                        orderModel.otherInfo.provCityId = viewModel.otherInfo.ProvCityID;
                        orderModel.otherInfo.cardPeriod = viewModel.otherInfo.CardPeriod.ToString("yyyy-MM-dd");
                        orderModel.otherInfo.notifyAnswerId = viewModel.otherInfo.NotifyAnswerID.ToString();
                        orderModel.otherInfo.priceArgsId = viewModel.otherInfo.PriceArgsID;

                        orderModel.otherInfo.visaCity = viewModel.otherInfo.VisaCity;
                        orderModel.otherInfo.destination = viewModel.otherInfo.Destination;
                        orderModel.otherInfo.tripPurposeId = viewModel.otherInfo.TripPurposeId;
                        orderModel.otherInfo.propertyAddress = viewModel.otherInfo.PropertyAddress;
                        orderModel.otherInfo.relatedPersonHouse = viewModel.otherInfo.RelatedPersonHouse; 

                        OrderApplyOutputModel outPutModel = baoxianBLL.OrderApply(orderModel); 
                        OrderPayViewModel orderPayViewModel = new OrderPayViewModel();
                        orderPayViewModel.transNo = outPutModel.transNo;
                        orderPayViewModel.insureNum = outPutModel.insureNum;
                        orderPayViewModel.price = outPutModel.price;
                        orderPayViewModel.caseCode = orderModel.insurantInfo.cardCode;
                        orderPayViewModel.customkey = orderModel.customkey;
                        msg = SerializerHelper.SerializeObject(outPutModel);
                        if (outPutModel.respstat == "0000")
                        {
                            trans.Commit();//提交事务
                            Model.OrderApply oOrderApply = new Model.OrderApply();
                            OrderApplyBLL orderbll = new OrderApplyBLL();
                            oOrderApply = orderbll.GetModel(ApplyId);
                            oOrderApply.InsureNum = orderPayViewModel.insureNum;
                            oOrderApply.Price = orderPayViewModel.price;
                            oOrderApply.Respmsg = outPutModel.respmsg;
                            oOrderApply.Respstat = outPutModel.respstat;
                            oOrderApply.DepartmentId = departmentId;
                            bool flag = dalOrderApply.Update(oOrderApply);
                            if (!flag)
                            {
                                ExceptionLogBLL.WriteExceptionLogToDB("更新OrderApply表失败");
                            }
                            else //没问题后提交返利设置
                            {
                                #region 获取渠道返利设置
                                if (ApplyId > 0)
                                {
                                    CompanyRebate modelSys_CompanyRebate = new CompanyRebate();
                                    CompanyRebateBLL opSys_CompanyRebateBLL = new CompanyRebateBLL();
                                    StringBuilder where = new StringBuilder();
                                    where.AppendFormat("IsDeleted=0 and casecode='{0}'", viewModel.caseCode);
                                    DataSet ds = opSys_CompanyRebateBLL.GetList(where.ToString());
                                    DataTable dt = null;
                                    if (ds != null && ds.Tables.Count > 0)
                                    {
                                        dt = ds.Tables[0];
                                    }
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        DataRow dr = dt.Rows[0];
                                        modelSys_CompanyRebate = opSys_CompanyRebateBLL.DataRowToModel(dr);
                                        if (modelSys_CompanyRebate != null)
                                        {
                                            /*
                                            总价=订单金额
                                            总部毛利=总价*产品分成百分比（魔方提供 我方后台管理设置渠道各产品返回分成百分比）
                                            商家利润=总部毛利*商家返利百分比（我方后台管理设置渠各产品商家分成百分比）
                                            代理商利润=总部毛利*代理商返利百分比（我方后台管理设置渠各产品商家分成百分比）
                                            总部净利润=总部毛利-商家利润-代理商利润
                                            */
                                            decimal orderMoney = viewModel.TotalPrice;
                                            decimal hqRebate = modelSys_CompanyRebate.CompanyRebatePer;
                                            decimal hqMoney = orderMoney * (hqRebate / 100);
                                            decimal agentRebate = modelSys_CompanyRebate.AgentRebate;
                                            decimal agentMoney = hqMoney * (agentRebate / 100);
                                            decimal merchantRebate = modelSys_CompanyRebate.MerchantRebate;
                                            decimal merchantMoney = hqMoney * (merchantRebate / 100);
                                            decimal netProfit = hqMoney - agentMoney - merchantMoney;

                                            #region 订单返利信息入库
                                            OrderRebateBLL opSys_OrderRebate = new OrderRebateBLL();
                                            OrderRebate modelSys_OrderRebate = new OrderRebate();
                                            modelSys_OrderRebate.TransNo = viewModel.transNo;
                                            modelSys_OrderRebate.CompanyId = 1;
                                            modelSys_OrderRebate.UserId = viewModel.orderApply.UserID;
                                            modelSys_OrderRebate.OrderApplyId = ApplyId;
                                            modelSys_OrderRebate.CompanyRebateId = modelSys_CompanyRebate.CompanyRebateId;
                                            modelSys_OrderRebate.OrderMoney = orderMoney;
                                            modelSys_OrderRebate.HQRebate = hqRebate;
                                            modelSys_OrderRebate.HQMoney = hqMoney;
                                            modelSys_OrderRebate.MerchantRebate = merchantRebate;
                                            modelSys_OrderRebate.MerchantMoney = merchantMoney;
                                            modelSys_OrderRebate.AgentRebate = agentRebate;
                                            modelSys_OrderRebate.AgentMoney = agentMoney;
                                            modelSys_OrderRebate.NetProfit = netProfit;
                                            modelSys_OrderRebate.PayStatus = 0;
                                            modelSys_OrderRebate.IsSettled = 0;
                                            modelSys_OrderRebate.IsCancel = 0;
                                            modelSys_OrderRebate.SettlementDate = null;
                                            modelSys_OrderRebate.CreateDate = DateTime.Now;
                                            modelSys_OrderRebate.Remark = modelSys_CompanyRebate.RebateName;
                                            modelSys_OrderRebate.IsDeleted = 0;
                                            int orderRebateId = opSys_OrderRebate.Add(modelSys_OrderRebate);
                                            if (orderRebateId < 0)
                                            {
                                                ExceptionLogBLL.WriteExceptionLogToDB("订单返利信息添加失败");
                                            }

                                            #endregion

                                            #region 订单支付申请预先入库
                                            OrderPayApplyBLL opSys_OrderPayApplyBLL = new OrderPayApplyBLL();
                                            OrderPayApply modelSys_OrderPayApply = new OrderPayApply();
                                            modelSys_OrderPayApply.OrderRebateId = orderRebateId;
                                            modelSys_OrderPayApply.OrderMoney = orderMoney;
                                            modelSys_OrderPayApply.PayOrderNumber = string.Empty;
                                            modelSys_OrderPayApply.PayStatus = 0;
                                            modelSys_OrderPayApply.PayPlatform = 1;
                                            modelSys_OrderPayApply.PayMethod = 1;
                                            modelSys_OrderPayApply.PayCode = string.Empty;
                                            modelSys_OrderPayApply.PayText = string.Empty;
                                            modelSys_OrderPayApply.PayJson = string.Empty;
                                            modelSys_OrderPayApply.CreateDate = DateTime.Now;
                                            modelSys_OrderPayApply.Remark = modelSys_CompanyRebate.RebateName;
                                            modelSys_OrderPayApply.IsDeleted = 0;
                                            int res1 = opSys_OrderPayApplyBLL.Add(modelSys_OrderPayApply);
                                            if (res1 < 0)
                                            {
                                                ExceptionLogBLL.WriteExceptionLogToDB("订单支付申请预先入库失败");
                                            }
                                            #endregion
                                        }
                                    }
                                    else
                                    {
                                        ExceptionLogBLL.WriteExceptionLogToDB("获取渠道返利设置信息获取失败");
                                    }
                                }
                                #endregion
                            } 
                        }
                        else
                        {
                            trans.Rollback(); 
                        } 
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());   
                        return false;
                    }
                }
            }
        }
    }
}
