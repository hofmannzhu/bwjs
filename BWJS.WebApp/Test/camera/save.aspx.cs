using BWJS.AppCode;
using UtilityHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace BWJS.WebApp.Test.camera
{
    public partial class save : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string data = DNTRequest.GetString("data");
                if (!string.IsNullOrEmpty(data))
                {
                    Log.WriteLog(data, "data", "|");
                }
                else
                {
                    string content;
                    string sPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                    if (sPath.Substring(sPath.Length - 1, 1) != "\\")
                    {
                        sPath += "\\";
                    }
                    if (!Directory.Exists(sPath + "\\log"))
                    {
                        Directory.CreateDirectory(sPath + "\\log");
                    }

                    string sFileName = sPath + "\\log\\" + "data" + System.DateTime.Today.ToString("yyyyMMdd") + ".log";
                    string result = string.Empty;
                    if (File.Exists(sFileName))
                    {
                        using (StreamReader sr = new StreamReader(sFileName))
                        {
                            content = sr.ReadToEnd();
                        }
                        if (!string.IsNullOrEmpty(content))
                        {
                            string[] list = content.Split(new char[] { '|' });
                            if (list.Length > 0)
                            {
                                foreach (string src in list)
                                {
                                    if (!string.IsNullOrEmpty(src))
                                    {
                                        result += "<img style=\"width: 96px; height: 118px;\" src=\"" + "data:image/jpeg;base64," + src + "\" />";
                                    }
                                }
                            }
                        }
                    }
                    Response.Write(result);
                }
            }
            catch (Exception ex) {
                Log.WriteLog(ex.ToString());
            }
        }
    }
}