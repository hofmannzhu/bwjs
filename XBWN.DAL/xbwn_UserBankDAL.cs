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
    /// 信博维诺手机运营商爬取任务
    /// </summary>
    public partial class xbwn_UserBankDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(XBWN.Model.xbwn_UserBank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[xbwn_UserBank](");
            strSql.Append("Flag,IsDeleted,CreateId,CreateDate,EditId,EditDate,NetLoanApplyId,No,RealName,IdNo,BankCardNo,TelNo,Cash,SmsCode");
            strSql.Append(") values (");
            strSql.Append("@Flag,@IsDeleted,@CreateId,@CreateDate,@EditId,@EditDate,@NetLoanApplyId,@No,@RealName,@IdNo,@BankCardNo,@TelNo,@Cash,@SmsCode");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@Flag", model.Flag) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@NetLoanApplyId", model.NetLoanApplyId) ,
                        new SqlParameter("@No", model.No) ,
                        new SqlParameter("@RealName", model.RealName) ,
                        new SqlParameter("@IdNo", model.IdNo) ,
                        new SqlParameter("@BankCardNo", model.BankCardNo) ,
                        new SqlParameter("@TelNo", model.TelNo) ,
                        new SqlParameter("@Cash", model.Cash) ,
                        new SqlParameter("@SmsCode", model.SmsCode)

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
        public bool Update(XBWN.Model.xbwn_UserBank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[xbwn_UserBank] set ");

            strSql.Append(" Flag = @Flag , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" NetLoanApplyId = @NetLoanApplyId , ");
            strSql.Append(" No = @No , ");
            strSql.Append(" RealName = @RealName , ");
            strSql.Append(" IdNo = @IdNo , ");
            strSql.Append(" BankCardNo = @BankCardNo , ");
            strSql.Append(" TelNo = @TelNo , ");
            strSql.Append(" Cash = @Cash , ");
            strSql.Append(" SmsCode = @SmsCode  ");
            strSql.Append(" where UserBankId=@UserBankId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@UserBankId",model.UserBankId) ,
                        new SqlParameter("@Flag",model.Flag) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@NetLoanApplyId",model.NetLoanApplyId) ,
                        new SqlParameter("@No",model.No) ,
                        new SqlParameter("@RealName",model.RealName) ,
                        new SqlParameter("@IdNo",model.IdNo) ,
                        new SqlParameter("@BankCardNo",model.BankCardNo) ,
                        new SqlParameter("@TelNo",model.TelNo) ,
                        new SqlParameter("@Cash",model.Cash) ,
                        new SqlParameter("@SmsCode",model.SmsCode)

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
        public XBWN.Model.xbwn_UserBank GetModel(int UserBankId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserBankId, Flag, IsDeleted, CreateId, CreateDate, EditId, EditDate, NetLoanApplyId, No, RealName, IdNo, BankCardNo, TelNo, Cash, SmsCode  ");
            strSql.Append("  from dbo.[xbwn_UserBank] ");
            strSql.Append(" where UserBankId=@UserBankId");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserBankId", SqlDbType.Int,4)
            };
            parameters[0].Value = UserBankId;


            XBWN.Model.xbwn_UserBank model = new XBWN.Model.xbwn_UserBank();
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
        public XBWN.Model.xbwn_UserBank DataRowToModel(DataRow row)
        {
            XBWN.Model.xbwn_UserBank model = new XBWN.Model.xbwn_UserBank();

            if (row != null)
            {
                if (row["UserBankId"].ToString() != "")
                {
                    model.UserBankId = int.Parse(row["UserBankId"].ToString());
                }
                if (row["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(row["Flag"].ToString());
                }
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
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
                if (row["NetLoanApplyId"].ToString() != "")
                {
                    model.NetLoanApplyId = int.Parse(row["NetLoanApplyId"].ToString());
                }
                model.No = row["No"].ToString();
                model.RealName = row["RealName"].ToString();
                model.IdNo = row["IdNo"].ToString();
                model.BankCardNo = row["BankCardNo"].ToString();
                model.TelNo = row["TelNo"].ToString();
                if (row["Cash"].ToString() != "")
                {
                    model.Cash = int.Parse(row["Cash"].ToString());
                }
                model.SmsCode = row["SmsCode"].ToString();

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
            strSql.Append(" FROM dbo.[xbwn_UserBank] ");
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
            strSql.Append(" FROM dbo.[xbwn_UserBank] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region ExtensionMethod
        public XBWN.Model.xbwn_UserBank GetModel(string realName, string idNo, string telNo, int flag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from dbo.[xbwn_UserBank] ");
            strSql.Append(" where RealName=@RealName and IdNo=@IdNo and TelNo=@TelNo and Flag=@Flag");
            SqlParameter[] parameters = {
                    new SqlParameter("@RealName", realName),
                    new SqlParameter("@IdNo", idNo),
                    new SqlParameter("@TelNo", telNo),
                    new SqlParameter("@Flag", flag)
            };
            
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
        /// 更新一条数据
        /// </summary>
        public bool Update(string smsCode,int flag, string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[xbwn_UserBank] set ");
            strSql.Append(" Flag = @Flag , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" SmsCode = @SmsCode  ");
            strSql.Append(" where No=@No ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Flag",flag),
                        new SqlParameter("@EditDate",DateTime.Now),
                        new SqlParameter("@SmsCode",smsCode),
                        new SqlParameter("@No",no)
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
        public bool Delete(int UserBankId, int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[xbwn_UserBank] set IsDeleted=1,EditId=@EditId,EditDate=@EditDate");
            strSql.Append(" where UserBankId=@UserBankId");
            SqlParameter[] parameters = {
                    new SqlParameter("@EditId", userId),
                    new SqlParameter("@EditDate", DateTime.Now),
                    new SqlParameter("@UserBankId", UserBankId),
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
        public bool DeleteList(string UserBankIdlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.[xbwn_UserBank] set IsDeleted=1,EditId={0},EditDate='{1}'", userId, DateTime.Now);
            strSql.Append(" where UserBankId in (" + UserBankIdlist + ")  ");
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
            tablesql.Append(" FROM dbo.[xbwn_UserBank] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion
    }
}
