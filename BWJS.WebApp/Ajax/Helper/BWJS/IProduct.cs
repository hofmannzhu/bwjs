using BWJS.Model;
using BWJS.BLL;
using UtilityHelper;
using BWJS.AppCode;
using MofangInterface.BLL;
using MofangInterface.Model.InputModel;
using MofangInterface.Model.OutputModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BWJSLog.BLL;
using Mofang.Model;
using Mofang.BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BWJS.Model.Model;
using System.Data.SqlClient;
using BWJS.AppCode;

namespace BWJS.WebApp.Ajax.Helper.BWJS
{
    /// <summary>
    /// 网贷产品
    /// </summary>
    public class IProduct
    {
        static string jsonText = string.Empty;

        static public void Implementation(string postJsonText)
        {
            jsonText = postJsonText;
            string action = DNTRequest.GetString("action");
            if (string.IsNullOrEmpty(action))
            {
                action = JsonRequest.GetJsonKeyVal(jsonText, "action");
            }
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "test":
                        //HttpContext.Current.Response.Write(test());
                        break;
                }
            }
        }

    }
}