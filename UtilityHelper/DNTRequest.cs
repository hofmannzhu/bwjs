using System;
using System.Web;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace UtilityHelper
{
    /// <summary>
    /// Request������
    /// </summary>
    public class DNTRequest
    {
        #region ƴװJSON
        /// <summary>
        /// ƴװJSON
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
        /// ƴװJSON
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

        #region ͼƬ���
        /// <summary>
        /// ��ȥͼƬbyte[]
        /// </summary>
        /// <param name="picDir">ͼƬ�����ַ</param>
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
        /// �жϵ�ǰҳ���Ƿ���յ���Post����
        /// </summary>
        /// <returns>�Ƿ���յ���Post����</returns>
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
        /// �жϵ�ǰҳ���Ƿ���յ���Get����
        /// </summary>
        /// <returns>�Ƿ���յ���Get����</returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        /// <summary>
        /// ����ָ���ķ�����������Ϣ
        /// </summary>
        /// <param name="strName">������������</param>
        /// <returns>������������Ϣ</returns>
        public static string GetServerString(string strName)
        {
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
                return string.Empty;

            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }

        /// <summary>
        /// ������һ��ҳ��ĵ�ַ
        /// </summary>
        /// <returns>��һ��ҳ��ĵ�ַ</returns>
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
        /// �õ���ǰ��������ͷ
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
        /// �õ�����ͷ
        /// </summary>
        /// <returns></returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        /// <summary>
        /// ��ȡ��ǰ�����ԭʼ URL(URL ������Ϣ֮��Ĳ���,������ѯ�ַ���(�������))
        /// </summary>
        /// <returns>ԭʼ URL</returns>
        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }

        /// <summary>
        /// �жϵ�ǰ�����Ƿ�������������
        /// </summary>
        /// <returns>��ǰ�����Ƿ�������������</returns>
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
        /// �ж��Ƿ�����������������
        /// </summary>
        /// <returns>�Ƿ�����������������</returns>
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
        /// ��õ�ǰ����Url��ַ
        /// </summary>
        /// <returns>��ǰ����Url��ַ</returns>
        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }

        /// <summary>
        /// ���ָ��Url������ֵ
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <returns>Url������ֵ</returns>
        public static string GetQueryString(string strName)
        {
            return GetQueryString(strName, false);
        }

        /// <summary>
        /// ���ָ��Url������ֵ
        /// </summary> 
        /// <param name="strName">Url����</param>
        /// <param name="sqlSafeCheck">�Ƿ����SQL��ȫ���</param>
        /// <returns>Url������ֵ</returns>
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
        /// ��õ�ǰҳ�������
        /// </summary>
        /// <returns>��ǰҳ�������</returns>
        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }

        /// <summary>
        /// ���ر���Url�������ܸ���
        /// </summary>
        /// <returns></returns>
        public static int GetParamCount()
        {
            return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
        }

        /// <summary>
        /// ���ָ����������ֵ
        /// </summary>
        /// <param name="strName">������</param>
        /// <returns>��������ֵ</returns>
        public static string GetFormString(string strName)
        {
            return GetFormString(strName, false);
        }

        /// <summary>
        /// ���ָ����������ֵ
        /// </summary>
        /// <param name="strName">������</param>
        /// <param name="sqlSafeCheck">�Ƿ����SQL��ȫ���</param>
        /// <returns>��������ֵ</returns>
        public static string GetFormString(string strName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
                return string.Empty;

            if (sqlSafeCheck && !Utils.IsSafeSqlString(HttpContext.Current.Request.Form[strName]))
                return "unsafe string";

            return HttpContext.Current.Request.Form[strName];
        }

        /// <summary>
        /// ���Url���������ֵ, ���ж�Url�����Ƿ�Ϊ���ַ���, ��ΪTrue�򷵻ر�������ֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <returns>Url���������ֵ</returns>
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
        /// ���Url���������ֵ, ���ж�Url�����Ƿ�Ϊ���ַ���, ��ΪTrue�򷵻ر�������ֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <param name="sqlSafeCheck">�Ƿ����SQL��ȫ���</param>
        /// <returns>Url���������ֵ</returns>
        public static string GetString(string strName, bool sqlSafeCheck)
        {
            if (string.IsNullOrEmpty(GetQueryString(strName)))
                return GetFormString(strName, sqlSafeCheck);
            else
                return GetQueryString(strName, sqlSafeCheck);
        }

        /// <summary>
        /// ���ָ��Url������int����ֵ
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <returns>Url������int����ֵ</returns>
        public static int GetQueryInt(string strName)
        {
            return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], 0);
        }

        /// <summary>
        /// ���ָ��Url������int����ֵ
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>Url������int����ֵ</returns>
        public static int GetQueryInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
        }

        /// <summary>
        /// ���ָ����������int����ֵ
        /// </summary>
        /// <param name="strName">������</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>��������int����ֵ</returns>
        public static int GetFormInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// ���ָ��Url���������int����ֵ, ���ж�Url�����Ƿ�Ϊȱʡֵ, ��ΪTrue�򷵻ر�������ֵ
        /// </summary>
        /// <param name="strName">Url�������</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>Url���������int����ֵ</returns>
        public static int GetInt(string strName, int defValue)
        {
            if (GetQueryInt(strName, defValue) == defValue)
                return GetFormInt(strName, defValue);
            else
                return GetQueryInt(strName, defValue);
        }

        /// <summary>
        /// ���ָ��Url������float����ֵ
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>Url������int����ֵ</returns>
        public static float GetQueryFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
        }

        /// <summary>
        /// ���ָ����������float����ֵ
        /// </summary>
        /// <param name="strName">������</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>��������float����ֵ</returns>
        public static float GetFormFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// ���ָ��Url���������float����ֵ, ���ж�Url�����Ƿ�Ϊȱʡֵ, ��ΪTrue�򷵻ر�������ֵ
        /// </summary>
        /// <param name="strName">Url�������</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>Url���������int����ֵ</returns>
        public static float GetFloat(string strName, float defValue)
        {
            if (GetQueryFloat(strName, defValue) == defValue)
                return GetFormFloat(strName, defValue);
            else
                return GetQueryFloat(strName, defValue);
        }

        /// <summary>
        /// ��õ�ǰҳ��ͻ��˵�IP
        /// </summary>
        /// <returns>��ǰҳ��ͻ��˵�IP</returns>
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
        /// �����û��ϴ����ļ�
        /// </summary>
        /// <param name="path">����·��</param>
        public static void SaveRequestFile(string path)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                HttpContext.Current.Request.Files[0].SaveAs(path);
            }
        }


        #region ʱ���
        /// <summary>
        /// ��ȡ��ǰ����ʱ���
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
        /// ʱ���ת��Ϊ����ʱ�����
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

        #region ͼƬ��base64������ַ�����ת

        /// <summary>
        /// ͼƬתΪbase64������ַ���
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
        /// base64������ַ���תΪͼƬ
        /// </summary>
        /// <param name="base64Code">base64�ַ���</param>
        /// <param name="fileDir">.jpg/.bmp/.gif/.png���ָ�ʽ���ļ�����·��</param>
        /// <param name="filePath">.jpg/.bmp/.gif/.png���ָ�ʽ���ļ�����·��</param>
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
        /// base64������ַ���תΪͼƬ�������ת����byte[]
        /// </summary>
        /// <param name="base64Code">base64�ַ���</param>
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
