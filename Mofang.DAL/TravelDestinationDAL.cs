using UtilityHelper;
using Mofang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using UtilityHelper.Data;

namespace Mofang.DAL
{
    /// <summary>
    /// 出行目的地
    /// </summary>
    public partial class TravelDestinationDAL: BaseService
    {
        public TravelDestinationDAL() { }
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mofang.Model.TravelDestination model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TravelDestination(");
            strSql.Append("Value,Name,Status,Sort");
            strSql.Append(") values (");
            strSql.Append("@Value,@Name,@Status,@Sort");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@Value", model.Value) ,
                        new SqlParameter("@Name", model.Name) ,
                        new SqlParameter("@Status", model.Status) ,
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
        public bool Update(Mofang.Model.TravelDestination model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TravelDestination set ");

            strSql.Append(" Value = @Value , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" Sort = @Sort  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Id",model.Id) ,
                        new SqlParameter("@Value",model.Value) ,
                        new SqlParameter("@Name",model.Name) ,
                        new SqlParameter("@Status",model.Status) ,
                        new SqlParameter("@Sort",model.Sort)

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


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TravelDestination set IsDeleted=1");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


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

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TravelDestination set IsDeleted=1");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Mofang.Model.TravelDestination GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Value, Name, Status, Sort  ");
            strSql.Append("  from TravelDestination ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


            Mofang.Model.TravelDestination model = new Mofang.Model.TravelDestination();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Value"].ToString() != "")
                {
                    model.Value = int.Parse(ds.Tables[0].Rows[0]["Value"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
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
            strSql.Append(" FROM TravelDestination ");
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
            strSql.Append(" FROM TravelDestination ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        public List<TravelDestination> GetTravelDestinationList(string caseCode)
        {
            try
            {
                string strOrderBy = "  ";
                string strOutFields = "Id,Value,Name,Status,Sort";
                string strSelectFields = " Id,Value,Name,Status,Sort ";
                string strTable = @"TravelDestination where Id in(select * from dbo.F_SplitToInt((select TravelDestinationIDs from  Products  where  CaseCode='" + caseCode + "'),','))";              
                string strSql = "SELECT  " + strSelectFields + " FROM " + strTable + "   ";
                string strWhere = " ";
                strSql = strSql + strWhere;
                strSql = strSql + strOrderBy;
                SqlParameter[] parameters = new SqlParameter[]{
                // new SqlParameter ("@TypeID",TypeID)
               };
                List<TravelDestination> list = SqlDataUtilityHelper.GetListFromDB<TravelDestination>(strOutFields, ConnectionString, strSql, parameters);

                return list;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
