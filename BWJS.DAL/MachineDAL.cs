using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using UtilityHelper.Data;
using BWJS.Model;
using BWJS.Model.Model;

namespace BWJS.DAL
{
    /// <summary>
    /// 设备表
    /// </summary>
    public partial class MachineDAL : BaseService
    {

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.Machine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Machine(");
            strSql.Append("Remark,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordUpdateTime,RecordCreateTime,Latitude,Longitude,LocationAddress,AgentId,UserID,AgentName,SupervisorId,SupervisorName,SalesmanId,SalesmanName,SN,MAC,Address,Status,TeamViewerNumber,TeamViewerPwd,ActivationCode,MachineSupplierId,Platform,FlatDeviceNumber,SId");
            strSql.Append(") values (");
            strSql.Append("@Remark,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordUpdateTime,@RecordCreateTime,@Latitude,@Longitude,@LocationAddress,@AgentId,@UserID,@AgentName,@SupervisorId,@SupervisorName,@SalesmanId,@SalesmanName,@SN,@MAC,@Address,@Status,@TeamViewerNumber,@TeamViewerPwd,@ActivationCode,@MachineSupplierId,@Platform,@FlatDeviceNumber,@SId");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime) ,
                        new SqlParameter("@Latitude", model.Latitude) ,
                        new SqlParameter("@Longitude", model.Longitude) ,
                        new SqlParameter("@LocationAddress", model.LocationAddress) ,
                        new SqlParameter("@AgentId", model.AgentId) ,
                        new SqlParameter("@UserID", model.UserID) ,
                        new SqlParameter("@AgentName", model.AgentName) ,
                        new SqlParameter("@SupervisorId", model.SupervisorId) ,
                        new SqlParameter("@SupervisorName", model.SupervisorName) ,
                        new SqlParameter("@SalesmanId", model.SalesmanId) ,
                        new SqlParameter("@SalesmanName", model.SalesmanName) ,
                        new SqlParameter("@SN", model.SN) ,
                        new SqlParameter("@MAC", model.MAC) ,
                        new SqlParameter("@Address", model.Address) ,
                        new SqlParameter("@Status", model.Status) ,
                        new SqlParameter("@TeamViewerNumber", model.TeamViewerNumber) ,
                        new SqlParameter("@TeamViewerPwd", model.TeamViewerPwd) ,
                        new SqlParameter("@ActivationCode", model.ActivationCode),
                        new SqlParameter("@MachineSupplierId", model.MachineSupplierId),
                        new SqlParameter("@Platform", model.Platform),
                        new SqlParameter("@FlatDeviceNumber", model.FlatDeviceNumber),
                        new SqlParameter("@SId", model.SId)
                        
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
        public bool Update(BWJS.Model.Machine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Machine set ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" CreatUserID = @CreatUserID , ");
            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");
            strSql.Append(" RecordIsDelete = @RecordIsDelete , ");
            strSql.Append(" RecordUpdateTime = @RecordUpdateTime , ");
            strSql.Append(" RecordCreateTime = @RecordCreateTime , ");
            strSql.Append(" Latitude = @Latitude , ");
            strSql.Append(" Longitude = @Longitude , ");
            strSql.Append(" LocationAddress = @LocationAddress , ");
            strSql.Append(" AgentId = @AgentId , ");
            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" AgentName = @AgentName , ");
            strSql.Append(" SupervisorId = @SupervisorId , ");
            strSql.Append(" SupervisorName = @SupervisorName , ");
            strSql.Append(" SalesmanId = @SalesmanId , ");
            strSql.Append(" SalesmanName = @SalesmanName , ");
            strSql.Append(" SN = @SN , ");
            strSql.Append(" MAC = @MAC , ");
            strSql.Append(" Address = @Address , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" TeamViewerNumber = @TeamViewerNumber , ");
            strSql.Append(" TeamViewerPwd = @TeamViewerPwd , ");
            strSql.Append(" ActivationCode = @ActivationCode , ");
            strSql.Append(" MachineSupplierId = @MachineSupplierId  ,");
            strSql.Append(" Platform = @Platform , ");
            strSql.Append(" FlatDeviceNumber = @FlatDeviceNumber , ");
            strSql.Append(" SId = @SId  ");
            
            strSql.Append(" where MachineID=@MachineID ");
            SqlParameter[] parameters = {
                        new SqlParameter("@MachineID",model.MachineID) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@CreatUserID",model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID",model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete",model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime",model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime",model.RecordCreateTime) ,
                        new SqlParameter("@Latitude",model.Latitude) ,
                        new SqlParameter("@Longitude",model.Longitude) ,
                        new SqlParameter("@LocationAddress",model.LocationAddress) ,
                        new SqlParameter("@AgentId",model.AgentId) ,
                        new SqlParameter("@UserID",model.UserID) ,
                        new SqlParameter("@AgentName",model.AgentName) ,
                        new SqlParameter("@SupervisorId",model.SupervisorId) ,
                        new SqlParameter("@SupervisorName",model.SupervisorName) ,
                        new SqlParameter("@SalesmanId",model.SalesmanId) ,
                        new SqlParameter("@SalesmanName",model.SalesmanName) ,
                        new SqlParameter("@SN",model.SN) ,
                        new SqlParameter("@MAC",model.MAC) ,
                        new SqlParameter("@Address",model.Address) ,
                        new SqlParameter("@Status",model.Status) ,
                        new SqlParameter("@TeamViewerNumber",model.TeamViewerNumber) ,
                        new SqlParameter("@TeamViewerPwd",model.TeamViewerPwd) ,
                        new SqlParameter("@ActivationCode",model.ActivationCode),
                        new SqlParameter("@MachineSupplierId",model.MachineSupplierId),
                        new SqlParameter("@Platform",model.Platform),
                        new SqlParameter("@FlatDeviceNumber",model.FlatDeviceNumber),
                        new SqlParameter("@SId",model.SId)
                        
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
        public BWJS.Model.Machine GetModel(int MachineID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Machine ");
            strSql.Append(" where MachineID=@MachineID");
            SqlParameter[] parameters = {
                    new SqlParameter("@MachineID", SqlDbType.Int,4)
            };
            parameters[0].Value = MachineID;
            BWJS.Model.Machine model = new BWJS.Model.Machine();
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
        public BWJS.Model.Machine DataRowToModel(DataRow row)
        {
            BWJS.Model.Machine model = new BWJS.Model.Machine();
            if (row != null)
            {
                if (row["MachineID"].ToString() != "")
                {
                    model.MachineID = int.Parse(row["MachineID"].ToString());
                }
                model.Remark = row["Remark"].ToString();
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
                model.Latitude = row["Latitude"].ToString();
                model.Longitude = row["Longitude"].ToString();
                model.LocationAddress = row["LocationAddress"].ToString();
                if (row["AgentId"].ToString() != "")
                {
                    model.AgentId = int.Parse(row["AgentId"].ToString());
                }
                if (row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                model.AgentName = row["AgentName"].ToString();
                if (row["SupervisorId"].ToString() != "")
                {
                    model.SupervisorId = int.Parse(row["SupervisorId"].ToString());
                }
                model.SupervisorName = row["SupervisorName"].ToString();
                if (row["SalesmanId"].ToString() != "")
                {
                    model.SalesmanId = int.Parse(row["SalesmanId"].ToString());
                }
                model.SalesmanName = row["SalesmanName"].ToString();
                model.SN = row["SN"].ToString();
                model.MAC = row["MAC"].ToString();
                model.Address = row["Address"].ToString();
                if (row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                model.TeamViewerNumber = row["TeamViewerNumber"].ToString();
                model.TeamViewerPwd = row["TeamViewerPwd"].ToString();
                model.ActivationCode = row["ActivationCode"].ToString();
                if (row["MachineSupplierId"].ToString() != "")
                {
                    model.MachineSupplierId = int.Parse(row["MachineSupplierId"].ToString());
                }
                model.Platform = row["Platform"].ToString();
                model.FlatDeviceNumber = row["FlatDeviceNumber"].ToString();
                model.SId = row["SId"].ToString(); 
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
            strSql.Append(" FROM Machine ");
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
        //    strSql.Append(" FROM Machine ");
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

        #region  ExtensionMethod

        /// <summary>
        /// 删除一条数据
        /// </summary>
        //public bool Delete(int machineId, int userId)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update Machine set RecordIsDelete=1,UserId=null,RecordUpdateUserID=@RecordUpdateUserID,RecordUpdateTime=@RecordUpdateTime");
        //    strSql.Append(" where MachineID=@MachineID");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@MachineID", machineId),
        //            new SqlParameter("@RecordUpdateUserID", userId),
        //            new SqlParameter("@RecordUpdateTime", DateTime.Now)
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string machineIdlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update Machine set RecordIsDelete=1,UserId=null,RecordUpdateUserID={0},RecordUpdateTime='{1}'", userId, DateTime.Now);
            strSql.Append(" where MachineID in (" + machineIdlist + "); ");
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
            tablesql.Append("select a.*,(case when b.[SignName] is null or b.[SignName]='' then '无' else b.[SignName] end) UserFullName ,c.[SupplierName] from [BWJSDB].[dbo].[Machine] a left join [BWJSDB].[dbo].[SupplierInfo] b on b.[SId]=a.[SId] left join [BWJSDB].[dbo].[MachineSupplier] c on c.[MachineSupplierId]=a.[MachineSupplierId]");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.Machine GetModelByUserId(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Machine ");
            strSql.Append(" where UserID=@UserID and RecordIsDelete=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            BWJS.Model.Machine model = new BWJS.Model.Machine();
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
        public DataSet GetModelListName(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.[SignName] from [BWJSDB].[dbo].[Machine] a left join [BWJSDB].[dbo].[SupplierInfo] b on b.[SId]=a.[SId] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MachineBackups DataRowToModelName(DataRow row)
        {
            MachineBackups model = new MachineBackups();
            if (row != null)
            {
                if (row["MachineID"].ToString() != "")
                {
                    model.MachineID = int.Parse(row["MachineID"].ToString());
                }
                model.Remark = row["Remark"].ToString();
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
                model.Latitude = row["Latitude"].ToString();
                model.Longitude = row["Longitude"].ToString();
                model.LocationAddress = row["LocationAddress"].ToString();
                if (row["AgentId"].ToString() != "")
                {
                    model.AgentId = int.Parse(row["AgentId"].ToString());
                }
                if (row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["MachineSupplierId"].ToString() != "")
                {
                    model.MachineSupplierId = int.Parse(row["MachineSupplierId"].ToString());
                }
                model.AgentName = row["AgentName"].ToString();
                if (row["SupervisorId"].ToString() != "")
                {
                    model.SupervisorId = int.Parse(row["SupervisorId"].ToString());
                }
                model.SupervisorName = row["SupervisorName"].ToString();
                if (row["SalesmanId"].ToString() != "")
                {
                    model.SalesmanId = int.Parse(row["SalesmanId"].ToString());
                }
                model.SalesmanName = row["SalesmanName"].ToString();
                model.SN = row["SN"].ToString();
                model.MAC = row["MAC"].ToString();
                model.Address = row["Address"].ToString();
                if (row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                model.TeamViewerNumber = row["TeamViewerNumber"].ToString();
                model.TeamViewerPwd = row["TeamViewerPwd"].ToString();
                model.ActivationCode = row["ActivationCode"].ToString();
                //if (row["UserName"] != null)
                //{
                //    model.UserName = row["UserName"].ToString();
                //}
                //if (row["LoginName"] != null)
                //{
                //    model.LoginName = row["LoginName"].ToString();
                //}
                if (row["Platform"] != null)
                {
                    model.Platform = row["Platform"].ToString();
                }
                if (row["FlatDeviceNumber"] != null)
                {
                    model.FlatDeviceNumber = row["FlatDeviceNumber"].ToString();
                }
                //if (row["SId"] != null)
                //{
                //    model.SId = row["SId"].ToString();
                //}
                if (row["SignName"] != null)
                {
                    model.SignName = row["SignName"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsBySN(string SN)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Machine");
            strSql.Append(" where SN=@SN and RecordIsDelete=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@SN", SqlDbType.VarChar,100)
            };
            parameters[0].Value = SN;
            return BWJSHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool Exists(int MachineID, string SN)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Machine");
            strSql.Append(" where ");
            strSql.Append(" MachineID <> @MachineID and  ");
            strSql.Append(" SN = @SN  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MachineID", SqlDbType.Int,4),
                    new SqlParameter("@SN", SqlDbType.VarChar,100)          };
            parameters[0].Value = MachineID;
            parameters[1].Value = SN;
            return BWJSHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsByUserIdImei(int userId, string Imei)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Machine");
            strSql.Append(" where ");
            strSql.Append(" UserID = @userId and  ");
            strSql.Append(" FlatDeviceNumber = @Imei  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@userId", SqlDbType.Int,4),
                    new SqlParameter("@Imei", SqlDbType.VarChar,100)          };
            parameters[0].Value = userId;
            parameters[1].Value = Imei;
            return BWJSHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public int TotalUserIdPlatform(int userId, string Platform)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Machine");
            strSql.Append(" where ");
            strSql.Append(" UserID = @userId and  ");
            strSql.Append(" Platform = @Platform  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@userId", SqlDbType.Int,4),
                    new SqlParameter("@Platform", SqlDbType.VarChar,100)          };
            parameters[0].Value = userId;
            parameters[1].Value = Platform;
            return BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

