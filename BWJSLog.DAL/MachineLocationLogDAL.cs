using UtilityHelper;
using UtilityHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BWJSLog.DAL
{

    /// <summary>
    /// 设备登录日志
    /// </summary>
    public partial class MachineLocationLogDAL : BaseService
    {
        public MachineLocationLogDAL()
        { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJSLog.Model.MachineLocationLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[MachineLocationLog](");
            strSql.Append("CreateDate,IsDeleted,Remark,UserId,MachineId,IP,MAC,Latitude,Longitude,LocationAddress,LocationData");
            strSql.Append(") values (");
            strSql.Append("@CreateDate,@IsDeleted,@Remark,@UserId,@MachineId,@IP,@MAC,@Latitude,@Longitude,@LocationAddress,@LocationData");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@UserId", model.UserId) ,
                        new SqlParameter("@MachineId", model.MachineId) ,
                        new SqlParameter("@IP", model.IP) ,
                        new SqlParameter("@MAC", model.MAC) ,
                        new SqlParameter("@Latitude", model.Latitude) ,
                        new SqlParameter("@Longitude", model.Longitude) ,
                        new SqlParameter("@LocationAddress", model.LocationAddress) ,
                        new SqlParameter("@LocationData", model.LocationData)

            };


            object obj = BWJSLogHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(BWJSLog.Model.MachineLocationLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[MachineLocationLog] set ");

            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" MachineId = @MachineId , ");
            strSql.Append(" IP = @IP , ");
            strSql.Append(" MAC = @MAC , ");
            strSql.Append(" Latitude = @Latitude , ");
            strSql.Append(" Longitude = @Longitude , ");
            strSql.Append(" LocationAddress = @LocationAddress , ");
            strSql.Append(" LocationData = @LocationData  ");
            strSql.Append(" where MachineLocationLogId=@MachineLocationLogId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@MachineLocationLogId",model.MachineLocationLogId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@UserId",model.UserId) ,
                        new SqlParameter("@MachineId",model.MachineId) ,
                        new SqlParameter("@IP",model.IP) ,
                        new SqlParameter("@MAC",model.MAC) ,
                        new SqlParameter("@Latitude",model.Latitude) ,
                        new SqlParameter("@Longitude",model.Longitude) ,
                        new SqlParameter("@LocationAddress",model.LocationAddress) ,
                        new SqlParameter("@LocationData",model.LocationData)

            };

            int rows = BWJSLogHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int MachineLocationLogId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[MachineLocationLog] set IsDeleted=1");
            strSql.Append(" where MachineLocationLogId=@MachineLocationLogId");
            SqlParameter[] parameters = {
                    new SqlParameter("@MachineLocationLogId", SqlDbType.Int,4)
            };
            parameters[0].Value = MachineLocationLogId;


            int rows = BWJSLogHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string MachineLocationLogIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[MachineLocationLog] set IsDeleted=1");
            strSql.Append(" where ID in (" + MachineLocationLogIdlist + ")  ");
            int rows = BWJSLogHelperSQL.ExecuteSql(strSql.ToString());
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
        public BWJSLog.Model.MachineLocationLog GetModel(int MachineLocationLogId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MachineLocationLogId, CreateDate, IsDeleted, Remark, UserId, MachineId, IP, MAC, Latitude, Longitude, LocationAddress, LocationData  ");
            strSql.Append("  from dbo.[MachineLocationLog] ");
            strSql.Append(" where MachineLocationLogId=@MachineLocationLogId");
            SqlParameter[] parameters = {
                    new SqlParameter("@MachineLocationLogId", SqlDbType.Int,4)
            };
            parameters[0].Value = MachineLocationLogId;


            BWJSLog.Model.MachineLocationLog model = new BWJSLog.Model.MachineLocationLog();
            DataSet ds = BWJSLogHelperSQL.Query(strSql.ToString(), parameters);

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
        public BWJSLog.Model.MachineLocationLog DataRowToModel(DataRow row)
        {
            BWJSLog.Model.MachineLocationLog model = new BWJSLog.Model.MachineLocationLog();

            if (row != null)
            {
                if (row["MachineLocationLogId"].ToString() != "")
                {
                    model.MachineLocationLogId = int.Parse(row["MachineLocationLogId"].ToString());
                }
                if (row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                model.Remark = row["Remark"].ToString();
                if (row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["MachineId"].ToString() != "")
                {
                    model.MachineId = int.Parse(row["MachineId"].ToString());
                }
                model.IP = row["IP"].ToString();
                model.MAC = row["MAC"].ToString();
                model.Latitude = row["Latitude"].ToString();
                model.Longitude = row["Longitude"].ToString();
                model.LocationAddress = row["LocationAddress"].ToString();

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
            strSql.Append(" FROM dbo.[MachineLocationLog] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSLogHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" FROM dbo.[MachineLocationLog] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSLogHelperSQL.Query(strSql.ToString());
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
            return BWJSLogHelperSQL.GetPageList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
            tablesql.Append(" FROM dbo.[MachineLocationLog] ");
            return BWJSLogHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }
        #endregion

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
