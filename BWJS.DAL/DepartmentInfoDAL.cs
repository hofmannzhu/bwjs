using BWJS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityHelper;
using UtilityHelper.Data;

namespace BWJS.DAL
{

    /// <summary>
    /// 角色
    /// </summary>
    public partial class DepartmentInfoDAL : BaseService
    {
        public DepartmentInfoDAL() { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.DepartmentInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DepartmentInfo(");
            strSql.Append(@"DepartmentName
                                      , ParentID
                                      , DepartmentCode
                                      , Remark
                                      , IsReceiveBusiness
                                      , CreatedUser
                                      , RecordIsDelete
                                      , RecordCreateTime
                                      , RecordUpdateTime");
            strSql.Append(") values (");
            strSql.Append(@"@DepartmentName
                                      , @ParentID
                                      , @DepartmentCode
                                      , @Remark
                                      , @IsReceiveBusiness
                                      , @CreatedUser
                                      , @RecordIsDelete
                                      , @RecordCreateTime
                                      , @RecordUpdateTime");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                          new SqlParameter("@DepartmentName", model.DepartmentName) ,
                          new SqlParameter("@ParentID", model.ParentID) ,
                          new SqlParameter("@DepartmentCode", model.DepartmentCode) ,
                          new SqlParameter("@Remark", model.Remark) ,
                            new SqlParameter("@IsReceiveBusiness", model.IsReceiveBusiness) ,
                          new SqlParameter("@CreatedUser", model.CreatedUser) ,
                          new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                          new SqlParameter("@RecordCreateTime", model.RecordCreateTime) ,
                          new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) };


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
        public bool Update(BWJS.Model.DepartmentInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [DepartmentInfo] set ");

            strSql.Append(" DepartmentName = @DepartmentName , ");
            strSql.Append(" ParentID = @ParentID , ");
            strSql.Append(" DepartmentCode = @DepartmentCode , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" UpdateUser = @UpdateUser , ");
            strSql.Append(" IsReceiveBusiness = @IsReceiveBusiness , ");
            strSql.Append(" RecordIsDelete = @RecordIsDelete , ");
            strSql.Append(" RecordUpdateTime = @RecordUpdateTime  ");
            strSql.Append(" where DepartmentID=@DepartmentID ");
            SqlParameter[] parameters = {
                         new SqlParameter("@DepartmentID", model.DepartmentID) ,
                          new SqlParameter("@DepartmentName", model.DepartmentName) ,
                          new SqlParameter("@ParentID", model.ParentID) ,
                          new SqlParameter("@DepartmentCode", model.DepartmentCode) ,
                          new SqlParameter("@Remark", model.Remark) ,
                          new SqlParameter("@UpdateUser", model.UpdateUser) ,
                            new SqlParameter("@IsReceiveBusiness", model.IsReceiveBusiness) ,
                          new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                          new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) };

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
        public bool Delete(int DepartmentID,int EditId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DepartmentInfo set RecordIsDelete=1,EditDate=GETDATE(),EditId=@EditId");
            strSql.Append(" where DepartmentID=@DepartmentID");
            SqlParameter[] parameters = {
                    new SqlParameter("@DepartmentID", SqlDbType.Int,4),
                     new SqlParameter("@EditId", SqlDbType.Int,4)
            };
            parameters[0].Value = DepartmentID;
            parameters[1].Value = EditId;

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
        public bool DeleteList(string DepartmentIDlist,int EditId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DepartmentInfo set IsDeleted=1,EditDate=GETDATE(),EditId="+ EditId + "");
            strSql.Append(" where ID in (" + DepartmentIDlist + ")  ");
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
        public BWJS.Model.DepartmentInfo GetModel(int DepartmentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  DepartmentID
                                                  , DepartmentName
                                                  , ParentID
                                                  , IsReceiveBusiness
                                                  , DepartmentCode
                                                  , Remark
                                                  , UpdateUser
                                                  , CreatedUser
                                                  , RecordIsDelete
                                                  , RecordCreateTime
                                                  , RecordUpdateTime ");
            strSql.Append("  from DepartmentInfo ");
            strSql.Append(" where DepartmentID=@DepartmentID");
            SqlParameter[] parameters = {
                    new SqlParameter("@DepartmentID", SqlDbType.Int,4)
            };
            parameters[0].Value = DepartmentID;


            BWJS.Model.DepartmentInfo model = new BWJS.Model.DepartmentInfo();
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
        public BWJS.Model.DepartmentInfo DataRowToModel(DataRow row)
        {
            BWJS.Model.DepartmentInfo model = new BWJS.Model.DepartmentInfo();
            if (row != null)
            {
                if (row["DepartmentID"].ToString() != "")
                {
                    model.DepartmentID = int.Parse(row["DepartmentID"].ToString());
                }
                if (row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
                }
                model.DepartmentCode = row["DepartmentCode"].ToString();

                model.Remark = row["Remark"].ToString();

                model.DepartmentName = row["DepartmentName"].ToString();


                if (row["CreatedUser"].ToString() != "")
                {
                    model.CreatedUser = int.Parse(row["CreatedUser"].ToString());
                }

                if (row["RecordIsDelete"].ToString() != "" && (row["RecordIsDelete"].ToString().ToLower() == "false"))
                {
                    model.RecordIsDelete = false;
                }
                else {
                    model.RecordIsDelete = true;
                }
                if (row["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(row["RecordCreateTime"].ToString());
                }
                if (row["RecordUpdateTime"].ToString() != "")
                {
                    model.RecordUpdateTime = DateTime.Parse(row["RecordUpdateTime"].ToString());
                }
                if (row["IsReceiveBusiness"].ToString() != "" && row["IsReceiveBusiness"].ToString().ToLower() == "true")
                {
                    model.IsReceiveBusiness = true;
                }
                else {
                    model.IsReceiveBusiness = false;
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
            strSql.Append(" FROM [DepartmentInfo] ");
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
            strSql.Append(" FROM DepartmentInfo ");
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
            tablesql.Append(@"select r.*,r1.DepartmentName as ParentDepartmentInfoName  FROM [DepartmentInfo] 
r left join [DepartmentInfo] r1 on r.ParentId=r1.DepartmentID and r1.RecordIsDelete=0");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }
        #endregion

        #region ExtensionMethod


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DepartmentInfo GetDepartmentInfoOne(int DepartmentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT   [DepartmentID]
                                          ,[DepartmentName]
                                          ,[ParentID]
                                          ,[DepartmentCode]
                                          ,[Remark]
                                          ,[IsReceiveBusiness]
                                          ,[CreatedUser]
                                          ,[RecordIsDelete]
                                          ,[RecordCreateTime]
                                          ,[RecordUpdateTime] FROM  [DepartmentInfo] WHERE RecordIsDelete=0 and DepartmentID=@DepartmentID");
            SqlParameter[] parameters = {
                    new SqlParameter("@DepartmentID", SqlDbType.Int,4)
            };
            parameters[0].Value = DepartmentID;
            DepartmentInfo model = new DepartmentInfo();
            DataSet ds = BWJSHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["DepartmentID"].ToString() != "")
                {
                    model.DepartmentID = int.Parse(ds.Tables[0].Rows[0]["DepartmentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DepartmentName"].ToString() != "")
                {
                    model.DepartmentName = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = ds.Tables[0].Rows[0]["ParentID"].ToString().ToInt();
                }
                if (ds.Tables[0].Rows[0]["DepartmentCode"].ToString() != "")
                {
                    model.DepartmentCode = ds.Tables[0].Rows[0]["DepartmentCode"].ToString().ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedUser"].ToString() != "")
                {
                    model.CreatedUser = int.Parse(ds.Tables[0].Rows[0]["CreatedUser"].ToString());
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
                if (ds.Tables[0].Rows[0]["IsReceiveBusiness"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsReceiveBusiness"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsReceiveBusiness"].ToString().ToLower() == "true"))
                    {
                        model.IsReceiveBusiness = true;
                    }
                    else
                    {
                        model.IsReceiveBusiness = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordCreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString() != "")
                {
                    model.RecordUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool UpdateDelete(int DepartmentID,int EditId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update  [DepartmentInfo]  set RecordIsDelete=1,EditDate=GETDATE(),EditId=@EditId ");
            strSql.Append(" where DepartmentID=@DepartmentID;UPDATE dbo.Users SET DepartmentID=0 WHERE DepartmentID=@DepartmentID  AND IsDeleted=0;");
            SqlParameter[] parameters = {
                    new SqlParameter("@DepartmentID", DepartmentID),
                     new SqlParameter("@EditId", EditId)
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetParentNameList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select r.*,r1.DepartmentName as ParentDepartmentInfoName  FROM [DepartmentInfo] 
r left join [DepartmentInfo] r1 on r.ParentId=r1.DepartmentID and r1.RecordIsDelete=0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获取当前部门下的授权功能
        /// </summary>
        /// <param name="DepartmentID">部门ID</param>
        /// <param name=""></param>
        /// <returns></returns>
        public List<DepartmentInfo> GetDepartmentInfolist(int ParentID, int RecordIsDelete)
        {
            string selectFields = @" CreatedUser ,
                                                DepartmentCode ,
                                                DepartmentID ,
                                                DepartmentName ,
                                                IsReceiveBusiness ,
                                                ParentID ,
                                                RecordCreateTime ,
                                                RecordIsDelete ,
                                                RecordUpdateTime ,
                                                Remark ,
                                                UpdateUser";
            string strSql = "Select " + selectFields + " from DepartmentInfo where  ParentID  = "+ ParentID + "  and RecordIsDelete = " + RecordIsDelete + "";
            List<DepartmentInfo> dataList = SqlDataUtilityHelper.GetListFromDB<DepartmentInfo>(selectFields, this.ConnectionString, strSql, null);
            return dataList;
        }

        #endregion
    }
}
