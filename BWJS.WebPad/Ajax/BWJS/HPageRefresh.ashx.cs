﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BWJS.WebPad.Ajax.BWJS
{
    /// <summary>
    /// HPageRefresh 的摘要说明
    /// </summary>
    public class HPageRefresh : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("OnLine");
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