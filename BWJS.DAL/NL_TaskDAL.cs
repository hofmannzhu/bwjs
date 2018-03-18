using UtilityHelper;
using UtilityHelper.Data;
using BWJS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BWJS.DAL
{
    /// <summary>
    /// 运营商爬取任务
    /// </summary>
    public partial class NL_TaskDAL
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.NL_Task model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[NL_Task](");
            strSql.Append("IsDeleted,CreateId,CreateDate,EditId,EditDate,ConsultId,TelNo,ServicePwd,TaskId,State,TaskStatus,ImgStr,Mark");
            strSql.Append(") values (");
            strSql.Append("@IsDeleted,@CreateId,@CreateDate,@EditId,@EditDate,@ConsultId,@TelNo,@ServicePwd,@TaskId,@State,@TaskStatus,@ImgStr,@Mark");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@ConsultId", model.ConsultId) ,
                        new SqlParameter("@TelNo", model.TelNo) ,
                        new SqlParameter("@ServicePwd", model.ServicePwd) ,
                        new SqlParameter("@TaskId", model.TaskId) ,
                        new SqlParameter("@State", model.State) ,
                        new SqlParameter("@TaskStatus", model.TaskStatus) ,
                        new SqlParameter("@ImgStr", model.ImgStr) ,
                        new SqlParameter("@Mark", model.Mark)

            };


            object obj = BWJSHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(BWJS.Model.NL_Task model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NL_Task] set ");

            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" ConsultId = @ConsultId , ");
            strSql.Append(" TelNo = @TelNo , ");
            strSql.Append(" ServicePwd = @ServicePwd , ");
            strSql.Append(" TaskId = @TaskId , ");
            strSql.Append(" State = @State , ");
            strSql.Append(" TaskStatus = @TaskStatus , ");
            strSql.Append(" ImgStr = @ImgStr , ");
            strSql.Append(" Mark = @Mark  ");
            strSql.Append(" where AutoId=@AutoId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@AutoId",model.AutoId) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@ConsultId",model.ConsultId) ,
                        new SqlParameter("@TelNo",model.TelNo) ,
                        new SqlParameter("@ServicePwd",model.ServicePwd) ,
                        new SqlParameter("@TaskId",model.TaskId) ,
                        new SqlParameter("@State",model.State) ,
                        new SqlParameter("@TaskStatus",model.TaskStatus) ,
                        new SqlParameter("@ImgStr",model.ImgStr) ,
                        new SqlParameter("@Mark",model.Mark)

            };

            int rows = BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public BWJS.Model.NL_Task GetModel(int AutoId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AutoId, IsDeleted, CreateId, CreateDate, EditId, EditDate, ConsultId, TelNo, ServicePwd, TaskId, State, TaskStatus, ImgStr, Mark  ");
            strSql.Append("  from dbo.[NL_Task] ");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
                    new SqlParameter("@AutoId", SqlDbType.Int,4)
            };
            parameters[0].Value = AutoId;


            BWJS.Model.NL_Task model = new BWJS.Model.NL_Task();
            DataSet ds = BWJSHelperSQL.Query(strSql.ToString(), parameters);

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
        public BWJS.Model.NL_Task DataRowToModel(DataRow row)
        {
            BWJS.Model.NL_Task model = new BWJS.Model.NL_Task();

            if (row != null)
            {
                if (row["AutoId"].ToString() != "")
                {
                    model.AutoId = int.Parse(row["AutoId"].ToString());
                }
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
                if (row["EditId"].ToString() != "")
                {
                    model.EditId = int.Parse(row["EditId"].ToString());
                }
                if (row["EditDate"].ToString() != "")
                {
                    model.EditDate = DateTime.Parse(row["EditDate"].ToString());
                }
                if (row["ConsultId"].ToString() != "")
                {
                    model.ConsultId = int.Parse(row["ConsultId"].ToString());
                }
                model.TelNo = row["TelNo"].ToString();
                model.ServicePwd = row["ServicePwd"].ToString();
                model.TaskId = row["TaskId"].ToString();
                model.State = row["State"].ToString();
                model.TaskStatus = row["TaskStatus"].ToString();
                model.ImgStr = row["ImgStr"].ToString();
                if (row["Mark"].ToString() != "")
                {
                    if ((row["Mark"].ToString() == "1") || (row["Mark"].ToString().ToLower() == "true"))
                    {
                        model.Mark = true;
                    }
                    else
                    {
                        model.Mark = false;
                    }
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
            strSql.Append(" FROM dbo.[NL_Task] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" FROM dbo.[NL_Task] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region ExtensionMethod
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AutoId, int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NL_Task] set IsDeleted=1,EditId=@EditId,EditDate=@EditDate");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
                    new SqlParameter("@EditId", userId),
                    new SqlParameter("@EditDate", DateTime.Now),
                    new SqlParameter("@AutoId", AutoId),
            };

            int rows = BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string AutoIdlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.[NL_Task] set IsDeleted=1,EditId={0},EditDate='{1}'", userId, DateTime.Now);
            strSql.Append(" where AutoId in (" + AutoIdlist + ")  ");
            int rows = BWJSHelperSQL.ExecuteSql(strSql.ToString());
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
            return BWJSHelperSQL.GetPageList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
            tablesql.Append(" FROM dbo.[NL_Task] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion
    }
}