using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityHelper;

namespace BWJSLog.DAL
{
    /// <summary>
    /// 接口调用日志
    /// </summary>
    public partial class ApiInvokingLogDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJSLog.Model.ApiInvokingLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[ApiInvokingLog](");
            strSql.Append("ResponseDate,ResponseData,IsDeleted,CreateId,CreateDate,CompanyId,BusinessType,RelationId,ClassName,MethodName,ApiUrl,RequestDate,RequestData");
            strSql.Append(") values (");
            strSql.Append("@ResponseDate,@ResponseData,@IsDeleted,@CreateId,@CreateDate,@CompanyId,@BusinessType,@RelationId,@ClassName,@MethodName,@ApiUrl,@RequestDate,@RequestData");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@ResponseDate", model.ResponseDate) ,
                        new SqlParameter("@ResponseData", model.ResponseData) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@CompanyId", model.CompanyId) ,
                        new SqlParameter("@BusinessType", model.BusinessType) ,
                        new SqlParameter("@RelationId", model.RelationId) ,
                        new SqlParameter("@ClassName", model.ClassName) ,
                        new SqlParameter("@MethodName", model.MethodName) ,
                        new SqlParameter("@ApiUrl", model.ApiUrl) ,
                        new SqlParameter("@RequestDate", model.RequestDate) ,
                        new SqlParameter("@RequestData", model.RequestData)

            };


            object obj = BWJSLogHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt32(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJSLog.Model.ApiInvokingLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[ApiInvokingLog] set ");

            strSql.Append(" ResponseDate = @ResponseDate , ");
            strSql.Append(" ResponseData = @ResponseData , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" CompanyId = @CompanyId , ");
            strSql.Append(" BusinessType = @BusinessType , ");
            strSql.Append(" RelationId = @RelationId , ");
            strSql.Append(" ClassName = @ClassName , ");
            strSql.Append(" MethodName = @MethodName , ");
            strSql.Append(" ApiUrl = @ApiUrl , ");
            strSql.Append(" RequestDate = @RequestDate , ");
            strSql.Append(" RequestData = @RequestData  ");
            strSql.Append(" where ApiInvokingLogId=@ApiInvokingLogId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ApiInvokingLogId",model.ApiInvokingLogId) ,
                        new SqlParameter("@ResponseDate",model.ResponseDate) ,
                        new SqlParameter("@ResponseData",model.ResponseData) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@CompanyId",model.CompanyId) ,
                        new SqlParameter("@BusinessType",model.BusinessType) ,
                        new SqlParameter("@RelationId",model.RelationId) ,
                        new SqlParameter("@ClassName",model.ClassName) ,
                        new SqlParameter("@MethodName",model.MethodName) ,
                        new SqlParameter("@ApiUrl",model.ApiUrl) ,
                        new SqlParameter("@RequestDate",model.RequestDate) ,
                        new SqlParameter("@RequestData",model.RequestData)

            };

            int rows = BWJSLogHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJSLog.Model.ApiInvokingLog GetModel(int ApiInvokingLogId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ApiInvokingLogId, ResponseDate, ResponseData, IsDeleted, CreateId, CreateDate, CompanyId, BusinessType, RelationId, ClassName, MethodName, ApiUrl, RequestDate, RequestData  ");
            strSql.Append("  from dbo.[ApiInvokingLog] ");
            strSql.Append(" where ApiInvokingLogId=@ApiInvokingLogId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ApiInvokingLogId", SqlDbType.Int,4)
            };
            parameters[0].Value = ApiInvokingLogId;


            BWJSLog.Model.ApiInvokingLog model = new BWJSLog.Model.ApiInvokingLog();
            DataSet ds = BWJSLogHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// datarow转成对象实体
        /// </summary>
        public BWJSLog.Model.ApiInvokingLog DataRowToModel(DataRow row)
        {
            BWJSLog.Model.ApiInvokingLog model = new BWJSLog.Model.ApiInvokingLog();

            if (row != null)
            {
                if (row["ApiInvokingLogId"].ToString() != "")
                {
                    model.ApiInvokingLogId = int.Parse(row["ApiInvokingLogId"].ToString());
                }
                if (row["ResponseDate"].ToString() != "")
                {
                    model.ResponseDate = DateTime.Parse(row["ResponseDate"].ToString());
                }
                model.ResponseData = row["ResponseData"].ToString();
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                if (row["CreateId"].ToString() != "")
                {
                    model.CreateId = int.Parse(row["CreateId"].ToString());
                }
                if (row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                }
                if (row["BusinessType"].ToString() != "")
                {
                    model.BusinessType = int.Parse(row["BusinessType"].ToString());
                }
                if (row["RelationId"].ToString() != "")
                {
                    model.RelationId = int.Parse(row["RelationId"].ToString());
                }
                model.ClassName = row["ClassName"].ToString();
                model.MethodName = row["MethodName"].ToString();
                model.ApiUrl = row["ApiUrl"].ToString();
                if (row["RequestDate"].ToString() != "")
                {
                    model.RequestDate = DateTime.Parse(row["RequestDate"].ToString());
                }
                model.RequestData = row["RequestData"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM dbo.[ApiInvokingLog] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSLogHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM dbo.[ApiInvokingLog] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSLogHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region ExtensionMethod
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ApiInvokingLogId, int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[ApiInvokingLog] set IsDeleted=1,EditId=@EditId,EditDate=@EditDate");
            strSql.Append(" where ApiInvokingLogId=@ApiInvokingLogId");
            SqlParameter[] parameters = {
                    new SqlParameter("@EditId", userId),
                    new SqlParameter("@EditDate", DateTime.Now),
                    new SqlParameter("@ApiInvokingLogId", ApiInvokingLogId),
            };

            int rows = BWJSLogHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string ApiInvokingLogIdlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.[ApiInvokingLog] set IsDeleted=1,EditId={0},EditDate='{1}'", userId, DateTime.Now);
            strSql.Append(" where ApiInvokingLogId in (" + ApiInvokingLogIdlist + ")  ");
            int rows = BWJSLogHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public DataTable GetList(string tablesql, string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            return BWJSLogHelperSQL.GetPageList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
        public DataTable GetList(string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            StringBuilder tablesql = new StringBuilder();
            tablesql.Append("select * ");
            tablesql.Append(" FROM dbo.[ApiInvokingLog] ");
            return BWJSLogHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion
        
    }
}
