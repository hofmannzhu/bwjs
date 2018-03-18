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
    /// 渠道返利
    /// </summary>
    public partial class CompanyRebateDAL : BaseService
    {
        public CompanyRebateDAL() { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.CompanyRebate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[CompanyRebate](");
            strSql.Append("SettlementMethod,SalesPercentage,ProfitDescription,Remark,IsDeleted,CreateId,CreateDate,EditId,EditDate,CompanyId,ProductId,CaseCode,RebateName,CompanyRebatePer,MerchantRebate,AgentRebate,HQRebate");
            strSql.Append(") values (");
            strSql.Append("@SettlementMethod,@SalesPercentage,@ProfitDescription,@Remark,@IsDeleted,@CreateId,@CreateDate,@EditId,@EditDate,@CompanyId,@ProductId,@CaseCode,@RebateName,@CompanyRebatePer,@MerchantRebate,@AgentRebate,@HQRebate");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@SettlementMethod", model.SettlementMethod) ,
                        new SqlParameter("@SalesPercentage", model.SalesPercentage) ,
                        new SqlParameter("@ProfitDescription", model.ProfitDescription) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@CompanyId", model.CompanyId) ,
                        new SqlParameter("@ProductId", model.ProductId) ,
                        new SqlParameter("@CaseCode", model.CaseCode) ,
                        new SqlParameter("@RebateName", model.RebateName) ,
                        new SqlParameter("@CompanyRebatePer", model.CompanyRebatePer) ,
                        new SqlParameter("@MerchantRebate", model.MerchantRebate) ,
                        new SqlParameter("@AgentRebate", model.AgentRebate) ,
                        new SqlParameter("@HQRebate", model.HQRebate)

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
        public bool Update(BWJS.Model.CompanyRebate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[CompanyRebate] set ");

            strSql.Append(" SettlementMethod = @SettlementMethod , ");
            strSql.Append(" SalesPercentage = @SalesPercentage , ");
            strSql.Append(" ProfitDescription = @ProfitDescription , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            //strSql.Append(" CreateId = @CreateId , ");
            //strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" CompanyId = @CompanyId , ");
            strSql.Append(" ProductId = @ProductId , ");
            strSql.Append(" CaseCode = @CaseCode , ");
            strSql.Append(" RebateName = @RebateName , ");
            strSql.Append(" CompanyRebatePer = @CompanyRebatePer , ");
            strSql.Append(" MerchantRebate = @MerchantRebate , ");
            strSql.Append(" AgentRebate = @AgentRebate , ");
            strSql.Append(" HQRebate = @HQRebate  ");
            strSql.Append(" where CompanyRebateId=@CompanyRebateId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@CompanyRebateId",model.CompanyRebateId) ,
                        new SqlParameter("@SettlementMethod",model.SettlementMethod) ,
                        new SqlParameter("@SalesPercentage",model.SalesPercentage) ,
                        new SqlParameter("@ProfitDescription",model.ProfitDescription) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        //new SqlParameter("@CreateId",model.CreateId) ,
                        //new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@CompanyId",model.CompanyId) ,
                        new SqlParameter("@ProductId",model.ProductId) ,
                        new SqlParameter("@CaseCode",model.CaseCode) ,
                        new SqlParameter("@RebateName",model.RebateName) ,
                        new SqlParameter("@CompanyRebatePer",model.CompanyRebatePer) ,
                        new SqlParameter("@MerchantRebate",model.MerchantRebate) ,
                        new SqlParameter("@AgentRebate",model.AgentRebate) ,
                        new SqlParameter("@HQRebate",model.HQRebate)

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
        public bool Delete(int CompanyRebateId,int EditId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[CompanyRebate] set IsDeleted=1,EditDate=GETDATE(),EditId=@EditId");
            strSql.Append(" where CompanyRebateId=@CompanyRebateId");
            SqlParameter[] parameters = {
                    new SqlParameter("@CompanyRebateId", SqlDbType.Int,4),
                    new SqlParameter("@EditId", SqlDbType.Int,4)
            };
            parameters[0].Value = CompanyRebateId;
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string CompanyRebateIdlist,int EditId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[CompanyRebate] set IsDeleted=1,EditDate=GETDATE(),EditId="+ EditId + "");
            strSql.Append(" where ID in (" + CompanyRebateIdlist + ")  ");
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
        public BWJS.Model.CompanyRebate GetModel(int CompanyRebateId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CompanyRebateId, SettlementMethod, SalesPercentage, ProfitDescription, Remark, IsDeleted, CreateId, CreateDate, EditId, EditDate, CompanyId, ProductId, CaseCode, RebateName, CompanyRebatePer, MerchantRebate, AgentRebate, HQRebate  ");
            strSql.Append("  from dbo.[CompanyRebate] ");
            strSql.Append(" where CompanyRebateId=@CompanyRebateId");
            SqlParameter[] parameters = {
                    new SqlParameter("@CompanyRebateId", SqlDbType.Int,4)
            };
            parameters[0].Value = CompanyRebateId;


            BWJS.Model.CompanyRebate model = new BWJS.Model.CompanyRebate();
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
        public BWJS.Model.CompanyRebate DataRowToModel(DataRow row)
        {
            BWJS.Model.CompanyRebate model = new BWJS.Model.CompanyRebate();

            if (row != null)
            {
                if (row["CompanyRebateId"].ToString() != "")
                {
                    model.CompanyRebateId = int.Parse(row["CompanyRebateId"].ToString());
                }
                if (row["SettlementMethod"].ToString() != "")
                {
                    model.SettlementMethod = int.Parse(row["SettlementMethod"].ToString());
                }
                if (row["SalesPercentage"].ToString() != "")
                {
                    model.SalesPercentage = decimal.Parse(row["SalesPercentage"].ToString());
                }
                model.ProfitDescription = row["ProfitDescription"].ToString();
                model.Remark = row["Remark"].ToString();
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
                if (row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                }
                if (row["ProductId"].ToString() != "")
                {
                    model.ProductId = int.Parse(row["ProductId"].ToString());
                }
                model.CaseCode = row["CaseCode"].ToString();
                model.RebateName = row["RebateName"].ToString();
                if (row["CompanyRebatePer"].ToString() != "")
                {
                    model.CompanyRebatePer = decimal.Parse(row["CompanyRebatePer"].ToString());
                }
                if (row["MerchantRebate"].ToString() != "")
                {
                    model.MerchantRebate = decimal.Parse(row["MerchantRebate"].ToString());
                }
                if (row["AgentRebate"].ToString() != "")
                {
                    model.AgentRebate = decimal.Parse(row["AgentRebate"].ToString());
                }
                if (row["HQRebate"].ToString() != "")
                {
                    model.HQRebate = decimal.Parse(row["HQRebate"].ToString());
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
            strSql.Append(" FROM dbo.[CompanyRebate] ");
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
            strSql.Append(" FROM dbo.[CompanyRebate] ");
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
            tablesql.Append(" FROM dbo.[CompanyRebate] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
