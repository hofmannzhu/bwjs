using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace UtilityHelper
{
    class CrossDomainCookie : IHttpModule
    {
        private string m_RootDomain = string.Empty;
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            m_RootDomain = ConfigurationManager.AppSettings["RootDomain"];
           
            Type stateServerSessionProvider = typeof(HttpSessionState).Assembly.GetType("System.Web.SessionState.OutOfProcSessionStateStore");
            FieldInfo uriField = stateServerSessionProvider.GetField("s_uribase", BindingFlags.Static | BindingFlags.NonPublic);

            if (uriField == null)
                throw new ArgumentException("UriField was not found");

            uriField.SetValue(null, m_RootDomain);

            context.EndRequest += new System.EventHandler(context_EndRequest);
        }

        /// <summary>
        /// 从发送给客户端的Cookie集合中找出记录会话ID的Cookie
        /// 并修改它的Domain属性值为要共享的一级域名
        /// </summary>

        void context_EndRequest(object sender, System.EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;

            for (int i = 0; i < app.Context.Response.Cookies.Count; i++)
            {
                //ASP.NET_SessionId是默认的存储会话ID的key，如果修改了默认值这里要修改成一致的
                //if (app.Context.Response.Cookies[i].Name.Equals("ASP.NET_SessionId"))
                //{
                //    app.Context.Response.Cookies[i].Domain = m_RootDomain;
                //    return;
                //}
                app.Context.Response.Cookies[i].Domain = m_RootDomain;
            }
        }
    }
}
