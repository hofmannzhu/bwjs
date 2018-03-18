using BWJS.AppCode;
using BWJS.BLL;
using BWJS.BLL.CookieMag;
using BWJS.Model;
using BWJS.Model.Model;
using BWJSLog.BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Xml;
using UtilityHelper;
using XBWN.DAL;
using XBWN.Model;
using XBWNInterface.Model;

namespace XBWNInterface.BLL
{
    public class NewLoanInterface
    {
        /// <summary>
        /// 移动端来源[安卓ANDROID、苹果IOS、BWPC]
        /// </summary>
        static string source = CommonHelper.GetAppSettingsValue("source", "BWPC");
        /// <summary>
        /// 渠道来源  如：xx商城
        /// </summary>
        static string sourceChannel = CommonHelper.GetAppSettingsValue("sourceChannel", "18");
        /// <summary>
        /// cookie键
        /// </summary>
        static string cookieKey = CommonHelper.GetAppSettingsValue("cookieKey", "token");
        /// <summary>
        /// cookie值
        /// </summary>
        static public string cookieValue = string.Empty;
        /// <summary>
        /// 公钥加密
        /// </summary>
        static string publicKey = RSA.RSAPublicKeyJava2DotNet(CommonHelper.GetAppSettingsValue("publicKey", string.Empty));
        /// <summary>
        /// 私钥解密
        /// </summary>
        static string privateKey = RSA.RSAPrivateKeyJava2DotNet(CommonHelper.GetAppSettingsValue("privateKey", string.Empty));
        /// <summary>
        /// 信博维诺对接地址
        /// </summary>
        static string xinboweinuoApi = CommonHelper.GetAppSettingsValue("xinboweinuoApi", "http://192.168.66:66");
        /// <summary>
        /// 信博维诺对接地址风控测试
        /// </summary>
        static string newxinboweinuoApi = CommonHelper.GetAppSettingsValue("newxinboweinuoApi", "http://192.168.66:66");

        #region 图片上传
        /// <summary>
        /// 图片上传
        /// </summary>
        static public Object ImagesUpload(string base64Code, byte[] photoData, string fileName, string contentType, string sskdRequestParasJson)
        {
            string result = string.Empty;
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }

                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = sskdRequestParas.Timestamp;
                header.orderNo = sskdRequestParas.OrderNo;
                header.sign = sskdRequestParas.Sign;
                header.equipmentNo = sskdRequestParas.EquipmentNo;
                header.merchantsNo = sskdRequestParas.MerchantsNo;
                header.orderType = "LOAN";
                header.orderSource = "BWPC";
                req.header = header;

