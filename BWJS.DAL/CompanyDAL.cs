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
    /// 渠道
    /// </summary>
    public partial class CompanyDAL : BaseService
    {
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.Company model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[Company](");
            strSql.Append("Logo,API,QRCode,MainBrand,MainBusiness,IsDisplay,IsRelyOnPrimaryKey,RecommendationPrefix,RecommendationLength,RecommendationCode,CompanyCategoryId,Wechat,PublicWechat,Remark,Status,OrderId,IsDeleted,CreateId,CreateDate,EditId,EditDate,CompanyName,AndroidURL,IosURL,IsAPK,DockingMode,CompanyManager,Phone,Mobile,Address,QQ,SiteUrl,DescriptionHtml,AuditConditions");
            strSql.Append(") values (");
            strSql.Append("@Logo,@API,@QRCode,@MainBrand,@MainBusiness,@IsDisplay,@IsRelyOnPrimaryKey,@RecommendationPrefix,@RecommendationLength,@RecommendationCode,@CompanyCategoryId,@Wechat,@PublicWechat,@Remark,@Status,@OrderId,@IsDeleted,@CreateId,@CreateDate,@EditId,@EditDate,@CompanyName,@AndroidURL,@IosURL,@IsAPK,@DockingMode,@CompanyManager,@Phone,@Mobile,@Address,@QQ,@SiteUrl,@DescriptionHtml,@AuditConditions");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@Logo", model.Logo) ,
                        new SqlParameter("@API", model.API) ,
                        new SqlParameter("@QRCode", model.QRCode) ,
                        new SqlParameter("@MainBrand", model.MainBrand) ,
                        new SqlParameter("@MainBusiness", model.MainBusiness) ,
                        new SqlParameter("@IsDisplay", model.IsDisplay) ,
                        new SqlParameter("@IsRelyOnPrimaryKey", model.IsRelyOnPrimaryKey) ,
                        new SqlParameter("@RecommendationPrefix", model.RecommendationPrefix) ,
                        new SqlParameter("@RecommendationLength", model.RecommendationLength) ,
                        new SqlParameter("@RecommendationCode", model.RecommendationCode) ,
                        new SqlParameter("@CompanyCategoryId", model.CompanyCategoryId) ,
                        new SqlParameter("@Wechat", model.Wechat) ,
                        new SqlParameter("@PublicWechat", model.PublicWechat) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@Status", model.Status) ,
                        new SqlParameter("@OrderId", model.OrderId) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@CreateId", model.CreateId) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@EditId", model.EditId) ,
                        new SqlParameter("@EditDate", model.EditDate) ,
                        new SqlParameter("@CompanyName", model.CompanyName) ,
                        new SqlParameter("@AndroidURL", model.AndroidURL) ,
                        new SqlParameter("@IosURL", model.IosURL) ,
                        new SqlParameter("@IsAPK", model.IsAPK) ,
                        new SqlParameter("@DockingMode", model.DockingMode) ,
                        new SqlParameter("@CompanyManager", model.CompanyManager) ,
                        new SqlParameter("@Phone", model.Phone) ,
                        new SqlParameter("@Mobile", model.Mobile) ,
                        new SqlParameter("@Address", model.Address) ,
                        new SqlParameter("@QQ", model.QQ) ,
                        new SqlParameter("@SiteUrl", model.SiteUrl),
                        new SqlParameter("@DescriptionHtml", model.DescriptionHtml),
                        new SqlParameter("@AuditConditions", model.AuditConditions)

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
        public bool Update(BWJS.Model.Company model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[Company] set ");
            strSql.Append(" Logo = @Logo , ");
            strSql.Append(" API = @API , ");
            strSql.Append(" QRCode = @QRCode , ");
            strSql.Append(" MainBrand = @MainBrand , ");
            strSql.Append(" MainBusiness = @MainBusiness , ");
            strSql.Append(" IsDisplay = @IsDisplay , ");
            strSql.Append(" IsRelyOnPrimaryKey = @IsRelyOnPrimaryKey , ");
            strSql.Append(" RecommendationPrefix = @RecommendationPrefix , ");
            strSql.Append(" RecommendationLength = @RecommendationLength , ");
            strSql.Append(" RecommendationCode = @RecommendationCode , ");
            strSql.Append(" CompanyCategoryId = @CompanyCategoryId , ");
            strSql.Append(" Wechat = @Wechat , ");
            strSql.Append(" PublicWechat = @PublicWechat , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" OrderId = @OrderId , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" CreateId = @CreateId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditId = @EditId , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" CompanyName = @CompanyName , ");
            strSql.Append(" AndroidURL = @AndroidURL , ");
            strSql.Append(" IosURL = @IosURL , ");
            strSql.Append(" IsAPK = @IsAPK , ");
            strSql.Append(" DockingMode = @DockingMode , ");
            strSql.Append(" CompanyManager = @CompanyManager , ");
            strSql.Append(" Phone = @Phone , ");
            strSql.Append(" Mobile = @Mobile , ");
            strSql.Append(" Address = @Address , ");
            strSql.Append(" QQ = @QQ , ");
            strSql.Append(" SiteUrl = @SiteUrl , ");
            strSql.Append(" DescriptionHtml = @DescriptionHtml , ");
            strSql.Append(" AuditConditions = @AuditConditions  ");
            strSql.Append(" where CompanyId=@CompanyId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@CompanyId",model.CompanyId) ,
                        new SqlParameter("@Logo",model.Logo) ,
                        new SqlParameter("@API",model.API) ,
                        new SqlParameter("@QRCode",model.QRCode) ,
                        new SqlParameter("@MainBrand",model.MainBrand) ,
                        new SqlParameter("@MainBusiness",model.MainBusiness) ,
                        new SqlParameter("@IsDisplay",model.IsDisplay) ,
                        new SqlParameter("@IsRelyOnPrimaryKey",model.IsRelyOnPrimaryKey) ,
                        new SqlParameter("@RecommendationPrefix",model.RecommendationPrefix) ,
                        new SqlParameter("@RecommendationLength",model.RecommendationLength) ,
                        new SqlParameter("@RecommendationCode",model.RecommendationCode) ,
                        new SqlParameter("@CompanyCategoryId",model.CompanyCategoryId) ,
                        new SqlParameter("@Wechat",model.Wechat) ,
                        new SqlParameter("@PublicWechat",model.PublicWechat) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@Status",model.Status) ,
                        new SqlParameter("@OrderId",model.OrderId) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@CreateId",model.CreateId) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@EditId",model.EditId) ,
                        new SqlParameter("@EditDate",model.EditDate) ,
                        new SqlParameter("@CompanyName",model.CompanyName) ,
                        new SqlParameter("@AndroidURL",model.AndroidURL) ,
                        new SqlParameter("@IosURL",model.IosURL) ,
                        new SqlParameter("@IsAPK",model.IsAPK) ,
                        new SqlParameter("@DockingMode",model.DockingMode) ,
                        new SqlParameter("@CompanyManager",model.CompanyManager) ,
                        new SqlParameter("@Phone",model.Phone) ,
                        new SqlParameter("@Mobile",model.Mobile) ,
                        new SqlParameter("@Address",model.Address) ,
                        new SqlParameter("@QQ",model.QQ) ,
                        new SqlParameter("@SiteUrl",model.SiteUrl),
                        new SqlParameter("@DescriptionHtml",model.DescriptionHtml),
                        new SqlParameter("@AuditConditions",model.AuditConditions)
                        
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
        public bool Delete(int CompanyId,int EditId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[Company] set IsDeleted=1,EditDate=GETDATE(),EditId=@EditId");
            strSql.Append(" where CompanyId=@CompanyId");
            SqlParameter[] parameters = {
                    new SqlParameter("@CompanyId", SqlDbType.Int,4),
                    new SqlParameter("@EditId", SqlDbType.Int,4)
            };
            parameters[0].Value = CompanyId;
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
        public bool DeleteList(string CompanyIdlist,int EditId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[Company] set IsDeleted=1,EditDate=GETDATE(),EditId="+ EditId + "");
            strSql.Append(" where ID in (" + CompanyIdlist + ")  ");
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
        public BWJS.Model.Company GetModel(int CompanyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CompanyId, Logo, API, QRCode, MainBrand, MainBusiness, IsDisplay, IsRelyOnPrimaryKey, RecommendationPrefix, RecommendationLength, RecommendationCode, CompanyCategoryId, Wechat, PublicWechat, Remark, Status, OrderId, IsDeleted, CreateId, CreateDate, EditId, EditDate, CompanyName, AndroidURL, IosURL, IsAPK, DockingMode, CompanyManager, Phone, Mobile, Address, QQ, SiteUrl ,DescriptionHtml ,AuditConditions");
            strSql.Append("  from dbo.[Company] ");
            strSql.Append(" where CompanyId=@CompanyId");
            SqlParameter[] parameters = {
                    new SqlParameter("@CompanyId", SqlDbType.Int,4)
            };
            parameters[0].Value = CompanyId; 
            BWJS.Model.Company model = new BWJS.Model.Company();
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
            strSql.Append(" FROM dbo.[Company] ");
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
            strSql.Append(" FROM dbo.[Company] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSHelperSQL.Query(strSql.ToString());
        }
        
        public DataTable GetList(string tablesql, string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            return BWJSHelperSQL.GetPageList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }


        #endregion

        #region  ExtensionMethod

        /// <summary>
        /// datarow转成对象实体
        /// </summary>
        public BWJS.Model.Company DataRowToModel(DataRow row)
        {
            BWJS.Model.Company model = new BWJS.Model.Company();

            if (row != null)
            {
                if (row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                }
                model.Logo = row["Logo"].ToString();
                model.API = row["API"].ToString();
                model.QRCode = row["QRCode"].ToString();
                model.MainBrand = row["MainBrand"].ToString();
                model.MainBusiness = row["MainBusiness"].ToString();
                if (row["IsDisplay"].ToString() != "")
                {
                    model.IsDisplay = int.Parse(row["IsDisplay"].ToString());
                }
                if (row["IsRelyOnPrimaryKey"].ToString() != "")
                {
                    model.IsRelyOnPrimaryKey = int.Parse(row["IsRelyOnPrimaryKey"].ToString());
                }
                model.RecommendationPrefix = row["RecommendationPrefix"].ToString();
                if (row["RecommendationLength"].ToString() != "")
                {
                    model.RecommendationLength = int.Parse(row["RecommendationLength"].ToString());
                }
                model.RecommendationCode = row["RecommendationCode"].ToString();
                model.Wechat = row["Wechat"].ToString();
                model.PublicWechat = row["PublicWechat"].ToString();
                model.Remark = row["Remark"].ToString();
                if (row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["CompanyCategoryId"].ToString() != "")
                {
                    model.CompanyCategoryId = int.Parse(row["CompanyCategoryId"].ToString());
                }
                if (row["OrderId"].ToString() != "")
                {
                    model.OrderId = int.Parse(row["OrderId"].ToString());
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
                model.CompanyName = row["CompanyName"].ToString();
                model.CompanyManager = row["CompanyManager"].ToString();
                model.Phone = row["Phone"].ToString();
                model.Mobile = row["Mobile"].ToString();
                model.Address = row["Address"].ToString();
                model.QQ = row["QQ"].ToString();
                model.SiteUrl = row["SiteUrl"].ToString();

                model.IsAPK = bool.Parse(row["IsAPK"].ToString());
                model.AndroidURL = row["AndroidURL"].ToString();
                model.IosURL = row["IosURL"].ToString();
                if (row["DockingMode"].ToString() != "")
                {
                    model.DockingMode = int.Parse(row["DockingMode"].ToString());
                }
                if (row["DescriptionHtml"].ToString() != "")
                {
                    model.DescriptionHtml = row["DescriptionHtml"].ToString();
                }
                //if (row["ReplaceUrlParam"].ToString() != "")
                //{
                //    model.ReplaceUrlParam = row["ReplaceUrlParam"].ToString();
                //} 
                CompanyNetLoanDAL dalCompanyNetLoanDAL = new CompanyNetLoanDAL();
                CompanyNetLoan modelCompanyNetLoan = dalCompanyNetLoanDAL.GetModel(model.CompanyId);
                // model.CompanyNetLoan = modelCompanyNetLoan;

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得商家渠道推荐码
        /// </summary>
        public string GetRecommendationCode(int CompanyId, int? UserId)
        {
            string result = string.Empty;

            #region 改造前
            //DataTable dt = null;
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select RecommendationCode from dbo.[CompanyRelation]");
            //strSql.Append(" where ");
            //strSql.Append(" CompanyId = @CompanyId  ");
            //strSql.Append(" and UserId = @UserId  ");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@CompanyId", CompanyId),
            //        new SqlParameter("@UserId", UserId)
            //    };
            //dt = BWJSHelperSQL.ReturnDataTable(strSql.ToString(), parameters);
            //if (dt == null || dt.Rows.Count == 0)
            //{
            //    strSql = new StringBuilder();
            //    strSql.Append("select RecommendationCode from dbo.[Company]");
            //    strSql.Append(" where ");
            //    strSql.Append(" CompanyId = @CompanyId  ");
            //    SqlParameter[] parameters1 = {
            //        new SqlParameter("@CompanyId", CompanyId)
            //    };
            //    dt = BWJSHelperSQL.ReturnDataTable(strSql.ToString(), parameters1);
            //}
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    result = dt.Rows[0][0].ToString();
            //} 
            #endregion

            Company model = GetModel(CompanyId);
            if (model != null)
            {
                if (model.IsDisplay == 1)
                {
                    if (model.IsRelyOnPrimaryKey == 1)
                    {

                        string prefix = model.RecommendationPrefix;
                        int maxlength = model.RecommendationLength;
                        int length = maxlength - prefix.Length;
                        result = prefix + UserId.ToString().PadLeft(length, '0');
                    }
                    else
                    {
                        result = model.RecommendationCode;
                    }
                }
            }

            return result;
        }

        public DataTable GetNameList(string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            StringBuilder tablesql = new StringBuilder();
            tablesql.Append(@"SELECT c.*,cc.CompanyCategoryName FROM dbo.Company c
                                          LEFT JOIN dbo.CompanyCategory cc ON cc.CompanyCategoryId = c.CompanyCategoryId AND cc.IsDeleted = 0 ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        public DataTable GetList(string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            StringBuilder tablesql = new StringBuilder();
            tablesql.Append("select * ");
            tablesql.Append(" FROM dbo.[Company] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion  ExtensionMethod
    }
}
