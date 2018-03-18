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
    /// 资产信息
    /// </summary>
    public partial class NL_AssetInfoDAL
    {

        public bool Exists(int ConsultId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dbo.[NL_AssetInfo]");
            strSql.Append(" where ");
            strSql.Append(" ConsultId = @ConsultId  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ConsultId", SqlDbType.Int,4)         };
            parameters[0].Value = ConsultId;

            return BWJSHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int  Add(BWJS.Model.NL_AssetInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[NL_AssetInfo](");
            strSql.Append("ConsultId,Cars,Houses,OtherLoans,SesameSeed,TaobaoAccount,ParticleLoan,BusinessPolicy,CreditCard,CreditSituation,CreditCardServiceLife");
            strSql.Append(") values (");
            strSql.Append("@ConsultId,@Cars,@Houses,@OtherLoans,@SesameSeed,@TaobaoAccount,@ParticleLoan,@BusinessPolicy,@CreditCard,@CreditSituation,@CreditCardServiceLife");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@ConsultId", model.ConsultId) ,
                        new SqlParameter("@Cars", model.Cars) ,
                        new SqlParameter("@Houses", model.Houses) ,
                        new SqlParameter("@OtherLoans", model.OtherLoans) ,
                        new SqlParameter("@SesameSeed", model.SesameSeed) ,
                        new SqlParameter("@TaobaoAccount", model.TaobaoAccount) ,
                        new SqlParameter("@ParticleLoan", model.ParticleLoan) ,
                        new SqlParameter("@BusinessPolicy", model.BusinessPolicy) ,
                        new SqlParameter("@CreditCard", model.CreditCard) ,
                        new SqlParameter("@CreditSituation", model.CreditSituation) ,
                        new SqlParameter("@CreditCardServiceLife", model.CreditCardServiceLife)

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
        public bool Update(BWJS.Model.NL_AssetInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NL_AssetInfo] set ");

            strSql.Append(" ConsultId=@ConsultId , ");
            strSql.Append(" Cars=@Cars , ");
            strSql.Append(" Houses=@Houses , ");
            strSql.Append(" OtherLoans=@OtherLoans , ");
            strSql.Append(" SesameSeed=@SesameSeed , ");
            strSql.Append(" TaobaoAccount=@TaobaoAccount , ");
            strSql.Append(" ParticleLoan=@ParticleLoan , ");
            strSql.Append(" BusinessPolicy=@BusinessPolicy , ");
            strSql.Append(" CreditCard=@CreditCard , ");
            strSql.Append(" CreditSituation=@CreditSituation , ");
            strSql.Append(" CreditCardServiceLife=@CreditCardServiceLife  ");
            strSql.Append(" where ConsultId=@ConsultId  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ConsultId",model.ConsultId) ,
                        new SqlParameter("@Cars",model.Cars) ,
                        new SqlParameter("@Houses",model.Houses) ,
                        new SqlParameter("@OtherLoans",model.OtherLoans) ,
                        new SqlParameter("@SesameSeed",model.SesameSeed) ,
                        new SqlParameter("@TaobaoAccount",model.TaobaoAccount) ,
                        new SqlParameter("@ParticleLoan",model.ParticleLoan) ,
                        new SqlParameter("@BusinessPolicy",model.BusinessPolicy) ,
                        new SqlParameter("@CreditCard",model.CreditCard) ,
                        new SqlParameter("@CreditSituation",model.CreditSituation) ,
                        new SqlParameter("@CreditCardServiceLife",model.CreditCardServiceLife)

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
        public bool Delete(int ConsultId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NL_AssetInfo] set IsDeleted=1");
            strSql.Append(" where ConsultId=@ConsultId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ConsultId", SqlDbType.Int,4)          };
            parameters[0].Value = ConsultId;


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
        public BWJS.Model.NL_AssetInfo GetModel(int ConsultId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ConsultId, Cars, Houses, OtherLoans, SesameSeed, TaobaoAccount, ParticleLoan, BusinessPolicy, CreditCard, CreditSituation, CreditCardServiceLife  ");
            strSql.Append("  from dbo.[NL_AssetInfo] ");
            strSql.Append(" where ConsultId=@ConsultId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ConsultId", SqlDbType.Int,4)          };
            parameters[0].Value = ConsultId;


            BWJS.Model.NL_AssetInfo model = new BWJS.Model.NL_AssetInfo();
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
        public BWJS.Model.NL_AssetInfo DataRowToModel(DataRow row)
        {
            BWJS.Model.NL_AssetInfo model = new BWJS.Model.NL_AssetInfo();

            if (row != null)
            {
                if (row["ConsultId"].ToString() != "")
                {
                    model.ConsultId = int.Parse(row["ConsultId"].ToString());
                }
                if (row["Cars"].ToString() != "")
                {
                    model.Cars = int.Parse(row["Cars"].ToString());
                }
                if (row["Houses"].ToString() != "")
                {
                    model.Houses = int.Parse(row["Houses"].ToString());
                }
                if (row["OtherLoans"].ToString() != "")
                {
                    model.OtherLoans = int.Parse(row["OtherLoans"].ToString());
                }
                if (row["SesameSeed"].ToString() != "")
                {
                    model.SesameSeed = int.Parse(row["SesameSeed"].ToString());
                }
                if (row["TaobaoAccount"].ToString() != "")
                {
                    model.TaobaoAccount = int.Parse(row["TaobaoAccount"].ToString());
                }
                if (row["ParticleLoan"].ToString() != "")
                {
                    model.ParticleLoan = int.Parse(row["ParticleLoan"].ToString());
                }
                if (row["BusinessPolicy"].ToString() != "")
                {
                    model.BusinessPolicy = int.Parse(row["BusinessPolicy"].ToString());
                }
                if (row["CreditCard"].ToString() != "")
                {
                    model.CreditCard = int.Parse(row["CreditCard"].ToString());
                }
                if (row["CreditSituation"].ToString() != "")
                {
                    model.CreditSituation = int.Parse(row["CreditSituation"].ToString());
                }
                if (row["CreditCardServiceLife"].ToString() != "")
                {
                    model.CreditCardServiceLife = int.Parse(row["CreditCardServiceLife"].ToString());
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
            strSql.Append(" FROM dbo.[NL_AssetInfo] ");
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
            strSql.Append(" FROM dbo.[NL_AssetInfo] ");
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
            tablesql.Append(" FROM dbo.[NL_AssetInfo] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

    }
}


/*------ 代码生成时出现错误: ------
C:\Program Files (x86)\Maticsoft\Codematic2\Template\TemplateFile\xin.cmt\DAL.cmt(0,0) : warning CS0414: Compiling transformation: 私有字段“Microsoft.VisualStudio.TextTemplating82209DB9872A0BDA5290AA0EB6B4978D.GeneratedTextTransformation.n”已被赋值，但从未使用过它的值
*/
