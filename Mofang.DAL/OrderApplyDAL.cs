using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using System.Linq;
using Mofang.Model;
using Dapper;
namespace Mofang.DAL
{
    /// <summary>
    /// 承保申请表
    /// </summary>
    public partial class OrderApplyDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mofang.Model.OrderApply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[OrderApply](");
            strSql.Append("CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordUpdateTime,RecordCreateTime,MachineID,UserID,DepartmentId,InsureNum,Price,Respmsg,Respstat,Status");
            strSql.Append(") values (");
            strSql.Append("@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordUpdateTime,@RecordCreateTime,@MachineID,@UserID,@DepartmentId,@InsureNum,@Price,@Respmsg,@Respstat,@Status");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime) ,
                        new SqlParameter("@MachineID", model.MachineID) ,
                        new SqlParameter("@UserID", model.UserID) ,
                        new SqlParameter("@DepartmentId", model.DepartmentId) ,
                        new SqlParameter("@InsureNum", model.InsureNum) ,
                        new SqlParameter("@Price", model.Price) ,
                        new SqlParameter("@Respmsg", model.Respmsg) ,
                        new SqlParameter("@Respstat", model.Respstat) ,
                        new SqlParameter("@Status", model.Status)

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
        public bool Update(Mofang.Model.OrderApply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderApply] set ");

