using MofangInterface.Model.InputModel;
using MofangInterface.Model.OutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityHelper;
using BWJSLog.BLL;
using System.Diagnostics;
using System.Reflection;
using MofangInterface.Model;
using BWJSLog.Model;
using System.Net;
using System.IO;

namespace MofangInterface.BLL
{
    public class BaoxianDataBLL
    {
        /// <summary>
        /// 渠道密钥
        /// </summary>
        string VI = LinkFun.getVI();

        /// <summary>
        /// 接口地址
        /// </summary>
        string URLBaseMoFang = LinkFun.getURLBaseMoFang();

        /// <summary>
        /// 渠道商身份标识
        /// </summary>
        string Customkey = LinkFun.getCustomkey();

        ///// <summary>
        ///// 页面通知地址
        ///// </summary>
        //const string pageNoticeUrl = "";

        #region orderApply承保
        /// <summary>
        /// 承保
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OrderApplyOutputModel OrderApply(OrderApplyInputModel model)
        {
            try
            {
                string methodName = "orderApply";
                model.customkey = Customkey;
                string strJson = SerializerHelper.ToJson(model);
                string sign = UtilityHelper.Utils.MD5(VI + strJson);
                string url = URLBaseMoFang + methodName + ".html?sign=" + sign;
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, strJson);
                #region 发送魔方日志
                //MofangSendLog mofangSendLog = new MofangSendLog();
                //mofangSendLog.MothodName = "OrderApply";
                //mofangSendLog.FKID = ApplyId;
                //mofangSendLog.TransNo = orderModel.transNo;
                //mofangSendLog.IsSend = true;
                //mofangSendLogMessage =
                #endregion
                OrderApplyOutputModel outModel = new OrderApplyOutputModel();
                outModel = SerializerHelper.FromJsonTo<OrderApplyOutputModel>(retrunStr);
                if (outModel.respstat != "0000")
                {
                    ReceivedLog(model.transNo, "OrderApply", outModel.respmsg);
                }
                return outModel;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());

