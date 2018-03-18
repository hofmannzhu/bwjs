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
    /// 角色
    /// </summary>
    public partial class RoleDAL : BaseService
    {
        public RoleDAL() { }

        #region BasicMethod
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Role(");
            strSql.Append("IsDeleted,RoleName,RoleType,RoleStatus,Remark,CreateId,CreateDate,EditId,EditDate,ParentId,IsManager");
            strSql.Append(") values (");
            strSql.Append("@IsDeleted,@RoleName,@RoleType,@RoleStatus,@Remark,@CreateId,@CreateDate,@EditId,@EditDate,@ParentId,@IsManager");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@RoleName", model.RoleName) ,
                        new SqlParameter("@RoleType", model.RoleType) ,
                        new SqlParameter("@RoleStatus", model.RoleStatus) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                         new SqlParameter("@ParentId", model.ParentId) ,
                          new SqlParameter("@IsManager", model.IsManager) ,
                        new SqlParameter("@EditDate", model.EditDate)
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
        public bool Update(BWJS.Model.Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Role] set ");

            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" RoleName = @RoleName , ");
            strSql.Append(" RoleType = @RoleType , ");
            strSql.Append(" RoleStatus = @RoleStatus , ");
            strSql.Append(" ParentId = @ParentId , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate, ");
            strSql.Append(" IsManager = @IsManager   ");
            strSql.Append(" where RoleId=@RoleId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@RoleId",model.RoleId) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@RoleName",model.RoleName) ,
                        new SqlParameter("@RoleType",model.RoleType) ,
                        new SqlParameter("@RoleStatus",model.RoleStatus) ,
                        new SqlParameter("@Remark",model.Remark) ,
                         new SqlParameter("@ParentId",model.ParentId) ,
                          new SqlParameter("@IsManager",model.IsManager) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate)

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
        public bool Delete(int RoleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Role set IsDeleted=1");
            strSql.Append(" where RoleId=@RoleId");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleId", SqlDbType.Int,4)
            };
            parameters[0].Value = RoleId;


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
        public bool DeleteList(string RoleIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Role set IsDeleted=1");
            strSql.Append(" where ID in (" + RoleIdlist + ")  ");
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
        public BWJS.Model.Role GetModel(int RoleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleId, IsDeleted, RoleName, RoleType, RoleStatus, Remark, CreateId, CreateDate, EditId, EditDate,IsManager  ");
            strSql.Append("  from Role ");
            strSql.Append(" where RoleId=@RoleId");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleId", SqlDbType.Int,4)
            };
            parameters[0].Value = RoleId;


            BWJS.Model.Role model = new BWJS.Model.Role();
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
        public BWJS.Model.Role DataRowToModel(DataRow row)
        {
            BWJS.Model.Role model = new BWJS.Model.Role();

            if (row != null)
            {
                if (row["RoleId"].ToString() != "")
                {
                    model.RoleId = int.Parse(row["RoleId"].ToString());
                }
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                model.RoleName = row["RoleName"].ToString();
                if (row["RoleType"].ToString() != "")
                {
                    model.RoleType = int.Parse(row["RoleType"].ToString());
                }
                if (row["RoleStatus"].ToString() != "")
                {
                    model.RoleStatus = int.Parse(row["RoleStatus"].ToString());
                }
                model.Remark = row["Remark"].ToString();
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
                if (row["IsManager"].ToString() == "1"|| row["IsManager"].ToString()=="true")
                {
                    model.IsManager = true;
                }
                if (row["IsManager"].ToString() != "")
                {
                    if ((row["IsManager"].ToString() == "1") || (row["IsManager"].ToString() == "true"))
                    {
                        model.IsManager = true;
                    }
                    else
                    {
                        model.IsManager = false;
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
            strSql.Append(" FROM [Role] ");
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
            strSql.Append(" FROM Role ");
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
            tablesql.Append(@"select r.*,r1.RoleName as ParentRoleName  FROM [Role] r left join [Role] r1 on r.ParentId=r1.RoleId and r1.IsDeleted=0");
            //tablesql.Append(" FROM [Role] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }
        #endregion

        #region ExtensionMethod


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Role GetRoleOne(int RoleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT   CreateDate ,
                                        CreateId ,
                                        EditDate ,
                                        EditId ,
                                        IsDeleted ,
                                        Remark ,
                                        RoleId ,
                                        RoleName ,
                                        RoleStatus ,
                                         IsManager,
                                        RoleType FROM  [role] WHERE IsDeleted=0 and RoleId=@RoleId");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleId", SqlDbType.Int,4)
            };
            parameters[0].Value = RoleId;
            Role model = new Role();
            DataSet ds = BWJSHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RoleId"].ToString() != "")
                {
                    model.RoleId = int.Parse(ds.Tables[0].Rows[0]["RoleId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleName"].ToString() != "")
                {
                    model.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RoleStatus"].ToString() != "")
                {
                    model.RoleStatus = ds.Tables[0].Rows[0]["RoleStatus"].ToString().ToInt();
                }
                if (ds.Tables[0].Rows[0]["RoleType"].ToString() != "")
                {
                    model.RoleType = ds.Tables[0].Rows[0]["RoleType"].ToString().ToInt();
                }
                if (ds.Tables[0].Rows[0]["CreateId"].ToString() != "")
                {
                    model.CreateId = int.Parse(ds.Tables[0].Rows[0]["CreateId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EditId"].ToString() != "")
                {
                    model.EditId = int.Parse(ds.Tables[0].Rows[0]["EditId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsDeleted"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsDeleted"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsDeleted"].ToString().ToLower() == "true"))
                    {
                        model.IsDeleted = 1;
                    }
                    else
                    {
                        model.IsDeleted = 0;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsManager"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsManager"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsManager"].ToString().ToLower() == "true"))
                    {
                        model.IsManager = true;
                    }
                    else
                    {
                        model.IsManager = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["EditDate"].ToString() != "")
                {
                    model.EditDate = DateTime.Parse(ds.Tables[0].Rows[0]["EditDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }

                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool UpdateDelete(int RoleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update  [Role]  set IsDeleted=1 where RoleId=@RoleId; UPDATE UserRole SET IsDeleted=1 WHERE RoleId=@RoleId AND IsDeleted=0");
      
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleId", RoleId)
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetParentNameList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT r.*,r2.RoleName AS ParentName FROM  [Role] r LEFT JOIN [role] r2 ON r.ParentId=r2.RoleId AND r2.IsDeleted=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        #endregion
    }
}
