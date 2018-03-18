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
    /// 结算申请详情
    /// </summary>
    public partial class OrderRebateSettlementDetailsDAL : BaseService
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.OrderRebateSettlementDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[OrderRebateSettlementDetails](");
            strSql.Append("OrderRebateSettlementApplyId,OrderRebateId,CreateDate,CreateId");
            strSql.Append(") values (");
            strSql.Append("@OrderRebateSettlementApplyId,@OrderRebateId,@CreateDate,@CreateId");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@OrderRebateSettlementApplyId", model.OrderRebateSettlementApplyId) ,
                        new SqlParameter("@OrderRebateId", model.OrderRebateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@CreateId", model.CreateId)

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
        public bool Update(BWJS.Model.OrderRebateSettlementDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderRebateSettlementDetails] set ");

            strSql.Append(" OrderRebateSettlementApplyId = @OrderRebateSettlementApplyId , ");
            strSql.Append(" OrderRebateId = @OrderRebateId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" CreateId = @CreateId  ");
            strSql.Append(" where OrderRebateSettlementDetailsId=@OrderRebateSettlementDetailsId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@OrderRebateSettlementDetailsId",model.OrderRebateSettlementDetailsId) ,
                        new SqlParameter("@OrderRebateSettlementApplyId",model.OrderRebateSettlementApplyId) ,
                        new SqlParameter("@OrderRebateId",model.OrderRebateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@CreateId",model.CreateId)

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
        public bool Delete(int OrderRebateSettlementDetailsId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderRebateSettlementDetails] set IsDeleted=1");
            strSql.Append(" where OrderRebateSettlementDetailsId=@OrderRebateSettlementDetailsId");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderRebateSettlementDetailsId", SqlDbType.Int,4)
            };
            parameters[0].Value = OrderRebateSettlementDetailsId;


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
        public bool DeleteList(string OrderRebateSettlementDetailsIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderRebateSettlementDetails] set IsDeleted=1");
            strSql.Append(" where ID in (" + OrderRebateSettlementDetailsIdlist + ")  ");
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
        public BWJS.Model.OrderRebateSettlementDetails GetModel(int OrderRebateSettlementDetailsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderRebateSettlementDetailsId, OrderRebateSettlementApplyId, OrderRebateId, CreateDate, CreateId  ");
            strSql.Append("  from dbo.[OrderRebateSettlementDetails] ");
            strSql.Append(" where OrderRebateSettlementDetailsId=@OrderRebateSettlementDetailsId");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderRebateSettlementDetailsId", SqlDbType.Int,4)
            };
            parameters[0].Value = OrderRebateSettlementDetailsId;


            BWJS.Model.OrderRebateSettlementDetails model = new BWJS.Model.OrderRebateSettlementDetails();
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
        public BWJS.Model.OrderRebateSettlementDetails DataRowToModel(DataRow row)
        {
            BWJS.Model.OrderRebateSettlementDetails model = new BWJS.Model.OrderRebateSettlementDetails();

            if (row != null)
            {
                if (row["OrderRebateSettlementDetailsId"].ToString() != "")
                {
                    model.OrderRebateSettlementDetailsId = int.Parse(row["OrderRebateSettlementDetailsId"].ToString());
                }
                if (row["OrderRebateSettlementApplyId"].ToString() != "")
                {
                    model.OrderRebateSettlementApplyId = int.Parse(row["OrderRebateSettlementApplyId"].ToString());
                }
                if (row["OrderRebateId"].ToString() != "")
                {
                    model.OrderRebateId = int.Parse(row["OrderRebateId"].ToString());
                }
                if (row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["CreateId"].ToString() != "")
                {
                    model.CreateId = int.Parse(row["CreateId"].ToString());
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
            strSql.Append(" FROM dbo.[OrderRebateSettlementDetails] ");
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
            strSql.Append(" FROM dbo.[OrderRebateSettlementDetails] ");
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
            tablesql.Append(" FROM dbo.[OrderRebateSettlementDetails] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion  ExtensionMethod

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
