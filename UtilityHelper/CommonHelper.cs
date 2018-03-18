

using Newtonsoft.Json;
using ObjectModels.JsTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Xml;
using ThoughtWorks.QRCode.Codec;

namespace UtilityHelper
{
    public class CommonHelper
    {

        private static System.Text.RegularExpressions.Regex numberRegex = new System.Text.RegularExpressions.Regex(@"(\d+)");

        /// <summary>
        /// 用户编号编码
        /// </summary>
        /// <returns></returns>
        public static string CodeNo()
        {

            return "";
        }
        /// <summary>
        /// 获取服务器IP
        /// </summary>
        /// <returns></returns>
        private static string GetIp()
        {
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            string strAddr = ipEntry.AddressList[0].ToString();
            return strAddr;

        }

        /// <summary>
        /// 商标详细信息
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string getBrandInfo(string BrandID)
        {
            string url = ConfigurationManager.AppSettings["BrandInfoURL"].ToString();
            IDictionary<string, string> IDic = new Dictionary<string, string>();
            IDic.Add("bh", BrandID);
            return new HttpUtils().DoGet(url, IDic);

        }

        /// <summary>
        /// 输入电话号码，返回归属地
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string getPhonestt(String phone)
        {
            String urlname = string.Format("http://api.k780.com:88/?app=phone.get&phone={0}&appkey=10003&sign=b59bc3ef6191eb9f747dd4e83c99f2a4&format=xml", phone);
            XmlDocument doc = new XmlDocument();
            doc.XmlResolver = null;
            doc.Load(urlname);
            XmlNode root = doc.SelectSingleNode("/root/success");
            if (root != null)
            {
                string strsuccess = (root.SelectSingleNode("/root/success")).InnerText;
                if (strsuccess == "1")
                {
                    XmlNode rootch = doc.SelectSingleNode("/root/result/att");


                    if (rootch != null)
                    {
                        string strstt = (root.SelectSingleNode("/root/result/att")).InnerText;
                        return strstt;

                    }


                }

            }

            return "未知";

        }
        /// <summary>
        /// 获得用户IP地址
        /// </summary>
        /// <returns>用户IP地址</returns>
        public static string GetUserIP()
        {
            string strIPAddr, userip;
            strIPAddr = userip = "";
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                userip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }

            if (userip == "" || userip.ToLower().IndexOf("unknown") >= 0)
            {
                strIPAddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                strIPAddr = strIPAddr.Trim();
            }
            else if (userip.IndexOf(",") >= 0)
            {
                strIPAddr = userip.Substring(0, userip.IndexOf(","));
            }
            else if (userip.IndexOf(";") >= 0)
            {
                strIPAddr = userip.Substring(0, userip.IndexOf(";"));
            }

            else
            {
                strIPAddr = userip;
            }
            return strIPAddr;
        }

        /// <summary>
        /// MD5函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str, Encoding encoding, bool isDoubleEnc = false)
        {
            byte[] b = encoding.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            if (isDoubleEnc)
            {
                b = new MD5CryptoServiceProvider().ComputeHash(b);
            }
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');
            return ret;
        }
        /// <summary>
        /// MD5函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str, bool isDoubleEnc = false)
        {
            return MD5(str, Encoding.Default, isDoubleEnc);
        }

