﻿using BWJS.DAL;
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
    /// 订单返利结算申请
    /// </summary>
    public partial class ProductRelationBLL
    {
        private readonly ProductRelationDAL dal = new ProductRelationDAL();
        public ProductRelationBLL() { }

        #region BasicMethod
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.ProductRelation model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.ProductRelation model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ProductRelationId)
        {

            return dal.Delete(ProductRelationId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string ProductRelationIdlist)
        {
            return dal.DeleteList(ProductRelationIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.ProductRelation GetModel(int ProductRelationId)
        {

            return dal.GetModel(ProductRelationId);
        }
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BWJS.Model.Sys_ProductRelation GetModelByCache(int ProductRelationId)
		{
			
			string CacheKey = "Sys_ProductRelationModel-" + ProductRelationId;
			object objModel = BWJS.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductRelationId);
					if (objModel != null)
					{
						int ModelCache = BWJS.Common.ConfigHelper.GetConfigInt("ModelCache");
						BWJS.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BWJS.Model.Sys_ProductRelation)objModel;
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
        public List<BWJS.Model.ProductRelation> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.ProductRelation> DataTableToList(DataTable dt)
        {
            List<BWJS.Model.ProductRelation> modelList = new List<BWJS.Model.ProductRelation>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BWJS.Model.ProductRelation model;
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
        public BWJS.Model.ProductRelation DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }
        #endregion

        #region ExtensionMethod

        #endregion
    }
}
