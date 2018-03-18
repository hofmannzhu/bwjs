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
    /// 产品分类映射
    /// </summary>
    public partial class ProductRelationDAL : BaseService
    {
        public ProductRelationDAL() { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.ProductRelation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductRelation(");
            strSql.Append("ClassId,ProductId");
            strSql.Append(") values (");
            strSql.Append("@ClassId,@ProductId");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@ClassId", model.ClassId) ,
                        new SqlParameter("@ProductId", model.ProductId)

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
        public bool Update(BWJS.Model.ProductRelation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductRelation set ");

            strSql.Append(" ClassId = @ClassId , ");
            strSql.Append(" ProductId = @ProductId  ");
            strSql.Append(" where ProductRelationId=@ProductRelationId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ProductRelationId",model.ProductRelationId) ,
                        new SqlParameter("@ClassId",model.ClassId) ,
                        new SqlParameter("@ProductId",model.ProductId)

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
        public bool Delete(int ProductRelationId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductRelation set IsDeleted=1");
            strSql.Append(" where ProductRelationId=@ProductRelationId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProductRelationId", SqlDbType.Int,4)
            };
            parameters[0].Value = ProductRelationId;


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
        public bool DeleteList(string ProductRelationIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductRelation set IsDeleted=1");
            strSql.Append(" where ID in (" + ProductRelationIdlist + ")  ");
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
        public BWJS.Model.ProductRelation GetModel(int ProductRelationId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProductRelationId, ClassId, ProductId  ");
            strSql.Append("  from ProductRelation ");
            strSql.Append(" where ProductRelationId=@ProductRelationId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProductRelationId", SqlDbType.Int,4)
            };
            parameters[0].Value = ProductRelationId;


            BWJS.Model.ProductRelation model = new BWJS.Model.ProductRelation();
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
        public BWJS.Model.ProductRelation DataRowToModel(DataRow row)
        {
            BWJS.Model.ProductRelation model = new BWJS.Model.ProductRelation();

            if (row != null)
            {
                if (row["ProductRelationId"].ToString() != "")
                {
                    model.ProductRelationId = int.Parse(row["ProductRelationId"].ToString());
                }
                if (row["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(row["ClassId"].ToString());
                }
                if (row["ProductId"].ToString() != "")
                {
                    model.ProductId = int.Parse(row["ProductId"].ToString());
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
            strSql.Append(" FROM ProductRelation ");
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
            strSql.Append(" FROM ProductRelation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        #endregion

        #region ExtensionMethod

        #endregion
    }
}
