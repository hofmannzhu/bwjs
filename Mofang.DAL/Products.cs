using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using Mofang.Model;
using UtilityHelper.Data;
using Mofang.Model.ViewModel;

namespace Mofang.DAL
{
    //终端产品展示表
    public partial class ProductsDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mofang.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Products(");
            strSql.Append("PeriodDate,PeriodAge,InsuranceDate,IsQuitInsure,CardTypeIDs,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordUpdateTime,RecordCreateTime,CompanyId,Remark,CompanyName,ProductTypeId,ProductTypeName,ProductCategoryId,ProductName,ProductPlan,CaseCode");
            strSql.Append(") values (");
            strSql.Append("@PeriodDate,@PeriodAge,@InsuranceDate,@IsQuitInsure,@CardTypeIDs,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordUpdateTime,@RecordCreateTime,@CompanyId,@Remark,@CompanyName,@ProductTypeId,@ProductTypeName,@ProductCategoryId,@ProductName,@ProductPlan,@CaseCode");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@PeriodDate", model.PeriodDate) ,
                        new SqlParameter("@PeriodAge", model.PeriodAge) ,
                        new SqlParameter("@InsuranceDate", model.InsuranceDate) ,
                        new SqlParameter("@IsQuitInsure", model.IsQuitInsure) ,
                        new SqlParameter("@CardTypeIDs", model.CardTypeIDs) ,
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime) ,
                        new SqlParameter("@CompanyId", model.CompanyId) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@CompanyName", model.CompanyName) ,
                        new SqlParameter("@ProductTypeId", model.ProductTypeId) ,
                        new SqlParameter("@ProductTypeName", model.ProductTypeName) ,
                        new SqlParameter("@ProductCategoryId", model.ProductCategoryId) ,
                        new SqlParameter("@ProductName", model.ProductName) ,
                        new SqlParameter("@ProductPlan", model.ProductPlan) ,
                        new SqlParameter("@CaseCode", model.CaseCode)

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
        public bool Update(Mofang.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set ");

            strSql.Append(" PeriodDate = @PeriodDate , ");
            strSql.Append(" PeriodAge = @PeriodAge , ");
            strSql.Append(" InsuranceDate = @InsuranceDate , ");
            strSql.Append(" IsQuitInsure = @IsQuitInsure , ");
            strSql.Append(" CardTypeIDs = @CardTypeIDs , ");
            strSql.Append(" CreatUserID = @CreatUserID , ");
            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");
            strSql.Append(" RecordIsDelete = @RecordIsDelete , ");
            strSql.Append(" RecordUpdateTime = @RecordUpdateTime , ");
            strSql.Append(" RecordCreateTime = @RecordCreateTime , ");
            strSql.Append(" CompanyId = @CompanyId , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" CompanyName = @CompanyName , ");
            strSql.Append(" ProductTypeId = @ProductTypeId , ");
            strSql.Append(" ProductTypeName = @ProductTypeName , ");
            strSql.Append(" ProductCategoryId = @ProductCategoryId , ");
            strSql.Append(" ProductName = @ProductName , ");
            strSql.Append(" ProductPlan = @ProductPlan , ");
            strSql.Append(" CaseCode = @CaseCode  ");
            strSql.Append(" where ProductsID=@ProductsID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ProductsID",model.ProductsID) ,
                        new SqlParameter("@PeriodDate",model.PeriodDate) ,
                        new SqlParameter("@PeriodAge",model.PeriodAge) ,
                        new SqlParameter("@InsuranceDate",model.InsuranceDate) ,
                        new SqlParameter("@IsQuitInsure",model.IsQuitInsure) ,
                        new SqlParameter("@CardTypeIDs",model.CardTypeIDs) ,
                        new SqlParameter("@CreatUserID",model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID",model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete",model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime",model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime",model.RecordCreateTime) ,
                        new SqlParameter("@CompanyId",model.CompanyId) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@CompanyName",model.CompanyName) ,
                        new SqlParameter("@ProductTypeId",model.ProductTypeId) ,
                        new SqlParameter("@ProductTypeName",model.ProductTypeName) ,
                        new SqlParameter("@ProductCategoryId",model.ProductCategoryId) ,
                        new SqlParameter("@ProductName",model.ProductName) ,
                        new SqlParameter("@ProductPlan",model.ProductPlan) ,
                        new SqlParameter("@CaseCode",model.CaseCode)

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
        public bool Delete(int ProductsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set IsDeleted=1");
            strSql.Append(" where ProductsID=@ProductsID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProductsID", SqlDbType.Int,4)
            };
            parameters[0].Value = ProductsID;


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
        public bool DeleteList(string ProductsIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set IsDeleted=1");
            strSql.Append(" where ID in (" + ProductsIDlist + ")  ");
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
        public Mofang.Model.Products GetModel(int ProductsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProductsID, PeriodDate, PeriodAge, InsuranceDate, IsQuitInsure, CardTypeIDs, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime, RecordCreateTime, CompanyId, Remark, CompanyName, ProductTypeId, ProductTypeName, ProductCategoryId, ProductName, ProductPlan, CaseCode  ");
            strSql.Append("  from Products ");
            strSql.Append(" where ProductsID=@ProductsID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProductsID", SqlDbType.Int,4)
            };
            parameters[0].Value = ProductsID;


            Mofang.Model.Products model = new Mofang.Model.Products();
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
        public Mofang.Model.Products DataRowToModel(DataRow row)
        {
            Mofang.Model.Products model = new Mofang.Model.Products();

            if (row != null)
            {
                if (row["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(row["ProductsID"].ToString());
                }
                model.PeriodDate = row["PeriodDate"].ToString();
                model.PeriodAge = row["PeriodAge"].ToString();
                model.InsuranceDate = row["InsuranceDate"].ToString();
                model.IsQuitInsure = row["IsQuitInsure"].ToString();
                model.CardTypeIDs = row["CardTypeIDs"].ToString();
                if (row["CreatUserID"].ToString() != "")
                {
                    model.CreatUserID = int.Parse(row["CreatUserID"].ToString());
                }
                if (row["RecordUpdateUserID"].ToString() != "")
                {
                    model.RecordUpdateUserID = int.Parse(row["RecordUpdateUserID"].ToString());
                }
                if (row["RecordIsDelete"].ToString() != "")
                {
                    if ((row["RecordIsDelete"].ToString() == "1") || (row["RecordIsDelete"].ToString().ToLower() == "true"))
                    {
                        model.RecordIsDelete = true;
                    }
                    else
                    {
                        model.RecordIsDelete = false;
                    }
                }
                if (row["RecordUpdateTime"].ToString() != "")
                {
                    model.RecordUpdateTime = DateTime.Parse(row["RecordUpdateTime"].ToString());
                }
                if (row["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(row["RecordCreateTime"].ToString());
                }
                if (row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                }
                model.Remark = row["Remark"].ToString();
                model.CompanyName = row["CompanyName"].ToString();
                if (row["ProductTypeId"].ToString() != "")
                {
                    model.ProductTypeId = int.Parse(row["ProductTypeId"].ToString());
                }
                model.ProductTypeName = row["ProductTypeName"].ToString();
                if (row["ProductCategoryId"].ToString() != "")
                {
                    model.ProductCategoryId = int.Parse(row["ProductCategoryId"].ToString());
                }
                model.ProductName = row["ProductName"].ToString();
                model.ProductPlan = row["ProductPlan"].ToString();
                model.CaseCode = row["CaseCode"].ToString();

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
            strSql.Append(" FROM Products ");
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
            strSql.Append(" FROM Products ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region ExtensionMethod

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool UpdateDelete(int ProductsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set  RecordIsDelete =1   ");
            strSql.Append(" where ProductsID=@ProductsID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProductsID", SqlDbType.Int,4)
            };
            parameters[0].Value = ProductsID;


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
        public bool UpdateDeleteList(string ProductsIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set  RecordIsDelete =1");
            strSql.Append(" where ID in (" + ProductsIDlist + ")  ");
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

        public List<ProductsViewModel> GetProducts(int CategoryId)
        {
            try
            {
                string strOrderBy = " ";
                string strOutFields = "ProductsID,CompanyName,ProductName,CategoryName,CaseCode,ProductPictureUrl,ProducDescribe";
                string strSelectFields = "a.ProductsID,a.CompanyName,a.ProductName,b.CategoryName,a.CaseCode,a.ProductPictureUrl,a.ProducDescribe";
                string strTable = @"products a
                    Left join   ProductCategory b on b.ProductCategoryID=a.ProductCategoryID ";
                string strSql = "SELECT  " + strSelectFields + " FROM " + strTable + " WHERE  a.RecordIsDelete= 0   ";
                string strWhere = " and b.ProductCategoryID=" + CategoryId;
                strSql = strSql + strWhere;
                strSql = strSql + strOrderBy;
                SqlParameter[] parameters = new SqlParameter[]{
                // new SqlParameter ("@TypeID",TypeID)
               };
                List<ProductsViewModel> list = SqlDataUtilityHelper.GetListFromDB<ProductsViewModel>(strOutFields, ConnectionString, strSql, parameters);

                return list;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
       

        public List<Products> ProductsByCaseCode(string caseCode)
        {
            try
            {
                string strOrderBy = "  ";
                string strOutFields = "ProductsID,CompanyId ,CompanyName ,ProductTypeId ,ProductTypeName ,ProductCategoryId ,ProductName  ,ProductPlan,CaseCode ,PeriodDate ,PeriodAge,InsuranceDate,IsQuitInsure,CardTypeIDs,CreatUserID ,RecordUpdateUserID ,RecordIsDelete ,RecordUpdateTime ,RecordCreateTime,Remark";
                string strSelectFields = " ProductsID,CompanyId ,CompanyName ,ProductTypeId ,ProductTypeName ,ProductCategoryId ,ProductName  ,ProductPlan,CaseCode ,PeriodDate ,PeriodAge,InsuranceDate,IsQuitInsure,CardTypeIDs,CreatUserID ,RecordUpdateUserID ,RecordIsDelete ,RecordUpdateTime ,RecordCreateTime,Remark ";
                string strTable = @" Products ";
                string strSql = "SELECT  " + strSelectFields + " FROM " + strTable + "   ";
                string strWhere = " where CaseCode='" + caseCode + "'";
                strSql = strSql + strWhere;
                strSql = strSql + strOrderBy;
                SqlParameter[] parameters = new SqlParameter[]{
                // new SqlParameter ("@TypeID",TypeID)
               };
                List<Products> list = SqlDataUtilityHelper.GetListFromDB<Products>(strOutFields, ConnectionString, strSql, parameters);

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

