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
    /// NLLoanConfig
    /// </summary>
    public partial class NLLoanConfigDAL
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.NLLoanConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[NLLoanConfig](");
            strSql.Append("RecordCreateTime,KeyType,KeyName,KeyVal,Description,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordUpdateTime");
            strSql.Append(") values (");
            strSql.Append("@RecordCreateTime,@KeyType,@KeyName,@KeyVal,@Description,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordUpdateTime");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@TypeName", model.TypeName) ,
                        new SqlParameter("@KeyName", model.KeyName) ,
                        new SqlParameter("@KeyVal", model.KeyVal) ,
                        new SqlParameter("@KeyDesc", model.KeyDesc) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@EditDate", model.EditDate)

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
        public bool Update(BWJS.Model.NLLoanConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NLLoanConfig] set ");

            strSql.Append(" RecordCreateTime = @RecordCreateTime , ");
            strSql.Append(" KeyType = @KeyType , ");
            strSql.Append(" KeyName = @KeyName , ");
            strSql.Append(" KeyVal = @KeyVal , ");
            strSql.Append(" Description = @Description , ");
            strSql.Append(" CreatUserID = @CreatUserID , ");
            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");
            strSql.Append(" RecordIsDelete = @RecordIsDelete , ");
            strSql.Append(" RecordUpdateTime = @RecordUpdateTime  ");
            strSql.Append(" where Id=@Id ");


                    
                             SqlParameter[] parameters = {
                    new SqlParameter("@ID",model.ID) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@TypeName", model.TypeName) ,
                        new SqlParameter("@KeyName", model.KeyName) ,
                        new SqlParameter("@KeyVal", model.KeyVal) ,
                        new SqlParameter("@KeyDesc", model.KeyDesc) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@EditDate", model.EditDate)

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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NLLoanConfig] set IsDeleted=1");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[NLLoanConfig] set IsDeleted=1");
            strSql.Append(" where ID in (" + Idlist + ")  ");
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
        public BWJS.Model.NLLoanConfig GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, RecordCreateTime, KeyType, KeyName, KeyVal, Description, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime  ");
            strSql.Append("  from dbo.[NLLoanConfig] ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


            BWJS.Model.NLLoanConfig model = new BWJS.Model.NLLoanConfig();
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
        public BWJS.Model.NLLoanConfig DataRowToModel(DataRow row)
        {
            BWJS.Model.NLLoanConfig model = new BWJS.Model.NLLoanConfig();

            if (row != null)
            {
                if (row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["TypeName"].ToString() != "")
                {
                    model.TypeName = row["TypeName"].ToString();
                }
                model.KeyName = row["KeyName"].ToString();
                model.KeyValue = row["KeyValue"].ToString();
                model.KeyDesc = row["KeyDesc"].ToString();
                if (row["CreateId"].ToString() != "")
                {
                    model.CreateId = int.Parse(row["CreateId"].ToString());
                }
                if (row["EditId"].ToString() != "")
                {
                    model.EditId = int.Parse(row["EditId"].ToString());
                }
                if (row["IsDeleted"].ToString() != "")
                {
                    if ((row["IsDeleted"].ToString() == "1") || (row["IsDeleted"].ToString().ToLower() == "true"))
                    {
                        model.IsDeleted = 1;
                    }
                    else
                    {
                        model.IsDeleted = 0;
                    }
                }
                if (row["EditDate"].ToString() != "")
                {
                    model.EditDate = DateTime.Parse(row["EditDate"].ToString());
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
            strSql.Append(" FROM dbo.[NLLoanConfig] ");
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
            strSql.Append(" FROM dbo.[NLLoanConfig] ");
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
            tablesql.Append(" FROM dbo.[NLLoanConfig] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }
        #endregion
        /// <summary>
        /// 根据Key的名称 查询Key值
        /// </summary>
        /// <param name="Keyname"></param>
        /// <returns></returns>
        public string GetValue(string Keyname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  KeyVal from NLLoanConfig ");
            strSql.Append(" where KeyName=@keyname ");
            SqlParameter[] parameters = {
                    new SqlParameter("@keyname", SqlDbType.NVarChar)};
            parameters[0].Value = Keyname;
            object obj = BWJSHelperSQL.GetSingle(strSql.ToString(), parameters);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetConfigList(string TypeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM dbo.[NL_LoanConfig] ");
            if (TypeName.Trim() != "")
            {
                strSql.Append(" where  IsDeleted=0 and  TypeName= '"+ TypeName + "'" );
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }
    }
}
