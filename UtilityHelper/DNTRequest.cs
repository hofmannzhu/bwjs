using System;
using System.Web;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace UtilityHelper
{
    /// <summary>
    /// Request操作类
    /// </summary>
    public class DNTRequest
    {
        #region 拼装JSON
        /// <summary>
        /// 拼装JSON
        /// </summary>
        static public string GetResultJson(bool result, string msg, Object data)
        {
            string resultJson = string.Empty;
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("result", result);
                ht.Add("msg", msg);
                ht.Add("data", data);
            }
            catch (Exception ex)
            {
                ht.Add("result", false);
                ht.Add("msg", ex.Message);
            }
            resultJson = Newtonsoft.Json.JsonConvert.SerializeObject(ht);
            return resultJson;
        }

        /// <summary>
        /// 拼装JSON
        /// </summary>
        static public string GetResultJsonForApi(bool result, string msg, Object data)
        {
            string resultJson = string.Empty;
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("success", result);
                ht.Add("message", msg);
                ht.Add("data", data);
            }
            catch (Exception ex)
            {
                ht.Add("success", false);
                ht.Add("message", ex.Message);
            }
            resultJson = Newtonsoft.Json.JsonConvert.SerializeObject(ht);
            return resultJson;
        }
        #endregion

        #region 图片入库
        /// <summary>
        /// 或去图片byte[]
        /// </summary>
        /// <param name="picDir">图片物理地址</param>
        /// <returns>byte[]</returns>
        static public byte[] GetPhotoByte(string picDir)
        {
            string str = picDir;
            FileStream file = new FileStream(str, FileMode.Open, FileAccess.Read);
            byte[] photo = new byte[file.Length];
            file.Read(photo, 0, photo.Length);
            file.Close();
            return photo;
        }

        #endregion

        /// <summary>
        /// 判断当前页面是否接收到了Post请求
        /// </summary>
        /// <returns>是否接收到了Post请求</returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }

        public static Decimal GetDecimal(string pval, Decimal defval)
        {
            try
            {
                Decimal result = Convert.ToDecimal(DNTRequest.GetString(pval));
                return result;
            }
            catch
            {
                return defval;
            }
        }

        /// <summary>
        /// 判断当前页面是否接收到了Get请求
        /// </summary>
        /// <returns>是否接收到了Get请求</returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        /// <summary>
        /// 返回指定的服务器变量信息
        /// </summary>
        /// <param name="strName">服务器变量名</param>
        /// <returns>服务器变量信息</returns>
        public static string GetServerString(string strName)
        {
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
                return string.Empty;

            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }

        /// <summary>
        /// 返回上一个页面的地址
        /// </summary>
        /// <returns>上一个页面的地址</returns>
        public static string GetUrlReferrer()
        {
            string retVal = null;

            try
            {
                retVal = HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch
            {
            }

            if (retVal == null)
                return string.Empty;

            return retVal;
        }

        /// <summary>
        /// 得到当前完整主机头
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentFullHost()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            if (!request.Url.IsDefaultPort)
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());

            return request.Url.Host;
        }

        /// <summary>
        /// 得到主机头
        /// </summary>
        /// <returns></returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        /// <summary>
        /// 获取当前请求的原始 URL(URL 中域信息之后的部分,包括查询字符串(如果存在))
        /// </summary>
        /// <returns>原始 URL</returns>
        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }

        /// <summary>
        /// 判断当前访问是否来自浏览器软件
        /// </summary>
        /// <returns>当前访问是否来自浏览器软件</returns>
        public static bool IsBrowserGet()
        {
            string[] BrowserName = { "ie", "opera", "netscape", "mozilla", "konqueror", "firefox" };
            string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();
            for (int i = 0; i < BrowserName.Length; i++)
            {
                if (curBrowser.IndexOf(BrowserName[i]) >= 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否来自搜索引擎链接
        /// </summary>
        /// <returns>是否来自搜索引擎链接</returns>
        public static bool IsSearchEnginesGet()
        {
            if (HttpContext.Current.Request.UrlReferrer == null)
                return false;

            string[] SearchEngine = { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom", "yisou", "iask", "soso", "gougou", "zhongsou" };
            string tmpReferrer = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
            for (int i = 0; i < SearchEngine.Length; i++)
            {
                if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获得当前完整Url地址
        /// </summary>
        /// <returns>当前完整Url地址</returns>
        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }

        /// <summary>
        /// 获得指定Url参数的值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <returns>Url参数的值</returns>
        public static string GetQueryString(string strName)
        {
            return GetQueryString(strName, false);
        }

        /// <summary>
        /// 获得指定Url参数的值
        /// </summary> 
        /// <param name="strName">Url参数</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns>Url参数的值</returns>
        public static string GetQueryString(string strName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
                return string.Empty;
            else
            {
                if (sqlSafeCheck && !Utils.IsSafeSqlString(HttpContext.Current.Request.QueryString[strName]))
                {
                    return "unsafe string";
                }
                else
                {
                    return HttpContext.Current.Request.QueryString[strName];
                }
            }
        }

        /// <summary>
        /// 获得当前页面的名称
        /// </summary>
        /// <returns>当前页面的名称</returns>
        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }

        /// <summary>
        /// 返回表单或Url参数的总个数
        /// </summary>
        /// <returns></returns>
        public static int GetParamCount()
        {
            return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
        }

        /// <summary>
        /// 获得指定表单参数的值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <returns>表单参数的值</returns>
        public static string GetFormString(string strName)
        {
            return GetFormString(strName, false);
        }

        /// <summary>
        /// 获得指定表单参数的值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns>表单参数的值</returns>
        public static string GetFormString(string strName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
                return string.Empty;

            if (sqlSafeCheck && !Utils.IsSafeSqlString(HttpContext.Current.Request.Form[strName]))
                return "unsafe string";

            return HttpContext.Current.Request.Form[strName];
        }

        /// <summary>
        /// 获得Url或表单参数的值, 先判断Url参数是否为空字符串, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">参数</param>
        /// <returns>Url或表单参数的值</returns>
        public static string GetString(string strName)
        {
            return GetString(strName, false);
        }

        public static DateTime GetDateTime(string strName, string defVal)
        {
            string datestr = DNTRequest.GetString(strName);
            DateTime tmpdate = DateTime.Now;

            bool issuccess = true;
            try
            {
                tmpdate = Convert.ToDateTime(datestr);
            }
            catch (System.Exception ex)
            {
                string errormsg = ex.Message;
                issuccess = false;
            }

            if (!issuccess)
            {
                try
                {
                    if (defVal != "" || defVal != null)
                    {
                        tmpdate = Convert.ToDateTime(defVal);
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }

            return tmpdate;
        }

        /// <summary>
        /// 获得Url或表单参数的值, 先判断Url参数是否为空字符串, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">参数</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns>Url或表单参数的值</returns>
        public static string GetString(string strName, bool sqlSafeCheck)
        {
            if (string.IsNullOrEmpty(GetQueryString(strName)))
                return GetFormString(strName, sqlSafeCheck);
            else
                return GetQueryString(strName, sqlSafeCheck);
        }

        /// <summary>
        /// 获得指定Url参数的int类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <returns>Url参数的int类型值</returns>
        public static int GetQueryInt(string strName)
        {
            return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], 0);
        }

        /// <summary>
        /// 获得指定Url参数的int类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url参数的int类型值</returns>
        public static int GetQueryInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
        }

        /// <summary>
        /// 获得指定表单参数的int类型值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>表单参数的int类型值</returns>
        public static int GetFormInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// 获得指定Url或表单参数的int类型值, 先判断Url参数是否为缺省值, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">Url或表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url或表单参数的int类型值</returns>
        public static int GetInt(string strName, int defValue)
        {
            if (GetQueryInt(strName, defValue) == defValue)
                return GetFormInt(strName, defValue);
            else
                return GetQueryInt(strName, defValue);
        }

        /// <summary>
        /// 获得指定Url参数的float类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url参数的int类型值</returns>
        public static float GetQueryFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
        }

        /// <summary>
        /// 获得指定表单参数的float类型值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>表单参数的float类型值</returns>
        public static float GetFormFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// 获得指定Url或表单参数的float类型值, 先判断Url参数是否为缺省值, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">Url或表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url或表单参数的int类型值</returns>
        public static float GetFloat(string strName, float defValue)
        {
            if (GetQueryFloat(strName, defValue) == defValue)
                return GetFormFloat(strName, defValue);
            else
                return GetQueryFloat(strName, defValue);
        }

        /// <summary>
        /// 获得当前页面客户端的IP
        /// </summary>
        /// <returns>当前页面客户端的IP</returns>
        public static string GetIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(result) || !Utils.IsIP(result))
                return "127.0.0.1";

            return result;
        }

        /// <summary>
        /// 保存用户上传的文件
        /// </summary>
        /// <param name="path">保存路径</param>
        public static void SaveRequestFile(string path)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                HttpContext.Current.Request.Files[0].SaveAs(path);
            }
        }


        #region 时间戳
        /// <summary>
        /// 获取当前本地时间戳
        /// </summary>   
        static public long GetCurrentTimeUnix
        {
            get
            {
                TimeSpan cha = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)));
                long t = (long)cha.TotalSeconds;
                return t;
            }
        }
        /// <summary>
        /// 时间戳转换为本地时间对象
        /// </summary>
        /// <returns></returns>      
        static public DateTime GetUnixDateTime(long unix)
        {
            //long unix = 1500863191;
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime newTime = dtStart.AddSeconds(unix);
            return newTime;
        }
        #endregion

        #region 图片与base64编码的字符串互转

        /// <summary>
        /// 图片转为base64编码的字符串
        /// </summary>
        /// <param name="imageFileName"></param>
        /// <returns></returns>
        static public string ImageToBase64String(string imageFileName)
        {
            try
            {
                Bitmap bmp = new Bitmap(imageFileName);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// base64编码的字符串转为图片
        /// </summary>
        /// <param name="base64Code">base64字符串</param>
        /// <param name="fileDir">.jpg/.bmp/.gif/.png四种格式的文件物理路径</param>
        /// <param name="filePath">.jpg/.bmp/.gif/.png四种格式的文件绝对路径</param>
        /// <returns></returns>
        static public Bitmap Base64StringToImage(string base64Code, ref string fileDir, ref string filePath)
        {
            try
            {
                string sPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                if (sPath.Substring(sPath.Length - 1, 1) != "\\")
                {
                    sPath += "\\";
                }
                if (!Directory.Exists(sPath + "Temp"))
                {
                    Directory.CreateDirectory(sPath + "Temp");
                }
                string tempName = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                string sFileName = sPath + "Temp\\" + tempName;
                fileDir = sFileName;
                filePath = "/Temp/" + tempName;

                byte[] arr = Convert.FromBase64String(base64Code);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);

                string f1 = sFileName + ".jpg";
                string f2 = sFileName + ".bmp";
                string f3 = sFileName + ".gif";
                string f4 = sFileName + ".png";

                bmp.Save(f1, ImageFormat.Jpeg);
                bmp.Save(f2, ImageFormat.Bmp);
                bmp.Save(f3, ImageFormat.Gif);
                bmp.Save(f4, ImageFormat.Png);
                ms.Close();

                return bmp;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// base64编码的字符串转为图片对象后再转换成byte[]
        /// </summary>
        /// <param name="base64Code">base64字符串</param>
        /// <returns></returns>
        static public byte[] Base64StringToByte(string base64Code, ref string msg, ref string fileName)
        {
            byte[] photo = new byte[0];
            try
            {
                string sPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                if (sPath.Substring(sPath.Length - 1, 1) != "\\")
                {
                    sPath += "\\";
                }
                if (!Directory.Exists(sPath + "Temp"))
                {
                    Directory.CreateDirectory(sPath + "Temp");
                }
                string tempName = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                string sFileName = sPath + "Temp\\" + tempName;

                byte[] arr = Convert.FromBase64String(base64Code);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);

                string f1 = sFileName + ".jpg";
                fileName = tempName + ".jpg";

                bmp.Save(f1, ImageFormat.Jpeg);
                ms.Close();

                FileStream fs = new FileStream(f1, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                photo = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return photo;
        }
        #endregion
    }
}
