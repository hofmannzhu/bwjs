using BWJS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityHelper;
using UtilityHelper.Data;

namespace BWJS.DAL
{
   public class SupplierInfoDAL: BaseService
    {
        public bool Exists(int SId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SupplierInfo");
            strSql.Append(" where ");
            strSql.Append(" SId = @SId  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SId", SqlDbType.Int,4)
            };
            parameters[0].Value = SId;

            return BWJSHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SupplierInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SupplierInfo(");
            strSql.Append("CompanyWebsite,CompanyPhone,CautionMoney,Guarantee,GuaranteeMobile,Balance,LockBalance,TotalBalance,Type,State,SignName,CreateTime,UpdateTime,Remark,extend1,extend2,extend3,extend4,extend5,UserName,UserMobile,UserEmail,UserAdress,UserQQ,UserWechat,CorporateName");
            strSql.Append(") values (");
            strSql.Append("@CompanyWebsite,@CompanyPhone,@CautionMoney,@Guarantee,@GuaranteeMobile,@Balance,@LockBalance,@TotalBalance,@Type,@State,@SignName,@CreateTime,@UpdateTime,@Remark,@extend1,@extend2,@extend3,@extend4,@extend5,@UserName,@UserMobile,@UserEmail,@UserAdress,@UserQQ,@UserWechat,@CorporateName");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@CompanyWebsite", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@CompanyPhone", SqlDbType.VarChar,100) ,
                        new SqlParameter("@CautionMoney", SqlDbType.VarChar,200) ,
                        new SqlParameter("@Guarantee", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@GuaranteeMobile", SqlDbType.VarChar,200) ,
                        new SqlParameter("@Balance", SqlDbType.VarChar,50) ,
                        new SqlParameter("@LockBalance", SqlDbType.VarChar,50) ,
                        new SqlParameter("@TotalBalance", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Type", SqlDbType.TinyInt,1) ,
                        new SqlParameter("@State", SqlDbType.TinyInt,1) ,
                        new SqlParameter("@SignName", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Remark", SqlDbType.NVarChar,500) ,
                        new SqlParameter("@extend1", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@extend2", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@extend3", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@extend4", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@extend5", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@UserName", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@UserMobile", SqlDbType.VarChar,50) ,
                        new SqlParameter("@UserEmail", SqlDbType.VarChar,100) ,
                        new SqlParameter("@UserAdress", SqlDbType.NVarChar,500) ,
                        new SqlParameter("@UserQQ", SqlDbType.VarChar,50) ,
                        new SqlParameter("@UserWechat", SqlDbType.VarChar,200) ,
                        new SqlParameter("@CorporateName", SqlDbType.NVarChar,100)

            };

            parameters[0].Value = model.CompanyWebsite;
            parameters[1].Value = model.CompanyPhone;
            parameters[2].Value = model.CautionMoney;
            parameters[3].Value = model.Guarantee;
            parameters[4].Value = model.GuaranteeMobile;
            parameters[5].Value = model.Balance;
            parameters[6].Value = model.LockBalance;
            parameters[7].Value = model.TotalBalance;
            parameters[8].Value = model.Type;
            parameters[9].Value = model.State;
            parameters[10].Value = model.SignName;
            parameters[11].Value = model.CreateTime;
            parameters[12].Value = model.UpdateTime;
            parameters[13].Value = model.Remark;
            parameters[14].Value = model.extend1;
            parameters[15].Value = model.extend2;
            parameters[16].Value = model.extend3;
            parameters[17].Value = model.extend4;
            parameters[18].Value = model.extend5;
            parameters[19].Value = model.UserName;
            parameters[20].Value = model.UserMobile;
            parameters[21].Value = model.UserEmail;
            parameters[22].Value = model.UserAdress;
            parameters[23].Value = model.UserQQ;
            parameters[24].Value = model.UserWechat;
            parameters[25].Value = model.CorporateName;

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
        public bool Update(SupplierInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SupplierInfo set ");

            strSql.Append(" CompanyWebsite = @CompanyWebsite , ");
            strSql.Append(" CompanyPhone = @CompanyPhone , ");
            strSql.Append(" CautionMoney = @CautionMoney , ");
            strSql.Append(" Guarantee = @Guarantee , ");
            strSql.Append(" GuaranteeMobile = @GuaranteeMobile , ");
            strSql.Append(" Balance = @Balance , ");
            strSql.Append(" LockBalance = @LockBalance , ");
            strSql.Append(" TotalBalance = @TotalBalance , ");
            strSql.Append(" Type = @Type , ");
            strSql.Append(" State = @State , ");
            strSql.Append(" SignName = @SignName , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" UpdateTime = @UpdateTime , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" extend1 = @extend1 , ");
            strSql.Append(" extend2 = @extend2 , ");
            strSql.Append(" extend3 = @extend3 , ");
            strSql.Append(" extend4 = @extend4 , ");
            strSql.Append(" extend5 = @extend5 , ");
            strSql.Append(" UserName = @UserName , ");
            strSql.Append(" UserMobile = @UserMobile , ");
            strSql.Append(" UserEmail = @UserEmail , ");
            strSql.Append(" UserAdress = @UserAdress , ");
            strSql.Append(" UserQQ = @UserQQ , ");
            strSql.Append(" UserWechat = @UserWechat , ");
            strSql.Append(" CorporateName = @CorporateName  ");
            strSql.Append(" where SId=@SId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@SId", SqlDbType.Int,4) ,
                        new SqlParameter("@CompanyWebsite", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@CompanyPhone", SqlDbType.VarChar,100) ,
                        new SqlParameter("@CautionMoney", SqlDbType.VarChar,200) ,
                        new SqlParameter("@Guarantee", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@GuaranteeMobile", SqlDbType.VarChar,200) ,
                        new SqlParameter("@Balance", SqlDbType.VarChar,50) ,
                        new SqlParameter("@LockBalance", SqlDbType.VarChar,50) ,
                        new SqlParameter("@TotalBalance", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Type", SqlDbType.TinyInt,1) ,
                        new SqlParameter("@State", SqlDbType.TinyInt,1) ,
                        new SqlParameter("@SignName", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Remark", SqlDbType.NVarChar,500) ,
                        new SqlParameter("@extend1", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@extend2", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@extend3", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@extend4", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@extend5", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@UserName", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@UserMobile", SqlDbType.VarChar,50) ,
                        new SqlParameter("@UserEmail", SqlDbType.VarChar,100) ,
                        new SqlParameter("@UserAdress", SqlDbType.NVarChar,500) ,
                        new SqlParameter("@UserQQ", SqlDbType.VarChar,50) ,
                        new SqlParameter("@UserWechat", SqlDbType.VarChar,200) ,
                        new SqlParameter("@CorporateName", SqlDbType.NVarChar,100)

            };

            parameters[0].Value = model.SId;
            parameters[1].Value = model.CompanyWebsite;
            parameters[2].Value = model.CompanyPhone;
            parameters[3].Value = model.CautionMoney;
            parameters[4].Value = model.Guarantee;
            parameters[5].Value = model.GuaranteeMobile;
            parameters[6].Value = model.Balance;
            parameters[7].Value = model.LockBalance;
            parameters[8].Value = model.TotalBalance;
            parameters[9].Value = model.Type;
            parameters[10].Value = model.State;
            parameters[11].Value = model.SignName;
            parameters[12].Value = model.CreateTime;
            parameters[13].Value = model.UpdateTime;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.extend1;
            parameters[16].Value = model.extend2;
            parameters[17].Value = model.extend3;
            parameters[18].Value = model.extend4;
            parameters[19].Value = model.extend5;
            parameters[20].Value = model.UserName;
            parameters[21].Value = model.UserMobile;
            parameters[22].Value = model.UserEmail;
            parameters[23].Value = model.UserAdress;
            parameters[24].Value = model.UserQQ;
            parameters[25].Value = model.UserWechat;
            parameters[26].Value = model.CorporateName;
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
        public bool Delete(int SId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SupplierInfo ");
            strSql.Append(" where SId=@SId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SId", SqlDbType.Int,4)
            };
            parameters[0].Value = SId;


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
        public bool DeleteList(string SIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SupplierInfo ");
            strSql.Append(" where ID in (" + SIdlist + ")  ");
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
        public SupplierInfo GetModel(int SId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SId, CompanyWebsite, CompanyPhone, CautionMoney, Guarantee, GuaranteeMobile, Balance, LockBalance, TotalBalance, Type, State, SignName, CreateTime, UpdateTime, Remark, extend1, extend2, extend3, extend4, extend5, UserName, UserMobile, UserEmail, UserAdress, UserQQ, UserWechat, CorporateName  ");
            strSql.Append("  from SupplierInfo ");
            strSql.Append(" where SId=@SId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SId", SqlDbType.Int,4)
            };
            parameters[0].Value = SId;


            SupplierInfo model = new SupplierInfo();
            DataSet ds = BWJSHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SId"].ToString() != "")
                {
                    model.SId = int.Parse(ds.Tables[0].Rows[0]["SId"].ToString());
                }
                model.CompanyWebsite = ds.Tables[0].Rows[0]["CompanyWebsite"].ToString();
                model.CompanyPhone = ds.Tables[0].Rows[0]["CompanyPhone"].ToString();
                model.CautionMoney = ds.Tables[0].Rows[0]["CautionMoney"].ToString();
                model.Guarantee = ds.Tables[0].Rows[0]["Guarantee"].ToString();
                model.GuaranteeMobile = ds.Tables[0].Rows[0]["GuaranteeMobile"].ToString();
                model.Balance = ds.Tables[0].Rows[0]["Balance"].ToString();
                model.LockBalance = ds.Tables[0].Rows[0]["LockBalance"].ToString();
                model.TotalBalance = ds.Tables[0].Rows[0]["TotalBalance"].ToString();
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                model.SignName = ds.Tables[0].Rows[0]["SignName"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.extend1 = ds.Tables[0].Rows[0]["extend1"].ToString();
                model.extend2 = ds.Tables[0].Rows[0]["extend2"].ToString();
                model.extend3 = ds.Tables[0].Rows[0]["extend3"].ToString();
                model.extend4 = ds.Tables[0].Rows[0]["extend4"].ToString();
                model.extend5 = ds.Tables[0].Rows[0]["extend5"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.UserMobile = ds.Tables[0].Rows[0]["UserMobile"].ToString();
                model.UserEmail = ds.Tables[0].Rows[0]["UserEmail"].ToString();
                model.UserAdress = ds.Tables[0].Rows[0]["UserAdress"].ToString();
                if (ds.Tables[0].Rows[0]["UserQQ"].ToString() != "")
                {
                    model.UserQQ = ds.Tables[0].Rows[0]["UserQQ"].ToString();
                }
                model.UserWechat = ds.Tables[0].Rows[0]["UserWechat"].ToString();
                model.CorporateName = ds.Tables[0].Rows[0]["CorporateName"].ToString();

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
            strSql.Append(" FROM SupplierInfo ");
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
            strSql.Append(" FROM SupplierInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SupplierInfo GetModelBySId(int SId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from SupplierInfo ");
            strSql.Append(" where SId=@SId and State=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@SId", SqlDbType.Int,4)
            };
            parameters[0].Value = SId;
            SupplierInfo model = new SupplierInfo();
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
        public SupplierInfo DataRowToModel(DataRow row)
        {
           SupplierInfo model = new Model.SupplierInfo();

            if (row != null)
            {
                if (row["SId"].ToString() != "")
                {
                    model.SId = int.Parse(row["SId"].ToString());
                }
                model.CompanyWebsite = row["CompanyWebsite"].ToString();
                model.CompanyPhone = row["CompanyPhone"].ToString();
                model.CautionMoney = row["CautionMoney"].ToString();
                model.Guarantee = row["Guarantee"].ToString();
                model.GuaranteeMobile = row["GuaranteeMobile"].ToString();
                model.Balance = row["Balance"].ToString();
                model.LockBalance = row["LockBalance"].ToString();
                model.TotalBalance = row["TotalBalance"].ToString();
                if (row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                model.SignName = row["SignName"].ToString();
                if (row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
                model.Remark = row["Remark"].ToString();
                model.extend1 = row["extend1"].ToString();
                model.extend2 = row["extend2"].ToString();
                model.extend3 = row["extend3"].ToString();
                model.extend4 = row["extend4"].ToString();
                model.extend5 = row["extend5"].ToString();
                model.UserName = row["UserName"].ToString();
                model.UserMobile = row["UserMobile"].ToString();
                model.UserEmail = row["UserEmail"].ToString();
                model.UserAdress = row["UserAdress"].ToString();
                if (row["UserQQ"].ToString() != "")
                {
                    model.UserQQ = row["UserQQ"].ToString();
                }
                model.UserWechat = row["UserWechat"].ToString();
                model.CorporateName = row["CorporateName"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetSignName(int SId)
        {
            string resultStr = string.Empty;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  SignName  ");
            strSql.Append("  from SupplierInfo ");
            strSql.Append(" where SId=@SId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SId", SqlDbType.Int,4)
            };
            parameters[0].Value = SId; 
            SupplierInfo model = new SupplierInfo();
            DataSet ds = BWJSHelperSQL.Query(strSql.ToString(), parameters); 
            if (ds.Tables[0].Rows.Count > 0)
            {
                resultStr = ds.Tables[0].Rows[0]["SignName"].ToString(); 
            }
            return resultStr;
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
            tablesql.Append(" FROM dbo.[SupplierInfo] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }
    }
}
