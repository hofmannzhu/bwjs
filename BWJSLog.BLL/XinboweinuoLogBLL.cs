using BWJSLog.DAL;
using BWJSLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace BWJSLog.BLL
{
    /// <summary>
    /// 信博维诺接口操作日志
    /// </summary>
    public partial class XinboweinuoLogBLL
    {
        private readonly XinboweinuoLogDAL dal = new XinboweinuoLogDAL();

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJSLog.Model.XinboweinuoLog model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJSLog.Model.XinboweinuoLog model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJSLog.Model.XinboweinuoLog GetModel(int XinboweinuoLogId)
        {

            return dal.GetModel(XinboweinuoLogId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJSLog.Model.XinboweinuoLog> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJSLog.Model.XinboweinuoLog> DataTableToList(DataTable dt)
        {
            List<BWJSLog.Model.XinboweinuoLog> modelList = new List<BWJSLog.Model.XinboweinuoLog>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BWJSLog.Model.XinboweinuoLog model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(dt.Rows[n]);
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJSLog.Model.XinboweinuoLog DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        #endregion

        #region  ExtensionMethod
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int XinboweinuoLogId, int userId)
        {

            return dal.Delete(XinboweinuoLogId, userId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string XinboweinuoLogIdlist, int userId)
        {
            return dal.DeleteList(XinboweinuoLogIdlist, userId);
        }
        /// <summary>
        /// 分页获得数据列表
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="orderBy">排序字段&排序方向</param>
        /// <param name="sql">返回完整的的可执行sql</param>
        /// <param name="zys">总页数</param>
        /// <param name="sumcount">总记录数</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            return dal.GetList(where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        /// <summary>
        /// 分页获得数据列表
        /// </summary>
        /// <param name="tablesql">要执行的sql语句</param>
        /// <param name="where">查询条件</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="orderBy">排序字段&排序方向</param>
        /// <param name="sql">返回完整的的可执行sql</param>
        /// <param name="zys">总页数</param>
        /// <param name="sumcount">总记录数</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(string tablesql, string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            return dal.GetList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }
        /// <summary>
        /// 添加信博维诺接口调用日志
        /// </summary>
        /// <param name="netLoanApplyId">网贷申请编号</param>
        /// <param name="apiUrl">请求地址</param>
        /// <param name="requestDate">请求日期时间</param>
        /// <param name="requestData">请求json</param>
        /// <param name="responseDate">响应日期时间</param>
        /// <param name="responseData">响应json</param>
        /// <returns>添加结果</returns>
        static public int Add(int netLoanApplyId, string apiUrl, DateTime requestDate, string requestData, DateTime responseDate, string responseData)
        {
            int result = -1;
            StackTrace st = new StackTrace(true);
            MethodBase mb = st.GetFrame(1).GetMethod();
            string clsString = mb.DeclaringType.FullName;
            string mName = mb.Name;

            XinboweinuoLogBLL opXinboweinuoLog = new XinboweinuoLogBLL();
            XinboweinuoLog modelXinboweinuoLog = new XinboweinuoLog();
            modelXinboweinuoLog.NetLoanApplyId = netLoanApplyId;
            modelXinboweinuoLog.ClassName = clsString;
            modelXinboweinuoLog.MethodName = mName;
            modelXinboweinuoLog.ApiUrl = apiUrl;
            modelXinboweinuoLog.RequestDate = requestDate;
            modelXinboweinuoLog.RequestData = requestData;
            modelXinboweinuoLog.ResponseDate = responseDate;
            modelXinboweinuoLog.ResponseData = responseData;
            modelXinboweinuoLog.IsDeleted = 0;
            modelXinboweinuoLog.CreateDate = DateTime.Now;
            result = opXinboweinuoLog.Add(modelXinboweinuoLog);
            return result;
        }
        #endregion  ExtensionMethod
    }
}
