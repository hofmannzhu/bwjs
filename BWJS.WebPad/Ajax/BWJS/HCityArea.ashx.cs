using BWJS.BLL;
using BWJS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BWJS.WebPad.Ajax.BWJS
{
    /// <summary>
    /// HCityArea 的摘要说明
    /// </summary>
    public class HCityArea : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["Action"];
            switch (action)
            {
                case "GetCityArea":
                    GetCityArea(context);
                    break;
            }
        }


        public void GetCityArea(HttpContext context)
        {
            StringBuilder strCityAreaTree = new StringBuilder();
            strCityAreaTree.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");
            int ParentID = 0;
            CityAreaBLL CityAreabll = new CityAreaBLL();
            List<CityArea> lstCityArea = new List<CityArea>();
            if (!string.IsNullOrEmpty(context.Request.QueryString["ParentID"]))
            {
                ParentID = Convert.ToInt32(context.Request.QueryString["ParentID"]);
            }
            lstCityArea = CityAreabll.GetCityAreaAllList(ParentID);
            foreach (var item in lstCityArea)
            {
                strCityAreaTree.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.Name);
            }

            context.Response.Write(strCityAreaTree);

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