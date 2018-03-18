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
    /// 系统设置
    /// </summary>
    public partial class SysSettingsDAL: BaseService
    {
        #region ExtensionMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.SysSettings model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[SysSettings](");
            strSql.Append("TimerSeconds,Remark,Status,IsDeleted,CreateId,CreateDate,EditId,EditDate,CompnayName,IP,DomainName,Logo,Icon,RecordNumber,TimerHours,TimerMinutes");
            strSql.Append(") values (");
            strSql.Append("@TimerSeconds,@Remark,@Status,@IsDeleted,@CreateId,@CreateDate,@EditId,@EditDate,@CompnayName,@IP,@DomainName,@Logo,@Icon,@RecordNumber,@TimerHours,@TimerMinutes");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@TimerSeconds", model.TimerSeconds) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@Status", model.Status) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@CompnayName", model.CompnayName) ,
                        new SqlParameter("@IP", model.IP) ,
                        new SqlParameter("@DomainName", model.DomainName) ,
                        new SqlParameter("@Logo", model.Logo) ,
                        new SqlParameter("@Icon", model.Icon) ,
                        new SqlParameter("@RecordNumber", model.RecordNumber) ,
                        new SqlParameter("@TimerHours", model.TimerHours) ,
                        new SqlParameter("@TimerMinutes", model.TimerMinutes)

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
        public bool Update(BWJS.Model.SysSettings model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[SysSettings] set ");

            strSql.Append(" TimerSeconds = @TimerSeconds , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" CompnayName = @CompnayName , ");
            strSql.Append(" IP = @IP , ");
            strSql.Append(" DomainName = @DomainName , ");
            strSql.Append(" Logo = @Logo , ");
            strSql.Append(" Icon = @Icon , ");
            strSql.Append(" RecordNumber = @RecordNumber , ");
            strSql.Append(" TimerHours = @TimerHours , ");
            strSql.Append(" TimerMinutes = @TimerMinutes  ");
            strSql.Append(" where SysSettingsId=@SysSettingsId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@SysSettingsId",model.SysSettingsId) ,
                        new SqlParameter("@TimerSeconds",model.TimerSeconds) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@Status",model.Status) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@CompnayName",model.CompnayName) ,
                        new SqlParameter("@IP",model.IP) ,
                        new SqlParameter("@DomainName",model.DomainName) ,
                        new SqlParameter("@Logo",model.Logo) ,
                        new SqlParameter("@Icon",model.Icon) ,
                        new SqlParameter("@RecordNumber",model.RecordNumber) ,
                        new SqlParameter("@TimerHours",model.TimerHours) ,
                        new SqlParameter("@TimerMinutes",model.TimerMinutes)

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
        public bool Delete(int SysSettingsId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[SysSettings] set IsDeleted=1");
            strSql.Append(" where SysSettingsId=@SysSettingsId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SysSettingsId", SqlDbType.Int,4)
            };
            parameters[0].Value = SysSettingsId;


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
        public bool DeleteList(string SysSettingsIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[SysSettings] set IsDeleted=1");
            strSql.Append(" where ID in (" + SysSettingsIdlist + ")  ");
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
        public BWJS.Model.SysSettings GetModel(int SysSettingsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysSettingsId, TimerSeconds, Remark, Status, IsDeleted, CreateId, CreateDate, EditId, EditDate, CompnayName, IP, DomainName, Logo, Icon, RecordNumber, TimerHours, TimerMinutes  ");
            strSql.Append("  from dbo.[SysSettings] ");
            strSql.Append(" where SysSettingsId=@SysSettingsId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SysSettingsId", SqlDbType.Int,4)
            };
            parameters[0].Value = SysSettingsId;


            BWJS.Model.SysSettings model = new BWJS.Model.SysSettings();
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
        public BWJS.Model.SysSettings DataRowToModel(DataRow row)
        {
            BWJS.Model.SysSettings model = new BWJS.Model.SysSettings();

            if (row != null)
            {
                if (row["SysSettingsId"].ToString() != "")
                {
                    model.SysSettingsId = int.Parse(row["SysSettingsId"].ToString());
                }
                if (row["TimerSeconds"].ToString() != "")
                {
                    model.TimerSeconds = int.Parse(row["TimerSeconds"].ToString());
                }
                model.Remark = row["Remark"].ToString();
                if (row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
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
                if (row["EditId"].ToString() != "")
                {
                    model.EditId = int.Parse(row["EditId"].ToString());
                }
                if (row["EditDate"].ToString() != "")
                {
                    model.EditDate = DateTime.Parse(row["EditDate"].ToString());
                }
                model.CompnayName = row["CompnayName"].ToString();
                model.IP = row["IP"].ToString();
                model.DomainName = row["DomainName"].ToString();
                model.Logo = row["Logo"].ToString();
                model.Icon = row["Icon"].ToString();
                model.RecordNumber = row["RecordNumber"].ToString();
                if (row["TimerHours"].ToString() != "")
                {
                    model.TimerHours = int.Parse(row["TimerHours"].ToString());
                }
                if (row["TimerMinutes"].ToString() != "")
                {
                    model.TimerMinutes = int.Parse(row["TimerMinutes"].ToString());
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
            strSql.Append(" FROM dbo.[SysSettings] ");
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
            strSql.Append(" FROM dbo.[SysSettings] ");
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
            tablesql.Append(" FROM dbo.[SysSettings] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion

        #region ExtensionMethod

        #endregion
    }
}
