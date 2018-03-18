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
    /// 区域
    /// </summary>
    public partial class RegionDAL : BaseService
    {
        public RegionDAL() { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.Region model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Region(");
            strSql.Append("EditDate,IsDeleted,Remark,ReginName,ReginCode,ParentId,RegionDir,RegionStatus,CreateId,CreateDate,EditId");
            strSql.Append(") values (");
            strSql.Append("@EditDate,@IsDeleted,@Remark,@ReginName,@ReginCode,@ParentId,@RegionDir,@RegionStatus,@CreateId,@CreateDate,@EditId");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@ReginName", model.ReginName) ,
                        new SqlParameter("@ReginCode", model.ReginCode) ,
                        new SqlParameter("@ParentId", model.ParentId) ,
                        new SqlParameter("@RegionDir", model.RegionDir) ,
                        new SqlParameter("@RegionStatus", model.RegionStatus) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId)

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
        public bool Update(BWJS.Model.Region model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Region set ");

            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" ReginName = @ReginName , ");
            strSql.Append(" ReginCode = @ReginCode , ");
            strSql.Append(" ParentId = @ParentId , ");
            strSql.Append(" RegionDir = @RegionDir , ");
            strSql.Append(" RegionStatus = @RegionStatus , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId  ");
            strSql.Append(" where RegionId=@RegionId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@RegionId",model.RegionId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@ReginName",model.ReginName) ,
                        new SqlParameter("@ReginCode",model.ReginCode) ,
                        new SqlParameter("@ParentId",model.ParentId) ,
                        new SqlParameter("@RegionDir",model.RegionDir) ,
                        new SqlParameter("@RegionStatus",model.RegionStatus) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@EditId",model.EditId)

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
        public bool Delete(int RegionId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Region set IsDeleted=1");
            strSql.Append(" where RegionId=@RegionId");
            SqlParameter[] parameters = {
                    new SqlParameter("@RegionId", SqlDbType.Int,4)
            };
            parameters[0].Value = RegionId;


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
        public bool DeleteList(string RegionIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Region set IsDeleted=1");
            strSql.Append(" where ID in (" + RegionIdlist + ")  ");
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
        public BWJS.Model.Region GetModel(int RegionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RegionId, EditDate, IsDeleted, Remark, ReginName, ReginCode, ParentId, RegionDir, RegionStatus, CreateId, CreateDate, EditId  ");
            strSql.Append("  from Region ");
            strSql.Append(" where RegionId=@RegionId");
            SqlParameter[] parameters = {
                    new SqlParameter("@RegionId", SqlDbType.Int,4)
            };
            parameters[0].Value = RegionId;


            BWJS.Model.Region model = new BWJS.Model.Region();
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
        public BWJS.Model.Region DataRowToModel(DataRow row)
        {
            BWJS.Model.Region model = new BWJS.Model.Region();

            if (row != null)
            {
                if (row["RegionId"].ToString() != "")
                {
                    model.RegionId = int.Parse(row["RegionId"].ToString());
                }
                if (row["EditDate"].ToString() != "")
                {
                    model.EditDate = DateTime.Parse(row["EditDate"].ToString());
                }
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                model.Remark = row["Remark"].ToString();
                model.ReginName = row["ReginName"].ToString();
                model.ReginCode = row["ReginCode"].ToString();
                if (row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                model.RegionDir = row["RegionDir"].ToString();
                if (row["RegionStatus"].ToString() != "")
                {
                    model.RegionStatus = int.Parse(row["RegionStatus"].ToString());
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
            strSql.Append(" FROM Region ");
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
            strSql.Append(" FROM Region ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
