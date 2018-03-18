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


namespace BWJS.WebPad.Ajax.Helper.BWJS
{
    /// <summary>
    /// 后台左侧导航
    /// </summary>
    public class ILeftMenu
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
                    case "getleft":
                        HttpContext.Current.Response.Write(GetLeftMenu());
                        break;

                }

                #endregion
            }
        }

        #region 获取左侧导航菜单
        /// <summary>
        /// 获取左侧导航菜单
        /// </summary>
        static public Object GetLeftMenu()
        {
            #region 开始
            string result = string.Empty;
            try
            {
                int parentId = DNTRequest.GetInt("parentId", 0);
                FunctionBLL opFunctionBLL = new FunctionBLL();
                Function modelFunction = new Function();
                DataSet ds = opFunctionBLL.GetList("IsDeleted=0");
                DataTable dt = null;
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                List<Hashtable> list = new List<Hashtable>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow[] allList = dt.Select(string.Format("ClassId=0 and ParentId={0}", parentId), "OrderId ASC");
                    if (allList.Length > 0)
                    {
                        foreach (DataRow dr in allList)
                        {
                            bool isParent = false;
                            DataRow[] allChild = dt.Select(string.Format("ClassId=0 and ParentId={0}", dr["FunctionId"]), "OrderId ASC");
                            if (allChild != null && allChild.Length > 0)
                            {
                                isParent = true;
                            }
                            string className = ComPage.SafeToString(dr["FunctionName"]);
                            Hashtable ht = new Hashtable();

                            ht.Add("id", dr["FunctionId"]);
                            ht.Add("name", className);
                            ht.Add("pId", dr["ParentId"]);
                            ht.Add("url", dr["ExternalLinkAddress"]);
                            ht.Add("code", dr["FunctionCode"]);

                            if (isParent)
                            {
                                GetLeftMenuChild(list, allChild, dt);
                            }
                            list.Add(ht);

                        }
                    }
                }
                result = DNTRequest.GetResultJson(true, "success", list);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, ex.Message, null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
            #endregion end 开始
        }

        /// <summary>
        /// 获取左侧导航子菜单
        /// </summary>
        static public void GetLeftMenuChild(List<Hashtable> list, DataRow[] allList, DataTable dt)
        {
            try
            {
                if (allList.Length > 0)
                {
                    foreach (DataRow dr in allList)
                    {
                        bool isParent = false;
                        DataRow[] allChild = dt.Select(string.Format("ClassId=0 and parentId={0}", dr["FunctionId"]), "OrderId ASC");
                        if (allChild != null && allChild.Length > 0)
                        {
                            isParent = true;
                        }
                        string className = ComPage.SafeToString(dr["FunctionName"]);
                        Hashtable child = new Hashtable();
                        child.Add("id", dr["FunctionId"]);
                        child.Add("name", className);
                        child.Add("pId", dr["ParentId"]);
                        child.Add("url", dr["ExternalLinkAddress"]);
                        child.Add("code", dr["FunctionCode"]);

                        if (isParent)
                        {
                            GetLeftMenuChild(list, allChild, dt);
                        }
                        list.Add(child);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
        }

        #endregion
    }
}