            strSql.Append(" CreatUserID = @CreatUserID , ");
            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");
            strSql.Append(" RecordIsDelete = @RecordIsDelete , ");
            strSql.Append(" RecordUpdateTime = @RecordUpdateTime , ");
            strSql.Append(" RecordCreateTime = @RecordCreateTime , ");
            strSql.Append(" MachineID = @MachineID , ");
            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" DepartmentId = @DepartmentId , ");
            strSql.Append(" InsureNum = @InsureNum , ");
            strSql.Append(" Price = @Price , ");
            strSql.Append(" Respmsg = @Respmsg , ");
            strSql.Append(" Respstat = @Respstat , ");
            strSql.Append(" Status = @Status  ");
            strSql.Append(" where OrderApplyID=@OrderApplyID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@OrderApplyID",model.OrderApplyID) ,
                        new SqlParameter("@CreatUserID",model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID",model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete",model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime",model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime",model.RecordCreateTime) ,
                        new SqlParameter("@MachineID",model.MachineID) ,
                        new SqlParameter("@UserID",model.UserID) ,
                        new SqlParameter("@DepartmentId",model.DepartmentId) ,
                        new SqlParameter("@InsureNum",model.InsureNum) ,
                        new SqlParameter("@Price",model.Price) ,
                        new SqlParameter("@Respmsg",model.Respmsg) ,
                        new SqlParameter("@Respstat",model.Respstat) ,
                        new SqlParameter("@Status",model.Status)

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
        public bool Delete(int OrderApplyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderApply] set IsDeleted=1");
            strSql.Append(" where OrderApplyID=@OrderApplyID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderApplyID", SqlDbType.Int,4)
            };
            parameters[0].Value = OrderApplyID;


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
        public bool DeleteList(string OrderApplyIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderApply] set IsDeleted=1");
            strSql.Append(" where ID in (" + OrderApplyIDlist + ")  ");
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
        public Mofang.Model.OrderApply GetModel(int OrderApplyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderApplyID, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime, RecordCreateTime, MachineID, UserID, DepartmentId, InsureNum, Price, Respmsg, Respstat, Status  ");
            strSql.Append("  from dbo.[OrderApply] ");
            strSql.Append(" where OrderApplyID=@OrderApplyID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderApplyID", SqlDbType.Int,4)
            };
            parameters[0].Value = OrderApplyID;


            Mofang.Model.OrderApply model = new Mofang.Model.OrderApply();
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
        public Mofang.Model.OrderApply DataRowToModel(DataRow row)
        {
            Mofang.Model.OrderApply model = new Mofang.Model.OrderApply();

            if (row != null)
            {
                if (row["OrderApplyID"].ToString() != "")
                {
                    model.OrderApplyID = int.Parse(row["OrderApplyID"].ToString());
                }
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
                if (row["MachineID"].ToString() != "")
                {
                    model.MachineID = int.Parse(row["MachineID"].ToString());
                }
                if (row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["DepartmentId"].ToString() != "")
                {
                    model.DepartmentId = int.Parse(row["DepartmentId"].ToString());
                }
                model.InsureNum = row["InsureNum"].ToString();
                model.Price = row["Price"].ToString();
                model.Respmsg = row["Respmsg"].ToString();
                model.Respstat = row["Respstat"].ToString();
                if (row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
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
            strSql.Append(" FROM dbo.[OrderApply] ");
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
            strSql.Append(" FROM dbo.[OrderApply] ");
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
            tablesql.Append("select * ");
            tablesql.Append(" FROM dbo.[OrderApply] ");
            return DbHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion

        #region ExtensionMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(OrderApply model, SqlTransaction trans, SqlConnection conn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrderApply(");
            strSql.Append("MachineID,DepartmentId,UserID,InsureNum,Price,Respmsg,Respstat,Status,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordUpdateTime,RecordCreateTime");
            strSql.Append(") values (");
            strSql.Append("@MachineID,@DepartmentId,@UserID,@InsureNum,@Price,@Respmsg,@Respstat,@Status,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordUpdateTime,@RecordCreateTime");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@MachineID", model.MachineID) ,
                        new SqlParameter("@DepartmentId", model.DepartmentId) ,
                        new SqlParameter("@UserID", model.UserID) ,
                        new SqlParameter("@InsureNum", model.InsureNum) ,
                        new SqlParameter("@Price", model.Price) ,
                        new SqlParameter("@Respmsg",  model.Respmsg) ,
                        new SqlParameter("@Respstat", model.Respstat) ,
                        new SqlParameter("@Status",  model.Status) ,
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime)

            };


            object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters);
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
        /// 删除一条数据
        /// </summary>
        public bool UpdateDelete(int OrderApplyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderApply set  RecordIsDelete =1   ");
            strSql.Append(" where OrderApplyID=@OrderApplyID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderApplyID", SqlDbType.Int,4)
            };
            parameters[0].Value = OrderApplyID;


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
        public bool UpdateDeleteList(string OrderApplyIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderApply set  RecordIsDelete =1 ");
            strSql.Append(" where ID in (" + OrderApplyIDlist + ")  ");
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
        /// machine添加
        /// </summary>
        /// <param name="contentInfo"></param>
        /// <returns></returns>
        public int Create(OrderApply model)
        {
            string sql = @"  insert into OrderApply ( MachineID ,  UserID  , InsureNum , Price , Respmsg , Respstat , Status , CreatUserID , RecordUpdateUserID , RecordIsDelete , RecordUpdateTime , RecordCreateTime )values(@MachineID
            ,@UserID ,@InsureNum ,@Price ,@Respmsg ,@Respstat ,@Status ,@CreatUserID ,@RecordUpdateUserID ,@RecordIsDelete ,@RecordUpdateTime ,@RecordCreateTime );
             select SCOPE_IDENTITY()";

            using (IDbConnection conn = new SqlConnection(this.ConnectionString))
            {
                return conn.ExecuteScalar<int>(sql, model);
            }
        }

        public OrderApply GetOrderApply(int OrderApplyID)
        {

            string sql = @"  select* from OrderApply where RecordIsDelete=0";

            using (IDbConnection conn = new SqlConnection(this.ConnectionString))
            {
                var resultlist = conn.Query<OrderApply>(sql, new { Id = OrderApplyID }).AsList<OrderApply>();
                if (resultlist != null)
                {
                    if (resultlist.Count > 0)
                    {
                        var result = resultlist.FirstOrDefault();
                        return result;
                    }
                }
            }
            return null;
        } 
        #endregion


    }
}

