using UtilityHelper;
using UtilityHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BWJSLog.DAL
{
    /// <summary>
    /// 短信发送日志
    /// </summary>
    public partial class SmsSendLogDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJSLog.Model.SmsSendLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SmsSendLog(");
            strSql.Append("SendResult,SmsTemplateId,SendType,SmsContent,Mobile,Status,IsDeleted,CreateDate,SendDate");
            strSql.Append(") values (");
            strSql.Append("@SendResult,@SmsTemplateId,@SendType,@SmsContent,@Mobile,@Status,@IsDeleted,@CreateDate,@SendDate");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@SendResult", model.SendResult) ,
                        new SqlParameter("@SmsTemplateId", model.SmsTemplateId) ,
                        new SqlParameter("@SendType", model.SendType) ,
                        new SqlParameter("@SmsContent", model.SmsContent) ,
                        new SqlParameter("@Mobile", model.Mobile) ,
                        new SqlParameter("@Status", model.Status) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@SendDate", model.SendDate)

            };


            object obj = BWJSLogHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(BWJSLog.Model.SmsSendLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SmsSendLog set ");

            strSql.Append(" SendResult = @SendResult , ");
            strSql.Append(" SmsTemplateId = @SmsTemplateId , ");
            strSql.Append(" SendType = @SendType , ");
            strSql.Append(" SmsContent = @SmsContent , ");
            strSql.Append(" Mobile = @Mobile , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" SendDate = @SendDate  ");
            strSql.Append(" where SmsLogId=@SmsLogId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@SmsLogId",model.SmsLogId) ,
                        new SqlParameter("@SendResult",model.SendResult) ,
                        new SqlParameter("@SmsTemplateId",model.SmsTemplateId) ,
                        new SqlParameter("@SendType",model.SendType) ,
                        new SqlParameter("@SmsContent",model.SmsContent) ,
                        new SqlParameter("@Mobile",model.Mobile) ,
                        new SqlParameter("@Status",model.Status) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@SendDate",model.SendDate)

            };

            int rows = BWJSLogHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int SmsLogId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SmsSendLog set IsDeleted=1");
            strSql.Append(" where SmsLogId=@SmsLogId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SmsLogId", SqlDbType.Int,4)
            };
            parameters[0].Value = SmsLogId;


            int rows = BWJSLogHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string SmsLogIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SmsSendLog set IsDeleted=1");
            strSql.Append(" where ID in (" + SmsLogIdlist + ")  ");
            int rows = BWJSLogHelperSQL.ExecuteSql(strSql.ToString());
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
        public BWJSLog.Model.SmsSendLog GetModel(int SmsLogId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SmsLogId, SendResult, SmsTemplateId, SendType, SmsContent, Mobile, Status, IsDeleted, CreateDate, SendDate  ");
            strSql.Append("  from SmsSendLog ");
            strSql.Append(" where SmsLogId=@SmsLogId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SmsLogId", SqlDbType.Int,4)
            };
            parameters[0].Value = SmsLogId;


            BWJSLog.Model.SmsSendLog model = new BWJSLog.Model.SmsSendLog();
            DataSet ds = BWJSLogHelperSQL.Query(strSql.ToString(), parameters);

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
        public BWJSLog.Model.SmsSendLog DataRowToModel(DataRow row)
        {
            BWJSLog.Model.SmsSendLog model = new BWJSLog.Model.SmsSendLog();

            if (row != null)
            {
                if (row["SmsLogId"].ToString() != "")
                {
                    model.SmsLogId = int.Parse(row["SmsLogId"].ToString());
                }
                model.SendResult = row["SendResult"].ToString();
                if (row["SmsTemplateId"].ToString() != "")
                {
                    model.SmsTemplateId = int.Parse(row["SmsTemplateId"].ToString());
                }
                if (row["SendType"].ToString() != "")
                {
                    model.SendType = int.Parse(row["SendType"].ToString());
                }
                model.SmsContent = row["SmsContent"].ToString();
                model.Mobile = row["Mobile"].ToString();
                if (row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                if (row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["SendDate"].ToString() != "")
                {
                    model.SendDate = DateTime.Parse(row["SendDate"].ToString());
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
            strSql.Append(" FROM SmsSendLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSLogHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" FROM SmsSendLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSLogHelperSQL.Query(strSql.ToString());
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
            return BWJSLogHelperSQL.GetPageList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion

        #region ExtensionMethod

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
            tablesql.Append(" FROM SmsSendLog a ");
            return BWJSLogHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }
        #endregion
    }
}
