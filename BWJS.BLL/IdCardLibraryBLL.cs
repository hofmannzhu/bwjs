using BWJS.DAL;
using BWJS.Model;
using BWJS.Model.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BWJS.BLL
{
    /// <summary>
    /// 身份证号码库
    /// </summary>
    public partial class IdCardLibraryBLL
    {
        private readonly IdentityCardLibraryDAL dal = new IdentityCardLibraryDAL();

        #region BaseMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.IdentityCardLibrary model)
        {
            return dal.Add(model);

        }

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(BWJS.Model.IdentityCardLibrary model)
        //{
        //    return dal.Update(model);
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool Delete(int IdentityCardLibraryId)
        //{

        //    return dal.Delete(IdentityCardLibraryId);
        //}
        ///// <summary>
        ///// 批量删除一批数据
        ///// </summary>
        //public bool DeleteList(string IdentityCardLibraryIdlist)
        //{
        //    return dal.DeleteList(IdentityCardLibraryIdlist);
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.IdentityCardLibrary GetModel(int IdentityCardLibraryId)
        {

            return dal.GetModel(IdentityCardLibraryId);
        }
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BWJS.Model.IdentityCardLibrary GetModelByCache(int IdentityCardLibraryId)
		{
			
			string CacheKey = "IdentityCardLibraryModel-" + IdentityCardLibraryId;
			object objModel = BWJS.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(IdentityCardLibraryId);
					if (objModel != null)
					{
						int ModelCache = BWJS.Common.ConfigHelper.GetConfigInt("ModelCache");
						BWJS.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BWJS.Model.IdentityCardLibrary)objModel;
		}*/

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        //public DataSet GetList(int Top, string strWhere, string filedOrder)
        //{
        //    return dal.GetList(Top, strWhere, filedOrder);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<BWJS.Model.IdentityCardLibrary> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList(strWhere);
        //    return DataTableToList(ds.Tables[0]);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<BWJS.Model.IdentityCardLibrary> DataTableToList(DataTable dt)
        //{
        //    List<BWJS.Model.IdentityCardLibrary> modelList = new List<BWJS.Model.IdentityCardLibrary>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        BWJS.Model.IdentityCardLibrary model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = DataRowToModel(dt.Rows[n]);
        //            modelList.Add(model);
        //        }
        //    }
        //    return modelList;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetAllList()
        //{
        //    return GetList("");
        //}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        //public BWJS.Model.IdentityCardLibrary DataRowToModel(DataRow row)
        //{
        //    return dal.DataRowToModel(row);
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
        public DataTable GetList(string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            return dal.GetList(where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
        //public DataTable GetList(string tablesql, string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        //{
        //    return dal.GetList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        //}
        #endregion

        #region ExtensionMethod

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
            return dal.Exists(fullName, sex, identityCardNumber,  address, issuedAt, effectedDate, expiredDate);
        }
        #endregion
    }
}
