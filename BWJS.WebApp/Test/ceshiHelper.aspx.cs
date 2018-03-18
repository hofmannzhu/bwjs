using MofangInterface.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

namespace BWJS.WebApp.Test
{
    public partial class ceshiHelper1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
        }
        public void ProcessRequest()
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            //UpFile();

            string msg = string.Empty;
            msg += "Form=";
            for (int i = 0; i < System.Web.HttpContext.Current.Request.Form.Count; i++)
            {
                msg += System.Web.HttpContext.Current.Request.Form[i] + ",";
            }
            msg += "<br />|QueryString=";
            for (int i = 0; i < System.Web.HttpContext.Current.Request.QueryString.Count; i++)
            {
                msg += System.Web.HttpContext.Current.Request.QueryString[i] + ",";
            }

            msg += "<br />|jsonText=";
            byte[] reqData = HttpContext.Current.Request.BinaryRead(HttpContext.Current.Request.TotalBytes);
            msg += Encoding.Default.GetString(reqData);

            HttpContext.Current.Response.Write(msg);
        }
    }
}