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
    /// 网贷申请
    /// </summary>
    public partial class NetLoanApplyDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.NetLoanApply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[NetLoanApply](");
            strSql.Append("Sex,Mobile,RecommendationCode,Remark,Status,IsDeleted,ApplicationAmount,LoanAmount,ContractAmount,LoanTerm,CompanyId,CreateDate,LoanDate,ProductId,ProductName,IsSettled,MerchantRebate,MerchantMoney,AgentRebate,AgentMoney,HQRebate,UserId,HQMoney,NetProfit,SettlementDate,DepartmentId,SN,IdCardLibraryId,FullName,IdCardType,IdCard,SourceCompany");
            strSql.Append(") values (");
            strSql.Append("@Sex,@Mobile,@RecommendationCode,@Remark,@Status,@IsDeleted,@ApplicationAmount,@LoanAmount,@ContractAmount,@LoanTerm,@CompanyId,@CreateDate,@LoanDate,@ProductId,@ProductName,@IsSettled,@MerchantRebate,@MerchantMoney,@AgentRebate,@AgentMoney,@HQRebate,@UserId,@HQMoney,@NetProfit,@SettlementDate,@DepartmentId,@SN,@IdCardLibraryId,@FullName,@IdCardType,@IdCard,@SourceCompany");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@Sex", model.Sex) ,
                        new SqlParameter("@Mobile", model.Mobile) ,
                        new SqlParameter("@RecommendationCode", model.RecommendationCode) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@Status", model.Status) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@ApplicationAmount", model.ApplicationAmount) ,
                        new SqlParameter("@LoanAmount", model.LoanAmount) ,
                        new SqlParameter("@ContractAmount", model.ContractAmount) ,
                        new SqlParameter("@LoanTerm", model.LoanTerm) ,
                        new SqlParameter("@CompanyId", model.CompanyId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@LoanDate", model.LoanDate) ,
                        new SqlParameter("@ProductId", model.ProductId) ,
                        new SqlParameter("@ProductName", model.ProductName) ,
                        new SqlParameter("@IsSettled", model.IsSettled) ,
                        new SqlParameter("@MerchantRebate", model.MerchantRebate) ,
                        new SqlParameter("@MerchantMoney", model.MerchantMoney) ,
                        new SqlParameter("@AgentRebate", model.AgentRebate) ,
                        new SqlParameter("@AgentMoney", model.AgentMoney) ,
                        new SqlParameter("@HQRebate", model.HQRebate) ,
                        new SqlParameter("@UserId", model.UserId) ,
                        new SqlParameter("@HQMoney", model.HQMoney) ,
                        new SqlParameter("@NetProfit", model.NetProfit) ,
                        new SqlParameter("@SettlementDate", model.SettlementDate) ,
                        new SqlParameter("@DepartmentId", model.DepartmentId) ,
                        new SqlParameter("@SN", model.SN) ,
                        new SqlParameter("@IdCardLibraryId", model.IdCardLibraryId) ,
                        new SqlParameter("@FullName", model.FullName) ,
                        new SqlParameter("@IdCardType", model.IdCardType) ,
                        new SqlParameter("@IdCard", model.IdCard),
                        new SqlParameter("@SourceCompany", model.SourceCompany) 

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
        //public bool Update(BWJS.Model.NetLoanApply model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update dbo.[NetLoanApply] set ");

        //    strSql.Append(" Sex = @Sex , ");
        //    strSql.Append(" Mobile = @Mobile , ");
        //    strSql.Append(" RecommendationCode = @RecommendationCode , ");
        //    strSql.Append(" Remark = @Remark , ");
        //    strSql.Append(" Status = @Status , ");
        //    strSql.Append(" IsDeleted = @IsDeleted , ");
        //    strSql.Append(" ApplicationAmount = @ApplicationAmount , ");
        //    strSql.Append(" LoanAmount = @LoanAmount , ");
        //    strSql.Append(" ContractAmount = @ContractAmount , ");
        //    strSql.Append(" LoanTerm = @LoanTerm , ");
        //    strSql.Append(" CompanyId = @CompanyId , ");
        //    strSql.Append(" CreateDate = @CreateDate , ");
        //    strSql.Append(" LoanDate = @LoanDate , ");
        //    strSql.Append(" ProductId = @ProductId , ");
        //    strSql.Append(" ProductName = @ProductName , ");
        //    strSql.Append(" IsSettled = @IsSettled , ");
        //    strSql.Append(" MerchantRebate = @MerchantRebate , ");
        //    strSql.Append(" MerchantMoney = @MerchantMoney , ");
        //    strSql.Append(" AgentRebate = @AgentRebate , ");
        //    strSql.Append(" AgentMoney = @AgentMoney , ");
        //    strSql.Append(" HQRebate = @HQRebate , ");
        //    strSql.Append(" UserId = @UserId , ");
        //    strSql.Append(" HQMoney = @HQMoney , ");
        //    strSql.Append(" NetProfit = @NetProfit , ");
        //    strSql.Append(" SettlementDate = @SettlementDate , ");
        //    strSql.Append(" DepartmentId = @DepartmentId , ");
        //    strSql.Append(" SN = @SN , ");
        //    strSql.Append(" IdCardLibraryId = @IdCardLibraryId , ");
        //    strSql.Append(" FullName = @FullName , ");
        //    strSql.Append(" IdCardType = @IdCardType , ");
        //    strSql.Append(" IdCard = @IdCard  ");
        //    strSql.Append(" where NetLoanApplyId=@NetLoanApplyId ");

        //    SqlParameter[] parameters = {
        //                new SqlParameter("@NetLoanApplyId",model.NetLoanApplyId) ,
        //                new SqlParameter("@Sex",model.Sex) ,
        //                new SqlParameter("@Mobile",model.Mobile) ,
        //                new SqlParameter("@RecommendationCode",model.RecommendationCode) ,
        //                new SqlParameter("@Remark",model.Remark) ,
        //                new SqlParameter("@Status",model.Status) ,
        //                new SqlParameter("@IsDeleted",model.IsDeleted) ,
        //                new SqlParameter("@ApplicationAmount",model.ApplicationAmount) ,
        //                new SqlParameter("@LoanAmount",model.LoanAmount) ,
        //                new SqlParameter("@ContractAmount",model.ContractAmount) ,
        //                new SqlParameter("@LoanTerm",model.LoanTerm) ,
        //                new SqlParameter("@CompanyId",model.CompanyId) ,
        //                new SqlParameter("@CreateDate",model.CreateDate) ,
        //                new SqlParameter("@LoanDate",model.LoanDate) ,
        //                new SqlParameter("@ProductId",model.ProductId) ,
        //                new SqlParameter("@ProductName",model.ProductName) ,
        //                new SqlParameter("@IsSettled",model.IsSettled) ,
        //                new SqlParameter("@MerchantRebate",model.MerchantRebate) ,
        //                new SqlParameter("@MerchantMoney",model.MerchantMoney) ,
        //                new SqlParameter("@AgentRebate",model.AgentRebate) ,
        //                new SqlParameter("@AgentMoney",model.AgentMoney) ,
        //                new SqlParameter("@HQRebate",model.HQRebate) ,
        //                new SqlParameter("@UserId",model.UserId) ,
        //                new SqlParameter("@HQMoney",model.HQMoney) ,
        //                new SqlParameter("@NetProfit",model.NetProfit) ,
        //                new SqlParameter("@SettlementDate",model.SettlementDate) ,
        //                new SqlParameter("@DepartmentId",model.DepartmentId) ,
        //                new SqlParameter("@SN",model.SN) ,
        //                new SqlParameter("@IdCardLibraryId",model.IdCardLibraryId) ,
        //                new SqlParameter("@FullName",model.FullName) ,
        //                new SqlParameter("@IdCardType",model.IdCardType) ,
        //                new SqlParameter("@IdCard",model.IdCard)

        //    };

        //    int rows = BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        /// <summary>
        /// 删除一条数据
        /// </summary>
        //public bool Delete(int NetLoanApplyId)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update dbo.[NetLoanApply] set IsDeleted=1");
        //    strSql.Append(" where NetLoanApplyId=@NetLoanApplyId");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@NetLoanApplyId", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = NetLoanApplyId;


        //    int rows = BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        //public bool DeleteList(string NetLoanApplyIdlist)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update dbo.[NetLoanApply] set IsDeleted=1");
        //    strSql.Append(" where ID in (" + NetLoanApplyIdlist + ")  ");
        //    int rows = BWJSHelperSQL.ExecuteSql(strSql.ToString());
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.NetLoanApply GetModel(int NetLoanApplyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NetLoanApplyId, Sex, Mobile, RecommendationCode, Remark, Status, IsDeleted, ApplicationAmount, LoanAmount, ContractAmount, LoanTerm, CompanyId, CreateDate, LoanDate, ProductId, ProductName, IsSettled, MerchantRebate, MerchantMoney, AgentRebate, AgentMoney, HQRebate, UserId, HQMoney, NetProfit, SettlementDate, DepartmentId, SN, IdCardLibraryId, FullName, IdCardType, IdCard ,SourceCompany ");
            strSql.Append("  from dbo.[NetLoanApply] ");
            strSql.Append(" where NetLoanApplyId=@NetLoanApplyId");
            SqlParameter[] parameters = {
                    new SqlParameter("@NetLoanApplyId", SqlDbType.Int,4)
            };
            parameters[0].Value = NetLoanApplyId;


            BWJS.Model.NetLoanApply model = new BWJS.Model.NetLoanApply();
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
        public BWJS.Model.NetLoanApply DataRowToModel(DataRow row)
        {
            BWJS.Model.NetLoanApply model = new BWJS.Model.NetLoanApply();

            if (row != null)
            {
                if (row["NetLoanApplyId"].ToString() != "")
                {
                    model.NetLoanApplyId = int.Parse(row["NetLoanApplyId"].ToString());
                }
                if (row["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(row["Sex"].ToString());
                }
                model.Mobile = row["Mobile"].ToString();
                model.RecommendationCode = row["RecommendationCode"].ToString();
                model.Remark = row["Remark"].ToString();
                if (row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                if (row["ApplicationAmount"].ToString() != "")
                {
                    model.ApplicationAmount = decimal.Parse(row["ApplicationAmount"].ToString());
                }
                if (row["LoanAmount"].ToString() != "")
                {
                    model.LoanAmount = decimal.Parse(row["LoanAmount"].ToString());
                }
                if (row["ContractAmount"].ToString() != "")
                {
                    model.ContractAmount = decimal.Parse(row["ContractAmount"].ToString());
                }
                if (row["LoanTerm"].ToString() != "")
                {
                    model.LoanTerm = int.Parse(row["LoanTerm"].ToString());
                }
                if (row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                }
                if (row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["LoanDate"].ToString() != "")
                {
                    model.LoanDate = DateTime.Parse(row["LoanDate"].ToString());
                }
                if (row["ProductId"].ToString() != "")
                {
                    model.ProductId = int.Parse(row["ProductId"].ToString());
                }
                model.ProductName = row["ProductName"].ToString();
                if (row["IsSettled"].ToString() != "")
                {
                    model.IsSettled = int.Parse(row["IsSettled"].ToString());
                }
                if (row["MerchantRebate"].ToString() != "")
                {
                    model.MerchantRebate = decimal.Parse(row["MerchantRebate"].ToString());
                }
                if (row["MerchantMoney"].ToString() != "")
                {
                    model.MerchantMoney = decimal.Parse(row["MerchantMoney"].ToString());
                }
                if (row["AgentRebate"].ToString() != "")
                {
                    model.AgentRebate = decimal.Parse(row["AgentRebate"].ToString());
                }
                if (row["AgentMoney"].ToString() != "")
                {
                    model.AgentMoney = decimal.Parse(row["AgentMoney"].ToString());
                }
                if (row["HQRebate"].ToString() != "")
                {
                    model.HQRebate = decimal.Parse(row["HQRebate"].ToString());
                }
                if (row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["HQMoney"].ToString() != "")
                {
                    model.HQMoney = decimal.Parse(row["HQMoney"].ToString());
                }
                if (row["NetProfit"].ToString() != "")
                {
                    model.NetProfit = decimal.Parse(row["NetProfit"].ToString());
                }
                if (row["SettlementDate"].ToString() != "")
                {
                    model.SettlementDate = DateTime.Parse(row["SettlementDate"].ToString());
                }
                if (row["DepartmentId"].ToString() != "")
                {
                    model.DepartmentId = int.Parse(row["DepartmentId"].ToString());
                }
                model.SN = row["SN"].ToString();
                if (row["IdCardLibraryId"].ToString() != "")
                {
                    model.IdCardLibraryId = int.Parse(row["IdCardLibraryId"].ToString());
                }
                model.FullName = row["FullName"].ToString();
                if (row["IdCardType"].ToString() != "")
                {
                    model.IdCardType = int.Parse(row["IdCardType"].ToString());
                }
                model.IdCard = row["IdCard"].ToString();
                model.SourceCompany = row["SourceCompany"].ToString(); 
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
        //public DataSet GetAllList()
        //{
        //    return GetList("");
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select * ");
        //    strSql.Append(" FROM dbo.[NetLoanApply] ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    return BWJSHelperSQL.Query(strSql.ToString());
        //}

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        //public DataSet GetList(int Top, string strWhere, string filedOrder)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select ");
        //    if (Top > 0)
        //    {
        //        strSql.Append(" top " + Top.ToString());
        //    }
        //    strSql.Append(" * ");
        //    strSql.Append(" FROM dbo.[NetLoanApply] ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    strSql.Append(" order by " + filedOrder);
        //    return BWJSHelperSQL.Query(strSql.ToString());
        //}

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
        //public DataTable GetList(string tablesql, string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        //{
        //    return BWJSHelperSQL.GetPageList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        //}

        #endregion

        #region ExtensionMethod

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
            tablesql.Append(@"
select a.*,b.UserName MerchantName,c.Name IdCardTypeName,d.[CompanyName],d.[MainBusiness],d.CompanyCategoryId,e.[CompanyCategoryName]
from [BWJSDB].[dbo].[NetLoanApply] a
left join [BWJSDB].[dbo].[Users] b on b.UserId = a.UserId
left join MofangDB.[dbo].CardType c on c.Value = a.IdCardType AND a.IsDeleted = 0
left join [BWJSDB].[dbo].[Company] d on d.[CompanyId] = a.[CompanyId]  AND d.IsDeleted = 0
left join [dbo].[CompanyCategory] e on e.[CompanyCategoryId]=d.CompanyCategoryId");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion
    }
}
