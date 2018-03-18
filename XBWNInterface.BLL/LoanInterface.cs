using UtilityHelper;
using XBWNInterface.Model;
using BWJSLog.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BWJSLog.Model;
using XBWN.Model;
using XBWN.DAL;
using Newtonsoft.Json.Linq;
using BWJS.Model;
using Newtonsoft.Json;
using BWJS.BLL;

namespace XBWNInterface.BLL
{
    /// <summary>
    /// 贷款接口用户操作实现
    /// </summary>
    public class LoanInterface
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
        static string xinboweinuoApi = CommonHelper.GetAppSettingsValue("xinboweinuoApi", "http://localhost");

        #region 验证手机是否注册
        /// <summary>
        /// 验证手机是否注册
        /// </summary>
        static public Object CheckMonbileIsRegister(string telNo, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new { telNo = telNo };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/m/vt";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(apiUrl, inputJson);
                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 验证手机是否注册

        #region 发送手机验证码
        /// <summary>
        /// 发送手机验证码
        /// </summary
        static public Object GetMonbileSmsCode(string telNo, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new { telNo = telNo };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/m/svc";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(apiUrl, inputJson);
                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 发送手机验证码

        #region 会员注册
        /// <summary>
        /// 会员注册
        /// </summary>
        static public Object MemerRegister(string telNo, string password, string inviteCode, string smsCode, int netLoanApplyId = -1)
        {
            try
            {
                string ip = HttpContext.Current.Request.UserHostAddress;
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = ip;
                device.gps = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                f f = new f();
                f.t = "1234567890";
                f.v = "1234567890";
                req.device.f = f;
                string userPassword = password;
                password = RSA.RSAEncrypt(publicKey, password);
                var data = new
                {
                    telNo = telNo,
                    password = password,
                    inviteCode = inviteCode,
                    registerIP = ip,
                    smsCode = smsCode
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/m/r";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(apiUrl, inputJson);
                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                #region 解析返回json
                string imei = string.Empty;
                int? memberId = null;
                int? customerId = null;
                string token = string.Empty;
                string realName = string.Empty;
                string idNo = string.Empty;
                bool success = false;
                bool mark = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    //o = (JObject)JsonConvert.DeserializeObject(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                        mark = UtilityHelper.TypeConverter.StrToBool(o["mark"].ToString(), false);
                        imei = o["data"]["imei"].ToString();
                        string mid = o["data"]["memberId"].ToString();
                        mid = RSA.RSADecrypt(privateKey, mid);
                        memberId = UtilityHelper.TypeConverter.StrToInt(mid);
                        string cid = o["data"]["customerId"].ToString();
                        cid = RSA.RSADecrypt(privateKey, cid);
                        customerId = UtilityHelper.TypeConverter.StrToInt(cid);
                        token = o["data"]["token"].ToString();
                        realName = o["data"]["realName"].ToString();
                        idNo = o["data"]["idNo"].ToString();
                    }
                }
                #endregion

                if (success)
                {
                    #region 写入会员信息
                    xbwn_Users modelUsers = new xbwn_Users();
                    modelUsers.NetLoanApplyId = netLoanApplyId;
                    modelUsers.IMEI = imei;
                    modelUsers.MemberId = memberId;
                    modelUsers.CustomerId = customerId;
                    modelUsers.Token = token;
                    modelUsers.RealName = realName;
                    modelUsers.IdNo = idNo;
                    modelUsers.TelNo = telNo;
                    modelUsers.UserPassword = userPassword;
                    modelUsers.InviteCode = inviteCode;
                    modelUsers.RegisterIP = ip;
                    modelUsers.SmsCode = smsCode;
                    modelUsers.FontId = string.Empty;
                    modelUsers.BankId = string.Empty;
                    modelUsers.FaceNo = string.Empty;
                    modelUsers.Success = false;
                    modelUsers.Mark = mark;
                    modelUsers.IsDeleted = 0;
                    xbwn_UsersDAL dalUsers = new xbwn_UsersDAL();
                    dalUsers.Add(modelUsers);

                    #endregion
                }
                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 会员注册

        #region 会员登录
        /// <summary>
        /// 会员登录
        /// </summary>
        static public Object MemerSignIn(string telNo, string password, string smsCode, int netLoanApplyId = -1)
        {
            try
            {
                string ip = HttpContext.Current.Request.UserHostAddress;
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = ip;
                device.gps = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                f f = new f();
                f.t = "1234567890";
                f.v = "1234567890";
                req.device.f = f;

                password = RSA.RSAEncrypt(publicKey, password);
                var data = new
                {
                    telNo = telNo,
                    password = password,
                    smsCode = smsCode
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/m/li";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(apiUrl, inputJson);
                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                #region 解析返回json
                string imei = string.Empty;
                int memberId = -1;
                int customerId = -1;
                string token = string.Empty;
                string realName = string.Empty;
                bool success = false;
                bool mark = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                        imei = o["data"]["imei"].ToString();
                        string mid = o["data"]["memberId"].ToString();
                        mid = RSA.RSADecrypt(privateKey, mid);
                        memberId = UtilityHelper.TypeConverter.StrToInt(mid);
                        string cid = o["data"]["customerId"].ToString();
                        cid = RSA.RSADecrypt(privateKey, cid);
                        customerId = UtilityHelper.TypeConverter.StrToInt(cid);
                        token = o["data"]["token"].ToString();
                        realName = o["data"]["realName"].ToString();
                        mark = UtilityHelper.TypeConverter.StrToBool(o["mark"].ToString(), false);
                    }
                }
                #endregion

                if (success)
                {
                    #region 修改会员信息
                    xbwn_UsersDAL dalUsers = new xbwn_UsersDAL();
                    xbwn_Users dbmodelUsers = dalUsers.GetModel(memberId, customerId);
                    if (dbmodelUsers != null)
                    {
                        dbmodelUsers.NetLoanApplyId = netLoanApplyId;
                        dbmodelUsers.IMEI = imei;
                        dbmodelUsers.MemberId = memberId;
                        dbmodelUsers.CustomerId = customerId;
                        dbmodelUsers.Token = token;
                        dbmodelUsers.RealName = realName;
                        dbmodelUsers.TelNo = telNo;
                        //string postpwd = RSA.RSADecrypt(privateKey, password);
                        //dbmodelUsers.UserPassword = postpwd;
                        dbmodelUsers.RegisterIP = ip;
                        dbmodelUsers.SmsCode = smsCode;
                        dalUsers.Update(dbmodelUsers);
                    }
                    #endregion
                }

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 会员登录

        #region 获取银行卡列表
        /// <summary>
        /// 获取银行卡列表
        /// </summary>
        static public Object GetBankCardList(int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new
                {
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/c/cl";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                #region 解析返回json
                string no = string.Empty;
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                    }
                }
                #endregion

                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 添加银行卡

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
        static public Object BankCardAdd(string realName, string idNo, string bankCardNo, string telNo, int cash, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                string idNoForUserBank = idNo;
                string bankCardNoForUserBank = bankCardNo;
                idNo = RSA.RSAEncrypt(publicKey, idNo);
                bankCardNo = RSA.RSAEncrypt(publicKey, bankCardNo);
                var data = new
                {
                    realName = realName,
                    idNo = idNo,
                    bankCardNo = bankCardNo,
                    telNo = telNo,
                    cash = cash,
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/c/acbc";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                #region 解析返回json
                string no = string.Empty;
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                        no = o["data"]["no"].ToString();
                    }
                }
                #endregion

                if (success)
                {
                    #region 添加银行卡
                    if (!string.IsNullOrEmpty(no))
                    {
                        xbwn_UserBank model = new xbwn_UserBank();
                        model.NetLoanApplyId = netLoanApplyId;
                        model.No = no;
                        model.RealName = realName;
                        model.IdNo = idNoForUserBank;
                        model.BankCardNo = bankCardNoForUserBank;
                        model.TelNo = telNo;
                        model.Cash = cash;
                        model.SmsCode = string.Empty;
                        model.Flag = 0;
                        model.IsDeleted = 0;
                        model.CreateDate = DateTime.Now;
                        xbwn_UserBankDAL dal = new xbwn_UserBankDAL();
                        dal.Add(model);
                    }
                    #endregion
                }
                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 添加银行卡

        #region 发送银行手机验证码
        /// <summary>
        /// 发送银行手机验证码
        /// </summary>
        static public Object BankCardSmsCode(string no, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new
                {
                    no = no
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/c/sbcc";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 发送银行手机验证码

        #region 验证银行手机短信
        /// <summary>
        /// 验证银行手机短信
        /// </summary>
        static public Object BankCardSmsCodeCheck(string no, string code, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new
                {
                    no = no,
                    code = code
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/c/vbcc";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                #region 解析返回json
                int flag = 0;
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                        flag = UtilityHelper.TypeConverter.ObjectToInt(o["data"]["flag"]);
                    }
                }
                #endregion
                if (success)
                {
                    #region 修改银行卡
                    if (!string.IsNullOrEmpty(no))
                    {
                        xbwn_UserBankDAL dal = new xbwn_UserBankDAL();
                        dal.Update(code, flag, no);
                    }
                    #endregion
                }

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 验证银行手机短信

        #region 图片上传
        /// <summary>
        /// 图片上传
        /// </summary>
        static public Object ImagesUpload(string base64Code, byte[] photoData, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new { };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/h/up/f";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookieAndByte(apiUrl, inputJson, photoData, cookieKey, cookieValue);
                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                #region 解析返回json
                int imgId = 0;
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                        imgId = UtilityHelper.TypeConverter.ObjectToInt(o["data"]["imgId"]);
                    }
                }
                #endregion

                if (success)
                {
                    #region 添加图片
                    if (imgId != 0)
                    {
                        xbwn_Picture model = new xbwn_Picture();
                        model.NetLoanApplyId = netLoanApplyId;
                        model.Base64Code = base64Code;
                        model.ImgId = imgId.ToString();
                        model.IsDeleted = 0;
                        model.CreateDate = DateTime.Now;
                        xbwn_PictureDAL dal = new xbwn_PictureDAL();
                        dal.Add(model);
                    }
                    #endregion
                }

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 图片上传

        #region 检查身份认证是否成功
        /// <summary>
        /// 检查身份认证是否成功
        /// </summary>
        static public Object CheckUserIsAuthentication(string memberId, string customerId, int netLoanApplyId = -1)
        {
            string result = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(memberId) && !string.IsNullOrEmpty(customerId))
                {
                    string postMemberId = memberId.Replace(" ", "+");
                    postMemberId = RSA.RSADecrypt(privateKey, postMemberId);
                    int getMemberId = UtilityHelper.TypeConverter.ObjectToInt(postMemberId);
                    string postCustomerId = customerId.Replace(" ", "+");
                    postCustomerId = RSA.RSADecrypt(privateKey, postCustomerId);
                    int getCustomerId = UtilityHelper.TypeConverter.ObjectToInt(postCustomerId);
                    xbwn_UsersDAL dal = new xbwn_UsersDAL();
                    xbwn_Users model = dal.GetModel(getMemberId, getCustomerId);
                    if (model != null)
                    {
                        if (model.Success)
                        {
                            result = DNTRequest.GetResultJson(true, "success", null);
                        }
                        else
                        {
                            result = DNTRequest.GetResultJson(false, "已注册，未认证", null);
                        }
                    }
                    else
                    {
                        return DNTRequest.GetResultJson(false, "未注册，请先注册", null);
                    }
                }
                else
                {
                    return DNTRequest.GetResultJson(false, "请先登录", null);
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "检查身份认证是否成功异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion end 身份证信息提交

        #region 身份证信息提交
        /// <summary>
        /// 身份证信息提交
        /// </summary>
        static public Object SubmitIDInformation(string fontId, string bankId, string realName, string idNo, string birth, string national, string address, string authority, string validperiod, string faceNo, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                idNo = RSA.RSAEncrypt(publicKey, idNo);
                var data = new
                {
                    fontId = fontId,
                    bankId = bankId,
                    realName = realName,
                    idNo = idNo,
                    birth = birth,
                    national = national,
                    address = address,
                    authority = authority,
                    validperiod = validperiod,
                    faceNo = faceNo
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/c/vic";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                #region 解析返回json
                bool success = false;
                bool mark = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    mark = UtilityHelper.TypeConverter.StrToBool(o["mark"].ToString(), false);
                }
                #endregion

                if (success)
                {
                    #region 修改会员信息
                    if (success)
                    {
                        xbwn_UsersDAL dalUsers = new xbwn_UsersDAL();
                        xbwn_Users dbmodelUsers = dalUsers.GetModelByNetLoanApplyId(netLoanApplyId);
                        if (dbmodelUsers != null)
                        {
                            dbmodelUsers.FontId = fontId;
                            dbmodelUsers.BankId = bankId;
                            dbmodelUsers.FaceNo = faceNo;
                            dbmodelUsers.Success = success;
                            dalUsers.Update(dbmodelUsers);
                        }
                    }
                    #endregion
                }

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 身份证信息提交

        #region 创建手机运营商爬取任务
        /// <summary>
        /// 创建手机运营商爬取任务
        /// </summary>
        static public Object TaskCreate(string telNo, string servicePwd, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                string servicePwdPlaintext = servicePwd;
                string servicePwdCiphertext = RSA.RSAEncrypt(publicKey, servicePwd);
                var data = new
                {
                    telNo = telNo,
                    servicePwd = servicePwdCiphertext
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/c/qmcbr";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                #region 解析返回json
                string taskId = string.Empty;
                string state = string.Empty;
                string taskStatus = string.Empty;
                string imgStr = string.Empty;
                bool mark = false;
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                        //taskId = o["data"]["taskId"].ToString();
                        //state = o["data"]["state"].ToString();
                        //taskStatus = o["data"]["taskStatus"].ToString();
                        //imgStr = o["data"]["imgStr"].ToString();
                        mark = UtilityHelper.TypeConverter.StrToBool(o["mark"].ToString(), false);
                    }
                }
                #endregion

                if (success)
                {
                    #region 添加任务
                    if (!string.IsNullOrEmpty(taskId))
                    {
                        xbwn_Task model = new XBWN.Model.xbwn_Task();
                        model.NetLoanApplyId = netLoanApplyId;
                        model.TelNo = telNo;
                        model.ServicePwd = servicePwdPlaintext;
                        model.TaskId = taskId;
                        model.State = state;
                        model.TaskStatus = taskStatus;
                        model.ImgStr = imgStr;
                        model.Mark = mark;
                        model.IsDeleted = 0;
                        model.CreateDate = DateTime.Now;
                        xbwn_TaskDAL dal = new xbwn_TaskDAL();
                        dal.Add(model);
                    }
                    #endregion
                }

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 创建手机运营商爬取任务

        #region 更新手机运营商爬取任务
        /// <summary>
        /// 更新手机运营商爬取任务
        /// </summary>
        static public Object TaskUpdate(string smsCode, string taskId, string servicePwd, string imgCode, string realName, string idNo, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new
                {
                    smsCode = smsCode,
                    taskId = taskId,
                    servicePwd = servicePwd,
                    imgCode = imgCode,
                    realName = realName,
                    idNo = idNo,
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/c/vom";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);

                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 更新手机运营商爬取任务

        #region 查询手机运营商爬取任务
        /// <summary>
        /// 查询手机运营商爬取任务
        /// </summary>
        static public Object TaskQuery(string taskId, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new
                {
                    taskId = taskId
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/c/voq";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);

                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 查询手机运营商爬取任务

        #region 发送运营商短信
        /// <summary>
        /// 发送运营商短信
        /// </summary>
        static public Object SendOperatorSmsCode(string taskId, string telNo, string smsCode, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new
                {
                    taskId = taskId
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/c/ssc";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);

                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 发送运营商短信

        #region 发送运营商图片验证码
        /// <summary>
        /// 发送运营商图片验证码
        /// </summary>
        static public Object SendOperatorImgCode(string taskId, string telNo, string imgCode, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new
                {
                    taskId = taskId
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/c/sic";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);

                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 发送运营商图片验证码

        #region 获取借款参数
        /// <summary>
        /// 获取借款参数
        /// </summary>
        static public Object GetLoanParas(int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new { };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/l/lp";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);

                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 获取借款参数

        #region 提交借款
        /// <summary>
        /// 提交借款
        /// </summary>
        static public Object SubmitLoanApply(string loanAmount, string bankIdStr, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;
                int bankId = 0;
                try
                {
                    bankId = int.Parse(RSA.RSADecrypt(privateKey, bankIdStr));
                    bankIdStr = RSA.RSAEncrypt(publicKey, bankId.ToString());
                }
                catch (Exception ex) { }
                decimal loanAmountdec = decimal.Parse(loanAmount);
                var data = new
                {
                    loanAmount = loanAmountdec,
                    bankId = bankIdStr
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/l/lcm";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                #region 解析返回json
                string borrowNo = string.Empty;
                decimal amountReceived = 0;
                decimal loanServiceCharge = 0;
                decimal loanRate = 0;
                decimal returnAmount = 0;
                DateTime? loanDate = null;
                int loanDays = 0;
                DateTime? dueDate = null;
                string interestName = string.Empty;
                string interestValue = string.Empty;
                int bankCardId = -1;
                int memberId = -1;
                int customerId = -1;
                string realName = string.Empty;
                string idNo = string.Empty;
                string bankCode = string.Empty;
                string BankName = string.Empty;
                string bankCardNo = string.Empty;
                string telNo = string.Empty;
                int isCorrect = 0;
                bool mark = false;
                bool tradePasswordExist = false;
                bool success = false;
                if (!string.IsNullOrEmpty(outputJson))
                {
                    JObject o = JObject.Parse(outputJson);
                    success = UtilityHelper.TypeConverter.StrToBool(o["success"].ToString(), false);
                    if (success)
                    {
                        borrowNo = o["data"]["borrowNo"].ToString();
                        amountReceived = UtilityHelper.TypeConverter.SafeToDecimal(o["data"]["amountReceived"]);
                        loanServiceCharge = UtilityHelper.TypeConverter.SafeToDecimal(o["data"]["loanServiceCharge"]);
                        loanRate = UtilityHelper.TypeConverter.SafeToDecimal(o["data"]["loanRate"]);
                        returnAmount = UtilityHelper.TypeConverter.SafeToDecimal(o["data"]["returnAmount"]);
                        if (!string.IsNullOrEmpty(o["data"]["loanDate"].ToString()))
                        {
                            loanDate = UtilityHelper.Utils.MillisecondsToDateTime(Convert.ToInt64(o["data"]["loanDate"]));
                        }
                        loanDays = UtilityHelper.TypeConverter.StrToInt(o["data"]["loanDays"].ToString());
                        if (!string.IsNullOrEmpty(o["data"]["dueDate"].ToString()))
                        {
                            dueDate = UtilityHelper.Utils.MillisecondsToDateTime(Convert.ToInt64(o["data"]["dueDate"]));
                        }
                        //interestName = o["data"]["listInterest"]["interestName"].ToString();
                        //interestValue = o["data"]["listInterest"]["interestValue"].ToString();

                        string bid = o["data"]["bankCard"]["bankCardId"].ToString();
                        bid = RSA.RSADecrypt(privateKey, bid);
                        bankCardId = UtilityHelper.TypeConverter.StrToInt(bid);

                        string mid = o["data"]["bankCard"]["memberId"].ToString();
                        mid = RSA.RSADecrypt(privateKey, mid);
                        memberId = UtilityHelper.TypeConverter.StrToInt(mid);
                        string cid = o["data"]["bankCard"]["customerId"].ToString();
                        cid = RSA.RSADecrypt(privateKey, cid);
                        customerId = UtilityHelper.TypeConverter.StrToInt(cid);

                        realName = o["data"]["bankCard"]["realName"].ToString();
                        idNo = o["data"]["bankCard"]["idNo"].ToString();
                        bankCode = o["data"]["bankCard"]["bankCode"].ToString();
                        BankName = o["data"]["bankCard"]["bankName"].ToString();
                        bankCardNo = o["data"]["bankCard"]["bankCardNo"].ToString();
                        telNo = o["data"]["bankCard"]["telNo"].ToString();
                        isCorrect = UtilityHelper.TypeConverter.StrToInt(o["data"]["bankCard"]["isCorrect"].ToString());
                        mark = UtilityHelper.TypeConverter.StrToBool(o["mark"].ToString(), false);
                    }
                }
                #endregion

                if (success)
                {
                    #region 添加贷款
                    if (!string.IsNullOrEmpty(borrowNo))
                    {
                        xbwn_Loan model = new XBWN.Model.xbwn_Loan();
                        model.NetLoanApplyId = netLoanApplyId;
                        model.BorrowNo = borrowNo;
                        model.BankId = bankId.ToString();
                        model.LoanAmount = loanAmountdec;
                        model.AmountReceived = amountReceived;
                        model.LoanServiceCharge = loanServiceCharge;
                        model.LoanRate = loanRate;
                        model.ReturnAmount = returnAmount;
                        model.LoanDate = loanDate;
                        model.LoanDays = loanDays;
                        model.DueDate = dueDate;
                        model.InterestName = interestName;
                        model.InterestValue = interestValue;
                        model.BankCardId = bankCardId;
                        model.MemberId = memberId;
                        model.CustomerId = customerId;
                        model.RealName = realName;
                        model.IdNo = idNo;
                        model.BankCode = bankCode;
                        model.BankName = BankName;
                        model.TelNo = telNo;
                        model.IsCorrect = isCorrect;
                        model.TradePasswordExist = tradePasswordExist;
                        model.TradePassword = string.Empty;
                        model.TradePasswordSecond = string.Empty;
                        model.Flag = 0;
                        model.Mark = mark;
                        model.IsDeleted = 0;
                        model.CreateDate = DateTime.Now;
                        xbwn_LoanDAL dal = new xbwn_LoanDAL();
                        dal.Add(model);
                    }
                    #endregion
                }

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 提交借款

        #region 确认借款
        /// <summary>
        /// 确认借款
        /// </summary>
        static public Object ConfirmationLoanApply(string borrowNo, string tradePassword, string tradePasswordSecond, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;
                f f = new f();
                f.t = "1234567890";
                f.v = "1234567890";
                req.device.f = f;

                tradePassword = RSA.RSAEncrypt(publicKey, tradePassword);
                tradePasswordSecond = RSA.RSAEncrypt(publicKey, tradePasswordSecond);
                var data = new
                {
                    borrowNo = borrowNo,
                    tradePassword = tradePassword,
                    tradePasswordSecond = tradePasswordSecond
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/l/lcf";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);
                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

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
                    }
                }
                #endregion

                if (success)
                {
                    #region 修改贷款
                    if (!string.IsNullOrEmpty(borrowNo))
                    {
                        xbwn_LoanDAL dal = new xbwn_LoanDAL();
                        xbwn_Loan dbmodelLoan = dal.GetModelByBorrowNo(borrowNo);
                        if (dbmodelLoan != null)
                        {
                            //tradePassword = RSA.RSADecrypt(privateKey, tradePassword);
                            //tradePasswordSecond = RSA.RSADecrypt(privateKey, tradePasswordSecond);
                            //dbmodelLoan.TradePassword = tradePassword;
                            //dbmodelLoan.TradePasswordSecond = tradePasswordSecond;
                            dbmodelLoan.Flag = flag;
                            dal.Update(tradePassword, tradePasswordSecond, flag, borrowNo);
                        }
                    }
                    #endregion
                }

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion end 确认借款

        #region 首页综合信息查询
        /// <summary>
        /// 首页综合信息查询
        /// </summary>
        static public Object ComprehensiveQuery(int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new { };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/h/a";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);

                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion

        #region 借款状态审核查询
        /// <summary>
        /// 借款状态审核查询
        /// </summary>
        static public Object BorrowingStateQuery(string borrowNo, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new
                {
                    borrowNo = borrowNo
                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/l/qbs";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);

                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion

        #region 特许授权
        /// <summary>
        /// 特许授权
        /// </summary>
        static public Object ConfirmationOfAuthorization(string identityCardNumber, string accountExec, string authorizedPassword,string operatorName, string operatorId, string borrowNo, int netLoanApplyId = -1)
        {
            try
            {
                xbwn_Request req = new xbwn_Request();
                header header = new header();
                header.target = "123";
                header.key = "MIUI";
                header.version = "1.0";
                header.requestType = 0;
                header.timestamp = DNTRequest.GetCurrentTimeUnix;
                req.header = header;

                device device = new device();
                device.imei = "1234567890";
                device.uuid = "1234567890";
                device.ip = HttpContext.Current.Request.UserHostAddress;
                device.gps = "1234567890";
                device.networkLocation = "1234567890";
                device.mac = "1234567890";
                device.brGid = "1234567890";
                device.brNo = "1234567890";
                device.tdGid = "1234567890";
                device.source = source;
                device.sourceChannel = sourceChannel;
                req.device = device;

                var data = new
                {
                    identityCardNumber = identityCardNumber,
                    accountExec = accountExec,
                    authorizedPassword = authorizedPassword,
                    operatorName = operatorName,
                    operatorId = operatorId,
                    borrowNo = borrowNo

                };
                req.data = data;

                string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);

                DateTime requestDate = DateTime.Now;
                string apiUrl = xinboweinuoApi + "/iservice/s/l/alb";
                string outputJson = UtilityHelper.HttpService.GetHttpWebResponseByRestSharpAddCookie(apiUrl, inputJson, cookieKey, cookieValue);

                XinboweinuoLogBLL.Add(netLoanApplyId, apiUrl, requestDate, inputJson, DateTime.Now, outputJson);

                return outputJson;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                return ex.Message;
            }
        }

        #endregion
        
    }
}
