using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using BWJS.Model;
using BWJS.Model.OutputModel;
using UtilityHelper.Data;
using BWJS.Model.InputModel;
using BWJS.Model.Model;

namespace BWJS.DAL.Ad
{
    //广告位表
    public partial class AdPositionDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.AdPosition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[AdPosition](");
            strSql.Append("RecordUpdateTime,RecordCreateTime,Name,Sort,DefaultPicUrl,TypeId,AdReleaseID,CreatUserID,RecordUpdateUserID,RecordIsDelete");
            strSql.Append(") values (");
            strSql.Append("@RecordUpdateTime,@RecordCreateTime,@Name,@Sort,@DefaultPicUrl,@TypeId,@AdReleaseID,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime) ,
                        new SqlParameter("@Name", model.Name) ,
                        new SqlParameter("@Sort", model.Sort) ,
                        new SqlParameter("@DefaultPicUrl", model.DefaultPicUrl) ,
                        new SqlParameter("@TypeId", model.TypeId) ,
                        new SqlParameter("@AdReleaseID", model.AdReleaseID) ,
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete)

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
        public bool Update(BWJS.Model.AdPosition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[AdPosition] set ");

            strSql.Append(" RecordUpdateTime = @RecordUpdateTime , ");
            strSql.Append(" RecordCreateTime = @RecordCreateTime , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Sort = @Sort , ");
            strSql.Append(" DefaultPicUrl = @DefaultPicUrl , ");
            strSql.Append(" TypeId = @TypeId , ");
            strSql.Append(" AdReleaseID = @AdReleaseID , ");
            strSql.Append(" CreatUserID = @CreatUserID , ");
            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");
            strSql.Append(" RecordIsDelete = @RecordIsDelete  ");
            strSql.Append(" where AdPositionID=@AdPositionID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@AdPositionID",model.AdPositionID) ,
                        new SqlParameter("@RecordUpdateTime",model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime",model.RecordCreateTime) ,
                        new SqlParameter("@Name",model.Name) ,
                        new SqlParameter("@Sort",model.Sort) ,
                        new SqlParameter("@DefaultPicUrl",model.DefaultPicUrl) ,
                        new SqlParameter("@TypeId",model.TypeId) ,
                        new SqlParameter("@AdReleaseID",model.AdReleaseID) ,
                        new SqlParameter("@CreatUserID",model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID",model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete",model.RecordIsDelete)

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
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.AdPosition GetModel(int AdPositionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AdPositionID, RecordUpdateTime, RecordCreateTime, Name, Sort, DefaultPicUrl, TypeId, AdReleaseID, CreatUserID, RecordUpdateUserID, RecordIsDelete  ");
            strSql.Append("  from dbo.[AdPosition] ");
            strSql.Append(" where AdPositionID=@AdPositionID");
            SqlParameter[] parameters = {
                    new SqlParameter("@AdPositionID", SqlDbType.Int,4)
            };
            parameters[0].Value = AdPositionID;


            BWJS.Model.AdPosition model = new BWJS.Model.AdPosition();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

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
        public BWJS.Model.AdPosition DataRowToModel(DataRow row)
        {
            BWJS.Model.AdPosition model = new BWJS.Model.AdPosition();

            if (row != null)
            {
                if (row["AdPositionID"].ToString() != "")
                {
                    model.AdPositionID = int.Parse(row["AdPositionID"].ToString());
                }
                if (row["RecordUpdateTime"].ToString() != "")
                {
                    model.RecordUpdateTime = DateTime.Parse(row["RecordUpdateTime"].ToString());
                }
                if (row["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(row["RecordCreateTime"].ToString());
                }
                model.Name = row["Name"].ToString();
                if (row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
                }
                model.DefaultPicUrl = row["DefaultPicUrl"].ToString();
                if (row["TypeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(row["TypeId"].ToString());
                }
                if (row["AdReleaseID"].ToString() != "")
                {
                    model.AdReleaseID = int.Parse(row["AdReleaseID"].ToString());
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
            strSql.Append(" FROM dbo.[AdPosition] ");
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
            strSql.Append(" FROM dbo.[AdPosition] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region ExtensionMethod

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AdPositionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdPosition set IsDeleted=1");
            strSql.Append(" where AdPositionID=@AdPositionID");
            SqlParameter[] parameters = {
                    new SqlParameter("@AdPositionID", SqlDbType.Int,4)
            };
            parameters[0].Value = AdPositionID;


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
        public bool DeleteList(string AdPositionIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdPosition set IsDeleted=1");
            strSql.Append(" where ID in (" + AdPositionIDlist + ")  ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AdPositionID, int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[AdPosition] set IsDeleted=1,EditId=@EditId,EditDate=@EditDate");
            strSql.Append(" where AdPositionID=@AdPositionID");
            SqlParameter[] parameters = {
                    new SqlParameter("@EditId", userId),
                    new SqlParameter("@EditDate", DateTime.Now),
                    new SqlParameter("@AdPositionID", AdPositionID),
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string AdPositionIDlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.[AdPosition] set IsDeleted=1,EditId={0},EditDate='{1}'", userId, DateTime.Now);
            strSql.Append(" where AdPositionID in (" + AdPositionIDlist + ")  ");
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
            return DbHelperSQL.GetPageList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
            tablesql.Append(" FROM dbo.[AdPosition] ");
            return DbHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }
        
        public bool BackUpdate(int AdReleaseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE AdPosition SET AdReleaseID=0 WHERE AdReleaseID=@AdReleaseID   AND RecordIsDelete=0 ");

            SqlParameter[] parameters = {
                    new SqlParameter("@AdReleaseID", SqlDbType.Int,4)
            };
            parameters[0].Value = AdReleaseID;

            return BWJSHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool ChangeSort(int AdPositionID, int Sort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE AdPosition SET Sort=@Sort,RecordUpdateTime=GETDATE(),RecordUpdateUserID=1 WHERE AdPositionID=@AdPositionID AND RecordIsDelete=0 ");
            SqlParameter[] parameters = {
                        new SqlParameter("@Sort", Sort) ,
                        new SqlParameter("@AdPositionID", AdPositionID)
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
        /// 广告位绑定广告
        /// </summary>
        public bool UpdateAdReleaseID(int AdReleaseID, int AdPositionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE AdPosition SET AdReleaseID=@AdReleaseID ,RecordUpdateUserID=1,RecordUpdateTime=GETDATE() WHERE AdPositionID=@AdPositionID AND RecordIsDelete=0 ");
            SqlParameter[] parameters = {
                        new SqlParameter("@AdReleaseID", AdReleaseID) ,
                        new SqlParameter("@AdPositionID", AdPositionID)
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
        public bool UpdateDelete(int AdPositionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update  AdPosition  set RecordIsDelete=1 ");
            strSql.Append(" where AdPositionID=@AdPositionID");
            SqlParameter[] parameters = {
                    new SqlParameter("@AdPositionID", AdPositionID)
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
        /// 批量删除一批数据
        /// </summary>
        public bool UpdateDeleteList(string AdPositionIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update  AdPosition  set RecordIsDelete=1 ");
            strSql.Append(" where AdPositionID in (" + AdPositionIDlist + ")  ");
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

        public int GetMaxSort()
        {

            string strSql = "SELECT TOP 1 Sort FROM dbo.AdPosition WHERE RecordIsDelete=0 ORDER BY Sort desc";
            SqlParameter[] parameters = null;
            object obj = BWJSHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj) + 1;
            }
        }

        public AdPosition GetAdPositionOne(int AdPositionID)
        {
            try
            {
                string outFields = "AdPositionID, Name, Sort, DefaultPicUrl, AdReleaseID, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime, RecordCreateTime ";
                string strSelectFields = "AdPositionID, Name, Sort, DefaultPicUrl, AdReleaseID, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime, RecordCreateTime ";
                string strSql = "Select top 1 " + strSelectFields + " from  AdPosition where RecordIsDelete=0  and AdPositionID=@AdPositionID ";
                SqlParameter[] parameters = new SqlParameter[]{
                     new SqlParameter ("@AdPositionID",AdPositionID)
               };
                var result = SqlDataUtilityHelper.GetObjectFromDB<AdPosition>(outFields.Split(','), this.ConnectionString, strSql, parameters);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch
            {

            }

            return null;

        }

        public List<AdPostionReleaseOutputModel> GetAdPostionReleaseList(AdPostionReleaseOutputModel AdPostionReleaseIutputModel)
        {
            try
            {
                string strOrderBy = " ";
                string strOutFields = "DefaultPicUrl, FileName, VirtualPath ,FileSuffix";
                string strSelectFields = "AP.DefaultPicUrl, R.FileName, R.VirtualPath , R.FileSuffix";
                string strTable = @"AdPosition AP
                    Left join  AdRelease AR on AR.AdReleaseID = AP.AdReleaseID and AR.RecordIsDelete = 0
                    Left join  Resource R on R.ResourceID = AR.ResourceID and R.RecordIsDelete = 0";
                string strSql = "SELECT  " + strSelectFields + " FROM " + strTable + " WHERE  AP.RecordIsDelete= 0   ";
                string strWhere = "";
                strSql = strSql + strWhere;
                strSql = strSql + strOrderBy;
                SqlParameter[] parameters = new SqlParameter[]{
                // new SqlParameter ("@TypeID",TypeID)
               };
                List<AdPostionReleaseOutputModel> list = SqlDataUtilityHelper.GetListFromDB<AdPostionReleaseOutputModel>(strOutFields, ConnectionString, strSql, parameters);

                return list;
            }
            catch
            {

            }
            return null;
        }
        public DataPager<AdPosition> GetAdPositionList(AdPosition model, int pageNo, int pageSize)
        {
            string rowNumberOrderby = "AdPositionID asc";
            StringBuilder strWhere = new StringBuilder("");
            strWhere.Append("1=1");

            var selectFields = "AdPositionID, Name, Sort, DefaultPicUrl, AdReleaseID, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime, RecordCreateTime ";
            var outFields = "AdPositionID, Name, Sort, DefaultPicUrl, AdReleaseID, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime, RecordCreateTime ";
            var tableName = @"AdPosition    ";
            var dataPager = SqlDataUtilityHelper.GetDataToPager<AdPosition>(outFields, selectFields, tableName, rowNumberOrderby, this.ConnectionString, strWhere.ToString(), null, pageNo, pageSize);
            return dataPager;

        }

        public int VerificationIsName(string Name, int AdPositionID)
        {
            int result = -1;
            try
            {
                string sql = "SELECT TOP 1 AdPositionID FROM  dbo.AdPosition WHERE RecordIsDelete=0 AND Name=@Name and AdPositionID<>@AdPositionID";
                IEnumerable<SqlParameter> parameters = new SqlParameter[] {
                                                           new SqlParameter ("@Name",Name),
                                                           new SqlParameter ("@AdPositionID",AdPositionID)
                                                                            };
                result = SqlDataUtilityHelper.ExecuteScalar(this.ConnectionString, sql.ToString(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetNameList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ap.*,are.AdReleaseName  FROM dbo.AdPosition ap LEFT JOIN dbo.AdRelease are ON are.AdReleaseID=ap.AdReleaseID AND are.RecordIsDelete=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// datarow转成对象实体
        /// </summary>
        public AdPositionBackups DataRowNameToModel(DataRow row)
        {
            AdPositionBackups model = new AdPositionBackups();

            if (row != null)
            {
                if (row["AdPositionID"].ToString() != "")
                {
                    model.AdPositionID = int.Parse(row["AdPositionID"].ToString());
                }
                if (row["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(row["RecordCreateTime"].ToString());
                }
                if (row["AdReleaseName"].ToString() != "")
                {
                    model.AdReleaseName = row["AdReleaseName"].ToString();
                }
                model.Name = row["Name"].ToString();
                if (row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
                }
                if (row["TypeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(row["TypeId"].ToString());
                }
                model.DefaultPicUrl = row["DefaultPicUrl"].ToString();
                if (row["AdReleaseID"].ToString() != "")
                {
                    model.AdReleaseID = int.Parse(row["AdReleaseID"].ToString());
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

                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion

    }
}

