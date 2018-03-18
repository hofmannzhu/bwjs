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
    /// 功能菜单
    /// </summary>
    public partial class FunctionDAL : BaseService
    {
        public FunctionDAL() { }

        #region BasicMethod 
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.Function model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Function](");
            strSql.Append("Status,OrderId,CreateId,CreateDate,EditId,EditDate,IsDeleted,Remark,FunctionName,FunctionCode,FunctionIcon,FunctionClass,ClassId,ParentId,ExternalLinkAddress,FunctionDir");
            strSql.Append(") values (");
            strSql.Append("@Status,@OrderId,@CreateId,@CreateDate,@EditId,@EditDate,@IsDeleted,@Remark,@FunctionName,@FunctionCode,@FunctionIcon,@FunctionClass,@ClassId,@ParentId,@ExternalLinkAddress,@FunctionDir");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@Status", model.Status) ,
                        new SqlParameter("@OrderId", model.OrderId) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@FunctionName", model.FunctionName) ,
                        new SqlParameter("@FunctionCode", model.FunctionCode) ,
                        new SqlParameter("@FunctionIcon", model.FunctionIcon) ,
                        new SqlParameter("@FunctionClass", model.FunctionClass) ,
                        new SqlParameter("@ClassId", model.ClassId) ,
                        new SqlParameter("@ParentId", model.ParentId) ,
                        new SqlParameter("@ExternalLinkAddress", model.ExternalLinkAddress) ,
                        new SqlParameter("@FunctionDir", model.FunctionDir) 
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
        public bool Update(BWJS.Model.Function model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Function] set "); 
            strSql.Append(" Status = @Status , ");
            strSql.Append(" OrderId = @OrderId , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" FunctionName = @FunctionName , ");
            strSql.Append(" FunctionCode = @FunctionCode , ");
            strSql.Append(" FunctionIcon = @FunctionIcon , ");
            strSql.Append(" FunctionClass = @FunctionClass , ");
            strSql.Append(" ClassId = @ClassId , ");
            strSql.Append(" ParentId = @ParentId , ");
            strSql.Append(" ExternalLinkAddress = @ExternalLinkAddress , ");
            strSql.Append(" FunctionDir = @FunctionDir  ");
            strSql.Append(" where FunctionId=@FunctionId "); 
            SqlParameter[] parameters = {
                        new SqlParameter("@FunctionId",model.FunctionId) ,
                        new SqlParameter("@Status",model.Status) ,
                        new SqlParameter("@OrderId",model.OrderId) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@FunctionName",model.FunctionName) ,
                        new SqlParameter("@FunctionCode",model.FunctionCode) ,
                        new SqlParameter("@FunctionIcon",model.FunctionIcon) ,
                        new SqlParameter("@FunctionClass",model.FunctionClass) ,
                        new SqlParameter("@ClassId",model.ClassId) ,
                        new SqlParameter("@ParentId",model.ParentId) ,
                        new SqlParameter("@ExternalLinkAddress",model.ExternalLinkAddress) ,
                        new SqlParameter("@FunctionDir",model.FunctionDir) 
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
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.Function GetModel(int FunctionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FunctionId, Status, OrderId, CreateId, CreateDate, EditId, EditDate, IsDeleted, Remark, FunctionName, FunctionCode, FunctionIcon, FunctionClass, ClassId, ParentId, ExternalLinkAddress, FunctionDir  ");
            strSql.Append("  from [Function] ");
            strSql.Append(" where FunctionId=@FunctionId");
            SqlParameter[] parameters = {
                    new SqlParameter("@FunctionId", SqlDbType.Int,4)
            };
            parameters[0].Value = FunctionId;


            BWJS.Model.Function model = new BWJS.Model.Function();
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
        public BWJS.Model.Function DataRowToModel(DataRow row)
        {
            BWJS.Model.Function model = new BWJS.Model.Function();

            if (row != null)
            {
                if (row["FunctionId"].ToString() != "")
                {
                    model.FunctionId = int.Parse(row["FunctionId"].ToString());
                }
                if (row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["OrderId"].ToString() != "")
                {
                    model.OrderId = int.Parse(row["OrderId"].ToString());
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
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                model.Remark = row["Remark"].ToString();
                model.FunctionName = row["FunctionName"].ToString();
                model.FunctionCode = row["FunctionCode"].ToString();
                model.FunctionIcon = row["FunctionIcon"].ToString();
                model.FunctionClass = row["FunctionClass"].ToString();
                if (row["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(row["ClassId"].ToString());
                }
                if (row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                model.ExternalLinkAddress = row["ExternalLinkAddress"].ToString();
                model.FunctionDir = row["FunctionDir"].ToString();

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
        //public DataSet GetAllList()
        //{
        //    return GetList("");
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [Function] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
        //public DataTable GetList(string tablesql, string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        //{
        //    return BWJSHelperSQL.GetPageList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        //}

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
            tablesql.Append("SELECT f.*,f2.FunctionName AS ParentName,u.UserName  AS lastName   FROM  dbo.[Function] f LEFT JOIN dbo.[Function] f2 ON f.ParentId=f2.FunctionId AND f2.IsDeleted=0    LEFT JOIN dbo.Users u ON u.UserID=f.EditId  ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        /// <summary>
        /// 获取最大排序编号加1
        /// </summary>
        /// <returns></returns>
        public int GetMaxOrderId()
        {
            int maxOrderId = 1;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select max(OrderId)+1 from [Function]");

                DataTable dt = BWJSHelperSQL.ReturnDataTable(strSql.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    maxOrderId = Convert.ToInt32(dt.Rows[0][0]);
                }
            }
            catch { }
            return maxOrderId;
        }

        public int VerificationIsFunName(string FunctionName, int FunctionId)
        {
            int result = -1;
            try
            {
                string sql = "SELECT TOP 1 FunctionId FROM dbo.[Function] WHERE IsDeleted=0 AND FunctionId=@FunctionId  AND FunctionName=@FunctionName ";
                IEnumerable<SqlParameter> parameters = new SqlParameter[] {
                                                           new SqlParameter ("@FunctionName",FunctionName),
                                                           new SqlParameter ("@FunctionId",FunctionId)
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
        /// 获取当前部门下的授权功能
        /// </summary>
        /// <param name="DepartmentID">部门ID</param>
        /// <param name=""></param>
        /// <returns></returns>
        public List<Function> GetFuctionDepartmentExtentList()
        {

            string selectFields = @"   ClassId ,
        CreateDate ,
        CreateId ,
        EditDate ,
        EditId ,
        ExternalLinkAddress ,
        FunctionClass ,
        FunctionCode ,
        FunctionDir ,
        FunctionIcon ,
        FunctionId ,
        FunctionName ,
        IsDeleted ,
        ParentId ,
        Remark ,
        Status ";
            string strSql = @"SELECT    ClassId ,
        CreateDate ,
        CreateId ,
        EditDate ,
        EditId ,
        ExternalLinkAddress ,
        FunctionClass ,
        FunctionCode ,
        FunctionDir ,
        FunctionIcon ,
        FunctionId ,
        FunctionName ,
        IsDeleted ,
        ParentId ,
        Remark ,
        Status 
                                        FROM  [Function] 
                                        WHERE IsDeleted=0  ";
            List<Function> dataList = SqlDataUtilityHelper.GetListFromDB<Function>(selectFields, this.ConnectionString, strSql, null);
            return dataList;

        }


        public List<Function> GetFunctionInfolist(int ParentId)
        {
            string selectFields = @"ClassId ,
        CreateDate ,
        CreateId ,
        EditDate ,
        EditId ,
        ExternalLinkAddress ,
        FunctionClass ,
        FunctionCode ,
        FunctionDir ,
        FunctionIcon ,
        FunctionId ,
        FunctionName ,
        IsDeleted ,
        ParentId ,
        Remark ,
        Status ";
            string strSql = @"select ClassId ,
        CreateDate ,
        CreateId ,
        EditDate ,
        EditId ,
        ExternalLinkAddress ,
        FunctionClass ,
        FunctionCode ,
        FunctionDir ,
        FunctionIcon ,
        FunctionId ,
        FunctionName ,
        IsDeleted ,
        ParentId ,
        Remark ,
        Status from  [Function]  Where  IsDeleted=0 And ParentId=@ParentId ";
            List<Function> dataList = SqlDataUtilityHelper.GetListFromDB<Function>(selectFields, this.ConnectionString, strSql, new[] { new SqlParameter("@ParentId", ParentId) });
            return dataList;


        }


        //public Function GetFunctionInfoOne(int FunctionId)
        //{
        //    Function item = null;
        //    try
        //    {

        //        string strSelectFields = @"ClassId ,
        //CreateDate ,
        //CreateId ,
        //EditDate ,
        //EditId ,
        //ExternalLinkAddress ,
        //FunctionClass ,
        //FunctionCode ,
        //FunctionDir ,
        //FunctionIcon ,
        //FunctionId ,
        //FunctionName ,
        //IsDeleted ,
        //ParentId ,
        //Remark ,
        //Status ";
        //        string strSql = @"Select ClassId ,
        //CreateDate ,
        //CreateId ,
        //EditDate ,
        //EditId ,
        //ExternalLinkAddress ,
        //FunctionClass ,
        //FunctionCode ,
        //FunctionDir ,
        //FunctionIcon ,
        //FunctionId ,
        //FunctionName ,
        //IsDeleted ,
        //ParentId ,
        //Remark ,
        //Status from [Function] where  FunctionId  = @FunctionId ";
        //        SqlParameter[] parameters = new SqlParameter[]{
        //         new SqlParameter ("@FunctionId",FunctionId)
        //       };
        //        Function obj = SqlDataUtilityHelper.GetObjectFromDB<Function>(strSelectFields.Split(','), this.ConnectionString, strSql, parameters);
        //        if (obj != null)
        //        {
        //            return obj;
        //        }
        //        else
        //        {
        //            return null;
        //        }


        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return item;
        //}

        //public string GetFunctionName(int FunctionID, int RecordIsDelete)
        //{
        //    try
        //    {
        //        string strSql = "Select FunctionName from FunctionInfo where  FunctionID  =@FunctionID  And RecordIsDelete = @RecordIsDelete";
        //        SqlParameter[] parameters = new SqlParameter[] {
        //            new SqlParameter("@FunctionID", FunctionID),
        //            new SqlParameter("@RecordIsDelete", RecordIsDelete)

        //        };
        //        object obj = SqlDataUtilityHelper.ExecuteScalar(this.ConnectionString, strSql, parameters);
        //        if (obj != null)
        //        {
        //            return (string)obj;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return null;
        //}


        public bool soleFunctionCode(string RandomCode, int RecordIsDelete)
        {
            int result = -1;
            try
            {
                string sql = "SELECT COUNT(*) from [Function] where FunctionCode=@FunctionCode  And IsDeleted =@IsDeleted ";
                IEnumerable<SqlParameter> parameters = new SqlParameter[] {
                                                          new SqlParameter ("@FunctionCode",RandomCode),
                                                           new SqlParameter ("@IsDeleted",RecordIsDelete)
                                                         };
                object obj = SqlDataUtilityHelper.ExecuteScalar(this.ConnectionString, sql, parameters.ToArray());
                //如果执行正确并且受影响行数大于1的话，正确。编辑的状态下，有且仅有一条FunctionCode
                if (obj != null && ((int)obj) > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

            }
            return result > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool UpdateDelete(int FunctionId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Function] set  IsDeleted =1  ,EditDate=GETDATE() ");
            strSql.Append(" where FunctionId=@FunctionId and  IsDeleted =0   ");
            SqlParameter[] parameters = {
                    new SqlParameter("@FunctionId", SqlDbType.Int,4)
            };
            parameters[0].Value = FunctionId;


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
        /// 获取当前部门下的授权功能
        /// </summary>
        /// <param name="DepartmentID">部门ID</param>
        /// <param name=""></param>
        /// <returns></returns>
        public List<Function> GetFuctionDepartmentExtentList2(string where)
        {

            string selectFields = @"   ClassId ,CreateDate ,CreateId ,
        EditDate ,
        EditId ,
        ExternalLinkAddress ,
        FunctionClass ,
        FunctionCode ,
        FunctionDir ,
        FunctionIcon ,
        FunctionId ,
        FunctionName ,
        IsDeleted ,
        ParentId ,
        Remark ,
        Status ";
            string strSql = @"  SELECT  f.ClassId ,
          f.CreateDate ,
         f.CreateId ,
         f.EditDate ,
         f.EditId ,
          f.ExternalLinkAddress ,
          f.FunctionClass ,
          f.FunctionCode ,
          f.FunctionDir ,
          f.FunctionIcon ,
          f.FunctionId ,
          f.FunctionName ,
          f.IsDeleted ,
          f.OrderId ,
          f.ParentId ,
          f.Remark ,
          f.[Status]  FROM dbo.[Function] f 
          LEFT JOIN [RoleFunction] rf  ON rf.FunctionId=f.FunctionId AND rf.IsDeleted=0
          LEFT JOIN [role] r ON r.RoleId=rf.RoleId AND r.IsDeleted=0
          LEFT JOIN [UserRole] ur  ON ur.RoleId=r.RoleId AND ur.IsDeleted=0 ";

            strSql += "   WHERE " + where;

            List<Function> dataList = SqlDataUtilityHelper.GetListFromDB<Function>(selectFields, this.ConnectionString, strSql, null);
            return dataList;

        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetPsrentNameList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT f.*,f2.FunctionName AS ParentFunctionName  FROM dbo.[Function]  f LEFT JOIN [Function] f2 ON f.ParentId=f2.FunctionId AND f2.IsDeleted=0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        #endregion

    }
}
