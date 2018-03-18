using UtilityHelper;
using UtilityHelper.Data;
using BWJS.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BWJS.DAL
{

    /// <summary>
    /// 用户银行卡
    /// </summary>
    public partial class UserBankDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.UserBank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[UserBank](");
            strSql.Append("Remark,CreateId,CreateDate,EditId,EditDate,IsDeleted,UserId,BankCode,OpeningBank,CardHolder,CardNumber,BankAddress,AlipayAccount,IsDefault");
            strSql.Append(") values (");
            strSql.Append("@Remark,@CreateId,@CreateDate,@EditId,@EditDate,@IsDeleted,@UserId,@BankCode,@OpeningBank,@CardHolder,@CardNumber,@BankAddress,@AlipayAccount,@IsDefault");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@UserId", model.UserId) ,
                        new SqlParameter("@BankCode", model.BankCode) ,
                        new SqlParameter("@OpeningBank", model.OpeningBank) ,
                        new SqlParameter("@CardHolder", model.CardHolder) ,
                        new SqlParameter("@CardNumber", model.CardNumber) ,
                        new SqlParameter("@BankAddress", model.BankAddress) ,
                        new SqlParameter("@AlipayAccount", model.AlipayAccount) ,
                        new SqlParameter("@IsDefault", model.IsDefault)

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
        public bool Update(BWJS.Model.UserBank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[UserBank] set ");

            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" BankCode = @BankCode , ");
            strSql.Append(" OpeningBank = @OpeningBank , ");
            strSql.Append(" CardHolder = @CardHolder , ");
            strSql.Append(" CardNumber = @CardNumber , ");
            strSql.Append(" BankAddress = @BankAddress , ");
            strSql.Append(" AlipayAccount = @AlipayAccount , ");
            strSql.Append(" IsDefault = @IsDefault  ");
            strSql.Append(" where UserBankId=@UserBankId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@UserBankId",model.UserBankId) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@UserId",model.UserId) ,
                        new SqlParameter("@BankCode",model.BankCode) ,
                        new SqlParameter("@OpeningBank",model.OpeningBank) ,
                        new SqlParameter("@CardHolder",model.CardHolder) ,
                        new SqlParameter("@CardNumber",model.CardNumber) ,
                        new SqlParameter("@BankAddress",model.BankAddress) ,
                        new SqlParameter("@AlipayAccount",model.AlipayAccount) ,
                        new SqlParameter("@IsDefault",model.IsDefault)

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
        public BWJS.Model.UserBank GetModel(int UserBankId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from dbo.[UserBank] ");
            strSql.Append(" where UserBankId=@UserBankId");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserBankId", SqlDbType.Int,4)
            };
            parameters[0].Value = UserBankId;


            BWJS.Model.UserBank model = new BWJS.Model.UserBank();
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
        public BWJS.Model.UserBank DataRowToModel(DataRow row)
        {
            BWJS.Model.UserBank model = new BWJS.Model.UserBank();

            if (row != null)
            {
                if (row["UserBankId"].ToString() != "")
                {
                    model.UserBankId = int.Parse(row["UserBankId"].ToString());
                }
                model.Remark = row["Remark"].ToString();
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
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                if (row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                model.BankCode = row["BankCode"].ToString();
                model.OpeningBank = row["OpeningBank"].ToString();
                model.CardHolder = row["CardHolder"].ToString();
                model.CardNumber = row["CardNumber"].ToString();
                model.BankAddress = row["BankAddress"].ToString();
                model.AlipayAccount = row["AlipayAccount"].ToString();
                if (row["IsDefault"].ToString() != "")
                {
                    if ((row["IsDefault"].ToString() == "1") || (row["IsDefault"].ToString().ToLower() == "true"))
                    {
                        model.IsDefault = true;
                    }
                    else
                    {
                        model.IsDefault = false;
                    }
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
            strSql.Append(" FROM dbo.[UserBank] ");
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
            strSql.Append(" FROM dbo.[UserBank] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        #endregion

        #region  ExtensionMethod

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int userBankId, int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserBank set IsDeleted=1,EditId=@EditId,EditDate=@EditDate");
            strSql.Append(" where UserBankId=@UserBankId");
            SqlParameter[] parameters = {
                    new SqlParameter("@EditId", userId),
                    new SqlParameter("@EditDate", DateTime.Now),
                    new SqlParameter("@UserBankId", userBankId),
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
        public bool DeleteList(string userBankIdlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update UserBank set IsDeleted=1,EditId={0},EditDate='{1}'", userId, DateTime.Now);
            strSql.Append(" where UserBankId in (" + userBankIdlist + ")  ");
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
            tablesql.Append("select * from dbo.[UserBank] a ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="userId">商家编号</param>
        /// <param name="cardNumber">银行卡号</param>
        /// <returns></returns>
        public bool ExistsByCardNumber(int userId, string cardNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dbo.[UserBank]");
            strSql.Append(" where IsDeleted=0 and UserId=@UserId and CardNumber=@CardNumber");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", userId),
                    new SqlParameter("@CardNumber", cardNumber)
            };
            return BWJSHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="userBankId">主键</param>
        /// <param name="cardNumber">银行卡号</param>
        /// <returns></returns>
        public bool Exists(int userBankId, string cardNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dbo.[UserBank]");
            strSql.Append(" where IsDeleted=0");
            strSql.Append(" and UserBankId <> @UserBankId");
            strSql.Append(" and CardNumber = @CardNumber");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserBankId", userBankId),
                    new SqlParameter("@CardNumber", cardNumber)
            };

            return BWJSHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="userId">商家编号</param>
        /// <param name="userBankId">主键</param>
        /// <param name="cardNumber">银行卡号</param>
        /// <returns></returns>
        public bool Exists(int userId, int userBankId, string cardNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dbo.[UserBank]");
            strSql.Append(" where IsDeleted=0");
            strSql.Append(" and UserId = @UserId");
            strSql.Append(" and UserBankId <> @UserBankId");
            strSql.Append(" and CardNumber = @CardNumber");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", userId),
                    new SqlParameter("@UserBankId", userBankId),
                    new SqlParameter("@CardNumber", cardNumber)
            };

            return BWJSHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改默认银行卡
        /// </summary>
        public bool SetDefault(int userBankId, int userId, int editId)
        {
            List<String> tsql = new List<String>();
            StringBuilder tableSql = new StringBuilder();
            tableSql.AppendFormat("update UserBank set IsDefault=0,EditId={0},EditDate='{1}' where UserId={2}", editId, DateTime.Now, userId);
            tsql.Add(tableSql.ToString());
            tableSql = new StringBuilder();
            tableSql.AppendFormat("update UserBank set IsDefault=1,EditId={0},EditDate='{1}' where UserBankId={2}", editId, DateTime.Now, userBankId);
            tsql.Add(tableSql.ToString());

            int rows = BWJSHelperSQL.ExecuteSqlTran(tsql);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  ExtensionMethod
    }
}
