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
    /// 分类表
    /// </summary>
    public partial class GlobalClassDAL : BaseService
    {
        public GlobalClassDAL()
        { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        //public int Add(BWJS.Model.GlobalClass model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into GlobalClass(");
        //    strSql.Append("Status,ExternalLinkAddress,Remark,IsDeleted,CreateId,CreateDate,EditId,EditDate,ChannelId,ClassName,ClassCode,ClassIcon,ParentId,OpenType,OrderId,ClassPath");
        //    strSql.Append(") values (");
        //    strSql.Append("@Status,@ExternalLinkAddress,@Remark,@IsDeleted,@CreateId,@CreateDate,@EditId,@EditDate,@ChannelId,@ClassName,@ClassCode,@ClassIcon,@ParentId,@OpenType,@OrderId,@ClassPath");
        //    strSql.Append(") ");
        //    strSql.Append(";select SCOPE_IDENTITY()");
        //    SqlParameter[] parameters = {
        //                new SqlParameter("@Status", model.Status) ,
        //                new SqlParameter("@ExternalLinkAddress", model.ExternalLinkAddress) ,
        //                new SqlParameter("@Remark", model.Remark) ,
        //                new SqlParameter("@IsDeleted", model.IsDeleted) ,
        //                new SqlParameter("@CreateId", model.CreateId) ,
        //                new SqlParameter("@CreateDate", model.CreateDate) ,
        //                new SqlParameter("@EditId", model.EditId) ,
        //                new SqlParameter("@EditDate", model.EditDate) ,
        //                new SqlParameter("@ChannelId", model.ChannelId) ,
        //                new SqlParameter("@ClassName", model.ClassName) ,
        //                new SqlParameter("@ClassCode", model.ClassCode) ,
        //                new SqlParameter("@ClassIcon", model.ClassIcon) ,
        //                new SqlParameter("@ParentId", model.ParentId) ,
        //                new SqlParameter("@OpenType", model.OpenType) ,
        //                new SqlParameter("@OrderId", model.OrderId) ,
        //                new SqlParameter("@ClassPath", model.ClassPath)

        //    };


        //    object obj = BWJSHelperSQL.GetSingle(strSql.ToString(), parameters);
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {

        //        return Convert.ToInt32(obj);

        //    }

        //}


        /// <summary>
        /// 更新一条数据
        /// </summary>
        //public bool Update(BWJS.Model.GlobalClass model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update GlobalClass set ");

        //    strSql.Append(" Status = @Status , ");
        //    strSql.Append(" ExternalLinkAddress = @ExternalLinkAddress , ");
        //    strSql.Append(" Remark = @Remark , ");
        //    strSql.Append(" IsDeleted = @IsDeleted , ");
        //    strSql.Append(" CreateId = @CreateId , ");
        //    strSql.Append(" CreateDate = @CreateDate , ");
        //    strSql.Append(" EditId = @EditId , ");
        //    strSql.Append(" EditDate = @EditDate , ");
        //    strSql.Append(" ChannelId = @ChannelId , ");
        //    strSql.Append(" ClassName = @ClassName , ");
        //    strSql.Append(" ClassCode = @ClassCode , ");
        //    strSql.Append(" ClassIcon = @ClassIcon , ");
        //    strSql.Append(" ParentId = @ParentId , ");
        //    strSql.Append(" OpenType = @OpenType , ");
        //    strSql.Append(" OrderId = @OrderId , ");
        //    strSql.Append(" ClassPath = @ClassPath  ");
        //    strSql.Append(" where ClassId=@ClassId ");

        //    SqlParameter[] parameters = {
        //                new SqlParameter("@ClassId",model.ClassId) ,
        //                new SqlParameter("@Status",model.Status) ,
        //                new SqlParameter("@ExternalLinkAddress",model.ExternalLinkAddress) ,
        //                new SqlParameter("@Remark",model.Remark) ,
        //                new SqlParameter("@IsDeleted",model.IsDeleted) ,
        //                new SqlParameter("@CreateId",model.CreateId) ,
        //                new SqlParameter("@CreateDate",model.CreateDate) ,
        //                new SqlParameter("@EditId",model.EditId) ,
        //                new SqlParameter("@EditDate",model.EditDate) ,
        //                new SqlParameter("@ChannelId",model.ChannelId) ,
        //                new SqlParameter("@ClassName",model.ClassName) ,
        //                new SqlParameter("@ClassCode",model.ClassCode) ,
        //                new SqlParameter("@ClassIcon",model.ClassIcon) ,
        //                new SqlParameter("@ParentId",model.ParentId) ,
        //                new SqlParameter("@OpenType",model.OpenType) ,
        //                new SqlParameter("@OrderId",model.OrderId) ,
        //                new SqlParameter("@ClassPath",model.ClassPath)

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
        //public bool Delete(int ClassId)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update GlobalClass set IsDeleted=1");
        //    strSql.Append(" where ClassId=@ClassId");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@ClassId", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = ClassId;


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
        //public bool DeleteList(string ClassIdlist)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update GlobalClass set IsDeleted=1");
        //    strSql.Append(" where ID in (" + ClassIdlist + ")  ");
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
        //public BWJS.Model.GlobalClass GetModel(int ClassId)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select ClassId, Status, ExternalLinkAddress, Remark, IsDeleted, CreateId, CreateDate, EditId, EditDate, ChannelId, ClassName, ClassCode, ClassIcon, ParentId, OpenType, OrderId, ClassPath  ");
        //    strSql.Append("  from GlobalClass ");
        //    strSql.Append(" where ClassId=@ClassId");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@ClassId", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = ClassId;


        //    BWJS.Model.GlobalClass model = new BWJS.Model.GlobalClass();
        //    DataSet ds = BWJSHelperSQL.Query(strSql.ToString(), parameters);

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        return DataRowToModel(ds.Tables[0].Rows[0]);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// datarow转成对象实体
        /// </summary>
        //public BWJS.Model.GlobalClass DataRowToModel(DataRow row)
        //{
        //    BWJS.Model.GlobalClass model = new BWJS.Model.GlobalClass();

        //    if (row != null)
        //    {
        //        if (row["ClassId"].ToString() != "")
        //        {
        //            model.ClassId = int.Parse(row["ClassId"].ToString());
        //        }
        //        if (row["Status"].ToString() != "")
        //        {
        //            model.Status = int.Parse(row["Status"].ToString());
        //        }
        //        model.ExternalLinkAddress = row["ExternalLinkAddress"].ToString();
        //        model.Remark = row["Remark"].ToString();
        //        if (row["IsDeleted"].ToString() != "")
        //        {
        //            model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
        //        }
        //        if (row["CreateId"].ToString() != "")
        //        {
        //            model.CreateId = int.Parse(row["CreateId"].ToString());
        //        }
        //        if (row["CreateDate"].ToString() != "")
        //        {
        //            model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
        //        }
        //        if (row["EditId"].ToString() != "")
        //        {
        //            model.EditId = int.Parse(row["EditId"].ToString());
        //        }
        //        if (row["EditDate"].ToString() != "")
        //        {
        //            model.EditDate = DateTime.Parse(row["EditDate"].ToString());
        //        }
        //        if (row["ChannelId"].ToString() != "")
        //        {
        //            model.ChannelId = int.Parse(row["ChannelId"].ToString());
        //        }
        //        model.ClassName = row["ClassName"].ToString();
        //        model.ClassCode = row["ClassCode"].ToString();
        //        model.ClassIcon = row["ClassIcon"].ToString();
        //        if (row["ParentId"].ToString() != "")
        //        {
        //            model.ParentId = int.Parse(row["ParentId"].ToString());
        //        }
        //        model.OpenType = row["OpenType"].ToString();
        //        if (row["OrderId"].ToString() != "")
        //        {
        //            model.OrderId = int.Parse(row["OrderId"].ToString());
        //        }
        //        model.ClassPath = row["ClassPath"].ToString();

        //        return model;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
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
            strSql.Append(" FROM GlobalClass ");
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
        //    strSql.Append(" FROM GlobalClass ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    strSql.Append(" order by " + filedOrder);
        //    return BWJSHelperSQL.Query(strSql.ToString());
        //}

        #endregion

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
