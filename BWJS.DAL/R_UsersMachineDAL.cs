using BWJS.Model.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityHelper;

namespace BWJS.DAL
{
    public class R_UsersMachineDAL : BaseService
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RUMID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from R_UsersMachine");
            strSql.Append(" where RUMID=@RUMID");
            SqlParameter[] parameters = {
                    new SqlParameter("@RUMID", SqlDbType.Int,4)
            };
            parameters[0].Value = RUMID;

            return BWJSHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(R_UsersMachine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into R_UsersMachine(");
            strSql.Append("UserID,MachineID,RecordIsDelete,RecordCreateTime,RecordUpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@MachineID,@RecordIsDelete,@RecordCreateTime,@RecordUpdateTime)");
              strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@MachineID", SqlDbType.Int,4),
                    new SqlParameter("@RecordIsDelete", SqlDbType.Bit,1),
                    new SqlParameter("@RecordCreateTime", SqlDbType.DateTime),
                    new SqlParameter("@RecordUpdateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.MachineID;
            parameters[2].Value = model.RecordIsDelete;
            parameters[3].Value = model.RecordCreateTime;
            parameters[4].Value = model.RecordUpdateTime;

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
        public bool Update(R_UsersMachine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update R_UsersMachine set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("MachineID=@MachineID,");
            strSql.Append("RecordIsDelete=@RecordIsDelete,");
            strSql.Append("RecordCreateTime=@RecordCreateTime,");
            strSql.Append("RecordUpdateTime@=RecordUpdateTime");
            strSql.Append(" where RUMID=@RUMID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@MachineID", SqlDbType.Int,4),
                    new SqlParameter("@RecordIsDelete", SqlDbType.Bit,1),
                    new SqlParameter("@RecordCreateTime", SqlDbType.DateTime),
                    new SqlParameter("@RecordUpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@RUMID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.MachineID;
            parameters[2].Value = model.RecordIsDelete;
            parameters[3].Value = model.RecordCreateTime;
            parameters[4].Value = model.RecordUpdateTime;
            parameters[5].Value = model.RUMID;

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
        public bool Delete(int RUMID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from R_UsersMachine ");
            strSql.Append(" where RUMID=@RUMID");
            SqlParameter[] parameters = {
                    new SqlParameter("@RUMID", SqlDbType.Int,4)
            };
            parameters[0].Value = RUMID;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string RUMIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from R_UsersMachine ");
            strSql.Append(" where RUMID in (" + RUMIDlist + ")  ");
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
        public bool DeleteListByMachineID(int machineId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from R_UsersMachine ");
            strSql.Append(" where MachineID=@machineId");
            SqlParameter[] parameters = {
                    new SqlParameter("@machineId", SqlDbType.Int,4)
            };
            parameters[0].Value = machineId;

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
        public R_UsersMachine GetModel(int RUMID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RUMID,UserID,MachineID,RecordIsDelete,RecordCreateTime,RecordUpdateTime from R_UsersMachine ");
            strSql.Append(" where RUMID=@RUMID");
            SqlParameter[] parameters = {
                    new SqlParameter("@RUMID", SqlDbType.Int,4)
            };
            parameters[0].Value = RUMID;

            R_UsersMachine model = new R_UsersMachine();
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
        public R_UsersMachine DataRowToModel(DataRow row)
        {
            R_UsersMachine model = new R_UsersMachine();
            if (row != null)
            {
                if (row["RUMID"] != null && row["RUMID"].ToString() != "")
                {
                    model.RUMID = int.Parse(row["RUMID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["MachineID"] != null && row["MachineID"].ToString() != "")
                {
                    model.MachineID = int.Parse(row["MachineID"].ToString());
                }
                if (row["RecordIsDelete"] != null && row["RecordIsDelete"].ToString() != "")
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
                if (row["RecordCreateTime"] != null && row["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(row["RecordCreateTime"].ToString());
                }
                if (row["RecordUpdateTime"] != null && row["RecordUpdateTime"].ToString() != "")
                {
                    model.RecordUpdateTime = DateTime.Parse(row["RecordUpdateTime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RUMID,UserID,MachineID,RecordIsDelete,RecordCreateTime,RecordUpdateTime ");
            strSql.Append(" FROM R_UsersMachine ");
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
            strSql.Append(" RUMID,UserID,MachineID,RecordIsDelete,RecordCreateTime,RecordUpdateTime ");
            strSql.Append(" FROM R_UsersMachine ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM R_UsersMachine ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = BWJSHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.RUMID desc");
            }
            strSql.Append(")AS Row, T.*  from R_UsersMachine T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("tblName", SqlDbType.VarChar, 255),
					new SqlParameter("fldName", SqlDbType.VarChar, 255),
					new SqlParameter("PageSize", SqlDbType.Int),
					new SqlParameter("PageIndex", SqlDbType.Int),
					new SqlParameter("IsReCount", SqlDbType.Bit),
					new SqlParameter("OrderType", SqlDbType.Bit),
					new SqlParameter("strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "R_UsersMachine";
			parameters[1].Value = "RUMID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return BWJSHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
