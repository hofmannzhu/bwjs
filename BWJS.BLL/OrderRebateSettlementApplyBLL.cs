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
    /// 订单返利结算申请
    /// </summary>
    public partial class OrderRebateSettlementApplyBLL
    {
        private readonly OrderRebateSettlementApplyDAL dal = new OrderRebateSettlementApplyDAL();

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.OrderRebateSettlementApply model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        //public bool Update(BWJS.Model.OrderRebateSettlementApply model)
        //{
        //    return dal.Update(model);
        //}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        //public bool Delete(int OrderRebateSettlementApplyId)
        //{

        //    return dal.Delete(OrderRebateSettlementApplyId);
        //}
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        //public bool DeleteList(string OrderRebateSettlementApplyIdlist)
        //{
        //    return dal.DeleteList(OrderRebateSettlementApplyIdlist);
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.OrderRebateSettlementApply GetModel(int OrderRebateSettlementApplyId)
        {

            return dal.GetModel(OrderRebateSettlementApplyId);
        }
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BWJS.Model.OrderRebateSettlementApply GetModelByCache(int OrderRebateSettlementApplyId)
		{
			
			string CacheKey = "OrderRebateSettlementApplyModel-" + OrderRebateSettlementApplyId;
			object objModel = BWJS.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(OrderRebateSettlementApplyId);
					if (objModel != null)
					{
						int ModelCache = BWJS.Common.ConfigHelper.GetConfigInt("ModelCache");
						BWJS.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BWJS.Model.OrderRebateSettlementApply)objModel;
		}*/
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<BWJS.Model.OrderRebateSettlementApply> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList(strWhere);
        //    return DataTableToList(ds.Tables[0]);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<BWJS.Model.OrderRebateSettlementApply> DataTableToList(DataTable dt)
        //{
        //    List<BWJS.Model.OrderRebateSettlementApply> modelList = new List<BWJS.Model.OrderRebateSettlementApply>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        BWJS.Model.OrderRebateSettlementApply model;
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
        //public BWJS.Model.OrderRebateSettlementApply DataRowToModel(DataRow row)
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

        #region  ExtensionMethod

        /// <summary>
        /// 确认结算，更新结算申请表结算状态为已结算和更新订单表结算状态为已结算
        /// </summary>
        /// <param name="orderRebateSettlementApplyId">结算申请主键</param>
        /// <param name="userId">当前登录人编号</param>
        /// <param name="res01">更新结算申请表结算状态为已结算的结果</param>
        /// <param name="res02">更新订单表结算状态为已结算的结果</param>
        public void ConfirmSettlement(string orderRebateSettlementApplyId, int userId, ref int res01, ref int res02)
        {
            dal.ConfirmSettlement(orderRebateSettlementApplyId, userId, ref res01, ref res02);
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
        #endregion  ExtensionMethod
    }
}
