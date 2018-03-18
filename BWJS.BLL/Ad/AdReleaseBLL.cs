using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BWJS.Model;
using BWJS.Model.Model;

namespace BWJS.BLL
{
    //广告发布表
    public partial class AdReleaseBLL
    {

        private readonly BWJS.DAL.Ad.AdReleaseDAL dal = new DAL.Ad.AdReleaseDAL();
        public AdReleaseBLL()
        { }

        #region BasicMethod
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.AdRelease model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.AdRelease model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AdReleaseID)
        {

            return dal.Delete(AdReleaseID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string AdReleaseIDlist)
        {
            return dal.DeleteList(AdReleaseIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.AdRelease GetModel(int AdReleaseID)
        {

            return dal.GetModel(AdReleaseID);
        }
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BWJS.Model.AdRelease GetModelByCache(int AdReleaseID)
		{
			
			string CacheKey = "AdReleaseModel-" + AdReleaseID;
			object objModel = BWJS.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AdReleaseID);
					if (objModel != null)
					{
						int ModelCache = BWJS.Common.ConfigHelper.GetConfigInt("ModelCache");
						BWJS.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BWJS.Model.AdRelease)objModel;
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
        public List<BWJS.Model.AdRelease> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.AdRelease> DataTableToList(DataTable dt)
        {
            List<BWJS.Model.AdRelease> modelList = new List<BWJS.Model.AdRelease>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BWJS.Model.AdRelease model;
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
        public BWJS.Model.AdRelease DataRowToModel(DataRow row)
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
        #endregion

        #region  ExtensionMethod

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateResourceID(AdRelease model)
        {
            return dal.UpdateResourceID(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool UpdateDelete(int AdReleaseID)
        {

            return dal.UpdateDelete(AdReleaseID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool UpdateDeleteList(string AdReleaseIDlist)
        {
            return dal.UpdateDeleteList(AdReleaseIDlist);
        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AdReleaseBackup GetModelOne(int AdReleaseID)
        {

            return dal.GetModelOne(AdReleaseID);
        }
        /// <summary>
        /// 获取广告
        /// </summary>
        public List<AdReleaseExpand> GetReleaseExpandList()
        {

            return dal.GetReleaseExpandList();
        }
        /// <summary>
        /// 获取广告
        /// </summary>
        /// <returns></returns>

        public DataTable GetReleaseExpandL(string where)
        {
            return dal.GetReleaseExpandL(where);
        }

            #endregion

        }
}