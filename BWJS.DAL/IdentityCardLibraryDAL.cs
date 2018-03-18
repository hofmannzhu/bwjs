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
    /// 身份证号码库
    /// </summary>
    public partial class IdentityCardLibraryDAL: BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.IdentityCardLibrary model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[IdentityCardLibrary](");
            strSql.Append("IssuedAt,EffectedDate,ExpiredDate,IdentityCardPhoto,IdentityCardPhotoPath,IdentityCardPhotoData,IdentityCardData,ExtendedField1,ExtendedField2,ExtendedField3,CompanyId,Remark,CreateId,CreateDate,EditId,EditDate,IsDeleted,IdentityCardNumber,FullName,Sex,Nation,BirthDay,Address");
            strSql.Append(") values (");
            strSql.Append("@IssuedAt,@EffectedDate,@ExpiredDate,@IdentityCardPhoto,@IdentityCardPhotoPath,@IdentityCardPhotoData,@IdentityCardData,@ExtendedField1,@ExtendedField2,@ExtendedField3,@CompanyId,@Remark,@CreateId,@CreateDate,@EditId,@EditDate,@IsDeleted,@IdentityCardNumber,@FullName,@Sex,@Nation,@BirthDay,@Address");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@IssuedAt", model.IssuedAt) ,
                        new SqlParameter("@EffectedDate", model.EffectedDate) ,
                        new SqlParameter("@ExpiredDate", model.ExpiredDate) ,
                        new SqlParameter("@IdentityCardPhoto", model.IdentityCardPhoto) ,
                        new SqlParameter("@IdentityCardPhotoPath", model.IdentityCardPhotoPath) ,
                        new SqlParameter("@IdentityCardPhotoData", model.IdentityCardPhotoData) ,
                        new SqlParameter("@IdentityCardData", model.IdentityCardData) ,
                        new SqlParameter("@ExtendedField1", model.ExtendedField1) ,
                        new SqlParameter("@ExtendedField2", model.ExtendedField2) ,
                        new SqlParameter("@ExtendedField3", model.ExtendedField3) ,
                        new SqlParameter("@CompanyId", model.CompanyId) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@IdentityCardNumber", model.IdentityCardNumber) ,
                        new SqlParameter("@FullName", model.FullName) ,
                        new SqlParameter("@Sex", model.Sex) ,
                        new SqlParameter("@Nation", model.Nation) ,
                        new SqlParameter("@BirthDay", model.BirthDay) ,
                        new SqlParameter("@Address", model.Address) 
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
        //public bool Update(BWJS.Model.IdentityCardLibrary model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update dbo.[IdentityCardLibrary] set ");

        //    strSql.Append(" IssuedAt = @IssuedAt , ");
        //    strSql.Append(" EffectedDate = @EffectedDate , ");
        //    strSql.Append(" ExpiredDate = @ExpiredDate , ");
        //    strSql.Append(" IdentityCardPhoto = @IdentityCardPhoto , ");
        //    strSql.Append(" IdentityCardPhotoPath = @IdentityCardPhotoPath , ");
        //    strSql.Append(" IdentityCardPhotoData = @IdentityCardPhotoData , ");
        //    strSql.Append(" IdentityCardData = @IdentityCardData , ");
        //    strSql.Append(" ExtendedField1 = @ExtendedField1 , ");
        //    strSql.Append(" ExtendedField2 = @ExtendedField2 , ");
        //    strSql.Append(" ExtendedField3 = @ExtendedField3 , ");
        //    strSql.Append(" CompanyId = @CompanyId , ");
        //    strSql.Append(" Remark = @Remark , ");
        //    strSql.Append(" CreateId = @CreateId , ");
        //    strSql.Append(" CreateDate = @CreateDate , ");
        //    strSql.Append(" EditId = @EditId , ");
        //    strSql.Append(" EditDate = @EditDate , ");
        //    strSql.Append(" IsDeleted = @IsDeleted , ");
        //    strSql.Append(" IdentityCardNumber = @IdentityCardNumber , ");
        //    strSql.Append(" FullName = @FullName , ");
        //    strSql.Append(" Sex = @Sex , ");
        //    strSql.Append(" Nation = @Nation , ");
        //    strSql.Append(" BirthDay = @BirthDay , ");
        //    strSql.Append(" Address = @Address  ");
        //    strSql.Append(" where IdentityCardLibraryId=@IdentityCardLibraryId ");

        //    SqlParameter[] parameters = {
        //                new SqlParameter("@IdentityCardLibraryId",model.IdentityCardLibraryId) ,
        //                new SqlParameter("@IssuedAt",model.IssuedAt) ,
        //                new SqlParameter("@EffectedDate",model.EffectedDate) ,
        //                new SqlParameter("@ExpiredDate",model.ExpiredDate) ,
        //                new SqlParameter("@IdentityCardPhoto",model.IdentityCardPhoto) ,
        //                new SqlParameter("@IdentityCardPhotoPath",model.IdentityCardPhotoPath) ,
        //                new SqlParameter("@IdentityCardPhotoData",model.IdentityCardPhotoData) ,
        //                new SqlParameter("@IdentityCardData",model.IdentityCardData) ,
        //                new SqlParameter("@ExtendedField1",model.ExtendedField1) ,
        //                new SqlParameter("@ExtendedField2",model.ExtendedField2) ,
        //                new SqlParameter("@ExtendedField3",model.ExtendedField3) ,
        //                new SqlParameter("@CompanyId",model.CompanyId) ,
        //                new SqlParameter("@Remark",model.Remark) ,
        //                new SqlParameter("@CreateId",model.CreateId) ,
        //                new SqlParameter("@CreateDate",model.CreateDate) ,
        //                new SqlParameter("@EditId",model.EditId) ,
        //                new SqlParameter("@EditDate",model.EditDate) ,
        //                new SqlParameter("@IsDeleted",model.IsDeleted) ,
        //                new SqlParameter("@IdentityCardNumber",model.IdentityCardNumber) ,
        //                new SqlParameter("@FullName",model.FullName) ,
        //                new SqlParameter("@Sex",model.Sex) ,
        //                new SqlParameter("@Nation",model.Nation) ,
        //                new SqlParameter("@BirthDay",model.BirthDay) ,
        //                new SqlParameter("@Address",model.Address)

        //    };

        //    int rows = BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        /// <summary>
        /// 删除一条数据
        /// </summary>
        //public bool Delete(int IdentityCardLibraryId)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update dbo.[IdentityCardLibrary] set IsDeleted=1");
        //    strSql.Append(" where IdentityCardLibraryId=@IdentityCardLibraryId");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@IdentityCardLibraryId", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = IdentityCardLibraryId;


        //    int rows = BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        //public bool DeleteList(string IdentityCardLibraryIdlist)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update dbo.[IdentityCardLibrary] set IsDeleted=1");
        //    strSql.Append(" where ID in (" + IdentityCardLibraryIdlist + ")  ");
        //    int rows = BWJSHelperSQL.ExecuteSql(strSql.ToString());
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.IdentityCardLibrary GetModel(int IdentityCardLibraryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select IdentityCardLibraryId, IssuedAt, EffectedDate, ExpiredDate, IdentityCardPhoto, IdentityCardPhotoPath, IdentityCardPhotoData, IdentityCardData, ExtendedField1, ExtendedField2, ExtendedField3, CompanyId, Remark, CreateId, CreateDate, EditId, EditDate, IsDeleted, IdentityCardNumber, FullName, Sex, Nation, BirthDay, Address  ");
            strSql.Append("  from dbo.[IdentityCardLibrary] ");
            strSql.Append(" where IdentityCardLibraryId=@IdentityCardLibraryId");
            SqlParameter[] parameters = {
                    new SqlParameter("@IdentityCardLibraryId", SqlDbType.Int,4)
            };
            parameters[0].Value = IdentityCardLibraryId; 
            BWJS.Model.IdentityCardLibrary model = new BWJS.Model.IdentityCardLibrary();
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
        public BWJS.Model.IdentityCardLibrary DataRowToModel(DataRow row)
        {
            BWJS.Model.IdentityCardLibrary model = new BWJS.Model.IdentityCardLibrary(); 
            if (row != null)
            {
                if (row["IdentityCardLibraryId"].ToString() != "")
                {
                    model.IdentityCardLibraryId = int.Parse(row["IdentityCardLibraryId"].ToString());
                }
                model.IssuedAt = row["IssuedAt"].ToString();
                if (row["EffectedDate"].ToString() != "")
                {
                    model.EffectedDate = DateTime.Parse(row["EffectedDate"].ToString());
                }
                if (row["ExpiredDate"].ToString() != "")
                {
                    model.ExpiredDate = DateTime.Parse(row["ExpiredDate"].ToString());
                }
                if (row["IdentityCardPhoto"].ToString() != "")
                {
                    model.IdentityCardPhoto = (byte[])row["IdentityCardPhoto"];
                }
                model.IdentityCardPhotoPath = row["IdentityCardPhotoPath"].ToString();
                model.IdentityCardPhotoData = row["IdentityCardPhotoData"].ToString();
                model.IdentityCardData = row["IdentityCardData"].ToString();
                model.ExtendedField1 = row["ExtendedField1"].ToString();
                model.ExtendedField2 = row["ExtendedField2"].ToString();
                model.ExtendedField3 = row["ExtendedField3"].ToString();
                if (row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                }
                model.Remark = row["Remark"].ToString();
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
                model.IdentityCardNumber = row["IdentityCardNumber"].ToString();
                model.FullName = row["FullName"].ToString();
                if (row["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(row["Sex"].ToString());
                }
                model.Nation = row["Nation"].ToString();
                if (row["BirthDay"].ToString() != "")
                {
                    model.BirthDay = DateTime.Parse(row["BirthDay"].ToString());
                }
                model.Address = row["Address"].ToString(); 
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
            strSql.Append(" FROM dbo.[IdentityCardLibrary] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        //public DataSet GetList(int Top, string strWhere, string filedOrder)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select ");
        //    if (Top > 0)
        //    {
        //        strSql.Append(" top " + Top.ToString());
        //    }
        //    strSql.Append(" * ");
        //    strSql.Append(" FROM dbo.[IdentityCardLibrary] ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    strSql.Append(" order by " + filedOrder);
        //    return BWJSHelperSQL.Query(strSql.ToString());
        //}

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
            tablesql.Append("select a.*,b.[CompanyName] from dbo.[IdentityCardLibrary] a left join [dbo].[Company] b on b.[CompanyId] = a.[CompanyId] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="fullName">姓名</param>
        /// <param name="sex">性别</param>
        /// <param name="identityCardNumber">身份证号码</param>
        /// <param name="address">地址</param>
        /// <param name="issuedAt">签发地</param>
        /// <param name="validityPeriodBegin">生效日期</param>
        /// <param name="validityPeriodEnd">失效日期</param>
        /// <returns>身份证号码库编号</returns>
        public int Exists(string fullName, int sex, string identityCardNumber, string address, string issuedAt, string effectedDate, string expiredDate)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 IdentityCardLibraryId from dbo.[IdentityCardLibrary]");
            strSql.Append(" where IsDeleted=0");
            strSql.AppendFormat(" and FullName = '{0}'", fullName);
            strSql.AppendFormat(" and Sex = {0}", sex);
            strSql.AppendFormat(" and IdentityCardNumber = '{0}'", identityCardNumber);
            strSql.AppendFormat(" and Address = '{0}'", address);
            strSql.AppendFormat(" and IssuedAt = '{0}'", issuedAt);
            if (!string.IsNullOrEmpty(effectedDate))
            {
                strSql.AppendFormat(" and EffectedDate = '{0}'", effectedDate);
            }
            if (!string.IsNullOrEmpty(expiredDate))
            {
                strSql.AppendFormat(" and ExpiredDate = '{0}'", expiredDate);
            }
            DataTable dt = BWJSHelperSQL.ReturnDataTable(strSql.ToString());
            if (dt != null && dt.Rows.Count > 0) {
                result = Convert.ToInt32(dt.Rows[0]["IdentityCardLibraryId"]);
            }
            return result;
        }
        #endregion
    }
}
