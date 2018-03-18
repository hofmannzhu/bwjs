using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BWJS.WebApp.Test
{
    /// <summary>
    /// demoHelper 的摘要说明
    /// </summary>
    public class demoHelper : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

        }
        
        #region 实现

        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}