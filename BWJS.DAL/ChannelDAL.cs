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
    /// 分类类别表
    /// </summary>
    public partial class ChannelDAL : BaseService
    {
        public ChannelDAL()
        { }

        #region  BasicMethod
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.Channel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Channel(");
            strSql.Append("EditId,EditDate,ChannelName,IsDeleted,CreateId,CreateDate");
            strSql.Append(") values (");
            strSql.Append("@EditId,@EditDate,@ChannelName,@IsDeleted,@CreateId,@CreateDate");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@ChannelName", model.ChannelName) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate)

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
        public bool Update(BWJS.Model.Channel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Channel set ");

            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" ChannelName = @ChannelName , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate  ");
            strSql.Append(" where ChannelId=@ChannelId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ChannelId",model.ChannelId) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@ChannelName",model.ChannelName) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate)

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
        public bool Delete(int ChannelId,int EditId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Channel set IsDeleted=1 ,EditDate=GETDATE() ,EditId=@EditId ");
            strSql.Append(" where ChannelId=@ChannelId");
            SqlParameter[] parameters = {
                new SqlParameter("@EditId", SqlDbType.Int,4),
                    new SqlParameter("@ChannelId", SqlDbType.Int,4)
            };
            parameters[0].Value = EditId;
            parameters[1].Value = ChannelId;


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
        public bool DeleteList(string ChannelIdlist,int EditId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Channel set IsDeleted=1,EditDate=GETDATE() ,EditId="+ EditId + " ");
            strSql.Append(" where ID in (" + ChannelIdlist + ")  ");
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
        public BWJS.Model.Channel GetModel(int ChannelId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ChannelId, EditId, EditDate, ChannelName, IsDeleted, CreateId, CreateDate  ");
            strSql.Append("  from Channel ");
            strSql.Append(" where ChannelId=@ChannelId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ChannelId", SqlDbType.Int,4)
            };
            parameters[0].Value = ChannelId;


            BWJS.Model.Channel model = new BWJS.Model.Channel();
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
        public BWJS.Model.Channel DataRowToModel(DataRow row)
        {
            BWJS.Model.Channel model = new BWJS.Model.Channel();

            if (row != null)
            {
                if (row["ChannelId"].ToString() != "")
                {
                    model.ChannelId = int.Parse(row["ChannelId"].ToString());
                }
                if (row["EditId"].ToString() != "")
                {
                    model.EditId = int.Parse(row["EditId"].ToString());
                }
                if (row["EditDate"].ToString() != "")
                {
                    model.EditDate = DateTime.Parse(row["EditDate"].ToString());
                }
                model.ChannelName = row["ChannelName"].ToString();
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
            strSql.Append(" FROM Channel ");
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
            strSql.Append(" FROM Channel ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSHelperSQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
