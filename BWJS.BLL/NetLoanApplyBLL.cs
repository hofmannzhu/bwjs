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
    /// 网贷申请
    /// </summary>
    public partial class NetLoanApplyBLL
    {
        private readonly NetLoanApplyDAL dal = new NetLoanApplyDAL();

        #region BaseMethod
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.NetLoanApply model)
        {
            return dal.Add(model);

        }

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(BWJS.Model.NetLoanApply model)
        //{
        //    return dal.Update(model);
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool Delete(int NetLoanApplyId)
        //{

        //    return dal.Delete(NetLoanApplyId);
        //}
        /// <summary>
        /// 批量删除一批数据
        ///// </summary>
        //public bool DeleteList(string NetLoanApplyIdlist)
        //{
        //    return dal.DeleteList(NetLoanApplyIdlist);
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.NetLoanApply GetModel(int NetLoanApplyId)
        {

            return dal.GetModel(NetLoanApplyId);
        }
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BWJS.Model.NetLoanApply GetModelByCache(int NetLoanApplyId)
		{
			
			string CacheKey = "NetLoanApplyModel-" + NetLoanApplyId;
			object objModel = BWJS.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(NetLoanApplyId);
					if (objModel != null)
					{
						int ModelCache = BWJS.Common.ConfigHelper.GetConfigInt("ModelCache");
						BWJS.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BWJS.Model.NetLoanApply)objModel;
		}*/

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    return dal.GetList(strWhere);
        //}
        ///// <summary>
        ///// 获得前几行数据
        ///// </summary>
        //public DataSet GetList(int Top, string strWhere, string filedOrder)
        //{
        //    return dal.GetList(Top, strWhere, filedOrder);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<BWJS.Model.NetLoanApply> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList(strWhere);
        //    return DataTableToList(ds.Tables[0]);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<BWJS.Model.NetLoanApply> DataTableToList(DataTable dt)
        //{
        //    List<BWJS.Model.NetLoanApply> modelList = new List<BWJS.Model.NetLoanApply>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        BWJS.Model.NetLoanApply model;
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
        //public BWJS.Model.NetLoanApply DataRowToModel(DataRow row)
        //{
        //    return dal.DataRowToModel(row);
        //}

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

        #endregion
    }
}
