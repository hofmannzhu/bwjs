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
    /// 渠道关系
    /// </summary>
    public partial class CompanyRelationBLL
    {
        private readonly CompanyRelationDAL dal = new CompanyRelationDAL();

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(BWJS.Model.CompanyRelation model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.CompanyRelation model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int CompanyId, int UserId, int EditId)
        {

            return dal.Delete(CompanyId, UserId, EditId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.CompanyRelation GetModel(int CompanyId, int UserId)
        {

            return dal.GetModel(CompanyId, UserId);
        }

        /// <summary>
        /// 得到一个对象实体重载
        /// </summary>
        public BWJS.Model.CompanyRelation GetModel(int CompanyRelationId)
        {

            return dal.GetModel(CompanyRelationId);
        }
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BWJS.Model.CompanyRelation GetModelByCache(int CompanyId,int UserId)
		{
			
			string CacheKey = "CompanyRelationModel-" + CompanyId+UserId;
			object objModel = BWJS.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CompanyId,UserId);
					if (objModel != null)
					{
						int ModelCache = BWJS.Common.ConfigHelper.GetConfigInt("ModelCache");
						BWJS.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BWJS.Model.CompanyRelation)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.CompanyRelation> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.CompanyRelation> DataTableToList(DataTable dt)
        {
            List<BWJS.Model.CompanyRelation> modelList = new List<BWJS.Model.CompanyRelation>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BWJS.Model.CompanyRelation model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(dt.Rows[n]);
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.CompanyRelation DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
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
        public DataTable GetList(string tablesql, string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            return dal.GetList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string companyRelationIdlist, int userId)
        {
            return dal.DeleteList(companyRelationIdlist, userId);
        }

        public CompanyRelationBackups GetCompanyRelationName(string strWhere)
        {
            DataSet ds = dal.GetModelListName(strWhere);
            return DataTableToListName(ds.Tables[0]);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public CompanyRelationBackups DataTableToListName(DataTable dt)
        {
            CompanyRelationBackups model = new CompanyRelationBackups();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {

                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModelName(dt.Rows[n]);
                }
            }
            return model;
        }
        #endregion  ExtensionMethod

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
