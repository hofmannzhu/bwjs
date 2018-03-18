using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using Mofang.Model;
using Mofang.Model.ViewModel;
using UtilityHelper.Data;

namespace Mofang.DAL
{
    //退保表单
    public partial class CardTypeDAL : BaseService
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CardType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CardType(");
            strSql.Append("Value,Name,Sort");
            strSql.Append(") values (");
            strSql.Append("@Value,@Name,@Sort");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@Value", model.Value) ,
                        new SqlParameter("@Name", model.Name) ,
                        new SqlParameter("@Sort", model.Sort)

            };

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(CardType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CardType set ");
            strSql.Append(" Value = @Value , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Sort = @Sort  ");
            strSql.Append(" where CDID=@CDID  and RecordUpdateTime = @RecordUpdateTime");
            SqlParameter[] parameters = {
                        new SqlParameter("@CDID",  model.CDID) ,
                        new SqlParameter("@Value", model.Value) ,
                        new SqlParameter("@Name", model.Name) ,
                        new SqlParameter("@Sort", model.Sort)

            };
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool UpdateDelete(int CDID)
        //{

        //	StringBuilder strSql=new StringBuilder();
        //	strSql.Append("update CardType set  RecordIsDelete =1  ");
        //	strSql.Append(" where CDID=@CDID");
        //				SqlParameter[] parameters = {
        //			new SqlParameter("@CDID", SqlDbType.Int,4)
        //	};
        //	parameters[0].Value = CDID;


        //	int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        //	if (rows > 0)
        //	{
        //		return true;
        //	}
        //	else
        //	{
        //		return false;
        //	}
        //}

        //		/// <summary>
        ///// 批量删除一批数据
        ///// </summary>
        //public bool UpdateDeleteList(string CDIDlist )
        //{
        //	StringBuilder strSql=new StringBuilder();
        //	strSql.Append("update CardType set  RecordIsDelete =1  ");
        //	strSql.Append(" where ID in ("+CDIDlist + ")  ");
        //	int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
        //	if (rows > 0)
        //	{
        //		return true;
        //	}
        //	else
        //	{
        //		return false;
        //	}
        //}


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CardType GetModel(int CDID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CDID, Value, Name, Sort  ");
            strSql.Append("  from CardType ");
            strSql.Append(" where CDID=@CDID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CDID", SqlDbType.Int,4)
            };
            parameters[0].Value = CDID;


            CardType model = new CardType();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CDID"].ToString() != "")
                {
                    model.CDID = int.Parse(ds.Tables[0].Rows[0]["CDID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Value"].ToString() != "")
                {
                    model.Value = int.Parse(ds.Tables[0].Rows[0]["Value"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM CardType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" FROM CardType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<CardTypeViewModel> GetCardTypeList(string caseCode)
        {
            try
            {
                string strOrderBy = "  ";
                string strOutFields = "Value,Name";
                string strSelectFields = " Value,Name ";
                string strTable = @"CardType where CDID in(select * from dbo.F_SplitToInt((select CardTypeIDs from  Products  where  CaseCode='" + caseCode + "'),','))";
                string strSql = "SELECT  " + strSelectFields + " FROM " + strTable + "   ";
                string strWhere = "";
                strSql = strSql + strWhere;
                strSql = strSql + strOrderBy;
                SqlParameter[] parameters = new SqlParameter[]{
                // new SqlParameter ("@TypeID",TypeID)
               };
                List<CardTypeViewModel> list = SqlDataUtilityHelper.GetListFromDB<CardTypeViewModel>(strOutFields, ConnectionString, strSql, parameters);

                return list;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}

