using BWJS.BLL;
using BWJS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using UtilityHelper;

namespace BWJS.WebApp.Ajax.Admin
{
    /// <summary>
    /// HAdPosition 的摘要说明
    /// </summary>
    public class HAdPosition : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = GetParam("Action", context);
            switch (action)
            {
                case "AdPositionAddList":
                    AdPositionAddList(context);
                    break;
                case "GetAdPositionList":
                    GetAdPositionList(context);
                    break;
                case "DeleteAdPosition":
                    DeleteAdPosition(context);
                    break;
                case "GetAdPositionOne":
                    GetAdPositionOne(context);
                    break;
                case "GetAdPositionName":
                    GetAdPositionName(context);
                    break;
                case "GetMaxSort":
                    GetMaxSort(context);
                    break;

                case "GetSeleSort":
                    GetSeleSort(context);
                    break;

                case "ChangeSort":
                    ChangeSort(context);
                    break;
                case "VerificationIsName":
                    VerificationIsName(context);
                    break;


            }
        }


        public void VerificationIsName(HttpContext context)
        {
            int AdPositionID = 0;
            var Name = context.Request.QueryString["Name"];
            if (!string.IsNullOrEmpty(context.Request.QueryString["AdPositionID"]))
            {
                AdPositionID = Convert.ToInt32(context.Request.QueryString["AdPositionID"]);
            }

            AdPositionBLL AdPositionbll = new AdPositionBLL();
            if (!string.IsNullOrEmpty(Name))
            {
                AdPositionID = AdPositionbll.VerificationIsName(Name, AdPositionID);
            }
            context.Response.Write(AdPositionID);
        }

        public void ChangeSort(HttpContext context)
        {
            int Sort = 0;
            int AdPositionID = 0;
            bool b = false;
            if (GetParam("Sort", context) != "")
            {
                Sort = Convert.ToInt32(GetParam("Sort", context));
            }
            if (GetParam("AdPositionID", context) != "")
            {
                AdPositionID = Convert.ToInt32(GetParam("AdPositionID", context));
            }
            AdPositionBLL AdPositionbll = new AdPositionBLL();
            b = AdPositionbll.ChangeSort(AdPositionID, Sort);
            context.Response.Write(b);
        }

        public void GetSeleSort(HttpContext context)
        {
            StringBuilder strAdPositionName = new StringBuilder();
            strAdPositionName.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");
            string Where = "RecordIsDelete=0";
            AdPositionBLL CityAreabll = new AdPositionBLL();
            List<AdPosition> lstAdPosition = new List<AdPosition>();
            lstAdPosition = CityAreabll.GetModelList(Where);
            foreach (var item in lstAdPosition)
            {
                if (item.AdReleaseID == 0)
                {
                    strAdPositionName.AppendFormat("  <option value=\"{0}\">{1}</option>", item.Sort.ToString(), item.Sort);
                }

            }

            context.Response.Write(strAdPositionName);

        }
        public void GetMaxSort(HttpContext context)
        {
            int SortData = 0;
            AdPositionBLL AdPositionbll = new AdPositionBLL();
            SortData = AdPositionbll.GetMaxSort();
            context.Response.Write(SortData);

        }
        public void DeleteAdPosition(HttpContext context)
        {
            var AdPositionID = context.Request.QueryString["AdPositionID"];
            AdPositionBLL bll = new AdPositionBLL();
            bool b = false;
            if (!string.IsNullOrEmpty(AdPositionID))
            {
                b = bll.UpdateDelete(Convert.ToInt32(AdPositionID));
            }
            context.Response.Write(b ? "1" : "0");
        }

        public void GetAdPositionList(HttpContext context)
        {
            AdPositionBLL AdPositionbll = new AdPositionBLL();
            List<AdPosition> list = new List<AdPosition>();
            var AdPositionData = context.Request.QueryString["AdPositionData"];
            string Where = "ap.RecordIsDelete=0";
            if (!string.IsNullOrEmpty(AdPositionData) && AdPositionData != "")
            {
                Where += " AND (ap.Name like'" + AdPositionData + "%') ";
            }
            list = AdPositionbll.GetNameModelList(Where);
            var b = SerializerHelper.SerializeObject(new { data = list });
            context.Response.Write(b);
        }


        public void GetAdPositionName(HttpContext context)
        {
            int AdReleaseID = 0;
            AdPositionBLL bll = new AdPositionBLL();
            if (!string.IsNullOrEmpty(context.Request.QueryString["AdReleaseID"]))
            {
                AdReleaseID = Convert.ToInt32(context.Request.QueryString["AdReleaseID"]);
            }

            StringBuilder strAdPositionName = new StringBuilder();
            strAdPositionName.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");
            string Where = "RecordIsDelete=0 And ( AdReleaseID=" + AdReleaseID + " OR (AdReleaseID is NULL) OR AdReleaseID=0  )";
            AdPositionBLL CityAreabll = new AdPositionBLL();
            List<AdPosition> lstAdPosition = new List<AdPosition>();
            lstAdPosition = CityAreabll.GetModelList(Where);
            foreach (var item in lstAdPosition)
            {
                strAdPositionName.AppendFormat("  <option value=\"{0}\">{1}</option>", item.AdPositionID.ToString(), item.Name);
            }

            context.Response.Write(strAdPositionName);

        }

        public void AdPositionAddList(HttpContext context)
        {
            int AdPositionID = 0;
            if (!string.IsNullOrEmpty(GetParam("AdPositionID", context).ToString()))
            {
                AdPositionID = Convert.ToInt32(GetParam("AdPositionID", context).ToString());
            }
            string objOrder = GetParam("adpositionModel", context);
            AdPosition adposition = JsonConvert.DeserializeObject<AdPosition>(objOrder);
            AdPositionBLL adPositionbll = new AdPositionBLL();
            int result = 0;

            if (adposition.Name != "")
            {
                HttpFileCollection hfColl = context.Request.Files;
                HttpPostedFile postFile = hfColl["FileLoad1"];
                if (postFile != null)
                {
                    string fileName = Path.GetFileName(postFile.FileName);
                    string fPath = "/Resources/";
                    string TPath = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                    string filePath = fPath + TPath;
                    string basePath = HttpContext.Current.Server.MapPath(fPath);
                    string fDir = basePath + TPath;
                    // 路径不存在的创建
                    if (!System.IO.Directory.Exists(basePath))
                        System.IO.Directory.CreateDirectory(basePath);

                    if (System.IO.File.Exists(fDir))
                        System.IO.File.Delete(fDir);


                    postFile.SaveAs(fDir);
                    adposition.DefaultPicUrl = filePath;
                }
                else {
                    string DefaultPicUrl = GetParam("hidDefaultPicUrl", context);
                    adposition.DefaultPicUrl = DefaultPicUrl;
                }
                if (AdPositionID > 0)
                {
                    AdPosition oAdPosition= adPositionbll.GetModel(AdPositionID);
                    oAdPosition.Name = adposition.Name;
                    oAdPosition.Sort = adposition.Sort;
                    oAdPosition.DefaultPicUrl = adposition.DefaultPicUrl;
                    //编辑
                    result = adPositionbll.Update(oAdPosition) ? 1 : 0;
                    //adPositionbll.BackUpdate(adposition.AdReleaseID);
                }
                else {
                    result = adPositionbll.Add(adposition);
                }

            }
            context.Response.Write(result);
        }



        public void GetAdPositionOne(HttpContext context)
        {
            var AdPositionID = context.Request.QueryString["AdPositionID"];
            AdPositionBLL bll = new AdPositionBLL();
            AdPosition a = new AdPosition();
            if (!string.IsNullOrEmpty(AdPositionID))
            {
                a = bll.GetModel(Convert.ToInt32(AdPositionID));
            }

            context.Response.Write(SerializerHelper.SerializeObject(a));
        }
        private string GetParam(string name, HttpContext context)
        {

            string value = context.Request.QueryString[name] ?? context.Request.Form[name];
            return string.IsNullOrEmpty(value) ? "" : value.Trim();
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