using UtilityHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBWN.DAL
{
    /// <summary>
    /// 信博维诺用户表
    /// </summary>
    public partial class xbwn_UsersDAL
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(XBWN.Model.xbwn_Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[xbwn_Users](");
            strSql.Append("UserPassword,InviteCode,RegisterIP,SmsCode,FontId,BankId,FaceNo,Success,Mark,IsDeleted,NetLoanApplyId,CreateId,CreateDate,EditId,EditDate,IMEI,MemberId,CustomerId,Token,RealName,IdNo,TelNo");
            strSql.Append(") values (");
            strSql.Append("@UserPassword,@InviteCode,@RegisterIP,@SmsCode,@FontId,@BankId,@FaceNo,@Success,@Mark,@IsDeleted,@NetLoanApplyId,@CreateId,@CreateDate,@EditId,@EditDate,@IMEI,@MemberId,@CustomerId,@Token,@RealName,@IdNo,@TelNo");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@UserPassword", model.UserPassword) ,
                        new SqlParameter("@InviteCode", model.InviteCode) ,
                        new SqlParameter("@RegisterIP", model.RegisterIP) ,
                        new SqlParameter("@SmsCode", model.SmsCode) ,
                        new SqlParameter("@FontId", model.FontId) ,
                        new SqlParameter("@BankId", model.BankId) ,
                        new SqlParameter("@FaceNo", model.FaceNo) ,
                        new SqlParameter("@Success", model.Success) ,
                        new SqlParameter("@Mark", model.Mark) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@NetLoanApplyId", model.NetLoanApplyId) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@IMEI", model.IMEI) ,
                        new SqlParameter("@MemberId", model.MemberId) ,
                        new SqlParameter("@CustomerId", model.CustomerId) ,
                        new SqlParameter("@Token", model.Token) ,
                        new SqlParameter("@RealName", model.RealName) ,
                        new SqlParameter("@IdNo", model.IdNo) ,
                        new SqlParameter("@TelNo", model.TelNo)

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
        public bool Update(XBWN.Model.xbwn_Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[xbwn_Users] set ");

            strSql.Append(" UserPassword = @UserPassword , ");
            strSql.Append(" InviteCode = @InviteCode , ");
            strSql.Append(" RegisterIP = @RegisterIP , ");
            strSql.Append(" SmsCode = @SmsCode , ");
            strSql.Append(" FontId = @FontId , ");
            strSql.Append(" BankId = @BankId , ");
            strSql.Append(" FaceNo = @FaceNo , ");
            strSql.Append(" Success = @Success , ");
            strSql.Append(" Mark = @Mark , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" NetLoanApplyId = @NetLoanApplyId , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" IMEI = @IMEI , ");
            strSql.Append(" MemberId = @MemberId , ");
            strSql.Append(" CustomerId = @CustomerId , ");
            strSql.Append(" Token = @Token , ");
            strSql.Append(" RealName = @RealName , ");
            strSql.Append(" IdNo = @IdNo , ");
            strSql.Append(" TelNo = @TelNo  ");
            strSql.Append(" where UserId=@UserId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@UserId",model.UserId) ,
                        new SqlParameter("@UserPassword",model.UserPassword) ,
                        new SqlParameter("@InviteCode",model.InviteCode) ,
                        new SqlParameter("@RegisterIP",model.RegisterIP) ,
                        new SqlParameter("@SmsCode",model.SmsCode) ,
                        new SqlParameter("@FontId",model.FontId) ,
                        new SqlParameter("@BankId",model.BankId) ,
                        new SqlParameter("@FaceNo",model.FaceNo) ,
                        new SqlParameter("@Success",model.Success) ,
                        new SqlParameter("@Mark",model.Mark) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@NetLoanApplyId",model.NetLoanApplyId) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@IMEI",model.IMEI) ,
                        new SqlParameter("@MemberId",model.MemberId) ,
                        new SqlParameter("@CustomerId",model.CustomerId) ,
                        new SqlParameter("@Token",model.Token) ,
                        new SqlParameter("@RealName",model.RealName) ,
                        new SqlParameter("@IdNo",model.IdNo) ,
                        new SqlParameter("@TelNo",model.TelNo)

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
        public XBWN.Model.xbwn_Users GetModel(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from dbo.[xbwn_Users] ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = UserId;


            XBWN.Model.xbwn_Users model = new XBWN.Model.xbwn_Users();
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
        public XBWN.Model.xbwn_Users DataRowToModel(DataRow row)
        {
            XBWN.Model.xbwn_Users model = new XBWN.Model.xbwn_Users();

            if (row != null)
            {
                if (row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                model.UserPassword = row["UserPassword"].ToString();
                model.InviteCode = row["InviteCode"].ToString();
                model.RegisterIP = row["RegisterIP"].ToString();
                model.SmsCode = row["SmsCode"].ToString();
                model.FontId = row["FontId"].ToString();
                model.BankId = row["BankId"].ToString();
                model.FaceNo = row["FaceNo"].ToString();
                if (row["Success"].ToString() != "")
                {
                    if ((row["Success"].ToString() == "1") || (row["Success"].ToString().ToLower() == "true"))
                    {
                        model.Success = true;
                    }
                    else
                    {
                        model.Success = false;
                    }
                }
                if (row["Mark"].ToString() != "")
                {
                    if ((row["Mark"].ToString() == "1") || (row["Mark"].ToString().ToLower() == "true"))
                    {
                        model.Mark = true;
                    }
                    else
                    {
                        model.Mark = false;
                    }
                }
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                if (row["NetLoanApplyId"].ToString() != "")
                {
                    model.NetLoanApplyId = int.Parse(row["NetLoanApplyId"].ToString());
                }
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
                model.IMEI = row["IMEI"].ToString();
                if (row["MemberId"].ToString() != "")
                {
                    model.MemberId = int.Parse(row["MemberId"].ToString());
                }
                if (row["CustomerId"].ToString() != "")
                {
                    model.CustomerId = int.Parse(row["CustomerId"].ToString());
                }
                model.Token = row["Token"].ToString();
                model.RealName = row["RealName"].ToString();
                model.IdNo = row["IdNo"].ToString();
                model.TelNo = row["TelNo"].ToString();

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
            strSql.Append(" FROM dbo.[xbwn_Users] ");
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
            strSql.Append(" FROM dbo.[xbwn_Users] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XBWN.Model.xbwn_Users GetModelByNetLoanApplyId(int netLoanApplyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from dbo.[xbwn_Users] ");
            strSql.Append(" where NetLoanApplyId=@NetLoanApplyId");
            SqlParameter[] parameters = {
                    new SqlParameter("@NetLoanApplyId", netLoanApplyId)
            };

            XBWN.Model.xbwn_Users model = new XBWN.Model.xbwn_Users();
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
        /// 得到一个对象实体
        /// </summary>
        public XBWN.Model.xbwn_Users GetModel(int memberId,int customerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from dbo.[xbwn_Users] ");
            strSql.Append(" where MemberId=@MemberId and CustomerId=@CustomerId");
            SqlParameter[] parameters = {
                    new SqlParameter("@MemberId", memberId),
                    new SqlParameter("@CustomerId", customerId)
            };

            XBWN.Model.xbwn_Users model = new XBWN.Model.xbwn_Users();
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserId, int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[xbwn_Users] set IsDeleted=1,EditId=@EditId,EditDate=@EditDate");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@EditId", userId),
                    new SqlParameter("@EditDate", DateTime.Now),
                    new SqlParameter("@UserId", UserId),
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string UserIdlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.[xbwn_Users] set IsDeleted=1,EditId={0},EditDate='{1}'", userId, DateTime.Now);
            strSql.Append(" where UserId in (" + UserIdlist + ")  ");
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
            tablesql.Append(" FROM dbo.[xbwn_Users] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion
    }
}
