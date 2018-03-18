using BWJS.AppCode;
using BWJS.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BWJS.Model;
using System.Net;
using System.Text;
using UtilityHelper;
using BWJS.BLL.CookieMag;
using System.Xml;
using BWJSLog.BLL;
using BWJSLog.Model;
using Newtonsoft.Json.Linq;
using XBWNInterface.BLL;

namespace BWJS.WebPad.Ajax.UsersLogin
{
    /// <summary>
    /// HUsersLogin 的摘要说明
    /// </summary>
    public class HUsersLogin : IHttpHandler
    {
        MachineBLL machineBll = new MachineBLL();
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["Action"];
            switch (action)
            {
                case "GetLoginOn":
                    GetLoginOn(context);
                    break;
                    //case "GetLoginImei":
                    //    GetLoginImei(context);
                    //    break;

            }
        }


        //private void GetLoginImei(HttpContext context)
        //{
        //    ILog  log= new ILog();
        //    try
        //    {
        //        string LoginName = context.Request.Params["LoginName"];
        //        string Password = context.Request.Params["Password"];
        //        string CardID = context.Request.Params["CardID"];
        //        string Imei = context.Request.Params["Imei"];
        //        log.OperationLogAdd(LoginName, Password);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }



        //}
        private void GetLoginOn(HttpContext context)
        {
            UsersBLL bll = new UsersBLL();
            ReturnModel ReturnModel = new ReturnModel();
            //int IsManager = 0;
            int result = 0;
            try
            {
                string LoginName = context.Request.Params["LoginName"];
                string Password = context.Request.Params["Password"];
                string CardID = context.Request.Params["CardID"];
                string Imei = context.Request.Params["Imei"];
                //string IsRemember = context.Request.Params["IsRemember"];

                if (!string.IsNullOrEmpty(LoginName) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(CardID))
                {

                    Users users = new Users();
                    string PwdKey = LinkFun.getPwdKey();
                    Password = DESEncrypt.Encrypt(PwdKey, Password);//旧密码加密 
                    ReturnModel = bll.VerificationPassword(LoginName, Password, CardID);
                    if (ReturnModel.IsSuccess)
                    {
                        int UserID = (int)ReturnModel.Data;
                        ILog.OperationLogAdd(UserID, Imei + "登录" + DateTime.Now);
                        result = UserID;
                        //if (!string.IsNullOrEmpty(Imei) && LoginName != "admin")
                        //{
                        //    bool bImei = machineBll.ExistsByUserIdImei(UserID, Imei);
                        //    if (!bImei)
                        //    {
                        //        ReturnModel.IsSuccess = false;
                        //        ReturnModel.ErrMessage = "您在该设备中还未授权。";
                        //        return;
                        //    }
                        //}
                        MerchantFrontCookieBLL.SetMerchantFrontCookie(UserID, LoginName);


                        #region 改造前端登录方法存储到缓存
                        UsersBLL bllUsers = new UsersBLL();
                        Users model = bllUsers.GetModel(UserID);
                        if (model != null)
                        {
                            string key = ComPage.memberModelCacheDependency + model.UserID;
                            ComPage.SetBWJSCache(key, Guid.NewGuid(), null, DateTime.Now.AddMinutes(ComPage.SafeToDouble(LinkFun.ConfigString("FrontEndCookieExpires", "120"))), TimeSpan.Zero);

                            HttpCookie cookie = new HttpCookie(LinkFun.ConfigString("FrontEndCookieName", "BWJSFrontEnd20180108"));
                            cookie.Expires = DateTime.Now.AddMinutes(ComPage.SafeToDouble(LinkFun.ConfigString("FrontEndCookieExpires", "120")));
                            cookie.Values.Add("Id", HttpContext.Current.Server.UrlEncode(model.UserID.ToString()));

                            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                            System.Web.HttpContext.Current.Response.AppendCookie(cookie);

                            model.LastAccessIP = HttpContext.Current.Request.UserHostAddress;
                            model.LoginTimes = ComPage.SafeToInt(model.LoginTimes) + 1;
                            model.RecordUpdateTime = DateTime.Now;
                            model.IsLogined = 1;
                            bllUsers.Update(model);
                        }
                        #endregion 
                    }
                }
                context.Response.Write(ObjectToJson(ReturnModel));
            }
            catch (Exception ex)
            {
                context.Response.Write(ex);
            }
        }




        /// <summary>
        /// 将对象序列化成Json
        /// </summary>
        /// <param name="obj">需要序列化的对象</param>
        /// <returns>序列化后的字符串</returns>
        public static string ObjectToJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 从Json字符串反序列化为对象
        /// </summary>
        /// <param name="jsonString">Json字符串</param>
        /// <param name="obj">要生成的对象类型</param>
        /// <returns>反序列化后的对象</returns>
        public static object JsonToObject(string jsonString)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<LoginUserCookie>(jsonString);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }



    }
}