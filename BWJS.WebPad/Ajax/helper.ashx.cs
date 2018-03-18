using BWJS.AppCode;
using BWJS.WebPad.Ajax.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BWJS.WebPad.Ajax
{
    /// <summary>
    /// 帮助类
    /// </summary>
    public class helper : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            BWJSDisptcher.Dispatcher();
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