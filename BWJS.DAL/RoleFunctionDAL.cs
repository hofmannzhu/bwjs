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
    /// 角色权限
    /// </summary>
    public partial class RoleFunctionDAL : BaseService
    {
        public RoleFunctionDAL() { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.RoleFunction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RoleFunction(");
            strSql.Append("RoleFunctionId,RoleId,FunctionId,CreateId,CreateDate,EditId,EditDate,IsDeleted");
            strSql.Append(") values (");
            strSql.Append("@RoleFunctionId,@RoleId,@FunctionId,@CreateId,@CreateDate,@EditId,@EditDate,@IsDeleted");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@RoleFunctionId", model.RoleFunctionId) ,
                        new SqlParameter("@RoleId", model.RoleId) ,
                        new SqlParameter("@FunctionId", model.FunctionId) ,
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
        public bool Update(BWJS.Model.RoleFunction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RoleFunction set ");

            strSql.Append(" RoleFunctionId = @RoleFunctionId , ");
            strSql.Append(" RoleId = @RoleId , ");
            strSql.Append(" FunctionId = @FunctionId , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" IsDeleted = @IsDeleted  ");
            strSql.Append(" where RoleFunctionId=@RoleFunctionId  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@RoleFunctionId",model.RoleFunctionId) ,
                        new SqlParameter("@RoleId",model.RoleId) ,
                        new SqlParameter("@FunctionId",model.FunctionId) ,
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
        public bool Delete(int RoleFunctionId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RoleFunction set IsDeleted=1");
            strSql.Append(" where RoleFunctionId=@RoleFunctionId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleFunctionId", SqlDbType.Int,4)            };
            parameters[0].Value = RoleFunctionId;


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
        public BWJS.Model.RoleFunction GetModel(int RoleFunctionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleFunctionId, RoleId, FunctionId, CreateId, CreateDate, EditId, EditDate, IsDeleted  ");
            strSql.Append("  from RoleFunction ");
            strSql.Append(" where RoleFunctionId=@RoleFunctionId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleFunctionId", SqlDbType.Int,4)            };
            parameters[0].Value = RoleFunctionId;


            BWJS.Model.RoleFunction model = new BWJS.Model.RoleFunction();
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
        public BWJS.Model.RoleFunction DataRowToModel(DataRow row)
        {
            BWJS.Model.RoleFunction model = new BWJS.Model.RoleFunction();

            if (row != null)
            {
                if (row["RoleFunctionId"].ToString() != "")
                {
                    model.RoleFunctionId = int.Parse(row["RoleFunctionId"].ToString());
                }
                if (row["RoleId"].ToString() != "")
                {
                    model.RoleId = int.Parse(row["RoleId"].ToString());
                }
                if (row["FunctionId"].ToString() != "")
                {
                    model.FunctionId = int.Parse(row["FunctionId"].ToString());
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
            strSql.Append("select * ");
            strSql.Append(" FROM RoleFunction ");
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
            strSql.Append(" FROM RoleFunction ");
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
            tablesql.Append(" FROM RoleFunction ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion

        #region ExtensionMethod


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateRoleFun(int RoleId, string FunctionArray)
        {
            StringBuilder strSql = new StringBuilder();
            string[] FunctionIDList = FunctionArray.Split(',');
            strSql.Append(" update [RoleFunction] set IsDeleted=1 where RoleId=" + RoleId + ";");
            for (int i = 0; i < (FunctionIDList.Count() - 1); i++)
            {
                if (FunctionIDList[i] != "" && FunctionIDList[i] != null)
                {
                    strSql.Append(@"insert into[RoleFunction]([RoleId] ,[FunctionId],[CreateId],[CreateDate],[EditId],[EditDate],[IsDeleted]) 
                                values(" + RoleId + ", " + FunctionIDList[i].ToInt() + ", 1 , getdate() , 1 , getdate(), 0);");
                }
            }

            SqlParameter[] parameters = { };

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

        #endregion





        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataSet GetAssignCheck(int RoleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from RoleFunction ");
            strSql.Append(" where RoleId=@RoleId and IsDeleted=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleId", SqlDbType.Int,4)};
            parameters[0].Value = RoleId;


            BWJS.Model.RoleFunction model = new BWJS.Model.RoleFunction();
            DataSet ds = BWJSHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }
    }
}