                return null;
            }
        }
        #endregion

        #region orderCancle退保
        /// <summary>
        /// 退保
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public OrderCancleOutputModel OrderCancle(OrderCancleInputModel model)
        {
            try
            {
                string methodName = "orderCancle";
                model.customkey = "bowangjishi";
                // UtilityHelper.CommonHelper.OrderNoOne();
                //model.transNo = Guid.NewGuid().ToString("N");
                string strJson = SerializerHelper.ToJson(model);
                string sign = UtilityHelper.Utils.MD5("c8d994c2e6f824eb9fc54e49c0d771c1" + strJson);
                string url = URLBaseMoFang + methodName + ".html?sign=" + sign;
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, strJson);
                OrderCancleOutputModel outModel = new OrderCancleOutputModel();
                outModel = SerializerHelper.FromJsonTo<OrderCancleOutputModel>(retrunStr);
                if (outModel.respstat != "0000")
                {
                    ReceivedLog(model.transNo, "OrderCancle", outModel.respmsg);
                }
                return outModel;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());

                return null;
            }
        }

        #endregion

        #region orderSummary投保单列表
        /// <summary>
        /// 投保单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public OrderSummaryOutputModel OrderSummary(OrderSummaryInputModel model)
        {
            try
            {
                string methodName = "orderSummary";
                model.customkey = Customkey;
                string strJson = SerializerHelper.ToJson(model);
                string sign = UtilityHelper.Utils.MD5(VI + strJson);
                string url = URLBaseMoFang + methodName + ".html?sign=" + sign;
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, strJson);
                OrderSummaryOutputModel outModel = new OrderSummaryOutputModel();
                outModel = SerializerHelper.FromJsonTo<OrderSummaryOutputModel>(retrunStr);
                //if (outModel.respstat != "0000")
                //{
                //    ReceivedLog(model.transNo, "OrderSummary", outModel.respmsg);
                //}
                return outModel;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());

                return null;
            }
        }

        #endregion

        #region getPayUrl获取支付链接
        /// <summary>
        /// 获取支付链接
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public GetPayUrlResp GetPayUrl(GetPayUrlReq model)
        {
            try
            {
                string methodName = "getPayUrl";
                model.customkey = Customkey;
                //  model.pageNoticeUrl = LinkFun.getPageNoticeUrl();
                model.pageNoticeUrl = UtilityHelper.Utils.UrlEncode(LinkFun.getPageNoticeUrl());
                string strJson = SerializerHelper.ToJson(model);
                string sign = UtilityHelper.Utils.MD5(VI + strJson);
                string url = URLBaseMoFang + methodName + ".html?sign=" + sign;
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, strJson);
                GetPayUrlResp outModel = new GetPayUrlResp();
                outModel = SerializerHelper.FromJsonTo<GetPayUrlResp>(retrunStr);
                if (outModel.respstat != "0000")
                {
                    ReceivedLog(model.transNo, "GetPayUrl", outModel.respmsg);
                }
                return outModel;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());

                return null;
            }
        }

        #endregion

        #region getProductPropertyArea产品财产所在地
        /// <summary>
        /// 产品财产所在地
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public ProductPropertyAreaResp GetProductPropertyArea(ProductPropertyAreaReq model)
        {
            try
            {
                string methodName = "getProductPropertyArea";
                model.customkey = Customkey;//costomKey!=Customkey ?
                string strJson = SerializerHelper.ToJson(model);
                string sign = UtilityHelper.Utils.MD5(VI + strJson);
                string url = URLBaseMoFang + methodName + ".html?sign=" + sign;
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, strJson);
                ProductPropertyAreaResp outModel = new ProductPropertyAreaResp();
                outModel = SerializerHelper.FromJsonTo<ProductPropertyAreaResp>(retrunStr);
                if (outModel.respstat != "0000")
                {
                    ReceivedLog(model.transNo, "GetProductPropertyArea", outModel.respmsg);
                }
                return outModel;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());

                return null;
            }
        }

        #endregion

        #region getProductDetails产品详细信息
        /// <summary>
        /// 产品详细信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public ProductDetailsResp GetProductDetails(ProductDetailsReq model)
        {
            try
            {
                string methodName = "getProductDetails";
                model.customkey = Customkey;
                string strJson = SerializerHelper.ToJson(model);
                string sign = UtilityHelper.Utils.MD5(VI + strJson);
                string url = URLBaseMoFang + methodName + ".html?sign=" + sign;
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, strJson);
                ProductDetailsResp outModel = new ProductDetailsResp();
                outModel = SerializerHelper.FromJsonTo<ProductDetailsResp>(retrunStr);
                if (outModel.respstat != "0000")
                {
                    ReceivedLog(model.transNo, "GetProductDetails", outModel.respmsg);
                }
                return outModel;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());

                return null;
            }
        }
        #endregion

        #region getOrderTrial订单试算
        /// <summary>
        /// 订单试算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TrialResp GetOrderTrial(TrialReq model)
        {
            try
            {
                string TransNo = UtilityHelper.CommonHelper.OrderNoOne();
                model.transNo = TransNo; //Guid.NewGuid().ToString("N");
                string methodName = "getOrderTrial";
                model.customkey = Customkey;
                string strJson = SerializerHelper.ToJson(model);
                string sign = UtilityHelper.Utils.MD5(VI + strJson);
                string url = URLBaseMoFang + methodName + ".html?sign=" + sign;
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, strJson);
                TrialResp outModel = new TrialResp();
                outModel = SerializerHelper.FromJsonTo<TrialResp>(retrunStr);
                if (outModel.respstat != "0000")
                {
                    ReceivedLog(model.transNo, "GetOrderTrial", outModel.respmsg);
                }
                return outModel;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());

                return null;
            }
        }

        #endregion

        #region getHealthNotifyQues获取健康告知题目

        /// <summary>
        /// 获取健康告知题目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HealthNotifyQuesResp GetHealthNotifyQues(HealthNotifyQuesReq model)
        {
            try
            {
                string methodName = "getHealthNotifyQues";
                model.customkey = Customkey;
                string strJson = SerializerHelper.ToJson(model);
                string sign = UtilityHelper.Utils.MD5(VI + strJson);
                string url = URLBaseMoFang + methodName + ".html?sign=" + sign;
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, strJson);
                HealthNotifyQuesResp outModel = new HealthNotifyQuesResp();
                outModel = SerializerHelper.FromJsonTo<HealthNotifyQuesResp>(retrunStr);
                if (outModel.respstat != "0000")
                {
                    ReceivedLog(model.transNo, "GetHealthNotifyQues", outModel.respmsg);
                }
                return outModel;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());

                return null;
            }
        }
        #endregion

        #region healthAnswerSubmit健康告知提交

        /// <summary>
        /// 健康告知提交
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HealthNotifyResp HealthAnswerSubmit(HealthNotifyReq model)
        {
            try
            {
                string methodName = "healthAnswerSubmit";
                model.customkey = Customkey;
                string strJson = SerializerHelper.ToJson(model);
                string sign = UtilityHelper.Utils.MD5(VI + strJson);
                string url = URLBaseMoFang + methodName + ".html?sign=" + sign;
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, strJson);
                HealthNotifyResp outModel = new HealthNotifyResp();
                outModel = SerializerHelper.FromJsonTo<HealthNotifyResp>(retrunStr);
                if (outModel.respstat != "0000")
                {
                    ReceivedLog(model.transNo, "HealthAnswerSubmit", outModel.respmsg);
                }
                return outModel;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return null;
            }
        }
        #endregion

        #region productInsuredArea产品可投保区域

        /// <summary>
        /// 产品可投保区域
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ProductDestinationResp ProductInsuredArea(ProductInsuredAreaReq model)
        {
            try
            {
                string methodName = "productInsuredArea";
                model.customkey = Customkey;
                string strJson = SerializerHelper.ToJson(model);
                string sign = UtilityHelper.Utils.MD5(VI + strJson);
                string url = URLBaseMoFang + methodName + ".html?sign=" + sign;
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, strJson);
                ProductDestinationResp outModel = new ProductDestinationResp();
                outModel = SerializerHelper.FromJsonTo<ProductDestinationResp>(retrunStr);
                if (outModel.respstat != "0000")
                {
                    ReceivedLog(model.transNo, "ProductInsuredArea", outModel.respmsg);
                }
                return outModel;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());

                return null;
            }
        }
        #endregion
        /// <summary>
        /// 产品出行目的地
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ProductCXDestinationResp ProductDestinations(ProductDestinationReq model)
        {
            try
            {
                string methodName = "productDestinations";
                model.customkey = Customkey;
                string strJson = SerializerHelper.ToJson(model);
                string sign = UtilityHelper.Utils.MD5(VI + strJson);
                string url = URLBaseMoFang + methodName + ".html?sign=" + sign;
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, strJson);
                ProductCXDestinationResp outModel = new ProductCXDestinationResp();
                outModel = SerializerHelper.FromJsonTo<ProductCXDestinationResp>(retrunStr);
                if (outModel.respstat != "0000")
                {
                    ReceivedLog(model.transNo, "ProductDestinations", outModel.respmsg);
                }
                return outModel;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                Log.WriteLog(" " + ex);
                return null;
            }
        }
        //body是要传递的参数,格式"roleId=1&uid=2"
        //post的cotentType填写:
        //"application/x-www-form-urlencoded"
        //soap填写:"text/xml; charset=utf-8"
        public static string PostHttp(string url, string body, string contentType)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 20000;

            byte[] btBodys = Encoding.UTF8.GetBytes(body);
            httpWebRequest.ContentLength = btBodys.Length;
            httpWebRequest.GetRequestStream().Write(btBodys, 0,  btBodys.Length);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
           
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();

            httpWebResponse.Close();
            streamReader.Close();
            httpWebRequest.Abort();
            httpWebResponse.Close();

            return responseContent;
        } 

        public JobInfoResp GetJobInfo(JobInfoReq model)
        {
            try
            {
                string methodName = "getProductJob";
                model.customkey = Customkey;
                string strJson = SerializerHelper.ToJson(model);
                string sign = UtilityHelper.Utils.MD5(VI + strJson);
                string url = URLBaseMoFang + methodName + ".html?sign=" + sign;
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, strJson);
                         
               string retrunStr22= PostHttp(url, strJson, "application/json;charset=utf-8");
               // string retrunStr = UtilityHelper.HttpService.Post(url, strJson);
                JobInfoResp outModel = new JobInfoResp();
                outModel = SerializerHelper.FromJsonTo<JobInfoResp>(retrunStr);
                if (outModel.respstat != "0000")
                {
                    ReceivedLog(model.transNo, "GetJobInfo", outModel.respmsg);
                }
                return outModel;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                Log.WriteLog(" " + ex);
                return null;
            }
        }

        public void ReceivedLog(string transNo, string mothodName, string respmsg)
        {
            MofangReceivedLogBLL oMofangReceivedLogBLL = new MofangReceivedLogBLL();
            MofangReceivedLog oLogModel = new MofangReceivedLog();
            oLogModel.TransNo = transNo;//这里存提交时的订单号，
            oLogModel.RecordCreateTime = DateTime.Now;
            oLogModel.RecordUpdateTime = DateTime.Now;
            oLogModel.ReceivedTime = DateTime.Now;
            oLogModel.MothodName = mothodName;
            oLogModel.Message = respmsg;
            oMofangReceivedLogBLL.Add(oLogModel);
        }
    }
}
