using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using Mofang.Model;
using UtilityHelper.Data;

namespace Mofang.DAL
{
    /// <summary>
    /// 产品分类表
    /// </summary>
    public partial class ProductCategoryDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mofang.Model.ProductCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductCategory(");
            strSql.Append("CategoryName,OrderId,ParentId");
            strSql.Append(") values (");
            strSql.Append("@CategoryName,@OrderId,@ParentId");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@CategoryName", model.CategoryName) ,
                        new SqlParameter("@OrderId", model.OrderId) ,
                        new SqlParameter("@ParentId", model.ParentId)

            };


            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Mofang.Model.ProductCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductCategory set ");

            strSql.Append(" CategoryName = @CategoryName , ");
            strSql.Append(" OrderId = @OrderId , ");
            strSql.Append(" ParentId = @ParentId  ");
            strSql.Append(" where ProductCategoryId=@ProductCategoryId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ProductCategoryId",model.ProductCategoryId) ,
                        new SqlParameter("@CategoryName",model.CategoryName) ,
                        new SqlParameter("@OrderId",model.OrderId) ,
                        new SqlParameter("@ParentId",model.ParentId)

            };

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int ProductCategoryId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductCategory set IsDeleted=1");
            strSql.Append(" where ProductCategoryId=@ProductCategoryId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProductCategoryId", SqlDbType.Int,4)
            };
            parameters[0].Value = ProductCategoryId;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string ProductCategoryIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductCategory set IsDeleted=1");
            strSql.Append(" where ID in (" + ProductCategoryIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Mofang.Model.ProductCategory GetModel(int ProductCategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProductCategoryId, CategoryName, OrderId, ParentId  ");
            strSql.Append("  from ProductCategory ");
            strSql.Append(" where ProductCategoryId=@ProductCategoryId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProductCategoryId", SqlDbType.Int,4)
            };
            parameters[0].Value = ProductCategoryId;


            Mofang.Model.ProductCategory model = new Mofang.Model.ProductCategory();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

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
        public Mofang.Model.ProductCategory DataRowToModel(DataRow row)
        {
            Mofang.Model.ProductCategory model = new Mofang.Model.ProductCategory();

            if (row != null)
            {
                if (row["ProductCategoryId"].ToString() != "")
                {
                    model.ProductCategoryId = int.Parse(row["ProductCategoryId"].ToString());
                }
                model.CategoryName = row["CategoryName"].ToString();
                if (row["OrderId"].ToString() != "")
                {
                    model.OrderId = int.Parse(row["OrderId"].ToString());
                }
                if (row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
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
            strSql.Append(" FROM ProductCategory ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" FROM ProductCategory ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region ExtensionMethod
        public List<ProductCategory> GetCardTypeList()
        {
            try
            {
                string strOrderBy = " order by OrderId asc";
                string strOutFields = "ProductCategoryId,CategoryName,OrderId,ParentId,ProductCaPictureUrl";
                string strSelectFields = " ProductCategoryId,CategoryName,OrderId,ParentId,ProductCaPictureUrl";
                string strTable = @" ProductCategory ";
                string strSql = "SELECT  " + strSelectFields + " FROM " + strTable + "   ";
                string strWhere = "";
                strSql = strSql + strWhere;
                strSql = strSql + strOrderBy;
                SqlParameter[] parameters = new SqlParameter[]{
                // new SqlParameter ("@TypeID",TypeID)
               };
                List<ProductCategory> list = SqlDataUtilityHelper.GetListFromDB<ProductCategory>(strOutFields, ConnectionString, strSql, parameters);

                return list;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        #endregion
    }
}

