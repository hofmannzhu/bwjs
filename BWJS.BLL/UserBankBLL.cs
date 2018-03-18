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
    /// 用户银行卡
    /// </summary>
    public partial class UserBankBLL
    {
        private readonly UserBankDAL dal = new UserBankDAL();
        public UserBankBLL() { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.UserBank model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.UserBank model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.UserBank GetModel(int UserBankId)
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
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.UserBank> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.UserBank> DataTableToList(DataTable dt)
        {
            List<BWJS.Model.UserBank> modelList = new List<BWJS.Model.UserBank>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BWJS.Model.UserBank model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(dt.Rows[n]);
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.UserBank DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }
        #endregion

        #region  ExtensionMethod
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int userBankId, int userId)
        {

            return dal.Delete(userBankId, userId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string userBankIdlist, int userId)
        {
            return dal.DeleteList(userBankIdlist, userId);
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
        /// 是否存在该记录
        /// </summary>
        /// <param name="userId">商家编号</param>
        /// <param name="cardNumber">银行卡号</param>
        /// <returns></returns>
        public bool ExistsByCardNumber(int userId, string cardNumber)
        {
            return dal.ExistsByCardNumber(userId, cardNumber);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="userBankId">主键</param>
        /// <param name="cardNumber">银行卡号</param>
        /// <returns></returns>
        public bool Exists(int userBankId, string cardNumber)
        {
            return dal.Exists(userBankId, cardNumber);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="userId">商家编号</param>
        /// <param name="userBankId">主键</param>
        /// <param name="cardNumber">银行卡号</param>
        /// <returns></returns>
        public bool Exists(int userId, int userBankId, string cardNumber)
        {
            return dal.Exists(userId, userBankId, cardNumber);
        }
        /// <summary>
        /// 修改默认银行卡
        /// </summary>
        public bool SetDefault(int userBankId, int userId, int editId)
        {
            return dal.SetDefault(userBankId, userId, editId);
        }
        #endregion  ExtensionMethod
    }
}
