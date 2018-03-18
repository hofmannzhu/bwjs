using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using Mofang.Model;
namespace Mofang.DAL
{
    //订单信息
    public partial class ApplicationDataDAL : BaseService
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ApplicationData model, SqlTransaction trans, SqlConnection conn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ApplicationData(");
            strSql.Append("OrderApplyID,ApplicationDate,StartDate,EndDate,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordCreateTime,RecordUpdateTime");
            strSql.Append(") values (");
            strSql.Append("@OrderApplyID,@ApplicationDate,@StartDate,@EndDate,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordCreateTime,@RecordUpdateTime");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@OrderApplyID", model.OrderApplyID) ,
                        new SqlParameter("@ApplicationDate", model.ApplicationDate) ,
                        new SqlParameter("@StartDate", model.StartDate) ,
                        new SqlParameter("@EndDate", model.EndDate) ,
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime)

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
        /// 增加一条数据
        /// </summary>
        public int Add(ApplicationData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ApplicationData(");
            strSql.Append("OrderApplyID,ApplicationDate,StartDate,EndDate,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordCreateTime,RecordUpdateTime");
            strSql.Append(") values (");
            strSql.Append("@OrderApplyID,@ApplicationDate,@StartDate,@EndDate,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordCreateTime,@RecordUpdateTime");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@OrderApplyID", model.OrderApplyID) ,
                        new SqlParameter("@ApplicationDate", model.ApplicationDate) ,
                        new SqlParameter("@StartDate", model.StartDate) ,
                        new SqlParameter("@EndDate",model.EndDate) ,
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                        new SqlParameter("@RecordCreateTime",model.RecordCreateTime) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime)

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
        public bool Update(ApplicationData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ApplicationData set ");
            strSql.Append(" OrderApplyID = @OrderApplyID , ");
            strSql.Append(" ApplicationDate = @ApplicationDate , ");
            strSql.Append(" StartDate = @StartDate , ");
            strSql.Append(" EndDate = @EndDate , ");
            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");
            strSql.Append(" RecordUpdateTime = GetDate() ");
            strSql.Append(" where AppDataID=@AppDataID  and RecordUpdateTime = @RecordUpdateTime");
            SqlParameter[] parameters = {
                        new SqlParameter("@AppDataID",  model.AppDataID) ,
                        new SqlParameter("@OrderApplyID",  model.OrderApplyID) ,
                        new SqlParameter("@ApplicationDate", model.ApplicationDate) ,
                        new SqlParameter("@StartDate", model.StartDate) ,
                        new SqlParameter("@EndDate", model.EndDate) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime)

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
        public bool UpdateDelete(int AppDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ApplicationData set  RecordIsDelete =1  ");
            strSql.Append(" where AppDataID=@AppDataID");
            SqlParameter[] parameters = {
                    new SqlParameter("@AppDataID", SqlDbType.Int,4)
            };
            parameters[0].Value = AppDataID;


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
        public bool UpdateDeleteList(string AppDataIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ApplicationData set  RecordIsDelete =1 ");
            strSql.Append(" where ID in (" + AppDataIDlist + ")  ");
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
        public ApplicationData GetModel(int AppDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AppDataID, OrderApplyID, ApplicationDate, StartDate, EndDate, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordCreateTime, RecordUpdateTime  ");
            strSql.Append("  from ApplicationData ");
            strSql.Append(" where AppDataID=@AppDataID");
            SqlParameter[] parameters = {
                    new SqlParameter("@AppDataID", SqlDbType.Int,4)
            };
            parameters[0].Value = AppDataID;


            ApplicationData model = new ApplicationData();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AppDataID"].ToString() != "")
                {
                    model.AppDataID = int.Parse(ds.Tables[0].Rows[0]["AppDataID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderApplyID"].ToString() != "")
                {
                    model.OrderApplyID = int.Parse(ds.Tables[0].Rows[0]["OrderApplyID"].ToString());
                }
                model.ApplicationDate = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
                model.StartDate = ds.Tables[0].Rows[0]["StartDate"].ToString();
                model.EndDate = ds.Tables[0].Rows[0]["EndDate"].ToString();
                if (ds.Tables[0].Rows[0]["CreatUserID"].ToString() != "")
                {
                    model.CreatUserID = int.Parse(ds.Tables[0].Rows[0]["CreatUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString() != "")
                {
                    model.RecordUpdateUserID = int.Parse(ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordIsDelete"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["RecordIsDelete"].ToString() == "1") || (ds.Tables[0].Rows[0]["RecordIsDelete"].ToString().ToLower() == "true"))
                    {
                        model.RecordIsDelete = true;
                    }
                    else
                    {
                        model.RecordIsDelete = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordCreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString() != "")
                {
                    model.RecordUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString());
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
            strSql.Append(" FROM ApplicationData ");
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
            strSql.Append(" FROM ApplicationData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

