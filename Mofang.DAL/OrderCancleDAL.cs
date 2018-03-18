using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using Mofang.Model;
namespace Mofang.DAL
{
    //退保表
    public partial class OrderCancleDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mofang.Model.OrderCancle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[OrderCancle](");
            strSql.Append("RecordIsDelete,RecordUpdateTime,RecordCreateTime,InsureNum,RespCode,TransNo,RespMsg,OrderApplyID,OrderRebateId,CreatUserID,RecordUpdateUserID");
            strSql.Append(") values (");
            strSql.Append("@RecordIsDelete,@RecordUpdateTime,@RecordCreateTime,@InsureNum,@RespCode,@TransNo,@RespMsg,@OrderApplyID,@OrderRebateId,@CreatUserID,@RecordUpdateUserID");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime) ,
                        new SqlParameter("@InsureNum", model.InsureNum) ,
                        new SqlParameter("@RespCode", model.RespCode) ,
                        new SqlParameter("@TransNo", model.TransNo) ,
                        new SqlParameter("@RespMsg", model.RespMsg) ,
                        new SqlParameter("@OrderApplyID", model.OrderApplyID) ,
                        new SqlParameter("@OrderRebateId", model.OrderRebateId) ,
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID)

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
        public bool Update(Mofang.Model.OrderCancle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderCancle] set ");

            strSql.Append(" RecordIsDelete = @RecordIsDelete , ");
            strSql.Append(" RecordUpdateTime = @RecordUpdateTime , ");
            strSql.Append(" RecordCreateTime = @RecordCreateTime , ");
            strSql.Append(" InsureNum = @InsureNum , ");
            strSql.Append(" RespCode = @RespCode , ");
            strSql.Append(" TransNo = @TransNo , ");
            strSql.Append(" RespMsg = @RespMsg , ");
            strSql.Append(" OrderApplyID = @OrderApplyID , ");
            strSql.Append(" OrderRebateId = @OrderRebateId , ");
            strSql.Append(" CreatUserID = @CreatUserID , ");
            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID  ");
            strSql.Append(" where OrderCancleID=@OrderCancleID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@OrderCancleID",model.OrderCancleID) ,
                        new SqlParameter("@RecordIsDelete",model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime",model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime",model.RecordCreateTime) ,
                        new SqlParameter("@InsureNum",model.InsureNum) ,
                        new SqlParameter("@RespCode",model.RespCode) ,
                        new SqlParameter("@TransNo",model.TransNo) ,
                        new SqlParameter("@RespMsg",model.RespMsg) ,
                        new SqlParameter("@OrderApplyID",model.OrderApplyID) ,
                        new SqlParameter("@OrderRebateId",model.OrderRebateId) ,
                        new SqlParameter("@CreatUserID",model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID",model.RecordUpdateUserID)

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
        public bool Delete(int OrderCancleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderCancle] set IsDeleted=1");
            strSql.Append(" where OrderCancleID=@OrderCancleID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderCancleID", SqlDbType.Int,4)
            };
            parameters[0].Value = OrderCancleID;


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
        public bool DeleteList(string OrderCancleIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderCancle] set IsDeleted=1");
            strSql.Append(" where ID in (" + OrderCancleIDlist + ")  ");
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
        public Mofang.Model.OrderCancle GetModel(int OrderCancleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderCancleID, RecordIsDelete, RecordUpdateTime, RecordCreateTime, InsureNum, RespCode, TransNo, RespMsg, OrderApplyID, OrderRebateId, CreatUserID, RecordUpdateUserID  ");
            strSql.Append("  from dbo.[OrderCancle] ");
            strSql.Append(" where OrderCancleID=@OrderCancleID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderCancleID", SqlDbType.Int,4)
            };
            parameters[0].Value = OrderCancleID;


            Mofang.Model.OrderCancle model = new Mofang.Model.OrderCancle();
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
        public Mofang.Model.OrderCancle DataRowToModel(DataRow row)
        {
            Mofang.Model.OrderCancle model = new Mofang.Model.OrderCancle();

            if (row != null)
            {
                if (row["OrderCancleID"].ToString() != "")
                {
                    model.OrderCancleID = int.Parse(row["OrderCancleID"].ToString());
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
                model.InsureNum = row["InsureNum"].ToString();
                model.RespCode = row["RespCode"].ToString();
                model.TransNo = row["TransNo"].ToString();
                model.RespMsg = row["RespMsg"].ToString();
                if (row["OrderApplyID"].ToString() != "")
                {
                    model.OrderApplyID = int.Parse(row["OrderApplyID"].ToString());
                }
                if (row["OrderRebateId"].ToString() != "")
                {
                    model.OrderRebateId = int.Parse(row["OrderRebateId"].ToString());
                }
                if (row["CreatUserID"].ToString() != "")
                {
                    model.CreatUserID = int.Parse(row["CreatUserID"].ToString());
                }
                if (row["RecordUpdateUserID"].ToString() != "")
                {
                    model.RecordUpdateUserID = int.Parse(row["RecordUpdateUserID"].ToString());
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
            strSql.Append(" FROM dbo.[OrderCancle] ");
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
            strSql.Append(" FROM dbo.[OrderCancle] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
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
            return DbHelperSQL.GetPageList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
            tablesql.Append(@"   select a.*,u.UserName AS MerchantName,u.RecordIsDelete AS uIsDeleted,dinfo.DepartmentName from 
                                        [MofangDB].dbo.[OrderCancle] a
                                        inner join MofangDB.dbo.OrderApply b on b.OrderApplyID = a.OrderApplyId  AND b.RecordIsDelete=0
                                        LEFT JOIN [BWJSDB].dbo.Users  u ON u.UserID=b.UserID 
                                          LEFT JOIN [BWJSDB].dbo.DepartmentInfo  dinfo ON dinfo.DepartmentID = b.DepartmentID AND dinfo.RecordIsDelete = 0 ");
            return DbHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }
        #endregion

        #region ExtensionMethod

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool UpdateDelete(int OrderCancleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderCancle set  RecordIsDelete =1  ");
            strSql.Append(" where OrderCancleID=@OrderCancleID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderCancleID", SqlDbType.Int,4)
            };
            parameters[0].Value = OrderCancleID;


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
        public bool UpdateDeleteList(string OrderCancleIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderCancle set  RecordIsDelete =1  ");
            strSql.Append(" where ID in (" + OrderCancleIDlist + ")  ");
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
        
        #endregion


    }
}

