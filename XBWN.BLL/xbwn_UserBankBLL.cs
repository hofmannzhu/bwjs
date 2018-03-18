using XBWN.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBWN.BLL
{
    /// <summary>
    /// 信博维诺用户银行卡表
    /// </summary>
    public partial class xbwn_UserBankBLL
    {
        private readonly xbwn_UserBankDAL dal = new xbwn_UserBankDAL();

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(XBWN.Model.xbwn_UserBank model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(XBWN.Model.xbwn_UserBank model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XBWN.Model.xbwn_UserBank GetModel(int UserBankId)
        {

            return dal.GetModel(UserBankId);
        }

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
        public List<XBWN.Model.xbwn_UserBank> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XBWN.Model.xbwn_UserBank> DataTableToList(DataTable dt)
        {
            List<XBWN.Model.xbwn_UserBank> modelList = new List<XBWN.Model.xbwn_UserBank>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XBWN.Model.xbwn_UserBank model;
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
        public XBWN.Model.xbwn_UserBank DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        #endregion

        #region  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XBWN.Model.xbwn_UserBank> GetModelList(string realName, string idNo, string telNo, int flag)
        {
            DataSet ds = dal.GetList(string.Format("RealName='{0}' and IdNo='{1}' and TelNo='{2}' and Flag={3}", realName, idNo, telNo, flag));
            return DataTableToList(ds.Tables[0]);
        }
        public XBWN.Model.xbwn_UserBank GetModel(string realName,string idNo,string telNo,int flag)
        {
            return dal.GetModel(realName, idNo, telNo, flag);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(string smsCode, int flag, string no)
        {
            return dal.Update(smsCode, flag, no);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserBankId, int userId)
        {
            return dal.Delete(UserBankId, userId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string UserBankIdlist, int userId)
        {
            return dal.DeleteList(UserBankIdlist, userId);
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
        #endregion  ExtensionMethod
    }
}
