using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using BWJS.Model;
using UtilityHelper.Data;
using Dapper;
using System.Linq;
using BWJS.Model.Model;
using BWJSLog.BLL;
namespace BWJS.DAL
{
    /// <summary>
    /// 会员表
    /// </summary>
    [Serializable]
    public partial class UsersDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Users(");
            strSql.Append("UserType,GravatarResourceID,LastAccessIP,CompanyName,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordUpdateTime,RecordCreateTime,CardID,LoginName,ReginId,IsLocked,IsLogined,LoginTimes,ProvinceID,CityID,CountyID,Address,Password,UserName,Sex,Phone,QQ,Wechat,Email,DepartmentID,SId");
            strSql.Append(") values (");
            strSql.Append("@UserType,@GravatarResourceID,@LastAccessIP,@CompanyName,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordUpdateTime,@RecordCreateTime,@CardID,@LoginName,@ReginId,@IsLocked,@IsLogined,@LoginTimes,@ProvinceID,@CityID,@CountyID,@Address,@Password,@UserName,@Sex,@Phone,@QQ,@Wechat,@Email,@DepartmentID,@SId");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@UserType", model.UserType) ,
                        new SqlParameter("@GravatarResourceID", model.GravatarResourceID) ,
                        new SqlParameter("@LastAccessIP", model.LastAccessIP) ,
                        new SqlParameter("@CompanyName", model.CompanyName) ,
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime) ,
                        new SqlParameter("@CardID", model.CardID) ,
                        new SqlParameter("@LoginName", model.LoginName) ,
                        new SqlParameter("@ReginId", model.ReginId) ,
                        new SqlParameter("@IsLocked", model.IsLocked) ,
                        new SqlParameter("@IsLogined", model.IsLogined) ,
                        new SqlParameter("@LoginTimes", model.LoginTimes) ,
                        new SqlParameter("@ProvinceID", model.ProvinceID) ,
                        new SqlParameter("@CityID", model.CityID) ,
                        new SqlParameter("@CountyID", model.CountyID) ,
                        new SqlParameter("@Address", model.Address) ,
                        new SqlParameter("@Password", model.Password) ,
                        new SqlParameter("@UserName", model.UserName) ,
                        new SqlParameter("@Sex", model.Sex) ,
                        new SqlParameter("@Phone", model.Phone) ,
                        new SqlParameter("@QQ", model.QQ) ,
                        new SqlParameter("@Wechat", model.Wechat) ,
                        new SqlParameter("@Email", model.Email),
                        new SqlParameter("@DepartmentID", model.DepartmentID),
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
        public bool Update(BWJS.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append(" UserType = @UserType , ");
            strSql.Append(" GravatarResourceID = @GravatarResourceID , ");
            strSql.Append(" LastAccessIP = @LastAccessIP , ");
            strSql.Append(" CompanyName = @CompanyName , ");
            strSql.Append(" CreatUserID = @CreatUserID , ");
            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");
            strSql.Append(" RecordIsDelete = @RecordIsDelete , ");
            strSql.Append(" RecordUpdateTime = @RecordUpdateTime , ");
            strSql.Append(" RecordCreateTime = @RecordCreateTime , ");
            strSql.Append(" CardID = @CardID , ");
            strSql.Append(" LoginName = @LoginName , ");
            strSql.Append(" ReginId = @ReginId , ");
            strSql.Append(" IsLocked = @IsLocked , ");
            strSql.Append(" IsLogined = @IsLogined , ");
            strSql.Append(" LoginTimes = @LoginTimes , ");
            strSql.Append(" ProvinceID = @ProvinceID , ");
            strSql.Append(" CityID = @CityID , ");
            strSql.Append(" CountyID = @CountyID , ");
            strSql.Append(" Address = @Address , ");
            strSql.Append(" UserName = @UserName , ");
            strSql.Append(" Sex = @Sex , ");
            strSql.Append(" Phone = @Phone , ");
            strSql.Append(" QQ = @QQ , ");
            strSql.Append(" Wechat = @Wechat , ");
            strSql.Append(" Email = @Email, ");
            strSql.Append(" DepartmentID = @DepartmentID ,");
            strSql.Append(" SId = @SId ");
            strSql.Append(" where UserID=@UserID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@UserID",model.UserID) ,
                        new SqlParameter("@UserType",model.UserType) ,
                        new SqlParameter("@GravatarResourceID",model.GravatarResourceID) ,
                        new SqlParameter("@LastAccessIP",model.LastAccessIP) ,
                        new SqlParameter("@CompanyName",model.CompanyName) ,
                        new SqlParameter("@CreatUserID",model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID",model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete",model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime",model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime",model.RecordCreateTime) ,
                        new SqlParameter("@CardID",model.CardID) ,
                        new SqlParameter("@LoginName",model.LoginName) ,
                        new SqlParameter("@ReginId",model.ReginId) ,
                        new SqlParameter("@IsLocked",model.IsLocked) ,
                        new SqlParameter("@IsLogined",model.IsLogined) ,
                        new SqlParameter("@LoginTimes",model.LoginTimes) ,
                        new SqlParameter("@ProvinceID",model.ProvinceID) ,
                        new SqlParameter("@CityID",model.CityID) ,
                        new SqlParameter("@CountyID",model.CountyID) ,
                        new SqlParameter("@Address",model.Address) ,
                        new SqlParameter("@UserName",model.UserName) ,
                        new SqlParameter("@Sex",model.Sex) ,
                        new SqlParameter("@Phone",model.Phone) ,
                        new SqlParameter("@QQ",model.QQ) ,
                        new SqlParameter("@Wechat",model.Wechat) ,
                        new SqlParameter("@Email",model.Email),
                        new SqlParameter("@DepartmentID",model.DepartmentID),
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set RecordIsDelete=1");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4)
            };
            parameters[0].Value = UserID;


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
        public bool DeleteList(string UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set RecordIsDelete=1");
            strSql.Append(" where ID in (" + UserIDlist + ")  ");
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
        public BWJS.Model.Users GetModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Users ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4)
            };
            parameters[0].Value = UserID;


            BWJS.Model.Users model = new BWJS.Model.Users();
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
        public BWJS.Model.Users DataRowToModel(DataRow row)
        {
            BWJS.Model.Users model = new BWJS.Model.Users();

            if (row != null)
            {
                if (row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(row["UserType"].ToString());
                }
                model.GravatarResourceID = row["GravatarResourceID"].ToString();
                model.LastAccessIP = row["LastAccessIP"].ToString();
                model.CompanyName = row["CompanyName"].ToString();
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
                model.CardID = row["CardID"].ToString();
                model.LoginName = row["LoginName"].ToString();
                if (row["ReginId"].ToString() != "")
                {
                    model.ReginId = int.Parse(row["ReginId"].ToString());
                }
                if (row["IsLocked"].ToString() != "")
                {
                    model.IsLocked = int.Parse(row["IsLocked"].ToString());
                }
                if (row["IsLogined"].ToString() != "")
                {
                    model.IsLogined = int.Parse(row["IsLogined"].ToString());
                }
                if (row["LoginTimes"].ToString() != "")
                {
                    model.LoginTimes = int.Parse(row["LoginTimes"].ToString());
                }
                if (row["ProvinceID"].ToString() != "")
                {
                    model.ProvinceID = int.Parse(row["ProvinceID"].ToString());
                }
                if (row["CityID"].ToString() != "")
                {
                    model.CityID = int.Parse(row["CityID"].ToString());
                }
                if (row["CountyID"].ToString() != "")
                {
                    model.CountyID = int.Parse(row["CountyID"].ToString());
                }
                model.Address = row["Address"].ToString();
                model.Password = row["Password"].ToString();
                model.UserName = row["UserName"].ToString();
                model.Sex = row["Sex"].ToString();
                model.Phone = row["Phone"].ToString();
                model.QQ = row["QQ"].ToString();
                model.Wechat = row["Wechat"].ToString();
                model.Email = row["Email"].ToString();
                if (row["DepartmentID"].ToString() != "")
                {
                    model.DepartmentID = int.Parse(row["DepartmentID"].ToString());
                }
                if (row["SId"].ToString() != "")
                {
                    model.SId = row["SId"].ToString();
                }
                
                MachineDAL dalMachine = new MachineDAL();
                Machine modelMachine = dalMachine.GetModelByUserId(model.UserID);
                model.EquipmentNo = ((modelMachine == null) ? (string.Empty) : (modelMachine.MachineID.ToString()));

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
            strSql.Append(" FROM Users ");
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
            strSql.Append(" FROM Users ");
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
            tablesql.Append(" FROM Users ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion

        #region ExtensionMethod
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public Users AdminLogin(string AdminName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Users where RecordIsDelete=0 and LoginName=@LoginName");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", AdminName)
            };
            Users model = new Users();
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetListName(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" SELECT  u.*,
        (ca.name + ca1.Name + ca2.Name+u.Address) AS CityData,d.DepartmentName  FROM  dbo.Users u
LEFT JOIN dbo.CityArea ca ON u.ProvinceID = ca.ID
LEFT JOIN dbo.CityArea ca1 ON u.CityID = ca1.ID
LEFT JOIN dbo.CityArea ca2 ON u.CountyID = ca2.ID
LEFT JOIN [DepartmentInfo] d ON  u.DepartmentID=d.DepartmentID  AND d.RecordIsDelete=0");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// datarow转成对象实体
        /// </summary>
        public UsersBackups DataRowBackupsToModel(DataRow row)
        {
            UsersBackups model = new UsersBackups();

            if (row != null)
            {
                if (row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(row["UserType"].ToString());
                }
                model.GravatarResourceID = row["GravatarResourceID"].ToString();
                if (row["CityID"].ToString() != "")
                {
                    model.CityID = int.Parse(row["CityID"].ToString());
                }
                model.LastAccessIP = row["LastAccessIP"].ToString();
                model.CompanyName = row["CompanyName"].ToString();
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
                model.LoginName = row["LoginName"].ToString();
                model.CardID = row["CardID"].ToString();
                if (row["ReginId"].ToString() != "")
                {
                    model.ReginId = int.Parse(row["ReginId"].ToString());
                }
                model.Password = row["Password"].ToString();
                model.UserName = row["UserName"].ToString();
                model.Sex = row["Sex"].ToString();
                model.Phone = row["Phone"].ToString();
                model.QQ = row["QQ"].ToString();
                model.Wechat = row["Wechat"].ToString();
                model.Email = row["Email"].ToString();
                if (row["ProvinceID"].ToString() != "")
                {
                    model.ProvinceID = int.Parse(row["ProvinceID"].ToString());
                }
                if (row["CountyID"].ToString() != "")
                {
                    model.CountyID = int.Parse(row["CountyID"].ToString());
                }
                model.CityData = row["CityData"].ToString();
                model.DepartmentName = row["DepartmentName"].ToString();
                if (row["DepartmentID"].ToString() != "")
                {
                    model.DepartmentID = int.Parse(row["DepartmentID"].ToString());
                }


                return model;
            }
            else
            {
                return null;
            }
        }



        public int VerificationIsManager(string LoginName, string Password)
        {
            int result = -1;
            try
            {
                string sql = "select  top 1 isnull(UserType,0)  from  Users where LoginName=@LoginName  and  Password=@Password AND  RecordIsDelete=0";
                IEnumerable<SqlParameter> parameters = new SqlParameter[] {
                                                           new SqlParameter ("@LoginName",LoginName),
                                                            new SqlParameter ("@Password",Password)
                                                                            };
                result = SqlDataUtilityHelper.ExecuteScalar(this.ConnectionString, sql.ToString(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public int VerificationIsUserName(string LoginName)
        {
            int result = -1;
            try
            {
                string sql = "select  top 1 isnull(UserType,0)  from  Users where LoginName=@LoginName AND  RecordIsDelete=0";
                IEnumerable<SqlParameter> parameters = new SqlParameter[] {
                                                           new SqlParameter ("@LoginName",LoginName)
                                                                            };
                result = SqlDataUtilityHelper.ExecuteScalar(this.ConnectionString, sql.ToString(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public int VerificationPassword(string LoginName, string Password, string CardID)
        {
            int result = -1;
            try
            {
                string sql = "select  top 1 isnull(UserID,0)  from  Users where LoginName=@LoginName  AND  RecordIsDelete=0";
                IEnumerable<SqlParameter> parameters = new SqlParameter[] {
                                                           new SqlParameter ("@LoginName",LoginName)
                                                                            };
                result = SqlDataUtilityHelper.ExecuteScalar(this.ConnectionString, sql.ToString(), parameters);
                if (result > 0)
                {
                    string sql2 = "select  top 1 isnull(UserID,0)  from  Users where LoginName=@LoginName  and  Password=@Password  AND  RecordIsDelete=0";
                    IEnumerable<SqlParameter> parameters2 = new SqlParameter[] {
                                                           new SqlParameter ("@LoginName",LoginName),
                                                            new SqlParameter ("@Password",Password)
                                                                            };
                    result = SqlDataUtilityHelper.ExecuteScalar(this.ConnectionString, sql2.ToString(), parameters2);
                    if (result > 0)
                    {
                        string sql3 = "select  top 1 isnull(UserID,0)  from  Users where LoginName=@LoginName  and  Password=@Password  and CardID=@CardID  AND  RecordIsDelete=0";
                        IEnumerable<SqlParameter> parameters3 = new SqlParameter[] {
                                                           new SqlParameter ("@LoginName",LoginName),
                                                             new SqlParameter ("@CardID",CardID),
                                                            new SqlParameter ("@Password",Password)
                                                                            };
                        result = SqlDataUtilityHelper.ExecuteScalar(this.ConnectionString, sql3.ToString(), parameters3);
                        if (result > 0)
                        {

                        }
                        else {
                            result = -3;
                        }
                    }
                    else {
                        result = -2;
                    }
                }
                else {
                    result = -1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        #endregion

        public DataSet GetNameList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT u.*,d.ParentID,d.DepartmentName FROM dbo.Users u  LEFT JOIN [DepartmentInfo] d ON u.DepartmentID=d.DepartmentID AND d.RecordIsDelete=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateDepartmentID(BWJS.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append(" DepartmentID = @DepartmentID , ");
            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");
            strSql.Append(" RecordIsDelete = @RecordIsDelete , ");
            strSql.Append(" RecordUpdateTime = @RecordUpdateTime  ");
            strSql.Append(" where UserID=@UserID;");
            strSql.Append(@" UPDATE MofangDB.dbo.OrderApply SET DepartmentID = @DepartmentID  WHERE ((DepartmentID = NULL) or (DepartmentID=0)) AND UserID = @UserID  AND RecordIsDelete = 0 ;  ");
            SqlParameter[] parameters = {
                        new SqlParameter("@UserID",model.UserID) ,
                        new SqlParameter("@DepartmentID",model.DepartmentID) ,
                        new SqlParameter("@RecordUpdateUserID",model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete",model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime",model.RecordUpdateTime)
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
        public DataTable GetNameList(string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            StringBuilder tablesql = new StringBuilder();
            tablesql.Append(@"SELECT  u.*,
        (ISNULL(ca.name,'') + ISNULL(ca1.Name,'') + ISNULL(ca2.Name,'')+ISNULL(u.Address,'')) AS CityData, d.DepartmentName,re.RoleName  FROM  dbo.Users u
LEFT JOIN dbo.CityArea ca ON u.ProvinceID = ca.ID
LEFT JOIN dbo.CityArea ca1 ON u.CityID = ca1.ID
LEFT JOIN dbo.CityArea ca2 ON u.CountyID = ca2.ID
LEFT JOIN[DepartmentInfo] d ON  u.DepartmentID = d.DepartmentID  AND d.RecordIsDelete = 0
LEFT JOIN dbo.UserRole uri ON uri.UserId=u.UserID AND uri.IsDeleted=0
LEFT JOIN dbo.[Role] re ON re.RoleId=uri.RoleId AND re.IsDeleted=0");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }




        public DataTable GetUserRoleTable(string where)
        {
            StringBuilder tablesql = new StringBuilder();
            tablesql.Append(@"SELECT  u.*,
        (ca.name + ca1.Name + ca2.Name+u.Address) AS CityData, d.DepartmentName,re.RoleName,re.RoleId,re.ParentId   FROM  dbo.Users u
LEFT JOIN dbo.CityArea ca ON u.ProvinceID = ca.ID
LEFT JOIN dbo.CityArea ca1 ON u.CityID = ca1.ID
LEFT JOIN dbo.CityArea ca2 ON u.CountyID = ca2.ID
LEFT JOIN[DepartmentInfo] d ON  u.DepartmentID = d.DepartmentID  AND d.RecordIsDelete = 0
LEFT JOIN dbo.UserRole uri ON uri.UserId=u.UserID AND uri.IsDeleted=0
LEFT JOIN dbo.[Role] re ON re.RoleId=uri.RoleId AND re.IsDeleted=0");
            tablesql.Append(" where " + where + "");
            return BWJSHelperSQL.ReturnDataTable(tablesql.ToString());

        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        public bool UserUpdatePwd(string newPwd, string oldPwd, int userId, string PwdKey, out string msg)
        {
            msg = string.Empty;
            #region 判断是否为空

            if (!string.IsNullOrEmpty(newPwd))
            {
                newPwd = newPwd.Trim();
            }
            else
            {
                msg = "新密码不能为空！";
                return false;
            }
            if (!string.IsNullOrEmpty(oldPwd))
            {
                oldPwd = oldPwd.Trim();
            }
            else
            {
                msg = "旧密码不能为空！";
                return false;
            }
            int length = Utils.GetStringLength(newPwd);
            if (length < 6)
            {
                msg = "新密码长度不能少于6个字符！";
                return false;
            }
            #endregion
            Users usersModel = GetModel(userId);
            oldPwd = DESEncrypt.Encrypt(PwdKey, oldPwd);//旧密码加密
            newPwd = DESEncrypt.Encrypt(PwdKey, newPwd);//新密码加密
            if (usersModel != null)
            {
                if (usersModel.Password != oldPwd)
                {
                    msg = "旧密码输入错误！";
                    return false;
                }
                else if (usersModel.Password == newPwd)
                {
                    msg = "旧密码不能和新密码相同！";
                    return false;
                }
                else
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update Users set ");
                        strSql.Append(" Password = @newPwd  ");
                        strSql.Append(" where  UserID=@UserID and Password=@oldPwd;");
                        SqlParameter[] parameters = {
                                    new SqlParameter("@oldPwd",oldPwd) ,
                                    new SqlParameter("@newPwd",newPwd) ,
                                    new SqlParameter("@UserID",userId)
                        };
                        int rows = BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                        if (rows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            msg = "系统繁忙，请稍后再试...";
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogBLL.WriteExceptionLogToDB("USersDAL类，方法名UserUpdatePwd---修改密码异常信息：" + ex.ToString());
                    }
                }
            }
            else
            {
                msg = "非法进入！";
            }
            if (!string.IsNullOrEmpty(msg))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Users GetModelBySId(int sId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Users ");
            strSql.Append(" where SId=@sId and RecordIsDelete=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@sId", SqlDbType.Int,4)
            };
            parameters[0].Value = sId;
            BWJS.Model.Users model = new BWJS.Model.Users();
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
    }
}

