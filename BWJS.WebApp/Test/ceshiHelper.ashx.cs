using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MofangInterface.BLL;
using System.Text;
using UtilityHelper;

namespace BWJS.WebApp.Test
{
    /// <summary>
    /// ceshiHelper 的摘要说明
    /// </summary>
    public class ceshiHelper : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            //UpFile();

            //BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
            //string res = baoxianDataBLL.GetLocationInfo();
            ////msg = msg + "<br />res=" + res;
            //context.Response.Write(res);

            string msg = string.Empty;
            msg += "Form=";
            for (int i = 0; i < System.Web.HttpContext.Current.Request.Form.Count; i++)
            {
                msg += System.Web.HttpContext.Current.Request.Form[i] + ",";
            }
            msg += "|QueryString=";
            for (int i = 0; i < System.Web.HttpContext.Current.Request.QueryString.Count; i++)
            {
                msg += System.Web.HttpContext.Current.Request.QueryString[i] + ",";
            }
            msg += "|jsonText=";
            System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
            System.Web.HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
            byte[] reqData = System.Web.HttpContext.Current.Request.BinaryRead(System.Web.HttpContext.Current.Request.TotalBytes);
            msg += Encoding.Default.GetString(reqData);
            msg += "iDisplayStart=" + DNTRequest.GetString("iDisplayStart");
            msg += "iDisplayLength=" + DNTRequest.GetString("iDisplayLength");
            msg += "iDisplayLength=" + HttpContext.Current.Request.Params["iDisplayStart"];
            msg += "iDisplayLength=" + HttpContext.Current.Request.Params["iDisplayLength"];

        }

        public void UpFile()
        {
            System.Web.HttpFileCollection _file = System.Web.HttpContext.Current.Request.Files;
            if (_file.Count > 0)
            {
                //文件大小  
                long size = _file[0].ContentLength;
                //文件类型  
                string type = _file[0].ContentType;
                //文件名  
                string name = _file[0].FileName;
                //文件格式  
                string _tp = System.IO.Path.GetExtension(name);

                //if (_tp.ToLower() == ".jpg" || _tp.ToLower() == ".jpeg" || _tp.ToLower() == ".gif" || _tp.ToLower() == ".png" || _tp.ToLower() == ".swf")
                //{
                    //获取文件流  
                    System.IO.Stream stream = _file[0].InputStream;
                    //保存文件  
                    string saveName = DateTime.Now.ToString("yyyyMMddHHmmss") + _tp;
                    string path = HttpContext.Current.Server.MapPath("/Test/temp/");
                    if (!Directory.Exists(path)) {
                        Directory.CreateDirectory(path);
                    }
                    _file[0].SaveAs(path+saveName);
                //}
            }
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