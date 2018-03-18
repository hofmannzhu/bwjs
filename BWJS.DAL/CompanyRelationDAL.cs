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
    /// 渠道关系
    /// </summary>
    public partial class CompanyRelationDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(BWJS.Model.CompanyRelation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[CompanyRelation](");
            strSql.Append("CreateDate,EditId,EditDate,CompanyId,UserId,DepartmentId,RecommendationCode,QRCode,Remark,IsDeleted,CreateId,API");
            strSql.Append(") values (");
            strSql.Append("@CreateDate,@EditId,@EditDate,@CompanyId,@UserId,@DepartmentId,@RecommendationCode,@QRCode,@Remark,@IsDeleted,@CreateId,@API");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@CompanyId", model.CompanyId) ,
                        new SqlParameter("@UserId", model.UserId) ,
                        new SqlParameter("@DepartmentId", model.DepartmentId) ,
                        new SqlParameter("@RecommendationCode", model.RecommendationCode) ,
                        new SqlParameter("@QRCode", model.QRCode) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CreateId", model.CreateId),
                        new SqlParameter("@API", model.API)
            };
            BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.CompanyRelation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[CompanyRelation] set ");

            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" CompanyId = @CompanyId , ");
            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" DepartmentId = @DepartmentId , ");
            strSql.Append(" RecommendationCode = @RecommendationCode , ");
            strSql.Append(" QRCode = @QRCode , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" API = @API ");
            strSql.Append(" where CompanyRelationId=@CompanyRelationId ");
            //strSql.Append(" where CompanyId=@CompanyId and UserId=@UserId  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@CompanyRelationId",model.CompanyRelationId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@CompanyId",model.CompanyId) ,
                        new SqlParameter("@UserId",model.UserId) ,
                        new SqlParameter("@DepartmentId",model.DepartmentId) ,
                        new SqlParameter("@RecommendationCode",model.RecommendationCode) ,
                        new SqlParameter("@QRCode",model.QRCode) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted),
                        new SqlParameter("@API",model.API)
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int CompanyId, int UserId, int EditId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[CompanyRelation] set IsDeleted=1,EditDate=GETDATE(),EditId=@EditId");
            strSql.Append(" where CompanyId=@CompanyId and UserId=@UserId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@CompanyId", SqlDbType.Int,4),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
            new SqlParameter("@EditId", SqlDbType.Int,4)  };
            parameters[0].Value = CompanyId;
            parameters[1].Value = UserId;
            parameters[2].Value = EditId;
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
        public bool DeleteList(string companyRelationIdlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.[CompanyRelation] set IsDeleted=1,EditId={0},EditDate='{1}'", userId, DateTime.Now);
            strSql.Append(" where CompanyRelationId in (" + companyRelationIdlist + ")  ");
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

        public DataSet GetModelListName(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,a2.CompanyName,a2.MainBusiness,a3.UserName,a4.DepartmentName from [BWJSDB].[dbo].[CompanyRelation] a left join [BWJSDB].[dbo].[Company] a2 on a.CompanyId = a2.CompanyId left join [BWJSDB].[dbo].[Users] a3 on a.UserId = a3.UserID left join [BWJSDB].[dbo].[DepartmentInfo] a4 on a.DepartmentId = a4.DepartmentId");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.CompanyRelation GetModel(int CompanyId, int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CompanyRelationId, CreateDate, EditId, EditDate, CompanyId, UserId, DepartmentId, RecommendationCode, QRCode, Remark, IsDeleted, CreateId ,API ");
            strSql.Append("  from dbo.[CompanyRelation] ");
            strSql.Append(" where CompanyId=@CompanyId and UserId=@UserId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@CompanyId", SqlDbType.Int,4),
                    new SqlParameter("@UserId", SqlDbType.Int,4)            };
            parameters[0].Value = CompanyId;
            parameters[1].Value = UserId;


            BWJS.Model.CompanyRelation model = new BWJS.Model.CompanyRelation();
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
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public CompanyRelationBackups DataRowToModelName(DataRow row)
        {
            CompanyRelationBackups model = new CompanyRelationBackups();

            if (row != null)
            {
                if (row["CompanyRelationId"].ToString() != "")
                {
                    model.CompanyRelationId = int.Parse(row["CompanyRelationId"].ToString());
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
                if (row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                }
                if (row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["DepartmentId"].ToString() != "")
                {
                    model.DepartmentId = int.Parse(row["DepartmentId"].ToString());
                }
                model.RecommendationCode = row["RecommendationCode"].ToString();
                model.QRCode = row["QRCode"].ToString();
                model.Remark = row["Remark"].ToString();
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                if (row["CreateId"].ToString() != "")
                {
                    model.CreateId = int.Parse(row["CreateId"].ToString());
                }
                if (row["API"].ToString() != "")
                {
                    model.API = row["API"].ToString();
                }
                if (row["UserName"].ToString() != "")
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["CompanyName"].ToString() != "")
                {
                    model.CompanyName = row["CompanyName"].ToString();
                }
                if (row["DepartmentName"].ToString() != "")
                {
                    model.DepartmentName = row["DepartmentName"].ToString();
                }
                if (row["MainBusiness"].ToString() != "")
                {
                    model.MainBusiness = row["MainBusiness"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体重载
        /// </summary>
        /// <param name="CompanyRelationId"></param>
        /// <returns></returns>
        public BWJS.Model.CompanyRelation GetModel(int CompanyRelationId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CompanyRelation ");
            strSql.Append(" where CompanyRelationId=@CompanyRelationId");
            SqlParameter[] parameters = {
                    new SqlParameter("@CompanyRelationId", SqlDbType.Int,4)
            };
            parameters[0].Value = CompanyRelationId;
            BWJS.Model.CompanyRelation model = new BWJS.Model.CompanyRelation();
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
        public BWJS.Model.CompanyRelation DataRowToModel(DataRow row)
        {
            BWJS.Model.CompanyRelation model = new BWJS.Model.CompanyRelation();

            if (row != null)
            {
                if (row["CompanyRelationId"].ToString() != "")
                {
                    model.CompanyRelationId = int.Parse(row["CompanyRelationId"].ToString());
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
                if (row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                }
                if (row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["DepartmentId"].ToString() != "")
                {
                    model.DepartmentId = int.Parse(row["DepartmentId"].ToString());
                }
                model.RecommendationCode = row["RecommendationCode"].ToString();
                model.QRCode = row["QRCode"].ToString();
                model.Remark = row["Remark"].ToString();
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                if (row["CreateId"].ToString() != "")
                {
                    model.CreateId = int.Parse(row["CreateId"].ToString());
                }
                if (row["API"].ToString() != "")
                {
                    model.API = row["API"].ToString();
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
            strSql.Append(" FROM CompanyRelation ");
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
            strSql.Append(" FROM CompanyRelation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSHelperSQL.Query(strSql.ToString());
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
            //tablesql.Append("select * ");
            //tablesql.Append(" FROM dbo.[CompanyRelation] a");
            //tablesql.Append(@"select a.*,a2.CompanyName,a3.UserName from [BWJSDB].[dbo].[CompanyRelation] a inner join [BWJSDB].[dbo].[Company] a2 on a.CompanyId = a2.CompanyId inner join [BWJSDB].[dbo].[Users] a3 on a.UserId = a3.UserID");
            tablesql.Append(@"select a.*,a2.CompanyName,a2.MainBusiness,a3.UserName,a4.DepartmentName from [BWJSDB].[dbo].[CompanyRelation] a left join [BWJSDB].[dbo].[Company] a2 on a.CompanyId = a2.CompanyId left join [BWJSDB].[dbo].[Users] a3 on a.UserId = a3.UserID left join [BWJSDB].[dbo].[DepartmentInfo] a4 on a.DepartmentId = a4.DepartmentId");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }
        #endregion

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
