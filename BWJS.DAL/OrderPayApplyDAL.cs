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
    /// 订单支付
    /// </summary>
    public partial class OrderPayApplyDAL : BaseService
    {
        public OrderPayApplyDAL() { }

        #region BaseMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.OrderPayApply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrderPayApply(");
            strSql.Append("PayJson,CreateDate,PayDate,Remark,IsDeleted,OrderRebateId,OrderMoney,PayOrderNumber,PayStatus,PayPlatform,PayMethod,PayCode,PayText");
            strSql.Append(") values (");
            strSql.Append("@PayJson,@CreateDate,@PayDate,@Remark,@IsDeleted,@OrderRebateId,@OrderMoney,@PayOrderNumber,@PayStatus,@PayPlatform,@PayMethod,@PayCode,@PayText");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@PayJson", model.PayJson) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@PayDate", model.PayDate) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@OrderRebateId", model.OrderRebateId) ,
                        new SqlParameter("@OrderMoney", model.OrderMoney) ,
                        new SqlParameter("@PayOrderNumber", model.PayOrderNumber) ,
                        new SqlParameter("@PayStatus", model.PayStatus) ,
                        new SqlParameter("@PayPlatform", model.PayPlatform) ,
                        new SqlParameter("@PayMethod", model.PayMethod) ,
                        new SqlParameter("@PayCode", model.PayCode) ,
                        new SqlParameter("@PayText", model.PayText)

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
        public bool Update(BWJS.Model.OrderPayApply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderPayApply set ");

            strSql.Append(" PayJson = @PayJson , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" PayDate = @PayDate , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" OrderRebateId = @OrderRebateId , ");
            strSql.Append(" OrderMoney = @OrderMoney , ");
            strSql.Append(" PayOrderNumber = @PayOrderNumber , ");
            strSql.Append(" PayStatus = @PayStatus , ");
            strSql.Append(" PayPlatform = @PayPlatform , ");
            strSql.Append(" PayMethod = @PayMethod , ");
            strSql.Append(" PayCode = @PayCode , ");
            strSql.Append(" PayText = @PayText  ");
            strSql.Append(" where OrderPayApplyId=@OrderPayApplyId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@OrderPayApplyId",model.OrderPayApplyId) ,
                        new SqlParameter("@PayJson",model.PayJson) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@PayDate",model.PayDate) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@OrderRebateId",model.OrderRebateId) ,
                        new SqlParameter("@OrderMoney",model.OrderMoney) ,
                        new SqlParameter("@PayOrderNumber",model.PayOrderNumber) ,
                        new SqlParameter("@PayStatus",model.PayStatus) ,
                        new SqlParameter("@PayPlatform",model.PayPlatform) ,
                        new SqlParameter("@PayMethod",model.PayMethod) ,
                        new SqlParameter("@PayCode",model.PayCode) ,
                        new SqlParameter("@PayText",model.PayText)

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
        /// datarow转成对象实体
        /// </summary>
        public BWJS.Model.OrderPayApply DataRowToModel(DataRow row)
        {
            BWJS.Model.OrderPayApply model = new BWJS.Model.OrderPayApply();

            if (row != null)
            {
                if (row["OrderPayApplyId"].ToString() != "")
                {
                    model.OrderPayApplyId = int.Parse(row["OrderPayApplyId"].ToString());
                }
                model.PayJson = row["PayJson"].ToString();
                if (row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["PayDate"].ToString() != "")
                {
                    model.PayDate = DateTime.Parse(row["PayDate"].ToString());
                }
                model.Remark = row["Remark"].ToString();
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                if (row["OrderRebateId"].ToString() != "")
                {
                    model.OrderRebateId = int.Parse(row["OrderRebateId"].ToString());
                }
                if (row["OrderMoney"].ToString() != "")
                {
                    model.OrderMoney = decimal.Parse(row["OrderMoney"].ToString());
                }
                model.PayOrderNumber = row["PayOrderNumber"].ToString();
                if (row["PayStatus"].ToString() != "")
                {
                    model.PayStatus = int.Parse(row["PayStatus"].ToString());
                }
                if (row["PayPlatform"].ToString() != "")
                {
                    model.PayPlatform = int.Parse(row["PayPlatform"].ToString());
                }
                if (row["PayMethod"].ToString() != "")
                {
                    model.PayMethod = int.Parse(row["PayMethod"].ToString());
                }
                model.PayCode = row["PayCode"].ToString();
                model.PayText = row["PayText"].ToString();

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
            strSql.Append(" FROM OrderPayApply ");
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
            tablesql.Append(@"
select c.OrderApplyId,
a.OrderPayApplyId, a.OrderRebateId, c.InsureNum, a.PayStatus, a.PayPlatform, a.CreateDate, 
a.PayDate, a.Remark,a.OrderMoney,b.IsSettled,b.IsCancel, d.CName TBName, e.CName BBName,
b.TransNo,u.UserName AS MerchantName,u.RecordIsDelete AS uIsDeleted,c.DepartmentId,dinfo.DepartmentName ,c.UserID 
from BWJSDB.dbo.OrderPayApply a 
LEFT JOIN BWJSDB.dbo.OrderRebate b on b.OrderRebateId = a.OrderRebateId AND b.IsDeleted=0
LEFT JOIN MofangDB.dbo.OrderApply c on c.OrderApplyID = b.OrderApplyId AND c.RecordIsDelete=0
LEFT JOIN MofangDB.dbo.ApplicantInfo d on d.OrderApplyId = c.OrderApplyId AND d.RecordIsDelete=0
LEFT JOIN MofangDB.dbo.InsurantInfo e on e.OrderApplyId = c.OrderApplyId AND e.RecordIsDelete=0
LEFT JOIN dbo.Users u ON u.UserID=c.UserID
LEFT JOIN dbo.DepartmentInfo dinfo ON dinfo.DepartmentID = c.DepartmentID AND dinfo.RecordIsDelete = 0 ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion  ExtensionMethod
    }
}
