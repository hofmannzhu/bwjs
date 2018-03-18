using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Web;

namespace UtilityHelper
{
    public class CompressionModule : IHttpModule
    {
        void IHttpModule.Dispose()

        { }



        void IHttpModule.Init(HttpApplication context)
        {

            context.PreRequestHandlerExecute += new EventHandler(context_PostReleaseRequestState);

        }



        void context_PostReleaseRequestState(object sender, EventArgs e)
        {

            HttpApplication app = (HttpApplication)sender;

            if ((app.Context.CurrentHandler is System.Web.UI.Page || app.Context.CurrentHandler is System.Web.IHttpHandler))
            {

                if (IsEncodingAccepted(GZIP))
                {

                    app.Response.Filter = new GZipStream(app.Response.Filter, CompressionMode.Compress);

                    SetEncoding(GZIP);

                }

                else if (IsEncodingAccepted(DEFLATE))
                {

                    app.Response.Filter = new DeflateStream(app.Response.Filter, CompressionMode.Compress);

                    SetEncoding(DEFLATE);

                }

            }

        }



        private const string GZIP = "gzip";

        private const string DEFLATE = "deflate";



        private static bool IsEncodingAccepted(string encoding)
        {

            HttpContext context = HttpContext.Current;

            return context.Request.Headers["Accept-encoding"] != null && context.Request.Headers["Accept-encoding"].Contains(encoding);

        }



        private static void SetEncoding(string encoding)
        {

            HttpContext.Current.Response.AppendHeader("Content-encoding", encoding);

        }
    }
}