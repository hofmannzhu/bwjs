using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace UtilityHelper
{
    public class HttpService
    {
        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }

        public static string Post(string url, string jsondata)
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            string paraUrlCoded = jsondata;
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;



        }

        #region 模拟请求RestSharp

        /// <summary>
        /// 向远程地址POST传递数据并获得响应
        /// </summary>
        /// <param name="url">远程地址</param>
        /// <param name="postDataStr">参数字符串</param>
        /// <returns></returns>
        static public string GetHttpWebResponseByRestSharp(string url, string postDataStr)
        {
            string result = string.Empty;
            IRestResponse<Object> response = null;
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("postman-token", "553c3271-f497-c99f-cfa6-2665c8c1036a");
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", postDataStr, ParameterType.RequestBody);
                //string result = client.Execute(request)
                response = client.Execute<Object>(request);
                //if (response.StatusCode == HttpStatusCode.OK)
                //{
                result = response.Content;
                //}
                //else
                //{
                //    result = string.Format("{\"respstat\": \"{0}\",\"respmsg\": \"{1}\"}", response.StatusCode, response.Content);
                //}
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
            }
            return result;
        }

        /// <summary>
        /// 向远程地址POST传递数据并获得响应
        /// </summary>
        /// <param name="url">远程地址</param>
        /// <param name="postDataStr">参数字符串</param>
        /// <returns></returns>
        static public string GetHttpWebResponseByRestSharp(string url, string postDataStr, string contentType)
        {
            string result = string.Empty;
            IRestResponse<Object> response = null;
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("postman-token", "553c3271-f497-c99f-cfa6-2665c8c1036a");
                request.AddHeader("cache-control", "no-cache");
                if (!string.IsNullOrEmpty(contentType))
                {
                    request.AddHeader("Content-Type", contentType);
                }
                request.AddParameter("application/x-www-form-urlencoded", postDataStr, ParameterType.RequestBody);
                //string result = client.Execute(request)
                response = client.Execute<Object>(request);
                //if (response.StatusCode == HttpStatusCode.OK)
                //{
                result = response.Content;
                //}
                //else
                //{
                //    result = string.Format("{\"respstat\": \"{0}\",\"respmsg\": \"{1}\"}", response.StatusCode, response.Content);
                //}
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
            }
            return result;
        }

        /// <summary>
        /// 向远程地址POST传递数据并获得响应
        /// </summary>
        /// <param name="url">远程地址</param>
        /// <param name="postDataStr">参数字符串</param>
        /// <returns></returns>
        static public string GetHttpWebResponseByRestSharpAddCookie(string url, string postDataStr, string cookieKey, string cookieValue)
        {
            string result = string.Empty;
            IRestResponse<Object> response = null;
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", postDataStr, ParameterType.RequestBody);
                request.AddCookie(cookieKey, cookieValue);
                //string result = client.Execute(request)
                response = client.Execute<Object>(request);
                //if (response.StatusCode == HttpStatusCode.OK)
                //{
                result = response.Content;
                //}
                //else
                //{
                //    result = string.Format("{\"respstat\": \"{0}\",\"respmsg\": \"{1}\"}", response.StatusCode, response.Content);
                //}
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
            }
            return result;
        }

        static public string GetHttpWebResponseByRestSharpAddCookieAndByte(string url, string postDataStr, byte[] photoData, string cookieKey, string cookieValue)
        {
            string result = string.Empty;
            IRestResponse<Object> response = null;
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", postDataStr, ParameterType.RequestBody);
                request.AddCookie(cookieKey, cookieValue);
                request.AddFileBytes("file", photoData, "upbytes");
                //string result = client.Execute(request)
                response = client.Execute<Object>(request);
                //if (response.StatusCode == HttpStatusCode.OK)
                //{
                result = response.Content;
                //}
                //else
                //{
                //    result = string.Format("{\"respstat\": \"{0}\",\"respmsg\": \"{1}\"}", response.StatusCode, response.Content);
                //}
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
            }
            return result;
        }

        static public string GetHttpWebResponseByRestSharpAddCookieAndByteForUpload(string url, string postDataStr, byte[] photoData, string cookieKey, string cookieValue, string fileName, string contentType)
        {
            string result = string.Empty;
            IRestResponse<Object> response = null;
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                //request.AddHeader("content-type", "application/json");
                //request.AddParameter("application/json", postDataStr, ParameterType.RequestBody);
                request.AddCookie(cookieKey, cookieValue);
                request.AddFileBytes("file", photoData, fileName, contentType);
                //string result = client.Execute(request)
                response = client.Execute<Object>(request);
                //if (response.StatusCode == HttpStatusCode.OK)
                //{
                result = response.Content;
                //}
                //else
                //{
                //    result = string.Format("{\"respstat\": \"{0}\",\"respmsg\": \"{1}\"}", response.StatusCode, response.Content);
                //}
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
            }
            return result;
        }

        #endregion

        #region 模拟请求

        /// <summary>
        /// 获取远程页面内容
        /// </summary>
        static public string GetHttpWebResponse20170911(string url, string postParamters)
        {
            string result = string.Empty;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream writer = null;
            try
            {
                System.Net.ServicePointManager.DefaultConnectionLimit = 200;//默认2
                System.GC.Collect();

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 50000;
                request.AllowAutoRedirect = false;
                request.AllowWriteStreamBuffering = false;

                //request.KeepAlive = false;
                //request.UserAgent = "";

                //request.Accept = "text/plain";
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";

                byte[] payload;
                payload = Encoding.UTF8.GetBytes(postParamters);
                request.ContentLength = payload.Length;

                writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();

                response = (HttpWebResponse)request.GetResponse();
                //if (response.StatusCode == HttpStatusCode.OK && response.ContentLength < int.MaxValue)
                //{
                reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
                result = reader.ReadToEnd();
                //}
            }
            catch (WebException ex)
            {
                result = ex.Message.ToString();
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                }
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (request != null)
                {
                    request = null;
                }
            }
            return result;
        }

        static public string GetHttpWebResponse(string url, string postString)
        {
            string result = string.Empty;
            try
            {
                byte[] postData = Encoding.UTF8.GetBytes(postString.ToString());
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可  
                byte[] responseData = webClient.UploadData(url, "POST", postData);//得到返回字符流  
                result = Encoding.UTF8.GetString(responseData);//解码
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }

        /// <summary>
        /// 向远程地址传递数据并获得响应
        /// </summary>
        /// <param name="url">远程地址</param>
        /// <param name="postParamters">参数字符串</param>
        /// <param name="postMethod">POST/GET</param>
        /// <returns>返回消息</returns>
        static public string GetHttpWebResponse(string url, string postParamters, string contentType, string postMethod)
        {
            string result = string.Empty;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader Reader = null;
            Stream s = null;
            Stream writer = null;
            try
            {
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                //System.Net.ServicePointManager.DefaultConnectionLimit = 200;//默认2
                //System.GC.Collect();

                string strURL = url;
                request = (HttpWebRequest)WebRequest.Create(strURL);

                //request.KeepAlive = false;
                request.Timeout = 600000;
                request.AllowAutoRedirect = false;

                request.Method = postMethod;
                request.ContentType = contentType;
                byte[] payload;
                payload = Encoding.UTF8.GetBytes(postParamters);
                request.ContentLength = payload.Length;

                writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();

                response = (HttpWebResponse)request.GetResponse();
                s = response.GetResponseStream();

                Reader = new StreamReader(s, System.Text.Encoding.UTF8);
                result = Reader.ReadLine();
            }
            catch (System.Net.ProtocolViolationException ex)
            {
                request.Abort();
            }
            catch (System.Net.WebException ex)
            {
                request.Abort();
            }
            catch (System.ObjectDisposedException ex)
            {
                request.Abort();
            }
            catch (System.InvalidOperationException ex)
            {
                request.Abort();
            }
            catch (System.NotSupportedException ex)
            {
                request.Abort();
            }
            catch (Exception ex)
            {
                request.Abort();
                result = ex.Message;
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                }
                if (response != null)
                    response.Close();
                if (Reader != null)
                    Reader.Close();
                if (s != null)
                    s.Close();
                if (writer != null)
                    writer.Close();
            }
            return result;
        }

        #region 模拟请求2


        static public string HttpPost(string url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            //request.CookieContainer = cookie;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("utf-8"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //response.Cookies = cookie.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        static public string HttpGet(string url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        static public string btnPost_Click(string url, string postParamters, string postMethod)
        {

            string result = string.Empty;
            try
            {
                byte[] postData = Encoding.UTF8.GetBytes(postParamters.ToString());//编码，尤其是汉字，事先要看下抓取网页的编码方式  
                WebClient webClient = new WebClient();
                if (postMethod.ToLower() == "post")
                {
                    webClient.Headers.Add("Content-Type", "application/json;charset=UTF-8");//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可   
                }
                byte[] responseData = webClient.UploadData(url, postMethod, postData);//得到返回字符流  
                result = Encoding.UTF8.GetString(responseData);//解码
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }

        static public string HttpPostData(string url, int timeOut, string fileKeyName, string filePath, NameValueCollection stringDict)
        {
            string responseContent;
            var memStream = new MemoryStream();
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            // 边界符  
            var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
            // 边界符  
            var beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            // 最后的结束符  
            var endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");

            // 设置属性  
            webRequest.Method = "POST";
            webRequest.Timeout = timeOut;
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;

            // 写入文件  
            const string filePartHeader =
                "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                 "Content-Type: application/octet-stream\r\n\r\n";
            var header = string.Format(filePartHeader, fileKeyName, filePath);
            var headerbytes = Encoding.UTF8.GetBytes(header);

            memStream.Write(beginBoundary, 0, beginBoundary.Length);
            memStream.Write(headerbytes, 0, headerbytes.Length);

            var buffer = new byte[1024];
            int bytesRead; // =0  

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                memStream.Write(buffer, 0, bytesRead);
            }

            // 写入字符串的Key  
            var stringKeyHeader = "\r\n--" + boundary +
                                   "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                                   "\r\n\r\n{1}\r\n";

            foreach (byte[] formitembytes in from string key in stringDict.Keys
                                             select string.Format(stringKeyHeader, key, stringDict[key])
                                                 into formitem
                                             select Encoding.UTF8.GetBytes(formitem))
            {
                memStream.Write(formitembytes, 0, formitembytes.Length);
            }

            // 写入最后的结束边界符  
            memStream.Write(endBoundary, 0, endBoundary.Length);

            webRequest.ContentLength = memStream.Length;

            var requestStream = webRequest.GetRequestStream();

            memStream.Position = 0;
            var tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();

            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();

            var httpWebResponse = (HttpWebResponse)webRequest.GetResponse();

            using (var httpStreamReader = new StreamReader(httpWebResponse.GetResponseStream(),
                                                            Encoding.GetEncoding("utf-8")))
            {
                responseContent = httpStreamReader.ReadToEnd();
            }

            fileStream.Close();
            httpWebResponse.Close();
            webRequest.Abort();

            return responseContent;
        }


        #endregion

        #endregion

        public static string PostTwo(string paramData, string postUrl, bool isHttps)
        {
            if (isHttps)
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            }
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(postUrl);
            Encoding encoding = Encoding.UTF8;
            string param = paramData;//"rule=11111111&proxyid=ruleliu1&proxye=true";
            //encoding.GetBytes(postData);  
            byte[] bs = Encoding.ASCII.GetBytes(param);
            string responseData = String.Empty;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;
            if (isHttps)
            {
                req.UserAgent = DefaultUserAgent;
            }
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
            }
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    responseData = reader.ReadToEnd().ToString();
                }
                return responseData;
            }
        }


        public static string CreatePostHttpResponse(string url, IDictionary<string, string> parameters, Encoding charset)
        {
            HttpWebRequest request = null;
            //HTTPSQ请求  
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = DefaultUserAgent;
            //如果需要POST数据     
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = charset.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            string html = "";
            using (Stream streamresponse = request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(streamresponse)) //创建一个stream读取流  
                    html = sr.ReadToEnd();   //从头读到尾，放到字符串html  
            }   //获取响应的字符串流  

            return html;
        }

        public static string Get(string url, bool isHttps)
        {
            string result = "";

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            if (isHttps)
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            }

            try
            {
                ServicePointManager.DefaultConnectionLimit = 200;
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {
                throw new WebException(e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }
    }
}
