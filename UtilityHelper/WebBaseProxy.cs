using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using System.Net;

namespace UtilityHelper
{
    public abstract class WebBaseProxy
    {
        /// <summary>
        /// 授权签名字段
        /// </summary>
        protected readonly string AuthorizeSignString = "CIPUN";

        /// <summary>
        /// 日至输出函数
        /// </summary>
        public Action<string> LogOutput { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, string> DataBody { get; set; }

        public WebBaseProxy()
        {
            AuthorizeSignString = CommonHelper.GetConfigValue("SyncProxyAuthorizeSign");
            DataBody = new Dictionary<string, string>();
        }

        public virtual void AddBody(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                throw new NullReferenceException("Key 不能为空值！");
            if (!DataBody.ContainsKey(key))
                DataBody.Add(key, value);
        }


        /// <summary>
        /// 创建一个发送的数据提
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, string> BuildDataBody()
        {
            return DataBody;
        }

        /// <summary>
        /// 创建基础地址
        /// </summary>
        /// <returns></returns>
        public virtual string BuildUrl()
        {
            return CommonHelper.GetConfigValue("SyncProxyUrl");
        }

        /// <summary>
        /// 创建签名
        /// </summary>
        /// <returns></returns>
        public virtual string BuildAuthorizeSign(string suffix = "")
        {

            var dataBody = BuildDataBody();
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> k in dataBody.OrderBy(k => k.Key))
            {
                if (sb.Length > 0)
                    sb.Append("&");
                sb.Append(k.Key + "=" + k.Value);
            }

            return CommonHelper.MD5(string.Format("{0}{1}{2}", AuthorizeSignString, sb.ToString().Replace("&", "").Replace("=", ""), suffix), Encoding.UTF8);
        }

        /// <summary>
        /// 创建签名
        /// </summary>
        /// <returns></returns>
        public virtual string BuildAuthorizeSign(Dictionary<string, string> dic, string suffix = "")
        {

            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> k in dic.OrderBy(k => k.Key))
            {
                if (sb.Length > 0)
                    sb.Append("&");
                sb.Append(k.Key + "=" + k.Value);
            }
            return CommonHelper.MD5(string.Format("{0}{1}{2}", AuthorizeSignString, sb.ToString().Replace("&", "").Replace("=", ""), suffix), Encoding.UTF8);
        }


        public virtual WebRequestInfo Execute(bool isPost = false)
        {
            var dataBody = BuildDataBody();
            var url = BuildUrl();

            WebRequestInfo requestInfo = new WebRequestInfo();
            requestInfo.PostData = dataBody;
            requestInfo.RequestUrl = url;

            var httpUtile = new HttpUtils();
            if (isPost)
            {
                requestInfo.Result = httpUtile.DoPost(url, dataBody);
            }
            else
            {
                requestInfo.Result = httpUtile.DoGet(url, dataBody);
            }

            return requestInfo;
        }

        public virtual WebRequestInfo ExecuteAsync(bool isPost = false)
        {
            var dataBody = BuildDataBody();
            var url = BuildUrl();
            var httpUtile = new HttpUtils();
            WebRequestInfo requestInfo = new WebRequestInfo();
            requestInfo.PostData = dataBody;
            requestInfo.RequestUrl = url;
            if (isPost)
            {
                requestInfo.ResponseTask = httpUtile.DoPostAsync(url, dataBody);
            }
            else
            {
                requestInfo.ResponseTask = httpUtile.DoGetAsync(url, dataBody);
            }

            return requestInfo;

        }
    }

    public class WebRequestInfo
    {

        public string UniqueId { get; private set; }

        public string RequestUrl { get; set; }

        public Dictionary<string, string> PostData { get; set; }

        public System.Threading.Tasks.Task<WebResponse> ResponseTask { get; set; }

        public string Result { get; set; }

        public WebRequestInfo()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

    }
}
