using BWJS.AppCode;
using Mofang.BLL;
using Mofang.Model;
using BWJS.Model;
using BWJS.BLL;
using UtilityHelper;
using System;
using System.Web.UI;
using System.Text;
using System.Data;
using BWJSLog.BLL;

namespace BWJS.WebApp.Mofang
{
    public partial class PayResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetPayResult();
            }
        }

        /// <summary>
        /// 获取的支付结果
        /// </summary>
        protected void GetPayResult()
        {
            //HttpContext.Current.Response.ContentType = "application/octet-stream";
            //HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
            //byte[] reqData = HttpContext.Current.Request.BinaryRead(HttpContext.Current.Request.TotalBytes);
            //string jsonText = Encoding.Default.GetString(reqData);
            /*
            BSId	String	业务系统流水号
Price	String	支付的金额
PayOrderNumber	String	支付单号码（支付系统唯一标识)
OnlinePaymnetId	String	在线支付标识
PaymentId	String	支付系统流水号
Success	String	成功则为：Success,失败不会通知
            */
            try
            {

                #region 取值

                string BSId = DNTRequest.GetString("BSId");
                string Price = DNTRequest.GetString("Price");
                string PayOrderNumber = DNTRequest.GetString("PayOrderNumber");
                string OnlinePaymnetId = DNTRequest.GetString("OnlinePaymnetId");
                string PaymentId = DNTRequest.GetString("PaymentId");
                string Success = DNTRequest.GetString("Success");
                int orderApplyId = 0;
                int orderRebateId = 0;
                string insureNum = DNTRequest.GetString("insureNum");
                StringBuilder where = new StringBuilder();
                DataSet ds = null;
                DataTable dt = null;
                if (!string.IsNullOrEmpty(insureNum))
                {
                    OrderApplyBLL opOrderApplyBLL = new OrderApplyBLL();
                    OrderApply modelOrderApply = new OrderApply();
                    where.AppendFormat("insurenum='{0}'", insureNum);
                    ds = new DataSet();
                    ds = opOrderApplyBLL.GetList(where.ToString());
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }

                }
                #endregion

                #region 支付结果更新

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    orderApplyId = ComPage.SafeToInt(dr["OrderApplyID"]);

                    #region 更新订单返利信息
                    OrderRebateBLL opSys_OrderRebate = new OrderRebateBLL();
                    OrderRebate modelSys_OrderRebate = new OrderRebate();
                    where = new StringBuilder();
                    where.AppendFormat("OrderApplyId={0}", orderApplyId);
                    ds = new DataSet();
                    ds = opSys_OrderRebate.GetList(where.ToString());
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            modelSys_OrderRebate = opSys_OrderRebate.DataRowToModel(dt.Rows[0]);
                            if (modelSys_OrderRebate != null)
                            {
                                litPrice.Text = modelSys_OrderRebate.OrderMoney.ToString("N2") + "元";
                                modelSys_OrderRebate.PayStatus = 1;
                                orderRebateId = modelSys_OrderRebate.OrderRebateId;
                                opSys_OrderRebate.Update(modelSys_OrderRebate);
                            }
                        }
                    }

                    #endregion

                    #region 更新订单支付申请
                    if (orderRebateId > 0)
                    {
                        OrderPayApplyBLL opSys_OrderPayApplyBLL = new OrderPayApplyBLL();
                        OrderPayApply modelSys_OrderPayApply = new OrderPayApply();
                        where = new StringBuilder();
                        where.AppendFormat("OrderRebateId={0}", orderRebateId);
                        ds = new DataSet();
                        ds = opSys_OrderPayApplyBLL.GetList(where.ToString());
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                modelSys_OrderPayApply = opSys_OrderPayApplyBLL.DataRowToModel(dt.Rows[0]);
                                if (modelSys_OrderPayApply != null)
                                {
                                    modelSys_OrderPayApply.PayOrderNumber = PayOrderNumber;
                                    modelSys_OrderPayApply.PayStatus = 1;
                                    modelSys_OrderPayApply.PayPlatform = 1;
                                    modelSys_OrderPayApply.PayMethod = 1;
                                    modelSys_OrderPayApply.PayCode = Success;
                                    string payMethod = "支付宝";
                                    switch (modelSys_OrderPayApply.PayMethod)
                                    {
                                        case 1:
                                            payMethod = "支付宝";
                                            break;
                                    }
                                    litPayMethod.Text = payMethod;
                                    litRemark.Text = modelSys_OrderPayApply.Remark;
                                    modelSys_OrderPayApply.PayDate = DateTime.Now;
                                    opSys_OrderPayApplyBLL.Update(modelSys_OrderPayApply);
                                }
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    litSuccess.Text = "未获取到支付信息";
                }

                #endregion


                #region 显示到页面

                litBSId.Text = insureNum;
                //litPayOrderNumber.Text = PayOrderNumber;
                litSuccess.Text = "支付成功";

                #endregion

                #region 记录通知结果
                var obj = new
                {
                    BSId = BSId,
                    Price = Price,
                    PayOrderNumber = PayOrderNumber,
                    OnlinePaymnetId = OnlinePaymnetId,
                    PaymentId = PaymentId,
                    Success = Success,
                };
                string res = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                //ExceptionLogBLL.WriteExceptionLogToDB("支付通知：" + res);
                #endregion

            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB("支付结果通知异常：" + ex.ToString());
            }
        }
    }
}