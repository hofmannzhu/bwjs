using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Mofang.DAL;
using Mofang.Model;
using Mofang.Model.ViewModel;

namespace Mofang.BLL
{
    //终端产品展示表
    public partial class ProductsBLL
    {

        private readonly ProductsDAL dal = new ProductsDAL();
        public ProductsBLL() { }

        #region BasicMethod
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mofang.Model.Products model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mofang.Model.Products model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ProductsID)
        {

            return dal.Delete(ProductsID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string ProductsIDlist)
        {
            return dal.DeleteList(ProductsIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mofang.Model.Products GetModel(int ProductsID)
        {

            return dal.GetModel(ProductsID);
        }
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Mofang.Model.Products GetModelByCache(int ProductsID)
		{
			
			string CacheKey = "ProductsModel-" + ProductsID;
			object objModel = Mofang.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductsID);
					if (objModel != null)
					{
						int ModelCache = Mofang.Common.ConfigHelper.GetConfigInt("ModelCache");
						Mofang.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Mofang.Model.Products)objModel;
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
        public List<Mofang.Model.Products> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mofang.Model.Products> DataTableToList(DataTable dt)
        {
            List<Mofang.Model.Products> modelList = new List<Mofang.Model.Products>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mofang.Model.Products model;
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
        public Mofang.Model.Products DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }
        #endregion

        #region  ExtensionMethod

        public List<ProductsViewModel> GetProducts(int CategoryId)
        {
            return dal.GetProducts(CategoryId);
        }
      
        public List<Products> ProductsByCaseCode(string caseCode)
        {
            return dal.ProductsByCaseCode(caseCode);
        }
        #endregion

    }
}