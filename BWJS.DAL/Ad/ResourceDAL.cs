using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using BWJS.Model;

namespace BWJS.DAL.Ad
{
    //资源表
    public partial class ResourceDAL : BaseService
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Resource model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Resource(");
            strSql.Append("ResourceName,FileName,VirtualPath,FilePath,FileSuffix,MD5,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordUpdateTime,RecordCreateTime");
            strSql.Append(") values (");
            strSql.Append("@ResourceName,@FileName,@VirtualPath,@FilePath,@FileSuffix,Upper(RIGHT(sys.fn_varbintohexstr(HASHBYTES('MD5',@FilePath)),32)),@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,GetDate(),GetDate()");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@ResourceName", model.ResourceName) ,
                        new SqlParameter("@FileName", model.FileName) ,
                        new SqlParameter("@VirtualPath", model.VirtualPath) ,
                        new SqlParameter("@FilePath", model.FilePath) ,
                        new SqlParameter("@FileSuffix", model.FileSuffix),
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete)

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
        public bool Update(Resource model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Resource set ");
            strSql.Append(" ResourceName = @ResourceName , ");
            strSql.Append(" FileName = @FileName , ");
            strSql.Append(" VirtualPath = @VirtualPath , ");
            strSql.Append(" FilePath = @FilePath , ");
            strSql.Append(" FileSuffix = @FileSuffix , ");
            strSql.Append(" MD5 = @MD5 , ");

            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");

            strSql.Append(" RecordUpdateTime = GetDate() ");


            strSql.Append(" where ResourceID=@ResourceID  and RecordUpdateTime = @RecordUpdateTime");

            SqlParameter[] parameters = {
                        new SqlParameter("@ResourceID", model.ResourceID) ,
                        new SqlParameter("@ResourceName", model.ResourceName) ,
                        new SqlParameter("@FileName", model.FileName) ,
                        new SqlParameter("@VirtualPath", model.VirtualPath) ,
                        new SqlParameter("@FilePath", model.FilePath) ,
                        new SqlParameter("@FileSuffix", model.FileSuffix) ,
                        new SqlParameter("@MD5", model.MD5) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime)


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
        public bool UpdateDelete(int ResourceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update from Resource set  RecordIsDelete=1 ");
            strSql.Append(" where ResourceID=@ResourceID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ResourceID", SqlDbType.Int,4)
            };
            parameters[0].Value = ResourceID;


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
        public bool UpdateDeleteList(string ResourceIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update from Resource set  RecordIsDelete=1");
            strSql.Append(" where ResourceID in (" + ResourceIDlist + ")  ");
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
        public Resource GetModel(int ResourceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ResourceID, ResourceName, FileName, VirtualPath, FilePath, FileSuffix, MD5, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime, RecordCreateTime  ");
            strSql.Append("  from Resource ");
            strSql.Append(" where ResourceID=@ResourceID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ResourceID", SqlDbType.Int,4)
            };
            parameters[0].Value = ResourceID;


            Resource model = new Resource();
            DataSet ds = BWJSHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ResourceID"].ToString() != "")
                {
                    model.ResourceID = int.Parse(ds.Tables[0].Rows[0]["ResourceID"].ToString());
                }
                model.ResourceName = ds.Tables[0].Rows[0]["ResourceName"].ToString();
                model.FileName = ds.Tables[0].Rows[0]["FileName"].ToString();
                model.VirtualPath = ds.Tables[0].Rows[0]["VirtualPath"].ToString();
                model.FilePath = ds.Tables[0].Rows[0]["FilePath"].ToString();
                model.FileSuffix = ds.Tables[0].Rows[0]["FileSuffix"].ToString();
                model.MD5 = ds.Tables[0].Rows[0]["MD5"].ToString();
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
            strSql.Append(" FROM Resource ");
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
            strSql.Append(" FROM Resource ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSHelperSQL.Query(strSql.ToString());
        }


    }
}

