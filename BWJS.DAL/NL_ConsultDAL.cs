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
    /// 网贷申请
    /// </summary>
    public partial class NL_ConsultDAL
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.NL_Consult model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[NL_Consult](");
            strSql.Append("Status,StatusRemark,ProvinceId,CityId,DistrictId,Area,Address,Email,CreateDate,Sign,CompanyId,OrderNo,QueryCode,IdentitySuccess,MobileOperatorSuccess,AlipaySuccess,TaobaoSuccess,JdSuccess,PbocSuccess,RbjSuccess,GjjSuccess,FullName,ChsiSuccess,EmailSuccess,OtherSuccess,IMEI,MemberId,CustomerId,Token,Mark,UserPassword,InviteCode,Mobile,RegisterIP,SmsCode,FontId,BankId,FaceNo,IDNo,LoanAmount,LoanTerm,LoanUse,LoanRate");
            strSql.Append(") values (");
            strSql.Append("@Status,@StatusRemark,@ProvinceId,@CityId,@DistrictId,@Area,@Address,@Email,@CreateDate,@Sign,@CompanyId,@OrderNo,@QueryCode,@IdentitySuccess,@MobileOperatorSuccess,@AlipaySuccess,@TaobaoSuccess,@JdSuccess,@PbocSuccess,@RbjSuccess,@GjjSuccess,@FullName,@ChsiSuccess,@EmailSuccess,@OtherSuccess,@IMEI,@MemberId,@CustomerId,@Token,@Mark,@UserPassword,@InviteCode,@Mobile,@RegisterIP,@SmsCode,@FontId,@BankId,@FaceNo,@IDNo,@LoanAmount,@LoanTerm,@LoanUse,@LoanRate");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@Status", model.Status) ,
                        new SqlParameter("@StatusRemark", model.StatusRemark) ,
                        new SqlParameter("@ProvinceId", model.ProvinceId) ,
                        new SqlParameter("@CityId", model.CityId) ,
                        new SqlParameter("@DistrictId", model.DistrictId) ,
                        new SqlParameter("@Area", model.Area) ,
                        new SqlParameter("@Address", model.Address) ,
                        new SqlParameter("@Email", model.Email) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@Sign", model.Sign) ,
                        new SqlParameter("@CompanyId", model.CompanyId) ,
                        new SqlParameter("@OrderNo", model.OrderNo) ,
                        new SqlParameter("@QueryCode", model.QueryCode) ,
                        new SqlParameter("@IdentitySuccess", model.IdentitySuccess) ,
                        new SqlParameter("@MobileOperatorSuccess", model.MobileOperatorSuccess) ,
                        new SqlParameter("@AlipaySuccess", model.AlipaySuccess) ,
                        new SqlParameter("@TaobaoSuccess", model.TaobaoSuccess) ,
                        new SqlParameter("@JdSuccess", model.JdSuccess) ,
                        new SqlParameter("@PbocSuccess", model.PbocSuccess) ,
                        new SqlParameter("@RbjSuccess", model.RbjSuccess) ,
                        new SqlParameter("@GjjSuccess", model.GjjSuccess) ,
                        new SqlParameter("@FullName", model.FullName) ,
                        new SqlParameter("@ChsiSuccess", model.ChsiSuccess) ,
                        new SqlParameter("@EmailSuccess", model.EmailSuccess) ,
                        new SqlParameter("@OtherSuccess", model.OtherSuccess) ,
                        new SqlParameter("@IMEI", model.IMEI) ,
                        new SqlParameter("@MemberId", model.MemberId) ,
                        new SqlParameter("@CustomerId", model.CustomerId) ,
                        new SqlParameter("@Token", model.Token) ,
                        new SqlParameter("@Mark", model.Mark) ,
                        new SqlParameter("@UserPassword", model.UserPassword) ,
                        new SqlParameter("@InviteCode", model.InviteCode) ,
                        new SqlParameter("@Mobile", model.Mobile) ,
                        new SqlParameter("@RegisterIP", model.RegisterIP) ,
                        new SqlParameter("@SmsCode", model.SmsCode) ,
                        new SqlParameter("@FontId", model.FontId) ,
                        new SqlParameter("@BankId", model.BankId) ,
                        new SqlParameter("@FaceNo", model.FaceNo) ,
                        new SqlParameter("@IDNo", model.IDNo) ,
                        new SqlParameter("@LoanAmount", model.LoanAmount) ,
                        new SqlParameter("@LoanTerm", model.LoanTerm) ,
                        new SqlParameter("@LoanUse", model.LoanUse) ,
                        new SqlParameter("@LoanRate", model.LoanRate)

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
        public bool Update(BWJS.Model.NL_Consult model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NL_Consult] set ");

            strSql.Append(" Status = @Status , ");
            strSql.Append(" StatusRemark = @StatusRemark , ");
            strSql.Append(" ProvinceId = @ProvinceId , ");
            strSql.Append(" CityId = @CityId , ");
            strSql.Append(" DistrictId = @DistrictId , ");
            strSql.Append(" Area = @Area , ");
            strSql.Append(" Address = @Address , ");
            strSql.Append(" Email = @Email , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" Sign = @Sign , ");
            strSql.Append(" CompanyId = @CompanyId , ");
            strSql.Append(" OrderNo = @OrderNo , ");
            strSql.Append(" QueryCode = @QueryCode , ");
            strSql.Append(" IdentitySuccess = @IdentitySuccess , ");
            strSql.Append(" MobileOperatorSuccess = @MobileOperatorSuccess , ");
            strSql.Append(" AlipaySuccess = @AlipaySuccess , ");
            strSql.Append(" TaobaoSuccess = @TaobaoSuccess , ");
            strSql.Append(" JdSuccess = @JdSuccess , ");
            strSql.Append(" PbocSuccess = @PbocSuccess , ");
            strSql.Append(" RbjSuccess = @RbjSuccess , ");
            strSql.Append(" GjjSuccess = @GjjSuccess , ");
            strSql.Append(" FullName = @FullName , ");
            strSql.Append(" ChsiSuccess = @ChsiSuccess , ");
            strSql.Append(" EmailSuccess = @EmailSuccess , ");
            strSql.Append(" OtherSuccess = @OtherSuccess , ");
            strSql.Append(" IMEI = @IMEI , ");
            strSql.Append(" MemberId = @MemberId , ");
            strSql.Append(" CustomerId = @CustomerId , ");
            strSql.Append(" Token = @Token , ");
            strSql.Append(" Mark = @Mark , ");
            strSql.Append(" UserPassword = @UserPassword , ");
            strSql.Append(" InviteCode = @InviteCode , ");
            strSql.Append(" Mobile = @Mobile , ");
            strSql.Append(" RegisterIP = @RegisterIP , ");
            strSql.Append(" SmsCode = @SmsCode , ");
            strSql.Append(" FontId = @FontId , ");
            strSql.Append(" BankId = @BankId , ");
            strSql.Append(" FaceNo = @FaceNo , ");
            strSql.Append(" IDNo = @IDNo , ");
            strSql.Append(" LoanAmount = @LoanAmount , ");
            strSql.Append(" LoanTerm = @LoanTerm , ");
            strSql.Append(" LoanUse = @LoanUse , ");
            strSql.Append(" LoanRate = @LoanRate  ");
            strSql.Append(" where ConsultId=@ConsultId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ConsultId",model.ConsultId) ,
                        new SqlParameter("@Status",model.Status) ,
                        new SqlParameter("@StatusRemark",model.StatusRemark) ,
                        new SqlParameter("@ProvinceId",model.ProvinceId) ,
                        new SqlParameter("@CityId",model.CityId) ,
                        new SqlParameter("@DistrictId",model.DistrictId) ,
                        new SqlParameter("@Area",model.Area) ,
                        new SqlParameter("@Address",model.Address) ,
                        new SqlParameter("@Email",model.Email) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@Sign",model.Sign) ,
                        new SqlParameter("@CompanyId",model.CompanyId) ,
                        new SqlParameter("@OrderNo",model.OrderNo) ,
                        new SqlParameter("@QueryCode",model.QueryCode) ,
                        new SqlParameter("@IdentitySuccess",model.IdentitySuccess) ,
                        new SqlParameter("@MobileOperatorSuccess",model.MobileOperatorSuccess) ,
                        new SqlParameter("@AlipaySuccess",model.AlipaySuccess) ,
                        new SqlParameter("@TaobaoSuccess",model.TaobaoSuccess) ,
                        new SqlParameter("@JdSuccess",model.JdSuccess) ,
                        new SqlParameter("@PbocSuccess",model.PbocSuccess) ,
                        new SqlParameter("@RbjSuccess",model.RbjSuccess) ,
                        new SqlParameter("@GjjSuccess",model.GjjSuccess) ,
                        new SqlParameter("@FullName",model.FullName) ,
                        new SqlParameter("@ChsiSuccess",model.ChsiSuccess) ,
                        new SqlParameter("@EmailSuccess",model.EmailSuccess) ,
                        new SqlParameter("@OtherSuccess",model.OtherSuccess) ,
                        new SqlParameter("@IMEI",model.IMEI) ,
                        new SqlParameter("@MemberId",model.MemberId) ,
                        new SqlParameter("@CustomerId",model.CustomerId) ,
                        new SqlParameter("@Token",model.Token) ,
                        new SqlParameter("@Mark",model.Mark) ,
                        new SqlParameter("@UserPassword",model.UserPassword) ,
                        new SqlParameter("@InviteCode",model.InviteCode) ,
                        new SqlParameter("@Mobile",model.Mobile) ,
                        new SqlParameter("@RegisterIP",model.RegisterIP) ,
                        new SqlParameter("@SmsCode",model.SmsCode) ,
                        new SqlParameter("@FontId",model.FontId) ,
                        new SqlParameter("@BankId",model.BankId) ,
                        new SqlParameter("@FaceNo",model.FaceNo) ,
                        new SqlParameter("@IDNo",model.IDNo) ,
                        new SqlParameter("@LoanAmount",model.LoanAmount) ,
                        new SqlParameter("@LoanTerm",model.LoanTerm) ,
                        new SqlParameter("@LoanUse",model.LoanUse) ,
                        new SqlParameter("@LoanRate",model.LoanRate)

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
        public BWJS.Model.NL_Consult GetModel(int ConsultId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ConsultId, Status, StatusRemark, ProvinceId, CityId, DistrictId, Area, Address, Email, CreateDate, Sign, CompanyId, OrderNo, QueryCode, IdentitySuccess, MobileOperatorSuccess, AlipaySuccess, TaobaoSuccess, JdSuccess, PbocSuccess, RbjSuccess, GjjSuccess, FullName, ChsiSuccess, EmailSuccess, OtherSuccess, IMEI, MemberId, CustomerId, Token, Mark, UserPassword, InviteCode, Mobile, RegisterIP, SmsCode, FontId, BankId, FaceNo, IDNo, LoanAmount, LoanTerm, LoanUse, LoanRate  ");
            strSql.Append("  from dbo.[NL_Consult] ");
            strSql.Append(" where ConsultId=@ConsultId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ConsultId", SqlDbType.Int,4)
            };
            parameters[0].Value = ConsultId;


            BWJS.Model.NL_Consult model = new BWJS.Model.NL_Consult();
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
        public BWJS.Model.NL_Consult DataRowToModel(DataRow row)
        {
            BWJS.Model.NL_Consult model = new BWJS.Model.NL_Consult();

            if (row != null)
            {
                if (row["ConsultId"].ToString() != "")
                {
                    model.ConsultId = int.Parse(row["ConsultId"].ToString());
                }
                if (row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                model.StatusRemark = row["StatusRemark"].ToString();
                if (row["ProvinceId"].ToString() != "")
                {
                    model.ProvinceId = int.Parse(row["ProvinceId"].ToString());
                }
                if (row["CityId"].ToString() != "")
                {
                    model.CityId = int.Parse(row["CityId"].ToString());
                }
                if (row["DistrictId"].ToString() != "")
                {
                    model.DistrictId = int.Parse(row["DistrictId"].ToString());
                }
                model.Area = row["Area"].ToString();
                model.Address = row["Address"].ToString();
                model.Email = row["Email"].ToString();
                if (row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                model.Sign = row["Sign"].ToString();
                if (row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                }
                model.OrderNo = row["OrderNo"].ToString();
                model.QueryCode = row["QueryCode"].ToString();
                if (row["IdentitySuccess"].ToString() != "")
                {
                    if ((row["IdentitySuccess"].ToString() == "1") || (row["IdentitySuccess"].ToString().ToLower() == "true"))
                    {
                        model.IdentitySuccess = true;
                    }
                    else
                    {
                        model.IdentitySuccess = false;
                    }
                }
                if (row["MobileOperatorSuccess"].ToString() != "")
                {
                    if ((row["MobileOperatorSuccess"].ToString() == "1") || (row["MobileOperatorSuccess"].ToString().ToLower() == "true"))
                    {
                        model.MobileOperatorSuccess = true;
                    }
                    else
                    {
                        model.MobileOperatorSuccess = false;
                    }
                }
                if (row["AlipaySuccess"].ToString() != "")
                {
                    if ((row["AlipaySuccess"].ToString() == "1") || (row["AlipaySuccess"].ToString().ToLower() == "true"))
                    {
                        model.AlipaySuccess = true;
                    }
                    else
                    {
                        model.AlipaySuccess = false;
                    }
                }
                if (row["TaobaoSuccess"].ToString() != "")
                {
                    if ((row["TaobaoSuccess"].ToString() == "1") || (row["TaobaoSuccess"].ToString().ToLower() == "true"))
                    {
                        model.TaobaoSuccess = true;
                    }
                    else
                    {
                        model.TaobaoSuccess = false;
                    }
                }
                if (row["JdSuccess"].ToString() != "")
                {
                    if ((row["JdSuccess"].ToString() == "1") || (row["JdSuccess"].ToString().ToLower() == "true"))
                    {
                        model.JdSuccess = true;
                    }
                    else
                    {
                        model.JdSuccess = false;
                    }
                }
                if (row["PbocSuccess"].ToString() != "")
                {
                    if ((row["PbocSuccess"].ToString() == "1") || (row["PbocSuccess"].ToString().ToLower() == "true"))
                    {
                        model.PbocSuccess = true;
                    }
                    else
                    {
                        model.PbocSuccess = false;
                    }
                }
                if (row["RbjSuccess"].ToString() != "")
                {
                    if ((row["RbjSuccess"].ToString() == "1") || (row["RbjSuccess"].ToString().ToLower() == "true"))
                    {
                        model.RbjSuccess = true;
                    }
                    else
                    {
                        model.RbjSuccess = false;
                    }
                }
                if (row["GjjSuccess"].ToString() != "")
                {
                    if ((row["GjjSuccess"].ToString() == "1") || (row["GjjSuccess"].ToString().ToLower() == "true"))
                    {
                        model.GjjSuccess = true;
                    }
                    else
                    {
                        model.GjjSuccess = false;
                    }
                }
                model.FullName = row["FullName"].ToString();
                if (row["ChsiSuccess"].ToString() != "")
                {
                    if ((row["ChsiSuccess"].ToString() == "1") || (row["ChsiSuccess"].ToString().ToLower() == "true"))
                    {
                        model.ChsiSuccess = true;
                    }
                    else
                    {
                        model.ChsiSuccess = false;
                    }
                }
                if (row["EmailSuccess"].ToString() != "")
                {
                    if ((row["EmailSuccess"].ToString() == "1") || (row["EmailSuccess"].ToString().ToLower() == "true"))
                    {
                        model.EmailSuccess = true;
                    }
                    else
                    {
                        model.EmailSuccess = false;
                    }
                }
                if (row["OtherSuccess"].ToString() != "")
                {
                    if ((row["OtherSuccess"].ToString() == "1") || (row["OtherSuccess"].ToString().ToLower() == "true"))
                    {
                        model.OtherSuccess = true;
                    }
                    else
                    {
                        model.OtherSuccess = false;
                    }
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
                model.UserPassword = row["UserPassword"].ToString();
                model.InviteCode = row["InviteCode"].ToString();
                model.Mobile = row["Mobile"].ToString();
                model.RegisterIP = row["RegisterIP"].ToString();
                model.SmsCode = row["SmsCode"].ToString();
                model.FontId = row["FontId"].ToString();
                model.BankId = row["BankId"].ToString();
                model.FaceNo = row["FaceNo"].ToString();
                model.IDNo = row["IDNo"].ToString();
                if (row["LoanAmount"].ToString() != "")
                {
                    model.LoanAmount = decimal.Parse(row["LoanAmount"].ToString());
                }
                if (row["LoanTerm"].ToString() != "")
                {
                    model.LoanTerm = int.Parse(row["LoanTerm"].ToString());
                }
                model.LoanUse = row["LoanUse"].ToString();
                if (row["LoanRate"].ToString() != "")
                {
                    model.LoanRate = decimal.Parse(row["LoanRate"].ToString());
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
            strSql.Append(" FROM dbo.[NL_Consult] ");
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
            strSql.Append(" FROM dbo.[NL_Consult] ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ConsultId, int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NL_Consult] set IsDeleted=1,EditId=@EditId,EditDate=@EditDate");
            strSql.Append(" where ConsultId=@ConsultId");
            SqlParameter[] parameters = {
                    new SqlParameter("@EditId", userId),
                    new SqlParameter("@EditDate", DateTime.Now),
                    new SqlParameter("@ConsultId", ConsultId),
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
        public bool DeleteList(string ConsultIdlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.[NL_Consult] set IsDeleted=1,EditId={0},EditDate='{1}'", userId, DateTime.Now);
            strSql.Append(" where ConsultId in (" + ConsultIdlist + ")  ");
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
            tablesql.Append(" FROM dbo.[NL_Consult] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetConsultId(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 mlc.ConsultId FROM [dbo].[NL_Consult] mlc INNER JOIN [dbo].[NL_ProfessionInfo] nlp ON mlc.ConsultId=nlp.ConsultId  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Update(int consultId, int status)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NL_Consult] set Status=@Status");
            strSql.Append(" where ConsultId=ConsultId");
            SqlParameter[] parameters = {
                    new SqlParameter("@Status", status),
                    new SqlParameter("@ConsultId", consultId)
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

        #endregion

    }
}