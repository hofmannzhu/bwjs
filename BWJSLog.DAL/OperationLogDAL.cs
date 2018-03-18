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
    /// 操作日志
    /// </summary>
    public partial class OperationLogDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJSLog.Model.OperationLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[OperationLog](");
            strSql.Append("DepartmentName,RoleId,RoleName,GroupId,GroupName,BusinessType,RelationId,LogContent,Ip,UserId,RealName,CreateDate,DepartmentId");
            strSql.Append(") values (");
            strSql.Append("@DepartmentName,@RoleId,@RoleName,@GroupId,@GroupName,@BusinessType,@RelationId,@LogContent,@Ip,@UserId,@RealName,@CreateDate,@DepartmentId");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@DepartmentName", model.DepartmentName) ,
                        new SqlParameter("@RoleId", model.RoleId) ,
                        new SqlParameter("@RoleName", model.RoleName) ,
                        new SqlParameter("@GroupId", model.GroupId) ,
                        new SqlParameter("@GroupName", model.GroupName) ,
                        new SqlParameter("@BusinessType", model.BusinessType) ,
                        new SqlParameter("@RelationId", model.RelationId) ,
                        new SqlParameter("@LogContent", model.LogContent) ,
                        new SqlParameter("@Ip", model.Ip) ,
                        new SqlParameter("@UserId", model.UserId) ,
                        new SqlParameter("@RealName", model.RealName) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@DepartmentId", model.DepartmentId)

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
        public bool Update(BWJSLog.Model.OperationLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OperationLog] set ");

            strSql.Append(" DepartmentName = @DepartmentName , ");
            strSql.Append(" RoleId = @RoleId , ");
            strSql.Append(" RoleName = @RoleName , ");
            strSql.Append(" GroupId = @GroupId , ");
            strSql.Append(" GroupName = @GroupName , ");
            strSql.Append(" BusinessType = @BusinessType , ");
            strSql.Append(" RelationId = @RelationId , ");
            strSql.Append(" LogContent = @LogContent , ");
            strSql.Append(" Ip = @Ip , ");
            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" RealName = @RealName , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" DepartmentId = @DepartmentId  ");
            strSql.Append(" where OperationLogId=@OperationLogId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@OperationLogId",model.OperationLogId) ,
                        new SqlParameter("@DepartmentName",model.DepartmentName) ,
                        new SqlParameter("@RoleId",model.RoleId) ,
                        new SqlParameter("@RoleName",model.RoleName) ,
                        new SqlParameter("@GroupId",model.GroupId) ,
                        new SqlParameter("@GroupName",model.GroupName) ,
                        new SqlParameter("@BusinessType",model.BusinessType) ,
                        new SqlParameter("@RelationId",model.RelationId) ,
                        new SqlParameter("@LogContent",model.LogContent) ,
                        new SqlParameter("@Ip",model.Ip) ,
                        new SqlParameter("@UserId",model.UserId) ,
                        new SqlParameter("@RealName",model.RealName) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@DepartmentId",model.DepartmentId)

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
        public BWJSLog.Model.OperationLog GetModel(int OperationLogId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OperationLogId, DepartmentName, RoleId, RoleName, GroupId, GroupName, BusinessType, RelationId, LogContent, Ip, UserId, RealName, CreateDate, DepartmentId  ");
            strSql.Append("  from dbo.[OperationLog] ");
            strSql.Append(" where OperationLogId=@OperationLogId");
            SqlParameter[] parameters = {
                    new SqlParameter("@OperationLogId", SqlDbType.Int,4)
            };
            parameters[0].Value = OperationLogId;


            BWJSLog.Model.OperationLog model = new BWJSLog.Model.OperationLog();
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
        public BWJSLog.Model.OperationLog DataRowToModel(DataRow row)
        {
            BWJSLog.Model.OperationLog model = new BWJSLog.Model.OperationLog();

            if (row != null)
            {
                if (row["OperationLogId"].ToString() != "")
                {
                    model.OperationLogId = int.Parse(row["OperationLogId"].ToString());
                }
                model.DepartmentName = row["DepartmentName"].ToString();
                if (row["RoleId"].ToString() != "")
                {
                    model.RoleId = int.Parse(row["RoleId"].ToString());
                }
                model.RoleName = row["RoleName"].ToString();
                if (row["GroupId"].ToString() != "")
                {
                    model.GroupId = int.Parse(row["GroupId"].ToString());
                }
                model.GroupName = row["GroupName"].ToString();
                if (row["BusinessType"].ToString() != "")
                {
                    model.BusinessType = int.Parse(row["BusinessType"].ToString());
                }
                if (row["RelationId"].ToString() != "")
                {
                    model.RelationId = int.Parse(row["RelationId"].ToString());
                }
                model.LogContent = row["LogContent"].ToString();
                model.Ip = row["Ip"].ToString();
                if (row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                model.RealName = row["RealName"].ToString();
                if (row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["DepartmentId"].ToString() != "")
                {
                    model.DepartmentId = int.Parse(row["DepartmentId"].ToString());
                }

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
            strSql.Append(" FROM dbo.[OperationLog] ");
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
            strSql.Append(" FROM dbo.[OperationLog] ");
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
        public bool Delete(int OperationLogId, int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OperationLog] set IsDeleted=1,EditId=@EditId,EditDate=@EditDate");
            strSql.Append(" where OperationLogId=@OperationLogId");
            SqlParameter[] parameters = {
                    new SqlParameter("@EditId", userId),
                    new SqlParameter("@EditDate", DateTime.Now),
                    new SqlParameter("@OperationLogId", OperationLogId),
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
        public bool DeleteList(string OperationLogIdlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.[OperationLog] set IsDeleted=1,EditId={0},EditDate='{1}'", userId, DateTime.Now);
            strSql.Append(" where OperationLogId in (" + OperationLogIdlist + ")  ");
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
            tablesql.Append(" FROM dbo.[OperationLog] ");
            return BWJSLogHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion
    }
}
