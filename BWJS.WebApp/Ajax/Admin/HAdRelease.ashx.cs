using BWJS.BLL;
using BWJS.BLL.AdHelper;
using BWJS.Model;
using BWJS.Model.InputModel;
using BWJS.Model.Model;
using BWJS.Model.OutputModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using UtilityHelper;
using System.Data;

namespace BWJS.WebApp.Ajax.Admin
{
    /// <summary>
    /// HAdRelease 的摘要说明
    /// </summary>
    public class HAdRelease : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["Action"];
            if (action == "" || action == null)
            {
                action = context.Request.Form["Action"];
            }

            switch (action)
            {
                case "AdReleaseAddList":
                    AdReleaseAddList(context);
                    break;
                case "GetAdReleaseList":
                    GetAdReleaseList(context);
                    break;
                case "DeleteAdRelease":
                    DeleteAdRelease(context);
                    break;
                case "GetAdReleaseOne":
                    GetAdReleaseOne(context);
                    break;
                case "GetAdPostionReleaseList":
                    GetAdPostionReleaseList(context);
                    break;
                case "AdReleaseRepeat":
                    AdReleaseRepeat(context);
                    break;

            }
        }

        AdReleaseBLL adReleaseIDbll = new AdReleaseBLL();
        public void AdReleaseRepeat(HttpContext context)
        {
            int b = 0;
            string AdReleaseName = "";
            int AdReleaseID = 0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["AdReleaseName"]))
            {
                AdReleaseName = context.Request.QueryString["AdReleaseName"];
            }
            if (!string.IsNullOrEmpty(context.Request.QueryString["AdReleaseID"]))
            {
                AdReleaseID = Convert.ToInt32(context.Request.QueryString["AdReleaseID"]);
            }

            DataSet ds = new DataSet();
            ds = adReleaseIDbll.GetList(" AdReleaseID<>" + AdReleaseID + " and  AdReleaseName='" + AdReleaseName + "'  and RecordIsDelete=0 ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                b = 1;
            }
            context.Response.Write(b);

        }
        public void GetAdPostionReleaseList(HttpContext context)
        {
            int typeId = DNTRequest.GetInt("typeId", 1);
            List<AdPostionReleaseOutputModel> list = new List<AdPostionReleaseOutputModel>();
            List<AdPostionReleaseOutputModel> resultList = new List<AdPostionReleaseOutputModel>();
            AdHelperBLL adHelper = new AdHelperBLL();
            list = adHelper.GetAdPostionReleaseList(typeId);
            if (list != null && list.Count > 0)
            {
                foreach (var o in list)
                {
                    if (!(DateTime.Now >= o.BeginTime && DateTime.Now <= o.EndTime))//不在当前时间内则替换为默认图片
                    {
                        o.FilePath = o.DefaultPicUrl;
                    }
                    resultList.Add(o);
                }
            }
            var b = SerializerHelper.SerializeObject(resultList);
            context.Response.Write(b);
        }

        public void DeleteAdRelease(HttpContext context)
        {
            var AdReleaseID = context.Request.QueryString["AdReleaseID"];
            AdReleaseBLL bll = new AdReleaseBLL();
            bool b = false;
            if (!string.IsNullOrEmpty(AdReleaseID))
            {
                b = bll.UpdateDelete(Convert.ToInt32(AdReleaseID));
            }
            context.Response.Write(b ? "1" : "0");
        }

        public void GetAdReleaseList(HttpContext context)
        {
            AdReleaseBLL usersbll = new AdReleaseBLL();
            List<AdRelease> list = new List<AdRelease>();
            var AdReleaseData = context.Request.QueryString["AdReleaseData"];
            string Where = "a.RecordIsDelete=0";
            if (!string.IsNullOrEmpty(AdReleaseData) && AdReleaseData != "")
            {
                Where += " AND (a.[AdReleaseName] like'" + AdReleaseData + "%') ";
            }
            //list = usersbll.GetModelList(Where);
            DataTable dt = usersbll.GetReleaseExpandL(Where);
            //var b = JsonConvert.SerializeObject(new { data = list });
            var b = SerializerHelper.SerializeObject(new { data = dt });
            context.Response.Write(b);
        }
        public void AdReleaseAddList(HttpContext context)
        {
            int AdReleaseID = 0;
            int AdPositionID = 0;
            int ResourceID = 0;

            if (!string.IsNullOrEmpty(context.Request.Form["AdReleaseID"].ToString()))
            {
                AdReleaseID = Convert.ToInt32(context.Request.Form["AdReleaseID"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request.Form["AdPositionID"].ToString()))
            {
                AdPositionID = Convert.ToInt32(context.Request.Form["AdPositionID"].ToString());
            }

            var objOrder = GetParam("AdReleaseModel", context);
            AdReleaseBackup AdRelease = JsonConvert.DeserializeObject<AdReleaseBackup>(objOrder.ToString());
            AdReleaseBLL AdReleasebll = new AdReleaseBLL();
            //int result = 0;
            ////编辑
            //if (AdReleaseID > 0)
            //{
            //    if (AdRelease.BeginTime.ToString() != "" && AdRelease.EndTime.ToString() != "")
            //    {
            //        //AdRelease.ResourceInfo
            //        //result = AdReleasebll.Update(AdRelease) ? 1 : 0;
            //    }
            //}
            //else {

            if (AdRelease.BeginTime.ToString() != "" && AdRelease.EndTime.ToString() != "")
            {
                string TPath = "";
                byte[] bytes = null;
                string fileName = "";
                HttpFileCollection hfColl = context.Request.Files;
                HttpPostedFile postFile = hfColl["FileLoad1"];
                if (postFile != null)
                {
                    int FileLen;
                    fileName = Path.GetFileName(postFile.FileName);
                    string fPath = "/Resources/";
                    string basePath = HttpContext.Current.Server.MapPath(fPath);
                    // 存储路径规则：基础路径+日期(yyyyMMdd)+主键ID
                    TPath = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                    string fDir = basePath + TPath;
                    // 路径不存在的创建
                    if (!System.IO.Directory.Exists(basePath))
                        System.IO.Directory.CreateDirectory(basePath);

                    if (System.IO.File.Exists(fDir))
                    {
                        System.IO.File.Delete(fDir);
                    }


                    postFile.SaveAs(fDir);
                    FileLen = postFile.ContentLength;
                    bytes = new byte[FileLen];
                }
                else {
                    ResourceID = AdRelease.ResourceID;
                }
                ResourceBLL ResourceAddbll = new ResourceBLL();
                string msg = "";
                bool b = false;

                b = ResourceAddbll.ResourceAdd(ResourceID, AdPositionID, AdRelease, TPath, out msg, bytes, fileName);

                if (b)
                {
                    AdReleaseID = 1;
                }
            }
            ////}
            context.Response.Write(AdReleaseID);
        }
        public void GetAdReleaseOne(HttpContext context)
        {
            var AdReleaseID = context.Request.QueryString["AdReleaseID"];
            AdReleaseBLL bll = new AdReleaseBLL();
            AdRelease a = new AdRelease();
            if (!string.IsNullOrEmpty(AdReleaseID))
            {
                a = bll.GetModelOne(Convert.ToInt32(AdReleaseID));
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