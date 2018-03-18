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
    /// 订单返利结算申请
    /// </summary>
    public partial class OrderRebateSettlementApplyDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.OrderRebateSettlementApply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[OrderRebateSettlementApply](");
            strSql.Append("SalesPercentage,PaymentMethod,OpeningBank,CardHolder,CardNumber,Remark,CreateId,CreateDate,EditId,EditDate,UserId,IsDeleted,DepartmentId,StartDate,EndDate,ApplyMoney,ActualMoney,ApplyStatus,SettlementMethod");
            strSql.Append(") values (");
            strSql.Append("@SalesPercentage,@PaymentMethod,@OpeningBank,@CardHolder,@CardNumber,@Remark,@CreateId,@CreateDate,@EditId,@EditDate,@UserId,@IsDeleted,@DepartmentId,@StartDate,@EndDate,@ApplyMoney,@ActualMoney,@ApplyStatus,@SettlementMethod");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@SalesPercentage", model.SalesPercentage) ,
                        new SqlParameter("@PaymentMethod", model.PaymentMethod) ,
                        new SqlParameter("@OpeningBank", model.OpeningBank) ,
                        new SqlParameter("@CardHolder", model.CardHolder) ,
                        new SqlParameter("@CardNumber", model.CardNumber) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@UserId", model.UserId) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@DepartmentId", model.DepartmentId) ,
                        new SqlParameter("@StartDate", model.StartDate) ,
                        new SqlParameter("@EndDate", model.EndDate) ,
                        new SqlParameter("@ApplyMoney", model.ApplyMoney) ,
                        new SqlParameter("@ActualMoney", model.ActualMoney) ,
                        new SqlParameter("@ApplyStatus", model.ApplyStatus) ,
                        new SqlParameter("@SettlementMethod", model.SettlementMethod)

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
        //public bool Update(BWJS.Model.OrderRebateSettlementApply model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update dbo.[OrderRebateSettlementApply] set ");

        //    strSql.Append(" SalesPercentage = @SalesPercentage , ");
        //    strSql.Append(" PaymentMethod = @PaymentMethod , ");
        //    strSql.Append(" OpeningBank = @OpeningBank , ");
        //    strSql.Append(" CardHolder = @CardHolder , ");
        //    strSql.Append(" CardNumber = @CardNumber , ");
        //    strSql.Append(" Remark = @Remark , ");
        //    strSql.Append(" CreateId = @CreateId , ");
        //    strSql.Append(" CreateDate = @CreateDate , ");
        //    strSql.Append(" EditId = @EditId , ");
        //    strSql.Append(" EditDate = @EditDate , ");
        //    strSql.Append(" UserId = @UserId , ");
        //    strSql.Append(" IsDeleted = @IsDeleted , ");
        //    strSql.Append(" DepartmentId = @DepartmentId , ");
        //    strSql.Append(" StartDate = @StartDate , ");
        //    strSql.Append(" EndDate = @EndDate , ");
        //    strSql.Append(" ApplyMoney = @ApplyMoney , ");
        //    strSql.Append(" ActualMoney = @ActualMoney , ");
        //    strSql.Append(" ApplyStatus = @ApplyStatus , ");
        //    strSql.Append(" SettlementMethod = @SettlementMethod  ");
        //    strSql.Append(" where OrderRebateSettlementApplyId=@OrderRebateSettlementApplyId ");

        //    SqlParameter[] parameters = {
        //                new SqlParameter("@OrderRebateSettlementApplyId",model.OrderRebateSettlementApplyId) ,
        //                new SqlParameter("@SalesPercentage",model.SalesPercentage) ,
        //                new SqlParameter("@PaymentMethod",model.PaymentMethod) ,
        //                new SqlParameter("@OpeningBank",model.OpeningBank) ,
        //                new SqlParameter("@CardHolder",model.CardHolder) ,
        //                new SqlParameter("@CardNumber",model.CardNumber) ,
        //                new SqlParameter("@Remark",model.Remark) ,
        //                new SqlParameter("@CreateId",model.CreateId) ,
        //                new SqlParameter("@CreateDate",model.CreateDate) ,
        //                new SqlParameter("@EditId",model.EditId) ,
        //                new SqlParameter("@EditDate",model.EditDate) ,
        //                new SqlParameter("@UserId",model.UserId) ,
        //                new SqlParameter("@IsDeleted",model.IsDeleted) ,
        //                new SqlParameter("@DepartmentId",model.DepartmentId) ,
        //                new SqlParameter("@StartDate",model.StartDate) ,
        //                new SqlParameter("@EndDate",model.EndDate) ,
        //                new SqlParameter("@ApplyMoney",model.ApplyMoney) ,
        //                new SqlParameter("@ActualMoney",model.ActualMoney) ,
        //                new SqlParameter("@ApplyStatus",model.ApplyStatus) ,
        //                new SqlParameter("@SettlementMethod",model.SettlementMethod)

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
        //public bool Delete(int OrderRebateSettlementApplyId)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update dbo.[OrderRebateSettlementApply] set IsDeleted=1");
        //    strSql.Append(" where OrderRebateSettlementApplyId=@OrderRebateSettlementApplyId");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@OrderRebateSettlementApplyId", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = OrderRebateSettlementApplyId;


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
        //public bool DeleteList(string OrderRebateSettlementApplyIdlist)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update dbo.[OrderRebateSettlementApply] set IsDeleted=1");
        //    strSql.Append(" where ID in (" + OrderRebateSettlementApplyIdlist + ")  ");
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
        public BWJS.Model.OrderRebateSettlementApply GetModel(int OrderRebateSettlementApplyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderRebateSettlementApplyId, SalesPercentage, PaymentMethod, OpeningBank, CardHolder, CardNumber, Remark, CreateId, CreateDate, EditId, EditDate, UserId, IsDeleted, DepartmentId, StartDate, EndDate, ApplyMoney, ActualMoney, ApplyStatus, SettlementMethod  ");
            strSql.Append("  from dbo.[OrderRebateSettlementApply] ");
            strSql.Append(" where OrderRebateSettlementApplyId=@OrderRebateSettlementApplyId");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderRebateSettlementApplyId", SqlDbType.Int,4)
            };
            parameters[0].Value = OrderRebateSettlementApplyId;


            BWJS.Model.OrderRebateSettlementApply model = new BWJS.Model.OrderRebateSettlementApply();
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
        public BWJS.Model.OrderRebateSettlementApply DataRowToModel(DataRow row)
        {
            BWJS.Model.OrderRebateSettlementApply model = new BWJS.Model.OrderRebateSettlementApply();

            if (row != null)
            {
                if (row["OrderRebateSettlementApplyId"].ToString() != "")
                {
                    model.OrderRebateSettlementApplyId = int.Parse(row["OrderRebateSettlementApplyId"].ToString());
                }
                if (row["SalesPercentage"].ToString() != "")
                {
                    model.SalesPercentage = decimal.Parse(row["SalesPercentage"].ToString());
                }
                if (row["PaymentMethod"].ToString() != "")
                {
                    model.PaymentMethod = int.Parse(row["PaymentMethod"].ToString());
                }
                model.OpeningBank = row["OpeningBank"].ToString();
                model.CardHolder = row["CardHolder"].ToString();
                model.CardNumber = row["CardNumber"].ToString();
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
                if (row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                if (row["DepartmentId"].ToString() != "")
                {
                    model.DepartmentId = int.Parse(row["DepartmentId"].ToString());
                }
                if (row["StartDate"].ToString() != "")
                {
                    model.StartDate = DateTime.Parse(row["StartDate"].ToString());
                }
                if (row["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(row["EndDate"].ToString());
                }
                if (row["ApplyMoney"].ToString() != "")
                {
                    model.ApplyMoney = decimal.Parse(row["ApplyMoney"].ToString());
                }
                if (row["ActualMoney"].ToString() != "")
                {
                    model.ActualMoney = decimal.Parse(row["ActualMoney"].ToString());
                }
                if (row["ApplyStatus"].ToString() != "")
                {
                    model.ApplyStatus = int.Parse(row["ApplyStatus"].ToString());
                }
                if (row["SettlementMethod"].ToString() != "")
                {
                    model.SettlementMethod = int.Parse(row["SettlementMethod"].ToString());
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
        //public DataSet GetAllList()
        //{
        //    return GetList("");
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM dbo.[OrderRebateSettlementApply] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }

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
        //    strSql.Append(" FROM dbo.[OrderRebateSettlementApply] ");
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
            tablesql.Append(@"select a.*,b.UserName MerchantName,c.UserName CreateName
            from [dbo].[OrderRebateSettlementApply] a 
            left join [dbo].[Users] b on b.[UserId]=a.[UserId]
            left join [dbo].[Users] c on c.[UserId]=a.[CreateId]"); 
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion

        #region  ExtensionMethod

        /// <summary>
        /// 确认结算，更新结算申请表结算状态为已结算和更新订单表结算状态为已结算
        /// </summary>
        /// <param name="orderRebateSettlementApplyId">结算申请主键</param>
        /// <param name="userId">当前登录人编号</param>
        /// <param name="res01">更新结算申请表结算状态为已结算的结果</param>
        /// <param name="res02">更新订单表结算状态为已结算的结果</param>
        public void ConfirmSettlement(string orderRebateSettlementApplyId, int userId, ref int res01, ref int res02)
        {
            //更新结算申请表结算状态为已结算
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderRebateSettlementApply] set ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" ApplyStatus = 1 ");
            strSql.Append(" where OrderRebateSettlementApplyId in(@OrderRebateSettlementApplyId)");

            SqlParameter[] parameters01 = {
                        new SqlParameter("@EditId",userId) ,
                        new SqlParameter("@EditDate",DateTime.Now) ,
                        new SqlParameter("@OrderRebateSettlementApplyId",orderRebateSettlementApplyId)

            };
            res01 = BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters01);

            //更新订单表结算状态为已结算
            strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderRebate] set ");
            //strSql.Append(" EditId = @EditId , ");
            strSql.Append(" SettlementDate = @SettlementDate , ");
            strSql.Append(" IsSettled = 2 ");
            strSql.Append(" where OrderRebateId in(select OrderRebateId from [dbo].[OrderRebateSettlementDetails] where OrderRebateSettlementApplyId in(@OrderRebateSettlementApplyId))");

            SqlParameter[] parameters02 = {
                        //new SqlParameter("@EditId",userId) ,
                        new SqlParameter("@SettlementDate",DateTime.Now) ,
                        new SqlParameter("@OrderRebateSettlementApplyId",orderRebateSettlementApplyId)

            };
            res02 = BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters02);
        }
        #endregion  ExtensionMethod
    }
}
