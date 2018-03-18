using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilityHelper
{
    public class RouteHttpModule : IHttpModule
    {

        private string[] Routes = new string[] { "/crm/", "/trade/", "/support/", "/report/", "/doc/" };
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
         }
 
        private void context_BeginRequest(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;

            if (context.Request.UrlReferrer == null)
            {
                // context.Server.Transfer("/crm/error.html");
                return;
            }

            var routeString = GetRouteString(context.Request.UrlReferrer.PathAndQuery);
            if (!string.IsNullOrEmpty(routeString))
            {
                // context.Server.Transfer("/crm/error.html");
                var serverPath = GetRouteString(context.Request.Url.PathAndQuery);
                if (string.IsNullOrEmpty(serverPath))
                {
                    if (context.Request.RequestType == "GET")
                        context.Response.Redirect(string.Format("{0}{1}", routeString, context.Request.Url.PathAndQuery.Substring(1)));
                    else {
                        // if(context.Request.Url.p)
                         
                       context.Server.Execute(string.Format("{0}{1}", routeString, context.Request.Url.PathAndQuery.Substring(1)), true);
                    }
                }
            }

        }

        private string GetRouteString(string path)
        {
            foreach (var route in Routes)
            {
                if (path.StartsWith(route, StringComparison.OrdinalIgnoreCase))
                { 
                    return route;
                }
            }

            return "";
        }
    }
}
