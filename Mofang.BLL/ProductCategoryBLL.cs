using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Mofang.Model;
using Mofang.DAL;
namespace Mofang.BLL
{
    //产品分类表
    public partial class ProductCategoryBLL
    {

        private readonly ProductCategoryDAL dal = new ProductCategoryDAL();
        public ProductCategoryBLL()
        { }

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mofang.Model.ProductCategory model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mofang.Model.ProductCategory model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ProductCategoryId)
        {

            return dal.Delete(ProductCategoryId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string ProductCategoryIdlist)
        {
            return dal.DeleteList(ProductCategoryIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mofang.Model.ProductCategory GetModel(int ProductCategoryId)
        {

            return dal.GetModel(ProductCategoryId);
        }
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Mofang.Model.ProductCategory GetModelByCache(int ProductCategoryId)
		{
			
			string CacheKey = "ProductCategoryModel-" + ProductCategoryId;
			object objModel = Mofang.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductCategoryId);
					if (objModel != null)
					{
						int ModelCache = Mofang.Common.ConfigHelper.GetConfigInt("ModelCache");
						Mofang.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Mofang.Model.ProductCategory)objModel;
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
        public List<Mofang.Model.ProductCategory> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mofang.Model.ProductCategory> DataTableToList(DataTable dt)
        {
            List<Mofang.Model.ProductCategory> modelList = new List<Mofang.Model.ProductCategory>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mofang.Model.ProductCategory model;
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
        public Mofang.Model.ProductCategory DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }
        public List<ProductCategory> GetCardTypeList()
        {
            return dal.GetCardTypeList();
        }
        #endregion

    }
}