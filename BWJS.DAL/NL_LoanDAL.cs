﻿using UtilityHelper;
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
    /// 贷款信息
    /// </summary>
    public partial class NL_LoanDAL
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.NL_Loan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[NL_Loan](");
            strSql.Append("ReturnAmount,LoanDate,LoanDays,DueDate,InterestName,InterestValue,BankCardId,MemberId,CustomerId,RealName,ConsultId,IdNo,BankCode,BankName,TelNo,IsCorrect,TradePasswordExist,TradePassword,TradePasswordSecond,Flag,Mark,BorrowNo,IsDeleted,CreateId,CreateDate,EditId,EditDate,BankId,LoanInfo,LoanAmount,AmountReceived,LoanServiceCharge,LoanRate");
            strSql.Append(") values (");
            strSql.Append("@ReturnAmount,@LoanDate,@LoanDays,@DueDate,@InterestName,@InterestValue,@BankCardId,@MemberId,@CustomerId,@RealName,@ConsultId,@IdNo,@BankCode,@BankName,@TelNo,@IsCorrect,@TradePasswordExist,@TradePassword,@TradePasswordSecond,@Flag,@Mark,@BorrowNo,@IsDeleted,@CreateId,@CreateDate,@EditId,@EditDate,@BankId,@LoanInfo,@LoanAmount,@AmountReceived,@LoanServiceCharge,@LoanRate");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@ReturnAmount", model.ReturnAmount) ,
                        new SqlParameter("@LoanDate", model.LoanDate) ,
                        new SqlParameter("@LoanDays", model.LoanDays) ,
                        new SqlParameter("@DueDate", model.DueDate) ,
                        new SqlParameter("@InterestName", model.InterestName) ,
                        new SqlParameter("@InterestValue", model.InterestValue) ,
                        new SqlParameter("@BankCardId", model.BankCardId) ,
                        new SqlParameter("@MemberId", model.MemberId) ,
                        new SqlParameter("@CustomerId", model.CustomerId) ,
                        new SqlParameter("@RealName", model.RealName) ,
                        new SqlParameter("@ConsultId", model.ConsultId) ,
                        new SqlParameter("@IdNo", model.IdNo) ,
                        new SqlParameter("@BankCode", model.BankCode) ,
                        new SqlParameter("@BankName", model.BankName) ,
                        new SqlParameter("@TelNo", model.TelNo) ,
                        new SqlParameter("@IsCorrect", model.IsCorrect) ,
                        new SqlParameter("@TradePasswordExist", model.TradePasswordExist) ,
                        new SqlParameter("@TradePassword", model.TradePassword) ,
                        new SqlParameter("@TradePasswordSecond", model.TradePasswordSecond) ,
                        new SqlParameter("@Flag", model.Flag) ,
                        new SqlParameter("@Mark", model.Mark) ,
                        new SqlParameter("@BorrowNo", model.BorrowNo) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@BankId", model.BankId) ,
                        new SqlParameter("@LoanInfo", model.LoanInfo) ,
                        new SqlParameter("@LoanAmount", model.LoanAmount) ,
                        new SqlParameter("@AmountReceived", model.AmountReceived) ,
                        new SqlParameter("@LoanServiceCharge", model.LoanServiceCharge) ,
                        new SqlParameter("@LoanRate", model.LoanRate)

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
        public bool Update(BWJS.Model.NL_Loan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NL_Loan] set ");

            strSql.Append(" ReturnAmount = @ReturnAmount , ");
            strSql.Append(" LoanDate = @LoanDate , ");
            strSql.Append(" LoanDays = @LoanDays , ");
            strSql.Append(" DueDate = @DueDate , ");
            strSql.Append(" InterestName = @InterestName , ");
            strSql.Append(" InterestValue = @InterestValue , ");
            strSql.Append(" BankCardId = @BankCardId , ");
            strSql.Append(" MemberId = @MemberId , ");
            strSql.Append(" CustomerId = @CustomerId , ");
            strSql.Append(" RealName = @RealName , ");
            strSql.Append(" ConsultId = @ConsultId , ");
            strSql.Append(" IdNo = @IdNo , ");
            strSql.Append(" BankCode = @BankCode , ");
            strSql.Append(" BankName = @BankName , ");
            strSql.Append(" TelNo = @TelNo , ");
            strSql.Append(" IsCorrect = @IsCorrect , ");
            strSql.Append(" TradePasswordExist = @TradePasswordExist , ");
            strSql.Append(" TradePassword = @TradePassword , ");
            strSql.Append(" TradePasswordSecond = @TradePasswordSecond , ");
            strSql.Append(" Flag = @Flag , ");
            strSql.Append(" Mark = @Mark , ");
            strSql.Append(" BorrowNo = @BorrowNo , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" BankId = @BankId , ");
            strSql.Append(" LoanInfo = @LoanInfo , ");
            strSql.Append(" LoanAmount = @LoanAmount , ");
            strSql.Append(" AmountReceived = @AmountReceived , ");
            strSql.Append(" LoanServiceCharge = @LoanServiceCharge , ");
            strSql.Append(" LoanRate = @LoanRate  ");
            strSql.Append(" where LoanId=@LoanId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@LoanId",model.LoanId) ,
                        new SqlParameter("@ReturnAmount",model.ReturnAmount) ,
                        new SqlParameter("@LoanDate",model.LoanDate) ,
                        new SqlParameter("@LoanDays",model.LoanDays) ,
                        new SqlParameter("@DueDate",model.DueDate) ,
                        new SqlParameter("@InterestName",model.InterestName) ,
                        new SqlParameter("@InterestValue",model.InterestValue) ,
                        new SqlParameter("@BankCardId",model.BankCardId) ,
                        new SqlParameter("@MemberId",model.MemberId) ,
                        new SqlParameter("@CustomerId",model.CustomerId) ,
                        new SqlParameter("@RealName",model.RealName) ,
                        new SqlParameter("@ConsultId",model.ConsultId) ,
                        new SqlParameter("@IdNo",model.IdNo) ,
                        new SqlParameter("@BankCode",model.BankCode) ,
                        new SqlParameter("@BankName",model.BankName) ,
                        new SqlParameter("@TelNo",model.TelNo) ,
                        new SqlParameter("@IsCorrect",model.IsCorrect) ,
                        new SqlParameter("@TradePasswordExist",model.TradePasswordExist) ,
                        new SqlParameter("@TradePassword",model.TradePassword) ,
                        new SqlParameter("@TradePasswordSecond",model.TradePasswordSecond) ,
                        new SqlParameter("@Flag",model.Flag) ,
                        new SqlParameter("@Mark",model.Mark) ,
                        new SqlParameter("@BorrowNo",model.BorrowNo) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@BankId",model.BankId) ,
                        new SqlParameter("@LoanInfo",model.LoanInfo) ,
                        new SqlParameter("@LoanAmount",model.LoanAmount) ,
                        new SqlParameter("@AmountReceived",model.AmountReceived) ,
                        new SqlParameter("@LoanServiceCharge",model.LoanServiceCharge) ,
                        new SqlParameter("@LoanRate",model.LoanRate)

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
        public BWJS.Model.NL_Loan GetModel(int LoanId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LoanId, ReturnAmount, LoanDate, LoanDays, DueDate, InterestName, InterestValue, BankCardId, MemberId, CustomerId, RealName, ConsultId, IdNo, BankCode, BankName, TelNo, IsCorrect, TradePasswordExist, TradePassword, TradePasswordSecond, Flag, Mark, BorrowNo, IsDeleted, CreateId, CreateDate, EditId, EditDate, BankId, LoanInfo, LoanAmount, AmountReceived, LoanServiceCharge, LoanRate  ");
            strSql.Append("  from dbo.[NL_Loan] ");
            strSql.Append(" where LoanId=@LoanId");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoanId", SqlDbType.Int,4)
            };
            parameters[0].Value = LoanId;


            BWJS.Model.NL_Loan model = new BWJS.Model.NL_Loan();
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
        public BWJS.Model.NL_Loan DataRowToModel(DataRow row)
        {
            BWJS.Model.NL_Loan model = new BWJS.Model.NL_Loan();

            if (row != null)
            {
                if (row["LoanId"].ToString() != "")
                {
                    model.LoanId = int.Parse(row["LoanId"].ToString());
                }
                if (row["ReturnAmount"].ToString() != "")
                {
                    model.ReturnAmount = decimal.Parse(row["ReturnAmount"].ToString());
                }
                if (row["LoanDate"].ToString() != "")
                {
                    model.LoanDate = DateTime.Parse(row["LoanDate"].ToString());
                }
                if (row["LoanDays"].ToString() != "")
                {
                    model.LoanDays = int.Parse(row["LoanDays"].ToString());
                }
                if (row["DueDate"].ToString() != "")
                {
                    model.DueDate = DateTime.Parse(row["DueDate"].ToString());
                }
                model.InterestName = row["InterestName"].ToString();
                model.InterestValue = row["InterestValue"].ToString();
                if (row["BankCardId"].ToString() != "")
                {
                    model.BankCardId = int.Parse(row["BankCardId"].ToString());
                }
                if (row["MemberId"].ToString() != "")
                {
                    model.MemberId = int.Parse(row["MemberId"].ToString());
                }
                if (row["CustomerId"].ToString() != "")
                {
                    model.CustomerId = int.Parse(row["CustomerId"].ToString());
                }
                model.RealName = row["RealName"].ToString();
                if (row["ConsultId"].ToString() != "")
                {
                    model.ConsultId = int.Parse(row["ConsultId"].ToString());
                }
                model.IdNo = row["IdNo"].ToString();
                model.BankCode = row["BankCode"].ToString();
                model.BankName = row["BankName"].ToString();
                model.TelNo = row["TelNo"].ToString();
                if (row["IsCorrect"].ToString() != "")
                {
                    model.IsCorrect = int.Parse(row["IsCorrect"].ToString());
                }
                if (row["TradePasswordExist"].ToString() != "")
                {
                    if ((row["TradePasswordExist"].ToString() == "1") || (row["TradePasswordExist"].ToString().ToLower() == "true"))
                    {
                        model.TradePasswordExist = true;
                    }
                    else
                    {
                        model.TradePasswordExist = false;
                    }
                }
                model.TradePassword = row["TradePassword"].ToString();
                model.TradePasswordSecond = row["TradePasswordSecond"].ToString();
                if (row["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(row["Flag"].ToString());
                }
                if (row["Mark"].ToString() != "")
                {
                    if ((row["Mark"].ToString() == "1") || (row["Mark"].ToString().ToLower() == "true"))
                    {
                        model.Mark = true;
                    }
                    else
                    {
                        model.Mark = false;
                    }
                }
                model.BorrowNo = row["BorrowNo"].ToString();
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
                model.BankId = row["BankId"].ToString();
                model.LoanInfo = row["LoanInfo"].ToString();
                if (row["LoanAmount"].ToString() != "")
                {
                    model.LoanAmount = decimal.Parse(row["LoanAmount"].ToString());
                }
                if (row["AmountReceived"].ToString() != "")
                {
                    model.AmountReceived = decimal.Parse(row["AmountReceived"].ToString());
                }
                if (row["LoanServiceCharge"].ToString() != "")
                {
                    model.LoanServiceCharge = decimal.Parse(row["LoanServiceCharge"].ToString());
                }
                if (row["LoanRate"].ToString() != "")
                {
                    model.LoanRate = decimal.Parse(row["LoanRate"].ToString());
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
            strSql.Append(" FROM dbo.[NL_Loan] ");
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
            strSql.Append(" FROM dbo.[NL_Loan] ");
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
        public bool Delete(int LoanId, int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NL_Loan] set IsDeleted=1,EditId=@EditId,EditDate=@EditDate");
            strSql.Append(" where LoanId=@LoanId");
            SqlParameter[] parameters = {
                    new SqlParameter("@EditId", userId),
                    new SqlParameter("@EditDate", DateTime.Now),
                    new SqlParameter("@LoanId", LoanId),
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
        public bool DeleteList(string LoanIdlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.[NL_Loan] set IsDeleted=1,EditId={0},EditDate='{1}'", userId, DateTime.Now);
            strSql.Append(" where LoanId in (" + LoanIdlist + ")  ");
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
            tablesql.Append(" FROM dbo.[NL_Loan] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        /// <summary>
        /// 根据主表编号查询实体
        /// </summary>
        public BWJS.Model.NL_Loan GetModelByConsultId(int ConsultId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LoanId, ReturnAmount, LoanDate, LoanDays, DueDate, InterestName, InterestValue, BankCardId, MemberId, CustomerId, RealName, ConsultId, IdNo, BankCode, BankName, TelNo, IsCorrect, TradePasswordExist, TradePassword, TradePasswordSecond, Flag, Mark, BorrowNo, IsDeleted, CreateId, CreateDate, EditId, EditDate, BankId, LoanInfo, LoanAmount, AmountReceived, LoanServiceCharge, LoanRate  ");
            strSql.Append("  from dbo.[NL_Loan] ");
            strSql.Append(" where ConsultId=@ConsultId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ConsultId", ConsultId)
            };

            BWJS.Model.NL_Loan model = new BWJS.Model.NL_Loan();
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

        #endregion
    }
}