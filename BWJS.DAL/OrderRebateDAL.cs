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
    /// 订单返利
    /// </summary>
    public partial class OrderRebateDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.OrderRebate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[OrderRebate](");
            strSql.Append("AgentMoney,AgentRebate,HQRebate,HQMoney,NetProfit,PayStatus,IsSettled,IsCancel,SettlementDate,CreateDate,TransNo,Remark,IsDeleted,CompanyId,UserId,OrderApplyId,CompanyRebateId,OrderMoney,MerchantRebate,MerchantMoney");
            strSql.Append(") values (");
            strSql.Append("@AgentMoney,@AgentRebate,@HQRebate,@HQMoney,@NetProfit,@PayStatus,@IsSettled,@IsCancel,@SettlementDate,@CreateDate,@TransNo,@Remark,@IsDeleted,@CompanyId,@UserId,@OrderApplyId,@CompanyRebateId,@OrderMoney,@MerchantRebate,@MerchantMoney");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@AgentMoney", model.AgentMoney) ,
                        new SqlParameter("@AgentRebate", model.AgentRebate) ,
                        new SqlParameter("@HQRebate", model.HQRebate) ,
                        new SqlParameter("@HQMoney", model.HQMoney) ,
                        new SqlParameter("@NetProfit", model.NetProfit) ,
                        new SqlParameter("@PayStatus", model.PayStatus) ,
                        new SqlParameter("@IsSettled", model.IsSettled) ,
                        new SqlParameter("@IsCancel", model.IsCancel) ,
                        new SqlParameter("@SettlementDate", model.SettlementDate) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@TransNo", model.TransNo) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CompanyId", model.CompanyId) ,
                        new SqlParameter("@UserId", model.UserId) ,
                        new SqlParameter("@OrderApplyId", model.OrderApplyId) ,
                        new SqlParameter("@CompanyRebateId", model.CompanyRebateId) ,
                        new SqlParameter("@OrderMoney", model.OrderMoney) ,
                        new SqlParameter("@MerchantRebate", model.MerchantRebate) ,
                        new SqlParameter("@MerchantMoney", model.MerchantMoney)

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
        public bool Update(BWJS.Model.OrderRebate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderRebate] set ");

            strSql.Append(" AgentMoney = @AgentMoney , ");
            strSql.Append(" AgentRebate = @AgentRebate , ");
            strSql.Append(" HQRebate = @HQRebate , ");
            strSql.Append(" HQMoney = @HQMoney , ");
            strSql.Append(" NetProfit = @NetProfit , ");
            strSql.Append(" PayStatus = @PayStatus , ");
            strSql.Append(" IsSettled = @IsSettled , ");
            strSql.Append(" IsCancel = @IsCancel , ");
            strSql.Append(" SettlementDate = @SettlementDate , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" TransNo = @TransNo , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" CompanyId = @CompanyId , ");
            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" OrderApplyId = @OrderApplyId , ");
            strSql.Append(" CompanyRebateId = @CompanyRebateId , ");
            strSql.Append(" OrderMoney = @OrderMoney , ");
            strSql.Append(" MerchantRebate = @MerchantRebate , ");
            strSql.Append(" MerchantMoney = @MerchantMoney  ");
            strSql.Append(" where OrderRebateId=@OrderRebateId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@OrderRebateId",model.OrderRebateId) ,
                        new SqlParameter("@AgentMoney",model.AgentMoney) ,
                        new SqlParameter("@AgentRebate",model.AgentRebate) ,
                        new SqlParameter("@HQRebate",model.HQRebate) ,
                        new SqlParameter("@HQMoney",model.HQMoney) ,
                        new SqlParameter("@NetProfit",model.NetProfit) ,
                        new SqlParameter("@PayStatus",model.PayStatus) ,
                        new SqlParameter("@IsSettled",model.IsSettled) ,
                        new SqlParameter("@IsCancel",model.IsCancel) ,
                        new SqlParameter("@SettlementDate",model.SettlementDate) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@TransNo",model.TransNo) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@CompanyId",model.CompanyId) ,
                        new SqlParameter("@UserId",model.UserId) ,
                        new SqlParameter("@OrderApplyId",model.OrderApplyId) ,
                        new SqlParameter("@CompanyRebateId",model.CompanyRebateId) ,
                        new SqlParameter("@OrderMoney",model.OrderMoney) ,
                        new SqlParameter("@MerchantRebate",model.MerchantRebate) ,
                        new SqlParameter("@MerchantMoney",model.MerchantMoney)

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
        public BWJS.Model.OrderRebate GetModel(int OrderRebateId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderRebateId, AgentMoney, AgentRebate, HQRebate, HQMoney, NetProfit, PayStatus, IsSettled, IsCancel, SettlementDate, CreateDate, TransNo, Remark, IsDeleted, CompanyId, UserId, OrderApplyId, CompanyRebateId, OrderMoney, MerchantRebate, MerchantMoney  ");
            strSql.Append("  from dbo.[OrderRebate] ");
            strSql.Append(" where OrderRebateId=@OrderRebateId");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderRebateId", SqlDbType.Int,4)
            };
            parameters[0].Value = OrderRebateId;


            BWJS.Model.OrderRebate model = new BWJS.Model.OrderRebate();
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
        public BWJS.Model.OrderRebate DataRowToModel(DataRow row)
        {
            BWJS.Model.OrderRebate model = new BWJS.Model.OrderRebate();

            if (row != null)
            {
                if (row["OrderRebateId"].ToString() != "")
                {
                    model.OrderRebateId = int.Parse(row["OrderRebateId"].ToString());
                }
                if (row["AgentMoney"].ToString() != "")
                {
                    model.AgentMoney = decimal.Parse(row["AgentMoney"].ToString());
                }
                if (row["AgentRebate"].ToString() != "")
                {
                    model.AgentRebate = decimal.Parse(row["AgentRebate"].ToString());
                }
                if (row["HQRebate"].ToString() != "")
                {
                    model.HQRebate = decimal.Parse(row["HQRebate"].ToString());
                }
                if (row["HQMoney"].ToString() != "")
                {
                    model.HQMoney = decimal.Parse(row["HQMoney"].ToString());
                }
                if (row["NetProfit"].ToString() != "")
                {
                    model.NetProfit = decimal.Parse(row["NetProfit"].ToString());
                }
                if (row["PayStatus"].ToString() != "")
                {
                    model.PayStatus = int.Parse(row["PayStatus"].ToString());
                }
                if (row["IsSettled"].ToString() != "")
                {
                    model.IsSettled = int.Parse(row["IsSettled"].ToString());
                }
                if (row["IsCancel"].ToString() != "")
                {
                    model.IsCancel = int.Parse(row["IsCancel"].ToString());
                }
                if (row["SettlementDate"].ToString() != "")
                {
                    model.SettlementDate = DateTime.Parse(row["SettlementDate"].ToString());
                }
                if (row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                model.TransNo = row["TransNo"].ToString();
                model.Remark = row["Remark"].ToString();
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                if (row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                }
                if (row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["OrderApplyId"].ToString() != "")
                {
                    model.OrderApplyId = int.Parse(row["OrderApplyId"].ToString());
                }
                if (row["CompanyRebateId"].ToString() != "")
                {
                    model.CompanyRebateId = int.Parse(row["CompanyRebateId"].ToString());
                }
                if (row["OrderMoney"].ToString() != "")
                {
                    model.OrderMoney = decimal.Parse(row["OrderMoney"].ToString());
                }
                if (row["MerchantRebate"].ToString() != "")
                {
                    model.MerchantRebate = decimal.Parse(row["MerchantRebate"].ToString());
                }
                if (row["MerchantMoney"].ToString() != "")
                {
                    model.MerchantMoney = decimal.Parse(row["MerchantMoney"].ToString());
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM dbo.[OrderRebate] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        #endregion

        #region  ExtensionMethod

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
            tablesql.Append(@"	SELECT ort.*,moa.InsureNum,u.UserName as MerchantName,u.RecordIsDelete as uIsDeleted,dinfo.DepartmentName  FROM [dbo].OrderRebate ort
   LEFT JOIN MofangDB.dbo.OrderApply moa ON moa.OrderApplyID = ort.OrderApplyId AND moa.RecordIsDelete = 0
   LEFT JOIN dbo.Users u ON moa.UserID=u.UserID  
   LEFT JOIN dbo.DepartmentInfo dinfo ON dinfo.DepartmentID = moa.DepartmentID AND dinfo.RecordIsDelete = 0");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable QueryOrderList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
select a.CompanyId,c.CompanyName,a.UserId,d.UserType,d.UserName MerchantName,b.SettlementMethod,b.SalesPercentage,sum(round(a.OrderMoney,2))sumOrderMoney,sum(round(a.MerchantMoney,2))sumMerchantMoney,sum(round(a.AgentMoney,2))sumAgentMoney,sum(round(a.HQMoney,2))sumHQMoney,sum(round(a.NetProfit,2))sumNetProfit
from [dbo].[OrderRebate] a 
left join [dbo].[CompanyRebate] b on b.CompanyId=a.CompanyId
left join [dbo].[Company] c on c.CompanyId=a.CompanyId
left join [dbo].[Users] d on d.UserId=a.UserId");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(@" group by a.CompanyId,c.CompanyName,a.UserId,d.UserType,d.UserName,b.SettlementMethod,b.SalesPercentage");

            return BWJSHelperSQL.ReturnDataTable(strSql.ToString());
        }

        /// <summary>
        /// 结算申请详情信息入库和修改订单返利结算申请表的结算状态为已申请
        /// </summary>
        /// <param name="orderRebateSettlementApplyId">结算申请主键</param>
        /// <param name="userId">当前登录人编号</param>
        /// <param name="where">申请时查询条件</param>
        /// <param name="res01">结算申请详情信息入库的结果</param>
        /// <param name="res02">修改订单返利结算申请表的结算状态为已申请的结果</param>
        public void ApplySettlement(int orderRebateSettlementApplyId, int userId, string where, ref int res01, ref int res02)
        {
            //结算申请详情信息入库
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"insert into [dbo].[OrderRebateSettlementDetails](OrderRebateSettlementApplyId,OrderRebateId,CreateDate,CreateId)
select {0} OrderRebateSettlementApplyId,a.OrderRebateId,'{1}',{2}
from [dbo].[OrderRebate] a 
left join [dbo].[CompanyRebate] b on b.CompanyId=a.CompanyId
left join [dbo].[Company] c on c.CompanyId=a.CompanyId
left join [dbo].[Users] d on d.UserId=a.UserId", orderRebateSettlementApplyId, DateTime.Now, userId);
            if (where.Trim() != "")
            {
                strSql.Append(" where " + where);
            }
            res01 = BWJSHelperSQL.ExecuteSql(strSql.ToString());

            //修改订单返利结算申请表的结算状态为已申请
            strSql = new StringBuilder();
            strSql.AppendFormat(@"update [dbo].[OrderRebate]
set IsSettled=1
from [dbo].[OrderRebate] a
left join [dbo].[CompanyRebate] b on b.CompanyId=a.CompanyId
left join [dbo].[Company] c on c.CompanyId=a.CompanyId
left join [dbo].[Users] d on d.UserId=a.UserId");
            if (where.Trim() != "")
            {
                strSql.Append(" where " + where);
            }

            res02 = BWJSHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetOrderList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT ort.*,moa.InsureNum  FROM [dbo].OrderRebate ort
                                   LEFT JOIN BWJSDB.dbo.OrderApply moa ON moa.OrderApplyID = ort.OrderApplyId AND moa.RecordIsDelete = 0");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}
