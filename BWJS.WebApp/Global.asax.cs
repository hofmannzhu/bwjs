using BWJS.BLL;
using BWJS.Model;
using BWJSLog.BLL;
using BWJSLog.Model;
using MofangInterface.BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;
using System.Xml.Linq;

namespace BWJS.WebApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_BeginRequest(object source, EventArgs e)
        {
        }

        void Application_Error(object sender, EventArgs e)
        {
            try
            {
                //获取错误信息
                Exception lastError = Server.GetLastError();
                int httpCode = 200;
                HttpException httpError = lastError as HttpException;
                if (httpError != null)
                {
                    //获取错误代码
                    httpCode = httpError.GetHttpCode();
                }
                // 在出现未处理的错误时运行的代码
                Exception objErr = Server.GetLastError().GetBaseException();
                string error = string.Empty;
                string errortime = string.Empty;
                string erroraddr = string.Empty;
                string errorinfo = string.Empty;
                string errorsource = string.Empty;
                string errortrace = string.Empty;
                string errorcode = string.Empty;

                error += "发生时间:" + System.DateTime.Now.ToString() + "<br>";
                errortime = "发生时间:" + System.DateTime.Now.ToString();

                error += "发生异常页: " + Request.Url.ToString() + "<br>";
                erroraddr = "发生异常页: " + Request.Url.ToString();

                error += "返回状态码: " + httpCode + "<br>";
                errorcode = "返回状态码: " + httpCode;

                error += "异常信息: " + objErr.Message + "<br>";
                errorinfo = "异常信息: " + objErr.Message;
                //error +="错误源:"+objErr.Source+"<br>";
                //error += "堆栈信息:" + objErr.StackTrace + "<br>";
                errorsource = "错误源:" + objErr.Source;
                errortrace = "堆栈信息:" + objErr.StackTrace;
                Server.ClearError();
                string msg = errortime + " " + erroraddr + " " + errorcode + " " + errorinfo + " " + errorsource + " " + errortrace;
                ExceptionLogBLL.WriteExceptionLogToDB(msg);

            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
        }

    }
}