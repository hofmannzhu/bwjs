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
    /// 订单返利
    /// </summary>
    public partial class OrderRebateBLL
    {
        private readonly OrderRebateDAL dal = new OrderRebateDAL();

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.OrderRebate model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.OrderRebate model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.OrderRebate GetModel(int OrderRebateId)
        {

            return dal.GetModel(OrderRebateId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.OrderRebate DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }
        
        #endregion

        #region  ExtensionMethod
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

        public DataTable QueryOrderList(string strWhere)
        {
            return dal.QueryOrderList(strWhere);
        }

        /// <summary>
        /// 结算申请详情信息入库和修改订单返利结算申请表的结算状态为已申请
        /// </summary>
        /// <param name="orderRebateSettlementApplyId">结算申请主键</param>
        /// <param name="userId">当前登录人编号</param>
        /// <param name="where">申请时查询条件</param>
        /// <param name="res01">结算申请详情信息入库的结果</param>
        /// <param name="res02">修改订单返利结算申请表的结算状态为已申请的结果</param>
        public void ApplySettlement(int orderRebateSettlementApplyId, int userId, string where, ref int res01, ref int res02)
        {
            dal.ApplySettlement(orderRebateSettlementApplyId, userId, where, ref res01, ref res02);
        }

        public DataSet GetOrderList(string strWhere)
        {
            return dal.GetOrderList(strWhere);
        }

        #endregion  ExtensionMethod
    }
}
