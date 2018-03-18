using MofangInterface.Model.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Test
{
    public partial class CfsA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            HealthNotifyQuesReq model = new HealthNotifyQuesReq();
            model.transNo = "sn200711203";
            model.customkey = "bwjs";
            model.caseCode = "10005";
            model.priceArgsId = "2001";
            string strJson = SerializerHelper.ToJson(model);
            string url = "http://localhost:7173/Test/cfs/cfsb";
            string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, strJson);
        }
    }
}