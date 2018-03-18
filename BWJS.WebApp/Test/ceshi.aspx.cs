using UtilityHelper;
using BWJS.AppCode;
using BWJS.SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MofangInterface.BLL;
using MofangInterface.Model.InputModel;
using System.Diagnostics;
using System.Reflection;
using BWJSLog.BLL;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using XBWN.Model;
using Newtonsoft.Json.Linq;
using XBWN.DAL;
using Newtonsoft.Json;

namespace BWJS.WebApp.Test
{
    public partial class ceshi : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                byte[] idphoto = GetPhoto("C:\\Users\\ADMINI~1\\AppData\\Local\\Temp\\Low\\chinaidcard\\xp.jpg");

                litLocationInfo.Text = MachineLocationLogBLL.GetCurrentLocation();
                litIpInfo.Text = IpHelper.Test();

                //Test1();
                //renderOption&&renderOption({"status":0,"result":{"location":{"lng":116.30815063007148,"lat":40.056890127931279},"precise":1,"confidence":80,"level":"道路"}})
                decimal lat = ComPage.SafeToDecimal("40.056890127931279");
                /*{"address":"CN|\u5317\u4eac|\u5317\u4eac|None|UNICOM|0|0","content":{"address":"\u5317\u4eac\u5e02","address_detail":{"city":"\u5317\u4eac\u5e02","city_code":131,"district":"","province":"\u5317\u4eac\u5e02","street":"","street_number":""},"point":{"x":"116.40387397","y":"39.91488908"}},"status":0}*/
                //Response.Write(UtilityHelper.Utils.UnicodeToString("\u5317\u4eac"));

            }
            switch (DNTRequest.GetString("action"))
            {
                case "btnProductInsuredArea_Click":
                    btnProductInsuredArea_Click(sender, e);
                    break;
                case "btnOrderSummary_Click":
                    btnOrderSummary_Click(sender, e);
                    break;
            }

            string heartbeat = string.Empty;
            int hours = 24;
            int minutes = 60;
            int seconds = 60;
            double interval = 1000;
            interval = hours * minutes * seconds * 1000;

            litRandom.Text = interval.ToString();


            DateTime dt_1970 = new DateTime(1970, 1, 1); TimeSpan span = TimeSpan.FromMilliseconds(1514038683290) + TimeSpan.FromHours(8); DateTime ss = dt_1970 + span;

            Response.Write(ss.ToShortDateString());

        }

        protected void btnProductInsuredArea_Click(object sender, EventArgs e)
        {

            //string areaCode = areaCode.tex; 
            //string caseCode  =caseCode.Value;
            //string customkey =customkey.Value;
            //string transNo   = transNo.Value;

            string result = string.Empty;
            Response.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "ProductInsuredArea开始");
            try
            {

                BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
                ProductInsuredAreaReq model = new ProductInsuredAreaReq();
                model.transNo = DateTime.Now.ToString("yyyyMMddHHmmssfffff");
                model.caseCode = "0000052178002133";
                model.areaCode = string.Empty;
                var res = baoxianDataBLL.ProductInsuredArea(model);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            Response.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "OrderSummary结果：" + result);
        }

        protected void btnOrderSummary_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            Response.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "OrderSummary开始");
            try
            {
                BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
                OrderSummaryInputModel model = new OrderSummaryInputModel();
                //model.starttime = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
                //model.endtime = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd");
                model.starttime = "2016-11-25 16:25:20";
                model.endtime = "2018-12-03 16:25:20";
                model.customkey = "bowangjishi";
                model.start = 1;
                model.limit = 50;
                baoxianDataBLL.OrderSummary(model);
                result = "成功";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            Response.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "OrderSummary结果：" + result);
        }

        protected void Test1()
        {
            Response.Write(GetMethodInfo());
        }

        public string GetMethodInfo()
        {
            string str = "";
            //取得当前方法命名空间
            str += "命名空间名:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "<br />";
            //取得当前方法类全名 包括命名空间
            str += "命名空间+类名:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "<br />";
            //获得当前类名
            str += "类名:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "<br />";
            //取得当前方法名
            str += "方法名:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "<br />";
            str += "<br />";
            StackTrace ss = new StackTrace(true);
            MethodBase mb = ss.GetFrame(1).GetMethod();
            //取得父方法命名空间
            str += mb.DeclaringType.Namespace + "<br />";
            //取得父方法类名
            str += mb.DeclaringType.Name + "<br />";
            //取得父方法类全名
            str += mb.DeclaringType.FullName + "<br />";
            //取得父方法名
            str += mb.Name + "<br />";
            return str;
        }

        protected void btnSmsSend_Click(object sender, EventArgs e)
        {
            string msisdns = txtMsisdns.Text.Trim();
            string smsContent = txtSmsContent.Text.Trim();
            if (string.IsNullOrEmpty(smsContent))
            {
                smsContent = string.Format("尊敬的用户，您好：您的{0}交易流水号于{1}支付成功，投保单号为{2}，特此通知。【{3}】"
                   , "f088a1b28e5c4a5dabf81d4f96702b60", DateTime.Now.ToString("yy年MM月dd日HH时mm分"), "20170925002242", "闪速快贷");
                smsContent = string.Format("验证码：{0} 【{1}】", new Random().Next(6, 6), "闪速快贷");
            }
            string result = string.Empty;
            if (!string.IsNullOrEmpty(msisdns) && !string.IsNullOrEmpty(smsContent))
            {
                result = SmsHelper.DoSend(msisdns, null, smsContent, null, string.Empty);
            }
            else
            {
                result = "接收号码或发送内容不能为空";
            }
            litSendResult.Text = result;
        }

        #region image类型图片
        private void button_connect_Click(object sender, EventArgs e)
        {
            string sqlText = "server=localhost;initial catalog=Test; integrated security=true";
            string sqlstr = "insert into tast(photo) values(@image) ";
            SqlConnection conn = new SqlConnection(sqlText);
            conn.Open();
            SqlCommand comm = new SqlCommand(sqlstr, conn);
            comm.Parameters.Add("@image", SqlDbType.Image).Value = GetPhoto("DSC_6126.JPG");
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public byte[] GetPhoto(string str1)
        {
            byte[] photo = new byte[0];
            try
            {
                string str = str1;
                string idPhotoPath = CommonHelper.GetAppSettingsValue("IdPhotoPath", "/Resources/Temp/");
                string idPhotoServerPath = Server.MapPath(idPhotoPath);
                string fileName = "150422198204280331.jpg";
                string fileServerPath = idPhotoServerPath + fileName;
                if (!Directory.Exists(idPhotoServerPath))
                {
                    Directory.CreateDirectory(idPhotoServerPath);
                }
                if (File.Exists(fileServerPath))
                {
                    File.Delete(fileServerPath);
                }
                File.Copy(str1, fileServerPath);

                FileStream file = new FileStream(str, FileMode.Open, FileAccess.Read);
                photo = new byte[file.Length];
                file.Read(photo, 0, photo.Length);
                file.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return photo;
        }

        //取
        private void button_showimg_Click(object sender, EventArgs e)
        {
            string sqlText = "server=localhost;initial catalog=Test; integrated security=true";
            string sqlstr = "select *from tast where whf=1";
            SqlConnection conn = new SqlConnection(sqlText);
            conn.Open();
            SqlCommand comm = new SqlCommand(sqlstr, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;
            DataSet ds = new DataSet();
            da.Fill(ds);
            MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0][1]);
            //Image i = Image.FromStream(ms, true);
            //pictureBox1.Image = i;
        }
        #endregion

        protected void btnRandom_Click(object sender, EventArgs e)
        {
            string result = string.Empty;

            ArrayList ht = new ArrayList();
            Random rm = new Random();
            int RmNum = 10;
            for (int i = 0; ht.Count < RmNum; i++)
            {
                int nValue = rm.Next(1000000);
                if (!ht.Contains(nValue) && nValue != 0)
                {
                    ht.Add(nValue);
                    //Console.WriteLine(nValue.ToString());
                }
            }
            result = string.Join(",", ht.ToArray());
            litRandom.Text = result;
        }

        protected void btnJson_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// 公钥加密
            /// </summary>
            string publicKey = CommonHelper.GetAppSettingsValue("publicKey", "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCTVTAir38huCqIEcWNSVlBSSFuHIHq+EOsJNhcmin4BqmQazLB/RdWonPgeZRZNNOHOuAqQVHW84gHgoGu1+LsI7ui2tppqcUDcwuoBVvrpjM+Se4KKa+JgMHroPW+DqbavoqThyIxC9tad4nL6awpb4TM4ku8d2yt/c8cwRahUQIDAQAB");
            /// <summary>
            /// 私钥解密
            /// </summary>
            string privateKey = CommonHelper.GetAppSettingsValue("privateKey", "MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAKYa2u9VWd62gQzjkr3TFbQGHhf7fQuShZCleISBdMsggBdp6/Hb1PBD+7A0bzDyHcN+e6zGeTmdFJKfFL0VGftmgPCeH5mO1YJ98Rx5iWswXDD+k6LBfG6cFhYhiktjuLgHQ5eTL9sfnsugfpgBzPCg+Xjtsv+gK2WdqjWWmQ75AgMBAAECgYBDef9cYGDMv3j3Qm93G4vigOWyumAW1mPZ2c52jZxjdAV0/Xty2enL3OIet34/9OswYm5dRpcyV2RnF6a2FR9jQIA/A7DxzxcKkW7Du2x92JeEtLk/D8jfYJFTCebgenn+W9XQCFO8SAPHLzDC0BNkE1GlH7WU9x03S8d9mvcIDQJBANlXDd5wi/31y6NaJZrUKMgRPOnPsZpGszC3CGMBg2aQYhsa4HqjhfhGAmNWemfWYwTFI5nJZL0IHUNKuCWiDEcCQQDDprjVlr/LHi5zMDpmRz45RySKyh4MfQWNdkUXH/6pHvspPwjd6eDc/09F6FWYcR0vh6sxZ4k08mRpbHeyP+q/AkAsm4R6MilZb3hjR55OP9s67ObOqlUub/JZPkfXYjkg9ONd4s9N/IADrALTdq1a4JKkKP4ck0w8zAyNgil3d+IDAkEAub1okdUIhYNEo7QwbPLLnsLsbRpOhpqWD+Ms2jRUpie0V0bxWwNypzt1/a8Au7T++SV6H2/kcTCApRkFVWKarwJAalI8f9WacNlYyFtB8E37lRXELt9bzyBuuDLproaJO7p8/k6THES0kRGXuPBfoGJA0io73rD4S4rELVwe0BBtoA==");

            string outputJson = "{\"data\":[],\"success\":true,\"code\":null,\"message\":null,\"mark\":true,\"timestamp\":0}";
            outputJson = "{\"data\":{\"token\":\"c4cf0b3a-3bf1-46ea-826c-9004c1cbcd8a\",\"memberId\":\"EB7nnctjQ4sRIBQJ3C5IOMP14P2I2KOz43iim1jXcxYcnDA0qixE3+NM8k8Py9LDdCg6tqtctM0utUChGSIfkNPFsVPXNQiU7a6jj6lFzDqp8My8v4U51WNGbjEwPYM8tDjsgrpI220T/08ITv8nt6Ttk8YloAifVvCfF5HWTjg=\",\"customerId\":\"I/t7xcN4YyNqSNgDBfwiJkg8UkwSnHuI5OZI4BDqmeMvwGknVEK0weRhGSuRVT9hNrrql0Zsd03VDAuO+GLa1jPBywT/VrmsHuakvmvgw578qG3AJ2hPGLk8poYJJXYLwHHlxSRYpfVxbl6yqYVUlqXpogSXR7DGKOaRZCnWr5g=\",\"telNo\":\"8613426086182\",\"imei\":\"1234567890\",\"realName\":null},\"success\":true,\"code\":null,\"message\":null,\"mark\":true,\"timestamp\":0}";


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
                    //string mid = o["data"]["memberId"].ToString();
                    //mid = RSA.RSADecrypt(privateKey, mid);
                    //memberId = UtilityHelper.TypeConverter.StrToInt(mid);
                    //string cid = o["data"]["customerId"].ToString();
                    //cid = RSA.RSADecrypt(privateKey, cid);
                    //customerId = UtilityHelper.TypeConverter.StrToInt(cid);
                    token = o["data"]["token"].ToString();
                    realName = o["data"]["realName"].ToString();
                    idNo =UtilityHelper.TypeConverter.SafeToString(o["data"]["idNo"]);
                }
            }
            #endregion

            if (success)
            {
                #region 写入会员信息
                xbwn_Users modelUsers = new xbwn_Users();
                modelUsers.NetLoanApplyId = 3427;
                modelUsers.IMEI = imei;
                modelUsers.MemberId = -1;
                modelUsers.CustomerId = -1;
                modelUsers.Token = token;
                modelUsers.RealName = realName;
                modelUsers.IdNo = idNo;
                modelUsers.TelNo = "8613426086182";
                modelUsers.UserPassword = "zhuxk2017";
                modelUsers.InviteCode = string.Empty;
                modelUsers.RegisterIP = HttpContext.Current.Request.UserHostAddress;
                modelUsers.SmsCode = "600123";
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
        }
    }
}