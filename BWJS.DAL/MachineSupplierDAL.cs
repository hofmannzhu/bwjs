using BWJS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityHelper;

namespace BWJS.DAL
{

    //MachineSupplier
    public partial class MachineSupplierDAL : BaseService
    {
        #region BasicMethod 
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.MachineSupplier model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[MachineSupplier](");
            strSql.Append("API,QRCode,MainBrand,MainBusiness,Wechat,PublicWechat,Remark,Status,IsDeleted,CreateId,SupplierName,CreateDate,EditId,EditDate,Manager,Phone,Mobile,Address,QQ,SiteUrl,Logo");
            strSql.Append(") values (");
            strSql.Append("@API,@QRCode,@MainBrand,@MainBusiness,@Wechat,@PublicWechat,@Remark,@Status,@IsDeleted,@CreateId,@SupplierName,@CreateDate,@EditId,@EditDate,@Manager,@Phone,@Mobile,@Address,@QQ,@SiteUrl,@Logo");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@API", model.API) ,
                        new SqlParameter("@QRCode", model.QRCode) ,
                        new SqlParameter("@MainBrand", model.MainBrand) ,
                        new SqlParameter("@MainBusiness", model.MainBusiness) ,
                        new SqlParameter("@Wechat", model.Wechat) ,
                        new SqlParameter("@PublicWechat", model.PublicWechat) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@Status", model.Status) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@SupplierName", model.SupplierName) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@Manager", model.Manager) ,
                        new SqlParameter("@Phone", model.Phone) ,
                        new SqlParameter("@Mobile", model.Mobile) ,
                        new SqlParameter("@Address", model.Address) ,
                        new SqlParameter("@QQ", model.QQ) ,
                        new SqlParameter("@SiteUrl", model.SiteUrl) ,
                        new SqlParameter("@Logo", model.Logo) 
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
        public bool Update(BWJS.Model.MachineSupplier model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[MachineSupplier] set "); 
            strSql.Append(" API = @API , ");
            strSql.Append(" QRCode = @QRCode , ");
            strSql.Append(" MainBrand = @MainBrand , ");
            strSql.Append(" MainBusiness = @MainBusiness , ");
            strSql.Append(" Wechat = @Wechat , ");
            strSql.Append(" PublicWechat = @PublicWechat , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" SupplierName = @SupplierName , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" Manager = @Manager , ");
            strSql.Append(" Phone = @Phone , ");
            strSql.Append(" Mobile = @Mobile , ");
            strSql.Append(" Address = @Address , ");
            strSql.Append(" QQ = @QQ , ");
            strSql.Append(" SiteUrl = @SiteUrl , ");
            strSql.Append(" Logo = @Logo  ");
            strSql.Append(" where MachineSupplierId=@MachineSupplierId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@MachineSupplierId",model.MachineSupplierId) ,
                        new SqlParameter("@API",model.API) ,
                        new SqlParameter("@QRCode",model.QRCode) ,
                        new SqlParameter("@MainBrand",model.MainBrand) ,
                        new SqlParameter("@MainBusiness",model.MainBusiness) ,
                        new SqlParameter("@Wechat",model.Wechat) ,
                        new SqlParameter("@PublicWechat",model.PublicWechat) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@Status",model.Status) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@SupplierName",model.SupplierName) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@Manager",model.Manager) ,
                        new SqlParameter("@Phone",model.Phone) ,
                        new SqlParameter("@Mobile",model.Mobile) ,
                        new SqlParameter("@Address",model.Address) ,
                        new SqlParameter("@QQ",model.QQ) ,
                        new SqlParameter("@SiteUrl",model.SiteUrl) ,
                        new SqlParameter("@Logo",model.Logo)

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
        public BWJS.Model.MachineSupplier GetModel(int MachineSupplierId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MachineSupplierId, API, QRCode, MainBrand, MainBusiness, Wechat, PublicWechat, Remark, Status, IsDeleted, CreateId, SupplierName, CreateDate, EditId, EditDate, Manager, Phone, Mobile, Address, QQ, SiteUrl, Logo  ");
            strSql.Append("  from dbo.[MachineSupplier] ");
            strSql.Append(" where MachineSupplierId=@MachineSupplierId");
            SqlParameter[] parameters = {
                    new SqlParameter("@MachineSupplierId", SqlDbType.Int,4)
            };
            parameters[0].Value = MachineSupplierId;


            BWJS.Model.MachineSupplier model = new BWJS.Model.MachineSupplier();
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
        public BWJS.Model.MachineSupplier DataRowToModel(DataRow row)
        {
            BWJS.Model.MachineSupplier model = new BWJS.Model.MachineSupplier();

            if (row != null)
            {
                if (row["MachineSupplierId"].ToString() != "")
                {
                    model.MachineSupplierId = int.Parse(row["MachineSupplierId"].ToString());
                }
                model.API = row["API"].ToString();
                model.QRCode = row["QRCode"].ToString();
                model.MainBrand = row["MainBrand"].ToString();
                model.MainBusiness = row["MainBusiness"].ToString();
                model.Wechat = row["Wechat"].ToString();
                model.PublicWechat = row["PublicWechat"].ToString();
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
                model.SupplierName = row["SupplierName"].ToString();
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
                model.Manager = row["Manager"].ToString();
                model.Phone = row["Phone"].ToString();
                model.Mobile = row["Mobile"].ToString();
                model.Address = row["Address"].ToString();
                model.QQ = row["QQ"].ToString();
                model.SiteUrl = row["SiteUrl"].ToString();
                model.Logo = row["Logo"].ToString();

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
            strSql.Append(" FROM dbo.[MachineSupplier] ");
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
        //    strSql.Append(" FROM dbo.[MachineSupplier] ");
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
        /// 删除一条数据
        /// </summary>
        //public bool Delete(int machineSupplierId, int userId)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update dbo.[MachineSupplier] set IsDeleted=1,EditId=@EditId,EditDate=@EditDate");
        //    strSql.Append(" where MachineSupplierId=@MachineSupplierId");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@MachineSupplierId", machineSupplierId),
        //            new SqlParameter("@EditId", userId),
        //            new SqlParameter("@EditDate", DateTime.Now)
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string machineSupplierIdlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.[MachineSupplier] set IsDeleted=1,EditId={0},EditDate='{1}'", userId, DateTime.Now);
            strSql.Append(" where MachineSupplierId in (" + machineSupplierIdlist + ")  ");
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
            tablesql.Append(" FROM dbo.[MachineSupplier] a ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion

    }
}
