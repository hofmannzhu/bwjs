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
    /// 渠道网贷扩展
    /// </summary>
    public partial class CompanyNetLoanDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(BWJS.Model.CompanyNetLoan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[CompanyNetLoan](");
            strSql.Append("CompanyId,IsDeleted,CreateId,CreateDate,EditId,EditDate,HighestLoan,IsHaveGuarantee,IsMortgage,MaxMonthlyInterest,LoanPrescription,DescriptionHtml,Remark");
            strSql.Append(") values (");
            strSql.Append("@CompanyId,@IsDeleted,@CreateId,@CreateDate,@EditId,@EditDate,@HighestLoan,@IsHaveGuarantee,@IsMortgage,@MaxMonthlyInterest,@LoanPrescription,@DescriptionHtml,@Remark");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@CompanyId", model.CompanyId) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@HighestLoan", model.HighestLoan) ,
                        new SqlParameter("@IsHaveGuarantee", model.IsHaveGuarantee) ,
                        new SqlParameter("@IsMortgage", model.IsMortgage) ,
                        new SqlParameter("@MaxMonthlyInterest", model.MaxMonthlyInterest) ,
                        new SqlParameter("@LoanPrescription", model.LoanPrescription) ,
                        new SqlParameter("@DescriptionHtml", model.DescriptionHtml) ,
                        new SqlParameter("@Remark", model.Remark)

            };

            BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.CompanyNetLoan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[CompanyNetLoan] set ");

            strSql.Append(" CompanyId = @CompanyId , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" HighestLoan = @HighestLoan , ");
            strSql.Append(" IsHaveGuarantee = @IsHaveGuarantee , ");
            strSql.Append(" IsMortgage = @IsMortgage , ");
            strSql.Append(" MaxMonthlyInterest = @MaxMonthlyInterest , ");
            strSql.Append(" LoanPrescription = @LoanPrescription , ");
            strSql.Append(" DescriptionHtml = @DescriptionHtml , ");
            strSql.Append(" Remark = @Remark  ");
            strSql.Append(" where CompanyId=@CompanyId  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@CompanyId",model.CompanyId) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@HighestLoan",model.HighestLoan) ,
                        new SqlParameter("@IsHaveGuarantee",model.IsHaveGuarantee) ,
                        new SqlParameter("@IsMortgage",model.IsMortgage) ,
                        new SqlParameter("@MaxMonthlyInterest",model.MaxMonthlyInterest) ,
                        new SqlParameter("@LoanPrescription",model.LoanPrescription) ,
                        new SqlParameter("@DescriptionHtml",model.DescriptionHtml) ,
                        new SqlParameter("@Remark",model.Remark)

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
        public bool Delete(int CompanyId,int EditId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[CompanyNetLoan] set IsDeleted=1,EditDate=GETDATE(),EditId=@EditId");
            strSql.Append(" where CompanyId=@CompanyId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@CompanyId", SqlDbType.Int,4),
            new SqlParameter("@EditId", SqlDbType.Int,4) };
            parameters[0].Value = CompanyId;
            parameters[1].Value = EditId;

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
        public BWJS.Model.CompanyNetLoan GetModel(int CompanyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CompanyId, IsDeleted, CreateId, CreateDate, EditId, EditDate, HighestLoan, IsHaveGuarantee, IsMortgage, MaxMonthlyInterest, LoanPrescription, DescriptionHtml, Remark  ");
            strSql.Append("  from dbo.[CompanyNetLoan] ");
            strSql.Append(" where CompanyId=@CompanyId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@CompanyId", SqlDbType.Int,4)         };
            parameters[0].Value = CompanyId;


            BWJS.Model.CompanyNetLoan model = new BWJS.Model.CompanyNetLoan();
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
        public BWJS.Model.CompanyNetLoan DataRowToModel(DataRow row)
        {
            BWJS.Model.CompanyNetLoan model = new BWJS.Model.CompanyNetLoan();

            if (row != null)
            {
                if (row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
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
                if (row["HighestLoan"].ToString() != "")
                {
                    model.HighestLoan = decimal.Parse(row["HighestLoan"].ToString());
                }
                if (row["IsHaveGuarantee"].ToString() != "")
                {
                    model.IsHaveGuarantee = int.Parse(row["IsHaveGuarantee"].ToString());
                }
                if (row["IsMortgage"].ToString() != "")
                {
                    model.IsMortgage = int.Parse(row["IsMortgage"].ToString());
                }
                if (row["MaxMonthlyInterest"].ToString() != "")
                {
                    model.MaxMonthlyInterest = decimal.Parse(row["MaxMonthlyInterest"].ToString());
                }
                if (row["LoanPrescription"].ToString() != "")
                {
                    model.LoanPrescription = int.Parse(row["LoanPrescription"].ToString());
                }
                model.DescriptionHtml = row["DescriptionHtml"].ToString();
                model.Remark = row["Remark"].ToString();

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
            strSql.Append(" FROM dbo.[CompanyNetLoan] ");
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
            strSql.Append(" FROM dbo.[CompanyNetLoan] ");
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
            tablesql.Append(" FROM dbo.[CompanyNetLoan] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion

        #region ExtensionMethod

        #endregion
    }
}