                var data = new
                {
                    consumeTime = GetConsumeTime(sskdRequestParas)
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/h/up/f";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookieAndByteForUpload(apiUrl, inputJson, photoData, cookieKey, sskdRequestParas.Token, fileName, contentType);
                ILog.ApiInvokingLogAdd(sskdRequestParas.ConsultId, apiUrl, requestDate, inputJson, outputJson);

                #region 解析返回json
                int imgId = 0;
                bool success = false;
                string message = string.Empty;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    message = UtilityHelper.TypeConverter.SafeToString(o["message"]);
                    if (success)
                    {
                        imgId = UtilityHelper.TypeConverter.ObjectToInt(o["data"]["imgId"]);
                        #region 添加图片
                        if (imgId != 0)
                        {
                            if (!string.IsNullOrEmpty(base64Code))
                            {
                                base64Code = base64Code.Replace(" ", "+");
                            }
                            NL_Picture model = new NL_Picture();
                            model.ConsultId = sskdRequestParas.ConsultId;
                            model.Base64Code = base64Code;
                            model.ImgId = imgId.ToString();
                            model.IsDeleted = 0;
                            model.CreateDate = DateTime.Now;
                            NL_PictureBLL dal = new NL_PictureBLL();
                            dal.Add(model);
                        }
                        #endregion
                        result = outputJson;
                    }
                    else
                    {
                        result = DNTRequest.GetResultJsonForApi(false, "接口返回消息，" + message, null);
                    }
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
                #endregion
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "图片上传异常，请稍后再试", null);
            }
            return result;
        }

        /// <summary>
        /// 身份证图片上传
        /// </summary>
        static public string ImagesUploadForConsult(string base64Code, byte[] photoData, string sign, string orderNo, string equipmentNo, string merchantsNo, int netLoanApplyId, string fileName, string contentType, string sskdRequestParasJson, long timestamp, ref string msg)
        {
            string faceId = string.Empty;
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }
                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = timestamp;
                header.orderNo = orderNo;
                header.sign = sign;
                header.equipmentNo = equipmentNo;
                header.merchantsNo = merchantsNo;
                header.orderType = "LOAN";
                header.orderSource = "BWPC";
                req.header = header;

                var data = new
                {
                    consumeTime = GetConsumeTime(sskdRequestParas)
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/h/up/f";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookieAndByteForUpload(apiUrl, inputJson, photoData, cookieKey, cookieValue, fileName, contentType);
                ILog.ApiInvokingLogAdd(netLoanApplyId, apiUrl, requestDate, inputJson, outputJson);

                #region 解析返回json
                int imgId = 0;
                bool success = false;
                string message = string.Empty;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    message = UtilityHelper.TypeConverter.SafeToString(o["message"]);
                    if (success)
                    {
                        imgId = UtilityHelper.TypeConverter.ObjectToInt(o["data"]["imgId"]);
                        #region 添加图片
                        if (imgId != 0)
                        {
                            if (!string.IsNullOrEmpty(base64Code))
                            {
                                base64Code = base64Code.Replace(" ", "+");
                            }
                            NL_Picture model = new NL_Picture();
                            model.ConsultId = netLoanApplyId;
                            model.Base64Code = base64Code;
                            model.ImgId = imgId.ToString();
                            model.IsDeleted = 0;
                            model.CreateDate = DateTime.Now;
                            NL_PictureBLL dal = new NL_PictureBLL();
                            dal.Add(model);
                            faceId = imgId.ToString();
                        }
                        #endregion
                    }
                    else
                    {
                        msg = "接口返回消息，" + message;
                    }
                }
                else
                {
                    msg = "接口无响应，请稍后再试";
                }
                #endregion

            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                msg = "身份证图片上传异常，请稍后再试";
            }
            return faceId;
        }

        #endregion end 图片上传

        #region 检查身份认证是否成功
        /// <summary>
        /// 检查身份认证是否成功
        /// </summary>
        static public Object CheckUserIsAuthentication(string memberId, string customerId, int netLoanApplyId, string sskdRequestParasJson)
        {
            string result = string.Empty;
            try
            {
                if (netLoanApplyId != -1)
                {
                    NL_ConsultBLL bll = new NL_ConsultBLL();
                    NL_Consult model = bll.GetModel(netLoanApplyId);
                    if (model != null)
                    {
                        if (model.IdentitySuccess)
                        {
                            result = DNTRequest.GetResultJsonForApi(true, "success", null);
                        }
                        else
                        {
                            result = DNTRequest.GetResultJsonForApi(false, "未认证失败", null);
                        }
                    }
                    else
                    {
                        result = DNTRequest.GetResultJsonForApi(false, "未认证", null);
                    }
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJsonForApi(false, "检查身份认证是否成功异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion end 身份证信息提交

        #region 提交采集的人像信息
        /// <summary>
        /// 提交采集的人像信息
        /// </summary>
        static public Object SubmitIDInformation(string sign, string orderNo, string equipmentNo, string merchantsNo, string faceIds, string idCardIds, string realName, string idCardNo, string sex, string birth, string national, string address, string authority, string validperiod, int consultId, string sskdRequestParasJson, string orderSource = "")
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string result = string.Empty;
            try
            {
                ApplyStatusChange(consultId, 200, 100, string.Empty);

                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }

                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                header.orderNo = orderNo;
                header.sign = sign;
                header.equipmentNo = equipmentNo;
                header.merchantsNo = merchantsNo;
                header.orderType = "LOAN";
                header.orderSource = orderSource;
                req.header = header;

                var data = new
                {
                    faceIds = faceIds,
                    idCardIds = idCardIds,
                    realName = realName,
                    idCardNo = idCardNo,
                    sex = sex,
                    birth = birth,
                    national = national,
                    address = address,
                    authority = authority,
                    validperiod = validperiod,
                    consumeTime = GetConsumeTime(sskdRequestParas)
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/c/cp";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                ILog.ApiInvokingLogAdd(consultId, apiUrl, requestDate, inputJson, outputJson);

                #region 解析返回json
                bool success = false;
                //bool identitySuccess = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    //if (success)
                    //{
                    //    identitySuccess = UtilityHelper.TypeConverter.StrToBool(o["data"]["success"].ToString(), false);
                    //}
                }
                #endregion

                #region 修改认证状态
                if (success)
                {
                    NL_ConsultBLL dalUsers = new NL_ConsultBLL();
                    NL_Consult dbmodelUsers = dalUsers.GetModel(consultId);
                    if (dbmodelUsers != null)
                    {
                        dbmodelUsers.FontId = idCardIds;
                        dbmodelUsers.FaceNo = faceIds;
                        dbmodelUsers.IdentitySuccess = success;
                        dalUsers.Update(dbmodelUsers);
                    }
                }
                #endregion

                result = outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "提交采集的人像信息异常，请稍后再试", null);
            }
            return result;
        }

        #endregion end 身份证信息提交

        #region 根据四要素得到绑定卡
        /// <summary>
        /// 根据四要素得到绑定卡
        /// </summary>
        static public Object GetBankCardListByFourElements(string consultId, string token, string realName, string telNo, string idCardNo, string bankCardNo, string sskdRequestParasJson)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(realName))
                {
                    return DNTRequest.GetResultJsonForApi(false, "姓名必须填写", null);
                }
                if (string.IsNullOrEmpty(telNo))
                {
                    return DNTRequest.GetResultJsonForApi(false, "电话必须填写", null);
                }
                if (string.IsNullOrEmpty(idCardNo))
                {
                    return DNTRequest.GetResultJsonForApi(false, "证件号码必须填写", null);
                }
                if (string.IsNullOrEmpty(bankCardNo))
                {
                    return DNTRequest.GetResultJsonForApi(false, "银行卡号必须填写", null);
                }

                NL_BankBLL bll = new NL_BankBLL();
                string where = string.Format("RealName='{0}' and TelNo='{1}' and IdNo='{2}' and BankCardNo='{3}'", realName, telNo, idCardNo, bankCardNo);
                List<NL_Bank> list = bll.GetModelList(where);
                if (list.Count > 0)
                {
                    result = DNTRequest.GetResultJsonForApi(true, "success", list);
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "未绑定卡", null);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "根据四要素得到绑定卡异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 根据根据姓名证件号码得到绑定卡
        /// <summary>
        /// 根据根据姓名证件号码得到绑定卡
        /// </summary>
        static public Object GetBankCardListByTwoElements(string consultId, string token, string realName, string idCardNo, string sskdRequestParasJson, string orderSource = "")
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(realName))
                {
                    return DNTRequest.GetResultJsonForApi(false, "姓名必须填写", null);
                }
                if (string.IsNullOrEmpty(idCardNo))
                {
                    return DNTRequest.GetResultJsonForApi(false, "证件号码必须填写", null);
                }

                NL_BankBLL bll = new NL_BankBLL();
                string where = string.Format("RealName='{0}' and IdNo='{1}'", realName, idCardNo);
                List<NL_Bank> list = bll.GetModelList(where);
                if (list.Count > 0)
                {
                    result = DNTRequest.GetResultJsonForApi(true, "success", list);
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "未绑定卡", null);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "姓名证件号码得到绑定卡异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 银行卡列表
        /// <summary>
        /// 银行卡列表
        /// </summary>
        static public Object BankCardList(string sskdRequestParasJson)
        {
            string result = string.Empty;
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }

                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = sskdRequestParas.Timestamp;
                header.orderNo = sskdRequestParas.OrderNo;
                header.sign = sskdRequestParas.Sign;
                header.equipmentNo = sskdRequestParas.EquipmentNo;
                header.merchantsNo = sskdRequestParas.MerchantsNo;
                header.orderType = "LOAN";
                header.orderSource = sskdRequestParas.OrderSource;
                req.header = header;
                var data = new
                {
                    consumeTime = GetConsumeTime(sskdRequestParas),
                    token = sskdRequestParas.Token
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/b/gbcc";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, sskdRequestParas.Token); ;
                ILog.ApiInvokingLogAdd(sskdRequestParas.ConsultId, apiUrl, requestDate, inputJson, outputJson);

                #region 解析返回json
                string bankCardId = string.Empty;
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                    }
                    result = outputJson;
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
                #endregion

            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "获取银行卡列表异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 添加银行卡
        /// <summary>
        /// 添加银行卡
        /// </summary>
        /// <param name="realName">卡姓名，cash=1时必填</param>
        /// <param name="idNo">身份证。cash=1时必填</param>
        /// <param name="bankCardNo">银行卡号</param>
        /// <param name="telNo">手机号</param>
        /// <param name="cash">(1)|(0),1-提现卡，0-非提现卡</param>
        /// <param name="netLoanApplyId"></param> 
        static public Object BankCardAdd(string realName, string idCardNo, string bankCardNo, string telNo, string sign, string orderNo, string timeUnix, string merchantsNo, string equipmentNo, int consultId, string sskdRequestParasJson, string orderSource = "")
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string result = string.Empty;
            try
            {
                ApplyStatusChange(consultId, 700, 400, string.Empty);

                SSKDRequestParas sskdRequestParas = null;
                //if (!string.IsNullOrEmpty(sskdRequestParasJson))
                //{
                //    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                //}

                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = long.Parse(timeUnix);
                header.orderNo = orderNo;
                header.sign = sign;
                header.equipmentNo = equipmentNo;
                header.merchantsNo = merchantsNo;
                header.orderType = "LOAN";
                header.orderSource = orderSource;
                req.header = header;
                var data = new
                {
                    realName = realName,
                    idNo = idCardNo,
                    bankCardNo = bankCardNo,
                    telNo = telNo,
                    //consumeTime = GetConsumeTime(sskdRequestParas)

                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/b/acbc";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue); ;
                ILog.ApiInvokingLogAdd(consultId, apiUrl, requestDate, inputJson, outputJson);

                #region 解析返回json
                string bankCardId = string.Empty;
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                        bankCardId = o["data"]["bankCardId"].ToString();
                        #region 添加银行卡
                        if (!string.IsNullOrEmpty(bankCardId))
                        {
                            NL_BankBLL bll = new NL_BankBLL();
                            NL_Bank model = bll.GetModel(realName, telNo, idCardNo, bankCardNo);
                            if (model == null)
                            {
                                model = new NL_Bank();
                                model.ConsultId = consultId;
                                model.No = bankCardId;
                                model.BankCardNo = bankCardNo;
                                model.TelNo = telNo;
                                model.RealName = realName;
                                model.IdNo = idCardNo;
                                model.Cash = 1;
                                model.SmsCode = string.Empty;
                                model.Flag = 0;
                                model.IsDeleted = 0;
                                model.CreateDate = DateTime.Now;
                                bll.Add(model);
                            }
                            //else
                            //{
                            //    model.RealName = realName;
                            //    model.TelNo = telNo;
                            //    model.IdNo = idCardNo;
                            //    model.BankCardNo = bankCardNo;
                            //    bll.Update(model);
                            //}
                        }
                        #endregion
                    }
                    result = outputJson;
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
                #endregion

            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "获取用户自描述报告异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 发送银行手机验证码
        /// <summary>
        /// 发送银行手机验证码
        /// </summary>
        static public Object BankCardSmsCode(string realName, string idCardNo, string bankCardNo, string telNo, string sign, string orderNo, string timeUnix, string merchantsNo, string equipmentNo, int consultId, string sskdRequestParasJson, string orderSource = "")
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string result = string.Empty;
            try
            {
                ApplyStatusChange(consultId, 701, 700, string.Empty);

                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }

                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = long.Parse(timeUnix);
                header.orderNo = orderNo;
                header.sign = sign;
                header.equipmentNo = equipmentNo;
                header.merchantsNo = merchantsNo;
                header.orderType = "LOAN";
                header.orderSource = orderSource;
                req.header = header;
                var data = new
                {
                    realName = realName,
                    idCardNo = idCardNo,
                    bankCardNo = bankCardNo,
                    telNo = telNo,
                    consumeTime = GetConsumeTime(sskdRequestParas)

                };
                req.data = data;
                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/b/sbcc";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue); ;
                ILog.ApiInvokingLogAdd(consultId, apiUrl, requestDate, inputJson, outputJson);
                if (!string.IsNullOrEmpty(outputJson))
                {
                    result = outputJson;
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "获取用户自描述报告异常，请稍后再试", null);
            }
            return result;
        }

        #endregion end 发送银行手机验证码

        #region 验证银行手机短信
        /// <summary>
        /// 验证银行手机短信
        /// </summary>
        static public Object BankCardSmsCodeCheck(string code, string bankCardId, string sign, string orderNo, string timeUnix, string merchantsNo, string equipmentNo, int consultId, string sskdRequestParasJson, string orderSource = "")
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string result = string.Empty;
            try
            {
                ApplyStatusChange(consultId, 702, 701, string.Empty);

                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }

                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = long.Parse(timeUnix);
                header.sign = sign;
                header.orderNo = orderNo;
                header.equipmentNo = equipmentNo;
                header.merchantsNo = merchantsNo;
                header.orderType = "LOAN";
                header.orderSource = orderSource;
                req.header = header;

                var data = new
                {
                    code = code,
                    bankCardId = bankCardId,
                    consumeTime = GetConsumeTime(sskdRequestParas)
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/b/vbcc";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                ILog.ApiInvokingLogAdd(consultId, apiUrl, requestDate, inputJson, outputJson);

                #region 解析返回json
                int flag = 0;
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                        flag = UtilityHelper.TypeConverter.StrToInt(o["data"]["flag"].ToString());
                        if (flag == 1)
                        {
                            #region 修改银行卡
                            if (!string.IsNullOrEmpty(consultId.ToString()))
                            {
                                NL_BankBLL bll = new NL_BankBLL();
                                bll.Update(code, flag, consultId, bankCardId);
                            }
                            #endregion
                        }
                    }
                    result = outputJson;
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
                #endregion

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "获取用户自描述报告异常，请稍后再试", null);
            }
            return result;
        }

        #endregion end 验证银行手机短信

        #region 立即申请
        /// <summary>
        /// 立即申请
        /// </summary>
        static public Object InsertConsult(string Consult, string equipmentNo, string merchantsNo, string base64Code, string sskdRequestParasJson)
        {
            string outputJson = string.Empty;
            string resultJson = string.Empty;
            try
            {
                NL_ConsultExT postConsult = JsonConvert.DeserializeObject<NL_ConsultExT>(Consult);
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }
                if (postConsult != null)
                {
                    #region 网贷申请
                    NL_ConsultBLL opConsultBLL = new NL_ConsultBLL();
                    NL_ConsultExT modelConsult = new NL_ConsultExT();
                    modelConsult.FullName = postConsult.FullName;
                    modelConsult.Mobile = postConsult.Mobile;
                    modelConsult.IDNo = postConsult.IDNo;
                    modelConsult.LoanAmount = postConsult.LoanAmount;
                    modelConsult.LoanTerm = postConsult.LoanTerm;
                    modelConsult.LoanUse = postConsult.LoanUse;
                    modelConsult.CreateDate = DateTime.Now;
                    modelConsult.OrderNo = CommonHelper.OrderNoFour();//订单号生成

                    modelConsult.magId = postConsult.magId;
                    modelConsult.sex = postConsult.sex;
                    modelConsult.birth = postConsult.birth;
                    modelConsult.national = postConsult.national;
                    modelConsult.address = postConsult.address;
                    modelConsult.authority = postConsult.authority;
                    modelConsult.validperiod = postConsult.validperiod;
                    modelConsult.faceId = postConsult.faceId;
                    modelConsult.Status = 1;

                    int consultId = opConsultBLL.Add(modelConsult);
                    if (consultId > 0)
                    {
                        ApplyStatusChange(consultId, 1, -1, string.Empty);

                        long timestamp = DNTRequest.GetCurrentTimeUnix;
                        string sign = GetSign(modelConsult.IDNo, modelConsult.Mobile, int.Parse(modelConsult.magId));
                        string orderNo = modelConsult.OrderNo;

                        #region 上传身份证图片

                        if (!string.IsNullOrEmpty(base64Code))
                        {
                            base64Code = base64Code.Replace(" ", "+");
                        }

                        byte[] photoData = new byte[0];
                        string msg = string.Empty;
                        string fileName = string.Empty;
                        string _contentType = "application/x-jpg";
                        photoData = DNTRequest.Base64StringToByte(base64Code, ref msg, ref fileName);
                        if (!string.IsNullOrEmpty(msg))
                        {
                            return DNTRequest.GetResultJsonForApi(false, "身份证图片上传失败，" + msg, null);
                        }
                        string faceId = ImagesUploadForConsult(base64Code, photoData, sign, orderNo, equipmentNo, merchantsNo, consultId, fileName, _contentType, sskdRequestParasJson, timestamp, ref msg);
                        #endregion

                        if (!string.IsNullOrEmpty(faceId))
                        {
                            string longitude = string.Empty;
                            string latitude = string.Empty;
                            string gpsAddress = string.Empty;
                            GetCurrentLocationInfo(ref msg, ref longitude, ref latitude, ref gpsAddress);

                            #region 立即申请
                            newxbwn_Request req = new newxbwn_Request();
                            header header = new header();
                            header.target = "pcrk";
                            header.key = "myjm";
                            header.version = "V1";
                            header.requestType = 1;
                            header.timestamp = timestamp;
                            header.orderNo = orderNo;
                            header.sign = sign;
                            header.equipmentNo = equipmentNo;
                            header.merchantsNo = merchantsNo;
                            header.orderType = "LOAN";
                            header.orderSource = "BWPC";
                            req.header = header;
                            var data = new
                            {
                                cash = modelConsult.LoanAmount,//贷款金额
                                timelimit = modelConsult.LoanTerm,//借款期限
                                @using = modelConsult.LoanUse,//贷款用途
                                telNo = modelConsult.Mobile,//借款人手机号
                                realName = modelConsult.FullName,//身份证姓名
                                idCardNo = modelConsult.IDNo,//身份证号
                                sex = modelConsult.sex,//性别
                                birth = modelConsult.birth,//出生年月
                                national = modelConsult.national,//民族
                                address = modelConsult.address,//住址
                                authority = modelConsult.authority,//签发机关
                                validperiod = modelConsult.validperiod,//有效期
                                faceId = faceId,//人像图片ID
                                consumeTime = GetConsumeTime(sskdRequestParas),
                                longitude = longitude,
                                latitude = latitude,
                                gpsAddress = gpsAddress
                            };
                            req.data = data;

                            string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                            DateTime requestDate = DateTime.Now;
                            string apiUrl = xinboweinuoApi + "/iservice/s/m/so";
                            outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                            ILog.ApiInvokingLogAdd(consultId, apiUrl, requestDate, inputJson, outputJson);
                            bool success = false;
                            string message = string.Empty;
                            string token = string.Empty;
                            if (!string.IsNullOrEmpty(outputJson))
                            {
                                JObject o = JObject.Parse(outputJson);
                                success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                                message = UtilityHelper.TypeConverter.SafeToString(o["message"]);
                                if (success)
                                {
                                    token = UtilityHelper.TypeConverter.SafeToString(o["data"]["token"]);
                                    if (!string.IsNullOrEmpty(token))
                                    {
                                        #region token写入数据库
                                        NL_ConsultBLL bll = new NL_ConsultBLL();
                                        NL_Consult model = new NL_Consult();
                                        model = bll.GetModel(consultId);
                                        if (model != null)
                                        {
                                            model.Token = token;
                                            bll.Update(model);
                                        }
                                        #endregion
                                    }
                                    var dataresult = new
                                    {
                                        ConsultId = consultId,
                                        OrderNo = modelConsult.OrderNo,
                                        Mobile = modelConsult.Mobile,
                                        IDNo = modelConsult.IDNo,               //身份证号
                                        FullName = modelConsult.FullName,             // 身份证姓名
                                        Sex = modelConsult.sex,                      //性别
                                        Birth = modelConsult.birth,                  //出生年月
                                        National = modelConsult.national,            //民族
                                        Address = modelConsult.address,              //住址
                                        Authority = modelConsult.authority,          //签发机关
                                        Validperiod = modelConsult.validperiod,       //有效期
                                        Token = token,
                                        TimeStamp = timestamp
                                    };

                                    resultJson = DNTRequest.GetResultJsonForApi(true, "申请成功", dataresult);
                                }
                                else
                                {
                                    resultJson = DNTRequest.GetResultJsonForApi(false, "接口返回消息，" + message, null);
                                }
                            }
                            else
                            {
                                resultJson = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                            }
                            #endregion
                        }
                        else
                        {
                            resultJson = DNTRequest.GetResultJsonForApi(false, msg, null);
                        }
                    }
                    else
                    {
                        resultJson = DNTRequest.GetResultJsonForApi(false, "申请入库失败，请稍后再试", null);
                    }
                    #endregion 
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                resultJson = DNTRequest.GetResultJsonForApi(false, "申请异常，请稍后再试", null);
            }
            return resultJson;
        }
        #endregion

        #region 填写信息
        /// <summary>
        /// 用户订单接收接口
        /// </summary>
        static public Object FillInTheInformation(string sskdRequestParasJson, string array, string orderSource = "")
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string outputJson = string.Empty;
            string resultJson = string.Empty;
            int b = 0;
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                    sskdRequestParas.Target = "pcrk";
                    sskdRequestParas.Key = "myjm";
                    sskdRequestParas.Version = "V1";
                    sskdRequestParas.RequestType = 1;
                    sskdRequestParas.OrderType = "LOAN";
                    sskdRequestParas.OrderSource = orderSource;
                }
                ApplyStatusChange(sskdRequestParas.ConsultId, 100, 1, string.Empty);

                #region 申请主表操作
                NL_ConsultBLL bllConsult = new NL_ConsultBLL();
                NL_Consult modelConsult = bllConsult.GetModel(sskdRequestParas.ConsultId);
                if (modelConsult != null)
                {
                    modelConsult.ConsultId = sskdRequestParas.ConsultId;
                    modelConsult.ProvinceId = sskdRequestParas.ProvinceId;
                    modelConsult.CityId = sskdRequestParas.CityId;
                    modelConsult.DistrictId = sskdRequestParas.DistrictId;
                    modelConsult.Address = sskdRequestParas.Address;
                    modelConsult.Email = sskdRequestParas.Email;
                    bool res01 = bllConsult.Update(modelConsult);
                }
                #endregion

                #region 职业信息
                NL_ProfessionInfoBLL bllProfessionInfo = new NL_ProfessionInfoBLL();
                NL_ProfessionInfo modelProfessionInfo = bllProfessionInfo.GetModel(sskdRequestParas.ConsultId);
                if (modelProfessionInfo == null)
                {
                    modelProfessionInfo = new NL_ProfessionInfo();
                    modelProfessionInfo.ConsultId = sskdRequestParas.ConsultId;
                    modelProfessionInfo.Company = sskdRequestParas.CompanyName;
                    bllProfessionInfo.Add(modelProfessionInfo);
                }
                else
                {
                    modelProfessionInfo.ConsultId = sskdRequestParas.ConsultId;
                    modelProfessionInfo.Company = sskdRequestParas.Email;
                    bllProfessionInfo.Update(modelProfessionInfo);
                }
                #endregion

                #region 联系人信息表操作

                NL_ContactsBLL bllContacts = new NL_ContactsBLL();
                bllContacts.DeleteList(sskdRequestParas.ConsultId.ToString());

                int res05 = 0;
                List<Hashtable> contactList = new List<Hashtable>();
                List<NL_Contacts> listContacts = JsonConvert.DeserializeObject<List<NL_Contacts>>(array);
                for (int i = 0; i < listContacts.Count; i++)
                {
                    NL_Contacts modelContacts = new NL_Contacts();
                    modelContacts.ConsultId = sskdRequestParas.ConsultId;
                    modelContacts.FullName = listContacts[i].FullName;
                    modelContacts.Mobile = listContacts[i].Mobile;
                    modelContacts.RelationId = listContacts[i].RelationId;
                    modelContacts.Depth = i.ToInt();
                    modelContacts.IsDeleted = 0;
                    modelContacts.CreateDate = DateTime.Now;
                    modelContacts.CreateId = ((ComPage.CurrentUser == null) ? (-1) : (ComPage.CurrentUser.UserID));
                    res05 += bllContacts.Add(modelContacts);

                    Hashtable ht = new Hashtable();
                    ht.Add("contactName", modelContacts.FullName);
                    ht.Add("contactTel", modelContacts.Mobile);
                    ht.Add("contactRelation", modelContacts.RelationId);
                    contactList.Add(ht);
                }

                #endregion


                #region 向信博维诺接口Post数据
                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = sskdRequestParas.Target;
                header.key = sskdRequestParas.Key;
                header.version = sskdRequestParas.Version;
                header.requestType = sskdRequestParas.RequestType;
                header.timestamp = sskdRequestParas.Timestamp;
                header.orderNo = sskdRequestParas.OrderNo;
                header.sign = sskdRequestParas.Sign;
                header.equipmentNo = sskdRequestParas.EquipmentNo;
                header.merchantsNo = sskdRequestParas.MerchantsNo;
                header.orderType = sskdRequestParas.OrderType;
                header.orderSource = sskdRequestParas.OrderSource;
                req.header = header;

                #region 省市区
                string cityjson = "";
                CityAreaBLL cabll = new CityAreaBLL();
                string ProvinceName = cabll.GetCityAreaName(sskdRequestParas.ProvinceId.ToInt());
                string CityName = cabll.GetCityAreaName(sskdRequestParas.CityId.ToInt());
                string DistrictName = cabll.GetCityAreaName(sskdRequestParas.DistrictId.ToInt());

                var objCity = new
                {
                    ProvinceId = sskdRequestParas.ProvinceId,
                    ProvinceName = ProvinceName,
                    CityId = sskdRequestParas.CityId,
                    CityName = CityName,
                    DistrictId = sskdRequestParas.DistrictId,
                    DistrictName = DistrictName,
                    Address = sskdRequestParas.Address
                };
                cityjson = Newtonsoft.Json.JsonConvert.SerializeObject(objCity);
                #endregion

                string cl = Newtonsoft.Json.JsonConvert.SerializeObject(contactList);

                var data = new
                {
                    city = cityjson,
                    monthMoney = 0,      //月收入
                    professional = 0,                               //职业身份
                    worktime = string.Empty,          //当前工作单位工作时间
                    isnoFund = string.Empty,                 //是否有公积金
                    wageform = string.Empty,              //工资发放形式
                    recordSchool = string.Empty,           //学历
                    isnoCar = string.Empty,                     //名下是否有车
                    isnoHouse = string.Empty,                 //名下是否有房
                    isnoLoan = string.Empty,              //是否做过其他贷款
                    isnoZfbpoints = string.Empty,         //是否有支付宝芝麻分
                    isnoTaobaoNo = string.Empty,       //是否有淘宝账号
                    isnoBusiness = string.Empty,      //是否有商业保单
                    isnoCreditcard = string.Empty,        //是否有信用卡
                    creditSituation = string.Empty,  //信用情况
                    credityear = string.Empty,  //信用卡使用年限                                                                        
                    emergencyContact = cl,                           //紧急联系人
                    consumeTime = GetConsumeTime(sskdRequestParas)
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/m/smd";
                outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, sskdRequestParas.Token);
                ILog.ApiInvokingLogAdd(sskdRequestParas.ConsultId, apiUrl, requestDate, inputJson, outputJson);
                bool success = false;
                string message = string.Empty;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    message = UtilityHelper.TypeConverter.SafeToString(o["message"]);
                    if (success)
                    {
                        resultJson = outputJson;
                    }
                    else
                    {
                        resultJson = DNTRequest.GetResultJsonForApi(false, "接口返回消息，" + message, null);
                    }
                }
                else
                {
                    resultJson = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }

                #endregion
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                resultJson = DNTRequest.GetResultJsonForApi(false, "信息提交异常，请稍后再试", null);
            }
            return resultJson;
        }

        #endregion

        #region Pad立即申请
        /// <summary>
        ///Pad立即申请
        /// </summary>
        static public Object InsertPadConsult(string Consult, string equipmentNo, string merchantsNo)
        {
            string outputJson = string.Empty;
            string resultJson = string.Empty;

            try
            {
                NL_ConsultExT postConsult = JsonConvert.DeserializeObject<NL_ConsultExT>(Consult);
                if (postConsult != null)
                {
                    #region 网贷申请
                    NL_ConsultBLL opConsultBLL = new NL_ConsultBLL();
                    NL_ConsultExT modelConsult = new NL_ConsultExT();
                    modelConsult.FullName = postConsult.FullName;
                    modelConsult.Mobile = postConsult.Mobile;
                    modelConsult.IDNo = postConsult.IDNo;
                    modelConsult.LoanAmount = postConsult.LoanAmount;
                    modelConsult.LoanTerm = postConsult.LoanTerm;
                    modelConsult.LoanUse = postConsult.LoanUse;
                    modelConsult.CreateDate = DateTime.Now;
                    modelConsult.magId = postConsult.magId;
                    modelConsult.OrderNo = CommonHelper.OrderNoFour();//订单号生成

                    int consultId = opConsultBLL.Add(modelConsult);
                    if (consultId > 0)
                    {

                        string sign = GetSign(modelConsult.IDNo, modelConsult.Mobile, int.Parse(modelConsult.magId));
                        string orderNo = modelConsult.OrderNo;

                        #region 立即申请
                        string longitude = string.Empty;
                        string latitude = string.Empty;
                        string gpsAddress = string.Empty;
                        string msg = string.Empty;
                        GetCurrentLocationInfo(ref msg, ref longitude, ref latitude, ref gpsAddress);
                        long timestamp = DNTRequest.GetCurrentTimeUnix;
                        newxbwn_Request req = new newxbwn_Request();
                        header header = new header();
                        header.target = "pcrk";
                        header.key = "myjm";
                        header.version = "V1";
                        header.requestType = 1;
                        header.timestamp = DNTRequest.GetCurrentTimeUnix;
                        header.orderNo = orderNo;
                        header.sign = sign;
                        header.equipmentNo = equipmentNo;
                        header.merchantsNo = merchantsNo;
                        header.orderType = "LOAN";
                        header.orderSource = "BWPAD";
                        req.header = header;
                        var data = new
                        {
                            cash = modelConsult.LoanAmount,//贷款金额
                            timelimit = modelConsult.LoanTerm,//借款期限
                            @using = modelConsult.LoanUse,//贷款用途
                            telNo = modelConsult.Mobile,//借款人手机号
                            realName = modelConsult.FullName,//身份证姓名
                            idCardNo = modelConsult.IDNo,//身份证号
                            sex = "",//性别
                            birth = "",//出生年月
                            national = "",//民族
                            address = "",//住址
                            authority = "",//签发机关
                            validperiod = "",//有效期
                            faceId = "",//人像图片ID
                            longitude = longitude,
                            latitude = latitude,
                            gpsAddress = gpsAddress
                        };
                        req.data = data;
                        string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                        DateTime requestDate = DateTime.Now;
                        string apiUrl = xinboweinuoApi + "/iservice/s/m/so";
                        outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                        ILog.ApiInvokingLogAdd(consultId, apiUrl, requestDate, inputJson, outputJson);
                        bool success = false;
                        string message = string.Empty;
                        string token = string.Empty;
                        if (!string.IsNullOrEmpty(outputJson))
                        {
                            JObject o = JObject.Parse(outputJson);
                            success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                            message = UtilityHelper.TypeConverter.SafeToString(o["message"]);
                            if (success)
                            {
                                token = UtilityHelper.TypeConverter.SafeToString(o["data"]["token"]);
                                if (!string.IsNullOrEmpty(token))
                                {
                                    #region token写入数据库
                                    NL_ConsultBLL bll = new NL_ConsultBLL();
                                    NL_Consult model = new NL_Consult();
                                    model = bll.GetModel(consultId);
                                    if (model != null)
                                    {
                                        model.Token = token;
                                        bll.Update(model);
                                    }
                                    #endregion
                                }
                                var dataresult = new
                                {
                                    ConsultId = consultId,
                                    OrderNo = modelConsult.OrderNo,
                                    Mobile = modelConsult.Mobile,
                                    IDNo = modelConsult.IDNo,               //身份证号
                                    FullName = modelConsult.FullName,             // 身份证姓名
                                    Sex = "",                      //性别
                                    Birth = "",                  //出生年月
                                    National = "",            //民族
                                    Address = "",              //住址
                                    Authority = "",          //签发机关
                                    Validperiod = "",       //有效期
                                    TimeStamp = timestamp,
                                    Token = token,
                                    sign = sign
                                };

                                resultJson = DNTRequest.GetResultJsonForApi(true, "申请成功", dataresult);
                            }
                            else
                            {
                                resultJson = DNTRequest.GetResultJsonForApi(false, "接口返回消息，" + message, null);
                            }
                        }
                        else
                        {
                            resultJson = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                        }
                        #endregion
                    }
                    else
                    {
                        resultJson = DNTRequest.GetResultJsonForApi(false, "申请入库失败，请稍后再试", null);
                    }
                    #endregion 
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                resultJson = DNTRequest.GetResultJsonForApi(false, "申请异常，请稍后再试", null);
            }
            return resultJson;
        }
        #endregion

        #region   GetSign
        public static string GetSign(string idcard, string mobile, int magId)
        {
            string resultStr = string.Empty;
            if (string.IsNullOrEmpty(idcard) || string.IsNullOrEmpty(mobile))
            {
                resultStr = "error";
                return resultStr;
            }
            //int magId = MerchantFrontCookieBLL.GetMerchantFrontUserId();//商户号
            if (magId <= 0)
            {
                resultStr = "error";
                return resultStr;
            }
            MachineBLL machienbll = new MachineBLL();
            int MachineId = 0;//设备号
            try
            {
                MachineId = machienbll.GetModelByUserId(magId).MachineID;
            }
            catch (Exception ex)
            {
            }
            if (MachineId <= 0)
            {
                resultStr = "error";
                return resultStr;
            }
            if (string.IsNullOrEmpty(resultStr))
            {
                long TimeUnix = DNTRequest.GetCurrentTimeUnix;//时间戳
                string str = magId + "-" + MachineId + "-" + idcard + "-" + mobile + "-" + TimeUnix;//商户号+设备号+身份证号+手机号+时间戳，连接符为-
                return UtilityHelper.CommonHelper.MD5(str, false);
            }
            else
            {
                return resultStr;
            }
        }
        #endregion

        #region 用户报告
        /// <summary>
        /// 用户报告
        /// </summary>
        static public Object AppraisalReport(string ConsultId, string sign, string orderNo, string timeUnix, string reportType, string token, string merchantsNo, string equipmentNo, string bwjsApi, string sskdRequestParasJson, string orderSource = "")
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string result = string.Empty;
            try
            {
                ApplyStatusChange(UtilityHelper.TypeConverter.ObjectToInt(ConsultId), 400, 300, string.Empty);

                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    try
                    {
                        sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                    }
                    catch { }
                }

                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = ((sskdRequestParas == null) ? (long.Parse(timeUnix)) : (sskdRequestParas.Timestamp));
                header.orderNo = orderNo;
                header.sign = sign;
                header.equipmentNo = equipmentNo;
                header.merchantsNo = merchantsNo;
                header.orderType = "LOAN";
                header.orderSource = orderSource;
                req.header = header;

                var data = new
                {
                    reportType = reportType,
                    consumeTime = GetConsumeTime(sskdRequestParas)
                };
                req.data = data;
                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                DateTime requestDate = DateTime.Now;
                string apiUrl = newxinboweinuoApi + "/iservice/rt/ot/ur";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                ILog.ApiInvokingLogAdd(UtilityHelper.TypeConverter.ObjectToInt(ConsultId), apiUrl, requestDate, inputJson, outputJson);

                #region 解析返回json
                bool success = false;
                string code = string.Empty;
                string message = string.Empty;
                bool mark = false;
                long timestamp = 0;
                string json = string.Empty;
                string html = string.Empty;
                string progress = string.Empty;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    code = UtilityHelper.TypeConverter.SafeToString(o["code"]);
                    message = UtilityHelper.TypeConverter.SafeToString(o["message"]);
                    mark = UtilityHelper.TypeConverter.StrToBool(o["mark"].ToString(), false);
                    timestamp = Convert.ToInt64(o["timestamp"].ToString());
                    json = UtilityHelper.TypeConverter.SafeToString(o["data"]["json"]);
                    html = UtilityHelper.TypeConverter.SafeToString(o["data"]["html"]);
                    progress = UtilityHelper.TypeConverter.SafeToString(o["data"]["progress"]);
                    if (success)
                    {
                        #region 本地生成html文件
                        if (!string.IsNullOrEmpty(html))
                        {
                            //html = result.Replace("\\r\\n", "");
                            //html = result.Replace("\\t", "");
                            ////html = result.Replace("\"", "'");
                            //html = Newtonsoft.Json.JsonConvert.DeserializeObject(html).ToString();
                            string msg = string.Empty;
                            string fileName = string.Empty;
                            string filePath = string.Empty;
                            Log.WriteToHtml(html, false, ref msg, ref fileName, ref filePath);
                            if (!string.IsNullOrEmpty(filePath))
                            {
                                html = bwjsApi + filePath;
                            }
                        }
                        var newjsonobj = new
                        {
                            success = success,
                            code = code,
                            message = message,
                            mark = mark,
                            timestamp = timestamp,
                            data = new
                            {
                                json = json,
                                html = html,
                                progress = progress
                            }
                        };
                        result = Newtonsoft.Json.JsonConvert.SerializeObject(newjsonobj);
                        ILog.ApiInvokingLogAdd(UtilityHelper.TypeConverter.ObjectToInt(ConsultId), bwjsApi, requestDate, inputJson, result);
                        #endregion

                        //result = outputJson;
                    }
                    else
                    {
                        result = DNTRequest.GetResultJsonForApi(false, "接口返回消息，" + message, null);
                    }
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
                #endregion
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "获取用户报告异常，请稍后再试", null);
            }
            return result;
        }

        #endregion end 用户自描述报告

        #region 用户详细信息接口
        /// <summary>
        /// 用户订单接收接口
        /// </summary>
        static public Object UpdataConsult(string ConsultId, string ProvinceId, string CityId, string DistrictId, string Area, string Address, string ProfessionInfo, string IdentityInfo, string AssetInfo, string sign, string orderNo, string array, string equipmentNo, string merchantsNo, string orderSource, string sskdRequestParasJson)
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string outputJson = string.Empty;
            string resultJson = string.Empty;
            int b = 0;
            try
            {
                #region 申请主表操作
                NL_ConsultBLL bllConsult = new NL_ConsultBLL();
                NL_Consult modelConsult = bllConsult.GetModel(ConsultId.ToInt());
                if (modelConsult != null)
                {
                    modelConsult.ConsultId = ConsultId.ToInt();
                    modelConsult.ProvinceId = ProvinceId.ToInt();
                    modelConsult.CityId = CityId.ToInt();
                    modelConsult.DistrictId = DistrictId.ToInt();
                    modelConsult.Area = Area;
                    modelConsult.Address = Address;
                    bool res01 = bllConsult.Update(modelConsult);
                }
                #endregion

                #region 身份信息表操作
                NL_IdentityInfoBLL bllIdentityInfo = new NL_IdentityInfoBLL();
                NL_IdentityInfo dbIdentityInfo = bllIdentityInfo.GetModel(ComPage.SafeToInt(ConsultId));
                NL_IdentityInfo modelIdentityInfo = JsonConvert.DeserializeObject<NL_IdentityInfo>(IdentityInfo);
                int res02 = 0;
                if (dbIdentityInfo == null)
                {
                    res02 = bllIdentityInfo.Add(modelIdentityInfo);
                }
                else
                {
                    bllIdentityInfo.Update(modelIdentityInfo);
                }
                #endregion

                #region 职业信息表操作
                NL_ProfessionInfoBLL bllProfessionInfo = new NL_ProfessionInfoBLL();
                NL_ProfessionInfo dbProfessionInfo = bllProfessionInfo.GetModel(ComPage.SafeToInt(ConsultId));
                NL_ProfessionInfo modelProfessionInfo = JsonConvert.DeserializeObject<NL_ProfessionInfo>(ProfessionInfo);
                int res03 = 0;
                if (dbProfessionInfo == null)
                {
                    res03 = bllProfessionInfo.Add(modelProfessionInfo);
                }
                else
                {
                    bllProfessionInfo.Update(modelProfessionInfo);
                }
                #endregion

                #region 资产信息表操作
                NL_AssetInfoBLL bllAssetInfo = new NL_AssetInfoBLL();
                NL_AssetInfo dbAssetInfo = bllAssetInfo.GetModel(ComPage.SafeToInt(ConsultId));
                NL_AssetInfo modelAssetInfo = JsonConvert.DeserializeObject<NL_AssetInfo>(AssetInfo);
                int res04 = 0;
                if (dbAssetInfo == null)
                {
                    res04 = bllAssetInfo.Add(modelAssetInfo);
                }
                else
                {
                    bllAssetInfo.Update(modelAssetInfo);
                }
                #endregion

                #region 联系人信息表操作

                NL_ContactsBLL bllContacts = new NL_ContactsBLL();
                bllContacts.DeleteList(ConsultId);

                int res05 = 0;
                //string jsonText = JsonConvert.SerializeObject(array);
                List<NL_Contacts> listContacts = JsonConvert.DeserializeObject<List<NL_Contacts>>(array);
                for (int i = 0; i < listContacts.Count; i++)
                {
                    NL_Contacts modelContacts = new NL_Contacts();
                    modelContacts.ConsultId = modelAssetInfo.ConsultId;
                    modelContacts.FullName = listContacts[i].FullName;
                    modelContacts.Mobile = listContacts[i].Mobile;
                    modelContacts.RelationId = listContacts[i].RelationId;
                    modelContacts.Depth = i.ToInt();
                    modelContacts.IsDeleted = 0;
                    modelContacts.CreateDate = DateTime.Now;
                    modelContacts.CreateId = ((ComPage.CurrentUser == null) ? (-1) : (ComPage.CurrentUser.UserID));
                    res05 += bllContacts.Add(modelContacts);
                }

                #endregion

                ApplyStatusChange(UtilityHelper.TypeConverter.ObjectToInt(ConsultId), 100, 1, string.Empty);

                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }

                #region 向信博维诺接口Post数据
                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                header.orderNo = orderNo;
                header.sign = sign;
                header.equipmentNo = equipmentNo;
                header.merchantsNo = merchantsNo;
                header.orderType = "LOAN";
                header.orderSource = orderSource;
                req.header = header;

                #region 省市区
                string cityjson = "";
                CityAreaBLL cabll = new CityAreaBLL();
                string ProvinceName = cabll.GetCityAreaName(ProvinceId.ToInt());
                string CityName = cabll.GetCityAreaName(CityId.ToInt());
                string DistrictName = cabll.GetCityAreaName(DistrictId.ToInt());

                var objCity = new
                {
                    ProvinceId = ProvinceId,
                    ProvinceName = ProvinceName,
                    CityId = CityId,
                    CityName = CityName,
                    DistrictId = DistrictId,
                    DistrictName = DistrictName,
                    Address = Address
                };
                cityjson = Newtonsoft.Json.JsonConvert.SerializeObject(objCity);
                #endregion

                var data = new
                {
                    city = cityjson,
                    monthMoney = modelIdentityInfo.MonthlyIncome,      //月收入
                    professional = 0,                               //职业身份
                    worktime = modelIdentityInfo.WorkingHour,          //当前工作单位工作时间
                    isnoFund = modelIdentityInfo.Fund,                 //是否有公积金
                    wageform = modelIdentityInfo.Payroll,              //工资发放形式
                    recordSchool = modelIdentityInfo.Degree,           //学历
                    isnoCar = modelAssetInfo.Cars,                     //名下是否有车
                    isnoHouse = modelAssetInfo.Houses,                 //名下是否有房
                    isnoLoan = modelAssetInfo.OtherLoans,              //是否做过其他贷款
                    isnoZfbpoints = modelAssetInfo.SesameSeed,         //是否有支付宝芝麻分
                    isnoTaobaoNo = modelAssetInfo.TaobaoAccount,       //是否有淘宝账号
                    isnoBusiness = modelAssetInfo.BusinessPolicy,      //是否有商业保单
                    isnoCreditcard = modelAssetInfo.CreditCard,        //是否有信用卡
                    creditSituation = modelAssetInfo.CreditSituation,  //信用情况
                    credityear = modelAssetInfo.CreditCardServiceLife,  //信用卡使用年限
                                                                        //紧急联系人
                    emergencyContact = array,
                    consumeTime = GetConsumeTime(sskdRequestParas)
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/m/smd";
                outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                ILog.ApiInvokingLogAdd(UtilityHelper.TypeConverter.ObjectToInt(ConsultId), apiUrl, requestDate, inputJson, outputJson);
                bool success = false;
                string message = string.Empty;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    message = UtilityHelper.TypeConverter.SafeToString(o["message"]);
                    if (success)
                    {
                        resultJson = outputJson;
                    }
                    else
                    {
                        resultJson = DNTRequest.GetResultJsonForApi(false, "接口返回消息，" + message, null);
                    }
                }
                else
                {
                    resultJson = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }

                #endregion
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                resultJson = DNTRequest.GetResultJsonForApi(false, "信息提交异常，请稍后再试", null);
            }
            return resultJson;
        }

        #endregion

        #region 获取借款参数
        /// <summary>
        /// 获取借款参数
        /// </summary>
        static public Object GetLoanParas(string orderNo, string sign, int ConsultId, string timeUnix, string token, string equipmentNo, string merchantsNo, string sskdRequestParasJson, string orderSource = "")
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string result = string.Empty;
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }

                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                header.orderNo = orderNo;
                header.sign = sign;
                header.equipmentNo = equipmentNo;
                header.merchantsNo = merchantsNo;
                header.orderType = "LOAN";
                header.orderSource = orderSource;
                req.header = header;

                var data = new
                {
                    consumeTime = GetConsumeTime(sskdRequestParas)
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/l/lp";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                ILog.ApiInvokingLogAdd(ConsultId, apiUrl, requestDate, inputJson, outputJson);
                if (!string.IsNullOrEmpty(outputJson))
                {
                    result = outputJson;
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "获取借款参数异常，请稍后再试", null);
            }
            return result;
        }

        #endregion end 获取借款参数

        #region  借款分期计算
        /// <summary>
        /// 借款分期计算
        /// </summary>
        static public Object StagingCalculation(string orderNo, string sign, int ConsultId, string timeUnix, string productId, string lAmount, string token, string equipmentNo, string merchantsNo, string sskdRequestParasJson, string orderSource = "")
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string result = string.Empty;
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }

                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                header.orderNo = orderNo;
                header.sign = sign;
                header.equipmentNo = equipmentNo;
                header.merchantsNo = merchantsNo;
                header.orderType = "LOAN";
                header.orderSource = orderSource;

                req.header = header;

                var data = new
                {
                    productId = long.Parse(productId),
                    loanAmount = double.Parse(lAmount),
                    consumeTime = GetConsumeTime(sskdRequestParas)
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/l/sb";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                ILog.ApiInvokingLogAdd(ConsultId, apiUrl, requestDate, inputJson, outputJson);

                #region 解析返回json
                decimal loanAmount = 0m;
                int loanTimes = 0;
                decimal loanInterest = 0m;
                decimal loanFinallyAmount = 0m;

                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                        loanAmount = UtilityHelper.TypeConverter.SafeToDecimal(o["data"]["loanAmount"].ToString());
                        loanTimes = UtilityHelper.TypeConverter.StrToInt(o["data"]["periods"].ToString());
                        loanInterest = UtilityHelper.TypeConverter.SafeToDecimal(o["data"]["allInterest"].ToString());
                        loanFinallyAmount = UtilityHelper.TypeConverter.SafeToDecimal(o["data"]["allReturnAmount"].ToString());

                        #region 写入我方贷款信息表
                        NL_LoanBLL loanbll = new NL_LoanBLL();
                        NL_Loan model = loanbll.GetModelByConsultId(ConsultId);
                        if (model != null)
                        {
                            model.LoanAmount = loanAmount;
                            model.LoanDays = loanTimes;
                            model.InterestValue = loanInterest.ToString();
                            model.LoanInfo = outputJson;
                            model.ReturnAmount = loanFinallyAmount;
                            bool res = loanbll.Update(model);
                        }
                        else
                        {
                            model = new NL_Loan();
                            model.LoanAmount = loanAmount;
                            model.LoanDays = loanTimes;
                            model.InterestValue = loanInterest.ToString();
                            model.LoanInfo = outputJson;
                            model.ReturnAmount = loanFinallyAmount;
                            model.ConsultId = ConsultId;
                            int res = loanbll.Add(model);
                        }
                        #endregion
                    }
                    result = outputJson;
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
                #endregion
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "借款分期计算异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 借款申请
        /// <summary>
        /// 借款申请
        /// </summary>
        static public Object LoanApplication(string orderNo, string sign, int ConsultId, string bankCardNo, string productId, string loanAmount, string timeUnix, string token, string equipmentNo, string merchantsNo, string sskdRequestParasJson, string orderSource = "")
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string result = string.Empty;
            try
            {
                ApplyStatusChange(ConsultId, 500, 700, string.Empty);

                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }

                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                header.orderNo = orderNo;
                header.sign = sign;
                header.equipmentNo = equipmentNo;
                header.merchantsNo = merchantsNo;
                header.orderType = "LOAN";
                header.orderSource = orderSource;
                req.header = header;

                var data = new
                {
                    bankCardNo = bankCardNo,
                    productId = long.Parse(productId),
                    loanAmount = double.Parse(loanAmount),
                    consumeTime = GetConsumeTime(sskdRequestParas)
                };
                req.data = data;
                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/l/ab";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                ILog.ApiInvokingLogAdd(ConsultId, apiUrl, requestDate, inputJson, outputJson);
                if (!string.IsNullOrEmpty(outputJson))
                {
                    result = outputJson;
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "借款申请异常，请稍后再试", null);
            }
            return result;
        }
        #endregion

        #region 商户授权放款
        /// <summary>
        /// 商户授权放款
        /// </summary>
        static public Object ConfirmationOfAuthorization(string timeUnix, string orderNo, string sign, string token, string equipmentNo, string merchantsNo, string merchantsIdCardNo, string merchantsAcount, string merchantsMobile, string merchantsName, int ConsultId, string sskdRequestParasJson, string creditLine, string borrowNo, string orderSource = "")
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string result = string.Empty;
            try
            {
                ApplyStatusChange(ConsultId, 600, 500, string.Empty);

                SSKDRequestParas sskdRequestParas = null;
                //if (!string.IsNullOrEmpty(sskdRequestParasJson))
                //{
                //    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                //}

                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                header.orderNo = orderNo;
                header.sign = sign;
                header.equipmentNo = equipmentNo;
                header.merchantsNo = merchantsNo;
                header.orderType = "LOAN";
                header.orderSource = orderSource;
                req.header = header;

                var data = new
                {
                    merchantsAcount = merchantsAcount,                 //商户账号
                    merchantsName = merchantsName,                     //商户姓名
                    merchantsMobile = merchantsMobile,                 //商户手机号
                    merchantsIdCardNo = merchantsIdCardNo,             //商户身份证号
                    borrowNo = borrowNo,//借款单号
                    amount = creditLine
                    //consumeTime = GetConsumeTime(sskdRequestParas)
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/l/sl";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                ILog.ApiInvokingLogAdd(ConsultId, apiUrl, requestDate, inputJson, outputJson);
                if (!string.IsNullOrEmpty(outputJson))
                {
                    result = outputJson;
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "商户授权放款异常，请稍后再试", null);
            }
            return result;
        }

        #endregion

        #region 授权验证
        /// <summary>
        /// 授权验证
        /// </summary>
        static public Object Checkmcs(string ConsultId, string sign, string realName, string idNo, string returnUrl, string orderNo, string telNo, string typeId, string equipmentNo, string merchantsNo, string sskdRequestParasJson, string orderSource = "")
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string result = string.Empty;
            string outputJson = string.Empty;
            int b = 0;
            try
            {
                ApplyStatusChange(UtilityHelper.TypeConverter.ObjectToInt(ConsultId), 300, 200, string.Empty);

                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }

                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                header.orderNo = orderNo;
                header.sign = sign;
                header.equipmentNo = equipmentNo;
                header.merchantsNo = merchantsNo;
                header.orderType = "LOAN";
                header.orderSource = orderSource;
                req.header = header;
                var data = new
                {
                    telNo = telNo,  //	手机号
                    realName = realName,    //	姓名
                    idNo = idNo,    //	身份证号
                    returnUrl = returnUrl,   //	同步回调地址
                    bankcardType = "ibank_crawl",
                    consumeTime = GetConsumeTime(sskdRequestParas)
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                DateTime requestDate = DateTime.Now;
                string apiUrl = newxinboweinuoApi + "/iservice/rt/it/" + typeId;
                outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                ILog.ApiInvokingLogAdd(UtilityHelper.TypeConverter.ObjectToInt(ConsultId), apiUrl, requestDate, inputJson, outputJson);
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                        NL_Consult modelConsult = new NL_Consult();
                        NL_ConsultBLL consultbll = new NL_ConsultBLL();
                        modelConsult = consultbll.GetModel(ConsultId.ToInt());
                        if (modelConsult != null)
                        {
                            modelConsult.MobileOperatorSuccess = true;
                            b = consultbll.Update(modelConsult).ToInt();
                        }
                        result = outputJson;
                    }
                    else
                    {
                        result = DNTRequest.GetResultJsonForApi(false, "验证失败，请稍后再试", null);
                    }
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "验证异常，请稍后再试", null);
            }
            return result;
        }

        #endregion 授权验证结束

        #region 获取自描述信息
        /// <summary>
        /// 根据三要素获取自描述信息
        /// </summary>
        static public Object GetaInformation(string idNo, string Mobile, string FullName, string sskdRequestParasJson)
        {
            string result = string.Empty;
            string resultStr = "";
            int ConsultId = 0;
            ArrayList list = new ArrayList();  // 声明变量
            NL_Consult consultml = new NL_Consult();
            NL_IdentityInfo identityInfoml = new NL_IdentityInfo();
            NL_ProfessionInfo professionInfoml = new NL_ProfessionInfo();
            NL_AssetInfo assetInfoml = new NL_AssetInfo();
            List<NL_Contacts> Contactsml = new List<NL_Contacts>();

            NL_ConsultBLL consultbll = new NL_ConsultBLL();
            NL_IdentityInfoBLL identityInfobll = new NL_IdentityInfoBLL();
            NL_ProfessionInfoBLL professionInfobll = new NL_ProfessionInfoBLL();
            NL_AssetInfoBLL assetInfobll = new NL_AssetInfoBLL();
            NL_ContactsBLL contactsbll = new NL_ContactsBLL();
            CityAreaBLL cabll = new CityAreaBLL();
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }

                DataSet ds = new DataSet();
                DataTable dt = null;
                ///查看三要素是否注册过
                ds = consultbll.GetConsultId("  mlc.IDNo = '" + idNo + "' AND mlc.FullName = '" + FullName + "' AND mlc.Mobile = '" + Mobile + "'   ");
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    ConsultId = ComPage.SafeToInt(dt.Rows[0][0]);
                    consultml = consultbll.GetModel(ConsultId);
                    if (consultml != null)
                    {
                        list.Add(consultml);
                    }
                    else
                    {
                        list.Add(new NL_Consult());
                    }
                    identityInfoml = identityInfobll.GetModel(ConsultId);
                    if (identityInfoml != null)
                    {
                        list.Add(identityInfoml);
                    }
                    else
                    {
                        list.Add(new NL_IdentityInfo());
                    }
                    professionInfoml = professionInfobll.GetModel(ConsultId);
                    if (professionInfoml != null)
                    {
                        list.Add(professionInfoml);
                    }
                    else
                    {
                        list.Add(new NL_ProfessionInfo());
                    }
                    assetInfoml = assetInfobll.GetModel(ConsultId);
                    if (assetInfoml != null)
                    {
                        list.Add(assetInfoml);
                    }
                    else
                    {
                        list.Add(new NL_AssetInfo());
                    }
                    Contactsml = contactsbll.GetModelList(string.Format("ConsultId={0}", ConsultId));
                    if (Contactsml != null)
                    {
                        list.Add(Contactsml);
                    }
                    else
                    {
                        list.Add(new NL_Contacts());
                    }

                    result = DNTRequest.GetResultJsonForApi(true, "获取自描述信息成功", null);
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "未获取到自描述信息", null);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "获取自描述信息异常，请稍后再试", resultStr);
            }
            return result;
        }
        #endregion

        #region 设备信息
        /// <summary>
        /// 设备信息
        /// </summary>
        static public Object EquipmentCapture(string sskdRequestParasJson)
        {
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }
                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = sskdRequestParas.Timestamp;
                header.orderNo = sskdRequestParas.OrderNo;
                header.sign = sskdRequestParas.Sign;
                header.merchantsNo = sskdRequestParas.MerchantsNo;
                header.equipmentNo = sskdRequestParas.EquipmentNo;
                header.orderType = sskdRequestParas.OrderType;
                header.orderSource = sskdRequestParas.OrderSource;
                req.header = header;

                var data = new
                {
                    imeiNo = sskdRequestParas.MachineInfo.ImeiNo,
                    type = sskdRequestParas.MachineInfo.Type,
                    machineNo = sskdRequestParas.MachineInfo.MachineNo,
                    mac = sskdRequestParas.MachineInfo.Mac,                  //mac地址
                    address = sskdRequestParas.MachineInfo.Address,          //设备所在地
                    status = sskdRequestParas.MachineInfo.Status,            //状态 1 - 正常；0 - 冻结
                    remark = sskdRequestParas.MachineInfo.Remark,            //备注
                    longitude = sskdRequestParas.MachineInfo.Longitude,      //经度
                    latitude = sskdRequestParas.MachineInfo.Latitude,        //维度                    
                    consumeTime = GetConsumeTime(sskdRequestParas)

                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/rt/it/sdi";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, sskdRequestParas.Token);

                XinboweinuoLogBLL.Add(sskdRequestParas.ConsultId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion

        #region 商户信息
        /// <summary>
        /// 商户信息
        /// </summary>
        static public Object MerchantCapture(string sskdRequestParasJson)
        {
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }
                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = sskdRequestParas.Timestamp;
                header.orderNo = sskdRequestParas.OrderNo;
                header.sign = sskdRequestParas.Sign;
                header.merchantsNo = sskdRequestParas.MerchantsNo;
                header.equipmentNo = sskdRequestParas.EquipmentNo;
                header.orderType = sskdRequestParas.OrderType;
                header.orderSource = sskdRequestParas.OrderSource;
                req.header = header;

                var data = new
                {
                    merchantNo = sskdRequestParas.MerchantInfo.MerchantNo,                //商户编号
                    loginName = sskdRequestParas.MerchantInfo.LoginName,                  //用户名
                    realName = sskdRequestParas.MerchantInfo.RealName,                    //姓名
                    sex = sskdRequestParas.MerchantInfo.Sex,                              //性别
                    phone = sskdRequestParas.MerchantInfo.Phone,                          //电话
                    qq = sskdRequestParas.MerchantInfo.QQ,                                //QQ
                    weChat = sskdRequestParas.MerchantInfo.WeChat,                        //微信号
                    email = sskdRequestParas.MerchantInfo.Email,                          //邮箱
                    headId = sskdRequestParas.MerchantInfo.HeadId,                        //头像ID
                    companyName = sskdRequestParas.MerchantInfo.CompanyName,              //商户名称
                    idCardNo = sskdRequestParas.MerchantInfo.IdCardNo,                    //身份证号
                    isLocked = sskdRequestParas.MerchantInfo.IsLocked,                    //锁定状态 0 - 正常；1 - 锁定
                    isLogined = sskdRequestParas.MerchantInfo.IsLogined,                  //登录状态 0 - 未登录；1 - 已登录
                    loginTimes = sskdRequestParas.MerchantInfo.LoginTimes,                //登录次数
                    province = sskdRequestParas.MerchantInfo.Province,                    //所在省
                    city = sskdRequestParas.MerchantInfo.City,                            //所在市
                    country = sskdRequestParas.MerchantInfo.Country,                      //所在区县
                    address = sskdRequestParas.MerchantInfo.Address,                      //详细地址
                    superMerchantNo = sskdRequestParas.MerchantInfo.SuperMerchantNo,      //上级商户编号,
                    consumeTime = GetConsumeTime(sskdRequestParas)

                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/rt/it/smi";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, sskdRequestParas.Token);

                XinboweinuoLogBLL.Add(sskdRequestParas.ConsultId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion

        #region 设备商户关联信息
        /// <summary>
        /// 设备商户关联信息
        /// </summary>
        static public Object EquipmentMerchantRelation(string sskdRequestParasJson)
        {
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }
                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = sskdRequestParas.Timestamp;
                header.orderNo = sskdRequestParas.OrderNo;
                header.sign = sskdRequestParas.Sign;
                header.merchantsNo = sskdRequestParas.MerchantsNo;
                header.equipmentNo = sskdRequestParas.EquipmentNo;
                header.orderType = sskdRequestParas.OrderType;
                header.orderSource = sskdRequestParas.OrderSource;
                req.header = header;

                var data = new
                {
                    merchantNo = sskdRequestParas.MerchantsNo,
                    machineNo = sskdRequestParas.EquipmentNo,
                    consumeTime = GetConsumeTime(sskdRequestParas)

                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/rt/it/sdmri";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, sskdRequestParas.Token);

                XinboweinuoLogBLL.Add(sskdRequestParas.ConsultId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion

        #region 认证进度查询
        /// <summary>
        /// 认证进度查询
        /// </summary>
        static public Object GetRzjd(string consultId, string orderNo, string merhcantNo, string equipmentNo, string sign, string sskdRequestParasJson, string orderSource = "")
        {
            if (orderSource == "")
            {
                orderSource = "BWPC";
            }
            string result = string.Empty;
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                //if (!string.IsNullOrEmpty(sskdRequestParasJson))
                //{
                //    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                //}

                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.sign = sign;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                header.orderNo = orderNo;
                header.merchantsNo = merhcantNo;
                header.equipmentNo = equipmentNo;
                header.orderType = "LOAN";
                header.orderSource = orderSource;

                req.header = header;

                var data = new
                {
                    //consumeTime = GetConsumeTime(sskdRequestParas)
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = newxinboweinuoApi + "/iservice/rt/ot/rzjd";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                ILog.ApiInvokingLogAdd(UtilityHelper.TypeConverter.ObjectToInt(consultId), apiUrl, requestDate, inputJson, outputJson);
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                        result = outputJson;
                    }
                    else
                    {
                        result = DNTRequest.GetResultJsonForApi(false, "认证进度查询失败，请稍后再试", null);
                    }
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "认证进度查询异常，请稍后再试", null);
            }

            return result;
        }

        #endregion

        #region 贷款状态变更
        /// <summary>
        /// 贷款状态变更
        /// </summary>
        static public Object ApplyStatusChange(int consultId, int status, int prevStatus, string sskdRequestParasJson)
        {
            string result = string.Empty;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    SSKDRequestParas postSSKDRequestParas = null;
                    if (!string.IsNullOrEmpty(sskdRequestParasJson))
                    {
                        postSSKDRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                    }
                    NL_ConsultBLL bllConsult = new NL_ConsultBLL();
                    bool res1 = bllConsult.Update(consultId, status);

                    NL_ConsultStatusChangeLogBLL bllConsultStatusChangeLog = new NL_ConsultStatusChangeLogBLL();
                    NL_ConsultStatusChangeLog modelConsultStatusChangeLog = new NL_ConsultStatusChangeLog();
                    modelConsultStatusChangeLog.ConsultId = consultId;
                    modelConsultStatusChangeLog.BusinessType = 1;
                    modelConsultStatusChangeLog.Status = status;
                    modelConsultStatusChangeLog.PrevStatus = prevStatus;
                    modelConsultStatusChangeLog.CreateDate = DateTime.Now;
                    int res2 = bllConsultStatusChangeLog.Add(modelConsultStatusChangeLog);

                    if (res1 == true && res2 > 0)
                    {
                        ts.Complete();
                        result = DNTRequest.GetResultJsonForApi(true, "success", null);
                    }
                    else
                    {
                        ts.Dispose();
                        result = DNTRequest.GetResultJsonForApi(false, "贷款状态变更失败", null);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                    result = DNTRequest.GetResultJsonForApi(false, "贷款状态变更异常，请稍后再试", null);
                }
            }
            return result;
        }

        #endregion

        #region 获取时效秒数
        /// <summary>
        /// 获取时效秒数
        /// </summary>
        static public int GetConsumeTime(SSKDRequestParas sskdRequestParas)
        {
            int consumeTime = 0;
            try
            {
                DateTime pageLoadDateTime = DateTime.Now;
                if (sskdRequestParas != null)
                {
                    pageLoadDateTime = Convert.ToDateTime(sskdRequestParas.PageLoadDateTime);
                }
                TimeSpan tsp = DateTime.Now - pageLoadDateTime;
                consumeTime = tsp.Seconds;
            }
            catch
            {
            }
            return consumeTime;
        }
        #endregion

        #region 前台ajax（log记录）
        /// <summary>
        /// 前台ajax（log记录）
        /// </summary>
        static public Object AjaxApiLog(string url, string paramStr)
        {
            string result = string.Empty;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    XBWNInterface.BLL.ILog.ApiInvokingLogAdd(0, url, DateTime.Now, paramStr, "", 0, 0);
                }
                catch (Exception ex)
                {
                    ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                    result = DNTRequest.GetResultJsonForApi(false, "log记录异常，请稍后再试", null);
                }
                ts.Complete();
            }
            return result;
        }

        #endregion

        #region 获取当前位置信息

        /// <summary>
        /// 获取当前位置信息
        /// </summary>
        static void GetCurrentLocationInfo(ref string msg, ref string longitude, ref string latitude, ref string locationAddress)
        {
            try
            {
                #region 设置位置信息
                string locationData = string.Empty;

                #region 获取当前位置信息
                string jsonText = MachineLocationLogBLL.GetLocationInfo();
                if (!string.IsNullOrEmpty(jsonText))
                {
                    JObject o = JObject.Parse(jsonText);
                    longitude = o["content"]["point"]["x"].ToString();
                    latitude = o["content"]["point"]["y"].ToString();
                }
                #endregion

                #region 逆地理位置解析
                string locationXml = string.Empty;
                if (!string.IsNullOrEmpty(longitude) && !string.IsNullOrEmpty(latitude))
                {
                    locationData = MachineLocationLogBLL.GetAddressByLocation(longitude, latitude, "xml", 0);
                    if (!string.IsNullOrEmpty(locationData))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(locationData);
                        //locationXml = doc.DocumentElement.InnerXml;
                        //settings.OmitXmlDeclaration = true;//这一句表示忽略xml声明
                        XmlNodeList locationNodeList = doc.SelectNodes("GeocoderSearchResponse/result");
                        if (locationNodeList != null)
                        {
                            foreach (XmlNode locationNode in locationNodeList)
                            {
                                XmlNode formatted_address = locationNode.SelectSingleNode("formatted_address");
                                if (formatted_address != null)
                                {
                                    locationAddress += formatted_address.InnerText;
                                }
                                XmlNode sematic_description = locationNode.SelectSingleNode("sematic_description");
                                if (sematic_description != null)
                                {
                                    locationAddress += sematic_description.InnerText;
                                }
                            }
                        }
                    }
                }
                #endregion

                #endregion

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                ExceptionLogBLL.WriteExceptionLogToDB("获取当前位置信息异常，" + ex.ToString());
            }
        }
        #endregion

        #region 订单认证进度
        /// <summary>
        /// 订单认证进度
        /// </summary>
        static public Object OrderAuthenticationProgressQuery(string sskdRequestParasJson, string telNo, string idCardNo)
        {
            string result = string.Empty;
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }

                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = sskdRequestParas.Timestamp;
                header.orderNo = sskdRequestParas.OrderNo;
                header.sign = sskdRequestParas.Sign;
                header.equipmentNo = sskdRequestParas.EquipmentNo;
                header.merchantsNo = sskdRequestParas.MerchantsNo;
                header.orderType = "LOAN";
                header.orderSource = sskdRequestParas.OrderSource;
                req.header = header;
                var data = new
                {
                    consumeTime = GetConsumeTime(sskdRequestParas),
                    telNo = telNo,
                    idCardNo = idCardNo
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/m/ap";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, sskdRequestParas.Token); ;
                ILog.ApiInvokingLogAdd(sskdRequestParas.ConsultId, apiUrl, requestDate, inputJson, outputJson);

                #region 解析返回json
                string bankCardId = string.Empty;
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                    }
                    result = outputJson;
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
                #endregion
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "订单认证进度查询异常，请稍后再试", ex.ToString());
            }
            return result;
        }
        #endregion

        #region 商户授权
        /// <summary>
        /// 商户授权
        /// </summary>
        static public Object MerchantAcceptance(string sskdRequestParasJson, string merchantsAcount, string merchantsMobile, string merchantsName, string merchantsIdCardNo, string amount)
        {
            string result = string.Empty;
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }

                newxbwn_Request req = new newxbwn_Request();
                header header = new header();

                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = sskdRequestParas.Timestamp;
                header.orderNo = sskdRequestParas.OrderNo;
                header.sign = sskdRequestParas.Sign;
                header.equipmentNo = sskdRequestParas.EquipmentNo;
                header.merchantsNo = sskdRequestParas.MerchantsNo;
                header.orderType = "LOAN";
                header.orderSource = sskdRequestParas.OrderSource;
                req.header = header;
                var data = new
                {
                    merchantsAcount = merchantsAcount,// merchantsAcount    String  是   100 商户账号
                    merchantsName = merchantsName, //merchantsName   String  是   100 商户姓名
                    merchantsMobile = merchantsMobile,//merchantsMobile String  是   100 商户手机号
                    merchantsIdCardNo = merchantsIdCardNo, //merchantsIdCardNo   String  是   100 商户身份证号
                    authorizedType = sskdRequestParas.authorizedType, //authorizedType  String  是   100 授权类型(开户create 授额quota 提额improve)
                    amount = amount, //amount  Double  是   100 授权额度
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/l/sl";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, sskdRequestParas.Token); ;
                ILog.ApiInvokingLogAdd(sskdRequestParas.ConsultId, apiUrl, requestDate, inputJson, outputJson);

                #region 解析返回json
                string bankCardId = string.Empty;
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                    }
                    result = outputJson;
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
                #endregion
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "商户授权异常，请稍后再试", ex.ToString());
            }
            return result;
        }
        #endregion


        #region 查询商户权限
        /// <summary>
        /// 订单认证进度
        /// </summary>
        static public Object QueryBusinessPermissions(string sskdRequestParasJson)
        {
            string result = string.Empty;
            try
            {
                SSKDRequestParas sskdRequestParas = null;
                if (!string.IsNullOrEmpty(sskdRequestParasJson))
                {
                    sskdRequestParas = JsonConvert.DeserializeObject<SSKDRequestParas>(sskdRequestParasJson);
                }
                newxbwn_Request req = new newxbwn_Request();
                header header = new header();
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = sskdRequestParas.Timestamp;
                header.orderNo = sskdRequestParas.OrderNo;
                header.sign = sskdRequestParas.Sign;
                header.equipmentNo = sskdRequestParas.EquipmentNo;
                header.merchantsNo = sskdRequestParas.MerchantsNo;
                header.orderType = "LOAN";
                header.orderSource = sskdRequestParas.OrderSource;
                req.header = header;
                var data = new
                {
                    merchantNo = sskdRequestParas.MerchantsNo
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                DateTime requestDate = DateTime.Now;
                string apiUrl = newxinboweinuoApi + "/iservice/rt/it/qmp";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, sskdRequestParas.Token); ;
                ILog.ApiInvokingLogAdd(sskdRequestParas.ConsultId, apiUrl, requestDate, inputJson, outputJson);

                #region 解析返回json
                string bankCardId = string.Empty;
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                    }
                    result = outputJson;
                }
                else
                {
                    result = DNTRequest.GetResultJsonForApi(false, "接口无响应，请稍后再试", null);
                }
                #endregion
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = DNTRequest.GetResultJsonForApi(false, "查询商户权限异常，请稍后再试", ex.ToString());
            }
            return result;
        }
        #endregion

    }
}
