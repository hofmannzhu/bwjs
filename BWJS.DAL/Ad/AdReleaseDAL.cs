using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using BWJS.Model;
using BWJS.Model.Model;
using UtilityHelper.Data;

namespace BWJS.DAL.Ad
{
    //广告发布表
    public partial class AdReleaseDAL : BaseService
    {
        #region BasicMethod
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.AdRelease model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdRelease(");
            strSql.Append("Remark,BeginTime,EndTime,ResourceID,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordUpdateTime,RecordCreateTime,AdReleaseName");
            strSql.Append(") values (");
            strSql.Append("@Remark,@BeginTime,@EndTime,@ResourceID,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordUpdateTime,@RecordCreateTime,@AdReleaseName");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@BeginTime", model.BeginTime) ,
                        new SqlParameter("@EndTime", model.EndTime) ,
                        new SqlParameter("@ResourceID", model.ResourceID) ,
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,
                         new SqlParameter("@AdReleaseName", model.AdReleaseName),
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime)

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
        public bool Update(BWJS.Model.AdRelease model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdRelease set ");
            strSql.Append(" AdReleaseName = @AdReleaseName , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" BeginTime = @BeginTime , ");
            strSql.Append(" EndTime = @EndTime , ");
            strSql.Append(" ResourceID = @ResourceID , ");
            strSql.Append(" CreatUserID = @CreatUserID , ");
            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");
            strSql.Append(" RecordIsDelete = @RecordIsDelete , ");
            strSql.Append(" RecordUpdateTime = @RecordUpdateTime , ");
            strSql.Append(" RecordCreateTime = @RecordCreateTime  ");
            strSql.Append(" where AdReleaseID=@AdReleaseID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@AdReleaseID",model.AdReleaseID) ,
                        new SqlParameter("@AdReleaseName",model.AdReleaseName) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@BeginTime",model.BeginTime) ,
                        new SqlParameter("@EndTime",model.EndTime) ,
                        new SqlParameter("@ResourceID",model.ResourceID) ,
                        new SqlParameter("@CreatUserID",model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID",model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete",model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime",model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime",model.RecordCreateTime)

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
        public bool Delete(int AdReleaseID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdRelease set IsDeleted=1");
            strSql.Append(" where AdReleaseID=@AdReleaseID");
            SqlParameter[] parameters = {
                    new SqlParameter("@AdReleaseID", SqlDbType.Int,4)
            };
            parameters[0].Value = AdReleaseID;


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
        public bool DeleteList(string AdReleaseIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdRelease set IsDeleted=1");
            strSql.Append(" where ID in (" + AdReleaseIDlist + ")  ");
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
        public BWJS.Model.AdRelease GetModel(int AdReleaseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AdReleaseID, Remark, BeginTime, EndTime, ResourceID, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime, RecordCreateTime,AdReleaseName ");
            strSql.Append("  from AdRelease ");
            strSql.Append(" where AdReleaseID=@AdReleaseID");
            SqlParameter[] parameters = {
                    new SqlParameter("@AdReleaseID", SqlDbType.Int,4)
            };
            parameters[0].Value = AdReleaseID;


            BWJS.Model.AdRelease model = new BWJS.Model.AdRelease();
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
        public BWJS.Model.AdRelease DataRowToModel(DataRow row)
        {
            BWJS.Model.AdRelease model = new BWJS.Model.AdRelease();

            if (row != null)
            {
                if (row["AdReleaseID"].ToString() != "")
                {
                    model.AdReleaseID = int.Parse(row["AdReleaseID"].ToString());
                }
                model.Remark = row["Remark"].ToString();
                if (row["AdReleaseName"].ToString() != "")
                {
                    model.AdReleaseName = row["AdReleaseName"].ToString();
                }
                if (row["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(row["BeginTime"].ToString());
                }
                if (row["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(row["EndTime"].ToString());
                }
                if (row["ResourceID"].ToString() != "")
                {
                    model.ResourceID = int.Parse(row["ResourceID"].ToString());
                }
                if (row["CreatUserID"].ToString() != "")
                {
                    model.CreatUserID = int.Parse(row["CreatUserID"].ToString());
                }
                if (row["RecordUpdateUserID"].ToString() != "")
                {
                    model.RecordUpdateUserID = int.Parse(row["RecordUpdateUserID"].ToString());
                }
                if (row["RecordIsDelete"].ToString() != "")
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
                if (row["RecordUpdateTime"].ToString() != "")
                {
                    model.RecordUpdateTime = DateTime.Parse(row["RecordUpdateTime"].ToString());
                }
                if (row["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(row["RecordCreateTime"].ToString());
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
            strSql.Append(" FROM AdRelease ");
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
            strSql.Append(" FROM AdRelease ");
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
            tablesql.Append(" FROM AdRelease ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }
        #endregion

        #region ExtensionMethod

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateResourceID(AdRelease model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdRelease set ");
            strSql.Append(" ResourceID = @ResourceID , ");

            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");

            strSql.Append(" RecordUpdateTime = GetDate(), ");
            strSql.Append(" where AdReleaseID=@AdReleaseID");

            SqlParameter[] parameters = {
                        new SqlParameter("@AdReleaseID", model.AdReleaseID) ,
                        new SqlParameter("@ResourceID", model.ResourceID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID)
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
        public bool UpdateDelete(int AdReleaseID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdRelease set  RecordIsDelete =1  ");
            strSql.Append(" where AdReleaseID=@AdReleaseID and  RecordIsDelete =0; UPDATE AdPosition set AdReleaseID=null where AdReleaseID=@AdReleaseID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@AdReleaseID", SqlDbType.Int,4)
            };
            parameters[0].Value = AdReleaseID;


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
        public bool UpdateDeleteList(string AdReleaseIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdRelease set  RecordIsDelete =1   ");
            strSql.Append(" where AdReleaseID in (" + AdReleaseIDlist + ")  ");
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
        public AdReleaseBackup GetModelOne(int AdReleaseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select a.AdReleaseID,a.AdReleaseName, BeginTime, EndTime, a.ResourceID, a.CreatUserID, a.RecordUpdateUserID, a.RecordIsDelete, a.RecordUpdateTime, a.RecordCreateTime, a.Remark,r.FilePath,r.[FileName] ,ap.AdPositionID 
             from AdRelease a left join [Resource] r on a.ResourceID = r.ResourceID and r.RecordIsDelete = 0  
             LEFT JOIN dbo.AdPosition  ap ON ap.AdReleaseID=a.AdReleaseID AND ap.RecordIsDelete=0
                where a.AdReleaseID=@AdReleaseID");
            SqlParameter[] parameters = {
                    new SqlParameter("@AdReleaseID", SqlDbType.Int,4)
            };
            parameters[0].Value = AdReleaseID;
            AdReleaseBackup model = new AdReleaseBackup();
            DataSet ds = BWJSHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AdReleaseID"].ToString() != "")
                {
                    model.AdReleaseID = int.Parse(ds.Tables[0].Rows[0]["AdReleaseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AdReleaseName"].ToString() != "")
                {
                    model.AdReleaseName = ds.Tables[0].Rows[0]["AdReleaseName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                model.ResourceID = ds.Tables[0].Rows[0]["ResourceID"].ToInt();
                if (ds.Tables[0].Rows[0]["CreatUserID"].ToString() != "")
                {
                    model.CreatUserID = int.Parse(ds.Tables[0].Rows[0]["CreatUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString() != "")
                {
                    model.RecordUpdateUserID = int.Parse(ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordIsDelete"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["RecordIsDelete"].ToString() == "1") || (ds.Tables[0].Rows[0]["RecordIsDelete"].ToString().ToLower() == "true"))
                    {
                        model.RecordIsDelete = true;
                    }
                    else
                    {
                        model.RecordIsDelete = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString() != "")
                {
                    model.RecordUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordCreateTime"].ToString());
                }

                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.ResourceInfo = ds.Tables[0].Rows[0]["FilePath"].ToString();
                model.FileName = ds.Tables[0].Rows[0]["FileName"].ToString();
                model.AdPositionID = ds.Tables[0].Rows[0]["AdPositionID"].ToInt();
                return model;
            }
            else
            {
                return null;
            }
        }

        #region 获取广告

        /// <summary>
        /// 获取广告
        /// </summary>
        /// <returns></returns>

        public List<AdReleaseExpand> GetReleaseExpandList()
        {
            try
            {
                string strOrderBy = " ";
                string strOutFields = "a.*,b.[AdPositionID] PositionId,b.[Name] PositionName ";
                string strSelectFields = "a.*,b.[AdPositionID] PositionId,b.[Name] PositionName ";
                string strTable = @"[BWJSDB].[dbo].[AdRelease] a left join [BWJSDB].[dbo].[AdPosition] b on b.[AdReleaseID]=a.[AdReleaseID]";
                string strSql = "SELECT  " + strSelectFields + " FROM " + strTable + " WHERE  a.RecordIsDelete=0 ";
                string strWhere = "";
                strSql = strSql + strWhere;
                strSql = strSql + strOrderBy;
                SqlParameter[] parameters = new SqlParameter[]{
                // new SqlParameter ("@TypeID",TypeID)
               };
                List<AdReleaseExpand> list = SqlDataUtilityHelper.GetListFromDB<AdReleaseExpand>(strOutFields, ConnectionString, strSql, parameters);

                return list;
            }
            catch
            {

            }
            return null;
        }

        /// <summary>
        /// 获取广告
        /// </summary>
        /// <returns></returns>

        public DataTable GetReleaseExpandL(string where)
        {
            try
            {
                StringBuilder tablesql = new StringBuilder();
                tablesql.Append(@"select 
a.*,b.[AdPositionID] PositionId,b.[Name] PositionName  ,b.Sort
from [BWJSDB].[dbo].[AdRelease] a left join [BWJSDB].[dbo].[AdPosition] b on b.[AdReleaseID]=a.[AdReleaseID]  AND b.RecordIsDelete=0 ");
                if (!string.IsNullOrEmpty(where))
                {
                    tablesql.AppendFormat(" where {0} ", where);
                }
                return BWJSHelperSQL.ReturnDataTable(tablesql.ToString());
            }
            catch
            {

            }
            return null;
        }
        #endregion

        #endregion

    }
}

