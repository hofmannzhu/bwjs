using BWJS.BLL;
using BWJS.Model;
using BWJSLog.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using UtilityHelper;
using BWJS.AppCode;

namespace BWJS.WebApp.Ajax.Admin
{
    /// <summary>
    /// HCompany 的摘要说明
    /// </summary>
    public class HCompany : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = DNTRequest.GetString("Action"); 
            switch (action)
            {
                case "GetCompanyCategory":
                    HttpContext.Current.Response.Write(GetCompanyCategory(context));
                    break;
                case "AddCompany":
                    AddCompany(context); 
                    break;
                case "DeleteCompany":
                    DeleteCompany(context); 
                    break;
                case "GetCompanyOne":
                    GetCompanyOne(context);
                    break;
                    
            }
        }

        public void GetCompanyOne(HttpContext context) {
            var CompanyId = context.Request.QueryString["CompanyId"];
            CompanyBLL bll = new CompanyBLL();
            Company u = new Company();
            if (!string.IsNullOrEmpty(CompanyId))
            {
                u = bll.GetModel(Convert.ToInt32(CompanyId));
            }

            context.Response.Write(SerializerHelper.SerializeObject(u));
        }


        public void DeleteCompany(HttpContext context)
        {
            string result = string.Empty;
            try
            {
                var CompanyId = DNTRequest.GetString("CompanyId");
                if (string.IsNullOrEmpty(CompanyId))
                {
                    result = DNTRequest.GetResultJson(false, "请先选择一条数据", null);
                    return;
                }
                else
                {
                    CompanyBLL companybll = new CompanyBLL();
                    Company modelMachine = new Company();
                    bool res = companybll.Delete(Convert.ToInt32(CompanyId),ComPage.CurrentUser.UserID);
                    if (res)
                    {
                        result = DNTRequest.GetResultJson(true, "删除渠道成功", null);
                    }
                    else
                    {
                        result = DNTRequest.GetResultJson(false, "删除渠道失败，请稍后再试", null);
                    }
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "删除渠道异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            context.Response.Write(result);

        }

        public void AddCompany(HttpContext context)
        {
            int CompanyId = 0;
            if (!string.IsNullOrEmpty(DNTRequest.GetString("CompanyId")))
            {
                CompanyId = Convert.ToInt32(DNTRequest.GetString("CompanyId"));
            }

            string objOrder = GetParam("CompanyModel", context);
            Company company = JsonConvert.DeserializeObject<Company>(objOrder);
            CompanyBLL companybll = new CompanyBLL();

          //保存数据
            HttpFileCollection hfColl = context.Request.Files;
            HttpPostedFile postFile = hfColl["FileLoad1"];
            HttpPostedFile postFile2 = hfColl["FileLoad2"];
            if (postFile2!=null)
            {
                string fPath = "";
                if (company.CompanyCategoryId == 1)
                {
                    fPath = "/Content/img/Mofang/";
                }
                if (company.CompanyCategoryId == 2)
                {
                    fPath = "/Content/img/NetLoan/";
                }
                if (company.CompanyCategoryId == 3)
                {
                    fPath = "/Content/img/Bank/";
                }
                if (company.CompanyCategoryId == 4)
                {
                    fPath = "/Content/img/CreditCard/";
                }
                if (company.CompanyCategoryId == 5)
                {
                    fPath = "/Content/img/Other/";
                }
                string fileName = Path.GetFileName(postFile2.FileName);

                string TPath = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                string filePath = fPath + TPath;
                string basePath = HttpContext.Current.Server.MapPath(fPath);
                string fDir = basePath + TPath;
                // 路径不存在的创建
                if (!System.IO.Directory.Exists(basePath))
                    System.IO.Directory.CreateDirectory(basePath);

                if (System.IO.File.Exists(fDir))
                    System.IO.File.Delete(fDir);
                postFile2.SaveAs(fDir);
                company.Logo = filePath;
            }
            if (postFile != null)
            {
                string fPath = "";
                if (company.CompanyCategoryId == 1)
                {
                    fPath = "/Content/img/Mofang/";
                }
                if (company.CompanyCategoryId == 2)
                {
                    fPath = "/Content/img/NetLoan/";
                }
                if (company.CompanyCategoryId == 3)
                {
                    fPath = "/Content/img/Bank/";
                }
                if (company.CompanyCategoryId == 4)
                {
                    fPath = "/Content/img/CreditCard/";
                }
                if (company.CompanyCategoryId == 5)
                {
                    fPath = "/Content/img/Other/";
                }
                string fileName = Path.GetFileName(postFile.FileName);
            
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
                company.QRCode = filePath;
            }
                int result = 0;
            //编辑
            if (CompanyId > 0)
            {
                result = companybll.Update(company) ? 1 : 0;
            }
            else {
                result = companybll.Add(company);
            }
            context.Response.Write(result);
        }
        private string GetParam(string name, HttpContext context)
        {

            string value = context.Request.QueryString[name] ?? context.Request.Form[name];
            return string.IsNullOrEmpty(value) ? "" : value.Trim();
        }
        public Object GetCompanyCategory(HttpContext context)
        {
            string result = string.Empty;
            try
            {
                CompanyCategoryBLL ccb = new CompanyCategoryBLL();
                List<CompanyCategory> list = new List<CompanyCategory>();
                StringBuilder where = new StringBuilder();
                where.AppendFormat(" 1=1 and IsDeleted=0");

                list = ccb.GetModelList(where.ToString());
                result = DNTRequest.GetResultJson(true, "success", list);

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取渠道列表，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
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