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

namespace BWJS.WebPad.Ajax.Helper
{
    /// <summary>
    /// 功能权限的调度实现
    /// </summary>
    [DataContract]
    public partial class IFunction
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

                    case "OrderRebateList":
                        HttpContext.Current.Response.Write(GetOrderRebateList());
                        break;
                    case "FunctionList":
                        HttpContext.Current.Response.Write(GetFunctionList());
                        break;
                    case "getfunctionlist":
                        HttpContext.Current.Response.Write(GetFunctionListForZTree());
                        break;
                    case "getRolelist":
                        HttpContext.Current.Response.Write(GetRoleListForZTree());
                        break;
                    case "getfunctionmodel":
                        HttpContext.Current.Response.Write(GetFunctionModel());
                        break;
                    case "RoleList":
                        HttpContext.Current.Response.Write(GetRoleList());
                        break;
                    case "DepartmentList":
                        HttpContext.Current.Response.Write(GetDepartmentList());
                        break;
                    case "getDepartmentInfolist":
                        HttpContext.Current.Response.Write(GetDepartmentInfoListForZTree());
                        break;
                    case "UsersList":
                        HttpContext.Current.Response.Write(GetUsersList());
                        break;
                    case "CompanyList":
                        HttpContext.Current.Response.Write(GetCompanyList());
                        break;
                    case "DepartmentInfoListForSelect":
                        HttpContext.Current.Response.Write(DepartmentInfoListForSelect());
                        break;

                }

                #endregion
            }
        }

        static public Object DepartmentInfoListForSelect()
        {
            string result = string.Empty;
            try
            {
                DepartmentInfoBLL op = new DepartmentInfoBLL();
                List<DepartmentInfo> list = new List<DepartmentInfo>();
                StringBuilder where = new StringBuilder();
                where.AppendFormat("RecordIsDelete=0");
                list = op.GetModelList(where.ToString());
                result = DNTRequest.GetResultJson(true, "success", list);

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取商家部门异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        static public Object GetCompanyListForSelect()
        {
            string result = string.Empty;
            try
            {
                CompanyBLL op = new CompanyBLL();
                List<Company> list = new List<Company>();
                StringBuilder where = new StringBuilder();
                where.AppendFormat("IsDeleted=0");
                list = op.GetModelList(where.ToString());
                result = DNTRequest.GetResultJson(true, "success", list);

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取渠道异常，请稍后再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #region 获取功能列表为ZTree

        /// <summary>
        /// 获取功能列表为ZTree
        /// </summary>
        static public Object GetFunctionListForZTree()
        {
            #region 开始

            string result = string.Empty;
            try
            {
                int channelId = DNTRequest.GetInt("channelId", 7);
                int parentId = DNTRequest.GetInt("parentId", 0);
                FunctionBLL op = new FunctionBLL();
                Function model = new Function();
                DataSet ds = op.GetList("IsDeleted=0");
                DataTable dt = null;
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }

                List<Hashtable> list = new List<Hashtable>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow[] allList = dt.Select(string.Format("ParentId={0}", parentId), "OrderId ASC");
                    if (allList.Length > 0)
                    {
                        foreach (DataRow dr in allList)
                        {
                            bool isParent = false;
                            DataRow[] allChild = dt.Select(string.Format("ParentId={0}", dr["FunctionId"]), "OrderId ASC");
                            if (allChild != null && allChild.Length > 0)
                            {
                                isParent = true;
                            }
                            #region inner001
                            string className = ComPage.SafeToString(dr["FunctionName"]);
                            Hashtable ht = new Hashtable();

                            ht.Add("id", dr["FunctionId"]);
                            ht.Add("name", className);
                            ht.Add("pId", dr["ParentId"]);
                            ht.Add("externalLink", dr["ExternalLinkAddress"]);
                            ht.Add("orderId", dr["OrderId"]);
                            ht.Add("open", true);

                            if (isParent)
                            {
                                GetChild(list, allChild, dt);
                            }
                            list.Add(ht);
                            #endregion

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
        /// 获取功能列表为ZTree
        /// </summary>
        static public void GetChild(List<Hashtable> list, DataRow[] allList, DataTable dt)
        {
            try
            {
                if (allList.Length > 0)
                {
                    foreach (DataRow dr in allList)
                    {
                        bool isParent = false;
                        DataRow[] allChild = dt.Select(string.Format("parentId={0}", dr["FunctionId"]), "OrderId ASC");
                        if (allChild != null && allChild.Length > 0)
                        {
                            isParent = true;
                        }
                        string className = ComPage.SafeToString(dr["FunctionName"]);
                        Hashtable child = new Hashtable();
                        child.Add("id", dr["FunctionId"]);
                        child.Add("name", className);
                        child.Add("pId", dr["ParentId"]);
                        child.Add("externalLink", dr["ExternalLinkAddress"]);
                        child.Add("orderId", dr["OrderId"]);
                        child.Add("open", true);

                        if (isParent)
                        {
                            GetChild(list, allChild, dt);
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

        #region 获取功能实体类

        /// <summary>
        /// 获取功能实体类
        /// </summary>
        static public Object GetFunctionModel()
        {
            #region 开始

            string result = string.Empty;
            try
            {
                int functionId = DNTRequest.GetInt("functionId", -1);
                FunctionBLL op = new FunctionBLL();
                Function model = new Function();
                model = op.GetModel(functionId);
                result = DNTRequest.GetResultJson(true, "success", model);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, ex.Message, null);
                Log.WriteLog(ex.ToString());
            }
            return result;
            #endregion end 开始
        }
        #endregion

        #region 获取功能列表
        /// <summary>
        /// 获取功能列表
        /// </summary>
        static public Object GetFunctionList()
        {
            string result = string.Empty;
            try
            {
                string sEcho = JsonRequest.GetJsonKeyVal(jsonText, "sEcho");
                int displayStart = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayStart"));
                int displayLength = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayLength"));
                int pageIndex = (displayStart / displayLength) + 1;
                int pageSize = displayLength;

                #region 获取列表
                StringBuilder where = new StringBuilder();
                where.Append("1=1 and f.IsDeleted=0 ");

                #region 条件搜索
                string key = DNTRequest.GetString("searchKey");
                if (string.IsNullOrEmpty(key))
                {
                    key = JsonRequest.GetJsonKeyVal(jsonText, "searchKey");
                }

                string val = DNTRequest.GetString("searchValue");
                if (string.IsNullOrEmpty(val))
                {
                    val = JsonRequest.GetJsonKeyVal(jsonText, "searchValue");
                    val = System.Web.HttpContext.Current.Server.UrlDecode(val);
                }

                if (!string.IsNullOrEmpty(val))
                {
                    where.AppendFormat(" and (f.FunctionName like  '%{0}%' or f.FunctionCode like  '%{0}%' )", val);
                }
                #endregion

                string iSortCol_0 = JsonRequest.GetJsonKeyVal(jsonText, "iSortCol_0");
                string sSortDir_0 = JsonRequest.GetJsonKeyVal(jsonText, "sSortDir_0");
                int iSortingCols = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iSortingCols"));
                string orderBy = string.Empty;
                if (!string.IsNullOrEmpty(iSortCol_0))
                {
                    string orderField = JsonRequest.GetJsonKeyVal(jsonText, string.Format("mDataProp_{0}", iSortCol_0));
                    orderBy = string.Format(" {0} {1}", orderField, sSortDir_0);
                }

                string sql = "";
                int zys = 0;
                int sumcount = 0;
                FunctionBLL functionbll = new FunctionBLL();
                DataTable dt = functionbll.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
                /*
                    iTotalRecord = sumcount,
                    iTotalDisplayRecords = sumcount,
                */
                object obj = new
                {
                    result = true,
                    code = "",
                    msg = "",
                    recordsTotal = sumcount,
                    recordsFiltered = sumcount,
                    data = ((dt == null) ? (new DataTable()) : (dt)),
                    sEcho = sEcho,
                };
                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                #endregion

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        static public Object GetRoleList()
        {
            string result = string.Empty;
            try
            {
                string sEcho = JsonRequest.GetJsonKeyVal(jsonText, "sEcho");
                int displayStart = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayStart"));
                int displayLength = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayLength"));
                int pageIndex = (displayStart / displayLength) + 1;
                int pageSize = displayLength;

                #region 获取列表
                StringBuilder where = new StringBuilder();
                where.Append("1=1 and r.IsDeleted=0");

                #region 条件搜索
                string key = DNTRequest.GetString("searchKey");
                if (string.IsNullOrEmpty(key))
                {
                    key = JsonRequest.GetJsonKeyVal(jsonText, "searchKey");
                }

                string val = DNTRequest.GetString("searchValue");
                if (string.IsNullOrEmpty(val))
                {
                    val = JsonRequest.GetJsonKeyVal(jsonText, "searchValue");
                    val = System.Web.HttpContext.Current.Server.UrlDecode(val);
                }

                if (!string.IsNullOrEmpty(val) && val != "undefined")
                {
                    where.AppendFormat(" and (r.RoleName like  '{0}%')", val);
                }
                #endregion

                string iSortCol_0 = JsonRequest.GetJsonKeyVal(jsonText, "iSortCol_0");
                string sSortDir_0 = JsonRequest.GetJsonKeyVal(jsonText, "sSortDir_0");
                int iSortingCols = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iSortingCols"));
                string orderBy = string.Empty;
                if (!string.IsNullOrEmpty(iSortCol_0))
                {
                    string orderField = JsonRequest.GetJsonKeyVal(jsonText, string.Format("mDataProp_{0}", iSortCol_0));
                    orderBy = string.Format(" {0} {1}", orderField, sSortDir_0);
                }

                string sql = "";
                int zys = 0;
                int sumcount = 0;
                RoleBLL rolebll = new RoleBLL();
                DataTable dt = rolebll.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
                /*
                    iTotalRecord = sumcount,
                    iTotalDisplayRecords = sumcount,
                */
                object obj = new
                {
                    result = true,
                    code = "",
                    msg = "",
                    recordsTotal = sumcount,
                    recordsFiltered = sumcount,
                    data = ((dt == null) ? (new DataTable()) : (dt)),
                    sEcho = sEcho,
                };
                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                #endregion

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion
        /// <summary>
        /// 获取角色列表为ZTree
        /// </summary>
        static public Object GetRoleListForZTree()
        {
            #region 开始
            string result = string.Empty;
            try
            {
                int channelId = DNTRequest.GetInt("channelId", 7);
                int parentId = DNTRequest.GetInt("parentId", 0);
                RoleBLL op = new RoleBLL();
                Role model = new Role();
                DataSet ds = op.GetList(" IsDeleted=0 AND RoleStatus=1");
                DataTable dt = null;
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }

                List<Hashtable> list = new List<Hashtable>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow[] allList = dt.Select(string.Format("ParentId={0}", parentId), "RoleId ASC");
                    if (allList.Length > 0)
                    {
                        foreach (DataRow dr in allList)
                        {
                            bool isParent = false;
                            DataRow[] allChild = dt.Select(string.Format("ParentId={0}", dr["RoleId"]), "RoleId ASC");
                            if (allChild != null && allChild.Length > 0)
                            {
                                isParent = true;
                            }
                            #region inner001
                            string className = ComPage.SafeToString(dr["RoleName"]);
                            Hashtable ht = new Hashtable();

                            ht.Add("id", dr["RoleId"]);
                            ht.Add("name", className);
                            ht.Add("pId", dr["ParentId"]);
                            ht.Add("open", true);

                            if (isParent)
                            {
                                GetRoleChild(list, allChild, dt);
                            }
                            list.Add(ht);
                            #endregion

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
        /// 获取功能列表为ZTree
        /// </summary>
        static public void GetRoleChild(List<Hashtable> list, DataRow[] allList, DataTable dt)
        {
            try
            {
                if (allList.Length > 0)
                {
                    foreach (DataRow dr in allList)
                    {
                        bool isParent = false;
                        DataRow[] allChild = dt.Select(string.Format("parentId={0}", dr["RoleId"]), "RoleId ASC");
                        if (allChild != null && allChild.Length > 0)
                        {
                            isParent = true;
                        }
                        string className = ComPage.SafeToString(dr["RoleName"]);
                        Hashtable child = new Hashtable();
                        child.Add("id", dr["RoleId"]);
                        child.Add("name", className);
                        child.Add("pId", dr["ParentId"]);
                        child.Add("open", true);

                        if (isParent)
                        {
                            GetRoleChild(list, allChild, dt);
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



        #region 获取分利列表
        /// <summary>
        /// 获取分利列表
        /// </summary>
        static public Object GetOrderRebateList()
        {
            string result = string.Empty;
            try
            {
                string sEcho = JsonRequest.GetJsonKeyVal(jsonText, "sEcho");
                int displayStart = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayStart"));
                int displayLength = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayLength"));
                int pageIndex = (displayStart / displayLength) + 1;
                int pageSize = displayLength;

                #region 获取列表
                StringBuilder where = new StringBuilder();
                where.Append("1=1 and ort.IsDeleted=0 ");
                DepartmentInfo df = new DepartmentInfo();
                DepartmentInfoBLL bll = new DepartmentInfoBLL();
                df = bll.GetModel(ComPage.CurrentAdmin.DepartmentID);
                if (ComPage.CurrentAdmin.UserType != 1)
                {
                    if ((df == null) || (df != null && df.IsReceiveBusiness != false))
                    {
                        //where.Append(" AND  moa.UserID IN(select ID from [BWJSDB].dbo.[GetDepartmentChildren](" + ComPage.CurrentAdmin.UserID + "))");
                        where.Append(" AND moa.UserID IN(SELECT ID from[BWJSDB].dbo.[GetDepartmentChildren](" + ComPage.CurrentAdmin.UserID + "))");
                    }
                }

                #region 条件搜索
                string key = DNTRequest.GetString("searchKey");
                if (string.IsNullOrEmpty(key))
                {
                    key = JsonRequest.GetJsonKeyVal(jsonText, "searchKey");
                }

                string val = DNTRequest.GetString("searchValue");
                if (string.IsNullOrEmpty(val))
                {
                    val = JsonRequest.GetJsonKeyVal(jsonText, "searchValue");
                    val = System.Web.HttpContext.Current.Server.UrlDecode(val);
                }

                if (!string.IsNullOrEmpty(val))
                {
                    where.AppendFormat(" and  (moa.InsureNum like'" + val + "%'  or ort.TransNo  like'" + val + "%') ", val);
                }
                #endregion

                string iSortCol_0 = JsonRequest.GetJsonKeyVal(jsonText, "iSortCol_0");
                string sSortDir_0 = JsonRequest.GetJsonKeyVal(jsonText, "sSortDir_0");
                int iSortingCols = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iSortingCols"));
                string orderBy = string.Empty;
                if (!string.IsNullOrEmpty(iSortCol_0))
                {
                    string orderField = JsonRequest.GetJsonKeyVal(jsonText, string.Format("mDataProp_{0}", iSortCol_0));
                    orderBy = string.Format(" {0} {1}", orderField, sSortDir_0);
                }

                string sql = "";
                int zys = 0;
                int sumcount = 0;
                OrderRebateBLL orderRebatebll = new OrderRebateBLL();
                DataTable dt = orderRebatebll.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
                /*
                    iTotalRecord = sumcount,
                    iTotalDisplayRecords = sumcount,
                */
                object obj = new
                {
                    result = true,
                    code = "",
                    msg = "",
                    recordsTotal = sumcount,
                    recordsFiltered = sumcount,
                    data = ((dt == null) ? (new DataTable()) : (dt)),
                    sEcho = sEcho,
                };
                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                #endregion

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion


        #region 获取部门列表
        /// <summary>
        /// 获取部门列表
        /// </summary>
        static public Object GetDepartmentList()
        {
            string result = string.Empty;
            try
            {
                string sEcho = JsonRequest.GetJsonKeyVal(jsonText, "sEcho");
                int displayStart = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayStart"));
                int displayLength = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayLength"));
                int pageIndex = (displayStart / displayLength) + 1;
                int pageSize = displayLength;

                #region 获取列表
                StringBuilder where = new StringBuilder();
                where.Append("1=1 and r.RecordIsDelete=0");

                #region 条件搜索
                string key = DNTRequest.GetString("searchKey");
                if (string.IsNullOrEmpty(key))
                {
                    key = JsonRequest.GetJsonKeyVal(jsonText, "searchKey");
                }

                string val = DNTRequest.GetString("searchValue");
                if (string.IsNullOrEmpty(val))
                {
                    val = JsonRequest.GetJsonKeyVal(jsonText, "searchValue");
                    val = System.Web.HttpContext.Current.Server.UrlDecode(val);
                }

                if (!string.IsNullOrEmpty(val) && val != "undefined")
                {
                    where.AppendFormat(" and (r.DepartmentName like  '{0}%')", val);
                }
                #endregion

                string iSortCol_0 = JsonRequest.GetJsonKeyVal(jsonText, "iSortCol_0");
                string sSortDir_0 = JsonRequest.GetJsonKeyVal(jsonText, "sSortDir_0");
                int iSortingCols = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iSortingCols"));
                string orderBy = string.Empty;
                if (!string.IsNullOrEmpty(iSortCol_0))
                {
                    string orderField = JsonRequest.GetJsonKeyVal(jsonText, string.Format("mDataProp_{0}", iSortCol_0));
                    orderBy = string.Format(" {0} {1}", orderField, sSortDir_0);
                }

                string sql = "";
                int zys = 0;
                int sumcount = 0;
                DepartmentInfoBLL rolebll = new DepartmentInfoBLL();
                DataTable dt = rolebll.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
                /*
                    iTotalRecord = sumcount,
                    iTotalDisplayRecords = sumcount,
                */
                object obj = new
                {
                    result = true,
                    code = "",
                    msg = "",
                    recordsTotal = sumcount,
                    recordsFiltered = sumcount,
                    data = ((dt == null) ? (new DataTable()) : (dt)),
                    sEcho = sEcho,
                };
                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                #endregion

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion

        /// <summary>
        /// 获取角色列表为ZTree
        /// </summary>
        static public Object GetDepartmentInfoListForZTree()
        {
            #region 开始
            string result = string.Empty;
            try
            {
                int channelId = DNTRequest.GetInt("channelId", 7);
                int ParentId = DNTRequest.GetInt("ParentId", 0);
                DepartmentInfoBLL op = new DepartmentInfoBLL();
                DepartmentInfo model = new DepartmentInfo();
                DataSet ds = op.GetList(" RecordIsDelete=0 ");
                DataTable dt = null;
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }

                List<Hashtable> list = new List<Hashtable>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow[] allList = dt.Select(string.Format("ParentId={0}", ParentId), "DepartmentID ASC");
                    if (allList.Length > 0)
                    {
                        foreach (DataRow dr in allList)
                        {
                            bool isParent = false;
                            DataRow[] allChild = dt.Select(string.Format("ParentId={0}", dr["DepartmentID"]), "DepartmentID ASC");
                            if (allChild != null && allChild.Length > 0)
                            {
                                isParent = true;
                            }
                            #region inner001
                            string className = ComPage.SafeToString(dr["DepartmentName"]);
                            Hashtable ht = new Hashtable();

                            ht.Add("id", dr["DepartmentID"]);
                            ht.Add("name", className);
                            ht.Add("pId", dr["ParentId"]);
                            ht.Add("open", true);

                            if (isParent)
                            {
                                GetDepartmentInfoChild(list, allChild, dt);
                            }
                            list.Add(ht);
                            #endregion

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
        /// 获取功能列表为ZTree
        /// </summary>
        static public void GetDepartmentInfoChild(List<Hashtable> list, DataRow[] allList, DataTable dt)
        {
            try
            {
                if (allList.Length > 0)
                {
                    foreach (DataRow dr in allList)
                    {
                        bool isParent = false;
                        DataRow[] allChild = dt.Select(string.Format("ParentID={0}", dr["DepartmentID"]), "DepartmentID ASC");
                        if (allChild != null && allChild.Length > 0)
                        {
                            isParent = true;
                        }
                        string className = ComPage.SafeToString(dr["DepartmentName"]);
                        Hashtable child = new Hashtable();
                        child.Add("id", dr["DepartmentID"]);
                        child.Add("name", className);
                        child.Add("pId", dr["ParentID"]);
                        child.Add("open", true);

                        if (isParent)
                        {
                            GetDepartmentInfoChild(list, allChild, dt);
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




        #region 获取渠道
        /// <summary>
        /// 获取渠道列表
        /// </summary>
        static public Object GetCompanyList()
        {
            string result = string.Empty;
            try
            {
                string sEcho = JsonRequest.GetJsonKeyVal(jsonText, "sEcho");
                int displayStart = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayStart"));
                int displayLength = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayLength"));
                int pageIndex = (displayStart / displayLength) + 1;
                int pageSize = displayLength;

                #region 获取列表
                StringBuilder where = new StringBuilder();
                where.Append("1=1 and c.IsDeleted=0");
                #region 条件搜索
                string key = DNTRequest.GetString("searchKey");
                if (string.IsNullOrEmpty(key))
                {
                    key = JsonRequest.GetJsonKeyVal(jsonText, "searchKey");
                }
                string val = DNTRequest.GetString("searchValue");
                if (string.IsNullOrEmpty(val))
                {
                    val = JsonRequest.GetJsonKeyVal(jsonText, "searchValue");
                    val = System.Web.HttpContext.Current.Server.UrlDecode(val);
                }

                if (!string.IsNullOrEmpty(val) && val != "undefined")
                {
                    where.AppendFormat(" and (c.CompanyName like  '{0}%')", val);
                }
                string CompanyCategoryId = DNTRequest.GetString("CompanyCategoryId");
                string CompanyManager = DNTRequest.GetString("CompanyManager");
                if (string.IsNullOrEmpty(CompanyCategoryId))
                {
                    CompanyCategoryId = JsonRequest.GetJsonKeyVal(jsonText, "CompanyCategoryId");
                    CompanyCategoryId = System.Web.HttpContext.Current.Server.UrlDecode(CompanyCategoryId);
                }
                if (string.IsNullOrEmpty(CompanyManager))
                {
                    CompanyManager = JsonRequest.GetJsonKeyVal(jsonText, "CompanyManager");
                    CompanyManager = System.Web.HttpContext.Current.Server.UrlDecode(CompanyManager);
                }
                if (!string.IsNullOrEmpty(CompanyCategoryId) && CompanyCategoryId != "null" && CompanyCategoryId != "undefined")
                {
                    where.AppendFormat(" and c.CompanyCategoryId ={0} ", CompanyCategoryId);
                }
                if (!string.IsNullOrEmpty(CompanyManager) && CompanyManager != "null" && CompanyManager != "undefined")
                {
                    where.AppendFormat(" and c.CompanyManager like'{0}%'  ", CompanyManager);
                }

                #endregion

                string iSortCol_0 = JsonRequest.GetJsonKeyVal(jsonText, "iSortCol_0");
                string sSortDir_0 = JsonRequest.GetJsonKeyVal(jsonText, "sSortDir_0");
                int iSortingCols = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iSortingCols"));
                string orderBy = string.Empty;
                if (!string.IsNullOrEmpty(iSortCol_0))
                {
                    string orderField = JsonRequest.GetJsonKeyVal(jsonText, string.Format("mDataProp_{0}", iSortCol_0));
                    orderBy = string.Format(" {0} {1}", orderField, sSortDir_0);
                }

                string sql = "";
                int zys = 0;
                int sumcount = 0;
                CompanyBLL companybll = new CompanyBLL();
                DataTable dt = companybll.GetNameList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
                /*
                    iTotalRecord = sumcount,
                    iTotalDisplayRecords = sumcount,
                */
                object obj = new
                {
                    result = true,
                    code = "",
                    msg = "",
                    recordsTotal = sumcount,
                    recordsFiltered = sumcount,
                    data = ((dt == null) ? (new DataTable()) : (dt)),
                    sEcho = sEcho,
                };
                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                #endregion

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        static public Object GetUsersList()
        {
            string result = string.Empty;
            try
            {
                string sEcho = JsonRequest.GetJsonKeyVal(jsonText, "sEcho");
                int displayStart = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayStart"));
                int displayLength = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iDisplayLength"));
                int pageIndex = (displayStart / displayLength) + 1;
                int pageSize = displayLength;

                #region 获取列表
                StringBuilder where = new StringBuilder();
                where.Append("1=1 and u.RecordIsDelete=0 ");
                DepartmentInfo df = new DepartmentInfo();
                DepartmentInfoBLL bll = new DepartmentInfoBLL();
                df = bll.GetModel(ComPage.CurrentAdmin.DepartmentID);

                if (ComPage.CurrentAdmin.UserType != 1)
                {
                    if ((df == null) || (df != null && df.IsReceiveBusiness != false))
                    {
                        where.Append(" AND  u. UserID IN(select ID from [BWJSDB].dbo.[GetDepartmentChildren](" + ComPage.CurrentAdmin.UserID + "))");

                    }
                }

                #region 条件搜索
                string key = DNTRequest.GetString("searchKey");
                if (string.IsNullOrEmpty(key))
                {
                    key = JsonRequest.GetJsonKeyVal(jsonText, "searchKey");
                }
                string LoginName = DNTRequest.GetString("LoginName");
                string UsersName = DNTRequest.GetString("UsersName");
                string Mobiles = DNTRequest.GetString("Mobiles");
                string DepartmentInfoID = DNTRequest.GetString("DepartmentInfoID");

                if (string.IsNullOrEmpty(LoginName))
                {
                    LoginName = JsonRequest.GetJsonKeyVal(jsonText, "LoginName");
                    LoginName = System.Web.HttpContext.Current.Server.UrlDecode(LoginName);
                }
                if (string.IsNullOrEmpty(UsersName))
                {
                    UsersName = JsonRequest.GetJsonKeyVal(jsonText, "UsersName");
                    UsersName = System.Web.HttpContext.Current.Server.UrlDecode(UsersName);
                }
                if (string.IsNullOrEmpty(Mobiles))
                {
                    Mobiles = JsonRequest.GetJsonKeyVal(jsonText, "Mobiles");
                    Mobiles = System.Web.HttpContext.Current.Server.UrlDecode(Mobiles);
                }
                if (string.IsNullOrEmpty(DepartmentInfoID))
                {
                    DepartmentInfoID = JsonRequest.GetJsonKeyVal(jsonText, "DepartmentInfoID");
                    DepartmentInfoID = System.Web.HttpContext.Current.Server.UrlDecode(DepartmentInfoID);
                }



                if (!string.IsNullOrEmpty(LoginName))
                {
                    where.AppendFormat(" and u.LoginName like'{0}%'  ", LoginName);
                }
                if (!string.IsNullOrEmpty(UsersName))
                {
                    where.AppendFormat(" and u.UserName like'{0}%'  ", UsersName);
                }
                if (!string.IsNullOrEmpty(Mobiles))
                {
                    where.AppendFormat(" and u.Phone like'{0}%'  ", Mobiles);
                }
                if (!string.IsNullOrEmpty(DepartmentInfoID)&&DepartmentInfoID!= "undefined" && DepartmentInfoID != "0")
                {
                    where.AppendFormat(" and u.DepartmentID ={0}  ", DepartmentInfoID);
                }
                #endregion

                string iSortCol_0 = JsonRequest.GetJsonKeyVal(jsonText, "iSortCol_0");
                string sSortDir_0 = JsonRequest.GetJsonKeyVal(jsonText, "sSortDir_0");
                int iSortingCols = ComPage.SafeToInt(JsonRequest.GetJsonKeyVal(jsonText, "iSortingCols"));
                string orderBy = string.Empty;
                if (!string.IsNullOrEmpty(iSortCol_0))
                {
                    string orderField = JsonRequest.GetJsonKeyVal(jsonText, string.Format("mDataProp_{0}", iSortCol_0));
                    orderBy = string.Format(" {0} {1}", orderField, sSortDir_0);
                }

                string sql = "";
                int zys = 0;
                int sumcount = 0;
                UsersBLL Usersbll = new UsersBLL();
                DataTable dt = Usersbll.GetList(where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
                /*
                    iTotalRecord = sumcount,
                    iTotalDisplayRecords = sumcount,
                */
                object obj = new
                {
                    result = true,
                    code = "",
                    msg = "",
                    recordsTotal = sumcount,
                    recordsFiltered = sumcount,
                    data = ((dt == null) ? (new DataTable()) : (dt)),
                    sEcho = sEcho,
                };
                result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                #endregion

            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "操作异常，请稍候再试", null);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion
    }
}
