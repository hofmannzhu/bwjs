using BWJS.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Test
{
    public partial class OpCookie : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetTest();
            }
        }

        protected void GetTest()
        {
            string result = string.Empty;
            string sskdModel = string.Empty;

            result += string.Format("sskdModel={0}<br />", Newtonsoft.Json.JsonConvert.SerializeObject(sskdModel));

            if (HttpContext.Current.Request.Cookies["bwjsCookie20180106"] != null)
            {
                Utils.DelCoookie("bwjsCookie20180106");
            }
            else
            {
                Utils.WriteCookie("bwjsCookie20180106", "token", "1000", 2);
                Utils.WriteCookie("bwjsCookie20180106", "consultId", "b938b7e4-d50e-49b7-af98-08a090322189", 2);
            }

            string consultId = Utils.GetCookie("bwjsCookie20180106", "token");
            string token = Utils.GetCookie("bwjsCookie20180106", "consultId");

            result += string.Format("consultId={0}<br />", consultId);
            result += string.Format("token={0}<br />", token);

            Response.Write(result);
        }

        protected void btnClearCookie_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();

            Utils.DelCoookie("bwjsCookie20180106");

            GetTest();
        }
    }
}