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
    /// 用户角色
    /// </summary>
    public partial class UserRoleDAL : BaseService
    {
        public UserRoleDAL() { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.UserRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserRole(");
            strSql.Append("UserId,RoleId,CreateId,CreateDate,EditId,EditDate,IsDeleted");
            strSql.Append(") values (");
            strSql.Append("@UserId,@RoleId,@CreateId,@CreateDate,@EditId,@EditDate,@IsDeleted");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@UserId", model.UserId) ,
                        new SqlParameter("@RoleId", model.RoleId) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted)

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
        public bool Update(BWJS.Model.UserRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserRole set ");

            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" RoleId = @RoleId , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" IsDeleted = @IsDeleted  ");
            strSql.Append(" where UserRoleId=@UserRoleId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@UserRoleId",model.UserRoleId) ,
                        new SqlParameter("@UserId",model.UserId) ,
                        new SqlParameter("@RoleId",model.RoleId) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted)

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
        public bool Delete(int UserRoleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserRole set IsDeleted=1");
            strSql.Append(" where UserRoleId=@UserRoleId");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserRoleId", SqlDbType.Int,4)
            };
            parameters[0].Value = UserRoleId;


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
        public bool DeleteList(string UserRoleIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserRole set IsDeleted=1");
            strSql.Append(" where ID in (" + UserRoleIdlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.UserRole GetModel(int UserRoleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserRoleId, UserId, RoleId, CreateId, CreateDate, EditId, EditDate, IsDeleted  ");
            strSql.Append("  from UserRole ");
            strSql.Append(" where UserRoleId=@UserRoleId");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserRoleId", SqlDbType.Int,4)
            };
            parameters[0].Value = UserRoleId;


            BWJS.Model.UserRole model = new BWJS.Model.UserRole();
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
        public BWJS.Model.UserRole DataRowToModel(DataRow row)
        {
            BWJS.Model.UserRole model = new BWJS.Model.UserRole();

            if (row != null)
            {
                if (row["UserRoleId"].ToString() != "")
                {
                    model.UserRoleId = int.Parse(row["UserRoleId"].ToString());
                }
                if (row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["RoleId"].ToString() != "")
                {
                    model.RoleId = int.Parse(row["RoleId"].ToString());
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
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
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
            strSql.Append("select  top 1 * ");
            strSql.Append(" FROM UserRole ");
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
            strSql.Append(" FROM UserRole ");
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
            tablesql.Append("select * ");
            tablesql.Append(" FROM UserRole ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion

        #region ExtensionMethod


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetUserRoleName(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  ur.*,r.RoleName  FROM  UserRole  ur LEFT JOIN [role] r ON r.RoleId=ur.RoleId AND r.IsDeleted=0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateRole(BWJS.Model.UserRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UserRole SET IsDeleted=1 WHERE UserId=" + model.UserId + " AND IsDeleted=0;");
            strSql.Append(@" INSERT INTO UserRole ([UserId],[RoleId],[CreateId],[CreateDate] ,[EditId] ,[EditDate]  ,[IsDeleted])VALUES(@UserId
      ,@RoleId ,@CreateId,GETDATE()  ,@EditId,GETDATE() ,@IsDeleted);select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@UserId",model.UserId) ,
                        new SqlParameter("@RoleId",model.RoleId) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted)
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
        /// 获得数据列表
        /// </summary>
        public DataTable GetUserFunction(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select a.UserId,a.LoginName,a.UserName,b.RoleId,c.FunctionId,d.FunctionName,d.FunctionCode,d.FunctionClass,d.ParentId,d.ClassId,d.ExternalLinkAddress from [dbo].[Users] a 
left join[dbo].[UserRole] b on b.UserId = a.UserID and b.IsDeleted=0 
left join[dbo].[RoleFunction] c on c.RoleId = b.RoleId and c.IsDeleted=0
left join[dbo].[Function] d on d.FunctionId = c.FunctionId and d.IsDeleted=0
where a.UserId ={0} and a.RecordIsDelete=0", userId);
            return BWJSHelperSQL.ReturnDataTable(strSql.ToString());
        }
        #endregion
    }
}
