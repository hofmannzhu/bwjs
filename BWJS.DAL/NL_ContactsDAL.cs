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
    /// 联系人信息
    /// </summary>
    public partial class NL_ContactsDAL
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.NL_Contacts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[NL_Contacts](");
            strSql.Append("EditId,EditDate,ConsultId,FullName,Mobile,RelationId,Depth,IsDeleted,CreateId,CreateDate");
            strSql.Append(") values (");
            strSql.Append("@EditId,@EditDate,@ConsultId,@FullName,@Mobile,@RelationId,@Depth,@IsDeleted,@CreateId,@CreateDate");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@ConsultId", model.ConsultId) ,
                        new SqlParameter("@FullName", model.FullName) ,
                        new SqlParameter("@Mobile", model.Mobile) ,
                        new SqlParameter("@RelationId", model.RelationId) ,
                        new SqlParameter("@Depth", model.Depth) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate)

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
        public bool Update(BWJS.Model.NL_Contacts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NL_Contacts] set ");

            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" ConsultId = @ConsultId , ");
            strSql.Append(" FullName = @FullName , ");
            strSql.Append(" Mobile = @Mobile , ");
            strSql.Append(" RelationId = @RelationId , ");
            strSql.Append(" Depth = @Depth , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate  ");
            strSql.Append(" where ContactId=@ContactId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ContactId",model.ContactId) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@ConsultId",model.ConsultId) ,
                        new SqlParameter("@FullName",model.FullName) ,
                        new SqlParameter("@Mobile",model.Mobile) ,
                        new SqlParameter("@RelationId",model.RelationId) ,
                        new SqlParameter("@Depth",model.Depth) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate)

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
        public BWJS.Model.NL_Contacts GetModel(int ContactId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ContactId, EditId, EditDate, ConsultId, FullName, Mobile, RelationId, Depth, IsDeleted, CreateId, CreateDate  ");
            strSql.Append("  from dbo.[NL_Contacts] ");
            strSql.Append(" where ContactId=@ContactId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ContactId", SqlDbType.Int,4)
            };
            parameters[0].Value = ContactId;


            BWJS.Model.NL_Contacts model = new BWJS.Model.NL_Contacts();
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
        public BWJS.Model.NL_Contacts DataRowToModel(DataRow row)
        {
            BWJS.Model.NL_Contacts model = new BWJS.Model.NL_Contacts();

            if (row != null)
            {
                if (row["ContactId"].ToString() != "")
                {
                    model.ContactId = int.Parse(row["ContactId"].ToString());
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
                model.FullName = row["FullName"].ToString();
                model.Mobile = row["Mobile"].ToString();
                if (row["RelationId"].ToString() != "")
                {
                    model.RelationId = int.Parse(row["RelationId"].ToString());
                }
                if (row["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(row["Depth"].ToString());
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
            strSql.Append(" FROM dbo.[NL_Contacts] ");
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
            strSql.Append(" FROM dbo.[NL_Contacts] ");
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
        public bool Delete(int ContactId, int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NL_Contacts] set IsDeleted=1,EditId=@EditId,EditDate=@EditDate");
            strSql.Append(" where ContactId=@ContactId");
            SqlParameter[] parameters = {
                    new SqlParameter("@EditId", userId),
                    new SqlParameter("@EditDate", DateTime.Now),
                    new SqlParameter("@ContactId", ContactId),
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
        public bool DeleteList(string ContactIdlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.[NL_Contacts] set IsDeleted=1,EditId={0},EditDate='{1}'", userId, DateTime.Now);
            strSql.Append(" where ContactId in (" + ContactIdlist + ")  ");
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string consultIds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.[NL_Contacts] set IsDeleted=1,EditDate='{0}'", DateTime.Now);
            strSql.Append(" where ConsultId in (" + consultIds + ")  ");
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
            tablesql.Append(" FROM dbo.[NL_Contacts] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion
    }
}