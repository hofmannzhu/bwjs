﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Mofang.DAL;
using Mofang.Model;

namespace Mofang.BLL
{
    /// <summary>
    /// 退保表
    /// </summary>
    public partial class OrderCancleBLL
    {

        private readonly OrderCancleDAL dal = new OrderCancleDAL();

        public OrderCancleBLL() { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mofang.Model.OrderCancle model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mofang.Model.OrderCancle model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int OrderCancleID)
        {

            return dal.Delete(OrderCancleID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string OrderCancleIDlist)
        {
            return dal.DeleteList(OrderCancleIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mofang.Model.OrderCancle GetModel(int OrderCancleID)
        {

            return dal.GetModel(OrderCancleID);
        }
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Mofang.Model.OrderCancle GetModelByCache(int OrderCancleID)
		{
			
			string CacheKey = "OrderCancleModel-" + OrderCancleID;
			object objModel = Mofang.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(OrderCancleID);
					if (objModel != null)
					{
						int ModelCache = Mofang.Common.ConfigHelper.GetConfigInt("ModelCache");
						Mofang.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Mofang.Model.OrderCancle)objModel;
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
        public List<Mofang.Model.OrderCancle> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mofang.Model.OrderCancle> DataTableToList(DataTable dt)
        {
            List<Mofang.Model.OrderCancle> modelList = new List<Mofang.Model.OrderCancle>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mofang.Model.OrderCancle model;
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
        public Mofang.Model.OrderCancle DataRowToModel(DataRow row)
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
        /// 删除一条数据
        /// </summary>
        public bool UpdateDelete(int OrderCancleID)
        {

            return dal.UpdateDelete(OrderCancleID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool UpdateDeleteList(string OrderCancleIDlist)
        {
            return dal.UpdateDeleteList(OrderCancleIDlist);
        }
        
        #endregion

    }
}