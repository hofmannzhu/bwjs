﻿using UtilityHelper;
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
    /// 身份信息
    /// </summary>
    public partial class NL_IdentityInfoDAL
    {

        public bool Exists(int ConsultId)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from dbo.[NL_IdentityInfo]");
            strSql.Append(" where ");
            strSql.Append(" ConsultId=@ConsultId  ");
            SqlParameter[] parameters={
                    new SqlParameter("@ConsultId", SqlDbType.Int,4)          };
            parameters[0].Value=ConsultId;

            return BWJSHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int  Add(BWJS.Model.NL_IdentityInfo model)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into dbo.[NL_IdentityInfo](");
            strSql.Append("ConsultId,FullName,IDNo,MonthlyIncome,CreditHistory,HousingStatus,DrivingLicense,Face,IdentityCardScanner,DebitCard,CreditCard,ParticleLoan,BusinessPolicy,CreditCardAgeLimit,OtherLoan,SesameSeed,TaobaoAccount,Company,UnitNature,WorkingHour,Payroll,JobPosition,SocialSecurit,Fund,Degree,GraduationYear");
            strSql.Append(") values (");
            strSql.Append("@ConsultId,@FullName,@IDNo,@MonthlyIncome,@CreditHistory,@HousingStatus,@DrivingLicense,@Face,@IdentityCardScanner,@DebitCard,@CreditCard,@ParticleLoan,@BusinessPolicy,@CreditCardAgeLimit,@OtherLoan,@SesameSeed,@TaobaoAccount,@Company,@UnitNature,@WorkingHour,@Payroll,@JobPosition,@SocialSecurit,@Fund,@Degree,@GraduationYear");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");

            SqlParameter[] parameters={
                        new SqlParameter("@ConsultId", model.ConsultId) ,
                        new SqlParameter("@FullName", model.FullName) ,
                        new SqlParameter("@IDNo", model.IDNo) ,
                        new SqlParameter("@MonthlyIncome", model.MonthlyIncome) ,
                        new SqlParameter("@CreditHistory", model.CreditHistory) ,
                        new SqlParameter("@HousingStatus", model.HousingStatus) ,
                        new SqlParameter("@DrivingLicense", model.DrivingLicense) ,
                        new SqlParameter("@Face", model.Face) ,
                        new SqlParameter("@IdentityCardScanner", model.IdentityCardScanner) ,
                        new SqlParameter("@DebitCard", model.DebitCard) ,
                        new SqlParameter("@CreditCard", model.CreditCard) ,
                        new SqlParameter("@ParticleLoan", model.ParticleLoan) ,
                        new SqlParameter("@BusinessPolicy", model.BusinessPolicy) ,
                        new SqlParameter("@CreditCardAgeLimit", model.CreditCardAgeLimit) ,
                        new SqlParameter("@OtherLoan", model.OtherLoan) ,
                        new SqlParameter("@SesameSeed", model.SesameSeed) ,
                        new SqlParameter("@TaobaoAccount", model.TaobaoAccount) ,
                        new SqlParameter("@Company", model.Company) ,
                        new SqlParameter("@UnitNature", model.UnitNature) ,
                        new SqlParameter("@WorkingHour", model.WorkingHour) ,
                        new SqlParameter("@Payroll", model.Payroll) ,
                        new SqlParameter("@JobPosition", model.JobPosition) ,
                        new SqlParameter("@SocialSecurit", model.SocialSecurit) ,
                        new SqlParameter("@Fund", model.Fund) ,
                        new SqlParameter("@Degree", model.Degree) ,
                        new SqlParameter("@GraduationYear", model.GraduationYear)

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
        public bool Update(BWJS.Model.NL_IdentityInfo model)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("update dbo.[NL_IdentityInfo] set ");

            strSql.Append(" ConsultId =@ConsultId , ");
            strSql.Append(" FullName=@FullName , ");
            strSql.Append(" IDNo=@IDNo , ");
            strSql.Append(" MonthlyIncome=@MonthlyIncome , ");
            strSql.Append(" CreditHistory=@CreditHistory , ");
            strSql.Append(" HousingStatus=@HousingStatus , ");
            strSql.Append(" DrivingLicense=@DrivingLicense , ");
            strSql.Append(" Face=@Face , ");
            strSql.Append(" IdentityCardScanner=@IdentityCardScanner , ");
            strSql.Append(" DebitCard=@DebitCard , ");
            strSql.Append(" CreditCard=@CreditCard , ");
            strSql.Append(" ParticleLoan=@ParticleLoan , ");
            strSql.Append(" BusinessPolicy=@BusinessPolicy , ");
            strSql.Append(" CreditCardAgeLimit=@CreditCardAgeLimit , ");
            strSql.Append(" OtherLoan=@OtherLoan , ");
            strSql.Append(" SesameSeed=@SesameSeed , ");
            strSql.Append(" TaobaoAccount=@TaobaoAccount , ");
            strSql.Append(" Company=@Company , ");
            strSql.Append(" UnitNature=@UnitNature , ");
            strSql.Append(" WorkingHour=@WorkingHour , ");
            strSql.Append(" Payroll=@Payroll , ");
            strSql.Append(" JobPosition=@JobPosition , ");
            strSql.Append(" SocialSecurit=@SocialSecurit , ");
            strSql.Append(" Fund=@Fund , ");
            strSql.Append(" Degree=@Degree , ");
            strSql.Append(" GraduationYear=@GraduationYear  ");
            strSql.Append(" where ConsultId=@ConsultId  ");

            SqlParameter[] parameters={
                        new SqlParameter("@ConsultId",model.ConsultId) ,
                        new SqlParameter("@FullName",model.FullName) ,
                        new SqlParameter("@IDNo",model.IDNo) ,
                        new SqlParameter("@MonthlyIncome",model.MonthlyIncome) ,
                        new SqlParameter("@CreditHistory",model.CreditHistory) ,
                        new SqlParameter("@HousingStatus",model.HousingStatus) ,
                        new SqlParameter("@DrivingLicense",model.DrivingLicense) ,
                        new SqlParameter("@Face",model.Face) ,
                        new SqlParameter("@IdentityCardScanner",model.IdentityCardScanner) ,
                        new SqlParameter("@DebitCard",model.DebitCard) ,
                        new SqlParameter("@CreditCard",model.CreditCard) ,
                        new SqlParameter("@ParticleLoan",model.ParticleLoan) ,
                        new SqlParameter("@BusinessPolicy",model.BusinessPolicy) ,
                        new SqlParameter("@CreditCardAgeLimit",model.CreditCardAgeLimit) ,
                        new SqlParameter("@OtherLoan",model.OtherLoan) ,
                        new SqlParameter("@SesameSeed",model.SesameSeed) ,
                        new SqlParameter("@TaobaoAccount",model.TaobaoAccount) ,
                        new SqlParameter("@Company",model.Company) ,
                        new SqlParameter("@UnitNature",model.UnitNature) ,
                        new SqlParameter("@WorkingHour",model.WorkingHour) ,
                        new SqlParameter("@Payroll",model.Payroll) ,
                        new SqlParameter("@JobPosition",model.JobPosition) ,
                        new SqlParameter("@SocialSecurit",model.SocialSecurit) ,
                        new SqlParameter("@Fund",model.Fund) ,
                        new SqlParameter("@Degree",model.Degree) ,
                        new SqlParameter("@GraduationYear",model.GraduationYear)

            };

            int rows=BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int ConsultId)
        {

            StringBuilder strSql=new StringBuilder();
            strSql.Append("update dbo.[NL_IdentityInfo] set IsDeleted=1");
            strSql.Append(" where ConsultId=@ConsultId ");
            SqlParameter[] parameters={
                    new SqlParameter("@ConsultId", SqlDbType.Int,4)          };
            parameters[0].Value=ConsultId;


            int rows=BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public BWJS.Model.NL_IdentityInfo GetModel(int ConsultId)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select ConsultId, FullName, IDNo, MonthlyIncome, CreditHistory, HousingStatus, DrivingLicense, Face, IdentityCardScanner, DebitCard, CreditCard, ParticleLoan, BusinessPolicy, CreditCardAgeLimit, OtherLoan, SesameSeed, TaobaoAccount, Company, UnitNature, WorkingHour, Payroll, JobPosition, SocialSecurit, Fund, Degree, GraduationYear  ");
            strSql.Append("  from dbo.[NL_IdentityInfo] ");
            strSql.Append(" where ConsultId=@ConsultId ");
            SqlParameter[] parameters={
                    new SqlParameter("@ConsultId", SqlDbType.Int,4)          };
            parameters[0].Value=ConsultId;


            BWJS.Model.NL_IdentityInfo model=new BWJS.Model.NL_IdentityInfo();
            DataSet ds=BWJSHelperSQL.Query(strSql.ToString(), parameters);

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
        public BWJS.Model.NL_IdentityInfo DataRowToModel(DataRow row)
        {
            BWJS.Model.NL_IdentityInfo model=new BWJS.Model.NL_IdentityInfo();

            if (row != null)
            {
                if (row["ConsultId"].ToString() != "")
                {
                    model.ConsultId=int.Parse(row["ConsultId"].ToString());
                }
                model.FullName=row["FullName"].ToString();
                model.IDNo=row["IDNo"].ToString();
                if (row["MonthlyIncome"].ToString() != "")
                {
                    model.MonthlyIncome=int.Parse(row["MonthlyIncome"].ToString());
                }
                if (row["CreditHistory"].ToString() != "")
                {
                    model.CreditHistory=int.Parse(row["CreditHistory"].ToString());
                }
                if (row["HousingStatus"].ToString() != "")
                {
                    model.HousingStatus=int.Parse(row["HousingStatus"].ToString());
                }
                model.DrivingLicense=row["DrivingLicense"].ToString();
                model.Face=row["Face"].ToString();
                model.IdentityCardScanner=row["IdentityCardScanner"].ToString();
                model.DebitCard=row["DebitCard"].ToString();
                model.CreditCard=row["CreditCard"].ToString();
  
                if (row["ParticleLoan"].ToString() != "")
                {
                    model.ParticleLoan = int.Parse(row["ParticleLoan"].ToString());
                }
                if (row["BusinessPolicy"].ToString() != "")
                {
                    model.BusinessPolicy = int.Parse(row["BusinessPolicy"].ToString());
                }

                if (row["CreditCardAgeLimit"].ToString() != "")
                {
                    model.CreditCardAgeLimit=int.Parse(row["CreditCardAgeLimit"].ToString());
                }
      
                if (row["OtherLoan"].ToString() != "")
                {
                    model.OtherLoan = int.Parse(row["OtherLoan"].ToString());
                }
                if (row["SesameSeed"].ToString() != "")
                {
                    model.SesameSeed = int.Parse(row["SesameSeed"].ToString());
                }
                if (row["TaobaoAccount"].ToString() != "")
                {
                    model.TaobaoAccount = int.Parse(row["TaobaoAccount"].ToString());
                }

                model.Company=row["Company"].ToString();
                if (row["UnitNature"].ToString() != "")
                {
                    model.UnitNature=int.Parse(row["UnitNature"].ToString());
                }
                if (row["WorkingHour"].ToString() != "")
                {
                    model.WorkingHour=int.Parse(row["WorkingHour"].ToString());
                }
                if (row["Payroll"].ToString() != "")
                {
                    model.Payroll=int.Parse(row["Payroll"].ToString());
                }
                if (row["JobPosition"].ToString() != "")
                {
                    model.JobPosition=int.Parse(row["JobPosition"].ToString());
                }

                if (row["SocialSecurit"].ToString() != "")
                {
                    model.SocialSecurit = int.Parse(row["SocialSecurit"].ToString());
                }


                if (row["Fund"].ToString() != "")
                {
                    model.Fund = int.Parse(row["Fund"].ToString());
                }

                if (row["Degree"].ToString() != "")
                {
                    model.Degree=int.Parse(row["Degree"].ToString());
                }
                model.GraduationYear=row["GraduationYear"].ToString();

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
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM dbo.[NL_IdentityInfo] ");
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
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM dbo.[NL_IdentityInfo] ");
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
            StringBuilder tablesql=new StringBuilder();
            tablesql.Append("select * ");
            tablesql.Append(" FROM dbo.[NL_IdentityInfo] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

    }
}


/*------ 代码生成时出现错误: ------
C:\Program Files (x86)\Maticsoft\Codematic2\Template\TemplateFile\xin.cmt\DAL.cmt(0,0) : warning CS0414: Compiling transformation: 私有字段“Microsoft.VisualStudio.TextTemplating82209DB9872A0BDA5290AA0EB6B4978D.GeneratedTextTransformation.n”已被赋值，但从未使用过它的值
*/
