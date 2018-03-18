using BWJS.BLL;
using BWJS.BLL.CookieMag;
using BWJS.Model;
using BWJSLog.BLL;
using BWJSLog.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XBWNInterface.BLL
{
    /// <summary>
    /// 日志操作类实现
    /// </summary>
    public class ILog
    {
        #region 接口调用日志
        /// <summary>
        /// 接口调用日志
        /// </summary>
        /// <param name="apiUrl">请求地址</param>
        /// <param name="requestDate">请求日期时间</param>
        /// <param name="requestData">请求json</param>
        /// <param name="responseData">响应json</param>
        /// <param name="companyId">渠道编号</param>
        /// <param name="businessType">业务类型1网贷2保险3信用卡</param>
        /// <param name="relationId">关联编号</param>
        /// <returns>添加结果</returns>
        static public int ApiInvokingLogAdd(int relationId, string apiUrl, DateTime requestDate, string requestData, string responseData, int companyId = 1, int businessType = 1)
        {
            int result = -1;
            try
            {
                StackTrace st = new StackTrace(true);
                MethodBase mb = st.GetFrame(1).GetMethod();
                string clsString = mb.DeclaringType.FullName;
                string mName = mb.Name;

                ApiInvokingLogBLL opApiInvokingLog = new ApiInvokingLogBLL();
                ApiInvokingLog modelApiInvokingLog = new ApiInvokingLog();
                modelApiInvokingLog.CompanyId = companyId;
                modelApiInvokingLog.BusinessType = businessType;
                modelApiInvokingLog.RelationId = relationId;
                modelApiInvokingLog.ClassName = clsString;
                modelApiInvokingLog.MethodName = mName;
                modelApiInvokingLog.ApiUrl = apiUrl;
                modelApiInvokingLog.RequestDate = requestDate;
                modelApiInvokingLog.RequestData = requestData;
                modelApiInvokingLog.ResponseDate = DateTime.Now;
                modelApiInvokingLog.ResponseData = responseData;
                modelApiInvokingLog.IsDeleted = 0;
                modelApiInvokingLog.CreateDate = DateTime.Now;
                result = opApiInvokingLog.Add(modelApiInvokingLog);

            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 操作日志
        /// <summary>
        /// 操作日志
        /// </summary>
        /// <param name="logContent">日志内容</param>
        /// <param name="companyId">渠道编号</param>
        /// <param name="businessType">业务类型1网贷2保险3信用卡</param>
        /// <param name="relationId">关联编号</param>
        /// <returns>操作日志添加结果</returns>
        static public int OperationLogAdd(int relationId, string logContent, int companyId = 1, int businessType = 1)
        {
            int result = -1;
            try
            {
                int userId = -1;
                string realName = string.Empty;
                int departmentId = -1;
                string departmentName = string.Empty;

                LoginUserCookie currentUser = MerchantFrontCookieBLL.GetMerchantFrontUserCookie();
                if (currentUser != null)
                {
                    UsersBLL op = new UsersBLL();
                    Users model = new Users();
                    model = op.GetModel(currentUser.LoginUserID);
                    userId = currentUser.LoginUserID;
                    departmentId = model.DepartmentID;
                    if (model != null)
                    {
                        realName = model.UserName;

                        DepartmentInfoBLL opDepartment = new DepartmentInfoBLL();
                        DepartmentInfo modelDepartmentInfo = new DepartmentInfo();
                        modelDepartmentInfo = opDepartment.GetModel(departmentId);
                        if (modelDepartmentInfo != null)
                        {
                            departmentName = modelDepartmentInfo.DepartmentName;
                        }
                    }
                }

                StackTrace st = new StackTrace(true);
                MethodBase mb = st.GetFrame(1).GetMethod();
                string clsString = mb.DeclaringType.FullName;
                string mName = mb.Name;

                OperationLogBLL opOperationLog = new OperationLogBLL();
                OperationLog modelOperationLog = new OperationLog();

                modelOperationLog.BusinessType = businessType;
                modelOperationLog.RelationId = relationId;
                modelOperationLog.LogContent = logContent;
                modelOperationLog.Ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                modelOperationLog.UserId = userId;
                modelOperationLog.RealName = realName;
                modelOperationLog.CreateDate = DateTime.Now;
                modelOperationLog.DepartmentId = departmentId;
                modelOperationLog.DepartmentName = departmentName;
                modelOperationLog.CreateDate = DateTime.Now;
                result = opOperationLog.Add(modelOperationLog);


            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 网贷申请状态变更日志
        /// <summary>
        /// 网贷申请状态变更日志
        /// </summary>
        /// <param name="consultId">网贷申请编号</param>
        /// <param name="status">当前状态</param>
        /// <param name="prevStatus">上一步状态</param>
        /// <param name="businessType">业务类型1网贷2保险3信用卡</param>
        /// <returns>网贷申请状态变更添加结果</returns>
        static public int ConsultStatusChangeLogAdd(int consultId, int status, int prevStatus, int businessType = 1)
        {
            int result = -1;
            try
            {
                NL_ConsultStatusChangeLogBLL bll = new NL_ConsultStatusChangeLogBLL();
                NL_ConsultStatusChangeLog model = new NL_ConsultStatusChangeLog();
                model.ConsultId = consultId;
                model.BusinessType = businessType;
                model.Status = status;
                model.PrevStatus = prevStatus;
                model.CreateDate = DateTime.Now;
                result = bll.Add(model);
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }

        #endregion
    }
}
