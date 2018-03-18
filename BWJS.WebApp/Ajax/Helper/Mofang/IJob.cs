using MofangInterface.BLL;
using MofangInterface.Model.InputModel;
using MofangInterface.Model.OutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using UtilityHelper;

namespace BWJS.WebApp.Ajax.Helper.Mofang
{
    /// <summary>
    /// 调度实现
    /// </summary>
    [DataContract]
    public class IJob
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
                #region 实现

                switch (action)
                {
                    case "getJobInfo":
                        HttpContext.Current.Response.Write(GetJobInfo());
                        break;
                }

                #endregion
            }
        }
        /// <summary>
        /// 获取承保人职业列表
        /// </summary>
        /// <param name="oJobInfoResp"></param>
        /// <returns></returns>
        static public Object GetJobInfo()
        {
            string result = string.Empty;
            string cacheKey = string.Empty;
            try
            {
                BaoxianDataBLL oBaoxianDataBLL = new BaoxianDataBLL();
                JobInfoReq oJobInfoReq = new JobInfoReq();

                string parentId = DNTRequest.GetString("parentId");
                cacheKey = "jobCacheKey";
                oJobInfoReq.caseCode = DNTRequest.GetString("caseCode");
                oJobInfoReq.transNo = DNTRequest.GetString("transNo");

                object objJob = CacheHelper.GetCache(cacheKey);
                JobInfoResp oJobInfoResp = new JobInfoResp();
                if (objJob != null)
                {
                    oJobInfoResp = (JobInfoResp)objJob;
                }
                else
                { 
                    oJobInfoResp = oBaoxianDataBLL.GetJobInfo(oJobInfoReq);
                    CacheHelper.SetCache(cacheKey, oJobInfoResp,10);
                } 
                if (oJobInfoResp != null)
                {

                    List<InsureJobVo> jobList = oJobInfoResp.insureJobVos;
                    if (jobList.Count > 0)
                    {
                        int pid = 0;
                        if (!string.IsNullOrEmpty(parentId))
                        {
                            pid = int.Parse(parentId);
                            jobList = jobList.Where(c => c.parentId == pid).ToList();
                        }
                        else
                        {
                            result = DNTRequest.GetResultJson(false, "ajax：GetJobInfo方法 ----parentId异常", null);
                            return result;
                        }
                        object obj = new
                        {
                            result = true,
                            msg = "",
                            data = jobList,
                        };
                        result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                Log.WriteLog(" " + ex);
            }

            return result;
        }
    }
}