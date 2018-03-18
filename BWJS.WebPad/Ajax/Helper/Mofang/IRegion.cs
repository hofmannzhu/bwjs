using UtilityHelper;
using MofangInterface.BLL;
using MofangInterface.Model.InputModel;
using MofangInterface.Model.OutputModel;
using System;
using System.Runtime.Serialization;
using System.Web;
using System.Collections.Generic;

namespace BWJS.WebPad.Ajax.Helper
{
    /// <summary>
    /// 调度实现
    /// </summary>
    [DataContract]
    public class IRegion
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
                    case "getR":
                        HttpContext.Current.Response.Write(GetRegion());
                        break;
                    case "getProductPropertyArea":
                        HttpContext.Current.Response.Write(GetProductPropertyArea());
                        break; 
                }

                #endregion
            }
        }

        #region 获取产品可投保区域省市区

        /// <summary>
        /// 获取产品可投保区域省市区
        /// </summary>
        static public Object GetRegion()
        {
            string result = string.Empty;
            try
            {
                #region 获取列表

                BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
                ProductInsuredAreaReq model = new ProductInsuredAreaReq();
                model.transNo = DNTRequest.GetString("transNo");
                model.caseCode = DNTRequest.GetString("caseCode");
                model.areaCode = DNTRequest.GetString("areaCode");
                ProductDestinationResp res = baoxianDataBLL.ProductInsuredArea(model);

                object obj = new
                {
                    result = true,
                    msg = "",
                    data = res.areas,
                };
                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                #endregion

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                Log.WriteLog(" " + ex);
            }
            return result;
        }
        #endregion

        #region 获取产品财产所在地

        /// <summary>
        /// 获取产品财产所在地
        /// </summary>
        static public Object GetProductPropertyArea()
        {
            string result = string.Empty;
            try
            {
                #region 获取列表

                BaoxianDataBLL baoxianDataBLL = new BaoxianDataBLL();
                ProductPropertyAreaReq model = new ProductPropertyAreaReq();
                model.transNo = DNTRequest.GetString("transNo");
                model.caseCode = DNTRequest.GetString("caseCode");
                model.areaCode = DNTRequest.GetString("areaCode");
                ProductPropertyAreaResp res = baoxianDataBLL.GetProductPropertyArea(model);

                object obj = new
                {
                    result = true,
                    msg = "",
                    data = res.areas,
                };
                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                #endregion

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                Log.WriteLog(" " + ex);
            }
            return result;
        }
        #endregion

      
    }
}