        /// <summary>
        /// MD5ByUTF8加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5ByUTF8(string str)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider MD5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] MD5Source = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] MD5Out = MD5CSP.ComputeHash(MD5Source);
            return Convert.ToBase64String(MD5Out);
        }


        static public string MD516(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
        }
        static public string MD532(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();

            //MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            //byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(str));
            //StringBuilder sBuilder = new StringBuilder();
            //for (int i = 0; i < data.Length; i++)
            //{
            //    sBuilder.Append(data[i].ToString("x2"));
            //}
            //return sBuilder.ToString();
        }

        #region 从配置文件获取Value
        /// <summary>
        /// 从配置文件获取Value
        /// </summary>
        /// <param name="key">配置文件中key字符串</param>
        /// <returns></returns>
        static public string GetValueFromConfig(string key)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //获取AppSettings的节点 
                AppSettingsSection appsection = (AppSettingsSection)config.GetSection("appSettings");
                return appsection.Settings[key].Value;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        #endregion

        #region 设置配置文件
        /// <summary>
        /// 设置配置文件
        /// </summary>
        /// <param name="key">配置文件中key字符串</param>
        /// <param name="value">配置文件中value字符串</param>
        /// <returns></returns>
        static public bool SetValueFromConfig(string key, string value)
        {
            try
            {
                //打开配置文件 
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //获取AppSettings的节点 
                AppSettingsSection appsection = (AppSettingsSection)config.GetSection("appSettings");
                appsection.Settings[key].Value = value;
                config.Save();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        static public string GetAppSettingsValue(string key)
        {
            try
            {
                if (ConfigurationManager.AppSettings[key] != null)
                {
                    return ConfigurationManager.AppSettings[key].ToString();
                }
                else
                {
                    if (ConfigurationManager.ConnectionStrings[key] != null)
                    {
                        return ConfigurationManager.ConnectionStrings[key].ConnectionString;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }
        static public string GetAppSettingsValue(string key, object defaultval)
        {
            try
            {
                if (ConfigurationManager.AppSettings[key] != null)
                {
                    return ConfigurationManager.AppSettings[key].ToString();
                }
                else
                {
                    if (ConfigurationManager.ConnectionStrings[key] != null)
                    {
                        return ConfigurationManager.ConnectionStrings[key].ConnectionString;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            catch
            {
                if (defaultval != null)
                {
                    return defaultval.ToString();
                }
                return string.Empty;
            }
        }
        // <summary>
        /// 获取配置文件AppSetting或ConnectionString节信息
        /// </summary>
        /// <param name="ConfigKey"></param>
        /// <returns></returns>
        public static string GetConfigValue(string ConfigKey)
        {
            try
            {
                string config = ConfigurationManager.AppSettings[ConfigKey] ?? ConfigurationManager.ConnectionStrings[ConfigKey].ToString();
                return config;
            }
            catch
            {
                //[TDL]错误日志
                return null;
            }
        }

        public static int GetAppSettingInt(string key, int defaultValue)
        {
            int value = 0;
            if (!int.TryParse(ConfigurationManager.AppSettings[key], out value))
                value = defaultValue;

            return value;
        }


        /// <summary>
        /// 获取属性名称与JsonProperty的对应关系，key:属性名称,value:JsonProperty名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>key:属性名称,value:JsonProperty名称</returns>
        public static Dictionary<string, string> GetPropertyNameForJsonPropertyAttribute<T>() where T : class, new()
        {
            T t = new T();
            var SortFileds = new Dictionary<string, string>();
            var propertys = t.GetType().GetProperties();
            foreach (var p in propertys)
            {
                JsonPropertyAttribute[] xeas = p.GetCustomAttributes(typeof(JsonPropertyAttribute), true) as JsonPropertyAttribute[];
                if (xeas != null && xeas.Length > 0)
                    if (!SortFileds.ContainsKey(p.Name))
                        SortFileds.Add(p.Name, xeas[0].PropertyName);
            }

            return SortFileds;
        }

        /// <summary>
        /// 构造datatables.js用客户端请求对象
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static T GetSentParameters<T>(HttpRequest request) where T : SentParameters, new()
        {
            T sentParameters = new T();
            var spAtt = CommonHelper.GetPropertyNameForJsonPropertyAttribute<SentParameters>();
            var queryString = new NameValueCollection();
            var spType = sentParameters.GetType();
            if (request.HttpMethod.ToUpper() == "GET")
            {
                queryString = request.QueryString;
            }
            else
            {
                if (request.HttpMethod.ToUpper() == "POST")
                {
                    queryString = request.Form;
                }
            }
            foreach (var jpa in spAtt.Where(t => !t.Value.EndsWith("_")))
            {
                var value = queryString[jpa.Value];
                if (value == null)
                {
                    continue;
                }
                var p = spType.GetProperty(jpa.Key);
                if (p != null)
                {
                    p.SetValue(sentParameters, Convert.ChangeType(value, p.PropertyType, null), null);
                }
            }
            for (var index = 0; index < sentParameters.SortingCols; index++)
            {
                var sortIndex = -1;
                var value = queryString["iSortCol_" + index];
                if (!string.IsNullOrEmpty(value))
                {
                    int.TryParse(value, out sortIndex);
                }
                if (sortIndex > -1)
                {
                    sentParameters.SortCol.Add(sortIndex);
                    if (queryString.AllKeys.Contains("sSortDir_" + index))
                    {
                        sentParameters.SortDir.Add(queryString["sSortDir_" + index]);
                    }
                    else
                    {
                        sentParameters.SortDir.Add("desc");
                    }
                }
            }

            for (var index = 0; index < sentParameters.Columns; index++)
            {
                var tOrF = false;
                var value = queryString["bSearchable_" + index];
                if (!string.IsNullOrEmpty(value))
                {
                    bool.TryParse(value, out tOrF);
                }
                sentParameters.Searchable.Add(tOrF);
            }

            // 获取自定义参数
            foreach (var p in queryString.AllKeys.Where(t => t.StartsWith("c_")))
            {
                sentParameters.CustomerParameters.Add(p, HttpUtility.UrlDecode(queryString[p]));
            }

            return sentParameters;
        }


        /// <summary>
        /// 构造datatables.js用客户端请求对象
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <remarks>创建人员(日期):★彭振★(150720 08：47)</remarks>  
        public static T GetRquestParameters<T>(HttpRequest request) where T : SentParameters, new()
        {
            T sentParameters = new T();
            var spAtt = CommonHelper.GetPropertyNameForJsonPropertyAttribute<SentParameters>();
            var queryString = new NameValueCollection();
            var spType = sentParameters.GetType();
            if (request.HttpMethod.ToUpper() == "GET")
            {
                queryString = request.QueryString;
            }
            else
            {
                if (request.HttpMethod.ToUpper() == "POST")
                {
                    queryString = request.Form;
                }
            }
            foreach (var jpa in spAtt.Where(t => !t.Value.EndsWith("_")))
            {
                var value = queryString[jpa.Value];
                if (value == null)
                {
                    continue;
                }
                var p = spType.GetProperty(jpa.Key);
                if (p != null)
                {
                    p.SetValue(sentParameters, Convert.ChangeType(value, p.PropertyType, null), null);
                }
            }
            for (var index = 0; index < sentParameters.SortingCols; index++)
            {
                var sortIndex = -1;
                var value = queryString["iSortCol_" + index];
                if (!string.IsNullOrEmpty(value))
                {
                    int.TryParse(value, out sortIndex);
                }
                if (sortIndex > -1)
                {
                    sentParameters.SortCol.Add(sortIndex);
                    if (queryString.AllKeys.Contains("sSortDir_" + index))
                    {
                        sentParameters.SortDir.Add(queryString["sSortDir_" + index]);
                    }
                    else
                    {
                        sentParameters.SortDir.Add("desc");
                    }
                }
            }

            for (var index = 0; index < sentParameters.Columns; index++)
            {
                var tOrF = false;
                var value = queryString["bSearchable_" + index];
                if (!string.IsNullOrEmpty(value))
                {
                    bool.TryParse(value, out tOrF);
                }
                sentParameters.Searchable.Add(tOrF);
            }

            // 获取自定义参数
            foreach (var p in queryString.AllKeys.Where(t => t.StartsWith("c_")))
            {
                sentParameters.CustomerParameters.Add(p, HttpUtility.UrlDecode(queryString[p]));
            }

            #region 2015-7-20 08:46:47 彭振 适应JQwidgets控件传值增加

            sentParameters.DisplayStart = (request.QueryString["pagenum"].ToInt() * request.QueryString["pagesize"].ToInt()) + 1;
            sentParameters.DisplayLength = request.QueryString["pagesize"].ToInt();

            #endregion

            return sentParameters;
        }
        /// <summary>
        /// 返回客户端消息
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public static string MsgShow(string msg)
        {


            string s;
            s = "<script language=\"javascript\">";
            s += "alert('" + msg + "');";
            s += "</script>";
            return s;

        }

        /// <summary>
        /// 返回客户端消息
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public static string MsgShowClose(string msg)
        {


            string s;
            s = "<script language=\"javascript\">\r\n";
            s += "alert('" + msg + "');\r\nwindow.close();";
            s += "</script>";
            return s;

        }
        /// <summary>
        /// //关闭IFrame Layer 弹出的窗体
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string IFrameLayerClose(string msg)
        {

            string s;
            s = "<script language=\"javascript\">\r\n";

            s += "alert('" + msg + "');\r\n";
            s += "parent.layer.close(parent.layer.getFrameIndex(window.name));";
            s += "</script>";
            return s;

        }

        public static string ParentRefresh(string msg)
        {


            string s;
            s = "<script language=\"javascript\">\r\n";
            s += "alert('" + msg + "');\r\n";
            s += "window.opener.location.reload();\r\n";
            s += "window.close();\r\n";
            s += "</script>\r\n";
            return s;

        }
        public static string ParentClose(string msg)
        {


            string s;
            s = "<script language=\"javascript\">\r\n";
            s += "alert('" + msg + "');\r\n";
            s += "window.opener.close();\r\n";
            s += "</script>\r\n";
            return s;

        }
        public static string ParentRefresh()
        {


            string s;
            s = "<script language=\"javascript\">\r\n";
            s += "window.opener.location.reload();\r\n ";
            s += "</script>\r\n";
            return s;

        }


        /// <summary>
        /// 页面跳转
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string JumpPage(string url)
        {
            string s;
            s = "<script language=\"javascript\">";
            s += "window.location.href='" + url + "'";
            s += "</script>";
            return s;

        }


        /// <summary>
        /// 页面退回
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// 


        public static string JumpBack()
        {

            string s;
            s = "<script language=\"javascript\">";
            s += "window.history.back()";
            s += "</script>";
            return s;

        }


        /// <summary>
        /// 页面退回
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// 


        public static string JumpBack(string msg)
        {

            string s;
            s = "<script language=\"javascript\">";
            s += "alert('" + msg + "');\r\n";
            s += "window.history.back()";
            s += "</script>";
            return s;

        }


        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
        /// <summary>
        /// 判断是否是整数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d+$");
        }
        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public static bool IsUnsign(string value)
        {
            return Regex.IsMatch(value, @"^\d*[.]?\d*$");
        }
        /// <summary>
        /// 判断时间函数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDate(string value)
        {

            return Regex.IsMatch(value, @"^[1-9]{1}[0-9]{3}-[0-9]{1,2}-[0-9]{1,2}$");



        }

        public static bool IsEmail(string value)
        {

            return Regex.IsMatch(value, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

        }

        /// <summary>
        /// 转换日期为long型
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long DateTimeToLong(DateTime dt)
        {
            return (long)dt.ToUniversalTime().Subtract(DateTime.Parse("1970-01-01")).TotalMilliseconds;
        }

        /// <summary>
        /// 截字符串，汉字一个算两个字符，英文算一个字符返回值：截取后的字符串    
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="strlen">截取字符长度</param>
        /// <returns></returns>
        public static string SubstZFC(string str, int strlen)
        {
            if (str == "")
            {
                return "";
            }
            int tempLen = 0;
            string tempString = str;
            char[] c = str.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if ((int)c[i] > 126)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                if (tempLen == strlen)
                {
                    tempString = str.Substring(0, i + 1);
                    break;
                }
                else if (tempLen > strlen)
                {
                    tempString = str.Substring(0, i);
                    break;
                }
            }
            return tempString;
        }
        /// <summary>
        /// 返回字符数 1个汉字就是2个字符
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static int ZFC_Length(string strContent)
        {
            if (string.IsNullOrEmpty(strContent))
            {
                return 0;
            }
            int tempLen = 0;
            char[] c = strContent.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if ((int)c[i] > 126)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }


            }
            return tempLen;
        }

        public static string ReplacePhone(string Phone)
        {
            if (!string.IsNullOrEmpty(Phone))
            {

                bool IsShowAllPhone = false;
                try
                {
                    IsShowAllPhone = bool.Parse(CommonHelper.GetConfigValue("IsShowAllPhone"));
                }
                catch
                {

                }
                if (!IsShowAllPhone)
                {

                    if (Phone.Length > 6)
                    {
                        return Phone.Substring(0, Phone.Length - 6) + "******";
                    }
                    else
                    {
                        return "******";
                    }


                }
                else
                {
                    return Phone;
                }
            }
            else
            {
                return "";

            }

        }

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void Copy<T>(T source, T target)
            where T : class, new()
        {
            if (source == null || target == null)
                return;
            foreach (var p in source.GetType().GetProperties(BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public))
            {
                if (p.PropertyType.IsArray || (p.PropertyType.IsClass && p.PropertyType != typeof(string)) || p.PropertyType.IsInterface)
                    continue;

                var pTarget = target.GetType().GetProperty(p.Name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                if (pTarget != null)
                {

                    var value = p.GetValue(source, null);
                    if (value != null)
                    {
                        pTarget.SetValue(target,
                     Convert.ChangeType(value,
                      pTarget.PropertyType.GetGenericArguments().Count() == 0
                      ? pTarget.PropertyType
                      : pTarget.PropertyType.GetGenericArguments()[0]), null);
                    }
                }
            }
        }


        public static string UrlEncode(string msg)
        {
            return HttpUtility.UrlEncode(msg);
        }

        public static bool IsMobile(string strMobile)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(strMobile, @"^[1]+[1-9]+\d{9}");
        }

        /// <summary> 
        ///   转换为千分位 
        ///  </summary>    
        /// <param name="num">要转换的数字</param>  
        ///  <param name="fixeds">需要几位小数</param>  
        ///  <returns></returns>  

        public static string Commafy(decimal num, int fixeds)
        {
            //string rnum = num.ToString(string.Format("N{0}", fixeds));
            //string pattern = @"(-?\d+)(\d{3})";
            //while (Regex.IsMatch(rnum, pattern))
            //{
            //    rnum = Regex.Replace(rnum, pattern, "$1,$2",
            //        RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //}
            if (num != null)
            {
                return num.ToString(string.Format("N{0}", fixeds));
            }
            else
            {
                return "";
            }

        }
        public static string CommafyObj(object num, int fixeds)
        {
            //string rnum = num.ToString(string.Format("N{0}", fixeds));
            //string pattern = @"(-?\d+)(\d{3})";
            //while (Regex.IsMatch(rnum, pattern))
            //{
            //    rnum = Regex.Replace(rnum, pattern, "$1,$2",
            //        RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //}
            decimal money = 0;
            if (num != null)
            {
                decimal.TryParse(num.ToString(), out money);
                return money.ToString(string.Format("N{0}", fixeds));
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// 获取字符串中的数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetNumber(string str)
        {
            var strValue = "";
            foreach (Match m in numberRegex.Matches(str))
            {
                if (m.Success)
                {
                    strValue += m.Value;
                }
            }

            return strValue;
        }

        /// <summary>
        /// 计算N个工作日后的日期
        /// </summary>
        /// <param name="dt">开始时间</param>
        /// <param name="n">工作日天数</param>
        /// <returns></returns>
        public static DateTime GetWorkDateTime(DateTime dt, int n)
        {

            DateTime temp = dt;

            while (n-- > 0)
            {

                temp = temp.AddDays(1);

                while (temp.DayOfWeek == System.DayOfWeek.Saturday || temp.DayOfWeek == System.DayOfWeek.Sunday)
                {
                    temp = temp.AddDays(1);
                }


            }

            return temp;

        }
        public static string RemoveNotNumber(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return "";
            }
            else
            {
                key = key.Trim();
                return Regex.Replace(key, @"[^\d]*", "");
            }

        }


        public static string RemoveFirstZeroNumber(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return "";
            }
            else
            {
                key = key.Trim();
                return Regex.Replace(key, @"^0", "");
            }

        }
        /// <summary>
        /// 返回动态分页链接
        /// </summary>
        /// <param name="URL">地址</param>
        /// <param name="PageName">页码参数</param>
        /// <param name="AllPages">总页数</param>
        /// <param name="CurrentPage">当前页</param>
        /// <param name="PageSize">显示页码的数量</param>
        /// <returns></returns>
        public static string ShowPage(string URL, string PageName, int AllPages, int CurrentPage, int PageSize)
        {


            int hasParam = 0;
            int minPage = 0;
            int maxPage = 0;
            int leftCount = 0;
            int rightCount = 0;

            if (CurrentPage > AllPages)
            {
                CurrentPage = AllPages;
            }

            if (CurrentPage < 1)
            {
                CurrentPage = 1;
            }


            if (URL.IndexOf("?") > -1)
            {
                hasParam = 1;
            }
            if (hasParam == 1)
            {
                URL = URL + "&";
            }
            else
            {
                URL = URL + "?";
            }
            string strPage = "";
            strPage = strPage + "第 (" + CurrentPage + "/" + AllPages + ") 页 ";
            if (AllPages == 1)
            {
                //  strPage = strPage + "<span class=\"red_f\">[1]</span>";
            }
            else
            {
                if (AllPages <= PageSize)
                {
                    minPage = 1;
                    maxPage = AllPages;
                }
                else
                {
                    if (PageSize % 2 == 0)
                    {
                        leftCount = (PageSize / 2) - 1;
                        rightCount = PageSize / 2;
                    }
                    else
                    {
                        leftCount = (PageSize - 1) / 2;
                        rightCount = leftCount;
                    }
                    minPage = CurrentPage - leftCount;
                    maxPage = CurrentPage + rightCount;
                    if (minPage < 1)
                    {
                        minPage = 1;
                    }
                    if (maxPage > AllPages)
                    {
                        maxPage = AllPages;
                    }
                }
                if (CurrentPage > 1)
                {
                    strPage = strPage + "<a href = \"" + URL + PageName + "=1\">【首页】</a> ";
                    strPage = strPage + "<a href = \"" + URL + PageName + "=" + (CurrentPage - 1) + "\">【上一页】</a> ";

                }
                //for (int i = minPage; i <= maxPage; i++)
                //{
                //    if (i == CurrentPage)
                //    {
                //        strPage = strPage + "<span class=\"red_f\">[" + i + "]</span>  ";
                //    }
                //    else
                //    {
                //        strPage = strPage + "<a href = \"" + URL + PageName + "=" + i + "\">[" + i + "]</a> ";
                //    }
                //}
                if (CurrentPage < AllPages)
                {
                    strPage = strPage + "<a href = \"" + URL + PageName + "=" + (CurrentPage + 1) + "\">【下一页】</a> ";
                    strPage = strPage + "<a href = \"" + URL + PageName + "=" + AllPages + "\">【末页】</a> ";
                }
                else
                {
                    strPage = strPage + "<a>【下一页】</a> ";
                    strPage = strPage + "<a>【末页】</a> ";

                }
            }

            return strPage;
        }
        /// <summary>
        /// 删除指定路径文件
        /// </summary>
        /// <param name="fileUrl"></param>
        public static bool DeleteFile(string fileUrl)
        {
            try
            {
                string filename = "~/" + fileUrl;
                if (File.Exists(HttpContext.Current.Server.MapPath(filename)))
                {
                    File.Delete(HttpContext.Current.Server.MapPath(filename));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeContent"> 生成二维码的内容</param>
        /// <param name="QRCodePathName">二维码的路径，格式为jpg</param>
        /// <returns></returns>
        public static bool CreateQRCode(string CodeContent, string QRCodePathName)
        {
            try
            {
                Bitmap bt;
                string enCodeString = CodeContent;
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
                string path = HttpContext.Current.Server.MapPath(QRCodePathName);
                bt.Save(path);
                return true;
            }
            catch
            {
                return false;
            }


        }

        /// <summary>
        /// 生成随机的字符串
        /// </summary>
        /// <param name="codeCount"></param>
        /// <returns></returns>
        public static string CreateRandomCode(int codeCount)
        {
            string allChar = "2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,g,k,m,n,p,q,r,s,t,u,v,w,x,y,z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";

            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {

                int t = rand.Next(allCharArray.Length);

                randomCode += allCharArray[t];
            }
            return randomCode;
        }

        /// <summary>
        /// 从字符串中提取数字，包括小数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetNumFromStr(string str)
        {
            Regex r = new Regex("\\d+\\.?\\d*");
            bool ismatch = r.IsMatch(str);
            MatchCollection mc = r.Matches(str);

            string result = string.Empty;
            for (int i = 0; i < mc.Count; i++)
            {
                result += mc[i];
            }
            return result;
        }
        #region 订单流水号格式
        //Response.Write("Number1:"+new RandomNumber().OrderNoThree()); 
        //Response.Write("Number2:" + new RandomNumber().OrderNoTwo()); 
        //Response.Write("Number3:" + new RandomNumber().OrderNoOne()); 
        //Number1:P1608171449140001 
        //Number2:T636070421545568764 
        //Number3:201608171449145562080
        public static object _lock = new object();
        public static int count = 1;
        public static string OrderNoFour()
        {
            lock (_lock)
            {
                if (count >= 10000)
                {
                    count = 1;
                }
                var number = DateTime.Now.ToString("yyyyMMddHHmmss") + count.ToString("0000");
                count++;
                return number;
            }
        }

        public static string OrderNoThree()
        {
            lock (_lock)
            {
                if (count >= 10000)
                {
                    count = 1;
                }
                var number = "P" + DateTime.Now.ToString("yyMMddHHmmss") + count.ToString("0000");
                count++;
                return number;
            }
        }


        public static string OrderNoTwo()
        {
            lock (_lock)
            {
                return "T" + DateTime.Now.Ticks;

            }
        }

        public static string OrderNoOne()
        {
            lock (_lock)
            {
                Random ran = new Random();
                return "D" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ran.Next(1000, 9999).ToString();
            }
        }
        #endregion
    }
}
